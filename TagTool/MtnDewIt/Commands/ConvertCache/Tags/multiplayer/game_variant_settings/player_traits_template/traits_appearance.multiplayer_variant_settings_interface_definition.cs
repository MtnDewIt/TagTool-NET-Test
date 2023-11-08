using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_appearance_multiplayer_variant_settings_interface_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_appearance_multiplayer_variant_settings_interface_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance");
            var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(Stream, tag);
            goof.GameEngineSettings = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting> 
            {
                new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting
                {
                    Name = CacheContext.StringTable.GetStringId($@"traits_appearance"),
                    SettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.TemplatesTraitsAppearance,
                    Options = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option>
                    {
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_active_camo"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_waypoints"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_forced_change_colors"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_size"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_model_set"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_model"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, goof);
        }
    }
}
