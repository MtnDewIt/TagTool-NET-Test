using System;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x200)]
    public class GameVariantKing : GameVariantBase
    {
        public KingFlags VariantFlags;
        public short ScoreToWin;
        public short ScoreUnknown;
        public MovingHillSettings MovingHill;
        public MovingHillOrderSettings MovingHillOrder;
        public sbyte InsideHillPoints;
        public sbyte OutsideHillPoints;
        public sbyte UncontestedHillBonus;
        public sbyte KillPoints;
        public GameVariantPlayerTraits InsideHillTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 6)]
        public byte[] Padding1 = new byte[6];

        [Flags]
        public enum KingFlags : int
        {
            None = 0,
            OpaqueHill = 1 << 0,
        }

        public enum MovingHillSettings : sbyte
        {
            Off = 0,
            Seconds_10,
            Seconds_15,
            Seconds_30,
            Minutes_1,
            Minutes_2,
            Minutes_3,
            Minutes_4,
            Minutes_5,
        }

        public enum MovingHillOrderSettings : sbyte
        {
            Random = 0,
            Sequence,
        }
    }
}