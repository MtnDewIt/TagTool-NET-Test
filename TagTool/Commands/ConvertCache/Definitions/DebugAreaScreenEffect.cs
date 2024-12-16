using System.Collections.Generic;
using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Tags;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Commands.ConvertCache.Definitions
{
    [TagStructure(Name = "area_screen_effect", Tag = "sefc", Size = 0xC)]
    public class DebugAreaScreenEffect : TagStructure 
    {
        public List<ScreenEffectBlock> ScreenEffects;

        [TagStructure(Size = 0x9C)]
        public class ScreenEffectBlock : TagStructure
        {
            [TagField(Flags = Label)]
            public StringId Name;

            public AreaScreenEffect.ScreenEffectBlock.SefcFlagBits Flags;
            public AreaScreenEffect.HiddenFlagBits HiddenFlags;

            public float MaximumDistance;

            public TagFunction DistanceFalloffFunction = new TagFunction { Data = new byte[0] };

            public float Lifetime;

            public TagFunction TimeEvolutionFunction = new TagFunction { Data = new byte[0] };
            public TagFunction AngleFalloffFunction = new TagFunction { Data = new byte[0] };

            public float ExposureBoost;
            public float HueLeft;
            public float HueRight;
            public float Saturation;
            public float Desaturation;
            public float ContrastEnhance;
            public float GammaEnhance;    
            public float GammaReduce;

            public RealRgbColor ColorFilter;
            public RealRgbColor ColorFloor;

            public float VisionMode;
            public float VisionNoise;

            public CachedTag ScreenShader;
        }
    }
}
