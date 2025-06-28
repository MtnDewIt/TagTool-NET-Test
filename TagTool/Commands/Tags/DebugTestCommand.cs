using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Commands.Common;
using System;
using System.IO;
using TagTool.IO;
using TagTool.BlamFile;
using Newtonsoft.Json;
using TagTool.BlamFile.MCC;
using System.Linq;
using TagTool.Shaders.ShaderGenerator;
using HaloShaderGenerator.Globals;
using TagTool.Commands.Shaders;
using TagTool.Shaders.ShaderMatching;
using TagTool.Commands.JSON;

namespace TagTool.Commands.Tags
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, CommandContextStack contextStack) : base
        (
            false,
            "DebugTest",
            "Self Explanatory",

            "DebugTest",
            "Self Explanatory"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                //SHADER UNIT TEST
                //1.Generate Render Method Definitions

                GenerateRenderMethodDefinition(stream, ShaderType.Beam);
                GenerateRenderMethodDefinition(stream, ShaderType.Black);
                GenerateRenderMethodDefinition(stream, ShaderType.Contrail);
                GenerateRenderMethodDefinition(stream, ShaderType.Cortana);
                GenerateRenderMethodDefinition(stream, ShaderType.Custom);
                GenerateRenderMethodDefinition(stream, ShaderType.Decal);
                GenerateRenderMethodDefinition(stream, ShaderType.Foliage);
                GenerateRenderMethodDefinition(stream, ShaderType.Fur);
                GenerateRenderMethodDefinition(stream, ShaderType.FurStencil);
                GenerateRenderMethodDefinition(stream, ShaderType.Glass);
                GenerateRenderMethodDefinition(stream, ShaderType.Halogram);
                GenerateRenderMethodDefinition(stream, ShaderType.LightVolume);
                GenerateRenderMethodDefinition(stream, ShaderType.Mux);
                GenerateRenderMethodDefinition(stream, ShaderType.Particle);
                GenerateRenderMethodDefinition(stream, ShaderType.Screen);
                GenerateRenderMethodDefinition(stream, ShaderType.Shader);
                GenerateRenderMethodDefinition(stream, ShaderType.Terrain);
                GenerateRenderMethodDefinition(stream, ShaderType.Water);
                GenerateRenderMethodDefinition(stream, ShaderType.ZOnly);

                //2.Generate Global Shaders For Each Render Method Type

                GenerateGlobalShader(stream, ShaderType.Beam);
                GenerateGlobalShader(stream, ShaderType.Black);
                GenerateGlobalShader(stream, ShaderType.Contrail);
                GenerateGlobalShader(stream, ShaderType.Cortana);
                GenerateGlobalShader(stream, ShaderType.Custom);                
                GenerateGlobalShader(stream, ShaderType.Decal);                 
                GenerateGlobalShader(stream, ShaderType.Foliage, false);        
                GenerateGlobalShader(stream, ShaderType.Fur);
                GenerateGlobalShader(stream, ShaderType.FurStencil);
                GenerateGlobalShader(stream, ShaderType.Glass);
                GenerateGlobalShader(stream, ShaderType.Halogram);
                GenerateGlobalShader(stream, ShaderType.LightVolume);
                GenerateGlobalShader(stream, ShaderType.Mux);
                GenerateGlobalShader(stream, ShaderType.Particle);
                GenerateGlobalShader(stream, ShaderType.Screen);
                GenerateGlobalShader(stream, ShaderType.Shader);
                GenerateGlobalShader(stream, ShaderType.Terrain);
                GenerateGlobalShader(stream, ShaderType.Water);          
                GenerateGlobalShader(stream, ShaderType.ZOnly);

                //3.Generate All Chud Shaders

                var chgdTag = Cache.TagCache.AllocateTag<ChudGlobalsDefinition>($"ui\\chud\\globals");
                var chgd = new ChudGlobalsDefinition { HudShaders = new List<ChudGlobalsDefinition.HudShader>() };

                GenerateChudShader(stream, chgd, ChudShader.chud_simple, false);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter);
                GenerateChudShader(stream, chgd, ChudShader.chud_text_simple, false);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter_shield, false);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter_gradient);
                GenerateChudShader(stream, chgd, ChudShader.chud_crosshair);
                GenerateChudShader(stream, chgd, ChudShader.chud_directional_damage);
                GenerateChudShader(stream, chgd, ChudShader.chud_solid);
                GenerateChudShader(stream, chgd, ChudShader.chud_sensor);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter_single_color);
                GenerateChudShader(stream, chgd, ChudShader.chud_navpoint);
                GenerateChudShader(stream, chgd, ChudShader.chud_medal);
                GenerateChudShader(stream, chgd, ChudShader.chud_texture_cam);
                GenerateChudShader(stream, chgd, ChudShader.chud_cortana_screen);
                GenerateChudShader(stream, chgd, ChudShader.chud_cortana_camera);
                GenerateChudShader(stream, chgd, ChudShader.chud_cortana_offscreen);
                GenerateChudShader(stream, chgd, ChudShader.chud_cortana_screen_final);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter_chapter);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter_double_gradient);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter_radial_gradient);
                GenerateChudShader(stream, chgd, ChudShader.chud_turbulence);
                GenerateChudShader(stream, chgd, ChudShader.chud_emblem);
                GenerateChudShader(stream, chgd, ChudShader.chud_cortana_composite, false);
                GenerateChudShader(stream, chgd, ChudShader.chud_directional_damage_apply);
                GenerateChudShader(stream, chgd, ChudShader.chud_really_simple);
                GenerateChudShader(stream, chgd, ChudShader.chud_meter_gradient_inverse);

                Cache.Serialize(stream, chgdTag, chgd);

                //4.Generate All Explicit Shaders

                var rasgTag = Cache.TagCache.AllocateTag<ChudGlobalsDefinition>($"globals\\rasterizer_globals");
                var rasg = new RasterizerGlobals { DefaultShaders = new List<RasterizerGlobals.ExplicitShader>() };

                GenerateExplicitShader(stream, rasg, ExplicitShader.debug);
                GenerateExplicitShader(stream, rasg, ExplicitShader.debug2d);
                GenerateExplicitShader(stream, rasg, ExplicitShader.copy_surface);
                GenerateExplicitShader(stream, rasg, ExplicitShader.spike_blur_vertical);
                GenerateExplicitShader(stream, rasg, ExplicitShader.spike_blur_horizontal);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsize_2x_to_bloom);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsize_2x_target);
                GenerateExplicitShader(stream, rasg, ExplicitShader.copy_rgbe_to_rgb);
                GenerateExplicitShader(stream, rasg, ExplicitShader.update_persistence);
                GenerateExplicitShader(stream, rasg, ExplicitShader.add_downsampled);
                GenerateExplicitShader(stream, rasg, ExplicitShader.add);
                GenerateExplicitShader(stream, rasg, ExplicitShader.blur_11_horizontal, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.blur_11_vertical, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.cubemap_phi_blur);
                GenerateExplicitShader(stream, rasg, ExplicitShader.cubemap_theta_blur);
                GenerateExplicitShader(stream, rasg, ExplicitShader.cubemap_clamp);
                GenerateExplicitShader(stream, rasg, ExplicitShader.cubemap_divide);
                GenerateExplicitShader(stream, rasg, ExplicitShader.write_depth);
                GenerateExplicitShader(stream, rasg, ExplicitShader.final_composite);
                GenerateExplicitShader(stream, rasg, ExplicitShader.sky_dome_simple);
                GenerateExplicitShader(stream, rasg, ExplicitShader.transparent);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shield_meter);
                GenerateExplicitShader(stream, rasg, ExplicitShader.legacy_meter);
                GenerateExplicitShader(stream, rasg, ExplicitShader.overhead_map_geometry);
                GenerateExplicitShader(stream, rasg, ExplicitShader.legacy_hud_bitmap);
                GenerateExplicitShader(stream, rasg, ExplicitShader.blend3);
                GenerateExplicitShader(stream, rasg, ExplicitShader.particle_update);
                GenerateExplicitShader(stream, rasg, ExplicitShader.particle_spawn);
                GenerateExplicitShader(stream, rasg, ExplicitShader.screenshot_combine, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_2x2);
                GenerateExplicitShader(stream, rasg, ExplicitShader.rotate_2d);
                GenerateExplicitShader(stream, rasg, ExplicitShader.bspline_resample);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_bloom_dof);
                GenerateExplicitShader(stream, rasg, ExplicitShader.final_composite_dof);
                GenerateExplicitShader(stream, rasg, ExplicitShader.kernel_5, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.exposure_downsample);
                GenerateExplicitShader(stream, rasg, ExplicitShader.yuv_to_rgb);
                GenerateExplicitShader(stream, rasg, ExplicitShader.displacement);
                GenerateExplicitShader(stream, rasg, ExplicitShader.screenshot_display);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_block);
                GenerateExplicitShader(stream, rasg, ExplicitShader.crop);
                GenerateExplicitShader(stream, rasg, ExplicitShader.screenshot_combine_dof, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.gamma_correct);
                GenerateExplicitShader(stream, rasg, ExplicitShader.contrail_spawn);
                GenerateExplicitShader(stream, rasg, ExplicitShader.contrail_update);
                GenerateExplicitShader(stream, rasg, ExplicitShader.stencil_stipple);
                GenerateExplicitShader(stream, rasg, ExplicitShader.lens_flare);
                GenerateExplicitShader(stream, rasg, ExplicitShader.decorator_default);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_block_bloom);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_gaussian);
                GenerateExplicitShader(stream, rasg, ExplicitShader.apply_color_matrix);
                GenerateExplicitShader(stream, rasg, ExplicitShader.copy);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shadow_geometry);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shadow_apply);
                GenerateExplicitShader(stream, rasg, ExplicitShader.gradient, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.alpha_test_explicit);
                GenerateExplicitShader(stream, rasg, ExplicitShader.patchy_fog, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.light_volume_update);
                GenerateExplicitShader(stream, rasg, ExplicitShader.water_ripple);
                GenerateExplicitShader(stream, rasg, ExplicitShader.double_gradient, false);
                GenerateExplicitShader(stream, rasg, ExplicitShader.sniper_scope);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shield_impact);
                GenerateExplicitShader(stream, rasg, ExplicitShader.player_emblem_world);
                GenerateExplicitShader(stream, rasg, ExplicitShader.player_emblem_screen);
                GenerateExplicitShader(stream, rasg, ExplicitShader.implicit_hill);
                GenerateExplicitShader(stream, rasg, ExplicitShader.chud_overlay_blend);
                GenerateExplicitShader(stream, rasg, ExplicitShader.bloom_add_alpha1);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_block_bloom_ldr);
                GenerateExplicitShader(stream, rasg, ExplicitShader.restore_ldr_hdr_depth);
                GenerateExplicitShader(stream, rasg, ExplicitShader.beam_update);
                GenerateExplicitShader(stream, rasg, ExplicitShader.decorator_no_wind);
                GenerateExplicitShader(stream, rasg, ExplicitShader.decorator_static);
                GenerateExplicitShader(stream, rasg, ExplicitShader.decorator_sun);
                GenerateExplicitShader(stream, rasg, ExplicitShader.decorator_wavy);
                GenerateExplicitShader(stream, rasg, ExplicitShader.final_composite_zoom);
                GenerateExplicitShader(stream, rasg, ExplicitShader.final_composite_debug);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shadow_apply_point);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shadow_apply_bilinear);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shadow_apply_fancy);
                GenerateExplicitShader(stream, rasg, ExplicitShader.shadow_apply_faster);
                GenerateExplicitShader(stream, rasg, ExplicitShader.displacement_motion_blur);
                GenerateExplicitShader(stream, rasg, ExplicitShader.decorator_shaded);
                GenerateExplicitShader(stream, rasg, ExplicitShader.screenshot_memexport);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_gaussian_bloom_ldr);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_gaussian_bloom);
                GenerateExplicitShader(stream, rasg, ExplicitShader.downsample_4x4_block_bloom_new);
                GenerateExplicitShader(stream, rasg, ExplicitShader.bloom_curve);
                GenerateExplicitShader(stream, rasg, ExplicitShader.custom_gamma_correct);
                GenerateExplicitShader(stream, rasg, ExplicitShader.pixel_copy);
                GenerateExplicitShader(stream, rasg, ExplicitShader.decorator_edit);
                GenerateExplicitShader(stream, rasg, ExplicitShader.hdr_retrieve);
                GenerateExplicitShader(stream, rasg, ExplicitShader.smirnov);
                GenerateExplicitShader(stream, rasg, ExplicitShader.fxaa);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_94);
                GenerateExplicitShader(stream, rasg, ExplicitShader.sniper_scope_stencil_pc);
                GenerateExplicitShader(stream, rasg, ExplicitShader.ssao);
                GenerateExplicitShader(stream, rasg, ExplicitShader.ssao_blur);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_98);
                GenerateExplicitShader(stream, rasg, ExplicitShader.lightshafts);
                GenerateExplicitShader(stream, rasg, ExplicitShader.radial_blur);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_101);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_102);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_103);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_104);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_105);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_106);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_107);
                GenerateExplicitShader(stream, rasg, ExplicitShader.hud_camera_nightvision);
                GenerateExplicitShader(stream, rasg, ExplicitShader.unknown_109);

                Cache.Serialize(stream, rasgTag, rasg);

                //5.Generate All Possible Templates For Each Category And Option
                //6.Maybe attempt to generate a shader for each render method type to ensure that all parameters are being referenced correctly

                foreach (ShaderType shaderType in Enum.GetValues(typeof(ShaderType)))
                {
                    TemplateUnitTest(stream, shaderType);
                }
            }

            //7.Disassemble Data For Each Explicit Shader, Chud Shader and Render Method Type

            new DumpDisassembledShadersCommand(Cache).Execute(new List<string> { "Current" });

            foreach (var tag in Cache.TagCache.NonNull())
            {
                if (tag.IsInGroup("rmdf"))
                {
                    new GenerateTagObjectCommand(Cache, Cache as GameCacheHaloOnline).Execute(new List<string> { $@"{tag.Name}.{tag.Group}", $@"Recursive", $@"Current" });
                }
            }

            //8.Dump Diassembled Data from ED and MS23 (use as a comparision point to check if APPLY_FIXES functions correctly)

            var ms23Cache = GameCache.Open(new FileInfo(args[0]));

            new DumpDisassembledShadersCommand(ms23Cache).Execute(new List<string> { "MS23" });

            foreach (var tag in ms23Cache.TagCache.NonNull())
            {
                if (tag.IsInGroup("rmdf"))
                {
                    new GenerateTagObjectCommand(ms23Cache, ms23Cache as GameCacheHaloOnline).Execute(new List<string> { $@"{tag.Name}.{tag.Group}", $@"Recursive", $@"MS23" });
                }
            }

            var edCache = GameCache.Open(new FileInfo(args[1]));

            new DumpDisassembledShadersCommand(edCache).Execute(new List<string> { "ElDewrito" });

            foreach (var tag in edCache.TagCache.NonNull())
            {
                if (tag.IsInGroup("rmdf"))
                {
                    new GenerateTagObjectCommand(edCache, edCache as GameCacheHaloOnline).Execute(new List<string> { $@"{tag.Name}.{tag.Group}", $@"Recursive", $@"ElDewrito" });
                }
            }

            //We're gonna need to revert our changes :/
            //RESET ENTRY POINTS
            //REMOVE UNUSED FUNCTIONS
            //FOR ADDED REACH RENDER METHOD TYPES, REFERENCE GLASS IMPLEMENTATION TO FIX

            return true;
        }

        void GenerateRenderMethodDefinition(Stream stream, ShaderType shaderType, bool applyFixes = true)
        {
            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            switch (shaderType)
            {
                case ShaderType.LightVolume:
                    rmdfName = "shaders\\light_volume";
                    break;
                case ShaderType.FurStencil:
                    rmdfName = "shaders\\fur_stencil";
                    break;
            }

            var generator = ShaderGenerator.GetGlobalShaderGenerator(shaderType);

            if (!Cache.TagCache.TryGetTag<RenderMethodDefinition>(rmdfName, out CachedTag rmdfTag))
            {
                rmdfTag = Cache.TagCache.AllocateTag<RenderMethodDefinition>(rmdfName);
            }

            var rmdf = RenderMethodDefinitionGenerator.GenerateRenderMethodDefinition(Cache, stream, generator, shaderType, false, applyFixes);

            Cache.Serialize(stream, rmdfTag, rmdf);
        }

        public void GenerateGlobalShader(Stream stream, ShaderType shaderType, bool applyFixes = true)
        {
            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            switch (shaderType)
            {
                case ShaderType.LightVolume:
                    rmdfName = "shaders\\light_volume";
                    break;
                case ShaderType.FurStencil:
                    rmdfName = "shaders\\fur_stencil";
                    break;
            }

            CachedTag rmdfTag = Cache.TagCache.GetTag<RenderMethodDefinition>(rmdfName);
            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            GlobalPixelShader glps = ShaderGeneratorNew.GenerateSharedPixelShaders(Cache, rmdf, shaderType, applyFixes);
            GlobalVertexShader glvs = ShaderGeneratorNew.GenerateSharedVertexShaders(Cache, rmdf, shaderType, applyFixes);

            Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
        }

        public void GenerateExplicitShader(Stream stream, RasterizerGlobals rasg, ExplicitShader shader, bool applyFixes = true)
        {
            if (!Cache.TagCache.TryGetTag<PixelShader>($"rasterizer\\shaders\\{shader}", out CachedTag pixlTag))
                pixlTag = Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");

            if (!Cache.TagCache.TryGetTag<VertexShader>($"rasterizer\\shaders\\{shader}", out CachedTag vtshTag))
                vtshTag = Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            ShaderGeneratorNew.GenerateExplicitShader(Cache, stream, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);

            rasg.DefaultShaders.Add(new RasterizerGlobals.ExplicitShader { VertexShader = vtshTag, PixelShader = pixlTag });
        }

        public void GenerateChudShader(Stream stream, ChudGlobalsDefinition chgd, ChudShader shader, bool applyFixes = true)
        {
            if (!Cache.TagCache.TryGetTag<PixelShader>($"rasterizer\\shaders\\{shader}", out CachedTag pixlTag))
                pixlTag = Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");

            if (!Cache.TagCache.TryGetTag<VertexShader>($"rasterizer\\shaders\\{shader}", out CachedTag vtshTag))
                vtshTag = Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            ShaderGeneratorNew.GenerateChudShader(Cache, stream, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);

            chgd.HudShaders.Add(new ChudGlobalsDefinition.HudShader { VertexShader = vtshTag, PixelShader = pixlTag });
        }

        public void TemplateUnitTest(Stream stream, ShaderType shaderType)
        {
            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            switch (shaderType)
            {
                case ShaderType.LightVolume:
                    rmdfName = "shaders\\light_volume";
                    break;
                case ShaderType.FurStencil:
                    rmdfName = "shaders\\fur_stencil";
                    break;
            }

            var tag = Cache.TagCache.GetTag<RenderMethodDefinition>(rmdfName);
            var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, tag);

            for (int i = 0; i < rmdf.Categories.Count; i++)
            {
                if (rmdf.Categories[i].ShaderOptions.Count == 0)
                {
                    var options = new byte[rmdf.Categories.Count];

                    Console.WriteLine($"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}");

                    var rmt2Name = $"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}";

                    try
                    {
                        var rmt2 = ShaderGeneratorNew.GenerateTemplateSafe(Cache, stream, rmdf, rmt2Name, out _, out _);
                        var rmt2Tag = Cache.TagCache.AllocateTag<RenderMethodTemplate>(rmt2Name);
                        Cache.Serialize(stream, rmt2Tag, rmt2);

                        RenderMethodUnitTest(stream, Cache as GameCacheHaloOnlineBase, rmt2Name, rmt2Name);
                    }
                    catch (Exception e)
                    {
                        new TagToolWarning($"Failed to generate template \"{rmt2Name}\":\n {e}\n");
                    }
                }
                else
                {
                    for (int j = 0; j < rmdf.Categories[i].ShaderOptions.Count; j++)
                    {
                        var options = new byte[rmdf.Categories.Count];

                        options[i] = (byte)j;

                        Console.WriteLine($"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}");

                        var rmt2Name = $"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}";

                        try
                        {
                            var rmt2 = ShaderGeneratorNew.GenerateTemplateSafe(Cache, stream, rmdf, rmt2Name, out _, out _);
                            var rmt2Tag = Cache.TagCache.AllocateTag<RenderMethodTemplate>(rmt2Name);
                            Cache.Serialize(stream, rmt2Tag, rmt2);

                            RenderMethodUnitTest(stream, Cache as GameCacheHaloOnlineBase, rmt2Name, rmt2Name);
                        }
                        catch (Exception e)
                        {
                            new TagToolWarning($"Failed to generate template \"{rmt2Name}\":\n {e}\n");
                        }
                    }
                }
            }
        }

        public void RenderMethodUnitTest(Stream stream, GameCacheHaloOnlineBase cache, string renderMethodName, string rmt2Name)
        {
            Dictionary<string, string> ShaderTypeGroups = new Dictionary<string, string>
            {
                ["shader"] = "rmsh",
                ["decal"] = "rmd ",
                ["halogram"] = "rmhg",
                ["water"] = "rmw ",
                ["black"] = "rmbk",
                ["terrain"] = "rmtr",
                ["custom"] = "rmcs",
                ["foliage"] = "rmfl",
                ["screen"] = "rmss",
                ["cortana"] = "rmct",
                ["zonly"] = "rmzo",
                ["glass"] = "rmgl",
                ["fur_stencil"] = "rmfs",
                ["fur"] = "rmfu",
                ["mux"] = "rmmx",
            };

            if (!cache.TagCache.TryGetTag($"{rmt2Name.Split('.')[0]}.rmt2", out var rmt2Tag))
                new TagToolError(CommandError.TagInvalid, $"Could not find \"{rmt2Name}.rmt2\"");

            // easier to get the type, and cleaner to check if ms30
            ShaderMatcherNew.Rmt2Descriptor.TryParse(rmt2Tag.Name, out var rmt2Descriptor);

            // check if tag already exists, or allocate new one
            string rmGroup = ShaderTypeGroups[rmt2Descriptor.Type];
            if (!cache.TagCache.TryGetTag($"{renderMethodName}.{rmGroup}", out var rmTag))
                rmTag = cache.TagCache.AllocateTag(cache.TagCache.TagDefinitions.GetTagGroupFromTag(rmGroup), renderMethodName);

            string prefix = rmt2Descriptor.IsMs30 ? "ms30\\" : "";
            string rmdfName = prefix + "shaders\\" + rmt2Descriptor.Type;
            if (!cache.TagCache.TryGetTag($"{rmdfName}.rmdf", out var rmdfTag))
                new TagToolError(CommandError.TagInvalid, $"Could not find \"{rmdfName}.rmdf\"");

            var rmt2 = cache.Deserialize<RenderMethodTemplate>(stream, rmt2Tag);
            var rmdf = cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            // store rmop definitions for quick lookup
            List<RenderMethodOption> renderMethodOptions = new List<RenderMethodOption>();
            for (int i = 0; i < rmt2Descriptor.Options.Length; i++)
            {
                if (rmdf.GlobalOptions != null)
                    renderMethodOptions.Add(cache.Deserialize<RenderMethodOption>(stream, rmdf.GlobalOptions));

                if (rmdf.Categories[i].ShaderOptions.Count == 0)
                    continue;

                var rmopTag = rmdf.Categories[i].ShaderOptions[rmt2Descriptor.Options[i]].Option;
                if (rmopTag != null)
                    renderMethodOptions.Add(cache.Deserialize<RenderMethodOption>(stream, rmopTag));
            }

            // create definition
            object definition = Activator.CreateInstance(cache.TagCache.TagDefinitions.GetTagDefinitionType(rmGroup));
            // make changes as RenderMethod so the code can be reused for each rm type
            var rmDefinition = definition as RenderMethod;

            rmDefinition.BaseRenderMethod = rmdfTag;

            // initialize lists
            rmDefinition.Options = new List<RenderMethod.RenderMethodOptionIndex>();
            rmDefinition.ShaderProperties = new List<RenderMethod.RenderMethodPostprocessBlock>();

            foreach (var option in rmt2Descriptor.Options)
                rmDefinition.Options.Add(new RenderMethod.RenderMethodOptionIndex { OptionIndex = option });
            rmDefinition.SortLayer = TagTool.Shaders.SortingLayerValue.Normal;
            rmDefinition.PredictionAtomIndex = -1;

            PopulateRenderMethodConstants populateConstants = new PopulateRenderMethodConstants();

            // setup shader property
            RenderMethod.RenderMethodPostprocessBlock shaderProperty = new RenderMethod.RenderMethodPostprocessBlock
            {
                Template = rmt2Tag,
                // setup constants
                TextureConstants = populateConstants.SetupTextureConstants(rmt2, renderMethodOptions, cache),
                RealConstants = populateConstants.SetupRealConstants(rmt2, renderMethodOptions, cache),
                IntegerConstants = populateConstants.SetupIntegerConstants(rmt2, renderMethodOptions, cache),
                BooleanConstants = populateConstants.SetupBooleanConstants(rmt2, renderMethodOptions, cache),
                // get alpha blend mode
                BlendMode = populateConstants.GetAlphaBlendMode(rmt2Descriptor, rmdf, cache),
                // TODO
                QueryableProperties = new short[] { -1, -1, -1, -1, -1, -1, -1, -1 }
            };

            rmDefinition.ShaderProperties.Add(shaderProperty);

            cache.Serialize(stream, rmTag, definition);
            cache.SaveTagNames();

            Console.WriteLine($"Generated {rmGroup} tag: {rmTag.Name}.{rmTag.Group}");
        }
    }
}
