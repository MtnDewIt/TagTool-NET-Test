using System;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    [Flags]
    public enum GameVariantOddballFlags : int 
    {
        AutoBallPickup = 0,
        BallEffectEnabled,
    }

    [TagStructure(Size = 0x200)]
    public class GameVariantOddball : GameVariantBase
    {
        public GameVariantOddballFlags VariantFlags;
        public short ScoreToWin;
        public short ScoreUnknown;
        public short CarryingPoints;
        public sbyte KillPoints;
        public sbyte BallKillPoints;
        public sbyte CarrierKillPoints;
        public byte BallCount;
        public short BallSpawnDelay;
        public short BallInactiveRespawnDelay;
        public PlayerTraits CarrierTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 2)]
        public byte[] Padding1 = new byte[2];
    }
}