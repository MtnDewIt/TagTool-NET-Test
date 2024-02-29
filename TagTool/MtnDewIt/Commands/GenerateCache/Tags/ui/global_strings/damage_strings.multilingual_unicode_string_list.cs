using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class ui_global_strings_damage_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_global_strings_damage_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\global_strings\damage_strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            //AddString(unic, "armor_lock_crush", "Armor Lock");
            AddString(unic, "shade_turret", "Shade Turret");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
