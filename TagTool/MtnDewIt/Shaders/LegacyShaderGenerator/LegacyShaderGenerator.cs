using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HaloShaderGenerator.LegacyGenerator;
using HaloShaderGenerator.LegacyGenerator.Generator;
using HaloShaderGenerator.Globals;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Shaders.ShaderFunctions;
using TagTool.Tags.Definitions;
using static TagTool.Shaders.ShaderFunctions.ShaderFunctionHelper;
using static TagTool.Tags.Definitions.RenderMethod.RenderMethodPostprocessBlock;

namespace TagTool.MtnDewIt.Shaders.LegacyShaderGenerator
{
    struct SDependentRenderMethodData
    {
        public CachedTag Tag;
        public object Definition;
        public AnimatedParameter[] AnimatedParameters;
        public List<string> OrderedRealParameters;
        public List<string> OrderedIntParameters;
        public List<string> OrderedBoolParameters;
        public List<string> OrderedTextures;
        public int EffectIndex;

        public static void AddDependant(List<SDependentRenderMethodData> dependentRenderMethods, GameCache cache, CachedTag dependent, RenderMethod renderMethod, RenderMethodTemplate origRmt2, int effectIndex = -1)
        {
            var animatedParams = GetAnimatedParameters(cache, renderMethod, origRmt2);

            SDependentRenderMethodData dpData = new SDependentRenderMethodData
            {
                Tag = dependent,
                Definition = renderMethod,
                AnimatedParameters = animatedParams.ToArray(),
                OrderedRealParameters = new List<string>(),
                OrderedIntParameters = new List<string>(),
                OrderedBoolParameters = new List<string>(),
                OrderedTextures = new List<string>(),
                EffectIndex = effectIndex,
            };

            foreach (var realP in origRmt2.RealParameterNames)
                dpData.OrderedRealParameters.Add(cache.StringTable.GetString(realP.Name));
            foreach (var intP in origRmt2.IntegerParameterNames)
                dpData.OrderedIntParameters.Add(cache.StringTable.GetString(intP.Name));
            foreach (var boolP in origRmt2.BooleanParameterNames)
                dpData.OrderedBoolParameters.Add(cache.StringTable.GetString(boolP.Name));
            foreach (var textureP in origRmt2.TextureParameterNames)
                dpData.OrderedTextures.Add(cache.StringTable.GetString(textureP.Name));

            dependentRenderMethods.Add(dpData);
        }
    }

    public class LegacyShaderGenerator 
    {
        private static StringId AddString(GameCache cache, string str)
        {
            if (str == "")
                return StringId.Invalid;

            var stringId = cache.StringTable.GetStringId(str);

            if (stringId == StringId.Invalid)
                stringId = cache.StringTable.AddString(str);

            return stringId;
        }

