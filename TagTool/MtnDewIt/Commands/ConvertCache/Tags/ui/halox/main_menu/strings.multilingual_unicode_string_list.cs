using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_main_menu_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_main_menu_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\main_menu\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "customization", "CUSTOMIZATION");
            AddString(unic, "eldewrito_settings", "SETTINGS");
            AddString(unic, "eldewrito_version", "<eldewrito-version/>");
            AddString(unic, "exit", "EXIT");
            AddString(unic, "game_browser", "LOCAL GAMES");
            AddString(unic, "server_browser", "SERVER BROWSER");
            AddString(unic, "survival", "FIREFIGHT");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
