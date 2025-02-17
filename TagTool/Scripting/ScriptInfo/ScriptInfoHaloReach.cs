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
            [0xF9] = "debug_object_scheduler",
            [0xFA] = "render_debug_turn_on_cache_state",
            [0xFB] = "debug_use_black_for_missing_instances",
            [0xFC] = "render_environment",
            [0xFD] = "render_structure",
            [0xFE] = "render_per_vertex_lit_environment",
            [0xFF] = "render_per_pixel_lit_enviroment",
            [0x100] = "render_single_probe_lit_environment",
            [0x101] = "render_cluster_enabled",
            [0x102] = "render_objects",
            [0x103] = "render_lightmap_shadows",
            [0x104] = "render_rain",
            [0x105] = "render_rain_particles",
            [0x106] = "render_light_volume_rain_particles",
            [0x107] = "render_light_volume_rain_sheets",
            [0x108] = "render_rain_from_design_tag",
            [0x109] = "render_rain_occluder_as_normal_object",
            [0x10A] = "render_debug_enable_first_person_squish",
            [0x10B] = "render_tessellated_mesh",
            [0x10C] = "render_lightmap_shadows_apply",
            [0x10D] = "render_lights",
            [0x10E] = "render_water_tessellated",
            [0x10F] = "render_water_wireframe",
            [0x110] = "render_water_interaction",
            [0x111] = "render_water",
            [0x112] = "render_water_refraction",
            [0x113] = "render_debug_occlusion_bsp_index",
            [0x114] = "render_debug_occlusion_instance_index",
            [0x115] = "render_tessellated_wireframe",
            [0x116] = "render_first_person",
            [0x117] = "render_debug_mode",
            [0x118] = "render_debug_safe_frame_bounds",
            [0x119] = "render_debug_aspect_ratio_scale",
            [0x11A] = "render_debug_force_4x3_aspect_ratio",
            [0x11B] = "render_debug_transparents",
            [0x11C] = "render_debug_slow_transparents",
            [0x11D] = "render_transparents",
            [0x11E] = "render_low_res_transparents",
            [0x11F] = "render_debug_transparent_cull",
            [0x120] = "render_debug_transparent_cull_flip",
            [0x121] = "render_debug_transparent_sort_method",
            [0x122] = "render_debug_lens_flares",
            [0x123] = "render_debug_shield_instrumentation",
            [0x124] = "render_instanced_geometry",
            [0x125] = "render_sky",
            [0x126] = "render_lens_flares",
            [0x127] = "render_decals",
            [0x128] = "neuticle_render",
            [0x129] = "neuticle_update",
            [0x12A] = "neuticle_spawn",
            [0x12B] = "render_decorators",
            [0x12C] = "render_infinite_decorators",
            [0x12D] = "render_decorators_lod_mask",
            [0x12E] = "render_decorators_decimation_test",
            [0x12F] = "light_decorators",
            [0x130] = "render_decorator_bounds",
            [0x131] = "render_decorator_spheres",
            [0x132] = "render_decorator_descriptions",
            [0x133] = "render_debug_force_cinematic_lights",
            [0x134] = "render_debug_pix_events",
            [0x135] = "render_atmosphere_cluster_blend_data",
            [0x136] = "render_debug_display_command_buffer_data",
            [0x137] = "render_cloud_texture",
            [0x138] = "render_debug_enable_z_prepass",
            [0x139] = "render_debug_instance_occlusion",
            [0x13A] = "render_debug_screen_shaders",
            [0x13B] = "render_debug_screen_effects",
            [0x13C] = "render_screen_effects",
            [0x13D] = "render_debug_acoustic_sectors",
            [0x13E] = "render_debug_weather_dumplings",
            [0x13F] = "render_debug_atmosphere_dumplings",
            [0x140] = "render_debug_min_single_pass_rendering_distance",
            [0x141] = "render_pc_specular",
            [0x142] = "render_pc_albedo_lighting",
            [0x143] = "render_debug_save_surface",
            [0x144] = "render_screen_flashes",
            [0x145] = "texture_camera_near_plane",
            [0x146] = "texture_camera_exposure",
            [0x147] = "texture_camera_illum_scale",
            [0x148] = "render_near_clip_distance",
            [0x149] = "render_far_clip_distance",
            [0x14A] = "render_exposure_stops",
            [0x14B] = "display_exposure",
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
            [0x15E] = "render_shadow_bounds",
            [0x15F] = "render_shadow_bounds_solid",
            [0x160] = "render_shadow_opaque",
            [0x161] = "render_shadow_screenspace",
            [0x162] = "render_shadow_histencil",
            [0x163] = "render_shadow_hires",
            [0x164] = "render_shadow_objectspace_stencil_clip",
            [0x165] = "render_shadow_force_fancy",
            [0x166] = "render_shadow_force_old",
            [0x167] = "render_postprocess",
            [0x168] = "render_accum",
            [0x169] = "render_bloom_source",
            [0x16A] = "render_bloom",
            [0x16B] = "render_downsample",
            [0x16C] = "render_show_alpha",
            [0x16D] = "render_postprocess_exposure",
            [0x16E] = "render_accum_filter",
            [0x16F] = "render_tone_curve",
            [0x170] = "render_tone_curve_white",
            [0x171] = "render_exposure_lock",
            [0x172] = "render_postprocess_hue",
            [0x173] = "render_postprocess_saturation",
            [0x174] = "render_postprocess_red_filter",
            [0x175] = "render_postprocess_green_filter",
            [0x176] = "render_postprocess_blue_filter",
            [0x177] = "render_screenspace_center",
            [0x178] = "render_bounce_light_intensity",
            [0x179] = "render_bounce_light_only",
            [0x17A] = "render_disable_prt",
            [0x17B] = "force_render_lightmap_mesh",
            [0x17C] = "render_use_single_pass_rendering",
            [0x17D] = "render_force_single_pass_rendering",
            [0x17E] = "render_debug_foliage_enable",
            [0x17F] = "render_debug_enable_pc_transparents",
            [0x180] = "screenshot_anisotropic_level",
            [0x181] = "screenshot_gamma",
            [0x182] = "render_light_intensity",
            [0x183] = "render_light_clip_planes",
            [0x184] = "render_light_opaque",
            [0x185] = "cubemap_debug",
            [0x186] = "render_debug_cloth",
            [0x187] = "render_debug_antennas",
            [0x188] = "render_debug_leaf_systems",
            [0x189] = "render_debug_object_lighting",
            [0x18A] = "render_debug_object_lighting_refresh",
            [0x18B] = "render_debug_use_cholocate_mountain",
            [0x18C] = "render_debug_use_contrast_adjustment",
            [0x18D] = "render_debug_use_min_luminance",
            [0x18E] = "render_debug_use_bounce_to_ambient",
            [0x18F] = "render_debug_object_lighting_use_scenery_probe",
            [0x190] = "render_debug_object_lighting_use_device_probe",
            [0x191] = "render_debug_object_lighting_use_air_probe",
            [0x192] = "render_debug_show_air_probes",
            [0x193] = "render_debug_infinite_framerate",
            [0x194] = "render_debug_toggle_default_lightmaps_texaccum",
            [0x195] = "render_debug_object_lighting_interpolation_difference_factor",
            [0x196] = "render_debug_depth_render",
            [0x197] = "render_debug_depth_render_scale_r",
            [0x198] = "render_debug_depth_render_scale_g",
            [0x199] = "render_debug_depth_render_scale_b",
            [0x19A] = "render_debug_show_4x3_bounds",
            [0x19B] = "render_weather_bounds",
            [0x19C] = "render_debug_object_imposter",
            [0x19D] = "render_debug_object_imposter_always",
            [0x19E] = "render_debug_object_imposter_never",
            [0x19F] = "render_debug_instance_imposters",
            [0x1A0] = "render_debug_instance_imposter_always",
            [0x1A1] = "render_debug_instance_imposter_never",
            [0x1A2] = "render_debug_instance_imposter_hide_rainbows",
            [0x1A3] = "render_debug_enable_imposter_alpha_blend",
            [0x1A4] = "build_instance_imposters",
            [0x1A5] = "render_debug_cinematic_clip",
            [0x1A6] = "render_buffer_gamma",
            [0x1A7] = "render_screen_gamma",
            [0x1A8] = "render_buffer_gamma_curve",
            [0x1A9] = "render_color_balance_red",
            [0x1AA] = "render_color_balance_green",
            [0x1AB] = "render_color_balance_blue",
            [0x1AC] = "render_black_level_red",
            [0x1AD] = "render_black_level_green",
            [0x1AE] = "render_black_level_blue",
            [0x1AF] = "debug_volume_samples",
            [0x1B0] = "decal_create",
            [0x1B1] = "decal_frame_advance",
            [0x1B2] = "decal_render",
            [0x1B3] = "decal_render_preplaced",
            [0x1B4] = "decal_render_debug",
            [0x1B5] = "decal_render_debug_info",
            [0x1B6] = "decal_render_latest_debug",
            [0x1B7] = "decal_cull",
            [0x1B8] = "decal_fade",
            [0x1B9] = "decal_dump",
            [0x1BA] = "particle_create",
            [0x1BB] = "particle_frame_advance",
            [0x1BC] = "particle_render",
            [0x1BD] = "particle_render_debug",
            [0x1BE] = "particle_collision_debug",
            [0x1BF] = "particle_collision_debug_priority",
            [0x1C0] = "particle_render_debug_spheres",
            [0x1C1] = "particle_cull",
            [0x1C2] = "particle_dump",
            [0x1C3] = "particle_force_cpu",
            [0x1C4] = "particle_force_gpu",
            [0x1C5] = "effect_priority_cutoff",
            [0x1C6] = "render_debug_effect_text",
            [0x1C7] = "render_debug_effect_distance_from_camera",
            [0x1C8] = "render_debug_effect_name",
            [0x1C9] = "render_debug_effect_active_emitter_counts",
            [0x1CA] = "render_debug_effect_particle_counts",
            [0x1CB] = "render_debug_effect_light_volume_counts",
            [0x1CC] = "render_debug_effect_contrail_counts",
            [0x1CD] = "render_debug_effect_beam_counts",
            [0x1CE] = "render_debug_effect_bounding_speres",
            [0x1CF] = "render_debug_effect_emitter_shape",
            [0x1D0] = "render_debug_effect_toggle_particle_mode",
            [0x1D1] = "render_debug_effect_toggle_light_mode",
            [0x1D2] = "render_debug_effect_toggle_contrail_mode",
            [0x1D3] = "render_debug_effect_toggle_beam_mode",
            [0x1D4] = "weather_occlusion_max_height",
            [0x1D5] = "render_debug_viewport_scale",
            [0x1D6] = "render_debug_light_probes",
            [0x1D7] = "effect_property_culling",
            [0x1D8] = "contrail_create",
            [0x1D9] = "contrail_pulse",
            [0x1DA] = "contrail_frame_advance",
            [0x1DB] = "contrail_submit",
            [0x1DC] = "contrail_dump",
            [0x1DD] = "light_volume_create",
            [0x1DE] = "light_volume_frame_advance",
            [0x1DF] = "light_volume_submit",
            [0x1E0] = "light_volume_dump",
            [0x1E1] = "beam_create",
            [0x1E2] = "beam_frame_advance",
            [0x1E3] = "beam_submit",
            [0x1E4] = "beam_dump",
            [0x1E5] = "debug_pvs",
            [0x1E6] = "debug_pvs_render_all",
            [0x1E7] = "debug_pvs_activation",
            [0x1E8] = "pvs_building_disabled",
            [0x1E9] = "debug_pvs_editor_mode",
            [0x1EA] = "render_debug_full_bsp",
            [0x1EB] = "render_default_lighting",
            [0x1EC] = "render_debug_analytical_lightmap_light_enabled",
            [0x1ED] = "render_debug_vmf_lightmap_light_enabled",
            [0x1EE] = "render_debug_bounce_light_enabled",
            [0x1EF] = "visibility_debug_portals_2d",
            [0x1F0] = "visibility_debug_portals_2d_verbose",
            [0x1F1] = "visibility_debug_portals_3d",
            [0x1F2] = "visibility_debug_visible_cluster_portals_3d",
            [0x1F3] = "visibility_debug_all_portals_3d",
            [0x1F4] = "visibility_disable_conditional_portals",
            [0x1F5] = "visibility_debug_visible_clusters",
            [0x1F6] = "visibility_debug_portals_structure_bsp_index",
            [0x1F7] = "visibility_debug_portals_cluster_index",
            [0x1F8] = "visibility_debug_select_bsp_instance_visible",
            [0x1F9] = "visibility_debug_select_bsp_instance_bsp_index",
            [0x1FA] = "visibility_debug_select_bsp_instance_index",
            [0x1FB] = "visibility_enable_occlusion",
            [0x1FC] = "visibility_enable_multithreading",
            [0x1FD] = "error_geometry_draw_names",
            [0x1FE] = "error_geometry_tangent_space",
            [0x1FF] = "error_geometry_lightmap_lights",
            [0x200] = "debug_objects",
            [0x201] = "debug_objects_position_velocity",
            [0x202] = "debug_objects_origin",
            [0x203] = "debug_objects_root_node",
            [0x204] = "debug_objects_bounding_spheres",
            [0x205] = "debug_objects_attached_aabbs",
            [0x206] = "debug_objects_light_overlaps",
            [0x207] = "debug_objects_attached_bounding_spheres",
            [0x208] = "debug_objects_dynamic_render_bounding_spheres",
            [0x209] = "debug_objects_render_models",
            [0x20A] = "debug_objects_collision_models",
            [0x20B] = "debug_objects_cookie_cutters",
            [0x20C] = "debug_objects_early_movers",
            [0x20D] = "debug_objects_contact_points",
            [0x20E] = "debug_objects_constraints",
            [0x20F] = "debug_objects_vehicle_physics",
            [0x210] = "debug_objects_vehicle_effects",
            [0x211] = "debug_objects_vehicle_engines",
            [0x212] = "debug_objects_jetwash",
            [0x213] = "debug_objects_mass",
            [0x214] = "debug_objects_size",
            [0x215] = "debug_objects_speed",
            [0x216] = "debug_objects_havok_group",
            [0x217] = "debug_objects_physics_models",
            [0x218] = "debug_objects_expensive_physics",
            [0x219] = "debug_objects_water_physics",
            [0x21A] = "water_physics_velocity_minimum",
            [0x21B] = "water_physics_velocity_maximum",
            [0x21C] = "debug_objects_names",
            [0x21D] = "debug_objects_collision_hierarchy",
            [0x21E] = "debug_objects_names_full",
            [0x21F] = "debug_objects_indices",
            [0x220] = "debug_objects_indices_decimal",
            [0x221] = "debug_objects_functions",
            [0x222] = "debug_objects_functions_all",
            [0x223] = "debug_objects_model_targets",
            [0x224] = "debug_objects_pathfinding",
            [0x225] = "debug_objects_node_bounds",
            [0x226] = "debug_objects_unit_vectors",
            [0x227] = "debug_objects_unit_boost",
            [0x228] = "debug_objects_unit_seats",
            [0x229] = "debug_objects_unit_mouth_apeture",
            [0x22A] = "debug_objects_unit_firing",
            [0x22B] = "debug_objects_unit_lipsync",
            [0x22C] = "debug_objects_unit_lipsync_verbose",
            [0x22D] = "debug_objects_unit_emotion",
            [0x22E] = "debug_objects_unit_acceleration",
            [0x22F] = "debug_objects_unit_camera",
            [0x230] = "debug_objects_biped_autoaim_pills",
            [0x231] = "debug_objects_physics_control_node",
            [0x232] = "debug_objects_ground_plane",
            [0x233] = "debug_objects_movement_mode",
            [0x234] = "debug_objects_unit_pathfinding_surface",
            [0x235] = "debug_objects_devices",
            [0x236] = "debug_objects_machines",
            [0x237] = "debug_objects_garbage",
            [0x238] = "debug_objects_type_mask",
            [0x239] = "debug_objects_sound_spheres",
            [0x23A] = "debug_objects_active_nodes",
            [0x23B] = "debug_objects_unit_soft_ping_damage_regions",
            [0x23C] = "debug_objects_animation_times",
            [0x23D] = "debug_objects_animation",
            [0x23E] = "debug_objects_spawn_timers",
            [0x23F] = "debug_objects_freeze_ragdolls",
            [0x240] = "debug_objects_disable_relaxation",
            [0x241] = "debug_objects_sentinel_physics_ignore_lag",
            [0x242] = "debug_objects_ignore_node_masks",
            [0x243] = "objects_move_multithreading_enabled",
            [0x244] = "objects_compute_node_orientation_multithreading_enabled",
            [0x245] = "objects_assert_on_job_inconsistancy",
            [0x246] = "debug_objects_force_awake",
            [0x247] = "debug_objects_disable_node_animation",
            [0x248] = "debug_objects_dump_memory_stats",
            [0x249] = "debug_objects_object",
            [0x24A] = "debug_objects_by_index",
            [0x24B] = "debug_objects_player_only",
            [0x24C] = "debug_objects_vehicle_suspension",
            [0x24D] = "debug_objects_skeletons",
            [0x24E] = "debug_objects_cluster_counts",
            [0x24F] = "debug_objects_cluster_count_threshold",
            [0x250] = "debug_objects_networking",
            [0x251] = "debug_objects_animation_pose_channel",
            [0x252] = "render_model_nodes",
            [0x253] = "render_model_point_counts",
            [0x254] = "render_model_vertex_counts",
            [0x255] = "render_model_names",
            [0x256] = "render_model_triangle_counts",
            [0x257] = "render_model_collision_vertex_counts",
            [0x258] = "render_model_collision_surface_counts",
            [0x259] = "render_model_texture_usage",
            [0x25A] = "render_model_geometry_usage",
            [0x25B] = "render_model_cost",
            [0x25C] = "render_model_markers",
            [0x25D] = "render_model_no_geometry",
            [0x25E] = "render_model_skinning_disable",
            [0x25F] = "debug_weapons",
            [0x260] = "debug_weapons_triggers",
            [0x261] = "debug_weapons_barrels",
            [0x262] = "debug_weapons_magazines",
            [0x263] = "debug_weapons_primary",
            [0x264] = "debug_weapons_secondary",
            [0x265] = "debug_damage",
            [0x266] = "debug_player_damage",
            [0x267] = "debug_damage_verbose",
            [0x268] = "debug_damage_radius",
            [0x269] = "debug_damage_transfer",
            [0x26A] = "debug_damage_acceleration",
            [0x26B] = "debug_damage_response",
            [0x26C] = "debug_damage_aoe",
            [0x26D] = "debug_damage_armor",
            [0x26E] = "debug_damage_material",
            [0x26F] = "debug_damage_networking",
            [0x270] = "debug_damage_filter_output",
            [0x271] = "debug_damage_large_font",
            [0x272] = "debug_damage_player_inflicted_recent",
            [0x273] = "debug_damage_player_inflicted_duration",
            [0x274] = "hs_verbose",
            [0x275] = "breakpoints_enabled",
            [0x276] = "debug_trigger_volumes",
            [0x277] = "debug_trigger_volume_triangulation",
            [0x278] = "debug_point_physics",
            [0x279] = "water_physics_debug",
            [0x27A] = "collision_debug",
            [0x27B] = "collision_debug_attached",
            [0x27C] = "collision_debug_water_proxy",
            [0x27D] = "collision_debug_spray",
            [0x27E] = "collision_debug_objects_in_sphere",
            [0x27F] = "collision_debug_objects_in_sphere_attached",
            [0x280] = "collision_debug_features",
            [0x281] = "collision_debug_phantom_bsp",
            [0x282] = "collision_debug_lightmaps",
            [0x283] = "collision_debug_geometry_sampling",
            [0x284] = "collision_debug_print_position",
            [0x285] = "collision_kd_tree_exhaustive_debugging_enabled",
            [0x286] = "collision_kd_tree_debug",
            [0x287] = "collision_kd_tree_minimum_radius",
            [0x288] = "collision_kd_tree_maximum_depth",
            [0x289] = "collision_debug_flags",
            [0x28A] = "collision_debug_flag_structure",
            [0x28B] = "collision_debug_flag_water",
            [0x28C] = "collision_debug_flag_instanced_geometry",
            [0x28D] = "collision_debug_flag_objects",
            [0x28E] = "collision_debug_flag_objects_bipeds",
            [0x28F] = "collision_debug_flag_objects_giants",
            [0x290] = "collision_debug_flag_objects_effect_scenery",
            [0x291] = "collision_debug_flag_objects_vehicles",
            [0x292] = "collision_debug_flag_objects_weapons",
            [0x293] = "collision_debug_flag_objects_equipment",
            [0x294] = "collision_debug_flag_objects_terminals",
            [0x295] = "collision_debug_flag_objects_projectiles",
            [0x296] = "collision_debug_flag_objects_scenery",
            [0x297] = "collision_debug_flag_objects_machines",
            [0x298] = "collision_debug_flag_objects_controls",
            [0x299] = "collision_debug_flag_objects_sound_scenery",
            [0x29A] = "collision_debug_flag_objects_crates",
            [0x29B] = "collision_debug_flag_objects_creatures",
            [0x29C] = "collision_debug_flag_ignore_child_objects",
            [0x29D] = "collision_debug_flag_ignore_nonpathfindable_objects",
            [0x29E] = "collision_debug_flag_ignore_cinematic_objects",
            [0x29F] = "collision_debug_flag_ignore_dead_bipeds",
            [0x2A0] = "collision_debug_flag_ignore_passthrough_bipeds",
            [0x2A1] = "collision_debug_flag_front_facing_surfaces",
            [0x2A2] = "collision_debug_flag_back_facing_surfaces",
            [0x2A3] = "collision_debug_flag_ignore_two_sided_surfaces",
            [0x2A4] = "collision_debug_flag_ignore_invisible_surfaces",
            [0x2A5] = "collision_debug_flag_ignore_breakable_surfaces",
            [0x2A6] = "collision_debug_flag_allow_early_out",
            [0x2A7] = "collision_debug_flag_try_to_keep_location_valid",
            [0x2A8] = "collision_debug_repeat",
            [0x2A9] = "collision_debug_point_x",
            [0x2AA] = "collision_debug_point_y",
            [0x2AB] = "collision_debug_point_z",
            [0x2AC] = "collision_debug_vector_i",
            [0x2AD] = "collision_debug_vector_j",
            [0x2AE] = "collision_debug_vector_k",
            [0x2AF] = "collision_debug_length",
            [0x2B0] = "collision_debug_width",
            [0x2B1] = "collision_debug_height",
            [0x2B2] = "collision_debug_ignore_object_index",
            [0x2B3] = "collision_debug_fill_face",
            [0x2B4] = "debug_obstacle_path",
            [0x2B5] = "debug_obstacle_path_on_failure",
            [0x2B6] = "debug_obstacle_path_start_point_x",
            [0x2B7] = "debug_obstacle_path_start_point_y",
            [0x2B8] = "debug_obstacle_path_goal_point_x",
            [0x2B9] = "debug_obstacle_path_goal_point_y",
            [0x2BA] = "suppress_pathfinding_generation",
            [0x2BB] = "enable_pathfinding_generation_xbox",
            [0x2BC] = "ai_generate_flood_sector_wrl",
            [0x2BD] = "ai_pathfinding_generate_stats",
            [0x2BE] = "ai_pathfinding_use_exclusion",
            [0x2BF] = "ai_pathfinding_no_outlines_on_poopie_cutters",
            [0x2C0] = "debug_zone_set_critical_portals",
            [0x2C1] = "debug_camera",
            [0x2C2] = "debug_tangent_space",
            [0x2C3] = "debug_player",
            [0x2C4] = "debug_player_control_autoaim_always_active",
            [0x2C5] = "debug_structure",
            [0x2C6] = "debug_structure_occlude",
            [0x2C7] = "debug_structure_complexity",
            [0x2C8] = "debug_structure_water",
            [0x2C9] = "debug_structure_invisible",
            [0x2CA] = "debug_structure_cluster_skies",
            [0x2CB] = "debug_structure_slip_surfaces",
            [0x2CC] = "debug_structure_soft_ceilings",
            [0x2CD] = "debug_structure_soft_ceilings_biped",
            [0x2CE] = "debug_structure_soft_ceilings_vehicle",
            [0x2CF] = "debug_structure_soft_ceilings_huge_vehicle",
            [0x2D0] = "debug_structure_soft_ceilings_camera",
            [0x2D1] = "debug_structure_soft_ceilings_test_observer",
            [0x2D2] = "soft_ceilings_disable",
            [0x2D3] = "debug_structure_soft_kill",
            [0x2D4] = "debug_structure_cookie_cutters",
            [0x2D5] = "debug_structure_seam_edges",
            [0x2D6] = "debug_structure_seams",
            [0x2D7] = "debug_structure_seam_triangles",
            [0x2D8] = "debug_structure_seam_index",
            [0x2D9] = "debug_structure_seam_triangles_status",
            [0x2DA] = "debug_structure_seam_identical_instances",
            [0x2DB] = "debug_structure_automatic",
            [0x2DC] = "debug_structure_unique_colors",
            [0x2DD] = "debug_instanced_geometry",
            [0x2DE] = "debug_instanced_geometry_bounding_spheres",
            [0x2DF] = "debug_instanced_geometry_names",
            [0x2E0] = "debug_instanced_geometry_vertex_counts",
            [0x2E1] = "debug_instanced_geometry_collision_geometry",
            [0x2E2] = "debug_instanced_geometry_cookie_cutters",
            [0x2E3] = "debug_instanced_geometry_physics",
            [0x2E4] = "debug_instanced_geometry_physics_memory",
            [0x2E5] = "debug_instanced_geometry_physics_memory_threshold",
            [0x2E6] = "debug_structure_surface_references",
            [0x2E7] = "debug_structure_markers",
            [0x2E8] = "debug_bsp",
            [0x2E9] = "debug_kd",
            [0x2EA] = "debug_plane_index",
            [0x2EB] = "debug_surface_index",
            [0x2EC] = "debug_input",
            [0x2ED] = "debug_leaf0_index",
            [0x2EE] = "debug_leaf1_index",
            [0x2EF] = "debug_leaf_connection_index",
            [0x2F0] = "debug_cluster_index",
            [0x2F1] = "debug_first_person_weapons",
            [0x2F2] = "debug_first_person_models",
            [0x2F3] = "breakable_surfaces",
            [0x2F4] = "lightmap_light_preview_mode",
            [0x2F5] = "debug_lights",
            [0x2F6] = "debug_preplaced_lights",
            [0x2F7] = "debug_cheap_lights",
            [0x2F8] = "debug_light_passes",
            [0x2F9] = "debug_biped_landing",
            [0x2FA] = "debug_biped_throttle",
            [0x2FB] = "debug_biped_physics_nodes",
            [0x2FC] = "debug_biped_death_program_selector",
            [0x2FD] = "debug_biped_node_velocities",
            [0x2FE] = "debug_biped_proximity_feelers",
            [0x2FF] = "debug_collision_skip_instanced_geometry",
            [0x300] = "debug_collision_skip_objects",
            [0x301] = "debug_collision_skip_vectors",
            [0x302] = "debug_collision_object_payload_collision",
            [0x303] = "debug_collision_test_line_attached_disabled",
            [0x304] = "debug_objects_in_sphere_attached_disabled",
            [0x305] = "debug_material_effects",
            [0x306] = "debug_material_default_effects",
            [0x307] = "player_training_debug",
            [0x308] = "player_training_disable",
            [0x309] = "game_engine_debug_statborg",
            [0x30A] = "jaime_control_hack",
            [0x30B] = "bertone_control_hack",
            [0x30C] = "motor_system_debug",
            [0x30D] = "ai_profile_disable",
            [0x30E] = "ai_profile_random",
            [0x30F] = "ai_show",
            [0x310] = "ai_show_stats",
            [0x311] = "ai_show_actors",
            [0x312] = "ai_show_swarms",
            [0x313] = "ai_show_paths",
            [0x314] = "ai_show_line_of_sight",
            [0x315] = "ai_show_prop_types",
            [0x316] = "ai_show_sound_distance",
            [0x317] = "ai_render",
            [0x318] = "ai_render_all_actors",
            [0x319] = "ai_render_inactive_actors",
            [0x31A] = "ai_render_lineoffire_crouching",
            [0x31B] = "ai_render_lineoffire",
            [0x31C] = "ai_render_lineofsight",
            [0x31D] = "ai_render_ballistic_lineoffire",
            [0x31E] = "ai_render_vision_cones",
            [0x31F] = "ai_render_current_state",
            [0x320] = "ai_render_detailed_state",
            [0x321] = "ai_render_props",
            [0x322] = "ai_render_props_web",
            [0x323] = "ai_render_props_no_friends",
            [0x324] = "ai_render_props_unreachable",
            [0x325] = "ai_render_props_unopposable",
            [0x326] = "ai_render_props_stimulus",
            [0x327] = "ai_render_props_dialogue",
            [0x328] = "ai_render_props_salience",
            [0x329] = "ai_render_props_update",
            [0x32A] = "ai_render_props_search",
            [0x32B] = "ai_render_idle_look",
            [0x32C] = "ai_render_support_surfaces",
            [0x32D] = "ai_render_recent_damage",
            [0x32E] = "ai_render_current_damage",
            [0x32F] = "ai_render_threats",
            [0x330] = "ai_render_emotions",
            [0x331] = "ai_render_audibility",
            [0x332] = "ai_render_aiming_vectors",
            [0x333] = "ai_render_secondary_looking",
            [0x334] = "ai_render_targets",
            [0x335] = "ai_render_targets_all",
            [0x336] = "ai_render_targets_last_visible",
            [0x337] = "ai_render_target_groups",
            [0x338] = "ai_render_states",
            [0x339] = "ai_render_vitality",
            [0x33A] = "ai_render_vehicle_anchor",
            [0x33B] = "ai_render_flying_vehicle_movement_vectors",
            [0x33C] = "ai_render_flying_target_tail_cone",
            [0x33D] = "ai_render_evaluations",
            [0x33E] = "ai_render_evaluations_detailed",
            [0x33F] = "ai_render_evaluations_text",
            [0x340] = "ai_render_evaluations_shading_type",
            [0x341] = "ai_render_pursuit",
            [0x342] = "ai_render_shooting",
            [0x343] = "ai_render_trigger",
            [0x344] = "ai_render_projectile_aiming",
            [0x345] = "ai_render_aiming_validity",
            [0x346] = "ai_render_speech",
            [0x347] = "ai_render_leadership",
            [0x348] = "ai_render_status_flags",
            [0x349] = "ai_render_goal_state",
            [0x34A] = "ai_render_behavior_debug",
            [0x34B] = "ai_render_active_camo",
            [0x34C] = "ai_render_vehicle_attachment",
            [0x34D] = "ai_render_vehicle_reservations",
            [0x34E] = "ai_render_actor_blinddeaf",
            [0x34F] = "ai_render_morphing",
            [0x350] = "ai_render_look_orders",
            [0x351] = "ai_render_character_names",
            [0x352] = "ai_render_character_definition",
            [0x353] = "ai_render_behavior_failure",
            [0x354] = "ai_render_bunkering",
            [0x355] = "ai_render_pathfinding_influence_map",
            [0x356] = "ai_render_dialogue",
            [0x357] = "ai_render_dialogue_queue",
            [0x358] = "ai_render_dialogue_records",
            [0x359] = "ai_render_dialogue_player_weights",
            [0x35A] = "ai_dialogue_test_mode",
            [0x35B] = "ai_dialogue_verbose_pattern_errors",
            [0x35C] = "ai_dialogue_datamine_enable",
            [0x35D] = "ai_dialogue_datamine_failed_patterns_enable",
            [0x35E] = "ai_dialogue_log_failed_pattern_errors",
            [0x35F] = "ai_dialogue_debug_specific_vocalization",
            [0x360] = "ai_render_teams",
            [0x361] = "ai_render_actor_types",
            [0x362] = "ai_render_player_ratings",
            [0x363] = "ai_render_spatial_effects",
            [0x364] = "ai_render_firing_positions",
            [0x365] = "ai_render_firing_position_statistics",
            [0x366] = "ai_render_firing_position_obstacles",
            [0x367] = "ai_render_firing_position_bunkering",
            [0x368] = "ai_render_mission_critical",
            [0x369] = "ai_render_gun_positions",
            [0x36A] = "ai_render_aiming_positions",
            [0x36B] = "ai_render_burst_geometry",
            [0x36C] = "ai_render_vehicle_avoidance",
            [0x36D] = "ai_render_vehicles_enterable",
            [0x36E] = "ai_render_melee_check",
            [0x36F] = "ai_render_dialogue_variants",
            [0x370] = "ai_render_grenades",
            [0x371] = "ai_render_danger_zones",
            [0x372] = "ai_render_control",
            [0x373] = "ai_render_activation",
            [0x374] = "ai_render_paths",
            [0x375] = "ai_render_paths_text",
            [0x376] = "ai_render_paths_selected_only",
            [0x377] = "ai_render_paths_destination",
            [0x378] = "ai_render_paths_raw",
            [0x379] = "ai_render_paths_current",
            [0x37A] = "ai_render_paths_failed",
            [0x37B] = "ai_render_paths_smoothed",
            [0x37C] = "ai_render_paths_avoided",
            [0x37D] = "ai_render_paths_error_thresholds",
            [0x37E] = "ai_render_paths_avoidance_segment",
            [0x37F] = "ai_render_paths_avoidance_obstacles",
            [0x380] = "ai_render_paths_avoidance_search",
            [0x381] = "ai_render_paths_nodes",
            [0x382] = "ai_render_paths_nodes_all",
            [0x383] = "ai_render_paths_nodes_polygons",
            [0x384] = "ai_render_paths_nodes_costs",
            [0x385] = "ai_render_paths_nodes_closest",
            [0x386] = "ai_render_paths_distance",
            [0x387] = "ai_render_player_aiming_blocked",
            [0x388] = "ai_render_squad_patrol_state",
            [0x389] = "ai_render_deceleration_obstacles",
            [0x38A] = "ai_render_recent_obstacles",
            [0x38B] = "ai_render_inertia",
            [0x38C] = "ai_render_throttle_control",
            [0x38D] = "ai_render_stopping_distance",
            [0x38E] = "ai_render_destination_tolerance",
            [0x38F] = "ai_max_path_traverse_iterations",
            [0x390] = "ai_use_path_attractor_bounds",
            [0x391] = "ai_render_pathfinding_performance",
            [0x392] = "ai_render_pathfinding_performance_threshold",
            [0x393] = "ai_render_pathfinding_performance_cell_size",
            [0x394] = "ai_render_combat_range",
            [0x395] = "ai_render_dynamic_firing_positions",
            [0x396] = "ai_render_clumps",
            [0x397] = "ai_render_clump_props",
            [0x398] = "ai_render_clump_props_all",
            [0x399] = "ai_render_clump_dialogue",
            [0x39A] = "ai_render_sectors",
            [0x39B] = "ai_render_sector_bsps",
            [0x39C] = "ai_render_giant_sector_bsps",
            [0x39D] = "ai_render_sector_link_errors",
            [0x39E] = "ai_render_intersection_links",
            [0x39F] = "ai_render_non_walkable_sectors",
            [0x3A0] = "ai_render_threshold_links",
            [0x3A1] = "ai_render_sector_geometry_errors",
            [0x3A2] = "ai_pathfinding_generation_verbose",
            [0x3A3] = "ai_render_timeslices",
            [0x3A4] = "ai_render_sectors_range_max",
            [0x3A5] = "ai_render_sectors_range_min",
            [0x3A6] = "ai_render_link_specific",
            [0x3A7] = "ai_render_links",
            [0x3A8] = "ai_render_link_detailed",
            [0x3A9] = "ai_render_user_hints",
            [0x3AA] = "ai_render_area_flight_hints",
            [0x3AB] = "ai_render_hints",
            [0x3AC] = "ai_render_hints_detailed",
            [0x3AD] = "ai_render_object_hints",
            [0x3AE] = "ai_render_object_hints_all",
            [0x3AF] = "ai_render_object_properties",
            [0x3B0] = "ai_render_hints_movement",
            [0x3B1] = "ai_render_movement_mapping",
            [0x3B2] = "ai_render_persistent_movement_override",
            [0x3B3] = "ai_orders_print_entries",
            [0x3B4] = "ai_orders_print_entries_verbose",
            [0x3B5] = "ai_render_orders",
            [0x3B6] = "ai_render_suppress_combat",
            [0x3B7] = "ai_render_squad_patrol",
            [0x3B8] = "ai_render_formations",
            [0x3B9] = "ai_render_objectives",
            [0x3BA] = "ai_render_strength",
            [0x3BB] = "ai_render_squad_fronts",
            [0x3BC] = "ai_render_squad_fronts_detailed",
            [0x3BD] = "ai_render_ai_iterator",
            [0x3BE] = "ai_render_child_stack",
            [0x3BF] = "ai_render_behavior_movement_type",
            [0x3C0] = "ai_render_behavior_stack",
            [0x3C1] = "ai_render_behavior_stack_all",
            [0x3C2] = "ai_render_stimuli",
            [0x3C3] = "ai_render_stimuli_all",
            [0x3C4] = "ai_render_combat_status",
            [0x3C5] = "ai_render_decisions",
            [0x3C6] = "ai_render_decisions_all",
            [0x3C7] = "ai_render_command_scripts",
            [0x3C8] = "ai_render_script_data",
            [0x3C9] = "ai_hide_actor_errors",
            [0x3CA] = "ai_debug_tracking_data",
            [0x3CB] = "ai_debug_perception_data",
            [0x3CC] = "ai_debug_combat_status",
            [0x3CD] = "ai_render_tracked_props",
            [0x3CE] = "ai_render_tracked_props_all",
            [0x3CF] = "ai_debug_vignettes",
            [0x3D0] = "ai_render_joint_behaviors",
            [0x3D1] = "ai_render_swarm",
            [0x3D2] = "ai_render_flocks",
            [0x3D3] = "ai_render_flock_boid_destination",
            [0x3D4] = "ai_render_flock_danger",
            [0x3D5] = "ai_render_flock_boid_properties",
            [0x3D6] = "ai_render_vehicle_interest",
            [0x3D7] = "ai_render_player_battle_vector",
            [0x3D8] = "ai_render_player_needs_vehicle",
            [0x3D9] = "ai_debug_prop_refresh",
            [0x3DA] = "ai_debug_all_disposable",
            [0x3DB] = "ai_debug_disable_high_priority_timeslices",
            [0x3DC] = "ai_current_squad",
            [0x3DD] = "ai_current_actor",
            [0x3DE] = "ai_current_performance",
            [0x3DF] = "ai_render_vehicle_turns",
            [0x3E0] = "ai_render_discarded_firing_positions",
            [0x3E1] = "ai_render_firing_positions_all",
            [0x3E2] = "ai_render_firing_position_info",
            [0x3E3] = "ai_render_firing_position_index",
            [0x3E4] = "ai_inspect_avoidance_failure",
            [0x3E5] = "ai_render_action_selection_failure",
            [0x3E6] = "ai_render_debug_pathfinding",
            [0x3E7] = "ai_render_debug_pathfinding_wall_height",
            [0x3E8] = "ai_render_debug_pathfinding_wall_opacity",
            [0x3E9] = "ai_volume_avoidance_render",
            [0x3EA] = "ai_volume_avoidance_render_cuts",
            [0x3EB] = "ai_volume_avoidance_render_volumes",
            [0x3EC] = "ai_volume_avoidance_render_step_choices",
            [0x3ED] = "ai_volume_avoidance_render_step",
            [0x3EE] = "ai_volume_avoidance_render_tolerance",
            [0x3EF] = "ai_volume_avoidance_render_start_object_name",
            [0x3F0] = "ai_volume_avoidance_render_end_object_name",
            [0x3F1] = "ai_render_flying_cover",
            [0x3F2] = "ai_render_flying_area",
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
            [0x4FB] = "debug_tag_dependencies",
            [0x4FC] = "check_system_heap",
            [0x4FD] = "data_mine_player_update_interval",
            [0x4FE] = "data_mine_mp_player_update_interval",
            [0x4FF] = "data_mine_debug_menu_interval",
            [0x500] = "data_mine_spam_enabled",
            [0x501] = "webstats_file_zip_writes_per_frame",
            [0x502] = "debug_projectiles",
            [0x503] = "debug_projectiles_network",
            [0x504] = "debug_projectiles_duration_post_death",
            [0x505] = "debug_projectiles_disable_authoritative_sticks",
            [0x506] = "debug_damage_effects",
            [0x507] = "debug_damage_effect_obstacles",
            [0x508] = "force_player_walking",
            [0x509] = "unit_animation_report_missing_animations",
            [0x50A] = "font_cache_status",
            [0x50B] = "font_cache_debug_texture",
            [0x50C] = "font_cache_debug_graph",
            [0x50D] = "font_cache_debug_list",
            [0x50E] = "lruv_lirp_enabled",
            [0x50F] = "allow_sound_cache_file_editing",
            [0x510] = "halt_on_stack_overflow",
            [0x511] = "disable_progress_screen",
            [0x512] = "render_thread_enable",
            [0x513] = "character_force_physics",
            [0x514] = "enable_new_ik_method",
            [0x515] = "animation_throttle_dampening_scale",
            [0x516] = "animation_blend_change_scale",
            [0x517] = "debug_animation_force_subframe_on_loop",
            [0x518] = "debug_animation_fp_jump_land_disable",
            [0x519] = "debug_animation_fp_weapon_ik_disable",
            [0x51A] = "debug_animation_fp_sprint_disable",
            [0x51B] = "animation_turn_speed_blend_scale",
            [0x51C] = "biped_fitting_enable",
            [0x51D] = "biped_fitting_root_offset_enable",
            [0x51E] = "biped_pivot_enable",
            [0x51F] = "biped_pivot_allow_player",
            [0x520] = "ik_disable",
            [0x521] = "ik_chain_fixup_disable",
            [0x522] = "giant_hunt_player",
            [0x523] = "giant_hunting_min_radius",
            [0x524] = "giant_hunting_max_radius",
            [0x525] = "giant_hunting_throttle_scale",
            [0x526] = "giant_weapon_wait_time",
            [0x527] = "giant_weapon_trigger_time",
            [0x528] = "giant_ik",
            [0x529] = "giant_foot_ik",
            [0x52A] = "giant_ankle_ik",
            [0x52B] = "giant_elevation_control",
            [0x52C] = "giant_force_buckle",
            [0x52D] = "giant_force_crouch",
            [0x52E] = "giant_force_death",
            [0x52F] = "giant_buckle_rotation",
            [0x530] = "debug_objects_giant_feet",
            [0x531] = "debug_objects_giant_buckle",
            [0x532] = "enable_xsync_timings",
            [0x533] = "allow_restricted_tag_groups_to_load",
            [0x534] = "xsync_restricted_tag_groups",
            [0x535] = "enable_cache_build_resources",
            [0x536] = "xma_compression_level_default",
            [0x537] = "enable_console_window",
            [0x538] = "display_colors_in_banded_gamma",
            [0x539] = "use_tool_command_legacy",
            [0x53A] = "maximum_tool_command_history",
            [0x53B] = "disable_unit_aim_screens",
            [0x53C] = "disable_unit_look_screens",
            [0x53D] = "disable_unit_eye_tracking",
            [0x53E] = "enable_tag_resource_xsync",
            [0x53F] = "dont_recompile_shaders",
            [0x540] = "insepcting_xenon_shader",
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
            [0x562] = "amortized_prediction_object_batch_size",
            [0x563] = "enable_tag_resource_prediction",
            [0x564] = "enable_entire_pvs_prediction",
            [0x565] = "enable_cluster_objects_prediction",
            [0x566] = "disable_main_loop_throttle",
            [0x567] = "enable_partial_cache_flush",
            [0x568] = "force_unit_walking",
            [0x569] = "leap_force_start_rotation",
            [0x56A] = "leap_force_end_rotation",
            [0x56B] = "leap_force_flight_start_rotation",
            [0x56C] = "leap_force_flight_end_rotation",
            [0x56D] = "leap_flight_path_scale",
            [0x56E] = "leap_departure_power",
            [0x56F] = "leap_departure_scale",
            [0x570] = "leap_arrival_power",
            [0x571] = "leap_arrival_scale",
            [0x572] = "leap_twist_power",
            [0x573] = "leap_cannonball_power",
            [0x574] = "leap_cannonball_scale",
            [0x575] = "leap_idle_power",
            [0x576] = "leap_idle_scale",
            [0x577] = "leap_overlay_power",
            [0x578] = "leap_overlay_scale",
            [0x579] = "leap_interpolation_limit",
            [0x57A] = "biped_fake_soft_landing",
            [0x57B] = "biped_fake_hard_landing",
            [0x57C] = "biped_soft_landing_recovery_scale",
            [0x57D] = "biped_hard_landing_recovery_scale",
            [0x57E] = "biped_landing_absorbtion",
            [0x57F] = "debug_player_network_aiming",
            [0x580] = "collision_hierarchy_objects_in_cone_enabled",
            [0x581] = "aim_assist_disable_target_lead_vector",
            [0x582] = "enable_tag_edit_sync",
            [0x583] = "cache_file_builder_allow_sharing",
            [0x584] = "render_debug_dont_flash_low_res_textures",
            [0x585] = "debug_objects_pendulum",
            [0x586] = "ui_alpha",
            [0x587] = "ui_alpha_lockdown",
            [0x588] = "ui_alpha_eula_accepted",
            [0x589] = "ui_alpha_custom_games_enabled",
            [0x58A] = "ui_new_user_experience_suppress",
            [0x58B] = "net_config_client_badness_rating_threshold_override",
            [0x58C] = "net_config_disable_bad_client_anticheating_override",
            [0x58D] = "net_config_disable_bad_connectivity_anticheating_override",
            [0x58E] = "net_config_disable_bad_bandwidth_anticheating_override",
            [0x58F] = "net_config_maximum_multiplayer_split_screen_override",
            [0x590] = "net_config_crash_handling_minidump_type_override",
            [0x591] = "net_config_crash_handling_ui_display_override",
            [0x592] = "online_files_slowdown",
            [0x593] = "debug_trace_main_events",
            [0x594] = "force_xsync_memory_buyback",
            [0x595] = "bitmaps_trim_unused_pixels",
            [0x596] = "bitmaps_interleave_compressed_bitmaps",
            [0x597] = "ignore_predefined_performance_throttles",
            [0x598] = "enable_first_person_prediction",
            [0x599] = "enable_structure_prediction",
            [0x59A] = "cache_file_builder_dump_tag_sections",
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
            [0x5B9] = "error_geometry_environment_enabled",
            [0x5BA] = "error_geometry_lightmap_enabled",
            [0x5BB] = "error_geometry_seam_enabled",
            [0x5BC] = "error_geometry_instance_enabled",
            [0x5BD] = "error_geometry_object_enabled",
            [0x5BE] = "debug_objects_unit_melee",
            [0x5BF] = "force_buffer_2_frames",
            [0x5C0] = "disable_render_state_cache_optimization",
            [0x5C1] = "unknown5C1",
            [0x5C2] = "unknown5C2",
            [0x5C3] = "enable_better_cpu_gpu_sync",
            [0x5C4] = "require_secure_cache_files",
            [0x5C5] = "require_secure_variants",
            [0x5C6] = "debug_aim_assist_targets_enabled",
            [0x5C7] = "debug_aim_assist_targets_names",
            [0x5C8] = "debug_aim_assist_vectors",
            [0x5C9] = "motion_blur_max_viewport_count",
            [0x5CA] = "cinematic_prediction_enable",
            [0x5CB] = "skies_delete_on_zone_set_switch_enable",
            [0x5CC] = "reduce_widescreen_fov_during_cinematics",
            [0x5CD] = "cinematic_debugging_enable",
            [0x5CE] = "cinematic_debugging_verbose_enable",
            [0x5CF] = "import_sound_write_diagnostic_files",
            [0x5D0] = "import_sound_cut_samples_simple",
            [0x5D1] = "import_sound_cut_samples_search_count",
            [0x5D2] = "import_sound_cut_samples_slope_count",
            [0x5D3] = "sound_no_hdd_turn_on_the_juice",
            [0x5D4] = "sound_no_hdd_caching_enabled",
            [0x5D5] = "game_state_allow_insecure",
            [0x5D6] = "dump_cache_builder_determinism_log",
            [0x5D7] = "dump_cache_builder_determinism_log_full",
            [0x5D8] = "allow_insecure_resources",
            [0x5D9] = "use_new_dialogue_stripping",
            [0x5DA] = "ragdoll_immediately_on_death",
            [0x5DB] = "xsync_all_language_for_sound",
            [0x5DC] = "debug_sound_totals",
            [0x5DD] = "debug_sound_class_totals",
            [0x5DE] = "debug_multiplayer_object_properties",
            [0x5DF] = "g_enable_debug_animation_solving",
            [0x5E0] = "g_animation_debug_initial_camera_distance",
            [0x5E1] = "g_animation_debug_initial_target_vertical_offset",
            [0x5E2] = "objective_player_can_buy_while_dead",
            [0x5E3] = "objective_auto_switch_to_dead_cam_delay",
            [0x5E4] = "objective_dead_cam_respawning_delay_before_voluntary_control_of_spawn",
            [0x5E5] = "objective_dead_cam_respawn_suppression",
            [0x5E6] = "objective_dead_cam_respawn_time_resets_when_switching_targets",
            [0x5E7] = "objective_dead_cam_extermination_allows_push_to_respawn",
            [0x5E8] = "objective_dead_cam_enable_push_to_respawn",
            [0x5E9] = "objective_dead_cam_respawning_respawn_time_on_player_seconds",
            [0x5EA] = "objective_dead_cam_respawning_respawn_time_at_base_seconds",
            [0x5EB] = "objective_dead_cam_respawning_respawn_time_at_base_after_extermination_seconds",
            [0x5EC] = "objective_allow_laser_designation_selection_of_objectives",
            [0x5ED] = "objective_buy_menu_screen_button_override_dpad_up",
            [0x5EE] = "requisition_auto_enter_drivers_seat_of_purchased_vehicles",
            [0x5EF] = "requisition_enable_budget_limits",
            [0x5F0] = "laser_designation_control_enable",
            [0x5F1] = "laser_designation_control_as_toggle",
            [0x5F2] = "laser_designation_allow_firing_at_own_laser",
            [0x5F3] = "laser_designation_requires_equipment",
            [0x5F4] = "laser_designation_laser_point_fade_out_seconds",
            [0x5F5] = "net_show_simulation_quality_machine_index",
            [0x5F6] = "simulation_interpolation_visualize",
            [0x5F7] = "simulation_interpolation_disable_all_position_interpolation",
            [0x5F8] = "simulation_interpolation_disable_all_rotation_interpolation",
            [0x5F9] = "simulation_interpolation_force_all_interpolation_to_use_velocity_bumps",
            [0x5FA] = "simulation_interpolation_force_all_interpolation_to_use_blending",
            [0x5FB] = "simulation_interpolation_use_override_position_config",
            [0x5FC] = "simulation_interpolation_use_override_rotation_config",
            [0x5FD] = "simulation_interpolation_force_all_interpolation_to_use_warps",
            [0x5FE] = "simulation_interpolation_disable_velocity_bumps",
            [0x5FF] = "simulation_interpolation_disable_blends",
            [0x600] = "debug_instance_imposters",
            [0x601] = "debug_instance_groups",
            [0x602] = "debug_instance_group_decorator_type",
            [0x603] = "debug_instance_group_non_decorator_type",
            [0x604] = "debug_instance_group_members",
            [0x605] = "debug_instance_group_bounds",
            [0x606] = "render_debug_big_battle_squads",
            [0x607] = "megalo_debug",
            [0x608] = "megalo_debug_filter_lists",
            [0x609] = "debug_objects_physics_models_render_polyhedron_points",
            [0x60A] = "net_pretend_latency",
            [0x60B] = "net_force_voice_transmission_frequency",
            [0x60C] = "cache_file_builder_allow_invalid_map_sizes",
            [0x60D] = "weapon_barrel_create_projectiles_log",
            [0x60E] = "display_prefetch_progress",
            [0x60F] = "cache_file_builder_unshare_unique_map_locations",
            [0x610] = "damage_response_ignore_seat_ejection",
            [0x611] = "spawning_unseen_spawning_cone_distance",
            [0x612] = "spawning_unseen_spawning_cone_angle",
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
