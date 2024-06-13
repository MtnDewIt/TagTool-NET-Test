using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class WaterDefinition : RenderMethodData
    {
        public WaterDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GenerateTag<RenderMethodDefinition>($@"shaders\water");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = GenerateOptionData<shaders_water_options_water_global_render_method_option>();
            rmdf.Categories = new List<RenderMethodDefinition.CategoryBlock>
            {
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"waveshape"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"default"),
                            Option = GenerateOptionData<shaders_water_options_waveshape_default_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"bump"),
                            Option = GenerateOptionData<shaders_water_options_waveshape_bump_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"watercolor"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"pure"),
                            Option = GenerateOptionData<shaders_water_options_watercolor_pure_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"texture"),
                            Option = GenerateOptionData<shaders_water_options_watercolor_texture_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"reflection"),
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
                            Name = CacheContext.StringTable.GetOrAddString($@"static"),
                            Option = GenerateOptionData<shaders_water_options_reflection_static_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dynamic"),
                            Option = GenerateOptionData<shaders_water_options_reflection_dynamic_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"static_ssr"),
                            Option = GenerateOptionData<shaders_water_options_reflection_static_ssr_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"refraction"),
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
                            Name = CacheContext.StringTable.GetOrAddString($@"dynamic"),
                            Option = GenerateOptionData<shaders_water_options_refraction_dynamic_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"bankalpha"),
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
                            Name = CacheContext.StringTable.GetOrAddString($@"depth"),
                            Option = GenerateOptionData<shaders_water_options_bankalpha_depth_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"paint"),
                            Option = GenerateOptionData<shaders_water_options_bankalpha_paint_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"from_shape_texture_alpha"),
                            Option = GenerateOptionData<shaders_water_options_bankalpha_from_shape_texture_alpha_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"appearance"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"default"),
                            Option = GenerateOptionData<shaders_water_options_appearance_default_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"global_shape"),
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
                            Name = CacheContext.StringTable.GetOrAddString($@"paint"),
                            Option = GenerateOptionData<shaders_water_options_globalshape_paint_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"depth"),
                            Option = GenerateOptionData<shaders_water_options_globalshape_depth_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"foam"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = GenerateOptionData<shaders_water_options_foam_none_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"auto"),
                            Option = GenerateOptionData<shaders_water_options_foam_auto_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"paint"),
                            Option = GenerateOptionData<shaders_water_options_foam_paint_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"both"),
                            Option = GenerateOptionData<shaders_water_options_foam_both_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"reach_compatibility"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"disabled"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"enabled"),
                            Option = GenerateOptionData<shaders_water_options_reach_compatibility_enabled_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = StringId.Invalid,
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"enabled_detail_repeat"),
                            Option = GenerateOptionData<shaders_water_options_reach_compatibility_enabled_render_method_option>(),
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
                    EntryPoint = EntryPoint_32.Water_Tessellation,
                    Passes = new List<RenderMethodDefinition.EntryPointBlock.PassBlock>
                    {
                        new RenderMethodDefinition.EntryPointBlock.PassBlock
                        {
                            Flags = RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.None,
                            CategoryDependencies = null,
                        },
                    },
                },
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Static_Per_Pixel,
                    Passes = new List<RenderMethodDefinition.EntryPointBlock.PassBlock>
                    {
                        new RenderMethodDefinition.EntryPointBlock.PassBlock
                        {
                            Flags = RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.None,
                            CategoryDependencies = null,
                        },
                    },
                },
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Static_Per_Vertex,
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
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.Water,
                    Dependencies = null,
                },
            };
            rmdf.GlobalPixelShader = GenerateTag<GlobalPixelShader>($@"shaders\water_shared_pixel_shaders");
            rmdf.GlobalVertexShader = GenerateTag<GlobalVertexShader>($@"shaders\water_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}