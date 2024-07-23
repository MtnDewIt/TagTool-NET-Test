using System;
using System.IO;
using TagTool.Cache;
using TagTool.Extensions;
using TagTool.Tags.Definitions;
using TagTool.Tags.Resources;

namespace TagTool.Bitmaps.Utils
{
    public static class BitmapConverter
    {
        public static BaseBitmap ConvertGen3Bitmap(GameCache cache, Bitmap bitmap, int imageIndex, string tagName, bool forDDS = false)
        {
            var image = bitmap.Images[imageIndex];

            if (image.XboxFlags.HasFlag(BitmapFlagsXbox.Xbox360UseInterleavedTextures))
            {
                BitmapTextureInterleavedInteropResource resource = cache.ResourceCache.GetBitmapTextureInterleavedInteropResource(bitmap.InterleavedHardwareTextures[image.InterleavedInterop]);
                if (resource == null)
                    return null;

                BitmapTextureInteropDefinition definition = resource.Texture.Definition.Bitmap1;
                BitmapTextureInteropDefinition otherDefinition = resource.Texture.Definition.Bitmap2;
                if (image.InterleavedTextureIndex > 0)
                    (definition, otherDefinition) = (otherDefinition, definition);

                return ConvertGen3Bitmap(resource.Texture.Definition.PrimaryResourceData.Data, 
                    resource.Texture.Definition.SecondaryResourceData.Data, 
                    definition, 
                    bitmap, 
                    imageIndex, 
                    true,
                    image.InterleavedTextureIndex, 
                    otherDefinition, 
                    forDDS, 
                    cache.Version,
                    cache.Platform,
                    tagName);
            }
            else
            {
                BitmapTextureInteropResource resource = cache.ResourceCache.GetBitmapTextureInteropResource(bitmap.HardwareTextures[imageIndex]);
                if (resource == null)
                    return null;

                return ConvertGen3Bitmap(resource.Texture.Definition.PrimaryResourceData.Data, 
                    resource.Texture.Definition.SecondaryResourceData.Data, 
                    resource.Texture.Definition.Bitmap, 
                    bitmap, 
                    imageIndex, 
                    false, 
                    0, 
                    null, 
                    forDDS, 
                    cache.Version, 
                    cache.Platform,
                    tagName);
            }
        }

        private static BaseBitmap ConvertGen3Bitmap(byte[] primaryData, 
            byte[] secondaryData, 
            BitmapTextureInteropDefinition definition, 
            Bitmap bitmap, 
            int imageIndex, 
            bool isPaired, 
            int pairIndex, 
            BitmapTextureInteropDefinition otherDefinition, 
            bool forDDS, 
            CacheVersion version, 
            CachePlatform cachePlatform,
            string tagName)
        {
            if (primaryData == null && secondaryData == null)
                return null;

            Bitmap.Image image = bitmap.Images[imageIndex];
            BitmapFormat destinationformat = GestDestinationFormat(image.Format, tagName, bitmap, imageIndex, version, cachePlatform);

            int mipLevelCount = definition.MipmapCount;
            int layerCount = definition.BitmapType == BitmapType.CubeMap ? 6 : definition.Depth;
            bool swapCubemapFaces = definition.BitmapType == BitmapType.CubeMap && cachePlatform != CachePlatform.MCC;

            // array bitmaps will be converted to texture3d and thus can't have mipmaps unfortunately
            if (definition.BitmapType == BitmapType.Array && mipLevelCount > 1)
                mipLevelCount = 1;
            // for d3d9 dxn mips have to be >= 4x4 to avoid a crash
            if (destinationformat == BitmapFormat.Dxn)
                mipLevelCount = BitmapUtils.GetMipmapCount(image.Width, image.Height, 4, 4, maxCount: mipLevelCount);

            // convert the surfaces
            var result = new MemoryStream();
            foreach (var (layerIndex, mipLevel) in BitmapUtils.GetBitmapSurfacesEnumerable(layerCount, mipLevelCount, forDDS))
            {
                int sourceLayerIndex = layerIndex;
                if (swapCubemapFaces)
                {
                    if (layerIndex == 1) sourceLayerIndex = 2;
                    else if (layerIndex == 2) sourceLayerIndex = 1;
                }
                ConvertGen3BitmapData(image.Format, destinationformat, result, primaryData, secondaryData, definition, tagName, bitmap, imageIndex, mipLevel, sourceLayerIndex, isPaired, pairIndex, otherDefinition, version, cachePlatform);
            }

            // build the result bitmap
            BaseBitmap resultBitmap = new BaseBitmap(image);
            resultBitmap.Data = result.ToArray();
            resultBitmap.MipMapCount = mipLevelCount;
            if (resultBitmap.Type == BitmapType.Array)
                resultBitmap.Type = BitmapType.Texture3D;
            resultBitmap.UpdateFormat(destinationformat);

            return resultBitmap;
        }

