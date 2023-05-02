using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
{
    partial class PortingCacheCommand : Command 
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
                                DisplayName = $@"vanilla",
                                Name = StringId.Invalid,
                                RandomChance = 0.1f,
                                Characters = new List<ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter>()
                                {
                                    new ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter()
                                    {
                                        DisplayName = $@"masterchief",
                                        Name = CacheContext.StringTable.GetStringId($@"masterchief"),
                                        RandomChance = 0.1f,
                                    },
                                    new ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter()
                                    {
                                        DisplayName = $@"dervish",
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
                                CharacterName = CacheContext.StringTable.GetStringId($@"masterchief"),
                                CharacterDescription = StringId.Invalid,
                                HudGlobals = CacheContext.TagCache.GetTag<ChudGlobalsDefinition>($@"ui\chud\globals"),
                                VisionGlobals = CacheContext.TagCache.GetTag<VisionMode>($@"globals\default_vision_mode"),
                                ActionSet = null,
                                CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                                {
                                    flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.RotateInCustomization,
                                    BipedNameIndex = 15,
                                    SettingsCameraIndex = -1,
                                    PlatformNameIndex = -1,
                                    BipedPositionWidescreen = new RealPoint3d(-45f, -10f, -35f),
                                    BipedPositionStandard = new RealPoint3d(-45f, -10f, -35f),
                                },
                                CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                                {
                                    ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor,
                                    Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                                    {
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"red"),
                                            Description = CacheContext.StringTable.GetStringId($@"red"),
                                            Default = new ArgbColor(255, 0, 0, 255),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
                                    },
                                },
                            },
                            new ModGlobalsDefinition.PlayerCharacterCustomization()
                            {
                                GlobalPlayerCharacterTypeIndex = 1,
                                CharacterName = CacheContext.StringTable.GetStringId($@"dervish"),
                                CharacterDescription = StringId.Invalid,
                                HudGlobals = CacheContext.TagCache.GetTag<ChudGlobalsDefinition>($@"ui\chud\globals"),
                                VisionGlobals = CacheContext.TagCache.GetTag<VisionMode>($@"globals\default_vision_mode"),
                                ActionSet = null,
                                CharacterPositionData = new ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo()
                                {
                                    flags = ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue.RotateInCustomization,
                                    BipedNameIndex = 14,
                                    SettingsCameraIndex = -1,
                                    PlatformNameIndex = -1,
                                    BipedPositionWidescreen = new RealPoint3d(-45f, -10f, -35f),
                                    BipedPositionStandard = new RealPoint3d(-45f, -10f, -35f),
                                },
                                CharacterColors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors()
                                {
                                    ValidColorFlags = ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorFlagsValue.PrimaryColor,
                                    Colors = new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock[5]
                                    {
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock
                                        {
                                            Name = CacheContext.StringTable.GetStringId($@"red"),
                                            Description = CacheContext.StringTable.GetStringId($@"red"),
                                            Default = new ArgbColor(255, 0, 0, 255),
                                        },
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
                                        new ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors.ChangeColorBlock{},
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