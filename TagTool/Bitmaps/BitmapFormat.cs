using System;
using TagTool.Tags;

namespace TagTool.Bitmaps
{
    /// <summary>
    /// Bitmap data formats.
    /// </summary>
    [TagEnum(IsVersioned = true)]
    public enum BitmapFormat
    {
        A8,
        Y8,
        AY8,
        A8Y8,
        R8,
        Unused2,
        R5G6B5,
        Unused3,
        A1R5G5B5,
        A4R4G4B4,
        X8R8G8B8,
        A8R8G8B8,
        Unused4,
        Dxt5nm,
        Dxt1,
        Dxt3,
        Dxt5,
        A4R4G4B4Font,
        Unused7,
        Unused8,
        SoftwareRgbfp32,
        Unused9,
        V8U8,
        G8B8,
        Abgrfp32,
        Abgrfp16,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        F16Mono,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        F16Red,
        Q8W8V8U8,
        A2R10G10B10,
        A16B16G16R16,
        V16U16,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        L16,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        R16G16,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        SignedR16G16B16A16,
        Dxt3a,
        Dxt5a,
        Dxt3A1111,
        Dxn,
        Ctx1,
        Dxt3aAlpha,
        Dxt3aMono,
        Dxt5aAlpha,
        Dxt5aMono,
        DxnMonoAlpha,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        Dxt5Red,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        Dxt5Green,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        Dxt5Blue,
        [TagEnumMember(MinVersion = Cache.CacheVersion.HaloReach)]
        Depth24,
    }

    public static class BitmapFormatUtils
    {

       private static readonly int[] BitsPerPixelTable = new int[]
       {
            8,   // A8
            8,   // Y8
            8,   // AY8
            16,  // A8Y8
            8,   // R8
            0,   // Unused2
            16,  // R5G6B5
            0,   // Unused3
            16,  // A1R5G5B5
            16,  // A4R4G4B4
            32,  // X8R8G8B8
            32,  // A8R8G8B8
            0,   // Unused4
            8,   // Dxt5nm
            4,   // Dxt1
            8,   // Dxt3
            8,   // Dxt5
            16,  // A4R4G4B4Font
            0,   // Unused7
            128, // Unused8
            96,  // SoftwareRgbfp32
            48,  // Unused9
            16,  // V8U8
            16,  // G8B8
            128, // Abgrfp32
            64,  // Abgrfp16
            16,  // F16Mono
            16,  // F16Red
            32,  // Q8W8V8U8
            32,  // A2R10G10B10
            64,  // A16B16G16R16
            32,  // V16U16
            16,  // L16
            32,  // R16G16
            64,  // SignedR16G16B16A16
            4,   // Dxt3A
            4,   // Dxt5A
            4,   // Dxt3A1111
            8,   // Dxn
            4,   // Ctx1
            4,   // Dxt3AAlpha
            4,   // Dxt3AMono
            4,   // Dxt5AAlpha
            4,   // Dxt5AMono
            8,   // DxnMonoAlpha
            8,   // Dxt5Red
            8,   // Dxt5Green
            8,   // Dxt5Blue
            32   // Depth24
       };

        /// <summary>
        /// Get the number of bits per pixel of a bitmap format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static int GetBitsPerPixel(BitmapFormat format)
        {
            return BitsPerPixelTable[(int)format];
        }

        /// <summary>
        /// Get the size in bytes of a block compressed format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static int GetBlockSize(BitmapFormat format)
        {
            int blockSize = 0;
            switch (format)
            {
                case BitmapFormat.Dxt1:
                case BitmapFormat.Dxt3a:
                case BitmapFormat.Dxt3aMono:
                case BitmapFormat.Dxt3aAlpha:
                case BitmapFormat.Dxt3A1111:
                case BitmapFormat.Dxt5a:
                case BitmapFormat.Dxt5aAlpha:
                case BitmapFormat.Dxt5aMono:
                case BitmapFormat.Ctx1:
                    blockSize = 8;
                    break;
                case BitmapFormat.Dxt3:
                case BitmapFormat.Dxt5:
                case BitmapFormat.Dxt5nm:
                case BitmapFormat.Dxn:
                case BitmapFormat.DxnMonoAlpha:
                    blockSize = 16;
                    break;
                default:
                    blockSize = -1;
                    break;
            }
            return blockSize;
        }

        /// <summary>
        /// Get the dimension of a block in block compressed formats.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static int GetBlockDimension(BitmapFormat format)
        {
            return BitmapUtils.IsCompressedFormat(format) ? 4 : 1;
        }
    }
}
