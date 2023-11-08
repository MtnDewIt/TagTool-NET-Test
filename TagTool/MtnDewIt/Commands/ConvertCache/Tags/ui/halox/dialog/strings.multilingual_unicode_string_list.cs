using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_dialog_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_dialog_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\dialog\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "confirm_boot_betrayer", "This will remove the player from the game. Are you sure you wish to do this?");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
