using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Bitmaps;
using TagTool.Bitmaps.Utils;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Common;

namespace TagTool.Commands.Mod
{
    internal class OptimizeBitmapsCommand : Command
    {
        private GameCache Cache { get; }

        public OptimizeBitmapsCommand(GameCache cache)
            : base(true,
                   "OptimizeBitmaps",
                   "Trims, converts, and unlinks unused bitmap resources to get as most resource as possible.",
                   "OptimizeBitmaps [bitmaps] [normalmaps] [lightmaps] [cutmips] [ccmaps] [skips...]",
                   "- bitmaps: convert A8R8G8B8 format to DXT5. (Highly recommended).\n" +
                   "- normalmaps: convert DXN normals to DXT1 (Recommended, please filter detailed normal maps).\n" +
                   "- cutmips: truncate all chains to 3 mips (Not recommended in any case).\n" +
                   "- lightmaps: removes useless mip levels on lightmaps (Highly recommended for ported MCC maps).\n" +
                   "- ccmaps: for textures ending with _cc or _color, if they are DXT5 but have no alpha, convert to DXT1.\n" +
                   "- skips: just write anything; if a bitmaps contains it, it will be skipped.")
        {
            Cache = cache;
        }

        private static bool IsPowerOfTwo(int x) => x >= 2 && (x & (x - 1)) == 0;

