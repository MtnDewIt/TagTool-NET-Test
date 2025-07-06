using System;

namespace TagTool.Common
{
    [Flags]
    public enum PlayerAppearanceFlags : byte
    {
        None = 0,
        FemaleVoice = 1 << 0,
    }
}