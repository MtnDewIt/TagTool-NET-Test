using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloShaderGenerator;
using HaloShaderGenerator.Generator;
using HaloShaderGenerator.Globals;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.RenderMethodDefinition;
using TagTool.Commands.Common;
using TagTool.Common.Logging;

namespace TagTool.Shaders.ShaderGenerator
{
    public class RenderMethodDefinitionGenerator
    {
        public static RenderMethodDefinition GenerateRenderMethodDefinition(GameCache cache, Stream cacheStream, IShaderGenerator generator, HaloShaderGenerator.Globals.ShaderType shaderType, bool regenGlobals, bool applyFixes)
        {
            var rmdf = new RenderMethodDefinition
            {
                GlobalOptions = GetOrCreateRmdfGlobalOptions(cache, cacheStream, generator, shaderType),
                Categories = BuildRmdfCategories(cache, cacheStream, generator, shaderType),
                EntryPoints = BuildEntryPoints(generator),
                VertexTypes = BuildVertexTypes(generator),
                Flags = GetRenderMethodFlags(generator),
            };

            GenerateSharedShaders(cache, cacheStream, rmdf, shaderType, regenGlobals, applyFixes);

            return rmdf;
        }

        private static CategoryBlock.ShaderOption BuildCategoryOption(GameCache cache, Stream cacheStream, string categoryName, uint categoryIndex, int optionIndex, IShaderGenerator generator)
        {
            CategoryBlock.ShaderOption result = new CategoryBlock.ShaderOption();

            string optionName = FixupMethodOptionName(generator.GetMethodOptionNames((int)categoryIndex).GetValue(optionIndex).ToString().ToLower());

            result.Name = cache.StringTable.GetOrAddString(optionName);

            var parameters = generator.GetParametersInOption(categoryName, optionIndex, out string rmopName, out _);

            if (rmopName != null)
            {
                RenderMethodOption rmop = BuildRenderMethodOptionFromParameters(cache, parameters);

                if (cache.TagCache.TryGetTag<RenderMethodOption>(rmopName, out CachedTag rmopTag))
                {
                    cache.Serialize(cacheStream, rmopTag, rmop);
                }
                else
                {
                    rmopTag = cache.TagCache.AllocateTag<RenderMethodOption>(rmopName);
                    cache.Serialize(cacheStream, rmopTag, rmop);
                }

                result.Option = rmopTag;
            }

            generator.GetOptionFunctions(categoryName, optionIndex, out string vertexFunction, out string pixelFunction);

            result.VertexFunction = vertexFunction != "invalid" ? cache.StringTable.GetOrAddString(vertexFunction) : StringId.Invalid;
            result.PixelFunction = pixelFunction != "invalid" ? cache.StringTable.GetOrAddString(pixelFunction) : StringId.Invalid;

            return result;
        }

        private static CategoryBlock BuildCategory(GameCache cache, Stream cacheStream, uint categoryIndex, IShaderGenerator generator, HaloShaderGenerator.Globals.ShaderType shaderType)
        {
            CategoryBlock result = new CategoryBlock();

            string categoryName = FixupMethodOptionName(generator.GetMethodNames().GetValue(categoryIndex).ToString().ToLower());

            result.Name = cache.StringTable.GetOrAddString(categoryName);

            result.ShaderOptions = new List<CategoryBlock.ShaderOption>();

            if (shaderType == HaloShaderGenerator.Globals.ShaderType.Black)
                return result;

            for (int i = 0; i < generator.GetMethodOptionCount((int)categoryIndex); i++)
            {
                var optionBlock = BuildCategoryOption(cache, cacheStream, categoryName, categoryIndex, i, generator);
                result.ShaderOptions.Add(optionBlock);
            }

            generator.GetCategoryFunctions(categoryName, out string vertexFunction, out string pixelFunction);

            result.VertexFunction = vertexFunction != "invalid" ? cache.StringTable.GetOrAddString(vertexFunction) : StringId.Invalid;
            result.PixelFunction = pixelFunction != "invalid" ? cache.StringTable.GetOrAddString(pixelFunction) : StringId.Invalid;

            return result;
        }

        private static List<CategoryBlock> BuildRmdfCategories(GameCache cache, Stream cacheStream, IShaderGenerator generator, HaloShaderGenerator.Globals.ShaderType shaderType)
        {
            List<CategoryBlock> result = new List<CategoryBlock>();

            for (uint i = 0; i < generator.GetMethodCount(); i++)
            {
                var categoryBlock = BuildCategory(cache, cacheStream, i, generator, shaderType);
                result.Add(categoryBlock);
            }

            cache.SaveStrings();
            return result;
        }

