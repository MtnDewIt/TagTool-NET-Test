using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class ParticleDefinition : RenderMethodData
    {
        public ParticleDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            RenderMethod();
        }

        public override void RenderMethod()
        {
            var tag = Cache.TagCache.GetTag<RenderMethodDefinition>($@"shaders\particle");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\global_particle_options");
            rmdf.Categories = new List<RenderMethodDefinition.CategoryBlock>
            {
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"albedo"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_diffuse_only"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_billboard_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_diffuse_plus_billboard_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_plus_billboard_alpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_palettized"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plus_billboard_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_palettized_plus_billboard_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_plus_billboard_alpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_sprite_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_diffuse_plus_sprite_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_plus_sprite_alpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plus_sprite_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_palettized_plus_sprite_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_plus_sprite_alpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_modulated"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_diffuse_modulated"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_modulated"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_glow"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_palettized_glow"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_glow"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plasma"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_palettized_plasma"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_plasma"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_2d_plasma"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\albedo_palettized_plasma"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_2d_plasma"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"blend_mode"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"opaque"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_opaque"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"additive"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_additive"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multiply"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_multiply"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"alpha_blend"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_alpha_blend"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"double_multiply"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_double_multiply"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"maximum"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_maximum"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multiply_add"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_multiply_add"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"add_src_times_dstalpha"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_add_src_times_dstalpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"add_src_times_srcalpha"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_add_src_times_srcalpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"inv_alpha_blend"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_inv_alpha_blend"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"pre_multiplied_alpha"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode_option_pre_multiplied_alpha"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_blend_mode"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"specialized_rendering"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specialized_rendering_option_none"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"distortion"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\specialized_rendering_distortion"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specialized_rendering_option_distortion"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"distortion_expensive"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\specialized_rendering_distortion"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specialized_rendering_option_distortion_expensive"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"distortion_diffuse"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\specialized_rendering_distortion"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specialized_rendering_option_distortion_diffuse"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"distortion_expensive_diffuse"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\specialized_rendering_distortion"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specialized_rendering_option_distortion_expensive_diffuse"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specialized_rendering"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"lighting"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_lighting_option_none"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"per_pixel_ravi_order_3"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_lighting_option_per_pixel_ravi_order_3"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"per_vertex_ravi_order_0"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_lighting_option_per_vertex_ravi_order_0"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_lighting"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"render_targets"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"ldr_and_hdr"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_render_targets_option_ldr_and_hdr"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"ldr_only"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_render_targets_option_ldr_only"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_render_targets"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"depth_fade"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_depth_fade_option_off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\depth_fade_on"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_depth_fade_option_on"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_depth_fade"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"black_point"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_black_point_option_off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_black_point_option_on"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_black_point"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"fog"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_fog_option_off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_fog_option_on"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_fog"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"frame_blend"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_frame_blend_option_off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\frame_blend_on"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_frame_blend_option_on"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_frame_blend"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"self_illumination"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_self_illumination_option_none"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"constant_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\particle_options\self_illumination_constant_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_self_illumination_option_constant_color"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_self_illumination"),
                },
            };
            rmdf.EntryPoints = new List<RenderMethodDefinition.EntryPointBlock>
            {
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Default,
                    Passes = new List<RenderMethodDefinition.EntryPointBlock.PassBlock>
                    {
                        new RenderMethodDefinition.EntryPointBlock.PassBlock
                        {
                            Flags = RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.None,
                            CategoryDependencies = null,
                        },
                    },
                },
            };
            rmdf.VertexTypes = new List<RenderMethodDefinition.VertexBlock>
            {
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.Particle,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.ParticleModel,
                    Dependencies = null,
                },
            };
            rmdf.GlobalPixelShader = Cache.TagCache.GetTag<GlobalPixelShader>($@"shaders\particle_shared_pixel_shaders");
            rmdf.GlobalVertexShader = Cache.TagCache.GetTag<GlobalVertexShader>($@"shaders\particle_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}