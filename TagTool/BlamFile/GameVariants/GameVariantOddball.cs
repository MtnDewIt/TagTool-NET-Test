using System;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x200)]
    public class GameVariantOddball : GameVariantBase
    {
        public OddballFlags VariantFlags;
        public short ScoreToWin;
        public short ScoreUnknown;
        public short CarryingPoints;
        public sbyte KillPoints;
        public sbyte BallKillPoints;
        public sbyte CarrierKillPoints;
        public byte BallCount;
        public short BallSpawnDelay;
        public short BallInactiveRespawnDelay;
        public GameVariantPlayerTraits CarrierTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 2)]
        public byte[] Padding1 = new byte[2];

        [Flags]
        public enum OddballFlags : int
        {
            None = 0,
            AutoBallPickup = 1 << 0,
            BallEffectEnabled = 1 << 1,
        }
    }
}