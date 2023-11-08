using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_pregame_lobby_selection_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_pregame_lobby_selection_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\pregame_lobby\selection\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "network_mode_offline", "Offline");
            AddString(unic, "network_mode_offline_description", "Play only on this PC.");
            AddString(unic, "network_mode_system_link", "Online");
            AddString(unic, "network_mode_system_link_advertise_description", "Host a INTERNET/LAN game. This can be joined from the Server Browser or the Local Games menu.");
            AddString(unic, "network_mode_system_link_browse_description", "Find games that are being hosted on your local area network or VPN.");
            AddString(unic, "network_mode_system_link_description", "Play with others over your local area network or VPN.");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
