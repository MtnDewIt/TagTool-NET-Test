using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags
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
            var tag = GetCachedTag<GfxTexturesList>($@"ui\eldewrito\maps");
            var gfxt = CacheContext.Deserialize<GfxTexturesList>(Stream, tag);
            gfxt.Textures = new List<GfxTexturesList.Texture>
            {
                new GfxTexturesList.Texture
                {
                    FileName = "30",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\zanzibar"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "31",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_turf"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "300",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\construct"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "310",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\deadlock"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "320",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\guardian"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "330",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\isolation"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "340",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\riverworld"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "350",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\salvation"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "360",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\snowbound"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "380",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\chill"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "390",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\cyberdyne"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "400",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\shrine"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "410",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\bunkerworld"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "440",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\docks"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "470",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sidewinder"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "480",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\warehouse"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "490",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\descent"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "500",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\spacecamp"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "520",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\lockout"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "580",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\armory"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "590",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\ghosttown"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "600",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\chillout"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "700",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_reactor"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "703",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_edge"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "705",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_avalanche"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "706",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_waterfall"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "709",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_sky_bridgenew"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "711",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_lockout"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "715",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_powerhouse"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "720",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\midship"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "730",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sandbox"),
                },
                new GfxTexturesList.Texture
                {
                    FileName = "740",
                    Bitmap = GetCachedTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\fortress"),
                },
            };
            CacheContext.Serialize(Stream, tag, gfxt);
        }
    }
}
