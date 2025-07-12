using System;
using System.IO;
using TagTool.Cache;
using TagTool.Extensions;
using TagTool.Tags.Definitions;

namespace TagTool.Bitmaps.Utils
{
    public class BitmapConverterGen3
    {
        public GameCache Cache { get; }
        public bool HqNormalMapCompression { get; set; }
        public bool ForceDxt5nm { get; set; }

        public BitmapConverterGen3(GameCache cache)
        {
            Cache = cache;
        }

        public BaseBitmap ConvertBitmap(Bitmap bitmap, int imageIndex, string tagName, bool forDDS = false)
        {
            var extractor = new BitmapExtractorGen3(Cache, bitmap, imageIndex);
            if (extractor.HasInvalidResource)
                return null;

            Bitmap.Image image = bitmap.Images[imageIndex];
            BitmapFormat destFormat = GestDestinationFormat(image.Format, tagName, bitmap, imageIndex);

            int mipCount = image.MipmapCount + 1;
            int layerCount = image.Type == BitmapType.CubeMap ? 6 : image.Depth;
            bool swapCubemapFaces = image.Type == BitmapType.CubeMap && Cache.Platform != CachePlatform.MCC;

            // array bitmaps will be converted to texture3d and thus can't have mipmaps unfortunately
            if (image.Type == BitmapType.Array && mipCount > 1)
                mipCount = 1;
            // for d3d9 dxn mips have to be >= 4x4 to avoid a crash
            if (destFormat == BitmapFormat.Dxn)
                mipCount = BitmapUtils.GetMipmapCountTruncate(image.Width, image.Height, 4, 4, maxCount: mipCount);

            // convert the surfaces
            var result = new MemoryStream();
            foreach (var (layerIndex, mipLevel) in BitmapUtils.GetBitmapSurfacesEnumerable(layerCount, mipCount, forDDS))
            {
                int sourceLayerIndex = layerIndex;
                if (swapCubemapFaces)
                {
                    if (layerIndex == 1) sourceLayerIndex = 2;
                    else if (layerIndex == 2) sourceLayerIndex = 1;
                }

                byte[] surface = extractor.ExtractSurface(sourceLayerIndex, mipLevel, out int levelWidth, out int levelHeight);
                surface = ConvertBitmapData(surface, levelWidth, levelHeight, image.Format, destFormat, bitmap, imageIndex, tagName);
                result.Write(surface);
            }

            // build the result bitmap
            BaseBitmap resultBitmap = new BaseBitmap(image);
            resultBitmap.Data = result.ToArray();
            resultBitmap.MipMapCount = mipCount;
            if (resultBitmap.Type == BitmapType.Array)
                resultBitmap.Type = BitmapType.Texture3D;
            resultBitmap.UpdateFormat(destFormat);

            return resultBitmap;
        }

        private BitmapFormat GestDestinationFormat(BitmapFormat format, string tagName, Bitmap bitmap, int imageIndex)
        {  
            // array textures will be converted to texture3d which does not support v8u8
            if (bitmap.Usage == Bitmap.BitmapUsageGlobalEnum.WaterArray)
                return BitmapFormat.A8R8G8B8;

            if (BitmapUtils.IsNormalMap(bitmap, imageIndex))
            {
                format = GetNormalMapFormat(format);

                // non-pow2 dxn is not supported in d3d9
                if (format == BitmapFormat.Dxn && !BitmapUtils.IsPowerOfTwo(bitmap.Images[imageIndex].Width, bitmap.Images[imageIndex].Height))
                    return BitmapFormat.Dxt1;

                return format;
            }

            return BitmapUtils.GetEquivalentBitmapFormat(format);
        }

        private CompressionQuality GetCompressionQuality(BitmapFormat destFormat)
        {
            if (destFormat == BitmapFormat.Dxt5nm && HqNormalMapCompression)
                return CompressionQuality.High;

            return CompressionQuality.Default;
        }

        private BitmapFormat GetNormalMapFormat(BitmapFormat format)
        {
            if (ForceDxt5nm)
                return BitmapFormat.Dxt5nm;

            if (format == BitmapFormat.V8U8)
                return format;

            return HqNormalMapCompression ? BitmapFormat.Dxn : BitmapFormat.Dxt1;
        }

