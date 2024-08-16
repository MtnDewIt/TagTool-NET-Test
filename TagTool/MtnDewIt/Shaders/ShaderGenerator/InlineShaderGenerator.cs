using HaloShaderGenerator;
using HaloShaderGenerator.Globals;
using HaloShaderGenerator.Shader;
using HaloShaderGenerator.TemplateGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.RenderMethodDefinition;

namespace TagTool.MtnDewIt.Shaders.ShaderGenerator
{
    public class InlineShaderGenerator 
    {
        private static List<byte> ApplyGlpsOptionHacks(List<byte> fakeOptions, GameCache cache, RenderMethodDefinition rmdf, ShaderType shaderType)
        {
            // force foliage albedo to 'simple' for glps - we just want a basic sample
            if (shaderType == ShaderType.Foliage)
            {
                for (int i = 0; i < rmdf.Categories.Count; i++)
                {
                    if (cache.StringTable.GetString(rmdf.Categories[i].Name) != "albedo")
                        continue;

                    for (int j = 0; j < rmdf.Categories[i].ShaderOptions.Count; j++)
                    {
                        if (cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[j].Name) != "simple")
                            continue;

                        fakeOptions[i] = (byte)j;
                        break;
                    }

                    break;
                }
            }

            return fakeOptions;
        }

        private static List<OptionInfo> BuildOptionInfo(GameCache cache, RenderMethodDefinition rmdf, byte[] options, ShaderType shaderType, bool ps = true)
        {
            List<OptionInfo> optionInfo = new List<OptionInfo>();

            if (rmdf.Flags.HasFlag(RenderMethodDefinitionFlags.UseAutomaticMacros))
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (options[i] >= rmdf.Categories[i].ShaderOptions.Count)
                        continue;

                    string category = cache.StringTable.GetString(rmdf.Categories[i].Name);
                    string option = cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[options[i]].Name);

