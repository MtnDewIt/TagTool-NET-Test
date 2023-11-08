using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_pregame_lobby_switch_lobby_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_pregame_lobby_switch_lobby_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\pregame_lobby\switch_lobby\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "survival", "FIREFIGHT");
            AddString(unic, "survival_help", "Take your party to Firefight missions that gradually increase in difficulty as you rack up the points.");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
