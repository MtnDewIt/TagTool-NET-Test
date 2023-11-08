using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_shaders_mp_intruder_visor_shader : TagFile
    {
        public objects_characters_masterchief_shaders_mp_intruder_visor_shader(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Shader>($@"objects\characters\masterchief\shaders\mp_intruder_visor");
            var rmsh = CacheContext.Deserialize<Shader>(Stream, tag); 
            rmsh.Options = new List<RenderMethod.RenderMethodOptionIndex>
            {
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 4,
                },
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 1,
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
                    OptionIndex = 0,
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
                new RenderMethod.RenderMethodOptionIndex
                {
                    OptionIndex = 0,
                },
            };
            rmsh.ShaderProperties = new List<RenderMethod.RenderMethodPostprocessBlock>
            {
                new RenderMethod.RenderMethodPostprocessBlock
                {
                    Template = GetCachedTag<RenderMethodTemplate>($@"shaders\shader_templates\_4_1_0_1_1_2_0_0_0_1_0_0"),
                    TextureConstants = new List<RenderMethod.RenderMethodPostprocessBlock.TextureConstant>
                    {
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\bitmaps\mp_intruder"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic4EXPENSIVE,
                            TextureTransformConstantIndex = 0,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\default_detail"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic4EXPENSIVE,
                            TextureTransformConstantIndex = 1,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\bitmaps\mp_visor_cc"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic4EXPENSIVE,
                            TextureTransformConstantIndex = 2,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"objects\characters\masterchief\bitmaps\mp_intruder_bump"),
                            FilterMode = RenderMethod.RenderMethodPostprocessBlock.TextureConstant.SamplerFilterMode.Anisotropic4EXPENSIVE,
                            TextureTransformConstantIndex = 3,
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.TextureConstant
                        {
                            Bitmap = GetCachedTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\gray_50_percent"),
                            TextureTransformConstantIndex = 15,
                        },
                    },
                    BooleanConstants = 1,
                    RealConstants = new List<RenderMethod.RenderMethodPostprocessBlock.RealConstant>
                    {
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                40f, 20f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                7f, 0.1f, 0.1f, 0.1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0.2f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0.5019608f, 0.5019608f, 0.5019608f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                8f, 8f, 8f, 8f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0.15f, 0.15f, 0.15f, 0.15f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0.5f, 0.5f, 0.5f, 0.5f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0.9f, 0.9f, 0.9f, 0.9f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0.9f, 0.9f, 0.9f, 0.9f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                10f, 10f, 10f, 10f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0.9f, 0.9f, 0.9f, 0.9f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                1f, 1f, 1f, 1f,
                            },
                        },
                        new RenderMethod.RenderMethodPostprocessBlock.RealConstant
                        {
                            Values = new float[]
                            {
                                0f, 0f, 0f, 0f,
                            },
                        },
                    },
                    BlendMode = RenderMethod.RenderMethodPostprocessBlock.BlendModeValue.Opaque,
                    Flags = RenderMethod.RenderMethodPostprocessBlock.RenderMethodPostprocessFlags.ForceSinglePass,
                    ImSoFiredPad = 0,
                    QueryableProperties = new short[]
                    {
                        -1, 0, -1, -1, -1, -1, -1, -1,
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, rmsh);
        }
    }
}
