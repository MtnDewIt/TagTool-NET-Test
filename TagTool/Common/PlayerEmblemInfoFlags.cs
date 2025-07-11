using System;

namespace TagTool.Common
{
    [Flags]
    public enum PlayerEmblemInfoFlags : sbyte
    {
        None = 0,
        AlternateForegroundChannelOff = 1 << 0,
        FlipForeground = 1 << 1,
        FlipBackground = 1 << 2,
    }
}
