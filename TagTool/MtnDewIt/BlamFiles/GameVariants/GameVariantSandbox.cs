using System;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    [Flags]
    public enum GameVariantSandboxFlags : byte
    {
        OpenChannelVoice = 0,
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

    [TagStructure(Size = 0x1F0)]
    public class GameVariantSandbox : GameVariantBase
    {
        public GameVariantSandboxFlags VariantFlags;
        public SandboxEditModeSettings EditMode;
        public SandboxRespawnTime RespawnTime;
        public PlayerTraits PlayerTraits;
    }
}