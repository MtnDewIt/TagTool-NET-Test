using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void ModGlobals()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("modg") && tag.Name == $@"multiplayer\mod_globals")
                    {
                        var modg = CacheContext.Deserialize<ModGlobalsDefinition>(stream, tag);
                        modg.PlayerCharacterSets = new List<ModGlobalsDefinition.PlayerCharacterSet>()
                        {
                            new ModGlobalsDefinition.PlayerCharacterSet()
                            {
                                DisplayName = "General",
                                Name = CacheContext.StringTable.GetStringId($@"default"),
                                RandomChance = 0.1f,
                                Characters = new List<ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter>()
                                {
                                    new ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter()
                                    {
                                        DisplayName = $@"Spartan",
                                        Name = CacheContext.StringTable.GetStringId($@"masterchief"),
                                        RandomChance = 0.1f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter()
                                    {
                                        DisplayName = $@"Elite",
                                        Name = CacheContext.StringTable.GetStringId($@"dervish"),
                                        RandomChance = 0.1f,
                                    },
                                },
                            },
                        };
                        modg.PlayerCharacterCustomizations = new List<ModGlobalsDefinition.PlayerCharacterCustomization>()
                        {
                            new ModGlobalsDefinition.PlayerCharacterCustomization()
                            {
                                GlobalPlayerCharacterTypeIndex = 0,
                                CharacterName = CacheContext.StringTable.GetStringId($@"model_spartan"),
                                CharacterDescription = CacheContext.StringTable.GetStringId($@"model_spartan_description"),
                                HudGlobals = GetCachedTag<ChudGlobalsDefinition>($@"ui\chud\globals"),
                                VisionGlobals = GetCachedTag<VisionMode>($@"globals\default_vision_mode"),
                                ActionSet = GetCachedTag<PlayerActionSet>($@"objects\characters\masterchief\mp_masterchief\actions"),
                                CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                                {
                                    flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera,
                                    BipedNameIndex = 15,
                                    SettingsCameraIndex = -1,
                                    PlatformNameIndex = -1,
                                    BipedPositionWidescreen = new RealPoint3d(-45f, -10f, -35f),
                                    BipedPositionStandard = new RealPoint3d(-45f, -10f, -35f),
                                },
                                CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                                {
                                    ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.TertiaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                                    TeamOverrideFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                                    Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                                    {
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_spartan_color_primary"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_spartan_color_primary_desc"),
                                            Default = new ArgbColor(0, 84, 110, 38),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_spartan_color_secondary"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_spartan_color_secondary_desc"),
                                            Default = new ArgbColor(0, 84, 110, 38),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_spartan_color_visor"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_spartan_color_visor_desc"),
                                            Default = new ArgbColor(0, 255, 127, 0),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_spartan_color_light"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_spartan_color_light_desc"),
                                            Default = new ArgbColor(0, 150, 133, 255),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            
                                        },
                                    },
                                },
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization()
                            {
                                GlobalPlayerCharacterTypeIndex = 1,
                                CharacterName = CacheContext.StringTable.GetStringId($@"model_elite"),
                                CharacterDescription = CacheContext.StringTable.GetStringId($@"model_elite_description"),
                                HudGlobals = GetCachedTag<ChudGlobalsDefinition>($@"ui\chud\globals"),
                                VisionGlobals = GetCachedTag<VisionMode>($@"globals\default_vision_mode"),
                                ActionSet = GetCachedTag<PlayerActionSet>($@"objects\characters\elite\mp_elite\actions"),
                                CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                                {
                                    flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera,
                                    BipedNameIndex = 14,
                                    SettingsCameraIndex = -1,
                                    PlatformNameIndex = -1,
                                    BipedPositionWidescreen = new RealPoint3d(-45f, -10f, -35f),
                                    BipedPositionStandard = new RealPoint3d(-45f, -10f, -35f),
                                },
                                CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                                {
                                    ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.TertiaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuinaryColor,
                                    TeamOverrideFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor,
                                    Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                                    {
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_elite_color_primary"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_elite_color_primary_desc"),
                                            Default = new ArgbColor(0, 67, 189, 255),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_elite_color_primary_sheen"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_elite_color_primary_sheen_desc"),
                                            Default = new ArgbColor(0, 224, 126, 255),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_elite_color_secondary"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_elite_color_secondary_desc"),
                                            Default = new ArgbColor(0, 146, 17, 255),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_elite_color_flair"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_elite_color_flair_desc"),
                                            Default = new ArgbColor(0, 255, 255, 255),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"cef_elite_color_light"),
                                            Description = CacheContext.StringTable.GetStringId($@"cef_elite_color_light_desc"),
                                            Default = new ArgbColor(0, 255, 255, 255),
                                        },
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, modg);
                    }
                }
            }
        }
    }
}