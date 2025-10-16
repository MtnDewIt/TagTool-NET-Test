using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
        private Bitmap ConvertBitmap(Stream cacheStream, CachedTag edTag, CachedTag blamTag, Bitmap bitmap)
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

            var tasks = new List<Task<BaseBitmap>>();
            for (int i = 0; i < bitmap.Images.Count; i++)
            {
                int imageIndex = i;
                tasks.Add(RunOnThreadPool(() => ConvertBitmapInternal(bitmap, imageIndex, blamTag.Name)));
            }

            AddTask(Task.WhenAll(tasks)
                .ContinueWith(task => FinishConvertBitmap(bitmap, blamTag.Name, task.GetAwaiter().GetResult()), MainThreadScheduler));

            return bitmap;
        }

        private Bitmap FinishConvertBitmap(Bitmap bitmap, string tagName, BaseBitmap[] convertedBitmaps)
        {
            var resources = new List<TagResourceReference>();
            for (int i = 0; i < convertedBitmaps.Length; i++)
            {
                BitmapUtils.SetBitmapImageData(convertedBitmaps[i], bitmap.Images[i]);
                var bitmapResourceDefinition = BitmapUtils.CreateBitmapTextureInteropResource(convertedBitmaps[i]);
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

        private BaseBitmap ConvertBitmapInternal(Bitmap bitmap, int imageIndex, string tagName)
        {
            var bitmapConverter = new BitmapConverterGen3(BlamCache)
            {
                ForceDxt5nm = Options.UseExperimentalDxt5nm,
                HqNormalMapCompression = Options.HqNormalMapConversion
            };
            return bitmapConverter.ConvertBitmap(bitmap, imageIndex, tagName);
        }
    }
}