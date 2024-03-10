using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_chud_bitmaps_ballistic_meters_bitmap : TagFile
    {
        public ui_chud_bitmaps_ballistic_meters_bitmap(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\ballistic_meters");
            var bitm = CacheContext.Deserialize<Bitmap>(Stream, tag);
            bitm.Sequences[7].Sprites[0].Top = 0.275625f;
            CacheContext.Serialize(Stream, tag, bitm);
        }
    }
}