        private static List<TagTool.Shaders.ShaderParameter> GenerateShaderParametersFromGenerator(GameCache cache, LegacyShaderGeneratorResult result)
        {
            var parameters = new List<TagTool.Shaders.ShaderParameter>();
            foreach (var register in result.Registers)
            {
                TagTool.Shaders.ShaderParameter shaderParameter = new TagTool.Shaders.ShaderParameter
                {
                    RegisterIndex = (ushort)register.Register,
                    RegisterCount = (byte)register.Size
                };

                switch (register.registerType)
                {
                    case LegacyShaderGeneratorResult.ShaderRegister.RegisterType.Boolean:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Boolean;
                        break;
                    case LegacyShaderGeneratorResult.ShaderRegister.RegisterType.Integer:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Integer;
                        break;
                    case LegacyShaderGeneratorResult.ShaderRegister.RegisterType.Sampler:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Sampler;
                        break;
                    case LegacyShaderGeneratorResult.ShaderRegister.RegisterType.Vector:
                        shaderParameter.RegisterType = TagTool.Shaders.ShaderParameter.RType.Vector;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                shaderParameter.ParameterName = AddString(cache, register.Name);

                parameters.Add(shaderParameter);
            }
            return parameters;
        }

        public static PixelShaderBlock GeneratePixelShaderBlock(GameCache cache, LegacyShaderGeneratorResult result)
        {
            if (result == null)
                return null;
            var pixelShaderBlock = new PixelShaderBlock
            {
                PCShaderBytecode = result.Bytecode,
                PCConstantTable = new ShaderConstantTable
                {
                    Constants = GenerateShaderParametersFromGenerator(cache, result),
                    ShaderType = TagTool.Shaders.ShaderType.PixelShader
                }
            };

            return pixelShaderBlock;
        }

        public static VertexShaderBlock GenerateVertexShaderBlock(GameCache cache, LegacyShaderGeneratorResult result)
        {
            if (result == null)
                return null;
            var vertexShaderBlock = new VertexShaderBlock
            {
                PCShaderBytecode = result.Bytecode,
                PCConstantTable = new ShaderConstantTable()
                {
                    Constants = GenerateShaderParametersFromGenerator(cache, result),
                    ShaderType = TagTool.Shaders.ShaderType.VertexShader
                }
            };

            return vertexShaderBlock;
        }

        public static GlobalVertexShader GenerateSharedVertexShader(GameCache cache, IShaderGenerator generator)
        {
            var glvs = new GlobalVertexShader { VertexTypes = new List<GlobalVertexShader.VertexTypeShaders>(), Shaders = new List<VertexShaderBlock>() };

            foreach (VertexType vertex in Enum.GetValues(typeof(VertexType)))
            {
                var vertexBlock = new GlobalVertexShader.VertexTypeShaders { EntryPoints = new List<GlobalVertexShader.VertexTypeShaders.GlobalShaderEntryPointBlock>() };
                glvs.VertexTypes.Add(vertexBlock);
                if (generator.IsVertexFormatSupported(vertex))
                {
                    foreach (ShaderStage entryPoint in Enum.GetValues(typeof(ShaderStage)))
                    {
                        var entryBlock = new GlobalVertexShader.VertexTypeShaders.GlobalShaderEntryPointBlock { ShaderIndex = -1 };

                        vertexBlock.EntryPoints.Add(entryBlock);
                        if (generator.IsEntryPointSupported(entryPoint) && generator.IsVertexShaderShared(entryPoint))
                        {
                            entryBlock.ShaderIndex = glvs.Shaders.Count;
                            var result = generator.GenerateSharedVertexShader(vertex, entryPoint);
                            glvs.Shaders.Add(GenerateVertexShaderBlock(cache, result));
                        }
                    }
                }
            }

            return glvs;
        }

        public static VertexShader GenerateVertexShader(GameCache cache, IShaderGenerator generator)
        {
            var vtsh = new VertexShader { EntryPoints = new List<VertexShader.VertexShaderEntryPoint>(), Shaders = new List<VertexShaderBlock>() };

            foreach (VertexType vertex in Enum.GetValues(typeof(VertexType)))
            {
                var vertexBlock = new VertexShader.VertexShaderEntryPoint { SupportedVertexTypes = new List<ShortOffsetCountBlock>() };
                vtsh.EntryPoints.Add(vertexBlock);
                if (generator.IsVertexFormatSupported(vertex))
                {
                    foreach (ShaderStage entryPoint in Enum.GetValues(typeof(ShaderStage)))
                    {
                        var entryBlock = new ShortOffsetCountBlock();
                        vertexBlock.SupportedVertexTypes.Add(entryBlock);
                        if (generator.IsEntryPointSupported(entryPoint) && !generator.IsVertexShaderShared(entryPoint))
                        {
                            entryBlock.Count = 1;
                            entryBlock.Offset = (byte)vtsh.Shaders.Count;
                            var result = generator.GenerateVertexShader(vertex, entryPoint);
                            vtsh.Shaders.Add(GenerateVertexShaderBlock(cache, result));
                        }
                    }
                }
            }

            if (vtsh.Shaders.Count == 0)
                vtsh.EntryPoints = null;

            return vtsh;
        }

        public static GlobalPixelShader GenerateSharedPixelShader(GameCache cache, IShaderGenerator generator)
        {
            var glps = new GlobalPixelShader { EntryPoints = new List<GlobalPixelShader.EntryPointBlock>(), Shaders = new List<PixelShaderBlock>() };
            foreach (ShaderStage entryPoint in Enum.GetValues(typeof(ShaderStage)))
            {
                var entryPointBlock = new GlobalPixelShader.EntryPointBlock { DefaultCompiledShaderIndex = -1 };
                glps.EntryPoints.Add(entryPointBlock);

                if (generator.IsEntryPointSupported(entryPoint) &&
                    generator.IsPixelShaderShared(entryPoint))
                {
                    if (generator.IsSharedPixelShaderWithoutMethod(entryPoint))
                    {
                        entryPointBlock.DefaultCompiledShaderIndex = glps.Shaders.Count;
                        var result = generator.GenerateSharedPixelShader(entryPoint, 0, 0);
                        glps.Shaders.Add(GeneratePixelShaderBlock(cache, result));
                    }

                    else if (generator.IsSharedPixelShaderUsingMethods(entryPoint))
                    {
                        for (int i = 0; i < generator.GetMethodCount(); i++)
                        {
                            if (generator.IsMethodSharedInEntryPoint(entryPoint, i))
                            {
                                entryPointBlock.CategoryDependency = new List<GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock>();

                                var optionBlock = new GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock
                                {
                                    DefinitionCategoryIndex = (short)i,
                                    OptionDependency = new List<GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock.GlobalShaderOptionDependency>()
                                };

                                entryPointBlock.CategoryDependency.Add(optionBlock);

                                for (int option = 0; option < generator.GetMethodOptionCount(i); option++)
                                {
                                    optionBlock.OptionDependency.Add(new GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock.GlobalShaderOptionDependency { CompiledShaderIndex = glps.Shaders.Count });
                                    var result = generator.GenerateSharedPixelShader(entryPoint, i, option);
                                    glps.Shaders.Add(GeneratePixelShaderBlock(cache, result));
                                }
                            }
                        }
                    }
                }
            }
            return glps;
        }

        public static PixelShader GeneratePixelShader(GameCache cache, IShaderGenerator generator)
        {
            var pixl = new PixelShader { EntryPointShaders = new List<ShortOffsetCountBlock>(), Shaders = new List<PixelShaderBlock>() };

            Dictionary<Task<LegacyShaderGeneratorResult>, int> tasks = new Dictionary<Task<LegacyShaderGeneratorResult>, int>(); // <task, entry point>


            foreach (ShaderStage entryPoint in Enum.GetValues(typeof(ShaderStage)))
            {
                var entryBlock = new ShortOffsetCountBlock();
                pixl.EntryPointShaders.Add(entryBlock);

                if (generator.IsEntryPointSupported(entryPoint) && !generator.IsPixelShaderShared(entryPoint))
                {
                    Task<LegacyShaderGeneratorResult> generatorTask = Task.Run(() => { return generator.GeneratePixelShader(entryPoint); });
                    tasks.Add(generatorTask, (int)entryPoint);
                }
            }

            Task.WaitAll(tasks.Keys.ToArray());

            foreach (var task in tasks)
            {
                pixl.EntryPointShaders[task.Value].Count = 1;
                pixl.EntryPointShaders[task.Value].Offset = (byte)pixl.Shaders.Count;
                pixl.Shaders.Add(GeneratePixelShaderBlock(cache, task.Key.Result));
            }
            return pixl;
        }

        private static int GetArgumentIndex(GameCache cache, string name, List<RenderMethodTemplate.ShaderArgument> args)
        {
            int index = -1;
            for (int i = 0; i < args.Count; i++)
            {
                var varg = args[i];
                if (name == cache.StringTable.GetString(varg.Name))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private static List<RenderMethodTemplate.RoutingInfoBlock> MapParameters(GameCache cache, ParameterUsage usage, ShaderParameters parameters, Dictionary<string, int> shaderRegisterMapping, List<RenderMethodTemplate.ShaderArgument> parameterNames)
        {
            var result = new List<RenderMethodTemplate.RoutingInfoBlock>();
            List<HaloShaderGenerator.Globals.ShaderParameter> shaderParameters;
            switch (usage)
            {
                case ParameterUsage.PS_Real:
                    shaderParameters = parameters.GetRealPixelParameters();
                    break;

                case ParameterUsage.VS_Real:
                    shaderParameters = parameters.GetRealVertexParameters();
                    break;

                case ParameterUsage.PS_Integer:
                    shaderParameters = parameters.GetIntegerPixelParameters();
                    break;

                case ParameterUsage.VS_Integer:
                    shaderParameters = parameters.GetIntegerVertexParameters();
                    break;

                case ParameterUsage.PS_Boolean:
                    shaderParameters = parameters.GetBooleanPixelParameters();
                    break;

                case ParameterUsage.VS_Boolean:
                    shaderParameters = parameters.GetBooleanVertexParameters();
                    break;

                case ParameterUsage.Texture:
                    shaderParameters = parameters.GetSamplerParameters();
                    break;
                default:
                    shaderParameters = new List<HaloShaderGenerator.Globals.ShaderParameter>();
                    break;
            }
            foreach (var parameter in shaderParameters)
            {
                bool vertex = (usage == ParameterUsage.Texture || usage == ParameterUsage.TextureExtern) && parameter.Flags.HasFlag(ShaderParameterFlags.IsVertexShader);
                var argumentMapping = new RenderMethodTemplate.RoutingInfoBlock();
                var registerName = vertex ? parameter.RegisterName + "_VERTEX_" : parameter.RegisterName;
                if (shaderRegisterMapping.ContainsKey(registerName))
                {
                    argumentMapping.DestinationIndex = (ushort)shaderRegisterMapping[registerName];
                    argumentMapping.SourceIndex = (byte)GetArgumentIndex(cache, parameter.ParameterName, parameterNames);
                    argumentMapping.Flags = (byte)(vertex ? 1 : 0);
                }
                else
                {
                    // Console.WriteLine($"Failed to find {usage} register parameter for {parameter.ParameterName}");
                    continue; // skip parameter, not present in shader
                }
                result.Add(argumentMapping);
            }
            return result;
        }

        private static List<RenderMethodTemplate.RoutingInfoBlock> MapExternParameters(ParameterUsage usage, ShaderParameters parameters, ShaderParameters globalParameters, Dictionary<string, int> shaderRegisterMapping)
        {
            var result = new List<RenderMethodTemplate.RoutingInfoBlock>();
            List<HaloShaderGenerator.Globals.ShaderParameter> shaderParameters;
            switch (usage)
            {
                case ParameterUsage.PS_RealExtern:
                    shaderParameters = parameters.GetRealExternPixelParameters();
                    shaderParameters.AddRange(globalParameters.GetRealExternPixelParameters());
                    break;
                case ParameterUsage.PS_IntegerExtern:
                    shaderParameters = parameters.GetIntegerExternPixelParameters();
                    shaderParameters.AddRange(globalParameters.GetIntegerExternPixelParameters());
                    break;
                case ParameterUsage.TextureExtern:
                    shaderParameters = parameters.GetSamplerExternPixelParameters();
                    shaderParameters.AddRange(globalParameters.GetSamplerExternPixelParameters());
                    break;

                case ParameterUsage.VS_RealExtern:
                    shaderParameters = parameters.GetRealExternVertexParameters();
                    shaderParameters.AddRange(globalParameters.GetRealExternVertexParameters());
                    break;
                case ParameterUsage.VS_IntegerExtern:
                    shaderParameters = parameters.GetIntegerExternVertexParameters();
                    shaderParameters.AddRange(globalParameters.GetIntegerExternVertexParameters());
                    break;

                default:
                    shaderParameters = new List<HaloShaderGenerator.Globals.ShaderParameter>();
                    break;
            }
            foreach (var parameter in shaderParameters)
            {
                var argumentMapping = new RenderMethodTemplate.RoutingInfoBlock();
                var registerName = parameter.RegisterName;
                if (shaderRegisterMapping.ContainsKey(registerName))
                {
                    argumentMapping.DestinationIndex = (ushort)shaderRegisterMapping[registerName];
                    argumentMapping.SourceIndex = (byte)parameter.RenderMethodExtern; // use the enum integer value
                }
                else
                {
                    // Console.WriteLine($"Failed to find {usage} register parameter for {parameter.ParameterName}");
                    continue; // skip parameter, not present in shader
                }
                result.Add(argumentMapping);
            }
            return result;
        }

        private static void AddMapping(ParameterUsage usage, RenderMethodTemplate rmt2, RenderMethodTemplate.PassBlock table, List<RenderMethodTemplate.RoutingInfoBlock> mappings)
        {
            if (mappings.Count > 0)
            {
                table[usage] = new RenderMethodTemplate.TagBlockIndex
                {
                    Offset = (ushort)rmt2.RoutingInfo.Count,
                    Count = (ushort)mappings.Count
                };
                rmt2.RoutingInfo.AddRange(mappings);
            }
        }

        public static RenderMethodTemplate GenerateRenderMethodTemplate(GameCache cache, Stream cacheStream, RenderMethodDefinition rmdf, GlobalPixelShader glps, GlobalVertexShader glvs, IShaderGenerator generator, string shaderName, out PixelShader pixl, out VertexShader vtsh)
        {
            var rmt2 = new RenderMethodTemplate();

            pixl = GeneratePixelShader(cache, generator);
            vtsh = GenerateVertexShader(cache, generator);

            if (!cache.TagCache.TryGetTag(shaderName + ".pixl", out var pixlTag))
                pixlTag = cache.TagCache.AllocateTag<PixelShader>(shaderName);
            cache.Serialize(cacheStream, pixlTag, pixl);
            rmt2.PixelShader = pixlTag;

            if (!cache.TagCache.TryGetTag(shaderName + ".vtsh", out var vtshTag))
                vtshTag = cache.TagCache.AllocateTag<VertexShader>(shaderName);
            cache.Serialize(cacheStream, vtshTag, vtsh);
            rmt2.VertexShader = vtshTag;

            foreach (ShaderStage mode in Enum.GetValues(typeof(ShaderStage)))
                if (generator.IsEntryPointSupported(mode))
                    rmt2.ValidEntryPoints |= (EntryPointBitMask)(1 << (int)mode);

            rmt2.RealParameterNames = new List<RenderMethodTemplate.ShaderArgument>();
            rmt2.IntegerParameterNames = new List<RenderMethodTemplate.ShaderArgument>();
            rmt2.BooleanParameterNames = new List<RenderMethodTemplate.ShaderArgument>();
            rmt2.TextureParameterNames = new List<RenderMethodTemplate.ShaderArgument>();

            var pixelShaderParameters = generator.GetPixelShaderParameters();
            var vertexShaderParameters = generator.GetVertexShaderParameters();
            var globalShaderParameters = generator.GetGlobalParameters();

            List<string> realParameterNames = new List<string>();
            List<string> intParameterNames = new List<string>();
            List<string> boolParameterNames = new List<string>();
            List<string> textureParameterNames = new List<string>();

            foreach (var p in pixelShaderParameters.GetRealPixelParameters())
                if (!realParameterNames.Contains(p.ParameterName))
                    realParameterNames.Add(p.ParameterName);
            foreach (var p in vertexShaderParameters.GetRealVertexParameters())
                if (!realParameterNames.Contains(p.ParameterName))
                    realParameterNames.Add(p.ParameterName);

            foreach (var p in pixelShaderParameters.GetIntegerPixelParameters())
                if (!intParameterNames.Contains(p.ParameterName))
                    intParameterNames.Add(p.ParameterName);
            foreach (var p in vertexShaderParameters.GetIntegerVertexParameters())
                if (!intParameterNames.Contains(p.ParameterName))
                    intParameterNames.Add(p.ParameterName);

            foreach (var p in pixelShaderParameters.GetBooleanPixelParameters())
                if (!boolParameterNames.Contains(p.ParameterName))
                    boolParameterNames.Add(p.ParameterName);
            foreach (var p in vertexShaderParameters.GetBooleanVertexParameters())
                if (!boolParameterNames.Contains(p.ParameterName))
                    boolParameterNames.Add(p.ParameterName);

            foreach (var p in pixelShaderParameters.GetSamplerPixelParameters())
                if (!textureParameterNames.Contains(p.ParameterName))
                    textureParameterNames.Add(p.ParameterName);
            foreach (var p in vertexShaderParameters.GetSamplerVertexParameters())
                if (!textureParameterNames.Contains(p.ParameterName))
                    textureParameterNames.Add(p.ParameterName);

            foreach (var p in realParameterNames)
                rmt2.RealParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = AddString(cache, p) });
            foreach (var p in intParameterNames)
                rmt2.IntegerParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = AddString(cache, p) });
            foreach (var p in boolParameterNames)
                rmt2.BooleanParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = AddString(cache, p) });
            foreach (var p in textureParameterNames)
                rmt2.TextureParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = AddString(cache, p) });

            rmt2.RoutingInfo = new List<RenderMethodTemplate.RoutingInfoBlock>();
            rmt2.Passes = new List<RenderMethodTemplate.PassBlock>();
            rmt2.EntryPoints = new List<RenderMethodTemplate.TagBlockIndex>();

            foreach (ShaderStage mode in Enum.GetValues(typeof(ShaderStage)))
            {
                var entryPoint = new RenderMethodTemplate.TagBlockIndex();

                if (generator.IsEntryPointSupported(mode))
                {
                    while (rmt2.EntryPoints.Count < (int)mode)
                        rmt2.EntryPoints.Add(new RenderMethodTemplate.TagBlockIndex());

                    entryPoint.Offset = (ushort)rmt2.Passes.Count();
                    entryPoint.Count = 1;
                    rmt2.EntryPoints.Add(entryPoint);

                    var parameterTable = new RenderMethodTemplate.PassBlock();

                    for (int i = 0; i < parameterTable.Values.Length; i++)
                        parameterTable.Values[i] = new RenderMethodTemplate.TagBlockIndex();

                    rmt2.Passes.Add(parameterTable);

                    // find pixel shader and vertex shader block loaded by this entry point

                    PixelShaderBlock pixelShader;
                    VertexShaderBlock vertexShader;

                    if (generator.IsVertexShaderShared(mode))
                        vertexShader = glvs.Shaders[glvs.VertexTypes[(ushort)rmdf.VertexTypes[0].VertexType].EntryPoints[(int)mode].ShaderIndex];
                    else
                        vertexShader = vtsh.Shaders[vtsh.EntryPoints[(ushort)rmdf.VertexTypes[0].VertexType].SupportedVertexTypes[(int)mode].Offset];

                    if (generator.IsPixelShaderShared(mode))
                    {
                        if (glps.EntryPoints[(int)mode].DefaultCompiledShaderIndex == -1)
                        {
                            // assumes shared pixel shader are only used for a single method, otherwise unknown procedure to obtain one or more pixel shader block
                            var optionValue = generator.GetMethodOptionValue(glps.EntryPoints[(int)mode].CategoryDependency[0].DefinitionCategoryIndex);
                            pixelShader = glps.Shaders[glps.EntryPoints[(int)mode].CategoryDependency[0].OptionDependency[optionValue].CompiledShaderIndex];
                        }
                        else
                            pixelShader = glps.Shaders[glps.EntryPoints[(int)mode].DefaultCompiledShaderIndex];
                    }
                    else
                        pixelShader = pixl.Shaders[pixl.EntryPointShaders[(int)mode].Offset];



                    // build dictionary register name to register index, speeds lookup time
                    // needs to be built for each usage type to avoid name conflicts

                    Dictionary<string, int> pixelShaderSamplerMapping = new Dictionary<string, int>();
                    Dictionary<string, int> pixelShaderVectorMapping = new Dictionary<string, int>();
                    Dictionary<string, int> pixelShaderIntegerMapping = new Dictionary<string, int>();
                    Dictionary<string, int> pixelShaderBooleanMapping = new Dictionary<string, int>();

                    foreach (var reg in pixelShader.PCConstantTable.Constants)
                    {
                        switch (reg.RegisterType)
                        {
                            case TagTool.Shaders.ShaderParameter.RType.Sampler:
                                pixelShaderSamplerMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                break;
                            case TagTool.Shaders.ShaderParameter.RType.Vector:
                                pixelShaderVectorMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                break;
                            case TagTool.Shaders.ShaderParameter.RType.Integer:
                                pixelShaderIntegerMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                break;
                            case TagTool.Shaders.ShaderParameter.RType.Boolean:
                                pixelShaderBooleanMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                break;
                        }
                    }

                    Dictionary<string, int> vertexShaderSamplerMapping = new Dictionary<string, int>();
                    Dictionary<string, int> vertexShaderVectorMapping = new Dictionary<string, int>();
                    Dictionary<string, int> vertexShaderIntegerMapping = new Dictionary<string, int>();
                    Dictionary<string, int> vertexShaderBooleanMapping = new Dictionary<string, int>();

                    foreach (var reg in vertexShader.PCConstantTable.Constants)
                    {
                        switch (reg.RegisterType)
                        {
                            case TagTool.Shaders.ShaderParameter.RType.Sampler:
                                //vertexShaderSamplerMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                pixelShaderSamplerMapping[cache.StringTable.GetString(reg.ParameterName) + "_VERTEX_"] = reg.RegisterIndex; // quick fix instead of rewriting all
                                break;
                            case TagTool.Shaders.ShaderParameter.RType.Vector:
                                vertexShaderVectorMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                break;
                            case TagTool.Shaders.ShaderParameter.RType.Integer:
                                vertexShaderIntegerMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                break;
                            case TagTool.Shaders.ShaderParameter.RType.Boolean:
                                vertexShaderBooleanMapping[cache.StringTable.GetString(reg.ParameterName)] = reg.RegisterIndex;
                                break;
                        }
                    }

                    // build parameter table and registers available for this entry point, order to be determined

                    List<RenderMethodTemplate.RoutingInfoBlock> mappings;
                    ParameterUsage currentUsage;

                    // sampler (ps)

                    currentUsage = ParameterUsage.TextureExtern;
                    mappings = MapExternParameters(currentUsage, pixelShaderParameters, globalShaderParameters, pixelShaderSamplerMapping);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    currentUsage = ParameterUsage.Texture;
                    ShaderParameters newTextureParameters = new ShaderParameters();
                    newTextureParameters.Parameters.AddRange(pixelShaderParameters.GetSamplerPixelParameters());
                    newTextureParameters.Parameters.AddRange(vertexShaderParameters.GetSamplerVertexParameters());
                    mappings = MapParameters(cache, currentUsage, newTextureParameters, pixelShaderSamplerMapping, rmt2.TextureParameterNames);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    // ps

                    currentUsage = ParameterUsage.PS_Real;
                    mappings = MapParameters(cache, currentUsage, pixelShaderParameters, pixelShaderVectorMapping, rmt2.RealParameterNames);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    currentUsage = ParameterUsage.PS_Integer;
                    mappings = MapParameters(cache, currentUsage, pixelShaderParameters, pixelShaderIntegerMapping, rmt2.IntegerParameterNames);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    currentUsage = ParameterUsage.PS_Boolean;
                    mappings = MapParameters(cache, currentUsage, pixelShaderParameters, pixelShaderBooleanMapping, rmt2.BooleanParameterNames);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    // vs

                    currentUsage = ParameterUsage.VS_Real;
                    mappings = MapParameters(cache, currentUsage, vertexShaderParameters, vertexShaderVectorMapping, rmt2.RealParameterNames);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    currentUsage = ParameterUsage.VS_Integer;
                    mappings = MapParameters(cache, currentUsage, vertexShaderParameters, vertexShaderIntegerMapping, rmt2.IntegerParameterNames);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    currentUsage = ParameterUsage.VS_Boolean;
                    mappings = MapParameters(cache, currentUsage, vertexShaderParameters, vertexShaderBooleanMapping, rmt2.BooleanParameterNames);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    // ps extern

                    currentUsage = ParameterUsage.PS_RealExtern;
                    mappings = MapExternParameters(currentUsage, pixelShaderParameters, globalShaderParameters, pixelShaderVectorMapping);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    currentUsage = ParameterUsage.PS_IntegerExtern;
                    mappings = MapExternParameters(currentUsage, pixelShaderParameters, globalShaderParameters, pixelShaderIntegerMapping);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    // vs extern

                    currentUsage = ParameterUsage.VS_RealExtern;
                    mappings = MapExternParameters(currentUsage, vertexShaderParameters, globalShaderParameters, vertexShaderVectorMapping);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);

                    currentUsage = ParameterUsage.VS_IntegerExtern;
                    mappings = MapExternParameters(currentUsage, vertexShaderParameters, globalShaderParameters, vertexShaderIntegerMapping);
                    AddMapping(currentUsage, rmt2, parameterTable, mappings);
                }
            }

            return rmt2;
        }

        public static void GenerateShaderTemplate(GameCache cache, Stream stream, string shaderType, byte[] options, RenderMethodDefinition rmdf)
        {
            string rmt2Name = $"shaders\\{shaderType}_templates\\_{string.Join("_", options)}";

            // Collect dependent render methods, store arguments

            List<SDependentRenderMethodData> dependentRenderMethods = new List<SDependentRenderMethodData>();

            if (cache.TagCache.TryGetTag(rmt2Name + ".rmt2", out var rmt2Tag))
            {
                var origRmt2 = cache.Deserialize<RenderMethodTemplate>(stream, rmt2Tag);
                var dependents = (cache as GameCacheHaloOnlineBase).TagCacheGenHO.NonNull().Where(t => ((Cache.HaloOnline.CachedTagHaloOnline)t).Dependencies.Contains(rmt2Tag.Index));

                foreach (var dependent in dependents)
                {
                    object definition = null;

                    if (dependent.IsInGroup("rm  "))
                    {
                        definition = cache.Deserialize(stream, dependent);
                    }
                    else
                    {
                        switch (dependent.Group.Tag.ToString())
                        {
                            case "prt3":
                                var prt3 = cache.Deserialize<Particle>(stream, dependent);
                                definition = prt3.RenderMethod;
                                break;
                            case "decs":
                                var decs = cache.Deserialize<DecalSystem>(stream, dependent);
                                for (int i = 0; i < decs.Decal.Count; i++)
                                    if (decs.Decal[i].RenderMethod.ShaderProperties[0].Template.Name == rmt2Name)
                                        SDependentRenderMethodData.AddDependant(dependentRenderMethods, cache, dependent, decs.Decal[i].RenderMethod, origRmt2, i);
                                continue;
                            case "beam":
                                var beam = cache.Deserialize<BeamSystem>(stream, dependent);
                                for (int i = 0; i < beam.Beams.Count; i++)
                                    if (beam.Beams[i].RenderMethod.ShaderProperties[0].Template.Name == rmt2Name)
                                        SDependentRenderMethodData.AddDependant(dependentRenderMethods, cache, dependent, beam.Beams[i].RenderMethod, origRmt2, i);
                                continue;
                            case "ltvl":
                                var ltvl = cache.Deserialize<LightVolumeSystem>(stream, dependent);
                                for (int i = 0; i < ltvl.LightVolumes.Count; i++)
                                    if (ltvl.LightVolumes[i].RenderMethod.ShaderProperties[0].Template.Name == rmt2Name)
                                        SDependentRenderMethodData.AddDependant(dependentRenderMethods, cache, dependent, ltvl.LightVolumes[i].RenderMethod, origRmt2, i);
                                continue;
                            case "cntl":
                                var cntl = cache.Deserialize<ContrailSystem>(stream, dependent);
                                for (int i = 0; i < cntl.Contrails.Count; i++)
                                    if (cntl.Contrails[i].RenderMethod.ShaderProperties[0].Template.Name == rmt2Name)
                                        SDependentRenderMethodData.AddDependant(dependentRenderMethods, cache, dependent, cntl.Contrails[i].RenderMethod, origRmt2, i);
                                continue;
                        }
                    }

                    SDependentRenderMethodData.AddDependant(dependentRenderMethods, cache, dependent, (RenderMethod)definition, origRmt2);
                }
            }

            // Generate template

            var generator = GetLegacyShaderGenerator(shaderType, options, true);

            var glps = cache.Deserialize<GlobalPixelShader>(stream, rmdf.GlobalPixelShader);
            var glvs = cache.Deserialize<GlobalVertexShader>(stream, rmdf.GlobalVertexShader);

            var rmt2 = GenerateRenderMethodTemplate(cache, stream, rmdf, glps, glvs, generator, rmt2Name, out _, out _);

            if (rmt2Tag == null)
                rmt2Tag = cache.TagCache.AllocateTag<RenderMethodTemplate>(rmt2Name);

            cache.Serialize(stream, rmt2Tag, rmt2);
            cache.SaveStrings();
            (cache as GameCacheHaloOnlineBase).SaveTagNames();

            Console.WriteLine($"Generated shader template \"{rmt2Name}\"");

            // Fixup render method parameters

            foreach (var dependent in dependentRenderMethods)
            {
                var postprocess = (dependent.Definition as RenderMethod).ShaderProperties[0];

                List<TextureConstant> reorderedTextureConstants = new List<TextureConstant>();
                foreach (var textureName in rmt2.TextureParameterNames)
                {
                    int origIndex = dependent.OrderedTextures.IndexOf(cache.StringTable.GetString(textureName.Name));
                    if (origIndex != -1)
                        reorderedTextureConstants.Add(postprocess.TextureConstants[origIndex]);
                    else
                        reorderedTextureConstants.Add(new TextureConstant());
                }
                postprocess.TextureConstants = reorderedTextureConstants;

                List<RealConstant> reorderedRealConstants = new List<RealConstant>();
                foreach (var realName in rmt2.RealParameterNames)
                {
                    int origIndex = dependent.OrderedRealParameters.IndexOf(cache.StringTable.GetString(realName.Name));
                    if (origIndex != -1)
                        reorderedRealConstants.Add(postprocess.RealConstants[origIndex]);
                    else
                        reorderedRealConstants.Add(new RealConstant());
                }
                postprocess.RealConstants = reorderedRealConstants;

                List<uint> reorderedIntConstants = new List<uint>();
                foreach (var intName in rmt2.IntegerParameterNames)
                {
                    int origIndex = dependent.OrderedIntParameters.IndexOf(cache.StringTable.GetString(intName.Name));
                    if (origIndex != -1)
                        reorderedIntConstants.Add(postprocess.IntegerConstants[origIndex]);
                    else
                        reorderedIntConstants.Add(new uint());
                }
                postprocess.IntegerConstants = reorderedIntConstants;

                uint reorderedBoolConstants = 0;
                for (int i = 0; i < rmt2.BooleanParameterNames.Count; i++)
                {
                    int origIndex = dependent.OrderedBoolParameters.IndexOf(cache.StringTable.GetString(rmt2.BooleanParameterNames[i].Name));
                    if (origIndex != -1)
                        reorderedBoolConstants |= ((postprocess.BooleanConstants >> origIndex) & 1) == 1 ? 1u << i : 0;
                }
                postprocess.BooleanConstants = reorderedBoolConstants;

                var textureAnimatedParams = dependent.AnimatedParameters.Where(x => x.Type == ShaderFunctionHelper.ParameterType.Texture);
                var realAnimatedParams = dependent.AnimatedParameters.Where(x => x.Type == ShaderFunctionHelper.ParameterType.Real);
                var intAnimatedParams = dependent.AnimatedParameters.Where(x => x.Type == ShaderFunctionHelper.ParameterType.Int);
                var boolAnimatedParams = dependent.AnimatedParameters.Where(x => x.Type == ShaderFunctionHelper.ParameterType.Bool);

                postprocess.RoutingInfo.Clear();
                var routingInfo = postprocess.RoutingInfo;

                foreach (var pass in postprocess.Passes)
                {
                    pass.RealPixel.Integer = 0;
                    pass.RealVertex.Integer = 0;
                    pass.Texture.Integer = 0;
                }

                for (int k = 0; k < postprocess.EntryPoints.Count; k++)
                {
                    var entry = postprocess.EntryPoints[k];
                    var rmt2Entry = rmt2.EntryPoints[k];

                    for (int i = entry.Offset; i < entry.Offset + entry.Count; i++)
                    {
                        var pass = postprocess.Passes[i];
                        var rmt2Pass = rmt2.Passes[rmt2Entry.Offset + (i - entry.Offset)];

                        // Texture

                        int usageOffset = rmt2Pass.Values[(int)ParameterUsage.Texture].Offset;
                        int usageCount = rmt2Pass.Values[(int)ParameterUsage.Texture].Count;

                        pass.Texture.Offset = (ushort)routingInfo.Count;
                        for (int j = usageOffset; j < usageOffset + usageCount; j++)
                        {
                            var rmt2RoutingInfo = rmt2.RoutingInfo[j];

                            string paramName = cache.StringTable.GetString(rmt2.TextureParameterNames[rmt2RoutingInfo.SourceIndex].Name);

                            foreach (var animatedParam in textureAnimatedParams)
                            {
                                if (animatedParam.Name == paramName)
                                {
                                    var newBlock = new RenderMethodRoutingInfoBlock
                                    {
                                        SourceIndex = rmt2RoutingInfo.SourceIndex,
                                        FunctionIndex = (byte)animatedParam.FunctionIndex,
                                        RegisterIndex = (short)rmt2RoutingInfo.DestinationIndex
                                    };

                                    routingInfo.Add(newBlock);
                                    pass.Texture.Count++;
                                    break;
                                }
                            }
                        }
                        pass.Texture.Offset = pass.Texture.Count == 0 ? (ushort)0 : pass.Texture.Offset;

                        // Real PS

                        usageOffset = rmt2Pass.Values[(int)ParameterUsage.PS_Real].Offset;
                        usageCount = rmt2Pass.Values[(int)ParameterUsage.PS_Real].Count;

                        pass.RealPixel.Offset = (ushort)routingInfo.Count;
                        for (int j = usageOffset; j < usageOffset + usageCount; j++)
                        {
                            var rmt2RoutingInfo = rmt2.RoutingInfo[j];

                            string paramName = cache.StringTable.GetString(rmt2.RealParameterNames[rmt2RoutingInfo.SourceIndex].Name);

                            foreach (var animatedParam in realAnimatedParams)
                            {
                                if (animatedParam.Name == paramName)
                                {
                                    var newBlock = new RenderMethodRoutingInfoBlock
                                    {
                                        SourceIndex = rmt2RoutingInfo.SourceIndex,
                                        FunctionIndex = (byte)animatedParam.FunctionIndex,
                                        RegisterIndex = (short)rmt2RoutingInfo.DestinationIndex
                                    };

                                    routingInfo.Add(newBlock);
                                    pass.RealPixel.Count++;
                                    break;
                                }
                            }
                        }
                        pass.RealPixel.Offset = pass.RealPixel.Count == 0 ? (ushort)0 : pass.RealPixel.Offset;

                        // Real VS

                        usageOffset = rmt2Pass.Values[(int)ParameterUsage.VS_Real].Offset;
                        usageCount = rmt2Pass.Values[(int)ParameterUsage.VS_Real].Count;

                        pass.RealVertex.Offset = (ushort)routingInfo.Count;
                        for (int j = usageOffset; j < usageOffset + usageCount; j++)
                        {
                            var rmt2RoutingInfo = rmt2.RoutingInfo[j];

                            string paramName = cache.StringTable.GetString(rmt2.RealParameterNames[rmt2RoutingInfo.SourceIndex].Name);

                            foreach (var animatedParam in realAnimatedParams)
                            {
                                if (animatedParam.Name == paramName)
                                {
                                    var newBlock = new RenderMethodRoutingInfoBlock
                                    {
                                        SourceIndex = rmt2RoutingInfo.SourceIndex,
                                        FunctionIndex = (byte)animatedParam.FunctionIndex,
                                        RegisterIndex = (short)rmt2RoutingInfo.DestinationIndex
                                    };

                                    routingInfo.Add(newBlock);
                                    pass.RealVertex.Count++;
                                    break;
                                }
                            }
                        }
                        pass.RealVertex.Offset = pass.RealVertex.Count == 0 ? (ushort)0 : pass.RealVertex.Offset;
                    }
                }

                if (dependent.Tag.IsInGroup("rm  "))
                {
                    cache.Serialize(stream, dependent.Tag, dependent.Definition);
                }
                else
                {
                    switch (dependent.Tag.Group.Tag.ToString())
                    {
                        case "prt3":
                            var prt3 = cache.Deserialize<Particle>(stream, dependent.Tag);
                            prt3.RenderMethod = (RenderMethod)dependent.Definition;
                            cache.Serialize(stream, dependent.Tag, prt3);
                            break;
                        case "decs":
                            var decs = cache.Deserialize<DecalSystem>(stream, dependent.Tag);
                            decs.Decal[dependent.EffectIndex].RenderMethod = (RenderMethod)dependent.Definition;
                            cache.Serialize(stream, dependent.Tag, decs);
                            break;
                        case "beam":
                            var beam = cache.Deserialize<BeamSystem>(stream, dependent.Tag);
                            beam.Beams[dependent.EffectIndex].RenderMethod = (RenderMethod)dependent.Definition;
                            cache.Serialize(stream, dependent.Tag, beam);
                            break;
                        case "ltvl":
                            var ltvl = cache.Deserialize<LightVolumeSystem>(stream, dependent.Tag);
                            ltvl.LightVolumes[dependent.EffectIndex].RenderMethod = (RenderMethod)dependent.Definition;
                            cache.Serialize(stream, dependent.Tag, ltvl);
                            break;
                        case "cntl":
                            var cntl = cache.Deserialize<ContrailSystem>(stream, dependent.Tag);
                            cntl.Contrails[dependent.EffectIndex].RenderMethod = (RenderMethod)dependent.Definition;
                            cache.Serialize(stream, dependent.Tag, cntl);
                            break;
                    }
                }
            }

            if (dependentRenderMethods.Count > 0)
                Console.WriteLine($"Corrected {dependentRenderMethods.Count} render method{(dependentRenderMethods.Count > 1 ? "s" : "")}");
        }

        public static IShaderGenerator GetLegacyGlobalShaderGenerator(string shaderType, bool applyFixes = false)
        {
            switch (shaderType)
            {
                case "beam": return new HaloShaderGenerator.LegacyGenerator.Beam.LegacyBeamGenerator(applyFixes);
                case "black": return new HaloShaderGenerator.LegacyGenerator.Black.LegacyShaderBlackGenerator();
                case "contrail": return new HaloShaderGenerator.LegacyGenerator.Contrail.LegacyContrailGenerator(applyFixes);
                case "cortana": return new HaloShaderGenerator.LegacyGenerator.Cortana.LegacyCortanaGenerator(applyFixes);
                case "custom": return new HaloShaderGenerator.LegacyGenerator.Custom.LegacyCustomGenerator(applyFixes);
                case "decal": return new HaloShaderGenerator.LegacyGenerator.Decal.LegacyDecalGenerator(applyFixes);
                case "foliage": return new HaloShaderGenerator.LegacyGenerator.Foliage.LegacyFoliageGenerator(applyFixes);
                //case "glass": return new HaloShaderGenerator.LegacyGenerator.Glass.LegacyGlassGenerator(applyFixes); // No realistic way to add this without hlsl data
                case "halogram": return new HaloShaderGenerator.LegacyGenerator.Halogram.LegacyHalogramGenerator(applyFixes);
                case "light_volume": return new HaloShaderGenerator.LegacyGenerator.LightVolume.LegacyLightVolumeGenerator(applyFixes);
                case "particle": return new HaloShaderGenerator.LegacyGenerator.Particle.LegacyParticleGenerator(applyFixes);
                case "screen": return new HaloShaderGenerator.LegacyGenerator.Screen.LegacyScreenGenerator(applyFixes);
                case "shader": return new HaloShaderGenerator.LegacyGenerator.Shader.LegacyShaderGenerator(applyFixes);
                case "terrain": return new HaloShaderGenerator.LegacyGenerator.Terrain.LegacyTerrainGenerator(applyFixes);
                case "water": return new HaloShaderGenerator.LegacyGenerator.Water.LegacyWaterGenerator(applyFixes);
                case "zonly": return new HaloShaderGenerator.LegacyGenerator.ZOnly.LegacyZOnlyGenerator(applyFixes);
            }

            return null;
        }

        public static IShaderGenerator GetLegacyShaderGenerator(string shaderType, byte[] options, bool applyFixes = false)
        {
            switch (shaderType)
            {
                case "beam": return new HaloShaderGenerator.LegacyGenerator.Beam.LegacyBeamGenerator(options, applyFixes);
                case "black": return new HaloShaderGenerator.LegacyGenerator.Black.LegacyShaderBlackGenerator();
                case "contrail": return new HaloShaderGenerator.LegacyGenerator.Contrail.LegacyContrailGenerator(options, applyFixes);
                case "cortana": return new HaloShaderGenerator.LegacyGenerator.Cortana.LegacyCortanaGenerator(options, applyFixes);
                case "custom": return new HaloShaderGenerator.LegacyGenerator.Custom.LegacyCustomGenerator(options, applyFixes);
                case "decal": return new HaloShaderGenerator.LegacyGenerator.Decal.LegacyDecalGenerator(options, applyFixes);
                case "foliage": return new HaloShaderGenerator.LegacyGenerator.Foliage.LegacyFoliageGenerator(options, applyFixes);
                //case "glass": return new HaloShaderGenerator.LegacyGenerator.Glass.LegacyGlassGenerator(options, applyFixes); // No realistic way to add this without hlsl data
                case "halogram": return new HaloShaderGenerator.LegacyGenerator.Halogram.LegacyHalogramGenerator(options, applyFixes);
                case "light_volume": return new HaloShaderGenerator.LegacyGenerator.LightVolume.LegacyLightVolumeGenerator(options, applyFixes);
                case "particle": return new HaloShaderGenerator.LegacyGenerator.Particle.LegacyParticleGenerator(options, applyFixes);
                case "screen": return new HaloShaderGenerator.LegacyGenerator.Screen.LegacyScreenGenerator(options, applyFixes);
                case "shader": return new HaloShaderGenerator.LegacyGenerator.Shader.LegacyShaderGenerator(options, applyFixes);
                case "terrain": return new HaloShaderGenerator.LegacyGenerator.Terrain.LegacyTerrainGenerator(options, applyFixes);
                case "water": return new HaloShaderGenerator.LegacyGenerator.Water.LegacyWaterGenerator(options, applyFixes);
                case "zonly": return new HaloShaderGenerator.LegacyGenerator.ZOnly.LegacyZOnlyGenerator(options, applyFixes);
            }

            return null;
        }
    }
}