using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_infection_infection_respawn_on_haven_move_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_infection_infection_respawn_on_haven_move_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_respawn_on_haven_move");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionRespawnOnHavenMove;
            sily.Name = CacheContext.StringTable.GetStringId($@"infection_respawn_on_haven_move");
            sily.Description = CacheContext.StringTable.GetStringId($@"infection_respawn_on_haven_move_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    Name = CacheContext.StringTable.GetStringId($@"disabled"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"enabled"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
