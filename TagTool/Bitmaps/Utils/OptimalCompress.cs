using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TagTool.Bitmaps.Utils
{
    // Based on the implementation in NVTT. Provides optimal compression for single channel blocks
    public class OptimalCompress
    {
        public static void CompressDXT1G(ReadOnlySpan<RGBAColor> input, Span<byte> output, uint mask)
        {
            var block = new BlockDXT1();
            CompressDXT1G(input, ref block, mask);

            ushort c0 = block.Col0.ToPacked();
            ushort c1 = block.Col1.ToPacked();
            output[0] = (byte)(c0 & 0xFF);
            output[1] = (byte)(c0 >> 8);
            output[2] = (byte)(c1 & 0xFF);
            output[3] = (byte)(c1 >> 8);
            output[4] = (byte)(block.Indices & 0xFF);
            output[5] = (byte)((block.Indices >> 8) & 0xFF);
            output[6] = (byte)((block.Indices >> 16) & 0xFF);
            output[7] = (byte)((block.Indices >> 24) & 0xFF);
        }

        public static void CompressDXT5A(ReadOnlySpan<byte> alphas, Span<byte> output, uint mask)
        {
            var block = new BlockDXT5A();
            CompressDXT5A(alphas, ref block, mask);

            output[0] = block.Alpha0;
            output[1] = block.Alpha1;
            output[2] = (byte)(block.Indices & 0xFF);
            output[3] = (byte)((block.Indices >> 8) & 0xFF);
            output[4] = (byte)((block.Indices >> 16) & 0xFF);
            output[5] = (byte)((block.Indices >> 24) & 0xFF);
            output[6] = (byte)((block.Indices >> 32) & 0xFF);
            output[7] = (byte)((block.Indices >> 40) & 0xFF);
        }

        private static void CompressDXT1G(ReadOnlySpan<RGBAColor> input, ref BlockDXT1 block, uint mask)
        {
            int ming = 63;
            int maxg = 0;

            bool isSingleColor = true;
            byte singleColor = input[0].G;

            // Get min/max green.
            for (int i = 0; i < 16; i++)
            {
                if ((mask & (1u << i)) == 0)
                    continue;

                byte green = (byte)((input[i].G + 1) >> 2); // Scale 8-bit to 6-bit green
                ming = Math.Min(ming, green);
                maxg = Math.Max(maxg, green);

                if (input[i].G != singleColor)
                    isSingleColor = false;
            }

            if (isSingleColor)
            {
                CompressDXT1G(singleColor, ref block);
                return;
            }

            block.Col0.R = 31; // Max 5-bit red (increases luminance range)
            block.Col1.R = 31;
            block.Col0.G = (byte)maxg;
            block.Col1.G = (byte)ming;
            block.Col0.B = 0; // Blue ignored for green optimization
            block.Col1.B = 0;

            int bestError = ComputeGreenError(input, block, mask);
            int bestg0 = maxg;
            int bestg1 = ming;

            // Expand search space a bit.
            const int greenExpand = 4;

            ming = (ming <= greenExpand) ? 0 : (ming - greenExpand);
            maxg = (maxg >= 63 - greenExpand) ? 63 : (maxg + greenExpand);

            for (int g0 = ming + 1; g0 <= maxg; g0++)
            {
                for (int g1 = ming; g1 < g0; g1++)
                {
                    block.Col0.G = (byte)g0;
                    block.Col1.G = (byte)g1;
                    int error = ComputeGreenError(input, block, mask, bestError);

                    if (error < bestError)
                    {
                        bestError = error;
                        bestg0 = g0;
                        bestg1 = g1;
                    }
                }
            }

            block.Col0.G = (byte)bestg0;
            block.Col1.G = (byte)bestg1;

            Debug.Assert(bestg0 == bestg1 || block.IsFourColorMode());

            Span<byte> palette = stackalloc byte[4];
            EvaluateGreenPalette(block, palette);
            block.Indices = ComputeGreenIndices(input, palette, mask);
        }

        private static void CompressDXT1G(byte g, ref BlockDXT1 block)
        {
            block.Col0 = new Color16 { R = 31, G = SingleColorLookup.OMatch6[g, 0], B = 0 };
            block.Col1 = new Color16 { R = 31, G = SingleColorLookup.OMatch6[g, 1], B = 0 };
            block.Indices = 0xaaaaaaaa; // (2 * Col0 + Col1) / 3

            if (block.Col0.ToPacked() < block.Col1.ToPacked())
            {
                (block.Col0, block.Col1) = (block.Col1, block.Col0);
                block.Indices ^= 0x55555555; // (Col0 + 2 * Col1) / 3 
            }
        }

        private static int ComputeGreenError(ReadOnlySpan<RGBAColor> rgba, in BlockDXT1 block, uint mask, int bestError = int.MaxValue)
        {
            // Create palette by scaling 6-bit green to 8-bit
            Span<byte> palette = stackalloc byte[4];
            EvaluateGreenPalette(in block, palette);

            int totalError = 0;
            for (int i = 0; i < 16; i++)
            {
                if ((mask & (1u << i)) == 0)
                    continue;

                int green = rgba[i].G;

                int error = GreenDistance(green, palette[0]);
                error = Math.Min(error, GreenDistance(green, palette[1]));
                error = Math.Min(error, GreenDistance(green, palette[2]));
                error = Math.Min(error, GreenDistance(green, palette[3]));

                totalError += error;

                if (totalError > bestError)
                {
                    // Early out
                    return totalError;
                }
            }

            return totalError;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EvaluateGreenPalette(in BlockDXT1 block, Span<byte> palette)
        {
            palette[0] = (byte)((block.Col0.G << 2) | (block.Col0.G >> 4)); // Approximate 6-bit to 8-bit
            palette[1] = (byte)((block.Col1.G << 2) | (block.Col1.G >> 4));
            palette[2] = (byte)((2 * palette[0] + palette[1] + 1) / 3); // Interpolated color
            palette[3] = (byte)((2 * palette[1] + palette[0] + 1) / 3); // Interpolated color
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GreenDistance(int g0, int g1)
        {
            int d = g0 - g1;
            return d * d; // Squared difference
        }

        private static uint ComputeGreenIndices(ReadOnlySpan<RGBAColor> rgba, ReadOnlySpan<byte> palette, uint mask)
        {
            uint indices = 0;
            for (int i = 0; i < 16; i++)
            {
                if ((mask & (1u << i)) == 0)
                    continue;

                byte pixelGreen = rgba[i].G;
                int minDiff = int.MaxValue;
                int bestIndex = 0;

                for (int j = 0; j < 4; j++)
                {
                    int diff = GreenDistance(pixelGreen, palette[j]);
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        bestIndex = j;
                    }
                }

                // ToPacked the index into the 32-bit indices field (2 bits per pixel)
                indices |= (uint)(bestIndex << (2 * i));
            }
            return indices;
        }

        private static void CompressDXT5A(ReadOnlySpan<byte> alphas, ref BlockDXT5A block, uint mask)
        {
            byte minAlpha = 255;
            byte maxAlpha = 0;
            byte minAlphaNo01 = 255;
            byte maxAlphaNo01 = 0;

            // Get min/max alpha, including and excluding 0 and 255.
            for (int i = 0; i < 16; i++)
            {
                if ((mask & (1u << i)) == 0)
                    continue;

                byte alpha = alphas[i];
                minAlpha = Math.Min(minAlpha, alpha);
                maxAlpha = Math.Max(maxAlpha, alpha);

                if (alpha != 0 && alpha != 255)
                {
                    minAlphaNo01 = Math.Min(minAlphaNo01, alpha);
                    maxAlphaNo01 = Math.Max(maxAlphaNo01, alpha);
                }
            }

            if (maxAlpha - minAlpha < 8)
            {
                block.Alpha0 = maxAlpha;
                block.Alpha1 = minAlpha;
                Debug.Assert(ComputeAlphaError(alphas, block, mask) == 0, "Expected zero error for small alpha range.");
            }
            else if (maxAlphaNo01 - minAlphaNo01 < 6)
            {
                block.Alpha0 = minAlphaNo01;
                block.Alpha1 = maxAlphaNo01;
                Debug.Assert(ComputeAlphaError(alphas, block, mask) == 0, "Expected zero error for small alpha range excluding 0 and 255.");
            }
            else
            {
                block.Alpha0 = maxAlpha;
                block.Alpha1 = minAlpha;

                float bestError = ComputeAlphaError(alphas, block, mask);
                int bestAlpha0 = maxAlpha;
                int bestAlpha1 = minAlpha;

                // Expand search space for eight-alpha mode (alpha0 > alpha1)
                const int alphaExpand = 8;
                minAlpha = (minAlpha <= alphaExpand) ? (byte)0 : (byte)(minAlpha - alphaExpand);
                maxAlpha = (maxAlpha >= 255 - alphaExpand) ? (byte)255 : (byte)(maxAlpha + alphaExpand);

                for (int a0 = minAlpha + 9; a0 <= maxAlpha; a0++)
                {
                    for (int a1 = minAlpha; a1 < a0 - 8; a1++)
                    {
                        Debug.Assert(a0 - a1 > 8, "Expected alpha0 - alpha1 > 8 for eight-alpha mode.");

                        block.Alpha0 = (byte)a0;
                        block.Alpha1 = (byte)a1;
                        float error = ComputeAlphaError(alphas, block, mask, bestError);

                        if (error < bestError)
                        {
                            bestError = error;
                            bestAlpha0 = a0;
                            bestAlpha1 = a1;
                        }
                    }
                }

                // Try six-alpha mode (alpha0 <= alpha1)
                const int alphaExpandNo01 = 6;
                minAlphaNo01 = (minAlphaNo01 <= alphaExpandNo01) ? (byte)0 : (byte)(minAlphaNo01 - alphaExpandNo01);
                maxAlphaNo01 = (maxAlphaNo01 >= 255 - alphaExpandNo01) ? (byte)255 : (byte)(maxAlphaNo01 + alphaExpandNo01);

                for (int a0 = minAlphaNo01 + 9; a0 <= maxAlphaNo01; a0++)
                {
                    for (int a1 = minAlphaNo01; a1 < a0 - 8; a1++)
                    {
                        Debug.Assert(a0 - a1 > 8, "Expected alpha0 - alpha1 > 8 for six-alpha mode.");

                        block.Alpha0 = (byte)a1; // Note: a0 is alpha1, a1 is alpha0 in six-alpha mode
                        block.Alpha1 = (byte)a0;
                        float error = ComputeAlphaError(alphas, block, mask, bestError);

                        if (error < bestError)
                        {
                            bestError = error;
                            bestAlpha0 = a1;
                            bestAlpha1 = a0;
                        }
                    }
                }

                block.Alpha0 = (byte)bestAlpha0;
                block.Alpha1 = (byte)bestAlpha1;
            }

            Span<byte> palette = stackalloc byte[8];
            block.EvaluatePalette(palette);
            block.Indices = ComputeAlphaIndices(alphas, palette, mask);
        }

        private static float ComputeAlphaError(ReadOnlySpan<byte> alphas, in BlockDXT5A block, uint mask, float bestError = float.MaxValue)
        {
            Span<byte> palette = stackalloc byte[8];
            block.EvaluatePalette(palette);

            float totalError = 0;
            for (int i = 0; i < 16; i++)
            {
                if ((mask & (1u << i)) == 0)
                    continue;

                int alpha = alphas[i];

                int minDist = int.MaxValue;
                for (int j = 0; j < 8; j++)
                {
                    int dist = AlphaDistance(alpha, palette[j]);
                    minDist = Math.Min(dist, minDist);
                }

                totalError += minDist;

                if (totalError > bestError)
                {
                    // early out
                    return totalError;
                }
            }

            return totalError;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int AlphaDistance(int a0, int a1)
        {
            int d = a0 - a1;
            return d * d; // Squared difference
        }

        private static ulong ComputeAlphaIndices(ReadOnlySpan<byte> alphas, Span<byte> palette, uint mask)
        {
            ulong indices = 0;
            for (int i = 0; i < 16; i++)
            {
                if ((mask & (1u << i)) == 0)
                    continue;

                byte pixelAlpha = alphas[i];
                int minDiff = int.MaxValue;
                int bestIndex = 0;

                for (int j = 0; j < 8; j++)
                {
                    int diff = Math.Abs(pixelAlpha - palette[j]);
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        bestIndex = j;
                    }
                }

                // ToPacked the 3-bit index into the 48-bit indices field
                indices |= (ulong)bestIndex << (int)(3 * i);
            }
            return indices;
        }

        struct BlockDXT1
        {
            public Color16 Col0;
            public Color16 Col1;
            public uint Indices;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool IsFourColorMode()
            {
                // Four-color mode if col0 > col1 (comparing as 16-bit RGB565 values)
                ushort c0 = (ushort)((Col0.R << 11) | (Col0.G << 5) | Col0.B);
                ushort c1 = (ushort)((Col1.R << 11) | (Col1.G << 5) | Col1.B);
                return c0 > c1;
            }

            public void EvaluatePalette(RGBAColor[] palette, bool useTargetDecoder)
            {
                if (palette.Length < 4)
                    throw new ArgumentException("Palette must have at least 4 elements.");

                // Convert endpoint colors to 8-bit
                palette[0] = Col0.ToColor32();
                palette[1] = Col1.ToColor32();

                if (IsFourColorMode())
                {
                    // Four-color mode: interpolate between col0 and col1
                    palette[2] = new RGBAColor
                    {
                        R = (byte)((2 * palette[0].R + palette[1].R + 1) / 3),
                        G = (byte)((2 * palette[0].G + palette[1].G + 1) / 3),
                        B = (byte)((2 * palette[0].B + palette[1].B + 1) / 3),
                        A = 255
                    };
                    palette[3] = new RGBAColor
                    {
                        R = (byte)((palette[0].R + 2 * palette[1].R + 1) / 3),
                        G = (byte)((palette[0].G + 2 * palette[1].G + 1) / 3),
                        B = (byte)((palette[0].B + 2 * palette[1].B + 1) / 3),
                        A = 255
                    };
                }
                else
                {
                    // Three-color mode: third color is average, fourth is transparent (not used here)
                    palette[2] = new RGBAColor
                    {
                        R = (byte)((palette[0].R + palette[1].R) / 2),
                        G = (byte)((palette[0].G + palette[1].G) / 2),
                        B = (byte)((palette[0].B + palette[1].B) / 2),
                        A = 255
                    };
                    palette[3] = new RGBAColor { R = 0, G = 0, B = 0, A = 0 }; // Transparent (not used in green-only)
                }
            }
        }

        struct BlockDXT5A
        {
            public byte Alpha0;
            public byte Alpha1;
            public ulong Indices; // 48 bits for 16 3-bit indices

            public bool IsEightAlphaMode()
            {
                return Alpha0 > Alpha1;
            }

            public void EvaluatePalette(Span<byte> palette)
            {
                if (palette.Length < 8)
                    throw new ArgumentException("Palette must have at least 8 elements.");

                palette[0] = Alpha0;
                palette[1] = Alpha1;

                if (IsEightAlphaMode())
                {
                    // Eight-alpha mode: interpolate between alpha0 and alpha1
                    for (int i = 0; i < 6; i++)
                    {
                        int weight0 = 6 - i;
                        int weight1 = i + 1;
                        palette[i + 2] = (byte)((weight0 * Alpha0 + weight1 * Alpha1 + 3) / 7); // Round correctly
                    }
                }
                else
                {
                    // Six-alpha mode: interpolate two values, plus 0 and 255
                    palette[2] = (byte)((4 * Alpha0 + 1 * Alpha1 + 2) / 5);
                    palette[3] = (byte)((3 * Alpha0 + 2 * Alpha1 + 2) / 5);
                    palette[4] = (byte)((2 * Alpha0 + 3 * Alpha1 + 2) / 5);
                    palette[5] = (byte)((1 * Alpha0 + 4 * Alpha1 + 2) / 5);
                    palette[6] = 0; // Fully transparent
                    palette[7] = 255; // Fully opaque
                }
            }
        }

        struct Color16(byte r, byte g, byte b)
        {
            public byte R = r;
            public byte G = g;
            public byte B = b;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RGBAColor ToColor32() => new(
                (byte)((R << 3) | (R >> 2)),
                (byte)((G << 2) | (G >> 4)),
                (byte)((B << 3) | (B >> 2)),
                255);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ushort ToPacked() => (ushort)((R << 11) | (G << 5) | B);

            public override string ToString() => $"({R}, {G}, {B})";
        }
    }
}
