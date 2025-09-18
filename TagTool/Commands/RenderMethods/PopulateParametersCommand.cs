﻿using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.RenderMethods
{
    class PopulateParametersCommand : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private RenderMethod Definition { get; }

        public PopulateParametersCommand(GameCache cache, CachedTag tag, RenderMethod definition)
            : base(true,

                 "PopulateParameters",
                 "Populates parameters from the render method's template.",

                 "PopulateParameters <pixel parameters> <vertex parameters>",
                 "Populates parameters from the render method's template.\n" + 
                 "Parameter names should be split by a comma. Enter \"none\" to skip a parameter type.\n" +
                 "ParameterTables will be created if none exist.")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 2)
                return new TagToolError(CommandError.ArgCount);

            string[] pixelRegisterNames = new string[] { "none" };
            string[] vertexRegisterNames = new string[] { "none" };

            if (args[0].ToLower() != "none")
                pixelRegisterNames = args[0].Split(',');
            if (args[1].ToLower() != "none")
                vertexRegisterNames = args[0].Split(',');

            Dictionary<int, string> PixelRegisterPairings = new Dictionary<int, string>();
            Dictionary<int, string> VertexRegisterPairings = new Dictionary<int, string>();

            var shaderProperty = Definition.ShaderProperties[0];

            if (shaderProperty.Template == null)
                return new TagToolError(CommandError.CustomError, "The shader\'s template was null");

            // find parameter registers and pair them for easy lookup later

            using (var stream = Cache.OpenCacheReadWrite())
            {
                RenderMethodTemplate rmt2 = Cache.Deserialize<RenderMethodTemplate>(stream, shaderProperty.Template);
                RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, Definition.BaseRenderMethod);

                // *technically* should search glps before pixl and vtsh after glvs but i dont think its necessary, just glvs and pixl should be fine
                var pixlTag = rmt2.PixelShader;
                var glvsTag = rmdf.GlobalVertexShader;

                if (pixlTag == null || glvsTag == null)
                    return new TagToolError(CommandError.CustomError, "The relative pixl or glvs tag was null");

                var pixl = Cache.Deserialize<PixelShader>(stream, pixlTag);
                var glvs = Cache.Deserialize<GlobalVertexShader>(stream, glvsTag);

                if (pixelRegisterNames[0] != "none")
                    foreach (var pixelRegisterName in pixelRegisterNames)
                    {
                        foreach (var shader in pixl.CompiledShaders)
                        {
                            bool canBreak = false;

                            foreach (var PCParameter in shader.CompiledShaderSplut.DX9ConstantTable.Constants)
                                if (PCParameter.RegisterSet == TagTool.Shaders.RasterizerConstantBlock.RegisterSetValue.Float && Cache.StringTable.GetString(PCParameter.ConstantName) == pixelRegisterName)
                                {
                                    PixelRegisterPairings.Add(PCParameter.RegisterStart, pixelRegisterName);
                                    canBreak = true;
                                    break;
                                }

                            if (canBreak)
                                break;
                        }
                    }

                if (vertexRegisterNames[0] != "none")
                    foreach (var vertexRegisterName in vertexRegisterNames)
                    {
                        foreach (var shader in glvs.CompiledShaders)
                        {
                            bool canBreak = false;

                            foreach (var PCParameter in shader.CompiledShaderSplut.DX9ConstantTable.Constants)
                                if (PCParameter.RegisterSet == TagTool.Shaders.RasterizerConstantBlock.RegisterSetValue.Float && Cache.StringTable.GetString(PCParameter.ConstantName) == vertexRegisterName)
                                {
                                    VertexRegisterPairings.Add(PCParameter.RegisterStart, vertexRegisterName);
                                    canBreak = true;
                                    break;
                                }

                            if (canBreak)
                                break;
                        }
                    }

                if ((pixelRegisterNames[0] != "none" && pixelRegisterNames.Length != PixelRegisterPairings.Count) || (vertexRegisterNames[0] != "none" && vertexRegisterNames.Length != VertexRegisterPairings.Count))
                    return new TagToolError(CommandError.CustomError, "One or more registers could not be found");

                // replace RM data

                shaderProperty.EntryPoints.Clear();
                shaderProperty.EntryPoints = rmt2.EntryPoints; //rmt2.EntryPoints.DeepClone(); // DeepClone if EntryPoints needs to be modified for whatever reason

                shaderProperty.Passes.Clear();
                shaderProperty.RoutingInfo.Clear();

                foreach (var table in rmt2.Passes)
                    shaderProperty.Passes.Add(new RenderMethod.RenderMethodPostprocessBlock.RenderMethodPostprocessPassBlock());

                // enumerate parameter tables and find parameters by register (easier to only build specified parameters)

                for (int i = 0; i < rmt2.Passes.Count; i++)
                {
                    var table = rmt2.Passes[i];
                    var rmTable = shaderProperty.Passes[i];

                    // vertex parameters

                    int addedParameterCount = 0;
                    rmTable.RealVertex.Offset = (ushort)shaderProperty.RoutingInfo.Count;

                    int rmt2ParameterIndex = table.Values[(int)TagTool.Shaders.ParameterUsage.VS_Real].Offset;
                    int rmt2ParameterCount = table.Values[(int)TagTool.Shaders.ParameterUsage.VS_Real].Count;

                    List<string> addedRegisters = new List<string>();

                    for (; rmt2ParameterIndex < (table.Values[(int)TagTool.Shaders.ParameterUsage.VS_Real].Offset + rmt2ParameterCount); rmt2ParameterIndex++)
                        if (VertexRegisterPairings.TryGetValue(rmt2.RoutingInfo[rmt2ParameterIndex].DestinationIndex, out var registerName) && !addedRegisters.Contains(registerName))
                        {
                            RenderMethod.RenderMethodPostprocessBlock.RenderMethodRoutingInfoBlock newParameter = new RenderMethod.RenderMethodPostprocessBlock.RenderMethodRoutingInfoBlock
                            {
                                RegisterIndex = (short)rmt2.RoutingInfo[rmt2ParameterIndex].DestinationIndex,
                                SourceIndex = rmt2.RoutingInfo[rmt2ParameterIndex].SourceIndex
                            };

                            addedRegisters.Add(registerName);
                            addedParameterCount++;

                            shaderProperty.RoutingInfo.Add(newParameter);
                        }

                    rmTable.RealVertex.Count = (ushort)addedParameterCount;

                    // pixel parameters

                    addedParameterCount = 0;
                    rmTable.RealPixel.Offset = (ushort)shaderProperty.RoutingInfo.Count;

                    int pxRmt2ParameterIndex = table.Values[(int)TagTool.Shaders.ParameterUsage.PS_Real].Offset;
                    int pxRmt2ParameterCount = table.Values[(int)TagTool.Shaders.ParameterUsage.PS_Real].Count;

                    addedRegisters.Clear();

                    for (; pxRmt2ParameterIndex < (table.Values[(int)TagTool.Shaders.ParameterUsage.PS_Real].Offset + pxRmt2ParameterCount); pxRmt2ParameterIndex++)
                        if (PixelRegisterPairings.TryGetValue(rmt2.RoutingInfo[pxRmt2ParameterIndex].DestinationIndex, out var registerName) && !addedRegisters.Contains(registerName))
                        {
                            RenderMethod.RenderMethodPostprocessBlock.RenderMethodRoutingInfoBlock newParameter = new RenderMethod.RenderMethodPostprocessBlock.RenderMethodRoutingInfoBlock
                            {
                                RegisterIndex = (short)rmt2.RoutingInfo[pxRmt2ParameterIndex].DestinationIndex,
                                SourceIndex = rmt2.RoutingInfo[pxRmt2ParameterIndex].SourceIndex
                            };

                            addedRegisters.Add(registerName);
                            addedParameterCount++;

                            shaderProperty.RoutingInfo.Add(newParameter);
                        }

                    rmTable.RealPixel.Count = (ushort)addedParameterCount;
                }

                Cache.Serialize(stream, Tag, Definition);
            }

            Console.WriteLine("Note: all parameters are now using function 0.\nDone!");
            return true;
        }
    }
}
