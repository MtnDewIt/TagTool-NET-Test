using System;
using System.Threading.Tasks;
using TagTool.Cache;

namespace TagTool.Bitmaps
{
    public static class BitmapCompression
    {
        private delegate void BlockDecompressor(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData);

        public static byte[] Decompress(byte[] compressedData, int width, int height, BitmapFormat format, CacheVersion version, CachePlatform platform)
        {
            return Decompress(compressedData, width, height, GetBlockDecompresor(format, version, platform));
        }

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
            byte[] decompressedData = new byte[width * height * 4];

            Parallel.For(0, blockCountY, y =>
            {
                for (int x = 0; x < blockCountX; x++)
                    decompressBlock(compressedData, x, y, width, height, decompressedData);
            });

            return decompressedData;
        }

        private unsafe static void DecompressDXT1(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 8;

            RGBAColor* colors = stackalloc RGBAColor[4];
            uint colorIndices = UnpackColorBlock(compressedData, blockIndex, colors, hasAlpha: true);

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
            uint colorIndices = UnpackColorBlock(compressedData, blockIndex + 8, colors, hasAlpha: false);

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
            uint colorIndices = UnpackColorBlock(compressedData, blockIndex + 8, colors, hasAlpha: false);

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

                    decompressedData[pixelIndex + 0] = CalculateNormalZ(r, g); // Blue channel is 0 for BC5
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

        public unsafe static void DecompressCTX1(byte[] compressedData, int blockX, int blockY, int width, int height, byte[] decompressedData)
        {
            int blockIndex = (blockY * ((width + 3) / 4) + blockX) * 8;

            // same as DXT1 (no alpha) except uses an 8:8 color format instead of a 5:6:5

            RGBAColor* vectors = stackalloc RGBAColor[4];
            vectors[0] = new RGBAColor(compressedData[blockIndex + 1], compressedData[blockIndex + 0], 0, 255);
            vectors[1] = new RGBAColor(compressedData[blockIndex + 3], compressedData[blockIndex + 2], 0, 255);
            vectors[2] = ColorLerp(vectors[0], vectors[1], 2, 1);
            vectors[3] = ColorLerp(vectors[0], vectors[1], 1, 2);

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

        private static unsafe uint UnpackColorBlock(byte[] compressedData, int blockIndex, RGBAColor* colors, bool hasAlpha)
        {
            ushort color0 = BitConverter.ToUInt16(compressedData, blockIndex);
            ushort color1 = BitConverter.ToUInt16(compressedData, blockIndex + 2);
            uint colorIndices = BitConverter.ToUInt32(compressedData, blockIndex + 4);

            colors[0] = UnpackColor565(color0);
            colors[1] = UnpackColor565(color1);

            if (color0 > color1 || !hasAlpha)
            {
                colors[2] = ColorLerp(colors[0], colors[1], 2, 1);
                colors[3] = ColorLerp(colors[0], colors[1], 1, 2);
            }
            else
            {
                colors[2] = ColorLerp(colors[0], colors[1], 1, 1);
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
                alpha0 = (byte)((((sbyte)alpha0 + 127) * 255) / 254);
                alpha1 = (byte)((((sbyte)alpha1 + 127) * 255) / 254);
            }

            alphas[0] = alpha0;
            alphas[1] = alpha1;

            if (alpha0 > alpha1)
            {
                alphas[2] = Lerp(alpha0, alpha1, 6, 1);
                alphas[3] = Lerp(alpha0, alpha1, 5, 2);
                alphas[4] = Lerp(alpha0, alpha1, 4, 3);
                alphas[5] = Lerp(alpha0, alpha1, 3, 4);
                alphas[6] = Lerp(alpha0, alpha1, 2, 5);
                alphas[7] = Lerp(alpha0, alpha1, 1, 6);
            }
            else
            {

                alphas[2] = Lerp(alpha0, alpha1, 4, 1);
                alphas[3] = Lerp(alpha0, alpha1, 3, 2);
                alphas[4] = Lerp(alpha0, alpha1, 2, 3);
                alphas[5] = Lerp(alpha0, alpha1, 1, 4);
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
            return new RGBAColor((byte)(r << 3), (byte)(g << 2), (byte)(b << 3), 255);
        }

        private static RGBAColor ColorLerp(RGBAColor c0, RGBAColor c1, int w0, int w1)
        {
            return new RGBAColor(
                Lerp(c0.R, c1.R, w0, w1),
                Lerp(c0.G, c1.G, w0, w1),
                Lerp(c0.B, c1.B, w0, w1), 255);
        }

        private static byte Lerp(int a0, int a1, int w0, int w1)
        {
            int sum = w0 + w1;
            int bias = sum / 2; // round to the nearest integer instead of truncating
            return (byte)((w0 * a0 + w1 * a1 + bias) / sum);
        }

        private static unsafe void CalculateNormalZ(RGBAColor* vector)
        {
            vector->B = CalculateNormalZ(vector->R, vector->G);
            vector->A = 255;
        }

        private static byte CalculateNormalZ(byte x, byte y)
        {
            float fx = ((x / 255f) * 2f) - 1f;
            float fy = ((y / 255f) * 2f) - 1f;
            float fz = CalculateNormalZ(fx, fy);
            return (byte)((fz + 1f) / 2f * 255f);
        }

        private static float CalculateNormalZ(float x, float y)
        {
            return (float)Math.Sqrt(Math.Max(0.0, Math.Min(1.0, 1.0 - (x * x) - (y * y))));
        }
    }
}
