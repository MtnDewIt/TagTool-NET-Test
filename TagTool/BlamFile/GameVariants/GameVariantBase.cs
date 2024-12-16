using System;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x1D0, Align = 0x1)]
    public class GameVariantBase : TagStructure
    {
        public long VariantChecksum;

        [TagField(Length = 32)]
        public string VariantName;

        public ContentItemMetadata Metadata;
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

        [TagStructure(Size = 0x28, Align = 0x1)]
        public class VariantRespawnOptions : TagStructure
        {
            public RespawnFlags Flags;
            public byte LivesPerRound;
            public byte TeamLivesPerRound;
            public byte RespawnTime;
            public byte SuicidePenalty;
            public byte BetrayalPenalty;
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

            // Not entirely sure if this enum is correct
            [Flags]
            public enum SocialFlags : int
            {
                None = 0,
                FriendlyFireEnabled = 1 << 0,
                BetrayalBootingEnabled = 1 << 1,
                EnemyVoiceEnabled = 1 << 3,
                OpenChannelVoiceEnabled = 1 << 4,
                DeadPlayerVoiceEnabled = 1 << 5,
                SpartansVsElitesEnabled = 1 << 6,
                ObserversEnabled = 1 << 7,
                TeamChangingEnabled = 1 << 8,
                TeamChangingBalancingOnlyEnabled = 1 << 9,
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