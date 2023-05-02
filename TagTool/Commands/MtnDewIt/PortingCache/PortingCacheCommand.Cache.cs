using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.Resources;
using TagTool.Commands.Files;
using TagTool.Common;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        private Globals MatgDefinition { get; set; } = null;
        private MultiplayerGlobals MulgDefinition { get; set; } = null;

        public Dictionary<int, CachedTagHaloOnline> ConvertedTags { get; } = new Dictionary<int, CachedTagHaloOnline>();
        public Dictionary<ResourceLocation, Dictionary<int, PageableResource>> CopiedResources { get; } = new Dictionary<ResourceLocation, Dictionary<int, PageableResource>>();
        public Dictionary<ResourceLocation, Stream> SourceResourceStreams = new Dictionary<ResourceLocation, Stream>();
        public Dictionary<ResourceLocation, Stream> DestinationResourceStreams = new Dictionary<ResourceLocation, Stream>();

        // These tag types are not copied over when rebuilding the cache
        public static readonly string[] UncleanSkipGroups = new[]
        {
            "armr", 
            "forg", 
            "mode", 
            "obje", 
            "pdm!", 
            "scnr", 
            "sus!", 
            "trdf", 
            "vfsl", 
            "cprl",
            "gfxt",
            "wgtz",
            "chdt",
            "chgd"
        };

        public static readonly string[] RequiredTags = new[] 
        {
            @"globals\ai_globals", // Cannot be ported due to dependency count (will cause cache bloating)
            @"globals\game_progression", // ODST specific (Can recreate)
            @"globals\global_achievements", // ODST Specific (Can recreate)
            @"globals\input_globals", // Halo Online Specific (Can recreate)
            @"globals\rasterizer_globals", // Might be able to port (Explicit Shaders are MS23 specific, and need to be copied over, along with any other shaders and the shield impact globals)
            @"sound\global_fx" // Cannot be ported due to issues with StringId conversion
        };

        // Default bitmaps, stored in rasterizer globals
        public static readonly string[] DefaultBitmapNames = new[]
        {
            @"shaders\default_bitmaps\bitmaps\gray_50_percent",
            @"shaders\default_bitmaps\bitmaps\alpha_grey50",
            @"shaders\default_bitmaps\bitmaps\color_white",
            @"shaders\default_bitmaps\bitmaps\default_detail",
            @"shaders\default_bitmaps\bitmaps\reference_grids",
            @"shaders\default_bitmaps\bitmaps\default_vector",
            @"shaders\default_bitmaps\bitmaps\default_alpha_test",
            @"shaders\default_bitmaps\bitmaps\default_dynamic_cube_map",
            @"shaders\default_bitmaps\bitmaps\color_red",
            @"shaders\default_bitmaps\bitmaps\alpha_white",
            @"shaders\default_bitmaps\bitmaps\monochrome_alpha_grid",
            @"shaders\default_bitmaps\bitmaps\gray_50_percent_linear",
            @"shaders\default_bitmaps\bitmaps\color_black_alpha_black",
            @"shaders\default_bitmaps\bitmaps\dither_pattern",
            @"shaders\default_bitmaps\bitmaps\bump_detail",
            @"shaders\default_bitmaps\bitmaps\color_black",
            @"shaders\default_bitmaps\bitmaps\auto_exposure_weight",
            @"shaders\default_bitmaps\bitmaps\dither_pattern2",
            @"shaders\default_bitmaps\bitmaps\random4_warp",
            @"levels\shared\bitmaps\nature\water\water_ripples",
            @"shaders\default_bitmaps\bitmaps\vision_mode_mask"
        };

        // These need to be copied over as the shader generator cannot generate chud shaders
        public static readonly string[] ChudShaders = new[]
        {
            @"rasterizer\shaders\chud_simple",
            @"rasterizer\shaders\chud_meter",
            @"rasterizer\shaders\chud_text_simple",
            @"rasterizer\shaders\chud_meter_shield",
            @"rasterizer\shaders\chud_meter_gradient",
            @"rasterizer\shaders\chud_crosshair",
            @"rasterizer\shaders\chud_directional_damage",
            @"rasterizer\shaders\chud_solid",
            @"rasterizer\shaders\chud_sensor",
            @"rasterizer\shaders\chud_meter_single_color",
            @"rasterizer\shaders\chud_navpoint",
            @"rasterizer\shaders\chud_medal",
            @"rasterizer\shaders\chud_texture_cam",
            @"rasterizer\shaders\chud_cortana_screen",
            @"rasterizer\shaders\chud_cortana_camera",
            @"rasterizer\shaders\chud_cortana_offscreen",
            @"rasterizer\shaders\chud_cortana_screen_final",
            @"rasterizer\shaders\chud_meter_chapter",
            @"rasterizer\shaders\chud_meter_double_gradient",
            @"rasterizer\shaders\chud_meter_radial_gradient",
            @"rasterizer\shaders\chud_turbulence",
            @"rasterizer\shaders\chud_emblem",
            @"rasterizer\shaders\chud_cortana_composite",
            @"rasterizer\shaders\chud_directional_damage_apply",
            @"rasterizer\shaders\chud_really_simple"
        };

        // These need to be coped over to the new cache, as TagTool cannot port shield impact tags correctly (Yet)
        public static readonly string[] ShieldImpactTags = new[]
        {
            @"fx\shield_impacts\spartan_3p",
            @"fx\shield_impacts\spartan_1p",
            @"fx\shield_impacts\overshield_3p",
            @"fx\shield_impacts\overshield_1p"
        };

        // Rebuilds the target cache, dumping the resulting files in the specified output directory
        public object rebuildCache(string destCacheDirectory)
        {
            ConvertedTags.Clear();
            CopiedResources.Clear();

            var destDirectory = new DirectoryInfo(destCacheDirectory);

            if (!destDirectory.Exists)
                destDirectory.Create();

            var destTagCache = CreateTagCache(destDirectory);

            var destStringIdPath = Path.Combine(destDirectory.FullName, CacheContext.StringIdCacheFile.Name);

            if (File.Exists(destStringIdPath))
                File.Delete(destStringIdPath);

            CacheContext.StringIdCacheFile.CopyTo(destStringIdPath);

            var srcResourceCaches = new Dictionary<ResourceLocation, ResourceCache>();
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
                SourceResourceStreams[location] = CacheContext.ResourceCaches.OpenCacheReadWrite(location);
                DestinationResourceStreams[location] = destCacheContext.ResourceCaches.OpenCacheReadWrite(location);
            }

            using (var srcStream = CacheContext.OpenCacheRead())
            using (var destStream = destCacheContext.OpenCacheReadWrite())
            {
                var cfgtTag = destCacheContext.TagCache.AllocateTag<Scenario>($@"global_tags");
                var cfgt = new CacheFileGlobalTags();
                destCacheContext.Serialize(destStream, cfgtTag, cfgt);
                
                var matgTag = destCacheContext.TagCache.AllocateTag<Globals>($@"globals\globals");
                var matg = new Globals();
                destCacheContext.Serialize(destStream, matgTag, matg);
                
                var mulgTag = destCacheContext.TagCache.AllocateTag<MultiplayerGlobals>($@"multiplayer\multiplayer_globals");
                var mulg = new MultiplayerGlobals();
                destCacheContext.Serialize(destStream, mulgTag, mulg);

                var smdtTag = destCacheContext.TagCache.AllocateTag<SurvivalModeGlobals>($@"multiplayer\survival_mode_globals");
                var smdt = new SurvivalModeGlobals();
                destCacheContext.Serialize(destStream, smdtTag, smdt);

                var modgTag = destCacheContext.TagCache.AllocateTag<ModGlobalsDefinition>($@"multiplayer\mod_globals");
                var modg = new ModGlobalsDefinition();
                destCacheContext.Serialize(destStream, modgTag, modg);
                
                var forgTag = destCacheContext.TagCache.AllocateTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals");
                var forg = new ForgeGlobalsDefinition();
                destCacheContext.Serialize(destStream, forgTag, forg);
                
                cfgt = destCacheContext.Deserialize<CacheFileGlobalTags>(destStream, cfgtTag);
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
                };
                destCacheContext.Serialize(destStream, cfgtTag, cfgt);

                foreach (var tagName in DefaultBitmapNames)
                {
                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tag == null || !tag.IsInGroup("bitm"))
                            continue;

                        if (tagName == tag.Name && tag.IsInGroup("bitm"))
                        {
                            CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            break;
                        }
                    }
                }

                foreach (var tag in CacheContext.TagCache.FindAllInGroup("rmdf"))
                    CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);

                foreach (var tagName in ChudShaders)
                {
                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tag == null || !tag.IsInGroup("pixl"))
                            continue;

                        if (tagName == tag.Name && tag.IsInGroup("pixl"))
                        {
                            CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            break;
                        }
                    }
                
                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tag == null || !tag.IsInGroup("vtsh"))
                            continue;

                        if (tagName == tag.Name && tag.IsInGroup("vtsh"))
                        {
                            CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            break;
                        }
                    }
                }

                foreach (var tagName in RequiredTags)
                {
                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tag == null || !tag.Name.Equals(tagName))
                            continue;

                        if (tagName == tag.Name)
                        {
                            CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            break;
                        }
                    }
                }

                foreach (var tagName in ShieldImpactTags)
                {
                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tag == null || !tag.IsInGroup("shit"))
                            continue;

                        if (tagName == tag.Name)
                        {
                            CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            break;
                        }
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

        // Creates a new tags.dat file (if guid does not equal the hex value specified below, the cache will not load)
        public TagCache CreateTagCache(DirectoryInfo directory)
        {
            if (!directory.Exists)
                directory.Create();

            var file = new FileInfo(Path.Combine(directory.FullName, "tags.dat"));

            TagCache cache = null;

            using (var stream = file.Create())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(0);                  // padding
                writer.Write(32);                 // table offset
                writer.Write(0);                  // table entry count
                writer.Write(0);                  // padding
                writer.Write(0x01D0631BCC791704); // guid
                writer.Write(0);                  // padding
                writer.Write(0);                  // padding
            }

            return cache;
        }

        // Creates a new resource file (if guid does not equal the hex value specified below, the cache will not load)
        public ResourceCache CreateResourceCache(DirectoryInfo directory, ResourceLocation location)
        {
            if (!directory.Exists)
                directory.Create();

            var file = new FileInfo(Path.Combine(directory.FullName, ResourceCachesHaloOnline.ResourceCacheNames[location]));

            ResourceCache cache = null;

            using (var stream = file.Create())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(0);                  // padding
                writer.Write(32);                 // table offset
                writer.Write(0);                  // table entry count
                writer.Write(0);                  // padding
                writer.Write(0x01D0631BCC92931B); // guid
                writer.Write(0);                  // padding
                writer.Write(0);                  // padding
            }

            return cache;
        }

        public CachedTagHaloOnline CopyTag(CachedTagHaloOnline srcTag, GameCacheHaloOnline srcCacheContext, Stream srcStream, GameCacheHaloOnline destCacheContext, Stream destStream)
        {
            if (srcTag == null)
                return null;

            if (UncleanSkipGroups.Where(tag => srcTag.IsInGroup(tag)).Count() != 0)
                return null;

            if (srcTag.Name?.StartsWith("hf2p") ?? false)
                return null; // kill it with fucking fire

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

        // Retargets the cache (Its bascially the equivalent of the restart command)
        public void retargetCache()
        {
            var newFileInfo = new FileInfo(outputDirectoryInfo.FullName + "\\tags.dat");
            Cache = GameCache.Open(newFileInfo);
            CacheContext = Cache as GameCacheHaloOnline;
            ContextStack.Push(TagCacheContextFactory.Create(ContextStack, Cache));
        }

        // Copies over required files (map files required for updating map files)
        public void moveFontPackage()
        {
            Directory.CreateDirectory($@"{outputDirectoryInfo.FullName}\fonts");

            // Will add upscaled font packages once HUD and UI issues have been resolved

            //File.Copy($@"{Program.TagToolDirectory}\Tools\PortingCache\Fonts\Upscaled\font_package.bin", $@"{outputDirectoryInfo.FullName}\fonts\font_package.bin");
            File.Copy($@"{Program.TagToolDirectory}\Tools\PortingCache\Fonts\Default\font_package.bin", $@"{outputDirectoryInfo.FullName}\fonts\font_package.bin");
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
    }
}