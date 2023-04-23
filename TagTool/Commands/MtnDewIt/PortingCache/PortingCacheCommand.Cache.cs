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
        private GfxTexturesList GfxtDefintion { get; set; } = null;

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
            "cprl"
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
                var cfgtTag = CopyTag((CachedTagHaloOnline)CacheContext.TagCache.FindFirstInGroup("cfgt"), CacheContext, srcStream, destCacheContext, destStream);

                foreach (var tagName in DefaultBitmapNames)
                {
                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tag == null || !tag.IsInGroup("bitm"))
                            continue;

                        if (tagName == tag.Name)
                        {
                            CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            break;
                        }
                    }
                }

                foreach (var tagName in ChudShaders)
                {
                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tagName == tag.Name && tag.IsInGroup("pixl"))
                        {
                            CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);
                            break;
                        }
                    }

                    foreach (var tag in CacheContext.TagCache.NonNull())
                    {
                        if (tagName == tag.Name && tag.IsInGroup("vtsh"))
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

                foreach (var tag in CacheContext.TagCache.FindAllInGroup("rmdf"))
                    CopyTag((CachedTagHaloOnline)tag, CacheContext, srcStream, destCacheContext, destStream);

                CopyTag((CachedTagHaloOnline)CacheContext.TagCache.GetTag<Globals>(@"globals\globals"), CacheContext, srcStream, destCacheContext, destStream);

                destCacheContext.Serialize(destStream, cfgtTag, new CacheFileGlobalTags
                {
                    GlobalTags = new List<TagReferenceBlock>
                    {
                        new TagReferenceBlock { Instance = destCacheContext.TagCache.GetTag<Globals>(@"globals\globals") },
                        new TagReferenceBlock { Instance = destCacheContext.TagCache.GetTag<GfxTexturesList>(@"ui\halox\main_menu\gfxt") }
                    }
                });
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

            // Removes MS30 shaders
            if (srcTag.Name.StartsWith("ms30") && srcTag.IsInGroup("rmdf"))
                return null;

            // Removes existing UI tags
            if (srcTag.IsInGroup("wgtz"))
                return null;

            // Removes all HUD tags
            if (srcTag.IsInGroup("chdt"))
                return null;

            // Removes chud globals definition tag
            if (srcTag.IsInGroup("chgd"))
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

            if (tagData is Globals matg)
                CleanGlobals(matg);

            if (tagData is MultiplayerGlobals mulg)
                CleanMultiplayerGlobals(mulg);

            if (tagData is GfxTexturesList gfxt)
                CleanGfxtTexturesList(gfxt);

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

        private void CleanGlobals(Globals matgDefintion)
        {
            if (MatgDefinition == null)
                MatgDefinition = matgDefintion;

            matgDefintion.InterfaceTags[0].GfxUiStrings = null;
        }

        private void CleanGfxtTexturesList(GfxTexturesList gfxtDefinition)
        {
            if (GfxtDefintion == null)
                GfxtDefintion = gfxtDefinition;

            gfxtDefinition.Textures = null;
        }

        private void CleanMultiplayerGlobals(MultiplayerGlobals mulgDefinition)
        {
            if (MulgDefinition == null)
                MulgDefinition = mulgDefinition;

            // These go unused in 0.7
            mulgDefinition.Universal[0].SpartanArmorCustomization = null;
            mulgDefinition.Universal[0].EliteArmorCustomization = null;

            mulgDefinition.Universal[0].Equipment = new List<MultiplayerGlobals.MultiplayerUniversalBlock.Consumable>
            {
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("empty"),
                    Object = null,
                    Type = 0
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("jammer"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\jammer_equipment\jammer_equipment"),
                    Type = 8
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("powerdrain"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\powerdrain_equipment\powerdrain_equipment"),
                    Type = 1
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("bubbleshield"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment"),
                    Type = 2
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("superflare"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\superflare_equipment\superflare_equipment"),
                    Type = 10
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("regenerator"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\regenerator_equipment\regenerator_equipment"),
                    Type = 4
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("tripmine"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\tripmine_equipment\tripmine_equipment"),
                    Type = 0
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("deployable_cover"),
                    Object = null,
                    Type = 6
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("invincibility"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\invincibility_equipment\invincibility_equipment"),
                    Type = 7
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("gravlift"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\gravlift_equipment\gravlift_equipment"),
                    Type = 3
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("auto_turret"),
                    Object = null,
                    Type = 9
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("invisibility"),
                    Object = null,
                    Type = 5
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.Consumable
                {
                    Name = CacheContext.StringTable.GetStringId("deployable_cover"),
                    Object = CacheContext.TagCache.GetTag<Equipment>(@"objects\equipment\instantcover_equipment\instantcover_equipment"),
                    Type = 6
                }
            };

            mulgDefinition.Universal[0].GameVariantWeapons = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon>
            {
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("battle_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\battle_rifle\battle_rifle")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("assault_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\assault_rifle\assault_rifle")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("plasma_pistol"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\pistol\plasma_pistol\plasma_pistol")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("spike_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\spike_rifle\spike_rifle")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("smg"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\smg\smg")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("carbine"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\covenant_carbine\covenant_carbine")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("energy_sword"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\melee\energy_blade\energy_blade")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("magnum"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\pistol\magnum\magnum")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("needler"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\pistol\needler\needler")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("plasma_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\plasma_rifle\plasma_rifle")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("rocket_launcher"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\support_high\rocket_launcher\rocket_launcher")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("shotgun"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\shotgun\shotgun")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("sniper_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\sniper_rifle\sniper_rifle")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("brute_shot"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\support_low\brute_shot\brute_shot")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("unarmed"),
                    RandomChance = 0,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\melee\energy_blade\energy_blade_useless")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("beam_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\rifle\beam_rifle\beam_rifle")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("spartan_laser"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\support_high\spartan_laser\spartan_laser")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("none"),
                    RandomChance = 0,
                    Weapon = null
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("gravity_hammer"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\melee\gravity_hammer\gravity_hammer")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("excavator"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\pistol\excavator\excavator")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("flamethrower"),
                    RandomChance = 0,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\turret\flamethrower\flamethrower")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.StringTable.GetStringId("missile_pod"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.GetTag<Weapon>(@"objects\weapons\turret\missile_pod\missile_pod")
                }
            };

            mulgDefinition.Universal[0].GameVariantVehicles = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle>
            {
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("warthog"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\warthog\warthog")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("ghost"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\ghost\ghost")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("scorpion"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\scorpion\scorpion")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("wraith"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\wraith\wraith")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("banshee"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\banshee\banshee")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("mongoose"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\mongoose\mongoose")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("chopper"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\brute_chopper\brute_chopper")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("mauler"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\mauler\mauler")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.StringTable.GetStringId("hornet"),
                    Vehicle = CacheContext.TagCache.GetTag<Vehicle>(@"objects\vehicles\hornet\hornet")
                }
            };

            mulgDefinition.Universal[0].VehicleSets = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet>
            {
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("default"),
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>()
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("no_vehicles"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("mongooses_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                            SubstitutedVehicle = CacheContext.StringTable.GetStringId("mongoose")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("light_ground_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("tanks_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("aircraft_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("no_light_ground"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("no_tanks"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("no_aircraft"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.StringTable.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Invalid
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet
                {
                    Name = CacheContext.StringTable.GetStringId("all_vehicles"),
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.VehicleSet.Substitution>()
                }
            };

            mulgDefinition.Universal[0].WeaponSets = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet>
            {
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("default"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("needler")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("brute_shot")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sentinel_beam")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("beam_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("flamethrower")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("missile_pod")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("assault_rifles"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("duals"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("hammers"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("lasers"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spartan_laser")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("rockets"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("shotguns"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("sniper_rifles"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("beam_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sniper_rifle")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("swords"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("no_power_weapons"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("needler")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("brute_shot")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sentinel_beam")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("no_snipers"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("assault_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_pistol")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("spike_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("smg")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("carbine")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("energy_sword")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("magnum")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("needler")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("plasma_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("rocket_launcher")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("shotgun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("brute_shot")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("sentinel_beam")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("battle_rifle")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("gravity_hammer")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("excavator")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("flamethrower")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("missile_pod")
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("no_weapons"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = StringId.Invalid
                        },
                    }
                    #endregion
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet
                {
                    Name = CacheContext.StringTable.GetStringId("random"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution>()
                    {
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("battle_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("assault_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_pistol"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spike_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("smg"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("carbine"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("energy_sword"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("magnum"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("needler"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("plasma_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("rocket_launcher"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("shotgun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sniper_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("brute_shot"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("fuel_rod_gun"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("sentinel_beam"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("beam_rifle"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("spartan_laser"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("gravity_hammer"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("excavator"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("flamethrower"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                        new MultiplayerGlobals.MultiplayerUniversalBlock.WeaponSet.Substitution
                        {
                            OriginalWeapon = CacheContext.StringTable.GetStringId("missile_pod"),
                            SubstitutedWeapon = CacheContext.StringTable.GetStringId("random")
                        },
                    }
                    #endregion
                },
            };

            mulgDefinition.Universal[0].GameVariantGrenades = new List<MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock>
            {
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock
                {
                    Name = CacheContext.StringTable.GetStringId("frag_grenade"),
                    Grenade = CacheContext.TagCache.GetTag<Equipment>(@"objects\weapons\grenade\frag_grenade\frag_grenade")
                },
                new MultiplayerGlobals.MultiplayerUniversalBlock.GameVariantGrenadeBlock
                {
                    Name = CacheContext.StringTable.GetStringId("plasma_grenade"),
                    Grenade = CacheContext.TagCache.GetTag<Equipment>(@"objects\weapons\grenade\plasma_grenade\plasma_grenade")
                }
            };

            mulgDefinition.Runtime[0].HaloOnlineRuntimeEffects.AutoFlipEffect = CacheContext.TagCache.GetTag<Effect>(@"objects\multi\equipment\fx\detonation");
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
        public void moveDependencies()
        {
            File.Copy($@"{Cache.Directory}\guardian.map", $@"{outputDirectoryInfo.FullName}\guardian.map");
            File.Copy($@"{Cache.Directory}\mainmenu.map", $@"{outputDirectoryInfo.FullName}\mainmenu.map");
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