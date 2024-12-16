﻿/*
	All DXT compression code here has been ported from the open source library SquishLib.
	I take no credit for any of the code written in this file.
    License information is listed below.
*/

/* -----------------------------------------------------------------------------

	Copyright (c) 2006 Simon Brown                          si@sjbrown.co.uk

	Permission is hereby granted, free of charge, to any person obtaining
	a copy of this software and associated documentation files (the 
	"Software"), to	deal in the Software without restriction, including
	without limitation the rights to use, copy, modify, merge, publish,
	distribute, sublicense, and/or sell copies of the Software, and to 
	permit persons to whom the Software is furnished to do so, subject to 
	the following conditions:

	The above copyright notice and this permission notice shall be included
	in all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
	OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
	MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
	IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
	CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
	TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
	SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	
   -------------------------------------------------------------------------- */

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TagTool.Common;
using static TagTool.Bitmaps.Utils.SquishLib;
using System.Numerics;
using TagTool.Extensions;

namespace TagTool.Bitmaps.Utils
{
    public static class SquishLib
    {
        public static bool HaloS3TC = true;

        [Flags]
        public enum SquishFlags : uint
        {
            //! Use DXT1 compression.
            kDxt1 = (1 << 0),
            //! Use DXT3 compression.
            kDxt3 = (1 << 1),
            //! Use DXT5 compression.
            kDxt5 = (1 << 2),
            //! Use DXN (ATI2n) compression.
            kDxn = (1 << 9),
            //! Use a very slow but very high quality colour compressor.
            kColourIterativeClusterFit = (1 << 8),
            //! Use a slow but high quality colour compressor (the default).
            kColourClusterFit = (1 << 3),
            //! Use a fast but low quality colour compressor.
            kColourRangeFit = (1 << 4),
            //! Use a perceptual metric for colour error (the default).
            kColourMetricPerceptual = (1 << 5),
            //! Use a uniform metric for colour error.
            kColourMetricUniform = (1 << 6),
            //! Weight the colour by alpha during cluster fit (disabled by default).
            kWeightColourByAlpha = (1 << 7),
            //! Compressor constructed with compressed texture data
            kAlreadyCompressed = (1 << 10),
            //! Source is BGRA rather than RGBA
            kSourceBgra = (1 << 11)
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct SourceBlock
        {
            public SourceBlock(byte start, byte end, byte error)
            {
                this.start = start;
                this.end = end;
                this.error = error;
            }

            public byte start;
            public byte end;
            public byte error;
        }

        public static class ColourBlock
        {
            public static int FloatToInt(float a, int limit)
            {
                // use ANSI round-to-zero behaviour to get round-to-nearest
                int i = (int)(a + 0.5f);

                // clamp to the limit
                if (i < 0)
                    i = 0;
                else if (i > limit)
                    i = limit;

                // done
                return i;
            }

			// 3d vector
            public static int FloatTo565(Vector<float> colour)
            {
                // get the components in the correct range
                int r = FloatToInt(31.0f * colour[0], 31);
                int g = FloatToInt(63.0f * colour[1], 63);
                int b = FloatToInt(31.0f * colour[2], 31);

                // pack into a single value
                return (r << 11) | (g << 5) | b;
            }

            public static void WriteColourBlock(int a, int b, ReadOnlySpan<byte> indices, Span<byte> block)
            {
                // write the endpoints
                block[0] = (byte)(a & 0xff);
                block[1] = (byte)(a >> 8);
                block[2] = (byte)(b & 0xff);
                block[3] = (byte)(b >> 8);

                // write the indices
                for (int i = 0; i < 4; ++i)
                {
                    byte b0 = indices[4 * i + 0];
                    byte b1 = indices[4 * i + 1];
                    byte b2 = indices[4 * i + 2];
                    byte b3 = indices[4 * i + 3];
                    block[4 + i] = (byte)(b0 | (byte)(b1 << 2) | (byte)(b2 << 4) | (byte)(b3 << 6));
                }
            }

			//3d vectors
            public static void WriteColourBlock3(Vector<float> start, Vector<float> end, ReadOnlySpan<byte> indices, Span<byte> block)
            {
                // get the packed values
                int a = FloatTo565(start);
                int b = FloatTo565(end);

                // remap the indices
                Span<byte> remapped = stackalloc byte[16];
                if (a <= b)
                {
                    // use the indices directly
                    for (int i = 0; i < 16; ++i)
                        remapped[i] = indices[i];
                }
                else
                {
                    // swap a and b
                    int tmp = a;
                    a = b;
                    b = tmp;

                    for (int i = 0; i < 16; ++i)
                    {
                        if (indices[i] == 0)
                            remapped[i] = 1;
                        else if (indices[i] == 1)
                            remapped[i] = 0;
                        else
                            remapped[i] = indices[i];
                    }
                }

                // write the block
                WriteColourBlock(a, b, remapped, block);
            }

			// 3d vectors
            public static void WriteColourBlock4(Vector<float> start, Vector<float> end, ReadOnlySpan<byte> indices, Span<byte> block)
            {
                // get the packed values
                int a = FloatTo565(start);
                int b = FloatTo565(end);

                // remap the indices
                Span<byte> remapped = stackalloc byte[16];
                if (a < b)
                {
                    // swap a and b
                    int tmp = a;
                    a = b;
                    b = tmp;

                    for (int i = 0; i < 16; ++i)
                        remapped[i] = (byte)((indices[i] ^ 0x1) & 0x3);
                }
                else if (a == b)
                {
                    // use index 0
                    for (int i = 0; i < 16; ++i)
                        remapped[i] = 0;
                }
                else
                {
                    // use the indices directly
                    for (int i = 0; i < 16; ++i)
                        remapped[i] = indices[i];
                }

                // write the block
                WriteColourBlock(a, b, remapped, block);
            }
        }

        public static class SquishMath
        {
			// 3d
            public static Vector<float> GetMultiplicity1Evector(Sym3x3 matrix, float evalue)
            {
                // compute M
                Sym3x3 m = new Sym3x3();
                m[0] = matrix[0] - evalue;
                m[1] = matrix[1];
                m[2] = matrix[2];
                m[3] = matrix[3] - evalue;
                m[4] = matrix[4];
                m[5] = matrix[5] - evalue;

                // compute U
                Sym3x3 u = new Sym3x3();
                u[0] = m[3] * m[5] - m[4] * m[4];
                u[1] = m[2] * m[4] - m[1] * m[5];
                u[2] = m[1] * m[4] - m[2] * m[3];
                u[3] = m[0] * m[5] - m[2] * m[2];
                u[4] = m[1] * m[2] - m[4] * m[0];
                u[5] = m[0] * m[3] - m[1] * m[1];

                // find the largest component
                float mc = Math.Abs(u[0]);
                int mi = 0;
                for (int i = 1; i < 6; ++i)
                {
                    float c = Math.Abs(u[i]);
                    if (c > mc)
                    {
                        mc = c;
                        mi = i;
                    }
                }

                // pick the column with this component
                switch (mi)
                {
                    case 0:
                        return VectorExtensions.InitializeVector(new float[] { u[0], u[1], u[2] });
                    case 1:
                    case 3:
                        return VectorExtensions.InitializeVector(new float[] { u[1], u[3], u[4] });
                    default:
                        return VectorExtensions.InitializeVector(new float[] { u[2], u[4], u[5] });
                }
            }

			// 3d
            public static Vector<float> GetMultiplicity2Evector(Sym3x3 matrix, float evalue)
            {
                // compute M
                Sym3x3 m = new Sym3x3();
                m[0] = matrix[0] - evalue;
                m[1] = matrix[1];
                m[2] = matrix[2];
                m[3] = matrix[3] - evalue;
                m[4] = matrix[4];
                m[5] = matrix[5] - evalue;

                // find the largest component
                float mc = (float)Math.Abs(m[0]);
                int mi = 0;
                for (int i = 1; i < 6; ++i)
                {
                    float c = (float)Math.Abs(m[i]);
                    if (c > mc)
                    {
                        mc = c;
                        mi = i;
                    }
                }

                // pick the first eigenvector based on this index
                switch (mi)
                {
                    case 0:
                    case 1:
                        return VectorExtensions.InitializeVector(new float[] { -m[1], m[0], 0.0f });
                    case 2:
                        return VectorExtensions.InitializeVector(new float[] { m[2], 0.0f, -m[0] });
                    case 3:
                    case 4:
                        return VectorExtensions.InitializeVector(new float[] { 0.0f, -m[4], m[3] });
                    default:
                        return VectorExtensions.InitializeVector(new float[] { 0.0f, -m[5], m[4] });
                }
            }

            public static float LengthSquared(RealVector3d v) => RealVector3d.DotProduct(v, v);
            public static float LengthSquared3d(Vector<float> v) => VectorExtensions.Dot3d(v, v);


            public static RealVector3d Min(RealVector3d a, RealVector3d b) =>
                new RealVector3d(Math.Min(a.I, b.I), Math.Min(a.J, b.J), Math.Min(a.K, b.K));
            public static RealVector4d Min(RealVector4d a, RealVector4d b) =>
                new RealVector4d(Math.Min(a.I, b.I), Math.Min(a.J, b.J), Math.Min(a.K, b.K), Math.Min(a.W, b.W));

            public static RealVector3d Max(RealVector3d a, RealVector3d b) =>
                new RealVector3d(Math.Max(a.I, b.I), Math.Max(a.J, b.J), Math.Max(a.K, b.K));
            public static RealVector4d Max(RealVector4d a, RealVector4d b) =>
                new RealVector4d(Math.Max(a.I, b.I), Math.Max(a.J, b.J), Math.Max(a.K, b.K), Math.Max(a.W, b.W));

            public static Vector<float> Max4d(Vector<float> a, Vector<float> b)
			{
				return VectorExtensions.InitializeVector(new float[]
				{
					Math.Max(a[0], b[0]),
                    Math.Max(a[1], b[1]),
                    Math.Max(a[2], b[2]),
                    Math.Max(a[3], b[3])
                });
            }
            public static Vector<float> Min4d(Vector<float> a, Vector<float> b)
            {
                return VectorExtensions.InitializeVector(new float[]
                {
                    Math.Min(a[0], b[0]),
                    Math.Min(a[1], b[1]),
                    Math.Min(a[2], b[2]),
                    Math.Min(a[3], b[3])
                });
            }
            public static Vector<float> Max3d(Vector<float> a, Vector<float> b)
            {
                return VectorExtensions.InitializeVector(new float[]
                {
                    Math.Max(a[0], b[0]),
                    Math.Max(a[1], b[1]),
                    Math.Max(a[2], b[2])
                });
            }
            public static Vector<float> Min3d(Vector<float> a, Vector<float> b)
            {
                return VectorExtensions.InitializeVector(new float[]
                {
                    Math.Min(a[0], b[0]),
                    Math.Min(a[1], b[1]),
                    Math.Min(a[2], b[2])
                });
            }

            public static RealVector3d Truncate(RealVector3d input) => new RealVector3d(
                    input.I > 0.0f ? (float)Math.Floor(input.I) : (float)Math.Ceiling(input.I),
                    input.J > 0.0f ? (float)Math.Floor(input.J) : (float)Math.Ceiling(input.J),
                    input.K > 0.0f ? (float)Math.Floor(input.K) : (float)Math.Ceiling(input.K)
                );
            public static RealVector4d Truncate(RealVector4d input) => new RealVector4d(
                    input.I > 0.0f ? (float)Math.Floor(input.I) : (float)Math.Ceiling(input.I),
                    input.J > 0.0f ? (float)Math.Floor(input.J) : (float)Math.Ceiling(input.J),
                    input.K > 0.0f ? (float)Math.Floor(input.K) : (float)Math.Ceiling(input.K),
                    input.W > 0.0f ? (float)Math.Floor(input.W) : (float)Math.Ceiling(input.W)
                );
            public static Vector<float> Truncate4d(Vector<float> input) => VectorExtensions.InitializeVector(new float[]
				{
					input[0] > 0.0f ? (float)Math.Floor(input[0]) : (float)Math.Ceiling(input[0]),
					input[1] > 0.0f ? (float)Math.Floor(input[1]) : (float)Math.Ceiling(input[1]),
					input[2] > 0.0f ? (float)Math.Floor(input[2]) : (float)Math.Ceiling(input[2]),
					input[3] > 0.0f ? (float)Math.Floor(input[3]) : (float)Math.Ceiling(input[3])
				});
            public static Vector<float> Truncate3d(Vector<float> input) => VectorExtensions.InitializeVector(new float[]
                {
                    input[0] > 0.0f ? (float)Math.Floor(input[0]) : (float)Math.Ceiling(input[0]),
                    input[1] > 0.0f ? (float)Math.Floor(input[1]) : (float)Math.Ceiling(input[1]),
                    input[2] > 0.0f ? (float)Math.Floor(input[2]) : (float)Math.Ceiling(input[2])
                });


            public static bool CompareAnyLessThan(RealVector4d a, RealVector4d b) =>
                a.I < b.I || a.J < b.J || a.K < b.K || a.W < b.W;
        }

        public abstract class ColourFit
        {
            public ColourFit(ColourSet colours, uint flags)
            {
                m_colours = colours;
                m_flags = flags;
            }

            public void Compress(Span<byte> block)
            {
                bool isDxt1 = ((m_flags & (uint)SquishFlags.kDxt1) != 0);
                if (isDxt1)
                {
                    Compress3(block);
                    if (!m_colours.IsTransparent())
                        Compress4(block);
                }
                else
                    Compress4(block);
            }

            protected abstract void Compress3(Span<byte> block);
            protected abstract void Compress4(Span<byte> block);

            protected ColourSet m_colours;
            protected uint m_flags;
        }

		public class Compressor
		{
			public Compressor(SquishFlags flags, byte[] data, int width, int height)
            {
                Width = width;
                Height = height;

                if ((flags & SquishFlags.kAlreadyCompressed) != 0)
					CompressedData = data;
				else
					Rgba = data;

                // grab the flag bits
                Flags = (SquishFlags)FixFlags((uint)flags);
            }

