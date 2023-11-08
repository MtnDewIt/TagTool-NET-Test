using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_boot_betrayer_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_boot_betrayer_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\boot_betrayer\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "help", @"You were betrayed again by <betrayer-name\>. Press \UE102 if you want to boot this player from the game.");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
