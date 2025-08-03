using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Bitmaps.Utils;
using TagTool.Cache;

namespace TagTool.Bitmaps
{
    public static class BitmapDecoder
    {
        // WARNING: internal decoders should only decode by virtual dimensions, not array length!
        public static byte[] DecodeBitmap(byte[] bitmRaw, BitmapFormat format, int virtualWidth, int virtualHeight, CacheVersion version = CacheVersion.Unknown, CachePlatform platform = CachePlatform.Original)
        {
            switch (format)
            {
                case BitmapFormat.A8:
                    return DecodeA8(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.Y8:
                    return DecodeY8(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.AY8:
                    return DecodeAY8(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.A8Y8:
                    return DecodeA8Y8(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.L16:
                    return DecodeY16(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.R5G6B5:
                    return DecodeR5G6B5(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.A1R5G5B5:
                    return DecodeA1R5G5B5(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.A4R4G4B4:
                    return DecodeA4R4G4B4(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.X8R8G8B8:
                case BitmapFormat.A8R8G8B8:
                case BitmapFormat.Q8W8V8U8:
                    return DecodeA8R8G8B8(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.A4R4G4B4Font:
                    return DecodeP8(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.V8U8:
                    return DecodeV8U8(bitmRaw, virtualWidth, virtualHeight);

                case BitmapFormat.V16U16:
                    return DecodeV16U16(bitmRaw, virtualWidth, virtualHeight);

                default:
                    if (BitmapUtils.IsCompressedFormat(format))
                        return BitmapCompression.Decompress(bitmRaw, virtualWidth, virtualHeight, format, version, platform);
                    else
                        throw new NotSupportedException($"Unsupported bitmap format {format}.");
            }
        }

        public static byte[] EncodeBitmap(byte[] bitm, BitmapFormat format, int virtualWidth, int virtualHeight, CompressionQuality quality = CompressionQuality.Default)
        {
            switch (format)
            {
                case BitmapFormat.A8:
                    return EncodeA8(bitm, virtualWidth, virtualHeight);

                case BitmapFormat.Y8:
                    return EncodeY8(bitm, virtualWidth, virtualHeight);

                case BitmapFormat.A8Y8:
                    return EncodeA8Y8(bitm, virtualWidth, virtualHeight);

                case BitmapFormat.A8R8G8B8:
                case BitmapFormat.Q8W8V8U8:
                    return EncodeA8R8G8B8(bitm, virtualWidth, virtualHeight);

                case BitmapFormat.V8U8:
                    return EncodeV8U8(bitm, virtualWidth, virtualHeight);

                default:
                    if(BitmapUtils.IsCompressedFormat(format))
                        return BitmapCompression.Compress(bitm, virtualWidth, virtualHeight, format, quality);
                    else
                        throw new NotSupportedException($"Unsupported bitmap format {format}.");
            }
        }

        private static byte[] DecodeP8(byte[] data, int width, int height)
        {
            var buffer = new byte[data.Length * 4];
            for (int i = 0; i < data.Length; i++)
            {
                buffer[i * 4 + 0] = data[i];
                buffer[i * 4 + 1] = data[i];
                buffer[i * 4 + 2] = data[i];
                buffer[i * 4 + 3] = 255;
            }
            return buffer;
        }

        private static byte[] DecodeA8R8G8B8(byte[] data, int width, int height)
        {
            return data;
        }

        private static byte[] EncodeA8R8G8B8(byte[] data, int width, int height)
        {
            return data;
        }

        private static byte[] DecodeA1R5G5B5(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[width * height * 4];
            for (int i = 0; i < (width * height * 2); i += 2)
            {
                short temp = (short)(data[i + 1] | (data[i] << 8));
                buffer[i * 2] = (byte)(temp & 0x1F);
                buffer[i * 2 + 1] = (byte)((temp >> 5) & 0x3F);
                buffer[i * 2 + 2] = (byte)((temp >> 11) & 0x1F);
                buffer[i * 2 + 3] = 0xFF;
            }
            return buffer;
        }

        private static byte[] DecodeA4R4G4B4(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[width * height * 4];
            for (int i = 0; i < (width * height * 2); i += 2)
            {
                buffer[i * 2 + 2] = (byte)((data[i + 1] & 0x0F) << 4);
                buffer[i * 2 + 3] = (byte)(data[i + 1] & 0xF0);
                buffer[i * 2 + 0] = (byte)((data[i + 0] & 0x0F) << 4);
                buffer[i * 2 + 1] = (byte)(data[i + 0] & 0xF0);
            }
            return buffer;
        }

        private static byte[] DecodeA8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 4];
            for (int i = 0; i < (height * width); i++)
            {
                int index = i * 4;
                buffer[index] = 0;
                buffer[index + 1] = 0;
                buffer[index + 2] = 0;
                buffer[index + 3] = data[i];
            }

            return buffer;
        }

        private static byte[] DecodeY16(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 4];

            for (int i = 0; i < (height * width); i++)
            {
                // 16 bit color, but stored in 8 bits, precision loss, we can use the most important byte and truncate the rest for now.
                // ushort color = (ushort)((data[i * 2]) | (data[i * 2 + 1] << 8));

                int index = i * 4;
                buffer[index] = data[i * 2 + 1];
                buffer[index + 1] = data[i * 2 + 1];
                buffer[index + 2] = data[i * 2 + 1];
                buffer[index + 3] = 0;
            }

            return buffer;
        }

        private static byte[] DecodeA8B8G8R8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 4];

            for (int i = 0; i < (height * width); i++)
            {
                int index = i * 4;
                buffer[index] = data[index];
                buffer[index + 1] = data[index + 3];
                buffer[index + 2] = data[index + 2];
                buffer[index + 3] = data[index + 1];
            }

            return buffer;
        }


        private static byte[] EncodeA8(byte[] data, int width, int height, int idx = 3)
        {
            byte[] buffer = new byte[height * width];
            for (int i = 0; i < (buffer.Length); i++)
            {
                int index = i * 4;
                buffer[i] = data[index + idx];
            }
            return buffer;
        }

        private static byte[] DecodeA8Y8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 4];
            for (int i = 0; i < (height * width * 2); i += 2)
            {
                buffer[i * 2 + 3] = data[i+1];
                buffer[i * 2 + 2] = data[i];
                buffer[i * 2 + 1] = data[i];
                buffer[i * 2 + 0] = data[i];
            }
            return buffer;
        }

        private static byte[] EncodeA8Y8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 2];
            for (int i = 0; i < buffer.Length; i += 2)
            {
                int index = i * 2;
                buffer[i + 1] = data[index + 3];
                buffer[i] = data[index + 2];
            }
            return buffer;
        }

        private static byte[] EncodeV8U8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 2];
            for (int i = 0; i < height * width * 2; i += 2)
            {
                int index = 2 * i;
                buffer[i] = data[index + 2]; // V 
                buffer[i + 1] = data[index + 1]; // U
            }
            return buffer;
        }

