using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Bitmaps;
using TagTool.Tags.Definitions;
using TagTool.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Bitmaps;
using TagTool.Tags.Definitions;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Tags;
using TagTool.Bitmaps.DDS;
using TagTool.IO;
using System.Linq;
using TagTool.Bitmaps.Utils;

namespace TagTool.Commands.Tags
{
	class GenerateBitmapCommand : Command
	{
		public GameCacheHaloOnlineBase Cache { get; }
		public object TagDefinition { get; private set; }

        public GenerateBitmapCommand(GameCacheHaloOnlineBase cache)
			: base(true,

                  "GenerateBitmap",
                  "Creates a new bitm tag with a specified name from a DDS image.",

                  "GenerateBitmap [flags] <name or prefix> <path> [curve] [conversion] [mipCount|-1]",

                  "Creates bitm tag(s) with a specified name from DDS image(s) at the provided path."
                  + "\nIf <path> is a folder, a tag for each DDS within is created as <prefix>\\filename."
                  + "\nAny flags should be separated with commas (e.g. a,b,c)."
                  + "\nOptional curve (linear, sRGB, gamma2, xRGB), conversion (DXT1, DXT5, DXN), and mip count (0–16)."
                  + "\nIf no mipCount is provided, uses the DDS's own mips."
                  + "\nIf mipCount = -1, generates full mip chain."

                  + "\n\nAvailable flags:"
                  + "\n\tsequence : imports all DDS with an integer prefix to the same tag as distinct images"
                  + "\n\talphaseq : same as above but added alphabetically"
                  + "\n\tlinear : sets the bitmap curve mode as Linear")
		{
			Cache = cache;
		}

