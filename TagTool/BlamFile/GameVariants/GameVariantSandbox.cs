using System;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x1F0, Align = 0x1)]
    public class GameVariantSandbox : GameVariantBase
    {
        public SandboxFlags VariantFlags;
        public SandboxEditModeSettings EditMode;
        public SandboxRespawnTime RespawnTime;
        public GameVariantPlayerTraits PlayerTraits;

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