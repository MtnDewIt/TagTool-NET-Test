using System.Collections.Generic;

namespace TagTool.Scripting
{
    public class ScriptInfoHaloReach
    {
        public static Dictionary<int, string> ValueTypes = new Dictionary<int, string>
        {
            [0x00] = "unparsed",
            [0x01] = "special_form",
            [0x02] = "function_name",
            [0x03] = "passthrough",
            [0x04] = "void",
            [0x05] = "boolean",
            [0x06] = "real",
            [0x07] = "short",
            [0x08] = "long",
            [0x09] = "string",
            [0x0A] = "script",
            [0x0B] = "string_id",
            [0x0C] = "unit_seat_mapping",
            [0x0D] = "trigger_volume",
            [0x0E] = "cutscene_flag",
            [0x0F] = "cutscene_camera_point",
            [0x10] = "cutscene_title",
            [0x11] = "cutscene_recording",
            [0x12] = "device_group",
            [0x13] = "ai",
            [0x14] = "ai_command_list",
            [0x15] = "ai_command_script",
            [0x16] = "ai_behavior",
            [0x17] = "ai_orders",
            [0x18] = "ai_line",
            [0x19] = "starting_profile",
            [0x1A] = "conversation",
            [0x1B] = "player",
            [0x1C] = "zone_set",
            [0x1D] = "designer_zone",
            [0x1E] = "point_reference",
            [0x1F] = "style",
            [0x20] = "object_list",
            [0x21] = "folder",
            [0x22] = "sound",
            [0x23] = "effect",
            [0x24] = "damage",
            [0x25] = "looping_sound",
            [0x26] = "animation_graph",
            [0x27] = "damage_effect",
            [0x28] = "object_definition",
            [0x29] = "bitmap",
            [0x2A] = "shader",
            [0x2B] = "render_model",
            [0x2C] = "structure_definition",
            [0x2D] = "lightmap_definition",
            [0x2E] = "cinematic_definition",
            [0x2F] = "cinematic_scene_definition",
            [0x30] = "cinematic_transition_definition",
            [0x31] = "bink_definition",
            [0x32] = "cui_screen_definition",
            [0x33] = "any_tag",
            [0x34] = "any_tag_not_resolving",
            [0x35] = "game_difficulty",
            [0x36] = "team",
            [0x37] = "mp_team",
            [0x38] = "controller",
            [0x39] = "button_preset",
            [0x3A] = "joystick_preset",
            [0x3B] = "player_color",
            [0x3C] = "player_model_choice",
            [0x3D] = "voice_output_setting",
            [0x3E] = "voice_mask",
            [0x3F] = "subtitle_setting",
            [0x40] = "actor_type",
            [0x41] = "model_state",
            [0x42] = "event",
            [0x43] = "character_physics",
            [0x44] = "skull",
            [0x45] = "firing_point_evaluator",
            [0x46] = "damage_region",
            [0x47] = "object",
            [0x48] = "unit",
            [0x49] = "vehicle",
            [0x4A] = "weapon",
            [0x4B] = "device",
            [0x4C] = "scenery",
            [0x4D] = "effect_scenery",
            [0x4E] = "object_name",
            [0x4F] = "unit_name",
            [0x50] = "vehicle_name",
            [0x51] = "weapon_name",
            [0x52] = "device_name",
            [0x53] = "scenery_name",
            [0x54] = "effect_scenery_name",
            [0x55] = "cinematic_lightprobe",
            [0x56] = "animation_budget_reference",
            [0x57] = "looping_sound_budget_reference",
            [0x58] = "sound_budget_reference",
        };

