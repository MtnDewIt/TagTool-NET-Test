using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_mod_globals_mod_globals : TagFile
    {
        public multiplayer_mod_globals_mod_globals(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<ModGlobalsDefinition>($@"multiplayer\mod_globals");
            var modg = CacheContext.Deserialize<ModGlobalsDefinition>(Stream, tag);
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
                            BipedRotation = 50f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "body",
                            ScriptNameWidescreen = "body_camera_wide",
                            ScriptNameStandard = "body_camera_standard",
                            BipedRotation = 60f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "leftshoulder",
                            ScriptNameWidescreen = "leftshoulder_camera_wide",
                            ScriptNameStandard = "leftshoulder_camera_standard",
                            BipedRotation = 40f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "rightshoulder",
                            ScriptNameWidescreen = "rightshoulder_camera_wide",
                            ScriptNameStandard = "rightshoulder_camera_standard",
                            BipedRotation = 110f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "emblem",
                            ScriptNameWidescreen = "rightshoulder_camera_wide",
                            ScriptNameStandard = "rightshoulder_camera_standard",
                            BipedRotation = 110f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "exit",
                            ScriptNameWidescreen = "exit_subcamera",
                            ScriptNameStandard = "exit_subcamera",
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "colorsTertiary",
                            ScriptNameWidescreen = "helmet_camera_wide",
                            ScriptNameStandard = "helmet_camera_standard",
                            BipedRotation = 50f,
                            RotationDuration = 0.5f,
                        },
                    },
                    CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                    {
                        flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera | ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.RotateInCustomization,
                        BipedNameIndex = 1,
                        SettingsCameraIndex = 15,
                        PlatformNameIndex = 0,
                        RelativeBipedPosition = new RealVector3d(0f, 0f, 0f),
                    },
                    CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                    {
                        ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.TertiaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                        TeamOverrideFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                        Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                        {
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_primary"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_primary_desc"),
                                Default = new ArgbColor(0, 84, 110, 38),
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_secondary"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_secondary_desc"),
                                Default = new ArgbColor(0, 84, 110, 38),
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_visor"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_visor_desc"),
                                Default = new ArgbColor(0, 255, 127, 0),
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_light"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_light_desc"),
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
                            BipedRotation = 50f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "body",
                            ScriptNameWidescreen = "body_camera_wide",
                            ScriptNameStandard = "body_camera_standard",
                            BipedRotation = 70f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "leftshoulder",
                            ScriptNameWidescreen = "leftshoulder_camera_wide",
                            ScriptNameStandard = "leftshoulder_camera_standard",
                            BipedRotation = 0f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "rightshoulder",
                            ScriptNameWidescreen = "rightshoulder_camera_wide",
                            ScriptNameStandard = "rightshoulder_camera_standard",
                            BipedRotation = 70f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "emblem",
                            ScriptNameWidescreen = "rightshoulder_camera_wide",
                            ScriptNameStandard = "rightshoulder_camera_standard",
                            BipedRotation = 70f,
                            RotationDuration = 0.5f,
                        },
                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterRegionScript
                        {
                            RegionName = "exit",
                            ScriptNameWidescreen = "exit_subcamera",
                            ScriptNameStandard = "exit_subcamera",
                            RotationDuration = 0.5f,
                        },
                    },
                    CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                    {
                        flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.PlaceBipedRelativeToCamera | ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.RotateInCustomization,
                        BipedNameIndex = 26,
                        SettingsCameraIndex = 15,
                        PlatformNameIndex = 0,
                        RelativeBipedPosition = new RealVector3d(0.3f, 0.04f, 0f),
                        RelativeBipedRotation = -10f,
                    },
                    CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                    {
                        ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.TertiaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.QuaternaryColor,
                        TeamOverrideFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor | ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.SecondaryColor,
                        Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                        {
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_primary"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_primary_desc"),
                                Default = new ArgbColor(0, 11, 33, 86),
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_secondary"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_secondary_desc"),
                                Default = new ArgbColor(0, 29, 16, 82),
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_detail"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_detail_desc"),
                                Default = new ArgbColor(0, 255, 255, 255),
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                Name = CacheContext.StringTable.GetStringId($@"cef_color_light"),
                                Description = CacheContext.StringTable.GetStringId($@"cef_color_light_desc"),
                                Default = new ArgbColor(0, 27, 255, 104),
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                            {
                                
                            },
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, modg);
        }
    }
}
