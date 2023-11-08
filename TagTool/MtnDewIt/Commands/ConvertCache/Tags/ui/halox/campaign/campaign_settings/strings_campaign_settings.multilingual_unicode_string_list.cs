using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_campaign_campaign_settings_strings_campaign_settings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_campaign_campaign_settings_strings_campaign_settings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\campaign_settings\strings_campaign_settings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "skulls_help", "This setting allows you to turn skulls on or off.");
            //AddString(unic, "skull_15_title", "Third Person");
            //AddString(unic, "skull_15_hint", "Interred somewhere, anywhere, nowhere?);
            //AddString(unic, "skull_15", "Got a good view of my ass from here");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