        public static Dictionary<int, string> Globals = new Dictionary<int, string>
        {
            [0x0] = "enable_melee_action",
            [0x1] = "debug_no_drawing",
            [0x2] = "debug_force_all_player_views_to_default_player",
            [0x3] = "debug_force_player_view_count",
            [0x4] = "debug_render_freeze",
            [0x5] = "debug_render_player_freeze",
            [0x6] = "debug_render_horizontal_splitscreen",
            [0x7] = "debug_load_panic_to_main_menu",
            [0x8] = "display_framerate",
            [0x9] = "display_pulse_rates",
            [0xA] = "display_throttle_rates",
            [0xB] = "display_lag_times",
            [0xC] = "display_frame_deltas",
            [0xD] = "console_status_string_render",
            [0xE] = "console_pauses_game",
            [0xF] = "framerate_infinite",
            [0x10] = "framerate_debug",
            [0x11] = "framerate_use_system_time",
            [0x12] = "framerate_stabilization",
            [0x13] = "g_animation_debug_rendering_on",
            [0x14] = "g_animation_debug_view_type_selected",
            [0x15] = "g_animation_debug_current_target",
            [0x16] = "debug_controller_latency",
            [0x17] = "unknown17",
            [0x18] = "unknown18",
            [0x19] = "unknown19",
            [0x1A] = "unknown1A",
            [0x1B] = "camera_fov",
            [0x1C] = "unknown1C",
            [0x1D] = "unknown1D",
            [0x1E] = "unknown1E",
            [0x1F] = "unknown1F",
            [0x20] = "unknown20",
            [0x21] = "unknown21",
            [0x22] = "unknown22",
            [0x23] = "unknown23",
            [0x24] = "unknown24",
            [0x25] = "unknown25",
            [0x26] = "unknown26",
            [0x27] = "unknown27",
            [0x28] = "unknown28",
            [0x29] = "unknown29",
            [0x2A] = "unknown2A",
            [0x2B] = "unknown2B",
            [0x2C] = "unknown2C",
            [0x2D] = "game_speed",
            [0x2E] = "game_time_lock",
            [0x2F] = "game_time_statistics",
            [0x30] = "map_info_debug",
            [0x31] = "debug_game_save",
            [0x32] = "recover_saved_games_hack",
            [0x33] = "game_state_verify_on_write",
            [0x34] = "game_state_verify_on_read",
            [0x35] = "debug_verify_game_variant_settings",
            [0x36] = "debug_globals_empty",
            [0x37] = "dont_load_material_effects",
            [0x38] = "editor_strip_dialogue_sounds",
            [0x39] = "scenario_load_fast",
            [0x3A] = "scenario_load_fast_and_playable",
            [0x3B] = "prune_global_use_empty",
            [0x3C] = "prune_global_material_effects",
            [0x3D] = "prune_scenario_lightmaps",
            [0x3E] = "prune_scenario_add_single_bsp_zones",
            [0x3F] = "prune_scenario_force_single_bsp_zone_set",
            [0x40] = "prune_scenario_for_environment_editing",
            [0x41] = "prune_scenario_for_environment_finishing",
            [0x42] = "prune_scenario_for_environment_pathfinding",
            [0x43] = "prune_scenario_for_environment_editing_keep_cinematics",
            [0x44] = "prune_scenario_for_environment_editing_keep_scenery",
            [0x45] = "prune_scenario_use_gray_shader",
            [0x46] = "prune_global_dialog_sounds",
            [0x47] = "prune_facial_animation_data",
            [0x48] = "prune_error_geometry",
            [0x49] = "pruning_keep_scripts",
            [0x4A] = "prune_global",
            [0x4B] = "prune_global_keep_playable",
            [0x4C] = "variant_culling_enabled",
            [0x4D] = "material_culling_enabled",
            [0x4E] = "display_precache_progress",
            [0x4F] = "log_precache_progress",
            [0x50] = "fake_precache_percentage",
            [0x51] = "force_aligned_utility_drive",
            [0x52] = "debug_object_garbage_collection",
            [0x53] = "debug_object_dump_log",
            [0x54] = "allow_all_sounds_on_player",
            [0x55] = "disable_player_rotation",
            [0x56] = "player_rotation_scale",
            [0x57] = "debug_player_respawn",
            [0x58] = "debug_survival_mode",
            [0x59] = "survival_performance_mode",
            [0x5A] = "debug_survival_mode_infinite_lives",
            [0x5B] = "debug_survival_mode_respawn_if_iron",
            [0x5C] = "g_synchronous_client_maximum_catchup_chunk_size",
            [0x5D] = "g_editor_maximum_edited_object_speed",
            [0x5E] = "g_editor_edited_object_spring_constant",
            [0x5F] = "g_editor_maximum_rotation_speed",
            [0x60] = "chud_enabled",
            [0x61] = "chud_debug_grid",
            [0x62] = "chud_debug_messages",
            [0x63] = "chud_debug_crosshair",
            [0x64] = "chud_debug_metagame",
            [0x65] = "chud_debug_reticle_radius",
            [0x66] = "chud_debug_highlight_object",
            [0x67] = "chud_debug_highlight_object_color_red",
            [0x68] = "chud_debug_highlight_object_color_green",
            [0x69] = "chud_debug_highlight_object_color_blue",
            [0x6A] = "chud_debug_highlight_object_color_alpha",
            [0x6B] = "chud_debug_animation_speed",
            [0x6C] = "debug_animation_override_blend_channel_input",
            [0x6D] = "debug_animation_blend_test_parent_relative",
            [0x6E] = "debug_animation_blend_test_horizontal",
            [0x6F] = "debug_animation_blend_test_vertical",
            [0x70] = "debug_animation_snap_nearest_pose_blend",
            [0x71] = "debug_animation_object_space_offset_disable",
            [0x72] = "debug_animation_fik_correction_enable",
            [0x73] = "debug_animation_fik_subframe_precision_enable",
            [0x74] = "debug_animation_object_space_offset_draw",
            [0x75] = "debug_animation_ik_chains_disable",
            [0x76] = "debug_animation_footlock_disable",
            [0x77] = "debug_animation_footlock_locking_disable",
            [0x78] = "debug_animation_precomputed_velocity_boundaries_disable",
            [0x79] = "debug_animation_ik_sets_disable",
            [0x7A] = "debug_animation_gait_preserve_frame_ratio",
            [0x7B] = "debug_animation_move_preserve_frame_ratio",
            [0x7C] = "debug_animation_root_offset_disable",
            [0x7D] = "debug_animation_camera_offset_disable",
            [0x7E] = "debug_animation_unsafe_debug_enable",
            [0x7F] = "debug_animation_maximum_channels_displayed",
            [0x80] = "debug_animation_footlock_draw",
            [0x81] = "debug_animation_footlock_draw_raw",
            [0x82] = "debug_animation_footlock_draw_turned",
            [0x83] = "debug_animation_footlock_draw_fitted",
            [0x84] = "debug_animation_footlock_draw_turn_sampling",
            [0x85] = "debug_animation_footlock_draw_grid_sampling",
            [0x86] = "debug_animation_footlock_draw_raycast",
            [0x87] = "debug_animation_footlock_draw_contact",
            [0x88] = "debug_animation_footlock_draw_displacement",
            [0x89] = "debug_animation_turn_radius_draw",
            [0x8A] = "debug_animation_assassination_selection",
            [0x8B] = "debug_animation_phonebooth_test_draw",
            [0x8C] = "debug_animation_phonebooth_draw_time",
            [0x8D] = "debug_pose_overlay_force_interpolation_across_sphere",
            [0x8E] = "debug_enable_press_to_assassinate",
            [0x8F] = "debug_enable_same_team_assassinate",
            [0x90] = "debug_enable_force_phonebooth_assassinate",
            [0x91] = "debug_unit_all_animations",
            [0x92] = "debug_unit_animations",
            [0x93] = "debug_unit_illumination",
            [0x94] = "debug_unit_active_camo_frequency_modulator",
            [0x95] = "debug_unit_active_camo_frequency_modulator_bias",
            [0x96] = "debug_player_melee_attack",
            [0x97] = "debug_boarding_force_enemy",
            [0x98] = "enable_animation_decompression_cache",
            [0x99] = "enable_animation_influenced_flight",
            [0x9A] = "enable_flight_noise",
            [0x9B] = "enable_player_transitions",
            [0x9C] = "enable_pain_screen_aim_fixup",
            [0x9D] = "disable_node_interpolation",
            [0x9E] = "disable_analog_movement",
            [0x9F] = "disable_transition_animations",
            [0xA0] = "disable_animated_source_interpolation",
            [0xA1] = "debug_enable_easy_weapon_down_claw",
            [0xA2] = "debug_vehicle_animated_trick_animation_name",
            [0xA3] = "debug_vehicle_animated_trick_camera_name",
            [0xA4] = "debug_orbiting_camera_maximum_distance_override",
            [0xA5] = "cheat_deathless_player",
            [0xA6] = "cheat_valhalla",
            [0xA7] = "cheat_jetpack",
            [0xA8] = "cheat_infinite_ammo",
            [0xA9] = "cheat_bottomless_clip",
            [0xAA] = "cheat_bump_possession",
            [0xAB] = "cheat_super_jump",
            [0xAC] = "cheat_reflexive_damage_effects",
            [0xAD] = "cheat_medusa",
            [0xAE] = "cheat_omnipotent",
            [0xAF] = "cheat_controller",
            [0xB0] = "cheat_chevy",
            [0xB1] = "cheat_porcupine",
            [0xB2] = "cheat_infinite_equipment_energy",
            [0xB3] = "effects_corpse_nonviolent",
            [0xB4] = "debug_effects_nonviolent",
            [0xB5] = "debug_effects_locations",
            [0xB6] = "effects_enable",
            [0xB7] = "debug_effects_allocation",
            [0xB8] = "debug_effects_play_distances",
            [0xB9] = "debug_effects_lightprobe_sampling",
            [0xBA] = "player_effects_enabled",
            [0xBB] = "g_animation_statistic_accumulator_enabled",
            [0xBC] = "sound_global_room_gain",
            [0xBD] = "unknownBD",
            [0xBE] = "unknownBE",
            [0xBF] = "unknownBF",
            [0xC0] = "unknownC0",
            [0xC1] = "unknownC1",
            [0xC2] = "unknownC2",
            [0xC3] = "unknownC3",
            [0xC4] = "unknownC4",
            [0xC5] = "unknownC5",
            [0xC6] = "unknownC6",
            [0xC7] = "unknownC7",
            [0xC8] = "unknownC8",
            [0xC9] = "unknownC9",
            [0xCA] = "debug_duckers",
            [0xCB] = "debug_sound_listeners",
            [0xCC] = "unknownCC",
            [0xCD] = "unknownCD",
            [0xCE] = "unknownCE",
            [0xCF] = "unknownCF",
            [0xD0] = "unknownD0",
            [0xD1] = "unknownD1",
            [0xD2] = "unknownD2",
            [0xD3] = "unknownD3",
            [0xD4] = "unknownD4",
            [0xD5] = "unknownD5",
            [0xD6] = "unknownD6",
            [0xD7] = "unknownD7",
            [0xD8] = "unknownD8",
            [0xD9] = "unknownD9",
            [0xDA] = "unknownDA",
            [0xDB] = "unknownDB",
            [0xDC] = "unknownDC",
            [0xDD] = "unknownDD",
            [0xDE] = "unknownDE",
            [0xDF] = "unknownDF",
            [0xE0] = "unknownE0",
            [0xE1] = "unknownE1",
            [0xE2] = "unknownE2",
            [0xE3] = "unknownE3",
            [0xE4] = "unknownE4",
            [0xE5] = "unknownE5",
            [0xE6] = "unknownE6",
            [0xE7] = "unknownE7",
            [0xE8] = "unknownE8",
            [0xE9] = "unknownE9",
            [0xEA] = "unknownEA",
            [0xEB] = "unknownEB",
            [0xEC] = "unknownEC",
            [0xED] = "unknownED",
            [0xEE] = "unknownEE",
            [0xEF] = "unknownEF",
            [0xF0] = "unknownF0",
            [0xF1] = "unknownF1",
            [0xF2] = "unknownF2",
            [0xF3] = "unknownF3",
            [0xF4] = "unknownF4",
            [0xF5] = "unknownF5",
            [0xF6] = "disable_expensive_physics_rebuilding",
            [0xF7] = "minimum_havok_object_acceleration",
            [0xF8] = "minimum_havok_biped_object_acceleration",
            [0xF9] = "unknownF9",
            [0xFA] = "unknownFA",
            [0xFB] = "unknownFB",
            [0xFC] = "unknownFC",
            [0xFD] = "unknownFD",
            [0xFE] = "unknownFE",
            [0xFF] = "unknownFF",
            [0x100] = "unknown100",
            [0x101] = "unknown101",
            [0x102] = "unknown102",
            [0x103] = "render_lightmap_shadows",
            [0x104] = "render_rain",
            [0x105] = "unknown105",
            [0x106] = "unknown106",
            [0x107] = "unknown107",
            [0x108] = "unknown108",
            [0x109] = "unknown109",
            [0x10A] = "unknown10A",
            [0x10B] = "unknown10B",
            [0x10C] = "unknown10C",
            [0x10D] = "unknown10D",
            [0x10E] = "unknown10E",
            [0x10F] = "unknown10F",
            [0x110] = "unknown110",
            [0x111] = "unknown111",
            [0x112] = "unknown112",
            [0x113] = "unknown113",
            [0x114] = "unknown114",
            [0x115] = "unknown115",
            [0x116] = "unknown116",
            [0x117] = "unknown117",
            [0x118] = "unknown118",
            [0x119] = "unknown119",
            [0x11A] = "unknown11A",
            [0x11B] = "unknown11B",
            [0x11C] = "unknown11C",
            [0x11D] = "unknown11D",
            [0x11E] = "unknown11E",
            [0x11F] = "unknown11F",
            [0x120] = "unknown120",
            [0x121] = "unknown121",
            [0x122] = "unknown122",
            [0x123] = "unknown123",
            [0x124] = "unknown124",
            [0x125] = "unknown125",
            [0x126] = "unknown126",
            [0x127] = "unknown127",
            [0x128] = "unknown128",
            [0x129] = "unknown129",
            [0x12A] = "unknown12A",
            [0x12B] = "unknown12B",
            [0x12C] = "unknown12C",
            [0x12D] = "unknown12D",
            [0x12E] = "unknown12E",
            [0x12F] = "unknown12F",
            [0x130] = "unknown130",
            [0x131] = "unknown131",
            [0x132] = "unknown132",
            [0x133] = "unknown133",
            [0x134] = "unknown134",
            [0x135] = "unknown135",
            [0x136] = "unknown136",
            [0x137] = "unknown137",
            [0x138] = "unknown138",
            [0x139] = "unknown139",
            [0x13A] = "unknown13A",
            [0x13B] = "unknown13B",
            [0x13C] = "unknown13C",
            [0x13D] = "unknown13D",
            [0x13E] = "unknown13E",
            [0x13F] = "unknown13F",
            [0x140] = "unknown140",
            [0x141] = "unknown141",
            [0x142] = "unknown142",
            [0x143] = "unknown143",
            [0x144] = "render_screen_flashes",
            [0x145] = "texture_camera_near_plane",
            [0x146] = "texture_camera_exposure",
            [0x147] = "texture_camera_illum_scale",
            [0x148] = "render_near_clip_distance",
            [0x149] = "render_far_clip_distance",
            [0x14A] = "unknown14A",
            [0x14B] = "unknown14B",
            [0x14C] = "render_HDR_target_stops",
            [0x14D] = "render_surface_LDR_mode",
            [0x14E] = "render_surface_HDR_mode",
            [0x14F] = "render_first_person_fov_scale",
            [0x150] = "rasterizer_triliner_threshold",
            [0x151] = "rasterizer_present_immediate_threshold",
            [0x152] = "tiling",
            [0x153] = "render_screen_res",
            [0x154] = "render_tiling_resolve_fragment_index",
            [0x155] = "render_tiling_viewport_offset_x",
            [0x156] = "render_tiling_viewport_offset_y",
            [0x157] = "render_force_anisotropic_mode",
            [0x158] = "render_force_anisotropic_level",
            [0x159] = "render_force_max_mipmap_level",
            [0x15A] = "render_force_min_mipmap_level",
            [0x15B] = "render_force_mipmap_lodbias",
            [0x15C] = "render_alpha_test_reference",
            [0x15D] = "render_true_gamma",
            [0x15E] = "unknown15E",
            [0x15F] = "unknown15F",
            [0x160] = "unknown160",
            [0x161] = "unknown161",
            [0x162] = "unknown162",
            [0x163] = "unknown163",
            [0x164] = "unknown164",
            [0x165] = "unknown165",
            [0x166] = "unknown166",
            [0x167] = "unknown167",
            [0x168] = "unknown168",
            [0x169] = "unknown169",
            [0x16A] = "unknown16A",
            [0x16B] = "unknown16B",
            [0x16C] = "unknown16C",
            [0x16D] = "unknown16D",
            [0x16E] = "unknown16E",
            [0x16F] = "unknown16F",
            [0x170] = "unknown170",
            [0x171] = "unknown171",
            [0x172] = "render_postprocess_hue",
            [0x173] = "render_postprocess_saturation",
            [0x174] = "render_postprocess_red_filter",
            [0x175] = "render_postprocess_green_filter",
            [0x176] = "render_postprocess_blue_filter",
            [0x177] = "unknown177",
            [0x178] = "render_bounce_light_intensity",
            [0x179] = "render_bounce_light_only",
            [0x17A] = "unknown17A",
            [0x17B] = "unknown17B",
            [0x17C] = "unknown17C",
            [0x17D] = "unknown17D",
            [0x17E] = "unknown17E",
            [0x17F] = "unknown17F",
            [0x180] = "unknown180",
            [0x181] = "unknown181",
            [0x182] = "unknown182",
            [0x183] = "unknown183",
            [0x184] = "unknown184",
            [0x185] = "unknown185",
            [0x186] = "unknown186",
            [0x187] = "unknown187",
            [0x188] = "unknown188",
            [0x189] = "unknown189",
            [0x18A] = "unknown18A",
            [0x18B] = "unknown18B",
            [0x18C] = "unknown18C",
            [0x18D] = "unknown18D",
            [0x18E] = "unknown18E",
            [0x18F] = "unknown18F",
            [0x190] = "unknown190",
            [0x191] = "unknown191",
            [0x192] = "unknown192",
            [0x193] = "unknown193",
            [0x194] = "unknown194",
            [0x195] = "unknown195",
            [0x196] = "render_debug_depth_render",
            [0x197] = "render_debug_depth_render_scale_r",
            [0x198] = "render_debug_depth_render_scale_g",
            [0x199] = "render_debug_depth_render_scale_b",
            [0x19A] = "unknown19A",
            [0x19B] = "unknown19B",
            [0x19C] = "unknown19C",
            [0x19D] = "unknown19D",
            [0x19E] = "unknown19E",
            [0x19F] = "unknown19F",
            [0x1A0] = "unknown1A0",
            [0x1A1] = "unknown1A1",
            [0x1A2] = "unknown1A2",
            [0x1A3] = "unknown1A3",
            [0x1A4] = "unknown1A4",
            [0x1A5] = "unknown1A5",
            [0x1A6] = "unknown1A6",
            [0x1A7] = "unknown1A7",
            [0x1A8] = "unknown1A8",
            [0x1A9] = "unknown1A9",
            [0x1AA] = "unknown1AA",
            [0x1AB] = "unknown1AB",
            [0x1AC] = "unknown1AC",
            [0x1AD] = "unknown1AD",
            [0x1AE] = "unknown1AE",
            [0x1AF] = "unknown1AF",
            [0x1B0] = "unknown1B0",
            [0x1B1] = "unknown1B1",
            [0x1B2] = "unknown1B2",
            [0x1B3] = "unknown1B3",
            [0x1B4] = "unknown1B4",
            [0x1B5] = "unknown1B5",
            [0x1B6] = "unknown1B6",
            [0x1B7] = "unknown1B7",
            [0x1B8] = "unknown1B8",
            [0x1B9] = "unknown1B9",
            [0x1BA] = "unknown1BA",
            [0x1BB] = "unknown1BB",
            [0x1BC] = "unknown1BC",
            [0x1BD] = "unknown1BD",
            [0x1BE] = "unknown1BE",
            [0x1BF] = "unknown1BF",
            [0x1C0] = "unknown1C0",
            [0x1C1] = "unknown1C1",
            [0x1C2] = "unknown1C2",
            [0x1C3] = "unknown1C3",
            [0x1C4] = "unknown1C4",
            [0x1C5] = "unknown1C5",
            [0x1C6] = "unknown1C6",
            [0x1C7] = "unknown1C7",
            [0x1C8] = "unknown1C8",
            [0x1C9] = "unknown1C9",
            [0x1CA] = "unknown1CA",
            [0x1CB] = "unknown1CB",
            [0x1CC] = "unknown1CC",
            [0x1CD] = "unknown1CD",
            [0x1CE] = "unknown1CE",
            [0x1CF] = "unknown1CF",
            [0x1D0] = "unknown1D0",
            [0x1D1] = "unknown1D1",
            [0x1D2] = "unknown1D2",
            [0x1D3] = "unknown1D3",
            [0x1D4] = "unknown1D4",
            [0x1D5] = "unknown1D5",
            [0x1D6] = "unknown1D6",
            [0x1D7] = "unknown1D7",
            [0x1D8] = "unknown1D8",
            [0x1D9] = "unknown1D9",
            [0x1DA] = "unknown1DA",
            [0x1DB] = "unknown1DB",
            [0x1DC] = "unknown1DC",
            [0x1DD] = "unknown1DD",
            [0x1DE] = "unknown1DE",
            [0x1DF] = "unknown1DF",
            [0x1E0] = "unknown1E0",
            [0x1E1] = "unknown1E1",
            [0x1E2] = "unknown1E2",
            [0x1E3] = "unknown1E3",
            [0x1E4] = "unknown1E4",
            [0x1E5] = "unknown1E5",
            [0x1E6] = "unknown1E6",
            [0x1E7] = "unknown1E7",
            [0x1E8] = "unknown1E8",
            [0x1E9] = "unknown1E9",
            [0x1EA] = "unknown1EA",
            [0x1EB] = "unknown1EB",
            [0x1EC] = "unknown1EC",
            [0x1ED] = "unknown1ED",
            [0x1EE] = "unknown1EE",
            [0x1EF] = "unknown1EF",
            [0x1F0] = "unknown1F0",
            [0x1F1] = "unknown1F1",
            [0x1F2] = "unknown1F2",
            [0x1F3] = "unknown1F3",
            [0x1F4] = "unknown1F4",
            [0x1F5] = "unknown1F5",
            [0x1F6] = "unknown1F6",
            [0x1F7] = "unknown1F7",
            [0x1F8] = "unknown1F8",
            [0x1F9] = "unknown1F9",
            [0x1FA] = "unknown1FA",
            [0x1FB] = "visibility_enable_occlusion",
            [0x1FC] = "unknown1FC",
            [0x1FD] = "unknown1FD",
            [0x1FE] = "unknown1FE",
            [0x1FF] = "unknown1FF",
            [0x200] = "debug_objects",
            [0x201] = "unknown201",
            [0x202] = "unknown202",
            [0x203] = "unknown203",
            [0x204] = "debug_objects_bounding_spheres",
            [0x205] = "unknown205",
            [0x206] = "unknown206",
            [0x207] = "unknown207",
            [0x208] = "unknown208",
            [0x209] = "unknown209",
            [0x20A] = "debug_objects_collision_models",
            [0x20B] = "debug_objects_cookie_cutters",
            [0x20C] = "unknown20C",
            [0x20D] = "unknown20D",
            [0x20E] = "unknown20E",
            [0x20F] = "unknown20F",
            [0x210] = "unknown210",
            [0x211] = "unknown211",
            [0x212] = "unknown212",
            [0x213] = "unknown213",
            [0x214] = "unknown214",
            [0x215] = "unknown215",
            [0x216] = "unknown216",
            [0x217] = "debug_objects_physics_models",
            [0x218] = "unknown218",
            [0x219] = "unknown219",
            [0x21A] = "water_physics_velocity_minimum",
            [0x21B] = "water_physics_velocity_maximum",
            [0x21C] = "unknown21C",
            [0x21D] = "unknown21D",
            [0x21E] = "unknown21E",
            [0x21F] = "unknown21F",
            [0x220] = "unknown220",
            [0x221] = "unknown221",
            [0x222] = "unknown222",
            [0x223] = "unknown223",
            [0x224] = "unknown224",
            [0x225] = "unknown225",
            [0x226] = "unknown226",
            [0x227] = "unknown227",
            [0x228] = "unknown228",
            [0x229] = "unknown229",
            [0x22A] = "unknown22A",
            [0x22B] = "unknown22B",
            [0x22C] = "unknown22C",
            [0x22D] = "unknown22D",
            [0x22E] = "unknown22E",
            [0x22F] = "unknown22F",
            [0x230] = "unknown230",
            [0x231] = "unknown231",
            [0x232] = "unknown232",
            [0x233] = "unknown233",
            [0x234] = "unknown234",
            [0x235] = "unknown235",
            [0x236] = "unknown236",
            [0x237] = "unknown237",
            [0x238] = "unknown238",
            [0x239] = "unknown239",
            [0x23A] = "unknown23A",
            [0x23B] = "unknown23B",
            [0x23C] = "unknown23C",
            [0x23D] = "unknown23D",
            [0x23E] = "unknown23E",
            [0x23F] = "unknown23F",
            [0x240] = "unknown240",
            [0x241] = "unknown241",
            [0x242] = "unknown242",
            [0x243] = "unknown243",
            [0x244] = "unknown244",
            [0x245] = "unknown245",
            [0x246] = "unknown246",
            [0x247] = "unknown247",
            [0x248] = "unknown248",
            [0x249] = "unknown249",
            [0x24A] = "unknown24A",
            [0x24B] = "unknown24B",
            [0x24C] = "unknown24C",
            [0x24D] = "unknown24D",
            [0x24E] = "unknown24E",
            [0x24F] = "unknown24F",
            [0x250] = "unknown250",
            [0x251] = "unknown251",
            [0x252] = "unknown252",
            [0x253] = "unknown253",
            [0x254] = "unknown254",
            [0x255] = "unknown255",
            [0x256] = "unknown256",
            [0x257] = "unknown257",
            [0x258] = "unknown258",
            [0x259] = "unknown259",
            [0x25A] = "unknown25A",
            [0x25B] = "unknown25B",
            [0x25C] = "unknown25C",
            [0x25D] = "unknown25D",
            [0x25E] = "unknown25E",
            [0x25F] = "unknown25F",
            [0x260] = "unknown260",
            [0x261] = "unknown261",
            [0x262] = "unknown262",
            [0x263] = "unknown263",
            [0x264] = "unknown264",
            [0x265] = "unknown265",
            [0x266] = "unknown266",
            [0x267] = "unknown267",
            [0x268] = "unknown268",
            [0x269] = "unknown269",
            [0x26A] = "unknown26A",
            [0x26B] = "unknown26B",
            [0x26C] = "unknown26C",
            [0x26D] = "unknown26D",
            [0x26E] = "unknown26E",
            [0x26F] = "unknown26F",
            [0x270] = "unknown270",
            [0x271] = "unknown271",
            [0x272] = "unknown272",
            [0x273] = "unknown273",
            [0x274] = "unknown274",
            [0x275] = "breakpoints_enabled",
            [0x276] = "unknown276",
            [0x277] = "unknown277",
            [0x278] = "unknown278",
            [0x279] = "unknown279",
            [0x27A] = "collision_debug",
            [0x27B] = "unknown27B",
            [0x27C] = "unknown27C",
            [0x27D] = "unknown27D",
            [0x27E] = "unknown27E",
            [0x27F] = "unknown27F",
            [0x280] = "unknown280",
            [0x281] = "unknown281",
            [0x282] = "unknown282",
            [0x283] = "unknown283",
            [0x284] = "unknown284",
            [0x285] = "unknown285",
            [0x286] = "unknown286",
            [0x287] = "unknown287",
            [0x288] = "unknown288",
            [0x289] = "unknown289",
            [0x28A] = "unknown28A",
            [0x28B] = "unknown28B",
            [0x28C] = "unknown28C",
            [0x28D] = "unknown28D",
            [0x28E] = "unknown28E",
            [0x28F] = "unknown28F",
            [0x290] = "unknown290",
            [0x291] = "unknown291",
            [0x292] = "unknown292",
            [0x293] = "unknown293",
            [0x294] = "unknown294",
            [0x295] = "unknown295",
            [0x296] = "unknown296",
            [0x297] = "unknown297",
            [0x298] = "unknown298",
            [0x299] = "unknown299",
            [0x29A] = "unknown29A",
            [0x29B] = "unknown29B",
            [0x29C] = "unknown29C",
            [0x29D] = "unknown29D",
            [0x29E] = "unknown29E",
            [0x29F] = "unknown29F",
            [0x2A0] = "unknown2A0",
            [0x2A1] = "unknown2A1",
            [0x2A2] = "unknown2A2",
            [0x2A3] = "unknown2A3",
            [0x2A4] = "collision_debug_flag_ignore_invisible_surfaces",
            [0x2A5] = "unknown2A5",
            [0x2A6] = "unknown2A6",
            [0x2A7] = "unknown2A7",
            [0x2A8] = "unknown2A8",
            [0x2A9] = "unknown2A9",
            [0x2AA] = "unknown2AA",
            [0x2AB] = "unknown2AB",
            [0x2AC] = "unknown2AC",
            [0x2AD] = "unknown2AD",
            [0x2AE] = "unknown2AE",
            [0x2AF] = "unknown2AF",
            [0x2B0] = "unknown2B0",
            [0x2B1] = "unknown2B1",
            [0x2B2] = "unknown2B2",
            [0x2B3] = "unknown2B3",
            [0x2B4] = "unknown2B4",
            [0x2B5] = "unknown2B5",
            [0x2B6] = "unknown2B6",
            [0x2B7] = "unknown2B7",
            [0x2B8] = "unknown2B8",
            [0x2B9] = "unknown2B9",
            [0x2BA] = "unknown2BA",
            [0x2BB] = "unknown2BB",
            [0x2BC] = "unknown2BC",
            [0x2BD] = "unknown2BD",
            [0x2BE] = "unknown2BE",
            [0x2BF] = "unknown2BF",
            [0x2C0] = "unknown2C0",
            [0x2C1] = "unknown2C1",
            [0x2C2] = "unknown2C2",
            [0x2C3] = "unknown2C3",
            [0x2C4] = "unknown2C4",
            [0x2C5] = "unknown2C5",
            [0x2C6] = "unknown2C6",
            [0x2C7] = "unknown2C7",
            [0x2C8] = "unknown2C8",
            [0x2C9] = "unknown2C9",
            [0x2CA] = "unknown2CA",
            [0x2CB] = "unknown2CB",
            [0x2CC] = "unknown2CC",
            [0x2CD] = "unknown2CD",
            [0x2CE] = "unknown2CE",
            [0x2CF] = "unknown2CF",
            [0x2D0] = "unknown2D0",
            [0x2D1] = "unknown2D1",
            [0x2D2] = "unknown2D2",
            [0x2D3] = "unknown2D3",
            [0x2D4] = "debug_structure_cookie_cutters",
            [0x2D5] = "unknown2D5",
            [0x2D6] = "unknown2D6",
            [0x2D7] = "unknown2D7",
            [0x2D8] = "unknown2D8",
            [0x2D9] = "unknown2D9",
            [0x2DA] = "unknown2DA",
            [0x2DB] = "unknown2DB",
            [0x2DC] = "unknown2DC",
            [0x2DD] = "debug_instanced_geometry",
            [0x2DE] = "unknown2DE",
            [0x2DF] = "unknown2DF",
            [0x2E0] = "unknown2E0",
            [0x2E1] = "debug_instanced_geometry_collision_geometry",
            [0x2E2] = "debug_instanced_geometry_cookie_cutters",
            [0x2E3] = "unknown2E3",
            [0x2E4] = "unknown2E4",
            [0x2E5] = "unknown2E5",
            [0x2E6] = "unknown2E6",
            [0x2E7] = "unknown2E7",
            [0x2E8] = "unknown2E8",
            [0x2E9] = "unknown2E9",
            [0x2EA] = "unknown2EA",
            [0x2EB] = "unknown2EB",
            [0x2EC] = "unknown2EC",
            [0x2ED] = "unknown2ED",
            [0x2EE] = "unknown2EE",
            [0x2EF] = "unknown2EF",
            [0x2F0] = "unknown2F0",
            [0x2F1] = "unknown2F1",
            [0x2F2] = "unknown2F2",
            [0x2F3] = "breakable_surfaces",
            [0x2F4] = "unknown2F4",
            [0x2F5] = "unknown2F5",
            [0x2F6] = "unknown2F6",
            [0x2F7] = "unknown2F7",
            [0x2F8] = "unknown2F8",
            [0x2F9] = "unknown2F9",
            [0x2FA] = "unknown2FA",
            [0x2FB] = "unknown2FB",
            [0x2FC] = "unknown2FC",
            [0x2FD] = "unknown2FD",
            [0x2FE] = "unknown2FE",
            [0x2FF] = "unknown2FF",
            [0x300] = "unknown300",
            [0x301] = "unknown301",
            [0x302] = "unknown302",
            [0x303] = "unknown303",
            [0x304] = "unknown304",
            [0x305] = "unknown305",
            [0x306] = "unknown306",
            [0x307] = "unknown307",
            [0x308] = "unknown308",
            [0x309] = "unknown309",
            [0x30A] = "unknown30A",
            [0x30B] = "unknown30B",
            [0x30C] = "unknown30C",
            [0x30D] = "unknown30D",
            [0x30E] = "unknown30E",
            [0x30F] = "unknown30F",
            [0x310] = "unknown310",
            [0x311] = "unknown311",
            [0x312] = "unknown312",
            [0x313] = "unknown313",
            [0x314] = "unknown314",
            [0x315] = "unknown315",
            [0x316] = "unknown316",
            [0x317] = "unknown317",
            [0x318] = "unknown318",
            [0x319] = "unknown319",
            [0x31A] = "unknown31A",
            [0x31B] = "unknown31B",
            [0x31C] = "unknown31C",
            [0x31D] = "unknown31D",
            [0x31E] = "unknown31E",
            [0x31F] = "unknown31F",
            [0x320] = "unknown320",
            [0x321] = "ai_render_props",
            [0x322] = "unknown322",
            [0x323] = "unknown323",
            [0x324] = "unknown324",
            [0x325] = "unknown325",
            [0x326] = "unknown326",
            [0x327] = "unknown327",
            [0x328] = "unknown328",
            [0x329] = "unknown329",
            [0x32A] = "unknown32A",
            [0x32B] = "unknown32B",
            [0x32C] = "unknown32C",
            [0x32D] = "unknown32D",
            [0x32E] = "unknown32E",
            [0x32F] = "unknown32F",
            [0x330] = "unknown330",
            [0x331] = "unknown331",
            [0x332] = "ai_render_aiming_vectors",
            [0x333] = "unknown333",
            [0x334] = "unknown334",
            [0x335] = "unknown335",
            [0x336] = "unknown336",
            [0x337] = "unknown337",
            [0x338] = "unknown338",
            [0x339] = "unknown339",
            [0x33A] = "unknown33A",
            [0x33B] = "unknown33B",
            [0x33C] = "unknown33C",
            [0x33D] = "ai_render_evaluations",
            [0x33E] = "ai_render_evaluations_detailed",
            [0x33F] = "ai_render_evaluations_text",
            [0x340] = "unknown340",
            [0x341] = "unknown341",
            [0x342] = "unknown342",
            [0x343] = "unknown343",
            [0x344] = "unknown344",
            [0x345] = "unknown345",
            [0x346] = "unknown346",
            [0x347] = "unknown347",
            [0x348] = "unknown348",
            [0x349] = "unknown349",
            [0x34A] = "unknown34A",
            [0x34B] = "unknown34B",
            [0x34C] = "unknown34C",
            [0x34D] = "unknown34D",
            [0x34E] = "unknown34E",
            [0x34F] = "unknown34F",
            [0x350] = "unknown350",
            [0x351] = "unknown351",
            [0x352] = "unknown352",
            [0x353] = "unknown353",
            [0x354] = "unknown354",
            [0x355] = "unknown355",
            [0x356] = "unknown356",
            [0x357] = "unknown357",
            [0x358] = "unknown358",
            [0x359] = "unknown359",
            [0x35A] = "unknown35A",
            [0x35B] = "unknown35B",
            [0x35C] = "unknown35C",
            [0x35D] = "unknown35D",
            [0x35E] = "unknown35E",
            [0x35F] = "unknown35F",
            [0x360] = "unknown360",
            [0x361] = "unknown361",
            [0x362] = "unknown362",
            [0x363] = "unknown363",
            [0x364] = "unknown364",
            [0x365] = "ai_render_firing_position_statistics",
            [0x366] = "unknown366",
            [0x367] = "unknown367",
            [0x368] = "unknown368",
            [0x369] = "unknown369",
            [0x36A] = "unknown36A",
            [0x36B] = "unknown36B",
            [0x36C] = "unknown36C",
            [0x36D] = "unknown36D",
            [0x36E] = "unknown36E",
            [0x36F] = "unknown36F",
            [0x370] = "unknown370",
            [0x371] = "unknown371",
            [0x372] = "unknown372",
            [0x373] = "unknown373",
            [0x374] = "unknown374",
            [0x375] = "unknown375",
            [0x376] = "unknown376",
            [0x377] = "unknown377",
            [0x378] = "unknown378",
            [0x379] = "unknown379",
            [0x37A] = "unknown37A",
            [0x37B] = "unknown37B",
            [0x37C] = "unknown37C",
            [0x37D] = "unknown37D",
            [0x37E] = "unknown37E",
            [0x37F] = "unknown37F",
            [0x380] = "unknown380",
            [0x381] = "unknown381",
            [0x382] = "unknown382",
            [0x383] = "unknown383",
            [0x384] = "unknown384",
            [0x385] = "unknown385",
            [0x386] = "unknown386",
            [0x387] = "unknown387",
            [0x388] = "unknown388",
            [0x389] = "unknown389",
            [0x38A] = "unknown38A",
            [0x38B] = "unknown38B",
            [0x38C] = "unknown38C",
            [0x38D] = "unknown38D",
            [0x38E] = "unknown38E",
            [0x38F] = "unknown38F",
            [0x390] = "unknown390",
            [0x391] = "unknown391",
            [0x392] = "unknown392",
            [0x393] = "unknown393",
            [0x394] = "unknown394",
            [0x395] = "unknown395",
            [0x396] = "unknown396",
            [0x397] = "unknown397",
            [0x398] = "unknown398",
            [0x399] = "unknown399",
            [0x39A] = "unknown39A",
            [0x39B] = "ai_render_sector_bsps",
            [0x39C] = "unknown39C",
            [0x39D] = "unknown39D",
            [0x39E] = "unknown39E",
            [0x39F] = "unknown39F",
            [0x3A0] = "unknown3A0",
            [0x3A1] = "unknown3A1",
            [0x3A2] = "unknown3A2",
            [0x3A3] = "unknown3A3",
            [0x3A4] = "unknown3A4",
            [0x3A5] = "unknown3A5",
            [0x3A6] = "unknown3A6",
            [0x3A7] = "unknown3A7",
            [0x3A8] = "unknown3A8",
            [0x3A9] = "unknown3A9",
            [0x3AA] = "unknown3AA",
            [0x3AB] = "unknown3AB",
            [0x3AC] = "unknown3AC",
            [0x3AD] = "unknown3AD",
            [0x3AE] = "unknown3AE",
            [0x3AF] = "unknown3AF",
            [0x3B0] = "unknown3B0",
            [0x3B1] = "unknown3B1",
            [0x3B2] = "unknown3B2",
            [0x3B3] = "unknown3B3",
            [0x3B4] = "unknown3B4",
            [0x3B5] = "unknown3B5",
            [0x3B6] = "unknown3B6",
            [0x3B7] = "unknown3B7",
            [0x3B8] = "unknown3B8",
            [0x3B9] = "ai_render_objectives",
            [0x3BA] = "unknown3BA",
            [0x3BB] = "unknown3BB",
            [0x3BC] = "unknown3BC",
            [0x3BD] = "unknown3BD",
            [0x3BE] = "unknown3BE",
            [0x3BF] = "unknown3BF",
            [0x3C0] = "ai_render_behavior_stack",
            [0x3C1] = "ai_render_behavior_stack_all",
            [0x3C2] = "unknown3C2",
            [0x3C3] = "unknown3C3",
            [0x3C4] = "unknown3C4",
            [0x3C5] = "ai_render_decisions",
            [0x3C6] = "unknown3C6",
            [0x3C7] = "ai_render_command_scripts",
            [0x3C8] = "unknown3C8",
            [0x3C9] = "unknown3C9",
            [0x3CA] = "unknown3CA",
            [0x3CB] = "unknown3CB",
            [0x3CC] = "unknown3CC",
            [0x3CD] = "unknown3CD",
            [0x3CE] = "unknown3CE",
            [0x3CF] = "unknown3CF",
            [0x3D0] = "unknown3D0",
            [0x3D1] = "unknown3D1",
            [0x3D2] = "unknown3D2",
            [0x3D3] = "unknown3D3",
            [0x3D4] = "unknown3D4",
            [0x3D5] = "unknown3D5",
            [0x3D6] = "unknown3D6",
            [0x3D7] = "unknown3D7",
            [0x3D8] = "unknown3D8",
            [0x3D9] = "unknown3D9",
            [0x3DA] = "unknown3DA",
            [0x3DB] = "unknown3DB",
            [0x3DC] = "ai_current_squad",
            [0x3DD] = "ai_current_actor",
            [0x3DE] = "ai_current_performance",
            [0x3DF] = "unknown3DF",
            [0x3E0] = "unknown3E0",
            [0x3E1] = "unknown3E1",
            [0x3E2] = "unknown3E2",
            [0x3E3] = "unknown3E3",
            [0x3E4] = "unknown3E4",
            [0x3E5] = "unknown3E5",
            [0x3E6] = "unknown3E6",
            [0x3E7] = "unknown3E7",
            [0x3E8] = "unknown3E8",
            [0x3E9] = "unknown3E9",
            [0x3EA] = "unknown3EA",
            [0x3EB] = "unknown3EB",
            [0x3EC] = "unknown3EC",
            [0x3ED] = "unknown3ED",
            [0x3EE] = "unknown3EE",
            [0x3EF] = "unknown3EF",
            [0x3F0] = "unknown3F0",
            [0x3F1] = "unknown3F1",
            [0x3F2] = "unknown3F2",
            [0x3F3] = "ai_combat_status_asleep",
            [0x3F4] = "ai_combat_status_idle",
            [0x3F5] = "ai_combat_status_alert",
            [0x3F6] = "ai_combat_status_active",
            [0x3F7] = "ai_combat_status_uninspected",
            [0x3F8] = "ai_combat_status_definite",
            [0x3F9] = "ai_combat_status_certain",
            [0x3FA] = "ai_combat_status_visible",
            [0x3FB] = "ai_combat_status_clear_los",
            [0x3FC] = "ai_combat_status_dangerous",
            [0x3FD] = "ai_task_status_never",
            [0x3FE] = "ai_task_status_occupied",
            [0x3FF] = "ai_task_status_empty",
            [0x400] = "ai_task_status_inactive",
            [0x401] = "ai_task_status_exhausted",
            [0x402] = "unknown402",
            [0x403] = "unknown403",
            [0x404] = "unknown404",
            [0x405] = "unknown405",
            [0x406] = "unknown406",
            [0x407] = "unknown407",
            [0x408] = "unknown408",
            [0x409] = "unknown409",
            [0x40A] = "unknown40A",
            [0x40B] = "unknown40B",
            [0x40C] = "unknown40C",
            [0x40D] = "unknown40D",
            [0x40E] = "unknown40E",
            [0x40F] = "unknown40F",
            [0x410] = "unknown410",
            [0x411] = "unknown411",
            [0x412] = "unknown412",
            [0x413] = "unknown413",
            [0x414] = "unknown414",
            [0x415] = "unknown415",
            [0x416] = "unknown416",
            [0x417] = "unknown417",
            [0x418] = "unknown418",
            [0x419] = "unknown419",
            [0x41A] = "ai_action_berserk",
            [0x41B] = "ai_action_surprise_front",
            [0x41C] = "ai_action_surprise_back",
            [0x41D] = "ai_action_evade_left",
            [0x41E] = "ai_action_evade_right",
            [0x41F] = "ai_action_dive_forward",
            [0x420] = "ai_action_dive_back",
            [0x421] = "ai_action_dive_left",
            [0x422] = "ai_action_dive_right",
            [0x423] = "ai_action_advance",
            [0x424] = "unknown424",
            [0x425] = "unknown425",
            [0x426] = "unknown426",
            [0x427] = "unknown427",
            [0x428] = "unknown428",
            [0x429] = "unknown429",
            [0x42A] = "unknown42A",
            [0x42B] = "unknown42B",
            [0x42C] = "unknown42C",
            [0x42D] = "unknown42D",
            [0x42E] = "unknown42E",
            [0x42F] = "unknown42F",
            [0x430] = "unknown430",
            [0x431] = "unknown431",
            [0x432] = "unknown432",
            [0x433] = "unknown433",
            [0x434] = "unknown434",
            [0x435] = "unknown435",
            [0x436] = "unknown436",
            [0x437] = "unknown437",
            [0x438] = "unknown438",
            [0x439] = "unknown439",
            [0x43A] = "unknown43A",
            [0x43B] = "unknown43B",
            [0x43C] = "unknown43C",
            [0x43D] = "unknown43D",
            [0x43E] = "unknown43E",
            [0x43F] = "unknown43F",
            [0x440] = "unknown440",
            [0x441] = "unknown441",
            [0x442] = "unknown442",
            [0x443] = "unknown443",
            [0x444] = "unknown444",
            [0x445] = "unknown445",
            [0x446] = "unknown446",
            [0x447] = "unknown447",
            [0x448] = "unknown448",
            [0x449] = "unknown449",
            [0x44A] = "unknown44A",
            [0x44B] = "unknown44B",
            [0x44C] = "unknown44C",
            [0x44D] = "unknown44D",
            [0x44E] = "unknown44E",
            [0x44F] = "unknown44F",
            [0x450] = "unknown450",
            [0x451] = "unknown451",
            [0x452] = "unknown452",
            [0x453] = "unknown453",
            [0x454] = "unknown454",
            [0x455] = "unknown455",
            [0x456] = "unknown456",
            [0x457] = "unknown457",
            [0x458] = "unknown458",
            [0x459] = "unknown459",
            [0x45A] = "unknown45A",
            [0x45B] = "unknown45B",
            [0x45C] = "unknown45C",
            [0x45D] = "unknown45D",
            [0x45E] = "unknown45E",
            [0x45F] = "unknown45F",
            [0x460] = "unknown460",
            [0x461] = "unknown461",
            [0x462] = "unknown462",
            [0x463] = "unknown463",
            [0x464] = "unknown464",
            [0x465] = "unknown465",
            [0x466] = "unknown466",
            [0x467] = "unknown467",
            [0x468] = "unknown468",
            [0x469] = "unknown469",
            [0x46A] = "unknown46A",
            [0x46B] = "unknown46B",
            [0x46C] = "unknown46C",
            [0x46D] = "unknown46D",
            [0x46E] = "unknown46E",
            [0x46F] = "unknown46F",
            [0x470] = "unknown470",
            [0x471] = "unknown471",
            [0x472] = "unknown472",
            [0x473] = "unknown473",
            [0x474] = "unknown474",
            [0x475] = "unknown475",
            [0x476] = "unknown476",
            [0x477] = "unknown477",
            [0x478] = "unknown478",
            [0x479] = "unknown479",
            [0x47A] = "unknown47A",
            [0x47B] = "unknown47B",
            [0x47C] = "unknown47C",
            [0x47D] = "unknown47D",
            [0x47E] = "unknown47E",
            [0x47F] = "unknown47F",
            [0x480] = "unknown480",
            [0x481] = "unknown481",
            [0x482] = "unknown482",
            [0x483] = "unknown483",
            [0x484] = "unknown484",
            [0x485] = "unknown485",
            [0x486] = "unknown486",
            [0x487] = "unknown487",
            [0x488] = "unknown488",
            [0x489] = "unknown489",
            [0x48A] = "unknown48A",
            [0x48B] = "unknown48B",
            [0x48C] = "unknown48C",
            [0x48D] = "unknown48D",
            [0x48E] = "unknown48E",
            [0x48F] = "unknown48F",
            [0x490] = "unknown490",
            [0x491] = "unknown491",
            [0x492] = "unknown492",
            [0x493] = "unknown493",
            [0x494] = "unknown494",
            [0x495] = "unknown495",
            [0x496] = "unknown496",
            [0x497] = "unknown497",
            [0x498] = "unknown498",
            [0x499] = "unknown499",
            [0x49A] = "unknown49A",
            [0x49B] = "unknown49B",
            [0x49C] = "unknown49C",
            [0x49D] = "unknown49D",
            [0x49E] = "unknown49E",
            [0x49F] = "unknown49F",
            [0x4A0] = "unknown4A0",
            [0x4A1] = "unknown4A1",
            [0x4A2] = "unknown4A2",
            [0x4A3] = "unknown4A3",
            [0x4A4] = "unknown4A4",
            [0x4A5] = "unknown4A5",
            [0x4A6] = "unknown4A6",
            [0x4A7] = "unknown4A7",
            [0x4A8] = "unknown4A8",
            [0x4A9] = "unknown4A9",
            [0x4AA] = "unknown4AA",
            [0x4AB] = "unknown4AB",
            [0x4AC] = "unknown4AC",
            [0x4AD] = "unknown4AD",
            [0x4AE] = "unknown4AE",
            [0x4AF] = "unknown4AF",
            [0x4B0] = "unknown4B0",
            [0x4B1] = "unknown4B1",
            [0x4B2] = "unknown4B2",
            [0x4B3] = "unknown4B3",
            [0x4B4] = "unknown4B4",
            [0x4B5] = "unknown4B5",
            [0x4B6] = "unknown4B6",
            [0x4B7] = "unknown4B7",
            [0x4B8] = "unknown4B8",
            [0x4B9] = "unknown4B9",
            [0x4BA] = "unknown4BA",
            [0x4BB] = "unknown4BB",
            [0x4BC] = "unknown4BC",
            [0x4BD] = "unknown4BD",
            [0x4BE] = "unknown4BE",
            [0x4BF] = "unknown4BF",
            [0x4C0] = "unknown4C0",
            [0x4C1] = "unknown4C1",
            [0x4C2] = "unknown4C2",
            [0x4C3] = "unknown4C3",
            [0x4C4] = "unknown4C4",
            [0x4C5] = "unknown4C5",
            [0x4C6] = "unknown4C6",
            [0x4C7] = "unknown4C7",
            [0x4C8] = "unknown4C8",
            [0x4C9] = "unknown4C9",
            [0x4CA] = "unknown4CA",
            [0x4CB] = "unknown4CB",
            [0x4CC] = "unknown4CC",
            [0x4CD] = "unknown4CD",
            [0x4CE] = "unknown4CE",
            [0x4CF] = "unknown4CF",
            [0x4D0] = "unknown4D0",
            [0x4D1] = "unknown4D1",
            [0x4D2] = "unknown4D2",
            [0x4D3] = "unknown4D3",
            [0x4D4] = "cinematic_letterbox_style",
            [0x4D5] = "unknown4D5",
            [0x4D6] = "unknown4D6",
            [0x4D7] = "unknown4D7",
            [0x4D8] = "unknown4D8",
            [0x4D9] = "unknown4D9",
            [0x4DA] = "unknown4DA",
            [0x4DB] = "unknown4DB",
            [0x4DC] = "unknown4DC",
            [0x4DD] = "unknown4DD",
            [0x4DE] = "unknown4DE",
            [0x4DF] = "unknown4DF",
            [0x4E0] = "unknown4E0",
            [0x4E1] = "unknown4E1",
            [0x4E2] = "unknown4E2",
            [0x4E3] = "unknown4E3",
            [0x4E4] = "global_playtest_mode",
            [0x4E5] = "unknown4E5",
            [0x4E6] = "unknown4E6",
            [0x4E7] = "unknown4E7",
            [0x4E8] = "unknown4E8",
            [0x4E9] = "unknown4E9",
            [0x4EA] = "unknown4EA",
            [0x4EB] = "unknown4EB",
            [0x4EC] = "unknown4EC",
            [0x4ED] = "unknown4ED",
            [0x4EE] = "unknown4EE",
            [0x4EF] = "unknown4EF",
            [0x4F0] = "unknown4F0",
            [0x4F1] = "unknown4F1",
            [0x4F2] = "unknown4F2",
            [0x4F3] = "unknown4F3",
            [0x4F4] = "unknown4F4",
            [0x4F5] = "unknown4F5",
            [0x4F6] = "unknown4F6",
            [0x4F7] = "unknown4F7",
            [0x4F8] = "unknown4F8",
            [0x4F9] = "unknown4F9",
            [0x4FA] = "e3",
            [0x4FB] = "unknown4FB",
            [0x4FC] = "unknown4FC",
            [0x4FD] = "unknown4FD",
            [0x4FE] = "unknown4FE",
            [0x4FF] = "unknown4FF",
            [0x500] = "unknown500",
            [0x501] = "unknown501",
            [0x502] = "unknown502",
            [0x503] = "unknown503",
            [0x504] = "unknown504",
            [0x505] = "unknown505",
            [0x506] = "unknown506",
            [0x507] = "unknown507",
            [0x508] = "unknown508",
            [0x509] = "unknown509",
            [0x50A] = "unknown50A",
            [0x50B] = "unknown50B",
            [0x50C] = "unknown50C",
            [0x50D] = "unknown50D",
            [0x50E] = "lruv_lirp_enabled",
            [0x50F] = "unknown50F",
            [0x510] = "unknown510",
            [0x511] = "unknown511",
            [0x512] = "unknown512",
            [0x513] = "unknown513",
            [0x514] = "unknown514",
            [0x515] = "unknown515",
            [0x516] = "unknown516",
            [0x517] = "unknown517",
            [0x518] = "unknown518",
            [0x519] = "unknown519",
            [0x51A] = "unknown51A",
            [0x51B] = "unknown51B",
            [0x51C] = "unknown51C",
            [0x51D] = "unknown51D",
            [0x51E] = "unknown51E",
            [0x51F] = "unknown51F",
            [0x520] = "unknown520",
            [0x521] = "unknown521",
            [0x522] = "unknown522",
            [0x523] = "unknown523",
            [0x524] = "unknown524",
            [0x525] = "unknown525",
            [0x526] = "unknown526",
            [0x527] = "unknown527",
            [0x528] = "unknown528",
            [0x529] = "unknown529",
            [0x52A] = "unknown52A",
            [0x52B] = "unknown52B",
            [0x52C] = "unknown52C",
            [0x52D] = "unknown52D",
            [0x52E] = "unknown52E",
            [0x52F] = "unknown52F",
            [0x530] = "unknown530",
            [0x531] = "unknown531",
            [0x532] = "unknown532",
            [0x533] = "unknown533",
            [0x534] = "unknown534",
            [0x535] = "unknown535",
            [0x536] = "unknown536",
            [0x537] = "unknown537",
            [0x538] = "unknown538",
            [0x539] = "unknown539",
            [0x53A] = "unknown53A",
            [0x53B] = "unknown53B",
            [0x53C] = "unknown53C",
            [0x53D] = "unknown53D",
            [0x53E] = "unknown53E",
            [0x53F] = "unknown53F",
            [0x540] = "unknown540",
            [0x541] = "use_temp_directory_for_files",
            [0x542] = "unknown542",
            [0x543] = "unknown543",
            [0x544] = "unknown544",
            [0x545] = "unknown545",
            [0x546] = "unknown546",
            [0x547] = "unknown547",
            [0x548] = "unknown548",
            [0x549] = "unknown549",
            [0x54A] = "unknown54A",
            [0x54B] = "unknown54B",
            [0x54C] = "unknown54C",
            [0x54D] = "unknown54D",
            [0x54E] = "unknown54E",
            [0x54F] = "unknown54F",
            [0x550] = "unknown550",
            [0x551] = "unknown551",
            [0x552] = "unknown552",
            [0x553] = "unknown553",
            [0x554] = "unknown554",
            [0x555] = "unknown555",
            [0x556] = "unknown556",
            [0x557] = "unknown557",
            [0x558] = "unknown558",
            [0x559] = "unknown559",
            [0x55A] = "unknown55A",
            [0x55B] = "unknown55B",
            [0x55C] = "unknown55C",
            [0x55D] = "unknown55D",
            [0x55E] = "unknown55E",
            [0x55F] = "unknown55F",
            [0x560] = "unknown560",
            [0x561] = "enable_amortized_prediction",
            [0x562] = "unknown562",
            [0x563] = "enable_tag_resource_prediction",
            [0x564] = "enable_entire_pvs_prediction",
            [0x565] = "enable_cluster_objects_prediction",
            [0x566] = "unknown566",
            [0x567] = "unknown567",
            [0x568] = "unknown568",
            [0x569] = "unknown569",
            [0x56A] = "unknown56A",
            [0x56B] = "unknown56B",
            [0x56C] = "unknown56C",
            [0x56D] = "unknown56D",
            [0x56E] = "unknown56E",
            [0x56F] = "unknown56F",
            [0x570] = "unknown570",
            [0x571] = "unknown571",
            [0x572] = "unknown572",
            [0x573] = "unknown573",
            [0x574] = "unknown574",
            [0x575] = "unknown575",
            [0x576] = "unknown576",
            [0x577] = "unknown577",
            [0x578] = "unknown578",
            [0x579] = "unknown579",
            [0x57A] = "unknown57A",
            [0x57B] = "unknown57B",
            [0x57C] = "unknown57C",
            [0x57D] = "unknown57D",
            [0x57E] = "unknown57E",
            [0x57F] = "unknown57F",
            [0x580] = "unknown580",
            [0x581] = "unknown581",
            [0x582] = "unknown582",
            [0x583] = "unknown583",
            [0x584] = "unknown584",
            [0x585] = "unknown585",
            [0x586] = "unknown586",
            [0x587] = "unknown587",
            [0x588] = "unknown588",
            [0x589] = "unknown589",
            [0x58A] = "unknown58A",
            [0x58B] = "unknown58B",
            [0x58C] = "unknown58C",
            [0x58D] = "unknown58D",
            [0x58E] = "unknown58E",
            [0x58F] = "unknown58F",
            [0x590] = "unknown590",
            [0x591] = "unknown591",
            [0x592] = "unknown592",
            [0x593] = "unknown593",
            [0x594] = "unknown594",
            [0x595] = "unknown595",
            [0x596] = "unknown596",
            [0x597] = "ignore_predefined_performance_throttles",
            [0x598] = "enable_first_person_prediction",
            [0x599] = "enable_structure_prediction",
            [0x59A] = "unknown59A",
            [0x59B] = "minidump_force_regular_minidump_with_ui",
            [0x59C] = "unknown59C",
            [0x59D] = "unknown59D",
            [0x59E] = "unknown59E",
            [0x59F] = "unknown59F",
            [0x5A0] = "use_command_buffers",
            [0x5A1] = "use_group_command_buffers",
            [0x5A2] = "clear_command_buffer_cache",
            [0x5A3] = "command_buffers_generated_per_frame",
            [0x5A4] = "command_buffers_released_per_frame",
            [0x5A5] = "command_buffer_release_threshold",
            [0x5A6] = "unknown5A6",
            [0x5A7] = "use_command_buffer_fixups",
            [0x5A8] = "unknown5A8",
            [0x5A9] = "motion_blur_max",
            [0x5AA] = "motion_blur_scale",
            [0x5AB] = "motion_blur_center_falloff_x",
            [0x5AC] = "motion_blur_center_falloff_y",
            [0x5AD] = "motion_blur_fps_threshold",
            [0x5AE] = "unknown5AE",
            [0x5AF] = "unknown5AF",
            [0x5B0] = "unknown5B0",
            [0x5B1] = "unknown5B1",
            [0x5B2] = "unknown5B2",
            [0x5B3] = "unknown5B3",
            [0x5B4] = "unknown5B4",
            [0x5B5] = "unknown5B5",
            [0x5B6] = "g_fireteam_target_selection_preference_bonus",
            [0x5B7] = "ai_fireteam_hold_distance",
            [0x5B8] = "ai_fireteam_protect_leader",
            [0x5B9] = "unknown5B9",
            [0x5BA] = "unknown5BA",
            [0x5BB] = "unknown5BB",
            [0x5BC] = "unknown5BC",
            [0x5BD] = "unknown5BD",
            [0x5BE] = "unknown5BE",
            [0x5BF] = "force_buffer_2_frames",
            [0x5C0] = "disable_render_state_cache_optimization",
            [0x5C1] = "unknown5C1",
            [0x5C2] = "unknown5C2",
            [0x5C3] = "enable_better_cpu_gpu_sync",
            [0x5C4] = "unknown5C4",
            [0x5C5] = "unknown5C5",
            [0x5C6] = "unknown5C6",
            [0x5C7] = "unknown5C7",
            [0x5C8] = "unknown5C8",
            [0x5C9] = "unknown5C9",
            [0x5CA] = "cinematic_prediction_enable",
            [0x5CB] = "skies_delete_on_zone_set_switch_enable",
            [0x5CC] = "reduce_widescreen_fov_during_cinematics",
            [0x5CD] = "unknown5CD",
            [0x5CE] = "unknown5CE",
            [0x5CF] = "unknown5CF",
            [0x5D0] = "unknown5D0",
            [0x5D1] = "unknown5D1",
            [0x5D2] = "unknown5D2",
            [0x5D3] = "unknown5D3",
            [0x5D4] = "unknown5D4",
            [0x5D5] = "unknown5D5",
            [0x5D6] = "unknown5D6",
            [0x5D7] = "unknown5D7",
            [0x5D8] = "unknown5D8",
            [0x5D9] = "unknown5D9",
            [0x5DA] = "unknown5DA",
            [0x5DB] = "unknown5DB",
            [0x5DC] = "unknown5DC",
            [0x5DD] = "unknown5DD",
            [0x5DE] = "unknown5DE",
            [0x5DF] = "unknown5DF",
            [0x5E0] = "unknown5E0",
            [0x5E1] = "unknown5E1",
            [0x5E2] = "unknown5E2",
            [0x5E3] = "unknown5E3",
            [0x5E4] = "unknown5E4",
            [0x5E5] = "unknown5E5",
            [0x5E6] = "unknown5E6",
            [0x5E7] = "unknown5E7",
            [0x5E8] = "unknown5E8",
            [0x5E9] = "unknown5E9",
            [0x5EA] = "unknown5EA",
            [0x5EB] = "unknown5EB",
            [0x5EC] = "unknown5EC",
            [0x5ED] = "unknown5ED",
            [0x5EE] = "unknown5EE",
            [0x5EF] = "unknown5EF",
            [0x5F0] = "unknown5F0",
            [0x5F1] = "unknown5F1",
            [0x5F2] = "unknown5F2",
            [0x5F3] = "unknown5F3",
            [0x5F4] = "unknown5F4",
            [0x5F5] = "unknown5F5",
            [0x5F6] = "unknown5F6",
            [0x5F7] = "unknown5F7",
            [0x5F8] = "unknown5F8",
            [0x5F9] = "unknown5F9",
            [0x5FA] = "unknown5FA",
            [0x5FB] = "unknown5FB",
            [0x5FC] = "unknown5FC",
            [0x5FD] = "unknown5FD",
            [0x5FE] = "unknown5FE",
            [0x5FF] = "unknown5FF",
            [0x600] = "unknown600",
            [0x601] = "unknown601",
            [0x602] = "unknown602",
            [0x603] = "unknown603",
            [0x604] = "unknown604",
            [0x605] = "unknown605",
            [0x606] = "unknown606",
            [0x607] = "unknown607",
            [0x608] = "unknown608",
            [0x609] = "unknown609",
            [0x60A] = "unknown60A",
            [0x60B] = "unknown60B",
            [0x60C] = "unknown60C",
            [0x60D] = "unknown60D",
            [0x60E] = "unknown60E",
            [0x60F] = "unknown60F",
            [0x610] = "unknown610",
            [0x611] = "unknown611",
            [0x612] = "unknown612",
            [0x613] = "respawn_players_into_friendly_vehicle",
            [0x614] = "unknown614",
            [0x615] = "unknown615",
            [0x616] = "unknown616",
            [0x617] = "unknown617",
            [0x618] = "unknown618",
            [0x619] = "unknown619",
            [0x61A] = "unknown61A",
            [0x61B] = "debug_performances",
            [0x61C] = "unknown61C",
            [0x61D] = "unknown61D",
            [0x61E] = "unknown61E",
            [0x61F] = "unknown61F",
            [0x620] = "unknown620",
            [0x621] = "unknown621",
            [0x622] = "unknown622",
            [0x623] = "unknown623",
            [0x624] = "unknown624",
            [0x625] = "unknown625",
            [0x626] = "unknown626",
            [0x627] = "unknown627",
            [0x628] = "unknown628",
            [0x629] = "unknown629",
            [0x62A] = "unknown62A",
            [0x62B] = "unknown62B",
            [0x62C] = "unknown62C",
            [0x62D] = "unknown62D",
            [0x62E] = "unknown62E",
            [0x62F] = "unknown62F",
            [0x630] = "unknown630",
            [0x631] = "unknown631",
            [0x632] = "unknown632",
            [0x633] = "display_client_synchronous_input_lag",
            [0x634] = "unknown634",
            [0x635] = "unknown635",
            [0x636] = "unknown636",
            [0x637] = "unknown637",
            [0x638] = "unknown638",
            [0x639] = "unknown639",
            [0x63A] = "unknown63A",
            [0x63B] = "unknown63B",
            [0x63C] = "unknown63C",
            [0x63D] = "unknown63D",
            [0x63E] = "unknown63E",
            [0x63F] = "unknown63F",
            [0x640] = "unknown640",
            [0x641] = "unknown641",
            [0x642] = "clients_always_respect_action_priority_for_weapon_switch",
            [0x643] = "render_debug_visibility_bounding_sphere_scale",
            [0x644] = "game_engine_events_show_even_with_unparsed_tokens",
            [0x645] = "debug_button_action_mapping_active",
            [0x646] = "randomize_player_appearance_on_spawn",
            [0x647] = "render_debug_pause_aging",
            [0x648] = "main_disable_pix_counters",
            [0x649] = "net_always_record_bandwidth",
            [0x64A] = "use_playtest_rasterizer_throttle",
            [0x64B] = "render_debug_game_grief",
            [0x64C] = "render_debug_players_probability_of_winning",
            [0x64D] = "chud_state_debug_flag",
            [0x64E] = "render_invisible_models",
            [0x64F] = "main_block_simulate_ms",
            [0x650] = "net_block_simulate_ms",
            [0x651] = "net_message_queue_stress_test_pct",
            [0x652] = "convex_decomposition_enabled",
            [0x653] = "transport_force_shutdown",
            [0x654] = "prune_globals_for_gametype",
            [0x655] = "disable_saved_film_history",
            [0x656] = "allow_vehicle_to_vehicle_boarding",
            [0x657] = "visibility_query_plane_count",
            [0x658] = "jumperjumper_enabled",
            [0x659] = "net_banhammer_lsp_sync_enabled",
            [0x65A] = "supply_depot_notification_enabled",
            [0x65B] = "nag_messages_enabled",
            [0x65C] = "film_farm_enabled",
            [0x65D] = "net_log_all_message_queue_state",
            [0x65E] = "debug_havok_memory",
            [0x65F] = "render_transparents_bucket_low_res",
            [0x660] = "observer_collision_speed_scale",
            [0x661] = "leave_bonobo_init_in_place",
            [0x662] = "render_pre_placed_lights",
            [0x663] = "allow_spawning_with_no_spawn_points",
            [0x664] = "cui_service_record_test_enabled",
            [0x665] = "debug_aim_assist_lead_vectors_disabled",
            [0x666] = "first_person_motion_blur_speed_mapping_scale",
            [0x667] = "first_person_motion_blur_speed_mapping_offset",
            [0x668] = "special_object_motion_blur_speed_mapping_scale",
            [0x669] = "special_object_motion_blur_speed_mapping_offset",
            [0x66A] = "debug_suppress_crosshair_player_names",
            [0x66B] = "debug_suppress_all_game_engine_player_names",
            [0x66C] = "mirror_context_tracking_enabled",
            [0x66D] = "debug_airstrike",
            [0x66E] = "cui_debug_window_index",
            [0x66F] = "cui_render_debug_enabled",
            [0x670] = "guardian_kills_awarded_to_most_damage",
            [0x671] = "render_coop_spawn_safety_status_tests",
            [0x672] = "network_friends_leaderboard_test_enabled",
            [0x673] = "decal_bias_coeff_d",
            [0x674] = "decal_bias_coeff_e",
            [0x675] = "dump_game_options_on_establish_fail",
            [0x676] = "shadow_apply_depth_bias",
            [0x677] = "shadow_apply_slope_depth_bias",
            [0x678] = "campaign_save_tracker_test_content_item_exists",
            [0x679] = "override_file_transfer_upstream_quota_bytes_per_second",
            [0x67A] = "enable_prefetch_resource_defragmentation",
            [0x67B] = "player_respawn_check_airborne",
            [0x67C] = "use_command_buffer_shadow_generate",
            [0x67D] = "rasterizer_profiler_single_callback_enabled",
            [0x67E] = "shadow_generate_dynamic_lights_depth_bias",
            [0x67F] = "shadow_generate_dynamic_lights_slope_depth_bias",
            [0x680] = "shadow_generate_depth_bias",
            [0x681] = "shadow_generate_slope_depth_bias",
            [0x682] = "imposter_cache_build",
            [0x683] = "mvar_files_enabled",
            [0x684] = "mglo_files_enabled",
            [0x685] = "imposter_capturing",
            [0x686] = "debug_snap_to_map_variant",
            [0x687] = "enable_initial_bink_reclaim",
            [0x688] = "map_variant_debug",
            [0x689] = "map_variant_debug_objects",
            [0x68A] = "display_simulation_profiler_events",
            [0x68B] = "render_max_z_prepass_splitscreen_count",
            [0x68C] = "use_draw_bundles",
            [0x68D] = "flicker_draw_bundles",
            [0x68E] = "draw_bundle_stats",
        };

