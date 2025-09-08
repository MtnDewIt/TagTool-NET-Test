using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TagTool.Cache;
using TagTool.Common;
using static TagTool.Audio.SoundClass;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions.Gen2
{
    [TagStructure(Name = "sound_classes", Tag = "sncl", Size = 0x8)]
    public class SoundClasses : TagStructure
    {
        public List<SoundClassBlock> Classes;
        
        [TagStructure(Size = 0x5C, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x78, Platform = CachePlatform.MCC)]
        public class SoundClassBlock : TagStructure
        {
            /// <summary>
            /// maximum number of sounds playing per individual sound tag
            /// </summary>
            public short MaxSoundsPerTag116;
            /// <summary>
            /// maximum number of sounds of this type playing on an object
            /// </summary>
            public short MaxSoundsPerObject116;
            /// <summary>
            /// replaces other instances after this many milliseconds
            /// </summary>
            public int PreemptionTime; // ms
            public InternalFlagsValue InternalFlags;
            public FlagsValue Flags;
            public short Priority;
            public CacheMissModeValue CacheMissMode;
            /// <summary>
            /// how much reverb applies to this sound class
            /// </summary>
            public float ReverbGain; // dB
            public float OverrideSpeakerGain; // dB
            public Bounds<float> DistanceBounds;
            public Bounds<float> GainBounds; // dB
            public float CutsceneDucking; // dB
            public float CutsceneDuckingFadeInTime; // seconds
            /// <summary>
            /// how long this lasts after the cutscene ends
            /// </summary>
            public float CutsceneDuckingSustainTime; // seconds
            public float CutsceneDuckingFadeOutTime; // seconds
            public float ScriptedDialogDucking; // dB
            public float ScriptedDialogDuckingFadeInTime; // seconds
            /// <summary>
            /// how long this lasts after the scripted dialog ends
            /// </summary>
            public float ScriptedDialogDuckingSustainTime; // seconds
            public float ScriptedDialogDuckingFadeOutTime; // seconds
            public float DopplerFactor;
            public StereoPlaybackTypeValue StereoPlaybackType;
            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;
            public float TransmissionMultiplier;
            public float ObstructionMaxBend;
            public float OcclusionMaxBend;

            [TagField(Platform = CachePlatform.MCC)]
            public float InnerSilenceDistance;
            [TagField(Platform = CachePlatform.MCC)]
            public float LowPassMinimumDistance;
            [TagField(Platform = CachePlatform.MCC)]
            public float LowPassMaximumDistance;
            [TagField(Platform = CachePlatform.MCC)]
            public byte[] Function;
            [TagField(Platform = CachePlatform.MCC)]
            public List<SoundClassDucking> ExtDucking;

            
            [Flags]
            public enum InternalFlagsValue : ushort
            {
                Valid = 1 << 0,
                IsSpeech = 1 << 1,
                Scripted = 1 << 2,
                StopsWithObject = 1 << 3,
                Unused = 1 << 4,
                ValidDopplerFactor = 1 << 5,
                ValidObstructionFactor = 1 << 6,
                Multilingual = 1 << 7
            }
            
            [Flags]
            public enum FlagsValue : ushort
            {
                PlaysDuringPause = 1 << 0,
                DryStereoMix = 1 << 1,
                NoObjectObstruction = 1 << 2,
                UseCenterSpeakerUnspatialized = 1 << 3,
                SendMonoToLfe = 1 << 4,
                Deterministic = 1 << 5,
                UseHugeTransmission = 1 << 6,
                AlwaysUseSpeakers = 1 << 7,
                DonTStripFromMainMenu = 1 << 8,
                IgnoreStereoHeadroom = 1 << 9,
                LoopFadeOutIsLinear = 1 << 10,
                StopWhenObjectDies = 1 << 11,
                AllowCacheFileEditing = 1 << 12
            }
            
            public enum CacheMissModeValue : short
            {
                Discard,
                Postpone
            }
            
            public enum StereoPlaybackTypeValue : sbyte
            {
                FirstPerson,
                Ambient
            }

            [TagStructure(Size = 0x14)]
            public class SoundClassDucking : TagStructure
            {
                [TagField(EnumType = typeof(int))]
                public SoundClassHalo2 SoundClass;
                public float GainDB;
                public float FadeInTime;
                public float SustainTime;
                public float FadeOutTime;
            }
        }
    }
}

