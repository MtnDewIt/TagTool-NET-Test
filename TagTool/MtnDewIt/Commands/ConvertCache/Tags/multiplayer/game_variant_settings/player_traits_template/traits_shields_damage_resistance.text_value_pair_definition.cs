using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_shields_damage_resistance_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_shields_damage_resistance_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_shields_damage_resistance");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateDamageResistance;
            sily.Name = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance");
            sily.Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    Name = CacheContext.StringTable.GetStringId($@"unchanged"),
                    Description = CacheContext.StringTable.GetStringId($@"unchanged_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"percent_10"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_weaker_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"percent_50"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_weaker_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 3,
                    Name = CacheContext.StringTable.GetStringId($@"percent_90"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_weaker_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 4,
                    Name = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_normal"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_normal_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 5,
                    Name = CacheContext.StringTable.GetStringId($@"percent_110"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 6,
                    Name = CacheContext.StringTable.GetStringId($@"percent_150"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 7,
                    Name = CacheContext.StringTable.GetStringId($@"percent_200"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 8,
                    Name = CacheContext.StringTable.GetStringId($@"percent_300"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 9,
                    Name = CacheContext.StringTable.GetStringId($@"percent_500"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 10,
                    Name = CacheContext.StringTable.GetStringId($@"percent_1000"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 11,
                    Name = CacheContext.StringTable.GetStringId($@"percent_1500"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 12,
                    Name = CacheContext.StringTable.GetStringId($@"percent_2000"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 13,
                    Name = CacheContext.StringTable.GetStringId($@"percent_3000"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_stronger_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 14,
                    Name = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_invulnerable"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_invulnerable_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 15,
                    Name = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_invincible"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_health_damage_resistance_invincible_desc"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
