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

        // Generates the specified map image tags, and assigns them and thier corresponding map id to the gfxtextureslist tag
        public void generateMapImages() 
        {
            // Generates the map images for the main menu (Halo Online is unable to use .blf files for map images, so this is used as a work around)
            // TODO: Add ODST Maps (Maybe add flags to include certain maps in certain cache types?)
            CreateBitmap($@"levels\ui\placeholder\placeholder\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\unknown.dds");
            CreateBitmap($@"levels\solo\005_intro\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\005_intro.dds");
            CreateBitmap($@"levels\solo\010_jungle\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\010_jungle.dds");
            CreateBitmap($@"levels\solo\020_base\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\020_base.dds");
            CreateBitmap($@"levels\solo\030_outskirts\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\030_outskirts.dds");
            CreateBitmap($@"levels\solo\040_voi\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\040_voi.dds");
            CreateBitmap($@"levels\solo\050_floodvoi\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\050_floodvoi.dds");
            CreateBitmap($@"levels\solo\070_waste\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\070_waste.dds");
            CreateBitmap($@"levels\solo\100_citadel\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\100_citadel.dds");
            CreateBitmap($@"levels\solo\110_hc\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\110_hc.dds");
            CreateBitmap($@"levels\solo\120_halo\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\120_halo.dds");
            CreateBitmap($@"levels\solo\130_epilogue\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\130_epilogue.dds");
            CreateBitmap($@"levels\dlc\armory\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\armory.dds");
            CreateBitmap($@"levels\dlc\bunkerworld\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\bunkerworld.dds");
            CreateBitmap($@"levels\dlc\chillout\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\chillout.dds");
            CreateBitmap($@"levels\dlc\descent\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\descent.dds");
            CreateBitmap($@"levels\dlc\docks\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\docks.dds");
            CreateBitmap($@"levels\dlc\fortress\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\fortress.dds");
            CreateBitmap($@"levels\dlc\ghosttown\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\ghosttown.dds");
            CreateBitmap($@"levels\dlc\lockout\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\lockout.dds");
            CreateBitmap($@"levels\dlc\midship\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\midship.dds");
            CreateBitmap($@"levels\dlc\sandbox\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\sandbox.dds");
            CreateBitmap($@"levels\dlc\sidewinder\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\sidewinder.dds");
            CreateBitmap($@"levels\dlc\spacecamp\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\spacecamp.dds");
            CreateBitmap($@"levels\dlc\warehouse\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\warehouse.dds");
            CreateBitmap($@"levels\multi\chill\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\chill.dds");
            CreateBitmap($@"levels\multi\construct\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\construct.dds");
            CreateBitmap($@"levels\multi\cyberdyne\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\cyberdyne.dds");
            CreateBitmap($@"levels\multi\deadlock\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\deadlock.dds");
            CreateBitmap($@"levels\multi\guardian\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\guardian.dds");
            CreateBitmap($@"levels\multi\isolation\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\isolation.dds");
            CreateBitmap($@"levels\multi\riverworld\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\riverworld.dds");
            CreateBitmap($@"levels\multi\s3d_avalanche\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\s3d_avalanche.dds");
            CreateBitmap($@"levels\multi\s3d_edge\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\s3d_edge.dds");
            CreateBitmap($@"levels\multi\s3d_reactor\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\s3d_reactor.dds");
            CreateBitmap($@"levels\multi\s3d_turf\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\s3d_turf.dds");
            CreateBitmap($@"levels\multi\s3d_waterfall\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\s3d_waterfall.dds");
            CreateBitmap($@"levels\multi\salvation\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\salvation.dds");
            CreateBitmap($@"levels\multi\shrine\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\shrine.dds");
            CreateBitmap($@"levels\multi\snowbound\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\snowbound.dds");
            CreateBitmap($@"levels\multi\zanzibar\bitmaps\gfxt", $@"{Program.TagToolDirectory}\Tools\PortingCache\Images\zanzibar.dds");

            // Assigns the newly created bitmap tags to the gfxtextureslist tag. The map ID input with each bitmap must match that given map file, otherwise the images will not display correctly
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("gfxt") && tag.Name == $@"ui\halox\main_menu\gfxt")
                    {
                        var gfxt = CacheContext.Deserialize<GfxTexturesList>(stream, tag);
                        gfxt.Textures = new List<GfxTexturesList.Texture>()
                        {
                            new GfxTexturesList.Texture()
                            {
                                FileName = "placeholder",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\ui\placeholder\placeholder\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3005",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\005_intro\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3010",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\010_jungle\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3020",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\020_base\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3030",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\030_outskirts\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3040",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\040_voi\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3050",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\050_floodvoi\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3070",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\070_waste\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3100",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\100_citadel\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3110",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\110_hc\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3120",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\120_halo\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "3130",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\solo\130_epilogue\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "580",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\armory\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "410",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\bunkerworld\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "600",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\chillout\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "490",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\descent\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "440",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\docks\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "740",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\fortress\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "590",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\ghosttown\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "520",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\lockout\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "720",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\midship\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "730",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\sandbox\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "470",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\sidewinder\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "500",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\spacecamp\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "580",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\dlc\warehouse\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "380",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\chill\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "300",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\construct\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "390",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\cyberdyne\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "310",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\deadlock\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "320",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\guardian\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "330",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\isolation\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "340",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\riverworld\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "705",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\s3d_avalanche\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "703",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\s3d_edge\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "700",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\s3d_reactor\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "31",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\s3d_turf\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "706",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\s3d_waterfall\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "350",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\salvation\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "400",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\shrine\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "360",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\snowbound\bitmaps\gfxt"),
                            },
                            new GfxTexturesList.Texture()
                            {
                                FileName = "30",
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\multi\zanzibar\bitmaps\gfxt"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, gfxt);
                    }
                }
            }
        }
    }
}