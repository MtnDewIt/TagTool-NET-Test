using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_global_options_rounds_reset_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_global_options_rounds_reset_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\global_options\rounds_reset");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalRoundsReset;
            sily.Name = CacheContext.StringTable.GetStringId($@"rounds_reset");
            sily.Description = CacheContext.StringTable.GetStringId($@"rounds_reset_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Name = CacheContext.StringTable.GetStringId($@"rounds_reset_none"),
                    Description = CacheContext.StringTable.GetStringId($@"rounds_reset_none_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"rounds_reset_players"),
                    Description = CacheContext.StringTable.GetStringId($@"rounds_reset_players_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"rounds_reset_all"),
                    Description = CacheContext.StringTable.GetStringId($@"rounds_reset_all_desc"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
