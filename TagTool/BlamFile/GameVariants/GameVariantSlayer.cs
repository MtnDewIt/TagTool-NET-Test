using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x200, Align = 0x1)]
    public class GameVariantSlayer : GameVariantBase
    {
        public short ScoreToWin;
        public short ScoreUnknown;
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

        [TagField(Flags = TagFieldFlags.Padding, Length = 2)]
        public byte[] Padding1 = new byte[2];
    }
}