        private static BitmapFormat GestDestinationFormat(BitmapFormat format, string tagName, Bitmap bitmap, int imageIndex, CacheVersion version, CachePlatform platform)
        {
            // fix dxt5 bumpmaps (h3 wraith bump)
            if (bitmap.Usage == Bitmap.BitmapUsageGlobalEnum.BumpMapfromHeightMap &&
                format == BitmapFormat.Dxt5 &&
                tagName != @"levels\multi\zanzibar\bitmaps\palm_frond_a_bump")
            {
                return BitmapFormat.Dxn;
            }

            // non-pow2 dxn is not supported in d3d9
            if (format == BitmapFormat.Dxn && !BitmapUtils.IsPowerOfTwo(bitmap.Images[imageIndex].Width, bitmap.Images[imageIndex].Height))
                return BitmapFormat.A8R8G8B8;

            // array textures will be converted to texture3d which does not support v8u8
            if (bitmap.Usage == Bitmap.BitmapUsageGlobalEnum.WaterArray)
                return BitmapFormat.A8R8G8B8;

            return BitmapUtils.GetEquivalentBitmapFormat(format);
        }

        private unsafe static void ConvertGen3BitmapData(BitmapFormat format, BitmapFormat destinationFormat, Stream resultStream, byte[] primaryData, byte[] secondaryData, BitmapTextureInteropDefinition definition, string tagName, Bitmap bitmap, int imageIndex,  int level, int layerIndex, bool isPaired, int pairIndex, BitmapTextureInteropDefinition otherDefinition, CacheVersion version, CachePlatform platform)
        {
            byte[] surface = BitmapUtils.GetBitmapSurface(primaryData, secondaryData, definition, bitmap, imageIndex, level, layerIndex, isPaired, pairIndex, otherDefinition, platform);
            
            int surfaceWidth = Math.Max(1, definition.Width >> level);
            int surfaceHeight = Math.Max(1, definition.Height >> level);

            surface = ConvertBitmapData(surface, surfaceWidth, surfaceHeight, format, destinationFormat, bitmap, imageIndex, tagName, version, platform);
            
            resultStream.Write(surface, 0, surface.Length);
        }

        private static byte[] ConvertBitmapData(byte[] data, int width, int height, BitmapFormat format, BitmapFormat destinationFormat, Bitmap bitmap, int imageIndex, string tagName, CacheVersion version, CachePlatform platform)
        {
            if (platform == CachePlatform.MCC && format == destinationFormat)
                return ConvertDXGIFormats(data, width, height, format);

            // DXN -> ATI2
            if (platform == CachePlatform.Original && format == BitmapFormat.Dxn && destinationFormat == BitmapFormat.Dxn)
                return BitmapDecoder.SwapXYDxn(data, width, height);

            // fix dxt5 bumpmaps (h3 wraith bump)
            if (format == BitmapFormat.Dxt5 &&
                bitmap.Usage == Bitmap.BitmapUsageGlobalEnum.BumpMapfromHeightMap &&
                tagName != @"levels\multi\zanzibar\bitmaps\palm_frond_a_bump") // this tag is actually an alpha test bitmap, ignore it
            {
                data = BitmapDecoder.DecodeBitmap(data, format, width, height, version, platform);
                // (0<->1) to (-1<->1)
                for (int i = 0; i < data.Length; i += 4)
                {
                    data[i + 0] = 0;
                    data[i + 1] = (byte)((data[i + 1] + 255) / 2);
                    data[i + 2] = (byte)((data[i + 2] + 255) / 2);
                    data[i + 3] = 0;
                }
                return BitmapDecoder.EncodeBitmap(data, BitmapFormat.Dxn, width, height);
            }

            // cubemap compatibility - this is required for h3 shaders to look correct when using reach dynamic cubemaps
            if (version >= CacheVersion.HaloReach && bitmap.Images[imageIndex].ExponentBias == 2)
            {
                var rawData = BitmapDecoder.DecodeBitmap(data, format, width, height, version, platform);
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
                return BitmapDecoder.EncodeBitmap(rawData, destinationFormat, width, height);
            }

            if (format == destinationFormat)
                return data;

            data = BitmapDecoder.DecodeBitmap(data, format, width, height, version, platform);
            return BitmapDecoder.EncodeBitmap(data, destinationFormat, width, height);
        }

        private static unsafe byte[] ConvertDXGIFormats(byte[] data, int width, int height, BitmapFormat format)
        {
            if (format == BitmapFormat.Dxn)
            {
                byte unorm(byte b) => (byte)(((sbyte)b / 127f + 1) / 2f * 255f);
                for (int i = 0; i < data.Length; i += 16)
                {
                    // signed -> unsigned
                    data[i + 0] = unorm(data[i + 0]);
                    data[i + 1] = unorm(data[i + 1]);
                    data[i + 8] = unorm(data[i + 8]);
                    data[i + 9] = unorm(data[i + 9]);
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
