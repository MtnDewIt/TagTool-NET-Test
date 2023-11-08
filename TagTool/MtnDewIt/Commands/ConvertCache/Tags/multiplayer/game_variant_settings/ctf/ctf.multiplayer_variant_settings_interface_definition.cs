using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_ctf_ctf_multiplayer_variant_settings_interface_definition : TagFile
    {
        public multiplayer_game_variant_settings_ctf_ctf_multiplayer_variant_settings_interface_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\ctf\ctf");
            var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(Stream, tag);
            goof.GameEngineSettings = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting> 
            {
                new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting
                {
                    Name = CacheContext.StringTable.GetStringId($@"ctf"),
                    SettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.CtfMain,
                    Options = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option>
                    {
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\ctf\ctf_sudden_death"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\ctf\ctf_flag_at_home"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\ctf\ctf_touch_return"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\ctf\ctf_idle_return"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\ctf\ctf_respawn_on_capture"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            TemplateBasedSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\player_traits_dynamic_template"),
                            SubmenuSettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.CtfCarrierTraitsMain,
                            SubmenuName = CacheContext.StringTable.GetStringId($@"ctf_flag_carrier_traits"),
                            SubmenuDescription = CacheContext.StringTable.GetStringId($@"ctf_flag_carrier_traits_desc"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, goof);
        }
    }
}
