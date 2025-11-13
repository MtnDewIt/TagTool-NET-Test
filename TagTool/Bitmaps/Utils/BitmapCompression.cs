using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TagTool.Bitmaps.Utils;
using TagTool.Cache;

namespace TagTool.Bitmaps
{
    public enum CompressionQuality
    {
        Default,
        Low,
        High,
    }

    public static class BitmapCompression
    {
        public static byte[] Decompress(byte[] compressedData, int width, int height, BitmapFormat format, CacheVersion version, CachePlatform platform)
        {
            return Decompress(compressedData, width, height, GetBlockDecompresor(format, version, platform));
        }

        public static byte[] Compress(byte[] data, int width, int height, BitmapFormat format, CompressionQuality quality)
        {
            Debug.Assert((width * height * 4) == data.Length);

            switch (format)
            {
                case BitmapFormat.Dxn: // ATI2
                    return Compress(SquishLib.SquishFlags.kDxn, data, width, height);
                case BitmapFormat.Dxt1:
                    return Compress(SquishLib.SquishFlags.kDxt1, data, width, height);
                case BitmapFormat.Dxt3:
                    return Compress(SquishLib.SquishFlags.kDxt3, data, width, height);
                case BitmapFormat.Dxt5:
                    return Compress(SquishLib.SquishFlags.kDxt5, data, width, height);
                case BitmapFormat.Dxt5nm:
                    return CompressDXT5nm(data, width, height, quality);
                default:
                    throw new NotSupportedException($"Unsupported bitmap format {format}");
            }
        }

        private static byte[] Compress(SquishLib.SquishFlags flags, byte[] data, int width, int height)
        {
            flags |= SquishLib.SquishFlags.kColourIterativeClusterFit | SquishLib.SquishFlags.kSourceBgra;
            return new SquishLib.Compressor(flags, data, width, height).CompressTexture();
        }

        private static unsafe byte[] CompressDXT5nm(byte[] data, int width, int height, CompressionQuality quality)
        {
            if (quality < CompressionQuality.High)
            {
                byte[] buffer = new byte[data.Length];
                fixed (byte* src = data)
                fixed (byte* dest = buffer)
                {
                    for (int i = 0; i < data.Length; i += 4)
                    {
                        byte g = src[i + 1];
                        byte r = src[i + 2];
                        dest[i + 0] = g;
                        dest[i + 1] = g;
                        dest[i + 2] = g;
                        dest[i + 3] = r;
                    }
                }
                return Compress(SquishLib.SquishFlags.kDxt5, buffer, width, height);
            }

            int blockCountX = (width + 3) >> 2;
            int blockCountY = (height + 3) >> 2;
            int blockCount = blockCountX * blockCountY;

            byte[] output = new byte[blockCount * 16];

            Parallel.For(0, blockCount, blockIndex =>
            {
                Span<RGBAColor> colors = stackalloc RGBAColor[16];
                Span<byte> alphas = stackalloc byte[16];

                int bx = blockIndex % blockCountX;
                int by = blockIndex / blockCountX;

                int x = bx * 4;
                int y = by * 4;

                uint mask = 0;
                for (int py = 0; py < 4; py++)
                {
                    for (int px = 0; px < 4; px++)
                    {
                        int destIndex = py * 4 + px;
                        if (x + px < width && y + py < height)
                        {
                            int srcIndex = (x + px + width * (y + py)) * 4;
                            byte b = data[srcIndex + 0];
                            byte g = data[srcIndex + 1];
                            byte r = data[srcIndex + 2];

                            alphas[destIndex] = r;
                            colors[destIndex] = new RGBAColor(g, g, g, 255);
                            mask |= (1u << destIndex);
                        }
                    }
                }

                int blockOffset = (by * blockCountX + bx) * 16;
                OptimalCompress.CompressDXT1G(colors, output.AsSpan(blockOffset + 8, 8), mask);
                OptimalCompress.CompressDXT5A(alphas, output.AsSpan(blockOffset, 8), mask);
            });

            return output;
        }

        private delegate void BlockDecompressor(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData);

