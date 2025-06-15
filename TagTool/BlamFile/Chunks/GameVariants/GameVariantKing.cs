using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure]
    public class GameVariantKing : GameVariantBase
    {
        public KingFlags VariantFlags;
        public short ScoreToWin;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreToWinEarly;

        public MovingHillSettings MovingHill;
        public MovingHillOrderSettings MovingHillOrder;
        public sbyte InsideHillPoints;
        public sbyte OutsideHillPoints;
        public sbyte UncontestedHillBonus;
        public sbyte KillPoints;
        public GameVariantPlayerTraits InsideHillTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x6)]
        public byte[] Padding3;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x82, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x60, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

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

        public static GameVariantKing Decode(BitStream stream)
        {
            var variant = new GameVariantKing();

            // TODO: Implement

            return variant;
        }

        public static void Encode(BitStream stream, GameVariantKing variant)
        {
            // TODO: Implement
        }
    }
}