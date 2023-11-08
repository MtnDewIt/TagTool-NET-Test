using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_weapons_multiplayer_variant_settings_interface_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_weapons_multiplayer_variant_settings_interface_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons");
            var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(Stream, tag);
            goof.GameEngineSettings = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting>
            {
                new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting
                {
                    Name = CacheContext.StringTable.GetStringId($@"traits_weapons"),
                    SettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.TemplatesTraitsWeapons,
                    Options = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option>
                    {
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_damage_modifier"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_initial_primary"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_initial_secondary"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_initial_grenade_count"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_recharging_grenades"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_infinite_ammo"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_pickup"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_third_person_camera"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, goof);
        }
    }
}
