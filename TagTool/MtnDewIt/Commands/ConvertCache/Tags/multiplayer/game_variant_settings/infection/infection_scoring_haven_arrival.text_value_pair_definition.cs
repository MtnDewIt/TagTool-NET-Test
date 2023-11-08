using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_scoring_haven_arrival");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionHavenArrivalPoints;
            sily.Name = CacheContext.StringTable.GetStringId($@"infection_scoring_haven_arrival");
            sily.Description = CacheContext.StringTable.GetStringId($@"infection_scoring_haven_arrival_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -10,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_10"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -9,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_9"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -8,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_8"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -7,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_7"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -6,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -5,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_5"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -4,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -3,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -2,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = -1,
                    Name = CacheContext.StringTable.GetStringId($@"int_minus_1"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    Name = CacheContext.StringTable.GetStringId($@"int_0"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"int_1"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"int_2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 3,
                    Name = CacheContext.StringTable.GetStringId($@"int_3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 4,
                    Name = CacheContext.StringTable.GetStringId($@"int_4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 5,
                    Name = CacheContext.StringTable.GetStringId($@"int_5"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 6,
                    Name = CacheContext.StringTable.GetStringId($@"int_6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 7,
                    Name = CacheContext.StringTable.GetStringId($@"int_7"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 8,
                    Name = CacheContext.StringTable.GetStringId($@"int_8"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 9,
                    Name = CacheContext.StringTable.GetStringId($@"int_9"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 10,
                    Name = CacheContext.StringTable.GetStringId($@"int_10"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
