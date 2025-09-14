using HaloShaderGenerator;
using HaloShaderGenerator.Generator;
using HaloShaderGenerator.Globals;
using HaloShaderGenerator.Shader;
using HaloShaderGenerator.TemplateGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Cache.Eldorado;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.Tags.Definitions;

namespace TagTool.Shaders.ShaderGenerator
{
    public class ShaderGenerator
    {
        public static IShaderGenerator GetGlobalShaderGenerator(HaloShaderGenerator.Globals.ShaderType shaderType)
        {
            switch (shaderType)
            {
            	// TODO: Update Shader Generator
                case HaloShaderGenerator.Globals.ShaderType.Beam:            return new HaloShaderGenerator.Beam.BeamGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Black:           return new HaloShaderGenerator.Black.BlackGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Contrail:        return new HaloShaderGenerator.Contrail.ContrailGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Cortana:         return new HaloShaderGenerator.Cortana.CortanaGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Custom:          return new HaloShaderGenerator.Custom.CustomGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Decal:           return new HaloShaderGenerator.Decal.DecalGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Foliage:         return new HaloShaderGenerator.Foliage.FoliageGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Fur:             return new HaloShaderGenerator.Fur.FurGenerator();
                case HaloShaderGenerator.Globals.ShaderType.FurStencil:      return new HaloShaderGenerator.FurStencil.FurStencilGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Glass:           return new HaloShaderGenerator.Glass.GlassGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Halogram:        return new HaloShaderGenerator.Halogram.HalogramGenerator();
                case HaloShaderGenerator.Globals.ShaderType.LightVolume:     return new HaloShaderGenerator.LightVolume.LightVolumeGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Mux:             return new HaloShaderGenerator.Mux.MuxGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Particle:        return new HaloShaderGenerator.Particle.ParticleGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Screen:          return new HaloShaderGenerator.Screen.ScreenGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Shader:          return new HaloShaderGenerator.Shader.ShaderGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Terrain:         return new HaloShaderGenerator.Terrain.TerrainGenerator();
                case HaloShaderGenerator.Globals.ShaderType.Water:           return new HaloShaderGenerator.Water.WaterGenerator();
                case HaloShaderGenerator.Globals.ShaderType.ZOnly:           return new HaloShaderGenerator.ZOnly.ZOnlyGenerator();
            }

            Log.Error($"Could not retrieve shared shader generator for \"{shaderType}\"");
            return null;
        }
    }

    public partial class ShaderGeneratorNew
    {
        [Flags]
        private enum ParameterTypeFlags
        {
            Vector = 0,
            Integer = 1 << 0,
            Boolean = 1 << 1,
            Sampler = 1 << 2
        }

        private static StringId AddStringSafe(GameCache cache, string str)
        {
            var sTable = (StringTableEldorado)cache.StringTable;

            if (str == "")
                return StringId.Invalid;
            var stringId = sTable.GetStringId(str);
            if (stringId == StringId.Invalid)
                stringId = sTable.AddStringBlocking(str);
            return stringId;
        }

        public static bool AutoMacroIsParameter(string categoryName, HaloShaderGenerator.Globals.ShaderType shaderType) 
        {
            switch (shaderType) 
            {
                // TODO: Investigate whether or not this causes issues with reach decals
                case HaloShaderGenerator.Globals.ShaderType.Decal:
                    if (categoryName == "blend_mode" || categoryName == "parallax" || categoryName == "interier")
                        return true;
                    break;
            }

            return false;
        }

