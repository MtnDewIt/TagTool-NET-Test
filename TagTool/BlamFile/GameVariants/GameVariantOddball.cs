﻿using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure]
    public class GameVariantOddball : GameVariantBase
    {
        public OddballFlags VariantFlags;
        public short ScoreToWin;
        
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public short ScoreToWinEarly;
        
        public short CarryingPoints;
        public sbyte KillPoints;
        public sbyte BallKillPoints;
        public sbyte CarrierKillPoints;
        public byte BallCount;
        public short BallSpawnDelay;
        public short BallInactiveRespawnDelay;
        public GameVariantPlayerTraits CarrierTraits;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
        public byte[] Padding1 = new byte[0x2];

        //[TagField(Flags = TagFieldFlags.Padding, Length = 0x80, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x60, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum OddballFlags : int
        {
            None = 0,
            AutoBallPickup = 1 << 0,
            BallEffectEnabled = 1 << 1,
        }
    }
}