using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_map_overrides_weapon_set_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_map_overrides_weapon_set_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\map_overrides\weapon_set");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.SidGlobalMapWeaponSet;
            sily.Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set");
            sily.Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"default"),
                    Name = CacheContext.StringTable.GetStringId($@"map_default"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_default_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifles"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_assault_rifles"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_value_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"duals"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_duals"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_duals_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"hammers"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_hammers"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_value_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"lasers"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_lasers"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_value_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"rockets"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_rockets"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_value_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"shotguns"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_shotguns"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_value_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"sniper_rifles"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_sniper_rifles"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_value_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"swords"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_swords"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_value_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"random"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_random"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_random_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"no_power_weapons"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_no_power_weapons"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_no_power_weapons_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"no_snipers"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_no_snipers"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_no_snipers_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"no_weapons"),
                    Name = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_none"),
                    Description = CacheContext.StringTable.GetStringId($@"map_overrides_weapon_set_none_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"base"),
                    Name = CacheContext.StringTable.GetStringId($@"base"),
                    Description = CacheContext.StringTable.GetStringId($@"info"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
