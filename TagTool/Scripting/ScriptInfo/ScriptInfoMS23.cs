﻿using System.Collections.Generic;

namespace TagTool.Scripting
{
    public class ScriptInfoMS23
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
            [0x1B] = "zone_set",
            [0x1C] = "designer_zone",
            [0x1D] = "point_reference",
            [0x1E] = "style",
            [0x1F] = "object_list",
            [0x20] = "folder",
            [0x21] = "sound",
            [0x22] = "effect",
            [0x23] = "damage",
            [0x24] = "looping_sound",
            [0x25] = "animation_graph",
            [0x26] = "damage_effect",
            [0x27] = "object_definition",
            [0x28] = "bitmap",
            [0x29] = "shader",
            [0x2A] = "render_model",
            [0x2B] = "structure_definition",
            [0x2C] = "lightmap_definition",
            [0x2D] = "cinematic_definition",
            [0x2E] = "cinematic_scene_definition",
            [0x2F] = "bink_definition",
            [0x30] = "any_tag",
            [0x31] = "any_tag_not_resolving",
            [0x32] = "game_difficulty",
            [0x33] = "team",
            [0x34] = "mp_team",
            [0x35] = "controller",
            [0x36] = "button_preset",
            [0x37] = "joystick_preset",
            [0x38] = "player_character_type",
            [0x39] = "voice_output_setting",
            [0x3A] = "voice_mask",
            [0x3B] = "subtitle_setting",
            [0x3C] = "actor_type",
            [0x3D] = "model_state",
            [0x3E] = "event",
            [0x3F] = "character_physics",
            [0x40] = "primary_skull",
            [0x41] = "secondary_skull",
            [0x42] = "object",
            [0x43] = "unit",
            [0x44] = "vehicle",
            [0x45] = "weapon",
            [0x46] = "device",
            [0x47] = "scenery",
            [0x48] = "effect_scenery",
            [0x49] = "object_name",
            [0x4A] = "unit_name",
            [0x4B] = "vehicle_name",
            [0x4C] = "weapon_name",
            [0x4D] = "device_name",
            [0x4E] = "scenery_name",
            [0x4F] = "effect_scenery_name",
            [0x50] = "cinematic_lightprobe",
            [0x51] = "animation_budget_reference",
            [0x52] = "looping_sound_budget_reference",
            [0x53] = "sound_budget_reference",
        };

        public static Dictionary<int, string> Globals = new Dictionary<int, string>
        {
            [0x000] = "unknown0",
            [0x001] = "unknown1",
            [0x002] = "unknown2",
            [0x003] = "unknown3",
            [0x004] = "unknown4",
            [0x005] = "unknown5",
            [0x006] = "unknown6",
            [0x007] = "unknown7",
            [0x008] = "unknown8",
            [0x009] = "unknown9",
            [0x00A] = "unknownA",
            [0x00B] = "unknownB",
            [0x00C] = "unknownC",
            [0x00D] = "unknownD",
            [0x00E] = "unknownE",
            [0x00F] = "unknownF",
            [0x010] = "unknown10",
            [0x011] = "unknown11",
            [0x012] = "unknown12",
            [0x013] = "debug_controller_latency",
            [0x014] = "debug_physical_memory",
            [0x015] = "terminal_render",
            [0x016] = "events_debug_spam_render",
            [0x017] = "console_dump_to_debug_display",
            [0x018] = "camera_fov",
            [0x019] = "camera_yaw_scale",
            [0x01A] = "camera_pitch_scale",
            [0x01B] = "camera_forward_scale",
            [0x01C] = "camera_side_scale",
            [0x01D] = "camera_up_scale",
            [0x01E] = "flying_camera_maximum_boost_speed",
            [0x01F] = "flying_camera_movement_delay",
            [0x020] = "flying_camera_has_collision",
            [0x021] = "flying_camera_use_old_controls",
            [0x022] = "editor_director_mouse_wheel_speed_enabled",
            [0x023] = "async_display_statistics",
            [0x024] = "suppress_upload_debug",
            [0x025] = "lightmap_pointsample",
            [0x026] = "debug_no_frustum_clip",
            [0x027] = "debug_camera_projection",
            [0x028] = "debug_bink",
            [0x029] = "game_paused",
            [0x02A] = "game_speed",
            [0x02B] = "unknown2B",
            [0x02C] = "unknown2C",
            [0x02D] = "unknown2D",
            [0x02E] = "unknown2E",
            [0x02F] = "unknown2F",
            [0x030] = "unknown30",
            [0x031] = "unknown31",
            [0x032] = "unknown32",
            [0x033] = "unknown33",
            [0x034] = "unknown34",
            [0x035] = "unknown35",
            [0x036] = "unknown36",
            [0x037] = "unknown37",
            [0x038] = "unknown38",
            [0x039] = "unknown39",
            [0x03A] = "unknown3A",
            [0x03B] = "unknown3B",
            [0x03C] = "unknown3C",
            [0x03D] = "unknown3D",
            [0x03E] = "unknown3E",
            [0x03F] = "unknown3F",
            [0x040] = "unknown40",
            [0x041] = "unknown41",
            [0x042] = "unknown42",
            [0x043] = "unknown43",
            [0x044] = "unknown44",
            [0x045] = "unknown45",
            [0x046] = "unknown46",
            [0x047] = "unknown47",
            [0x048] = "unknown48",
            [0x049] = "fake_precache_percentage",
            [0x04A] = "force_aligned_utility_drive",
            [0x04B] = "debug_object_garbage_collection",
            [0x04C] = "debug_object_dump_log",
            [0x04D] = "allow_all_sounds_on_player",
            [0x04E] = "disable_player_rotation",
            [0x04F] = "player_rotation_scale",
            [0x050] = "debug_player_respawn",
            [0x051] = "g_synchronous_client_maximum_catchup_chunk_size",
            [0x052] = "g_editor_maximum_edited_object_speed",
            [0x053] = "g_editor_edited_object_spring_constant",
            [0x054] = "g_editor_maximum_rotation_speed",
            [0x055] = "chud_enabled",
            [0x056] = "chud_debug_grid",
            [0x057] = "chud_debug_messages",
            [0x058] = "chud_cortana_debug",
            [0x059] = "chud_debug_crosshair",
            [0x05A] = "chud_debug_metagame",
            [0x05B] = "debug_unit_all_animations",
            [0x05C] = "debug_unit_animations",
            [0x05D] = "debug_unit_illumination",
            [0x05E] = "debug_unit_active_camo_frequency_modulator",
            [0x05F] = "debug_unit_active_camo_frequency_modulator_bias",
            [0x060] = "unknown60",
            [0x061] = "unknown61",
            [0x062] = "unknown62",
            [0x063] = "unknown63",
            [0x064] = "unknown64",
            [0x065] = "unknown65",
            [0x066] = "unknown66",
            [0x067] = "unknown67",
            [0x068] = "unknown68",
            [0x069] = "unknown69",
            [0x06A] = "unknown6A",
            [0x06B] = "unknown6B",
            [0x06C] = "unknown6C",
            [0x06D] = "unknown6D",
            [0x06E] = "unknown6E",
            [0x06F] = "unknown6F",
            [0x070] = "unknown70",
            [0x071] = "unknown71",
            [0x072] = "unknown72",
            [0x073] = "unknown73",
            [0x074] = "unknown74",
            [0x075] = "unknown75",
            [0x076] = "effects_enable",
            [0x077] = "unknown77",
            [0x078] = "unknown78",
            [0x079] = "unknown79",
            [0x07A] = "unknown7A",
            [0x07B] = "unknown7B",
            [0x07C] = "unknown7C",
            [0x07D] = "unknown7D",
            [0x07E] = "unknown7E",
            [0x07F] = "sound_global_room_gain",
            [0x080] = "sound_direct_path_gain",
            [0x081] = "enable_pc_sound",
            [0x082] = "unknown82",
            [0x083] = "unknown83",
            [0x084] = "unknown84",
            [0x085] = "unknown85",
            [0x086] = "unknown86",
            [0x087] = "unknown87",
            [0x088] = "unknown88",
            [0x089] = "unknown89",
            [0x08A] = "unknown8A",
            [0x08B] = "unknown8B",
            [0x08C] = "unknown8C",
            [0x08D] = "unknown8D",
            [0x08E] = "unknown8E",
            [0x08F] = "unknown8F",
            [0x090] = "unknown90",
            [0x091] = "unknown91",
            [0x092] = "unknown92",
            [0x093] = "unknown93",
            [0x094] = "unknown94",
            [0x095] = "unknown95",
            [0x096] = "unknown96",
            [0x097] = "unknown97",
            [0x098] = "unknown98",
            [0x099] = "unknown99",
            [0x09A] = "unknown9A",
            [0x09B] = "unknown9B",
            [0x09C] = "unknown9C",
            [0x09D] = "unknown9D",
            [0x09E] = "collision_log_time",
            [0x09F] = "havok_collision_tolerance",
            [0x0A0] = "havok_debug_mode",
            [0x0A1] = "havok_thread_count",
            [0x0A2] = "havok_environment_type",
            [0x0A3] = "havok_shape_radius",
            [0x0A4] = "havok_jumping_beans",
            [0x0A5] = "havok_disable_deactivation",
            [0x0A6] = "havok_weld_environment",
            [0x0A7] = "havok_batch_add_entities_disabled",
            [0x0A8] = "havok_shape_cache",
            [0x0A9] = "havok_shape_cache_debug",
            [0x0AA] = "havok_enable_back_stepping",
            [0x0AB] = "havok_enable_sweep_shapes",
            [0x0AC] = "havok_display_stats",
            [0x0AD] = "havok_initialize_profiling",
            [0x0AE] = "impacts_debug",
            [0x0AF] = "proxies_debug",
            [0x0B0] = "collision_damage_debug",
            [0x0B1] = "havok_play_impact_effects",
            [0x0B2] = "havok_play_biped_impact_effects",
            [0x0B3] = "physics_debug",
            [0x0B4] = "havok_cleanup_inactive_agents",
            [0x0B5] = "havok_memory_always_system",
            [0x0B6] = "disable_expensive_physics_rebuilding",
            [0x0B7] = "minimum_havok_object_acceleration",
            [0x0B8] = "minimum_havok_biped_object_acceleration",
            [0x0B9] = "debug_object_scheduler",
            [0x0BA] = "render_debug_cache_state",
            [0x0BB] = "render_environment",
            [0x0BC] = "render_objects",
            [0x0BD] = "visibility_debug_use_old_sphere_test",
            [0x0BE] = "render_lightmap_shadows",
            [0x0BF] = "render_lightmap_shadows_apply",
            [0x0C0] = "render_lights",
            [0x0C1] = "render_water_tessellated",
            [0x0C2] = "render_water_wireframe",
            [0x0C3] = "render_water_interaction",
            [0x0C4] = "render_water",
            [0x0C5] = "render_water_ripple_cutoff_distance",
            [0x0C6] = "render_first_person",
            [0x0C7] = "render_debug_mode",
            [0x0C8] = "render_debug_safe_frame_bounds",
            [0x0C9] = "render_debug_colorbars",
            [0x0CA] = "render_debug_aspect_ratio_scale",
            [0x0CB] = "render_debug_force_4x3_aspect_ratio",
            [0x0CC] = "render_debug_transparents",
            [0x0CD] = "render_debug_slow_transparents",
            [0x0CE] = "render_transparents",
            [0x0CF] = "render_debug_transparent_cull",
            [0x0D0] = "render_debug_transparent_cull_flip",
            [0x0D1] = "render_debug_transparent_sort_method",
            [0x0D2] = "render_debug_lens_flares",
            [0x0D3] = "render_instanced_geometry",
            [0x0D4] = "render_sky",
            [0x0D5] = "render_lens_flares",
            [0x0D6] = "render_decorators",
            [0x0D7] = "light_decorators",
            [0x0D8] = "render_decorator_bounds",
            [0x0D9] = "render_decorator_spheres",
            [0x0DA] = "render_decorator_bsp_test_offset_scale_parameter",
            [0x0DB] = "unknownDB",
            [0x0DC] = "unknownDC",
            [0x0DD] = "unknownDD",
            [0x0DE] = "unknownDE",
            [0x0DF] = "unknownDF",
            [0x0E0] = "unknownE0",
            [0x0E1] = "unknownE1",
            [0x0E2] = "unknownE2",
            [0x0E3] = "unknownE3",
            [0x0E4] = "unknownE4",
            [0x0E5] = "render_debug_save_surface",
            [0x0E6] = "render_disable_screen_effects_not_first_person",
            [0x0E7] = "render_screen_flashes",
            [0x0E8] = "texture_camera_near_plane",
            [0x0E9] = "texture_camera_exposure",
            [0x0EA] = "texture_camera_illum_scale",
            [0x0EB] = "render_near_clip_distance",
            [0x0EC] = "render_far_clip_distance",
            [0x0ED] = "render_exposure_stops",
            [0x0EE] = "display_exposure",
            [0x0EF] = "render_HDR_target_stops",
            [0x0F0] = "render_surface_LDR_mode",
            [0x0F1] = "render_surface_HDR_mode",
            [0x0F2] = "render_first_person_fov_scale",
            [0x0F3] = "rasterizer_triliner_threshold",
            [0x0F4] = "rasterizer_present_immediate_threshold",
            [0x0F5] = "tiling",
            [0x0F6] = "render_screen_res",
            [0x0F7] = "render_force_tiling",
            [0x0F8] = "render_tiling_resolve_fragment_index",
            [0x0F9] = "render_tiling_viewport_offset_x",
            [0x0FA] = "render_tiling_viewport_offset_y",
            [0x0FB] = "render_true_gamma",
            [0x0FC] = "render_shadow_bounds",
            [0x0FD] = "render_shadow_bounds_solid",
            [0x0FE] = "render_shadow_opaque",
            [0x0FF] = "render_shadow_screenspace",
            [0x100] = "render_shadow_histencil",
            [0x101] = "render_shadow_hires",
            [0x102] = "render_shadow_objectspace_stencil_clip",
            [0x103] = "render_shadow_force_fancy",
            [0x104] = "render_shadow_force_old",
            [0x105] = "render_postprocess",
            [0x106] = "render_accum",
            [0x107] = "render_bloom_source",
            [0x108] = "render_persist",
            [0x109] = "render_bloom",
            [0x10A] = "render_bling",
            [0x10B] = "render_downsample",
            [0x10C] = "render_show_alpha",
            [0x10D] = "render_postprocess_exposure",
            [0x10E] = "render_accum_filter",
            [0x10F] = "render_tone_curve",
            [0x110] = "render_tone_curve_white",
            [0x111] = "render_exposure_lock",
            [0x112] = "render_postprocess_hue",
            [0x113] = "render_postprocess_saturation",
            [0x114] = "render_postprocess_red_filter",
            [0x115] = "render_postprocess_green_filter",
            [0x116] = "render_postprocess_blue_filter",
            [0x117] = "render_screenspace_center",
            [0x118] = "render_bounce_light_intensity",
            [0x119] = "render_bounce_light_only",
            [0x11A] = "render_disable_prt",
            [0x11B] = "force_render_lightmap_mesh",
            [0x11C] = "screenshot_anisotropic_level",
            [0x11D] = "screenshot_gamma",
            [0x11E] = "render_light_intensity",
            [0x11F] = "render_light_clip_planes",
            [0x120] = "render_light_opaque",
            [0x121] = "cubemap_debug",
            [0x122] = "render_debug_cloth",
            [0x123] = "render_debug_antennas",
            [0x124] = "render_debug_leaf_systems",
            [0x125] = "render_debug_object_lighting",
            [0x126] = "render_debug_object_lighting_refresh",
            [0x127] = "render_debug_use_cholocate_mountain",
            [0x128] = "render_debug_object_lighting_use_scenery_probe",
            [0x129] = "render_debug_object_lighting_use_device_probe",
            [0x12A] = "render_debug_object_lighting_use_air_probe",
            [0x12B] = "render_debug_show_air_probes",
            [0x12C] = "render_debug_infinite_framerate",
            [0x12D] = "render_debug_toggle_default_lightmaps_texaccum",
            [0x12E] = "render_debug_toggle_default_static_lighting",
            [0x12F] = "render_debug_toggle_default_dynamic_lighting",
            [0x130] = "render_debug_toggle_default_sfx",
            [0x131] = "render_debug_depth_render",
            [0x132] = "render_debug_depth_render_scale_r",
            [0x133] = "render_debug_depth_render_scale_g",
            [0x134] = "render_debug_depth_render_scale_b",
            [0x135] = "render_debug_show_4x3_bounds",
            [0x136] = "render_weather_bounds",
            [0x137] = "render_debug_cinematic_clip",
            [0x138] = "render_buffer_gamma",
            [0x139] = "render_screen_gamma",
            [0x13A] = "render_buffer_gamma_curve",
            [0x13B] = "render_color_balance_red",
            [0x13C] = "render_color_balance_green",
            [0x13D] = "render_color_balance_blue",
            [0x13E] = "render_black_level_red",
            [0x13F] = "render_black_level_green",
            [0x140] = "render_black_level_blue",
            [0x141] = "debug_volume_samples",
            [0x142] = "decal_create",
            [0x143] = "decal_frame_advance",
            [0x144] = "decal_render",
            [0x145] = "decal_render_debug",
            [0x146] = "decal_render_latest_debug",
            [0x147] = "decal_cull",
            [0x148] = "decal_fade",
            [0x149] = "decal_dump",
            [0x14A] = "decal_z_bias",
            [0x14B] = "decal_slope_z_bias",
            [0x14C] = "unknown14C",
            [0x14D] = "unknown14D",
            [0x14E] = "unknown14E",
            [0x14F] = "unknown14F",
            [0x150] = "unknown150",
            [0x151] = "unknown151",
            [0x152] = "unknown152",
            [0x153] = "unknown153",
            [0x154] = "unknown154",
            [0x155] = "unknown155",
            [0x156] = "unknown156",
            [0x157] = "unknown157",
            [0x158] = "unknown158",
            [0x159] = "effect_priority_cutoff",
            [0x15A] = "weather_occlusion_max_height",
            [0x15B] = "render_method_debug",
            [0x15C] = "render_debug_viewport_scale",
            [0x15D] = "render_debug_light_probes",
            [0x15E] = "effect_property_culling",
            [0x15F] = "contrail_create",
            [0x160] = "contrail_pulse",
            [0x161] = "contrail_frame_advance",
            [0x162] = "contrail_submit",
            [0x163] = "contrail_dump",
            [0x164] = "light_volume_create",
            [0x165] = "light_volume_frame_advance",
            [0x166] = "light_volume_submit",
            [0x167] = "light_volume_dump",
            [0x168] = "beam_create",
            [0x169] = "beam_frame_advance",
            [0x16A] = "beam_submit",
            [0x16B] = "beam_dump",
            [0x16C] = "debug_inactive_objects",
            [0x16D] = "debug_pvs",
            [0x16E] = "debug_pvs_render_all",
            [0x16F] = "debug_pvs_activation",
            [0x170] = "pvs_building_disabled",
            [0x171] = "debug_pvs_editor_mode",
            [0x172] = "render_default_lighting",
            [0x173] = "visibility_debug_portals",
            [0x174] = "visibility_debug_audio_clusters",
            [0x175] = "visibility_debug_visible_clusters",
            [0x176] = "visibility_debug_portals_structure_bsp_index",
            [0x177] = "visibility_debug_portals_cluster_index",
            [0x178] = "error_geometry_draw_names",
            [0x179] = "error_geometry_tangent_space",
            [0x17A] = "error_geometry_lightmap_lights",
            [0x17B] = "debug_objects",
            [0x17C] = "debug_objects_position_velocity",
            [0x17D] = "debug_objects_origin",
            [0x17E] = "debug_objects_root_node",
            [0x17F] = "debug_objects_bounding_spheres",
            [0x180] = "debug_objects_attached_bounding_spheres",
            [0x181] = "debug_objects_dynamic_render_bounding_spheres",
            [0x182] = "debug_objects_render_models",
            [0x183] = "debug_objects_collision_models",
            [0x184] = "debug_objects_early_movers",
            [0x185] = "debug_objects_contact_points",
            [0x186] = "debug_objects_constraints",
            [0x187] = "debug_objects_vehicle_physics",
            [0x188] = "debug_objects_mass",
            [0x189] = "debug_objects_physics_models",
            [0x18A] = "debug_objects_expensive_physics",
            [0x18B] = "debug_objects_water_physics",
            [0x18C] = "water_physics_velocity_minimum",
            [0x18D] = "water_physics_velocity_maximum",
            [0x18E] = "debug_objects_names",
            [0x18F] = "debug_objects_names_full",
            [0x190] = "debug_objects_indices",
            [0x191] = "debug_objects_functions",
            [0x192] = "debug_objects_functions_all",
            [0x193] = "debug_objects_model_targets",
            [0x194] = "debug_objects_pathfinding",
            [0x195] = "debug_objects_profile_times",
            [0x196] = "debug_objects_node_bounds",
            [0x197] = "debug_objects_unit_vectors",
            [0x198] = "debug_objects_unit_seats",
            [0x199] = "debug_objects_unit_mouth_apeture",
            [0x19A] = "debug_objects_unit_firing",
            [0x19B] = "debug_objects_unit_lipsync",
            [0x19C] = "debug_objects_unit_lipsync_verbose",
            [0x19D] = "debug_objects_unit_emotion",
            [0x19E] = "debug_objects_unit_acceleration",
            [0x19F] = "debug_objects_unit_camera",
            [0x1A0] = "debug_objects_biped_autoaim_pills",
            [0x1A1] = "debug_objects_biped_melee_in_range",
            [0x1A2] = "debug_objects_physics_control_node",
            [0x1A3] = "debug_objects_ground_plane",
            [0x1A4] = "debug_objects_movement_mode",
            [0x1A5] = "debug_objects_unit_pathfinding_surface",
            [0x1A6] = "debug_objects_devices",
            [0x1A7] = "debug_objects_machines",
            [0x1A8] = "debug_objects_garbage",
            [0x1A9] = "debug_objects_type_mask",
            [0x1AA] = "debug_objects_sound_spheres",
            [0x1AB] = "debug_objects_active_nodes",
            [0x1AC] = "debug_objects_animation_times",
            [0x1AD] = "debug_objects_animation",
            [0x1AE] = "debug_objects_spawn_timers",
            [0x1AF] = "debug_objects_freeze_ragdolls",
            [0x1B0] = "debug_objects_disable_relaxation",
            [0x1B1] = "debug_objects_sentinel_physics_ignore_lag",
            [0x1B2] = "debug_objects_ignore_node_masks",
            [0x1B3] = "debug_objects_force_awake",
            [0x1B4] = "debug_objects_disable_node_animation",
            [0x1B5] = "debug_objects_dump_memory_stats",
            [0x1B6] = "debug_objects_object",
            [0x1B7] = "debug_objects_by_index",
            [0x1B8] = "debug_objects_player_only",
            [0x1B9] = "debug_objects_vehicle_suspension",
            [0x1BA] = "debug_objects_skeletons",
            [0x1BB] = "debug_objects_cluster_counts",
            [0x1BC] = "debug_objects_cluster_count_threshold",
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
            [0x1DB] = "collision_debug_flags",
            [0x1DC] = "collision_debug_flag_structure",
            [0x1DD] = "collision_debug_flag_water",
            [0x1DE] = "collision_debug_flag_instanced_geometry",
            [0x1DF] = "collision_debug_flag_objects",
            [0x1E0] = "collision_debug_flag_objects_bipeds",
            [0x1E1] = "collision_debug_flag_objects_giants",
            [0x1E2] = "collision_debug_flag_objects_effect_scenery",
            [0x1E3] = "collision_debug_flag_objects_vehicles",
            [0x1E4] = "collision_debug_flag_objects_weapons",
            [0x1E5] = "collision_debug_flag_objects_equipment",
            [0x1E6] = "collision_debug_flag_objects_terminals",
            [0x1E7] = "collision_debug_flag_objects_projectiles",
            [0x1E8] = "collision_debug_flag_objects_scenery",
            [0x1E9] = "collision_debug_flag_objects_machines",
            [0x1EA] = "collision_debug_flag_objects_controls",
            [0x1EB] = "collision_debug_flag_objects_sound_scenery",
            [0x1EC] = "collision_debug_flag_objects_crates",
            [0x1ED] = "collision_debug_flag_objects_creatures",
            [0x1EE] = "collision_debug_flag_ignore_child_objects",
            [0x1EF] = "collision_debug_flag_ignore_nonpathfindable_objects",
            [0x1F0] = "collision_debug_flag_ignore_cinematic_objects",
            [0x1F1] = "collision_debug_flag_ignore_dead_bipeds",
            [0x1F2] = "collision_debug_flag_ignore_passthrough_bipeds",
            [0x1F3] = "collision_debug_flag_front_facing_surfaces",
            [0x1F4] = "collision_debug_flag_back_facing_surfaces",
            [0x1F5] = "collision_debug_flag_ignore_two_sided_surfaces",
            [0x1F6] = "collision_debug_flag_ignore_invisible_surfaces",
            [0x1F7] = "collision_debug_flag_ignore_breakable_surfaces",
            [0x1F8] = "collision_debug_flag_allow_early_out",
            [0x1F9] = "collision_debug_flag_try_to_keep_location_valid",
            [0x1FA] = "collision_debug_repeat",
            [0x1FB] = "collision_debug_point_x",
            [0x1FC] = "collision_debug_point_y",
            [0x1FD] = "collision_debug_point_z",
            [0x1FE] = "collision_debug_vector_i",
            [0x1FF] = "collision_debug_vector_j",
            [0x200] = "collision_debug_vector_k",
            [0x201] = "collision_debug_length",
            [0x202] = "collision_debug_width",
            [0x203] = "collision_debug_height",
            [0x204] = "collision_debug_ignore_object_index",
            [0x205] = "debug_obstacle_path",
            [0x206] = "debug_obstacle_path_on_failure",
            [0x207] = "debug_obstacle_path_start_point_x",
            [0x208] = "debug_obstacle_path_start_point_y",
            [0x209] = "debug_obstacle_path_goal_point_x",
            [0x20A] = "debug_obstacle_path_goal_point_y",
            [0x20B] = "suppress_pathfinding_generation",
            [0x20C] = "enable_pathfinding_generation_xbox",
            [0x20D] = "ai_generate_flood_sector_wrl",
            [0x20E] = "ai_pathfinding_generate_stats",
            [0x20F] = "debug_zone_set_critical_portals",
            [0x210] = "debug_camera",
            [0x211] = "debug_tangent_space",
            [0x212] = "debug_player",
            [0x213] = "debug_player_control_autoaim_always_active",
            [0x214] = "debug_structure",
            [0x215] = "debug_structure_complexity",
            [0x216] = "debug_structure_water",
            [0x217] = "debug_structure_invisible",
            [0x218] = "debug_structure_cluster_skies",
            [0x219] = "debug_structure_slip_surfaces",
            [0x21A] = "debug_structure_soft_ceilings",
            [0x21B] = "debug_structure_soft_ceilings_biped",
            [0x21C] = "debug_structure_soft_ceilings_vehicle",
            [0x21D] = "debug_structure_soft_ceilings_huge_vehicle",
            [0x21E] = "debug_structure_soft_ceilings_camera",
            [0x21F] = "debug_structure_soft_ceilings_test_observer",
            [0x220] = "soft_ceilings_disable",
            [0x221] = "debug_structure_soft_kill",
            [0x222] = "debug_structure_seam_edges",
            [0x223] = "debug_structure_seams",
            [0x224] = "debug_structure_seam_triangles",
            [0x225] = "debug_structure_automatic",
            [0x226] = "debug_structure_unique_colors",
            [0x227] = "debug_instanced_geometry",
            [0x228] = "debug_instanced_geometry_bounding_spheres",
            [0x229] = "debug_instanced_geometry_names",
            [0x22A] = "debug_instanced_geometry_vertex_counts",
            [0x22B] = "debug_instanced_geometry_collision_geometry",
            [0x22C] = "debug_structure_surface_references",
            [0x22D] = "debug_structure_markers",
            [0x22E] = "debug_bsp",
            [0x22F] = "debug_plane_index",
            [0x230] = "debug_surface_index",
            [0x231] = "debug_input",
            [0x232] = "debug_leaf0_index",
            [0x233] = "debug_leaf1_index",
            [0x234] = "debug_leaf_connection_index",
            [0x235] = "debug_cluster_index",
            [0x236] = "debug_first_person_weapons",
            [0x237] = "debug_first_person_models",
            [0x238] = "breakable_surfaces",
            [0x239] = "debug_lights",
            [0x23A] = "debug_light_passes",
            [0x23B] = "debug_biped_landing",
            [0x23C] = "debug_biped_throttle",
            [0x23D] = "debug_biped_relaxation_pose",
            [0x23E] = "debug_biped_node_velocities",
            [0x23F] = "debug_collision_skip_instanced_geometry",
            [0x240] = "debug_collision_skip_objects",
            [0x241] = "debug_collision_skip_vectors",
            [0x242] = "debug_collision_object_payload_collision",
            [0x243] = "debug_material_effects",
            [0x244] = "debug_material_default_effects",
            [0x245] = "player_training_debug",
            [0x246] = "player_training_disable",
            [0x247] = "game_engine_debug_statborg",
            [0x248] = "jaime_control_hack",
            [0x249] = "bertone_control_hack",
            [0x24A] = "motor_system_debug",
            [0x24B] = "ai_profile_disable",
            [0x24C] = "ai_profile_random",
            [0x24D] = "ai_show",
            [0x24E] = "ai_show_stats",
            [0x24F] = "ai_show_actors",
            [0x250] = "ai_show_swarms",
            [0x251] = "ai_show_paths",
            [0x252] = "ai_show_line_of_sight",
            [0x253] = "ai_show_prop_types",
            [0x254] = "ai_show_sound_distance",
            [0x255] = "ai_render",
            [0x256] = "ai_render_all_actors",
            [0x257] = "ai_render_inactive_actors",
            [0x258] = "ai_render_lineoffire_crouching",
            [0x259] = "ai_render_lineoffire",
            [0x25A] = "ai_render_lineofsight",
            [0x25B] = "ai_render_ballistic_lineoffire",
            [0x25C] = "ai_render_vision_cones",
            [0x25D] = "ai_render_current_state",
            [0x25E] = "ai_render_detailed_state",
            [0x25F] = "ai_render_props",
            [0x260] = "ai_render_props_web",
            [0x261] = "ai_render_props_no_friends",
            [0x262] = "ai_render_props_unreachable",
            [0x263] = "ai_render_props_unopposable",
            [0x264] = "ai_render_props_stimulus",
            [0x265] = "ai_render_props_dialogue",
            [0x266] = "ai_render_props_salience",
            [0x267] = "ai_render_props_update",
            [0x268] = "ai_render_idle_look",
            [0x269] = "ai_render_support_surfaces",
            [0x26A] = "ai_render_recent_damage",
            [0x26B] = "ai_render_current_damage",
            [0x26C] = "ai_render_threats",
            [0x26D] = "ai_render_emotions",
            [0x26E] = "ai_render_audibility",
            [0x26F] = "ai_render_aiming_vectors",
            [0x270] = "ai_render_secondary_looking",
            [0x271] = "ai_render_targets",
            [0x272] = "ai_render_targets_all",
            [0x273] = "ai_render_targets_last_visible",
            [0x274] = "ai_render_states",
            [0x275] = "ai_render_vitality",
            [0x276] = "ai_render_evaluations",
            [0x277] = "ai_render_evaluations_detailed",
            [0x278] = "ai_render_evaluations_text",
            [0x279] = "ai_render_evaluations_shading",
            [0x27A] = "ai_render_evaluations_shading_type",
            [0x27B] = "ai_render_pursuit",
            [0x27C] = "ai_render_shooting",
            [0x27D] = "ai_render_trigger",
            [0x27E] = "ai_render_projectile_aiming",
            [0x27F] = "ai_render_aiming_validity",
            [0x280] = "ai_render_speech",
            [0x281] = "ai_render_leadership",
            [0x282] = "ai_render_status_flags",
            [0x283] = "ai_render_goal_state",
            [0x284] = "ai_render_behavior_debug",
            [0x285] = "ai_render_active_camo",
            [0x286] = "ai_render_vehicle_attachment",
            [0x287] = "ai_render_vehicle_reservations",
            [0x288] = "ai_render_actor_blinddeaf",
            [0x289] = "ai_render_morphing",
            [0x28A] = "ai_render_look_orders",
            [0x28B] = "ai_render_character_names",
            [0x28C] = "ai_render_behavior_failure",
            [0x28D] = "ai_render_dialogue",
            [0x28E] = "ai_render_dialogue_queue",
            [0x28F] = "ai_render_dialogue_records",
            [0x290] = "ai_render_dialogue_player_weights",
            [0x291] = "ai_dialogue_test_mode",
            [0x292] = "ai_dialogue_datamine_enable",
            [0x293] = "ai_render_teams",
            [0x294] = "ai_render_player_ratings",
            [0x295] = "ai_render_spatial_effects",
            [0x296] = "ai_render_firing_positions",
            [0x297] = "ai_render_firing_position_statistics",
            [0x298] = "ai_render_firing_position_obstacles",
            [0x299] = "ai_render_mission_critical",
            [0x29A] = "ai_render_gun_positions",
            [0x29B] = "ai_render_aiming_positions",
            [0x29C] = "ai_render_burst_geometry",
            [0x29D] = "ai_render_vehicle_avoidance",
            [0x29E] = "ai_render_vehicles_enterable",
            [0x29F] = "ai_render_melee_check",
            [0x2A0] = "ai_render_dialogue_variants",
            [0x2A1] = "ai_render_grenades",
            [0x2A2] = "ai_render_danger_zones",
            [0x2A3] = "ai_render_control",
            [0x2A4] = "ai_render_activation",
            [0x2A5] = "ai_render_paths",
            [0x2A6] = "ai_render_paths_text",
            [0x2A7] = "ai_render_paths_selected_only",
            [0x2A8] = "ai_render_paths_destination",
            [0x2A9] = "ai_render_paths_raw",
            [0x2AA] = "ai_render_paths_current",
            [0x2AB] = "ai_render_paths_failed",
            [0x2AC] = "ai_render_paths_smoothed",
            [0x2AD] = "ai_render_paths_avoided",
            [0x2AE] = "ai_render_paths_error_thresholds",
            [0x2AF] = "ai_render_paths_avoidance_segment",
            [0x2B0] = "ai_render_paths_avoidance_obstacles",
            [0x2B1] = "ai_render_paths_avoidance_search",
            [0x2B2] = "ai_render_paths_nodes",
            [0x2B3] = "ai_render_paths_nodes_all",
            [0x2B4] = "ai_render_paths_nodes_polygons",
            [0x2B5] = "ai_render_paths_nodes_costs",
            [0x2B6] = "ai_render_paths_nodes_closest",
            [0x2B7] = "ai_render_paths_distance",
            [0x2B8] = "ai_render_player_aiming_blocked",
            [0x2B9] = "ai_render_squad_patrol_state",
            [0x2BA] = "ai_render_deceleration_obstacles",
            [0x2BB] = "ai_render_recent_obstacles",
            [0x2BC] = "ai_render_combat_range",
            [0x2BD] = "ai_render_dynamic_firing_positions",
            [0x2BE] = "ai_render_clumps",
            [0x2BF] = "ai_render_clump_props",
            [0x2C0] = "ai_render_clump_props_all",
            [0x2C1] = "ai_render_clump_dialogue",
            [0x2C2] = "ai_render_sectors",
            [0x2C3] = "ai_render_sector_bsps",
            [0x2C4] = "ai_render_giant_sector_bsps",
            [0x2C5] = "ai_render_sector_link_errors",
            [0x2C6] = "ai_render_intersection_links",
            [0x2C7] = "ai_render_non_walkable_sectors",
            [0x2C8] = "ai_render_threshold_links",
            [0x2C9] = "ai_render_sector_geometry_errors",
            [0x2CA] = "ai_pathfinding_generation_verbose",
            [0x2CB] = "ai_render_sectors_range_max",
            [0x2CC] = "ai_render_sectors_range_min",
            [0x2CD] = "ai_render_link_specific",
            [0x2CE] = "ai_render_links",
            [0x2CF] = "ai_render_user_hints",
            [0x2D0] = "ai_render_area_flight_hints",
            [0x2D1] = "ai_render_hints",
            [0x2D2] = "ai_render_hints_detailed",
            [0x2D3] = "ai_render_object_hints",
            [0x2D4] = "ai_render_object_hints_all",
            [0x2D5] = "ai_render_object_properties",
            [0x2D6] = "ai_render_hints_movement",
            [0x2D7] = "ai_orders_print_entries",
            [0x2D8] = "ai_orders_print_entries_verbose",
            [0x2D9] = "ai_render_orders",
            [0x2DA] = "ai_render_suppress_combat",
            [0x2DB] = "ai_render_squad_patrol",
            [0x2DC] = "ai_render_formations",
            [0x2DD] = "ai_render_objectives",
            [0x2DE] = "ai_render_strength",
            [0x2DF] = "ai_render_squad_fronts",
            [0x2E0] = "ai_render_squad_fronts_detailed",
            [0x2E1] = "ai_render_ai_iterator",
            [0x2E2] = "ai_render_child_stack",
            [0x2E3] = "ai_render_behavior_stack",
            [0x2E4] = "ai_render_behavior_stack_all",
            [0x2E5] = "ai_render_stimuli",
            [0x2E6] = "ai_render_combat_status",
            [0x2E7] = "ai_render_decisions",
            [0x2E8] = "ai_render_decisions_all",
            [0x2E9] = "ai_render_command_scripts",
            [0x2EA] = "ai_render_script_data",
            [0x2EB] = "ai_hide_actor_errors",
            [0x2EC] = "ai_debug_tracking_data",
            [0x2ED] = "ai_debug_perception_data",
            [0x2EE] = "ai_debug_combat_status",
            [0x2EF] = "ai_render_tracked_props",
            [0x2F0] = "ai_render_tracked_props_all",
            [0x2F1] = "ai_debug_vignettes",
            [0x2F2] = "ai_render_joint_behaviors",
            [0x2F3] = "ai_render_swarm",
            [0x2F4] = "ai_render_flocks",
            [0x2F5] = "ai_render_vehicle_interest",
            [0x2F6] = "ai_render_player_battle_vector",
            [0x2F7] = "ai_render_player_needs_vehicle",
            [0x2F8] = "ai_debug_prop_refresh",
            [0x2F9] = "ai_debug_all_disposable",
            [0x2FA] = "ai_current_squad",
            [0x2FB] = "ai_current_actor",
            [0x2FC] = "ai_render_vehicle_turns",
            [0x2FD] = "ai_render_discarded_firing_positions",
            [0x2FE] = "ai_render_firing_positions_all",
            [0x2FF] = "ai_render_firing_position_info",
            [0x300] = "ai_inspect_avoidance_failure",
            [0x301] = "ai_render_action_selection_failure",
            [0x302] = "ai_combat_status_asleep",
            [0x303] = "ai_combat_status_idle",
            [0x304] = "ai_combat_status_alert",
            [0x305] = "ai_combat_status_active",
            [0x306] = "ai_combat_status_uninspected",
            [0x307] = "ai_combat_status_definite",
            [0x308] = "ai_combat_status_certain",
            [0x309] = "ai_combat_status_visible",
            [0x30A] = "ai_combat_status_clear_los",
            [0x30B] = "ai_combat_status_dangerous",
            [0x30C] = "ai_task_status_never",
            [0x30D] = "ai_task_status_occupied",
            [0x30E] = "ai_task_status_empty",
            [0x30F] = "ai_task_status_inactive",
            [0x310] = "ai_task_status_exhausted",
            [0x311] = "ai_evaluator_preference",
            [0x312] = "ai_evaluator_avoidance",
            [0x313] = "ai_evaluator_sum",
            [0x314] = "ai_evaluator_pathfinding",
            [0x315] = "ai_evaluator_preferred_group",
            [0x316] = "ai_evaluator_pursuit_walkdistance",
            [0x317] = "ai_evaluator_pursuit_targetdistance",
            [0x318] = "ai_evaluator_pursuit_targethint",
            [0x319] = "ai_evaluator_pursuit_visible",
            [0x31A] = "ai_evaluator_pursuit_examined_us",
            [0x31B] = "ai_evaluator_pursuit_examined_total",
            [0x31C] = "ai_evaluator_pursuit_available",
            [0x31D] = "ai_evaluator_panic_walkdistance",
            [0x31E] = "ai_evaluator_panic_targetdistance",
            [0x31F] = "ai_evaluator_panic_closetotarget",
            [0x320] = "ai_evaluator_guard_walkdistance",
            [0x321] = "ai_evaluator_attack_weaponrange",
            [0x322] = "ai_evaluator_attack_idealrange",
            [0x323] = "ai_evaluator_attack_visible",
            [0x324] = "ai_evaluator_attack_dangerousenemy",
            [0x325] = "ai_evaluator_combatmove_walkdistance",
            [0x326] = "ai_evaluator_combatmove_lineoffire",
            [0x327] = "ai_evaluator_hide_cover",
            [0x328] = "ai_evaluator_hide_exposed",
            [0x329] = "ai_evaluator_uncover_pre_evaluate",
            [0x32A] = "ai_evaluator_uncover_visible",
            [0x32B] = "ai_evaluator_uncover_blocked",
            [0x32C] = "ai_evaluator_previously_discarded",
            [0x32D] = "ai_evaluator_danger_zone",
            [0x32E] = "ai_evaluator_move_into_danger_zone",
            [0x32F] = "ai_evaluator_3d_path_available",
            [0x330] = "ai_evaluator_point_avoidance",
            [0x331] = "ai_evaluator_point_preference",
            [0x332] = "ai_evaluator_directional_driving",
            [0x333] = "ai_evaluator_favor_former_firing_position",
            [0x334] = "ai_evaluator_hide_pre_evaluation",
            [0x335] = "ai_evaluator_pursuit",
            [0x336] = "ai_evaluator_pursuit_area_discarded",
            [0x337] = "ai_evaluator_flag_preferences",
            [0x338] = "ai_evaluator_perch_preferences",
            [0x339] = "ai_evaluator_combatmove_lineoffire_occluded",
            [0x33A] = "ai_evaluator_attack_same_frame_of_reference",
            [0x33B] = "ai_evaluator_wall_leanable",
            [0x33C] = "ai_evaluator_cover_near_friends",
            [0x33D] = "ai_evaluator_combat_move_near_follow_unit",
            [0x33E] = "ai_evaluator_goal_preferences",
            [0x33F] = "ai_evaluator_hint_plane",
            [0x340] = "ai_evaluator_postsearch_prefer_original",
            [0x341] = "ai_evaluator_leadership",
            [0x342] = "ai_evaluator_flee_to_leader",
            [0x343] = "ai_evaluator_goal_points_only",
            [0x344] = "ai_evaluator_attack_leader_distance",
            [0x345] = "ai_evaluator_too_far_from_leader",
            [0x346] = "ai_evaluator_guard_preference",
            [0x347] = "ai_evaluator_guard_wall_preference",
            [0x348] = "ai_evaluator_obstacle",
            [0x349] = "ai_evaluator_facing",
            [0x34A] = "ai_evaluator_hide_equipment",
            [0x34B] = "ai_action_berserk",
            [0x34C] = "ai_action_surprise_front",
            [0x34D] = "ai_action_surprise_back",
            [0x34E] = "ai_action_evade_left",
            [0x34F] = "ai_action_evade_right",
            [0x350] = "ai_action_dive_forward",
            [0x351] = "ai_action_dive_back",
            [0x352] = "ai_action_dive_left",
            [0x353] = "ai_action_dive_right",
            [0x354] = "ai_action_advance",
            [0x355] = "ai_action_cheer",
            [0x356] = "ai_action_fallback",
            [0x357] = "ai_action_hold",
            [0x358] = "ai_action_point",
            [0x359] = "ai_action_posing",
            [0x35A] = "ai_action_shakefist",
            [0x35B] = "ai_action_signal_attack",
            [0x35C] = "ai_action_signal_move",
            [0x35D] = "ai_action_taunt",
            [0x35E] = "ai_action_warn",
            [0x35F] = "ai_action_wave",
            [0x360] = "ai_activity_none",
            [0x361] = "ai_activity_patrol",
            [0x362] = "ai_activity_stand",
            [0x363] = "ai_activity_crouch",
            [0x364] = "ai_activity_stand_drawn",
            [0x365] = "ai_activity_crouch_drawn",
            [0x366] = "ai_activity_corner",
            [0x367] = "ai_activity_corner_open",
            [0x368] = "ai_activity_bunker",
            [0x369] = "ai_activity_bunker_open",
            [0x36A] = "ai_activity_combat",
            [0x36B] = "ai_activity_backup",
            [0x36C] = "ai_activity_guard",
            [0x36D] = "ai_activity_guard_crouch",
            [0x36E] = "ai_activity_guard_wall",
            [0x36F] = "ai_activity_typing",
            [0x370] = "ai_activity_kneel",
            [0x371] = "ai_activity_gaze",
            [0x372] = "ai_activity_poke",
            [0x373] = "ai_activity_sniff",
            [0x374] = "ai_activity_track",
            [0x375] = "ai_activity_watch",
            [0x376] = "ai_activity_examine",
            [0x377] = "ai_activity_sleep",
            [0x378] = "ai_activity_at_ease",
            [0x379] = "ai_activity_cower",
            [0x37A] = "ai_activity_tai_chi",
            [0x37B] = "ai_activity_pee",
            [0x37C] = "ai_activity_doze",
            [0x37D] = "ai_activity_eat",
            [0x37E] = "ai_activity_medic",
            [0x37F] = "ai_activity_work",
            [0x380] = "ai_activity_cheering",
            [0x381] = "ai_activity_injured",
            [0x382] = "ai_activity_captured",
            [0x383] = "morph_disallowed",
            [0x384] = "morph_time_ranged_tank",
            [0x385] = "morph_time_ranged_stealth",
            [0x386] = "morph_time_tank_ranged",
            [0x387] = "morph_time_tank_stealth",
            [0x388] = "morph_time_stealth_ranged",
            [0x389] = "morph_time_stealth_tank",
            [0x38A] = "morph_form_ranged",
            [0x38B] = "morph_form_tank",
            [0x38C] = "morph_form_stealth",
            [0x38D] = "ai_movement_patrol",
            [0x38E] = "ai_movement_asleep",
            [0x38F] = "ai_movement_combat",
            [0x390] = "ai_movement_flee",
            [0x391] = "ai_movement_flaming",
            [0x392] = "ai_movement_stunned",
            [0x393] = "ai_movement_berserk",
            [0x394] = "ai_print_major_upgrade",
            [0x395] = "ai_print_evaluation_statistics",
            [0x396] = "ai_print_communication",
            [0x397] = "ai_print_communication_player",
            [0x398] = "ai_print_vocalizations",
            [0x399] = "ai_print_placement",
            [0x39A] = "ai_print_speech",
            [0x39B] = "ai_print_allegiance",
            [0x39C] = "ai_print_lost_speech",
            [0x39D] = "ai_print_migration",
            [0x39E] = "ai_print_scripting",
            [0x39F] = "ai_print_disposal",
            [0x3A0] = "ai_print_killing_sprees",
            [0x3A1] = "ai_naimad_spew",
            [0x3A2] = "ai_maxd_spew",
            [0x3A3] = "ai_debug_fast_los",
            [0x3A4] = "ai_debug_evaluate_all_positions",
            [0x3A5] = "ai_debug_path",
            [0x3A6] = "ai_debug_path_start_freeze",
            [0x3A7] = "ai_debug_path_end_freeze",
            [0x3A8] = "ai_debug_path_flood",
            [0x3A9] = "ai_debug_path_maximum_radius",
            [0x3AA] = "ai_debug_path_attractor",
            [0x3AB] = "ai_debug_path_attractor_radius",
            [0x3AC] = "ai_debug_path_attractor_weight",
            [0x3AD] = "ai_debug_path_accept_radius",
            [0x3AE] = "ai_debug_path_radius",
            [0x3AF] = "ai_debug_path_destructible",
            [0x3B0] = "ai_debug_path_giant",
            [0x3B1] = "ai_debug_ballistic_lineoffire_freeze",
            [0x3B2] = "ai_debug_path_naive_estimate",
            [0x3B3] = "ai_debug_blind",
            [0x3B4] = "ai_debug_deaf",
            [0x3B5] = "ai_debug_invisible_player",
            [0x3B6] = "ai_debug_ignore_player",
            [0x3B7] = "ai_debug_force_all_active",
            [0x3B8] = "ai_debug_path_disable_smoothing",
            [0x3B9] = "ai_debug_path_disable_obstacle_avoidance",
            [0x3BA] = "net_bitstream_debug",
            [0x3BB] = "net_bitstream_display_errors",
            [0x3BC] = "net_bitstream_capture_structure",
            [0x3BD] = "net_never_timeout",
            [0x3BE] = "net_use_local_time",
            [0x3BF] = "net_traffic_warnings",
            [0x3C0] = "net_traffic_print",
            [0x3C1] = "net_messages_print",
            [0x3C2] = "net_replication_requests_print",
            [0x3C3] = "net_packet_print_mask",
            [0x3C4] = "net_experimental",
            [0x3C5] = "net_rate_unlimited",
            [0x3C6] = "net_rate_server",
            [0x3C7] = "net_rate_client",
            [0x3C8] = "net_window_unlimited",
            [0x3C9] = "net_window_size",
            [0x3CA] = "net_bandwidth_unlimited",
            [0x3CB] = "net_bandwidth_per_channel",
            [0x3CC] = "unknown3CC",
            [0x3CD] = "unknown3CD",
            [0x3CE] = "unknown3CE",
            [0x3CF] = "unknown3CF",
            [0x3D0] = "unknown3D0",
            [0x3D1] = "unknown3D1",
            [0x3D2] = "net_maximum_machine_count",
            [0x3D3] = "net_maximum_player_count",
            [0x3D4] = "net_debug_random_seeds",
            [0x3D5] = "net_allow_out_of_sync",
            [0x3D6] = "net_distributed_always",
            [0x3D7] = "net_distributed_never",
            [0x3D8] = "net_matchmaking_force_gather",
            [0x3D9] = "net_matchmaking_force_search",
            [0x3DA] = "net_matchmaking_fail_arbitration",
            [0x3DB] = "net_connectivity_model_enabled",
            [0x3DC] = "net_nat_override",
            [0x3DD] = "net_matchmaking_nat_check_enabled",
            [0x3DE] = "net_matchmaking_hopper_id_adjustment",
            [0x3DF] = "net_matchmaking_use_last_map_and_game",
            [0x3E0] = "net_matchmaking_allow_early_start",
            [0x3E1] = "net_matchmaking_skip_host_migration",
            [0x3E2] = "net_matchmaking_force_disband",
            [0x3E3] = "net_enable_host_migration_loop",
            [0x3E4] = "net_matchmaking_fake_progress",
            [0x3E5] = "net_matchmaking_force_no_joining",
            [0x3E6] = "net_matchmaking_allow_idle_controllers",
            [0x3E7] = "net_simulation_set_stream_bandwidth",
            [0x3E8] = "net_set_channel_disconnect_interval",
            [0x3E9] = "net_enable_block_detection",
            [0x3EA] = "net_override_base_xp",
            [0x3EB] = "net_override_ranked_games_played",
            [0x3EC] = "net_matchmaking_mask_maps",
            [0x3ED] = "net_status_memory",
            [0x3EE] = "net_status_link",
            [0x3EF] = "net_status_sim",
            [0x3F0] = "net_status_channels",
            [0x3F1] = "net_status_connections",
            [0x3F2] = "net_status_message_queues",
            [0x3F3] = "net_status_observer",
            [0x3F4] = "net_status_sessions",
            [0x3F5] = "net_status_leaderboard",
            [0x3F6] = "net_status_leaderboard_mask",
            [0x3F7] = "net_test",
            [0x3F8] = "net_test_rate",
            [0x3F9] = "net_test_update_server",
            [0x3FA] = "net_test_update_client",
            [0x3FB] = "net_test_replication_scheduler",
            [0x3FC] = "net_test_debug_spheres",
            [0x3FD] = "net_test_matchmaking_playlist_index",
            [0x3FE] = "net_voice_diagnostics",
            [0x3FF] = "net_http_failure_ratio",
            [0x400] = "net_show_network_quality",
            [0x401] = "net_fake_network_quality",
            [0x402] = "sim_status_world",
            [0x403] = "sim_status_views",
            [0x404] = "sim_entity_validate",
            [0x405] = "sim_disable_aim_assist",
            [0x406] = "sim_bandwidth_eater",
            [0x407] = "debug_player_teleport",
            [0x408] = "debug_players",
            [0x409] = "debug_player_input",
            [0x40A] = "debug_survival_mode",
            [0x40B] = "display_rumble_status_lines",
            [0x40C] = "enable_pc_joystick",
            [0x40D] = "texture_cache_show_mipmap_bias",
            [0x40E] = "texture_cache_graph",
            [0x40F] = "texture_cache_list",
            [0x410] = "texture_cache_force_low_detail",
            [0x411] = "texture_cache_force_medium_detail",
            [0x412] = "texture_cache_force_high_detail",
            [0x413] = "texture_cache_status",
            [0x414] = "texture_cache_usage",
            [0x415] = "texture_cache_block_warning",
            [0x416] = "texture_cache_lod_bias",
            [0x417] = "texture_cache_dynamic_low_detail_texture",
            [0x418] = "render_debug_low_res_textures",
            [0x419] = "geometry_cache_graph",
            [0x41A] = "geometry_cache_list",
            [0x41B] = "geometry_cache_status",
            [0x41C] = "geometry_cache_block_warning",
            [0x41D] = "geometry_cache_never_block",
            [0x41E] = "geometry_cache_debug_display",
            [0x41F] = "director_camera_switch_fast",
            [0x420] = "director_camera_switch_disable",
            [0x421] = "director_camera_speed_scale",
            [0x422] = "director_disable_first_person",
            [0x423] = "director_use_dt",
            [0x424] = "observer_collision_enabled",
            [0x425] = "observer_collision_anticipation_enabled",
            [0x426] = "observer_collision_water_flags",
            [0x427] = "g_observer_wave_height",
            [0x428] = "debug_recording",
            [0x429] = "debug_recording_newlines",
            [0x42A] = "cinematic_letterbox_style",
            [0x42B] = "run_game_scripts",
            [0x42C] = "vehicle_status_display",
            [0x42D] = "vehicle_disable_suspension_animations",
            [0x42E] = "vehicle_disable_acceleration_screens",
            [0x42F] = "biped_meter_display",
            [0x430] = "display_verbose_disk_usage",
            [0x431] = "display_disk_usage",
            [0x432] = "default_scenario_ai_type",
            [0x433] = "debug_menu_enabled",
            [0x434] = "catch_exceptions",
            [0x435] = "debug_first_person_hide_base",
            [0x436] = "debug_first_person_hide_movement",
            [0x437] = "debug_first_person_hide_jitter",
            [0x438] = "debug_first_person_hide_overlay",
            [0x439] = "debug_first_person_hide_pitch_turn",
            [0x43A] = "debug_first_person_hide_ammo",
            [0x43B] = "debug_first_person_hide_ik",
            [0x43C] = "global_playtest_mode",
            [0x43D] = "g_override_logon_task",
            [0x43E] = "g_logon_task_override_result_code",
            [0x43F] = "ui_time_scale",
            [0x440] = "ui_display_memory",
            [0x441] = "ui_memory_verify",
            [0x442] = "xov_display_memory",
            [0x443] = "gui_debug_text_bounds_global",
            [0x444] = "gui_debug_bitmap_bounds_global",
            [0x445] = "gui_debug_model_bounds_global",
            [0x446] = "gui_debug_list_item_bounds_global",
            [0x447] = "gui_debug_list_bounds_global",
            [0x448] = "gui_debug_group_bounds_global",
            [0x449] = "gui_debug_screen_bounds_global",
            [0x44A] = "render_comment_flags",
            [0x44B] = "render_comment_flags_text",
            [0x44C] = "render_comment_flags_look_at",
            [0x44D] = "enable_controller_flag_drop",
            [0x44E] = "sapien_keyboard_toggle_for_camera_movement",
            [0x44F] = "override_player_representation_index",
            [0x450] = "e3",
            [0x451] = "debug_tag_dependencies",
            [0x452] = "disable_network_hopper_download",
            [0x453] = "disable_network_configuration_download",
            [0x454] = "check_system_heap",
            [0x455] = "data_mine_player_update_interval",
            [0x456] = "data_mine_mp_player_update_interval",
            [0x457] = "data_mine_debug_menu_interval",
            [0x458] = "data_mine_spam_enabled",
            [0x459] = "webstats_file_zip_writes_per_frame",
            [0x45A] = "debug_projectiles",
            [0x45B] = "debug_damage_effects",
            [0x45C] = "debug_damage_effect_obstacles",
            [0x45D] = "force_player_walking",
            [0x45E] = "unit_animation_report_missing_animations",
            [0x45F] = "font_cache_status",
            [0x460] = "font_cache_debug_texture",
            [0x461] = "font_cache_debug_graph",
            [0x462] = "font_cache_debug_list",
            [0x463] = "lruv_lirp_enabled",
            [0x464] = "halt_on_stack_overflow",
            [0x465] = "disable_progress_screen",
            [0x466] = "render_thread_enable",
            [0x467] = "character_force_physics",
            [0x468] = "enable_new_ik_method",
            [0x469] = "animation_throttle_dampening_scale",
            [0x46A] = "animation_blend_change_scale",
            [0x46B] = "biped_fitting_enable",
            [0x46C] = "biped_fitting_root_offset_enable",
            [0x46D] = "biped_pivot_enable",
            [0x46E] = "biped_pivot_allow_player",
            [0x46F] = "giant_hunt_player",
            [0x470] = "giant_hunting_min_radius",
            [0x471] = "giant_hunting_max_radius",
            [0x472] = "giant_hunting_throttle_scale",
            [0x473] = "giant_weapon_wait_time",
            [0x474] = "giant_weapon_trigger_time",
            [0x475] = "giant_ik",
            [0x476] = "giant_foot_ik",
            [0x477] = "giant_ankle_ik",
            [0x478] = "giant_elevation_control",
            [0x479] = "giant_force_buckle",
            [0x47A] = "giant_force_crouch",
            [0x47B] = "giant_force_death",
            [0x47C] = "giant_buckle_rotation",
            [0x47D] = "debug_objects_giant_feet",
            [0x47E] = "debug_objects_giant_buckle",
            [0x47F] = "enable_xsync_timings",
            [0x480] = "allow_restricted_tag_groups_to_load",
            [0x481] = "xsync_restricted_tag_groups",
            [0x482] = "enable_cache_build_resources",
            [0x483] = "xma_compression_level_default",
            [0x484] = "enable_console_window",
            [0x485] = "display_colors_in_banded_gamma",
            [0x486] = "use_tool_command_legacy",
            [0x487] = "maximum_tool_command_history",
            [0x488] = "disable_unit_aim_screens",
            [0x489] = "disable_unit_look_screens",
            [0x48A] = "disable_unit_eye_tracking",
            [0x48B] = "enable_tag_resource_xsync",
            [0x48C] = "dont_recompile_shaders",
            [0x48D] = "use_temp_directory_for_files",
            [0x48E] = "scenario_load_all_tags",
            [0x48F] = "synchronization_debug",
            [0x490] = "profiler_pulse_rates",
            [0x491] = "profiler_collection_interval",
            [0x492] = "debug_objects_scenery",
            [0x493] = "disable_switch_zone_sets",
            [0x494] = "facial_animation_testing_enabled",
            [0x495] = "profiler_datamine_uploads_enabled",
            [0x496] = "debug_object_recycling",
            [0x497] = "enable_sound_over_network",
            [0x498] = "lsp_allow_lsp_connections",
            [0x499] = "lsp_allow_raw_connections",
            [0x49A] = "lsp_service_id_override",
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
            [0x4A5] = "aiming_interpolation_stop_delta",
            [0x4A6] = "aiming_interpolation_start_delta",
            [0x4A7] = "aiming_interpolation_rate",
            [0x4A8] = "airborne_arc_enabled",
            [0x4A9] = "airborne_descent_test_duration",
            [0x4AA] = "airborne_descent_test_count",
            [0x4AB] = "enable_amortized_prediction",
            [0x4AC] = "amortized_prediction_object_batch_size",
            [0x4AD] = "enable_tag_resource_prediction",
            [0x4AE] = "enable_entire_pvs_prediction",
            [0x4AF] = "enable_cluster_objects_prediction",
            [0x4B0] = "disable_main_loop_throttle",
            [0x4B1] = "force_unit_walking",
            [0x4B2] = "leap_force_start_rotation",
            [0x4B3] = "leap_force_end_rotation",
            [0x4B4] = "leap_force_flight_start_rotation",
            [0x4B5] = "leap_force_flight_end_rotation",
            [0x4B6] = "leap_flight_path_scale",
            [0x4B7] = "leap_departure_power",
            [0x4B8] = "leap_departure_scale",
            [0x4B9] = "leap_arrival_power",
            [0x4BA] = "leap_arrival_scale",
            [0x4BB] = "leap_twist_power",
            [0x4BC] = "leap_cannonball_power",
            [0x4BD] = "leap_cannonball_scale",
            [0x4BE] = "leap_idle_power",
            [0x4BF] = "leap_idle_scale",
            [0x4C0] = "leap_overlay_power",
            [0x4C1] = "leap_overlay_scale",
            [0x4C2] = "leap_interpolation_limit",
            [0x4C3] = "biped_fake_soft_landing",
            [0x4C4] = "biped_fake_hard_landing",
            [0x4C5] = "biped_soft_landing_recovery_scale",
            [0x4C6] = "biped_hard_landing_recovery_scale",
            [0x4C7] = "biped_landing_absorbtion",
            [0x4C8] = "debug_player_network_aiming",
            [0x4C9] = "aim_assist_disable_target_lead_vector",
            [0x4CA] = "enable_tag_edit_sync",
            [0x4CB] = "instance_default_fade_start_pixels",
            [0x4CC] = "instance_default_fade_end_pixels",
            [0x4CD] = "render_debug_dont_flash_low_res_textures",
            [0x4CE] = "debug_objects_pendulum",
            [0x4CF] = "ui_alpha",
            [0x4D0] = "ui_alpha_lockdown",
            [0x4D1] = "ui_alpha_eula_accepted",
            [0x4D2] = "ui_alpha_custom_games_enabled",
            [0x4D3] = "net_config_client_badness_rating_threshold_override",
            [0x4D4] = "net_config_disable_bad_client_anticheating_override",
            [0x4D5] = "net_config_disable_bad_connectivity_anticheating_override",
            [0x4D6] = "net_config_disable_bad_bandwidth_anticheating_override",
            [0x4D7] = "net_config_maximum_multiplayer_split_screen_override",
            [0x4D8] = "net_config_crash_handling_minidump_type_override",
            [0x4D9] = "net_config_crash_handling_ui_display_override",
            [0x4DA] = "online_files_slowdown",
            [0x4DB] = "debug_trace_main_events",
            [0x4DC] = "force_xsync_memory_buyback",
            [0x4DD] = "bitmaps_trim_unused_pixels",
            [0x4DE] = "bitmaps_interleave_compressed_bitmaps",
            [0x4DF] = "ignore_predefined_performance_throttles",
            [0x4E0] = "enable_first_person_prediction",
            [0x4E1] = "enable_structure_prediction",
            [0x4E2] = "enable_structure_audibility",
            [0x4E3] = "debug_sound_transmission",
            [0x4E4] = "minidump_force_regular_minidump_with_ui",
            [0x4E5] = "giant_custom_anim_recovery_time",
            [0x4E6] = "facial_animation_enable_lipsync",
            [0x4E7] = "facial_animation_enable_gestures",
            [0x4E8] = "facial_animation_enable_noise",
            [0x4E9] = "render_alpha_to_coverage",
            [0x4EA] = "rasterizer_disable_vsync",
            [0x4EB] = "scale_ui_to_maintain_aspect_ratio",
            [0x4EC] = "maximum_aspect_ratio_scale_percentage",
            [0x4ED] = "enable_sound_transmission",
            [0x4EE] = "disable_audibility_generation",
            [0x4EF] = "motion_blur_expected_dt",
            [0x4F0] = "motion_blur_max_x",
            [0x4F1] = "motion_blur_max_y",
            [0x4F2] = "motion_blur_scale_x",
            [0x4F3] = "motion_blur_scale_y",
            [0x4F4] = "motion_blur_center_falloff",
            [0x4F5] = "unicode_warn_on_truncation",
            [0x4F6] = "debug_determinism_version",
            [0x4F7] = "debug_determinism_compatible_version",
            [0x4F8] = "error_geometry_environment_enabled",
            [0x4F9] = "error_geometry_lightmap_enabled",
            [0x4FA] = "error_geometry_seam_enabled",
            [0x4FB] = "error_geometry_instance_enabled",
            [0x4FC] = "error_geometry_object_enabled",
            [0x4FD] = "debug_objects_unit_melee",
            [0x4FE] = "force_buffer_2_frames",
            [0x4FF] = "disable_render_state_cache_optimization",
            [0x500] = "utility_drive_enabled",
            [0x501] = "debug_objects_root_node_print",
            [0x502] = "enable_better_cpu_gpu_sync",
            [0x503] = "require_secure_cache_files",
            [0x504] = "debug_aim_assist_targets_enabled",
            [0x505] = "motion_blur_max_viewport_count",
            [0x506] = "cinematic_prediction_enable",
            [0x507] = "render_debug_cortana_ticks",
            [0x508] = "skies_delete_on_zone_set_switch_enable",
            [0x509] = "reduce_widescreen_fov_during_cinematics",
            [0x50A] = "unknown50A",
            [0x50B] = "unknown50B",
            [0x50C] = "unknown50C",
            [0x50D] = "unknown50D",
            [0x50E] = "unknown50E",
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
            [0x51A] = "survival_performance_mode",
            [0x51B] = "unknown51B",
            [0x51C] = "unknown51C",
            [0x51D] = "unknown51D",
            [0x51E] = "load_time_multiplier",
            [0x51F] = "unknown51F",
            [0x520] = "unknown520",
            [0x521] = "unknown521",
            [0x522] = "unknown522",
        };

        public static Dictionary<int, ScriptInfo> Scripts = new Dictionary<int, ScriptInfo>
        {
            [0x000] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "begin"),
            [0x001] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "begin_random"),
            [0x002] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "if"),
            [0x003] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "cond"),
            [0x004] = new ScriptInfo(HsType.HaloOnlineValue.Passthrough, "set"),
            [0x005] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "and"),
            [0x006] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "or"),
            [0x007] = new ScriptInfo(HsType.HaloOnlineValue.Real, "+"),
            [0x008] = new ScriptInfo(HsType.HaloOnlineValue.Real, "-"),
            [0x009] = new ScriptInfo(HsType.HaloOnlineValue.Real, "*"),
            [0x00A] = new ScriptInfo(HsType.HaloOnlineValue.Real, "/"),
            [0x00B] = new ScriptInfo(HsType.HaloOnlineValue.Real, "%"),
            [0x00C] = new ScriptInfo(HsType.HaloOnlineValue.Real, "min"),
            [0x00D] = new ScriptInfo(HsType.HaloOnlineValue.Real, "max"),
            [0x00E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "="),
            [0x00F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "!="),
            [0x010] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, ">"),
            [0x011] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "<"),
            [0x012] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, ">="),
            [0x013] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "<="),
            [0x014] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sleep"),
            [0x015] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sleep_forever"),
            [0x016] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "sleep_until"),
            [0x017] = new ScriptInfo(HsType.HaloOnlineValue.Void, "wake"),
            [0x018] = new ScriptInfo(HsType.HaloOnlineValue.Void, "inspect"),
            [0x019] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x01A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "evaluate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Script),
            },
            [0x01B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "not")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x01C] = new ScriptInfo(HsType.HaloOnlineValue.Real, "pin")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x01D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "print")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x01E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "log_print")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x01F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_show_thread")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x020] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_script_thread")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x021] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x022] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_globals")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x023] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_variable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x024] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_scripting_variable_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x025] = new ScriptInfo(HsType.HaloOnlineValue.Void, "breakpoint")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x026] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_active_scripts"),
            [0x027] = new ScriptInfo(HsType.HaloOnlineValue.Long, "get_executing_running_thread"),
            [0x028] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_thread")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x029] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "script_started")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x02A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "script_finished")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x02B] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "players"),
            [0x02C] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "player_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x02D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_volume_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x02E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "kill_volume_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x02F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "volume_teleport_players_not_inside")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x030] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x031] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x032] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_objects_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x033] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x034] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "volume_test_players_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x035] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "volume_return_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
            },
            [0x036] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "volume_return_objects_by_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x037] = new ScriptInfo(HsType.HaloOnlineValue.Void, "zone_set_trigger_volume_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x038] = new ScriptInfo(HsType.HaloOnlineValue.Object, "list_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x039] = new ScriptInfo(HsType.HaloOnlineValue.Short, "list_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x03A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "list_count_not_dead")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x03B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x03C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_random")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x03D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_at_ai_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x03E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_on_object_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x03F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "effect_new_on_ground")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Effect),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x040] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x041] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_object_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x042] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_objects_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x043] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x044] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x045] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Damage),
            },
            [0x046] = new ScriptInfo(HsType.HaloOnlineValue.Void, "soft_ceiling_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x047] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x048] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_clone")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x049] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_anew")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x04A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_if_necessary")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x04B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_containing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x04C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_clone_containing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x04D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_anew_containing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x04E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_folder")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x04F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_create_folder_anew")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x050] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x051] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy_containing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x052] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy_all"),
            [0x053] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy_type_mask")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x054] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_delete_by_definition")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x055] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_destroy_folder")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Folder),
            },
            [0x056] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_hide")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x057] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shadowless")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x058] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_buckling_magnitude_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x059] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_function_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x05A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_function_variable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x05B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_clear_function_variable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x05C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_clear_all_function_variables")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x05D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_dynamic_simulation_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x05E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_phantom_power")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x05F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_wake_physics")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x060] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_ranged_attack_inhibited")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x061] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_melee_attack_inhibited")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x062] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_dump_memory"),
            [0x063] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_get_health")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x064] = new ScriptInfo(HsType.HaloOnlineValue.Real, "object_get_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x065] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x066] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_physics")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x067] = new ScriptInfo(HsType.HaloOnlineValue.Object, "object_get_parent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x068] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_attach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x069] = new ScriptInfo(HsType.HaloOnlineValue.Object, "object_at_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x06A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_detach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x06B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_scale")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x06C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_velocity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x06D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_inertia_tensor_scale")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x06E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_collision_damage_armor_scale")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x06F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_velocity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x070] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_deleted_when_deactivated")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x071] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "object_model_target_destroyed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x072] = new ScriptInfo(HsType.HaloOnlineValue.Short, "object_model_targets_destroyed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x073] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_damage_damage_section")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x074] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cannot_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x075] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "object_vitality_pinned")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x076] = new ScriptInfo(HsType.HaloOnlineValue.Void, "garbage_collect_now"),
            [0x077] = new ScriptInfo(HsType.HaloOnlineValue.Void, "garbage_collect_unsafe"),
            [0x078] = new ScriptInfo(HsType.HaloOnlineValue.Void, "garbage_collect_multiplayer"),
            [0x079] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cannot_take_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x07A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_can_take_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x07B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cinematic_lod")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x07C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cinematic_collision")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x07D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_cinematic_visibility")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x07E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x07F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_predict_high")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x080] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objects_predict_low")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x081] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_type_predict_high")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x082] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_type_predict_low")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x083] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_type_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x084] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x085] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_teleport_to_ai_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x086] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_facing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x087] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x088] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield_normalized")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x089] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield_stun")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x08A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_shield_stun_infinite")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x08B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_permutation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x08C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x08D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_region_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ModelState),
            },
            [0x08E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "objects_can_see_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x08F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "objects_can_see_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x090] = new ScriptInfo(HsType.HaloOnlineValue.Real, "objects_distance_to_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x091] = new ScriptInfo(HsType.HaloOnlineValue.Real, "objects_distance_to_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x092] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_info"),
            [0x093] = new ScriptInfo(HsType.HaloOnlineValue.Void, "position_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x094] = new ScriptInfo(HsType.HaloOnlineValue.Void, "shader_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Shader),
            },
            [0x095] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bitmap_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Bitmap),
            },
            [0x096] = new ScriptInfo(HsType.HaloOnlineValue.Void, "script_recompile"),
            [0x097] = new ScriptInfo(HsType.HaloOnlineValue.Void, "script_doc"),
            [0x098] = new ScriptInfo(HsType.HaloOnlineValue.Void, "help")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x099] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "game_engine_objects"),
            [0x09A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "random_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x09B] = new ScriptInfo(HsType.HaloOnlineValue.Real, "real_random_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x09C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_constants_reset"),
            [0x09D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_set_gravity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x09E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_set_velocity_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x09F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physics_disable_character_ground_adhesion_forces")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_debug_start"),
            [0x0A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_dump_world")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_dump_world_close_movie"),
            [0x0A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_profile_start"),
            [0x0A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_profile_stop"),
            [0x0A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_profile_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "havok_reset_allocated_state"),
            [0x0A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "breakable_surfaces_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "breakable_surfaces_reset"),
            [0x0A9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "recording_play")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneRecording),
            },
            [0x0AA] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "recording_play_and_delete")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneRecording),
            },
            [0x0AB] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "recording_play_and_hover")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneRecording),
            },
            [0x0AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "recording_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0AD] = new ScriptInfo(HsType.HaloOnlineValue.Short, "recording_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0AE] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "render_lights")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "print_light_state"),
            [0x0B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_lights_enable_cinematic_shadow")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_object_marker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_attach_to_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_target_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_position_world_offset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_on"),
            [0x0B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_off"),
            [0x0B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_aspect_ratio")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_resolution")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_render_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_unknownBC")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_fov")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_set_fov_frame_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_camera_enable_dynamic_lights")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_on")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_off")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_set_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_set_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_attach_to_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_target_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_structure")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_highlight_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_clear_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_spin_around")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_from_player_view")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_camera_window")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_texture_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_structure_cluster")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_cluster_fog")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_plane")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_plane_infinite_extent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_zone")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_fog_zone_floodfill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x0D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_all_fog_planes")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_all_cluster_errors")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_line_opacity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_text_opacity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_opacity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_non_occluded_fog_planes")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_use_pervertex"),
            [0x0DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_use_reset"),
            [0x0DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_sample_enable"),
            [0x0DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_structure_lightmaps_sample_disable"),
            [0x0DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_object_bitmaps")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x0DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_bsp_resources")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_all_object_resources"),
            [0x0E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_query_d3d_resources"),
            [0x0E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_text_using_simple_font")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_postprocess_color_tweaking_reset"),
            [0x0E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_relative_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x0E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_relative_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x0E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_idle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
            },
            [0x0EA] = new ScriptInfo(HsType.HaloOnlineValue.Short, "scenery_get_animation_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
            },
            [0x0EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_can_blink")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_active_camo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x0ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_open")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_close")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_kill_silent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0F1] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_is_emitting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0F2] = new ScriptInfo(HsType.HaloOnlineValue.Short, "unit_get_custom_animation_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_stop_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0F4] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0F5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0F6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0F7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_relative_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x0F8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "custom_animation_list")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0F9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_custom_animation_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x0FA] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_custom_animation_relative_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x0FB] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_is_playing_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x0FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_custom_animations_hold_on_last_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_custom_animations_prevent_lipsync_head_movement")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x0FE] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "preferred_animation_list_add")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x0FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "preferred_animation_list_clear"),
            [0x100] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_actively_controlled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x101] = new ScriptInfo(HsType.HaloOnlineValue.Short, "unit_get_team_index")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x102] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_aim_without_turning")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x103] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_enterable_by_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x104] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_seat_enterable_by_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x105] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_get_enterable_by_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x106] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_only_takes_damage_from_players_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x107] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_enter_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x108] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_falling_damage_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x109] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_in_vehicle_type_mask")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x10A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "object_get_turret_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x10B] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "object_get_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x10C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_board_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x10D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_emotion")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x10E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_emotion_by_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x10F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_enable_eye_tracking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x110] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_integrated_flashlight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x111] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_voice")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x112] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_enable_vision_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x113] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_in_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x114] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_test_seat_unit_list")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x115] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_test_seat_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x116] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_test_seat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x117] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_prefer_tight_camera_track")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x118] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_exit_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x119] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_exit_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x11A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_maximum_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x11B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "units_set_maximum_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x11C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_current_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x11D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "units_set_current_vitality")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x11E] = new ScriptInfo(HsType.HaloOnlineValue.Short, "vehicle_load_magic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x11F] = new ScriptInfo(HsType.HaloOnlineValue.Short, "vehicle_unload")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x120] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_animation_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x121] = new ScriptInfo(HsType.HaloOnlineValue.Void, "magic_melee_attack"),
            [0x122] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "vehicle_riders")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x123] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "vehicle_driver")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x124] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "vehicle_gunner")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x125] = new ScriptInfo(HsType.HaloOnlineValue.Real, "unit_get_health")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x126] = new ScriptInfo(HsType.HaloOnlineValue.Real, "unit_get_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x127] = new ScriptInfo(HsType.HaloOnlineValue.Short, "unit_get_total_grenade_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x128] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x129] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_weapon_readied")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x12A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_any_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x12B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_has_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x12C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_lower_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x12D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_raise_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x12E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_drop_support_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x12F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_spew_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x130] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_force_reload")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x131] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_stats_dump"),
            [0x132] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_animation_forced_seat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x133] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_doesnt_drop_items")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
            },
            [0x134] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_impervious")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x135] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_suspended")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x136] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_add_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StartingProfile),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x137] = new ScriptInfo(HsType.HaloOnlineValue.Void, "weapon_hold_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Weapon),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x138] = new ScriptInfo(HsType.HaloOnlineValue.Void, "weapon_enable_warthog_chaingun_light")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x139] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_set_never_appears_locked")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x13A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_set_power")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x13B] = new ScriptInfo(HsType.HaloOnlineValue.Real, "device_get_power")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
            },
            [0x13C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_set_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x13D] = new ScriptInfo(HsType.HaloOnlineValue.Real, "device_get_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
            },
            [0x13E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_set_position_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x13F] = new ScriptInfo(HsType.HaloOnlineValue.Real, "device_group_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
            },
            [0x140] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_group_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x141] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_group_set_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x142] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_one_sided_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x143] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_ignore_player_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x144] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_operates_automatically_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x145] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_closes_automatically_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x146] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_group_change_only_once_more_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DeviceGroup),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x147] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_set_position_track")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x148] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_set_overlay_track")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x149] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_animate_position")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x14A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "device_animate_overlay")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x14B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_all_powerups"),
            [0x14C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_all_weapons"),
            [0x14D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_all_vehicles"),
            [0x14E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_teleport_to_camera"),
            [0x14F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_active_camouflage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x150] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheat_active_camouflage_by_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x151] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cheats_load"),
            [0x152] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop_safe")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x153] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x154] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x155] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x156] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_enabled"),
            [0x157] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_grenades")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x158] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x159] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_player_dialogue_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x15A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_infection_suppress")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x15B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_fast_and_dumb")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x15C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_log_reset"),
            [0x15D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_log_dump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x15E] = new ScriptInfo(HsType.HaloOnlineValue.Object, "ai_get_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x15F] = new ScriptInfo(HsType.HaloOnlineValue.Unit, "ai_get_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x160] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_get_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x161] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_get_turret_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x162] = new ScriptInfo(HsType.HaloOnlineValue.PointReference, "ai_random_smart_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x163] = new ScriptInfo(HsType.HaloOnlineValue.PointReference, "ai_nearest_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x164] = new ScriptInfo(HsType.HaloOnlineValue.Long, "ai_get_point_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x165] = new ScriptInfo(HsType.HaloOnlineValue.PointReference, "ai_point_set_get_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x166] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x167] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x168] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_place_in_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x169] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_cannot_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x16A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_vitality_pinned")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x16B] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_index_from_spawn_formation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x16C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_resurrect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x16D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x16E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_kill_silent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x16F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_erase")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x170] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_erase_all"),
            [0x171] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_disposable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x172] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_select")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x173] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_deselect"),
            [0x174] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_deaf")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x175] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_blind")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x176] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_weapon_up")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x177] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_flood_disperse")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x178] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_magically_see")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x179] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_magically_see_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x17A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_active_camo")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x17B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_suppress_combat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x17C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_engineer_explode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x17D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_grunt_kamikaze")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x17E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_migrate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x17F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allegiance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x180] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allegiance_remove")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x181] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allegiance_break")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x182] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_braindead")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x183] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_braindead_by_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x184] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_disregard")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x185] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_prefer_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectList),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x186] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_prefer_target_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x187] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_prefer_target_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x188] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_targeting_group")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x189] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_targeting_group")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x18A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_teleport_to_starting_location_if_outside_bsp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x18B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_teleport_to_spawn_point_if_outside_bsp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x18C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x18D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_bring_forward")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x18E] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_migrate_form")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x18F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_morph")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x190] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "biped_morph")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x191] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_renew")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x192] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_force_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x193] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_force_active_by_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x194] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_playfight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x195] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_reconnect"),
            [0x196] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_berserk")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x197] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_set_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x198] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_allow_dormant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x199] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_is_attacking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_fighting_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19B] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_living_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19C] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_living_fraction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19D] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_in_vehicle_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19E] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_body_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x19F] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_strength")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A0] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_swarm_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A1] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_nonswarm_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A2] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "ai_actors")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A3] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_allegiance_broken")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
            },
            [0x1A4] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_spawn_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1A5] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "object_get_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x1A6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_rotate_scenario")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1A7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_translate_scenario")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_duplicate_bsp_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x1A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_duplicate_bsp_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x1AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_rotate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_reflect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_translate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x1AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_rotate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x1AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_reflect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x1AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenario_translate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x1B0] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_set_task")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1B1] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_set_objective")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1B2] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_task_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B3] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_set_task_condition")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1B4] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_leadership")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_leadership_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B6] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_task_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_reset_objective")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_squad_patrol_objective_disallow")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1B9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "generate_pathfinding"),
            [0x1BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_render_paths_all"),
            [0x1BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_activity_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_activity_abort")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1BD] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1BE] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get_from_starting_location")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1BF] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get_from_spawn_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C0] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_vehicle_get_squad_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C1] = new ScriptInfo(HsType.HaloOnlineValue.Vehicle, "ai_vehicle_get_from_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1C2] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_vehicle_reserve_seat")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1C3] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_vehicle_reserve")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1C4] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "ai_player_get_vehicle_squad")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x1C5] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_vehicle_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_carrying_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1C7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_in_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x1C8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_player_needs_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x1C9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_player_any_needs_vehicle"),
            [0x1CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x1CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x1CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x1CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_enter_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x1CE] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_enter_squad_vehicles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x1D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1D1] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vehicle_overturned")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x1D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_flip")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x1D3] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1D4] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1D5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1D6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1D7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_delete")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1D8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "flock_definition_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x1D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flock_unperch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "drop_ai")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x1DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_verify_tags"),
            [0x1DC] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "ai_wall_lean")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x1DD] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x1DE] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line_at_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x1DF] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line_on_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x1E0] = new ScriptInfo(HsType.HaloOnlineValue.Real, "ai_play_line_on_object_for_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x1E1] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_play_line_on_point_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1E2] = new ScriptInfo(HsType.HaloOnlineValue.Short, "ai_play_line_on_point_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_time_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_award_points")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_award_primary_skull")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PrimarySkull),
            },
            [0x1E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_award_secondary_skull")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.SecondarySkull),
            },
            [0x1E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "campaign_metagame_award_event")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1E8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_metagame_enabled"),
            [0x1E9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_survival_enabled"),
            [0x1EA] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_is_finished_easy"),
            [0x1EB] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_is_finished_normal"),
            [0x1EC] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_is_finished_heroic"),
            [0x1ED] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "campaign_is_finished_legendary"),
            [0x1EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_run_command_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x1EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_queue_command_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x1F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stack_command_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x1F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_reserve")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_reserve")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1F3] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1F4] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1F5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1F6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x1F7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
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
            [0x1F8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
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
            [0x1F9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_cast")
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
            [0x1FA] = new ScriptInfo(HsType.HaloOnlineValue.Ai, "vs_role")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_alert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x1FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x1FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_alert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x200] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x201] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x202] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x203] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_alert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x204] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_alert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x205] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x206] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_damage")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x207] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x208] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x209] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_abort_on_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x20A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_abort_on_vehicle_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x20B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_set_cleanup_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Script),
            },
            [0x20C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_release")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x20D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_release_all"),
            [0x20E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_command_script_running")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x20F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_command_script_queued")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiCommandScript),
            },
            [0x210] = new ScriptInfo(HsType.HaloOnlineValue.Short, "cs_number_queued")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x211] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_moving"),
            [0x212] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cs_moving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x213] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_running_atom")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x214] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_running_atom_movement")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x215] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_running_atom_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x216] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "vs_running_atom_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x217] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x218] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x219] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x21A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x21B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x21C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x21D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x21E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x21F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x220] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x221] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x222] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_fly_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x223] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x224] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x225] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x226] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x227] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x228] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x229] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x22A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_by")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x22B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x22C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_and_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x22D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_and_posture")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x22E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_and_posture")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x22F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_nearest")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x230] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_nearest")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x231] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_in_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x232] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_in_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x233] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x234] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x235] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x236] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_towards")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x237] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_move_towards_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x238] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_move_towards_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x239] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_swarm_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x23A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_swarm_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x23B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_swarm_from")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x23C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_swarm_from")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x23D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x23E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x23F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_grenade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x240] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_grenade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x241] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x242] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x243] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_jump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x244] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_jump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x245] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_jump_to_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x246] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_jump_to_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x247] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vocalize")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x248] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vocalize")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x249] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x24A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x24B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x24C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x24D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x24E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x24F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x250] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x251] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_action_at_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x252] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_action_at_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x253] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_action_at_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x254] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_action_at_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x255] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x256] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x257] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x258] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x259] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x25A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x25B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x25C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_death")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x25D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x25E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x25F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x260] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_custom_animation_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x261] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_play_line")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x262] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_play_line")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AiLine),
            },
            [0x263] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x264] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_die")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x265] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_deploy_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x266] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_deploy_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x267] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_approach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x268] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_approach")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x269] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_approach_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x26A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_approach_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x26B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x26C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x26D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x26E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_go_to_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.UnitSeatMapping),
            },
            [0x26F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_set_style")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Style),
            },
            [0x270] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_set_style")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Style),
            },
            [0x271] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_force_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x272] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_force_combat_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x273] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_targeting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x274] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_enable_targeting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x275] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_looking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x276] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_enable_looking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x277] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_moving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x278] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_enable_moving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x279] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_enable_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_suppress_activity_termination")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_suppress_activity_termination")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_suppress_dialogue_global")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_suppress_dialogue_global")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x27F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x280] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x281] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_look_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x282] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_look_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x283] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_look_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x284] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_look_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x285] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_aim")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x286] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_aim")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x287] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_aim_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x288] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_aim_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x289] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_aim_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x28A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_aim_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x28B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x28C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_face")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x28D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_face_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x28E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_face_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x28F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_face_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x290] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_face_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x291] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x292] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x293] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x294] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x295] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x296] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x297] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_shoot_secondary_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x298] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_shoot_secondary_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x299] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_lower_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x29A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_lower_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x29B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vehicle_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x29C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vehicle_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x29D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vehicle_speed_instantaneous")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x29E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vehicle_speed_instantaneous")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x29F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_vehicle_boost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_vehicle_boost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_turn_sharpness")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_turn_sharpness")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_enable_pathfinding_failsafe")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_enable_pathfinding_failsafe")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_set_pathfinding_radius")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_set_pathfinding_radius")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_ignore_obstacles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_ignore_obstacles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_approach_stop"),
            [0x2AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_approach_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x2AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_movement_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_movement_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_crouch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_walk")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_walk")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_posture_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_posture_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_posture_exit"),
            [0x2B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_posture_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x2B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stow"),
            [0x2B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_stow")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x2B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_draw"),
            [0x2BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_draw")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x2BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_teleport")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
            },
            [0x2BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stop_custom_animation"),
            [0x2BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_stop_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x2BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_stop_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x2C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_stop_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x2C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_player_melee")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x2C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_player_melee")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x2C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_melee_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x2C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_melee_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x2C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cs_smash_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x2C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vs_smash_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x2C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_control")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x2CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x2CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_with_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative_with_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative_with_speed_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_animation_relative_with_speed_loop_offset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_predict_resources_at_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x2D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_predict_resources_at_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x2D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_first_person")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x2D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_cinematic"),
            [0x2D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_cinematic_scene")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicSceneDefinition),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x2D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_place_relative")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_place_worldspace"),
            [0x2D7] = new ScriptInfo(HsType.HaloOnlineValue.Short, "camera_time"),
            [0x2D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_field_of_view")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_camera_set_easing_in")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_camera_set_easing_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_print")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x2DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_pan")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_pan")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x2DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_save"),
            [0x2DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_load"),
            [0x2E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_save_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x2E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_camera_load_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x2E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "director_debug_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2E3] = new ScriptInfo(HsType.HaloOnlineValue.GameDifficulty, "game_difficulty_get"),
            [0x2E4] = new ScriptInfo(HsType.HaloOnlineValue.GameDifficulty, "game_difficulty_get_real"),
            [0x2E5] = new ScriptInfo(HsType.HaloOnlineValue.Short, "game_insertion_point_get"),
            [0x2E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_insertion_point_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x2E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_set_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x2E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_set_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x2E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_clear"),
            [0x2EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "pvs_reset"),
            [0x2EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "players_unzoom_all"),
            [0x2EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_enable_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_disable_movement")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_disable_weapon_pickup")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_disable_sprint")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_disable_equipment_use")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F1] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_flashlight_on"),
            [0x2F2] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_active_camouflage_on"),
            [0x2F3] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_camera_control")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x2F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_action_test_reset"),
            [0x2F5] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_jump"),
            [0x2F6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_primary_trigger"),
            [0x2F7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_grenade_trigger"),
            [0x2F8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_vision_trigger"),
            [0x2F9] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_rotate_weapons"),
            [0x2FA] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_rotate_grenades"),
            [0x2FB] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_melee"),
            [0x2FC] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_action"),
            [0x2FD] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_accept"),
            [0x2FE] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_cancel"),
            [0x2FF] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_up"),
            [0x300] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_down"),
            [0x301] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_left"),
            [0x302] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_right"),
            [0x303] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_look_relative_all_directions"),
            [0x304] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_move_relative_all_directions"),
            [0x305] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_back"),
            [0x306] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_left"),
            [0x307] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_right"),
            [0x308] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_up"),
            [0x309] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_dpad_down"),
            [0x30A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_x"),
            [0x30B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_y"),
            [0x30C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_left_shoulder"),
            [0x30D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_right_shoulder"),
            [0x30E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_waypoint_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x30F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_action_test_reset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x310] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_grenade_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x311] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_vision_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x312] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_rotate_weapons")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x313] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_rotate_grenades")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x314] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_melee")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x315] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_action")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x316] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_accept")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x317] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_cancel")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x318] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_up")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x319] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_down")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x31A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_left")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x31B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_right")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x31C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_look_relative_all_directions")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x31D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_move_relative_all_directions")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x31E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_back")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x31F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_left")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x320] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_right")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x321] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_up")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x322] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_dpad_down")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x323] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_x")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x324] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_y")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x325] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_left_shoulder")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x326] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_action_test_right_shoulder")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x327] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player0_looking_up"),
            [0x328] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player0_looking_down"),
            [0x329] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player0_set_pitch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x32A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player1_set_pitch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x32B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player2_set_pitch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x32C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player3_set_pitch")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x32D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_lookstick_forward"),
            [0x32E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_action_test_lookstick_backward"),
            [0x32F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_teleport_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x330] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_reset"),
            [0x331] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_reset_random"),
            [0x332] = new ScriptInfo(HsType.HaloOnlineValue.Void, "switch_bsp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x333] = new ScriptInfo(HsType.HaloOnlineValue.Void, "switch_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ZoneSet),
            },
            [0x334] = new ScriptInfo(HsType.HaloOnlineValue.Long, "current_zone_set"),
            [0x335] = new ScriptInfo(HsType.HaloOnlineValue.Long, "current_zone_set_fully_active"),
            [0x336] = new ScriptInfo(HsType.HaloOnlineValue.Void, "switch_map_and_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x337] = new ScriptInfo(HsType.HaloOnlineValue.Void, "crash")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x338] = new ScriptInfo(HsType.HaloOnlineValue.Void, "version"),
            [0x339] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status"),
            [0x33A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "record_movie")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x33B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "record_movie_distributed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x33C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x33D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_debug"),
            [0x33E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_big")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x33F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_big_raw")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x340] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_size")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x341] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_simple")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x342] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_cubemap")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x343] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_webmap")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x344] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cubemap_dynamic_generate"),
            [0x345] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_capture"),
            [0x346] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_set_path")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x347] = new ScriptInfo(HsType.HaloOnlineValue.Void, "screenshot_unknown347")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x348] = new ScriptInfo(HsType.HaloOnlineValue.Void, "main_menu"),
            [0x349] = new ScriptInfo(HsType.HaloOnlineValue.Void, "main_halt"),
            [0x34A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "map_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x34B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_multiplayer"),
            [0x34C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_set_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x34D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_splitscreen")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x34E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_difficulty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.GameDifficulty),
            },
            [0x34F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_active_primary_skulls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x350] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_active_secondary_skulls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x351] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_coop_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x352] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_initial_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x353] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_tick_rate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x354] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x355] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_start_when_ready"),
            [0x356] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_start_when_joined")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x357] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_rate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x358] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_cache_flush"),
            [0x359] = new ScriptInfo(HsType.HaloOnlineValue.Void, "geometry_cache_flush"),
            [0x35A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_cache_flush"),
            [0x35B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_cache_flush"),
            [0x35C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "font_cache_flush"),
            [0x35D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "language_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x35E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "texture_cache_test_malloc"),
            [0x35F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_memory"),
            [0x360] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_memory_by_file"),
            [0x361] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_memory_for_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x362] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_tags"),
            [0x363] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tags_verify_all"),
            [0x364] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x365] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_set_thread")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x366] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_set_sort_method")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x367] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_set_range")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x368] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_set_attribute")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x369] = new ScriptInfo(HsType.HaloOnlineValue.Void, "trace_next_frame")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x36A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "trace_next_frame_to_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x36B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "trace_tick")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x36C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "collision_log_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x36D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_control_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x36E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "damage_control_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x36F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_lines"),
            [0x370] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dialogue_break_on_vocalization")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x371] = new ScriptInfo(HsType.HaloOnlineValue.Void, "fade_in")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x372] = new ScriptInfo(HsType.HaloOnlineValue.Void, "fade_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x373] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_start"),
            [0x374] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_stop"),
            [0x375] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_skip_start_internal"),
            [0x376] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_skip_stop_internal"),
            [0x377] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_show_letterbox")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x378] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_show_letterbox_immediate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x379] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_title")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
            },
            [0x37A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_title_delayed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x37B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_suppress_bsp_object_creation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x37C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_subtitle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x37D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicDefinition),
            },
            [0x37E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_shot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicSceneDefinition),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x37F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_get_shot"),
            [0x380] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_early_exit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x381] = new ScriptInfo(HsType.HaloOnlineValue.Long, "cinematic_get_early_exit"),
            [0x382] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_active_camera")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x383] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_object_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x384] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_object_create_cinematic_anchor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x385] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_object_destroy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x386] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_destroy"),
            [0x387] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_clips_initialize_for_shot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x388] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_clips_destroy"),
            [0x389] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lights_initialize_for_shot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x38A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lights_destroy"),
            [0x38B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lights_destroy_shot"),
            [0x38C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_light_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CinematicLightprobe),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x38D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_light_object_off")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x38E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_rebuild_all"),
            [0x38F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_update_dynamic_light_direction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x390] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lighting_update_sh_light")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x391] = new ScriptInfo(HsType.HaloOnlineValue.Object, "cinematic_object_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x392] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_reset"),
            [0x393] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_briefing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x394] = new ScriptInfo(HsType.HaloOnlineValue.CinematicDefinition, "cinematic_tag_reference_get_cinematic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x395] = new ScriptInfo(HsType.HaloOnlineValue.CinematicSceneDefinition, "cinematic_tag_reference_get_scene")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x396] = new ScriptInfo(HsType.HaloOnlineValue.Effect, "cinematic_tag_reference_get_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x397] = new ScriptInfo(HsType.HaloOnlineValue.Sound, "cinematic_tag_reference_get_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x398] = new ScriptInfo(HsType.HaloOnlineValue.Sound, "cinematic_tag_reference_get_music")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x399] = new ScriptInfo(HsType.HaloOnlineValue.LoopingSound, "cinematic_tag_reference_get_music_looping")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x39A] = new ScriptInfo(HsType.HaloOnlineValue.AnimationGraph, "cinematic_tag_reference_get_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x39B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "cinematic_scripting_object_coop_flags_valid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x39C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_fade_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x39D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x39E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_cinematic_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x39F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_destroy_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x3A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_music")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_dialogue")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x3A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_stop_music")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_cinematic_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_object_no_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_create_and_animate_cinematic_object_no_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_play_cortana_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "attract_mode_start"),
            [0x3AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "attract_mode_set_seconds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_level_advance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_won"),
            [0x3AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_lost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_revert"),
            [0x3B0] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_is_cooperative"),
            [0x3B1] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_is_playtest"),
            [0x3B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_can_use_flashlights")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_and_quit"),
            [0x3B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_unsafe"),
            [0x3B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_insertion_point_unlock")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x3B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_insertion_point_lock")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x3B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_games_enumerate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x3B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_games_delete_campaign_save")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x3B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_games_save_last_film")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x3BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_games_autosave_free_up_space"),
            [0x3BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "content_catalogue_display_status")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievement_grant_to_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievement_grant_to_all_players")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievements_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievements_skip_validation_checks")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_influencers")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_respawn_zones")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_proximity_forbid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_moving_vehicle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_weapon_influences")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_dangerous_projectiles")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_deployed_equipment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_proximity_enemy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_teammates")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_random_influence")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_nominal_weight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_natural_weight")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_spawning_use_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_initial_spawn_point_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_respawn_point_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_export_variant_settings")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_general")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_flavor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_slayer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_ctf")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_oddball")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_king")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_vip")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_juggernaut")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_territories")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_assault")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_engine_event_test_infection")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load"),
            [0x3DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_save"),
            [0x3DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_save_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load_game"),
            [0x3E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_load_game_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_regular_upload_to_debug_server")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "core_set_upload_option")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x3E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "force_debugger_not_present")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "force_debugger_always_present")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x3E6] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_safe_to_save"),
            [0x3E7] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_safe_to_speak"),
            [0x3E8] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_all_quiet"),
            [0x3E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save"),
            [0x3EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_cancel"),
            [0x3EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_no_timeout"),
            [0x3EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_immediate"),
            [0x3ED] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_saving"),
            [0x3EE] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "game_reverted"),
            [0x3EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_ui_screen_init"),
            [0x3F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_ui_screen_term"),
            [0x3F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_set_tag_parameter_unsafe")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x3F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x3F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_trigger")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x3F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x3F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_cinematic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x3F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_with_subtitle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3F8] = new ScriptInfo(HsType.HaloOnlineValue.Long, "sound_impulse_language_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x3F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x3FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_3d")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x3FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_mark_as_outro")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
            },
            [0x3FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_naked")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x3FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_predict")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
            },
            [0x3FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x3FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
            },
            [0x400] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_stop_immediately")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
            },
            [0x401] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_set_scale")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x402] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_set_alternate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x403] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_loop_spam"),
            [0x404] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_show_channel")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x405] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_debug_sound_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x406] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sounds_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x407] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_set_gain")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x408] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_set_gain_db")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x409] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_class_enable_ducker")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x40A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_environment_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x40B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_set_global_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x40C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_set_global_effect_scale")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x40D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_auto_turret")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x40E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_hover")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x40F] = new ScriptInfo(HsType.HaloOnlineValue.Long, "vehicle_count_bipeds_killed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Vehicle),
            },
            [0x410] = new ScriptInfo(HsType.HaloOnlineValue.Void, "biped_ragdoll")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x411] = new ScriptInfo(HsType.HaloOnlineValue.Void, "water_float_reset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x412] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_show_training_text")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x413] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_set_training_text")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x414] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_enable_training")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x415] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_flashlight"),
            [0x416] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_crouch"),
            [0x417] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_stealth"),
            [0x418] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_equipment"),
            [0x419] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_activate_jump"),
            [0x41A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_training_reset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x41B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_activate_team_nav_point_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x41C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "hud_deactivate_team_nav_point_flag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
            },
            [0x41D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_cortana_suck")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x41E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_texture_cam")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x41F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_cortana_set_range_multiplier")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x420] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_cortana_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x421] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x422] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_weapon_stats")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x423] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_crosshair")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x424] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_shield")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x425] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_grenades")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x426] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_messages")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x427] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_motion_sensor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x428] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_spike_grenades")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x429] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_fire_grenades")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x42A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_compass")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x42B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_stamina")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x42C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_energy_meters")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x42D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_consumables")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x42E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_cinematic_fade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x42F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_bonus_round_show_timer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x430] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_bonus_round_start_timer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x431] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_bonus_round_set_timer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x432] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cls"),
            [0x433] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_spam_suppression_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x434] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x435] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_hide")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x436] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_show_all"),
            [0x437] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_hide_all"),
            [0x438] = new ScriptInfo(HsType.HaloOnlineValue.Void, "error_geometry_list"),
            [0x439] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_translation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x43A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x43B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rumble")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x43C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x43D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x43E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_translation_for_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x43F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rotation_for_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x440] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_set_max_rumble_for_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x441] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_start_for_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x442] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_effect_stop_for_player")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x443] = new ScriptInfo(HsType.HaloOnlineValue.Void, "time_code_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x444] = new ScriptInfo(HsType.HaloOnlineValue.Void, "time_code_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x445] = new ScriptInfo(HsType.HaloOnlineValue.Void, "time_code_reset"),
            [0x446] = new ScriptInfo(HsType.HaloOnlineValue.Void, "script_screen_effect_set_value")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x447] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x448] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_set_crossfade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x449] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_set_crossfade2")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x44A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_screen_effect_stop"),
            [0x44B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_near_clip_distance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x44C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_far_clip_distance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x44D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_atmosphere_fog")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x44E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "atmosphere_fog_override_fade")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x44F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "motion_blur")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x450] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_weather")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x451] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_patchy_fog")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x452] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_environment_map_attenuation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x453] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_environment_map_bitmap")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Bitmap),
            },
            [0x454] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_reset_environment_map_bitmap"),
            [0x455] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_environment_map_tint")
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
            [0x456] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_reset_environment_map_tint"),
            [0x457] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_layer")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x458] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "player_has_skills"),
            [0x459] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_has_mad_secret_skills")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x45A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_invert_look"),
            [0x45B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_look_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x45C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_look_invert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x45D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "controller_get_look_invert"),
            [0x45E] = new ScriptInfo(HsType.HaloOnlineValue.Long, "user_interface_controller_get_last_level_played")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x45F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_look_inverted")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x460] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_vibration_enabled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x461] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_flight_stick_aircraft_controls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x462] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_auto_center_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x463] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_crouch_lock")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x464] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_button_preset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ButtonPreset),
            },
            [0x465] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_joystick_preset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.JoystickPreset),
            },
            [0x466] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_look_sensitivity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x467] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_unlock_single_player_levels")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x468] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_lock_single_player_levels")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x469] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_unlock_skulls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x46A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_lock_skulls")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x46B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_unlock_models")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x46C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_lock_models")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x46D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_single_player_level_completed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.GameDifficulty),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x46E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_player_character_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PlayerCharacterType),
            },
            [0x46F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_emblem_info")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x470] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_voice_output_setting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.VoiceOutputSetting),
            },
            [0x471] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_voice_mask")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.VoiceMask),
            },
            [0x472] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_subtitle_setting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.SubtitleSetting),
            },
            [0x473] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_campaign_solo_high_score")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x474] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_campaign_coop_high_score")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x475] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_survival_solo_high_score")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x476] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_survival_coop_high_score")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x477] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_clear_high_scores")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x478] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_unsignedin_user")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x479] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_display_storage_device_selection")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x47A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "font_cache_bitmap_save")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x47B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_load_main_menu"),
            [0x47C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_text_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x47D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_text_font")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x47E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_show_title_safe_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x47F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_debug_element_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x480] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_memory_dump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x481] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ui_time_scale_step")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x482] = new ScriptInfo(HsType.HaloOnlineValue.Void, "xoverlapped_debug_render")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x483] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_load_screen")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x484] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_reset"),
            [0x485] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_start"),
            [0x486] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_stop"),
            [0x487] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_post")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x488] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_post_toast")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x489] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_resolve")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x48A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_error_clear")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x48B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_dialog_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x48C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_spartan_milestone_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x48D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_spartan_rank_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x48E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_print_active_screens"),
            [0x48F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_print_active_screen_strings"),
            [0x490] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_screen_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x491] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_screen_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x492] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_screen_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x493] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_screen_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x494] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_group_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x495] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_group_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x496] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_group_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x497] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_group_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x498] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x499] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x49A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x49B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x49C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_item_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x49D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_item_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x49E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_item_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x49F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_list_item_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_text_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_text_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_text_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_text_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_bitmap_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_bitmap_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_bitmap_bounds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_bitmap_rotation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_debug_music_state")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cc_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cc_test")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_clear"),
            [0x4AC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_show_up_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_finish_up_to")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_finish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_unavailable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_show")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_finish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "objectives_secondary_unavailable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "input_suppress_rumble")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "input_disable_claw_button_combos")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "update_remote_camera"),
            [0x4B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_build_network_config"),
            [0x4B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_build_game_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_verify_game_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_load_and_use_game_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_use_hopper_directory")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_dump"),
            [0x4BD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_clear"),
            [0x4BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_connection_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_squad_host_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_squad_client_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_group_host_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_group_client_badness_history")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_quality_set_estimated_bandwidth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_friend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_squad_to_friend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_sessionid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_join_squad_to_sessionid")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_enable_join_friend_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_set_maximum_player_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_set_campaign_insertion_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_status_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_sim_reset"),
            [0x4CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_sim_spike_now"),
            [0x4CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_sim_dropspike_now"),
            [0x4CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_ping"),
            [0x4D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_channel_delete"),
            [0x4D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_delegate_host")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_delegate_leader")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_map_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_campaign_difficulty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x4D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_reset_objects"),
            [0x4D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_fatal_error"),
            [0x4D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_set_machine_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_enabled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_disable_suppression")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_global_display_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_global_log_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_global_remote_log_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_display_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_force_display_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_log_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_remote_log_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_debugger_break_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_halt_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Event),
            },
            [0x4E3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_list_categories")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "events_suppress_console_display")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_bink_movie")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_bink_movie_from_tag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.BinkDefinition),
            },
            [0x4E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_credits_skip_to_menu"),
            [0x4E8] = new ScriptInfo(HsType.HaloOnlineValue.Long, "bink_time"),
            [0x4E9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_global_doppler_factor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_global_mixbin_headroom")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_environment_source_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x4EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_set_mission_segment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_insert")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4EE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_upload"),
            [0x4EF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_flush"),
            [0x4F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_debug_menu_setting")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_open_debug_menu"),
            [0x4F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "data_mine_set_display_mission_segment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null4F4")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_memory_allocators")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_memory_allocators")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "display_video_standard"),
            [0x4F8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_xcr_monkey_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x4F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_show_guide_status"),
            [0x4FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_show_users_xuids"),
            [0x4FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_show_are_users_friends")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_invite_friend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x4FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_get_squad_session_id"),
            [0x4FE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_get_screens")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x4FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_get_screen_widgets")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x500] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_screen_get_datasources")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x501] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_screen_get_data_columns")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x502] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_screen_get_data")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x503] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_screen_invoke_list_item_by_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x504] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_screen_invoke_list_item_by_text")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x505] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_screen_invoke_list_item_by_handle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x506] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_auto_screen_send_button_press")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x507] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_download_storage_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x508] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_game_results_save_to_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x509] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_game_results_load_from_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x50A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_roster_save_to_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x50B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_roster_load_from_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x50C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_fragment_utility_drive")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x50D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_metagame_results_save_to_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x50E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_metagame_results_load_from_file")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x50F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "clear_webcache"),
            [0x510] = new ScriptInfo(HsType.HaloOnlineValue.Void, "force_manifest_redownload"),
            [0x511] = new ScriptInfo(HsType.HaloOnlineValue.Void, "online_files_retry"),
            [0x512] = new ScriptInfo(HsType.HaloOnlineValue.Void, "online_files_upload")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x513] = new ScriptInfo(HsType.HaloOnlineValue.Void, "online_files_throttle_bandwidth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x514] = new ScriptInfo(HsType.HaloOnlineValue.Void, "online_marketplace_refresh"),
            [0x515] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x516] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_test_submit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x517] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_test_submit_multiplayer"),
            [0x518] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_test_submit_campaign"),
            [0x519] = new ScriptInfo(HsType.HaloOnlineValue.Void, "webstats_throttle_bandwidth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x51A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "netdebug_prefer_internet")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x51B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flag_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x51C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flag_new_at_look")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x51D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_clear"),
            [0x51E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_default_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x51F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_default_comment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x520] = new ScriptInfo(HsType.HaloOnlineValue.Void, "flags_set_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x521] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "object_list_children")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectDefinition),
            },
            [0x522] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_outgoing_channel_count")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x523] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_voice_repeater_peer_index")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x524] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_mute")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x525] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_hopper")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x526] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_global_arbitrated")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x527] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_global_unarbitrated")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x528] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_refresh"),
            [0x529] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_loaded_tags"),
            [0x52A] = new ScriptInfo(HsType.HaloOnlineValue.Long, "interpolator_start")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x52B] = new ScriptInfo(HsType.HaloOnlineValue.Long, "interpolator_start_smooth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x52C] = new ScriptInfo(HsType.HaloOnlineValue.Long, "interpolator_stop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x52D] = new ScriptInfo(HsType.HaloOnlineValue.Long, "interpolator_restart")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x52E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "interpolator_is_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x52F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "interpolator_is_finished")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x530] = new ScriptInfo(HsType.HaloOnlineValue.Long, "interpolator_set_current_value")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x531] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_get_current_value")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x532] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_get_start_value")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x533] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_get_final_value")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x534] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_get_current_phase")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x535] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_get_current_time_fraction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x536] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_get_start_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x537] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_get_final_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x538] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_evaluate_at")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x539] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_evaluate_at_time_fraction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x53A] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_evaluate_at_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x53B] = new ScriptInfo(HsType.HaloOnlineValue.Real, "interpolator_evaluate_at_time_delta")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x53C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_stop_all"),
            [0x53D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_restart_all"),
            [0x53E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "interpolator_flip"),
            [0x53F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_pc_runtime_language")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x540] = new ScriptInfo(HsType.HaloOnlineValue.Void, "animation_cache_stats_reset"),
            [0x541] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_clone_players_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x542] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_move_attached_objects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x543] = new ScriptInfo(HsType.HaloOnlineValue.Void, "vehicle_enable_ghost_effects")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x544] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_global_sound_environment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x545] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reset_dsp_image"),
            [0x546] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_save_cinematic_skip"),
            [0x547] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_outro_start"),
            [0x548] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_enable_ambience_details")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x549] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x54A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_reset")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x54B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_blur_amount")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x54C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_threshold")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x54D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_brightness")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x54E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_box_factor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x54F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_max_factor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x550] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_silver_bullet")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x551] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_only")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x552] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_high_res")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x553] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_brightness_alpha")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x554] = new ScriptInfo(HsType.HaloOnlineValue.Void, "rasterizer_bloom_override_max_factor_alpha")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x555] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cache_block_for_one_frame"),
            [0x556] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_suppress_ambience_update_on_revert"),
            [0x557] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_autoexposure_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x558] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_full")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x559] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_fade_in")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x55A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_fade_out")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x55B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x55C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_autoexposure_instant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x55D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_exposure_set_environment_darken")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x55E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_depth_of_field_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x55F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_depth_of_field")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x560] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_dof_focus_depth")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x561] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_dof_blur_animate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x562] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_debug_video_mode"),
            [0x563] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lightmap_shadow_disable"),
            [0x564] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_lightmap_shadow_enable"),
            [0x565] = new ScriptInfo(HsType.HaloOnlineValue.Void, "predict_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x566] = new ScriptInfo(HsType.HaloOnlineValue.ObjectList, "mp_players_by_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x567] = new ScriptInfo(HsType.HaloOnlineValue.Long, "mp_active_player_count_by_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x568] = new ScriptInfo(HsType.HaloOnlineValue.Void, "deterministic_end_game"),
            [0x569] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_game_won")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x56A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_respawn_override_timers")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x56B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_ai_allegiance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Team),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x56C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_allegiance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x56D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mp_round_started"),
            [0x56E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "give_medal")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x56F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_scripts_reset"),
            [0x570] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_ai_place")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x571] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_ai_place")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x572] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_ai_kill")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x573] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_ai_kill_silent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x574] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_object_create")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x575] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_object_create_clone")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x576] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_object_create_anew")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ObjectName),
            },
            [0x577] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_object_destroy")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x578] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_file_set_backend")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x579] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_object_belongs_to_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x57A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_weapon_belongs_to_team")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.MpTeam),
            },
            [0x57B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_debug_goal_object_boundary_geometry")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x57C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mp_dump_candy_monitor_state"),
            [0x57D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_camera_third_person")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x57E] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "get_camera_third_person")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x57F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_logging")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x580] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_set_trace_flags")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x581] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_game_state_checksum")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x582] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_trace")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x583] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_set_consumer_sample_level")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x584] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null584")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x585] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_play")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x586] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_play_last"),
            [0x587] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_disable_version_checking")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x588] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_toggle_debug_saving")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x589] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_films_delete_on_level_load")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x58A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_films_show_timestamp")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x58B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_manager_should_record_film_default")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x58C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "mover_set_program")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x58D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_log_compare_log_files")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x58E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "floating_point_exceptions_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x58F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "determinism_debug_manager_enable_log_file_comparision_on_oos")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x590] = new ScriptInfo(HsType.HaloOnlineValue.Void, "event_logs_snapshot"),
            [0x591] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_reload_force")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x592] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_unload_force")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x593] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_load_force")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x594] = new ScriptInfo(HsType.HaloOnlineValue.Void, "predict_bink_movie")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x595] = new ScriptInfo(HsType.HaloOnlineValue.Void, "predict_bink_movie_from_tag")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.BinkDefinition),
            },
            [0x596] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_dump_history"),
            [0x597] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x598] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_flying_cam_at_point")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneCameraPoint),
            },
            [0x599] = new ScriptInfo(HsType.HaloOnlineValue.Void, "camera_set_target")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x59A] = new ScriptInfo(HsType.HaloOnlineValue.Long, "game_coop_player_count"),
            [0x59B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_force_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x59C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_output_pulse"),
            [0x59D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "string_id_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x59E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "find")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x59F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "add_recycling_volume")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.TriggerVolume),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_set_per_frame_publish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5A1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_recycling_clear_history"),
            [0x5A2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_cinematics_script"),
            [0x5A3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "global_preferences_clear"),
            [0x5A4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_storage_set_storage_subdirectory")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5A5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "network_storage_set_storage_user")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5A6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status_line_dump"),
            [0x5A7] = new ScriptInfo(HsType.HaloOnlineValue.Long, "game_tick_get"),
            [0x5A8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "loop_it")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5A9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "loop_clear"),
            [0x5AA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status_lines_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5AB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "status_lines_disable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5AC] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "on_target_platform"),
            [0x5AD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profile_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5AE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profile_deactivate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5AF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_game_set_player_standing")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5B0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_get_game_id"),
            [0x5B1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_hopper_list"),
            [0x5B2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_hopper_game_list"),
            [0x5B3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_matchmaking_hopper_set_game")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5B4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_set_playback_game_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5B5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_set_pending_playback_game_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5B6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "noguchis_mystery_tour")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5B7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "designer_zone_sync"),
            [0x5B8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_designer_zone")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DesignerZone),
            },
            [0x5B9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "designer_zone_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DesignerZone),
            },
            [0x5BA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "designer_zone_deactivate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.DesignerZone),
            },
            [0x5BB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_always_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5BC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_seek_to_film_tick")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5BD] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "tag_is_active")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTagNotResolving),
            },
            [0x5BE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_set_incremental_publish")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5BF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_active_resources"),
            [0x5C0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_persistent")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5C1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "display_zone_size_estimates")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5C2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "report_zone_size_estimates"),
            [0x5C3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_disconnect_squad"),
            [0x5C4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_disconnect_group"),
            [0x5C5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_clear_squad_session_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5C6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_clear_group_session_parameter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5C7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_life_cycle_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5C8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_test_life_cycle_display_states"),
            [0x5C9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "overlapped_display_task_descriptions"),
            [0x5CA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "overlapped_task_inject_error")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5CB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_hopper_all_users")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5CC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_global_arbitrated_all_users")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5CD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_clear_global_unarbitrated_all_users")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5CE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_sapien_crash"),
            [0x5CF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "output_window_add_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5D0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "output_window_remove_category")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5D1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "output_window_list_categories"),
            [0x5D2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "decorators_split")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5D3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bandwidth_profiler_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5D4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "bandwidth_profiler_set_context")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5D5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "overlapped_task_pause")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5D6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_set_controller_cheat_flags")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5D7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_set_controller_ban_flags")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5D8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_dump_strings"),
            [0x5D9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_dump_repeated_play_list"),
            [0x5DA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_set_user_stats")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5DB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_leaderboard_set_user_game_stats")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5DC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_build_map_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5DD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_verify_map_variant")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x5DE] = new ScriptInfo(HsType.HaloOnlineValue.Void, "async_set_work_delay_milliseconds")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5DF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_start_with_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x5E0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_set_demand_throttle_to_io")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5E1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "set_performance_throttle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5E2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "global_preferences_quality_set_all")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5E3] = new ScriptInfo(HsType.HaloOnlineValue.Real, "get_performance_throttle")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5E4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_headset_boost")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5E5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_activate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5E6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_deactivate")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5E7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_activate_from_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x5E8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_deactivate_from_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x5E9] = new ScriptInfo(HsType.HaloOnlineValue.Long, "tiling_current"),
            [0x5EA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_limit_lipsync_to_mouth_only")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5EB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_active_zone_tags"),
            [0x5EC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "calculate_tag_prediction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnyTag),
            },
            [0x5ED] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_enable_fast_prediction")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5EE] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_start_first_person_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5EF] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_is_playing_custom_first_person_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x5F0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_stop_first_person_custom_animation")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x5F1] = new ScriptInfo(HsType.HaloOnlineValue.Void, "prepare_to_switch_to_zone_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.ZoneSet),
            },
            [0x5F2] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_zone_activate_for_debugging")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5F3] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_play_random_ping")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x5F4] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_fade_out_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5F5] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_fade_in_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5F6] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_control_fade_out_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5F7] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_control_fade_in_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5F8] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_lock_gaze")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PointReference),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5F9] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_unlock_gaze")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x5FA] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_control_scale_all_input")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x5FB] = new ScriptInfo(HsType.HaloOnlineValue.Void, "run_like_dvd"),
            [0x5FC] = new ScriptInfo(HsType.HaloOnlineValue.Void, "profiler_auto_core_save")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x5FD] = new ScriptInfo(HsType.HaloOnlineValue.Void, "run_no_hdd"),
            [0x5FE] = new ScriptInfo(HsType.HaloOnlineValue.BinkDefinition, "cinematic_tag_reference_get_bink")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x5FF] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_force_match_configurations")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x600] = new ScriptInfo(HsType.HaloOnlineValue.Void, "voice_set_force_hud")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x601] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_custom_animation_speed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x602] = new ScriptInfo(HsType.HaloOnlineValue.Void, "scenery_animation_start_at_frame_loop")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Scenery),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationGraph),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x603] = new ScriptInfo(HsType.HaloOnlineValue.Void, "saved_film_set_repro_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x604] = new ScriptInfo(HsType.HaloOnlineValue.CinematicSceneDefinition, "cortana_tag_reference_get_scene")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x605] = new ScriptInfo(HsType.HaloOnlineValue.Void, "net_banhammer_force_download")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x606] = new ScriptInfo(HsType.HaloOnlineValue.Void, "font_set_emergency"),
            [0x607] = new ScriptInfo(HsType.HaloOnlineValue.Void, "biped_force_ground_fitting_on")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x608] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_chud_objective")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
            },
            [0x609] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_cinematic_title")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneTitle),
            },
            [0x60A] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "terminal_is_being_read"),
            [0x60B] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "terminal_was_accessed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x60C] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "terminal_was_completed")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
            },
            [0x60D] = new ScriptInfo(HsType.HaloOnlineValue.Weapon, "unit_get_primary_weapon")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x60E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dump_cortana_script"),
            [0x60F] = new ScriptInfo(HsType.HaloOnlineValue.AnimationGraph, "budget_resource_get_animation_graph")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.AnimationBudgetReference),
            },
            [0x610] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_award_level_complete_achievements"),
            [0x611] = new ScriptInfo(HsType.HaloOnlineValue.LoopingSound, "budget_resource_get_looping_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSoundBudgetReference),
            },
            [0x612] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_safe_to_respawn")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x613] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cortana_effect_kill"),
            [0x614] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_item_slayer"),
            [0x615] = new ScriptInfo(HsType.HaloOnlineValue.Void, "test_create_content_item_screenshot"),
            [0x616] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_destroy_cortana_effect_cinematic"),
            [0x617] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_migrate_infanty")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
            },
            [0x618] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_cinematic_motion_blur")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x619] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_dont_do_avoidance")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x61A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_clean_up")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x61B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_erase_inactive")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x61C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ai_survival_cleanup")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Ai),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x61D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "stop_bink_movie"),
            [0x61E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "play_credits_unskippable"),
            [0x61F] = new ScriptInfo(HsType.HaloOnlineValue.Sound, "budget_resource_get_sound")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.SoundBudgetReference),
            },
            [0x620] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_single_player_level_unlocked")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x621] = new ScriptInfo(HsType.HaloOnlineValue.Void, "physical_memory_dump"),
            [0x622] = new ScriptInfo(HsType.HaloOnlineValue.Void, "tag_resources_validate_all_pages")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x623] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_set_debug_mode")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x624] = new ScriptInfo(HsType.HaloOnlineValue.Object, "cinematic_scripting_get_object")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x625] = new ScriptInfo(HsType.HaloOnlineValue.Void, "dummy_function"),
            [0x626] = new ScriptInfo(HsType.HaloOnlineValue.Long, "gp_integer_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x627] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gp_integer_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x628] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "gp_boolean_get")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x629] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gp_boolean_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x62A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gp_dump")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x62B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gp_dump_debug")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x62C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gp_startup")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x62D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gp_reset"),
            [0x62E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gp_commit_options"),
            [0x62F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_start_screen_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x630] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_stop_screen_effect")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x631] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_level_prepare")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x632] = new ScriptInfo(HsType.HaloOnlineValue.Void, "prepare_game_level")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x633] = new ScriptInfo(HsType.HaloOnlineValue.Void, "game_start_with_network_session")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x634] = new ScriptInfo(HsType.HaloOnlineValue.Void, "levels_add_campaign_map_with_id")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x635] = new ScriptInfo(HsType.HaloOnlineValue.Void, "levels_add_campaign_map")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x636] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x637] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_effect_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x638] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_impulse_start_3d_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Sound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x639] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_start_editor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x63A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_channels_log_start"),
            [0x63B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_channels_log_start_named")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x63C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_channels_log_stop"),
            [0x63D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "cinematic_scripting_set_user_input_constraints")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x63E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "skull_primary_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.PrimarySkull),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x63F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "skull_secondary_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.SecondarySkull),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x640] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_popup_message_index")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x641] = new ScriptInfo(HsType.HaloOnlineValue.Void, "controller_set_vidmaster_seen")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x642] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_enter_lobby")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x643] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_respawn_dead_players"),
            [0x644] = new ScriptInfo(HsType.HaloOnlineValue.Long, "survival_mode_lives_get"),
            [0x645] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_lives_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x646] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_set_get"),
            [0x647] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_set_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x648] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_round_get"),
            [0x649] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_round_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x64A] = new ScriptInfo(HsType.HaloOnlineValue.Short, "survival_mode_wave_get"),
            [0x64B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_wave_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x64C] = new ScriptInfo(HsType.HaloOnlineValue.Real, "survival_mode_set_multiplier_get"),
            [0x64D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_set_multiplier_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x64E] = new ScriptInfo(HsType.HaloOnlineValue.Real, "survival_mode_bonus_multiplier_get"),
            [0x64F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_bonus_multiplier_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x650] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_sound_channel_fadeout_time")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x651] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_set_rounds_per_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x652] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_set_waves_per_round")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x653] = new ScriptInfo(HsType.HaloOnlineValue.Void, "render_model_marker_name_filter")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x654] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_event_new")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x655] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_begin_new_set"),
            [0x656] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_begin_new_round"),
            [0x657] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_begin_new_wave"),
            [0x658] = new ScriptInfo(HsType.HaloOnlineValue.Void, "survival_mode_award_hero_medal"),
            [0x659] = new ScriptInfo(HsType.HaloOnlineValue.Long, "campaign_metagame_get_player_score")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x65A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "collision_debug_lightmaps_print"),
            [0x65B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_coop_campaign_save")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x65C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_look_training_hack")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x65D] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "device_arg_has_been_touched_by_unit")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Device),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x65E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "gui_hide_all_screens")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x65F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "debug_lightmap_inspect"),
            [0x660] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievements_display_debug_names"),
            [0x661] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievement_grant_to_controller_by_debug_name")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x662] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievements_grant_all_to_controller")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x663] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievements_award_all_vidmaster_achievements")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Controller),
            },
            [0x664] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_fade_for_first_person_cinematic")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x665] = new ScriptInfo(HsType.HaloOnlineValue.Void, "achievement_post_chud_progression")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x666] = new ScriptInfo(HsType.HaloOnlineValue.Void, "object_set_vision_mode_render_default")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x667] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_show_navpoint")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.CutsceneFlag),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x668] = new ScriptInfo(HsType.HaloOnlineValue.Void, "run_like_package"),
            [0x669] = new ScriptInfo(HsType.HaloOnlineValue.Void, "clear_map_slot")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x66A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "clear_map_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x66B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_confirm_message")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x66C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_confirm_cancel_message")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x66D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_confirm_y_button")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x66E] = new ScriptInfo(HsType.HaloOnlineValue.Long, "player_get_kills_by_type")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x66F] = new ScriptInfo(HsType.HaloOnlineValue.Boolean, "unit_flashlight_on")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Unit),
            },
            [0x670] = new ScriptInfo(HsType.HaloOnlineValue.Void, "clear_command_buffer_cache_from_script")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x671] = new ScriptInfo(HsType.HaloOnlineValue.Void, "sound_looping_resume")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.LoopingSound),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x672] = new ScriptInfo(HsType.HaloOnlineValue.Void, "chud_bonus_round_set_target_score")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x673] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null673"),
            [0x674] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null674")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x675] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null675")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x676] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null676"),
            [0x677] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null677")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x678] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null678"),
            [0x679] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null679"),
            [0x67A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null67A")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x67B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null67B")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x67C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null67C"),
            [0x67D] = new ScriptInfo(HsType.HaloOnlineValue.Long, "ui_get_player_model_id"),
            [0x67E] = new ScriptInfo(HsType.HaloOnlineValue.Long, "ui_get_music_id"),
            [0x67F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null67F")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x680] = new ScriptInfo(HsType.HaloOnlineValue.Void, "unit_set_armor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Object),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x681] = new ScriptInfo(HsType.HaloOnlineValue.Void, "player_set_armor")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x682] = new ScriptInfo(HsType.HaloOnlineValue.Void, "change_network_privacy_to_system_link"),
            [0x683] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ssao_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x684] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ssao_radius")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x685] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ssao_intensity")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x686] = new ScriptInfo(HsType.HaloOnlineValue.Void, "ssao_sampleZThreshold")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x687] = new ScriptInfo(HsType.HaloOnlineValue.Void, "fxaa_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x688] = new ScriptInfo(HsType.HaloOnlineValue.Void, "color_grading_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x689] = new ScriptInfo(HsType.HaloOnlineValue.Void, "lightshafts_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x68A] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null68A")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x68B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reflections_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x68C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reflection_blur_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x68D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reflection_multisampling_enabled")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x68E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reflection_multisample_passes")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x68F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reflection_fxaa_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x690] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reflection_debug_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x691] = new ScriptInfo(HsType.HaloOnlineValue.Void, "reflection_color_bilinear_filter_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x692] = new ScriptInfo(HsType.HaloOnlineValue.Void, "end_match_wait_time_increment")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x693] = new ScriptInfo(HsType.HaloOnlineValue.Void, "process_memory_debug"),
            [0x694] = new ScriptInfo(HsType.HaloOnlineValue.Void, "background_set")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
            },
            [0x695] = new ScriptInfo(HsType.HaloOnlineValue.Void, "local_player_earn_wp_event")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.StringId),
            },
            [0x696] = new ScriptInfo(HsType.HaloOnlineValue.Void, "default_screen_effect_enable")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x697] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null697")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.String),
            },
            [0x698] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null698"),
            [0x699] = new ScriptInfo(HsType.HaloOnlineValue.Void, "mouse_inversion_get"),
            [0x69A] = new ScriptInfo(HsType.HaloOnlineValue.Long, "mouse_inversion_set"),
            [0x69B] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null69B")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x69C] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null69C")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Short),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
            },
            [0x69D] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null69D"),
            [0x69E] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null69E")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Long),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Real),
            },
            [0x69F] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null69F")
            {
                new ScriptInfo.ParameterInfo(HsType.HaloOnlineValue.Boolean),
            },
            [0x6A0] = new ScriptInfo(HsType.HaloOnlineValue.Void, "null6A0"),
        };
    }
}
