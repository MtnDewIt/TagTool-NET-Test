using System;
using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "gui_widget_sprite_animation_definition", Tag = "wspr", Size = 0x24, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "gui_widget_sprite_animation_definition", Tag = "wspr", Size = 0x2C, MinVersion = CacheVersion.EldoradoED)]
    public class GuiWidgetSpriteAnimationDefinition : TagStructure
    {
        public WidgetComponentAnimationFlags Flags;
        public List<WidgetSpriteAnimationKeyframeBlock> Keyframes;
        public TagFunction DefaultFunction;

        [TagField(MinVersion = CacheVersion.EldoradoED)]
        public uint Unknown;
        [TagField(MinVersion = CacheVersion.EldoradoED)]
        public uint Unknown2;

        [Flags]
        public enum WidgetComponentAnimationFlags : uint
        {
            LoopCyclic = 1 << 0,
            LoopReverse = 1 << 1
        }

        [TagStructure(Size = 0x14)]
        public class WidgetSpriteAnimationKeyframeBlock : TagStructure
        {
            public int TimeOffset; // milliseconds
            public short SpriteSequence;
            public short SpriteFrame;
            public List<TagFunction> CustomTransitionFxn;
        }
    }
}