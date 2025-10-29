using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.Audio
{
    [TagStructure(Size = 0x1C, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2PC)]
    [TagStructure(Size = 0x24, MinVersion = CacheVersion.Halo3Retail)]
    public class Promotion : TagStructure
	{
        public List<Rule> Rules;
        public List<RuntimeTimer> RuntimeTimers;

        public int RuntimeActivePromotionIndex;
        public int RuntimeLastPromotionTime;
        public int RuntimeSuppressionTimeout;

        [TagStructure(Size = 0x10)]
        public class Rule : TagStructure
		{
            public short PitchRangeIndex;
            public short MaximumPlayingCount;

            /// <summary>
            /// time from when first permutation plays to when another sound from an equal or lower promotion can play
            /// </summary>
            public float SuppressionTime; // seconds

            public int RuntimeRolloverTime;
            public int ImpulsePromotionTime;
        }

        [TagStructure(Size = 0x4)]
        public class RuntimeTimer : TagStructure
		{
            public int Timer;
        }
    }
}