        private static CachedTag GetOrCreateRmdfGlobalOptions(GameCache cache, Stream cacheStream, IShaderGenerator generator, HaloShaderGenerator.Globals.ShaderType shaderType)
        {
            RenderMethodOption rmop = BuildRenderMethodOptionFromParameters(cache, generator.GetGlobalParameters(out string globalRmopName));

            if (cache.TagCache.TryGetTag<RenderMethodOption>(globalRmopName, out CachedTag rmopTag))
            {
                cache.Serialize(cacheStream, rmopTag, rmop);
            }
            else
            {
                rmopTag = cache.TagCache.AllocateTag<RenderMethodOption>(globalRmopName);
                cache.Serialize(cacheStream, rmopTag, rmop);
            }

            return rmopTag;
        }

        private static RenderMethodOption BuildRenderMethodOptionFromParameters(GameCache cache, ShaderParameters parameters)
        {
            RenderMethodOption rmop = new RenderMethodOption();
            rmop.Parameters = new List<RenderMethodOption.ParameterBlock>();

            foreach (var parameter in parameters.Parameters)
            {
                if (parameter.CodeType == HLSLType.Xform_2d || parameter.CodeType == HLSLType.Xform_3d)
                    continue;

                RenderMethodOption.ParameterBlock parameterBlock = new RenderMethodOption.ParameterBlock();

                parameterBlock.Name = cache.StringTable.GetOrAddString(parameter.ParameterName);

                parameterBlock.RenderMethodExtern = (RenderMethodExtern)parameter.RenderMethodExtern;

                switch (parameter.RegisterType)
                {
                    case RegisterType.Boolean:
                        parameterBlock.Type = RenderMethodOption.ParameterBlock.OptionDataType.Bool;
                        break;
                    case RegisterType.Integer:
                        parameterBlock.Type = RenderMethodOption.ParameterBlock.OptionDataType.Int;
                        break;
                    case RegisterType.Sampler:
                        parameterBlock.Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap;
                        break;
                    case RegisterType.Vector:
                        if (parameter.Flags.HasFlag(ShaderOptionParameter.ShaderParameterFlags.IsColor) && parameter.CodeType == HLSLType.Float4)
                            parameterBlock.Type = RenderMethodOption.ParameterBlock.OptionDataType.ArgbColor;
                        else if (parameter.Flags.HasFlag(ShaderOptionParameter.ShaderParameterFlags.IsColor) && parameter.CodeType == HLSLType.Float3)
                            parameterBlock.Type = RenderMethodOption.ParameterBlock.OptionDataType.Color;
                        else if (parameter.CodeType != HLSLType.Float4)
                            parameterBlock.Type = RenderMethodOption.ParameterBlock.OptionDataType.Real;
                        break;
                }

                parameterBlock.DefaultFilterMode = (RenderMethodOption.ParameterBlock.DefaultFilterModeValue)parameter.FilterMode;
                parameterBlock.DefaultAddressMode = (RenderMethodOption.ParameterBlock.DefaultAddressModeValue)parameter.AddressMode;

                parameterBlock.DefaultBitmapScale = parameter.BitmapScale;

                if (parameter.SamplerBitmap != null)
                {
                    if (cache.TagCache.TryGetTag<Bitmap>(parameter.SamplerBitmap, out CachedTag result))
                    {
                        parameterBlock.DefaultSamplerBitmap = result;
                    }
                    else
                    {
                        Log.Warning($"Could not retrieve sampler bitmap \"{parameter.SamplerBitmap}\"");
                        parameterBlock.DefaultSamplerBitmap = null;
                    }
                }
                else
                {
                    parameterBlock.DefaultSamplerBitmap = null;
                }

                parameterBlock.DefaultFloatArgument = parameter.FloatArgument;
                parameterBlock.DefaultIntBoolArgument = parameter.IntBoolArgument;
                parameterBlock.DefaultColor = new ArgbColor(parameter.ColorArgument.Alpha, parameter.ColorArgument.Red, parameter.ColorArgument.Green, parameter.ColorArgument.Blue);

                rmop.Parameters.Add(parameterBlock);
            }

            cache.SaveStrings();
            return rmop;
        }

