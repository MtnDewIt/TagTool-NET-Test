using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ConvertCache.Definitions
{
    [TagStructure(Name = "player_action_set", Tag = "pact", Size = 0x148)]
    public class DebugPlayerActionSet : TagStructure 
    {
        public WidgetData Widget;
        public List<Action> Actions;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x100)]
        public byte[] Unused = new byte[0x100];

        [TagStructure(Size = 0x3C)]
        public class WidgetData : TagStructure
        {
            [TagField(Length = 32)]
            public string Title;
            public PlayerActionSet.WidgetData.WidgetType Type;
            public ushort Flags;
            public byte[] Stylesheet;
        }

        [TagStructure(Size = 0x5C)]
        public class Action : TagStructure
        {
            [TagField(Length = 32)]
            public string Title;
            [TagField(Length = 32)]
            public string IconName;
            public StringId AnimationEnter;
            public StringId AnimationIdle;
            public StringId AnimationExit;
            public PlayerActionSet.Action.ActionFlags Flags;
            public List<Unit.UnitCameraBlock> OverrideCamera;
        }
    }
}
