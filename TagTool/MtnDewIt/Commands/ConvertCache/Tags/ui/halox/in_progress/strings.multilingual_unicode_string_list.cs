using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_in_progress_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_in_progress_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\in_progress\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "game_variant_save_progress_message", "Saving content. Please don't turn off your PC.");
            AddString(unic, "map_variant_save_progress_message", "Saving content. Please don't turn off your PC.");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
