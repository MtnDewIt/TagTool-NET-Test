using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.Common
{
    public static class PrimitiveValueCache
    {
		//bool
		private static readonly object True = true;
		private static readonly object False = true;
		public static object For(bool value) => value ? True : False;

		//byte
		private static readonly object[] Bytes = GetBytes();
		private static object[] GetBytes()
		{
			object[] arr = new object[256];
			for (int i = 0; i < 256; i++) arr[i] = (byte)i;
			return arr;
		}
		public static object For(byte value) => Bytes[value];

		//sbyte
		private static readonly object[] SBytes = GetSBytes();
		private static object[] GetSBytes()
		{
			object[] arr = new object[256];
			for (int i = 0; i < 256; i++) arr[i] = (sbyte)(byte)i;
			return arr;
		}
		public static object For(sbyte value) => SBytes[(byte)value];

		//per thread cache helper types - Clock of size 16
		[InlineArray(16), StructLayout(LayoutKind.Sequential)]
		private struct Object16
		{
			private object _field;
		}
		private abstract class AutoCache<T> where T : IEquatable<T>
		{
			[InlineArray(16), StructLayout(LayoutKind.Sequential)]
			private struct T16
			{
				private T _field;
			}

			private Object16 objects;
			private T16 values;
			private int index;
			private ushort useBit;

			protected abstract object GetCacheValue(T value);

			[MethodImpl(MethodImplOptions.AggressiveInlining)] //we want to devirtualise the call to GetCacheValue
			public object GetOrCache(T value)
			{
				//check if it's in the cache
				ref var obj0 = ref objects[0];
				ref var val0 = ref values[0];
				int idx = MemoryMarshal.CreateSpan(ref val0, 16).IndexOf(value);
				if (idx >= 0)
				{
					useBit = (ushort)(useBit | 1 << idx);
					return Unsafe.Add(ref obj0, idx);
				}

				//otherwise, apply clock algorithm
				while (true)
				{
					var mask = 1 << (index & 0xF);
					if ((useBit & mask) > 0)
					{
						//clear use bit, try next
						useBit = (ushort)(useBit & ~mask);
						index++;
						index &= 0xF;
					}
					else
					{
						//we have an unset use bit, let's use it
						useBit = (ushort)(useBit | mask);
						Unsafe.Add(ref val0, index) = value;
						object o = GetCacheValue(value);
						Unsafe.Add(ref obj0, index) = o;
						return o;
					}
				}
			}
		}
		private class AutoBoxingCache<T> : AutoCache<T> where T : unmanaged, IEquatable<T>
		{
            protected override object GetCacheValue(T value) => value;
        }

		//ushort
		private static readonly object[] UShorts = GetUShorts(); //0 to 63
		private static object[] GetUShorts()
		{
			object[] arr = new object[64];
			for (int i = 0; i < 64; i++) arr[i] = (ushort)i;
			return arr;
		}
		[ThreadStatic] private static AutoBoxingCache<ushort> _ushortThreadCache;
		public static object For(ushort value) => value < 64 ? UShorts[value] : (_ushortThreadCache ??= new()).GetOrCache(value);

		//ushort
		private static readonly object[] Shorts = GetShorts(); //-16 to 47
		private static object[] GetShorts()
		{
			object[] arr = new object[64];
			for (int i = 0; i < 64; i++) arr[i] = (short)(i - 16);
			return arr;
		}
		[ThreadStatic] private static AutoBoxingCache<short> _shortThreadCache;
		public static object For(short value) => (uint)(value + 16) < 64 ? Shorts[value + 16] : (_shortThreadCache ??= new()).GetOrCache(value);

		//uint
		private static readonly object[] UInts = GetUInts(); //0 to 63
		private static object[] GetUInts()
		{
			object[] arr = new object[64];
			for (int i = 0; i < 64; i++) arr[i] = (uint)i;
			return arr;
		}
		[ThreadStatic] private static AutoBoxingCache<uint> _uintThreadCache;
		public static object For(uint value) => value < 64 ? UInts[value] : (_uintThreadCache ??= new()).GetOrCache(value);

		//uint
		private static readonly object[] Ints = GetInts(); //-16 to 47
		private static object[] GetInts()
		{
			object[] arr = new object[64];
			for (int i = 0; i < 64; i++) arr[i] = i - 16;
			return arr;
		}
		[ThreadStatic] private static AutoBoxingCache<int> _intThreadCache;
		public static object For(int value) => (uint)(value + 16) < 64 ? Ints[value + 16] : (_intThreadCache ??= new()).GetOrCache(value);

		//ulong
		private static readonly object[] ULongs = GetULongs(); //0 to 63
		private static object[] GetULongs()
		{
			object[] arr = new object[64];
			for (int i = 0; i < 64; i++) arr[i] = (ulong)i;
			return arr;
		}
		[ThreadStatic] private static AutoBoxingCache<ulong> _ulongThreadCache;
		public static object For(ulong value) => value < 64 ? ULongs[value] : (_ulongThreadCache ??= new()).GetOrCache(value);

		//ulong
		private static readonly object[] Longs = GetLongs(); //-16 to 47
		private static object[] GetLongs()
		{
			object[] arr = new object[64];
			for (int i = 0; i < 64; i++) arr[i] = (long)(i - 16);
			return arr;
		}
		[ThreadStatic] private static AutoBoxingCache<long> _longThreadCache;
		public static object For(long value) => (ulong)(value + 16) < 64 ? Longs[value + 16] : (_longThreadCache ??= new()).GetOrCache(value);

		//float
		private static readonly object FloatNaN = float.NaN;
		private static readonly object FloatPositive0 = 0.0f;
		private static readonly object FloatNegative0 = BitConverter.Int32BitsToSingle(int.MinValue);
		private static readonly object FloatPositive1 = 1.0f;
		private static readonly object FloatNegative1 = -1.0f;
		private static readonly object FloatPositiveInfinity = float.PositiveInfinity;
		private static readonly object FloatNegativeInfinity = float.NegativeInfinity;
		[ThreadStatic] private static AutoBoxingCache<float> _floatThreadCache;
        public static object For(float value)
        {
			if (float.IsNaN(value)) return FloatNaN;
			return BitConverter.SingleToUInt32Bits(value) switch
			{
				0x00000000 => FloatPositive0,
				0x80000000 => FloatNegative0,
				0x3F800000 => FloatPositive1,
				0xBF800000 => FloatNegative1,
				0x7F800000 => FloatPositiveInfinity,
				0xFF800000 => FloatNegativeInfinity,
				_ => (_floatThreadCache ??= new()).GetOrCache(value),
			};
		}

		//double
		private static readonly object DoubleNaN = double.NaN;
		private static readonly object DoublePositive0 = 0.0;
		private static readonly object DoubleNegative0 = BitConverter.Int64BitsToDouble(long.MinValue);
		private static readonly object DoublePositive1 = 1.0;
		private static readonly object DoubleNegative1 = -1.0;
		private static readonly object DoublePositiveInfinity = double.PositiveInfinity;
		private static readonly object DoubleNegativeInfinity = double.NegativeInfinity;
		[ThreadStatic] private static AutoBoxingCache<double> _doubleThreadCache;
		public static object For(double value)
		{
			if (double.IsNaN(value)) return DoubleNaN;
			return BitConverter.DoubleToUInt64Bits(value) switch
			{
				0x0000000000000000 => DoublePositive0,
				0x8000000000000000 => DoubleNegative0,
				0x3FF0000000000000 => DoublePositive1,
				0xBFF0000000000000 => DoubleNegative1,
				0x7FF0000000000000 => DoublePositiveInfinity,
				0xFFF0000000000000 => DoubleNegativeInfinity,
				_ => (_doubleThreadCache ??= new()).GetOrCache(value),
			};
		}

		//custom type: Tag (caching the string value)
		private class AutoTagStringCache : AutoCache<int>
		{
			protected override object GetCacheValue(int value) => new Tag() { Value = value }.ToStringUncached();
		}
		[ThreadStatic] private static AutoTagStringCache _tagThreadCache;
		public static string GetStringFor(Tag t) => Unsafe.As<string>((_tagThreadCache ??= new()).GetOrCache(t.Value)); //reinterpretation as string is safe since GetCacheValue always produces a string
	}
}
