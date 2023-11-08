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
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
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

        public void GenerateMapImages() 
        {
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\placeholder", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\unknown.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\armory", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\armory.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\bunkerworld", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\bunkerworld.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\chillout", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\chillout.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\descent", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\descent.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\docks", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\docks.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\fortress", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\fortress.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\ghosttown", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\ghosttown.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\lockout", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\lockout.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\midship", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\midship.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sandbox", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sandbox.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sidewinder", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sidewinder.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\spacecamp", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\spacecamp.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\warehouse", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\warehouse.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\chill", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\chill.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\construct", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\construct.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\cyberdyne", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\cyberdyne.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\deadlock", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\deadlock.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\guardian", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\guardian.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\isolation", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\isolation.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\riverworld", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\riverworld.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\s3d_avalanche", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\s3d_avalanche.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\s3d_edge", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\s3d_edge.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\s3d_reactor", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\s3d_reactor.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\s3d_turf", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\s3d_turf.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\s3d_waterfall", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\s3d_waterfall.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\salvation", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\salvation.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\shrine", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\shrine.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\snowbound", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\snowbound.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\zanzibar", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\zanzibar.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\005_intro", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\005_intro.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\010_jungle", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\010_jungle.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\020_base", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\020_base.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\030_outskirts", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\030_outskirts.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\040_voi", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\040_voi.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\050_floodvoi", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\050_floodvoi.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\070_waste", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\070_waste.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\100_citadel", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\100_citadel.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\110_hc", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\110_hc.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\120_halo", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\120_halo.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\130_epilogue", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\130_epilogue.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\c100", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\c100.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\c200", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\c200.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\h100", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\h100.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\l200", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\l200.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\l300", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\l300.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sc100", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sc100.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sc110", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sc110.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sc120", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sc120.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sc130", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sc130.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sc140", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sc140.dds");
            CreateBitmap($@"ui\eldewrito\common\map_bitmaps\sc150", $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Maps\sc150.dds");

            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("mlst") && tag.Name == $@"ui\eldewrito\maps") 
                    {
                        var mlst = CacheContext.Deserialize<MapList>(stream, tag);
                        mlst.DefaultMapImage = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\placeholder");
                        mlst.MapImages = new List<MapList.MapImage>
                        {
                            new MapList.MapImage
                            {
                                MapId = 30,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\zanzibar"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 31,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_turf"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 300,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\construct"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 310,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\deadlock"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 320,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\guardian"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 330,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\isolation"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 340,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\riverworld"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 350,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\salvation"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 360,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\snowbound"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 380,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\chill"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 390,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\cyberdyne"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 400,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\shrine"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 410,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\bunkerworld"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 440,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\docks"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 470,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sidewinder"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 480,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\warehouse"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 490,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\descent"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 500,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\spacecamp"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 520,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\lockout"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 580,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\armory"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 590,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\ghosttown"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 600,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\chillout"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 700,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_reactor"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 703,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_edge"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 705,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_avalanche"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 706,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_waterfall"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 720,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\midship"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 730,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sandbox"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 740,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\fortress"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3005,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\005_intro"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3010,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\010_jungle"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3020,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\020_base"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3030,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\030_outskirts"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3040,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\040_voi"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3050,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\050_floodvoi"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3070,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\070_waste"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3100,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\100_citadel"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3110,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\110_hc"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3120,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\120_halo"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 3130,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\130_epilogue"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 4100,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\c100"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 4200,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\c200"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 5000,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\h100"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 5200,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\l200"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 5300,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\l300"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 6100,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc100"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 6110,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc110"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 6120,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc120"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 6130,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc130"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 6140,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc140"),
                            },
                            new MapList.MapImage
                            {
                                MapId = 6150,
                                Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc150"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, mlst);
                    }
                }
            }
        }
    }
}