using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Commands.Shaders;
using TagTool.Tags.Definitions;
using TagTool.Commands;
using TagTool.MtnDewIt.Shaders.ShaderGenerator;
using static TagTool.Tags.Definitions.RenderMethod.RenderMethodPostprocessBlock;
using System;
using TagTool.Shaders.ShaderFunctions;
using TagTool.Shaders;
using static TagTool.Shaders.ShaderFunctions.ShaderFunctionHelper;

namespace TagTool.MtnDewIt.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command
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
                List<AnimatedParameter> animatedParams = new List<AnimatedParameter>();

                if (renderMethod.ShaderProperties.Count != 0 ||
                    renderMethod.ShaderProperties[0].Functions.Count != 0 ||
                    renderMethod.ShaderProperties[0].EntryPoints.Count != 0 ||
                    renderMethod.ShaderProperties[0].Passes.Count != 0 ||
                    renderMethod.ShaderProperties[0].RoutingInfo.Count != 0)
                {
                    var properties = renderMethod.ShaderProperties[0];

                    uint validEntries = 0;

                    if (cache.Version < CacheVersion.HaloOnline301003)
                        validEntries = (uint)origRmt2.ValidEntryPoints;

                    if (cache.Version < CacheVersion.HaloReach)
                        validEntries = (uint)origRmt2.ValidEntryPointsHO;

                    for (int i = 0; i < properties.EntryPoints.Count; i++)
                    {
                        if ((validEntries >> i & 1) == 0)
                            continue;

                        var entry = properties.EntryPoints[i];
                        if (entry.Count == 0 || entry.Offset >= properties.Passes.Count)
                            continue;

                        for (int j = entry.Offset; j < entry.Offset + entry.Count; j++)
                        {
                            var table = properties.Passes[j];
                            if (table.Texture.Count > 0)
                            {
                                for (int k = table.Texture.Offset; k < table.Texture.Offset + table.Texture.Count; k++)
                                {
                                    var parameter = properties.RoutingInfo[k];
                                    if (parameter.FunctionIndex < properties.Functions.Count)
                                    {
                                        string name = cache.StringTable.GetString(origRmt2.TextureParameterNames[parameter.SourceIndex].Name);

                                        AnimatedParameter animatedParameter = new AnimatedParameter
                                        {
                                            Name = name,
                                            Type = ParameterType.Texture,
                                            FunctionIndex = parameter.FunctionIndex,
                                            FunctionType = properties.Functions[parameter.FunctionIndex].Type
                                        };

                                        if (!animatedParams.Contains(animatedParameter))
                                        {
                                            animatedParams.Add(animatedParameter);
                                        }
                                    }
                                }
                            }
                            if (table.RealPixel.Count > 0)
                            {
                                for (int k = table.RealPixel.Offset; k < table.RealPixel.Offset + table.RealPixel.Count; k++)
                                {
                                    var parameter = properties.RoutingInfo[k];
                                    if (parameter.FunctionIndex < properties.Functions.Count)
                                    {
                                        string name = cache.StringTable.GetString(origRmt2.RealParameterNames[parameter.SourceIndex].Name);

                                        AnimatedParameter animatedParameter = new AnimatedParameter
                                        {
                                            Name = name,
                                            Type = ParameterType.Real,
                                            FunctionIndex = parameter.FunctionIndex,
                                            FunctionType = properties.Functions[parameter.FunctionIndex].Type
                                        };

                                        if (!animatedParams.Contains(animatedParameter))
                                        {
                                            animatedParams.Add(animatedParameter);
                                        }
                                    }
                                }
                            }
                            if (table.RealVertex.Count > 0)
                            {
                                for (int k = table.RealVertex.Offset; k < table.RealVertex.Offset + table.RealVertex.Count; k++)
                                {
                                    var parameter = properties.RoutingInfo[k];
                                    if (parameter.FunctionIndex < properties.Functions.Count)
                                    {
                                        string name = cache.StringTable.GetString(origRmt2.RealParameterNames[parameter.SourceIndex].Name);

                                        AnimatedParameter animatedParameter = new AnimatedParameter
                                        {
                                            Name = name,
                                            Type = ParameterType.Real,
                                            FunctionIndex = parameter.FunctionIndex,
                                            FunctionType = properties.Functions[parameter.FunctionIndex].Type
                                        };

                                        if (!animatedParams.Contains(animatedParameter))
                                        {
                                            animatedParams.Add(animatedParameter);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

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

        public void UpdateShaderData()
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                GenerateRenderMethod(stream, $@"shader", false);
                GenerateRenderMethod(stream, $@"halogram", false);

                RecompileShaderType(stream, $@"shader");
                RecompileShaderType(stream, $@"beam");
                RecompileShaderType(stream, $@"contrail");
                RecompileShaderType(stream, $@"decal");
                RecompileShaderType(stream, $@"halogram");
                RecompileShaderType(stream, $@"light_volume");
                RecompileShaderType(stream, $@"particle");
                RecompileShaderType(stream, $@"terrain");
                RecompileShaderType(stream, $@"water");
                RecompileShaderType(stream, $@"foliage");
                RecompileShaderType(stream, $@"screen");
            }
        }

        public void GenerateRenderMethod(Stream stream, string shaderType, bool updateRenderMethod) 
        {
            if (updateRenderMethod)
            {
                LegacyRenderMethodDefinitionGenerator.UpdateRenderMethodDefinition(Cache, stream, shaderType);
            }

            else 
            {
                var generator = TagTool.Shaders.ShaderGenerator.ShaderGenerator.GetGlobalShaderGenerator(shaderType, true);

                if (!CacheContext.TagCache.TryGetTag<RenderMethodDefinition>($@"shaders\{shaderType}", out CachedTag rmdfTag))
                {
                    rmdfTag = CacheContext.TagCache.AllocateTag<RenderMethodDefinition>($@"shaders\{shaderType}");
                }

                var rmdf = LegacyRenderMethodDefinitionGenerator.GenerateRenderMethodDefinition(Cache, stream, generator, shaderType, out _, out _);
                CacheContext.Serialize(stream, rmdfTag, rmdf);

                CacheContext.SaveTagNames();
            }
        }

        public void RecompileShaderType(Stream stream, string shaderType)
        {
            var rmdfTag = CacheContext.TagCache.GetTag<RenderMethodDefinition>($@"shaders\{shaderType}");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            if (rmdf.GlobalVertexShader == null || rmdf.GlobalPixelShader == null)
                new TagToolError(CommandError.TagInvalid, "A global shader was missing from rmdf");

            List<CachedTag> regenTags = new List<CachedTag>();

            foreach (var tag in CacheContext.TagCache.NonNull())
            {
                if (tag.Group.Tag != "rmt2" || tag.Name.StartsWith("ms30") || !tag.Name.Split('\\')[1].StartsWith(shaderType + "_templates"))
                    continue;

                regenTags.Add(tag);
            }

            // TODO: add multithreading
            // Need to figure out how to synchronize all the required data between threads first
            foreach (var tag in regenTags)
            {
                List<byte> options = new List<byte>();

                foreach (var option in tag.Name.Split('\\')[2].Remove(0, 1).Split('_'))
                    options.Add(byte.Parse(option));

                while (options.Count != rmdf.Categories.Count)
                    options.Add(0);

                GenerateRenderMethodTemplate(Cache, stream, shaderType, options.ToArray(), rmdf);
            }
        }

        public void GenerateRenderMethodTemplateTag(string shaderType, string shaderOptions)
        {
            List<byte> rawShaderOptions = new List<byte>();

            string[] optionsList = shaderOptions.Split(new char[] { ' ' });

            for (int i = 0; i < optionsList.Length; i++)
            {
                var parsedShaderOption = byte.Parse(optionsList[i]);

                rawShaderOptions.Add(parsedShaderOption);
            }

            using (var stream = Cache.OpenCacheReadWrite())
            {
                var tag = CacheContext.TagCache.GetTag<RenderMethodDefinition>($@"shaders\{shaderType}");
                var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(stream, tag);

                GenerateRenderMethodTemplate(Cache, stream, shaderType, rawShaderOptions.ToArray(), rmdf);
            }
        }

        public void GenerateRenderMethodTemplate(GameCache cache, Stream stream, string shaderType, byte[] options, RenderMethodDefinition rmdf) 
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

            var generator = LegacyShaderGenerator.GetLegacyShaderGenerator(shaderType, options, true);

            var glps = cache.Deserialize<GlobalPixelShader>(stream, rmdf.GlobalPixelShader);
            var glvs = cache.Deserialize<GlobalVertexShader>(stream, rmdf.GlobalVertexShader);

            var rmt2 = LegacyShaderGenerator.GenerateRenderMethodTemplate(cache, stream, rmdf, glps, glvs, generator, rmt2Name, out _, out _);

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
    }
}