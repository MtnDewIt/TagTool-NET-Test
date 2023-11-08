using System.Collections.Generic;
using TagTool.Tags.Definitions;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void GameVariantSettingsSetup()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_third_person_camera")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = (TextValuePairDefinition.GameVariantParameters)670;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_weapons_third_person_camera");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_weapons_third_person_camera_desc");
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
                                Name = CacheContext.StringTable.GetStringId($@"enabled"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"disabled"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_movement_sprint")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = (TextValuePairDefinition.GameVariantParameters)692;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_movement_sprint");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_movement_sprint_desc");
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
                                Name = CacheContext.StringTable.GetStringId($@"enabled"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"disabled"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_size")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateVisualAura;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_player_size");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_player_size_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Name = CacheContext.StringTable.GetStringId($@"unchanged"),
                                Description = CacheContext.StringTable.GetStringId($@"unchanged_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"percent_10"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 3,
                                Name = CacheContext.StringTable.GetStringId($@"percent_15"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 4,
                                Name = CacheContext.StringTable.GetStringId($@"percent_25"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 5,
                                Name = CacheContext.StringTable.GetStringId($@"percent_35"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 6,
                                Name = CacheContext.StringTable.GetStringId($@"percent_50"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 7,
                                Name = CacheContext.StringTable.GetStringId($@"percent_75"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 8,
                                Name = CacheContext.StringTable.GetStringId($@"percent_100"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 9,
                                Name = CacheContext.StringTable.GetStringId($@"percent_125"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 10,
                                Name = CacheContext.StringTable.GetStringId($@"percent_150"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 11,
                                Name = CacheContext.StringTable.GetStringId($@"percent_200"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 12,
                                Name = CacheContext.StringTable.GetStringId($@"percent_300"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 13,
                                Name = CacheContext.StringTable.GetStringId($@"percent_500"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 14,
                                Name = CacheContext.StringTable.GetStringId($@"percent_750"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 15,
                                Name = CacheContext.StringTable.GetStringId($@"percent_1000"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 16,
                                Name = CacheContext.StringTable.GetStringId($@"percent_1500"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 17,
                                Name = CacheContext.StringTable.GetStringId($@"percent_2000"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 18,
                                Name = CacheContext.StringTable.GetStringId($@"percent_3000"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_model_set")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = (TextValuePairDefinition.GameVariantParameters)648;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_player_model_set");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_player_model_set_desc");
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_model")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = (TextValuePairDefinition.GameVariantParameters)626;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_player_model");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_player_model_desc");
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\global_options\rounds_reset")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalRoundsReset;
                        sily.Name = CacheContext.StringTable.GetStringId($@"rounds_reset");
                        sily.Description = CacheContext.StringTable.GetStringId($@"rounds_reset_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Name = CacheContext.StringTable.GetStringId($@"rounds_reset_none"),
                                Description = CacheContext.StringTable.GetStringId($@"rounds_reset_none_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"rounds_reset_players"),
                                Description = CacheContext.StringTable.GetStringId($@"rounds_reset_players_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"rounds_reset_all"),
                                Description = CacheContext.StringTable.GetStringId($@"rounds_reset_all_desc"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\respawn_options\respawn_spectating")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalNewUnknown;
                        sily.Name = CacheContext.StringTable.GetStringId($@"respawn_spectating");
                        sily.Description = CacheContext.StringTable.GetStringId($@"respawn_spectating_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"allowed"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                Name = CacheContext.StringTable.GetStringId($@"not_allowed"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\ctf\ctf_respawn_on_capture")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntCtfRespawnDelay;
                        sily.Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture");
                        sily.Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                Name = CacheContext.StringTable.GetStringId($@"disabled"),
                                Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_disabled_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_ally"),
                                Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_ally_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_enemy"),
                                Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_enemy_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 3,
                                Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_all"),
                                Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_all_desc"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\infection\infection_haven_movement")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionHavenMovement;
                        sily.Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement");
                        sily.Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_none_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_none"),
                                Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_none_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_random"),
                                Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_random_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_sequence"),
                                Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_sequence_desc"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\infection\infection_haven_movement_time")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionHavenMovementTime;
                        sily.Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_time");
                        sily.Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_time_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                Name = CacheContext.StringTable.GetStringId($@"disabled"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 5,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_5"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 10,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_10"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 15,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_15"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 20,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_20"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 30,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_30"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 45,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_45"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 60,
                                Name = CacheContext.StringTable.GetStringId($@"time_minutes_1"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 120,
                                Name = CacheContext.StringTable.GetStringId($@"time_minutes_2"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\infection\infection_respawn_on_haven_move")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionRespawnOnHavenMove;
                        sily.Name = CacheContext.StringTable.GetStringId($@"infection_respawn_on_haven_move");
                        sily.Description = CacheContext.StringTable.GetStringId($@"infection_respawn_on_haven_move_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                Name = CacheContext.StringTable.GetStringId($@"disabled"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"enabled"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\infection\infection_scoring_haven_arrival")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionHavenArrivalPoints;
                        sily.Name = CacheContext.StringTable.GetStringId($@"infection_scoring_haven_arrival");
                        sily.Description = CacheContext.StringTable.GetStringId($@"infection_scoring_haven_arrival_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -10,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_10"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -9,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_9"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -8,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_8"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -7,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_7"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -6,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_6"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -5,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_5"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -4,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_4"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -3,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_3"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -2,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_2"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = -1,
                                Name = CacheContext.StringTable.GetStringId($@"int_minus_1"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                Name = CacheContext.StringTable.GetStringId($@"int_0"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"int_1"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"int_2"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 3,
                                Name = CacheContext.StringTable.GetStringId($@"int_3"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 4,
                                Name = CacheContext.StringTable.GetStringId($@"int_4"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 5,
                                Name = CacheContext.StringTable.GetStringId($@"int_5"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 6,
                                Name = CacheContext.StringTable.GetStringId($@"int_6"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 7,
                                Name = CacheContext.StringTable.GetStringId($@"int_7"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 8,
                                Name = CacheContext.StringTable.GetStringId($@"int_8"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 9,
                                Name = CacheContext.StringTable.GetStringId($@"int_9"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 10,
                                Name = CacheContext.StringTable.GetStringId($@"int_10"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_infinite_ammo") 
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateInfiniteAmmo;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_weapons_infinite_ammo");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_weapons_infinite_ammo_desc");
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
                                Name = CacheContext.StringTable.GetStringId($@"disabled"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"enabled"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 3,
                                Name = CacheContext.StringTable.GetStringId($@"bottomless_clip"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_shields_damage_resistance") 
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_initial_primary")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.SidGlobalTraitsTemplatePrimaryWeapon;
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr"),
                            //},
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //},
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
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_initial_secondary")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.SidGlobalTraitsTemplateSecondaryWeapon;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_weapons_initial_secondary");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_weapons_initial_secondary_desc");
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr"),
                            //},
                            new TextValuePairDefinition.TextValuePair
                            {
                                ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                                StringidValue = CacheContext.StringTable.GetStringId($@"energy_sword"),
                                Name = CacheContext.StringTable.GetStringId($@"traits_weapons_sword"),
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
                                StringidValue = CacheContext.StringTable.GetStringId($@"needler"),
                                Name = CacheContext.StringTable.GetStringId($@"traits_weapons_needler"),
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //},
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
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_movement_personal_gravity")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_active_camo")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateActiveCamo;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_desc");
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
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_off"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_off_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_bad"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_bad_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 3,
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_poor"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_poor_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 4,
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_good"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_good_desc"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_waypoints")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateWaypoint;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_desc");
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
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_none"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_none_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_allies"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_allies_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 3,
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_all"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_all_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 5,
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_nametag_none"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_nametag_none_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 4,
                                Name = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_nametag_allies"),
                                Description = CacheContext.StringTable.GetStringId($@"traits_appearance_waypoints_nametag_allies_desc"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\map_overrides\traits_weapons_initial_primary_untemplated")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr"),
                            //},
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //},
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
                        CacheContext.Serialize(stream, tag, sily);
                    }
                    
                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\map_overrides\traits_weapons_initial_secondary_untemplated")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.SidGlobalBaseTraitsSecondaryWeapon;
                        sily.Name = CacheContext.StringTable.GetStringId($@"traits_weapons_initial_secondary");
                        sily.Description = CacheContext.StringTable.GetStringId($@"traits_weapons_initial_secondary_desc");
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr"),
                            //},
                            new TextValuePairDefinition.TextValuePair
                            {
                                ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                                StringidValue = CacheContext.StringTable.GetStringId($@"energy_sword"),
                                Name = CacheContext.StringTable.GetStringId($@"traits_weapons_sword"),
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
                                StringidValue = CacheContext.StringTable.GetStringId($@"needler"),
                                Name = CacheContext.StringTable.GetStringId($@"traits_weapons_needler"),
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
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"assault_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"battle_rifle_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v5"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"covenant_carbine_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v1"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"dmr_v4"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"magnum_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"excavator_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_pistol_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"plasma_rifle_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v3"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v2"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v6"),
                            //},
                            //new TextValuePairDefinition.TextValuePair
                            //{
                            //    ExpectedValueType = TextValuePairDefinition.TextValuePair.ExpectedValueTypeValue.StringidReference,
                            //    StringidValue = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //    Name = CacheContext.StringTable.GetStringId($@"smg_v4"),
                            //},
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
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\map_overrides\weapon_set")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\respawn_options\respawn_time")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalRespawnTime;
                        sily.Name = CacheContext.StringTable.GetStringId($@"respawn_time");
                        sily.Description = CacheContext.StringTable.GetStringId($@"respawn_time_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Name = CacheContext.StringTable.GetStringId($@"time_instant"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_1"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_2"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 3,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_3"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 4,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_4"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                EnumeratedValue = 5,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_5"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 6,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_6"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 7,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_7"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 8,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_8"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 9,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_9"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 10,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_10"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 11,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_11"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 12,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_12"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 13,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_13"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 14,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_14"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 15,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_15"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 16,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_16"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 17,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_17"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 18,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_18"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 19,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_19"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 20,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_20"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 21,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_21"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 22,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_22"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 23,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_23"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 24,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_24"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 25,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_25"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 30,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_30"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 45,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_45"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 60,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_60"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 90,
                                Name = CacheContext.StringTable.GetStringId($@"time_seconds_90"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 120,
                                Name = CacheContext.StringTable.GetStringId($@"time_minutes_2"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 180,
                                Name = CacheContext.StringTable.GetStringId($@"time_minutes_3"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }

                    if (tag.IsInGroup("sily") && tag.Name == $@"multiplayer\game_variant_settings\social_options\team_changing")
                    {
                        var sily = CacheContext.Deserialize<TextValuePairDefinition>(stream, tag);
                        sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTeamChanging;
                        sily.Name = CacheContext.StringTable.GetStringId($@"social_team_changing");
                        sily.Description = CacheContext.StringTable.GetStringId($@"social_team_changing_desc");
                        sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
                        {
                            new TextValuePairDefinition.TextValuePair
                            {
                                Name = CacheContext.StringTable.GetStringId($@"not_allowed"),
                                Description = CacheContext.StringTable.GetStringId($@"social_team_changing_disabled_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                                EnumeratedValue = 1,
                                Name = CacheContext.StringTable.GetStringId($@"allowed"),
                                Description = CacheContext.StringTable.GetStringId($@"social_team_changing_enabled_desc"),
                            },
                            new TextValuePairDefinition.TextValuePair
                            {
                                EnumeratedValue = 2,
                                Name = CacheContext.StringTable.GetStringId($@"balanced"),
                                Description = CacheContext.StringTable.GetStringId($@"social_team_changing_balanced_desc"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, sily);
                    }



                    if (tag.IsInGroup("goof") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_appearance") 
                    {
                        var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, goof);
                    }

                    if (tag.IsInGroup("goof") && tag.Name == $@"multiplayer\game_variant_settings\global_options\global_options")
                    {
                        var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, goof);
                    }

                    if (tag.IsInGroup("goof") && tag.Name == $@"multiplayer\game_variant_settings\ctf\ctf")
                    {
                        var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, goof);
                    }

                    if (tag.IsInGroup("goof") && tag.Name == $@"multiplayer\game_variant_settings\infection\infection")
                    {
                        var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(stream, tag);
                        goof.GameEngineSettings = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting> 
                        {
                            new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting
                            {
                                Name = CacheContext.StringTable.GetStringId($@"infection"),
                                SettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.InfectionMain,
                                Options = new List<MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option>
                                {
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        ExplicitSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\infection\infection_scoring"),
                                        SubmenuName = CacheContext.StringTable.GetStringId($@"infection_scoring"),
                                        SubmenuDescription = CacheContext.StringTable.GetStringId($@"infection_scoring_desc"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        TemplateBasedSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\player_traits_template"),
                                        SubmenuSettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.InfectionZombieTraitsMain,
                                        SubmenuName = CacheContext.StringTable.GetStringId($@"infection_traits_zombie"),
                                        SubmenuDescription = CacheContext.StringTable.GetStringId($@"infection_traits_zombie_desc"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        TemplateBasedSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\player_traits_template"),
                                        SubmenuSettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.InfectionAlphaZombieTraitsMain,
                                        SubmenuName = CacheContext.StringTable.GetStringId($@"infection_traits_alpha"),
                                        SubmenuDescription = CacheContext.StringTable.GetStringId($@"infection_traits_alpha_desc"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        TemplateBasedSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\player_traits_dynamic_template"),
                                        SubmenuSettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.InfectionLastManTraitsMain,
                                        SubmenuName = CacheContext.StringTable.GetStringId($@"infection_traits_last_man"),
                                        SubmenuDescription = CacheContext.StringTable.GetStringId($@"infection_traits_last_man_desc"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_next_zombie"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_haven_movement"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_haven_movement_time"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_respawn_on_haven_move"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        ValuePairs = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_scoring_haven_arrival"),
                                    },
                                    new MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.Option
                                    {
                                        TemplateBasedSubmenu = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\player_traits_template\player_traits_dynamic_template"),
                                        SubmenuSettingCategory = MultiplayerVariantSettingsInterfaceDefinition.GameEngineSetting.SettingCategoryValue.InfectionSafeHavenTraitsMain,
                                        SubmenuName = CacheContext.StringTable.GetStringId($@"infection_traits_safe_haven"),
                                        SubmenuDescription = CacheContext.StringTable.GetStringId($@"infection_traits_safe_haven_desc"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, goof);
                    }

                    if (tag.IsInGroup("goof") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_weapons") 
                    {
                        var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, goof);
                    }

                    if (tag.IsInGroup("goof") && tag.Name == $@"multiplayer\game_variant_settings\player_traits_template\traits_movement")
                    {
                        var goof = CacheContext.Deserialize<MultiplayerVariantSettingsInterfaceDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, goof);
                    }
                }
            }
        }
    }
}