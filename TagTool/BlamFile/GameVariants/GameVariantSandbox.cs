﻿using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure]
    public class GameVariantSandbox : GameVariantBase
    {
        public SandboxFlags VariantFlags;
        public SandboxEditModeSettings EditMode;
        public SandboxRespawnTime RespawnTime;
        public GameVariantPlayerTraits PlayerTraits;

        //[TagField(Flags = TagFieldFlags.Padding, Length = 0x90, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0x70, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Alignment;

        [Flags]
        public enum SandboxFlags : byte
        {
            None = 0,
            OpenChannelVoice = 1 << 0,
        }

        public enum SandboxEditModeSettings : byte
        {
            AllPlayers = 0,
            OnlyLeader,
        }

        public enum SandboxRespawnTime : short
        {
            Instant = 0,
            Seconds_3 = 3,
            Seconds_4 = 4,
            Seconds_5 = 5,
            Seconds_6 = 6,
            Seconds_7 = 7,
            Seconds_8 = 8,
            Seconds_9 = 9,
            Seconds_10 = 10,
            Seconds_15 = 15,
            Seconds_30 = 30,
            Seconds_60 = 60,
        }
    }
}