using TagTool.MtnDewIt.Commands.ConvertCache.Tags;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.ConvertCache 
{
    partial class ConvertCacheCommand : Command 
    {
        public void UpdateTagData()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                Cache.StringTable.Add($@"thunder_clap");
                Cache.StringTable.Add($@"twerk");
                Cache.StringTable.Add($@"dance1test");
                Cache.StringTable.Add($@"dance1");
                Cache.StringTable.Add($@"mixamo");
                Cache.StringTable.Add($@"fingerlay");
                Cache.StringTable.Add($@"fingerstand");
                Cache.StringTable.Add($@"breakdance");
                Cache.StringTable.Add($@"hiphop");
                Cache.StringTable.Add($@"ballskick");
                Cache.StringTable.Add($@"con_blast_exit");
                Cache.StringTable.Add($@"flaming_ninja_active");
                Cache.StringTable.Add($@"menu_spartan2");
                Cache.StringTable.Add($@"menu_spartan1");
                Cache.StringTable.Add($@"mainmenu_odst01");
                Cache.SaveStrings();
                
                new ui_chud_bitmaps_stamina_icon_elite_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_placeholder_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_armory_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_bunkerworld_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_chillout_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_descent_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_docks_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_fortress_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_ghosttown_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_lockout_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_midship_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sandbox_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sidewinder_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_spacecamp_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_warehouse_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_chill_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_construct_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_cyberdyne_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_deadlock_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_guardian_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_isolation_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_riverworld_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_s3d_avalanche_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_s3d_edge_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_s3d_reactor_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_s3d_turf_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_s3d_waterfall_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_salvation_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_shrine_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_snowbound_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_zanzibar_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_005_intro_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_010_jungle_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_020_base_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_030_outskirts_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_040_voi_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_050_floodvoi_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_070_waste_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_100_citadel_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_110_hc_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_120_halo_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_130_epilogue_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_c100_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_c200_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_h100_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_l200_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_l300_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sc100_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sc110_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sc120_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sc130_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sc140_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_common_map_bitmaps_sc150_bitmap(Cache, CacheContext, stream);

                new ui_eldewrito_maps_map_list(Cache, CacheContext, stream);

                new objects_characters_masterchief_mp_masterchief_action_camera_camera_track(Cache, CacheContext, stream);

                new objects_characters_masterchief_mp_masterchief_actions_player_action_set(Cache, CacheContext, stream);

                new objects_characters_elite_mp_elite_action_camera_camera_track(Cache, CacheContext, stream);

                new objects_characters_elite_mp_elite_actions_player_action_set(Cache, CacheContext, stream);

                new objects_characters_masterchief_masterchief_model_animation_graph(Cache, CacheContext, stream);

                new objects_characters_elite_elite_model_animation_graph(Cache, CacheContext, stream);

                new objects_characters_dervish_dervish_model_animation_graph(Cache, CacheContext, stream);

                new objects_characters_masterchief_bitmaps_mp_visor_cc_bitmap(Cache, CacheContext, stream);

                new ui_halox_game_browser_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_dialog_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_main_menu_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_start_menu_panes_settings_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_start_menu_panes_settings_appearance_colors_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_switch_lobby_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_selection_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_in_progress_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_campaign_campaign_settings_strings_campaign_settings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_game_options_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_global_strings_global_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new ui_halox_boot_betrayer_strings_multilingual_unicode_string_list(Cache, CacheContext, stream);

                new globals_globals_globals(Cache, CacheContext, stream);

                new multiplayer_multiplayer_globals_multiplayer_globals(Cache, CacheContext, stream);

                new multiplayer_mod_globals_mod_globals(Cache, CacheContext, stream);

                new objects_multi_spawning_initial_spawn_point_scenery(Cache, CacheContext, stream);

                new objects_multi_spawning_respawn_zone_scenery(Cache, CacheContext, stream);

                new multiplayer_forge_globals_forge_globals_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_weapons_third_person_camera_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_movement_sprint_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_size_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_model_set_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_model_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_global_options_rounds_reset_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_respawn_options_respawn_spectating_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_ctf_ctf_respawn_on_capture_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_infection_infection_haven_movement_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_infection_infection_haven_movement_time_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_infection_infection_respawn_on_haven_move_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_infection_infection_scoring_haven_arrival_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_weapons_infinite_ammo_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_shields_damage_resistance_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_weapons_initial_primary_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_weapons_initial_secondary_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_movement_personal_gravity_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_appearance_active_camo_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_appearance_waypoints_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_map_overrides_traits_weapons_initial_primary_untemplated_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_map_overrides_traits_weapons_initial_secondary_untemplated_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_map_overrides_weapon_set_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_respawn_options_respawn_time_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_social_options_team_changing_text_value_pair_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_appearance_multiplayer_variant_settings_interface_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_global_options_global_options_multiplayer_variant_settings_interface_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_ctf_ctf_multiplayer_variant_settings_interface_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_infection_infection_multiplayer_variant_settings_interface_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_weapons_multiplayer_variant_settings_interface_definition(Cache, CacheContext, stream);

                new multiplayer_game_variant_settings_player_traits_template_traits_movement_multiplayer_variant_settings_interface_definition(Cache, CacheContext, stream);

                new ui_main_menu_user_interface_globals_definition(Cache, CacheContext, stream);

                new ui_multiplayer_user_interface_globals_definition(Cache, CacheContext, stream);

                new ui_single_player_user_interface_globals_definition(Cache, CacheContext, stream);

                new globals_global_shield_impact_settings_shield_impact(Cache, CacheContext, stream);

                new globals_masterchief_3p_shield_impact_shield_impact(Cache, CacheContext, stream);

                new globals_masterchief_fp_shield_impact_shield_impact(Cache, CacheContext, stream);

                new globals_elite_3p_shield_impact_shield_impact(Cache, CacheContext, stream);

                new globals_elite_fp_shield_impact_shield_impact(Cache, CacheContext, stream);

                new fx_shield_impacts_overshield_3p_shield_impact(Cache, CacheContext, stream);

                new fx_shield_impacts_overshield_1p_shield_impact(Cache, CacheContext, stream);

                new ui_halox_main_menu_main_menu_list_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_main_menu_main_menu_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_switch_lobby_lobbies_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_start_menu_panes_settings_sidebar_items_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_start_menu_panes_settings_display_sidebar_items_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_start_menu_panes_settings_display_spinner_display_subtitles_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_start_menu_panes_settings_display_start_menu_settings_display_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_lobby_list_campaign_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_campaign_campaign_scoring_gui_skin_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_pregame_lobby_campaign_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_campaign_campaign_select_scoring_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_campaign_campaign_select_skulls_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_lobby_list_survival_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_pregame_lobby_survival_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_selection_pregame_survival_level_selection_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_selection_survival_select_difficulty_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_selection_survival_select_skulls_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_lobby_list_multiplayer_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_pregame_lobby_multiplayer_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_lobby_list_mapeditor_gui_datasource_definition(Cache, CacheContext, stream);

                new ui_halox_pregame_lobby_pregame_lobby_mapeditor_gui_screen_widget_definition(Cache, CacheContext, stream);

                new ui_halox_common_roster_roster_gui_skin_definition(Cache, CacheContext, stream);

                new ui_chud_spartan_chud_definition(Cache, CacheContext, stream);

                new ui_chud_elite_chud_definition(Cache, CacheContext, stream);

                new ui_chud_scoreboard_chud_definition(Cache, CacheContext, stream);

                new ui_chud_scoreboard_elite_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_assault_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_ctf_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_editor_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_infection_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_juggernaut_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_king_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_oddball_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_slayer_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_territories_chud_definition(Cache, CacheContext, stream);

                new ui_chud_multiplayer_intro_summary_vip_chud_definition(Cache, CacheContext, stream);

                new ui_chud_assault_rifle_chud_definition(Cache, CacheContext, stream);

                new ui_chud_assault_rifle_v5_chud_definition(Cache, CacheContext, stream);

                new ui_chud_assault_rifle_v2_chud_definition(Cache, CacheContext, stream);

                new ui_chud_assault_rifle_v6_chud_definition(Cache, CacheContext, stream);

                new ui_chud_assault_rifle_v3_chud_definition(Cache, CacheContext, stream);

                new ui_chud_battle_rifle_chud_definition(Cache, CacheContext, stream);

                new ui_chud_battle_rifle_v2_chud_definition(Cache, CacheContext, stream);

                new ui_chud_battle_rifle_v3_chud_definition(Cache, CacheContext, stream);

                new ui_chud_battle_rifle_v4_chud_definition(Cache, CacheContext, stream);

                new ui_chud_battle_rifle_v6_chud_definition(Cache, CacheContext, stream);

                new ui_chud_battle_rifle_v5_chud_definition(Cache, CacheContext, stream);

                new ui_chud_battle_rifle_v1_chud_definition(Cache, CacheContext, stream);

                new ui_chud_beam_rifle_chud_definition(Cache, CacheContext, stream);

                new ui_chud_brute_shot_chud_definition(Cache, CacheContext, stream);

                new ui_chud_carbine_chud_definition(Cache, CacheContext, stream);

                new ui_chud_carbine_v2_chud_definition(Cache, CacheContext, stream);

                new ui_chud_carbine_v4_chud_definition(Cache, CacheContext, stream);

                new ui_chud_carbine_v6_chud_definition(Cache, CacheContext, stream);

                new ui_chud_carbine_v3_chud_definition(Cache, CacheContext, stream);

                new ui_chud_carbine_v1_chud_definition(Cache, CacheContext, stream);

                new ui_chud_dmr_chud_definition(Cache, CacheContext, stream);

                new ui_chud_dmr_v2_chud_definition(Cache, CacheContext, stream);

                new ui_chud_dmr_v1_chud_definition(Cache, CacheContext, stream);

                new ui_chud_dmr_v4_chud_definition(Cache, CacheContext, stream);

                new ui_chud_dmr_v6_chud_definition(Cache, CacheContext, stream);

                new ui_chud_dmr_v3_chud_definition(Cache, CacheContext, stream);

                new ui_chud_excavator_chud_definition(Cache, CacheContext, stream);

                new ui_chud_excavator_v3_chud_definition(Cache, CacheContext, stream);

                new ui_chud_flamethrower_chud_definition(Cache, CacheContext, stream);

                new ui_chud_fuel_rod_cannon_chud_definition(Cache, CacheContext, stream);

                new ui_chud_hammer_chud_definition(Cache, CacheContext, stream);

                new ui_chud_machinegun_turret_chud_definition(Cache, CacheContext, stream);

                new ui_chud_magnum_chud_definition(Cache, CacheContext, stream);

                new ui_chud_magnum_v2_chud_definition(Cache, CacheContext, stream);

                new ui_chud_magnum_v3_chud_definition(Cache, CacheContext, stream);

                new ui_chud_missile_chud_definition(Cache, CacheContext, stream);

                new ui_chud_needler_chud_definition(Cache, CacheContext, stream);

                new ui_chud_plasma_pistol_chud_definition(Cache, CacheContext, stream);

                new ui_chud_plasma_pistol_v3_chud_definition(Cache, CacheContext, stream);

                new ui_chud_plasma_rifle_chud_definition(Cache, CacheContext, stream);

                new ui_chud_plasma_rifle_v6_chud_definition(Cache, CacheContext, stream);

                new ui_chud_plasma_turret_chud_definition(Cache, CacheContext, stream);

                new ui_chud_rocket_chud_definition(Cache, CacheContext, stream);

                new ui_chud_sentinel_beam_chud_definition(Cache, CacheContext, stream);

                new ui_chud_shotgun_chud_definition(Cache, CacheContext, stream);

                new ui_chud_smg_chud_definition(Cache, CacheContext, stream);

                new ui_chud_smg_v2_chud_definition(Cache, CacheContext, stream);

                new ui_chud_smg_v4_chud_definition(Cache, CacheContext, stream);

                new ui_chud_smg_v6_chud_definition(Cache, CacheContext, stream);

                new ui_chud_smg_v1_chud_definition(Cache, CacheContext, stream);

                new ui_chud_sniper_rifle_chud_definition(Cache, CacheContext, stream);

                new ui_chud_spartan_laser_chud_definition(Cache, CacheContext, stream);

                new ui_chud_spike_rifle_chud_definition(Cache, CacheContext, stream);

                new ui_chud_sword_chud_definition(Cache, CacheContext, stream);

                new ui_chud_globals_chud_globals_definition(Cache, CacheContext, stream);

                new objects_characters_masterchief_mp_masterchief_mp_masterchief_model(Cache, CacheContext, stream);

                new objects_characters_masterchief_masterchief_model(Cache, CacheContext, stream);

                new objects_characters_elite_mp_elite_mp_elite_model(Cache, CacheContext, stream);

                new objects_characters_elite_elite_sp_model(Cache, CacheContext, stream);

                new objects_characters_dervish_dervish_model(Cache, CacheContext, stream);

                new objects_characters_masterchief_mp_masterchief_mp_masterchief_biped(Cache, CacheContext, stream);

                new objects_characters_masterchief_mp_masterchief_mp_masterchief_render_model(Cache, CacheContext, stream);

                new objects_characters_masterchief_masterchief_biped(Cache, CacheContext, stream);

                new objects_characters_masterchief_fx_flaming_ninja_effect(Cache, CacheContext, stream);

                new objects_characters_masterchief_fx_shield_shield_down_light(Cache, CacheContext, stream);

                new objects_characters_elite_mp_elite_mp_elite_biped(Cache, CacheContext, stream);

                new objects_characters_elite_mp_elite_mp_elite_render_model(Cache, CacheContext, stream);

                new objects_characters_dervish_dervish_biped(Cache, CacheContext, stream);

                new objects_characters_dervish_fx_shield_shield_down_light(Cache, CacheContext, stream);

                new objects_characters_monitor_monitor_editor_biped(Cache, CacheContext, stream);

                new objects_equipment_hologram_bipeds_masterchief_hologram_biped(Cache, CacheContext, stream);

                new objects_equipment_hologram_bipeds_masterchief_hologram_model(Cache, CacheContext, stream);

                new objects_equipment_hologram_bipeds_elite_hologram_biped(Cache, CacheContext, stream);

                new objects_equipment_hologram_bipeds_elite_hologram_model(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_cobra_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_intruder_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_marathon_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_markv_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_ninja_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_odst_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_regulator_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_rogue_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_ryu_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_scout_visor_shader(Cache, CacheContext, stream);

                new objects_characters_masterchief_shaders_mp_visor_shader(Cache, CacheContext, stream);

                new objects_weapons_melee_energy_blade_energy_blade_weapon(Cache, CacheContext, stream);

                new objects_weapons_melee_energy_blade_energy_blade_useless_weapon(Cache, CacheContext, stream);

                new objects_weapons_melee_energy_blade_unarmed_weapon(Cache, CacheContext, stream);

                new objects_weapons_melee_gravity_hammer_gravity_hammer_weapon(Cache, CacheContext, stream);

                new objects_weapons_multiplayer_assault_bomb_assault_bomb_weapon(Cache, CacheContext, stream);

                new objects_weapons_multiplayer_ball_ball_weapon(Cache, CacheContext, stream);

                new objects_weapons_multiplayer_flag_flag_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_excavator_excavator_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_excavator_excavator_v3_excavator_v3_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_magnum_magnum_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_magnum_magnum_v2_magnum_v2_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_magnum_magnum_v3_magnum_v3_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_needler_needler_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_plasma_pistol_plasma_pistol_weapon(Cache, CacheContext, stream);

                new objects_weapons_pistol_plasma_pistol_plasma_pistol_v3_plasma_pistol_v3_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_assault_rifle_assault_rifle_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_assault_rifle_assault_rifle_v2_assault_rifle_v2_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_assault_rifle_assault_rifle_v3_assault_rifle_v3_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_assault_rifle_assault_rifle_v5_assault_rifle_v5_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_assault_rifle_assault_rifle_v6_assault_rifle_v6_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_battle_rifle_battle_rifle_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_battle_rifle_battle_rifle_v1_battle_rifle_v1_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_battle_rifle_battle_rifle_v2_battle_rifle_v2_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_battle_rifle_battle_rifle_v3_battle_rifle_v3_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_battle_rifle_battle_rifle_v4_battle_rifle_v4_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_battle_rifle_battle_rifle_v5_battle_rifle_v5_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_battle_rifle_battle_rifle_v6_battle_rifle_v6_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_beam_rifle_beam_rifle_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_covenant_carbine_covenant_carbine_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_covenant_carbine_covenant_carbine_v1_covenant_carbine_v1_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_covenant_carbine_covenant_carbine_v2_covenant_carbine_v2_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_covenant_carbine_covenant_carbine_v3_covenant_carbine_v3_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_covenant_carbine_covenant_carbine_v4_covenant_carbine_v4_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_covenant_carbine_covenant_carbine_v5_covenant_carbine_v5_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_covenant_carbine_covenant_carbine_v6_covenant_carbine_v6_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_dmr_dmr_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_dmr_dmr_v1_dmr_v1_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_dmr_dmr_v2_dmr_v2_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_dmr_dmr_v3_dmr_v3_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_dmr_dmr_v4_dmr_v4_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_dmr_dmr_v6_dmr_v6_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_plasma_rifle_plasma_rifle_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_plasma_rifle_plasma_rifle_v6_plasma_rifle_v6_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_shotgun_shotgun_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_smg_smg_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_smg_smg_v1_smg_v1_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_smg_smg_v2_smg_v2_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_smg_smg_v4_smg_v4_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_smg_smg_v6_smg_v6_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_sniper_rifle_sniper_rifle_weapon(Cache, CacheContext, stream);

                new objects_weapons_rifle_spike_rifle_spike_rifle_weapon(Cache, CacheContext, stream);

                new objects_weapons_support_high_flak_cannon_flak_cannon_weapon(Cache, CacheContext, stream);

                new objects_weapons_support_high_rocket_launcher_rocket_launcher_weapon(Cache, CacheContext, stream);

                new objects_weapons_support_high_spartan_laser_spartan_laser_weapon(Cache, CacheContext, stream);

                new objects_weapons_support_low_brute_shot_brute_shot_weapon(Cache, CacheContext, stream);

                new objects_weapons_support_low_sentinel_gun_sentinel_gun_weapon(Cache, CacheContext, stream);

                new objects_equipment_concussiveblast_equipment_concussiveblast_equipment_equipment(Cache, CacheContext, stream);

                new levels_ui_mainmenu_mainmenu_scenario(Cache, CacheContext, stream);

                new levels_multi_guardian_guardian_scenario(Cache, CacheContext, stream);

                new levels_multi_riverworld_riverworld_scenario(Cache, CacheContext, stream);

                new levels_multi_s3d_avalanche_s3d_avalanche_scenario(Cache, CacheContext, stream);

                new levels_multi_s3d_edge_s3d_edge_scenario(Cache, CacheContext, stream);

                new levels_multi_s3d_reactor_s3d_reactor_scenario(Cache, CacheContext, stream);

                new levels_multi_s3d_turf_s3d_turf_scenario(Cache, CacheContext, stream);

                new levels_multi_cyberdyne_cyberdyne_scenario(Cache, CacheContext, stream);

                new levels_multi_chill_chill_scenario(Cache, CacheContext, stream);

                new levels_dlc_bunkerworld_bunkerworld_scenario(Cache, CacheContext, stream);

                new levels_multi_zanzibar_zanzibar_scenario(Cache, CacheContext, stream);

                new levels_multi_deadlock_deadlock_scenario(Cache, CacheContext, stream);

                new levels_multi_shrine_shrine_scenario(Cache, CacheContext, stream);

                new objects_eldewrito_reforge_block_01x20x20_black_mainmenu_crate(Cache, CacheContext, stream);

                new objects_eldewrito_reforge_block_01x20x20_black_mainmenu_model(Cache, CacheContext, stream);

                new objects_eldewrito_reforge_block_01x20x20_black_mainmenu_render_model(Cache, CacheContext, stream);

                new levels_ui_mainmenu_objects_spartan_cheap_spartan_cheap_biped(Cache, CacheContext, stream);

                new levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_biped(Cache, CacheContext, stream);

                new levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_model(Cache, CacheContext, stream);

                new levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_render_model(Cache, CacheContext, stream);
            }
        }
    }
}