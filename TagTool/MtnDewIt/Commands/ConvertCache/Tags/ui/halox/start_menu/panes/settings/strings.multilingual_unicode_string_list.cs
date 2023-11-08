using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_start_menu_panes_settings_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_start_menu_panes_settings_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\start_menu\panes\settings\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "controls_description", "Customize your settings to your personal preferences.");
            AddString(unic, "controls_settings", "ED SETTINGS");
            AddString(unic, "display_description", "Customize your screen settings to decide how you want subtitles to be displayed.");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
