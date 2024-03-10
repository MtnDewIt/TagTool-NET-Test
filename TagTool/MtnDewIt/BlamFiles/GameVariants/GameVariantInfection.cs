using System;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    [Flags]
    public enum GameVariantInfectionFlags : byte 
    {
        RespawnOnHavenMove = 0,
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


    [TagStructure(Size = 0x250)]
    public class GameVariantInfection : GameVariantBase 
    {
        public GameVariantInfectionFlags VariantFlags;
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
        public PlayerTraits ZombieTraits;
        public PlayerTraits FirstZombieTraits;
        public PlayerTraits SafeHavenDefenderTraits;
        public PlayerTraits LastHumanTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 4)]
        public byte[] Padding1 = new byte[4];
    }
}