using System;
using TagTool.Bitmaps.DDS;
using TagTool.Bitmaps;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        // generates a new bitmap tag, with the tag name corresponding to the input string, and bitmap data from the specified DDS file (Code repurposed from the 'importbitmap' command)
        public void CreateBitmap(string bitmapName, string DDS)
        {
            CachedTag tag = null;

            var groupTag = new Tag("bitm");

            using (var stream = Cache.OpenCacheReadWrite())
            {
                if (tag == null)
                    tag = Cache.TagCache.AllocateTag(Cache.TagCache.TagDefinitions.GetTagGroupFromTag(groupTag), bitmapName);

                Cache.Serialize(stream, tag, Activator.CreateInstance(Cache.TagCache.TagDefinitions.GetTagDefinitionType(groupTag)));

                CacheContext.SaveTagNames();
            }

            using (var stream = Cache.OpenCacheReadWrite())
            {
                var bitm = Cache.Deserialize<Bitmap>(stream, tag);

                bitm.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;
                bitm.Images.Add(new Bitmap.Image { Signature = new Tag("bitm") });
                bitm.HardwareTextures.Add(new TagResourceReference());

                var imageIndex = 0;
                BitmapImageCurve curve = BitmapImageCurve.xRGB;

                DDSFile dds = new DDSFile();

                using (var imageStream = File.OpenRead(DDS))
                using (var reader = new EndianReader(imageStream))
                {
                    dds.Read(reader);
                }

                var bitmapTextureInteropDefinition = BitmapInjector.CreateBitmapResourceFromDDS(Cache, dds, curve);
                var reference = Cache.ResourceCache.CreateBitmapResource(bitmapTextureInteropDefinition);

                bitm.HardwareTextures[imageIndex] = reference;
                bitm.Images[imageIndex] = BitmapUtils.CreateBitmapImageFromResourceDefinition(bitmapTextureInteropDefinition.Texture.Definition.Bitmap);

                Cache.Serialize(stream, tag, bitm);
            }
        }
    }
}