using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using TagTool.Cache;

namespace TagTool.Common
{
    public struct BitFlags<TEnum> : IBlamType, IBitFlags, IEquatable<BitFlags<TEnum>> where TEnum : struct, Enum
    {
        private static readonly string[] EnumNames = Enum.GetNames<TEnum>();
        private static readonly int BitCount = EnumNames.Length;

        private ulong _storage = 0;

        public BitFlags(ulong value) => _storage = value;
        public BitFlags() : this(0) { }

        public readonly bool IsClear => _storage == 0;

        public readonly ulong GetUnsafe() => _storage;
        public ulong SetUnsafe(ulong value) => _storage = value;

        public readonly bool Test(TEnum bit)
        {
            return ((_storage >> GetBitIndex(bit)) & 1) != 0;
        }

        public void Set(TEnum bit, bool value)
        {
            if (value)
                _storage |= CreateMask(GetBitIndex(bit));
            else
                _storage &= ~CreateMask(GetBitIndex(bit));
        }

        public void Clear()
        {
            _storage = 0;
        }

        public static BitFlags<TEnum> From(ReadOnlySpan<TEnum> bits)
        {
            var result = new BitFlags<TEnum>();

            foreach (var bit in bits)
                result.Set(bit, true);

            return result;
        }

        public override readonly string ToString()
        {
            if (_storage == 0)
                return string.Empty;

            var builder = new StringBuilder();

            ulong value = _storage;
            while (value != 0)
            {
                int bit = System.Numerics.BitOperations.TrailingZeroCount(value);

                if (builder.Length > 0)
                    builder.Append(", ");

                builder.Append(EnumNames[bit]);

                value &= value - 1;
            }

            return builder.ToString();
        }

        public static BitFlags<TEnum> operator |(BitFlags<TEnum> lhs, BitFlags<TEnum> rhs) => new(lhs._storage | rhs._storage);
        public static BitFlags<TEnum> operator &(BitFlags<TEnum> lhs, BitFlags<TEnum> rhs) => new(lhs._storage & rhs._storage);
        public static BitFlags<TEnum> operator ^(BitFlags<TEnum> lhs, BitFlags<TEnum> rhs) => new(lhs._storage ^ rhs._storage);
        public static BitFlags<TEnum> operator ~(BitFlags<TEnum> flags) => new(~flags._storage);

        public override readonly bool Equals(object obj) => obj is BitFlags<TEnum> other && _storage == other._storage;
        public readonly bool Equals(BitFlags<TEnum> other) => _storage == other._storage;
        public override readonly int GetHashCode() => _storage.GetHashCode();
        public static bool operator ==(BitFlags<TEnum> lhs, BitFlags<TEnum> rhs) => lhs._storage == rhs._storage;
        public static bool operator !=(BitFlags<TEnum> lhs, BitFlags<TEnum> rhs) => lhs._storage != rhs._storage;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetBitIndex(TEnum bit)
        {
            int index = Unsafe.As<TEnum, int>(ref bit);
            Debug.Assert(index >= 0 && index < BitCount);
            return index;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong CreateMask(int bit)
        {
            return 1UL << (bit & 63);
        }

        readonly bool IBitFlags.TestBit(Enum bit) => Test((TEnum)bit);
        void IBitFlags.SetBit(Enum bit, bool value) => Set((TEnum)bit, value);
        readonly ulong IBitFlags.GetUnsafe() => GetUnsafe();
        void IBitFlags.SetUnsafe(ulong value) => SetUnsafe(value);

        readonly bool IBlamType.TryParse(GameCache cache, List<string> args, out IBlamType result, out string error)
        {
            error = "";
            result = null;

            if (args.Count < 1)
            {
                error = $"{args.Count} arguments supplied; should be 1";
                return false;
            }

            string arg = args[0];

            var flags = new BitFlags<TEnum>(_storage);
            foreach (string name in arg.Split(','))
            {
                if (!Enum.TryParse(name, ignoreCase: true, out TEnum value) || !Enum.IsDefined(value))
                {
                    error = $"'{name}' is not a valid member of enum '{typeof(TEnum).Name}'";
                    return false;
                }

                flags.Set(value, true);
            }

            result = flags;
            return true;
        }
    }

    public interface IBitFlags
    {
        bool TestBit(Enum bit);
        void SetBit(Enum bit, bool value);
        ulong GetUnsafe();
        void SetUnsafe(ulong value);
    }
}
