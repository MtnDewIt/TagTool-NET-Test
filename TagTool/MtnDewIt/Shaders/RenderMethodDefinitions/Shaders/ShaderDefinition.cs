using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class ShaderDefinition : RenderMethodData
    {
        public ShaderDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = Cache.TagCache.GetTag<RenderMethodDefinition>($@"shaders\shader");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\global_shader_options");
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
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_default"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_default_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"detail_blend"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_detail_blend"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_detail_blend_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_detail_blend_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"constant_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_constant"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_constant_color_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_constant_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_change_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_change_color"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"four_change_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_four_change_color"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_four_change_color_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_four_change_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"three_detail_blend"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_three_detail_blend"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_three_detail_blend_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_three_detail_blend_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_detail_overlay"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_detail_overlay"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_overlay_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_overlay_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_detail"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_detail"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"color_mask"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_color_mask"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_color_mask_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_color_mask_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_detail_black_point"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_detail_black_point"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_black_point_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_detail_black_point_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_change_color_anim_overlay"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_change_color_anim_overlay"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_anim_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_anim_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"chameleon"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_chameleon"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_chameleon_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_chameleon_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_change_color_chameleon"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_change_color_chameleon"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_chameleon_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_chameleon_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"chameleon_masked"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_chameleon_masked"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_chameleon_masked_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_chameleon_masked_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"color_mask_hard_light"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_color_mask_hard_light"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_color_mask_hard_light_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_color_mask_hard_light_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"four_change_color_applying_to_specular"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_four_change_color"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_four_change_color_applying_to_specular_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_four_change_color_applying_to_specular_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_simple"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_simple_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_simple_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_change_color_tex_overlay"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_change_color_tex_overlay"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_tex_overlay_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_change_color_tex_overlay_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"chameleon_albedo_masked"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_chameleon_albedo_masked"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_chameleon_albedo_masked_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_chameleon_albedo_masked_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"custom_cube"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_custom_cube"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_custom_cube_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_custom_cube_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_two_color"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_color_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_two_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"emblem"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\albedo_emblem"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_emblem_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_emblem_ps"),
                        },
                    },
                    VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_vs"),
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_albedo_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"bump_mapping"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\bump_off"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_off_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_off_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\bump_default"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_default_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_default_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"detail"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\bump_detail"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_detail_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_detail_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"detail_masked"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\bump_detail_masked"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_detail_masked_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_detail_masked_ps"),
                        },
                    },
                    VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_vs"),
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_bumpmap_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"alpha_test"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\alpha_test_off"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_alpha_test_off_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\alpha_test_on"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_alpha_test_on_ps"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_alpha_test_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"specular_mask"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"no_specular_mask"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_specular_mask_no_specular_mask_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"specular_mask_from_diffuse"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_specular_mask_from_diffuse_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"specular_mask_from_texture"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\specular_mask_from_texture"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_specular_mask_texture_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"specular_mask_from_color_texture"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\specular_mask_from_texture"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_specular_mask_color_texture_ps"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_specular_mask_ps"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"material_model"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_diffuse_only"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"diffuse_only"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"cook_torrance"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_cook_torrance_option"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"cook_torrance_rim_fresnel"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"two_lobe_phong"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_two_lobe_phong_option"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"two_lobe_phong"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"foliage"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_foliage"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"foliage"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"none"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"none"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"glass"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\glass_material"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"glass"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"organism"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_organism_option"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"organism"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"single_lobe_phong"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\single_lobe_phong"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"single_lobe_phong"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"car_paint"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_car_paint"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"car_paint"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"hair"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_hair_option"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"hair"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"cook_torrance_odst"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\material_cook_torrance_option"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"cook_torrance"), // Don't know if the cook_torrance_odst option has been properly implemented :/
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"material_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"environment_mapping"),
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
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\env_map_per_pixel"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"per_pixel"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dynamic"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\env_map_dynamic"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"dynamic"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"from_flat_texture"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\env_map_from_flat_texture"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"from_flat_texture"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"custom_map"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\env_map_per_pixel"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"custom_map"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dynamic_reach"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\env_map_dynamic"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"dynamic_reach"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"envmap_type"),
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
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_simple"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_simple_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"3_channel_self_illum"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_3_channel"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_three_channel_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"plasma"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_plasma"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_plasma_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"from_diffuse"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_from_diffuse"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_from_albedo_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"illum_detail"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_detail"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_detail_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"meter"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_meter"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_meter_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"self_illum_times_diffuse"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_times_diffuse"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_times_diffuse_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple_with_alpha_mask"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_simple"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_simple_with_alpha_mask_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple_four_change_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_simple_four_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_simple_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"illum_change_color"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_change_color"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_illum_change_color_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"multilayer_additive"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"sshaders\shader_options\illum_multilayer"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_multilayer_additive_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"palettized_plasma"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_palettized_plasma"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_palettized_plasma_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"change_color_detail"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_change_color_detail"),
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_self_illumination_change_color_detail_ps"),
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
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"pre_multiplied_alpha"),
                            Option = null,
                            VertexFunction = StringId.Invalid,
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"pre_multiplied_alpha"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"blend_type"),
                },
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"parallax"),
                    ShaderOptions = new List<RenderMethodDefinition.CategoryBlock.ShaderOption>
                    {
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            Option = null,
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_off_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_off_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\parallax_simple"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_simple_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_simple_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"interpolated"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\parallax_simple"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_interpolated_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_interpolated_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"simple_detail"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\parallax_detail"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_simple_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_simple_detail_ps"),
                        },
                    },
                    VertexFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_vs"),
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"calc_parallax_ps"),
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
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"0"),
                        },
                    },
                    VertexFunction = StringId.Invalid,
                    PixelFunction = CacheContext.StringTable.GetOrAddString($@"bitmap_rotation"),
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
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"distort_nocolor_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"distort_off_ps"),
                        },
                        new RenderMethodDefinition.CategoryBlock.ShaderOption
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\sfx_distort"),
                            VertexFunction = CacheContext.StringTable.GetOrAddString($@"distort_nocolor_vs"),
                            PixelFunction = CacheContext.StringTable.GetOrAddString($@"distort_on_ps"),
                        },
                    },
                    VertexFunction = CacheContext.StringTable.GetOrAddString($@"distort_proc_vs"),
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
                            Option = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\soft_fade"),
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
                            CategoryDependencies = new List<RenderMethodDefinition.EntryPointBlock.PassBlock.CategoryDependency>
                            {
                                new RenderMethodDefinition.EntryPointBlock.PassBlock.CategoryDependency
                                {
                                    Category = 2,
                                },
                            },
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
                    EntryPoint = EntryPoint_32.Active_Camo,
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
                    EntryPoint = EntryPoint_32.Dynamic_Light_Cinematic,
                    Passes = new List<RenderMethodDefinition.EntryPointBlock.PassBlock>
                    {
                        new RenderMethodDefinition.EntryPointBlock.PassBlock
                        {
                            Flags = RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.None,
                            CategoryDependencies = new List<RenderMethodDefinition.EntryPointBlock.PassBlock.CategoryDependency>
                            {
                                new RenderMethodDefinition.EntryPointBlock.PassBlock.CategoryDependency
                                {
                                    Category = 2,
                                },
                            },
                        },
                    },
                },
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Sfx_Distort,
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
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.DualQuat,
                    Dependencies = null,
                },
            };
            rmdf.GlobalPixelShader = Cache.TagCache.GetTag<GlobalPixelShader>($@"shaders\shader_shared_pixel_shaders");
            rmdf.GlobalVertexShader = Cache.TagCache.GetTag<GlobalVertexShader>($@"shaders\shader_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.None;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}