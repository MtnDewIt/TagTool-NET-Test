using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_start_menu_panes_settings_appearance_colors_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_start_menu_panes_settings_appearance_colors_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\start_menu\panes\settings_appearance_colors\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "cef_color_detail", "Detail Color");
            AddString(unic, "cef_color_detail_desc", "The armor detail color preserves your individual identity in all multiplayer scenarios.");
            AddString(unic, "cef_color_light", "Light Color");
            AddString(unic, "cef_color_light_desc", "Like Christmas, but more subtle.");
            AddString(unic, "cef_color_primary", "Primary Color");
            AddString(unic, "cef_color_primary_desc", "The primary armor color will serve you in individual combat but will be overwritten in team scenarios.");
            AddString(unic, "cef_color_secondary", "Secondary Color");
            AddString(unic, "cef_color_secondary_desc", "The secondary armor color accents your primary color and will be overwritten in team scenarios.");
            AddString(unic, "cef_color_visor", "Visor Color");
            AddString(unic, "cef_color_visor_desc", "Adjust the tint of your Spartan's visor.");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
