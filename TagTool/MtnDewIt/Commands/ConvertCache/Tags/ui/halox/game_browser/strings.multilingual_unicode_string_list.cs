using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_game_browser_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_game_browser_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\game_browser\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "browser_title", "AVAILABLE GAMES");
            AddString(unic, "system_link_games", "Local Games");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
