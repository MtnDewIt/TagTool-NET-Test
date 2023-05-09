using TagTool.Tags.Definitions;
using System.Collections.Generic;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        public void GenerateRasterizerGlobalsTag() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                var rasgTag = CacheContext.TagCache.AllocateTag<RasterizerGlobals>($@"globals\rasterizer_globals");
                var rasg = new RasterizerGlobals();
                CacheContext.Serialize(stream, rasgTag, rasg);
            }
        }

        public void RasterizerGlobalsSetup() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("rasg") && tag.Name == $@"globals\rasterizer_globals") 
                    {
                        var rasg = CacheContext.Deserialize<RasterizerGlobals>(stream, tag);
                        rasg.DefaultBitmaps = new List<RasterizerGlobals.DefaultBitmap>
                        {
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_white"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\default_vector"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\default_dynamic_cube_map"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\default_environment_map"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Flags = RasterizerGlobals.DefaultBitmap.DefaultBitmapFlags.DoNotLoad,
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_black"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_black_alpha_black"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\gray_50_percent"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\auto_exposure_weight"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\auto_exposure_weight"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\dither_pattern2"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\random4_warp"),
                            },
                            new RasterizerGlobals.DefaultBitmap
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"levels\shared\bitmaps\nature\water\water_ripples"),
                            },
                        };
                        rasg.MaterialTextures = new List<RasterizerGlobals.MaterialTextureBlock>
                        {
                            new RasterizerGlobals.MaterialTextureBlock
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"rasterizer\cc0236"),
                            },
                            new RasterizerGlobals.MaterialTextureBlock
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"rasterizer\c78d78"),
                            },
                            new RasterizerGlobals.MaterialTextureBlock
                            {
                                Bitmap = CacheContext.TagCache.GetTag<Bitmap>($@"rasterizer\dd0236"),
                            },
                        };
                        rasg.DefaultVertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\simple");
                        rasg.DefaultPixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\simple");
                        rasg.DefaultShaders = new List<RasterizerGlobals.ExplicitShader>()
                        {
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\debug"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\debug"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\debug2d"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\debug2d"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\copy_surface"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\copy_surface"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\spike_blur_vertical"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\spike_blur_vertical"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\spike_blur_horizontal"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\spike_blur_horizontal"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsize_2x_to_bloom"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsize_2x_to_bloom"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsize_2x_target"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsize_2x_target"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\copy_rgbe_to_rgb"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\copy_rgbe_to_rgb"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\update_persistence"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\update_persistence"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\add_downsampled"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\add_downsampled"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\add"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\add"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\blur_11_horizontal"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\blur_11_horizontal"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\blur_11_vertical"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\blur_11_vertical"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\cubemap_phi_blur"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\cubemap_phi_blur"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\cubemap_theta_blur"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\cubemap_theta_blur"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\cubemap_clamp"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\cubemap_clamp"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\cubemap_divide"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\cubemap_divide"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\write_depth"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\write_depth"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\final_composite"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\final_composite"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\sky_dome_simple"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\sky_dome_simple"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\transparent"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\transparent"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shield_meter"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shield_meter"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\legacy_meter"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\legacy_meter"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\overhead_map_geometry"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\overhead_map_geometry"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\legacy_hud_bitmap"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\legacy_hud_bitmap"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\blend3"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\blend3"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\particle_update"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\particle_update"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\particle_spawn"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\particle_spawn"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\screenshot_combine"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\screenshot_combine"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_2x2"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_2x2"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\rotate_2d"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\rotate_2d"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\bspline_resample"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\bspline_resample"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_bloom_dof"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_bloom_dof"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\final_composite_dof"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\final_composite_dof"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\kernel_5"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\kernel_5"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\exposure_downsample"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\exposure_downsample"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\yuv_to_rgb"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\yuv_to_rgb"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\displacement"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\displacement"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\screenshot_display"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\screenshot_display"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\crop"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\crop"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\screenshot_combine_dof"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\screenshot_combine_dof"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\gamma_correct"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\gamma_correct"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\contrail_spawn"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\contrail_spawn"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\contrail_update"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\contrail_update"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\stencil_stipple"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\stencil_stipple"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\lens_flare"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\lens_flare"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\decorator_default"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\decorator_default"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block_bloom"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block_bloom"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_gaussian"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_gaussian"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\apply_color_matrix"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\apply_color_matrix"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\copy"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\copy"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shadow_geometry"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shadow_geometry"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shadow_apply"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shadow_apply"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\gradient"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\gradient"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\alpha_test_explicit"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\alpha_test_explicit"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\patchy_fog"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\patchy_fog"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\light_volume_update"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\light_volume_update"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\water_ripple"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\water_ripple"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\double_gradient"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\double_gradient"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\sniper_scope"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\sniper_scope"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shield_impact"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shield_impact"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\player_emblem_world"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\player_emblem_world"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\player_emblem_screen"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\player_emblem_screen"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\implicit_hill"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\implicit_hill"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\chud_overlay_blend"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\chud_overlay_blend"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\bloom_add_alpha1"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\bloom_add_alpha1"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_ldr"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_ldr"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\restore_ldr_hdr_depth"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\restore_ldr_hdr_depth"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\beam_update"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\beam_update"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\decorator_no_wind"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\decorator_no_wind"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\decorator_static"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\decorator_static"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\decorator_sun"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\decorator_sun"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\decorator_wavy"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\decorator_wavy"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\final_composite_zoom"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\final_composite_zoom"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\final_composite_debug"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\final_composite_debug"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shadow_apply_point"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shadow_apply_point"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shadow_apply_bilinear"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shadow_apply_bilinear"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shadow_apply_fancy"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shadow_apply_fancy"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shadow_apply_faster"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shadow_apply_faster"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\shadow_apply"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\shadow_apply"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\displacement_motion_blur"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\displacement_motion_blur"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\decorator_shaded"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\decorator_shaded"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\screenshot_memexport"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\screenshot_memexport"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom_ldr"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom_ldr"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_gaussian_bloom"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_new"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\downsample_4x4_block_bloom_new"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\bloom_curve"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\bloom_curve"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\custom_gamma_correct"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\custom_gamma_correct"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\pixel_copy"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\pixel_copy"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_5A"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_5A"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\exposure_hdr_retrieve"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\exposure_hdr_retrieve"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_debug_5C"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_debug_5C"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\fxaa"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\fxaa"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_5E"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_5E"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_5F"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_5F"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\ssao_ldr"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\ssao_ldr"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\ssao_hdr"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\ssao_hdr"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\ssao_apply"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\ssao_apply"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\lightshafts"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\lightshafts"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\lightshafts_blur"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\lightshafts_blur"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\screen_space_reflection"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\screen_space_reflection"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_66"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_66"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\halve_depth_color"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\halve_depth_color"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\halve_depth_normal"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\halve_depth_normal"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_69"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_69"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\screen_space_reflection_blur"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\screen_space_reflection_blur"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_6B"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_6B"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\hud_camera_nightvision"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\hud_camera_nightvision"),
                            },
                            new RasterizerGlobals.ExplicitShader()
                            {
                                VertexShader = CacheContext.TagCache.GetTag<VertexShader>($@"rasterizer\shaders\unknown_6D"),
                                PixelShader = CacheContext.TagCache.GetTag<PixelShader>($@"rasterizer\shaders\unknown_6D"),
                            },
                        };
                        rasg.ActiveCamoDistortion = CacheContext.TagCache.GetTag<Bitmap>($@"rasterizer\active_camouflage_distortion");
                        rasg.DefaultPerformanceTemplate = CacheContext.TagCache.GetTag<PerformanceThrottles>($@"globals\default");
                        rasg.DefaultShieldImpact = CacheContext.TagCache.GetTag<ShieldImpact>($@"globals\global_shield_impact_settings");
                        rasg.DefaultVisionMode = CacheContext.TagCache.GetTag<VisionMode>($@"globals\default_vision_mode");
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
                        CacheContext.Serialize(stream, tag, rasg);
                    }
                }
            }
        }
    }
};