            public byte[] CompressTexture()
			{
				int size = GetStorageRequirements();
                byte[] pooledDxtImage = ArrayPool<byte>.Shared.Rent(size);
                int dxtImageLen = 0;

                // initialise the block output
                int bytesPerBlock = ((Flags & SquishFlags.kDxt1) != 0) ? 8 : 16;

                Span<byte> sourceRgba = stackalloc byte[16 * 4];

                // loop over blocks
                for (int y = 0; y < Height; y += 4)
                {
                    for (int x = 0; x < Width; x += 4)
                    {
                        // build the 4x4 block of pixels
                        sourceRgba.Clear();
						int rgbaOffset = 0;

                        int mask = 0;
                        for (int py = 0; py < 4; ++py)
                        {
                            for (int px = 0; px < 4; ++px)
                            {
                                // get the source pixel in the image
                                int sx = x + px;
                                int sy = y + py;

                                // enable if we're in the image
                                if (sx < Width && sy < Height)
                                {
                                    // copy the rgba value
									byte r = Rgba[4 * (Width * sy + sx) + 0];
                                    byte g = Rgba[4 * (Width * sy + sx) + 1];
                                    byte b = Rgba[4 * (Width * sy + sx) + 2];
                                    byte a = Rgba[4 * (Width * sy + sx) + 3];

                                    if((Flags & SquishFlags.kSourceBgra) != 0)
                                        (r, b) = (b, r); // bgra -> rgba

                                    sourceRgba[rgbaOffset + 0] = r;
                                    sourceRgba[rgbaOffset + 1] = g;
                                    sourceRgba[rgbaOffset + 2] = b;
                                    sourceRgba[rgbaOffset + 3] = a;
                                    rgbaOffset += 4;

                                    // enable this pixel
                                    mask |= (1 << (4 * py + px));
                                }
                                else
                                {
									// skip this pixel as its outside the image
									rgbaOffset += 4;
                                }
                            }
                        }

                        //ensure buffer is big enough
                        if ((uint)dxtImageLen + (uint)bytesPerBlock > (uint)pooledDxtImage.Length)
                        {
                            var newPooled = ArrayPool<byte>.Shared.Rent(Math.Max(pooledDxtImage.Length * 2, pooledDxtImage.Length + bytesPerBlock));
                            pooledDxtImage.AsSpan()[..dxtImageLen].CopyTo(newPooled.AsSpan()[..dxtImageLen]);
                            ArrayPool<byte>.Shared.Return(pooledDxtImage);
                            pooledDxtImage = newPooled;
                        }

                        // compress it into the output
                        CompressMasked(sourceRgba, (uint)mask, pooledDxtImage.AsSpan()[dxtImageLen..(dxtImageLen + bytesPerBlock)], (uint)Flags);
                        dxtImageLen += bytesPerBlock;
                    }
                }

                if (size != dxtImageLen)
                    Console.WriteLine($"##DXT COMPRESSOR: Expected size \"{size}\" bytes did not match actual size of \"{dxtImageLen}\" bytes.");

                if (dxtImageLen == pooledDxtImage.Length)
                {
                    //don't return in this case: copying + allocating new + returning is more expensive than just not returning it
                    CompressedData = pooledDxtImage;
                }
                else
                {
                    CompressedData = pooledDxtImage.AsSpan()[..dxtImageLen].ToArray();
                    ArrayPool<byte>.Shared.Return(pooledDxtImage);
                }
                return CompressedData;
			}

			public byte[] DecompressTexture()
			{
				Rgba = new byte[Width * Height * 4];

				// initialise the block input
				var sourceBlocks = CompressedData;
                int bytesPerBlock = ((Flags & SquishFlags.kDxt1) != 0) ? 8 : 16;
				int blockOffset = 0;

                Span<byte> targetRgba = stackalloc byte[64];

                // loop over blocks
                for (int y = 0; y < Height; y += 4)
                {
                    for (int x = 0; x < Width; x += 4)
                    {
                        // decompress the block
                        targetRgba.Clear();
                        Decompress(sourceBlocks.AsSpan()[blockOffset..(blockOffset + bytesPerBlock)], Flags, targetRgba);

                        // write the decompressed pixels to the correct image locations
                        int rgbaOffset = 0;
                        for (int py = 0; py < 4; ++py)
                        {
                            for (int px = 0; px < 4; ++px)
                            {
                                // get the target location
                                int sx = x + px;
                                int sy = y + py;
                                if (sx < Width && sy < Height)
                                {
									byte r = targetRgba[rgbaOffset + 0];
                                    byte g = targetRgba[rgbaOffset + 1];
                                    byte b = targetRgba[rgbaOffset + 2];
                                    byte a = targetRgba[rgbaOffset + 3];

									if((Flags & SquishFlags.kSourceBgra) != 0)
										(r, b) = (b, r); // rgba -> bgra

                                    // copy the rgba value
                                    Rgba[4 * (Width * sy + sx) + 0] = r;
                                    Rgba[4 * (Width * sy + sx) + 1] = g;
                                    Rgba[4 * (Width * sy + sx) + 2] = b;
                                    Rgba[4 * (Width * sy + sx) + 3] = a;

									rgbaOffset += 4;
                                }
                                else
                                {
                                    // skip this pixel as its outside the image
									rgbaOffset += 4;
                                }
                            }
                        }

						// advance
						blockOffset += bytesPerBlock;
                    }
                }

				return Rgba;
            }

            public int GetStorageRequirements()
            {
                // compute the storage requirements
                int blockcount = ((Width + 3) / 4) * ((Height + 3) / 4);
                int blocksize = ((Flags & SquishFlags.kDxt1) != 0) ? 8 : 16;
                return blockcount * blocksize;
            }

            static public int GetStorageRequirements(SquishFlags flags, int width, int height)
            {
                int blockcount = ((width + 3) / 4) * ((height + 3) / 4);
                int blocksize = ((flags & SquishFlags.kDxt1) != 0) ? 8 : 16;
                return blockcount * blocksize;
            }

            private byte[] Rgba;
            private byte[] CompressedData;
            private readonly SquishFlags Flags;
			private readonly int Width;
			private readonly int Height;
        }

        public struct Sym3x3
        {
            public Sym3x3()
            {
                this = default;
            }
            public unsafe Sym3x3(float s)
            {
                MemoryMarshal.CreateSpan(ref m_x[0], 6).Fill(s);
            }

            public unsafe ref float this[int index]
            {
                get
                {
                    if ((uint)index > 6)
                    {
                        static void ThrowHelper()
                        {
                            throw new ArgumentOutOfRangeException("i", "Index is out of range, must be 0, 1, or 2");
                        }
                        ThrowHelper();
                    }
                    return ref m_x[index];
                }
            }

            unsafe fixed float m_x[6];

			// 3d
			public Vector<float> ComputePrincipleComponent()
            {
                float FLT_EPSILON = 1.192092896e-07F;
                var matrix = this;

                // compute the cubic coefficients
                float c0 = matrix[0] * matrix[3] * matrix[5]
                    + 2.0f * matrix[1] * matrix[2] * matrix[4]
                    - matrix[0] * matrix[4] * matrix[4]
                    - matrix[3] * matrix[2] * matrix[2]
                    - matrix[5] * matrix[1] * matrix[1];
                float c1 = matrix[0] * matrix[3] + matrix[0] * matrix[5] + matrix[3] * matrix[5]
                    - matrix[1] * matrix[1] - matrix[2] * matrix[2] - matrix[4] * matrix[4];
                float c2 = matrix[0] + matrix[3] + matrix[5];

                // compute the quadratic coefficients
                float a = c1 - (1.0f / 3.0f) * c2 * c2;
                float b = (-2.0f / 27.0f) * c2 * c2 * c2 + (1.0f / 3.0f) * c1 * c2 - c0;

                // compute the root count check
                float Q = 0.25f * b * b + (1.0f / 27.0f) * a * a * a;

                // test the multiplicity
                if (FLT_EPSILON < Q)
                {
                    // only one root, which implies we have a multiple of the identity
                    return VectorExtensions.InitializeVector(new float[] { 1.0f, 1.0f, 1.0f });
                }
                else if (Q < -FLT_EPSILON)
                {
                    // three distinct roots
                    float theta = (float)Math.Atan2(Math.Sqrt(-Q), -0.5f * b);
                    float rho = (float)Math.Sqrt(0.25f * b * b - Q);

                    float rt = (float)Math.Pow(rho, 1.0f / 3.0f);
                    float ct = (float)Math.Cos(theta / 3.0f);
                    float st = (float)Math.Sin(theta / 3.0f);

                    float l1 = (1.0f / 3.0f) * c2 + 2.0f * rt * ct;
                    float l2 = (1.0f / 3.0f) * c2 - rt * (ct + (float)Math.Sqrt(3.0f) * st);
                    float l3 = (1.0f / 3.0f) * c2 - rt * (ct - (float)Math.Sqrt(3.0f) * st);

                    // pick the larger
                    if (Math.Abs(l2) > Math.Abs(l1))
                        l1 = l2;
                    if (Math.Abs(l3) > Math.Abs(l1))
                        l1 = l3;

                    // get the eigenvector
                    return SquishMath.GetMultiplicity1Evector(matrix, l1);
                }
                else // if( -FLT_EPSILON <= Q && Q <= FLT_EPSILON )
                {
                    // two roots
                    float rt;
                    if (b < 0.0f)
                        rt = (float)-Math.Pow(-0.5f * b, 1.0f / 3.0f);
                    else
                        rt = (float)Math.Pow(0.5f * b, 1.0f / 3.0f);

                    float l1 = (1.0f / 3.0f) * c2 + rt;     // repeated
                    float l2 = (1.0f / 3.0f) * c2 - 2.0f * rt;

                    // get the eigenvector
                    if (Math.Abs(l1) > Math.Abs(l2))
                        return SquishMath.GetMultiplicity2Evector(matrix, l1);
                    else
                        return SquishMath.GetMultiplicity1Evector(matrix, l2);
                }
            }

			// 3d
            public static Sym3x3 ComputeWeightedCovariance(int n, ReadOnlySpan<Vector<float>> points, ReadOnlySpan<float> weights)
            {
                // compute the centroid
                float total = 0.0f;
                Vector<float> centroid = VectorExtensions.InitializeVector();
                for ( int i = 0; i < n; ++i )
                {
                    total += weights[i];
                    centroid += weights[i]*points[i];
                }
                centroid *= (1.0f / total);

                // accumulate the covariance matrix
                Sym3x3 covariance = new Sym3x3(0.0f);
                for( int i = 0; i < n; ++i )
                {
                    Vector<float> a = points[i] - centroid;
                    Vector<float> b = weights[i]*a;

                    covariance[0] += a[0] * b[0];
                    covariance[1] += a[0] * b[1];
                    covariance[2] += a[0] * b[2];
                    covariance[3] += a[1] * b[1];
                    covariance[4] += a[1] * b[2];
                    covariance[5] += a[2] * b[2];
                }
                
                // return it
                return covariance;
            }
        }

        [InlineArray(2), StructLayout(LayoutKind.Sequential)]
        public struct SingleColourLookup
        {
            private SourceBlock _field;

            public SingleColourLookup()
            {
                this[0] = default;
                this[1] = default;
            }

            public SingleColourLookup(byte s1, byte end1, byte error1, byte s2, byte end2, byte err2)
            {
                this[0] = new SourceBlock(s1, end1, error1);
                this[1] = new SourceBlock(s2, end2, err2);
            }
        }

        public struct ColourSet
        {
            public unsafe ColourSet(ReadOnlySpan<byte> rgba, uint mask, uint flags)
            {
                // init arrays
                Debug.Assert(sizeof(RealVector3d) == sizeof(float) * 3);
                this = default;

                Count = 0;
                Transparent = false;

                // check the compression mode for dxt1
                bool isDxt1 = ((flags & (uint)SquishFlags.kDxt1) != 0);
                bool weightByAlpha = ((flags & (uint)SquishFlags.kWeightColourByAlpha) != 0);

                // create the minimal set
                for (int i = 0; i < 16; ++i)
                {
                    // check this pixel is enabled
                    int bit = 1 << i;
                    if ((mask & bit) == 0)
                    {
                        _Remap[i] = -1;
                        continue;
                    }

                    // check for transparent pixels when using dxt1
                    if (isDxt1 && rgba[4 * i + 3] < 128)
                    {
                        _Remap[i] = -1;
                        Transparent = true;
                        continue;
                    }

                    // loop over previous points for a match
                    for (int j = 0; ; ++j)
                    {
                        // allocate a new point
                        if (j == i)
                        {
                            // normalise coordinates to [0,1]
                            float x = (float)rgba[4 * i] / 255.0f;
                            float y = (float)rgba[4 * i + 1] / 255.0f;
                            float z = (float)rgba[4 * i + 2] / 255.0f;

                            // ensure there is always non-zero weight even for zero alpha
                            float w = (float)(rgba[4 * i + 3] + 1) / 256.0f;

                            // add the point
                            Unsafe.Add(ref Unsafe.As<float, Vector<float>>(ref _Points[0]), Count) = VectorExtensions.InitializeVector(new float[] { x, y, z });
                            _Weights[Count] = (weightByAlpha ? w : 1.0f);
                            _Remap[i] = Count;

                            // advance
                            ++Count;
                            break;
                        }

                        // check for a match
                        int oldbit = 1 << j;
                        bool match = ((mask & oldbit) != 0)
                            && (rgba[4 * i] == rgba[4 * j])
                            && (rgba[4 * i + 1] == rgba[4 * j + 1])
                            && (rgba[4 * i + 2] == rgba[4 * j + 2])
                            && (rgba[4 * j + 3] >= 128 || !isDxt1);
                        if (match)
                        {
                            // get the index of the match
                            int index = Remap[j];

                            // ensure there is always non-zero weight even for zero alpha
                            float w = (float)(rgba[4 * i + 3] + 1) / 256.0f;

                            // map to this point and increase the weight
                            _Weights[index] += (weightByAlpha ? w : 1.0f);
                            _Remap[i] = index;
                            break;
                        }
                    }
                }

                // square root the weights
                for (int i = 0; i < Count; ++i)
                    _Weights[i] = (float)Math.Sqrt(Weights[i]);
            }

            public readonly void RemapIndices(ReadOnlySpan<byte> source, Span<byte> target)
            {
                for (int i = 0; i < 16; ++i)
                {
                    int j = Remap[i];
                    if (j == -1)
                        target[i] = 3;
                    else
                        target[i] = source[j];
                }
            }

            public readonly int GetCount() => Count;
            [UnscopedRef] public readonly ReadOnlySpan<Vector<float>> GetPoints() => Points;  //3d
            [UnscopedRef] public readonly ReadOnlySpan<float> GetWeights() => Weights;
            public readonly bool IsTransparent() => Transparent;

            private int Count;
            private unsafe fixed float _Points[16 * 3]; //RealVector3d = 3 floats
            [UnscopedRef] public unsafe readonly ReadOnlySpan<Vector<float>> Points => MemoryMarshal.CreateSpan(ref Unsafe.As<float, Vector<float>>(ref Unsafe.AsRef(in _Points[0])), 16); // 3d [16]
            private unsafe fixed float _Weights[16];
            [UnscopedRef] public unsafe readonly ReadOnlySpan<float> Weights => MemoryMarshal.CreateSpan(ref Unsafe.AsRef(in _Weights[0]), 16);
            private unsafe fixed int _Remap[16];
            [UnscopedRef] public unsafe readonly ReadOnlySpan<int> Remap => MemoryMarshal.CreateSpan(ref Unsafe.AsRef(in _Remap[0]), 16);
            private bool Transparent;
        }

        public class SingleColourFit : ColourFit
        {
            public static int FloatToInt(float a, int limit)
            {
                // use ANSI round-to-zero behaviour to get round-to-nearest
                int i = (int)(a + 0.5f);

                // clamp to the limit
                if (i < 0)
                    i = 0;
                else if (i > limit)
                    i = limit;

                // done
                return i;
            }

            public SingleColourFit(ColourSet colours, uint flags) : base(colours, flags)
            {
                // grab the single colour
                ReadOnlySpan<Vector<float>> values = m_colours.GetPoints();
                ReadOnlySpan<byte> colour_list = stackalloc byte[]
                {
                    (byte)FloatToInt(255.0f * values[0][0], 255),
                    (byte)FloatToInt(255.0f * values[0][1], 255),
                    (byte)FloatToInt(255.0f * values[0][2], 255)
                };
                colour_list.CopyTo(m_colour);

                // initialise the best error
                m_besterror = int.MaxValue;
            }

