using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0xAF, Align = 0x1, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0xB0, Align = 0x1, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    public class GameVariantBase : TagStructure
    {
        public VariantMiscellaneousOptions MiscellaneousOptions;
        public VariantRespawnOptions RespawnOptions;
        public VariantSocialOptions SocialOptions;
        public VariantMapOverrideOptions MapOverrideOptions;
        public BaseVariantFlags BaseFlags;
        public TeamScoring TeamScoringMethod;

        [TagStructure(Size = 0x4, Align = 0x1)]
        public class VariantMiscellaneousOptions : TagStructure
        {
            public MiscellaneousOptionsFlags Flags;
            public sbyte TimeLimit;
            public sbyte NumberOfRounds;
            public sbyte EarlyVictoryWinCount;

            [Flags]
            public enum MiscellaneousOptionsFlags : byte
            {
                None = 0,
                TeamsEnabled = 1 << 0,
                RoundResetPlayers = 1 << 1,
                RoundResetMap = 1 << 2,
                SpectatingEnabled = 1 << 3,
            }
        }

        [TagStructure(Size = 0x23, Align = 0x1, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x28, Align = 0x1, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public class VariantRespawnOptions : TagStructure
        {
            public RespawnFlags Flags;
            public byte LivesPerRound;
            public byte TeamLivesPerRound;

            [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
            public byte UnknownTime;

            public byte RespawnTime;
            public byte SuicidePenalty;
            public byte BetrayalPenalty;

            [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline700123)]
            public byte UnknownPenalty;

            public byte RespawnGrowth;
            public byte RespawnPlayerTraitsDuration;

            [TagField(Flags = TagFieldFlags.Padding, Length = 3)]
            public byte[] Padding1 = new byte[3];

            public GameVariantPlayerTraits RespawnPlayerTraits;

            [Flags]
            public enum RespawnFlags : byte
            {
                None,
                InheritRespawnTime = 1 << 0,
                RespawnWithTeammate = 1 << 1,
                RespawnAtLocation = 1 << 2,
                RespawnOnKills = 1 << 3,
                AutoRespawnDisabled = 1 << 4,
            }
        }

        [TagStructure(Size = 0x4, Align = 0x1)]
        public class VariantSocialOptions : TagStructure
        {
            public SocialFlags Flags;
            public TeamChangingFlags TeamChanging;

            [Flags]
            public enum SocialFlags : short
            {
                None = 0,
                FriendlyFireEnabled = 1 << 0,
                BetrayalBootingEnabled = 1 << 1,
                EnemyVoiceEnabled = 1 << 3,
                OpenChannelVoiceEnabled = 1 << 4,
                DeadPlayerVoiceEnabled = 1 << 5,
                SpartansVsElitesEnabled = 1 << 6,
                ObserversEnabled = 1 << 7,
            }

            public enum TeamChangingFlags : short
            {
                None = 0,
                TeamChangingEnabled,
                TeamChangingBalancingOnlyEnabled,
            }
        }

        [TagStructure(Size = 0x7C, Align = 0x1)]
        public class VariantMapOverrideOptions : TagStructure
        {
            public MapOverrideFlags Flags;
            public GameVariantPlayerTraits BasePlayerTraits;
            public short WeaponSetIndex;
            public short VehicleSetIndex;
            public GameVariantPlayerTraits RedPowerupTraits;
            public GameVariantPlayerTraits BluePowerupTraits;
            public GameVariantPlayerTraits YellowPowerupTraits;
            public byte RedPowerupDuration;
            public byte BluePowerupDuration;
            public byte YellowPowerupDuration;

            [TagField(Flags = TagFieldFlags.Padding, Length = 1)]
            public byte[] Padding1 = new byte[1];

            [Flags]
            public enum MapOverrideFlags : int
            {
                None = 0,
                GrenadesOnMap = 1 << 0,
                IndestructibleVehicles = 1 << 1,
            }
        }

        [Flags]
        public enum BaseVariantFlags : short
        {
            BuiltIn = 0,
        }

        public enum TeamScoring : short
        {
            SumOfTeam,
            MinimumScore,
            MaximumScore,
            Default,
        }
    }
}