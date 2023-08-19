using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheHaloOnlineCommand : Command
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
                                RegionCameraScripts = new List<ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript>
                                {
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "helmet",
                                        ScriptNameWidescreen = "helmet_camera_wide",
                                        ScriptNameStandard = "helmet_camera_standard",
                                        BipedRotation = 10,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "body",
                                        ScriptNameWidescreen = "body_camera_wide",
                                        ScriptNameStandard = "body_camera_standard",
                                        BipedRotation = -285f,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "leftshoulder",
                                        ScriptNameWidescreen = "leftshoulder_camera_wide",
                                        ScriptNameStandard = "leftshoulder_camera_standard",
                                        BipedRotation = 10,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "rightshoulder",
                                        ScriptNameWidescreen = "rightshoulder_camera_wide",
                                        ScriptNameStandard = "rightshoulder_camera_standard",
                                        BipedRotation = -225f,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "exit",
                                        ScriptNameWidescreen = "exit_subcamera",
                                        ScriptNameStandard = "exit_subcamera",
                                        RotationDuration = 0.75f,
                                    },
                                },
                                CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                                {
                                    flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera,
                                    BipedNameIndex = 1,
                                    SettingsCameraIndex = 15,
                                    PlatformNameIndex = -1,
                                    RelativeBipedPosition = new RealVector3d(0.05f, 0f, -0.02f),
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
                                RegionCameraScripts = new List<ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript>
                                {
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "helmet",
                                        ScriptNameWidescreen = "helmet_camera_wide",
                                        ScriptNameStandard = "helmet_camera_standard",
                                        BipedRotation = 15f,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "body",
                                        ScriptNameWidescreen = "body_camera_wide",
                                        ScriptNameStandard = "body_camera_standard",
                                        BipedRotation = 45f,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "leftshoulder",
                                        ScriptNameWidescreen = "leftshoulder_camera_wide",
                                        ScriptNameStandard = "leftshoulder_camera_standard",
                                        BipedRotation = -35f,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "rightshoulder",
                                        ScriptNameWidescreen = "rightshoulder_camera_wide",
                                        ScriptNameStandard = "rightshoulder_camera_standard",
                                        BipedRotation = -275f,
                                        RotationDuration = 0.75f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                                    {
                                        RegionName = "exit",
                                        ScriptNameWidescreen = "exit_subcamera",
                                        ScriptNameStandard = "exit_subcamera",
                                        RotationDuration = 0.75f,
                                    },
                                },
                                CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                                {
                                    flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera,
                                    BipedNameIndex = 26,
                                    SettingsCameraIndex = 15,
                                    PlatformNameIndex = -1,
                                    RelativeBipedPosition = new RealVector3d(0.3f, 0.04f, -0.02f),
                                    RelativeBipedRotation = -15f,
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