using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_infection_infection_haven_movement_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_infection_infection_haven_movement_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_haven_movement");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionHavenMovement;
            sily.Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement");
            sily.Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_none_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_none"),
                    Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_none_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_random"),
                    Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_random_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_sequence"),
                    Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_sequence_desc"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
