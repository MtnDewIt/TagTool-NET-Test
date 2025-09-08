using TagTool.Cache;
using System;
using TagTool.Audio;

namespace TagTool.Tags.Definitions.Gen2
{
    [TagStructure(Name = "sound", Tag = "snd!", Platform = CachePlatform.Original, Size = 0x14)]
    [TagStructure(Name = "sound", Tag = "snd!", Platform = CachePlatform.MCC, Size = 0x1C)]
    public class Sound : TagStructure
    {
        public Gen2SoundFlags Flags;
        public SoundClass Class;

        [TagField(Platform = CachePlatform.Original)]
        public SampleRate SampleRate;
        [TagField(Platform = CachePlatform.Original)]
        public Gen2Encoding Encoding;
        [TagField(Platform = CachePlatform.Original)]
        public Compression Compression;

        [TagField(Platform = CachePlatform.MCC)]
        public byte CodecIndex;
        [TagField(Platform = CachePlatform.MCC)]
        public short RemasteredSoundReferenceIndex;

        public short PlaybackParamaterIndex;
        public short PitchRangeIndex;
        public sbyte PitchRangeCount;
        public sbyte ScaleIndex;
        public sbyte PromotionIndex;
        public sbyte CustomPlaybackIndex;
        public short ExtraInfoIndex;
        public int MaximumPlayTime;

        [TagField(Platform = CachePlatform.MCC)]
        public float InnerSilenceDistance;  // don't play below this distance
        [TagField(Platform = CachePlatform.MCC)]
        public short FirstReflectionParametersIndex;
        [TagField(Platform = CachePlatform.MCC)]
        public byte ReflectionParametersCount;
        [TagField(Platform = CachePlatform.MCC)]
        public byte LowPassCutoffParametersIndex;

        [Flags]
        public enum Gen2SoundFlags : ushort
        {
            FitToAdpcmBlocksize = 1 << 0,
            SplitLongSoundIntoPermutations = 1 << 1,
            /// <summary>
            /// always play as 3d sound, even in first person
            /// </summary>
            AlwaysSpatialize = 1 << 2,
            /// <summary>
            /// disable occlusion/obstruction for this sound
            /// </summary>
            NeverObstruct = 1 << 3,
            InternalDonTTouch = 1 << 4,
            UseHugeSoundTransmission = 1 << 5,
            LinkCountToOwnerUnit = 1 << 6,
            PitchRangeIsLanguage = 1 << 7,
            DonTUseSoundClassSpeakerFlag = 1 << 8,
            DonTUseLipsyncData = 1 << 9,
            PlayOnlyInLegacyMode = 1 << 10,
            PlayOnlyInRemasteredMode = 1 << 11,
        }  
    }
}

