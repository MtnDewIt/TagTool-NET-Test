using TagTool.Cache;
using System;
using System.Collections.Generic;
using static TagTool.Tags.TagFieldFlags;
using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "sound_classes", Tag = "sncl", Size = 0xC, MinVersion = CacheVersion.Halo3Retail)]
    public class SoundClasses : TagStructure
	{
        public List<Class> Classes;

        [TagStructure(Size = 0x98, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xC0, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0xD4, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
        [TagStructure(Size = 0xA0, MinVersion = CacheVersion.EldoradoED)]
        public class Class : TagStructure
		{
            public short MaxSoundsPerTag;
            public short MaxSoundsPerObject;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public short MaxSoundsPerClass;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public short MaxSoundsPerObjectPerClass;

            public int PreemptionTime; // replaces other instances after this many milliseconds
            public InternalFlagBits InternalFlags;
            public ExternalFlagBits ClassFlags;
            public short Priority; // higher means more important
            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public CacheMissModeValue CacheMissMode;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public CacheMissModeODSTValue CacheMissModeODST;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public AccousticsFlagsValue BindToAccoustics;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public SuppressSpatializationFlagsValue SuppressSpatialization;
            [TagField(Length = 3, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.Halo3ODST)]
            public byte[] Padding;

            public SoundClassPropagation AirPropagation;
            public SoundClassPropagation UnderwaterPropagation;

            public float OverrideSpeakerGain;

            //
            // Distance Parameters
            //

            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public Bounds<float> DefaultDistanceBounds;
            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public Bounds<float> DistanceBounds;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public SoundClassDistanceParameters DistanceParameters;
            public Bounds<float> GainBounds;

            //
            // Unknown Reach
            //

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float EquipmentLowpass; // sets the lowpass wet mix when an equiment is active (wetmix)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float EnvironmentForcedLowpass; // sets the lowpass wet mix when an environment forced lowpass is active (wetmix)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float EffectLowpass; // sets the lowpass wet mix when a lowpass effect is active (wetmix)

            public SoundClassDucking CutsceneDucking;
            public SoundClassDucking ScriptedDialogDucking;
            public SoundClassDucking CortanaEffectDucking;

            //
            // ODST unique part
            //

            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
            public SoundClassDucking ArgDucking;
            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
            public SoundClassDucking PdaDucking;

            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public float UnknownCortanaEffect;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public SoundClassDucking BetweenRoundsDucking;

            public float DopplerFactor;
            public StereoPlaybackTypeValue StereoPlaybackType;
            [TagField(Length = 3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding2;    

            public float TransmissionMultiplier;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float TransmissionInterpolationTime; // default is 0.5 seconds (seconds)

            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public float ObstructionMaxBend;
            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public float OcclusionMaxBend;

            public int XmaCompressionLevel;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public float SendToLfeGain; // When send (mono) to lfe is set, this is how much additional gain to apply (dB)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int MinimumFacialAnimationDelay; // setting this forces sounds of this class to be delayed while the facial animation resource loads. (msecs)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int MaximumFacialAnimationDelay; // setting this allows sounds of this class to be delayed while the facial animation resource loads. (msecs)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int MaximumFacialAnimationBlend; // setting this makes sounds blends in facial animation (will cut off at maximum facial animation delay). (msecs)

            [Flags]
            public enum InternalFlagBits : ushort
            {
                None,
                Valid = 1 << 0,
                IsSpeech = 1 << 1,
                Scripted = 1 << 2,
                StopsWithObject = 1 << 3,
                ValidXmaCompressionLevel = 1 << 4,
                ValidDopplerFactor = 1 << 5,
                ValidObstructionFactor = 1 << 6,
                Multilingual = 1 << 7,
                ValidUnderwaterPropagation = 1 << 8,
                ValidSuppressSpatialization = 1 << 9,
                Bit10 = 1 << 10,
                StopsWithDeadObject = 1 << 11,
                Bit12 = 1 << 12,
                Bit13 = 1 << 13,
                Bit14 = 1 << 14,
                Bit15 = 1 << 15
            }

            [Flags]
            public enum ExternalFlagBits : ushort
            {
                None,
                CanPlayDuringPause = 1 << 0,
                DryStereoMix = 1 << 1,
                PlaysThroughObjects = 1 << 2,
                IsCenterUnspatialized = 1 << 3,
                MonoLfe = 1 << 4,
                Deterministic = 1 << 5,
                UseHugeTransmission = 1 << 6,
                AlwaysUseSpeakers = 1 << 7,
                IsAvailableOnMainmenu = 1 << 8,
                IgnoreStereoHeadroom = 1 << 9,
                LoopFadeOutIsLinear = 1 << 10,
                StopWhenObjectDies = 1 << 11,
                DontFadeOnGameOver = 1 << 12,
                DontPromotePriorityByProximity = 1 << 13,
                ClassPlaysOnMainmenu = 1 << 14,
                Bit15 = 1 << 15,
            }

            public enum CacheMissModeValue : short
            {
                Discard,
                Postpone,
            }

            public enum CacheMissModeODSTValue : sbyte
            {
                Discard,
                Postpone,
            }

            [Flags]
            public enum AccousticsFlagsValue : sbyte
            {
               Outside = (1 << 0),
               Inside = (1 << 1)
            }

            [Flags]
            public enum SuppressSpatializationFlagsValue : byte
            {
                FirstPerson = 1 << 0,
                ThirdPerson = 1 << 1
            }

            public enum StereoPlaybackTypeValue : sbyte
            {
                FirstPerson,
                Ambient,
            }

            [TagStructure(Size = 0x10)]
            public class SoundClassDucking : TagStructure
            {
                public float GainDB;
                public float FadeInTime;
                public float SustainTime;
                public float FadeOutTime;
            }

            [TagStructure(Size = 0x10)]
            public class SoundClassPropagation : TagStructure
            {
                public float ReverbGain;
                public float DirectPathGain;
                public float BaseObstruction;
                public float BaseOcclusion;
            }

            [TagStructure(Size = 0x20, MinVersion = CacheVersion.HaloReach)]
            public class SoundClassDistanceParameters : TagStructure
            {
                /// <summary>
                /// don't obstruct below this distance
                /// </summary>
                public float DontObstructDistance;
                /// <summary>
                /// don't play below this distance
                /// </summary>
                public float DontPlayDistance;
                /// <summary>
                /// start playing at full volume at this distance
                /// </summary>
                public float AttackDistance;
                /// <summary>
                /// start attenuating at this distance
                /// </summary>
                public float MinimumDistance;
                /// <summary>
                /// set attenuation to sustain db at this distance
                /// </summary>
                public float SustainBeginDistance;
                /// <summary>
                /// continue attenuating to silence at this distance
                /// </summary>
                public float SustainEndDistance;
                /// <summary>
                /// the distance beyond which this sound is no longer audible
                /// </summary>
                public float MaximumDistance;
                /// <summary>
                /// the amount of attenuation between sustain begin and end
                /// </summary>
                public float SustainDecibels;
            }
        }
    }
}