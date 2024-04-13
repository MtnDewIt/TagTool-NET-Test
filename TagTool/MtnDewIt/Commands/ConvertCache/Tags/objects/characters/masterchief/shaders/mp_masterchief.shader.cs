using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags
{
    public class objects_characters_masterchief_shaders_mp_masterchief_shader : TagFile
    {
        public objects_characters_masterchief_shaders_mp_masterchief_shader(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<Shader>($@"objects\characters\masterchief\shaders\mp_masterchief");
            var rmsh = CacheContext.Deserialize<Shader>(Stream, tag);
            rmsh.BaseRenderMethod = GetCachedTag<RenderMethodDefinition>($@"shaders\shader");
            rmsh.Options = new List<RenderMethod.RenderMethodOptionIndex>
            {
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 10,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 3,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 0,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 1,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 1,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 2,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 9,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 0,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 0,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 1,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 0,
                },
            };
            rmsh.ShaderProperties = new List<RenderMethod.RenderMethodPostprocessBlock>
            {
                new RenderMethod.RenderMethodPostprocessBlock
                {
                    Template = GetCachedTag<RenderMethodTemplate>($@"shaders\shader_templates\_10_3_0_1_1_2_9_0_0_1_0_0"),
                    TextureConstants = new List<RenderMethod.RenderMethodPostprocessBlock.TextureConstant>
                    {
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\bitmaps\mp_masterchief"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic3Expensive,
                            TextureTransformConstantIndex = 0,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\weapons\rifle\battle_rifle\bitmaps\gun_detail"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic3Expensive,
                            TextureTransformConstantIndex = 1,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\bitmaps\mp_masterchief_cc"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic3Expensive,
                            TextureTransformConstantIndex = 2,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\bitmaps\mp_masterchief_new_bump"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic3Expensive,
                            TextureTransformConstantIndex = 3,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\fp\bitmaps\efp_metal_bump"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic3Expensive,
                            TextureTransformConstantIndex = 4,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_white"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Trilinear,
                            TextureTransformConstantIndex = 5,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\gray_50_percent"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Trilinear,
                            TextureTransformConstantIndex = 14,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\bitmaps\masterchief_illum"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic3Expensive,
                            TextureTransformConstantIndex = 19,
                        },
                    },
                    RealConstants = new List<RenderMethod.RenderMethodPostprocessBlock.RealConstant>
                    {
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                20f, 20f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                20f, 20f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.5f, 0.5f, 0.5f, 0.5f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.5372549f, 0.5411765f, 0.49411768f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.27058825f, 0.39607847f, 0.7254902f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.5019608f, 0.5019608f, 0.5019608f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.2f, 0.2f, 0.2f, 0.2f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.2f, 0.2f, 0.2f, 0.2f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.5f, 0.5f, 0.5f, 0.5f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1, 1, 0, 0,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.75f, 0.75f, 0.75f, 0.75f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                2f, 2f, 2f, 2f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                0.3137255f, 0.34901962f, 0.454902f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                2f, 2f, 2f, 2f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[4]
                            {
                                2.5f, 2.5f, 2.5f, 2.5f,
                            },
                        },
                    },
                    BooleanConstants = 1,
                    Functions = new List<RenderMethod.RenderMethodAnimatedParameterBlock>
                    {
                        new RenderMethod.RenderMethodAnimatedParameterBlock
                        {
                            Type = RenderMethod.RenderMethodAnimatedParameterBlock.FunctionType.Value,
                            InputName = CacheContext.StringTable.GetOrAddString($@"shield_intensity"),
                            RangeName = StringId.Invalid,
                            TimePeriod = 1f,
                            Function = new TagFunction
                            {
                                Data = new byte[]
                                {
                                    0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x20, 0x40, 0x00, 0x00,
                                    0x20, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x3F,
                                    0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                    0x00, 0x00,
                                }
                            },
                        },
                    },
                    BlendMode = RenderMethod.RenderMethodPostprocessBlock.BlendModeValue.Opaque,
                    Flags = RenderMethod.RenderMethodPostprocessBlock.RenderMethodPostprocessFlags.ForceSinglePass,
                    ImSoFiredPad = 0,
                    QueryableProperties = new short[8]
                    {
                        -1, 0, -1, -1, -1, -1, -1, -1,
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, rmsh);
        }
    }
}