        private static BlockDecompressor GetBlockDecompresor(BitmapFormat format, CacheVersion version, CachePlatform platform)
        {
            switch (format)
            {
                case BitmapFormat.Dxt1: return DecompressDXT1;
                case BitmapFormat.Dxt3: return DecompressDXT3;
                case BitmapFormat.Dxt3a: return DecompressDXT3a;
                case BitmapFormat.Dxt3aMono: return DecompressDXT3aMono;
                case BitmapFormat.Dxt3aAlpha: return DecompressDXT3aAlpha;
                case BitmapFormat.Dxt3A1111: return DecompressDXT3a111;
                case BitmapFormat.Dxt5: return DecompressDXT5;
                case BitmapFormat.Dxt5a: return DecompressDXT5a;
                case BitmapFormat.Dxt5aMono: return DecompressDXT5aMono;
                case BitmapFormat.Dxt5aAlpha: return DecompressDXT5aAlpha;
                case BitmapFormat.Dxt5nm: return DecompressDXT5nm;
                case BitmapFormat.Dxn:
                    // not ideal, but i'm not sure how else to handle it currently
                    if (platform == CachePlatform.MCC)
                        return DecompressDXNSNorm;
                    else if (CacheVersionDetection.IsInGen(CacheGeneration.HaloOnline, version))
                        return DecompressATI2;
                    else
                        return DecompressDXNUNorm;
                case BitmapFormat.DxnMonoAlpha: return DecompressDXNMonoAlpha;
                case BitmapFormat.Ctx1: return DecompressCTX1;
                default:
                    throw new NotSupportedException($"Unsupported bitmap format {format}");
            }
        }

        private static byte[] Decompress(byte[] compressedData, int width, int height, BlockDecompressor decompressBlock)
        {
            int blockCountX = (width + 3) / 4;
            int blockCountY = (height + 3) / 4;
            int blockCount = blockCountX * blockCountY;

            byte[] decompressedData = new byte[width * height * 4];

            Parallel.For(0, blockCount, blockIndex =>
            {
                int x = blockIndex % blockCountX;
                int y = blockIndex / blockCountX;
                decompressBlock(compressedData, x, y, width, height, decompressedData);
            });

            return decompressedData;
        }

