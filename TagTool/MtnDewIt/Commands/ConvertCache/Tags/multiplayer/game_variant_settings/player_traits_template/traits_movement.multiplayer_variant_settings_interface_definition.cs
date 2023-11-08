using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_movement_multiplayer_variant_settings_interface_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_movement_multiplayer_variant_settings_interface_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_movement");
            var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(Stream, tag);
            goof.GameEngineSettings = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting> 
            {
                new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting
                {
                    Name = CacheContext.StringTable.GetStringId($@"traits_movement"),
                    SettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.TemplatesTraitsMovement,
                    Options = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option>
                    {
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_movement_walking_speed"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_movement_personal_gravity"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_movement_vehicle_useage"),
                        },
                        new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                        {
                            ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_movement_sprint"),
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, goof);
        }
    }
}
