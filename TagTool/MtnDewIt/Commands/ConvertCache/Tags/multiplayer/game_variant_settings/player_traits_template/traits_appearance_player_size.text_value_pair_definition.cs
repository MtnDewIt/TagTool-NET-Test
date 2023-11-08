using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_size_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_size_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_size");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateVisualAura;
            sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_player_size");
            sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_player_size_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Name = CacheContext.StringTable.GetStringId($@"unchanged"),
                    Description = CacheContext.StringTable.GetStringId($@"unchanged_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"percent_10"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 3,
                    Name = CacheContext.StringTable.GetStringId($@"percent_15"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 4,
                    Name = CacheContext.StringTable.GetStringId($@"percent_25"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 5,
                    Name = CacheContext.StringTable.GetStringId($@"percent_35"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 6,
                    Name = CacheContext.StringTable.GetStringId($@"percent_50"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 7,
                    Name = CacheContext.StringTable.GetStringId($@"percent_75"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 8,
                    Name = CacheContext.StringTable.GetStringId($@"percent_100"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 9,
                    Name = CacheContext.StringTable.GetStringId($@"percent_125"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 10,
                    Name = CacheContext.StringTable.GetStringId($@"percent_150"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 11,
                    Name = CacheContext.StringTable.GetStringId($@"percent_200"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 12,
                    Name = CacheContext.StringTable.GetStringId($@"percent_300"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 13,
                    Name = CacheContext.StringTable.GetStringId($@"percent_500"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 14,
                    Name = CacheContext.StringTable.GetStringId($@"percent_750"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 15,
                    Name = CacheContext.StringTable.GetStringId($@"percent_1000"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 16,
                    Name = CacheContext.StringTable.GetStringId($@"percent_1500"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 17,
                    Name = CacheContext.StringTable.GetStringId($@"percent_2000"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 18,
                    Name = CacheContext.StringTable.GetStringId($@"percent_3000"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
