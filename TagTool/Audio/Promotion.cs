using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.Audio
{
    [TagStructure(Size = 0x1C, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2PC)]
    [TagStructure(Size = 0x24, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x30, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Size = 0x24, MinVersion = CacheVersion.HaloReach)]
    public class Promotion : TagStructure
	{
        public List<Rule> Rules;
        public List<RuntimeTimer> RuntimeTimers;

        public uint RuntimeActivePromotionIndex;
        public uint RuntimeLastPromotionTime;
        public uint RuntimeSuppressionTimeout;

        [TagField(Gen = CacheGeneration.Eldorado)]
        public uint LongestPermutationDuration;
        [TagField(Gen = CacheGeneration.Eldorado)]
        public uint TotalSampleSize;
        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding, Gen = CacheGeneration.Eldorado)]
        public uint Padding;

        [TagStructure(Size = 0x10)]
        public class Rule : TagStructure
		{
            public short PitchRangeIndex;
            public short MaximumPlayingCount;

            /// <summary>
            /// time from when first permutation plays to when another sound from an equal or lower promotion can play
            /// </summary>
            public float SuppressionTime;   // seconds

            public uint RuntimeRolloverTime;
            public uint ImpulsePromotionTime;
        }

        [TagStructure(Size = 0x4)]
        public class RuntimeTimer : TagStructure
		{
            public int Timer;
        }
    }
}