                    if (!ShaderGeneratorNew.AutoMacroIsParameter(category, shaderType) || ps)
                    {
                        optionInfo.Add(new OptionInfo
                        {
                            Category = category,
                            PsMacro = "category_" + category,
                            //VsMacro = "category_" + category,
                            VsMacro = "invalid",
                            Option = option,
                            PsMacroValue = "category_" + category + "_option_" + option,
                            //VsMacroValue = "category_" + category + "_option_" + option
                            VsMacroValue = "invalid"
                        });
                    }
                    // definitions
                    for (int j = 0; j < rmdf.Categories[i].ShaderOptions.Count; j++)
                    {
                        optionInfo.Add(new OptionInfo
                        {
                            Category = category,
                            PsMacro = "category_" + category + "_option_" + cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[j].Name),
                            //VsMacro = "category_" + category + "_option_" + cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[j].Name),
                            VsMacro = "invalid",
                            Option = cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[j].Name),
                            PsMacroValue = j.ToString(),
                            //VsMacroValue = j.ToString()
                            VsMacroValue = "invalid"
                        });
                    }
                }
            }
            else
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (options[i] >= rmdf.Categories[i].ShaderOptions.Count)
                        continue;

                    optionInfo.Add(new OptionInfo
                    {
                        Category = cache.StringTable.GetString(rmdf.Categories[i].Name),
                        PsMacro = cache.StringTable.GetString(rmdf.Categories[i].PixelFunction),
                        VsMacro = cache.StringTable.GetString(rmdf.Categories[i].VertexFunction),
                        Option = cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[options[i]].Name),
                        PsMacroValue = cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[options[i]].PixelFunction),
                        VsMacroValue = cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[options[i]].VertexFunction)
                    });
                }
            }

            return optionInfo;
        }

        private static StringId AddStringSafe(GameCache cache, string str)
        {
            var sTable = (StringTableHaloOnline)cache.StringTable;

            if (str == "")
                return StringId.Invalid;
            var stringId = sTable.GetStringId(str);
            if (stringId == StringId.Invalid)
                stringId = sTable.AddStringBlocking(str);
            return stringId;
        }

        private static TagTool.Shaders.ShaderConstantTable BuildConstantTable(GameCache cache, ShaderGeneratorResult result, TagTool.Shaders.ShaderType shaderType)
        {
            List<TagTool.Shaders.ShaderParameter> parameters = new List<TagTool.Shaders.ShaderParameter>();

            foreach (var register in result.Registers)
            {
                TagTool.Shaders.ShaderParameter shaderParameter = new TagTool.Shaders.ShaderParameter
                {
                    RegisterIndex = (ushort)register.Register,
                    RegisterCount = (byte)register.Size
                };

                switch (register.registerType)
                {
                    case ShaderGeneratorResult.ShaderRegister.RegisterType.Boolean:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Boolean;
                        break;
                    case ShaderGeneratorResult.ShaderRegister.RegisterType.Integer:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Integer;
                        break;
                    case ShaderGeneratorResult.ShaderRegister.RegisterType.Sampler:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Sampler;
                        break;
                    case ShaderGeneratorResult.ShaderRegister.RegisterType.Vector:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Vector;
                        break;
                }

                shaderParameter.ParameterName = AddStringSafe(cache, register.Name);

                parameters.Add(shaderParameter);
            }

            return new TagTool.Shaders.ShaderConstantTable
            {
                Constants = parameters,
                ShaderType = shaderType
            };
        }

        public static GlobalPixelShader GenerateSharedPixelShaders(GameCache cache, RenderMethodDefinition rmdf, ShaderType shaderType, bool applyFixes)
        {
            GlobalPixelShader glps = new GlobalPixelShader { EntryPoints = new List<GlobalPixelShader.EntryPointBlock>(), Shaders = new List<TagTool.Shaders.PixelShaderBlock>() };
            for (int i = 0; i < Enum.GetValues(typeof(TagTool.Shaders.EntryPoint)).Length; i++)
                glps.EntryPoints.Add(new GlobalPixelShader.EntryPointBlock { DefaultCompiledShaderIndex = -1 });

            TemplateGenerator generator = new TemplateGenerator();

            foreach (var entryPoint in rmdf.EntryPoints)
            {
                if (entryPoint.Passes[0].Flags.HasFlag(EntryPointBlock.PassBlock.PassFlags.HasSharedPixelShader))
                {
                    ShaderStage entry = (ShaderStage)Enum.Parse(typeof(ShaderStage), entryPoint.EntryPoint.ToString());

                    if (entryPoint.Passes[0].CategoryDependencies.Count > 0)
                    {
                        glps.EntryPoints[(int)entry].CategoryDependency = new List<GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock>();

                        foreach (var dependency in entryPoint.Passes[0].CategoryDependencies)
                        {
                            var dependencyBlock = new GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock
                            {
                                DefinitionCategoryIndex = dependency.Category,
                                OptionDependency = new List<GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock.GlobalShaderOptionDependency>()
                            };

                            for (int i = 0; i < rmdf.Categories[dependency.Category].ShaderOptions.Count; i++)
                            {
                                List<byte> fakeOptions = Enumerable.Repeat((byte)0, rmdf.Categories.Count).ToList();
                                fakeOptions[dependency.Category] = (byte)i;

                                fakeOptions = ApplyGlpsOptionHacks(fakeOptions, cache, rmdf, shaderType);

                                List<OptionInfo> optionInfo = BuildOptionInfo(cache, rmdf, fakeOptions.ToArray(), shaderType);

                                ShaderGeneratorResult generatorResult = generator.GeneratePixelShader(shaderType, entry, optionInfo, applyFixes);

                                dependencyBlock.OptionDependency.Add(new GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock.GlobalShaderOptionDependency
                                {
                                    CompiledShaderIndex = glps.Shaders.Count
                                });

                                var pixelShaderBlock = new TagTool.Shaders.PixelShaderBlock
                                {
                                    PCShaderBytecode = generatorResult.Bytecode,
                                    PCConstantTable = BuildConstantTable(cache, generatorResult, TagTool.Shaders.ShaderType.PixelShader)
                                };

                                glps.Shaders.Add(pixelShaderBlock);
                            }

                            glps.EntryPoints[(int)entry].CategoryDependency.Add(dependencyBlock);
                        }
                    }
                    else
                    {
                        List<byte> fakeOptions = Enumerable.Repeat((byte)0, rmdf.Categories.Count).ToList();
                        List<OptionInfo> optionInfo = BuildOptionInfo(cache, rmdf, fakeOptions.ToArray(), shaderType);

                        ShaderGeneratorResult generatorResult = generator.GeneratePixelShader(shaderType, entry, optionInfo, applyFixes);

                        glps.EntryPoints[(int)entry].DefaultCompiledShaderIndex = glps.Shaders.Count;

                        var pixelShaderBlock = new TagTool.Shaders.PixelShaderBlock
                        {
                            PCShaderBytecode = generatorResult.Bytecode,
                            PCConstantTable = BuildConstantTable(cache, generatorResult, TagTool.Shaders.ShaderType.PixelShader)
                        };

                        glps.Shaders.Add(pixelShaderBlock);
                    }
                }
            }

            return glps;
        }

        public static GlobalVertexShader GenerateSharedVertexShaders(GameCache cache, RenderMethodDefinition rmdf, ShaderType shaderType, bool applyFixes)
        {
            GlobalVertexShader glvs = new GlobalVertexShader { Shaders = new List<TagTool.Shaders.VertexShaderBlock>(), VertexTypes = new List<GlobalVertexShader.VertexTypeShaders>() };
            for (int i = 0; i < Enum.GetValues(typeof(VertexType)).Length; i++)
            {
                var vertexTypeBlock = new GlobalVertexShader.VertexTypeShaders { EntryPoints = new List<GlobalVertexShader.VertexTypeShaders.GlobalShaderEntryPointBlock>() };

                if (rmdf.VertexTypes.Any(x => x.VertexType == (VertexBlock.VertexTypeValue)i))
                    for (int j = 0; j < Enum.GetValues(typeof(TagTool.Shaders.EntryPoint)).Length; j++)
                        vertexTypeBlock.EntryPoints.Add(new GlobalVertexShader.VertexTypeShaders.GlobalShaderEntryPointBlock { ShaderIndex = -1 });
                glvs.VertexTypes.Add(vertexTypeBlock);
            }

            TemplateGenerator generator = new TemplateGenerator();

            foreach (var vertexTypeBlock in rmdf.VertexTypes)
            {
                VertexType vertexType = (VertexType)Enum.Parse(typeof(VertexType), vertexTypeBlock.VertexType.ToString());

                if (vertexType == VertexType.DualQuat)
                    continue; // unsupported

                foreach (var entryPoint in rmdf.EntryPoints)
                {
                    ShaderStage entry = (ShaderStage)Enum.Parse(typeof(ShaderStage), entryPoint.EntryPoint.ToString());

                    if (vertexTypeBlock.Dependencies.Count > 0)
                    {
                        // TODO: support vertex option dependencies (n/a in any stock gen3 halo)
                    }
                    else
                    {
                        List<byte> fakeOptions = Enumerable.Repeat((byte)0, rmdf.Categories.Count).ToList();
                        List<OptionInfo> optionInfo = BuildOptionInfo(cache, rmdf, fakeOptions.ToArray(), shaderType, false);

                        ShaderGeneratorResult generatorResult = generator.GenerateVertexShader(shaderType, entry, vertexType, optionInfo, applyFixes);

                        glvs.VertexTypes[(int)vertexType].EntryPoints[(int)entry].ShaderIndex = glvs.Shaders.Count;

                        var vertexShaderBlock = new TagTool.Shaders.VertexShaderBlock
                        {
                            PCShaderBytecode = generatorResult.Bytecode,
                            PCConstantTable = BuildConstantTable(cache, generatorResult, TagTool.Shaders.ShaderType.VertexShader)
                        };

                        glvs.Shaders.Add(vertexShaderBlock);
                    }
                }
            }

            return glvs;
        }

        public static void GenerateExplicitShader(GameCache cache, string explicitShader, bool applyFixes, out PixelShader pixl, out VertexShader vtsh)
        {
            ExplicitGenerator generator = new ExplicitGenerator();

            ExplicitShader eExplicitShader = generator.GetExplicitIndex(explicitShader);

            List<ShaderStage> supportedEntries = generator.ScrapeEntryPoints(eExplicitShader);
            List<VertexType> supportedVertices = generator.ScrapeVertexTypes(eExplicitShader);

            pixl = new PixelShader { EntryPointShaders = new List<TagTool.Shaders.ShortOffsetCountBlock>(), Shaders = new List<TagTool.Shaders.PixelShaderBlock>() };
            vtsh = new VertexShader { EntryPoints = new List<VertexShader.VertexShaderEntryPoint>(), Shaders = new List<TagTool.Shaders.VertexShaderBlock>() };

            for (int i = 0; i < Enum.GetValues(typeof(ShaderStage)).Length; i++)
            {
                pixl.EntryPointShaders.Add(new TagTool.Shaders.ShortOffsetCountBlock());
                vtsh.EntryPoints.Add(new VertexShader.VertexShaderEntryPoint { SupportedVertexTypes = new List<TagTool.Shaders.ShortOffsetCountBlock>() });
            }

            foreach (var entry in supportedEntries)
            {
                // pixel shader
                ShaderGeneratorResult pixelResult = generator.GeneratePixelShader(eExplicitShader, entry, applyFixes);

                pixl.EntryPointShaders[(int)entry].Count = 1;
                pixl.EntryPointShaders[(int)entry].Offset = (byte)pixl.Shaders.Count;

                var pixelShaderBlock = new TagTool.Shaders.PixelShaderBlock
                {
                    PCShaderBytecode = pixelResult.Bytecode,
                    PCConstantTable = BuildConstantTable(cache, pixelResult, TagTool.Shaders.ShaderType.PixelShader)
                };

                pixl.Shaders.Add(pixelShaderBlock);

                // vertex shaders
                foreach (var vertex in supportedVertices)
                {
                    for (int i = 0; vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Count <= (int)vertex; i++)
                        vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Add(new TagTool.Shaders.ShortOffsetCountBlock());

                    ShaderGeneratorResult vertexResult = generator.GenerateVertexShader(eExplicitShader, entry, vertex, applyFixes);

                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Count = 1;
                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Offset = (byte)vtsh.Shaders.Count;

                    var vertexShaderBlock = new TagTool.Shaders.VertexShaderBlock
                    {
                        PCShaderBytecode = vertexResult.Bytecode,
                        PCConstantTable = BuildConstantTable(cache, vertexResult, TagTool.Shaders.ShaderType.VertexShader)
                    };

                    vtsh.Shaders.Add(vertexShaderBlock);
                }
            }
        }

        public static void GenerateChudShader(GameCache cache, string chudShader, bool applyFixes, out PixelShader pixl, out VertexShader vtsh)
        {
            //ChudShader eChudShader = (ChudShader)Enum.Parse(typeof(ChudShader), chudShader, true);

            List<ShaderStage> supportedEntries = new List<ShaderStage> { ShaderStage.Default };

            switch (chudShader)
            {
                case "chud_turbulence":
                    supportedEntries.Add(ShaderStage.Albedo);
                    supportedEntries.Add(ShaderStage.Dynamic_Light);
                    break;
            }

            List<VertexType> supportedVertices = new List<VertexType> { (chudShader == "chud_sensor" ? VertexType.FancyChud : VertexType.SimpleChud) };

            pixl = new PixelShader { EntryPointShaders = new List<TagTool.Shaders.ShortOffsetCountBlock>(), Shaders = new List<TagTool.Shaders.PixelShaderBlock>() };
            vtsh = new VertexShader { EntryPoints = new List<VertexShader.VertexShaderEntryPoint>(), Shaders = new List<TagTool.Shaders.VertexShaderBlock>() };

            for (int i = 0; i < Enum.GetValues(typeof(ShaderStage)).Length; i++)
            {
                pixl.EntryPointShaders.Add(new TagTool.Shaders.ShortOffsetCountBlock());
                vtsh.EntryPoints.Add(new VertexShader.VertexShaderEntryPoint { SupportedVertexTypes = new List<TagTool.Shaders.ShortOffsetCountBlock>() });
            }

            foreach (var entry in supportedEntries)
            {
                // pixel shader
                ShaderGeneratorResult pixelResult = GenericPixelShaderGenerator.GeneratePixelShader(chudShader, entry.ToString().ToLower(), applyFixes);

                pixl.EntryPointShaders[(int)entry].Count = 1;
                pixl.EntryPointShaders[(int)entry].Offset = (byte)pixl.Shaders.Count;

                var pixelShaderBlock = new TagTool.Shaders.PixelShaderBlock
                {
                    PCShaderBytecode = pixelResult.Bytecode,
                    PCConstantTable = BuildConstantTable(cache, pixelResult, TagTool.Shaders.ShaderType.PixelShader)
                };

                pixl.Shaders.Add(pixelShaderBlock);

                // vertex shaders
                foreach (var vertex in supportedVertices)
                {
                    for (int i = 0; vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Count <= (int)vertex; i++)
                        vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Add(new TagTool.Shaders.ShortOffsetCountBlock());

                    ShaderGeneratorResult vertexResult = GenericVertexShaderGenerator.GenerateVertexShader(chudShader, entry.ToString().ToLower(), vertex, applyFixes);

                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Count = 1;
                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Offset = (byte)vtsh.Shaders.Count;

                    var vertexShaderBlock = new TagTool.Shaders.VertexShaderBlock
                    {
                        PCShaderBytecode = vertexResult.Bytecode,
                        PCConstantTable = BuildConstantTable(cache, vertexResult, TagTool.Shaders.ShaderType.VertexShader)
                    };

                    vtsh.Shaders.Add(vertexShaderBlock);
                }
            }
        }
    }
}
