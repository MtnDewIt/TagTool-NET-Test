using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x4C, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x64, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x48, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x74, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Name = "survival_mode_globals", Tag = "smdt", Size = 0x70, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class SurvivalModeGlobals : TagStructure
    {
        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public float RespawnTime;

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
        public List<MultiplayerEventResponse> GeneralEvents;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public List<MultiplayerEventResponse> SurvivalEvents;

        [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public List<ArmorCustomization> ArmorCustomizations;

        [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public List<Wave> Waves;

        [TagField(ValidTags = new[] { "sdzg" }, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public CachedTag RequiredResources;

        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public uint UnknownHO;
        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public uint UnknownHO_1;

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