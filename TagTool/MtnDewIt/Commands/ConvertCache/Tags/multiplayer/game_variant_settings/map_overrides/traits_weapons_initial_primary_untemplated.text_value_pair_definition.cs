using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_map_overrides_traits_weapons_initial_primary_untemplated_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_map_overrides_traits_weapons_initial_primary_untemplated_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\map_overrides\traits_weapons_initial_primary_untemplated");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.SidGlobalBaseTraitsPrimaryWeapon;
            sily.Name = CacheContext.StringTable.GetStringId($@"traits_weapons_initial_primary");
            sily.Description = CacheContext.StringTable.GetStringId($@"traits_weapons_initial_primary_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"unchanged"),
                    Name = CacheContext.StringTable.GetStringId($@"unchanged"),
                    Description = CacheContext.StringTable.GetStringId($@"unchanged_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"default"),
                    Name = CacheContext.StringTable.GetStringId($@"map_default"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_assault_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_battle_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"beam_rifle"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_beam_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"brute_shot"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_brute_shot"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"carbine"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_carbine"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"dmr"),
                    Name = CacheContext.StringTable.GetStringId($@"dmr"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"energy_sword"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_sword"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"flamethrower"),
                    Name = CacheContext.StringTable.GetStringId($@"flamethrower"),
                    Description = CacheContext.StringTable.GetStringId($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"fuel_rod_gun"),
                    Name = CacheContext.StringTable.GetStringId($@"fuel_rod_gun"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"gravity_hammer"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_gravity_hammer"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"machinegun_turret"),
                    Name = CacheContext.StringTable.GetStringId($@"machinegun_turret"),
                    Description = CacheContext.StringTable.GetStringId($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"magnum"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_magnum"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"excavator"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_excavator"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"missile_pod"),
                    Name = CacheContext.StringTable.GetStringId($@"missile_pod"),
                    Description = CacheContext.StringTable.GetStringId($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"needler"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_needler"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_cannon"),
                    Name = CacheContext.StringTable.GetStringId($@"plasma_cannon"),
                    Description = CacheContext.StringTable.GetStringId($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_pistol"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_plasma_pistol"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_rifle"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_plasma_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"rocket_launcher"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_rocket_launcher"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"smg"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_smg"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"sentinel_beam"),
                    Name = CacheContext.StringTable.GetStringId($@"sentinel_beam"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"shotgun"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_shotgun"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"sniper_rifle"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_sniper_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"spartan_laser"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_laser"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"spike_rifle"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_spiker"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                    Name = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                    Name = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                    Name = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                    Name = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                    Name = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                    Name = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v3"),
                    Name = CacheContext.StringTable.GetStringId($@"smg_v3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v2"),
                    Name = CacheContext.StringTable.GetStringId($@"smg_v2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v6"),
                    Name = CacheContext.StringTable.GetStringId($@"smg_v6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v4"),
                    Name = CacheContext.StringTable.GetStringId($@"smg_v4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"random"),
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons_random"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"unarmed"),
                    Name = CacheContext.StringTable.GetStringId($@"unarmed"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetStringId($@"none"),
                    Name = CacheContext.StringTable.GetStringId($@"none"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
