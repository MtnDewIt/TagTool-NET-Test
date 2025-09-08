using System;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Tags.Resources;
using static TagTool.Tags.Definitions.Bitmap;

namespace TagTool.Bitmaps.Utils
{
    public static class BitmapUtilsPC
    {
        public static int GetMipmapOffset(Image bitmap, int layerIndex, int mipmapIndex)
        {
            switch (bitmap.Type)
            {
                case BitmapType.Texture2D:
                    return GetTexture2DOffset(bitmap, 0, 0, mipmapIndex);
                case BitmapType.Texture3D:
                    return GetTexture3DOffset(bitmap, 0, 0, layerIndex, mipmapIndex);
                case BitmapType.CubeMap:
                    return GetTextureCubemapOffset(bitmap, 0, 0, layerIndex, mipmapIndex);
                case BitmapType.Array:
                    return GetTextureArrayOffset(bitmap, 0, 0, layerIndex, mipmapIndex);
                default:
                    throw new NotImplementedException();
            }
        }

        public static int GetTexture2DOffset(Image bitmap, int x, int y, int mipmapIndex)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int align = bitmap.Flags.HasFlag(BitmapFlags.Compressed) ? 4 : 1;
            int bitsPerPixel = BitmapFormatUtils.GetBitsPerPixel(bitmap.Format);

            int offset = 0;
            for (int i = 0; i < mipmapIndex; i++)
            {
                offset += ((width + (align - 1)) & ~(align - 1)) * ((height + (align - 1)) & ~(align - 1));
                width = Math.Max(width >> 1, align);
                height = Math.Max(height >> 1, align);
            }

            return (offset + x + y * width) * bitsPerPixel / 8;
        }

        public static int GetTexture3DOffset(Image bitmap, int x, int y, int z, int mipmapIndex)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int depth = bitmap.Depth;
            int align = bitmap.Flags.HasFlag(BitmapFlags.Compressed) ? 4 : 1;
            int bitsPerPixel = BitmapFormatUtils.GetBitsPerPixel(bitmap.Format);

            int offset = 0;
            for (int i = 0; i < mipmapIndex; ++i)
            {
                offset += width * height * depth;
                width = Math.Max(width >> 1, align);
                height = Math.Max(height >> 1, align);
                depth = Math.Max(depth >> 1, align);
            }

            return bitsPerPixel * (offset + x + y * width + z * width * height) / 8;
        }

        public static int GetTextureCubemapOffset(Image bitmap, int x, int y, int z, int mipmapIndex)
        {
            int width = bitmap.Width;
            int align = bitmap.Flags.HasFlag(BitmapFlags.Compressed) ? 4 : 1;
            int bitsPerPixel = BitmapFormatUtils.GetBitsPerPixel(bitmap.Format);

            int offset = 0;
            for (int i = 0; i < mipmapIndex; i++)
            {
                offset += 6 * width * width;
                width = Math.Max(width >> 1, align);
            }

            return (offset + x + y * width + z * width * width) * bitsPerPixel / 8;
        }

        public static int GetTextureArrayOffset(Image bitmap, int x, int y, int z, int mipmapIndex)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int align = bitmap.Flags.HasFlag(BitmapFlags.Compressed) ? 4 : 1;
            int bitsPerPixel = BitmapFormatUtils.GetBitsPerPixel(bitmap.Format);

            int layerOffset = 0;
            int mipOffset = 0;

            for (int i = 0; i <= bitmap.MipmapCount; i++)
            {
                if (i == mipmapIndex)
                    mipOffset = layerOffset;
                layerOffset += width * height;
                width = Math.Max(width >> 1, align);
                height = Math.Max(height >> 1, align);
            }

            return (layerOffset * z + mipOffset + y * width + x) * bitsPerPixel / 8;
        }

        public static int GetMipmapWidth(Image bitmap, int mipmapIndex)
        {
            int width = Math.Max(bitmap.Width >> mipmapIndex, 1);
            if (bitmap.Flags.HasFlag(BitmapFlags.Compressed))
                width = width + (4 - (width & 3) & 3);
            return width;
        }

        public static int GetMipmapHeight(Image bitmap, int mipmapIndex)
        {
            int height = Math.Max(bitmap.Height >> mipmapIndex, 1);
            if (bitmap.Flags.HasFlag(BitmapFlags.Compressed))
                height = height + (4 - (height & 3) & 3);
            return height;
        }

        public static int GetMipmapDepth(Image bitmap, int mipmapIndex)
        {
            return Math.Max(bitmap.Depth >> mipmapIndex, 1);
        }

        public static int GetMipmapPixelCount(Image bitmap, int mipmapIndex)
        {
            int width = GetMipmapWidth(bitmap, mipmapIndex);
            int height = GetMipmapHeight(bitmap, mipmapIndex);
            int depth = GetMipmapDepth(bitmap, mipmapIndex);
            int pixelCount = width * height * depth;
            if (bitmap.Type == BitmapType.CubeMap)
                pixelCount *= 6;

            return pixelCount;
        }

        public static int GetMipmapPixelCount(Image bitmap, int layerIndex, int mipmapIndex)
        {
            int width = GetMipmapWidth(bitmap, mipmapIndex);
            int height = GetMipmapHeight(bitmap, mipmapIndex);
            int depth = GetMipmapDepth(bitmap, mipmapIndex);
            int pixelCount = width * height;
            return pixelCount;
        }

        public static int GetMipmapPixelDataSize(Image bitmap, int layerIndex, int mipmapIndex)
        {
            int bitsPerPixel = BitmapFormatUtils.GetBitsPerPixel(bitmap.Format);
            return GetMipmapPixelCount(bitmap, layerIndex, mipmapIndex) * bitsPerPixel / 8;
        }

        public static int GetPixelCount(Image bitmap)
        {
            int pixelCount = 0;
            for (int i = 0; i < bitmap.MipmapCount; i++)
                pixelCount += GetMipmapPixelCount(bitmap, i);
            return pixelCount;
        }

        public static byte[] GetBitmapLevelData(BitmapTextureInteropResource.BitmapDefinition definition, Bitmap bitmap, int imageIndex, int level, int layerIndex)
        {
            byte[] primaryData = definition.PrimaryResourceData.Data;
            byte[] secondaryData = definition.SecondaryResourceData.Data;

            var pixelDataOffset = GetMipmapOffset(bitmap.Images[imageIndex], layerIndex, level);
            var pixelDataSize = GetMipmapPixelDataSize(bitmap.Images[imageIndex], layerIndex, level);

            byte[] pixelData = new byte[pixelDataSize];
            if (level == 0 && definition.Bitmap.HighResInSecondaryResource > 0 || primaryData == null)
            {
                Array.Copy(secondaryData, pixelDataOffset, pixelData, 0, pixelData.Length);
            }
            else
            {
                if (secondaryData != null)
                    pixelDataOffset -= secondaryData.Length;
                Array.Copy(primaryData, pixelDataOffset, pixelData, 0, pixelDataSize);
            }
            return pixelData;
        }
    }
}
