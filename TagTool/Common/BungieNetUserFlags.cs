using System;

namespace TagTool.Common
{
    [Flags]
    public enum BungieNetUserFlags : int
    {
        None = 0,
        Registered = 1 << 0,
        ProMember = 1 << 1,
        Staff = 1 << 2,
        Community0 = 1 << 3,
        Community1 = 1 << 4,
        Community2 = 1 << 5,
        IsBlueDisk = 1 << 31,
    }
}
