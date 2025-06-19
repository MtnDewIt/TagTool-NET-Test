using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TagTool.Bitmaps;
using TagTool.Tags.Definitions;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Bitmaps.DDS;
using TagTool.Bitmaps.Utils;
using TagTool.IO;

namespace TagTool.Commands.Bitmaps
{
    class ImportBitmapCommand : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private Bitmap Bitmap { get; }

        public ImportBitmapCommand(GameCache cache, CachedTag tag, Bitmap bitmap)
            : base(false,
                   "ImportBitmap",
                   "Imports an image from a DDS file.",
                   "ImportBitmap <image index> <dds file> [curve] [conversion] [mipCount|-1]",
                   "The image index must be in hexadecimal.\n" +
                   "Optional curve (linear, sRGB, gamma2, xRGB), conversion (DXT1, DXN), and mip count (0–16).\n" +
                   "If no mipCount is provided, uses the DDS's own mips.\n" +
                   "If mipCount = -1, matches the original tag mip counts.")
        {
            Cache = cache;
            Tag = tag;
            Bitmap = bitmap;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 2 || args.Count > 5)
                return new TagToolError(CommandError.ArgCount);

            if (!int.TryParse(args[0], NumberStyles.Integer, null, out int imageIndex))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\"");

            // ensure at least one image slot
            if (Bitmap.Images.Count == 0)
            {
                Bitmap.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;
                Bitmap.Images.Add(new Bitmap.Image { Signature = new Tag("bitm") });
                Bitmap.HardwareTextures.Add(new TagResourceReference());
            }
            if (imageIndex < 0)
                return new TagToolError(CommandError.ArgInvalid, "Invalid image index");
            if (imageIndex >= Bitmap.Images.Count)
            {
                Bitmap.Images.Add(new Bitmap.Image { Signature = new Tag("bitm") });
                Bitmap.HardwareTextures.Add(new TagResourceReference());
                imageIndex = Bitmap.Images.Count - 1;
                new TagToolWarning($"Index out of range; new slot {imageIndex} created");
            }

            string imagePath = args[1];
            if (!File.Exists(imagePath))
                return new TagToolError(CommandError.FileNotFound, $"\"{imagePath}\"");

            // parse optional arguments
            BitmapImageCurve curve = BitmapImageCurve.xRGB;
            string conversionArg = null;
            int? mipCountArg = null;

            for (int i = 2; i < args.Count; i++)
            {
                var a = args[i].ToLowerInvariant();
                if (int.TryParse(a, out int m) && m >= -1 && m <= 16)
                    mipCountArg = m;
                else
                {
                    switch (a)
                    {
                        case "linear": curve = BitmapImageCurve.Linear; break;
                        case "srgb": curve = BitmapImageCurve.sRGB; break;
                        case "gamma2": curve = BitmapImageCurve.Gamma2; break;
                        case "xrgb": curve = BitmapImageCurve.xRGB; break;
                        case "dxt1":
                        case "dxn":
                            conversionArg = a; break;
                        default:
                            Console.WriteLine($"Unrecognized argument '{args[i]}', ignoring.");
                            break;
                    }
                }
            }

            // normal-map suffix forces linear
            bool isNormal = imagePath.EndsWith("_zbump.dds", StringComparison.OrdinalIgnoreCase)
                         || imagePath.EndsWith("_normal.dds", StringComparison.OrdinalIgnoreCase)
                         || imagePath.EndsWith("_normals.dds", StringComparison.OrdinalIgnoreCase)
                         || imagePath.EndsWith("_bump.dds", StringComparison.OrdinalIgnoreCase)
                         || imagePath.EndsWith("_microbump.dds", StringComparison.OrdinalIgnoreCase)
                         || imagePath.EndsWith("_n.dds", StringComparison.OrdinalIgnoreCase);
            if (isNormal) curve = BitmapImageCurve.Linear;

            Console.WriteLine("Importing image...");
            try
            {
                // read DDS
                DDSFile file;
                using (var fs = File.OpenRead(imagePath))
                using (var reader = new EndianReader(fs))
                {
                    file = new DDSFile();
                    file.Read(reader);
                }

                int width = file.Header.Width;
                int height = file.Header.Height;
                int ddsMips = Math.Max(1, file.Header.MipMapCount);

                // compute final mip count
                int finalMips;
                if (!mipCountArg.HasValue)
                    finalMips = ddsMips;
                else if (mipCountArg.Value < 0)
                    finalMips = Bitmap.Images[imageIndex].MipmapCount + 1;
                else
                {
                    finalMips = mipCountArg.Value;
                    if (finalMips == 0) finalMips = 1;
                }

                // create resource (handles all compressed / uncompressed automatically)
                var resource = BitmapInjector.CreateBitmapResourceFromDDS(Cache, file, curve);

                // decide if we need to rebuild mips / conversion
                bool rebuild = conversionArg != null || isNormal || mipCountArg.HasValue;
                if (rebuild)
                {
                    byte[] rawFile = File.ReadAllBytes(imagePath);
                    const int hdr = 128;

                    // detect source format, include uncompressed BGRA
                    uint fourcc = file.Header.PixelFormat.FourCC;
                    BitmapFormat srcFmt = fourcc switch
                    {
                        0x31545844 => BitmapFormat.Dxt1,
                        0x33545844 => BitmapFormat.Dxt3,
                        0x35545844 => BitmapFormat.Dxt5,
                        0 => BitmapFormat.A8R8G8B8,   // treat FourCC==0 as linear BGRA32
                        _ => throw new Exception("Unsupported DDS format: " + fourcc)
                    };

                    // choose target format
                    BitmapFormat dstFmt;
                        if (conversionArg != null)
                            {
                                // explicit override: DXT1 or DXN
                        dstFmt = (conversionArg == "dxn")
                                    ? BitmapFormat.Dxn
                                    : BitmapFormat.Dxt1;
                            }
                        else if (isNormal)
                            {
                                // only native DXT1 stays DXT1; all other normal sources → DXN
                        dstFmt = (srcFmt == BitmapFormat.Dxt1)
                                    ? BitmapFormat.Dxt1
                                    : BitmapFormat.Dxn;
                            }
                        else
                            {
                                // non‐normals: leave them exactly as they were
                        dstFmt = srcFmt;
                            }

                    // decode top mip
                    int blockSz = (srcFmt == BitmapFormat.Dxt1 ? 8 : 16);
                    if (srcFmt == BitmapFormat.A8R8G8B8) blockSz = 4 * width * height;
                    int topSz = srcFmt == BitmapFormat.A8R8G8B8
                        ? blockSz
                        : ((width + 3) / 4) * ((height + 3) / 4) * blockSz;
                    if (rawFile.Length - hdr < topSz)
                        throw new Exception("Incomplete DDS data for top mip");

                    byte[] topRaw;
                    if (srcFmt == BitmapFormat.A8R8G8B8)
                    {
                        // uncompressed: skip header
                        topRaw = new byte[width * height * 4];
                        Array.Copy(rawFile, hdr, topRaw, 0, topRaw.Length);
                    }
                    else
                    {
                        var cmp = new byte[topSz];
                        Array.Copy(rawFile, hdr, cmp, 0, topSz);
                        topRaw = BitmapDecoder.DecodeBitmap(cmp, srcFmt, width, height);
                    }

                    // build mip chain
                    var mips = new List<byte[]>();
                    byte[] prevRaw = topRaw;
                    int prevW = width, prevH = height;
                    for (int lvl = 0; lvl < finalMips; lvl++)
                    {
                        int w = (lvl == 0) ? prevW : Math.Max(1, prevW >> 1);
                        int h = (lvl == 0) ? prevH : Math.Max(1, prevH >> 1);
                        byte[] thisRaw = (lvl == 0) ? prevRaw : GenerateMip(prevRaw, prevW, prevH, w, h);
                        byte[] encoded = (dstFmt == BitmapFormat.A8R8G8B8)
                            ? thisRaw
                            : BitmapDecoder.EncodeBitmap(thisRaw, dstFmt, w, h);
                        mips.Add(encoded);
                        prevRaw = thisRaw;
                        prevW = w; prevH = h;
                    }

                    // concatenate
                    int total = 0;
                    foreach (var b in mips) total += b.Length;
                    var allData = new byte[total];
                    int pos = 0;
                    foreach (var b in mips)
                    {
                        Array.Copy(b, 0, allData, pos, b.Length);
                        pos += b.Length;
                    }

                    resource.Texture.Definition.PrimaryResourceData = new TagData(allData);
                    resource.Texture.Definition.Bitmap.Format = dstFmt;
                }

                resource.Texture.Definition.Bitmap.MipmapCount = (sbyte)finalMips;

                var reference = Cache.ResourceCache.CreateBitmapResource(resource);
                Bitmap.HardwareTextures[imageIndex] = reference;
                Bitmap.Images[imageIndex] = BitmapUtils
                    .CreateBitmapImageFromResourceDefinition(resource.Texture.Definition.Bitmap);

                using var ws = Cache.OpenCacheReadWrite();
                Cache.Serialize(ws, Tag, Bitmap);
            }
            catch (Exception ex)
            {
                return new TagToolError(CommandError.OperationFailed,
                    "Import failed: " + ex.Message);
            }

            Console.WriteLine("Done!");
            return true;
        }

        private static byte[] GenerateMip(byte[] src, int srcW, int srcH, int dstW, int dstH)
        {
            var dst = new byte[dstW * dstH * 4];
            for (int y = 0; y < dstH; y++)
                for (int x = 0; x < dstW; x++)
                {
                    int sx = x * 2, sy = y * 2;
                    int[] sum = new int[4];
                    for (int oy = 0; oy < 2; oy++) for (int ox = 0; ox < 2; ox++)
                        {
                            int ix = Math.Min(sx + ox, srcW - 1),
                                iy = Math.Min(sy + oy, srcH - 1);
                            int idx = (iy * srcW + ix) * 4;
                            sum[0] += src[idx]; sum[1] += src[idx + 1];
                            sum[2] += src[idx + 2]; sum[3] += src[idx + 3];
                        }
                    int di = (y * dstW + x) * 4;
                    dst[di] = (byte)(sum[0] >> 2);
                    dst[di + 1] = (byte)(sum[1] >> 2);
                    dst[di + 2] = (byte)(sum[2] >> 2);
                    dst[di + 3] = (byte)(sum[3] >> 2);
                }
            return dst;
        }
    }
}
