using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class TerrainDefinition : RenderMethodData
    {
        public TerrainDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GenerateTag<RenderMethodDefinition>($@"shaders\terrain");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = GenerateOptionData<shaders_shader_options_global_shader_options_render_method_option>();
            rmdf.Categories = new List<RenderMethodDefinition.CategoryBlock>
            {
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"blending"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"morph"),
                            Option = GenerateOptionData<shaders_terrain_options_default_blending_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"morph"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dynamic_morph"),
                            Option = GenerateOptionData<shaders_terrain_options_dynamic_blending_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"dynamic"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"blend_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"environment_map"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"none"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"per_pixel"),
                            Option = GenerateOptionData<shaders_shader_options_env_map_per_pixel_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"per_pixel"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dynamic"),
                            Option = GenerateOptionData<shaders_shader_options_env_map_dynamic_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"dynamic"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dynamic_reach"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"dynamic_reach"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"envmap_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"material_0"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_only_m_0_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_m_0_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only_plus_self_illum"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_only_plus_sefl_illum_m_0_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only_plus_self_illum"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_self_illum"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_plus_self_illumm_0_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_self_illum"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_heightmap"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_plus_heightmap_m_0_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_heightmap"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_two_detail"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_two_detail_m_0_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_two_detail"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_up_vector_plus_heightmap"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_plus_up_vector_plus_heightmap_m_0_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_up_vector_plus_heightmap"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"material_0_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"material_1"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_only_m_1_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_m_1_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only_plus_self_illum"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_only_plus_sefl_illum_m_1_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only_plus_self_illum"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_self_illum"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_plus_self_illumm_1_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_self_illum"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_heightmap"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_plus_heightmap_m_1_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_heightmap"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_up_vector_plus_heightmap"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_plus_up_vector_plus_heightmap_m_1_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_up_vector_plus_heightmap"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"material_1_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"material_2"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_only_m_2_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_m_2_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only_plus_self_illum"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_only_plus_sefl_illum_m_2_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only_plus_self_illum"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_self_illum"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_plus_self_illumm_2_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_plus_self_illum"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"material_2_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"material_3"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only_(four_material_shaders_disable_detail_bump)"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_only_m_3_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular_(four_material_shaders_disable_detail_bump)"),
                            Option = GenerateOptionData<shaders_terrain_options_diffuse_plus_specular_m_3_render_method_option>(),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_plus_specular"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"material_3_type"),
                },
            };
            rmdf.EntryPoints = new List<RenderMethodDefinition.EntryPointBlock>
            {
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Albedo,
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
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Static_Sh,
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
                    EntryPoint = EntryPoint_32.Dynamic_Light,
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
                    EntryPoint = EntryPoint_32.Lightmap_Debug_Mode,
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
                    EntryPoint = EntryPoint_32.Shadow_Generate,
                    Passes = new List<RenderMethodDefinition.EntryPointBlock.PassBlock>
                    {
                        new RenderMethodDefinition.EntryPointBlock.PassBlock
                        {
                            Flags = RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.HasSharedPixelShader,
                            CategoryDependencies = null,
                        },
                    },
                },
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Dynamic_Light_Cinematic,
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
                    EntryPoint = EntryPoint_32.Static_Prt_Quadratic,
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
                    EntryPoint = EntryPoint_32.Static_Prt_Linear,
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
                    EntryPoint = EntryPoint_32.Static_Prt_Ambient,
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
            };
            rmdf.GlobalPixelShader = GenerateTag<GlobalPixelShader>($@"shaders\terrain_shared_pixel_shaders");
            rmdf.GlobalVertexShader = GenerateTag<GlobalVertexShader>($@"shaders\terrain_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.None;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}