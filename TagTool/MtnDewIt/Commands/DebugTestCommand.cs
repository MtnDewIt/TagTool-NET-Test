using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.MtnDewIt.Commands.ConvertCache;
using TagTool.MtnDewIt.Shaders.LegacyShaderGenerator;
using TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;
using static TagTool.Commands.Shaders.GenerateShaderCommand;

namespace TagTool.MtnDewIt.Commands
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "DebugTest",
            "Calls on specific functions from within the specified class",
            "DebugTest",
            "Calls on specific functions from within the specified class. Assumes that the specified functions are public"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
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
                //UpdateRenderMethods(stream);

                new BeamDefinition(Cache, CacheContext, stream);
                new BlackDefinition(Cache, CacheContext, stream);
                new ContrailDefinition(Cache, CacheContext, stream);
                new CortanaDefinition(Cache, CacheContext, stream);
                new CustomDefinition(Cache, CacheContext, stream);
                new DecalDefinition(Cache, CacheContext, stream);
                new FoliageDefinition(Cache, CacheContext, stream);
                new HalogramDefinition(Cache, CacheContext, stream);
                new LightVolumeDefinition(Cache, CacheContext, stream);
                new ParticleDefinition(Cache, CacheContext, stream);
                new ScreenDefinition(Cache, CacheContext, stream);
                new ShaderDefinition(Cache, CacheContext, stream);
                new TerrainDefinition(Cache, CacheContext, stream);
                new WaterDefinition(Cache, CacheContext, stream);
                new ZOnlyDefinition(Cache, CacheContext, stream);

                // Ideally, this data would be applied when the tags are generated
                new shaders_beam_options_albedo_diffuse_only_render_method_option(Cache, CacheContext, stream);
                new shaders_beam_options_albedo_palettized_render_method_option(Cache, CacheContext, stream);
                new shaders_beam_options_albedo_palettized_plus_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_beam_options_global_beam_options_render_method_option(Cache, CacheContext, stream);
                new shaders_contrail_options_albedo_diffuse_only_render_method_option(Cache, CacheContext, stream);
                new shaders_contrail_options_albedo_palettized_render_method_option(Cache, CacheContext, stream);
                new shaders_contrail_options_albedo_palettized_plus_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_contrail_options_global_contrail_options_render_method_option(Cache, CacheContext, stream);
                new shaders_custom_options_albedo_waterfall_render_method_option(Cache, CacheContext, stream);
                new shaders_custom_options_alpha_test_multiply_map_render_method_option(Cache, CacheContext, stream);
                new shaders_custom_options_material_custom_specular_render_method_option(Cache, CacheContext, stream);
                new shaders_custom_options_window_room_map_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_diffuse_only_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_diffuse_plus_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_diffuse_plus_alpha_mask_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_emblem_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_palettized_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_palettized_plus_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_palettized_plus_alpha_mask_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_vector_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_albedo_vector_alpha_drop_shadow_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_bump_mapping_standard_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_bump_mapping_standard_mask_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_global_decal_options_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_specular_modulate_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_tinting_fully_modulated_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_tinting_partially_modulated_render_method_option(Cache, CacheContext, stream);
                new shaders_decal_options_tinting_unmodulated_render_method_option(Cache, CacheContext, stream);
                new shaders_foliage_options_material_default_render_method_option(Cache, CacheContext, stream);
                new shaders_light_volume_options_albedo_circular_render_method_option(Cache, CacheContext, stream);
                new shaders_light_volume_options_albedo_diffuse_only_render_method_option(Cache, CacheContext, stream);
                new shaders_light_volume_options_global_light_volume_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_diffuse_modulated_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_diffuse_only_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_diffuse_plus_billboard_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_diffuse_plus_sprite_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_palettized_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_palettized_glow_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_palettized_plasma_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_palettized_plus_billboard_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_albedo_palettized_plus_sprite_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_depth_fade_on_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_depth_fade_palette_shift_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_frame_blend_on_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_global_particle_options_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_self_illumination_constant_color_render_method_option(Cache, CacheContext, stream);
                new shaders_particle_options_specialized_rendering_distortion_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_base_single_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_blend_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_detail_a_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_detail_mask_a_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_global_screen_options_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_illum_palettized_plasma_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_overlay_tint_add_color_render_method_option(Cache, CacheContext, stream);
                new shaders_screen_options_warp_simple_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_chameleon_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_chameleon_albedo_masked_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_chameleon_masked_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_color_mask_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_color_mask_hard_light_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_constant_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_custom_cube_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_default_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_detail_blend_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_emblem_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_four_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_simple_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_three_detail_blend_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_change_color_anim_overlay_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_change_color_chameleon_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_change_color_tex_overlay_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_color_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_detail_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_detail_black_point_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_albedo_two_detail_overlay_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_alpha_test_off_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_alpha_test_on_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_bump_default_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_bump_detail_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_bump_detail_masked_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_bump_detail_plus_detail_masked_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_bump_detail_unorm_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_bump_off_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_cortana_albedo_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_cortana_screenspace_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_cortana_transparency_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_edge_fade_simple_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_env_map_dynamic_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_env_map_from_flat_texture_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_env_map_per_pixel_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_glass_material_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_global_shader_options_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_3_channel_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_change_color_detail_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_detail_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_from_diffuse_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_meter_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_multilayer_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_multilayer_five_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_multilayer_four_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_palettized_depth_fade_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_palettized_plasma_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_plasma_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_scope_blur_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_simple_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_simple_four_change_color_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_illum_times_diffuse_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_car_paint_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_cook_torrance_option_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_cook_torrance_rim_fresnel_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_diffuse_only_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_foliage_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_hair_option_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_organism_option_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_material_two_lobe_phong_option_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_overlay_additive_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_overlay_additive_detail_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_overlay_multiply_additive_detail_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_parallax_detail_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_parallax_simple_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_sfx_distort_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_single_lobe_phong_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_soft_fade_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_specular_mask_from_texture_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_warp_cortana_default_render_method_option(Cache, CacheContext, stream);
                new shaders_shader_options_warp_from_texture_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_default_blending_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_only_m_0_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_only_m_1_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_only_m_2_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_only_m_3_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_only_plus_sefl_illum_m_0_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_only_plus_sefl_illum_m_1_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_only_plus_sefl_illum_m_2_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_m_0_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_m_1_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_m_2_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_m_3_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_plus_heightmap_m_0_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_plus_heightmap_m_1_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_plus_self_illumm_0_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_plus_self_illumm_1_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_plus_self_illumm_2_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_plus_up_vector_plus_heightmap_m_0_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_specular_plus_up_vector_plus_heightmap_m_1_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_diffuse_plus_two_detail_m_0_render_method_option(Cache, CacheContext, stream);
                new shaders_terrain_options_dynamic_blending_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_appearance_default_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_bankalpha_depth_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_bankalpha_from_shape_texture_alpha_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_bankalpha_paint_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_foam_auto_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_foam_both_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_foam_none_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_foam_paint_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_globalshape_depth_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_globalshape_paint_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_reach_compatibility_enabled_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_reflection_dynamic_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_reflection_static_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_refraction_dynamic_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_watercolor_pure_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_watercolor_texture_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_water_global_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_waveshape_bump_render_method_option(Cache, CacheContext, stream);
                new shaders_water_options_waveshape_default_render_method_option(Cache, CacheContext, stream);

                Cache.SaveStrings();

                //GenerateGlobalShaders(stream);
            }
        }

        // CURRENT ISSUES:
        // - Broken Distortion Diffuse
        // - Broken Weapon Screen Shaders
        // - Broken Halogram Shaders? (Visible on s3d_waterfall and s3d_lockout)

        // TODO: FIX ISSUES!

        public void UpdateRenderMethods(Stream stream)
        {
            GenerateRenderMethod(stream, $@"beam", true);
            GenerateRenderMethod(stream, $@"black", true);
            GenerateRenderMethod(stream, $@"contrail", true);
            GenerateRenderMethod(stream, $@"cortana", true);
            GenerateRenderMethod(stream, $@"custom", true);
            GenerateRenderMethod(stream, $@"decal", true);
            GenerateRenderMethod(stream, $@"foliage", true);
            GenerateRenderMethod(stream, $@"halogram", true);
            GenerateRenderMethod(stream, $@"light_volume", true);
            GenerateRenderMethod(stream, $@"particle", true);
            GenerateRenderMethod(stream, $@"screen", true);
            GenerateRenderMethod(stream, $@"shader", true);
            GenerateRenderMethod(stream, $@"terrain", true);
            GenerateRenderMethod(stream, $@"water", true);
            GenerateRenderMethod(stream, $@"zonly", true);
        }

        public void GenerateRenderMethods(Stream stream)
        {
            GenerateRenderMethod(stream, $@"beam", false);
            GenerateRenderMethod(stream, $@"black", false);
            GenerateRenderMethod(stream, $@"contrail", false);
            GenerateRenderMethod(stream, $@"cortana", false);
            GenerateRenderMethod(stream, $@"custom", false);
            GenerateRenderMethod(stream, $@"decal", false);
            GenerateRenderMethod(stream, $@"foliage", false);
            GenerateRenderMethod(stream, $@"halogram", false);
            GenerateRenderMethod(stream, $@"light_volume", false);
            GenerateRenderMethod(stream, $@"particle", false);
            GenerateRenderMethod(stream, $@"screen", false);
            GenerateRenderMethod(stream, $@"shader", false);
            GenerateRenderMethod(stream, $@"terrain", false);
            GenerateRenderMethod(stream, $@"water", false);
            GenerateRenderMethod(stream, $@"zonly", false);
        }

        public void GenerateGlobalShaders(Stream stream)
        {
            GenerateGlobalShader(stream, $@"beam", false);
            GenerateGlobalShader(stream, $@"black", false);
            //GenerateGlobalShader(stream, $@"contrail", false);
            GenerateGlobalShader(stream, $@"cortana", false);
            GenerateGlobalShader(stream, $@"custom", false);
            GenerateGlobalShader(stream, $@"decal", false);
            GenerateGlobalShader(stream, $@"foliage", false);
            GenerateGlobalShader(stream, $@"halogram", false);
            //GenerateGlobalShader(stream, $@"lightvolume", false);
            //GenerateGlobalShader(stream, $@"particle", false);
            GenerateGlobalShader(stream, $@"screen", false);
            GenerateGlobalShader(stream, $@"shader", false);
            GenerateGlobalShader(stream, $@"terrain", false);
            GenerateGlobalShader(stream, $@"water", false);
            GenerateGlobalShader(stream, $@"zonly", false);

            GenerateGlobalShader(stream, $@"beam", true);
            GenerateGlobalShader(stream, $@"black", true);
            GenerateGlobalShader(stream, $@"contrail", true);
            GenerateGlobalShader(stream, $@"cortana", true);
            GenerateGlobalShader(stream, $@"custom", true);
            GenerateGlobalShader(stream, $@"decal", true);
            GenerateGlobalShader(stream, $@"foliage", true);
            GenerateGlobalShader(stream, $@"halogram", true);
            GenerateGlobalShader(stream, $@"lightvolume", true);
            GenerateGlobalShader(stream, $@"particle", true);
            GenerateGlobalShader(stream, $@"screen", true);
            GenerateGlobalShader(stream, $@"shader", true);
            GenerateGlobalShader(stream, $@"terrain", true);
            GenerateGlobalShader(stream, $@"water", true);
            GenerateGlobalShader(stream, $@"zonly", true);
        }

        public void RecompileShaders(Stream stream)
        {
            RecompileShaders(stream, $@"beam");
            RecompileShaders(stream, $@"black");
            RecompileShaders(stream, $@"contrail");
            RecompileShaders(stream, $@"cortana");
            RecompileShaders(stream, $@"custom");
            RecompileShaders(stream, $@"decal");
            RecompileShaders(stream, $@"foliage");
            RecompileShaders(stream, $@"halogram");
            RecompileShaders(stream, $@"light_volume");
            RecompileShaders(stream, $@"particle");
            RecompileShaders(stream, $@"screen");
            RecompileShaders(stream, $@"shader");
            RecompileShaders(stream, $@"terrain");
            RecompileShaders(stream, $@"water");
            RecompileShaders(stream, $@"zonly");
        }

        public void GenerateRenderMethod(Stream stream, string shaderType, bool updateRenderMethod)
        {
            if (updateRenderMethod)
            {
                LegacyRenderMethodDefinitionGenerator.UpdateRenderMethodDefinition(Cache, stream, shaderType);
            }

            else
            {
                var generator = LegacyShaderGenerator.GetLegacyGlobalShaderGenerator(shaderType, true);

                if (!CacheContext.TagCache.TryGetTag<RenderMethodDefinition>($@"shaders\{shaderType}", out CachedTag rmdfTag))
                {
                    rmdfTag = CacheContext.TagCache.AllocateTag<RenderMethodDefinition>($@"shaders\{shaderType}");
                }

                var rmdf = LegacyRenderMethodDefinitionGenerator.GenerateRenderMethodDefinition(Cache, stream, generator, shaderType, out _, out _);
                CacheContext.Serialize(stream, rmdfTag, rmdf);

                CacheContext.SaveTagNames();
                CacheContext.SaveStrings();
            }
        }

        public void GenerateGlobalShader(Stream stream, string shaderType, bool pixel)
        {
            var type = (HaloShaderGenerator.Globals.ShaderType)Enum.Parse(typeof(HaloShaderGenerator.Globals.ShaderType), shaderType, true);

            CachedTag rmdfTag = null;

            if (shaderType == "lightvolume")
            {
                rmdfTag = Cache.TagCache.GetTag($"shaders\\light_volume.rmdf");
            }
            else
            {
                rmdfTag = Cache.TagCache.GetTag($"shaders\\{shaderType}.rmdf");
            }

            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            if (pixel)
            {
                GlobalPixelShader glps = ShaderGeneratorNew.GenerateSharedPixelShaders(Cache, rmdf, type);
                Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            }
            else
            {
                GlobalVertexShader glvs = ShaderGeneratorNew.GenerateSharedVertexShaders(Cache, rmdf, type);
                Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
            }
        }

        public void RecompileShaders(Stream stream, string shaderType) 
        {
            if (!Cache.TagCache.TryGetTag($"shaders\\{shaderType}.rmdf", out CachedTag rmdfTag))
                new TagToolError(CommandError.TagInvalid, $"Missing \"{shaderType}\" rmdf");

            var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            if (rmdf.GlobalVertexShader == null || rmdf.GlobalPixelShader == null)
                new TagToolError(CommandError.TagInvalid, "A global shader was missing from rmdf");

            var glvs = Cache.Deserialize<GlobalVertexShader>(stream, rmdf.GlobalVertexShader);
            var glps = Cache.Deserialize<GlobalPixelShader>(stream, rmdf.GlobalPixelShader);

            List<CachedTag> regenTags = new List<CachedTag>();
            foreach (var tag in Cache.TagCache.NonNull())
            {
                if (tag.Group.Tag != "rmt2" ||
                    tag.Name.StartsWith("ms30") ||
                    !tag.Name.Split('\\')[1].StartsWith(shaderType + "_templates"))
                    continue;
                regenTags.Add(tag);
            }

            List<STemplateRecompileInfo> recompileInfo = new List<STemplateRecompileInfo>();

            foreach (var tag in regenTags)
            {
                List<byte> options = new List<byte>();
                foreach (var option in tag.Name.Split('\\')[2].Remove(0, 1).Split('_'))
                    options.Add(byte.Parse(option));
                while (options.Count < rmdf.Categories.Count)
                    options.Add(0);
                var aOptions = options.ToArray();

                STemplateRecompileInfo info = new STemplateRecompileInfo
                {
                    Name = $"shaders\\{shaderType}_templates\\_{string.Join("_", aOptions)}",
                    ShaderType = shaderType,
                    Options = aOptions,
                    Tag = tag,
                    Dependants = GetDependantsAsync(Cache, stream, shaderType, aOptions),
                    AllRmopParameters = ShaderGeneratorNew.GatherParameters(Cache, stream, rmdf, options)
                };

                recompileInfo.Add(info);
            }

            List<Task<STemplateRecompileInfo>> tasks = new List<Task<STemplateRecompileInfo>>();

            foreach (var info in recompileInfo)
            {
                Task<STemplateRecompileInfo> generatorTask = Task.Run(() => {
                    return GenerateRenderMethodTemplateAsync(Cache, info, rmdf, glvs, glps);
                });
                tasks.Add(generatorTask);
            }

            // serialize
            foreach (var task in tasks)
            {
                if (!Cache.TagCache.TryGetTag(task.Result.Name + ".pixl", out task.Result.Template.PixelShader))
                    task.Result.Template.PixelShader = Cache.TagCache.AllocateTag<PixelShader>(task.Result.Name);
                if (!Cache.TagCache.TryGetTag(task.Result.Name + ".vtsh", out task.Result.Template.VertexShader))
                    task.Result.Template.VertexShader = Cache.TagCache.AllocateTag<VertexShader>(task.Result.Name);

                Cache.Serialize(stream, task.Result.Template.PixelShader, task.Result.PixelShader);
                Cache.Serialize(stream, task.Result.Template.VertexShader, task.Result.VertexShader);
                Cache.Serialize(stream, task.Result.Tag, task.Result.Template);

                (Cache as GameCacheHaloOnlineBase).SaveTagNames();

                ReserializeDependantsAsync(Cache, stream, task.Result.Template, task.Result.Dependants);
            }

            // validation
            foreach (var task in tasks)
            {
                var rmt2 = Cache.Deserialize<RenderMethodTemplate>(stream, task.Result.Tag);
                var pixl = Cache.Deserialize<PixelShader>(stream, rmt2.PixelShader);

                if (rmt2.PixelShader.Name == null || rmt2.PixelShader.Name == "")
                    new TagToolWarning($"pixel_shader {rmt2.PixelShader.Index:X16} has no name");

                for (int i = 0; i < pixl.EntryPointShaders.Count; i++)
                {
                    bool entryNeeded = rmdf.EntryPoints.Any(x => (int)x.EntryPoint == i) &&
                        (glps.EntryPoints[i].DefaultCompiledShaderIndex == -1 && glps.EntryPoints[i].CategoryDependency.Count == 0);

                    if (pixl.EntryPointShaders[i].Count > 0 && !entryNeeded)
                        new TagToolWarning($"{rmt2.PixelShader.Name} has unneeded entry point shader {(TagTool.Shaders.EntryPoint)i}");

                    if (pixl.EntryPointShaders[i].Count == 0 && entryNeeded)
                        new TagToolWarning($"{rmt2.PixelShader.Name} missing entry point shader {(TagTool.Shaders.EntryPoint)i}");

                    if (pixl.EntryPointShaders[i].Count > 0 && pixl.EntryPointShaders[i].Offset >= pixl.Shaders.Count)
                        new TagToolWarning($"{rmt2.PixelShader.Name} has invalid compiled shader indices {i}");
                }
            }
        }
    }
}