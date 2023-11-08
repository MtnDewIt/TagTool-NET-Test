using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_global_options_global_options_multiplayer_variant_settings_interface_definition : TagFile
    {
        public multiplayer_game_variant_settings_global_options_global_options_multiplayer_variant_settings_interface_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\global_options\global_options");
            var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(Stream, tag);
            goof.GameEngineSettings = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting> 
            {
                new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting
                {
                    Name = CacheContext.StringTable.GetStringId($@"base_map"),
                    Options = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option>
                    {
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\global_options\round_limit"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\global_options\round_time_limit"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\global_options\rounds_reset"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            TemplateBasedSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\player_traits_template"),
                            SubmenuSettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.GlobalBaseTraitsMain,
                            SubmenuName = CacheContext.StringTable.GetStringId($@"map_overrides_base_traits"),
                            SubmenuDescription = CacheContext.StringTable.GetStringId($@"map_overrides_base_traits_desc"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ExplicitSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\global_options\respawn_options"),
                            SubmenuName = CacheContext.StringTable.GetStringId($@"respawn_options"),
                            SubmenuDescription = CacheContext.StringTable.GetStringId($@"respawn_options_desc"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\social_options\team_changing"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\social_options\friendly_fire"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\social_options\betrayal_booting"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\respawn_options\respawn_spectating"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, goof);
        }
    }
}
