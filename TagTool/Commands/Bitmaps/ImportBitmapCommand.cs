﻿using System;
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

                  "ImportBitmap <image index> <dds file> [curve mode]",

                  "The image index must be in hexadecimal.\n" +
                  "No conversion will be done on the data in the DDS file.\n" +
                  "The pixel format must be supported by the game.")
        {
            Cache = cache;
            Tag = tag;
            Bitmap = bitmap;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 3 || args.Count < 2)
                return new TagToolError(CommandError.ArgCount);

            if (!int.TryParse(args[0], NumberStyles.Integer, null, out int imageIndex))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\"");

            if (Bitmap.Images.Count == 0)
            {
                Bitmap.Flags = BitmapRuntimeFlags.UsingTagInteropAndTagResource;
                Bitmap.Images.Add(new Bitmap.Image { Signature = new Tag("bitm") });
                Bitmap.HardwareTextures.Add(new TagResourceReference());
            }

            if (imageIndex >= Bitmap.Images.Count)
            {
                Bitmap.Images.Add(new Bitmap.Image { Signature = new Tag("bitm") });
                Bitmap.HardwareTextures.Add(new TagResourceReference());
                imageIndex = Bitmap.Images.Count - 1;
                new TagToolWarning($"Index exceeds image count; new image created at index {imageIndex}");
            }
            else if (imageIndex < 0)
                return new TagToolError(CommandError.ArgInvalid, "Invalid image index");

            var imagePath = args[1];
            if (!File.Exists(imagePath))
                return new TagToolError(CommandError.FileNotFound, $"\"{imagePath}\"");

            BitmapImageCurve curve = BitmapImageCurve.xRGB;
            string inputCurve = args.Count == 3 ? args[2] : null;
            if (inputCurve != null)
            {
                switch (inputCurve.ToLowerInvariant())
                {
                    case "linear":
                        curve = BitmapImageCurve.Linear;
                        break;
                    case "sRGB":
                    case "srgb":
                        curve = BitmapImageCurve.sRGB;
                        break;
                    case "gamma2":
                        curve = BitmapImageCurve.Gamma2;
                        break;
                    case "xRGB":
                    case "xrgb":
                        curve = BitmapImageCurve.xRGB;
                        break;
                    default:
                        Console.WriteLine($"Invalid bitmap curve {inputCurve}, using xRGB instead");
                        break;
                }
            }

            // Check if the file name indicates a normal map (_zbump, _normal, or _n)
            bool useDXN = false;
            string lowerName = imagePath.ToLowerInvariant();
            if (lowerName.EndsWith("_zbump.dds") ||
                lowerName.EndsWith("_normal.dds") ||
                lowerName.EndsWith("_n.dds"))
            {
                useDXN = true;
            }

            Console.WriteLine("Importing image data...");
            try
            {
                // Create a DDSFile instance and read its contents.
                DDSFile file = new DDSFile();
                using (var imageStream = File.OpenRead(imagePath))
                using (var reader = new EndianReader(imageStream))
                {
                    file.Read(reader);
                }

                // Create the initial resource from the DDS file.
                var resource = BitmapInjector.CreateBitmapResourceFromDDS(Cache, file, curve);

                if (useDXN)
                {
                    Console.WriteLine("Detected normal map file. Converting from DXT5 to DXN...");

                    // Read entire file as raw bytes.
                    byte[] ddsRaw = File.ReadAllBytes(imagePath);
                    const int headerSize = 128; // 4 bytes magic + 124 bytes header
                    if (ddsRaw.Length <= headerSize)
                        throw new Exception("Invalid DDS file: file too short.");

                    // Compute expected size for the top mip level (for DXT5, 16 bytes per 4x4 block).
                    int width = file.Header.Width;
                    int height = file.Header.Height;
                    int blockWidth = (width + 3) / 4;
                    int blockHeight = (height + 3) / 4;
                    int expectedSize = blockWidth * blockHeight * 16;
                    if (ddsRaw.Length - headerSize < expectedSize)
                        throw new Exception("DDS file pixel data is smaller than expected.");

                    // Extract only the highest-resolution mip level.
                    byte[] highestResData = new byte[expectedSize];
                    Array.Copy(ddsRaw, headerSize, highestResData, 0, expectedSize);

                    // Decode the compressed data (which is in DXT5 format) into an uncompressed A8R8G8B8 buffer.
                    byte[] uncompressed = BitmapDecoder.DecodeBitmap(highestResData, BitmapFormat.Dxt5, width, height);

                    // Re-encode the uncompressed data as DXN (BC5).
                    byte[] dxnData = BitmapDecoder.EncodeBitmap(uncompressed, BitmapFormat.Dxn, width, height);

                    // Update the resource’s bitmap definition.
                    resource.Texture.Definition.PrimaryResourceData = new TagData(dxnData);
                    resource.Texture.Definition.Bitmap.Format = BitmapFormat.Dxn;
                }

                var reference = Cache.ResourceCache.CreateBitmapResource(resource);
                Bitmap.HardwareTextures[imageIndex] = reference;
                Bitmap.Images[imageIndex] = BitmapUtils.CreateBitmapImageFromResourceDefinition(
                    resource.Texture.Definition.Bitmap);

                using (var tagsStream = Cache.OpenCacheReadWrite())
                    Cache.Serialize(tagsStream, Tag, Bitmap);
            }
            catch (Exception ex)
            {
                return new TagToolError(CommandError.OperationFailed,
                    "Importing image data failed: " + ex.Message);
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}
