using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders;
using TagTool.MtnDewIt.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands
{
    class UpdateShaderDataCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }

        // Really gotta figure out how I'm gonna handle this
        // TODO's TODO: Write custom JSON parser :/
        // TODO: Unless tag data has any prerequisites, list files alphabetically
        // TODO: After all this data has been serialized, generate global shaders
        // TODO: Maybe add the extension to the file name in the parser?
        public static readonly string[] TagObjectList = new[] 
        {
            $@"shaders\beam.render_method_definition.json",
            $@"shaders\black.render_method_definition.json",
            $@"shaders\contrail.render_method_definition.json",
            $@"shaders\cortana.render_method_definition.json",
            $@"shaders\custom.render_method_definition.json",
            $@"shaders\decal.render_method_definition.json",
            $@"shaders\foliage.render_method_definition.json",
            $@"shaders\halogram.render_method_definition.json",
            $@"shaders\light_volume.render_method_definition.json",
            $@"shaders\particle.render_method_definition.json",
            $@"shaders\screen.render_method_definition.json",
            $@"shaders\shader.render_method_definition.json",
            $@"shaders\terrain.render_method_definition.json",
            $@"shaders\water.render_method_definition.json",
            $@"shaders\zonly.render_method_definition.json",
            $@"shaders\beam_options\albedo_diffuse_only.render_method_option.json",
            $@"shaders\beam_options\albedo_palettized.render_method_option.json",
            $@"shaders\beam_options\albedo_palettized_plus_alpha.render_method_option.json",
            $@"shaders\beam_options\global_beam_options.render_method_option.json",
            $@"shaders\contrail_options\albedo_diffuse_only.render_method_option.json",
            $@"shaders\contrail_options\albedo_palettized.render_method_option.json",
            $@"shaders\contrail_options\albedo_palettized_plus_alpha.render_method_option.json",
            $@"shaders\contrail_options\global_contrail_options.render_method_option.json",
            $@"shaders\custom_options\albedo_waterfall.render_method_option.json",
            $@"shaders\custom_options\alpha_test_multiply_map.render_method_option.json",
            $@"shaders\custom_options\material_custom_specular.render_method_option.json",
            $@"shaders\custom_options\window_room_map.render_method_option.json",
            $@"shaders\decal_options\albedo_change_color.render_method_option.json",
            $@"shaders\decal_options\albedo_diffuse_only.render_method_option.json",
            $@"shaders\decal_options\albedo_diffuse_plus_alpha.render_method_option.json",
            $@"shaders\decal_options\albedo_diffuse_plus_alpha_mask.render_method_option.json",
            $@"shaders\decal_options\albedo_emblem_change_color.render_method_option.json",
            $@"shaders\decal_options\albedo_palettized.render_method_option.json",
            $@"shaders\decal_options\albedo_palettized_plus_alpha.render_method_option.json",
            $@"shaders\decal_options\albedo_palettized_plus_alpha_mask.render_method_option.json",
            $@"shaders\decal_options\albedo_vector_alpha.render_method_option.json",
            $@"shaders\decal_options\albedo_vector_alpha_drop_shadow.render_method_option.json",
            $@"shaders\decal_options\bump_mapping_standard.render_method_option.json",
            $@"shaders\decal_options\bump_mapping_standard_mask.render_method_option.json",
            $@"shaders\decal_options\global_decal_options.render_method_option.json",
            $@"shaders\decal_options\specular_modulate.render_method_option.json",
            $@"shaders\decal_options\tinting_fully_modulated.render_method_option.json",
            $@"shaders\decal_options\tinting_partially_modulated.render_method_option.json",
            $@"shaders\decal_options\tinting_unmodulated.render_method_option.json",
            $@"shaders\foliage_options\material_default.render_method_option.json",
            $@"shaders\light_volume_options\albedo_circular.render_method_option.json",
            $@"shaders\light_volume_options\albedo_diffuse_only.render_method_option.json",
            $@"shaders\light_volume_options\global_light_volume.render_method_option.json",
            $@"shaders\particle_options\albedo_diffuse_modulated.render_method_option.json",
            $@"shaders\particle_options\albedo_diffuse_only.render_method_option.json",
            $@"shaders\particle_options\albedo_diffuse_plus_billboard_alpha.render_method_option.json",
            $@"shaders\particle_options\albedo_diffuse_plus_sprite_alpha.render_method_option.json",
            $@"shaders\particle_options\albedo_palettized.render_method_option.json",
            $@"shaders\particle_options\albedo_palettized_glow.render_method_option.json",
            $@"shaders\particle_options\albedo_palettized_plasma.render_method_option.json",
            $@"shaders\particle_options\albedo_palettized_plus_billboard_alpha.render_method_option.json",
            $@"shaders\particle_options\albedo_palettized_plus_sprite_alpha.render_method_option.json",
            $@"shaders\particle_options\depth_fade_on.render_method_option.json",
            $@"shaders\particle_options\depth_fade_palette_shift.render_method_option.json",
            $@"shaders\particle_options\frame_blend_on.render_method_option.json",
            $@"shaders\particle_options\global_particle_options.render_method_option.json",
            $@"shaders\particle_options\self_illumination_constant_color.render_method_option.json",
            $@"shaders\particle_options\specialized_rendering_distortion.render_method_option.json",
            $@"shaders\screen_options\base_single.render_method_option.json",
            $@"shaders\screen_options\blend.render_method_option.json",
            $@"shaders\screen_options\detail_a.render_method_option.json",
            $@"shaders\screen_options\detail_mask_a.render_method_option.json",
            $@"shaders\screen_options\global_screen_options.render_method_option.json",
            $@"shaders\screen_options\illum_palettized_plasma_change_color.render_method_option.json",
            $@"shaders\screen_options\overlay_tint_add_color.render_method_option.json",
            $@"shaders\screen_options\warp_simple.render_method_option.json",
            $@"shaders\shader_options\albedo_chameleon.render_method_option.json",
            $@"shaders\shader_options\albedo_chameleon_albedo_masked.render_method_option.json",
            $@"shaders\shader_options\albedo_chameleon_masked.render_method_option.json",
            $@"shaders\shader_options\albedo_color_mask.render_method_option.json",
            $@"shaders\shader_options\albedo_color_mask_hard_light.render_method_option.json",
            $@"shaders\shader_options\albedo_constant.render_method_option.json",
            $@"shaders\shader_options\albedo_custom_cube.render_method_option.json",
            $@"shaders\shader_options\albedo_default.render_method_option.json",
            $@"shaders\shader_options\albedo_detail_blend.render_method_option.json",
            $@"shaders\shader_options\albedo_emblem.render_method_option.json",
            $@"shaders\shader_options\albedo_four_change_color.render_method_option.json",
            $@"shaders\shader_options\albedo_scrolling_cube.render_method_option.json",
            $@"shaders\shader_options\albedo_scrolling_cube_mask.render_method_option.json",
            $@"shaders\shader_options\albedo_scrolling_texture_uv.render_method_option.json",
            $@"shaders\shader_options\albedo_simple.render_method_option.json",
            $@"shaders\shader_options\albedo_texture_from_misc.render_method_option.json",
            $@"shaders\shader_options\albedo_three_detail_blend.render_method_option.json",
            $@"shaders\shader_options\albedo_two_change_color.render_method_option.json",
            $@"shaders\shader_options\albedo_two_change_color_anim_overlay.render_method_option.json",
            $@"shaders\shader_options\albedo_two_change_color_chameleon.render_method_option.json",
            $@"shaders\shader_options\albedo_two_change_color_tex_overlay.render_method_option.json",
            $@"shaders\shader_options\albedo_two_color.render_method_option.json",
            $@"shaders\shader_options\albedo_two_detail.render_method_option.json",
            $@"shaders\shader_options\albedo_two_detail_black_point.render_method_option.json",
            $@"shaders\shader_options\albedo_two_detail_overlay.render_method_option.json",
            $@"shaders\shader_options\alpha_test_off.render_method_option.json",
            $@"shaders\shader_options\alpha_test_on.render_method_option.json",
            $@"shaders\shader_options\bump_default.render_method_option.json",
            $@"shaders\shader_options\bump_detail.render_method_option.json",
            $@"shaders\shader_options\bump_detail_masked.render_method_option.json",
            $@"shaders\shader_options\bump_detail_plus_detail_masked.render_method_option.json",
            $@"shaders\shader_options\bump_detail_unorm.render_method_option.json",
            $@"shaders\shader_options\bump_off.render_method_option.json",
            $@"shaders\shader_options\cortana_albedo.render_method_option.json",
            $@"shaders\shader_options\cortana_screenspace.render_method_option.json",
            $@"shaders\shader_options\cortana_transparency.render_method_option.json",
            $@"shaders\shader_options\distort_on.render_method_option.json",
            $@"shaders\shader_options\edge_fade_simple.render_method_option.json",
            $@"shaders\shader_options\env_map_dynamic.render_method_option.json",
            $@"shaders\shader_options\env_map_from_flat_texture.render_method_option.json",
            $@"shaders\shader_options\env_map_per_pixel.render_method_option.json",
            $@"shaders\shader_options\glass_material.render_method_option.json",
            $@"shaders\shader_options\global_shader_options.render_method_option.json",
            $@"shaders\shader_options\illum_3_channel.render_method_option.json",
            $@"shaders\shader_options\illum_change_color.render_method_option.json",
            $@"shaders\shader_options\illum_change_color_detail.render_method_option.json",
            $@"shaders\shader_options\illum_detail.render_method_option.json",
            $@"shaders\shader_options\illum_detail_world_space_four_cc.render_method_option.json",
            $@"shaders\shader_options\illum_from_diffuse.render_method_option.json",
            $@"shaders\shader_options\illum_holograms.render_method_option.json",
            $@"shaders\shader_options\illum_meter.render_method_option.json",
            $@"shaders\shader_options\illum_multilayer.render_method_option.json",
            $@"shaders\shader_options\illum_multilayer_five_change_color.render_method_option.json",
            $@"shaders\shader_options\illum_multilayer_four_change_color.render_method_option.json",
            $@"shaders\shader_options\illum_palettized_depth_fade.render_method_option.json",
            $@"shaders\shader_options\illum_palettized_plasma.render_method_option.json",
            $@"shaders\shader_options\illum_plasma.render_method_option.json",
            $@"shaders\shader_options\illum_plasma_wide_and_sharp_five_change_color.render_method_option.json",
            $@"shaders\shader_options\illum_scope_blur.render_method_option.json",
            $@"shaders\shader_options\illum_simple.render_method_option.json",
            $@"shaders\shader_options\illum_simple_four_change_color.render_method_option.json",
            $@"shaders\shader_options\illum_times_diffuse.render_method_option.json",
            $@"shaders\shader_options\material_car_paint.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_custom_cube_option.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_from_albedo.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_option.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_option_reach.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_pbr_maps_option.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_rim_fresnel.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_scrolling_cube.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_scrolling_cube_mask.render_method_option.json",
            $@"shaders\shader_options\material_cook_torrance_two_color_spec_tint.render_method_option.json",
            $@"shaders\shader_options\material_diffuse_only.render_method_option.json",
            $@"shaders\shader_options\material_foliage.render_method_option.json",
            $@"shaders\shader_options\material_hair_option.render_method_option.json",
            $@"shaders\shader_options\material_organism_option.render_method_option.json",
            $@"shaders\shader_options\material_two_lobe_phong_option.render_method_option.json",
            $@"shaders\shader_options\material_two_lobe_phong_option_reach.render_method_option.json",
            $@"shaders\shader_options\material_two_lobe_phong_tint_map_option.render_method_option.json",
            $@"shaders\shader_options\misc_attr_scrolling_cube.render_method_option.json",
            $@"shaders\shader_options\misc_attr_scrolling_projected.render_method_option.json",
            $@"shaders\shader_options\overlay_additive.render_method_option.json",
            $@"shaders\shader_options\overlay_additive_detail.render_method_option.json",
            $@"shaders\shader_options\overlay_multiply_additive_detail.render_method_option.json",
            $@"shaders\shader_options\parallax_detail.render_method_option.json",
            $@"shaders\shader_options\parallax_simple.render_method_option.json",
            $@"shaders\shader_options\sfx_distort.render_method_option.json",
            $@"shaders\shader_options\single_lobe_phong.render_method_option.json",
            $@"shaders\shader_options\soft_fade.render_method_option.json",
            $@"shaders\shader_options\specular_mask_from_texture.render_method_option.json",
            $@"shaders\shader_options\warp_cortana_default.render_method_option.json",
            $@"shaders\shader_options\warp_from_texture.render_method_option.json",
            $@"shaders\terrain_options\default_blending.render_method_option.json",
            $@"shaders\terrain_options\diffuse_only_m_0.render_method_option.json",
            $@"shaders\terrain_options\diffuse_only_m_1.render_method_option.json",
            $@"shaders\terrain_options\diffuse_only_m_2.render_method_option.json",
            $@"shaders\terrain_options\diffuse_only_m_3.render_method_option.json",
            $@"shaders\terrain_options\diffuse_only_plus_sefl_illum_m_0.render_method_option.json",
            $@"shaders\terrain_options\diffuse_only_plus_sefl_illum_m_1.render_method_option.json",
            $@"shaders\terrain_options\diffuse_only_plus_sefl_illum_m_2.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_m_0.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_m_1.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_m_2.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_m_3.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_plus_heightmap_m_0.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_plus_heightmap_m_1.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_plus_self_illumm_0.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_plus_self_illumm_1.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_plus_self_illumm_2.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_plus_up_vector_plus_heightmap_m_0.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_specular_plus_up_vector_plus_heightmap_m_1.render_method_option.json",
            $@"shaders\terrain_options\diffuse_plus_two_detail_m_0.render_method_option.json",
            $@"shaders\terrain_options\dynamic_blending.render_method_option.json",
            $@"shaders\water_options\appearance_default.render_method_option.json",
            $@"shaders\water_options\bankalpha_depth.render_method_option.json",
            $@"shaders\water_options\bankalpha_from_shape_texture_alpha.render_method_option.json",
            $@"shaders\water_options\bankalpha_paint.render_method_option.json",
            $@"shaders\water_options\foam_auto.render_method_option.json",
            $@"shaders\water_options\foam_both.render_method_option.json",
            $@"shaders\water_options\foam_none.render_method_option.json",
            $@"shaders\water_options\foam_paint.render_method_option.json",
            $@"shaders\water_options\globalshape_depth.render_method_option.json",
            $@"shaders\water_options\globalshape_paint.render_method_option.json",
            $@"shaders\water_options\reach_compatibility_enabled.render_method_option.json",
            $@"shaders\water_options\reflection_dynamic.render_method_option.json",
            $@"shaders\water_options\reflection_static.render_method_option.json",
            $@"shaders\water_options\reflection_static_ssr.render_method_option.json",
            $@"shaders\water_options\refraction_dynamic.render_method_option.json",
            $@"shaders\water_options\water_global.render_method_option.json",
            $@"shaders\water_options\watercolor_pure.render_method_option.json",
            $@"shaders\water_options\watercolor_texture.render_method_option.json",
            $@"shaders\water_options\waveshape_bump.render_method_option.json",
            $@"shaders\water_options\waveshape_default.render_method_option.json",
        };

        public UpdateShaderDataCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            true,
            "UpdateShaderData",
            "Updates Render Method Definitions To Include ElDewrito, and MCC Options",
            "UpdateShaderData",
            "Updates Render Method Definitions To Include ElDewrito, and MCC Options. Recompiles Global Pixel and Vertex Shaders"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            UpdateShaderData();

            return true;
        }

        public void UpdateShaderData()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                new shaders_beam_render_method_definition(Cache, CacheContext, stream);
                new shaders_black_render_method_definition(Cache, CacheContext, stream);
                new shaders_contrail_render_method_definition(Cache, CacheContext, stream);
                new shaders_cortana_render_method_definition(Cache, CacheContext, stream);
                new shaders_custom_render_method_definition(Cache, CacheContext, stream);
                new shaders_decal_render_method_definition(Cache, CacheContext, stream);
                new shaders_foliage_render_method_definition(Cache, CacheContext, stream);
                new shaders_halogram_render_method_definition(Cache, CacheContext, stream);
                new shaders_light_volume_render_method_definition(Cache, CacheContext, stream);
                new shaders_particle_render_method_definition(Cache, CacheContext, stream);
                new shaders_screen_render_method_definition(Cache, CacheContext, stream);
                new shaders_shader_render_method_definition(Cache, CacheContext, stream);
                new shaders_terrain_render_method_definition(Cache, CacheContext, stream);
                new shaders_water_render_method_definition(Cache, CacheContext, stream);
                new shaders_zonly_render_method_definition(Cache, CacheContext, stream);

                Cache.SaveStrings();

                GenerateGlobalShaders(stream, $@"beam");           // Data doesn't change between versions, Compiled vertex data is completely different from MS23
                GenerateGlobalShaders(stream, $@"black");
                GenerateGlobalShaders(stream, $@"contrail");       // Data doesn't change between versions, Compiled vertex data is completely different from MS23 
                GenerateGlobalShaders(stream, $@"cortana");
                GenerateGlobalShaders(stream, $@"custom");         // Vertex data is completely different from vertex data from updated source (use legacy generator for 1:1 data)
                GenerateGlobalShaders(stream, $@"decal");          // Vertex data is completely different between MS23 and vertex data from updated source (use legacy generator for 1:1 data)
                GenerateGlobalShaders(stream, $@"foliage", false); // Having APPLY_FIXES undefined generates 1:1 vertex data. 
                GenerateGlobalShaders(stream, $@"halogram");
                GenerateGlobalShaders(stream, $@"lightvolume");    // Data doesn't change between versions, Compiled vertex data is completely different from MS23 
                GenerateGlobalShaders(stream, $@"particle");       // Data doesn't change between versions, Compiled vertex data is completely different from MS23 
                GenerateGlobalShaders(stream, $@"screen");
                GenerateGlobalShaders(stream, $@"shader");
                GenerateGlobalShaders(stream, $@"terrain");        // Vertex data is completely different between MS23 and vertex data from updated source (use legacy generator for 1:1 data)
                GenerateGlobalShaders(stream, $@"water", false);   // Having APPLY_FIXES undefined generates 1:1 vertex data. 
                GenerateGlobalShaders(stream, $@"zonly");

                GenerateChudShader(stream, $@"chud_cortana_camera");
                GenerateChudShader(stream, $@"chud_cortana_composite", false);
                GenerateChudShader(stream, $@"chud_cortana_offscreen");
                GenerateChudShader(stream, $@"chud_cortana_screen");
                GenerateChudShader(stream, $@"chud_cortana_screen_final");
                GenerateChudShader(stream, $@"chud_crosshair");
                GenerateChudShader(stream, $@"chud_directional_damage");
                GenerateChudShader(stream, $@"chud_directional_damage_apply");
                GenerateChudShader(stream, $@"chud_emblem");
                GenerateChudShader(stream, $@"chud_medal");
                GenerateChudShader(stream, $@"chud_meter");
                GenerateChudShader(stream, $@"chud_meter_chapter");
                GenerateChudShader(stream, $@"chud_meter_double_gradient");
                GenerateChudShader(stream, $@"chud_meter_gradient");
                GenerateChudShader(stream, $@"chud_meter_gradient_inverse");
                GenerateChudShader(stream, $@"chud_meter_radial_gradient");
                GenerateChudShader(stream, $@"chud_meter_shield", false);
                GenerateChudShader(stream, $@"chud_meter_single_color");
                GenerateChudShader(stream, $@"chud_navpoint");
                GenerateChudShader(stream, $@"chud_really_simple");
                GenerateChudShader(stream, $@"chud_sensor");
                GenerateChudShader(stream, $@"chud_simple", false);
                GenerateChudShader(stream, $@"chud_solid");
                GenerateChudShader(stream, $@"chud_text_simple", false);
                GenerateChudShader(stream, $@"chud_texture_cam");
                GenerateChudShader(stream, $@"chud_turbulence");

                GenerateExplicitShader(stream, $@"add");
                GenerateExplicitShader(stream, $@"add_downsampled");
                GenerateExplicitShader(stream, $@"alpha_test_explicit");
                GenerateExplicitShader(stream, $@"apply_color_matrix");
                GenerateExplicitShader(stream, $@"beam_update");
                GenerateExplicitShader(stream, $@"blend3");
                GenerateExplicitShader(stream, $@"bloom_add_alpha1");
                GenerateExplicitShader(stream, $@"bloom_curve");
                GenerateExplicitShader(stream, $@"blur_11_horizontal", false);
                GenerateExplicitShader(stream, $@"blur_11_vertical", false);
                GenerateExplicitShader(stream, $@"bspline_resample");
                GenerateExplicitShader(stream, $@"chud_overlay_blend");
                GenerateExplicitShader(stream, $@"contrail_spawn");
                GenerateExplicitShader(stream, $@"contrail_update");
                GenerateExplicitShader(stream, $@"copy");
                GenerateExplicitShader(stream, $@"copy_rgbe_to_rgb");
                GenerateExplicitShader(stream, $@"copy_surface");
                GenerateExplicitShader(stream, $@"crop");
                GenerateExplicitShader(stream, $@"cubemap_clamp");
                GenerateExplicitShader(stream, $@"cubemap_divide");
                GenerateExplicitShader(stream, $@"cubemap_phi_blur");
                GenerateExplicitShader(stream, $@"cubemap_theta_blur");
                GenerateExplicitShader(stream, $@"custom_gamma_correct");
                GenerateExplicitShader(stream, $@"debug");
                GenerateExplicitShader(stream, $@"debug2d");
                GenerateExplicitShader(stream, $@"decorator_default");
                GenerateExplicitShader(stream, $@"decorator_edit");
                GenerateExplicitShader(stream, $@"decorator_no_wind");
                GenerateExplicitShader(stream, $@"decorator_shaded");
                GenerateExplicitShader(stream, $@"decorator_static");
                GenerateExplicitShader(stream, $@"decorator_sun");
                GenerateExplicitShader(stream, $@"decorator_wavy");
                GenerateExplicitShader(stream, $@"displacement");
                GenerateExplicitShader(stream, $@"displacement_motion_blur");
                GenerateExplicitShader(stream, $@"double_gradient", false);
                GenerateExplicitShader(stream, $@"downsample_2x2");
                GenerateExplicitShader(stream, $@"downsample_4x4_block");
                GenerateExplicitShader(stream, $@"downsample_4x4_block_bloom");
                GenerateExplicitShader(stream, $@"downsample_4x4_block_bloom_ldr");
                GenerateExplicitShader(stream, $@"downsample_4x4_block_bloom_new");
                GenerateExplicitShader(stream, $@"downsample_4x4_bloom_dof");
                GenerateExplicitShader(stream, $@"downsample_4x4_gaussian");
                GenerateExplicitShader(stream, $@"downsample_4x4_gaussian_bloom");
                GenerateExplicitShader(stream, $@"downsample_4x4_gaussian_bloom_ldr");
                GenerateExplicitShader(stream, $@"downsize_2x_target");
                GenerateExplicitShader(stream, $@"downsize_2x_to_bloom");
                GenerateExplicitShader(stream, $@"exposure_downsample");
                GenerateExplicitShader(stream, $@"final_composite");
                GenerateExplicitShader(stream, $@"final_composite_debug");
                GenerateExplicitShader(stream, $@"final_composite_dof");
                GenerateExplicitShader(stream, $@"final_composite_zoom");
                GenerateExplicitShader(stream, $@"fxaa");
                GenerateExplicitShader(stream, $@"gamma_correct");
                GenerateExplicitShader(stream, $@"gradient", false);
                GenerateExplicitShader(stream, $@"hdr_retrieve");
                GenerateExplicitShader(stream, $@"hud_camera_nightvision"); // Uses a custom implementation when compared to the ODST shader source.
                GenerateExplicitShader(stream, $@"implicit_hill");
                GenerateExplicitShader(stream, $@"kernel_5", false);
                GenerateExplicitShader(stream, $@"legacy_hud_bitmap");
                GenerateExplicitShader(stream, $@"legacy_meter");
                GenerateExplicitShader(stream, $@"lens_flare");
                GenerateExplicitShader(stream, $@"light_volume_update");
                GenerateExplicitShader(stream, $@"lightshafts");
                GenerateExplicitShader(stream, $@"overhead_map_geometry");
                GenerateExplicitShader(stream, $@"particle_spawn");
                GenerateExplicitShader(stream, $@"particle_update");
                GenerateExplicitShader(stream, $@"patchy_fog", false);
                GenerateExplicitShader(stream, $@"pixel_copy");
                GenerateExplicitShader(stream, $@"player_emblem_screen");
                GenerateExplicitShader(stream, $@"player_emblem_world");
                GenerateExplicitShader(stream, $@"radial_blur");
                GenerateExplicitShader(stream, $@"restore_ldr_hdr_depth");
                GenerateExplicitShader(stream, $@"rotate_2d");
                GenerateExplicitShader(stream, $@"screenshot_combine", false);
                GenerateExplicitShader(stream, $@"screenshot_combine_dof", false);
                GenerateExplicitShader(stream, $@"screenshot_display");
                GenerateExplicitShader(stream, $@"screenshot_memexport");
                GenerateExplicitShader(stream, $@"shadow_apply");
                GenerateExplicitShader(stream, $@"shadow_apply_bilinear");
                GenerateExplicitShader(stream, $@"shadow_apply_fancy");
                GenerateExplicitShader(stream, $@"shadow_apply_faster");
                GenerateExplicitShader(stream, $@"shadow_apply_point");
                GenerateExplicitShader(stream, $@"shadow_geometry");
                GenerateExplicitShader(stream, $@"shield_impact");
                GenerateExplicitShader(stream, $@"shield_meter");
                GenerateExplicitShader(stream, $@"sky_dome_simple");
                GenerateExplicitShader(stream, $@"smirnov");
                GenerateExplicitShader(stream, $@"sniper_scope");
                GenerateExplicitShader(stream, $@"sniper_scope_stencil_pc");
                GenerateExplicitShader(stream, $@"spike_blur_horizontal");
                GenerateExplicitShader(stream, $@"spike_blur_vertical");
                GenerateExplicitShader(stream, $@"ssao");
                GenerateExplicitShader(stream, $@"ssao_blur");
                GenerateExplicitShader(stream, $@"stencil_stipple");
                GenerateExplicitShader(stream, $@"transparent");
                GenerateExplicitShader(stream, $@"update_persistence");
                GenerateExplicitShader(stream, $@"water_ripple");
                GenerateExplicitShader(stream, $@"write_depth");
                GenerateExplicitShader(stream, $@"yuv_to_rgb");
                GenerateExplicitShader(stream, $@"unknown_94"); // unknown_94 // fxaa_alpha?
                GenerateExplicitShader(stream, $@"unknown_98"); // unknown_98
                GenerateExplicitShader(stream, $@"unknown_101"); // unknown_101
                GenerateExplicitShader(stream, $@"unknown_102"); // unknown_102
                GenerateExplicitShader(stream, $@"unknown_103"); // unknown_103
                GenerateExplicitShader(stream, $@"unknown_104"); // unknown_104
                GenerateExplicitShader(stream, $@"unknown_105"); // unknown_105
                GenerateExplicitShader(stream, $@"unknown_106"); // unknown_106
                GenerateExplicitShader(stream, $@"unknown_107"); // unknown_107
                GenerateExplicitShader(stream, $@"unknown_109"); // unknown_109
            }
        }

        public void GenerateGlobalShaders(Stream stream, string shaderType, bool applyFixes = true)
        {
            var type = (HaloShaderGenerator.Globals.ShaderType)Enum.Parse(typeof(HaloShaderGenerator.Globals.ShaderType), shaderType, true);

            CachedTag rmdfTag = Cache.TagCache.GetTag<RenderMethodDefinition>(shaderType == "lightvolume" ? "shaders\\light_volume" : $"shaders\\{shaderType}");

            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            GlobalPixelShader glps = InlineShaderGenerator.GenerateSharedPixelShaders(Cache, rmdf, type, applyFixes);
            GlobalVertexShader glvs = InlineShaderGenerator.GenerateSharedVertexShaders(Cache, rmdf, type, applyFixes);

            Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
        }

        public void GenerateExplicitShader(Stream stream, string shader, bool applyFixes = true)
        {
            var type = (HaloShaderGenerator.Globals.ExplicitShader)Enum.Parse(typeof(HaloShaderGenerator.Globals.ExplicitShader), shader, true);

            CachedTag pixlTag = Cache.TagCache.GetTag<PixelShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{type}");
            CachedTag vtshTag = Cache.TagCache.GetTag<VertexShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{type}");

            InlineShaderGenerator.GenerateExplicitShader(Cache, type.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }

        public void GenerateChudShader(Stream stream, string shader, bool applyFixes = true)
        {
            var type = (HaloShaderGenerator.Globals.ChudShader)Enum.Parse(typeof(HaloShaderGenerator.Globals.ChudShader), shader, true);

            CachedTag pixlTag = Cache.TagCache.GetTag<PixelShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{type}");
            CachedTag vtshTag = Cache.TagCache.GetTag<VertexShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{type}");

            InlineShaderGenerator.GenerateChudShader(Cache, type.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }
    }
}