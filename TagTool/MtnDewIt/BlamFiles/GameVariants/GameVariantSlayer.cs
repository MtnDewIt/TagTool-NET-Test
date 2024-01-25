using System;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    [TagStructure(Size = 0x200)]
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
        public PlayerTraits LeaderTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 2)]
        public byte[] Padding1 = new byte[2];
    }
}