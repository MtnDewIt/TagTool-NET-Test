using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Common;

namespace TagTool.Cache
{
    /// <summary>
    /// Platform dependent unsigned integer, uint32 when 32 bit, uint64 when 64 bit. 
    /// Serializer is responsible for properly reading/writing to file.
    /// </summary>
    public readonly struct PlatformUnsignedValue
    {
        public readonly ulong Value;

        public PlatformUnsignedValue() { Value = 0; }
        public PlatformUnsignedValue(ulong value) { Value = value; }
        public PlatformUnsignedValue(uint value) { Value = value; }

        public uint Get32BitValue() => (uint)(Value);
        public ulong Get64BitValue() => Value;

        public override readonly string ToString() => $"0x{Value:X}";
    }

    /// <summary>
    /// Platform dependent signed integer, int32 when 32 bit, int64 when 64 bit. 
    /// Serializer is responsible for properly reading/writing to file.
    /// </summary>
    public readonly struct PlatformSignedValue
    {
        public readonly long Value;

        public PlatformSignedValue() { Value = 0; }
        public PlatformSignedValue(long value) { Value = value; }
        public PlatformSignedValue(int value) { Value = value; }

        // TODO: verify this cast actually works
        public int Get32BitValue() => (int)(Value);
        public long Get64BitValue() => Value;

        public override string ToString() => $"{Value}";
    }
}