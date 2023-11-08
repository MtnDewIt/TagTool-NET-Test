using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.Resources;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Commands.Tags;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public Dictionary<int, CachedTagHaloOnline> ConvertedTags { get; } = new Dictionary<int, CachedTagHaloOnline>();
        public Dictionary<ResourceLocation, Dictionary<int, PageableResource>> CopiedResources { get; } = new Dictionary<ResourceLocation, Dictionary<int, PageableResource>>();
        public Dictionary<ResourceLocation, Stream> SourceResourceStreams = new Dictionary<ResourceLocation, Stream>();
        public Dictionary<ResourceLocation, Stream> DestinationResourceStreams = new Dictionary<ResourceLocation, Stream>();

        // Default bitmaps, stored in rasterizer globals
        public static readonly string[] DefaultBitmapNames = new[]
        {
           @"shaders\default_bitmaps\bitmaps\alpha_grey50",
           @"shaders\default_bitmaps\bitmaps\alpha_white",
           @"shaders\default_bitmaps\bitmaps\auto_exposure_weight",
           @"shaders\default_bitmaps\bitmaps\bump_detail",
           @"shaders\default_bitmaps\bitmaps\color_black",
           @"shaders\default_bitmaps\bitmaps\color_black_alpha_black",
           @"shaders\default_bitmaps\bitmaps\color_red",
           @"shaders\default_bitmaps\bitmaps\color_white",
           @"shaders\default_bitmaps\bitmaps\default_alpha_test",
           @"shaders\default_bitmaps\bitmaps\default_detail",
           @"shaders\default_bitmaps\bitmaps\default_dynamic_cube_map",
           @"shaders\default_bitmaps\bitmaps\default_environment_map",
           @"shaders\default_bitmaps\bitmaps\default_vector",
           @"shaders\default_bitmaps\bitmaps\dither_pattern",
           @"shaders\default_bitmaps\bitmaps\dither_pattern2",
           @"shaders\default_bitmaps\bitmaps\gray_50_percent",
           @"shaders\default_bitmaps\bitmaps\gray_50_percent_linear",
           @"shaders\default_bitmaps\bitmaps\monochrome_alpha_grid",
           @"shaders\default_bitmaps\bitmaps\random4_warp",
           @"shaders\default_bitmaps\bitmaps\reference_grids",
           @"shaders\default_bitmaps\bitmaps\sparklenoisemap",
           @"levels\shared\bitmaps\nature\water\water_ripples",
           @"levels\shared\bitmaps\nature\water\wave_foam",
        };

        // These need to be copied over as the shader generator cannot generate these shaders
        public static readonly string[] MS23Shaders = new[]
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
            @"rasterizer\shaders\chud_really_simple",
            @"rasterizer\shaders\debug",
            @"rasterizer\shaders\debug2d",
            @"rasterizer\shaders\copy_surface",
            @"rasterizer\shaders\spike_blur_vertical",
            @"rasterizer\shaders\spike_blur_horizontal",
            @"rasterizer\shaders\downsize_2x_to_bloom",
            @"rasterizer\shaders\downsize_2x_target",
            @"rasterizer\shaders\copy_rgbe_to_rgb",
            @"rasterizer\shaders\update_persistence",
            @"rasterizer\shaders\add_downsampled",
            @"rasterizer\shaders\add",
            @"rasterizer\shaders\blur_11_horizontal",
            @"rasterizer\shaders\blur_11_vertical",
            @"rasterizer\shaders\cubemap_phi_blur",
            @"rasterizer\shaders\cubemap_theta_blur",
            @"rasterizer\shaders\cubemap_clamp",
            @"rasterizer\shaders\cubemap_divide",
            @"rasterizer\shaders\write_depth",
            @"rasterizer\shaders\final_composite",
            @"rasterizer\shaders\sky_dome_simple",
            @"rasterizer\shaders\transparent",
            @"rasterizer\shaders\shield_meter",
            @"rasterizer\shaders\legacy_meter",
            @"rasterizer\shaders\overhead_map_geometry",
            @"rasterizer\shaders\legacy_hud_bitmap",
            @"rasterizer\shaders\blend3",
            @"rasterizer\shaders\particle_update",
            @"rasterizer\shaders\particle_spawn",
            @"rasterizer\shaders\screenshot_combine",
            @"rasterizer\shaders\downsample_2x2",
            @"rasterizer\shaders\rotate_2d",
            @"rasterizer\shaders\bspline_resample",
            @"rasterizer\shaders\downsample_4x4_bloom_dof",
            @"rasterizer\shaders\final_composite_dof",
            @"rasterizer\shaders\kernel_5",
            @"rasterizer\shaders\exposure_downsample",
            @"rasterizer\shaders\yuv_to_rgb",
            @"rasterizer\shaders\displacement",
            @"rasterizer\shaders\screenshot_display",
            @"rasterizer\shaders\downsample_4x4_block",
            @"rasterizer\shaders\crop",
            @"rasterizer\shaders\screenshot_combine_dof",
            @"rasterizer\shaders\gamma_correct",
            @"rasterizer\shaders\contrail_spawn",
            @"rasterizer\shaders\contrail_update",
            @"rasterizer\shaders\stencil_stipple",
            @"rasterizer\shaders\lens_flare",
            @"rasterizer\shaders\decorator_default",
            @"rasterizer\shaders\downsample_4x4_block_bloom",
            @"rasterizer\shaders\downsample_4x4_gaussian",
            @"rasterizer\shaders\apply_color_matrix",
            @"rasterizer\shaders\copy",
            @"rasterizer\shaders\shadow_geometry",
            @"rasterizer\shaders\shadow_apply",
            @"rasterizer\shaders\gradient",
            @"rasterizer\shaders\alpha_test_explicit",
            @"rasterizer\shaders\patchy_fog",
            @"rasterizer\shaders\light_volume_update",
            @"rasterizer\shaders\water_ripple",
            @"rasterizer\shaders\double_gradient",
            @"rasterizer\shaders\sniper_scope",
            @"rasterizer\shaders\shield_impact",
            @"rasterizer\shaders\player_emblem_world",
            @"rasterizer\shaders\player_emblem_screen",
            @"rasterizer\shaders\implicit_hill",
            @"rasterizer\shaders\chud_overlay_blend",
            @"rasterizer\shaders\bloom_add_alpha1",
            @"rasterizer\shaders\downsample_4x4_block_bloom_ldr",
            @"rasterizer\shaders\restore_ldr_hdr_depth",
            @"rasterizer\shaders\beam_update",
            @"rasterizer\shaders\decorator_no_wind",
            @"rasterizer\shaders\decorator_static",
            @"rasterizer\shaders\decorator_sun",
            @"rasterizer\shaders\decorator_wavy",
            @"rasterizer\shaders\final_composite_zoom",
            @"rasterizer\shaders\final_composite_debug",
            @"rasterizer\shaders\shadow_apply_point",
            @"rasterizer\shaders\shadow_apply_bilinear",
            @"rasterizer\shaders\shadow_apply_fancy",
            @"rasterizer\shaders\shadow_apply_faster",
            @"rasterizer\shaders\displacement_motion_blur",
            @"rasterizer\shaders\decorator_shaded",
            @"rasterizer\shaders\screenshot_memexport",
            @"rasterizer\shaders\downsample_4x4_gaussian_bloom_ldr",
            @"rasterizer\shaders\downsample_4x4_gaussian_bloom",
            @"rasterizer\shaders\downsample_4x4_block_bloom_new",
            @"rasterizer\shaders\bloom_curve",
            @"rasterizer\shaders\custom_gamma_correct",
            @"rasterizer\shaders\pixel_copy",
            @"rasterizer\shaders\unknown_5A",
            @"rasterizer\shaders\exposure_hdr_retrieve",
            @"rasterizer\shaders\unknown_debug_5C",
            @"rasterizer\shaders\fxaa",
            @"rasterizer\shaders\unknown_5E",
            @"rasterizer\shaders\unknown_5F",
            @"rasterizer\shaders\ssao_ldr",
            @"rasterizer\shaders\ssao_hdr",
            @"rasterizer\shaders\ssao_apply",
            @"rasterizer\shaders\lightshafts",
            @"rasterizer\shaders\lightshafts_blur",
            @"rasterizer\shaders\screen_space_reflection",
            @"rasterizer\shaders\unknown_66",
            @"rasterizer\shaders\halve_depth_color",
            @"rasterizer\shaders\halve_depth_normal",
            @"rasterizer\shaders\unknown_69",
            @"rasterizer\shaders\screen_space_reflection_blur",
            @"rasterizer\shaders\unknown_6B",
            @"rasterizer\shaders\hud_camera_nightvision",
            @"rasterizer\shaders\unknown_6D",
        };

        // Rebuilds the target cache, dumping the resulting files in the specified output directory
        public object rebuildCache(string destCacheDirectory)
        {
            ConvertedTags.Clear();
            CopiedResources.Clear();

            var destDirectory = new DirectoryInfo(destCacheDirectory);

            EmptyDirectory(destDirectory);

            CreateTagCache(destDirectory);

            // At some point I would like to have it generate its own string_ids.dat, however all current solutions I have tried
            // cause issues when copying over existing tags from MS23. Need to look into string id functionality, as for some reason when porting
            // shaders, it complains about missing shader options, when the string ids are in the cache :/

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
                var cfgtTag = destCacheContext.TagCache.AllocateTag<CacheFileGlobalTags>($@"global_tags");
                var cfgt = new CacheFileGlobalTags();
                destCacheContext.Serialize(destStream, cfgtTag, cfgt);

                var matgTag = destCacheContext.TagCache.AllocateTag<Globals>($@"globals\globals");
                var matg = new Globals();
                destCacheContext.Serialize(destStream, matgTag, matg);

                var modgTag = destCacheContext.TagCache.AllocateTag<ModGlobalsDefinition>($@"multiplayer\mod_globals");
                var modg = new ModGlobalsDefinition();
                destCacheContext.Serialize(destStream, modgTag, modg);

                var forgTag = destCacheContext.TagCache.AllocateTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals");
                var forg = new ForgeGlobalsDefinition();
                destCacheContext.Serialize(destStream, forgTag, forg);

                var mlstTag = destCacheContext.TagCache.AllocateTag<MapList>($@"ui\eldewrito\maps");
                var mlst = new MapList();
                destCacheContext.Serialize(destStream, mlstTag, mlst);

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
                    new TagReferenceBlock()
                    {
                        Instance = destCacheContext.TagCache.GetTag<MapList>($@"ui\eldewrito\maps"),
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
                {
                    CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                }

                foreach (var tagName in MS23Shaders)
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

        public CachedTagHaloOnline CopyTag(CachedTagHaloOnline srcTag, GameCacheHaloOnline srcCacheContext, Stream srcStream, GameCacheHaloOnline destCacheContext, Stream destStream)
        {
            if (srcTag == null)
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
        public void retargetCache(string cache)
        {
            var newFileInfo = new FileInfo(cache + "\\tags.dat");
            Cache = GameCache.Open(newFileInfo);
            CacheContext = Cache as GameCacheHaloOnline;
            ContextStack.Push(TagCacheContextFactory.Create(ContextStack, Cache));
        }

        // Copies over required files (map files required for updating map files)
        public void moveFontPackage(string path)
        {
            Directory.CreateDirectory($@"{path}\fonts");

            if (!File.Exists($@"{path}\fonts\font_package.bin"))
            {
                File.Copy($@"{Program.TagToolDirectory}\Tools\BaseCache\Fonts\Upscaled\font_package.bin", $@"{path}\fonts\font_package.bin");
            }
            else
            {
                new TagToolWarning($@"Font Package Detected in Specified Directory! Replacing Anyway.");
                File.Copy($@"{Program.TagToolDirectory}\Tools\BaseCache\Fonts\Upscaled\font_package.bin", $@"{path}\fonts\font_package.bin", true);
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
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assinging null tag instead");
                return null;
            }
        }
    }
}