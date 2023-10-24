using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class multiplayer_game_variant_settings_infection_infection_scoring_haven_arrival_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_infection_infection_scoring_haven_arrival_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer/game_variant_settings/infection/infection_scoring_haven_arrival");
        }
    }
}