        public static Dictionary<int, ScriptInfo> Scripts = new Dictionary<int, ScriptInfo>
        {
            [0x000] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "begin"),
            [0x001] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "begin_random"),
            [0x002] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "begin_count"),
            [0x003] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "begin_random_count"),
            [0x004] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "if"),
            [0x005] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "cond"),
            [0x006] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "set"),
            [0x007] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "and"),
            [0x008] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "or"),
            [0x009] = new ScriptInfo(HsType.HaloOnlineValue.Real, "+"),
            [0x00A] = new ScriptInfo(HsType.HaloOnlineValue.Real, "-"),
            [0x00B] = new ScriptInfo(HsType.HaloOnlineValue.Real, "*"),
            [0x00C] = new ScriptInfo(HsType.HaloOnlineValue.Real, "/"),
            [0x00D] = new ScriptInfo(HsType.HaloOnlineValue.Real, "%"),
            [0x00E] = new ScriptInfo(HsType.HaloOnlineValue.Real, "min"),
            [0x00F] = new ScriptInfo(HsType.HaloOnlineValue.Real, "max"),
            [0x010] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "="),
            [0x011] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "!="),
            [0x012] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, ">"),
            [0x013] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "<"),
            [0x014] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, ">="),
            [0x015] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "<="),
            [0x016] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sleep"),
            [0x017] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sleep_forever"),
            [0x018] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "sleep_until"),
            [0x019] = new ScriptInfo(HsType.HaloOnlineValue.Void, "wake"),
            [0x01A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "inspect"),
            [0x01B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "branch"),
            [0x01C] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "unit"),
            [0x01D] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "vehicle"),
            [0x01E] = new ScriptInfo(HsType.HaloOnlineValue.Weapon, "weapon"),
            [0x01F] = new ScriptInfo(HsType.HaloOnlineValue.Device, "device"),
            [0x020] = new ScriptInfo(HsType.HaloOnlineValue.Scenery, "scenery"),
            [0x021] = new ScriptInfo(HsType.HaloOnlineValue.EffectScenery, "effect_scenery"),
            [0x022] = new ScriptInfo(HsType.HaloOnlineValue.Void, "evaluate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Script),
            },
            [0x023] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "not")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x024] = new ScriptInfo(HsType.HaloOnlineValue.Real, "pin")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x025] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dummy_function"),
            [0x026] = new ScriptInfo(HsType.HaloOnlineValue.Void, "print")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x027] = new ScriptInfo(HsType.HaloOnlineValue.Void, "log_print")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x028] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_show_thread")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x029] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_script_thread")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x02A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x02B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_globals")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x02C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_variable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x02D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_variable_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x02E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "breakpoint")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x02F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_active_scripts"),
            [0x030] = new ScriptInfo(HsType.HaloOnlineValue.Long, "get_executing_running_thread"),
            [0x031] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_thread")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x032] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "script_started")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x033] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "script_finished")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x034] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "local_players"),
            [0x035] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "players"),
            [0x036] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "players_human"),
            [0x037] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "players_elite"),
            [0x038] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "player_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            //[0x039] = new ScriptInfo(HsType.HaloOnlineValue.player, "player_in_game_get")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x03A] = new ScriptInfo(HsType.HaloOnlineValue.player, "human_player_in_game_get")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x03B] = new ScriptInfo(HsType.HaloOnlineValue.player, "elite_player_in_game_get")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x03C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_is_in_game")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x03D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "editor_mode"),
            [0x03E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_volume_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x03F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_volume_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x040] = new ScriptInfo(HsType.HaloOnlineValue.Void, "volume_teleport_players_not_inside")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x041] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x042] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x043] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_objects_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x044] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x045] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_players_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x046] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "volume_return_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x047] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "volume_return_objects_by_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x048] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "volume_return_objects_by_campaign_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x049] = new ScriptInfo(HsType.HaloOnlineValue.Void, "zone_set_trigger_volume_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x04A] = new ScriptInfo(HsType.HaloOnlineValue.Object, "list_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x04B] = new ScriptInfo(HsType.HaloOnlineValue.Short, "list_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x04C] = new ScriptInfo(HsType.HaloOnlineValue.Short, "list_count_not_dead")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x04D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x04E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_random")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x04F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_random")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x050] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_at_ai_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x051] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_at_point_set_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x052] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_on_object_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x053] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_on_object_marker_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x054] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_stop_object_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x055] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_on_ground")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x056] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x057] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_object_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x058] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_objects_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x059] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x05A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x05B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
            },
            [0x05C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "soft_ceiling_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x05D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x05E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x05F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_clone")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x060] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_anew")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x061] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_if_necessary")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x062] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_folder")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x063] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_folder_anew")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x064] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x065] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy_all"),
            [0x066] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy_type_mask")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x067] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_delete_by_definition")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x068] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy_folder")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x069] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_hide")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x06A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shadowless")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x06B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_allegiance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x06C] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_buckling_magnitude_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x06D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_function_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x06E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_function_variable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x06F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_cinematic_function_variable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x070] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_clear_cinematic_function_variable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x071] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_clear_all_function_variables")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x072] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_dynamic_simulation_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x073] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_phantom_power")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x074] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_wake_physics")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x075] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "object_get_at_rest")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x076] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_ranged_attack_inhibited")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x077] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_melee_attack_inhibited")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x078] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_dump_memory"),
            [0x079] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_get_health")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x07A] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_get_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x07B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x07C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_physics")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x07D] = new ScriptInfo(HsType.HaloOnlineValue.Object, "object_get_parent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x07E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_attach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x07F] = new ScriptInfo(HsType.HaloOnlineValue.Object, "object_at_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x080] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_detach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x081] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_scale")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x082] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_velocity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x083] = new ScriptInfo(HsType.HaloOnlineValue.Short, "object_get_bsp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x084] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_as_fireteam_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x085] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "object_is_reserved")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x086] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_velocity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x087] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_deleted_when_deactivated")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x088] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_copy_player_appearance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x089] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "object_model_target_destroyed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x08A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "object_model_targets_destroyed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x08B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_enable_damage_section")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x08C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_disable_damage_section")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x08D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_damage_damage_section")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x08E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cannot_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x08F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cannot_die_except_kill_volumes")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x090] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_ignores_emp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x091] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "object_vitality_pinned")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x092] = new ScriptInfo(HsType.HaloOnlineValue.Void, "garbage_collect_now"),
            [0x093] = new ScriptInfo(HsType.HaloOnlineValue.Void, "garbage_collect_unsafe"),
            [0x094] = new ScriptInfo(HsType.HaloOnlineValue.Void, "garbage_collect_multiplayer"),
            [0x095] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cannot_take_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x096] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_get_recent_body_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x097] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_get_recent_shield_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x098] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_can_take_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x099] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_immune_to_friendly_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x09A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cinematic_lod")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x09B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cinematic_collision")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x09C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cinematic_visibility")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x09D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x09E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_predict_high")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x09F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_predict_low")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x0A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_type_predict_high")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x0A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_type_predict_low")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x0A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_type_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x0A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x0A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_teleport_to_ai_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x0A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_facing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x0A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield_stun")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield_stun_infinite")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_permutation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_region_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ModelState),
            },
            [0x0AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_model_state_property")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0AD] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "objects_can_see_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0AE] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "objects_can_see_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0AF] = new ScriptInfo(HsType.HaloOnlineValue.Real, "objects_distance_to_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0B0] = new ScriptInfo(HsType.HaloOnlineValue.Real, "objects_distance_to_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x0B1] = new ScriptInfo(HsType.HaloOnlineValue.Real, "objects_distance_to_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x0B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_info"),
            [0x0B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "position_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "shader_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Shader),
            },
            [0x0B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bitmap_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Bitmap),
            },
            [0x0B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "script_recompile"),
            [0x0B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "script_doc"),
            [0x0B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "help")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x0B9] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "game_engine_objects"),
            [0x0BA] = new ScriptInfo(HsType.HaloOnlineValue.Short, "random_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x0BB] = new ScriptInfo(HsType.HaloOnlineValue.Real, "real_random_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_constants_reset"),
            [0x0BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_set_gravity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_set_velocity_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_disable_character_ground_adhesion_forces")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_debug_start"),
            [0x0C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_debug_stop"),
            [0x0C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_dump_world")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_dump_world_close_movie"),
            [0x0C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_profile_start"),
            [0x0C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_profile_stop"),
            [0x0C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_profile_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_reset_allocated_state"),
            [0x0C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "breakable_surfaces_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "breakable_surfaces_reset"),
            [0x0CA] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "recording_play")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneRecording),
            },
            [0x0CB] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "recording_play_and_delete")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneRecording),
            },
            [0x0CC] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "recording_play_and_hover")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneRecording),
            },
            [0x0CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "recording_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0CE] = new ScriptInfo(HsType.HaloOnlineValue.Short, "recording_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0CF] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "render_lights")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "print_light_state"),
            [0x0D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_lights_enable_cinematic_shadow")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_object_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_attach_to_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_target_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_position_world_offset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_on"),
            [0x0D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_bink"),
            [0x0DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_off"),
            [0x0DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_aspect_ratio")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_resolution")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_render_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_fov")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_fov_frame_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_enable_dynamic_lights")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_on")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_off")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_set_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_set_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_attach_to_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_target_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_structure")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_highlight_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_clear_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_spin_around")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_from_player_view")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_window")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_texture_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_cheap_particles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_rain_occlusion")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_rain_fog")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_rain_toggle"),
            [0x0F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "weather_animate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "weather_animate_force")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_structure_cluster")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_cluster_fog")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_plane")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_plane_infinite_extent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0F8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_zone")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_zone_floodfill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_all_fog_planes")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_all_cluster_errors")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_line_opacity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_text_opacity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_opacity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_non_occluded_fog_planes")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x100] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_use_pervertex"),
            [0x101] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_use_reset"),
            [0x102] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_sample_enable"),
            [0x103] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_sample_disable"),
            [0x104] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_object_bitmaps")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x105] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_bsp_resources")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x106] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_all_object_resources"),
            [0x107] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_d3d_resources"),
            [0x108] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_text_using_simple_font")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x109] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_postprocess_color_tweaking_reset"),
            [0x10A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_wrinkle_weights_a")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x10B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_wrinkle_weights_b")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x10C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_wrinkle_weights_from_console")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x10D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x10E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x10F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x110] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_relative_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x111] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x112] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_relative_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x113] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_idle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
            },
            [0x114] = new ScriptInfo(HsType.HaloOnlineValue.Short, "scenery_get_animation_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
            },
            [0x115] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_can_blink")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x116] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_active_camo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x117] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_open")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x118] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_close")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x119] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x11A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_kill_silent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x11B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_is_emitting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x11C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_is_emp_stunned")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x11D] = new ScriptInfo(HsType.HaloOnlineValue.Short, "unit_get_custom_animation_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x11E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_stop_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x11F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x120] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x121] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x122] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_relative_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x123] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_list")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x124] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_custom_animation_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x125] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_custom_animation_relative_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x126] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_is_playing_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x127] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_mandibles_hidden")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x128] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_capture_set_file_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x129] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_capture_set_origin_object_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x12A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_capture_start_recording"),
            [0x12B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_capture_stop_recording"),
            [0x12C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "sync_action_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x12D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "object_running_sync_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x12E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_custom_animations_hold_on_last_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x12F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_custom_animations_prevent_lipsync_head_movement")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x130] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "preferred_animation_list_add")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x131] = new ScriptInfo(HsType.HaloOnlineValue.Void, "preferred_animation_list_clear"),
            [0x132] = new ScriptInfo(HsType.HaloOnlineValue.Short, "unit_get_team_index")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x133] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_aim_without_turning")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x134] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_enterable_by_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x135] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_get_enterable_by_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x136] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_only_takes_damage_from_players_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x137] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_enter_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x138] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_enter_vehicle_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x139] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_falling_damage_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x13A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_in_vehicle_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x13B] = new ScriptInfo(HsType.HaloOnlineValue.Short, "object_get_turret_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x13C] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "object_get_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x13D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_board_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x13E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_emotion")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x13F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_emotion_by_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x140] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_enable_eye_tracking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x141] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_integrated_flashlight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x142] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_in_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x143] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "unit_get_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x144] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_set_player_interaction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x145] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_set_unit_interaction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x146] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_test_seat_unit_list")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x147] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_test_seat_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x148] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_test_seat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x149] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_prefer_tight_camera_track")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x14A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_test_seat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x14B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_exit_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x14C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_exit_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x14D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_maximum_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x14E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "units_set_maximum_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x14F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_current_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x150] = new ScriptInfo(HsType.HaloOnlineValue.Void, "units_set_current_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x151] = new ScriptInfo(HsType.HaloOnlineValue.Short, "vehicle_load_magic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x152] = new ScriptInfo(HsType.HaloOnlineValue.Short, "vehicle_unload")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x153] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_animation_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x154] = new ScriptInfo(HsType.HaloOnlineValue.Void, "magic_melee_attack"),
            [0x155] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "vehicle_riders")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x156] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "vehicle_driver")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x157] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "vehicle_gunner")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x158] = new ScriptInfo(HsType.HaloOnlineValue.Real, "unit_get_health")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x159] = new ScriptInfo(HsType.HaloOnlineValue.Real, "unit_get_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x15A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "unit_get_total_grenade_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x15B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x15C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_weapon_readied")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x15D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_any_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x15E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x15F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_lower_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x160] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_raise_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x161] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_drop_support_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x162] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_spew_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x163] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_force_reload")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x164] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_stats_dump"),
            [0x165] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_animation_forced_seat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x166] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_doesnt_drop_items")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x167] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_impervious")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x168] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_suspended")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x169] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_add_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StartingProfile),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x16A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "weapon_set_primary_barrel_firing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Weapon),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x16B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "weapon_hold_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Weapon),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x16C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "weapon_enable_warthog_chaingun_light")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x16D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_set_never_appears_locked")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x16E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_set_power")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x16F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_set_position_transition_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x170] = new ScriptInfo(HsType.HaloOnlineValue.Real, "device_get_power")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
            },
            [0x171] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_set_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x172] = new ScriptInfo(HsType.HaloOnlineValue.Real, "device_get_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
            },
            [0x173] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_set_position_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x174] = new ScriptInfo(HsType.HaloOnlineValue.Real, "device_group_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
            },
            [0x175] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_group_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x176] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_group_set_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x177] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_one_sided_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x178] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_ignore_player_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x179] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_operates_automatically_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x17A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_closes_automatically_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x17B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_group_change_only_once_more_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x17C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_set_position_track")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x17D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_set_overlay_track")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x17E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_animate_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x17F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_animate_overlay")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x180] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_all_powerups"),
            [0x181] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_all_weapons"),
            [0x182] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_all_vehicles"),
            [0x183] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_teleport_to_camera"),
            [0x184] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_active_camouflage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x185] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_active_camouflage_by_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            //},
            [0x186] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheats_load"),
            [0x187] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop_safe")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x188] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x189] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x18A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop_permutation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x18B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "update_dropped_tag_permutation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x18C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x18D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_enabled"),
            [0x18E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_grenades")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x18F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x190] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_updating_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x191] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_player_dialogue_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x192] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_actor_dialogue_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x193] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_actor_dialogue_effect_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x194] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_infection_suppress")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x195] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_fast_and_dumb")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x196] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_lod_full_detail_actors")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x197] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_lod_full_detail_actors"),
            [0x198] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_force_full_lod")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x199] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_force_low_lod")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_clear_lod")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_log_reset"),
            [0x19C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_log_dump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x19D] = new ScriptInfo(HsType.HaloOnlineValue.Object, "ai_get_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19E] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "ai_get_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19F] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_get_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A0] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_get_turret_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1A1] = new ScriptInfo(HsType.HaloOnlineValue.PointReference, "ai_random_smart_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1A2] = new ScriptInfo(HsType.HaloOnlineValue.PointReference, "ai_nearest_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x1A3] = new ScriptInfo(HsType.HaloOnlineValue.Long, "ai_get_point_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x1A4] = new ScriptInfo(HsType.HaloOnlineValue.PointReference, "ai_point_set_get_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_debug_dump_behavior_tree")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_in_limbo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_in_limbo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_in_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_cannot_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1AC] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_vitality_pinned")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_wave")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_wave")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_wave_in_limbo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_wave_in_limbo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_clump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_designer_clump_perception_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_designer_clump_targeting_group")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1B4] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_index_from_spawn_formation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_resurrect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x1B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_kill_silent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_kill_no_statistics")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_erase")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_erase_all"),
            [0x1BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_disposable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_select")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_deselect"),
            [0x1BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_deaf")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_blind")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_weapon_up")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_flood_disperse")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_add_navpoint")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_magically_see")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_magically_see_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x1C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_active_camo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_suppress_combat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_engineer_explode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_grunt_kamikaze")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_squad_enumerate_immigrants")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_migrate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_migrate_persistent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allegiance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x1CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allegiance_remove")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x1CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allegiance_break")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x1CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_braindead")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_braindead_by_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_disregard")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_disregard_orphans")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_prefer_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_prefer_target_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x1D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_prefer_target_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_targeting_group")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_targeting_group")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_teleport_to_starting_location_if_outside_bsp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_teleport_to_spawn_point_if_outside_bsp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x1DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_bring_forward")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_renew")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_force_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_force_active_by_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_exit_limbo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_playfight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_reconnect"),
            [0x1E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_berserk")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x1E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allow_dormant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1E5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_is_attacking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1E6] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_fighting_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1E7] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_living_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1E8] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_living_fraction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1E9] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_in_vehicle_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1EA] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_body_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1EB] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_strength")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1EC] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_swarm_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1ED] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_nonswarm_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1EE] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "ai_actors")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1EF] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_allegiance_broken")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x1F0] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_spawn_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1F1] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "object_get_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x1F2] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_set_task")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1F3] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_set_objective")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1F4] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_task_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1F5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_set_task_condition")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1F6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_leadership")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1F7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_leadership_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1F8] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_task_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_reset_objective")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_squad_patrol_objective_disallow")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_cue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_remove_cue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1FD] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "generate_pathfinding"),
            [0x1FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_render_paths_all"),
            [0x1FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_render_evaluations_shading_none"),
            [0x200] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_render_evaluations_shading_all"),
            //[0x201] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_render_evaluations_shading")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.firingpointevaluator),
            //},
            [0x202] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_activity_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x203] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_activity_abort")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x204] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_object_set_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x205] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_object_set_targeting_bias")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x206] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_object_set_targeting_ranges")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x207] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_object_enable_targeting_from_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x208] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_object_enable_grenade_attack")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x209] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x20A] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get_from_starting_location")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x20B] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get_from_spawn_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x20C] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_vehicle_get_squad_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x20D] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get_from_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x20E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_vehicle_reserve_seat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x20F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_vehicle_reserve")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x210] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_player_get_vehicle_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x211] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_vehicle_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x212] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_carrying_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x213] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_in_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            //[0x214] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_player_needs_vehicle")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x215] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_player_any_needs_vehicle"),
            [0x216] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x217] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x218] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x219] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x21A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_enter_squad_vehicles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x21B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x21C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x21D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_overturned")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x21E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_flip")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x21F] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_squad_group_get_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x220] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_squad_group_get_squad_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x221] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_squad_patrol_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x222] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x223] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x224] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x225] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x226] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x227] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_delete")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x228] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_destroy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x229] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_definition_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x22A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flock_unperch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x22B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flock_set_targeting_group")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x22C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flock_destination_set_enabled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x22D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flock_destination_set_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x22E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flock_destination_copy_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x22F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x230] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_create_runtime_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x231] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_create_runtime_point_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x232] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_add_runtime_point_to_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x233] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_add_runtime_point_to_set_from_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x234] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_add_starting_location_to_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x235] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_add_starting_location_to_squad_from_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x236] = new ScriptInfo(HsType.HaloOnlineValue.Long, "mantini_add_cell_to_runtime_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x237] = new ScriptInfo(HsType.HaloOnlineValue.Long, "mantini_get_runtime_squad_cell_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x238] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_set_squad_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x239] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_set_spawn_point_weapons")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x23A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_set_spawn_point_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x23B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_set_spawn_point_variants")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x23C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_set_squad_cell_spawn_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x23D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_clear_runtime_squads"),
            [0x23E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mantini_remove_pointset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x23F] = new ScriptInfo(HsType.HaloOnlineValue.String, "mantini_get_loaded_map_name"),
            [0x240] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_verify_tags"),
            [0x241] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_wall_lean")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x242] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_fire_dialogue_event")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x243] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_play_vocalization")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x244] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_play_vocalization_on_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x245] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x246] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line_at_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x247] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line_on_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x248] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line_on_object_for_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x249] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_play_line_on_point_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x24A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_play_line_on_point_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x24B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_time_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x24C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_award_points")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x24D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_award_skull")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.skull),
            //},
            [0x24E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_metagame_enabled"),
            [0x24F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_survival_enabled"),
            [0x250] = new ScriptInfo(HsType.HaloOnlineValue.Void, "thespian_performance_test")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x251] = new ScriptInfo(HsType.HaloOnlineValue.Void, "thespian_folder_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x252] = new ScriptInfo(HsType.HaloOnlineValue.Void, "thespian_folder_deactivate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x253] = new ScriptInfo(HsType.HaloOnlineValue.Void, "thespian_performance_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x254] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "thespian_performance_setup_and_begin")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x255] = new ScriptInfo(HsType.HaloOnlineValue.Long, "performance_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x256] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cast_squad_in_performance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x257] = new ScriptInfo(HsType.HaloOnlineValue.Void, "performance_begin")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x258] = new ScriptInfo(HsType.HaloOnlineValue.Void, "thespian_performance_kill_by_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x259] = new ScriptInfo(HsType.HaloOnlineValue.Void, "thespian_performance_kill_by_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x25A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "thespian_fake_task_transition")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x25B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "performance_play_line_by_id")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x25C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "performance_play_line")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x25D] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "performance_get_actor_by_index")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x25E] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "performance_get_actor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x25F] = new ScriptInfo(HsType.HaloOnlineValue.Short, "performance_get_actor_count"),
            [0x260] = new ScriptInfo(HsType.HaloOnlineValue.Short, "performance_get_role_count"),
            [0x261] = new ScriptInfo(HsType.HaloOnlineValue.Short, "performance_get_line_count"),
            [0x262] = new ScriptInfo(HsType.HaloOnlineValue.Short, "performance_get_last_played_line_index"),
            [0x263] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "thespian_performance_is_blocked"),
            [0x264] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "actor_from_performance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x265] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_player_add_fireteam_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x266] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_player_remove_fireteam_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x267] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_player_set_fireteam_max")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x268] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_player_set_fireteam_no_max")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x269] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_player_set_fireteam_max_squad_absorb_distance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x26A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_fireteam_absorber")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x26B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_fireteam_fallback_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x26C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_is_in_fireteam")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x26D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_run_command_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x26E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_queue_command_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x26F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stack_command_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x270] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x271] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x272] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x273] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x274] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x275] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x276] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x277] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "vs_role")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x278] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_alert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x279] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x27B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_alert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_alert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x280] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x281] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x282] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x283] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x284] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_command_script_running")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x285] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_command_script_attached")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x286] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cs_number_queued")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x287] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_moving"),
            [0x288] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_moving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x289] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x28A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x28B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x28C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x28D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x28E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x28F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x290] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x291] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x292] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x293] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x294] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x295] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x296] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x297] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x298] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x299] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x29A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x29B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x29C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x29D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x29E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x29F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_and_posture")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x2A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_and_posture")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x2A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_attach_to_spline")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x2A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_nearest")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x2A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_nearest")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_nearest")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_in_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_in_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_towards_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_towards_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_swarm_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_swarm_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_swarm_from")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_swarm_from")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_grenade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_grenade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_use_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_use_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_jump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_jump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_jump_to_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_jump_to_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vocalize")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vocalize")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x2BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x2BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_action_at_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_action_at_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_action_at_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_action_at_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_line")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x2D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_line")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x2D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_deploy_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_deploy_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_approach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_approach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_approach_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_approach_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x2E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x2E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x2E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x2E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_set_style")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Style),
            },
            [0x2E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_set_style")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Style),
            },
            [0x2E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_force_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_force_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_targeting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_targeting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_looking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_looking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_moving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_moving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_suppress_activity_termination")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_suppress_activity_termination")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_suppress_dialogue_global")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_suppress_dialogue_global")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_look_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_look_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_look_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2F8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_look_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_aim")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_aim")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_aim_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_aim_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_aim_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_aim_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x300] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x301] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_face_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x302] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_face_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x303] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_face_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x304] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_face_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x305] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x306] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x307] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x308] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x309] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x30A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x30B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot_secondary_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x30C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot_secondary_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x30D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_lower_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x30E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_lower_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x30F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vehicle_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x310] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vehicle_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x311] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vehicle_speed_instantaneous")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x312] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vehicle_speed_instantaneous")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x313] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vehicle_boost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x314] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vehicle_boost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x315] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_turn_sharpness")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x316] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_turn_sharpness")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x317] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_pathfinding_failsafe")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x318] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_enable_pathfinding_failsafe")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x319] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_set_pathfinding_radius")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x31A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_set_pathfinding_radius")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x31B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_ignore_obstacles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x31C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_ignore_obstacles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x31D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_approach_stop"),
            [0x31E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_approach_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x31F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_push_stance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x320] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_push_stance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x321] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x322] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x323] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x324] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x325] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_walk")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x326] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_walk")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x327] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_posture_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x328] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_posture_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x329] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_posture_exit"),
            [0x32A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_posture_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x32B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stow")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x32C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stow")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x32D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x32E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x32F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stop_custom_animation"),
            [0x330] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_stop_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x331] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stop_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x332] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_stop_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x333] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_player_melee")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x334] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_player_melee")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x335] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_melee_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x336] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_melee_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x337] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_smash_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x338] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_smash_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x339] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_control")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x33A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x33B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x33C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x33D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x33E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_with_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x33F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative_with_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x340] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative_with_speed_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x341] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative_with_speed_loop_offset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x342] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_predict_resources_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x343] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_predict_resources_at_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x344] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_first_person")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x345] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_cinematic"),
            [0x346] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_cinematic_scene")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicSceneDefinition),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x347] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_place_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x348] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_place_worldspace"),
            [0x349] = new ScriptInfo(HsType.HaloOnlineValue.Short, "camera_time"),
            [0x34A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_field_of_view")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x34B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_camera_set_easing_in")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x34C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_camera_set_easing_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x34D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_print")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x34E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_pan")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x34F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_pan")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x350] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_save"),
            [0x351] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_load"),
            [0x352] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_save_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x353] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_load_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x354] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_save_simple_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x355] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_load_simple_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x356] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_load_text")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x357] = new ScriptInfo(HsType.HaloOnlineValue.Void, "director_debug_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x358] = new ScriptInfo(HsType.HaloOnlineValue.Void, "director_print_camera_transform")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x359] = new ScriptInfo(HsType.HaloOnlineValue.Void, "director_print_deterministic_camera_transform")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x35A] = new ScriptInfo(HsType.HaloOnlineValue.GameDifficulty, "game_difficulty_get"),
            [0x35B] = new ScriptInfo(HsType.HaloOnlineValue.GameDifficulty, "game_difficulty_get_real"),
            [0x35C] = new ScriptInfo(HsType.HaloOnlineValue.Short, "game_insertion_point_get"),
            [0x35D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_set_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x35E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_set_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x35F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_clear"),
            [0x360] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_reset"),
            [0x361] = new ScriptInfo(HsType.HaloOnlineValue.Void, "players_unzoom_all"),
            [0x362] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_enable_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x363] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_disable_movement")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x364] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_disable_weapon_pickup")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x365] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_night_vision_on"),
            [0x366] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_night_vision_on")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x367] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_active_camouflage_on"),
            [0x368] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_camera_control")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x369] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_action_test_reset"),
            [0x36A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_primary_trigger"),
            [0x36B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_grenade_trigger"),
            [0x36C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_vision_trigger"),
            [0x36D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_rotate_weapons"),
            [0x36E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_rotate_grenades"),
            [0x36F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_jump"),
            [0x370] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_equipment"),
            [0x371] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_context_primary"),
            [0x372] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_vehicle_trick_primary"),
            [0x373] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_vehicle_trick_secondary"),
            [0x374] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_melee"),
            [0x375] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_action"),
            [0x376] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_accept"),
            [0x377] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_cancel"),
            [0x378] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_up"),
            [0x379] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_down"),
            [0x37A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_left"),
            [0x37B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_right"),
            [0x37C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_all_directions"),
            [0x37D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_move_relative_all_directions"),
            [0x37E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_cinematic_skip"),
            [0x37F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_start"),
            [0x380] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_back"),
            [0x381] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_up"),
            [0x382] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_down"),
            [0x383] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_left"),
            [0x384] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_right"),
            //[0x385] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_action_test_reset")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x386] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_primary_trigger")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x387] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_grenade_trigger")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x388] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_vision_trigger")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x389] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_rotate_weapons")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x38A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_rotate_grenades")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x38B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_jump")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x38C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_equipment")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x38D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_context_primary")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x38E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_vehicle_trick_primary")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x38F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_vehicle_trick_secondary")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x390] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_melee")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x391] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_action")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x392] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_accept")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x393] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_cancel")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x394] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_up")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x395] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_down")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x396] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_left")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x397] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_right")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x398] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_all_directions")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x399] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_move_relative_all_directions")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x39A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_cinematic_skip")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x39B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_start")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x39C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_back")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x39D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_up")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x39E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_down")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x39F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_left")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x3A0] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_right")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x3A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_confirm_message")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x3A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_confirm_cancel_message")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x3A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_enable_soft_ping_region")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.damageregion),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            //},
            [0x3A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_print_soft_ping_regions")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x3A5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player0_looking_up"),
            [0x3A6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player0_looking_down"),
            //[0x3A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_pitch")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x3A8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_has_female_voice")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x3A9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_lookstick_forward"),
            [0x3AA] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_lookstick_backward"),
            [0x3AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_teleport_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x3AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_content_status_reload"),
            [0x3AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_content_status_force_local"),
            [0x3AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_content_status_force_content"),
            [0x3AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_content_status_force_clear"),
            [0x3B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_reset"),
            [0x3B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_reset_random"),
            [0x3B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "switch_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ZoneSet),
            },
            [0x3B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_print_zone_sets"),
            [0x3B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_print_current_zone_set"),
            [0x3B5] = new ScriptInfo(HsType.HaloOnlineValue.Long, "current_zone_set"),
            [0x3B6] = new ScriptInfo(HsType.HaloOnlineValue.Long, "current_zone_set_fully_active"),
            [0x3B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "switch_map_and_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "crash")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "version"),
            [0x3BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status"),
            [0x3BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "record_movie")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x3BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "record_movie_distributed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_debug"),
            [0x3BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_big")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_big_raw")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_size")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_simple")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_cubemap")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_webmap")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cubemap_dynamic_generate"),
            [0x3C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_snapshot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "structure_instance_snapshot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_thumbnail")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "main_menu"),
            [0x3CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "main_halt")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_multiplayer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_campaign"),
            [0x3CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_survival"),
            [0x3CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_player_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_set_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_splitscreen")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_difficulty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.GameDifficulty),
            },
            [0x3D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_active_skulls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_coop_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_initial_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_tick_rate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_start_when_ready"),
            [0x3D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_start_when_joined")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_rate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x3DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_cache_flush"),
            [0x3DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "geometry_cache_flush"),
            [0x3DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_cache_flush"),
            [0x3DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_cache_flush"),
            [0x3DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "font_cache_flush"),
            [0x3E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "language_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_cache_test_malloc"),
            [0x3E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_memory"),
            [0x3E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_memory_by_file"),
            [0x3E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_memory_for_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_tags"),
            [0x3E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_single_tag"),
            [0x3E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tags_verify_all"),
            [0x3E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "trace_next_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "trace_next_frame_to_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "trace_tick")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "collision_log_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_control_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_control_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_lines"),
            [0x3EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_break_on_vocalization")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "fade_in")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x3F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "fade_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            //[0x3F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "fade_in_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x3F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "fade_out_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x3F4] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_tag_fade_out_from_game")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3F5] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_tag_fade_in_to_cinematic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3F6] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_tag_fade_out_from_cinematic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3F7] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_tag_fade_in_to_game")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            //[0x3F8] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_transition_fade_out_from_game")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.cinematictransitiondefinition),
            //},
            //[0x3F9] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_transition_fade_in_to_cinematic")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.cinematictransitiondefinition),
            //},
            //[0x3FA] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_transition_fade_out_from_cinematic")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.cinematictransitiondefinition),
            //},
            //[0x3FB] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cinematic_transition_fade_in_to_game")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.cinematictransitiondefinition),
            //},
            [0x3FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_run_script_by_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_start"),
            [0x3FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_stop"),
            [0x3FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_skip_start_internal"),
            [0x400] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_skip_stop_internal"),
            [0x401] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_show_letterbox")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x402] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_show_letterbox_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x403] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_title")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
            },
            [0x404] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_title_delayed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x405] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_suppress_bsp_object_creation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x406] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_subtitle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x407] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicDefinition),
            },
            [0x408] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_shot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicSceneDefinition),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x409] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_get_shot"),
            [0x40A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_early_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x40B] = new ScriptInfo(HsType.HaloOnlineValue.Long, "cinematic_get_early_exit"),
            [0x40C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_active_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x40D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_object_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x40E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_object_create_cinematic_anchor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x40F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_object_destroy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x410] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_objects_destroy_all"),
            [0x411] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_destroy"),
            [0x412] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cinematic_in_progress"),
            [0x413] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cinematic_can_be_skipped"),
            [0x414] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_clips_initialize_for_shot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x415] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_clips_destroy"),
            [0x416] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lights_initialize_for_shot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x417] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lights_destroy"),
            [0x418] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lights_destroy_shot"),
            [0x419] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_light_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicLightprobe),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x41A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_light_object_off")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x41B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_rebuild_all"),
            [0x41C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_update_dynamic_light_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x41D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_update_vmf_light")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x41E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_update_analytical_light")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x41F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_update_ambient_light")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x420] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_update_scales")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x421] = new ScriptInfo(HsType.HaloOnlineValue.Object, "cinematic_object_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x422] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "cinematic_unit_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x423] = new ScriptInfo(HsType.HaloOnlineValue.Weapon, "cinematic_weapon_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x424] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_reset"),
            [0x425] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_briefing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x426] = new ScriptInfo(HsType.HaloOnlineValue.CinematicDefinition, "cinematic_tag_reference_get_cinematic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x427] = new ScriptInfo(HsType.HaloOnlineValue.CinematicSceneDefinition, "cinematic_tag_reference_get_scene")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x428] = new ScriptInfo(HsType.HaloOnlineValue.Effect, "cinematic_tag_reference_get_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x429] = new ScriptInfo(HsType.HaloOnlineValue.Sound, "cinematic_tag_reference_get_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x42A] = new ScriptInfo(HsType.HaloOnlineValue.Sound, "cinematic_tag_reference_get_music")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x42B] = new ScriptInfo(HsType.HaloOnlineValue.LoopingSound, "cinematic_tag_reference_get_music_looping")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x42C] = new ScriptInfo(HsType.HaloOnlineValue.AnimationGraph, "cinematic_tag_reference_get_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x42D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cinematic_scripting_object_coop_flags_valid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x42E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_fade_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x42F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x430] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_cinematic_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x431] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x432] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_destroy_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x433] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_destroy_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x434] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_scene")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x435] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_destroy_scene")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x436] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x437] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_music")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x438] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x439] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_stop_music")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x43A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_screen_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x43B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_stop_screen_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x43C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x43D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_cinematic_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x43E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_object_no_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x43F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_cinematic_object_no_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x440] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_set_user_input_constraints")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x441] = new ScriptInfo(HsType.HaloOnlineValue.Void, "attract_mode_start"),
            [0x442] = new ScriptInfo(HsType.HaloOnlineValue.Void, "attract_mode_set_seconds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x443] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_won"),
            [0x444] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_lost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x445] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_revert"),
            [0x446] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_award_level_complete_achievements"),
            [0x447] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_is_cooperative"),
            [0x448] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_is_playtest"),
            [0x449] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_can_use_flashlights")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x44A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_and_quit"),
            [0x44B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_unsafe"),
            [0x44C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_insertion_point_unlock")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x44D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_insertion_point_lock")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x44E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_insertion_point_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x44F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_games_delete_campaign_save")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x450] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_games_autosave_free_up_space"),
            //[0x451] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievement_grant_to_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            [0x452] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievement_grant_to_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x453] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievement_grant_to_all_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x454] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievements_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x455] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievements_skip_validation_checks")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x456] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_influencers")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x457] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_respawn_zones")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x458] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_proximity_forbid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x459] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_moving_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x45A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_weapon_influences")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x45B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_dangerous_projectiles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x45C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_deployed_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x45D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_proximity_enemy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x45E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_teammates")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x45F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_dead_teammates")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x460] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_random_influence")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x461] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_nominal_weight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x462] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_natural_weight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x463] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x464] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_use_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x465] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_initial_spawn_point_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x466] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_respawn_point_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x467] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_export_variant_settings")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x468] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_general")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x469] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_flavor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x46A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load"),
            [0x46B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x46C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_save"),
            [0x46D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_save_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x46E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load_game"),
            [0x46F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load_game_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x470] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_regular_upload_to_debug_server")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x471] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_set_upload_option")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x472] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_force_immediate_save_on_core_load")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x473] = new ScriptInfo(HsType.HaloOnlineValue.Void, "force_debugger_not_present")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x474] = new ScriptInfo(HsType.HaloOnlineValue.Void, "force_debugger_always_present")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x475] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_safe_to_save"),
            [0x476] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_safe_to_speak"),
            [0x477] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_all_quiet"),
            [0x478] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save"),
            [0x479] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_cancel"),
            [0x47A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_no_timeout"),
            [0x47B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_immediate"),
            [0x47C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_saving"),
            [0x47D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_reverted"),
            [0x47E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_respawn_dead_players"),
            [0x47F] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_lives_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x480] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_lives_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x481] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_mp_round_count"),
            [0x482] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_mp_round_current"),
            [0x483] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_set_get"),
            [0x484] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_round_get"),
            [0x485] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_waves_per_round"),
            [0x486] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_rounds_per_set"),
            [0x487] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_wave_get"),
            [0x488] = new ScriptInfo(HsType.HaloOnlineValue.Real, "survival_mode_set_multiplier_get"),
            [0x489] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_set_multiplier_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x48A] = new ScriptInfo(HsType.HaloOnlineValue.Real, "survival_mode_bonus_multiplier_get"),
            [0x48B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_bonus_multiplier_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x48C] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_wave_squad"),
            [0x48D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_current_wave_is_initial"),
            [0x48E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_current_wave_is_boss"),
            [0x48F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_current_wave_is_bonus"),
            [0x490] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_current_wave_is_last_in_set"),
            [0x491] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_begin_new_set"),
            [0x492] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_begin_new_wave"),
            [0x493] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_end_set"),
            [0x494] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_end_wave"),
            [0x495] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_award_hero_medal"),
            [0x496] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_incident_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x497] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_bonus_round_show_timer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x498] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_bonus_round_start_timer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x499] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_bonus_round_set_timer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x49A] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_time_limit"),
            [0x49B] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_set_count"),
            [0x49C] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_bonus_lives_awarded"),
            [0x49D] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_bonus_target"),
            [0x49E] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_shared_team_life_count"),
            [0x49F] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_elite_life_count"),
            [0x4A0] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_max_lives"),
            [0x4A1] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_generator_count"),
            [0x4A2] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_bonus_lives_elite_death"),
            [0x4A3] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_scenario_extras_enable"),
            [0x4A4] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_weapon_drops_enable"),
            [0x4A5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_ammo_crates_enable"),
            [0x4A6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_generator_defend_all"),
            [0x4A7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_generator_random_spawn"),
            [0x4A8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_current_wave_uses_dropship"),
            [0x4A9] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_get_current_wave_time_limit"),
            [0x4AA] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_get_respawn_time_seconds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x4AB] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "survival_mode_team_respawns_on_wave")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x4AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_sudden_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x4AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_increment_human_score")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x4AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_increment_elite_score")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x4AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_set_spartan_license_plate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_set_elite_license_plate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4B1] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_player_count_by_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x4B2] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "survival_mode_players_by_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x4B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x4B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_cinematic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_with_subtitle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4B9] = new ScriptInfo(HsType.HaloOnlineValue.Long, "sound_impulse_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x4BA] = new ScriptInfo(HsType.HaloOnlineValue.Long, "sound_impulse_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4BB] = new ScriptInfo(HsType.HaloOnlineValue.Long, "sound_impulse_language_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x4BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x4BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_3d")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_mark_as_outro")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x4BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_naked")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_preload_dialogue_sounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
            },
            [0x4C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_start_with_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_resume")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
            },
            [0x4C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_stop_immediately")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
            },
            [0x4C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_set_scale")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_set_alternate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_activate_layer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_deactivate_layer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_loop_spam"),
            [0x4CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_show_channel")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_debug_sound_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sounds_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_set_gain")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_set_gain_db")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_enable_ducker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_environment_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_start_global_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_start_global_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_stop_global_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_enable_acoustic_palette")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_disable_acoustic_palette")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_force_alternate_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_auto_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_hover")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4DB] = new ScriptInfo(HsType.HaloOnlineValue.Long, "vehicle_count_bipeds_killed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x4DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "biped_ragdoll")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x4DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "water_float_reset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x4DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_show_training_text")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_set_training_text")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_enable_training")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_night_vision"),
            [0x4E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_crouch"),
            [0x4E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_stealth"),
            [0x4E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_equipment"),
            [0x4E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_jump"),
            [0x4E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_reset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x4E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_texture_cam")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_weapon_stats")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_crosshair")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_grenades")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_messages")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_motion_sensor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_cinematics")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x4F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_weapon_stats_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x4F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_crosshair_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x4F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_shield_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x4F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_grenades_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x4F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_messages_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x4F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_motion_sensor_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x4F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_chapter_title_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x4F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_cinematics_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            [0x4F8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_cinematic_fade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_object_with_priority")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_object_with_priority")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x4FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_flag_with_priority")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_flag_with_priority")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            //[0x4FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_object_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            //},
            //[0x500] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_object_for_player_with_priority")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x501] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_object_for_player_with_priority")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            //[0x502] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_flag_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            //},
            //[0x503] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_flag_for_player_with_priority")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x504] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_flag_for_player_with_priority")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            [0x505] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_object_set_vertical_offset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x506] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_track_flag_set_vertical_offset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x507] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_post_message_HACK")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            //[0x508] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_post_message")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            //[0x509] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_post_medal")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            //[0x50A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_set_static_hs_variable")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x50B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_set_countdown_hs_variable")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x50C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_set_countup_hs_variable")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x50D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_clear_hs_variable")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            //[0x50E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_get_hs_variable")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x50F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_arbiter_ai_navpoint")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x510] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_screen_objective")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x511] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_screen_chapter_title")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            //[0x512] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_screen_training")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            [0x513] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cls"),
            [0x514] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_spam_suppression_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x515] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x516] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_hide")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x517] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_show_all"),
            [0x518] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_hide_all"),
            [0x519] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_list"),
            [0x51A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_translation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x51B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x51C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rumble")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x51D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x51E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            //[0x51F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_translation_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x520] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rotation_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x521] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rumble_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x522] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_start_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x523] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_stop_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            [0x524] = new ScriptInfo(HsType.HaloOnlineValue.Void, "time_code_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x525] = new ScriptInfo(HsType.HaloOnlineValue.Void, "time_code_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x526] = new ScriptInfo(HsType.HaloOnlineValue.Void, "time_code_reset"),
            [0x527] = new ScriptInfo(HsType.HaloOnlineValue.Void, "script_screen_effect_set_value")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x528] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x529] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_set_crossfade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x52A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_set_crossfade2")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x52B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_stop"),
            [0x52C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_near_clip_distance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x52D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_far_clip_distance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x52E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_atmosphere_fog")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x52F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "motion_blur")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x530] = new ScriptInfo(HsType.HaloOnlineValue.Void, "antialias_blur")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x531] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_weather")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x532] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_patchy_fog")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x533] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_ssao")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x534] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_disable_vsync")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x535] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "motion_blur_enabled"),
            [0x536] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_environment_map_attenuation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x537] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_environment_map_bitmap")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Bitmap),
            },
            [0x538] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_reset_environment_map_bitmap"),
            [0x539] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_environment_map_tint")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x53A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_reset_environment_map_tint"),
            [0x53B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_layer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x53C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_has_skills"),
            [0x53D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_has_mad_secret_skills")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x53E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_invert_look"),
            [0x53F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_look_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            //[0x540] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_invert_look")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x541] = new ScriptInfo(HsType.HaloOnlineValue.Long, "user_interface_controller_get_last_level_played")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x542] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_look_inverted")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x543] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_vibration_enabled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x544] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_flight_stick_aircraft_controls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x545] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_auto_center_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x546] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_crouch_lock")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x547] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_southpaw")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x548] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_clench_protection")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x549] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_button_preset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ButtonPreset),
            },
            [0x54A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_custom_button")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x54B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_joystick_preset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.JoystickPreset),
            },
            [0x54C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_look_sensitivity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x54D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_unlock_single_player_levels")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x54E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_lock_single_player_levels")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x54F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_unlock_skulls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x550] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_lock_skulls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x551] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_unlock_models")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x552] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_lock_models")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x553] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_single_player_level_completed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.GameDifficulty),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x554] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_primary_change_color")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.playercolor),
            //},
            //[0x555] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_secondary_change_color")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.playercolor),
            //},
            //[0x556] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_tertiary_change_color")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.playercolor),
            //},
            //[0x557] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_primary_emblem_color")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.playercolor),
            //},
            //[0x558] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_secondary_emblem_color")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.playercolor),
            //},
            //[0x559] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_background_emblem_color")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.playercolor),
            //},
            //[0x55A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_player_character_type")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.playermodelchoice),
            //},
            [0x55B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_emblem_info")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x55C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_voice_output_setting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.VoiceOutputSetting),
            },
            [0x55D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_subtitle_setting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.SubtitleSetting),
            },
            [0x55E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_nag_message_data")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x55F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_temporary_users_always_attached")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x560] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_new_user_experience")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x561] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_initial_bonus_toast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x562] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_loyalty_bonus_toast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x563] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_generic_bonus_toast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x564] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_unsignedin_user")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x565] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_display_storage_device_selection")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x566] = new ScriptInfo(HsType.HaloOnlineValue.Void, "font_cache_bitmap_save")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x567] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_load_main_menu"),
            [0x568] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_text_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x569] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_text_font")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x56A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_show_title_safe_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x56B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_element_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x56C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_memory_dump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x56D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_time_scale_step")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x56E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "xoverlapped_debug_render")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x56F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "shader_compile_target_platform")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x570] = new ScriptInfo(HsType.HaloOnlineValue.Void, "shader_compile_shader_pipeline")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x571] = new ScriptInfo(HsType.HaloOnlineValue.Void, "shader_compile_filter_shader_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x572] = new ScriptInfo(HsType.HaloOnlineValue.Void, "shader_compile_filter_category_option")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x573] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_load_screen")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x574] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_reset"),
            [0x575] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_start"),
            [0x576] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_stop"),
            [0x577] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_post")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x578] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_post_toast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x579] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_resolve")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x57A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_clear")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x57B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_dialog_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x57C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_music_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x57D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cc_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x57E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cc_test")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x57F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_clear"),
            [0x580] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_show_up_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x581] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_finish_up_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x582] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x583] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_finish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x584] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_unavailable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x585] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x586] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_finish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x587] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_unavailable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x588] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_set_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x589] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_set_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x58A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_show_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x58B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_finish_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x58C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_unavailable_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x58D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_show_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x58E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_finish_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x58F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_unavailable_string")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x590] = new ScriptInfo(HsType.HaloOnlineValue.Void, "input_suppress_rumble")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x591] = new ScriptInfo(HsType.HaloOnlineValue.Void, "input_disable_claw_button_combos")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x592] = new ScriptInfo(HsType.HaloOnlineValue.Void, "update_remote_camera"),
            [0x593] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_build_network_config"),
            [0x594] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_build_game_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x595] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_verify_game_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x596] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_load_and_use_game_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x597] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_use_hopper_directory")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x598] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_lsp_dump_services_and_servers"),
            [0x599] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_lsp_force_server")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x59A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_lsp_disable_server")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x59B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_lsp_disable_service")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x59C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_dump"),
            [0x59D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_clear"),
            [0x59E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_connection_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x59F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_squad_host_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_squad_client_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_squad_speculative_migration_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_squad_bridging_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_group_host_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_group_client_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_group_speculative_migration_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_group_bridging_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_friend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_squad_to_friend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_sessionid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_squad_to_sessionid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_enable_join_friend_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_set_maximum_player_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_status_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_ping"),
            [0x5AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_channel_delete"),
            [0x5B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_delegate_host")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_delegate_leader")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_map_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x5B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_campaign_difficulty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x5B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_player_color")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_reset_objects"),
            [0x5B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_fatal_error"),
            [0x5B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_set_machine_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_enabled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_suppression")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_suppress_display")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_global_display")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_global_log")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_global_debugger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_global_datamine")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_category_display")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_category_force_display")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_category_log")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_category_debugger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_category_debugger_break")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_category_halt")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_category_datamine")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_dump_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_logs_snapshot"),
            [0x5C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_disable_suppression")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_global_display_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_global_log_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_global_remote_log_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_display_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_force_display_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_debugger_break_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_halt_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x5D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_list_categories")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_suppress_console_display")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_bink_movie")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_bink_movie_from_tag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.BinkDefinition),
            },
            [0x5D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_credits"),
            [0x5D6] = new ScriptInfo(HsType.HaloOnlineValue.Long, "bink_time"),
            [0x5D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_global_doppler_factor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_global_mixbin_headroom")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_environment_source_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_set_mission_segment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_insert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_upload"),
            [0x5DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_flush"),
            [0x5DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_debug_menu_setting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_open_debug_menu"),
            [0x5E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_set_display_mission_segment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_set_header_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_memory_allocators")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_memory_allocators")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "display_video_standard"),
            [0x5E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_xcr_monkey_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_show_guide_status"),
            [0x5E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_show_users_xuids"),
            [0x5E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_show_are_users_friends")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_invite_friend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_get_squad_session_id"),
            [0x5EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_get_active_screens")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_get_screen_components")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_get_component_properties")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x5EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_send_button_press")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_invoke_list_item_by_string_id")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x5F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_invoke_list_item_by_long")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_invoke_list_item_by_boolean")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_invoke_list_item_by_text")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_download_storage_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_game_results_save_to_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_game_results_load_from_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_game_results_make_random"),
            [0x5F8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_fragment_utility_drive")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "clear_webcache"),
            [0x5FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "online_files_upload")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "online_files_throttle_bandwidth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "online_marketplace_refresh"),
            [0x5FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_test_submit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_test_submit_random_realistic"),
            [0x600] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_throttle_bandwidth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x601] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_log_uploads")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x602] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flag_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x603] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flag_new_at_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x604] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_clear"),
            [0x605] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_default_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x606] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_default_comment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x607] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_set_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x608] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bug_now")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x609] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bug_now_lite")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x60A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bug_now_auto")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x60B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bug_now_on_next_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x60C] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "object_list_children")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x60D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_outgoing_channel_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x60E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_voice_repeater_peer_index")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x60F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_mute")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x610] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_hopper")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x611] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_global_unarbitrated")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x612] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_refresh"),
            [0x613] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_selected_actor_jump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x614] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_loaded_tags"),
            [0x615] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x616] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x617] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_stop_all"),
            [0x618] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_dump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x619] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_dump_all"),
            [0x61A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_pc_runtime_language")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x61B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_cache_stats_reset"),
            [0x61C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_clone_players_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x61D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_move_attached_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x61E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_enable_ghost_effects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x61F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_global_sound_environment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x620] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reset_dsp_image"),
            [0x621] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_cinematic_skip"),
            [0x622] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_outro_start"),
            [0x623] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_enable_ambience_details")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x624] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x625] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_reset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x626] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_blur_amount")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x627] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_threshold")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x628] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_brightness")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x629] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_box_factor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x62A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_max_factor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x62B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_silver_bullet")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x62C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_only")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x62D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_high_res")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x62E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_brightness_alpha")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x62F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_max_factor_alpha")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x630] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cache_block_for_one_frame"),
            [0x631] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_suppress_ambience_update_on_revert"),
            [0x632] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_autoexposure_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x633] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_full")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x634] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_fade_in")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x635] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_fade_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x636] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x637] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_autoexposure_instant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x638] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_set_environment_darken")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x639] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_depth_of_field_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x63A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_depth_of_field")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x63B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_dof_focus_depth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x63C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_dof_blur_animate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x63D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_video_mode"),
            [0x63E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lightmap_shadow_disable"),
            [0x63F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lightmap_shadow_enable"),
            [0x640] = new ScriptInfo(HsType.HaloOnlineValue.Void, "predict_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x641] = new ScriptInfo(HsType.HaloOnlineValue.Long, "mp_player_count_by_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x642] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "mp_players_by_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x643] = new ScriptInfo(HsType.HaloOnlineValue.Long, "mp_active_player_count_by_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x644] = new ScriptInfo(HsType.HaloOnlineValue.Void, "deterministic_end_game"),
            [0x645] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_game_won")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x646] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_respawn_override_timers")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x647] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_ai_allegiance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x648] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_allegiance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x649] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mp_round_started"),
            //[0x64A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_round_end_with_winning_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x64B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_round_end_with_winning_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x64C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_round_end"),
            [0x64D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_scripts_reset"),
            [0x64E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_file_set_backend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x64F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_debug_goal_object_boundary_geometry")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x650] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_dump_candy_monitor_state"),
            [0x651] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_logging")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x652] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_set_trace_flags")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x653] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_game_state_checksum")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x654] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_trace")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x655] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_set_consumer_sample_level")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x656] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_log_compare_log_files")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x657] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_log_file_comparision_on_oos")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x658] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_play")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x659] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_play_last"),
            [0x65A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_disable_version_checking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x65B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_toggle_debug_saving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x65C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_films_show_timestamp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x65D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mover_set_program")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x65E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "floating_point_exceptions_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x65F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_reload_force")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x660] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_unload_force")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x661] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_load_force")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x662] = new ScriptInfo(HsType.HaloOnlineValue.Void, "predict_bink_movie")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x663] = new ScriptInfo(HsType.HaloOnlineValue.Void, "predict_bink_movie_from_tag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.BinkDefinition),
            },
            [0x664] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_dump_history"),
            [0x665] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x666] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_flying_cam_at_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x667] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x668] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_orbiting_cam_at_target_relative_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x669] = new ScriptInfo(HsType.HaloOnlineValue.Void, "director_cycle_debug_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x66A] = new ScriptInfo(HsType.HaloOnlineValue.Long, "game_coop_player_count"),
            [0x66B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_force_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x66C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_output_pulse"),
            [0x66D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "string_id_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x66E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "find")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x66F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "add_recycling_volume")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x670] = new ScriptInfo(HsType.HaloOnlineValue.Void, "add_recycling_volume_by_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x671] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_set_per_frame_publish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x672] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_recycling_clear_history"),
            [0x673] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_cinematics_script"),
            [0x674] = new ScriptInfo(HsType.HaloOnlineValue.Void, "global_preferences_clear"),
            [0x675] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_storage_set_storage_subdirectory")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x676] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_storage_set_storage_user")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x677] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_storage_run_locally")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x678] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status_line_dump"),
            [0x679] = new ScriptInfo(HsType.HaloOnlineValue.Long, "game_tick_get"),
            [0x67A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "loop_it")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x67B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "loop_clear"),
            [0x67C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status_lines_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x67D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status_lines_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x67E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "on_target_platform"),
            [0x67F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "f7_profiler_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x680] = new ScriptInfo(HsType.HaloOnlineValue.Void, "f7_profiler_substring_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x681] = new ScriptInfo(HsType.HaloOnlineValue.Void, "f7_profiler_substring_deactivate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x682] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_game_set_player_standing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x683] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_get_game_id"),
            [0x684] = new ScriptInfo(HsType.HaloOnlineValue.Void, "generate_rsa_2048_key_pair"),
            [0x685] = new ScriptInfo(HsType.HaloOnlineValue.Void, "create_secure_test_file"),
            [0x686] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_hopper_list"),
            [0x687] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_hopper_game_list"),
            [0x688] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_hopper_set_game")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x689] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_set_voting_system")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x68A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_set_arena_season")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x68B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_suppress_arena_popup")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x68C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_test_arena_screen")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x68D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_set_arena_stats")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x68E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_set_playback_game_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x68F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "noguchis_mystery_tour")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x690] = new ScriptInfo(HsType.HaloOnlineValue.Void, "designer_zone_sync"),
            [0x691] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_designer_zone")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DesignerZone),
            },
            [0x692] = new ScriptInfo(HsType.HaloOnlineValue.Void, "designer_zone_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DesignerZone),
            },
            [0x693] = new ScriptInfo(HsType.HaloOnlineValue.Void, "designer_zone_deactivate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DesignerZone),
            },
            [0x694] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_always_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x695] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_seek_to_film_tick")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x696] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_seek_to_film_timestamp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x697] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "tag_is_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTagNotResolving),
            },
            [0x698] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_set_incremental_publish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x699] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_enable_optional_caching")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x69A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_active_resources"),
            [0x69B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_persistent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x69C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "display_zone_size_estimates")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x69D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "report_zone_size_estimates"),
            [0x69E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_disconnect_squad"),
            [0x69F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_disconnect_group"),
            [0x6A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_clear_squad_session_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_clear_group_session_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_life_cycle_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_life_cycle_display_states"),
            [0x6A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_life_cycle_abort_matchmaking"),
            [0x6A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "overlapped_display_task_descriptions"),
            [0x6A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "overlapped_task_inject_error")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_hopper_all_users")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_global_unarbitrated_all_users")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unknown6A9"),
            [0x6AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_hopper_all_users")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_global_unarbitrated_all_users")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_sapien_crash"),
            [0x6AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "decorators_split")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x6AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bandwidth_profiler_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bandwidth_profiler_set_context")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_enabled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_object_names")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_machine_filter"),
            [0x6B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_priority_scope_tick"),
            [0x6B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_priority_scope_second_worst"),
            [0x6B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_priority_scope_second_best"),
            [0x6B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_color_by_relevance"),
            [0x6B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_color_by_update_period"),
            [0x6B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_priority_display_set_color_by_final_priority"),
            [0x6B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "overlapped_task_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_set_controller_cheat_flags")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_set_controller_ban_flags")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_dump_strings"),
            [0x6BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_dump_repeated_play_list"),
            [0x6BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_set_locality_override")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_set_user_stats")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_set_user_game_stats")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_build_map_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_verify_map_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_load_and_use_map_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "write_current_map_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "read_map_variant_and_make_current")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "async_set_thread_work_delay_milliseconds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_set_demand_throttle_to_io")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_flush_optional"),
            [0x6C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_performance_throttle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x6CA] = new ScriptInfo(HsType.HaloOnlineValue.Real, "get_performance_throttle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_headset_boost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x6CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_deactivate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_activate_from_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x6CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_deactivate_from_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x6D0] = new ScriptInfo(HsType.HaloOnlineValue.Long, "tiling_current"),
            [0x6D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_limit_lipsync_to_mouth_only")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_active_zone_tags"),
            [0x6D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "calculate_tag_prediction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x6D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_enable_fast_prediction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6D5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_start_first_person_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6D6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_is_playing_custom_first_person_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x6D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_stop_first_person_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x6D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "prepare_to_switch_to_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ZoneSet),
            },
            [0x6D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_activate_for_debugging")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_play_random_ping")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x6DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_fade_out_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x6DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_fade_in_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            //[0x6DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_lock_gaze")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            //[0x6DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_unlock_gaze")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x6DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_scale_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x6E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "run_like_dvd"),
            [0x6E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_auto_core_save")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "run_no_hdd"),
            [0x6E3] = new ScriptInfo(HsType.HaloOnlineValue.BinkDefinition, "cinematic_tag_reference_get_bink")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_force_match_configurations")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_force_hud")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_custom_animation_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x6E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_at_frame_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x6E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_set_repro_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "font_set_emergency"),
            [0x6EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "biped_force_ground_fitting_on")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_chud_objective")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
            },
            //[0x6EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_cinematic_title")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
            //},
            [0x6ED] = new ScriptInfo(HsType.HaloOnlineValue.Weapon, "unit_get_primary_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x6EE] = new ScriptInfo(HsType.HaloOnlineValue.AnimationGraph, "budget_resource_get_animation_graph")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationBudgetReference),
            },
            [0x6EF] = new ScriptInfo(HsType.HaloOnlineValue.LoopingSound, "budget_resource_get_looping_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSoundBudgetReference),
            },
            [0x6F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_safe_to_respawn")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x6F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_safe_to_respawn")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x6F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_item_slayer"),
            [0x6F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_item_screenshot"),
            [0x6F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_blf_screenshot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_blf_film")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_blf_film_clip")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_blf_game_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6F8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_blf_map_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x6F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_migrate_infanty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x6FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_cinematic_motion_blur")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dont_do_avoidance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_clean_up")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x6FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_erase_inactive")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x6FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_survival_cleanup")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_enable_stuck_flying_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x700] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_stuck_velocity_threshold")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x701] = new ScriptInfo(HsType.HaloOnlineValue.Void, "stop_bink_movie"),
            [0x702] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_credits_unskippable"),
            [0x703] = new ScriptInfo(HsType.HaloOnlineValue.Sound, "budget_resource_get_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.SoundBudgetReference),
            },
            [0x704] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_single_player_level_unlocked")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x705] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physical_memory_dump"),
            [0x706] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_validate_all_pages")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x707] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_debug_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x708] = new ScriptInfo(HsType.HaloOnlineValue.Object, "cinematic_scripting_get_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x709] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_override_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x70A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_stance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x70B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_stance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x70C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x70D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_effect_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x70E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_3d_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x70F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_start_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x710] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_channels_log_start"),
            [0x711] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_channels_log_start_named")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x712] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_channels_log_stop"),
            [0x713] = new ScriptInfo(HsType.HaloOnlineValue.Void, "simulation_profiler_enable"),
            [0x714] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_insert_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x715] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_seek_to_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x716] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_currency_issue_award_to_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x717] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unknown717")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x718] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unknown718")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x719] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_simulation_set_stream_bandwidth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x71A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_fadeout_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x71B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_model_marker_name_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            //[0x71C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "skull_enable")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.skull),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            //},
            [0x71D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "allow_object_to_be_lased")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x71E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "is_object_being_lased")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x71F] = new ScriptInfo(HsType.HaloOnlineValue.Long, "simulation_profiler_detail_level")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x720] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "simulation_profiler_enable_downstream_processing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x721] = new ScriptInfo(HsType.HaloOnlineValue.Long, "campaign_metagame_get_player_score")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x722] = new ScriptInfo(HsType.HaloOnlineValue.Void, "collision_debug_lightmaps_print"),
            [0x723] = new ScriptInfo(HsType.HaloOnlineValue.Void, "load_binary_game_engine")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x724] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_storage_files_display_file_names"),
            [0x725] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_storage_files_force_download")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x726] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_lightmap_inspect"),
            [0x727] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_colorbars")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x728] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_force_global_repeater_use")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x729] = new ScriptInfo(HsType.HaloOnlineValue.Void, "levels_add_campaign_map_with_id")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x72A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "levels_add_campaign_map")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x72B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "levels_add_multiplayer_map")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x72C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unknown72C"),
            [0x72D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "clear_map_slot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x72E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "clear_map_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x72F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_team_picker_unit_test"),
            [0x730] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_objects_unit_seats_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x731] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_lock_enforcement")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x732] = new ScriptInfo(HsType.HaloOnlineValue.Void, "lsp_presence_dump_blfs")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x733] = new ScriptInfo(HsType.HaloOnlineValue.Void, "lsp_leaderboard_dump_blfs")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x734] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_flush"),
            [0x735] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_profile_write"),
            [0x736] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_lsp_sync"),
            [0x737] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_force_unlock_all_purchasable_items"),
            [0x738] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_grant_to_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            //[0x739] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_grant_to_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            //},
            [0x73A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_commendation_increment_for_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            //[0x73B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_commendation_increment_for_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            [0x73C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_commendation_set_for_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x73D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_purchase")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x73E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_set_player_appearance_from_purchase")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x73F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_dump"),
            [0x740] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_reinitialize_from_storage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x741] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rewards_reset_to_default_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x742] = new ScriptInfo(HsType.HaloOnlineValue.Long, "rewards_get_total")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x743] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unknown743")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x744] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenges_enable_lsp_synchronization")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x745] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenges_clear"),
            [0x746] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenges_activate_challenge")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x747] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenges_list_active_challenges_for_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x748] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenge_advance_for_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x749] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenge_complete_for_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x74A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenge_advance_for_controller_by_indices")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x74B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "challenge_complete_for_controller_by_indices")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x74C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_set_screen_name_override_prefix")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            //[0x74D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_load_screen")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.cuiscreendefinition),
            //},
            //[0x74E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_load_themed_screen")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.cuiscreendefinition),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //},
            [0x74F] = new ScriptInfo(HsType.HaloOnlineValue.Long, "rewards_get_grade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x750] = new ScriptInfo(HsType.HaloOnlineValue.Long, "unknown750")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x751] = new ScriptInfo(HsType.HaloOnlineValue.Void, "exit_experience_set_params")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x752] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_profile_clear_to_default_values")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x753] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            //[0x754] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident_with_cause_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x755] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident_with_cause_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            //[0x756] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident_with_cause_player_and_effect_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x757] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident_with_cause_player_and_effect_team")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            //},
            //[0x758] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident_with_cause_team_and_effect_player")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x759] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident_with_cause_team_and_effect_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x75A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "submit_incident_with_cause_campaign_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x75B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_set_campaign_insertion_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x75C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hs_make_interactive_scripts_deterministic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x75D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "threadlib_runtests"),
            //[0x75E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_respawn_vehicle")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            //},
            [0x75F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "teleport_players_into_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x760] = new ScriptInfo(HsType.HaloOnlineValue.Void, "content_test_set_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x761] = new ScriptInfo(HsType.HaloOnlineValue.Void, "content_test_set_active_test_pass")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x762] = new ScriptInfo(HsType.HaloOnlineValue.Void, "command_buffer_cache_playback_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            //[0x763] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_spartan_loadout")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            //[0x764] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_elite_loadout")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x765] = new ScriptInfo(HsType.HaloOnlineValue.Void, "auto_graph")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x766] = new ScriptInfo(HsType.HaloOnlineValue.Void, "auto_graph_reset"),
            [0x767] = new ScriptInfo(HsType.HaloOnlineValue.Void, "auto_graph_enable_list")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x768] = new ScriptInfo(HsType.HaloOnlineValue.Void, "auto_graph_filter_list")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x769] = new ScriptInfo(HsType.HaloOnlineValue.Void, "auto_graph_list"),
            [0x76A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "auto_graph_hide"),
            [0x76B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "location_names_print"),
            [0x76C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_force_host")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x76D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_force_host_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x76E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_force_host_posse")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x76F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_force_host_group")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x770] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sandbox_load_label_strings")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x771] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_dump_network_statistics"),
            [0x772] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_enable_block_detection")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x773] = new ScriptInfo(HsType.HaloOnlineValue.Void, "main_enable_block_detection")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x774] = new ScriptInfo(HsType.HaloOnlineValue.Void, "main_synchronous_networking_request_vblank_slip"),
            [0x775] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_button_action_mapping_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x776] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_appearance_force_model_area")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x777] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_appearance_force_model_area_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x778] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_instanced_geometry_names_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x779] = new ScriptInfo(HsType.HaloOnlineValue.Void, "stream_manager_load_core")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x77A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "stream_manager_save_cores")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x77B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_waypoint_flags")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x77C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "waypoint_set_unlock_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x77D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "async_test_hang")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x77E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_campaign"),
            [0x77F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_firefight"),
            [0x780] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_multiplayer"),
            [0x781] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_matchmaking"),
            [0x782] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_custom_games"),
            [0x783] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_solo"),
            [0x784] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_coop"),
            [0x785] = new ScriptInfo(HsType.HaloOnlineValue.Void, "incidents_force_four_player_coop"),
            [0x786] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_sound_stress_test_message_queue"),
            [0x787] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_log_channel_message_queue_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x788] = new ScriptInfo(HsType.HaloOnlineValue.Void, "global_preferences_set_campaign_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x789] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_load_machine_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x78A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "lightmap_memory_inspect"),
            [0x78B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_set_random_holiday"),
            [0x78C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "airstrike_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x78D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "airstrike_weapons_exist"),
            [0x78E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "airstrike_set_launches")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x78F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_add_global_property_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x790] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_add_property_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x791] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_remove_global_property_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x792] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_remove_property_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x793] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_clear_global_property_watches"),
            [0x794] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_clear_property_watches"),
            [0x795] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_add_global_binding_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x796] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_add_binding_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x797] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_remove_global_binding_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x798] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_remove_binding_watch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x799] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_clear_global_binding_watches"),
            [0x79A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_clear_binding_watches"),
            [0x79B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_clear_global"),
            [0x79C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cui_debug_clear"),
            //[0x79D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_record_custom_penalty")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            //},
            [0x79E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_reset"),
            [0x79F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_force_social_matchmaking"),
            [0x7A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_force_ranked_matchmaking"),
            [0x7A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_ranked_matchmaking_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_social_matchmaking_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_custom_game_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_objects_in_sphere_radius")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_ai_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_enemy_ai_nearby_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_enemy_player_nearby_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_same_squad_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_shield_damage_base_penalty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_body_damage_base_penalty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_betrayal_base_penalty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_betrayal_boot_cutoff")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_ejection_cutoff")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_betrayal_decay_seconds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_grief_set_eject_decay_seconds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x7B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_disconnect_and_reconnect_all_channels"),
            [0x7B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_profile")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StartingProfile),
            },
            //[0x7B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_profile")
            //{
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StartingProfile),
            //    new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.player),
            //},
            [0x7B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "security_run_unit_tests"),
            [0x7B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_session_security_set_challenge_response")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x7B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_session_security_set_challenge_failure_on_timeout")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x7B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_session_security_set_challenge_force_fail")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x7B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_session_security_disable_challenges")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x7B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_player_appearance_encode_for_sneakernet"),
            [0x7B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_player_appearance_decode_from_sneakernet")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x7BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_content_resize_cache")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x7BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "motl_dump_bitvector_for_scenario"),
            [0x7BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "motl_verify_mapinfo_for_scenario"),
        };
    }
}
