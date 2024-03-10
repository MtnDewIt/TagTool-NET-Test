using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class DecalDefinition : RenderMethodData
    {
        public DecalDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = Cache.TagCache.GetTag<RenderMethodDefinition>($@"shaders\decal");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\global_decal_options");
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
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_diffuse_only"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_palettized"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plus_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_palettized_plus_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_plus_alpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_diffuse_plus_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_plus_alpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"emblem_change_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_emblem_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_emblem_change_color"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"change_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_change_color"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_alpha_mask"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_diffuse_plus_alpha_mask"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_plus_alpha_mask"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plus_alpha_mask"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_palettized_plus_alpha_mask"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_plus_alpha_mask"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"vector_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_vector_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_vector_alpha"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"vector_alpha_drop_shadow"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\albedo_vector_alpha_drop_shadow"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_vector_alpha_drop_shadow"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"render_pass"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"pre_lighting"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_render_pass_option_pre_lighting"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"post_lighting"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_render_pass_option_post_lighting"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_render_pass"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"specular"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"leave"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specular_option_leave"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"modulate"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\specular_modulate"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specular_option_modulate"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_specular"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"bump_mapping"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"leave"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_bump_mapping_option_leave"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\bump_mapping_standard"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_bump_mapping_option_standard"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard_mask"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\bump_mapping_standard_mask"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_bump_mapping_option_standard_mask"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_bump_mapping"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"tinting"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_tinting_option_none"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"unmodulated"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\tinting_unmodulated"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_tinting_option_unmodulated"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"partially_modulated"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\tinting_partially_modulated"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_tinting_option_partially_modulated"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"fully_modulated"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\decal_options\tinting_fully_modulated"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_tinting_option_fully_modulated"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_tinting"),
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
                            CategoryDependencies = new List<RenderMethodDefinition.EntryPointBlock.PassBlock.CategoryDependency>
                            {
                                new RenderMethodDefinition.EntryPointBlock.PassBlock.CategoryDependency
                                {
                                    Category = 4,
                                },
                            },
                        },
                    },
                },
            };
            rmdf.VertexTypes = new List<RenderMethodDefinition.VertexBlock>
            {
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.World,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.Rigid,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.Skinned,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.FlatWorld,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.FlatRigid,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.FlatSkinned,
                    Dependencies = null,
                },
            };
            rmdf.GlobalPixelShader = Cache.TagCache.GetTag<GlobalPixelShader>($@"shaders\decal_shared_pixel_shaders");
            rmdf.GlobalVertexShader = Cache.TagCache.GetTag<GlobalVertexShader>($@"shaders\decal_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}