using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_respawn_options_respawn_spectating_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_respawn_options_respawn_spectating_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\respawn_options\respawn_spectating");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalNewUnknown;
            sily.Name = CacheContext.StringTable.GetStringId($@"respawn_spectating");
            sily.Description = CacheContext.StringTable.GetStringId($@"respawn_spectating_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"allowed"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    Name = CacheContext.StringTable.GetStringId($@"not_allowed"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
