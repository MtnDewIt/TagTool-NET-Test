using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    //[TagStructure(Size = 0xB0, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x90, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    public class GameVariantSlayer : GameVariantBase
    {
        public short ScoreToWin;
        
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreToWinEarly;
        
        public short KillPoints;
        public sbyte AssistPoints;
        public sbyte DeathPoints;
        public sbyte SuicidePoints;
        public sbyte BetrayalPoints;
        public sbyte LeaderKilledPoints;
        public sbyte EliminationPoints;
        public sbyte AssassinationsPoints;
        public sbyte HeadshotPoints;
        public sbyte MeleePoints;
        public sbyte StickyPoints;
        public sbyte SplatterPoints;
        public sbyte KillingSpreePoints;
        public GameVariantPlayerTraits LeaderTraits;
        
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
        public byte[] Padding1;

        //[TagField(Flags = TagFieldFlags.Padding, Length = 0x80, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x60, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;
    }
}