            protected override void Compress3(Span<byte> block)
            {
                // build the table of lookups
                ReadOnlySpanSingleColourLookup3 lookups = default;
                lookups[0] = lookup_5_3;
                lookups[1] = lookup_6_3;
                lookups[2] = lookup_5_3;

                // find the best end-points and index
                ComputeEndPoints(lookups);

                // build the block if we win
                if (m_error < m_besterror)
                {
                    // remap the indices
                    Span<byte> indices = stackalloc byte[16];
                    m_colours.RemapIndices(stackalloc byte[] { m_index }, indices);

                    // save the block
                    ColourBlock.WriteColourBlock3(m_start, m_end, indices, block);

                    // save the error
                    m_besterror = m_error;
                }
            }

            protected override void Compress4(Span<byte> block)
            {
                // build the table of lookups
                ReadOnlySpanSingleColourLookup3 lookups = default;
                lookups[0] = lookup_5_4;
                lookups[1] = lookup_6_4;
                lookups[2] = lookup_5_4;

                // find the best end-points and index
                ComputeEndPoints(lookups);

                // build the block if we win
                if ( m_error < m_besterror )
                {
                    // remap the indices
                    Span<byte> indices = stackalloc byte[16];
                    m_colours.RemapIndices(stackalloc byte[] { m_index }, indices);

                    // save the block
                    ColourBlock.WriteColourBlock4( m_start, m_end, indices, block );

                    // save the error
                    m_besterror = m_error;
                }
            }

            //todo: use InlineArray
            [StructLayout(LayoutKind.Sequential)]
            public ref struct ReadOnlySpanSingleColourLookup3
            {
                private ReadOnlySpan<SingleColourLookup> span0;
                private ReadOnlySpan<SingleColourLookup> span1;
                private ReadOnlySpan<SingleColourLookup> span2;

                [UnscopedRef]
                public ref ReadOnlySpan<SingleColourLookup> this[int i]
                {
                    get
                    {
                        if ((uint)i > 3)
                        {
                            static void ThrowHelper()
                            {
                                throw new ArgumentOutOfRangeException("i", "Index is out of range, must be 0, 1, or 2");
                            }
                            ThrowHelper();
                        }
                        if (i == 0) return ref span0;
                        else if (i == 1) return ref span1;
                        else return ref span2;
                    }
                }
            }

            public void ComputeEndPoints(ReadOnlySpanSingleColourLookup3 lookups /*3 lookups passed here*/)
            {
                // check each index combination (endpoint or intermediate)
                m_error = int.MaxValue;
                Span<SourceBlock> sources = stackalloc SourceBlock[3];
                for (int index = 0; index < 2; ++index)
                {
                    // check the error for this codebook index
                    int error = 0;
                    for (int channel = 0; channel < 3; ++channel)
                    {
                        // grab the lookup table and index for this channel
                        ReadOnlySpan<SingleColourLookup> lookup = lookups[channel];
                        int target = m_colour[channel];

                        // store a pointer to the source for this channel
                        sources[channel] = lookup[target][index];

                        // accumulate the error
                        int diff = sources[channel].error;
                        error += diff * diff;
                    }

                    // keep it if the error is lower
                    if (error < m_error)
                    {
                        m_start = VectorExtensions.InitializeVector(new float[] {
                            (float)sources[0].start / 31.0f,
                            (float)sources[1].start / 63.0f,
                            (float)sources[2].start / 31.0f
                        });
                        m_end = VectorExtensions.InitializeVector(new float[] {
                            (float)sources[0].end / 31.0f,
                            (float)sources[1].end / 63.0f,
                            (float)sources[2].end / 31.0f
                        });
                        m_index = (byte)(2 * index);
                        m_error = error;
                    }
                }
            }

            private uint _m_colour;
            private Span<byte> m_colour => MemoryMarshal.CreateSpan(ref Unsafe.As<uint, byte>(ref _m_colour), 3);
            private Vector<float> m_start; // 3d
            private Vector<float> m_end; //3d
            private byte m_index;
            private int m_error;
            private int m_besterror;
        }

        public class RangeFit : ColourFit
        {
            public RangeFit(ColourSet colours, uint flags) : base(colours, flags)
            {
                // initialise the metric
                bool perceptual = ((m_flags & (uint)SquishFlags.kColourMetricPerceptual) != 0);
                if (perceptual)
                    m_metric = VectorExtensions.InitializeVector(new float[] { 0.2126f, 0.7152f, 0.0722f });
                else
                    m_metric = VectorExtensions.InitializeVector(new float[] { 1.0f, 1.0f, 1.0f });

                // initialise the best error
                m_besterror = float.MaxValue;

                // cache some values
                int count = m_colours.GetCount();
                var values = m_colours.GetPoints();
                var weights = m_colours.GetWeights();

                // get the covariance matrix
                Sym3x3 covariance = Sym3x3.ComputeWeightedCovariance(count, values, weights);

                // compute the principle component
                Vector<float> principle = covariance.ComputePrincipleComponent();

                // get the min and max range as the codebook endpoints
                Vector<float> start = VectorExtensions.InitializeVector();
                Vector<float> end = VectorExtensions.InitializeVector();
                if (count > 0)
                {
                    float min, max;

                    // compute the range
                    start = end = values[0];
                    min = max = VectorExtensions.Dot3d(values[0], principle);
                    for (int i = 1; i < count; ++i)
                    {
                        float val = VectorExtensions.Dot3d(values[i], principle);
                        if (val < min)
                        {
                            start = values[i];
                            min = val;
                        }
                        else if (val > max)
                        {
                            end = values[i];
                            max = val;
                        }
                    }
                }

                // clamp the output to [0, 1]
                Vector<float> one = VectorExtensions.InitializeVector(new float[] { 1.0f, 1.0f, 1.0f });
                Vector<float> zero = VectorExtensions.InitializeVector();
                start = SquishMath.Min3d(one, SquishMath.Max3d(zero, start));
                end = SquishMath.Min3d(one, SquishMath.Max3d(zero, end));

                // clamp to the grid and save
                Vector<float> grid = VectorExtensions.InitializeVector(new float[] { 31.0f, 63.0f, 31.0f });
                Vector<float> gridrcp = VectorExtensions.InitializeVector(new float[] { 1.0f / 31.0f, 1.0f / 63.0f, 1.0f / 31.0f });
                Vector<float> half = VectorExtensions.InitializeVector(new float[] { 0.5f, 0.5f, 0.5f });
                m_start = SquishMath.Truncate3d(grid * start + half) * gridrcp;
                m_end = SquishMath.Truncate3d(grid * end + half) * gridrcp;
            }

            protected override void Compress3(Span<byte> block)
            {
                // cache some values
                int count = m_colours.GetCount();
                var values = m_colours.GetPoints();

                // create a codebook
                ReadOnlySpan<Vector<float>> codes = stackalloc Vector<float>[]
                {
                    m_start,
                    m_end,
                    0.5f * m_start + 0.5f * m_end
                };

                // match each point to the closest code
                byte[] closest = new byte[16];
                float error = 0.0f;
                for (int i = 0; i < count; ++i)
                {
                    // find the closest code
                    float dist = float.MaxValue;
                    int idx = 0;
                    for (int j = 0; j < 3; ++j)
                    {
                        float d = SquishMath.LengthSquared3d(m_metric * (values[i] - codes[j]));
                        if (d < dist)
                        {
                            dist = d;
                            idx = j;
                        }
                    }

                    // save the index
                    closest[i] = (byte)idx;

                    // accumulate the error
                    error += dist;
                }

                // save this scheme if it wins
                if (error < m_besterror)
                {
                    // remap the indices
                    Span<byte> indices = stackalloc byte[16];
                    m_colours.RemapIndices(closest, indices);

                    // save the block
                    ColourBlock.WriteColourBlock3(m_start, m_end, indices, block);

                    // save the error
                    m_besterror = error;
                }
            }

            protected override void Compress4(Span<byte> block)
            {
                // cache some values
                int count = m_colours.GetCount();
                var values = m_colours.GetPoints();

                // create a codebook
                ReadOnlySpan<Vector<float>> codes = stackalloc Vector<float>[] {
                    m_start,
                    m_end,
                    (2.0f / 3.0f) * m_start + (1.0f / 3.0f) * m_end,
                    (1.0f / 3.0f) * m_start + (2.0f / 3.0f) * m_end,
                };

                // match each point to the closest code
                Span<byte> closest = stackalloc byte[16];
                float error = 0.0f;
                for (int i = 0; i < count; ++i)
                {
                    // find the closest code
                    float dist = float.MaxValue;
                    int idx = 0;
                    for (int j = 0; j < 4; ++j)
                    {
                        float d = SquishMath.LengthSquared3d(m_metric * (values[i] - codes[j]));
                        if (d < dist)
                        {
                            dist = d;
                            idx = j;
                        }
                    }

                    // save the index
                    closest[i] = (byte)idx;

                    // accumulate the error
                    error += dist;
                }

                // save this scheme if it wins
                if (error < m_besterror)
                {
                    // remap the indices
                    Span<byte> indices = stackalloc byte[16];
                    m_colours.RemapIndices(closest, indices);

                    // save the block
                    ColourBlock.WriteColourBlock4(m_start, m_end, indices, block);

                    // save the error
                    m_besterror = error;
                }
            }

            // all 3d
            private Vector<float> m_metric;
            private Vector<float> m_start;
            private Vector<float> m_end;
            private float m_besterror;
        }

        public class ClusterFit : ColourFit
        {
            public ClusterFit(ColourSet colours, uint flags) : base(colours, flags)
            {
                // init arrays
                List<byte[]> orderList = new List<byte[]>();
                for (int i = 0; i < kMaxIterations; i++)
                    orderList.Add(new byte[16]);
                m_order = orderList.ToArray();

                List<Vector<float>> pointWeightsList = new List<Vector<float>>();
                for (int i = 0; i < 16; i++)
                    pointWeightsList.Add(VectorExtensions.InitializeVector());
                m_points_weights = pointWeightsList.ToArray();

                // set the iteration count
                m_iterationCount = (m_flags & (uint)SquishFlags.kColourIterativeClusterFit) != 0 ? kMaxIterations : 1;

                // initialise the best error
                m_besterror = float.MaxValue;  // ..

                // initialise the metric
                bool perceptual = ((m_flags & (uint)SquishFlags.kColourMetricPerceptual) != 0);
                if (perceptual)
                    m_metric = VectorExtensions.InitializeVector(new float[] { 0.2126f, 0.7152f, 0.0722f, 0.0f });
                else
                    m_metric = VectorExtensions.InitializeVector(new float[] { 1.0f, 1.0f, 1.0f, 1.0f }); // ..

                // cache some values
                int count = m_colours.GetCount();
                var values = m_colours.GetPoints();

                // get the covariance matrix
                Sym3x3 covariance = Sym3x3.ComputeWeightedCovariance(count, values, m_colours.GetWeights());

                // compute the principle component
                m_principle = covariance.ComputePrincipleComponent();
            }

            // axis 3d
            private bool ConstructOrdering(ref Vector<float> axis, int iteration)
            {
                // cache some values
                int count = m_colours.GetCount();
                var values = m_colours.GetPoints();

                // build the list of dot products
                Span<float> dps = stackalloc float[16];
                byte[] order = m_order[iteration];
                for( int i = 0; i < count; ++i )
                {
                    dps[i] = VectorExtensions.Dot3d(values[i], axis);
                    order[i] = (byte)i;
                }
                    
                // stable sort using them
                for( int i = 0; i < count; ++i )
                {
                    for( int j = i; j > 0 && dps[j] < dps[j - 1]; --j )
                    {
                        float tmp = dps[j];
                        dps[j] = dps[j - 1];
                        dps[j - 1] = tmp;

                        byte tmpB = order[j];
                        order[j] = order[j - 1];
                        order[j - 1] = tmpB;
                    }
                }
                
                // check this ordering is unique
                for( int it = 0; it < iteration; ++it )
                {
                    byte[] prev = m_order[it];
                    bool same = true;
                    for( int i = 0; i < count; ++i )
                    {
                        if( order[i] != prev[i] )
                        {
                            same = false;
                            break;
                        }
                    }
                    if( same )
                        return false;
                }
                
                // copy the ordering and weight all the points
                var unweighted = m_colours.GetPoints();
                var weights = m_colours.GetWeights();
                m_xsum_wsum = VectorExtensions.InitializeVector(new float[] { 0.0f, 0.0f, 0.0f, 0.0f });
                for ( int i = 0; i < count; ++i )
                {
                    int j = order[i];
                    Vector<float> p = VectorExtensions.InitializeVector(new float[] { unweighted[j][0], unweighted[j][1], unweighted[j][2], 1.0f });
                    Vector<float> w = VectorExtensions.InitializeVector(new float[] { weights[j], weights[j], weights[j], weights[j] });
                    Vector<float> x = p * w;
                    m_points_weights[i] = x;
                    m_xsum_wsum += x;
                }
                return true;
            }

