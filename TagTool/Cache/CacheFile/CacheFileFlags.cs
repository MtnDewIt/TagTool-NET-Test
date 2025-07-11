using System;

namespace TagTool.Cache
{
    [Flags]
    public enum CacheFileFlags : ushort
    {
        None = 0,
        Compressed = 1 << 0,
    }
}
