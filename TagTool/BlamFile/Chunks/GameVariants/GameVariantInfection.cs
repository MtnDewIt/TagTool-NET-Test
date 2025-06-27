using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantInfection : GameVariantBase
    {
        public InfectionFlags VariantFlags;
        public InfectionSafeHavenSettings SafeHaven;
        public InfectionNextZombieSettings NextZombie;
        public InfectionInitialZombieCountSettings InitialZombieCount;
        public short SafeHavenMovementTime;
        public sbyte ZombieKillPoints;
        public sbyte InfectionPoints;
        public sbyte SafeHavenArrivalPoints;
        public sbyte SuicidePoints;
        public sbyte BetrayalPoints;
        public sbyte LastManBonusPoints;
        public GameVariantPlayerTraits ZombieTraits;
        public GameVariantPlayerTraits FirstZombieTraits;
        public GameVariantPlayerTraits SafeHavenDefenderTraits;
        public GameVariantPlayerTraits LastHumanTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 4)]
        public byte[] Padding3;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x30, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x10, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum InfectionFlags : byte
        {
            None = 0,
            RespawnOnHavenMove = 1 << 0,
        }

        public enum InfectionSafeHavenSettings : byte
        {
            Off = 0,
            Sequential,
            Random,
        }

        public enum InfectionNextZombieSettings : byte
        {
            Winner = 0,
            Chump,
            Uncharged,
            Random,
        }

        public enum InfectionInitialZombieCountSettings : byte
        {
            Count_25_Percent = 0,
            Count_50_Percent,
            Count_1,
            Count_2,
            Count_3,
            Count_4,
            Count_5,
            Count_6,
            Count_7,
            Count_8,
            Count_9,
            Count_10,
            Count_11,
            Count_12,
            Count_13,
            Count_14,
            Count_15,
        }

        public static GameVariantInfection Decode(BitStream stream)
        {
            var variant = new GameVariantInfection();

            variant.BaseFlags = (BaseVariantFlags)stream.ReadUnsigned(1);
            variant.MiscellaneousOptions = VariantMiscellaneousOptions.Decode(stream);
            variant.RespawnOptions = VariantRespawnOptions.Decode(stream);
            variant.SocialOptions = VariantSocialOptions.Decode(stream);
            variant.MapOverrideOptions = VariantMapOverrideOptions.Decode(stream);
            variant.TeamScoringMethod = (TeamScoring)stream.ReadUnsigned(3);

            variant.VariantFlags = (InfectionFlags)stream.ReadUnsigned(1);
            variant.SafeHaven = (InfectionSafeHavenSettings)stream.ReadUnsigned(2);
            variant.NextZombie = (InfectionNextZombieSettings)stream.ReadUnsigned(2);
            variant.InitialZombieCount = (InfectionInitialZombieCountSettings)stream.ReadUnsigned(5);
            variant.SafeHavenMovementTime = (short)stream.ReadUnsigned(7);
            variant.ZombieKillPoints = (sbyte)stream.ReadUnsigned(5);
            variant.InfectionPoints = (sbyte)stream.ReadUnsigned(5);
            variant.SafeHavenArrivalPoints = (sbyte)stream.ReadUnsigned(5);
            variant.SuicidePoints = (sbyte)stream.ReadUnsigned(5);
            variant.BetrayalPoints = (sbyte)stream.ReadUnsigned(5);
            variant.LastManBonusPoints = (sbyte)stream.ReadUnsigned(5);
            variant.ZombieTraits = GameVariantPlayerTraits.Decode(stream);
            variant.FirstZombieTraits = GameVariantPlayerTraits.Decode(stream);
            variant.SafeHavenDefenderTraits = GameVariantPlayerTraits.Decode(stream);
            variant.LastHumanTraits = GameVariantPlayerTraits.Decode(stream);

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantInfection variant)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}