        private static List<OptionInfo> BuildOptionInfo(GameCache cache, RenderMethodDefinition rmdf, 
            byte[] options, HaloShaderGenerator.Globals.ShaderType shaderType, bool ps = true)
        {
            List<OptionInfo> optionInfo = new List<OptionInfo>();

            if (rmdf.Flags.HasFlag(RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros))
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (options[i] >= rmdf.Categories[i].ShaderOptions.Count)
                        continue;

                    string category = cache.StringTable.GetString(rmdf.Categories[i].Name);
                    string option = cache.StringTable.GetString(rmdf.Categories[i].ShaderOptions[options[i]].Name);

                    if (ps)
                    {
                        // TODO: Confirm that this actually is correct
                        if (AutoMacroIsParameter(category, shaderType))
                        {
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

        private static ShaderConstantTable BuildConstantTable(GameCache cache, ShaderGeneratorResult result, ShaderType shaderType)
        {
            List<ShaderParameter> parameters = new List<ShaderParameter>();

            foreach (var register in result.Registers)
            {
                ShaderParameter shaderParameter = new ShaderParameter
                {
                    RegisterIndex = (ushort)register.Register,
                    RegisterCount = (byte)register.Size
                };

                // TODO: Update Shader Generator so I can update this switch :/
                switch (register.RegisterType)
                {
                    case ShaderGeneratorResult.ShaderRegister.ShaderRegisterType.Boolean:
                        shaderParameter.RegisterType = ShaderParameter.RType.Boolean;
                        break;
                    case ShaderGeneratorResult.ShaderRegister.ShaderRegisterType.Integer:
                        shaderParameter.RegisterType = ShaderParameter.RType.Integer;
                        break;
                    case ShaderGeneratorResult.ShaderRegister.ShaderRegisterType.Sampler:
                        shaderParameter.RegisterType = ShaderParameter.RType.Sampler;
                        break;
                    case ShaderGeneratorResult.ShaderRegister.ShaderRegisterType.Vector:
                        shaderParameter.RegisterType = ShaderParameter.RType.Vector;
                        break;
                }

                shaderParameter.ParameterName = AddStringSafe(cache, register.Name);

                parameters.Add(shaderParameter);
            }

            return new ShaderConstantTable
            {
                Constants = parameters,
                ShaderType = shaderType
            };
        }

        private static int GetConstantIndex(GameCache cache, ShaderConstantTable constantTable, string parameterName, ShaderParameter.RType type)
        {
            for (int i = 0; i < constantTable.Constants.Count; i++)
            {
                string constantName = cache.StringTable.GetString(constantTable.Constants[i].ParameterName);

                if (type == ShaderParameter.RType.Vector)
                {
                    if (constantName.EndsWith("_xform"))
                        constantName = constantName.Remove(constantName.Length - 6, 6);
                    //else if (constantName.StartsWith("category_"))
                    //    constantName = constantName.Remove(0, 9);
                }

                if (type == constantTable.Constants[i].RegisterType && constantName == parameterName)
                    return i;
            }

            return -1;
        }

        private static ShaderParameter.RType ParameterTypeToRegisterType(RenderMethodOption.ParameterBlock.OptionDataType type)
        {
            switch (type)
            {
                case RenderMethodOption.ParameterBlock.OptionDataType.Bitmap:
                    return ShaderParameter.RType.Sampler;
                case RenderMethodOption.ParameterBlock.OptionDataType.Real:
                case RenderMethodOption.ParameterBlock.OptionDataType.Color:
                case RenderMethodOption.ParameterBlock.OptionDataType.ArgbColor:
                    return ShaderParameter.RType.Vector;
                case RenderMethodOption.ParameterBlock.OptionDataType.Bool:
                    return ShaderParameter.RType.Boolean;
                case RenderMethodOption.ParameterBlock.OptionDataType.Int:
                    return ShaderParameter.RType.Integer;
            }
            return ShaderParameter.RType.Sampler;
        }

        private static List<RenderMethodTemplate.RoutingInfoBlock> GenerateRoutingInfo(GameCache cache,
            List<RenderMethodOption.ParameterBlock> rmopParameters,
            List<RenderMethodTemplate.ShaderArgument> rmt2ParameterList,
            ShaderConstantTable constantTable, 
            ShaderParameter.RType type,
            bool is_extern,
            bool vsSampler)
        {
            List<RenderMethodTemplate.RoutingInfoBlock> routingInfo = new List<RenderMethodTemplate.RoutingInfoBlock>();

            foreach (var parameter in rmopParameters.Where(x => (x.RenderMethodExtern == RenderMethodExtern.none) == !is_extern))
            {
                string parameterName = cache.StringTable.GetString(parameter.Name);

                int index = GetConstantIndex(cache, constantTable, parameterName, type);

                if (index != -1)
                {
                    int sourceIndex;
                    if (is_extern)
                    {
                        sourceIndex = (int)parameter.RenderMethodExtern;
                    }
                    else
                    {
                        sourceIndex = rmt2ParameterList.FindIndex(x => cache.StringTable.GetString(x.Name) == parameterName);

                        if (sourceIndex == -1)
                        {
                            throw new Exception("shits broke af");
                        }
                    }

                    routingInfo.Add(new RenderMethodTemplate.RoutingInfoBlock
                    {
                        DestinationIndex = constantTable.Constants[index].RegisterIndex,
                        SourceIndex = (byte)sourceIndex,
                        Flags = (byte)(vsSampler ? 1 : 0)
                    });
                }
                else if (ParameterTypeToRegisterType(parameter.Type) == type)
                {
                    //Log.Warning($"no binding for {constantTable.ShaderType} {(is_extern ? "extern " : "")}{type} \"{parameterName}\"");
                }
            }

            return routingInfo;
        }

        private static List<RenderMethodTemplate.RoutingInfoBlock> GenerateCategoryRoutingInfo(GameCache cache,
            RenderMethodDefinition rmdf,
            List<RenderMethodTemplate.ShaderArgument> rmt2ParameterList,
            ShaderConstantTable constantTable)
        {
            List<RenderMethodTemplate.RoutingInfoBlock> routingInfo = new List<RenderMethodTemplate.RoutingInfoBlock>();

            if (rmdf.Flags.HasFlag(RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros))
            {
                foreach (var category in rmdf.Categories)
                {
                    string categoryName = cache.StringTable.GetString(category.Name);

                    int index = GetConstantIndex(cache, constantTable, "category_" + categoryName, ShaderParameter.RType.Vector);

                    if (index != -1)
                    {
                        int sourceIndex = rmt2ParameterList.FindIndex(x => cache.StringTable.GetString(x.Name) == categoryName);

                        if (sourceIndex == -1)
                            throw new Exception($"\"categoryName\" category binding broken");

                        routingInfo.Add(new RenderMethodTemplate.RoutingInfoBlock
                        {
                            DestinationIndex = constantTable.Constants[index].RegisterIndex,
                            SourceIndex = (byte)sourceIndex,
                            Flags = 0
                        });
                    }
                }
            }

            return routingInfo;
        }

        private static void GetPassConstantTables(int entryPointIndex,
            List<byte> options,
            RenderMethodDefinition rmdf,
            PixelShader pixl,
            /*VertexShader vtsh,*/
            GlobalPixelShader glps,
            GlobalVertexShader glvs,
            out ShaderConstantTable psConstantTable, 
            out ShaderConstantTable vsConstantTable)
        {
            psConstantTable = new ShaderConstantTable { Constants = new List<ShaderParameter>(), ShaderType = ShaderType.PixelShader };

            if (entryPointIndex < glps.EntryPoints.Count && 
                (glps.EntryPoints[entryPointIndex].DefaultCompiledShaderIndex != -1 ||
                glps.EntryPoints[entryPointIndex].CategoryDependency.Count > 0))
            {
                if (glps.EntryPoints[entryPointIndex].CategoryDependency.Count > 0)
                {
                    int categoryIndex = glps.EntryPoints[entryPointIndex].CategoryDependency[0].DefinitionCategoryIndex;
                    if (categoryIndex >= 0 && categoryIndex < options.Count)
                    {
                        int shaderIndex = glps.EntryPoints[entryPointIndex].CategoryDependency[0].OptionDependency[options[categoryIndex]].CompiledShaderIndex;
                        psConstantTable = glps.Shaders[shaderIndex].PCConstantTable;
                    }
                }
                else
                {
                    psConstantTable = glps.Shaders[glps.EntryPoints[entryPointIndex].DefaultCompiledShaderIndex].PCConstantTable;
                }
            }
            else if (entryPointIndex < pixl.EntryPointShaders.Count)
            {
                if (pixl.EntryPointShaders[entryPointIndex].Count > 0)
                {
                    psConstantTable = pixl.Shaders[pixl.EntryPointShaders[entryPointIndex].Offset].PCConstantTable;
                }
            }

            int vertexIndex = (int)rmdf.VertexTypes[0].VertexType;
            int vsShaderIndex = glvs.VertexTypes[vertexIndex].EntryPoints[entryPointIndex].ShaderIndex;
            vsConstantTable = glvs.Shaders[vsShaderIndex].PCConstantTable;
        }

        private static void AccumRuntimeParameterType(GameCache cache, Dictionary<string, ParameterTypeFlags> parameterTypes, ShaderParameter constant)
        {
            string name = cache.StringTable.GetString(constant.ParameterName);

            if (parameterTypes.ContainsKey(name))
                parameterTypes[name] |= (ParameterTypeFlags)Enum.Parse(typeof(ParameterTypeFlags), constant.RegisterType.ToString());
            else
                parameterTypes[name] = (ParameterTypeFlags)Enum.Parse(typeof(ParameterTypeFlags), constant.RegisterType.ToString());
        }

        public static List<RenderMethodOption.ParameterBlock> GatherParameters(GameCache cache, Stream stream, RenderMethodDefinition rmdf, List<byte> options, bool includeGlobal = true)
        {
            List<RenderMethodOption.ParameterBlock> allRmopParameters = new List<RenderMethodOption.ParameterBlock>();

            if (includeGlobal)
            {
                if (rmdf.GlobalOptions != null)
                {
                    var globalRmop = cache.Deserialize<RenderMethodOption>(stream, rmdf.GlobalOptions);
                    allRmopParameters.AddRange(globalRmop.Parameters);
                }
            }

            for (int i = 0; i < rmdf.Categories.Count; i++)
            {
                if (rmdf.Categories[i].ShaderOptions.Count == 0)
                    continue;

                var option = rmdf.Categories[i].ShaderOptions[i < options.Count ? options[i] : 0];

                if (option.Option != null)
                {
                    var rmop = cache.Deserialize<RenderMethodOption>(stream, option.Option);

                    foreach (var parameter in rmop.Parameters)
                    {
                        if (allRmopParameters.Any(x => x.Name == parameter.Name)) // prevent duplicates
                            continue;

                        allRmopParameters.Add(parameter);
                    }
                }
            }

            return allRmopParameters;
        }

        public static List<RenderMethodOption.ParameterBlock> GatherParametersAsync(Dictionary<string, RenderMethodOption> renderMethodOptions, RenderMethodDefinition rmdf, List<byte> options, bool includeGlobal = true)
        {
            List<RenderMethodOption.ParameterBlock> allRmopParameters = new List<RenderMethodOption.ParameterBlock>();

            if (includeGlobal)
            {
                if (rmdf.GlobalOptions != null)
                {
                    var globalRmop = renderMethodOptions[rmdf.GlobalOptions.Name];
                    allRmopParameters.AddRange(globalRmop.Parameters);
                }
            }

            for (int i = 0; i < rmdf.Categories.Count; i++)
            {
                if (rmdf.Categories[i].ShaderOptions.Count == 0)
                    continue;

                var option = rmdf.Categories[i].ShaderOptions[i < options.Count ? options[i] : 0];

                if (option.Option != null)
                {
                    var rmop = renderMethodOptions[option.Option.Name];

                    foreach (var parameter in rmop.Parameters)
                    {
                        if (allRmopParameters.Any(x => x.Name == parameter.Name)) // prevent duplicates
                            continue;

                        allRmopParameters.Add(parameter);
                    }
                }
            }

            return allRmopParameters;
        }

        /// <summary>
        /// Non async
        /// </summary>
        public static RenderMethodTemplate GenerateTemplateSafe(GameCache cache, 
            Stream stream, 
            RenderMethodDefinition rmdf, 
            string shaderName,
            out PixelShader pixl,
            out VertexShader vtsh)
        {
            var glps = cache.Deserialize<GlobalPixelShader>(stream, rmdf.GlobalPixelShader);
            var glvs = cache.Deserialize<GlobalVertexShader>(stream, rmdf.GlobalVertexShader);

            // get options in numeric array
            List<byte> options = new List<byte>();
            foreach (var option in shaderName.Split('\\')[2].Remove(0, 1).Split('_'))
                options.Add(byte.Parse(option));

            var allRmopParameters = GatherParameters(cache, stream, rmdf, options);

            var rmt2 = GenerateTemplate(cache, rmdf, glvs, glps, allRmopParameters, shaderName, out pixl, out vtsh);

            if (!cache.TagCache.TryGetTag(shaderName + ".pixl", out rmt2.PixelShader))
                rmt2.PixelShader = cache.TagCache.AllocateTag<PixelShader>(shaderName);
            if (!cache.TagCache.TryGetTag(shaderName + ".vtsh", out rmt2.VertexShader))
                rmt2.VertexShader = cache.TagCache.AllocateTag<VertexShader>(shaderName);

            cache.Serialize(stream, rmt2.PixelShader, pixl);
            cache.Serialize(stream, rmt2.VertexShader, vtsh);

            return rmt2;
        }

        /// <summary>
        /// Async compatible -- WARNING: no serialization is to occur within the scope of this function. pixl and vtsh must be serialized after this function.
        /// </summary>
        public static RenderMethodTemplate GenerateTemplate(GameCache cache,
            RenderMethodDefinition rmdf, 
            GlobalVertexShader glvs,
            GlobalPixelShader glps,
            List<RenderMethodOption.ParameterBlock> allRmopParameters,
            string shaderName, 
            out PixelShader pixl, 
            out VertexShader vtsh)
        {
            var rmt2 = new RenderMethodTemplate
            {
                RoutingInfo = new List<RenderMethodTemplate.RoutingInfoBlock>(),
                Passes = new List<RenderMethodTemplate.PassBlock>(),
                EntryPoints = new List<TagBlockIndex>(),
                RealParameterNames = new List<RenderMethodTemplate.ShaderArgument>(),
                IntegerParameterNames = new List<RenderMethodTemplate.ShaderArgument>(),
                BooleanParameterNames = new List<RenderMethodTemplate.ShaderArgument>(),
                TextureParameterNames = new List<RenderMethodTemplate.ShaderArgument>(),
                OtherPlatforms = new List<RenderMethodTemplate.RenderMethodTemplatePlatformBlock>()
            };

            // get options in numeric array
            List<byte> options = new List<byte>();
            foreach (var option in shaderName.Split('\\')[2].Remove(0, 1).Split('_'))
                options.Add(byte.Parse(option));
            string type = shaderName.Split('\\')[1].Replace("_templates", "").Replace("_", "");

            // generate the shaders

            pixl = GeneratePixelShader(cache,
                rmdf,
                (HaloShaderGenerator.Globals.ShaderType)Enum.Parse(typeof(HaloShaderGenerator.Globals.ShaderType), type, true),
                options.ToArray());

            vtsh = new VertexShader();

            // accum parameters

            Dictionary<string, ParameterTypeFlags> parameterTypes = new Dictionary<string, ParameterTypeFlags>(); // <name, types>

            foreach (var shader in pixl.Shaders)
                foreach (var constant in shader.PCConstantTable.Constants)
                    AccumRuntimeParameterType(cache, parameterTypes, constant);
            //foreach (var shader in vtsh.Shaders)
            //    foreach (var constant in shader.PCConstantTable.Constants)
            //        AccumRuntimeParameterType(cache, parameterTypes, constant);
            foreach (var shader in glps.Shaders)
                foreach (var constant in shader.PCConstantTable.Constants)
                    AccumRuntimeParameterType(cache, parameterTypes, constant);
            foreach (var shader in glvs.Shaders)
                foreach (var constant in shader.PCConstantTable.Constants)
                    AccumRuntimeParameterType(cache, parameterTypes, constant);

            foreach (var parameter in allRmopParameters)
            {
                string name = cache.StringTable.GetString(parameter.Name);
                if (parameter.RenderMethodExtern == RenderMethodExtern.none)
                {
                    switch (parameter.Type)
                    {
                        case RenderMethodOption.ParameterBlock.OptionDataType.Real:
                        case RenderMethodOption.ParameterBlock.OptionDataType.Color:
                        case RenderMethodOption.ParameterBlock.OptionDataType.ArgbColor:
                            rmt2.RealParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = parameter.Name });
                            break;
                        case RenderMethodOption.ParameterBlock.OptionDataType.Int:
                            rmt2.IntegerParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = parameter.Name });
                            if (parameterTypes.ContainsKey(name) && parameterTypes[name].HasFlag(ParameterTypeFlags.Vector))
                                rmt2.RealParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = parameter.Name });
                            break;
                        case RenderMethodOption.ParameterBlock.OptionDataType.Bool:
                            rmt2.BooleanParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = parameter.Name });
                            if (parameterTypes.ContainsKey(name) && parameterTypes[name].HasFlag(ParameterTypeFlags.Vector))
                                rmt2.RealParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = parameter.Name });
                            break;
                        case RenderMethodOption.ParameterBlock.OptionDataType.Bitmap:
                            rmt2.TextureParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = parameter.Name });
                            if (parameterTypes.ContainsKey(name + "_xform")/* && parameterTypes[name + "_xform"].HasFlag(ParameterTypeFlags.Vector)*/)
                                rmt2.RealParameterNames.Add(new RenderMethodTemplate.ShaderArgument { Name = parameter.Name });
                            break;
                    }
                }
            }

            // hax for category, these really should be ordered in
            foreach (var categoryParameter in parameterTypes.Where(x => x.Key.StartsWith("category_")))
            {
                rmt2.RealParameterNames.Add(new RenderMethodTemplate.ShaderArgument { 
                    Name = cache.StringTable.GetStringId(categoryParameter.Key.Remove(0, 9)) 
                });
            }

            for (int i = 0; i < Enum.GetValues(typeof(EntryPoint)).Length; i++)
                rmt2.EntryPoints.Add(new TagBlockIndex());

            foreach (var entryBlock in rmdf.EntryPoints)
            {
                int i = (int)entryBlock.EntryPoint;

                rmt2.EntryPoints[i].Offset = (ushort)rmt2.Passes.Count;
                rmt2.EntryPoints[i].Count = 1;

                GetPassConstantTables(i, options, rmdf, pixl, glps, glvs, 
                    out var psConstantTable, out var vsConstantTable);

                RenderMethodTemplate.PassBlock pass = new RenderMethodTemplate.PassBlock();

                for (int j = 0; j < (int)ParameterUsage.Count; j++) // init
                    pass.Values[j] = new TagBlockIndex();

                // texture extern ps/vs //////////////////////////

                pass.Values[(int)ParameterUsage.TextureExtern].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    null,
                    psConstantTable,
                    ShaderParameter.RType.Sampler,
                    true,
                    false));
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    null,
                    vsConstantTable,
                    ShaderParameter.RType.Sampler,
                    true,
                    false));
                pass.Values[(int)ParameterUsage.TextureExtern].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.TextureExtern].Offset);

                // texture ps/vs ////////////////////////////

                pass.Values[(int)ParameterUsage.Texture].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.TextureParameterNames,
                    vsConstantTable,
                    ShaderParameter.RType.Sampler,
                    false,
                    true));
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.TextureParameterNames,
                    psConstantTable,
                    ShaderParameter.RType.Sampler,
                    false,
                    false));
                pass.Values[(int)ParameterUsage.Texture].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.Texture].Offset);

                // ps bindings ///////////////////////////////

                pass.Values[(int)ParameterUsage.PS_Real].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.RealParameterNames,
                    psConstantTable,
                    ShaderParameter.RType.Vector,
                    false,
                    false));
                rmt2.RoutingInfo.AddRange(GenerateCategoryRoutingInfo(cache,
                    rmdf,
                    rmt2.RealParameterNames,
                    psConstantTable));
                pass.Values[(int)ParameterUsage.PS_Real].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.PS_Real].Offset);
                pass.Values[(int)ParameterUsage.PS_Integer].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.IntegerParameterNames,
                    psConstantTable,
                    ShaderParameter.RType.Integer,
                    false,
                    false));
                pass.Values[(int)ParameterUsage.PS_Integer].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.PS_Integer].Offset);
                pass.Values[(int)ParameterUsage.PS_Boolean].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.BooleanParameterNames,
                    psConstantTable,
                    ShaderParameter.RType.Boolean,
                    false,
                    false));
                pass.Values[(int)ParameterUsage.PS_Boolean].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.PS_Boolean].Offset);

                // ps extern bindings /////////////////////////////////

                pass.Values[(int)ParameterUsage.PS_RealExtern].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    null,
                    psConstantTable,
                    ShaderParameter.RType.Vector,
                    true,
                    false));
                pass.Values[(int)ParameterUsage.PS_RealExtern].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.PS_RealExtern].Offset);
                pass.Values[(int)ParameterUsage.PS_IntegerExtern].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    null,
                    psConstantTable,
                    ShaderParameter.RType.Integer,
                    true,
                    false));
                pass.Values[(int)ParameterUsage.PS_IntegerExtern].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.PS_IntegerExtern].Offset);

                // vs bindings /////////////////////////////////

                pass.Values[(int)ParameterUsage.VS_Real].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.RealParameterNames,
                    vsConstantTable,
                    ShaderParameter.RType.Vector,
                    false,
                    false));
                rmt2.RoutingInfo.AddRange(GenerateCategoryRoutingInfo(cache,
                    rmdf,
                    rmt2.RealParameterNames,
                    vsConstantTable));
                pass.Values[(int)ParameterUsage.VS_Real].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.VS_Real].Offset);
                pass.Values[(int)ParameterUsage.VS_Integer].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.IntegerParameterNames,
                    vsConstantTable,
                    ShaderParameter.RType.Integer,
                    false,
                    false));
                pass.Values[(int)ParameterUsage.VS_Integer].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.VS_Integer].Offset);
                pass.Values[(int)ParameterUsage.VS_Boolean].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    rmt2.BooleanParameterNames,
                    vsConstantTable,
                    ShaderParameter.RType.Boolean,
                    false,
                    false));
                pass.Values[(int)ParameterUsage.VS_Boolean].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.VS_Boolean].Offset);

                // vs extern bindings
                pass.Values[(int)ParameterUsage.VS_RealExtern].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    null,
                    vsConstantTable,
                    ShaderParameter.RType.Vector,
                    true,
                    false));
                pass.Values[(int)ParameterUsage.VS_RealExtern].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.VS_RealExtern].Offset);
                pass.Values[(int)ParameterUsage.VS_IntegerExtern].Offset = (ushort)rmt2.RoutingInfo.Count;
                rmt2.RoutingInfo.AddRange(GenerateRoutingInfo(cache,
                    allRmopParameters,
                    null,
                    vsConstantTable,
                    ShaderParameter.RType.Integer,
                    true,
                    false));
                pass.Values[(int)ParameterUsage.VS_IntegerExtern].Count = (ushort)(rmt2.RoutingInfo.Count - pass.Values[(int)ParameterUsage.VS_IntegerExtern].Offset);

                // clean
                for (int j = 0; j < (int)ParameterUsage.Count; j++)
                    if (pass.Values[j].Count == 0)
                        pass.Values[j].Offset = 0;

                rmt2.Passes.Add(pass);
                rmt2.ValidEntryPoints |= (EntryPointBitMask)(1 << i);
            }


            return rmt2;
        }

        public static PixelShader GeneratePixelShader(GameCache cache, RenderMethodDefinition rmdf, HaloShaderGenerator.Globals.ShaderType shaderType, byte[] options)
        {
            PixelShader pixl = new PixelShader { EntryPointShaders = new List<ShortOffsetCountBlock>(), Shaders = new List<PixelShaderBlock>() };

            Dictionary<Task<ShaderGeneratorResult>, int> tasks = new Dictionary<Task<ShaderGeneratorResult>, int>(); // <task, entry point>

            TemplateGenerator generator = new TemplateGenerator();
            List<OptionInfo> optionInfo = BuildOptionInfo(cache, rmdf, options, shaderType);

            for (int i = 0; i < Enum.GetValues(typeof(EntryPoint)).Length; i++)
                pixl.EntryPointShaders.Add(new ShortOffsetCountBlock());

            foreach (var entry in rmdf.EntryPoints)
            {
                if (!entry.Passes[0].Flags.HasFlag(RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.HasSharedPixelShader))
                { 
                    ShaderStage entryPoint;

                    if (entry.EntryPoint == EntryPoint_32.Water_Tessellation)
                        entryPoint = ShaderStage.Water_Tessellation;
                    else
                        entryPoint = (ShaderStage)Enum.Parse(typeof(ShaderStage), entry.EntryPoint.ToString());

                    Task<ShaderGeneratorResult> generatorTask = Task.Run(() => { return generator.GeneratePixelShader(shaderType, entryPoint, optionInfo, true); });
                    tasks.Add(generatorTask, (int)entryPoint);
                }
            }

            Task.WaitAll(tasks.Keys.ToArray());

            foreach (var task in tasks)
            {
                pixl.EntryPointShaders[task.Value].Count = 1;
                pixl.EntryPointShaders[task.Value].Offset = (byte)pixl.Shaders.Count;

                var pixelShaderBlock = new PixelShaderBlock
                {
                    PCShaderBytecode = task.Key.Result.Bytecode,
                    PCConstantTable = BuildConstantTable(cache, task.Key.Result, ShaderType.PixelShader)
                };

                pixl.Shaders.Add(pixelShaderBlock);
            }
            return pixl;
        }

        private static List<byte> ApplyGlpsOptionHacks(List<byte> fakeOptions, GameCache cache, RenderMethodDefinition rmdf, HaloShaderGenerator.Globals.ShaderType shaderType)
        {
            // force foliage albedo to 'simple' for glps - we just want a basic sample
            if (shaderType == HaloShaderGenerator.Globals.ShaderType.Foliage)
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

        public static GlobalPixelShader GenerateSharedPixelShaders(GameCache cache, RenderMethodDefinition rmdf, HaloShaderGenerator.Globals.ShaderType shaderType, bool applyFixes)
        {
            GlobalPixelShader glps = new GlobalPixelShader { EntryPoints = new List<GlobalPixelShader.EntryPointBlock>(), Shaders = new List<PixelShaderBlock>() };
            for (int i = 0; i < Enum.GetValues(typeof(EntryPoint)).Length; i++)
                glps.EntryPoints.Add(new GlobalPixelShader.EntryPointBlock { DefaultCompiledShaderIndex = -1 });

            TemplateGenerator generator = new TemplateGenerator();

            foreach (var entryPoint in rmdf.EntryPoints)
            {
                if (entryPoint.Passes[0].Flags.HasFlag(RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.HasSharedPixelShader))
                {
                    ShaderStage entry = (ShaderStage)Enum.Parse(typeof(ShaderStage), entryPoint.EntryPoint.ToString());

                    if (entryPoint.Passes[0].CategoryDependencies.Count > 0)
                    {
                        glps.EntryPoints[(int)entry].CategoryDependency = new List<GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock>();

                        foreach (var dependency in entryPoint.Passes[0].CategoryDependencies)
                        {
                            var dependencyBlock = new GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock { DefinitionCategoryIndex = dependency.Category, 
                                OptionDependency = new List<GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock.GlobalShaderOptionDependency>() };

                            for (int i = 0; i < rmdf.Categories[dependency.Category].ShaderOptions.Count; i++)
                            {
                                List<byte> fakeOptions = Enumerable.Repeat((byte)0, rmdf.Categories.Count).ToList();
                                fakeOptions[dependency.Category] = (byte)i;

                                fakeOptions = ApplyGlpsOptionHacks(fakeOptions, cache, rmdf, shaderType);

                                List<OptionInfo> optionInfo = BuildOptionInfo(cache, rmdf, fakeOptions.ToArray(), shaderType);

                                ShaderGeneratorResult generatorResult = generator.GeneratePixelShader(shaderType, entry, optionInfo, applyFixes);

                                dependencyBlock.OptionDependency.Add(new GlobalPixelShader.EntryPointBlock.CategoryDependencyBlock.GlobalShaderOptionDependency { 
                                    CompiledShaderIndex = glps.Shaders.Count });

                                var pixelShaderBlock = new PixelShaderBlock
                                {
                                    PCShaderBytecode = generatorResult.Bytecode,
                                    PCConstantTable = BuildConstantTable(cache, generatorResult, ShaderType.PixelShader)
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

                        var pixelShaderBlock = new PixelShaderBlock
                        {
                            PCShaderBytecode = generatorResult.Bytecode,
                            PCConstantTable = BuildConstantTable(cache, generatorResult, ShaderType.PixelShader)
                        };

                        glps.Shaders.Add(pixelShaderBlock);
                    }
                }
            }

            return glps;
        }

        public static GlobalVertexShader GenerateSharedVertexShaders(GameCache cache, RenderMethodDefinition rmdf, HaloShaderGenerator.Globals.ShaderType shaderType, bool applyFixes)
        {
            GlobalVertexShader glvs = new GlobalVertexShader { Shaders = new List<VertexShaderBlock>(), VertexTypes = new List<GlobalVertexShader.VertexTypeShaders>() };
            for (int i = 0; i < Enum.GetValues(typeof(VertexType)).Length; i++)
            {
                var vertexTypeBlock = new GlobalVertexShader.VertexTypeShaders { EntryPoints = new List<GlobalVertexShader.VertexTypeShaders.GlobalShaderEntryPointBlock>() };

                if (rmdf.VertexTypes.Any(x => x.VertexType == (RenderMethodDefinition.VertexBlock.VertexTypeValue)i))
                    for (int j = 0; j < Enum.GetValues(typeof(EntryPoint)).Length; j++)
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

                        Log.Warning("Vertex Option Dependencies Not Currently Supported (Skipping)");
                    }
                    else
                    {
                        List<byte> fakeOptions = Enumerable.Repeat((byte)0, rmdf.Categories.Count).ToList();
                        List<OptionInfo> optionInfo = BuildOptionInfo(cache, rmdf, fakeOptions.ToArray(), shaderType, false);

                        ShaderGeneratorResult generatorResult = generator.GenerateVertexShader(shaderType, entry, vertexType, optionInfo, applyFixes);

                        glvs.VertexTypes[(int)vertexType].EntryPoints[(int)entry].ShaderIndex = glvs.Shaders.Count;

                        var vertexShaderBlock = new VertexShaderBlock
                        {
                            PCShaderBytecode = generatorResult.Bytecode,
                            PCConstantTable = BuildConstantTable(cache, generatorResult, ShaderType.VertexShader)
                        };

                        glvs.Shaders.Add(vertexShaderBlock);
                    }
                }
            }

            return glvs;
        }

        public static void GenerateExplicitShader(GameCache cache, Stream stream, string explicitShader, bool applyFixes, out PixelShader pixl, out VertexShader vtsh)
        {
            ExplicitGenerator generator = new ExplicitGenerator();
            
            HaloShaderGenerator.Globals.ExplicitShader eExplicitShader = generator.GetExplicitIndex(explicitShader);
            
            List<ShaderStage> supportedEntries = generator.ScrapeEntryPoints(eExplicitShader);
            List<VertexType> supportedVertices = generator.ScrapeVertexTypes(eExplicitShader);

            pixl = new PixelShader { EntryPointShaders = new List<ShortOffsetCountBlock>(), Shaders = new List<PixelShaderBlock>() };
            vtsh = new VertexShader { EntryPoints = new List<VertexShader.VertexShaderEntryPoint>(), Shaders = new List<VertexShaderBlock>() };

            for (int i = 0; i < Enum.GetValues(typeof(ShaderStage)).Length; i++)
            {
                pixl.EntryPointShaders.Add(new ShortOffsetCountBlock());
                vtsh.EntryPoints.Add(new VertexShader.VertexShaderEntryPoint { SupportedVertexTypes = new List<ShortOffsetCountBlock>() });
            }
            
            foreach (var entry in supportedEntries)
            {
                // pixel shader
                ShaderGeneratorResult pixelResult = generator.GeneratePixelShader(eExplicitShader, entry, applyFixes);

                pixl.EntryPointShaders[(int)entry].Count = 1;
                pixl.EntryPointShaders[(int)entry].Offset = (byte)pixl.Shaders.Count;

                var pixelShaderBlock = new PixelShaderBlock
                {
                    PCShaderBytecode = pixelResult.Bytecode,
                    PCConstantTable = BuildConstantTable(cache, pixelResult, ShaderType.PixelShader)
                };

                pixl.Shaders.Add(pixelShaderBlock);

                // vertex shaders
                foreach (var vertex in supportedVertices)
                {
                    for (int i = 0; vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Count <= (int)vertex; i++)
                        vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Add(new ShortOffsetCountBlock());

                    ShaderGeneratorResult vertexResult = generator.GenerateVertexShader(eExplicitShader, entry, vertex, applyFixes);

                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Count = 1;
                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Offset = (byte)vtsh.Shaders.Count;

                    var vertexShaderBlock = new VertexShaderBlock
                    {
                        PCShaderBytecode = vertexResult.Bytecode,
                        PCConstantTable = BuildConstantTable(cache, vertexResult, ShaderType.VertexShader)
                    };

                    vtsh.Shaders.Add(vertexShaderBlock);
                }
            }
        }

        public static void GenerateChudShader(GameCache cache, Stream stream, string chudShader, bool applyFixes, out PixelShader pixl, out VertexShader vtsh)
        {
            //ChudShader eChudShader = (ChudShader)Enum.Parse(typeof(ChudShader), chudShader, true);

            List<ShaderStage> supportedEntries = new List<ShaderStage> { ShaderStage.Default };

            switch (chudShader)
            {
                case "chud_turbulence":
                    supportedEntries.Add(ShaderStage.Albedo);
                    supportedEntries.Add(ShaderStage.Dynamic_Light);
                    break;
                case "chud_double_gradient": // ???
                    chudShader = "chud_meter_double_gradient";
                    break;
                case "chud_radial_gradient": // ???
                    chudShader = "chud_meter_radial_gradient";
                    break;
            }

            List<VertexType> supportedVertices = new List<VertexType> { (chudShader == "chud_sensor" ? VertexType.FancyChud : VertexType.SimpleChud) };

            pixl = new PixelShader { EntryPointShaders = new List<ShortOffsetCountBlock>(), Shaders = new List<PixelShaderBlock>() };
            vtsh = new VertexShader { EntryPoints = new List<VertexShader.VertexShaderEntryPoint>(), Shaders = new List<VertexShaderBlock>() };

            for (int i = 0; i < Enum.GetValues(typeof(ShaderStage)).Length; i++)
            {
                pixl.EntryPointShaders.Add(new ShortOffsetCountBlock());
                vtsh.EntryPoints.Add(new VertexShader.VertexShaderEntryPoint { SupportedVertexTypes = new List<ShortOffsetCountBlock>() });
            }

            foreach (var entry in supportedEntries)
            {
                // pixel shader
                ShaderGeneratorResult pixelResult = GenericPixelShaderGenerator.GeneratePixelShader(chudShader, entry.ToString().ToLower(), applyFixes);

                pixl.EntryPointShaders[(int)entry].Count = 1;
                pixl.EntryPointShaders[(int)entry].Offset = (byte)pixl.Shaders.Count;

                var pixelShaderBlock = new PixelShaderBlock
                {
                    PCShaderBytecode = pixelResult.Bytecode,
                    PCConstantTable = BuildConstantTable(cache, pixelResult, ShaderType.PixelShader)
                };

                pixl.Shaders.Add(pixelShaderBlock);

                // vertex shaders
                foreach (var vertex in supportedVertices)
                {
                    for (int i = 0; vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Count <= (int)vertex; i++)
                        vtsh.EntryPoints[(int)entry].SupportedVertexTypes.Add(new ShortOffsetCountBlock());

                    ShaderGeneratorResult vertexResult = GenericVertexShaderGenerator.GenerateVertexShader(chudShader, entry.ToString().ToLower(), vertex, applyFixes);

                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Count = 1;
                    vtsh.EntryPoints[(int)entry].SupportedVertexTypes[(int)vertex].Offset = (byte)vtsh.Shaders.Count;

                    var vertexShaderBlock = new VertexShaderBlock
                    {
                        PCShaderBytecode = vertexResult.Bytecode,
                        PCConstantTable = BuildConstantTable(cache, vertexResult, ShaderType.VertexShader)
                    };

                    vtsh.Shaders.Add(vertexShaderBlock);
                }
            }
        }
    }
}
