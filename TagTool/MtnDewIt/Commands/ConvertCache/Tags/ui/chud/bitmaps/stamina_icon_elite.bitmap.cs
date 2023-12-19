using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_bitmaps_stamina_icon_elite_bitmap : TagFile
    {
        public ui_chud_bitmaps_stamina_icon_elite_bitmap(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\stamina_icon_elite");
            var bitm = CacheContext.Deserialize<Bitmap>(Stream, tag);
            AddBitmap(bitm, 0, $@"{Program.TagToolDirectory}\Tools\BaseCache\Images\Assets\stamina_icon_elite.dds");
            CacheContext.Serialize(Stream, tag, bitm);
        }
    }
}
