using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Commands.Files;
using TagTool.Commands.Porting;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Porting
{
    public abstract partial class PortingContext
    {
        protected readonly GameCacheHaloOnlineBase CacheContext;
        protected readonly GameCache BlamCache;
        protected readonly TagDefinitionCache TagDefinitionCache = new();

        protected readonly BlockingCollection<Action> DeferredActions = [];

        protected readonly Dictionary<Tag, List<string>> ReplacedTags = [];
        protected readonly Dictionary<int, CachedTag> PortedTags = [];
        protected readonly Dictionary<uint, StringId> PortedStringIds = [];
        protected readonly Dictionary<Tag, CachedTag> DefaultTags = [];

        private PortingFlags Flags { get; set; } = PortingFlags.Default;
        private bool ScenarioPort = false;

        protected PortingContext(GameCacheHaloOnlineBase cacheContext, GameCache blamCache)
        {
            CacheContext = cacheContext;
            BlamCache = blamCache;

            foreach (var tagType in CacheContext.TagCache.TagDefinitions.Types.Keys)
                DefaultTags[tagType.Tag] = CacheContext.TagCache.FindFirstInGroup(tagType.Tag);

            InitAsync();
        }

        /// <summary>
        /// Ports a tag from the source cache to the destination cache, analogous to the PortTag command
        /// </summary>
        /// <remarks>
        /// For better performance for bulk conversions consider using <see cref="ConvertTag"/> instead, and call <see cref="Finish"/> when done.
        /// </remarks>
        /// <param name="tagToPort">Tag to be port</param>
        /// <param name="portingFlags">Various flags that control porting</param>
        /// <param name="optMpObjectParams">Optional multiplayer object parameters</param>
        /// <returns></returns>
        public CachedTag PortTag(CachedTag tagToPort, PortingFlags portingFlags = PortingFlags.Default, string[] optMpObjectParams = null)
        {
            return PortTag([tagToPort], portingFlags, optMpObjectParams)[0];
        }

        /// <summary>
        /// Ports a list of tags from the source cache to the destination cache, analogous to the PortTag command
        /// </summary>
        /// <remarks>
        /// For better performance for bulk conversions consider using <see cref="ConvertTag"/> instead, and call <see cref="Finish"/> when done.
        /// </remarks>
        /// <param name="tagsToPort">List of tags to be ported</param>
        /// <param name="portingFlags">Various flags that control porting</param>
        /// <param name="optMpObjectParams">Optional multiplayer object parameters</param>
        /// <returns></returns>
        public List<CachedTag> PortTag(IEnumerable<CachedTag> tagsToPort, PortingFlags portingFlags = PortingFlags.Default, string[] optMpObjectParams = null)
        {
            List<CachedTag> resultTags = [];

            PortingFlags oldFlags = Flags;
            Flags = portingFlags;

            var initialStringIdCount = CacheContext.StringTableHaloOnline.Count;

            try
            {
                using Stream cacheStream = CacheContext.OpenCacheReadWrite();
                using Stream blamCacheStream = BlamCache is GameCacheModPackage package ? package.OpenCacheRead(cacheStream) : BlamCache.OpenCacheRead();

                foreach (var blamTag in tagsToPort)
                {
                    CachedTag edTag = ConvertTag(cacheStream, blamCacheStream, blamTag);
                    resultTags.Add(edTag);

                    if (FlagIsSet(PortingFlags.MPobject))
                        TestForgePaletteCompatible(cacheStream, blamTag, optMpObjectParams);
                }

                Finish(cacheStream, blamCacheStream);
                return resultTags;
            }
            finally
            {
                Reset();
                Flags = oldFlags;

                if (initialStringIdCount != CacheContext.StringTable.Count)
                    CacheContext.SaveStrings();

                CacheContext.SaveTagNames();
            }
        }

        /// <summary>
        /// Checks whether a tag can be ported and optionally returns an alternative tag
        /// </summary>
        /// <param name="blamTag">Tag to be ported</param>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Source cache stream</param>
        /// <param name="resultTag">Alternative tag to use</param>
        /// <returns>True if the tag can be ported, otherwise resultTag will be used</returns>
        protected virtual bool TagIsValid(CachedTag blamTag, Stream cacheStream, Stream blamCacheStream, out CachedTag resultTag)
        {
            resultTag = null;
            return true;
        }

        /// <summary>
        /// Ports a tag from the source cache to the destination cache
        /// </summary>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Source cache stream</param>
        /// <param name="blamTag">Tag to be converted</param>
        /// <param name="blamDefinition">Optional pre-deserialized tag definition. Useful for making changes to a tag prior to porting</param>
        /// <returns>The resulting the tag from the destination cache</returns>
        public CachedTag ConvertTag(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, object blamDefinition = null)
        {
            if (blamTag == null)
                return null;

            CachedTag result = null;
#if !DEBUG
            try
            {
#endif
            if (PortedTags.ContainsKey(blamTag.Index))
                return PortedTags[blamTag.Index];

            if (TagIsValid(blamTag, cacheStream, blamCacheStream, out result))
            {
                if (blamTag.Name == null)
                {
                    blamTag.Name = $"{blamTag.Group.Tag}_" + $"{blamTag.Index:X4}";
                }
                var oldFlags = Flags;
                result = ConvertTagInternal(cacheStream, blamCacheStream, blamTag, blamDefinition);

                if (result == null)
                    new TagToolWarning($"null tag allocated for reference \"{blamTag.Name}.{blamTag.Group}\"");

                Flags = oldFlags;
            }
            else if (blamTag.Name != null && blamTag.IsInGroup("bitm"))
            {
                if (CacheContext.TagCache.TryGetTag($"{blamTag.Name}.{blamTag.Group}", out result))
                    new TagToolWarning($"using bitm tag reference \"{blamTag.Name}.{blamTag.Group}\" from source cache");
            }
#if !DEBUG
            }
            catch (Exception e)
            {
                new TagToolError(CommandError.CustomError, $"{e.GetType().Name} while porting '{blamTag.Name}.{blamTag.Group.Tag.ToString()}':");
                throw;
            }
#endif
            PortedTags[blamTag.Index] = result;
            return result;
        }

        protected virtual CachedTag ConvertTagInternal(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, object blamDefinition)
        {
            ProcessDeferredActions();

            if (blamTag == null)
                return null;

            var groupTag = blamTag.Group.Tag;

            //
            // Check to see if the ElDorado tag exists
            //

            CachedTag edTag = null;

            TagGroupGen3 edGroup = (TagGroupGen3)blamTag.Group;

            if (!CacheContext.TagCache.TagDefinitions.TagDefinitionExists(blamTag.Group))
            {
                Console.WriteLine($"Tag group {blamTag.Group} does not exist in destination cache! Returning null!");
                return null;
            }

            var wasReplacing = FlagIsSet(PortingFlags.Replace);
            var wasNew = FlagIsSet(PortingFlags.New);
            var wasSingle = FlagIsSet(PortingFlags.Recursive);

            foreach (var instance in CacheContext.TagCache.TagTable)
            {
                if (instance == null || !instance.IsInGroup(groupTag) || instance.Name == null || instance.Name != blamTag.Name)
                    continue;

                if (instance.IsInGroup("rm  ") && !FlagIsSet(PortingFlags.Ms30) && instance.Name.StartsWith("ms30"))
                    continue;

                if (ReplacedTags.TryGetValue(groupTag, out List<string> replacedTagNames) && replacedTagNames.Contains(blamTag.Name))
                {
                    if (instance.Group.Tag == groupTag)
                        return instance;
                }
                else if (!FlagIsSet(PortingFlags.New))
                {
                    if (FlagIsSet(PortingFlags.Replace) && !PortingConstants.DoNotReplaceGroups.Contains(instance.Group.Tag)
                        && !DoNotReplaceGroupsCommand.UserDefinedDoNotReplaceGroups.Contains(instance.Group.Tag.ToString()))
                    {
                        if (!FlagIsSet(PortingFlags.Recursive))
                            ToggleFlags(PortingFlags.Replace | PortingFlags.Recursive);

                        edTag = instance;
                        break;
                    }
                    else
                    {
                        if (FlagIsSet(PortingFlags.Merge))
                        {
                            MergeTags(cacheStream, blamCacheStream, blamTag, instance);
                        }

                        if (!ReplacedTags.ContainsKey(groupTag))
                            ReplacedTags[groupTag] = new List<string>();

                        ReplacedTags[groupTag].Add(blamTag.Name);
                        return instance;
                    }
                }
            }

            if (FlagIsSet(PortingFlags.New) && !FlagIsSet(PortingFlags.Recursive) && wasSingle)
                ToggleFlags(PortingFlags.New | PortingFlags.Recursive);

            //
            // If isReplacing is true, check current tags if there is an existing instance to replace
            //

            var replacedTags = ReplacedTags.ContainsKey(groupTag) ?
                (ReplacedTags[groupTag] ?? new List<string>()) :
                new List<string>();

            replacedTags.Add(blamTag.Name);
            ReplacedTags[groupTag] = replacedTags;

            //
            // Allocate Eldorado Tag
            //

            if (edTag == null)
            {
                if (FlagIsSet(PortingFlags.UseNull))
                {
                    var i = CacheContext.TagCache.TagTable.ToList().FindIndex(n => n == null);

                    if (i >= 0)
                        CacheContext.TagCacheGenHO.Tags[i] = (CachedTagHaloOnline)(edTag = (new CachedTagHaloOnline(i, edGroup)));
                }
                else
                {
                    edTag = CacheContext.TagCache.AllocateTag(edGroup);
                }
            }

            edTag.Name = blamTag.Name;

            if (blamTag.IsInGroup("scnr"))
                ScenarioPort = true;

            //
            // Load and convert the Blam tag definition
            //

            if (blamDefinition == null)
                blamDefinition = BlamCache.Deserialize(blamCacheStream, blamTag);

            bool isDeferred = false;
            blamDefinition = ConvertDefinition(cacheStream, blamCacheStream, blamTag, edTag, blamDefinition, out CachedTag altTag, out isDeferred);
            if (blamDefinition == null && altTag != null)
                return altTag;

            //
            // Finalize and serialize the new ElDorado tag definition
            //

            if (blamDefinition == null)
            {
                CacheContext.TagCacheGenHO.Tags[edTag.Index] = null;
                return null;
            }

            if (!isDeferred)
            {
                TagDefinitionCache.Evict(edTag);
                CacheContext.Serialize(cacheStream, edTag, blamDefinition);

                if (FlagIsSet(PortingFlags.Print))
                    Console.WriteLine($"['{edTag.Group.Tag}', 0x{edTag.Index:X4}] {edTag.Name}.{(edTag.Group as TagGroupGen3).Name}");
            }

            return edTag;
        }

        /// <summary>
        /// Merges blamTag into edTag
        /// </summary>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Source cache stream</param>
        /// <param name="blamTag">Tag to be merged</param>
        /// <param name="edTag">Tag to merge into</param>
        protected virtual void MergeTags(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, CachedTag edTag)
        {
        }

        /// <summary>
        /// Converts a tag definition
        /// </summary>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Source cache stream</param>
        /// <param name="blamTag">Tag to be ported</param>
        /// <param name="edTag">Tag that is being ported to</param>
        /// <param name="blamDefinition">Deserialized definition data</param>
        /// <param name="resultTag">Optional alternative tag to use if the data cannot be converted</param>
        /// <param name="isDeferred">Optional boolean that determines whether this tag should be serialized now (false) or later via a deferred action (true)</param>
        /// <returns></returns>
        protected virtual object ConvertDefinition(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, CachedTag edTag, object blamDefinition, out CachedTag resultTag, out bool isDeferred)
        {
            isDeferred = false;
            resultTag = null;
            return ConvertData(cacheStream, blamCacheStream, blamDefinition, blamDefinition, blamTag.Name);
        }

        /// <summary>
        /// Converts a <see cref="TagStructure"/> from the source cache to the destination cache
        /// </summary>
        /// <remarks>
        /// This should only be used if all you want to do is convert the fields and nothing else. Consider using <see cref="ConvertData"/> or <see cref="ConvertDefinition(Stream, Stream, CachedTag, CachedTag, object, out CachedTag, out bool)"/> If it'a tag definition
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheStream"></param>
        /// <param name="blamCacheStream"></param>
        /// <param name="data"></param>
        /// <param name="definition"></param>
        /// <param name="blamTagName"></param>
        /// <returns></returns>
        protected T ConvertStructure<T>(Stream cacheStream, Stream blamCacheStream, T data, object definition, string blamTagName) where T : TagStructure
        {
            foreach (var tagFieldInfo in TagStructure.GetTagFieldEnumerable(data.GetType(), CacheContext.Version, CacheContext.Platform))
            {
                var attributes = tagFieldInfo.FieldInfo.GetCustomAttributes(false).OfType<TagFieldAttribute>().ToList();
                if (attributes.Count == 0 || attributes.Any(attr => CacheVersionDetection.TestAttribute(attr, BlamCache.Version, BlamCache.Platform)))
                {
                    // skip the field if no conversion is needed
                    if ((tagFieldInfo.FieldType.IsValueType && tagFieldInfo.FieldType != typeof(StringId)) || tagFieldInfo.FieldType == typeof(string))
                    {
                        if (!tagFieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.GlobalMaterial))
                            continue;
                    }

                    var oldValue = tagFieldInfo.GetValue(data);
                    if (oldValue is null)
                        continue;

                    // convert the field
                    object newValue = ConvertFieldvalue(cacheStream, blamCacheStream, tagFieldInfo, oldValue, definition, blamTagName);
                    tagFieldInfo.SetValue(data, newValue);
                }
            }
            return data;
        }

        /// <summary>
        /// Converts arbitrary data
        /// </summary>
        /// <remarks>
        /// Avoid using this on tag definitions, use <see cref="ConvertDefinition"/> instead.
        /// </remarks>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Ssource cache stream</param>
        /// <param name="data">Data to be converted</param>
        /// <param name="definition">Current tag definition</param>
        /// <param name="blamTagName">Current tag name</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public virtual object ConvertData(Stream cacheStream, Stream blamCacheStream, object data, object definition, string blamTagName)
        {
            switch (data)
            {
                case TagResourceReference _:
                    return data;

                case StringId stringId:
                    stringId = ConvertStringId(stringId);
                    return stringId;

                case null:  // no conversion necessary
                case ValueType _:   // no conversion necessary
                case string _:  // no conversion necessary
                    return data;

                case CachedTag tag:
                    {
                        if (IgnoreBlamTagCommand.UserDefinedIgnoredBlamTagsIndicies.Contains(tag.Index))
                        {
                            //find equivalent in base cache otherwise use null
                            foreach (var instance in CacheContext.TagCache.FindAllInGroup(tag.Group.Tag))
                            {
                                if (instance == null || instance.Name == null)
                                    continue;

                                if (instance.Name == tag.Name)
                                    return instance;
                            }

                            return null;
                        }

                        if (!FlagIsSet(PortingFlags.Recursive))
                        {
                            foreach (var instance in CacheContext.TagCache.FindAllInGroup(tag.Group.Tag))
                            {
                                if (instance == null || instance.Name == null)
                                    continue;

                                if (instance.Name == tag.Name)
                                    return instance;
                            }

                            return null;
                        }

                        return ConvertTag(cacheStream, blamCacheStream, (CachedTag)data);
                    }

                case Array _:
                case IList _: // All arrays and List<T> implement IList, so we should just use that
                    data = ConvertCollection(cacheStream, blamCacheStream, data as IList, definition, blamTagName);
                    return data;

                case TagStructure tagStructure: // much faster to pattern match a type than to check for custom attributes.
                    tagStructure = ConvertStructure(cacheStream, blamCacheStream, tagStructure, definition, blamTagName);
                    return data;

                case PlatformSignedValue _:
                case PlatformUnsignedValue _:
                    return data;

                default:
                    new TagToolWarning($"Unhandled type in `ConvertData`: {data.GetType().Name} (probably harmless).");
                    break;
            }

            return data;
        }

        /// <summary>
        /// Converts a field value
        /// </summary>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Source cache stream</param>
        /// <param name="tagFieldInfo">TagFieldInfo of the field to be converted</param>
        /// <param name="value">Value of the field to be converted</param>
        /// <param name="definition">Current tag definition</param>
        /// <param name="blamTagName">Current tag name</param>
        /// <returns></returns>
        protected virtual object ConvertFieldvalue(Stream cacheStream, Stream blamCacheStream, TagFieldInfo tagFieldInfo, object value, object definition, string blamTagName)
        {
            return ConvertData(cacheStream, blamCacheStream, value, definition, blamTagName);
        }

        private IList ConvertCollection(Stream cacheStream, Stream blamCacheStream, IList data, object definition, string blamTagName)
        {
            // return early where possible
            if (data is null || data.Count == 0)
                return data;

            if (data[0] == null)
                return data;

            var type = data[0].GetType();
            if ((type.IsValueType && type != typeof(StringId)) || type == typeof(string))
                return data;

            // convert each element
            for (var i = 0; i < data.Count; i++)
            {
                var oldValue = data[i];
                var newValue = ConvertData(cacheStream, blamCacheStream, oldValue, definition, blamTagName);
                data[i] = newValue;
            }

            return data;
        }

        /// <summary>
        /// Converts a StringId from the source cache to destination cache
        /// </summary>
        /// <remarks>
        /// If the StringId exists in the destination cache exists then it is returned, otherwise one will be allocated
        /// </remarks>
        /// <param name="stringId">String id to convert</param>
        /// <returns>The existing or newly allocated string id in the destination cache</returns>
        protected StringId ConvertStringId(StringId stringId)
        {
            if (stringId == StringId.Invalid)
                return stringId;

            if (PortedStringIds.ContainsKey(stringId.Value))
                return PortedStringIds[stringId.Value];

            var value = BlamCache.StringTable.GetString(stringId);
            var edStringId = CacheContext.StringTable.GetStringId(value);


            if (edStringId != StringId.Invalid)
                return PortedStringIds[stringId.Value] = edStringId;

            if (edStringId == StringId.Invalid || !CacheContext.StringTable.Contains(value))
                return PortedStringIds[stringId.Value] = CacheContext.StringTable.AddString(value);

            return PortedStringIds[stringId.Value];
        }

        /// <summary>
        /// Should be called when finished with the <see cref="PortingContext "/> to finalize any pending tasks
        /// </summary>
        /// <remarks>
        /// This does not need to be called when using <see cref="PortTag "/> exclusively
        /// </remarks>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Sorce cache stream</param>
        public virtual void Finish(Stream cacheStream, Stream blamCacheStream)
        {
            WaitForPendingTasks();
            ProcessDeferredActions();

            if (ScenarioPort)
            {
                // TODO: consider removing 
                if (ScenarioPort && FlagIsSet(PortingFlags.UpdateMapFiles))
                    new UpdateMapFilesCommand(CacheContext).Execute(new List<string> { });
            }
        }

        /// <summary>
        /// Called to reset the state of the context after a call to PortTag regardless of whether it succeeds or fails
        /// </summary>
        protected virtual void Reset()
        {
            WaitForPendingTasks();
            while (DeferredActions.TryTake(out _)) { }
            ScenarioPort = false;
        }

        protected void ProcessDeferredActions()
        {
            while (DeferredActions.TryTake(out Action action))
            {
                action();
            }
        }
    }
}