            protected override void Compress3(Span<byte> block)
            {
                // declare variables
                int count = m_colours.GetCount();
                Vector<float> two = VectorExtensions.InitializeVector(new float[] { 2.0f, 2.0f, 2.0f, 2.0f });
                Vector<float> one = VectorExtensions.InitializeVector(new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
                Vector<float> half_half2 = VectorExtensions.InitializeVector(new float[] { 0.5f, 0.5f, 0.5f, 0.25f });
                Vector<float> zero = VectorExtensions.InitializeVector();
                Vector<float> half = VectorExtensions.InitializeVector(new float[] { 0.5f, 0.5f, 0.5f, 0.5f });
                Vector<float> grid = VectorExtensions.InitializeVector(new float[] { 31.0f, 63.0f, 31.0f, 0.0f });
                Vector<float> gridrcp = VectorExtensions.InitializeVector(new float[] { 1.0f / 31.0f, 1.0f / 63.0f, 1.0f / 31.0f, 0.0f });

                // prepare an ordering using the principle axis
                ConstructOrdering(ref m_principle, 0);

                // check all possible clusters and iterate on the total order
                Vector<float> beststart = VectorExtensions.InitializeVector();
                Vector<float> bestend = VectorExtensions.InitializeVector();
                float besterror = m_besterror;
                Span<byte> bestindices = stackalloc byte[16];
                int bestiteration = 0;
                int besti = 0, bestj = 0;

                // loop over iterations (we avoid the case that all points in first or last cluster)
                for (int iterationIndex = 0; ;)
                {
                    // first cluster [0,i) is at the start
                    Vector<float> part0 = VectorExtensions.InitializeVector();
                    for (int i = 0; i < count; ++i)
                    {
                        // second cluster [i,j) is half along
                        Vector<float> part1 = (i == 0) ? m_points_weights[0] : VectorExtensions.InitializeVector();
                        int jmin = (i == 0) ? 1 : i;
                        for (int j = jmin; ;)
                        {
                            // last cluster [j,count) is at the end
                            Vector<float> part2 = m_xsum_wsum - part1 - part0;

                            // compute least squares terms directly
                            Vector<float> alphax_sum = part1 * half_half2 + part0;
                            float alpha2_sum = alphax_sum[3];

                            Vector<float> betax_sum = part1 * half_half2 + part2;
                            float beta2_sum = betax_sum[3];

                            float alphabeta_sum = (part1[3] * half_half2[3]);

                            // compute the least-squares optimal points
                            float factor = 1.0f / (-1.0f * (alphabeta_sum * alphabeta_sum - (alpha2_sum * beta2_sum)));
                            Vector<float> a = -1.0f * (betax_sum * alphabeta_sum - (alphax_sum * beta2_sum)) * factor;
                            Vector<float> b = -1.0f * (alphax_sum * alphabeta_sum - (betax_sum * alpha2_sum)) * factor;

                            // clamp to the grid
                            a = SquishMath.Min4d(one, SquishMath.Max4d(zero, a));
                            b = SquishMath.Min4d(one, SquishMath.Max4d(zero, b));
                            a = SquishMath.Truncate4d(grid * a + half) * gridrcp;
                            b = SquishMath.Truncate4d(grid * b + half) * gridrcp;

                            // compute the error (we skip the constant xxsum)
                            Vector<float> e1 = (a * a) * alpha2_sum + (b * b * beta2_sum);
                            Vector<float> e2 = -1.0f * (a * alphax_sum - (a * b * alphabeta_sum));
                            Vector<float> e3 = -1.0f * (b * betax_sum - e2);
                            Vector<float> e4 = two * e3 + e1;

                            // apply the metric to the error term
                            Vector<float> e5 = e4 * m_metric;
                            float error = e5[0] + e5[1] + e5[2];

                            // keep the solution if it wins
                            if (error < besterror)
                            {
                                beststart = a;
                                bestend = b;
                                besti = i;
                                bestj = j;
                                besterror = error;
                                bestiteration = iterationIndex;
                            }

                            // advance
                            if (j == count)
                                break;
                            part1 += m_points_weights[j];
                            ++j;
                        }

                        // advance
                        part0 += m_points_weights[i];
                    }

                    // stop if we didn't improve in this iteration
                    if (bestiteration != iterationIndex)
                        break;

                    // advance if possible
                    ++iterationIndex;
                    if (iterationIndex == m_iterationCount)
                        break;

                    // stop if a new iteration is an ordering that has already been tried
                    Vector<float> axis = VectorExtensions.Convert4dTo3d(bestend - beststart);
                    if (!ConstructOrdering(ref axis, iterationIndex))
                        break;
                }

                // save the block if necessary
                if (besterror < m_besterror)
                {
                    // remap the indices
                    byte[] order = m_order[bestiteration];

                    Span<byte> unordered = stackalloc byte[16];
                    for (int m = 0; m < besti; ++m)
                        unordered[order[m]] = 0;
                    for (int m = besti; m < bestj; ++m)
                        unordered[order[m]] = 2;
                    for (int m = bestj; m < count; ++m)
                        unordered[order[m]] = 1;

                    m_colours.RemapIndices(unordered, bestindices);

                    // save the block
                    ColourBlock.WriteColourBlock3(VectorExtensions.Convert4dTo3d(beststart), VectorExtensions.Convert4dTo3d(bestend), bestindices, block);

                    // save the error
                    m_besterror = besterror;
                }
            }

            protected override void Compress4(Span<byte> block)
            {
                // declare variables
                int count = m_colours.GetCount();
                Vector<float> two = VectorExtensions.InitializeVector(new float[] { 2.0f, 2.0f, 2.0f, 2.0f });
                Vector<float> one = VectorExtensions.InitializeVector(new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
                Vector<float> onethird_onethird2 = VectorExtensions.InitializeVector(new float[] { 1.0f / 3.0f, 1.0f / 3.0f, 1.0f / 3.0f, 1.0f / 9.0f });
                Vector<float> twothirds_twothirds2 = VectorExtensions.InitializeVector(new float[] { 2.0f / 3.0f, 2.0f / 3.0f, 2.0f / 3.0f, 4.0f / 9.0f });
                Vector<float> twonineths = VectorExtensions.InitializeVector(new float[] { 2.0f / 9.0f, 2.0f / 9.0f, 2.0f / 9.0f, 2.0f / 9.0f });
                Vector<float> zero = VectorExtensions.InitializeVector();
                Vector<float> half = VectorExtensions.InitializeVector(new float[] { 0.5f, 0.5f, 0.5f, 0.5f });
                Vector<float> grid = VectorExtensions.InitializeVector(new float[] { 31.0f, 63.0f, 31.0f, 0.0f });
                Vector<float> gridrcp = VectorExtensions.InitializeVector(new float[] { 1.0f / 31.0f, 1.0f / 63.0f, 1.0f / 31.0f, 0.0f });

                // prepare an ordering using the principle axis
                ConstructOrdering(ref m_principle, 0);

                // check all possible clusters and iterate on the total order
                Vector<float> beststart = VectorExtensions.InitializeVector();
                Vector<float> bestend = VectorExtensions.InitializeVector();
                float besterror = m_besterror;
                Span<byte> bestindices = stackalloc byte[16];
                int bestiteration = 0;
                int besti = 0, bestj = 0, bestk = 0;

                // loop over iterations (we avoid the case that all points in first or last cluster)
                for (int iterationIndex = 0; ;)
                {
                    // first cluster [0,i) is at the start
                    Vector<float> part0 = VectorExtensions.InitializeVector();
                    for (int i = 0; i < count; ++i)
                    {
                        // second cluster [i,j) is one third along
                        Vector<float> part1 = VectorExtensions.InitializeVector();
                        for (int j = i; ;)
                        {
                            // third cluster [j,k) is two thirds along
                            Vector<float> part2 = (j == 0) ? m_points_weights[0] : VectorExtensions.InitializeVector();
                            int kmin = (j == 0) ? 1 : j;
                            for (int k = kmin; ;)
                            {
                                // last cluster [k,count) is at the end
                                Vector<float> part3 = m_xsum_wsum - part2 - part1 - part0;

                                // compute least squares terms directly
                                Vector<float> alphax_sum = (part2 * onethird_onethird2 + (part1 * twothirds_twothirds2 + part0));
                                float alpha2_sum = alphax_sum[3];

                                Vector<float> betax_sum = (part1 * onethird_onethird2 + (part2 * twothirds_twothirds2 + part3));
                                float beta2_sum = betax_sum[3];

                                Vector<float> alphabeta_sum = twonineths * (part1[3] + part2[3]);

                                // compute the least-squares optimal points
                                Vector<float> factor = -VectorExtensions.Subtract4d(alphabeta_sum * alphabeta_sum, alpha2_sum * beta2_sum);
                                Vector<float> a = -(betax_sum * alphabeta_sum - (alphax_sum * beta2_sum)) / factor;
                                Vector<float> b = -(alphax_sum * alphabeta_sum - (betax_sum * alpha2_sum)) / factor;

                                // clamp to the grid
                                a = SquishMath.Min4d(one, SquishMath.Max4d(zero, a));
                                b = SquishMath.Min4d(one, SquishMath.Max4d(zero, b));
                                a = SquishMath.Truncate4d(grid * a + half) * gridrcp;
                                b = SquishMath.Truncate4d(grid * b + half) * gridrcp;

                                // compute the error (we skip the constant xxsum)
                                Vector<float> e1 = a * a * alpha2_sum + (b * b * beta2_sum);
                                Vector<float> e2 = -(a * alphax_sum - (a * b * alphabeta_sum));
                                Vector<float> e3 = -(b * betax_sum - e2);
                                Vector<float> e4 = two * e3 + e1;

                                // apply the metric to the error term
                                Vector<float> e5 = e4 * m_metric;
                                float error = e5[0] + e5[1] + e5[2];

                                // keep the solution if it wins
                                if (error < besterror)
                                {
                                    beststart = a;
                                    bestend = b;
                                    besterror = error;
                                    besti = i;
                                    bestj = j;
                                    bestk = k;
                                    bestiteration = iterationIndex;
                                }

                                // advance
                                if (k == count)
                                    break;
                                part2 += m_points_weights[k];
                                ++k;
                            }

                            // advance
                            if (j == count)
                                break;
                            part1 += m_points_weights[j];
                            ++j;
                        }

                        // advance
                        part0 += m_points_weights[i];
                    }

                    // stop if we didn't improve in this iteration
                    if (bestiteration != iterationIndex)
                        break;

                    // advance if possible
                    ++iterationIndex;
                    if (iterationIndex == m_iterationCount)
                        break;

                    // stop if a new iteration is an ordering that has already been tried
                    Vector<float> axis = VectorExtensions.Convert4dTo3d(bestend - beststart);
                    if (!ConstructOrdering(ref axis, iterationIndex))
                        break;
                }

                // save the block if necessary
                if (besterror < m_besterror)
                {
                    // remap the indices
                    byte[] order = m_order[bestiteration];

                    Span<byte> unordered = stackalloc byte[16];
                    for (int m = 0; m < besti; ++m)
                        unordered[order[m]] = 0;
                    for (int m = besti; m < bestj; ++m)
                        unordered[order[m]] = 2;
                    for (int m = bestj; m < bestk; ++m)
                        unordered[order[m]] = 3;
                    for (int m = bestk; m < count; ++m)
                        unordered[order[m]] = 1;

                    m_colours.RemapIndices(unordered, bestindices);

                    // save the block
                    ColourBlock.WriteColourBlock4(VectorExtensions.Convert4dTo3d(beststart), VectorExtensions.Convert4dTo3d(bestend), bestindices, block);

                    // save the error
                    m_besterror = besterror;
                }
            }

            private static readonly int kMaxIterations = 8;

            private int m_iterationCount;
            private Vector<float> m_principle; //3d
            private byte[][] m_order; //  [16][kMaxIterations]
            private Vector<float>[] m_points_weights; //4d [16]
            private Vector<float> m_xsum_wsum;//4d
            private Vector<float> m_metric;	  //4d
            private float m_besterror;//4d
        }

        // NOTE that the return value is RGBA not BGRA
        private static void Decompress(ReadOnlySpan<byte> block, SquishFlags flags, Span<byte> rgba)
        {
            if (rgba.Length < 64)
            {
                static void Throw() => throw new ArgumentOutOfRangeException("rgba", "Length must be at least 64.");
                Throw();
            }

            // get the block locations
            ReadOnlySpan<byte> colourBlock = block;
            var alphaBock = block;
            if ((flags & SquishFlags.kDxt3) != 0 || (flags & SquishFlags.kDxt5) != 0)
                colourBlock = block[8..]; // skip 8 bytes in array

            // decompress colour
            DecompressColour(rgba, colourBlock, (flags & SquishFlags.kDxt1) != 0);

            // decompress alpha separately if necessary
            if ((flags & SquishFlags.kDxt3) != 0)
                DecompressAlphaDxt3(rgba, alphaBock);
            else if ((flags & SquishFlags.kDxt5) != 0)
                DecompressAlphaDxt5(rgba, alphaBock);
        }

        private static void DecompressColour(Span<byte> rgba, ReadOnlySpan<byte> block, bool isDxt1)
        {
            const bool d3d9 = true;

            // unpack the endpoints
            Span<byte> codes = stackalloc byte[16];
            int a = Unpack565((ushort)((int)block[0] | ((int)block[1] << 8)), codes, 0);
            int b = Unpack565((ushort)((int)block[2] | ((int)block[3] << 8)), codes, 4);

            // generate the midpoints
            for (int i = 0; i < 3; ++i)
            {
                int c = codes[i];
                int d = codes[4 + i];

                if (isDxt1 && a <= b)
                {
                    codes[8 + i] = (byte)((c + d) / 2);
                    codes[12 + i] = 0;
                }
                else
                {
                    codes[8 + i] = (byte)((2 * c + d + (d3d9 ? 1 : 0)) / 3);
                    codes[12 + i] = (byte)((c + 2 * d + (d3d9 ? 1 : 0)) / 3);
                }
            }

            // fill in alpha for the intermediate values
            codes[8 + 3] = 255;
            codes[12 + 3] = (isDxt1 && a <= b) ? (byte)0 : (byte)255;

            // unpack the indices
            Span<byte> indices = stackalloc byte[16];
            for (int i = 0; i < 4; ++i)
            {
                byte packed = block[4 + i];

                indices[4 * i + 0] = (byte)(packed & 0x3);
                indices[4 * i + 1] = (byte)((packed >> 2) & 0x3);
                indices[4 * i + 2] = (byte)((packed >> 4) & 0x3);
                indices[4 * i + 3] = (byte)((packed >> 6) & 0x3);
            }

            // store out the colours
            for (int i = 0; i < 16; ++i)
            {
                int offset = 4 * indices[i];
                for (int j = 0; j < 4; ++j)
                    rgba[4 * i + j] = codes[offset + j];
            }
        }

        private static int Unpack565(ushort packedValue, Span<byte> colours, int colourOffset)
        {
            // get the components in the stored range
            byte red = (byte)((packedValue >> 11) & 0x1f);
            byte green = (byte)((packedValue >> 5) & 0x3f);
            byte blue = (byte)(packedValue & 0x1f);

            // scale up to 8 bits (identical to HaloS3TC)
            colours[colourOffset + 0] = (byte)((red << 3) | (red >> 2));
            colours[colourOffset + 1] = (byte)((green << 2) | (green >> 4));
            colours[colourOffset + 2] = (byte)((blue << 3) | (blue >> 2));
            colours[colourOffset + 3] = 0xFF;

            return (int)packedValue;
        }

        private static void DecompressAlphaDxt3(Span<byte> rgba, ReadOnlySpan<byte> block)
        {
            // unpack the alpha values pairwise
            for (int i = 0; i < 8; ++i)
            {
                // quantise down to 4 bits
                byte quant = block[i];

                // unpack the values
                byte lo = (byte)(quant & 0x0f);
                byte hi = (byte)(quant & 0xf0);

                // convert back up to bytes
                rgba[8 * i + 3] = (byte)(lo | (lo << 4));
                rgba[8 * i + 7] = (byte)(hi | (hi >> 4));
            }
        }

        private static void DecompressAlphaDxt5(Span<byte> rgba, ReadOnlySpan<byte> block)
        {
            int alpha0 = block[0];
            int alpha1 = block[1];

            // compare the values to build the codebook
            Span<byte> codes = stackalloc byte[8];
            codes[0] = (byte)alpha0;
            codes[1] = (byte)alpha1;
            if (alpha0 <= alpha1)
            {
                // use 5-alpha codebook
                for (int i = 1; i < 5; ++i)
                    codes[1 + i] = (byte)(((5 - i) * alpha0 + i * alpha1) / 5);
                codes[6] = 0;
                codes[7] = 255;
            }
            else
            {
                // use 7-alpha codebook
                for (int i = 1; i < 7; ++i)
                    codes[1 + i] = (byte)(((7 - i) * alpha0 + i * alpha1) / 7);
            }

            // decode the indices
            Span<byte> indices = stackalloc byte[16];
            int blockOffset = 2;
            int destIndex = 0;
            for (int i = 0; i < 2; ++i)
            {
                // grab 3 bytes
                int value = 0;
                for (int j = 0; j < 3; ++j)
                {
                    int _byte = block[blockOffset];
                    blockOffset++;
                    value |= (_byte << 8 * j);
                }

                // unpack 8 3-bit values from it
                for (int j = 0; j < 8; ++j)
                {
                    int index = (value >> 3 * j) & 0x7;
                    indices[destIndex] = (byte)index;
                    destIndex++;
                }
            }

            // write out the indexed codebook values
            for (int i = 0; i < 16; ++i)
                rgba[4 * i + 3] = codes[indices[i]];
        }

        public static void Compress(ReadOnlySpan<byte> rgba, Span<byte> block, uint flags)
        {
            // compress with full mask
            CompressMasked(rgba, 0xffff, block, flags);
        }

        public static void CompressMasked(ReadOnlySpan<byte> rgba, uint mask, Span<byte> block, uint flags)
        {
            // fix any bad flags
            flags = FixFlags(flags);
            bool hasAlpha = (flags & ((uint)SquishFlags.kDxt3 | (uint)SquishFlags.kDxt5)) != 0;

            if ((flags & (uint)SquishFlags.kDxn) != 0)
            {
                CompressDxnBlock(rgba, mask, block);
                return;
            }

            // get the block locations
            var colourBlock = block;
            byte[] alphaChannelBuf = null;
            Span<byte> alphaChannel = default;
            if (hasAlpha)
            {
                colourBlock = block[8..]; // skip 8 bytes in array

                alphaChannelBuf = ArrayPool<byte>.Shared.Rent(rgba.Length / 4);
                alphaChannel = alphaChannelBuf[..(rgba.Length / 4)];
                for (int i = 0; i < rgba.Length; i += 4) alphaChannel[i >>> 2] = rgba[i + 3];
            }

            // create the minimal point set
            ColourSet colours = new ColourSet(rgba, mask, flags);

            // check the compression type and compress colour
            if (colours.GetCount() == 1)
            {
                // always do a single colour fit
                SingleColourFit fit = new SingleColourFit(colours, flags);
                fit.Compress(colourBlock);
            }
            else if ((flags & (uint)SquishFlags.kColourRangeFit ) != 0 || colours.GetCount() == 0 )
            {
                // do a range fit
                RangeFit fit = new RangeFit(colours, flags);
                fit.Compress(colourBlock);
            }
            else
            {
                // default to a cluster fit (could be iterative or not)
                ClusterFit fit = new ClusterFit(colours, flags);
                fit.Compress(colourBlock);
            }

            if (hasAlpha)
            {
                // write the colour block back to original buffer
                for (int i = 8; i < block.Length; i++)
                    block[i] = colourBlock[i - 8];
            }

            // compress alpha separately if necessary
            if ((flags & (uint)SquishFlags.kDxt3) != 0)
                CompressAlphaDxt3(alphaChannel, mask, block);
            else if ((flags & (uint)SquishFlags.kDxt5) != 0)
                CompressAlphaDxt5(alphaChannel, mask, block);

            if (alphaChannelBuf != null) ArrayPool<byte>.Shared.Return(alphaChannelBuf);
        }

        private static void CompressAlphaDxt3(ReadOnlySpan<byte> singleChannelData, uint mask, Span<byte> block)
        {			
            // quantise and pack the alpha values pairwise
            for( int i = 0; i < 8; ++i )
            {
                // quantise down to 4 bits
                float alpha1 = ( float )singleChannelData[2*i + 0] * ( 15.0f/255.0f );
                float alpha2 = ( float )singleChannelData[2*i + 1] * ( 15.0f/255.0f );
                int quant1 = SingleColourFit.FloatToInt( alpha1, 15 );
                int quant2 = SingleColourFit.FloatToInt( alpha2, 15 );
                
                // set alpha to zero where masked
                int bit1 = 1 << ( 2*i );
                int bit2 = 1 << ( 2*i + 1 );
                if( ( mask & bit1 ) == 0 )
                    quant1 = 0;
                if( ( mask & bit2 ) == 0 )
                    quant2 = 0;

                // pack into the byte
                block[i] = (byte)(quant1 | (quant2 << 4));
            }
        }

        private static void CompressAlphaDxt5(ReadOnlySpan<byte> singleChannelData, uint mask, Span<byte> block)
        {
            // get the range for 5-alpha and 7-alpha interpolation
            int min5 = 255;
            int max5 = 0;
            int min7 = 255;
            int max7 = 0;
            for (int i = 0; i < 16; ++i)
            {
                // check this pixel is valid
                int bit = 1 << i;
                if ((mask & bit) == 0)
                    continue;

                // incorporate into the min/max
                int value = singleChannelData[i];
                if (value < min7)
                    min7 = value;
                if (value > max7)
                    max7 = value;
                if (value != 0 && value < min5)
                    min5 = value;
                if (value != 255 && value > max5)
                    max5 = value;
            }

            // handle the case that no valid range was found
            if (min5 > max5)
                min5 = max5;
            if (min7 > max7)
                min7 = max7;

            // fix the range to be the minimum in each case
            FixRange(ref min5, ref max5, 5);
            FixRange(ref min7, ref max7, 7);

            // set up the 5-alpha code book
            byte[] codes5 = new byte[8];
            codes5[0] = (byte)min5;
            codes5[1] = (byte)max5;
            for (int i = 1; i < 5; ++i)
                codes5[1 + i] = (byte)(((5 - i) * min5 + i * max5) / 5);
            codes5[6] = 0;
            codes5[7] = 255;

            // set up the 7-alpha code book
            byte[] codes7 = new byte[8];
            codes7[0] = (byte)min7;
            codes7[1] = (byte)max7;
            for (int i = 1; i < 7; ++i)
                codes7[1 + i] = (byte)(((7 - i) * min7 + i * max7) / 7);

            // fit the data to both code books
            byte[] indices5 = new byte[16];
            byte[] indices7 = new byte[16];
            int err5 = FitCodes(singleChannelData, mask, codes5, indices5);
            int err7 = FitCodes(singleChannelData, mask, codes7, indices7);

            // save the block with least error
            if (err5 <= err7)
                WriteAlphaBlock5(min5, max5, indices5, block);
            else
                WriteAlphaBlock7(min7, max7, indices7, block);
        }

        private static void CompressDxnBlock(ReadOnlySpan<byte> rgba, uint mask, Span<byte> block)
        {
            // compress RG channels as 2 dxt5 alpha

            byte[] redChannelPooled = null;
            Span<byte> redChannel = (rgba.Length <= 128 ? stackalloc byte[32] : (redChannelPooled ??= ArrayPool<byte>.Shared.Rent(rgba.Length / 4)))[..(int)((uint)rgba.Length / 4)];
            byte[] greenChannelPooled = null;
            Span<byte> greenChannel = (rgba.Length <= 128 ? stackalloc byte[32] : (greenChannelPooled ??= ArrayPool<byte>.Shared.Rent(rgba.Length / 4)))[..(int)((uint)rgba.Length / 4)];
            for (int i = 0; i < rgba.Length; i += 4)
            {
                redChannel[i >>> 2] = rgba[i + 0];
                greenChannel[i >>> 2] = rgba[i + 1];
            }

            Span<byte> redBlock = stackalloc byte[8];
            Span<byte> greenBlock = stackalloc byte[8];

            CompressAlphaDxt5(redChannel, mask, redBlock);
            CompressAlphaDxt5(greenChannel, mask, greenBlock);

            if (redChannelPooled != null) ArrayPool<byte>.Shared.Return(redChannelPooled);
            if (greenChannelPooled != null) ArrayPool<byte>.Shared.Return(greenChannelPooled);

            // XY -> YX
            for (int i = 0; i < 8; i++)
                block[i] = greenBlock[i];
            for (int i = 0; i < 8; i++)
                block[i + 8] = redBlock[i];
        }

        private static void WriteAlphaBlock5(int alpha0, int alpha1, ReadOnlySpan<byte> indices, Span<byte> block)
        {
            // check the relative values of the endpoints
            if (alpha0 > alpha1)
            {
                // swap the indices
                Span<byte> swapped = stackalloc byte[16];
                for (int i = 0; i < 16; ++i)
                {
                    byte index = indices[i];
                    if (index == 0)
                        swapped[i] = 1;
                    else if (index == 1)
                        swapped[i] = 0;
                    else if (index <= 5)
                        swapped[i] = (byte)(7 - index);
                    else
                        swapped[i] = index;
                }

                // write the block
                WriteAlphaBlock(alpha1, alpha0, swapped, block);
            }
            else
            {
                // write the block
                WriteAlphaBlock(alpha0, alpha1, indices, block);
            }
        }

        private static void WriteAlphaBlock7(int alpha0, int alpha1, ReadOnlySpan<byte> indices, Span<byte> block)
        {
            // check the relative values of the endpoints
            if (alpha0 < alpha1)
            {
                // swap the indices
                Span<byte> swapped = stackalloc byte[16];
                for (int i = 0; i < 16; ++i)
                {
                    byte index = indices[i];
                    if (index == 0)
                        swapped[i] = 1;
                    else if (index == 1)
                        swapped[i] = 0;
                    else
                        swapped[i] = (byte)(9 - index);
                }

                // write the block
                WriteAlphaBlock(alpha1, alpha0, swapped, block);
            }
            else
            {
                // write the block
                WriteAlphaBlock(alpha0, alpha1, indices, block);
            }
        }

        private static void WriteAlphaBlock(int alpha0, int alpha1, ReadOnlySpan<byte> indices, Span<byte> block)
        {
            // write the first two bytes
            block[0] = (byte)alpha0;
            block[1] = (byte)alpha1;

            // pack the indices with 3 bits each
            int destOffset = 2;
            int srcOffset = 0;
            for (int i = 0; i < 2; ++i)
            {
                // pack 8 3-bit values
                int value = 0;
                for (int j = 0; j < 8; ++j)
                {
                    int index = indices[srcOffset];
                    srcOffset++;
                    value |= (index << 3 * j);
                }

                // store in 3 bytes
                for (int j = 0; j < 3; ++j)
                {
                    int aByte = (value >> 8 * j) & 0xff;
                    block[destOffset] = (byte)aByte;
                    destOffset++;
                }
            }
        }

        private static int FitCodes(ReadOnlySpan<byte> singleChannelData, uint mask, ReadOnlySpan<byte> codes, Span<byte> indices)
        {
            // fit each alpha value to the codebook
            int err = 0;
            for (int i = 0; i < 16; ++i)
            {
                // check this pixel is valid
                int bit = 1 << i;
                if ((mask & bit) == 0)
                {
                    // use the first code
                    indices[i] = 0;
                    continue;
                }

                // find the least error and corresponding index
                int value = singleChannelData[i];
                int least = int.MaxValue;
                int index = 0;
                for (int j = 0; j < 8; ++j)
                {
                    // get the squared error from this code
                    int dist = (int)value - (int)codes[j];
                    dist *= dist;

                    // compare with the best so far
                    if (dist < least)
                    {
                        least = dist;
                        index = j;
                    }
                }

                // save this index and accumulate the error
                indices[i] = (byte)index;
                err += least;
            }

            // return the total error
            return err;
        }

        private static void FixRange(ref int min, ref int max, int steps)
        {
            if (max - min < steps)
                max = Math.Min(min + steps, 255);
            if (max - min < steps)
                min = Math.Max(0, max - steps);
        }

        public static uint FixFlags(uint flags)
        {
            // grab the flag bits
            uint method = flags & ((uint)SquishFlags.kDxt1 | (uint)SquishFlags.kDxt3 | (uint)SquishFlags.kDxt5 | (uint)SquishFlags.kDxn);
            uint fit = flags & ((uint)SquishFlags.kColourIterativeClusterFit | (uint)SquishFlags.kColourClusterFit | (uint)SquishFlags.kColourRangeFit);
            uint metric = flags & ((uint)SquishFlags.kColourMetricPerceptual | (uint)SquishFlags.kColourMetricUniform);
            uint extra = flags & ((uint)SquishFlags.kWeightColourByAlpha | (uint)SquishFlags.kSourceBgra);

            // set defaults
            if (method != (uint)SquishFlags.kDxt3 && method != (uint)SquishFlags.kDxt5 && method != (uint)SquishFlags.kDxn)
                method = (uint)SquishFlags.kDxt1;
            if (fit != (uint)SquishFlags.kColourRangeFit)
                fit = (uint)SquishFlags.kColourClusterFit;
            if (metric != (uint)SquishFlags.kColourMetricUniform)
                metric = (uint)SquishFlags.kColourMetricPerceptual;

            // done
            return method | fit | metric | extra;
        }

        //ROS<byte> => new byte[] { ... } is an RVA static readonly
        static ReadOnlySpan<SingleColourLookup> lookup_5_3 => MemoryMarshal.Cast<byte, SingleColourLookup>(_lookup_5_3);
        private static ReadOnlySpan<byte> _lookup_5_3 => new byte[]
        {
            0, 0, 0, 0, 0, 0,
            0, 0, 1, 0, 0, 1,
            0, 0, 2, 0, 0, 2,
            0, 0, 3, 0, 1, 1,
            0, 0, 4, 0, 1, 0,
            1, 0, 3, 0, 1, 1,
            1, 0, 2, 0, 1, 2,
            1, 0, 1, 0, 2, 1,
            1, 0, 0, 0, 2, 0,
            1, 0, 1, 0, 2, 1,
            1, 0, 2, 0, 2, 2,
            1, 0, 3, 0, 3, 1,
            1, 0, 4, 0, 3, 0,
            2, 0, 3, 0, 3, 1,
            2, 0, 2, 0, 3, 2,
            2, 0, 1, 0, 4, 1,
            2, 0, 0, 0, 4, 0,
            2, 0, 1, 0, 4, 1,
            2, 0, 2, 0, 4, 2,
            2, 0, 3, 0, 5, 1,
            2, 0, 4, 0, 5, 0,
            3, 0, 3, 0, 5, 1,
            3, 0, 2, 0, 5, 2,
            3, 0, 1, 0, 6, 1,
            3, 0, 0, 0, 6, 0,
            3, 0, 1, 0, 6, 1,
            3, 0, 2, 0, 6, 2,
            3, 0, 3, 0, 7, 1,
            3, 0, 4, 0, 7, 0,
            4, 0, 4, 0, 7, 1,
            4, 0, 3, 0, 7, 2,
            4, 0, 2, 1, 7, 1,
            4, 0, 1, 1, 7, 0,
            4, 0, 0, 0, 8, 0,
            4, 0, 1, 0, 8, 1,
            4, 0, 2, 2, 7, 1,
            4, 0, 3, 2, 7, 0,
            4, 0, 4, 0, 9, 0,
            5, 0, 3, 0, 9, 1,
            5, 0, 2, 3, 7, 1,
            5, 0, 1, 3, 7, 0,
            5, 0, 0, 0, 10, 0,
            5, 0, 1, 0, 10, 1,
            5, 0, 2, 0, 10, 2,
            5, 0, 3, 0, 11, 1,
            5, 0, 4, 0, 11, 0,
            6, 0, 3, 0, 11, 1,
            6, 0, 2, 0, 11, 2,
            6, 0, 1, 0, 12, 1,
            6, 0, 0, 0, 12, 0,
            6, 0, 1, 0, 12, 1,
            6, 0, 2, 0, 12, 2,
            6, 0, 3, 0, 13, 1,
            6, 0, 4, 0, 13, 0,
            7, 0, 3, 0, 13, 1,
            7, 0, 2, 0, 13, 2,
            7, 0, 1, 0, 14, 1,
            7, 0, 0, 0, 14, 0,
            7, 0, 1, 0, 14, 1,
            7, 0, 2, 0, 14, 2,
            7, 0, 3, 0, 15, 1,
            7, 0, 4, 0, 15, 0,
            8, 0, 4, 0, 15, 1,
            8, 0, 3, 0, 15, 2,
            8, 0, 2, 1, 15, 1,
            8, 0, 1, 1, 15, 0,
            8, 0, 0, 0, 16, 0,
            8, 0, 1, 0, 16, 1,
            8, 0, 2, 2, 15, 1,
            8, 0, 3, 2, 15, 0,
            8, 0, 4, 0, 17, 0,
            9, 0, 3, 0, 17, 1,
            9, 0, 2, 3, 15, 1,
            9, 0, 1, 3, 15, 0,
            9, 0, 0, 0, 18, 0,
            9, 0, 1, 0, 18, 1,
            9, 0, 2, 0, 18, 2,
            9, 0, 3, 0, 19, 1,
            9, 0, 4, 0, 19, 0,
            10, 0, 3, 0, 19, 1,
            10, 0, 2, 0, 19, 2,
            10, 0, 1, 0, 20, 1,
            10, 0, 0, 0, 20, 0,
            10, 0, 1, 0, 20, 1,
            10, 0, 2, 0, 20, 2,
            10, 0, 3, 0, 21, 1,
            10, 0, 4, 0, 21, 0,
            11, 0, 3, 0, 21, 1,
            11, 0, 2, 0, 21, 2,
            11, 0, 1, 0, 22, 1,
            11, 0, 0, 0, 22, 0,
            11, 0, 1, 0, 22, 1,
            11, 0, 2, 0, 22, 2,
            11, 0, 3, 0, 23, 1,
            11, 0, 4, 0, 23, 0,
            12, 0, 4, 0, 23, 1,
            12, 0, 3, 0, 23, 2,
            12, 0, 2, 1, 23, 1,
            12, 0, 1, 1, 23, 0,
            12, 0, 0, 0, 24, 0,
            12, 0, 1, 0, 24, 1,
            12, 0, 2, 2, 23, 1,
            12, 0, 3, 2, 23, 0,
            12, 0, 4, 0, 25, 0,
            13, 0, 3, 0, 25, 1,
            13, 0, 2, 3, 23, 1,
            13, 0, 1, 3, 23, 0,
            13, 0, 0, 0, 26, 0,
            13, 0, 1, 0, 26, 1,
            13, 0, 2, 0, 26, 2,
            13, 0, 3, 0, 27, 1,
            13, 0, 4, 0, 27, 0,
            14, 0, 3, 0, 27, 1,
            14, 0, 2, 0, 27, 2,
            14, 0, 1, 0, 28, 1,
            14, 0, 0, 0, 28, 0,
            14, 0, 1, 0, 28, 1,
            14, 0, 2, 0, 28, 2,
            14, 0, 3, 0, 29, 1,
            14, 0, 4, 0, 29, 0,
            15, 0, 3, 0, 29, 1,
            15, 0, 2, 0, 29, 2,
            15, 0, 1, 0, 30, 1,
            15, 0, 0, 0, 30, 0,
            15, 0, 1, 0, 30, 1,
            15, 0, 2, 0, 30, 2,
            15, 0, 3, 0, 31, 1,
            15, 0, 4, 0, 31, 0,
            16, 0, 4, 0, 31, 1,
            16, 0, 3, 0, 31, 2,
            16, 0, 2, 1, 31, 1,
            16, 0, 1, 1, 31, 0,
            16, 0, 0, 4, 28, 0,
            16, 0, 1, 4, 28, 1,
            16, 0, 2, 2, 31, 1,
            16, 0, 3, 2, 31, 0,
            16, 0, 4, 4, 29, 0,
            17, 0, 3, 4, 29, 1,
            17, 0, 2, 3, 31, 1,
            17, 0, 1, 3, 31, 0,
            17, 0, 0, 4, 30, 0,
            17, 0, 1, 4, 30, 1,
            17, 0, 2, 4, 30, 2,
            17, 0, 3, 4, 31, 1,
            17, 0, 4, 4, 31, 0,
            18, 0, 3, 4, 31, 1,
            18, 0, 2, 4, 31, 2,
            18, 0, 1, 5, 31, 1,
            18, 0, 0, 5, 31, 0,
            18, 0, 1, 5, 31, 1,
            18, 0, 2, 5, 31, 2,
            18, 0, 3, 6, 31, 1,
            18, 0, 4, 6, 31, 0,
            19, 0, 3, 6, 31, 1,
            19, 0, 2, 6, 31, 2,
            19, 0, 1, 7, 31, 1,
            19, 0, 0, 7, 31, 0,
            19, 0, 1, 7, 31, 1,
            19, 0, 2, 7, 31, 2,
            19, 0, 3, 8, 31, 1,
            19, 0, 4, 8, 31, 0,
            20, 0, 4, 8, 31, 1,
            20, 0, 3, 8, 31, 2,
            20, 0, 2, 9, 31, 1,
            20, 0, 1, 9, 31, 0,
            20, 0, 0, 12, 28, 0,
            20, 0, 1, 12, 28, 1,
            20, 0, 2, 10, 31, 1,
            20, 0, 3, 10, 31, 0,
            20, 0, 4, 12, 29, 0,
            21, 0, 3, 12, 29, 1,
            21, 0, 2, 11, 31, 1,
            21, 0, 1, 11, 31, 0,
            21, 0, 0, 12, 30, 0,
            21, 0, 1, 12, 30, 1,
            21, 0, 2, 12, 30, 2,
            21, 0, 3, 12, 31, 1,
            21, 0, 4, 12, 31, 0,
            22, 0, 3, 12, 31, 1,
            22, 0, 2, 12, 31, 2,
            22, 0, 1, 13, 31, 1,
            22, 0, 0, 13, 31, 0,
            22, 0, 1, 13, 31, 1,
            22, 0, 2, 13, 31, 2,
            22, 0, 3, 14, 31, 1,
            22, 0, 4, 14, 31, 0,
            23, 0, 3, 14, 31, 1,
            23, 0, 2, 14, 31, 2,
            23, 0, 1, 15, 31, 1,
            23, 0, 0, 15, 31, 0,
            23, 0, 1, 15, 31, 1,
            23, 0, 2, 15, 31, 2,
            23, 0, 3, 16, 31, 1,
            23, 0, 4, 16, 31, 0,
            24, 0, 4, 16, 31, 1,
            24, 0, 3, 16, 31, 2,
            24, 0, 2, 17, 31, 1,
            24, 0, 1, 17, 31, 0,
            24, 0, 0, 20, 28, 0,
            24, 0, 1, 20, 28, 1,
            24, 0, 2, 18, 31, 1,
            24, 0, 3, 18, 31, 0,
            24, 0, 4, 20, 29, 0,
            25, 0, 3, 20, 29, 1,
            25, 0, 2, 19, 31, 1,
            25, 0, 1, 19, 31, 0,
            25, 0, 0, 20, 30, 0,
            25, 0, 1, 20, 30, 1,
            25, 0, 2, 20, 30, 2,
            25, 0, 3, 20, 31, 1,
            25, 0, 4, 20, 31, 0,
            26, 0, 3, 20, 31, 1,
            26, 0, 2, 20, 31, 2,
            26, 0, 1, 21, 31, 1,
            26, 0, 0, 21, 31, 0,
            26, 0, 1, 21, 31, 1,
            26, 0, 2, 21, 31, 2,
            26, 0, 3, 22, 31, 1,
            26, 0, 4, 22, 31, 0,
            27, 0, 3, 22, 31, 1,
            27, 0, 2, 22, 31, 2,
            27, 0, 1, 23, 31, 1,
            27, 0, 0, 23, 31, 0,
            27, 0, 1, 23, 31, 1,
            27, 0, 2, 23, 31, 2,
            27, 0, 3, 24, 31, 1,
            27, 0, 4, 24, 31, 0,
            28, 0, 4, 24, 31, 1,
            28, 0, 3, 24, 31, 2,
            28, 0, 2, 25, 31, 1,
            28, 0, 1, 25, 31, 0,
            28, 0, 0, 28, 28, 0,
            28, 0, 1, 28, 28, 1,
            28, 0, 2, 26, 31, 1,
            28, 0, 3, 26, 31, 0,
            28, 0, 4, 28, 29, 0,
            29, 0, 3, 28, 29, 1,
            29, 0, 2, 27, 31, 1,
            29, 0, 1, 27, 31, 0,
            29, 0, 0, 28, 30, 0,
            29, 0, 1, 28, 30, 1,
            29, 0, 2, 28, 30, 2,
            29, 0, 3, 28, 31, 1,
            29, 0, 4, 28, 31, 0,
            30, 0, 3, 28, 31, 1,
            30, 0, 2, 28, 31, 2,
            30, 0, 1, 29, 31, 1,
            30, 0, 0, 29, 31, 0,
            30, 0, 1, 29, 31, 1,
            30, 0, 2, 29, 31, 2,
            30, 0, 3, 30, 31, 1,
            30, 0, 4, 30, 31, 0,
            31, 0, 3, 30, 31, 1,
            31, 0, 2, 30, 31, 2,
            31, 0, 1, 31, 31, 1,
            31, 0, 0, 31, 31, 0,
        };

        //ROS<byte> => new byte[] { ... } is an RVA static readonly
        static ReadOnlySpan<SingleColourLookup> lookup_6_3 => MemoryMarshal.Cast<byte, SingleColourLookup>(_lookup_6_3);
        private static ReadOnlySpan<byte> _lookup_6_3 => new byte[]
        {
            0, 0, 0, 0, 0, 0,
            0, 0, 1, 0, 1, 1,
            0, 0, 2, 0, 1, 0,
            1, 0, 1, 0, 2, 1,
            1, 0, 0, 0, 2, 0,
            1, 0, 1, 0, 3, 1,
            1, 0, 2, 0, 3, 0,
            2, 0, 1, 0, 4, 1,
            2, 0, 0, 0, 4, 0,
            2, 0, 1, 0, 5, 1,
            2, 0, 2, 0, 5, 0,
            3, 0, 1, 0, 6, 1,
            3, 0, 0, 0, 6, 0,
            3, 0, 1, 0, 7, 1,
            3, 0, 2, 0, 7, 0,
            4, 0, 1, 0, 8, 1,
            4, 0, 0, 0, 8, 0,
            4, 0, 1, 0, 9, 1,
            4, 0, 2, 0, 9, 0,
            5, 0, 1, 0, 10, 1,
            5, 0, 0, 0, 10, 0,
            5, 0, 1, 0, 11, 1,
            5, 0, 2, 0, 11, 0,
            6, 0, 1, 0, 12, 1,
            6, 0, 0, 0, 12, 0,
            6, 0, 1, 0, 13, 1,
            6, 0, 2, 0, 13, 0,
            7, 0, 1, 0, 14, 1,
            7, 0, 0, 0, 14, 0,
            7, 0, 1, 0, 15, 1,
            7, 0, 2, 0, 15, 0,
            8, 0, 1, 0, 16, 1,
            8, 0, 0, 0, 16, 0,
            8, 0, 1, 0, 17, 1,
            8, 0, 2, 0, 17, 0,
            9, 0, 1, 0, 18, 1,
            9, 0, 0, 0, 18, 0,
            9, 0, 1, 0, 19, 1,
            9, 0, 2, 0, 19, 0,
            10, 0, 1, 0, 20, 1,
            10, 0, 0, 0, 20, 0,
            10, 0, 1, 0, 21, 1,
            10, 0, 2, 0, 21, 0,
            11, 0, 1, 0, 22, 1,
            11, 0, 0, 0, 22, 0,
            11, 0, 1, 0, 23, 1,
            11, 0, 2, 0, 23, 0,
            12, 0, 1, 0, 24, 1,
            12, 0, 0, 0, 24, 0,
            12, 0, 1, 0, 25, 1,
            12, 0, 2, 0, 25, 0,
            13, 0, 1, 0, 26, 1,
            13, 0, 0, 0, 26, 0,
            13, 0, 1, 0, 27, 1,
            13, 0, 2, 0, 27, 0,
            14, 0, 1, 0, 28, 1,
            14, 0, 0, 0, 28, 0,
            14, 0, 1, 0, 29, 1,
            14, 0, 2, 0, 29, 0,
            15, 0, 1, 0, 30, 1,
            15, 0, 0, 0, 30, 0,
            15, 0, 1, 0, 31, 1,
            15, 0, 2, 0, 31, 0,
            16, 0, 2, 1, 31, 1,
            16, 0, 1, 1, 31, 0,
            16, 0, 0, 0, 32, 0,
            16, 0, 1, 2, 31, 0,
            16, 0, 2, 0, 33, 0,
            17, 0, 1, 3, 31, 0,
            17, 0, 0, 0, 34, 0,
            17, 0, 1, 4, 31, 0,
            17, 0, 2, 0, 35, 0,
            18, 0, 1, 5, 31, 0,
            18, 0, 0, 0, 36, 0,
            18, 0, 1, 6, 31, 0,
            18, 0, 2, 0, 37, 0,
            19, 0, 1, 7, 31, 0,
            19, 0, 0, 0, 38, 0,
            19, 0, 1, 8, 31, 0,
            19, 0, 2, 0, 39, 0,
            20, 0, 1, 9, 31, 0,
            20, 0, 0, 0, 40, 0,
            20, 0, 1, 10, 31, 0,
            20, 0, 2, 0, 41, 0,
            21, 0, 1, 11, 31, 0,
            21, 0, 0, 0, 42, 0,
            21, 0, 1, 12, 31, 0,
            21, 0, 2, 0, 43, 0,
            22, 0, 1, 13, 31, 0,
            22, 0, 0, 0, 44, 0,
            22, 0, 1, 14, 31, 0,
            22, 0, 2, 0, 45, 0,
            23, 0, 1, 15, 31, 0,
            23, 0, 0, 0, 46, 0,
            23, 0, 1, 0, 47, 1,
            23, 0, 2, 0, 47, 0,
            24, 0, 1, 0, 48, 1,
            24, 0, 0, 0, 48, 0,
            24, 0, 1, 0, 49, 1,
            24, 0, 2, 0, 49, 0,
            25, 0, 1, 0, 50, 1,
            25, 0, 0, 0, 50, 0,
            25, 0, 1, 0, 51, 1,
            25, 0, 2, 0, 51, 0,
            26, 0, 1, 0, 52, 1,
            26, 0, 0, 0, 52, 0,
            26, 0, 1, 0, 53, 1,
            26, 0, 2, 0, 53, 0,
            27, 0, 1, 0, 54, 1,
            27, 0, 0, 0, 54, 0,
            27, 0, 1, 0, 55, 1,
            27, 0, 2, 0, 55, 0,
            28, 0, 1, 0, 56, 1,
            28, 0, 0, 0, 56, 0,
            28, 0, 1, 0, 57, 1,
            28, 0, 2, 0, 57, 0,
            29, 0, 1, 0, 58, 1,
            29, 0, 0, 0, 58, 0,
            29, 0, 1, 0, 59, 1,
            29, 0, 2, 0, 59, 0,
            30, 0, 1, 0, 60, 1,
            30, 0, 0, 0, 60, 0,
            30, 0, 1, 0, 61, 1,
            30, 0, 2, 0, 61, 0,
            31, 0, 1, 0, 62, 1,
            31, 0, 0, 0, 62, 0,
            31, 0, 1, 0, 63, 1,
            31, 0, 2, 0, 63, 0,
            32, 0, 2, 1, 63, 1,
            32, 0, 1, 1, 63, 0,
            32, 0, 0, 16, 48, 0,
            32, 0, 1, 2, 63, 0,
            32, 0, 2, 16, 49, 0,
            33, 0, 1, 3, 63, 0,
            33, 0, 0, 16, 50, 0,
            33, 0, 1, 4, 63, 0,
            33, 0, 2, 16, 51, 0,
            34, 0, 1, 5, 63, 0,
            34, 0, 0, 16, 52, 0,
            34, 0, 1, 6, 63, 0,
            34, 0, 2, 16, 53, 0,
            35, 0, 1, 7, 63, 0,
            35, 0, 0, 16, 54, 0,
            35, 0, 1, 8, 63, 0,
            35, 0, 2, 16, 55, 0,
            36, 0, 1, 9, 63, 0,
            36, 0, 0, 16, 56, 0,
            36, 0, 1, 10, 63, 0,
            36, 0, 2, 16, 57, 0,
            37, 0, 1, 11, 63, 0,
            37, 0, 0, 16, 58, 0,
            37, 0, 1, 12, 63, 0,
            37, 0, 2, 16, 59, 0,
            38, 0, 1, 13, 63, 0,
            38, 0, 0, 16, 60, 0,
            38, 0, 1, 14, 63, 0,
            38, 0, 2, 16, 61, 0,
            39, 0, 1, 15, 63, 0,
            39, 0, 0, 16, 62, 0,
            39, 0, 1, 16, 63, 1,
            39, 0, 2, 16, 63, 0,
            40, 0, 1, 17, 63, 1,
            40, 0, 0, 17, 63, 0,
            40, 0, 1, 18, 63, 1,
            40, 0, 2, 18, 63, 0,
            41, 0, 1, 19, 63, 1,
            41, 0, 0, 19, 63, 0,
            41, 0, 1, 20, 63, 1,
            41, 0, 2, 20, 63, 0,
            42, 0, 1, 21, 63, 1,
            42, 0, 0, 21, 63, 0,
            42, 0, 1, 22, 63, 1,
            42, 0, 2, 22, 63, 0,
            43, 0, 1, 23, 63, 1,
            43, 0, 0, 23, 63, 0,
            43, 0, 1, 24, 63, 1,
            43, 0, 2, 24, 63, 0,
            44, 0, 1, 25, 63, 1,
            44, 0, 0, 25, 63, 0,
            44, 0, 1, 26, 63, 1,
            44, 0, 2, 26, 63, 0,
            45, 0, 1, 27, 63, 1,
            45, 0, 0, 27, 63, 0,
            45, 0, 1, 28, 63, 1,
            45, 0, 2, 28, 63, 0,
            46, 0, 1, 29, 63, 1,
            46, 0, 0, 29, 63, 0,
            46, 0, 1, 30, 63, 1,
            46, 0, 2, 30, 63, 0,
            47, 0, 1, 31, 63, 1,
            47, 0, 0, 31, 63, 0,
            47, 0, 1, 32, 63, 1,
            47, 0, 2, 32, 63, 0,
            48, 0, 2, 33, 63, 1,
            48, 0, 1, 33, 63, 0,
            48, 0, 0, 48, 48, 0,
            48, 0, 1, 34, 63, 0,
            48, 0, 2, 48, 49, 0,
            49, 0, 1, 35, 63, 0,
            49, 0, 0, 48, 50, 0,
            49, 0, 1, 36, 63, 0,
            49, 0, 2, 48, 51, 0,
            50, 0, 1, 37, 63, 0,
            50, 0, 0, 48, 52, 0,
            50, 0, 1, 38, 63, 0,
            50, 0, 2, 48, 53, 0,
            51, 0, 1, 39, 63, 0,
            51, 0, 0, 48, 54, 0,
            51, 0, 1, 40, 63, 0,
            51, 0, 2, 48, 55, 0,
            52, 0, 1, 41, 63, 0,
            52, 0, 0, 48, 56, 0,
            52, 0, 1, 42, 63, 0,
            52, 0, 2, 48, 57, 0,
            53, 0, 1, 43, 63, 0,
            53, 0, 0, 48, 58, 0,
            53, 0, 1, 44, 63, 0,
            53, 0, 2, 48, 59, 0,
            54, 0, 1, 45, 63, 0,
            54, 0, 0, 48, 60, 0,
            54, 0, 1, 46, 63, 0,
            54, 0, 2, 48, 61, 0,
            55, 0, 1, 47, 63, 0,
            55, 0, 0, 48, 62, 0,
            55, 0, 1, 48, 63, 1,
            55, 0, 2, 48, 63, 0,
            56, 0, 1, 49, 63, 1,
            56, 0, 0, 49, 63, 0,
            56, 0, 1, 50, 63, 1,
            56, 0, 2, 50, 63, 0,
            57, 0, 1, 51, 63, 1,
            57, 0, 0, 51, 63, 0,
            57, 0, 1, 52, 63, 1,
            57, 0, 2, 52, 63, 0,
            58, 0, 1, 53, 63, 1,
            58, 0, 0, 53, 63, 0,
            58, 0, 1, 54, 63, 1,
            58, 0, 2, 54, 63, 0,
            59, 0, 1, 55, 63, 1,
            59, 0, 0, 55, 63, 0,
            59, 0, 1, 56, 63, 1,
            59, 0, 2, 56, 63, 0,
            60, 0, 1, 57, 63, 1,
            60, 0, 0, 57, 63, 0,
            60, 0, 1, 58, 63, 1,
            60, 0, 2, 58, 63, 0,
            61, 0, 1, 59, 63, 1,
            61, 0, 0, 59, 63, 0,
            61, 0, 1, 60, 63, 1,
            61, 0, 2, 60, 63, 0,
            62, 0, 1, 61, 63, 1,
            62, 0, 0, 61, 63, 0,
            62, 0, 1, 62, 63, 1,
            62, 0, 2, 62, 63, 0,
            63, 0, 1, 63, 63, 1,
            63, 0, 0, 63, 63, 0,
        };

        //ROS<byte> => new byte[] { ... } is an RVA static readonly
        static ReadOnlySpan<SingleColourLookup> lookup_5_4 => MemoryMarshal.Cast<byte, SingleColourLookup>(_lookup_5_4);
        private static ReadOnlySpan<byte> _lookup_5_4 => new byte[]
        {
            0, 0, 0, 0, 0, 0,
            0, 0, 1, 0, 1, 1,
            0, 0, 2, 0, 1, 0,
            0, 0, 3, 0, 1, 1,
            0, 0, 4, 0, 2, 1,
            1, 0, 3, 0, 2, 0,
            1, 0, 2, 0, 2, 1,
            1, 0, 1, 0, 3, 1,
            1, 0, 0, 0, 3, 0,
            1, 0, 1, 1, 2, 1,
            1, 0, 2, 1, 2, 0,
            1, 0, 3, 0, 4, 0,
            1, 0, 4, 0, 5, 1,
            2, 0, 3, 0, 5, 0,
            2, 0, 2, 0, 5, 1,
            2, 0, 1, 0, 6, 1,
            2, 0, 0, 0, 6, 0,
            2, 0, 1, 2, 3, 1,
            2, 0, 2, 2, 3, 0,
            2, 0, 3, 0, 7, 0,
            2, 0, 4, 1, 6, 1,
            3, 0, 3, 1, 6, 0,
            3, 0, 2, 0, 8, 0,
            3, 0, 1, 0, 9, 1,
            3, 0, 0, 0, 9, 0,
            3, 0, 1, 0, 9, 1,
            3, 0, 2, 0, 10, 1,
            3, 0, 3, 0, 10, 0,
            3, 0, 4, 2, 7, 1,
            4, 0, 4, 2, 7, 0,
            4, 0, 3, 0, 11, 0,
            4, 0, 2, 1, 10, 1,
            4, 0, 1, 1, 10, 0,
            4, 0, 0, 0, 12, 0,
            4, 0, 1, 0, 13, 1,
            4, 0, 2, 0, 13, 0,
            4, 0, 3, 0, 13, 1,
            4, 0, 4, 0, 14, 1,
            5, 0, 3, 0, 14, 0,
            5, 0, 2, 2, 11, 1,
            5, 0, 1, 2, 11, 0,
            5, 0, 0, 0, 15, 0,
            5, 0, 1, 1, 14, 1,
            5, 0, 2, 1, 14, 0,
            5, 0, 3, 0, 16, 0,
            5, 0, 4, 0, 17, 1,
            6, 0, 3, 0, 17, 0,
            6, 0, 2, 0, 17, 1,
            6, 0, 1, 0, 18, 1,
            6, 0, 0, 0, 18, 0,
            6, 0, 1, 2, 15, 1,
            6, 0, 2, 2, 15, 0,
            6, 0, 3, 0, 19, 0,
            6, 0, 4, 1, 18, 1,
            7, 0, 3, 1, 18, 0,
            7, 0, 2, 0, 20, 0,
            7, 0, 1, 0, 21, 1,
            7, 0, 0, 0, 21, 0,
            7, 0, 1, 0, 21, 1,
            7, 0, 2, 0, 22, 1,
            7, 0, 3, 0, 22, 0,
            7, 0, 4, 2, 19, 1,
            8, 0, 4, 2, 19, 0,
            8, 0, 3, 0, 23, 0,
            8, 0, 2, 1, 22, 1,
            8, 0, 1, 1, 22, 0,
            8, 0, 0, 0, 24, 0,
            8, 0, 1, 0, 25, 1,
            8, 0, 2, 0, 25, 0,
            8, 0, 3, 0, 25, 1,
            8, 0, 4, 0, 26, 1,
            9, 0, 3, 0, 26, 0,
            9, 0, 2, 2, 23, 1,
            9, 0, 1, 2, 23, 0,
            9, 0, 0, 0, 27, 0,
            9, 0, 1, 1, 26, 1,
            9, 0, 2, 1, 26, 0,
            9, 0, 3, 0, 28, 0,
            9, 0, 4, 0, 29, 1,
            10, 0, 3, 0, 29, 0,
            10, 0, 2, 0, 29, 1,
            10, 0, 1, 0, 30, 1,
            10, 0, 0, 0, 30, 0,
            10, 0, 1, 2, 27, 1,
            10, 0, 2, 2, 27, 0,
            10, 0, 3, 0, 31, 0,
            10, 0, 4, 1, 30, 1,
            11, 0, 3, 1, 30, 0,
            11, 0, 2, 4, 24, 0,
            11, 0, 1, 1, 31, 1,
            11, 0, 0, 1, 31, 0,
            11, 0, 1, 1, 31, 1,
            11, 0, 2, 2, 30, 1,
            11, 0, 3, 2, 30, 0,
            11, 0, 4, 2, 31, 1,
            12, 0, 4, 2, 31, 0,
            12, 0, 3, 4, 27, 0,
            12, 0, 2, 3, 30, 1,
            12, 0, 1, 3, 30, 0,
            12, 0, 0, 4, 28, 0,
            12, 0, 1, 3, 31, 1,
            12, 0, 2, 3, 31, 0,
            12, 0, 3, 3, 31, 1,
            12, 0, 4, 4, 30, 1,
            13, 0, 3, 4, 30, 0,
            13, 0, 2, 6, 27, 1,
            13, 0, 1, 6, 27, 0,
            13, 0, 0, 4, 31, 0,
            13, 0, 1, 5, 30, 1,
            13, 0, 2, 5, 30, 0,
            13, 0, 3, 8, 24, 0,
            13, 0, 4, 5, 31, 1,
            14, 0, 3, 5, 31, 0,
            14, 0, 2, 5, 31, 1,
            14, 0, 1, 6, 30, 1,
            14, 0, 0, 6, 30, 0,
            14, 0, 1, 6, 31, 1,
            14, 0, 2, 6, 31, 0,
            14, 0, 3, 8, 27, 0,
            14, 0, 4, 7, 30, 1,
            15, 0, 3, 7, 30, 0,
            15, 0, 2, 8, 28, 0,
            15, 0, 1, 7, 31, 1,
            15, 0, 0, 7, 31, 0,
            15, 0, 1, 7, 31, 1,
            15, 0, 2, 8, 30, 1,
            15, 0, 3, 8, 30, 0,
            15, 0, 4, 10, 27, 1,
            16, 0, 4, 10, 27, 0,
            16, 0, 3, 8, 31, 0,
            16, 0, 2, 9, 30, 1,
            16, 0, 1, 9, 30, 0,
            16, 0, 0, 12, 24, 0,
            16, 0, 1, 9, 31, 1,
            16, 0, 2, 9, 31, 0,
            16, 0, 3, 9, 31, 1,
            16, 0, 4, 10, 30, 1,
            17, 0, 3, 10, 30, 0,
            17, 0, 2, 10, 31, 1,
            17, 0, 1, 10, 31, 0,
            17, 0, 0, 12, 27, 0,
            17, 0, 1, 11, 30, 1,
            17, 0, 2, 11, 30, 0,
            17, 0, 3, 12, 28, 0,
            17, 0, 4, 11, 31, 1,
            18, 0, 3, 11, 31, 0,
            18, 0, 2, 11, 31, 1,
            18, 0, 1, 12, 30, 1,
            18, 0, 0, 12, 30, 0,
            18, 0, 1, 14, 27, 1,
            18, 0, 2, 14, 27, 0,
            18, 0, 3, 12, 31, 0,
            18, 0, 4, 13, 30, 1,
            19, 0, 3, 13, 30, 0,
            19, 0, 2, 16, 24, 0,
            19, 0, 1, 13, 31, 1,
            19, 0, 0, 13, 31, 0,
            19, 0, 1, 13, 31, 1,
            19, 0, 2, 14, 30, 1,
            19, 0, 3, 14, 30, 0,
            19, 0, 4, 14, 31, 1,
            20, 0, 4, 14, 31, 0,
            20, 0, 3, 16, 27, 0,
            20, 0, 2, 15, 30, 1,
            20, 0, 1, 15, 30, 0,
            20, 0, 0, 16, 28, 0,
            20, 0, 1, 15, 31, 1,
            20, 0, 2, 15, 31, 0,
            20, 0, 3, 15, 31, 1,
            20, 0, 4, 16, 30, 1,
            21, 0, 3, 16, 30, 0,
            21, 0, 2, 18, 27, 1,
            21, 0, 1, 18, 27, 0,
            21, 0, 0, 16, 31, 0,
            21, 0, 1, 17, 30, 1,
            21, 0, 2, 17, 30, 0,
            21, 0, 3, 20, 24, 0,
            21, 0, 4, 17, 31, 1,
            22, 0, 3, 17, 31, 0,
            22, 0, 2, 17, 31, 1,
            22, 0, 1, 18, 30, 1,
            22, 0, 0, 18, 30, 0,
            22, 0, 1, 18, 31, 1,
            22, 0, 2, 18, 31, 0,
            22, 0, 3, 20, 27, 0,
            22, 0, 4, 19, 30, 1,
            23, 0, 3, 19, 30, 0,
            23, 0, 2, 20, 28, 0,
            23, 0, 1, 19, 31, 1,
            23, 0, 0, 19, 31, 0,
            23, 0, 1, 19, 31, 1,
            23, 0, 2, 20, 30, 1,
            23, 0, 3, 20, 30, 0,
            23, 0, 4, 22, 27, 1,
            24, 0, 4, 22, 27, 0,
            24, 0, 3, 20, 31, 0,
            24, 0, 2, 21, 30, 1,
            24, 0, 1, 21, 30, 0,
            24, 0, 0, 24, 24, 0,
            24, 0, 1, 21, 31, 1,
            24, 0, 2, 21, 31, 0,
            24, 0, 3, 21, 31, 1,
            24, 0, 4, 22, 30, 1,
            25, 0, 3, 22, 30, 0,
            25, 0, 2, 22, 31, 1,
            25, 0, 1, 22, 31, 0,
            25, 0, 0, 24, 27, 0,
            25, 0, 1, 23, 30, 1,
            25, 0, 2, 23, 30, 0,
            25, 0, 3, 24, 28, 0,
            25, 0, 4, 23, 31, 1,
            26, 0, 3, 23, 31, 0,
            26, 0, 2, 23, 31, 1,
            26, 0, 1, 24, 30, 1,
            26, 0, 0, 24, 30, 0,
            26, 0, 1, 26, 27, 1,
            26, 0, 2, 26, 27, 0,
            26, 0, 3, 24, 31, 0,
            26, 0, 4, 25, 30, 1,
            27, 0, 3, 25, 30, 0,
            27, 0, 2, 28, 24, 0,
            27, 0, 1, 25, 31, 1,
            27, 0, 0, 25, 31, 0,
            27, 0, 1, 25, 31, 1,
            27, 0, 2, 26, 30, 1,
            27, 0, 3, 26, 30, 0,
            27, 0, 4, 26, 31, 1,
            28, 0, 4, 26, 31, 0,
            28, 0, 3, 28, 27, 0,
            28, 0, 2, 27, 30, 1,
            28, 0, 1, 27, 30, 0,
            28, 0, 0, 28, 28, 0,
            28, 0, 1, 27, 31, 1,
            28, 0, 2, 27, 31, 0,
            28, 0, 3, 27, 31, 1,
            28, 0, 4, 28, 30, 1,
            29, 0, 3, 28, 30, 0,
            29, 0, 2, 30, 27, 1,
            29, 0, 1, 30, 27, 0,
            29, 0, 0, 28, 31, 0,
            29, 0, 1, 29, 30, 1,
            29, 0, 2, 29, 30, 0,
            29, 0, 3, 29, 30, 1,
            29, 0, 4, 29, 31, 1,
            30, 0, 3, 29, 31, 0,
            30, 0, 2, 29, 31, 1,
            30, 0, 1, 30, 30, 1,
            30, 0, 0, 30, 30, 0,
            30, 0, 1, 30, 31, 1,
            30, 0, 2, 30, 31, 0,
            30, 0, 3, 30, 31, 1,
            30, 0, 4, 31, 30, 1,
            31, 0, 3, 31, 30, 0,
            31, 0, 2, 31, 30, 1,
            31, 0, 1, 31, 31, 1,
            31, 0, 0, 31, 31, 0,
        };

        //ROS<byte> => new byte[] { ... } is an RVA static readonly
        static ReadOnlySpan<SingleColourLookup> lookup_6_4 => MemoryMarshal.Cast<byte, SingleColourLookup>(_lookup_6_4);
        private static ReadOnlySpan<byte> _lookup_6_4 => new byte[]
        {
            0, 0, 0, 0, 0, 0,
            0, 0, 1, 0, 1, 0,
            0, 0, 2, 0, 2, 0,
            1, 0, 1, 0, 3, 1,
            1, 0, 0, 0, 3, 0,
            1, 0, 1, 0, 4, 0,
            1, 0, 2, 0, 5, 0,
            2, 0, 1, 0, 6, 1,
            2, 0, 0, 0, 6, 0,
            2, 0, 1, 0, 7, 0,
            2, 0, 2, 0, 8, 0,
            3, 0, 1, 0, 9, 1,
            3, 0, 0, 0, 9, 0,
            3, 0, 1, 0, 10, 0,
            3, 0, 2, 0, 11, 0,
            4, 0, 1, 0, 12, 1,
            4, 0, 0, 0, 12, 0,
            4, 0, 1, 0, 13, 0,
            4, 0, 2, 0, 14, 0,
            5, 0, 1, 0, 15, 1,
            5, 0, 0, 0, 15, 0,
            5, 0, 1, 0, 16, 0,
            5, 0, 2, 1, 15, 0,
            6, 0, 1, 0, 17, 0,
            6, 0, 0, 0, 18, 0,
            6, 0, 1, 0, 19, 0,
            6, 0, 2, 3, 14, 0,
            7, 0, 1, 0, 20, 0,
            7, 0, 0, 0, 21, 0,
            7, 0, 1, 0, 22, 0,
            7, 0, 2, 4, 15, 0,
            8, 0, 1, 0, 23, 0,
            8, 0, 0, 0, 24, 0,
            8, 0, 1, 0, 25, 0,
            8, 0, 2, 6, 14, 0,
            9, 0, 1, 0, 26, 0,
            9, 0, 0, 0, 27, 0,
            9, 0, 1, 0, 28, 0,
            9, 0, 2, 7, 15, 0,
            10, 0, 1, 0, 29, 0,
            10, 0, 0, 0, 30, 0,
            10, 0, 1, 0, 31, 0,
            10, 0, 2, 9, 14, 0,
            11, 0, 1, 0, 32, 0,
            11, 0, 0, 0, 33, 0,
            11, 0, 1, 2, 30, 0,
            11, 0, 2, 0, 34, 0,
            12, 0, 1, 0, 35, 0,
            12, 0, 0, 0, 36, 0,
            12, 0, 1, 3, 31, 0,
            12, 0, 2, 0, 37, 0,
            13, 0, 1, 0, 38, 0,
            13, 0, 0, 0, 39, 0,
            13, 0, 1, 5, 30, 0,
            13, 0, 2, 0, 40, 0,
            14, 0, 1, 0, 41, 0,
            14, 0, 0, 0, 42, 0,
            14, 0, 1, 6, 31, 0,
            14, 0, 2, 0, 43, 0,
            15, 0, 1, 0, 44, 0,
            15, 0, 0, 0, 45, 0,
            15, 0, 1, 8, 30, 0,
            15, 0, 2, 0, 46, 0,
            16, 0, 2, 0, 47, 0,
            16, 0, 1, 1, 46, 0,
            16, 0, 0, 0, 48, 0,
            16, 0, 1, 0, 49, 0,
            16, 0, 2, 0, 50, 0,
            17, 0, 1, 2, 47, 0,
            17, 0, 0, 0, 51, 0,
            17, 0, 1, 0, 52, 0,
            17, 0, 2, 0, 53, 0,
            18, 0, 1, 4, 46, 0,
            18, 0, 0, 0, 54, 0,
            18, 0, 1, 0, 55, 0,
            18, 0, 2, 0, 56, 0,
            19, 0, 1, 5, 47, 0,
            19, 0, 0, 0, 57, 0,
            19, 0, 1, 0, 58, 0,
            19, 0, 2, 0, 59, 0,
            20, 0, 1, 7, 46, 0,
            20, 0, 0, 0, 60, 0,
            20, 0, 1, 0, 61, 0,
            20, 0, 2, 0, 62, 0,
            21, 0, 1, 8, 47, 0,
            21, 0, 0, 0, 63, 0,
            21, 0, 1, 1, 62, 0,
            21, 0, 2, 1, 63, 0,
            22, 0, 1, 10, 46, 0,
            22, 0, 0, 2, 62, 0,
            22, 0, 1, 2, 63, 0,
            22, 0, 2, 3, 62, 0,
            23, 0, 1, 11, 47, 0,
            23, 0, 0, 3, 63, 0,
            23, 0, 1, 4, 62, 0,
            23, 0, 2, 4, 63, 0,
            24, 0, 1, 13, 46, 0,
            24, 0, 0, 5, 62, 0,
            24, 0, 1, 5, 63, 0,
            24, 0, 2, 6, 62, 0,
            25, 0, 1, 14, 47, 0,
            25, 0, 0, 6, 63, 0,
            25, 0, 1, 7, 62, 0,
            25, 0, 2, 7, 63, 0,
            26, 0, 1, 16, 45, 0,
            26, 0, 0, 8, 62, 0,
            26, 0, 1, 8, 63, 0,
            26, 0, 2, 9, 62, 0,
            27, 0, 1, 16, 48, 0,
            27, 0, 0, 9, 63, 0,
            27, 0, 1, 10, 62, 0,
            27, 0, 2, 10, 63, 0,
            28, 0, 1, 16, 51, 0,
            28, 0, 0, 11, 62, 0,
            28, 0, 1, 11, 63, 0,
            28, 0, 2, 12, 62, 0,
            29, 0, 1, 16, 54, 0,
            29, 0, 0, 12, 63, 0,
            29, 0, 1, 13, 62, 0,
            29, 0, 2, 13, 63, 0,
            30, 0, 1, 16, 57, 0,
            30, 0, 0, 14, 62, 0,
            30, 0, 1, 14, 63, 0,
            30, 0, 2, 15, 62, 0,
            31, 0, 1, 16, 60, 0,
            31, 0, 0, 15, 63, 0,
            31, 0, 1, 24, 46, 0,
            31, 0, 2, 16, 62, 0,
            32, 0, 2, 16, 63, 0,
            32, 0, 1, 17, 62, 0,
            32, 0, 0, 25, 47, 0,
            32, 0, 1, 17, 63, 0,
            32, 0, 2, 18, 62, 0,
            33, 0, 1, 18, 63, 0,
            33, 0, 0, 27, 46, 0,
            33, 0, 1, 19, 62, 0,
            33, 0, 2, 19, 63, 0,
            34, 0, 1, 20, 62, 0,
            34, 0, 0, 28, 47, 0,
            34, 0, 1, 20, 63, 0,
            34, 0, 2, 21, 62, 0,
            35, 0, 1, 21, 63, 0,
            35, 0, 0, 30, 46, 0,
            35, 0, 1, 22, 62, 0,
            35, 0, 2, 22, 63, 0,
            36, 0, 1, 23, 62, 0,
            36, 0, 0, 31, 47, 0,
            36, 0, 1, 23, 63, 0,
            36, 0, 2, 24, 62, 0,
            37, 0, 1, 24, 63, 0,
            37, 0, 0, 32, 47, 0,
            37, 0, 1, 25, 62, 0,
            37, 0, 2, 25, 63, 0,
            38, 0, 1, 26, 62, 0,
            38, 0, 0, 32, 50, 0,
            38, 0, 1, 26, 63, 0,
            38, 0, 2, 27, 62, 0,
            39, 0, 1, 27, 63, 0,
            39, 0, 0, 32, 53, 0,
            39, 0, 1, 28, 62, 0,
            39, 0, 2, 28, 63, 0,
            40, 0, 1, 29, 62, 0,
            40, 0, 0, 32, 56, 0,
            40, 0, 1, 29, 63, 0,
            40, 0, 2, 30, 62, 0,
            41, 0, 1, 30, 63, 0,
            41, 0, 0, 32, 59, 0,
            41, 0, 1, 31, 62, 0,
            41, 0, 2, 31, 63, 0,
            42, 0, 1, 32, 61, 0,
            42, 0, 0, 32, 62, 0,
            42, 0, 1, 32, 63, 0,
            42, 0, 2, 41, 46, 0,
            43, 0, 1, 33, 62, 0,
            43, 0, 0, 33, 63, 0,
            43, 0, 1, 34, 62, 0,
            43, 0, 2, 42, 47, 0,
            44, 0, 1, 34, 63, 0,
            44, 0, 0, 35, 62, 0,
            44, 0, 1, 35, 63, 0,
            44, 0, 2, 44, 46, 0,
            45, 0, 1, 36, 62, 0,
            45, 0, 0, 36, 63, 0,
            45, 0, 1, 37, 62, 0,
            45, 0, 2, 45, 47, 0,
            46, 0, 1, 37, 63, 0,
            46, 0, 0, 38, 62, 0,
            46, 0, 1, 38, 63, 0,
            46, 0, 2, 47, 46, 0,
            47, 0, 1, 39, 62, 0,
            47, 0, 0, 39, 63, 0,
            47, 0, 1, 40, 62, 0,
            47, 0, 2, 48, 46, 0,
            48, 0, 2, 40, 63, 0,
            48, 0, 1, 41, 62, 0,
            48, 0, 0, 41, 63, 0,
            48, 0, 1, 48, 49, 0,
            48, 0, 2, 42, 62, 0,
            49, 0, 1, 42, 63, 0,
            49, 0, 0, 43, 62, 0,
            49, 0, 1, 48, 52, 0,
            49, 0, 2, 43, 63, 0,
            50, 0, 1, 44, 62, 0,
            50, 0, 0, 44, 63, 0,
            50, 0, 1, 48, 55, 0,
            50, 0, 2, 45, 62, 0,
            51, 0, 1, 45, 63, 0,
            51, 0, 0, 46, 62, 0,
            51, 0, 1, 48, 58, 0,
            51, 0, 2, 46, 63, 0,
            52, 0, 1, 47, 62, 0,
            52, 0, 0, 47, 63, 0,
            52, 0, 1, 48, 61, 0,
            52, 0, 2, 48, 62, 0,
            53, 0, 1, 56, 47, 0,
            53, 0, 0, 48, 63, 0,
            53, 0, 1, 49, 62, 0,
            53, 0, 2, 49, 63, 0,
            54, 0, 1, 58, 46, 0,
            54, 0, 0, 50, 62, 0,
            54, 0, 1, 50, 63, 0,
            54, 0, 2, 51, 62, 0,
            55, 0, 1, 59, 47, 0,
            55, 0, 0, 51, 63, 0,
            55, 0, 1, 52, 62, 0,
            55, 0, 2, 52, 63, 0,
            56, 0, 1, 61, 46, 0,
            56, 0, 0, 53, 62, 0,
            56, 0, 1, 53, 63, 0,
            56, 0, 2, 54, 62, 0,
            57, 0, 1, 62, 47, 0,
            57, 0, 0, 54, 63, 0,
            57, 0, 1, 55, 62, 0,
            57, 0, 2, 55, 63, 0,
            58, 0, 1, 56, 62, 1,
            58, 0, 0, 56, 62, 0,
            58, 0, 1, 56, 63, 0,
            58, 0, 2, 57, 62, 0,
            59, 0, 1, 57, 63, 1,
            59, 0, 0, 57, 63, 0,
            59, 0, 1, 58, 62, 0,
            59, 0, 2, 58, 63, 0,
            60, 0, 1, 59, 62, 1,
            60, 0, 0, 59, 62, 0,
            60, 0, 1, 59, 63, 0,
            60, 0, 2, 60, 62, 0,
            61, 0, 1, 60, 63, 1,
            61, 0, 0, 60, 63, 0,
            61, 0, 1, 61, 62, 0,
            61, 0, 2, 61, 63, 0,
            62, 0, 1, 62, 62, 1,
            62, 0, 0, 62, 62, 0,
            62, 0, 1, 62, 63, 0,
            62, 0, 2, 63, 62, 0,
            63, 0, 1, 63, 63, 1,
            63, 0, 0, 63, 63, 0
        };

    }
}