        private static List<EntryPointBlock> BuildEntryPoints(IShaderGenerator generator)
        {
            List<EntryPointBlock> result = new List<EntryPointBlock>();

            for (int i = 0; i < generator.GetEntryPointOrder().Length; i++)
            {
                ShaderStage entryPoint = (ShaderStage)generator.GetEntryPointOrder().GetValue(i);

                var passBlock = new EntryPointBlock.PassBlock
                {
                    Flags = generator.IsPixelShaderShared(entryPoint) ? EntryPointBlock.PassBlock.PassFlags.HasSharedPixelShader : EntryPointBlock.PassBlock.PassFlags.None,
                    CategoryDependencies = new List<EntryPointBlock.PassBlock.CategoryDependency>()
                };

                if (generator.IsSharedPixelShaderUsingMethods(entryPoint))
                {
                    passBlock.CategoryDependencies.Add(new EntryPointBlock.PassBlock.CategoryDependency
                    {
                        Category = (ushort)generator.GetSharedPixelShaderCategory(entryPoint)
                    });
                }

                result.Add(new EntryPointBlock { EntryPoint = (EntryPoint_32)entryPoint, Passes = new List<EntryPointBlock.PassBlock> { passBlock } });
            }

            return result;
        }

        private static List<VertexBlock> BuildVertexTypes(IShaderGenerator generator)
        {
            List<VertexBlock> result = new List<VertexBlock>();

            for (int i = 0; i < generator.GetVertexTypeOrder().Length; i++) 
            {
                VertexType vertexType = (VertexType)generator.GetVertexTypeOrder().GetValue(i);

                result.Add(new VertexBlock { VertexType = (VertexBlock.VertexTypeValue)vertexType, Dependencies = new List<VertexBlock.EntryPointDependency>() });
            }

            return result;
        }

        private static void GenerateSharedShaders(GameCache cache, Stream cacheStream, RenderMethodDefinition rmdf, HaloShaderGenerator.Globals.ShaderType shaderType, bool regenGlobals, bool applyFixes)
        {
            string shaderName = shaderType.ToString().ToLower();

            switch (shaderType)
            {
                case HaloShaderGenerator.Globals.ShaderType.LightVolume:
                    shaderName = "light_volume";
                    break;
                case HaloShaderGenerator.Globals.ShaderType.FurStencil:
                    shaderName = "fur_stencil";
                    break;
            }

            GlobalPixelShader glps = ShaderGeneratorNew.GenerateSharedPixelShaders(cache, rmdf, shaderType, applyFixes);
            GlobalVertexShader glvs = ShaderGeneratorNew.GenerateSharedVertexShaders(cache, rmdf, shaderType, applyFixes);

            if (!cache.TagCache.TryGetTag<GlobalPixelShader>($"shaders\\{shaderName.ToLower()}_shared_pixel_shaders", out rmdf.GlobalPixelShader))
            {
                rmdf.GlobalPixelShader = cache.TagCache.AllocateTag<GlobalPixelShader>($"shaders\\{shaderName.ToLower()}_shared_pixel_shaders");
                cache.Serialize(cacheStream, rmdf.GlobalPixelShader, glps);
            }
            else if (regenGlobals) 
            {
                cache.Serialize(cacheStream, rmdf.GlobalPixelShader, glps);
            }

            if (!cache.TagCache.TryGetTag<GlobalVertexShader>($"shaders\\{shaderName.ToLower()}_shared_vertex_shaders", out rmdf.GlobalVertexShader))
            {
                rmdf.GlobalVertexShader = cache.TagCache.AllocateTag<GlobalVertexShader>($"shaders\\{shaderName.ToLower()}_shared_vertex_shaders");
                cache.Serialize(cacheStream, rmdf.GlobalVertexShader, glvs);
            }
            else if (regenGlobals) 
            {
                cache.Serialize(cacheStream, rmdf.GlobalVertexShader, glvs);
            }
        }

        private static string FixupMethodOptionName(string input)
        {
            switch (input)
            {
                case "diffuse_only_four_material_shaders_disable_detail_bump":
                    return "diffuse_only_(four_material_shaders_disable_detail_bump)";
                case "diffuse_plus_specular_four_material_shaders_disable_detail_bump":
                    return "diffuse_plus_specular_(four_material_shaders_disable_detail_bump)";
                case "first_person_never_with_rotating_bitmaps":
                    return @"first_person_never_w/rotating_bitmaps";
                case "_3_channel_self_illum":
                    return "3_channel_self_illum";
                case "blackness_no_options":
                    return "blackness(no_options)";
            }

            return input;
        }

        private static RenderMethodDefinitionFlags GetRenderMethodFlags(IShaderGenerator generator) 
        {
            return generator.IsAutoMacro() ? RenderMethodDefinitionFlags.UseAutomaticMacros : RenderMethodDefinitionFlags.None;
        }
    }
}
