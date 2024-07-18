using System;
using System.Diagnostics;
using System.IO;
using TagTool.Bitmaps.DDS;
using TagTool.Commands;
using TagTool.IO;

namespace TagTool.Bitmaps.Utils
{
    public static class BitmapUtilsLegacy
    {
        [Obsolete("Use the MipMapGenerator instead")]
        public static void GenerateMipMaps(BaseBitmap bitmap)
        {
            switch (bitmap.Format)
            {
                case BitmapFormat.Dxt1:
                case BitmapFormat.Dxt3:
                case BitmapFormat.Dxt5:
                case BitmapFormat.Dxn:
                    GenerateCompressedMipMaps(bitmap);
                    break;
                case BitmapFormat.A8Y8:
                case BitmapFormat.L16:
                case BitmapFormat.Y8:
                case BitmapFormat.A8:
                case BitmapFormat.A8R8G8B8:
                case BitmapFormat.V8U8:
                case BitmapFormat.V16U16:
                case BitmapFormat.X8R8G8B8:
                    GenerateUncompressedMipMaps(bitmap);
                    break;

                case BitmapFormat.A4R4G4B4:
                case BitmapFormat.R5G6B5:
                case BitmapFormat.Abgrfp16:
                case BitmapFormat.Abgrfp32:
                    bitmap.MipMapCount = 1;
                    break;
                default:
                    throw new Exception($"Unsupported format for mipmap generation {bitmap.Format}");

            }
        }
       
        [Obsolete("Use MipmapGenerator instead")]
        public static void GenerateCompressedMipMaps(BaseBitmap bitmap)
        {
            string tempBitmap = $@"Temp\{Guid.NewGuid().ToString()}.dds";

            if (!Directory.Exists(@"Temp"))
                Directory.CreateDirectory(@"Temp");

            //Write input dds
            bitmap.MipMapCount = 0;
            var header = new DDSHeader(bitmap);


            using (var outStream = File.Open(tempBitmap, FileMode.Create, FileAccess.Write))
            {
                header.Write(new EndianWriter(outStream));
                var dataStream = new MemoryStream(bitmap.Data);
                StreamUtil.Copy(dataStream, outStream, bitmap.Data.Length);
            }

            string args = " ";

            switch (bitmap.Format)
            {
                case BitmapFormat.Dxn:
                    args += "-bc5 -resize -normal -tonormal";
                    break;

                case BitmapFormat.Dxt1:
                    args += "-bc1 ";
                    break;
                case BitmapFormat.Dxt3:
                    args += "-bc2 ";
                    break;
                case BitmapFormat.Dxt5:
                    args += "-bc3 ";
                    break;

                default:
                    bitmap.MipMapCount = 1;
                    if (File.Exists(tempBitmap))
                        File.Delete(tempBitmap);
                    return;
            }

            args += $"{tempBitmap} {tempBitmap}";

            ProcessStartInfo info = new ProcessStartInfo($@"{Program.TagToolDirectory}\Tools\nvcompress.exe")
            {
                Arguments = args,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardError = false,
                RedirectStandardOutput = false,
                RedirectStandardInput = false
            };
            Process nvcompress = Process.Start(info);
            nvcompress.WaitForExit();

            using (var ddsStream = File.OpenRead(tempBitmap))
            {
                header.Read(new EndianReader(ddsStream));
                var dataSize = (int)(ddsStream.Length - ddsStream.Position);

                bitmap.Width = header.Width;
                bitmap.Height = header.Height;
                bitmap.Data = new byte[dataSize];
                bitmap.MipMapCount = Math.Max(1, header.MipMapCount - 1);
                ddsStream.Read(bitmap.Data, 0, dataSize);

                // Remove lowest DXN mipmaps to prevent issues with D3D memory allocation.
                if (bitmap.Format == BitmapFormat.Dxn)
                    TrimLowestMipmaps(bitmap);
            }

            if (File.Exists(tempBitmap))
                File.Delete(tempBitmap);
        }

        [Obsolete("Use MipMapGeneraor instead")]
        private static void GenerateUncompressedMipMaps(BaseBitmap bitmap)
        {
            int channelCount;
            switch (bitmap.Format)
            {

                case BitmapFormat.A8Y8:
                case BitmapFormat.V8U8:
                case BitmapFormat.V16U16:
                    channelCount = 2;
                    break;
                case BitmapFormat.Y8:
                case BitmapFormat.A8:
                case BitmapFormat.L16:
                    channelCount = 1;
                    break;
                case BitmapFormat.A8R8G8B8:
                case BitmapFormat.X8R8G8B8:
                    channelCount = 4;
                    break;
                default:
                    bitmap.MipMapCount = 1;
                    return;

            }
            MipMapGenerator generator = new MipMapGenerator();
            generator.GenerateMipMap(bitmap.Height, bitmap.Width, bitmap.Data, channelCount);
            bitmap.MipMapCount = generator.MipMaps.Count;
            bitmap.Data = generator.CombineImage(bitmap.Data);
            return;
        }

        public static void TrimLowestMipmaps(BaseBitmap resultBitmap)
        {
            int dataSize = 0;
            int mipMapCount;
            int width = resultBitmap.Width;
            int height = resultBitmap.Height;
            for (mipMapCount = 0; mipMapCount < resultBitmap.MipMapCount; mipMapCount++)
            {
                if (width < 4 || height < 4)
                    break;

                dataSize += BitmapUtils.RoundSize(width, 4) * BitmapUtils.RoundSize(height, 4);
                width /= 2;
                height /= 2;
            }

            resultBitmap.MipMapCount = mipMapCount;
            byte[] raw = new byte[dataSize];
            Array.Copy(resultBitmap.Data, raw, dataSize);
            resultBitmap.Data = raw;
        }

        [Obsolete("Use BitmapDecoder.EncodeBitmap instead")]
        public static byte[] EncodeDXN(byte[] rgba, int width, int height, out int mipCount, bool generateMips = false, bool resize = false)
        {
            string tempBitmap = $@"Temp\{Guid.NewGuid().ToString()}.dds";

            if (!Directory.Exists(@"Temp"))
                Directory.CreateDirectory(@"Temp");

            try
            {
                var ddsFile = new DDSFile(new DDSHeader((uint)width, (uint)height, 1, 1, BitmapFormat.A8R8G8B8, BitmapType.Texture2D), rgba);
                using (var writer = new EndianWriter(File.Create(tempBitmap)))
                    ddsFile.Write(writer);

                ProcessStartInfo info = new ProcessStartInfo($@"{Program.TagToolDirectory}\Tools\nvcompress.exe")
                {
                    Arguments = $"-bc5 -normal -tonormal {(generateMips ? "" : "-nomips")} {(!resize ? "" : "-resize")} {tempBitmap} {tempBitmap}",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardError = false,
                    RedirectStandardOutput = false,
                    RedirectStandardInput = false
                };
                Process nvcompress = Process.Start(info);
                nvcompress.WaitForExit();

                using (var reader = new EndianReader(File.OpenRead(tempBitmap)))
                {
                    ddsFile = new DDSFile();
                    ddsFile.Read(reader);
                    mipCount = ddsFile.Header.MipMapCount;
                    return ddsFile.BitmapData;
                }
            }
            finally
            {
                if (File.Exists(tempBitmap))
                    File.Delete(tempBitmap);
            }
        }
    }
}
