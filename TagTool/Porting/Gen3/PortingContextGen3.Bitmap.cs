using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Bitmaps;
using TagTool.Bitmaps.Utils;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        class BitmapConversionResult
        {
            public Bitmap Definition;
            public List<BaseBitmap> BaseBitmaps;
        }

        public void WaitForPendingBitmapConversion()
        {
            WaitForPendingTasks();
            ProcessDeferredActions();
        }

        private Bitmap ConvertBitmapAsync(Stream cacheStream, CachedTag edTag, CachedTag blamTag, Bitmap bitmap)
        {
            bitmap.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;
            bitmap.UnknownB4 = 0;

            if (BlamCache.Version >= CacheVersion.HaloReach)
            {
                switch (bitmap.Usage)
                {
                    case Bitmap.BitmapUsageGlobalEnum.NormalMapAkaZbump:
                    case Bitmap.BitmapUsageGlobalEnum.DetailZbrushBumpMap:
                    case Bitmap.BitmapUsageGlobalEnum.DetailNormalMap:
                        bitmap.Usage = Bitmap.BitmapUsageGlobalEnum.ZBrushBumpMapfromBumpMap;
                        break;
                    case Bitmap.BitmapUsageGlobalEnum.MaterialMap:
                    case Bitmap.BitmapUsageGlobalEnum.SmokeWarp:
                    case Bitmap.BitmapUsageGlobalEnum.CubemapGel:
                    case Bitmap.BitmapUsageGlobalEnum.LensFlareGamma22EffectsOnly:
                    case Bitmap.BitmapUsageGlobalEnum.SignedNoise:
                    case Bitmap.BitmapUsageGlobalEnum.RoughnessMapAuto:
                        bitmap.Usage = Bitmap.BitmapUsageGlobalEnum.DiffuseMap;
                        break;
                }
            }

            RunAsync(
                onExecute: () =>
                {
                    BitmapConversionResult result = new BitmapConversionResult();
                    result.Definition = bitmap;
                    result.BaseBitmaps = new List<BaseBitmap>();

                    for (int i = 0; i < bitmap.Images.Count; i++)
                        result.BaseBitmaps.Add(ConvertBitmapAsync(bitmap, i, blamTag.Name));

                    return result;
                },
                onSuccess: (BitmapConversionResult result) =>
                {
                    bitmap = FinishConvertBitmap(bitmap, result, blamTag.Name);
                    CacheContext.Serialize(cacheStream, edTag, bitmap);

                    if (FlagIsSet(PortingFlags.Print))
                        Console.WriteLine($"['{edTag.Group.Tag}', 0x{edTag.Index:X4}] {edTag.Name}.{(edTag.Group as TagGroupGen3).Name}");
                });

            return bitmap;
        }

        private BaseBitmap ConvertBitmapAsync(Bitmap bitmap, int imageIndex, string tagName)
        {
            var bitmapConverter = new BitmapConverterGen3(BlamCache)
            {
                ForceDxt5nm = Options.UseExperimentalDxt5nm,
                HqNormalMapCompression = Options.HqNormalMapConversion
            };
            return bitmapConverter.ConvertBitmap(bitmap, imageIndex, tagName);
        }

        private Bitmap FinishConvertBitmap(Bitmap bitmap, BitmapConversionResult result, string tagName)
        {
            List<TagResourceReference> resources = new List<TagResourceReference>();
            for (int i = 0; i < result.BaseBitmaps.Count; i++)
            {
                BitmapUtils.SetBitmapImageData(result.BaseBitmaps[i], bitmap.Images[i]);
                var bitmapResourceDefinition = BitmapUtils.CreateBitmapTextureInteropResource(result.BaseBitmaps[i]);
                var resourceReference = CacheContext.ResourceCache.CreateBitmapResource(bitmapResourceDefinition);
                resources.Add(resourceReference);
            }
            bitmap.HardwareTextures = resources;

            //fixup for HO expecting 6 sequences in sensor_blips bitmap
            if (tagName == "ui\\chud\\bitmaps\\sensor_blips")
            {
                bitmap.Sequences.Add(bitmap.Sequences[3]);
                bitmap.Sequences.Add(bitmap.Sequences[3]);
            }

            return bitmap;
        }
    }
}