        public override object Execute(List<string> args)
        {
            if (args.Count < 2)
                return new TagToolError(CommandError.ArgCount);

            int argIndex = 0;
            string imagePath = args[args.Count - 1];
            string tagname = args[args.Count - 2];
            string exMsg = null;

            bool batchImport = false;

            Tag groupTag = new Tag("bitm");

            // flags
            bool sequence = false;
            bool alphaseq = false;

            BitmapImageCurve curve = BitmapImageCurve.xRGB;
            string conversionArg = null;
            int? mipCountArg = null;

            if (args.Count > 2)
            {
                var flags = args[0].ToLower().Split(',');

                foreach (string flag in flags)
                {
                    switch(flag)
                    {
                        case "sequence":
                            sequence = true;
                            break;
                        case "alphaseq":
                            alphaseq = sequence = true;
                            break;
                        case "linear":
                            curve = BitmapImageCurve.Linear;
                            break;
                    }
                }

                if (flags.Length > 0 && !sequence && !alphaseq && curve != BitmapImageCurve.Linear)
                {
                    argIndex = 0;
                }
                else
                {
                    argIndex = 1;
                }
            }

            tagname = args[argIndex];
            imagePath = args[argIndex + 1];
            argIndex += 2;

            // Parse optional arguments
            for (int i = argIndex; i < args.Count; i++)
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
                        case "dxt5":
                        case "dxn":
                            conversionArg = a; break;
                        default:
                            Console.WriteLine($"Unrecognized argument '{args[i]}', ignoring.");
                            break;
                    }
                }
            }

            List<FileInfo> fileList = new List<FileInfo>();

            if (Directory.Exists(imagePath))
            {
                batchImport = true;
                var files = Directory.GetFiles(imagePath, "*.dds");

                if (files == null || files.Count() == 0 )
                    return new TagToolError(CommandError.CustomError, $"Directory \"{imagePath}\" contains no DDS files.");

                foreach (var file in files)
                {
                    fileList.Add(new FileInfo(file));
                }
            }
            else if (File.Exists(imagePath))
            {
                fileList.Add(new FileInfo(imagePath));
            }
            else
                return new TagToolError(CommandError.FileNotFound, $"\"{imagePath}\"");

            // image sequence import (e.g. numbers_plate)
            if (sequence)
            {
                CachedTag instance = null;
                instance = AllocateBitmTag(tagname, instance, groupTag);

                using (var stream = Cache.OpenCacheReadWrite())
                {
                    var imageIndex = 0;
                    var bitmap = Cache.Deserialize<Bitmap>(stream, instance);
                    bitmap.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;

                    if (!alphaseq)
                    {
                        while (true)
                        {
                            var currentFile = fileList.FirstOrDefault(f => f.Name.StartsWith(imageIndex.ToString()));
                            if (currentFile == null)
                            {
                                if (imageIndex == 0)
                                    return new TagToolError(CommandError.CustomError, "Sequence element 0 not found.");
                                else
                                    break;
                            }

                            PrepareTagAndImport(groupTag, currentFile, imageIndex, bitmap, curve, conversionArg, mipCountArg, ref exMsg);

                            if(exMsg != null)
                                return new TagToolError(CommandError.OperationFailed, "Importing image data failed: " + exMsg);

                            AddSequenceAndSprite(imageIndex, bitmap, currentFile.Name);

                            imageIndex++;
                        }
                    }
                    // importing a set of images as a sequence, but you don't care what order.
                    else
                    {
                        foreach (FileInfo file in fileList)
                        {
                            PrepareTagAndImport(groupTag, file, imageIndex, bitmap, curve, conversionArg, mipCountArg, ref exMsg);

                            if (exMsg != null)
                                return new TagToolError(CommandError.OperationFailed, "Importing image data failed: " + exMsg);

                            AddSequenceAndSprite(imageIndex, bitmap, file.Name);

                            imageIndex++;
                        }
                    }

                    Cache.Serialize(stream, instance, bitmap);
                }

                PrintSuccess(tagname, instance);
            }
            // standard or batch import
            else
            {
                foreach (FileInfo file in fileList)
                {
                    CachedTag instance = null;

                    if (batchImport)
                    {
                        tagname = args[argIndex - 2]; // reset to prefix

                        if (!tagname.EndsWith("\\"))
                            tagname += "\\";

                        tagname += file.Name.Split('.')[0];
                    }

                    instance = AllocateBitmTag(tagname, instance, groupTag);

                    using (var stream = Cache.OpenCacheReadWrite())
                    {
                        var bitmap = Cache.Deserialize<Bitmap>(stream, instance);
                        bitmap.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;
                        PrepareTagAndImport(groupTag, file, 0, bitmap, curve, conversionArg, mipCountArg, ref exMsg);

                        if (exMsg != null)
                            return new TagToolError(CommandError.OperationFailed, "Importing image data failed: " + exMsg);

                        Cache.Serialize(stream, instance, bitmap);
                    }

                    PrintSuccess(tagname, instance);
                }
            }

            return true;
		}



        private static void AddSequenceAndSprite(int imageIndex, Bitmap bitmap, string fileName)
        {
            bitmap.Sequences.Add(new Bitmap.Sequence
            {
                Name = fileName.Split('.')[0],
                BitmapCount = 1,
                Sprites = new List<Bitmap.Sequence.Sprite>
                {
                    new Bitmap.Sequence.Sprite
                    {
                        BitmapIndex = (short)imageIndex,
                        Right = 1,
                        Bottom = 1,
                        RegistrationPoint = new RealPoint2d(0.5f, 0.5f)
                    }
                }
            });
        }

        private void PrepareTagAndImport(Tag groupTag, FileInfo file, int imageIndex, Bitmap bitmap, BitmapImageCurve curve, string conversionArg, int? mipCountArg, ref string msg)
        {
            bitmap.Images.Add(new Bitmap.Image { Signature = groupTag });
            bitmap.HardwareTextures.Add(new TagResourceReference());

#if !DEBUG
			try
			{
#endif
            DDSFile dds = new DDSFile();

            using (var imageStream = File.OpenRead(file.FullName))
            using (var reader = new EndianReader(imageStream))
            {
                dds.Read(reader);
            }

                bool isNormal = file.Name.EndsWith("_zbump.dds", StringComparison.OrdinalIgnoreCase)
                             || file.Name.EndsWith("_normal.dds", StringComparison.OrdinalIgnoreCase)
                             || file.Name.EndsWith("_normals.dds", StringComparison.OrdinalIgnoreCase)
                             || file.Name.EndsWith("_bump.dds", StringComparison.OrdinalIgnoreCase)
                             || file.Name.EndsWith("_microbump.dds", StringComparison.OrdinalIgnoreCase)
                             || file.Name.EndsWith("_n.dds", StringComparison.OrdinalIgnoreCase);

                BitmapImageCurve local_curve = curve;
                if (isNormal) local_curve = BitmapImageCurve.Linear;

                int width = dds.Header.Width;
                int height = dds.Header.Height;
                int ddsMips = Math.Max(1, dds.Header.MipMapCount);

                // compute final mip count
                int maxMips = (int)Math.Floor(Math.Log(Math.Max(width, height), 2)) + 1;
                int finalMips;
                if (!mipCountArg.HasValue)
                    finalMips = ddsMips;
                else if (mipCountArg.Value < 0)
                    finalMips = maxMips;
                else
                {
                    finalMips = mipCountArg.Value;
                    if (finalMips == 0) finalMips = 1;
                }
                finalMips = Math.Min(finalMips, maxMips);

                uint fourcc = dds.Header.PixelFormat.FourCC;
                BitmapFormat srcFmt = fourcc switch
                {
                    0x31545844 => BitmapFormat.Dxt1,
                    0x33545844 => BitmapFormat.Dxt3,
                    0x35545844 => BitmapFormat.Dxt5,
                    0 => BitmapFormat.A8R8G8B8,
                    _ => throw new Exception("Unsupported DDS format: " + fourcc)
                };

                // Choose target format
                BitmapFormat dstFmt;
                if (conversionArg != null)
                {
                    dstFmt = conversionArg switch
                    {
                        "dxn" => BitmapFormat.Dxn,
                        "dxt5" => BitmapFormat.Dxt5,
                        _ => BitmapFormat.Dxt1
                    };
                }
                else if (isNormal)
                {
                    dstFmt = srcFmt switch
                    {
                        BitmapFormat.Dxt5 => BitmapFormat.Dxt5,
                        BitmapFormat.Dxt3 or BitmapFormat.Dxt1 => BitmapFormat.Dxt1,
                        BitmapFormat.A8R8G8B8 => BitmapFormat.Dxn,
                        _ => srcFmt
                    };
                }
                else
                {
                    dstFmt = srcFmt;
                }

                // decide if we need to rebuild mips / conversion
                bool rebuild = conversionArg != null || isNormal || mipCountArg.HasValue || dstFmt != srcFmt;

                if (!rebuild && finalMips == ddsMips)
                {
                    var bitmapTextureInteropDefinition = BitmapInjector.CreateBitmapResourceFromDDS(Cache, dds, local_curve);
                    var reference = Cache.ResourceCache.CreateBitmapResource(bitmapTextureInteropDefinition);

                    // set the tag data

                    bitmap.HardwareTextures[imageIndex] = reference;
                    bitmap.Images[imageIndex] = BitmapUtils.CreateBitmapImageFromResourceDefinition(bitmapTextureInteropDefinition.Texture.Definition.Bitmap);
                }
                else
                {
                    byte[] rawFile = File.ReadAllBytes(file.FullName);
                    const int hdr = 128;
                    int offset = hdr;
                    List<byte[]> rawMips = new List<byte[]>();
                    for (int lvl = 0; lvl < ddsMips; lvl++)
                    {
                        int w = Math.Max(1, width >> lvl);
                        int h = Math.Max(1, height >> lvl);
                        int sz = srcFmt == BitmapFormat.A8R8G8B8
                            ? 4 * w * h
                            : ((w + 3) / 4) * ((h + 3) / 4) * (srcFmt == BitmapFormat.Dxt1 ? 8 : 16);
                        if (offset + sz > rawFile.Length)
                            break;
                        byte[] slice = new byte[sz];
                        Array.Copy(rawFile, offset, slice, 0, sz);
                        offset += sz;
                        byte[] raw;
                        if (srcFmt == BitmapFormat.A8R8G8B8)
                        {
                            raw = slice;
                        }
                        else
                        {
                            raw = BitmapDecoder.DecodeBitmap(slice, srcFmt, w, h);
                        }
                        rawMips.Add(raw);
                    }
                    byte[] prevRaw = rawMips.Last();
                    int prevW = Math.Max(1, width >> (rawMips.Count - 1));
                    int prevH = Math.Max(1, height >> (rawMips.Count - 1));
                    for (int lvl = rawMips.Count; lvl < finalMips; lvl++)
                    {
                        int w = Math.Max(1, prevW >> 1);
                        int h = Math.Max(1, prevH >> 1);
                        byte[] thisRaw = GenerateMip(prevRaw, prevW, prevH, w, h);
                        rawMips.Add(thisRaw);
                        prevRaw = thisRaw;
                        prevW = w;
                        prevH = h;
                    }
                    if (rawMips.Count > finalMips)
                        rawMips = rawMips.GetRange(0, finalMips);
                    List<byte[]> encodedMips = new List<byte[]>();
                    for (int lvl = 0; lvl < finalMips; lvl++)
                    {
                        int w = Math.Max(1, width >> lvl);
                        int h = Math.Max(1, height >> lvl);
                        byte[] raw = rawMips[lvl];
                        if (dstFmt == BitmapFormat.A8R8G8B8)
                        {
                            encodedMips.Add(raw);
                        }
                        else
                        {
                            encodedMips.Add(BitmapDecoder.EncodeBitmap(raw, dstFmt, w, h));
                        }
                    }
                    byte[] allData = encodedMips.SelectMany(b => b).ToArray();
                    var baseBitmap = new BaseBitmap
                    {
                        Width = (short)width,
                        Height = (short)height,
                        Depth = 1,
                        Type = BitmapType.Texture2D,
                        Format = dstFmt,
                        Flags = BitmapFlags.None,
                        Curve = local_curve,
                        MipMapCount = (short)(finalMips),
                        Data = allData
                    };
                    baseBitmap.UpdateFormat(dstFmt);
                    var resource = BitmapUtils.CreateBitmapTextureInteropResource(baseBitmap);
                    var reference = Cache.ResourceCache.CreateBitmapResource(resource);
                    bitmap.HardwareTextures[imageIndex] = reference;
                    BitmapUtils.SetBitmapImageData(baseBitmap, bitmap.Images[imageIndex]);
                }

#if !DEBUG
			}
			catch (Exception ex)
			{
                msg = ex.Message;
			}
#endif
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
                        int ix = Math.Min(sx + ox, srcW - 1);
                        int iy = Math.Min(sy + oy, srcH - 1);
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

        private CachedTag AllocateBitmTag(string tagname, CachedTag instance, Tag groupTag)
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                if (instance == null)
                    instance = Cache.TagCache.AllocateTag(Cache.TagCache.TagDefinitions.GetTagGroupFromTag(groupTag), tagname);

                Cache.Serialize(stream, instance, Activator.CreateInstance(Cache.TagCache.TagDefinitions.GetTagDefinitionType(groupTag)));

                Cache.SaveTagNames();
            }

            return instance;
        }

        private static void PrintSuccess(string tagname, CachedTag instance)
        {
            Console.WriteLine("Image imported successfully.");
            var tagName = instance.Name ?? $"{tagname}";
            Console.WriteLine($"[Index: 0x{instance.Index:X4}] {tagname}.{instance.Group}");
        }
    }
}