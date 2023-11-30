using System.Collections.Generic;
using System.IO;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.Resources;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Cache.Gen3;
using TagTool.Serialization;
using TagTool.Scripting;
using TagTool.Tags;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;
using TagTool.Tags.Resources;
using System.Linq;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command
    {
        public Dictionary<int, CachedTagHaloOnline> ConvertedTags { get; } = new Dictionary<int, CachedTagHaloOnline>();
        public Dictionary<ResourceLocation, Dictionary<int, PageableResource>> CopiedResources { get; } = new Dictionary<ResourceLocation, Dictionary<int, PageableResource>>();
        public Dictionary<ResourceLocation, Stream> SourceResourceStreams = new Dictionary<ResourceLocation, Stream>();
        public Dictionary<ResourceLocation, Stream> DestinationResourceStreams = new Dictionary<ResourceLocation, Stream>();
        public static readonly string[] skipGroups = new[]
        {
            $@"bipd",
            $@"forg",
            $@"gfxt",
            $@"wgtz",
        };

        public static Dictionary<string, List<string>> requiredTags { get; } = new Dictionary<string, List<string>>()
        {
            { 
                "effe", 
                new List<string> 
                { 
                    $@"objects\characters\masterchief\damage_effects\concussive_blast",
                } 
            },
            { 
                "chdt", 
                new List<string> 
                { 
                    $@"ui\chud\spartan", 
                } 
            },
            { 
                "bitm", 
                new List<string> 
                { 
                    $@"ui\halox\main_menu\halo3_logo_ui", 
                } 
            },
        };

        public object RebuildCache(string destCacheDirectory)
        {
            ConvertedTags.Clear();
            CopiedResources.Clear();

            var destDirectory = new DirectoryInfo(destCacheDirectory);

            EmptyDirectory(destDirectory);

            CreateTagCache(destDirectory);

            CacheContext.StringIdCacheFile.CopyTo($@"{destDirectory.FullName}\string_ids.dat");

            var destResourceCaches = new Dictionary<ResourceLocation, ResourceCache>();
            var destCacheContext = new GameCacheHaloOnline(destDirectory);

            SetCacheVersion(destCacheContext, CacheVersion.HaloOnlineED);

            foreach (var value in Enum.GetValues(typeof(ResourceLocation)))
            {
                var location = (ResourceLocation)value;

                if (location == ResourceLocation.None || location == ResourceLocation.RenderModels || location == ResourceLocation.Lightmaps || location == ResourceLocation.Mods)
                    continue;

                CopiedResources[location] = new Dictionary<int, PageableResource>();

                destResourceCaches[location] = CreateResourceCache(destDirectory, location);
                SourceResourceStreams[location] = CacheContext.ResourceCaches.OpenCacheRead(location);
                DestinationResourceStreams[location] = destCacheContext.ResourceCaches.OpenCacheReadWrite(location);
            }

            using (var srcStream = CacheContext.OpenCacheRead())
            using (var destStream = destCacheContext.OpenCacheReadWrite())
            {
                var cfgtTag = CopyTag((CachedTagHaloOnline)CacheContext.TagCache.FindFirstInGroup("cfgt"), CacheContext, srcStream, destCacheContext, destStream);

                var modgTag = destCacheContext.TagCache.AllocateTag<ModGlobalsDefinition>($@"multiplayer\mod_globals");
                var modg = new ModGlobalsDefinition();
                destCacheContext.Serialize(destStream, modgTag, modg);

                var forgTag = destCacheContext.TagCache.AllocateTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals");
                var forg = new ForgeGlobalsDefinition();
                destCacheContext.Serialize(destStream, forgTag, forg);

                var mlstTag = destCacheContext.TagCache.AllocateTag<MapList>($@"ui\eldewrito\maps");
                var mlst = new MapList();
                destCacheContext.Serialize(destStream, mlstTag, mlst);

                var cfgt = destCacheContext.Deserialize<CacheFileGlobalTags>(destStream, cfgtTag);
                cfgt.GlobalTags = new List<TagReferenceBlock>()
                {
                    new TagReferenceBlock()
                    {
                        Instance = destCacheContext.TagCache.GetTag<Globals>($@"globals\globals"),
                    },
                    new TagReferenceBlock()
                    {
                        Instance = destCacheContext.TagCache.GetTag<ModGlobalsDefinition>($@"multiplayer\mod_globals"),
                    },
                    new TagReferenceBlock()
                    {
                        Instance = destCacheContext.TagCache.GetTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals"),
                    },
                    new TagReferenceBlock()
                    {
                        Instance = destCacheContext.TagCache.GetTag<MapList>($@"ui\eldewrito\maps"),
                    },
                };
                destCacheContext.Serialize(destStream, cfgtTag, cfgt);

                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag == null || !tag.IsInGroup("scnr"))
                        continue;

                    CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                }

                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    foreach (var requiredTag in requiredTags)
                    {
                        var requiredTagType = requiredTag.Key;
                        var requiredTagNames = requiredTag.Value;

                        foreach (var requiredTagName in requiredTagNames) 
                        {
                            if (tag.IsInGroup(requiredTagType) && tag.Name == requiredTagName)
                            {
                                CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            }
                        }
                    }
                }

                foreach (var tag in destCacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("sbsp"))
                    {
                        var sbsp = destCacheContext.Deserialize<ScenarioStructureBsp>(destStream, tag);
                        destCacheContext.ResourceCaches.ReplaceResource(sbsp.CollisionBspResource.HaloOnlinePageableResource, GetSbspCollisionData(tag.Name, srcStream));
                        destCacheContext.ResourceCaches.ReplaceResource(sbsp.PathfindingResource.HaloOnlinePageableResource, GetSbspPathfindingData(tag.Name, srcStream));
                        destCacheContext.Serialize(destStream, tag, sbsp);
                    }
                }
            }

            destCacheContext.SaveTagNames();

            foreach (var entry in SourceResourceStreams)
                entry.Value.Close();

            foreach (var entry in DestinationResourceStreams)
                entry.Value.Close();

            return true;
        }

        // Creates a new tags.dat file
        public TagCache CreateTagCache(DirectoryInfo directory)
        {
            var file = new FileInfo(Path.Combine(directory.FullName, "tags.dat"));

            TagCache cache = null;

            using (var stream = file.Create())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(0);
                writer.Write(32);
                writer.Write(0);
                writer.Write(0);
                writer.Write(0x01D0631BCC791704);
                writer.Write(0);
                writer.Write(0);
            }

            return cache;
        }

        // Creates a new resource file
        public ResourceCache CreateResourceCache(DirectoryInfo directory, ResourceLocation location)
        {
            var file = new FileInfo(Path.Combine(directory.FullName, ResourceCachesHaloOnline.ResourceCacheNames[location]));

            ResourceCache cache = null;

            using (var stream = file.Create())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(0);
                writer.Write(32);
                writer.Write(0);
                writer.Write(0);
                writer.Write(0x01D0631BCC92931B);
                writer.Write(0);
                writer.Write(0);
            }

            return cache;
        }

        private CachedTagHaloOnline CopyTag(CachedTagHaloOnline srcTag, GameCacheHaloOnline srcCacheContext, Stream srcStream, GameCacheHaloOnline destCacheContext, Stream destStream)
        {
            if (skipGroups.Any(tag => srcTag.IsInGroup(tag)))
                return null;

            if (srcTag.Name.Contains($@"objects\characters\masterchief\mp_masterchief\armor\"))
                return null;

            if (ConvertedTags.ContainsKey(srcTag.Index))
                return ConvertedTags[srcTag.Index];

            var structureType = srcCacheContext.TagCache.TagDefinitions.GetTagDefinitionType(srcTag.Group);
            var srcContext = new HaloOnlineSerializationContext(srcStream, srcCacheContext, srcTag);
            var tagData = srcCacheContext.Deserializer.Deserialize(srcContext, structureType);

            CachedTagHaloOnline destTag = null;

            for (var i = 0; i < destCacheContext.TagCacheGenHO.Tags.Count; i++)
            {
                if (destCacheContext.TagCacheGenHO.Tags[i] == null)
                {
                    destCacheContext.TagCacheGenHO.Tags[i] = destTag = new CachedTagHaloOnline(i, (TagGroupGen3)srcTag.Group);
                    break;
                }
            }

            if (destTag == null)
                destTag = (CachedTagHaloOnline)destCacheContext.TagCacheGenHO.AllocateTag(srcTag.Group);

            ConvertedTags[srcTag.Index] = destTag;

            if (srcTag.Name != null)
                destTag.Name = srcTag.Name;

            tagData = CopyData(tagData, srcCacheContext, srcStream, destCacheContext, destStream);

            if (structureType == typeof(Scenario))
                CopyScenario((Scenario)tagData);

            var destContext = new HaloOnlineSerializationContext(destStream, destCacheContext, destTag);
            destCacheContext.Serializer.Serialize(destContext, tagData);

            return destTag;
        }

        private object CopyData(object data, GameCacheHaloOnline srcCacheContext, Stream srcStream, GameCacheHaloOnline destCacheContext, Stream destStream)
        {
            if (data == null)
                return null;

            var type = data.GetType();

            if (type.IsPrimitive)
                return data;

            if (type == typeof(CachedTagHaloOnline))
                return CopyTag((CachedTagHaloOnline)data, srcCacheContext, srcStream, destCacheContext, destStream);

            if (type == typeof(PageableResource))
                return CopyResource((PageableResource)data, srcCacheContext, destCacheContext);

            if (type.IsArray)
                return CopyArray((Array)data, srcCacheContext, srcStream, destCacheContext, destStream);

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                return CopyList(data, type, srcCacheContext, srcStream, destCacheContext, destStream);

            if (type.IsSubclassOf(typeof(TagStructure)))
                return CopyStructure((TagStructure)data, type, srcCacheContext, srcStream, destCacheContext, destStream);

            return data;
        }

        private Array CopyArray(Array array, GameCacheHaloOnline srcCacheContext, Stream srcStream, GameCacheHaloOnline destCacheContext, Stream destStream)
        {
            if (array.GetType().GetElementType().IsPrimitive)
                return array;

            for (var i = 0; i < array.Length; i++)
            {
                var oldValue = array.GetValue(i);
                var newValue = CopyData(oldValue, srcCacheContext, srcStream, destCacheContext, destStream);
                array.SetValue(newValue, i);
            }

            return array;
        }

        private object CopyList(object list, Type type, GameCacheHaloOnline srcCacheContext, Stream srcStream, GameCacheHaloOnline destCacheContext, Stream destStream)
        {
            if (type.GenericTypeArguments[0].IsPrimitive)
                return list;

            var count = (int)type.GetProperty("Count").GetValue(list);
            var getItem = type.GetMethod("get_Item");
            var setItem = type.GetMethod("set_Item");

            for (var i = 0; i < count; i++)
            {
                var oldValue = getItem.Invoke(list, new object[] { i });
                var newValue = CopyData(oldValue, srcCacheContext, srcStream, destCacheContext, destStream);

                setItem.Invoke(list, new object[] { i, newValue });
            }

            return list;
        }

        private object CopyStructure(TagStructure data, Type type, GameCacheHaloOnline srcCacheContext, Stream srcStream, GameCacheHaloOnline destCacheContext, Stream destStream)
        {
            foreach (var field in data.GetTagFieldEnumerable(srcCacheContext.Version, srcCacheContext.Platform))
                field.SetValue(data, CopyData(field.GetValue(data), srcCacheContext, srcStream, destCacheContext, destStream));

            return data;
        }

        private PageableResource CopyResource(PageableResource pageable, GameCacheHaloOnline srcCacheContext, GameCacheHaloOnline destCacheContext)
        {
            if (pageable == null || pageable.Page.Index < 0 || !pageable.GetLocation(out var location))
                return null;

            ResourceLocation newLocation;

            switch (pageable.Resource.ResourceType)
            {
                case TagResourceTypeGen3.Bitmap:
                    newLocation = ResourceLocation.Textures;
                    break;

                case TagResourceTypeGen3.BitmapInterleaved:
                    newLocation = ResourceLocation.TexturesB;
                    break;

                case TagResourceTypeGen3.RenderGeometry:
                    newLocation = ResourceLocation.Resources;
                    break;

                case TagResourceTypeGen3.Sound:
                    newLocation = ResourceLocation.Audio;
                    break;

                default:
                    newLocation = ResourceLocation.ResourcesB;
                    break;
            }

            if (pageable.Page.CompressedBlockSize > 0)
            {
                var index = pageable.Page.Index;

                if (CopiedResources[location].ContainsKey(index))
                    return CopiedResources[location][index];

                var srcResCache = srcCacheContext.ResourceCaches.GetResourceCache(location);
                var dstResCache = destCacheContext.ResourceCaches.GetResourceCache(newLocation);

                var data = srcResCache.ExtractRaw(SourceResourceStreams[location], index, pageable.Page.CompressedBlockSize);

                pageable.ChangeLocation(newLocation);
                pageable.Page.Index = dstResCache.AddRaw(DestinationResourceStreams[newLocation], data);

                CopiedResources[location][index] = pageable;
            }

            return pageable;
        }

        private bool ScriptExpressionIsValue(HsSyntaxNode expr)
        {
            switch (expr.Flags)
            {
                case HsSyntaxNodeFlags.ParameterReference:
                    return true;

                case HsSyntaxNodeFlags.Expression:
                    if ((int)expr.ValueType.HaloOnline > 0x4)
                        return true;
                    else
                        return false;

                case HsSyntaxNodeFlags.ScriptReference: // The opcode is the tagblock index of the script it uses, so ignore
                case HsSyntaxNodeFlags.GlobalsReference: // The opcode is the tagblock index of the global it uses, so ignore
                case HsSyntaxNodeFlags.Group:
                    return false;

                default:
                    return false;
            }
        }

        private void CopyScriptTagReferenceExpressionData(HsSyntaxNode expr)
        {
            var srcTagIndex = BitConverter.ToInt32(expr.Data, 0);
            int destTagIndex;
            if (ConvertedTags.TryGetValue(srcTagIndex, out CachedTagHaloOnline tag))
            {
                destTagIndex = tag.Index;
            }
            else
            {
                destTagIndex = -1;
            }
            var newData = BitConverter.GetBytes(destTagIndex);
            expr.Data = newData;
        }

        private void CopyScenario(Scenario scnrDefinition)
        {
            foreach (var expr in scnrDefinition.ScriptExpressions)
            {
                if (!ScriptExpressionIsValue(expr))
                    continue;

                switch (expr.ValueType.HaloOnline)
                {
                    case HsType.HaloOnlineValue.Sound:
                    case HsType.HaloOnlineValue.Effect:
                    case HsType.HaloOnlineValue.Damage:
                    case HsType.HaloOnlineValue.LoopingSound:
                    case HsType.HaloOnlineValue.AnimationGraph:
                    case HsType.HaloOnlineValue.DamageEffect:
                    case HsType.HaloOnlineValue.ObjectDefinition:
                    case HsType.HaloOnlineValue.Bitmap:
                    case HsType.HaloOnlineValue.Shader:
                    case HsType.HaloOnlineValue.RenderModel:
                    case HsType.HaloOnlineValue.StructureDefinition:
                    case HsType.HaloOnlineValue.LightmapDefinition:
                    case HsType.HaloOnlineValue.CinematicDefinition:
                    case HsType.HaloOnlineValue.CinematicSceneDefinition:
                    case HsType.HaloOnlineValue.BinkDefinition:
                    case HsType.HaloOnlineValue.AnyTag:
                    case HsType.HaloOnlineValue.AnyTagNotResolving:
                        CopyScriptTagReferenceExpressionData(expr);
                        break;

                    default:
                        break;
                }
            }
        }

        private StructureBspTagResources GetSbspCollisionData(string sbspTag, Stream srcStream)
        {
            StructureBspTagResources collisionData = null;

            var tag = CacheContext.TagCache.GetTag<ScenarioStructureBsp>(sbspTag);
            var sbsp = CacheContext.Deserialize<ScenarioStructureBsp>(srcStream, tag);
            collisionData = CacheContext.ResourceCache.GetStructureBspTagResources(sbsp.CollisionBspResource);

            return collisionData;
        }

        private StructureBspCacheFileTagResources GetSbspPathfindingData(string sbspTag, Stream srcStream)
        {
            StructureBspCacheFileTagResources pathfindingData = null;

            var tag = CacheContext.TagCache.GetTag<ScenarioStructureBsp>(sbspTag);
            var sbsp = CacheContext.Deserialize<ScenarioStructureBsp>(srcStream, tag);
            pathfindingData = CacheContext.ResourceCache.GetStructureBspCacheFileTagResources(sbsp.PathfindingResource);

            return pathfindingData;
        }

        // Retargets the cache (Its bascially the equivalent of the restart command)
        public void RetargetCache(string cache)
        {
            var newFileInfo = new FileInfo(cache + "\\tags.dat");
            Cache = GameCache.Open(newFileInfo);
            CacheContext = Cache as GameCacheHaloOnline;
            ContextStack.Push(TagCacheContextFactory.Create(ContextStack, Cache));
        }

        // Copies over required files (map files required for updating map files)
        public void MoveFontPackage(string path)
        {
            Directory.CreateDirectory($@"{path}\fonts");

            if (!File.Exists($@"{path}\fonts\font_package.bin"))
            {
                File.Copy($@"{Program.TagToolDirectory}\Tools\BaseCache\Fonts\Upscaled_HO\font_package.bin", $@"{path}\fonts\font_package.bin");
            }
            else 
            {
                new TagToolWarning($@"Font Package Detected in Specified Directory! Replacing Anyway.");
                File.Copy($@"{Program.TagToolDirectory}\Tools\BaseCache\Fonts\Upscaled_HO\font_package.bin", $@"{path}\fonts\font_package.bin", true);
            }
        }

        public void EmptyDirectory(DirectoryInfo directoryInfo) 
        {
            string[] remove = { "map", "dat", "csv" };

            if (directoryInfo.GetFiles().Any(x => x.FullName.EndsWith(".map") || x.FullName.EndsWith(".dat") || x.FullName.EndsWith(".csv"))) 
            {
                new TagToolWarning($@"Cache Detected in Specified Directory! Replacing Anyway.");

                foreach (string fileType in remove)
                {
                    FileInfo[] files = directoryInfo.GetFiles("*." + fileType);

                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                }
            }
        }

        public void SetCacheVersion(GameCacheHaloOnline cache, CacheVersion version)
        {
            cache.Version = version;
            cache.TagCacheGenHO.Version = version;
            cache.TagCacheGenHO.Header.CreationTime = CacheVersionDetection.GetTimestamp(version);
            cache.StringTableHaloOnline.Version = version;
            cache.Serializer = new TagSerializer(version, CachePlatform.Original);
            cache.Deserializer = new TagDeserializer(version, CachePlatform.Original);
            cache.ResourceCaches = new ResourceCachesHaloOnline(cache);
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }
    }
}