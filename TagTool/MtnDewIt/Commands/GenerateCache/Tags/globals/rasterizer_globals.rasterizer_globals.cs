using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class globals_rasterizer_globals_rasterizer_globals : TagFile
    {
        public globals_rasterizer_globals_rasterizer_globals(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<RasterizerGlobals>($@"globals\rasterizer_globals");
            var rasg = CacheContext.Deserialize<RasterizerGlobals>(Stream, tag);
            rasg.DefaultBitmaps = new List<RasterizerGlobals.DefaultBitmap>
            {
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_white"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\default_vector"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\default_dynamic_cube_map"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\default_environment_map"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Flags = RasterizerGlobals.DefaultBitmap.DefaultBitmapFlags.DoNotLoad,
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_black"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_black_alpha_black"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\gray_50_percent"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\auto_exposure_weight"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\auto_exposure_weight"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\dither_pattern2"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\random4_warp"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"levels\shared\bitmaps\nature\water\water_ripples"),
                },
                new RasterizerGlobals.DefaultBitmap
                {
                    Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\monochrome_random"),
                },
            };
            rasg.MaterialTextures = new List<RasterizerGlobals.MaterialTextureBlock>
            {
                new RasterizerGlobals.MaterialTextureBlock
                {
                    Bitmap = GetCachedTag<Bitmap>($@"rasterizer\cc0236"),
                },
                new RasterizerGlobals.MaterialTextureBlock
                {
                    Bitmap = GetCachedTag<Bitmap>($@"rasterizer\c78d78"),
                },
                new RasterizerGlobals.MaterialTextureBlock
                {
                    Bitmap = GetCachedTag<Bitmap>($@"rasterizer\dd0236"),
                },
            };
            rasg.DefaultVertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\simple");
            rasg.DefaultPixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\simple");
            rasg.DefaultShaders = new List<RasterizerGlobals.ExplicitShader>()
            {
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\debug"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\debug"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\debug2d"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\debug2d"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\copy_surface"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\copy_surface"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\spike_blur_vertical"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\spike_blur_vertical"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\spike_blur_horizontal"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\spike_blur_horizontal"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsize_2x_to_bloom"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsize_2x_to_bloom"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsize_2x_target"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsize_2x_target"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\copy_rgbe_to_rgb"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\copy_rgbe_to_rgb"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\update_persistence"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\update_persistence"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\add_downsampled"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\add_downsampled"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\add"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\add"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\blur_11_horizontal"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\blur_11_horizontal"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\blur_11_vertical"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\blur_11_vertical"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\cubemap_phi_blur"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\cubemap_phi_blur"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\cubemap_theta_blur"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\cubemap_theta_blur"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\cubemap_clamp"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\cubemap_clamp"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\cubemap_divide"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\cubemap_divide"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\write_depth"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\write_depth"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\final_composite"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\final_composite"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\sky_dome_simple"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\sky_dome_simple"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\transparent"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\transparent"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shield_meter"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shield_meter"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\legacy_meter"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\legacy_meter"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\overhead_map_geometry"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\overhead_map_geometry"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\legacy_hud_bitmap"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\legacy_hud_bitmap"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\blend3"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\blend3"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\particle_update"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\particle_update"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\particle_spawn"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\particle_spawn"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\screenshot_combine"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\screenshot_combine"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_2x2"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_2x2"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\rotate_2d"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\rotate_2d"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\bspline_resample"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\bspline_resample"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_bloom_dof"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_bloom_dof"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\final_composite_dof"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\final_composite_dof"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\kernel_5"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\kernel_5"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\exposure_downsample"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\exposure_downsample"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\yuv_to_rgb"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\yuv_to_rgb"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\displacement"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\displacement"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\screenshot_display"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\screenshot_display"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\crop"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\crop"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\screenshot_combine_dof"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\screenshot_combine_dof"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\gamma_correct"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\gamma_correct"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\contrail_spawn"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\contrail_spawn"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\contrail_update"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\contrail_update"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\stencil_stipple"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\stencil_stipple"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\lens_flare"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\lens_flare"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\decorator_default"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\decorator_default"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block_bloom"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block_bloom"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_gaussian"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_gaussian"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\apply_color_matrix"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\apply_color_matrix"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\copy"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\copy"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shadow_geometry"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shadow_geometry"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shadow_apply"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shadow_apply"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\gradient"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\gradient"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\alpha_test_explicit"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\alpha_test_explicit"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\patchy_fog"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\patchy_fog"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\light_volume_update"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\light_volume_update"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\water_ripple"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\water_ripple"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\double_gradient"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\double_gradient"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\sniper_scope"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\sniper_scope"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shield_impact"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shield_impact"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\player_emblem_world"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\player_emblem_world"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\player_emblem_screen"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\player_emblem_screen"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\implicit_hill"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\implicit_hill"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\chud_overlay_blend"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\chud_overlay_blend"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\bloom_add_alpha1"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\bloom_add_alpha1"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_ldr"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_ldr"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\restore_ldr_hdr_depth"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\restore_ldr_hdr_depth"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\beam_update"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\beam_update"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\decorator_no_wind"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\decorator_no_wind"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\decorator_static"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\decorator_static"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\decorator_sun"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\decorator_sun"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\decorator_wavy"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\decorator_wavy"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\final_composite_zoom"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\final_composite_zoom"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\final_composite_debug"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\final_composite_debug"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shadow_apply_point"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shadow_apply_point"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shadow_apply_bilinear"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shadow_apply_bilinear"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shadow_apply_fancy"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shadow_apply_fancy"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shadow_apply_faster"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shadow_apply_faster"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\shadow_apply"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\shadow_apply"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\displacement_motion_blur"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\displacement_motion_blur"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\decorator_shaded"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\decorator_shaded"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\screenshot_memexport"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\screenshot_memexport"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom_ldr"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom_ldr"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_new"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_new"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\bloom_curve"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\bloom_curve"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\custom_gamma_correct"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\custom_gamma_correct"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\pixel_copy"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\pixel_copy"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\decorator_edit"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\decorator_edit"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\hdr_retrieve"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\hdr_retrieve"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\smirnov"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\smirnov"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\fxaa"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\fxaa"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_94"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_94"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\sniper_scope_stencil_pc"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\sniper_scope_stencil_pc"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\ssao"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\ssao"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\ssao_blur"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\ssao_blur"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_98"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_98"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\lightshafts"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\lightshafts"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\radial_blur"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\radial_blur"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_101"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_101"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_102"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_102"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_103"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_103"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_104"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_104"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_105"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_105"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_106"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_106"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_107"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_107"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\hud_camera_nightvision"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\hud_camera_nightvision"),
                },
                new RasterizerGlobals.ExplicitShader()
                {
                    VertexShader = GetCachedTag<VertexShader>($@"rasterizer\shaders\unknown_109"),
                    PixelShader = GetCachedTag<PixelShader>($@"rasterizer\shaders\unknown_109"),
                },
            };
            rasg.ActiveCamoDistortion = GetCachedTag<Bitmap>($@"rasterizer\active_camouflage_distortion");
            rasg.DefaultPerformanceTemplate = GetCachedTag<PerformanceThrottles>($@"globals\default");
            rasg.DefaultShieldImpact = GetCachedTag<ShieldImpact>($@"globals\global_shield_impact_settings");
            rasg.DefaultVisionMode = GetCachedTag<VisionMode>($@"globals\default_vision_mode");
            rasg.MotionBlurParametersLegacy = new RasterizerGlobals.MotionBlurParametersLegacyBlock
            {
                NumberOfTaps = 6,
                MaxBlurX = 0.03f,
                MaxBlurY = 0.05f,
                BlurScaleX = 0.05f,
                BlurScaleY = 0.15f,
                CenterFalloff = 1.4f,
                ExpectedTimePerTick = 0.03f,
            };
            CacheContext.Serialize(Stream, tag, rasg);
        }
    }
}
