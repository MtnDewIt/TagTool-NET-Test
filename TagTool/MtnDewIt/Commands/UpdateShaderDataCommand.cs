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