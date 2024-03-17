using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
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
            sily.Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_initial_primary");
            sily.Description = CacheContext.StringTable.GetOrAddString($@"traits_weapons_initial_primary_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"unchanged"),
                    Name = CacheContext.StringTable.GetOrAddString($@"unchanged"),
                    Description = CacheContext.StringTable.GetOrAddString($@"unchanged_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"default"),
                    Name = CacheContext.StringTable.GetOrAddString($@"map_default"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"assault_rifle"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_assault_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"battle_rifle"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_battle_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"beam_rifle"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_beam_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"brute_shot"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_brute_shot"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"carbine"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_carbine"),
                },
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"dmr"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"dmr"),
                //},
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"energy_sword"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_sword"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"flamethrower"),
                    Name = CacheContext.StringTable.GetOrAddString($@"flamethrower"),
                    Description = CacheContext.StringTable.GetOrAddString($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"fuel_rod_gun"),
                    Name = CacheContext.StringTable.GetOrAddString($@"fuel_rod_gun"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"gravity_hammer"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_gravity_hammer"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"machinegun_turret"),
                    Name = CacheContext.StringTable.GetOrAddString($@"machinegun_turret"),
                    Description = CacheContext.StringTable.GetOrAddString($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"magnum"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_magnum"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"excavator"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_excavator"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"missile_pod"),
                    Name = CacheContext.StringTable.GetOrAddString($@"missile_pod"),
                    Description = CacheContext.StringTable.GetOrAddString($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"needler"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_needler"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"plasma_cannon"),
                    Name = CacheContext.StringTable.GetOrAddString($@"plasma_cannon"),
                    Description = CacheContext.StringTable.GetOrAddString($@"support_weapon_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"plasma_pistol"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_plasma_pistol"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"plasma_rifle"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_plasma_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"rocket_launcher"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_rocket_launcher"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"smg"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_smg"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"sentinel_beam"),
                    Name = CacheContext.StringTable.GetOrAddString($@"sentinel_beam"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"shotgun"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_shotgun"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"sniper_rifle"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_sniper_rifle"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"spartan_laser"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_laser"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"spike_rifle"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_spiker"),
                },
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v2"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v2"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v4"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v4"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v6"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"assault_rifle_v6"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v1"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v1"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v2"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v2"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v6"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v6"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v5"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v5"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v4"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"battle_rifle_v4"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v1"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v1"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v2"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v2"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v6"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v6"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v5"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v5"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v4"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"covenant_carbine_v4"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"dmr_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"dmr_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"dmr_v1"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"dmr_v1"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"dmr_v2"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"dmr_v2"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"dmr_v6"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"dmr_v6"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"dmr_v4"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"dmr_v4"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"magnum_v2"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"magnum_v2"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"magnum_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"magnum_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"excavator_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"excavator_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"plasma_pistol_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"plasma_pistol_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"plasma_rifle_v6"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"plasma_rifle_v6"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"smg_v3"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"smg_v3"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"smg_v2"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"smg_v2"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"smg_v6"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"smg_v6"),
                //},
                //new TextValuePairDefinition.TextValuePair
                //{
                //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                //    StringidValue = CacheContext.StringTable.GetOrAddString($@"smg_v4"),
                //    Name = CacheContext.StringTable.GetOrAddString($@"smg_v4"),
                //},
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"random"),
                    Name = CacheContext.StringTable.GetOrAddString($@"traits_weapons_random"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"unarmed"),
                    Name = CacheContext.StringTable.GetOrAddString($@"unarmed"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                    StringidValue = CacheContext.StringTable.GetOrAddString($@"none"),
                    Name = CacheContext.StringTable.GetOrAddString($@"none"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