        public override object Execute(List<string> args)
        {
            bool convA8 = args.Any(a => a.Equals("bitmaps", StringComparison.OrdinalIgnoreCase));
            bool convDxn = args.Any(a => a.Equals("normalmaps", StringComparison.OrdinalIgnoreCase));
            bool trim3 = args.Any(a => a.Equals("cutmips", StringComparison.OrdinalIgnoreCase));
            bool doLight = args.Any(a => a.Equals("lightmaps", StringComparison.OrdinalIgnoreCase));
            bool convCC = args.Any(a => a.Equals("ccmaps", StringComparison.OrdinalIgnoreCase));

            // Include "ccmaps" so it does not end up in the skips list
            var flags = new[] { "bitmaps", "normalmaps", "cutmips", "lightmaps", "ccmaps" };
            var skips = args
                .Where(a => !flags.Contains(a.ToLowerInvariant()))
                .Select(a => a.ToLowerInvariant())
                .ToList();

            var tags = Cache.TagCache.TagTable
                .OfType<CachedTagHaloOnline>()
                .Where(t => !t.IsEmpty() && t.Group.ToString().Equals("bitmap", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var tag in tags)
            {
                var name = tag.Name ?? tag.ToString();
                var lower = name.ToLowerInvariant();

                if (skips.Any(s => lower.Contains(s))
                    || lower.Contains("cubemap")
                    || lower.Contains("chud")
                    || (lower.Contains("lightmap") && !doLight))
                {
                    Console.WriteLine($"Skipping tag: {name}");
                    continue;
                }

                Console.WriteLine($"Processing tag: {name}");
                Bitmap bmp;
                using (var rs = Cache.OpenCacheRead())
                    bmp = Cache.Deserialize(rs, tag) as Bitmap;

                if (bmp == null)
                {
                    Console.WriteLine($"Skipping non-bitmap: {name}");
                    continue;
                }

                var newList = new List<TagResourceReference>();
                bool isLightTag = lower.Contains("lightmap");
                bool isCCCandidate = convCC && (lower.EndsWith("_cc") || lower.EndsWith("_color"));

                // Loop through each image in the bitmap
                for (int i = 0; i < bmp.Images.Count; i++)
                {
                    try
                    {
                        var img = bmp.Images[i];
                        var oldRef = bmp.HardwareTextures[i];
                        var res = Cache.ResourceCache.GetBitmapTextureInteropResource(oldRef);
                        var data = res.Texture.Definition.PrimaryResourceData.Data
                                   ?? res.Texture.Definition.SecondaryResourceData.Data
                                   ?? Array.Empty<byte>();

                        int levels = img.MipmapCount + 1;
                        bool isSmallDetail = img.Width <= 512 && img.Height <= 512;

                        if (doLight && isLightTag)
                        {
                            Console.WriteLine($"Lightmap trim for {name}[{i}]");
                            levels = 1;
                        }
                        else if (trim3)
                        {
                            if (!isSmallDetail && levels > 3)
                            {
                                Console.WriteLine($"Trimming to 3 mips: {name}[{i}]");
                                levels = 3;
                            }
                        }

                        BitmapFormat currentFormat = img.Format;
                        bool a8 = currentFormat == BitmapFormat.A8R8G8B8;
                        bool dxn = currentFormat == BitmapFormat.Dxn;
                        bool dxt5 = currentFormat == BitmapFormat.Dxt5;

                        bool doA8 = convA8 && a8 && IsPowerOfTwo(img.Width) && IsPowerOfTwo(img.Height);
                        bool doDXN = convDxn && dxn;

                        // ----- Begin CCMaps logic -----
                        if (isCCCandidate && dxt5)
                        {
                            // Compute size of top-level DXT5 block
                            int w0 = img.Width;
                            int h0 = img.Height;
                            int topLevelSize = ((w0 + 3) / 4) * ((h0 + 3) / 4) * 16; // 16 bytes per block for DXT5

                            if (data.Length >= topLevelSize)
                            {
                                // Decode the very first mip into raw RGBA to inspect the alpha channel
                                var topSlice = new byte[topLevelSize];
                                Array.Copy(data, 0, topSlice, 0, topLevelSize);
                                byte[] rawRGBA = BitmapDecoder.DecodeBitmap(topSlice, BitmapFormat.Dxt5, w0, h0);

                                bool hasAnyAlpha = false;
                                for (int px = 3; px < rawRGBA.Length; px += 4)
                                {
                                    if (rawRGBA[px] != 0xFF)
                                    {
                                        hasAnyAlpha = true;
                                        break;
                                    }
                                }

                                if (!hasAnyAlpha)
                                {
                                    // No alpha usage: re-encode ALL levels to DXT1
                                    Console.WriteLine($"CCMap has no alpha, converting to DXT1: {name}[{i}] levels={levels}");
                                    int offset = 0;
                                    var outM = new List<byte[]>();

                                    for (int lvl = 0; lvl < levels; lvl++)
                                    {
                                        int w = Math.Max(1, img.Width >> lvl);
                                        int h = Math.Max(1, img.Height >> lvl);
                                        int blockSize = ((w + 3) / 4) * ((h + 3) / 4) * 16; // still 16 for DXT5 blocks

                                        if (offset + blockSize > data.Length)
                                            break;

                                        // Decode this mip from DXT5 to raw RGBA
                                        var sliceDxt5 = new byte[blockSize];
                                        Array.Copy(data, offset, sliceDxt5, 0, blockSize);
                                        byte[] rawMip = BitmapDecoder.DecodeBitmap(sliceDxt5, BitmapFormat.Dxt5, w, h);

                                        // Re-encode to DXT1
                                        outM.Add(BitmapDecoder.EncodeBitmap(rawMip, BitmapFormat.Dxt1, w, h));

                                        offset += blockSize;
                                    }

                                    if (outM.Count > 0)
                                    {
                                        var all = outM.SelectMany(b => b).ToArray();
                                        var nb = new BaseBitmap(img)
                                        {
                                            Format = BitmapFormat.Dxt1,
                                            Data = all,
                                            MipMapCount = outM.Count - 1
                                        };
                                        nb.UpdateFormat(BitmapFormat.Dxt1);
                                        BitmapUtils.SetBitmapImageData(nb, img);
                                        var nr = BitmapUtils.CreateBitmapTextureInteropResource(nb);
                                        newList.Add(Cache.ResourceCache.CreateBitmapResource(nr));
                                    }
                                    else
                                    {
                                        // Fallback: if something went wrong, keep original
                                        Console.WriteLine($"[Warning] No valid mips to re-encode, keeping original: {name}[{i}]");
                                        newList.Add(oldRef);
                                    }

                                    // Move to next image
                                    continue;
                                }
                                // If it does have alpha, we fall back and do nothing special for CCMaps
                            }
                            else
                            {
                                Console.WriteLine($"[Warning] Data length too small to inspect alpha: {name}[{i}]");
                            }
                        }
                        // ----- End CCMaps logic -----

                        // If not handled by CCMaps, proceed with existing logic
                        if (doA8 || doDXN)
                        {
                            var dst = doDXN ? BitmapFormat.Dxt1 : BitmapFormat.Dxt5;
                            Console.WriteLine($"Converting {name}[{i}] to {dst}, levels={levels}");
                            int offsetConv = 0;
                            var outM = new List<byte[]>();

                            for (int lvl = 0; lvl < levels; lvl++)
                            {
                                int w = Math.Max(1, img.Width >> lvl);
                                int h = Math.Max(1, img.Height >> lvl);

                                int sz = dxn
                                    ? ((w + 3) / 4) * ((h + 3) / 4) * 16
                                    : 4 * w * h;
                                if (offsetConv + sz > data.Length)
                                    break;

                                var slice = new byte[sz];
                                Array.Copy(data, offsetConv, slice, 0, sz);
                                offsetConv += sz;

                                if (dxn)
                                {
                                    var raw = BitmapDecoder.DecodeBitmap(slice, BitmapFormat.Dxn, w, h);
                                    outM.Add(BitmapDecoder.EncodeBitmap(raw, dst, w, h));
                                }
                                else
                                {
                                    outM.Add(BitmapDecoder.EncodeBitmap(slice, dst, w, h));
                                }
                            }

                            if (outM.Count == 0)
                            {
                                Console.WriteLine($"No valid mips, keeping original: {name}[{i}]");
                                newList.Add(oldRef);
                            }
                            else
                            {
                                var all = outM.SelectMany(b => b).ToArray();
                                var nb = new BaseBitmap(img)
                                {
                                    Format = dst,
                                    Data = all,
                                    MipMapCount = outM.Count - 1
                                };
                                nb.UpdateFormat(dst);
                                BitmapUtils.SetBitmapImageData(nb, img);
                                var nr = BitmapUtils.CreateBitmapTextureInteropResource(nb);
                                newList.Add(Cache.ResourceCache.CreateBitmapResource(nr));
                            }
                        }
                        else
                        {
                            // Mip-cutting or keep original
                            if (!isSmallDetail && levels != img.MipmapCount + 1)
                            {
                                Console.WriteLine($"Applying cut-only: {name}[{i}] levels={levels}");
                                int total = 0;
                                for (int l = 0; l < levels; l++)
                                {
                                    int w = Math.Max(1, img.Width >> l);
                                    int h = Math.Max(1, img.Height >> l);
                                    total += (dxn ? 16 * ((w + 3) / 4) * ((h + 3) / 4) : (4 * w * h));
                                }
                                var len = Math.Min(total, data.Length);
                                var cut = new byte[len];
                                Array.Copy(data, 0, cut, 0, len);
                                var cb = new BaseBitmap(img)
                                {
                                    Format = img.Format,
                                    Data = cut,
                                    MipMapCount = levels - 1
                                };
                                cb.UpdateFormat(img.Format);
                                BitmapUtils.SetBitmapImageData(cb, img);
                                var cr = BitmapUtils.CreateBitmapTextureInteropResource(cb);
                                newList.Add(Cache.ResourceCache.CreateBitmapResource(cr));
                            }
                            else
                            {
                                newList.Add(oldRef);
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        // Skip this image if indices are out of range
                        Console.WriteLine($"Skipping image {name}[{i}] due to ArgumentOutOfRange: {ex.Message}");
                        continue;
                    }
                }

                // Write back textures
                bmp.HardwareTextures = newList;
                bmp.InterleavedHardwareTextures.Clear();
                using (var ws = Cache.OpenCacheReadWrite())
                    Cache.Serialize(ws, tag, bmp);
            }

            Console.WriteLine("Done optimizing bitmaps.");
            return true;
        }
    }
}
