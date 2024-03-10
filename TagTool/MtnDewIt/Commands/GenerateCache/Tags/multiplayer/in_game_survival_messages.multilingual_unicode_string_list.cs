using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class multiplayer_in_game_survival_messages_multilingual_unicode_string_list : TagFile
    {
        public multiplayer_in_game_survival_messages_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\in_game_survival_messages");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
            AddString(unic, "gen_kill_cause_player", "You killed #effect_player");
            AddString(unic, "gen_kill_effect_player", "#cause_player killed you");
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
