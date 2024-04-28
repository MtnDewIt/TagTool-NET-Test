using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Shaders;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class HalogramDefinition : RenderMethodData
    {
        public HalogramDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GenerateTag<RenderMethodDefinition>($@"shaders\halogram");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = GenerateTag<RenderMethodOption>($@"shaders\shader_options\global_shader_options");
            rmdf.Categories = new List<RenderMethodDefinition.CategoryBlock>
            {
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"albedo"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"default"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_default"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"detail_blend"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_detail_blend"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_detail_blend_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"constant_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_constant"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_constant_color_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_constant_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_change_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_change_color"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"four_change_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_four_change_color"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_four_change_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"three_detail_blend"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_three_detail_blend"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_three_detail_blend_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_detail_overlay"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_detail_overlay"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_overlay_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_detail"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_detail"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"color_mask"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_color_mask"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_color_mask_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_detail_black_point"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_detail_black_point"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_black_point_ps"),
                        },
                    },
                    VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_vs"),
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"self_illumination"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_none_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_simple"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_simple_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"3_channel_self_illum"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_3_channel"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_three_channel_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"plasma"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_plasma"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_plasma_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"from_diffuse"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_from_diffuse"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_from_albedo_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"illum_detail"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_detail"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_detail_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"meter"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_meter"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_meter_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"self_illum_times_diffuse"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_times_diffuse"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_times_diffuse_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multilayer_additive"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_multilayer"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_multilayer_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"ml_add_four_change_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_multilayer_four_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_multilayer_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"ml_add_five_change_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_multilayer_five_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_multilayer_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"scope_blur"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_scope_blur"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_scope_blur_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plasma"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_palettized_plasma"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_palettized_plasma_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plasma_change_color"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\screen_options\illum_palettized_plasma_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_palettized_plasma_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_depth_fade"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\illum_palettized_depth_fade"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_palettized_depth_fade_ps"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_ps"),
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
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"opaque"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"additive"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"additive"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multiply"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"multiply"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"alpha_blend"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"alpha_blend"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"double_multiply"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"double_multiply"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"blend_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"misc"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"first_person_never"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"0"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"first_person_sometimes"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"0"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"first_person_always"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"0"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"first_person_never_w/rotating_bitmaps"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"1"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"always_calc_albedo"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"2"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"bitmap_rotation"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"warp"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_off_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"from_texture"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\warp_from_texture"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_warp_from_texture_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"parallax_simple"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\parallax_simple"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_simple_ps"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"overlay"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_overlay_none_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"additive"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\overlay_additive"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_overlay_additive_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"additive_detail"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\overlay_additive_detail"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_overlay_additive_detail_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multiply"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\overlay_additive"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_overlay_multiply_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multiply_and_additive_detail"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\overlay_multiply_additive_detail"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_overlay_multiply_and_additive_detail_ps"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_overlay_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"edge_fade"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_edge_fade_none_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\edge_fade_simple"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_edge_fade_simple_ps"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_edge_fade_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"distortion"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"distort_off_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\sfx_distort"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"distort_on_ps"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"distort_proc_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"soft_fade"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"apply_soft_fade_off"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            Option = GenerateTag<RenderMethodOption>($@"shaders\shader_options\soft_fade"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"apply_soft_fade_on"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"apply_soft_fade"),
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
                    EntryPoint = EntryPoint_32.Static_Per_Vertex_Color,
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
            rmdf.GlobalPixelShader = GenerateTag<GlobalPixelShader>($@"shaders\halogram_shared_pixel_shaders");
            rmdf.GlobalVertexShader = GenerateTag<GlobalVertexShader>($@"shaders\halogram_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.None;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}