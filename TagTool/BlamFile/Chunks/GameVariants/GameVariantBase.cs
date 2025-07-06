using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure(Size = 0x160, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x140, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    public class GameVariantBase : TagStructure
    {
        public VariantMiscellaneousOptions MiscellaneousOptions;
        public VariantRespawnOptions RespawnOptions;
        public VariantSocialOptions SocialOptions;
        public VariantMapOverrideOptions MapOverrideOptions;

        public BaseVariantFlags BaseFlags;
        public TeamScoring TeamScoringMethod;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x4, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] Padding1;

        [TagStructure(Size = 0x4)]
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

            public static VariantMiscellaneousOptions Decode(BitStream stream)
            {
                var miscellaneousOptions = new VariantMiscellaneousOptions();

                miscellaneousOptions.Flags = (MiscellaneousOptionsFlags)stream.ReadUnsigned(3);
                miscellaneousOptions.TimeLimit = (sbyte)stream.ReadUnsigned(8);
                miscellaneousOptions.NumberOfRounds = (sbyte)stream.ReadUnsigned(4);
                miscellaneousOptions.EarlyVictoryWinCount = (sbyte)stream.ReadUnsigned(4);

                return miscellaneousOptions;
            }

            public static void Encode(BitStream stream, VariantMiscellaneousOptions miscellaneousOptions)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [TagStructure(Size = 0x24, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
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

            [TagField(Flags = TagFieldFlags.Padding, Length = 0x3, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
            public byte[] Padding;

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

            public static VariantRespawnOptions Decode(BitStream stream)
            {
                var respawnOptions = new VariantRespawnOptions();

                respawnOptions.Flags = (RespawnFlags)stream.ReadUnsigned(4);
                respawnOptions.LivesPerRound = (byte)stream.ReadUnsigned(6);
                respawnOptions.TeamLivesPerRound = (byte)stream.ReadUnsigned(7);
                respawnOptions.RespawnTime = (byte)stream.ReadUnsigned(8);
                respawnOptions.SuicidePenalty = (byte)stream.ReadUnsigned(8);
                respawnOptions.BetrayalPenalty = (byte)stream.ReadUnsigned(8);
                respawnOptions.RespawnGrowth = (byte)stream.ReadUnsigned(4);
                respawnOptions.RespawnPlayerTraitsDuration = (byte)stream.ReadUnsigned(6);
                respawnOptions.RespawnPlayerTraits = GameVariantPlayerTraits.Decode(stream);

                return respawnOptions;
            }

            public static void Encode(BitStream stream, VariantRespawnOptions respawnOptions)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [TagStructure(Size = 0x4)]
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

            public static VariantSocialOptions Decode(BitStream stream)
            {
                var socialOptions = new VariantSocialOptions();

                stream.ReadBool();
                socialOptions.TeamChanging = (TeamChangingFlags)stream.ReadUnsigned(2);
                socialOptions.Flags = (SocialFlags)stream.ReadUnsigned(5);

                return socialOptions;
            }

            public static void Encode(BitStream stream, VariantSocialOptions socialOptions)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [TagStructure(Size = 0x7C)]
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
            public byte[] Padding;

            [Flags]
            public enum MapOverrideFlags : int
            {
                None = 0,
                GrenadesOnMap = 1 << 0,
                IndestructibleVehicles = 1 << 1,
            }

            public static VariantMapOverrideOptions Decode(BitStream stream)
            {
                var mapOverrideOptions = new VariantMapOverrideOptions();

                mapOverrideOptions.Flags = (MapOverrideFlags)stream.ReadUnsigned(2);
                mapOverrideOptions.BasePlayerTraits = GameVariantPlayerTraits.Decode(stream);
                mapOverrideOptions.WeaponSetIndex = (short)stream.ReadUnsigned(8);
                mapOverrideOptions.VehicleSetIndex = (short)stream.ReadUnsigned(8);
                mapOverrideOptions.RedPowerupTraits = GameVariantPlayerTraits.Decode(stream);
                mapOverrideOptions.BluePowerupTraits = GameVariantPlayerTraits.Decode(stream);
                mapOverrideOptions.YellowPowerupTraits = GameVariantPlayerTraits.Decode(stream);
                mapOverrideOptions.RedPowerupDuration = (byte)stream.ReadUnsigned(7);
                mapOverrideOptions.BluePowerupDuration = (byte)stream.ReadUnsigned(7);
                mapOverrideOptions.YellowPowerupDuration = (byte)stream.ReadUnsigned(7);

                return mapOverrideOptions;
            }

            public static void Encode(BitStream stream, VariantMapOverrideOptions mapOverrideOptions)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [Flags]
        public enum BaseVariantFlags : short
        {
            None = 0,
            BuiltIn = 1 << 0,
        }

        public enum TeamScoring : short
        {
            SumOfTeam,
            MinimumScore,
            MaximumScore,
            Default,
        }

        public static GameVariantBase Decode(BitStream stream)
        {
            var variant = new GameVariantBase();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantBase variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}