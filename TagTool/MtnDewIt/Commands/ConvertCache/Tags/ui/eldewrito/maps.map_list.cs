using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_eldewrito_maps_map_list : TagFile
    {
        public ui_eldewrito_maps_map_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<MapList>($@"ui\eldewrito\maps");
            var mlst = CacheContext.Deserialize<MapList>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, mlst);
        }
    }
}
