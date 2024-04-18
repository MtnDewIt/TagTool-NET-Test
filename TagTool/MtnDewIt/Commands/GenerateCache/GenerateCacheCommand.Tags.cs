using TagTool.MtnDewIt.Commands.GenerateCache.Tags;
using TagTool.Commands;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void UpdateTagData()
        {
            new multiplayer_global_multiplayer_messages_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new multiplayer_in_game_multiplayer_messages_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new multiplayer_in_game_survival_messages_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_global_strings_damage_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_global_strings_global_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_boot_betrayer_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_campaign_campaign_settings_strings_campaign_settings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_dialog_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_game_browser_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_game_options_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_in_progress_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_main_menu_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_selection_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_switch_lobby_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_start_menu_panes_settings_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_halox_start_menu_panes_settings_appearance_colors_strings_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ui_hud_hud_messages_multilingual_unicode_string_list(Cache, CacheContext, CacheStream);

            new ai_ai_dialogue_globals_ai_dialogue_globals(Cache, CacheContext, CacheStream);

            new ai_squad_templates_blank_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_campaign_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_line_break_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_1_banshee_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_1_banshee_nobomb_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_1_chopper_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_1_ghost_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_1_hunter_flak_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_1_hunter_plasma_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_1_shade_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_2_banshee_nobomb_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_2_bodyguards_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_2_ghost_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_2_jackal_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_4_brute_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_4_cov_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_4_grunt_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_brute_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_brute_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_brute_stealth_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_brute_stealth_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_brute_stealth_6_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_brute_turret_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_bugger_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_bugger_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_bugger_pupa_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_bugger_pupa_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_cap_grunt_eng_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_3_grunt_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_brute_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_brute_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_engineer_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_grunt_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_jackal_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_jackal_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_captain_solo_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_chieftain_flak_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_chieftain_hammer_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_chieftain_plasma_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_engineer_1_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_engineer_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_engineer_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_engineer_free_1_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_grunt_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_grunt_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_grunt_flak_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_grunt_flak_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_grunt_solo_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_grunt_turret_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_grunt_turret_undeployed_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_hunters_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_carbine_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_carbine_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_carbine_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_carbine_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_sniper_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_sniper_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_sniper_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_sniper_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jackal_solo_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jetpack_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jetpack_3_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jetpack_4_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_jetpack_solo_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_phantom_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_phantom_cheap_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_phantom_engineer_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_scorpion_2_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_scorpion_full_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_warthog_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_wraith_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_camp_wraith_aa_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_1_hunter_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_bonus_round_01_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_brute_jetpack_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_brute_pack_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_brute_stealth_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_bugger_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_bugger_day_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_chieftain_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_chieftain_1_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_chieftain_flak_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_chieftain_hammer_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_chieftain_plasma_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_covenant_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_grunt_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_jackal_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_jackal_sniper_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_phantom_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_sq_sur_phantom_cheap_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_survival_mode_squad_template(Cache, CacheContext, CacheStream);

            new ai_squad_templates_vehicles_squad_template(Cache, CacheContext, CacheStream);

            new fx_shield_impacts_overshield_1p_shield_impact(Cache, CacheContext, CacheStream);

            new fx_shield_impacts_overshield_3p_shield_impact(Cache, CacheContext, CacheStream);

            new globals_elite_3p_shield_impact_shield_impact(Cache, CacheContext, CacheStream);

            new globals_elite_fp_shield_impact_shield_impact(Cache, CacheContext, CacheStream);

            new globals_global_shield_impact_settings_shield_impact(Cache, CacheContext, CacheStream);

            new globals_globals_globals(Cache, CacheContext, CacheStream);

            new globals_input_globals_input_globals(Cache, CacheContext, CacheStream);

            new globals_masterchief_3p_shield_impact_shield_impact(Cache, CacheContext, CacheStream);

            new globals_masterchief_fp_shield_impact_shield_impact(Cache, CacheContext, CacheStream);

            new globals_rasterizer_globals_rasterizer_globals(Cache, CacheContext, CacheStream);

            new multiplayer_forge_globals_forge_globals_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_ctf_ctf_multiplayer_variant_settings_interface_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_ctf_ctf_respawn_on_capture_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_global_options_global_options_multiplayer_variant_settings_interface_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_global_options_rounds_reset_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_infection_infection_multiplayer_variant_settings_interface_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_infection_infection_haven_movement_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_infection_infection_haven_movement_time_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_infection_infection_respawn_on_haven_move_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_infection_infection_scoring_haven_arrival_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_map_overrides_traits_weapons_initial_primary_untemplated_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_map_overrides_traits_weapons_initial_secondary_untemplated_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_map_overrides_weapon_set_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_appearance_multiplayer_variant_settings_interface_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_appearance_active_camo_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_model_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_model_set_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_size_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_appearance_waypoints_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_movement_multiplayer_variant_settings_interface_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_movement_personal_gravity_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_movement_sprint_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_shields_damage_resistance_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_weapons_multiplayer_variant_settings_interface_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_weapons_infinite_ammo_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_weapons_initial_primary_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_weapons_initial_secondary_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_player_traits_template_traits_weapons_third_person_camera_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_respawn_options_respawn_spectating_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_respawn_options_respawn_time_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_game_variant_settings_social_options_team_changing_text_value_pair_definition(Cache, CacheContext, CacheStream);

            new multiplayer_mod_globals_mod_globals(Cache, CacheContext, CacheStream);

            new multiplayer_multiplayer_globals_multiplayer_globals(Cache, CacheContext, CacheStream);

            new multiplayer_survival_mode_globals_survival_mode_globals(Cache, CacheContext, CacheStream);

            new objects_characters_dervish_dervish_model(Cache, CacheContext, CacheStream);

            new objects_characters_dervish_dervish_biped(Cache, CacheContext, CacheStream);

            new objects_characters_dervish_dervish_model_animation_graph(Cache, CacheContext, CacheStream);

            new objects_characters_dervish_fx_shield_shield_down_light(Cache, CacheContext, CacheStream);

            new objects_characters_elite_elite_model_animation_graph(Cache, CacheContext, CacheStream);

            new objects_characters_elite_elite_sp_model(Cache, CacheContext, CacheStream);

            new objects_characters_elite_mp_elite_action_camera_camera_track(Cache, CacheContext, CacheStream);

            new objects_characters_elite_mp_elite_actions_player_action_set(Cache, CacheContext, CacheStream);

            new objects_characters_elite_mp_elite_mp_elite_model(Cache, CacheContext, CacheStream);

            new objects_characters_elite_mp_elite_mp_elite_biped(Cache, CacheContext, CacheStream);

            new objects_characters_elite_mp_elite_mp_elite_render_model(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_masterchief_model(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_masterchief_model_animation_graph(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_mp_masterchief_action_camera_camera_track(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_mp_masterchief_actions_player_action_set(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_mp_masterchief_mp_masterchief_model(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_mp_masterchief_mp_masterchief_biped(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_mp_masterchief_mp_masterchief_render_model(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_fx_flaming_ninja_effect(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_fx_shield_shield_down_light(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_bitmaps_mp_visor_cc_bitmap(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_masterchief_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_cobra_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_intruder_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_marathon_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_markv_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_ninja_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_odst_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_regulator_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_rogue_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_ryu_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_scout_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_masterchief_shaders_mp_visor_shader(Cache, CacheContext, CacheStream);

            new objects_characters_monitor_monitor_editor_biped(Cache, CacheContext, CacheStream);

            new objects_equipment_tripmine_tripmine_forge_equipment(Cache, CacheContext, CacheStream);

            new objects_levels_multi_shrine_behemoth_behemoth_forge_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_warthog_warthog_no_turret_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_warthog_warthog_snow_gauss_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_warthog_warthog_snow_no_turret_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_warthog_warthog_snow_troop_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_warthog_warthog_snow_wrecked_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_warthog_warthog_troop_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_warthog_warthog_wrecked_vehicle(Cache, CacheContext, CacheStream);

            new objects_vehicles_wraith_wraith_anti_air_vehicle(Cache, CacheContext, CacheStream);

            new sound_dsp_effects_sound_effect_templates_controller_0_headset_sound_effect_template(Cache, CacheContext, CacheStream);

            new sound_dsp_effects_sound_effect_templates_controller_1_headset_sound_effect_template(Cache, CacheContext, CacheStream);

            new sound_dsp_effects_sound_effect_templates_controller_2_headset_sound_effect_template(Cache, CacheContext, CacheStream);

            new sound_dsp_effects_sound_effect_templates_controller_3_headset_sound_effect_template(Cache, CacheContext, CacheStream);

            new sound_dsp_effects_sound_effect_templates_global_speaker_chorus_sound_effect_template(Cache, CacheContext, CacheStream);

            new sound_dsp_effects_sound_effect_templates_mono_distortion_sound_effect_template(Cache, CacheContext, CacheStream);

            new ui_chud_bitmaps_ballistic_meters_bitmap(Cache, CacheContext, CacheStream);

            new ui_chud_elite_chud_definition(Cache, CacheContext, CacheStream);

            new ui_chud_globals_chud_globals_definition(Cache, CacheContext, CacheStream);

            new ui_chud_multiplayer_intro_summary_editor_chud_definition(Cache, CacheContext, CacheStream);

            new ui_chud_multiplayer_intro_summary_infection_chud_definition(Cache, CacheContext, CacheStream);

            new ui_chud_scoreboard_chud_definition(Cache, CacheContext, CacheStream);

            new ui_chud_spartan_chud_definition(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_005_intro_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_010_jungle_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_020_base_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_030_outskirts_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_040_voi_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_050_floodvoi_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_070_waste_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_100_citadel_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_110_hc_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_120_halo_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_130_epilogue_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_armory_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_bunkerworld_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_c100_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_c200_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_chill_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_chillout_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_construct_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_cyberdyne_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_deadlock_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_descent_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_docks_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_fortress_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_ghosttown_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_guardian_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_h100_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_isolation_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_l200_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_l300_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_lockout_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_midship_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_placeholder_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_riverworld_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_avalanche_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_edge_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_reactor_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_turf_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_waterfall_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_salvation_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sandbox_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sc100_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sc110_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sc120_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sc130_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sc140_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sc150_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_shrine_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sidewinder_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_snowbound_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_spacecamp_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_warehouse_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_zanzibar_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_maps_map_list(Cache, CacheContext, CacheStream);

            new ui_halox_campaign_campaign_scoring_gui_skin_definition(Cache, CacheContext, CacheStream);

            new ui_halox_campaign_campaign_select_scoring_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_campaign_campaign_select_skulls_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_common_roster_roster_gui_skin_definition(Cache, CacheContext, CacheStream);

            new ui_halox_main_menu_main_menu_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_main_menu_main_menu_list_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_lobby_list_campaign_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_lobby_list_mapeditor_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_lobby_list_multiplayer_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_lobby_list_survival_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_pregame_lobby_campaign_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_pregame_lobby_mapeditor_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_pregame_lobby_multiplayer_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_pregame_lobby_survival_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_selection_pregame_survival_level_selection_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_selection_survival_select_difficulty_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_selection_survival_select_skulls_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_switch_lobby_lobbies_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_start_menu_panes_settings_sidebar_items_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_start_menu_panes_settings_display_sidebar_items_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_start_menu_panes_settings_display_spinner_display_subtitles_gui_datasource_definition(Cache, CacheContext, CacheStream);

            new ui_halox_start_menu_panes_settings_display_start_menu_settings_display_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_main_menu_user_interface_globals_definition(Cache, CacheContext, CacheStream);

            new ui_multiplayer_user_interface_globals_definition(Cache, CacheContext, CacheStream);

            new ui_single_player_user_interface_globals_definition(Cache, CacheContext, CacheStream);

            new levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_biped(Cache, CacheContext, CacheStream);

            new levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_model(Cache, CacheContext, CacheStream);

            new levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_render_model(Cache, CacheContext, CacheStream);

            switch (CacheType)
            {
                case GeneratedCacheType.Halo3:
                    new levels_ui_mainmenu_mainmenu_h3_scenario(Cache, CacheContext, CacheStream);
                    break;
            
                case GeneratedCacheType.Halo3Mythic:
                    new levels_ui_mainmenu_mainmenu_mythic_scenario(Cache, CacheContext, CacheStream);
                    break;
            
                case GeneratedCacheType.Halo3ODST:
                    new levels_ui_mainmenu_mainmenu_odst_scenario(Cache, CacheContext, CacheStream);
                    break;

                case GeneratedCacheType.ElDewrito:
                    new levels_ui_mainmenu_mainmenu_eldewrito_scenario(Cache, CacheContext, CacheStream);
                    break;

                case GeneratedCacheType.HaloOnline:
                    new levels_ui_mainmenu_mainmenu_halo_online_scenario(Cache, CacheContext, CacheStream);
                    break;
            }

            Cache.SaveStrings();
        }
    }
}