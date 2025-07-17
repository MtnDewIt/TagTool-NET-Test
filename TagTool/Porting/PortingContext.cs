using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Commands.Porting;
using TagTool.Common;
using TagTool.Porting.Gen3;
using TagTool.Porting.HaloOnline;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Porting
{
    public abstract partial class PortingContext : IDisposable
    {
        public readonly GameCacheHaloOnlineBase CacheContext;
        public readonly GameCache BlamCache;
        protected readonly TagDefinitionCache TagDefinitionCache = new();
        protected readonly BlockingCollection<Action> DeferredActions = [];
        private readonly HashSet<int> ReplacedTags = [];
        private readonly HashSet<int> VisitedTags = [];
        private readonly Dictionary<int, CachedTag> PortedTags = [];
        private readonly Dictionary<uint, StringId> PortedStringIds = [];
        private bool ShouldGenerateCampaignFile = false;

        public PortingFlags Flags = PortingFlags.Default;
        public List<Tag> DoNotReplaceGroups = [];
        public PortingOptions Options = new();

        protected PortingContext(GameCacheHaloOnlineBase cacheContext, GameCache blamCache)
        {
            CacheContext = cacheContext;
            BlamCache = blamCache;

            InitAsync();
        }

        /// <summary>
        /// Create context for porting from sourceCache to destCache
        /// </summary>
        /// <param name="destCache">Destination cache</param>
        /// <param name="sourceCache">Source cache</param>
        /// <returns>PortingContext</returns>
        /// <exception cref="NotSupportedException">Thrown if the cache is not supported</exception>
        public static PortingContext Create(GameCacheHaloOnlineBase destCache, GameCache sourceCache)
        {
            switch (sourceCache)
            {
                case GameCacheHaloOnlineBase:
                    return new PortingContextHO(destCache, sourceCache);
                case GameCacheGen3:
                    return new PortingContextGen3(destCache, sourceCache);
                default:
                    throw new NotSupportedException($"Porting cache '{sourceCache.DisplayName}' not supported currently");
            }
        }

        /// <summary>
        /// Checks whether a tag can be ported and optionally returns an alternative tag
        /// </summary>
        /// <param name="blamTag">Tag to be ported</param>
        /// <param name="cacheStream">Destination cache stream</param>
        /// <param name="blamCacheStream">Source cache stream</param>
        /// <param name="resultTag">Alternative tag to use</param>
        /// <returns>True if the tag can be ported, otherwise alternativeTag will be used</returns>
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
            ProcessDeferredActions();

            if (blamTag == null)
                return null;

            if (PortedTags.TryGetValue(blamTag.Index, out CachedTag portedTag))
                return portedTag;

            CachedTag result = null;
            if (TagIsValid(blamTag, cacheStream, blamCacheStream, out result))
            {
                result = ConvertTagInternal(cacheStream, blamCacheStream, blamTag, blamDefinition);

                if (result == null)
                    new TagToolWarning($"null tag allocated for reference \"{blamTag}\"");
            }
            else if (blamTag.Name != null && blamTag.IsInGroup("bitm"))
            {
                if (CacheContext.TagCache.TryGetTag($"{blamTag}", out result))
                    new TagToolWarning($"using bitm tag reference \"{blamTag}\" from source cache");
            }

            PortedTags[blamTag.Index] = result;
            return result;
        }

        protected virtual CachedTag ConvertTagInternal(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, object blamDefinition)
        {
            if (blamTag == null)
                return null;

            if (!CacheContext.TagCache.TagDefinitions.TagDefinitionExists(blamTag.Group))
            {
                new TagToolWarning($"Tag group {blamTag.Group} does not exist in destination cache! Returning null!");
                return null;
            }

            CachedTag edTag = null;

            //
            // Check to see if the ElDorado tag exists
            //

            if (!FlagIsSet(PortingFlags.New))
            {
                CachedTag existingTag =  FindExistingTag(blamTag);
                if (existingTag != null)
                {
                    // Avoid re-entrancy
                    if (!VisitedTags.Add(blamTag.Index))
                        return existingTag;

                    if (ShouldReplaceTag(existingTag))
                    {
                        if (!ReplacedTags.Add(blamTag.Index))
                            return existingTag;

                        edTag = existingTag;
                    }
                    else if (FlagIsSet(PortingFlags.Merge))
                    {
                        MergeTags(cacheStream, blamCacheStream, blamTag, existingTag);
                        return existingTag;
                    }
                }
            }
            VisitedTags.Add(blamTag.Index);

            //
            // Allocate Eldorado Tag
            //

            edTag ??= AllocateNewTag(blamTag);
            edTag.Name = blamTag.Name;

            //
            // Load and convert the Blam tag definition
            //

            if (blamDefinition == null)
                blamDefinition = BlamCache.Deserialize(blamCacheStream, blamTag);

            blamDefinition = ConvertDefinition(cacheStream, blamCacheStream, blamTag, edTag, blamDefinition, out bool isDeferred);

            if (blamDefinition == null)
            {
                // TODO: remove edTag from ConvertDefinition so that we don't have this problem
                if (edTag.Index < CacheContext.TagCacheGenHO.Tags.Count - 1)
                    CacheContext.TagCacheGenHO.Tags[edTag.Index] = null;
                else
                    CacheContext.TagCacheGenHO.Tags.RemoveAt(edTag.Index);

                CachedTag fallback = GetFallbackTag(blamTag);
                new TagToolError(CommandError.OperationFailed, $"Failed to convert tag '{blamTag}', using {fallback}");

                return fallback;
            }

            //
            // Finalize and serialize the new ElDorado tag definition
            //

            if (!isDeferred)
            {
                TagDefinitionCache.Evict(edTag);
                CacheContext.Serialize(cacheStream, edTag, blamDefinition);

                if (FlagIsSet(PortingFlags.Print))
                    Console.WriteLine($"['{edTag.Group.Tag}', 0x{edTag.Index:X4}] {edTag}");

                if (blamDefinition is Scenario scnr && FlagIsSet(PortingFlags.UpdateMapFiles))
                {
                    string mapInfoDir = BlamCache.Directory == null ? "" : Path.Combine(BlamCache.Directory.FullName, "info");
                    MapFileUpdater.UpdateMapFile(CacheContext, blamTag, scnr, mapInfoDir);

                    if (scnr.MapType == ScenarioMapType.SinglePlayer)
                        ShouldGenerateCampaignFile = true;
                }
            }

            return edTag;
        }

        private bool ShouldReplaceTag(CachedTag existingTag)
        {
            return FlagIsSet(PortingFlags.Replace)
                    && !PortingConstants.DoNotReplaceGroups.Contains(existingTag.Group.Tag)
                    && !DoNotReplaceGroups.Contains(existingTag.Group.Tag);
        }

        private CachedTag FindExistingTag(CachedTag blamTag)
        {
            // faster than TryGetTag
            foreach (CachedTag instance in CacheContext.TagCache.TagTable)
            {
                if (instance != null && instance.Group.Tag == blamTag.Group.Tag && instance.Name == blamTag.Name)
                    return instance;
            }
            return null;
        }

        protected CachedTag AllocateNewTag(CachedTag blamTag)
        {
            CachedTag edTag = null;

            if (FlagIsSet(PortingFlags.UseNull))
            {
                var i = CacheContext.TagCache.TagTable.ToList().FindIndex(n => n == null);

                if (i >= 0)
                    CacheContext.TagCacheGenHO.Tags[i] = (CachedTagHaloOnline)(edTag = (new CachedTagHaloOnline(i, blamTag.Group)));
            }
            else
            {
                edTag = CacheContext.TagCache.AllocateTag(blamTag.Group);
            }

            return edTag;
        }

        protected virtual CachedTag GetFallbackTag(CachedTag edTag)
        {
            return null;
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
        /// <param name="isDeferred">Optional boolean that determines whether this tag should be serialized now (false) or later via a deferred action (true)</param>
        /// <returns></returns>
        protected virtual object ConvertDefinition(Stream cacheStream, Stream blamCacheStream, CachedTag blamTag, CachedTag edTag, object blamDefinition, out bool isDeferred)
        {
            isDeferred = false;
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
        /// Converts a field portedTag
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
        /// Should be called when finished with the <see cref="PortingContext "/> to finalize any pending tasks and cleanup
        /// </summary>
        /// <remarks>
        /// Consider using <see cref="Dispose"/> or <seealso cref="CreateScope"/>
        /// </remarks>
        /// <param name="saveStrings">Save the string id cache</param>
        public virtual void Finish(bool saveStrings = true)
        {
            WaitForPendingTasks();

            try
            {
                ProcessDeferredActions();
                FinishInternal();

                if (saveStrings)
                    CacheContext.SaveStrings();
                CacheContext.SaveTagNames();

                if (ShouldGenerateCampaignFile)
                    CampaignFileGenerator.GenerateCampaignFile(CacheContext, BlamCache);
            }
            finally
            {
                // discard the queue in case of an exception
                while (DeferredActions.TryTake(out var _)) { }
                TagDefinitionCache.Clear();
                VisitedTags.Clear();
                PortedTags.Clear();
                ShouldGenerateCampaignFile = false;
            }
        }

        /// <summary>
        /// To be implemented by derived classes
        /// </summary>
        /// <remarks>
        /// Implementators should avoid throwing exceptions
        /// </remarks>
        protected virtual void FinishInternal()
        {
        }

        protected void ProcessDeferredActions()
        {
            while (DeferredActions.TryTake(out Action action))
            {
                action();
            }
        }

        /// <summary>
        /// Creates a scope that automatically calls <see cref="Finish"/> when disposed
        /// </summary>
        public IDisposable CreateScope(PortingFlags flags = PortingFlags.Default, bool saveStrings = true)
        {
            return new PortingContextScope(this, flags, saveStrings);
        }

        public void Dispose()
        {
            Finish();
            GC.SuppressFinalize(this);
        }

        private class PortingContextScope : IDisposable
        {
            private PortingContext _context;
            private PortingFlags _oldFlags;
            private bool _saveStrings;

            public PortingContextScope(PortingContext context, PortingFlags flags, bool saveStrings)
            {
                _context = context;
                _oldFlags = _context.Flags;
                _context.Flags = flags;
                _saveStrings = saveStrings;
            }

            public void Dispose()
            {
                _context.Finish(saveStrings: _saveStrings);
                _context.Flags = _oldFlags;
            }
        }
    }
}
