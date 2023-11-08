using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_movement_personal_gravity_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_movement_personal_gravity_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_movement_personal_gravity");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateGravity;
            sily.Name = CacheContext.StringTable.GetStringId($@"traits_movement_gravity");
            sily.Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Name = CacheContext.StringTable.GetStringId($@"unchanged"),
                    Description = CacheContext.StringTable.GetStringId($@"unchanged_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"percent_0"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_less_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"percent_15"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_less_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 3,
                    Name = CacheContext.StringTable.GetStringId($@"percent_25"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_less_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 4,
                    Name = CacheContext.StringTable.GetStringId($@"percent_35"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_less_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 5,
                    Name = CacheContext.StringTable.GetStringId($@"percent_50"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_less_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 6,
                    Name = CacheContext.StringTable.GetStringId($@"percent_75"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_less_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 7,
                    Name = CacheContext.StringTable.GetStringId($@"percent_100"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_normal_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 8,
                    Name = CacheContext.StringTable.GetStringId($@"percent_125"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_more_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 9,
                    Name = CacheContext.StringTable.GetStringId($@"percent_150"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_more_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 10,
                    Name = CacheContext.StringTable.GetStringId($@"percent_200"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_movement_gravity_more_desc"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
