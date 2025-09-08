using TagTool.Ai;
using System.Collections.Generic;
using TagTool.Common;
using System.Reflection.Emit;
using TagTool.Cache;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "ai_mission_dialogue", Tag = "mdlg", Size = 0xC)]
    public class AiMissionDialogue : TagStructure
	{
        public List<AiMissionDialogueLine> Lines;

        [TagStructure(Size = 0x14)]
        public class AiMissionDialogueLine : TagStructure
        {
            [TagField(Flags = TagFieldFlags.Label)]
            public StringId Name;
            public List<AiMissionDialogueLineVariant> Variants;
            public StringId DefaultSoundEffect;

            [TagStructure(Size = 0x18)]
            public class AiMissionDialogueLineVariant : TagStructure
            {
                [TagField(Flags = TagFieldFlags.Label)]
                public StringId Designation; // 3-letter designation for the character
                public CachedTag Sound;
                public StringId SoundEffect;
            }
        }
    }
}
