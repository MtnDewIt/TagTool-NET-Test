using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_global_strings_global_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_global_strings_global_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\global_strings\global_strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "network_mode_offline", "Offline");
            AddString(unic, "network_mode_system_link_advertise", "Online");
            AddString(unic, "metagame_off", "Off");
            AddString(unic, "metagame_on", "Free for All");
            AddString(unic, "metagame_on_group", "Team");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
