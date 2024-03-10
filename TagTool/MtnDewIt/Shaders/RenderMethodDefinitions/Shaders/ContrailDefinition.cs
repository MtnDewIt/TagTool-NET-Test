using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class ContrailDefinition : RenderMethodData
    {
        public ContrailDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = Cache.TagCache.GetTag<RenderMethodDefinition>($@"shaders\contrail");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\contrail_options\global_contrail_options");
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
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\contrail_options\albedo_diffuse_only"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\contrail_options\albedo_palettized"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plus_alpha"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\contrail_options\albedo_palettized_plus_alpha"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"category_albedo_option_palettized_plus_alpha"),
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
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.Contrail,
                    Dependencies = null,
                },
            };
            rmdf.GlobalPixelShader = Cache.TagCache.GetTag<GlobalPixelShader>($@"shaders\contrail_shared_pixel_shaders");
            rmdf.GlobalVertexShader = Cache.TagCache.GetTag<GlobalVertexShader>($@"shaders\contrail_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}