using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ConvertCache.Definitions
{
    [TagStructure(Name = "mod_globals", Tag = "modg", Size = 0x118)]
    public class DebugModGlobalsDefinition : TagStructure 
    {
        public List<PlayerCharacterSet> PlayerCharacterSets;
        public List<PlayerCharacterCustomization> PlayerCharacterCustomizations;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x100)]
        public byte[] Unused = new byte[0x100];

        [TagStructure(Size = 0x34)]
        public class PlayerCharacterSet : TagStructure
        {
            [TagField(Length = 32)]
            public string DisplayName;
            public StringId Name;
            public float RandomChance;
            public List<ModGlobalsDefinition.PlayerCharacterSet.PlayerCharacter> Characters;
        }

        [TagStructure(Size = 0xC4)]
        public class PlayerCharacterCustomization : TagStructure
        {
            public int GlobalPlayerCharacterTypeIndex;
            public StringId CharacterName;
            public StringId CharacterDescription;

            [TagField(ValidTags = new[] { "chgd" })]
            public CachedTag HudGlobals;
            [TagField(ValidTags = new[] { "vmdx" })]
            public CachedTag VisionGlobals;
            [TagField(ValidTags = new[] { "pact" })]
            public CachedTag ActionSet;

            public List<PlayerCharacterRegionScript> RegionCameraScripts;
            public CharacterPositionInfo CharacterPositionData;
            public ModGlobalsDefinition.PlayerCharacterCustomization.PlayerCharacterColors CharacterColors;

            [TagStructure(Size = 0x6C)]
            public class PlayerCharacterRegionScript : TagStructure
            {
                public int unused;
                [TagField(Length = 32)]
                public string RegionName;
                [TagField(Length = 32)]
                public string ScriptNameWidescreen;
                [TagField(Length = 32)]
                public string ScriptNameStandard;
                public float BipedRotation;
                public float RotationDuration;
            };

            [TagStructure(Size = 0x3C)]
            public class CharacterPositionInfo : TagStructure
            {
                public ModGlobalsDefinition.PlayerCharacterCustomization.CharacterPositionInfo.FlagsValue Flags;
                public int BipedNameIndex;
                public int SettingsCameraIndex;
                public int PlatformNameIndex;
                public RealVector3d RelativeBipedPosition;
                public float RelativeBipedRotation;
                public RealPoint3d BipedPositionWidescreen;
                public RealPoint3d BipedPositionStandard;
                public float BipedRotation;
            };
        }
    }
}