        private unsafe static void DecompressDXT1(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 8;

            RGBAColor* colors = stackalloc RGBAColor[4];
            uint colorIndices = UnpackColorBlock(compressedData, blockIndex, colors, isDxt1: true);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    int colorIndex = (int)(colorIndices >> (2 * (4 * j + i))) & 0x3;

                    decompressedData[pixelIndex + 0] = colors[colorIndex].B;
                    decompressedData[pixelIndex + 1] = colors[colorIndex].G;
                    decompressedData[pixelIndex + 2] = colors[colorIndex].R;
                    decompressedData[pixelIndex + 3] = colors[colorIndex].A;
                }
            }
        }

        private unsafe static void DecompressDXT3(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 16;
            ulong alphaData = BitConverter.ToUInt64(compressedData, blockIndex);

            RGBAColor* colors = stackalloc RGBAColor[4];
            uint colorIndices = UnpackColorBlock(compressedData, blockIndex + 8, colors);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    int colorIndex = (int)(colorIndices >> (2 * (4 * j + i))) & 0x3;
                    byte alpha = (byte)((alphaData >> (4 * (4 * j + i)) & 0xF) * 17);

                    decompressedData[pixelIndex + 0] = colors[colorIndex].B;
                    decompressedData[pixelIndex + 1] = colors[colorIndex].G;
                    decompressedData[pixelIndex + 2] = colors[colorIndex].R;
                    decompressedData[pixelIndex + 3] = alpha;
                }
            }
        }

        private unsafe static void DecompressDXT3a(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData) =>
            DecompressDXT3aX(compressedData, blockX, blockY, width, height, decompressedData, 0xFF, 0xFF, 0xFF, 0xFF);

        private unsafe static void DecompressDXT3aMono(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData) =>
            DecompressDXT3aX(compressedData, blockX, blockY, width, height, decompressedData, 0xFF, 0xFF, 0xFF, 0);

        private unsafe static void DecompressDXT3aAlpha(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData) =>
            DecompressDXT3aX(compressedData, blockX, blockY, width, height, decompressedData, 0, 0, 0, 0xFF);

        private unsafe static void DecompressDXT3aX(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData, byte rMask, byte gMask, byte bMask, byte aMask)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 8;
            ulong alphaData = BitConverter.ToUInt64(compressedData, blockIndex);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    byte alpha = (byte)(((alphaData >> (4 * (4 * j + i))) & 0xF) * 17);

                    decompressedData[pixelIndex + 0] = (byte)(alpha & rMask);
                    decompressedData[pixelIndex + 1] = (byte)(alpha & gMask);
                    decompressedData[pixelIndex + 2] = (byte)(alpha & bMask);
                    decompressedData[pixelIndex + 3] = (byte)(alpha & aMask);
                }
            }
        }

        private unsafe static void DecompressDXT3a111(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 8;
            ulong alphaData = BitConverter.ToUInt64(compressedData, blockIndex);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    byte alpha = (byte)((alphaData >> (4 * (4 * j + i))) & 0xF);

                    decompressedData[pixelIndex + 0] = (byte)(((alpha >> 0) & 0x1) * 255);
                    decompressedData[pixelIndex + 1] = (byte)(((alpha >> 1) & 0x1) * 255);
                    decompressedData[pixelIndex + 2] = (byte)(((alpha >> 2) & 0x1) * 255);
                    decompressedData[pixelIndex + 3] = (byte)(((alpha >> 3) & 0x1) * 255);
                }
            }
        }

        private unsafe static void DecompressDXT5(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 16;

            byte* alphas = stackalloc byte[8];
            ulong alphaIndices = UnpackDXT5AlphaBlock(alphas, compressedData, blockIndex);
            RGBAColor* colors = stackalloc RGBAColor[4];
            uint colorIndices = UnpackColorBlock(compressedData, blockIndex + 8, colors);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    int colorIndex = (int)(colorIndices >> (2 * (4 * j + i))) & 0x3;
                    int alphaIndex = (int)(alphaIndices >> (3 * (4 * j + i))) & 0x7;

                    decompressedData[pixelIndex + 0] = colors[colorIndex].B;
                    decompressedData[pixelIndex + 1] = colors[colorIndex].G;
                    decompressedData[pixelIndex + 2] = colors[colorIndex].R;
                    decompressedData[pixelIndex + 3] = alphas[alphaIndex];
                }
            }
        }

        private unsafe static void DecompressDXT5a(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData) =>
           DecompressDXT5aX(compressedData, blockX, blockY, width, height, decompressedData, 0xFF, 0xFF, 0xFF, 0xFF);

        private unsafe static void DecompressDXT5aMono(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData) =>
             DecompressDXT5aX(compressedData, blockX, blockY, width, height, decompressedData, 0xFF, 0xFF, 0xFF, 0);

        private unsafe static void DecompressDXT5aAlpha(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData) =>
            DecompressDXT5aX(compressedData, blockX, blockY, width, height, decompressedData, 0, 0, 0, 0xFF);

        private static unsafe void DecompressDXT5aX(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData, byte rMask, byte gMAsk, byte bMask, byte aMask)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 8;

            byte* alphaValues = stackalloc byte[8];
            ulong alphaIndices = UnpackDXT5AlphaBlock(alphaValues, compressedData, blockIndex);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);

                    int alphaIndex = (int)(alphaIndices >> (3 * (4 * j + i))) & 0x07;
                    byte alpha = alphaValues[alphaIndex];

                    decompressedData[pixelIndex + 0] = (byte)(alpha & rMask);
                    decompressedData[pixelIndex + 1] = (byte)(alpha & gMAsk);
                    decompressedData[pixelIndex + 2] = (byte)(alpha & bMask);
                    decompressedData[pixelIndex + 3] = (byte)(alpha & aMask);
                }
            }
        }

        private static unsafe void DecompressDXNSNorm(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
            => DecompressDXN(compressedData, blockX, blockY, width, height, decompressedData, signed: true, swapXY: false);

        private static unsafe void DecompressDXNUNorm(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
            => DecompressDXN(compressedData, blockX, blockY, width, height, decompressedData, signed: false, swapXY: false);

        private static unsafe void DecompressATI2(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
            => DecompressDXN(compressedData, blockX, blockY, width, height, decompressedData, signed: false, swapXY: true);


        private unsafe static void DecompressDXT5nm(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 16;

            byte* alphas = stackalloc byte[8];
            ulong alphaIndices = UnpackDXT5AlphaBlock(alphas, compressedData, blockIndex);
            RGBAColor* colors = stackalloc RGBAColor[4];
            uint colorIndices = UnpackColorBlock(compressedData, blockIndex + 8, colors);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    int colorIndex = (int)(colorIndices >> (2 * (4 * j + i))) & 0x3;
                    int alphaIndex = (int)(alphaIndices >> (3 * (4 * j + i))) & 0x7;

                    byte r = alphas[alphaIndex];
                    byte g = colors[colorIndex].G;

                    decompressedData[pixelIndex + 0] = BitmapUtils.CalculateNormalZ(r, g);
                    decompressedData[pixelIndex + 1] = g;
                    decompressedData[pixelIndex + 2] = r;
                    decompressedData[pixelIndex + 3] = 255;
                }
            }
        }

        private static unsafe void DecompressDXN(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData, bool signed, bool swapXY)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 16;

            byte* redValues = stackalloc byte[8];
            byte* greenValues = stackalloc byte[8];
            ulong redIndices = UnpackDXT5AlphaBlock(redValues, compressedData, blockIndex, signed);
            ulong greenIndices = UnpackDXT5AlphaBlock(greenValues, compressedData, blockIndex + 8, signed);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    int redIndex = (int)(redIndices >> (3 * (4 * j + i))) & 0x07;
                    int greenIndex = (int)(greenIndices >> (3 * (4 * j + i))) & 0x07;

                    byte r = redValues[redIndex];
                    byte g = greenValues[greenIndex];
                    if (swapXY) (r, g) = (g, r);

                    decompressedData[pixelIndex + 0] = BitmapUtils.CalculateNormalZ(r, g); // Blue channel is 0 for BC5
                    decompressedData[pixelIndex + 1] = g;
                    decompressedData[pixelIndex + 2] = r;
                    decompressedData[pixelIndex + 3] = 255; // Alpha channel is 255 (opaque)
                }
            }
        }

        private static unsafe void DecompressDXNMonoAlpha(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 16;

            byte* redValues = stackalloc byte[8];
            byte* greenValues = stackalloc byte[8];
            ulong redIndices = UnpackDXT5AlphaBlock(redValues, compressedData, blockIndex, signed: false);
            ulong greenIndices = UnpackDXT5AlphaBlock(greenValues, compressedData, blockIndex + 8, signed: false);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    int redIndex = (int)(redIndices >> (3 * (4 * j + i))) & 0x07;
                    int greenIndex = (int)(greenIndices >> (3 * (4 * j + i))) & 0x07;

                    byte r = redValues[redIndex];
                    byte g = greenValues[greenIndex];

                    decompressedData[pixelIndex + 0] = r;
                    decompressedData[pixelIndex + 1] = r;
                    decompressedData[pixelIndex + 2] = r;
                    decompressedData[pixelIndex + 3] = g;
                }
            }
        }

        private unsafe static void DecompressCTX1(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 8;

            // same as DXT1 (no alpha) except uses an 8:8 color format instead of a 5:6:5

            RGBAColor* vectors = stackalloc RGBAColor[4];
            vectors[0] = new RGBAColor(compressedData[blockIndex + 1], compressedData[blockIndex + 0], 0, 255);
            vectors[1] = new RGBAColor(compressedData[blockIndex + 3], compressedData[blockIndex + 2], 0, 255);
            vectors[2] = ColorLerp(vectors[0], vectors[1], 2, 1, 1);
            vectors[3] = ColorLerp(vectors[0], vectors[1], 1, 2, 1);

            CalculateNormalZ(&vectors[0]);
            CalculateNormalZ(&vectors[1]);
            CalculateNormalZ(&vectors[2]);
            CalculateNormalZ(&vectors[3]);

            uint vectorIndices = BitConverter.ToUInt32(compressedData, blockIndex + 4);

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int pixelX = blockX * 4 + i;
                    int pixelY = blockY * 4 + j;
                    if (pixelX >= width || pixelY >= height) continue;

                    int pixelIndex = 4 * (pixelY * width + pixelX);
                    int vertexIndex = (int)(vectorIndices >> (2 * (4 * j + i))) & 0x3;

                    RGBAColor* vector = &vectors[vertexIndex];
                    decompressedData[pixelIndex + 0] = vector->B;
                    decompressedData[pixelIndex + 1] = vector->G;
                    decompressedData[pixelIndex + 2] = vector->R;
                    decompressedData[pixelIndex + 3] = vector->A;
                }
            }
        }

        private static unsafe uint UnpackColorBlock(byte[] compressedData, int blockIndex, RGBAColor* colors, bool isDxt1 = false)
        {
            ushort color0 = BitConverter.ToUInt16(compressedData, blockIndex);
            ushort color1 = BitConverter.ToUInt16(compressedData, blockIndex + 2);
            uint colorIndices = BitConverter.ToUInt32(compressedData, blockIndex + 4);

            colors[0] = UnpackColor565(color0);
            colors[1] = UnpackColor565(color1);

            if (color0 > color1 || !isDxt1)
            {
                colors[2] = ColorLerp(colors[0], colors[1], 2, 1, 1);
                colors[3] = ColorLerp(colors[0], colors[1], 1, 2, 1);
            }
            else
            {
                colors[2] = ColorLerp(colors[0], colors[1], 1, 1, 0); // power of 2 doesn't use a bias
                colors[3] = RGBAColor.Transparent;
            }

            return colorIndices;
        }

        private static unsafe ulong UnpackDXT5AlphaBlock(byte* alphas, byte[] compressedData, int blockIndex, bool signed = false)
        {
            ulong indices = BitConverter.ToUInt64(compressedData, blockIndex) >> 16;

            byte alpha0 = compressedData[blockIndex];
            byte alpha1 = compressedData[blockIndex + 1];

            if (signed)
            {
                alpha0 += 128;
                alpha1 += 128;
            }

            alphas[0] = alpha0;
            alphas[1] = alpha1;

            if (alpha0 > alpha1)
            {
                alphas[2] = Lerp(alpha0, alpha1, 6, 1, 3);
                alphas[3] = Lerp(alpha0, alpha1, 5, 2, 3);
                alphas[4] = Lerp(alpha0, alpha1, 4, 3, 3);
                alphas[5] = Lerp(alpha0, alpha1, 3, 4, 3);
                alphas[6] = Lerp(alpha0, alpha1, 2, 5, 3);
                alphas[7] = Lerp(alpha0, alpha1, 1, 6, 3);
            }
            else
            {

                alphas[2] = Lerp(alpha0, alpha1, 4, 1, 2);
                alphas[3] = Lerp(alpha0, alpha1, 3, 2, 2);
                alphas[4] = Lerp(alpha0, alpha1, 2, 3, 2);
                alphas[5] = Lerp(alpha0, alpha1, 1, 4, 2);
                alphas[6] = 0;
                alphas[7] = 255;
            }

            return indices;
        }

        private static RGBAColor UnpackColor565(ushort color)
        {
            byte r = (byte)((color >> 11) & 0x1F);
            byte g = (byte)((color >> 5) & 0x3F);
            byte b = (byte)(color & 0x1F);

            // Scale to 8-bit
            r = (byte)((r << 3) | (r >> 2));
            g = (byte)((g << 2) | (g >> 4));
            b = (byte)((b << 3) | (b >> 2));

            return new RGBAColor(r, g, b, 255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static RGBAColor ColorLerp(RGBAColor c0, RGBAColor c1, int w0, int w1, int bias)
        {
            return new RGBAColor(
                Lerp(c0.R, c1.R, w0, w1, bias),
                Lerp(c0.G, c1.G, w0, w1, bias),
                Lerp(c0.B, c1.B, w0, w1, bias), 255);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte Lerp(byte a, byte b, int w0, int w1, int bias)
        {
            return (byte)((a * w0 + b * w1 + bias) / (w0 + w1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe void CalculateNormalZ(RGBAColor* vector)
        {
            vector->B = BitmapUtils.CalculateNormalZ(vector->R, vector->G);
            vector->A = 255;
        }
    }
}