        public static byte[] ConvertAY8ToA8Y8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 2];
            for (int i = 0; i < height * width * 2; i += 2)
            {
                int index = i / 2;
                buffer[i] = data[index];
                buffer[i + 1] = data[index];
            }
            return buffer;
        }

        private static byte[] DecodeAY8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 4];
            for (int i = 0; i < height * width; i++)
            {
                int index = i * 4;
                buffer[index] = data[i];
                buffer[index + 1] = data[i];
                buffer[index + 2] = data[i];
                buffer[index + 3] = data[i];
            }
            return buffer;
        }

       

        public static byte[] SwapXYDxn(byte[] data, int width, int height)
        {
            uint blockWidth, blockHeight;
            XboxGraphics.XGGetBlockDimensions(Direct3D.D3D9x.D3D9xGPU.GPUTEXTUREFORMAT.GPUTEXTUREFORMAT_DXN, out blockWidth, out blockHeight);
            uint alignedWidth = Direct3D.D3D9x.D3D.NextMultipleOf((uint)width, blockWidth);
            uint alignedHeight = Direct3D.D3D9x.D3D.NextMultipleOf((uint)height, blockHeight);
            int texelPitch = (int)(blockWidth * blockHeight * XboxGraphics.XGBitsPerPixelFromGpuFormat(Direct3D.D3D9x.D3D9xGPU.GPUTEXTUREFORMAT.GPUTEXTUREFORMAT_DXN)) >> 3;
            for (int i = 0; i < (alignedWidth * alignedHeight); i += texelPitch)
            {
                // store x values and swap
                byte xMin = data[i];
                byte xMax = data[i + 1];

                byte x1 = data[i + 2];
                byte x2 = data[i + 3];
                byte x3 = data[i + 4];
                byte x4 = data[i + 5];
                byte x5 = data[i + 6];
                byte x6 = data[i + 7];

                data[i] = data[i + 8];
                data[i + 1] = data[i + 9];

                data[i + 2] = data[i + 10];
                data[i + 3] = data[i + 11];
                data[i + 4] = data[i + 12];
                data[i + 5] = data[i + 13];
                data[i + 6] = data[i + 14];
                data[i + 7] = data[i + 15];

                data[i + 8] = xMin;
                data[i + 9] = xMax;

                data[i + 10] = x1;
                data[i + 11] = x2;
                data[i + 12] = x3;
                data[i + 13] = x4;
                data[i + 14] = x5;
                data[i + 15] = x6;
            }
            return data;
        }
        public static byte[] FixupBallisticMeter(byte[] data, int iconCount)
        {
            // Holds the unique blue values.
            HashSet<int> blueValues = new HashSet<int>();

            // Variables to hold min and max alpha and green values.
            int minAlpha = int.MaxValue;
            int maxAlpha = int.MinValue;
            int minGreen = int.MaxValue;
            int maxGreen = int.MinValue;

            // Extract blue values, green values, and alpha values.
            for (int i = 0; i < data.Length; i += 4) // Increment by 4 for each pixel (ARGB)
            {
                int blueValue = data[i]; // Blue value is at index 0 for each pixel (BGRA)
                int greenValue = data[i + 1]; // Green value is at index 1 for each pixel (BGRA)
                int alphaValue = data[i + 3]; // Alpha value is at index 3 for each pixel (BGRA)
                if (blueValue > 0)
                {
                    blueValues.Add(blueValue);
                }

                // Update min and max alpha if the current alpha is not zero.
                if (alphaValue > 0)
                {
                    minAlpha = Math.Min(minAlpha, alphaValue);
                    maxAlpha = Math.Max(maxAlpha, alphaValue);
                }

                // Update min and max green if the current green is not zero.
                if (greenValue > 0)
                {
                    minGreen = Math.Min(minGreen, greenValue);
                    maxGreen = Math.Max(maxGreen, greenValue);
                }
            }

            // Normalize alpha values if there is a range to normalize.
            if (minAlpha < maxAlpha)
            {
                for (int i = 3; i < data.Length; i += 4) // Start at index 3 and increment by 4 for each pixel (BGRA)
                {
                    int alphaValue = data[i];
                    if (alphaValue != 0) // Only modify non-zero alpha values.
                    {
                        // Normalize the alpha value to the 0-255 range.
                        data[i] = (byte)(((alphaValue - minAlpha) * 255) / (maxAlpha - minAlpha));
                    }
                }
            }

            // Normalize green values if there is a range to normalize.
            if (minGreen < maxGreen)
            {
                for (int i = 1; i < data.Length; i += 4) // Start at index 1 and increment by 4 for each pixel (BGRA)
                {
                    int greenValue = data[i];
                    if (greenValue != 0) // Only modify non-zero green values.
                    {
                        // Normalize the green value to the 0-5 range.
                        data[i] = (byte)((5 * (greenValue - minGreen) / (maxGreen - minGreen)));
                    }
                }
            }

            // Convert the HashSet to a List and sort it.
            var sortedBlueValues = blueValues.ToList();
            sortedBlueValues.Sort();

            // If the count matches iconCount, we assign values in order.
            if (sortedBlueValues.Count == iconCount)
            {
                // Create a dictionary to map original blue values to their new values.
                Dictionary<int, byte> blueValueMapping = new Dictionary<int, byte>();
                for (int i = 0; i < sortedBlueValues.Count; i++)
                {
                    // Map the sorted blue values to a range from 1 to iconCount.
                    blueValueMapping[sortedBlueValues[i]] = (byte)(i + 1);
                }

                // Loop through each pixel in the data
                for (int i = 0; i < data.Length; i += 4) // Increment by 4 for each pixel (ARGB)
                {
                    if (data[i] != 0) // Only modify non-zero blue values
                    {
                        // Apply the new blue value if it's in the dictionary
                        if (blueValueMapping.TryGetValue(data[i], out byte newBlueValue))
                        {
                            data[i] = newBlueValue;
                        }
                    }
                }
            }
            else
            {
                // Otherwise, we do the averaging and division as before
                List<int> differences = new List<int>();
                for (int i = 0; i < sortedBlueValues.Count - 1; i++)
                {
                    differences.Add(sortedBlueValues[i + 1] - sortedBlueValues[i]);
                }

                double averageDifference = differences.Any() ? differences.Average() : 0;

                for (int i = 0; i < data.Length; i += 4) // Increment by 4 for each pixel (ARGB)
                {
                    // Apply the value to the Blue component
                    if (data[i] != 0) // Only modify non-zero blue values
                    {
                        byte newData = (byte)((data[i] / averageDifference) + 1);
                        data[i] = newData;
                    }
                }
            }
            return data;
        }

        public static byte[] Ctx1ToDxn(byte[] data, int width, int height)
        {
            uint blockWidth, blockHeight;
            XboxGraphics.XGGetBlockDimensions(Direct3D.D3D9x.D3D9xGPU.GPUTEXTUREFORMAT.GPUTEXTUREFORMAT_CTX1, out blockWidth, out blockHeight);
            uint alignedWidth = Direct3D.D3D9x.D3D.NextMultipleOf((uint)width, blockWidth);
            uint alignedHeight = Direct3D.D3D9x.D3D.NextMultipleOf((uint)height, blockHeight);
            uint DXNbpp = XboxGraphics.XGBitsPerPixelFromGpuFormat(Direct3D.D3D9x.D3D9xGPU.GPUTEXTUREFORMAT.GPUTEXTUREFORMAT_DXN);
            uint CTXbpp = XboxGraphics.XGBitsPerPixelFromGpuFormat(Direct3D.D3D9x.D3D9xGPU.GPUTEXTUREFORMAT.GPUTEXTUREFORMAT_CTX1);
            int CTX1TexelPitch = (int)(blockWidth * blockHeight * CTXbpp) >> 3;
            int ctx1ImageSize = (int)(alignedWidth * alignedHeight * CTXbpp) >> 3;
            int DXNTexelPitch = (int)(blockWidth * blockHeight * DXNbpp) >> 3;

            byte[] buffer = new byte[(alignedWidth * alignedHeight * DXNbpp) >> 3];

            int b = 0;  // buffer block index (dxn)
            for (int i = 0; i < ctx1ImageSize; i += CTX1TexelPitch, b += DXNTexelPitch)
            {
                // convert X,Y min and max components (swap X and Y at the same time)
                byte minX = data[i + 0];
                byte minY = data[i + 1];
                byte maxX = data[i + 2];
                byte maxY = data[i + 3];

                buffer[b] = minX;
                buffer[b + 1] = maxX;
                buffer[b + 8] = minY;
                buffer[b + 9] = maxY;

                byte[] Ctx1indices = new byte[16];
                // convert indices
                for (int k = 0; k < 4; k++)
                {
                    Ctx1indices[(k * 4 + 0)] = (byte)((data[i + 4 + k] & 0xC0) >> 6);
                    Ctx1indices[(k * 4 + 1)] = (byte)((data[i + 4 + k] & 0x30) >> 4);
                    Ctx1indices[(k * 4 + 2)] = (byte)((data[i + 4 + k] & 0x0C) >> 2);
                    Ctx1indices[(k * 4 + 3)] = (byte)((data[i + 4 + k] & 0x03) >> 0);
                }


                var XIndices = FixCTX1Indices(Ctx1indices, minX, maxX);
                var YIndices = FixCTX1Indices(Ctx1indices, minY, maxY);

                // DXN indices, table of 3 bits , 16 times 12 bytes total
                buffer[b + 2] = (byte)(((XIndices[3]) << 0) | ((XIndices[2]) << 3) | ((XIndices[1] & 0x3) << 6));
                buffer[b + 3] = (byte)(((XIndices[1] & 0x4) >> 2) | ((XIndices[0]) << 1) | ((XIndices[7]) << 4) | ((XIndices[6] & 0x1) << 7));
                buffer[b + 4] = (byte)(((XIndices[6] & 0x6) >> 1) | ((XIndices[5]) << 2) | ((XIndices[4]) << 5));
                buffer[b + 5] = (byte)(((XIndices[11]) << 0) | ((XIndices[10]) << 3) | ((XIndices[9] & 0x3) << 6));
                buffer[b + 6] = (byte)(((XIndices[9] & 0x4) >> 2) | ((XIndices[8]) << 1) | ((XIndices[15]) << 4) | ((XIndices[14] & 0x1) << 7));
                buffer[b + 7] = (byte)(((XIndices[14] & 0x6) >> 1) | ((XIndices[13]) << 2) | ((XIndices[12]) << 5));

                buffer[b + 10] = (byte)(((YIndices[3]) << 0) | ((YIndices[2]) << 3) | ((YIndices[1] & 0x3) << 6));
                buffer[b + 11] = (byte)(((YIndices[1] & 0x4) >> 2) | ((YIndices[0]) << 1) | ((YIndices[7]) << 4) | ((YIndices[6] & 0x1) << 7));
                buffer[b + 12] = (byte)(((YIndices[6] & 0x6) >> 1) | ((YIndices[5]) << 2) | ((YIndices[4]) << 5));
                buffer[b + 13] = (byte)(((YIndices[11]) << 0) | ((YIndices[10]) << 3) | ((YIndices[9] & 0x3) << 6));
                buffer[b + 14] = (byte)(((YIndices[9] & 0x4) >> 2) | ((YIndices[8]) << 1) | ((YIndices[15]) << 4) | ((YIndices[14] & 0x1) << 7));
                buffer[b + 15] = (byte)(((YIndices[14] & 0x6) >> 1) | ((YIndices[13]) << 2) | ((YIndices[12]) << 5));

            }


            return buffer;
        }

        /// <summary>
        /// Converts from 2 bit index from CTX1 to the 3 bit index from DXN
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="c0"></param>
        /// <param name="c1"></param>
        /// <returns></returns>
        private static byte[] FixCTX1Indices(byte[] indices, byte c0, byte c1)
        {
            byte[] result = new byte[indices.Length];

            for (int i = 0; i < 16; i++)
            {
                byte index = indices[i];

                if (c0 > c1)
                {
                    if (index == 2)
                        index = 4;
                    if (index == 3)
                        index = 5;
                }
                else
                {
                    if (index == 2)
                        index = 3;
                    if (index == 3)
                        index = 4;
                }

                result[i] = index;
            }
            return result;
        }

        
        private static byte[] DecodeR5G6B5(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[width * height * 4];
            for (int i = 0; i < (width * height * 2); i += 2)
            {
                ushort temp = (ushort)(data[i + 1] | ((ushort)(data[i]) << 8));
                byte red = (byte)((temp >> 11) & 0x1f);
                byte green = (byte)((temp >> 5) & 0x3f);
                byte blue = (byte)(temp & 0x1f);

                buffer[(i * 2) + 0] = (byte)((red << 3) | (red >> 2));
                buffer[(i * 2) + 1] = (byte)((green << 2) | (green >> 4));
                buffer[(i * 2) + 2] = (byte)((blue << 3) | (blue >> 2));
                buffer[(i * 2) + 3] = 0xFF;
            }
            return buffer;
        }

        public static byte[] DecodeV8U8(byte[] data, int width, int height, bool swapXY = false)
        {
            byte[] buffer = new byte[width * height * 4];
            for (int i = 0; i < (width * height * 2); i += 2)
            {
                byte X = (byte)(data[i + 1] + 127);
                byte Y = (byte)(data[i + 0] + 127);

                buffer[i * 2] = 0xFF;
                buffer[(i * 2) + 1] = swapXY ? Y : X;
                buffer[(i * 2) + 2] = swapXY ? X : Y;
                buffer[(i * 2) + 3] = 0xFF;
            }
            return buffer;
        }

        public static byte[] DecodeV16U16(byte[] data, int width, int height, bool swapXY = false)
        {
            byte[] buffer = new byte[width * height * 4];
            for (int i = 0; i < (width * height * 4); i += 4)
            {
                ushort X = (ushort)(((((ushort)data[i + 2]) << 8) | (ushort)data[i + 3]) + 0x7FFF);
                ushort Y = (ushort)(((((ushort)data[i + 0]) << 8) | (ushort)data[i + 1]) + 0x7FFF);

                if (swapXY)
                {
                    buffer[i] = (byte)((X >> 8) & 0xFF);
                    buffer[(i) + 1] = (byte)(X & 0xFF);
                    buffer[(i) + 2] = (byte)((Y >> 8) & 0xFF);
                    buffer[(i) + 3] = (byte)(Y & 0xFF);
                }
                else
                {
                    buffer[i] = (byte)((Y >> 8) & 0xFF);
                    buffer[(i) + 1] = (byte)(Y & 0xFF);
                    buffer[(i) + 2] = (byte)((X >> 8) & 0xFF);
                    buffer[(i) + 3] = (byte)(X & 0xFF);
                }
            }
            return buffer;
        }

        private static byte[] DecodeY8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width * 4];
            for (int i = 0; i < (height * width); i++)
            {
                int index = i * 4;
                buffer[index + 3] = 0xFF;
                buffer[index + 2] = data[i];
                buffer[index + 1] = data[i];
                buffer[index + 0] = data[i];
            }
            return buffer;
        }

        private static byte[] EncodeY8(byte[] data, int width, int height)
        {
            byte[] buffer = new byte[height * width];
            for (int i = 0; i < (height * width); i++)
            {
                int index = i * 4;
                buffer[i] = data[index + 1];
            }
            return buffer;
        }

        public static List<byte[]> DecodeCubemap(byte[] bitmRaw, BitmapFormat format, int virtualWidth, int virtualHeight)
        {
            int faceSize = (virtualWidth * virtualHeight * BitmapFormatUtils.GetBitsPerPixel(format)) / 8;

            List<byte[]> result = new List<byte[]>();//new byte[rawFaceSize * 6];

            for (int i = 0; i < 6; i++)
            {
                result.Add(DecodeBitmap(bitmRaw.Skip(faceSize * i).ToArray(), format, virtualWidth, virtualHeight));
            }

            return result;
        }
    }
}
