using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;
using static TagTool.Tags.TagFieldFlags;
using System;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x4C, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x64, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x48, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x74, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x70, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class SurvivalModeGlobals : TagStructure
    {
        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public uint RespawnTime; // Bad! use game_engine_settings for this

        [TagField(ValidTags = new [] { "unic" })] public CachedTag SurvivalModeStrings;
        [TagField(ValidTags = new [] { "scmb", "snd!" })] public CachedTag CountdownSound;
        [TagField(ValidTags = new [] { "scmb", "snd!" })] public CachedTag RespawnSound;

        [TagField(ValidTags = ["coop"], MinVersion = CacheVersion.HaloReach)]
        public CachedTag CoopSpawningGlobals;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Wave> WavesReach;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<StateResponse> StateResponses;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<FirefightVoice> FirefightVoices;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<TeamColor> TeamColors;

        [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public List<SurvivalEvent> GeneralEvents;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public List<SurvivalEvent> SurvivalEvents;

        [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public List<ArmorCustomization> ArmorCustomizations;

        [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public List<Wave> Waves;

        [TagField(ValidTags = new[] { "sdzg" }, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public CachedTag RequiredResources;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public uint UnknownHO;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public uint UnknownHO_1;

        [TagStructure(Size = 0x108, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x10C, MinVersion = CacheVersion.HaloOnlineED)]
        public class SurvivalEvent : TagStructure
		{
            public GameEngineEventFlagsDefinition Flags;
            public TypeValue Type;
            [TagField(Flags = Label)]
            public StringId Event;
            public AudienceValue Audience;
            public short DisplayPriority;
            public short SubPriority;
            public TeamValue Team;
            public StringId DisplayString;
            public StringId DisplayMedal; // This is only valid on Flavor Events and will not award a medal for Engine Events

            [TagField(MinVersion = CacheVersion.HaloOnlineED)]
            public uint UnknownHO;

            public float DisplayTime; // seconds
            public RequiredFieldValue RequiredField;
            public RequiredFieldValue ExcludedAudience;
            public GameEngineEventSplitscreenSuppressionEnumDefinition SplitscreenSuppression;

            [TagField(Length = 0x2, Flags = Padding)]
            public byte[] Padding0;

            public StringId PrimaryString;
            public int PrimaryStringDuration; // seconds
            public StringId PluralDisplayString;
            public float SoundDelayAnnouncerOnly;
            public GameEngineSoundResponseFlagsDefinition SoundFlags;

            [TagField(Length = 0x2, Flags = Padding)]
            public byte[] Padding1;

            [TagField(ValidTags = new [] { "snd!" })] public CachedTag EnglishSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag JapaneseSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag GermanSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag FrenchSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag SpanishSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag LatinAmericanSpanishSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag ItalianSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag KoreanSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag ChineseTraditionalSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag ChineseSimplifiedSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag PortugueseSound;
            [TagField(ValidTags = new [] { "snd!" })] public CachedTag PolishSound;
            
            public CachedTag ProbablyRussianSound; // cfgt is referenced here?

            [Flags]
            public enum GameEngineEventFlagsDefinition : ushort
            {
                QuantityMessage = 1 << 0,
                SuppressText = 1 << 1
            }

            public enum TypeValue : short
            {
                General,
                Flavor,
                Slayer,
                CaptureTheFlag,
                Oddball,
                Unused,
                KingOfTheHill,
                Vip,
                Juggernaut,
                Territories,
                Assault,
                Infection,
                Survival,
                Unknown
            }

            public enum AudienceValue : short
            {
                CausePlayer,
                CauseTeam,
                EffectPlayer,
                EffectTeam,
                All
            }

            public enum TeamValue : short
            {
                NonePlayerOnly,
                Cause,
                Effect,
                All
            }

            public enum RequiredFieldValue : short
            {
                None,
                CausePlayer,
                CauseTeam,
                EffectPlayer,
                EffectTeam
            }

            [Flags]
            public enum GameEngineSoundResponseFlagsDefinition : ushort
            {
                AnnouncerSound = 1 << 0
            }

            public enum GameEngineEventSplitscreenSuppressionEnumDefinition : short
            {
                None,
                SuppressAudio,
                SuppressAudioIfOverlapping,
                SuppressText,
                SuppressAudioAndText
            }
        }

        [TagStructure(Size = 0x10)]
        public class ArmorCustomization : TagStructure
		{
            [TagField(Flags = Label)]
            public StringId CharacterName;
            public List<Region> Regions;

            [TagStructure(Size = 0x10)]
            public class Region : TagStructure
			{
                [TagField(Flags = Label)]
                public StringId RegionName;
                public List<Permutation> Permutations;

                [TagStructure(Size = 0x1C)]
                public class Permutation : TagStructure
				{
                    [TagField(Flags = Label)]
                    public StringId Name;
                    public StringId Description;
                    public short Flags;
                    public short Unknown;
                    public StringId AchievementRequired;
                    public List<Variant> Variants;

                    [TagStructure(Size = 0x8)]
                    public class Variant : TagStructure
					{
                        [TagField(Flags = Label)]
                        public StringId Region;
                        public StringId Permutation;
                    }
                }
            }
        }

        [TagStructure(Size = 0x14)]
        public class Wave : TagStructure
        {
            public StringId Name;

            [TagField(ValidTags = new[] { "wave" })]
            public CachedTag WaveTemplate;
        }

        [TagStructure(Size = 0x24, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0xC, Platform = CachePlatform.MCC)]
        public class StateResponse : TagStructure
        {
            [TagField(Platform = CachePlatform.Original)]
            public StateResponseFlags Flags;

            [TagField(Flags = Padding, Length = 2, Platform = CachePlatform.Original)]
            public byte[] Pad;

            public StateValue State;

            [TagField(Flags = Padding, Length = 2)]
            public ushort Pad1;

            public StringId FreeForAllMessage;
            public StringId TeamMessage;

            [TagField(Platform = CachePlatform.Original)]
            public CachedTag Unknown1;

            [TagField(Flags = Padding, Length = 2, Platform = CachePlatform.Original)]
            public uint Pad2;


            [Flags]
            public enum StateResponseFlags : ushort
            {
                Bit0 = 1 << 0,
                Bit1 = 1 << 1,
                Bit2 = 1 << 2,
                Bit3 = 1 << 3,
                Bit4 = 1 << 4,
                Bit5 = 1 << 5,
                Bit6 = 1 << 6,
                Bit7 = 1 << 7
            }

            public enum StateValue : ushort
            {
                WaitingForSpaceToClear,
                Observing,
                RespawningSoon,
                SittingOut,
                OutOfLives,
                Playing_Winning,
                Playing_Tied,
                Playing_Losing,
                GameOver_Won,
                GameOver_Tied,
                GameOver_Lost,
                GameOver_Tied2,
                YouHaveFlag,
                EnemyHasFlag,
                FlagNotHome,
                CarryingOddball,
                YouAreJuggernaut,
                YouControlHill,
                SwitchingSidesSoon,
                PlayerRecentlyStarted,
                YouHaveBomb,
                FlagContested,
                BombContested,
                LimitedLives_Multiple,
                LimitedLives_Single,
                LimitedLives_Final,
                Playing_Winning_Unlimited,
                Playing_Tied_Unlimited,
                Playing_Losing_Unlimited,
                WaitingToRespawn,
                WaitingForGameStart,
                Blank
            }
        }

        [TagStructure(Size = 0x48)]
        public class FirefightVoice : TagStructure
        {
            public StringId Name;
            public CachedTag DialogueMale;
            public CachedTag DialogueFemale;

            [TagField(Flags = Padding, Length = 4)]
            public byte[] Pad;

            public CachedTag SoundPreviewMale;
            public CachedTag SoundPreviewFemale;
        }

        [TagStructure(Size = 0xC)]
        public class TeamColor : TagStructure
        {
            public RealRgbColor Color;
        }
    }
}