        private byte[] ConvertBitmapData(byte[] data, int width, int height, BitmapFormat format, BitmapFormat destFormat, Bitmap bitmap, int imageIndex, string tagName)
        {
            if (Cache.Platform == CachePlatform.MCC && format == destFormat)
                return ConvertDXGIFormats(data, width, height, format);

            // DXN -> ATI2
            if (Cache.Platform == CachePlatform.Original && format == BitmapFormat.Dxn && destFormat == BitmapFormat.Dxn)
                return BitmapDecoder.SwapXYDxn(data, width, height);

            CompressionQuality quality = GetCompressionQuality(destFormat);

            // fix dxt5 bumpmaps (h3 wraith bump)
            if (format == BitmapFormat.Dxt5 && tagName == @"objects\vehicles\wraith\bitmaps\wraith_bump")
            {
                data = BitmapDecoder.DecodeBitmap(data, format, width, height, Cache.Version, Cache.Platform);
                for (int i = 0; i < data.Length; i += 4)
                {
                    byte g = (byte)((data[i + 1] + 255) / 2);
                    byte r = (byte)((data[i + 2] + 255) / 2);
                    data[i + 0] = BitmapUtils.CalculateNormalZ(r, g);
                    data[i + 1] = g;
                    data[i + 2] = r;
                    data[i + 3] = 255;
                }
                return BitmapDecoder.EncodeBitmap(data, destFormat, width, height, quality);
            }

            // cubemap compatibility - this is required for h3 shaders to look correct when using reach dynamic cubemaps
            if (Cache.Version >= CacheVersion.HaloReach && bitmap.Images[imageIndex].ExponentBias == 2)
            {
                var rawData = BitmapDecoder.DecodeBitmap(data, format, width, height, Cache.Version, Cache.Platform);
                const float oneDiv255 = 1.0f / 255.0f;
                float expBias = (float)Math.Pow(2.0f, bitmap.Images[imageIndex].ExponentBias); // 4.0f
                for (int i = 0; i < data.Length; i += 4)
                {
                    var vector = VectorExtensions.InitializeVector(new float[] { rawData[i], rawData[i + 1], rawData[i + 2], rawData[i + 3] });

                    vector *= oneDiv255; // 0-1 range
                                         // need more math here. not sure if it can be prebaked. this should do for now.
                    vector *= vector;
                    vector *= 255.0f; // 0-255 range

                    rawData[i + 0] = (byte)vector[0];
                    rawData[i + 1] = (byte)vector[1];
                    rawData[i + 2] = (byte)vector[2];
                    //rawData[i + 3] = (byte)(biasedAlpha * 255.0f); // no need to touch alpha.
                }
                return BitmapDecoder.EncodeBitmap(rawData, destFormat, width, height, quality);
            }

            if (format == destFormat)
                return data;

            data = BitmapDecoder.DecodeBitmap(data, format, width, height, Cache.Version, Cache.Platform);
            return BitmapDecoder.EncodeBitmap(data, destFormat, width, height, quality);
        }

        private static unsafe byte[] ConvertDXGIFormats(byte[] data, int width, int height, BitmapFormat format)
        {
            if (format == BitmapFormat.Dxn)
            {
                for (int i = 0; i < data.Length; i += 16)
                {
                    // signed -> unsigned
                    data[i + 0] += 128;
                    data[i + 1] += 128;
                    data[i + 8] += 128;
                    data[i + 9] += 128;

                    // swap X/Y
                    for (int j = 0; j < 8; j++)
                    {
                        byte tmp = data[i + j];
                        data[i + j] = data[i + j + 8];
                        data[i + j + 8] = tmp;
                    }
                }
                return data;
            }

            if (format == BitmapFormat.A2R10G10B10)
            {
                // convert DXGI_FORMAT_R10G10B10A2_UNORM to A2R10G10B10
                fixed (byte* ptr = data)
                {
                    for (int i = 0; i < width * height; i++)
                    {
                        uint* pixel = (uint*)&ptr[i * 4];
                        uint R = (*pixel & 0x3ff00000) >> 20;
                        uint G = (*pixel & 0x000ffc00);
                        uint B = (*pixel & 0x000003ff) << 20;
                        uint A = (*pixel & 0xC0000000);
                        *pixel = B | G | R | A;
                    }
                }
                return data;
            }

            return data;
        }
    }
}
