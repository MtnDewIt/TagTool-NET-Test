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
            var tag = GenerateTag<RenderMethodDefinition>($@"shaders\decal");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = GenerateTag<RenderMethodOption>($@"shaders\decal_options\global_decal_options");
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
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_diffuse_only"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_palettized"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plus_alpha"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_palettized_plus_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_alpha"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_diffuse_plus_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"emblem_change_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_emblem_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"change_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_alpha_mask"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_diffuse_plus_alpha_mask"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plus_alpha_mask"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_palettized_plus_alpha_mask"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"vector_alpha"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_vector_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"vector_alpha_drop_shadow"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\albedo_vector_alpha_drop_shadow"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
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
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"additive"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multiply"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"alpha_blend"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"double_multiply"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"maximum"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multiply_add"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"add_src_times_dstalpha"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"add_src_times_srcalpha"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"inv_alpha_blend"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"pre_multiplied_alpha"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
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
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"post_lighting"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
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
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"modulate"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\specular_modulate"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
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
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\bump_mapping_standard"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard_mask"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\bump_mapping_standard_mask"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
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
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"unmodulated"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\tinting_unmodulated"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"partially_modulated"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\tinting_partially_modulated"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"fully_modulated"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\decal_options\tinting_fully_modulated"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
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
            rmdf.GlobalPixelShader = GenerateTag<GlobalPixelShader>($@"shaders\decal_shared_pixel_shaders");
            rmdf.GlobalVertexShader = GenerateTag<GlobalVertexShader>($@"shaders\decal_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}