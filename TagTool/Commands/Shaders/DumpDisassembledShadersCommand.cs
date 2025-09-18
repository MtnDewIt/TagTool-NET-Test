﻿using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.IO;
using System.Collections.Generic;
using System.IO;
using System;
using TagTool.Tags.Definitions;
using TagTool.Geometry;
using TagTool.Cache.Eldorado;
using TagTool.Shaders;
using System.Diagnostics;
using TagTool.Common.Logging;

namespace TagTool.Commands.Shaders
{
    // TODO: Support Reach gpix
    public class DumpDisassembledShadersCommand : Command
    {
        GameCache Cache;
        RenderMethodTemplate CurrentRmt2;
        RenderMethodDefinition CurrentRmdf;
        List<byte> CurrentOptionIndices;
        int CurrentEntryPointIndex;
        bool IsXbox;
        string OutputPath;

        public DumpDisassembledShadersCommand(GameCache cache) : base
        (
            false, 
            "DumpDisassembledShaders", 
            "Dump disassembled shaders", 
            "DumpDisassembledShaders <Output Path> [Cache Directory]",
            "Dump disassembled shaders"
        )
        {
            Cache = cache;
            CurrentRmt2 = null;
            CurrentRmdf = null;
            CurrentOptionIndices = new List<byte>();
            CurrentEntryPointIndex = -1;
            IsXbox = false;
        }

        public override object Execute(List<string> args)
        {
            if (Cache.Platform != CachePlatform.MCC && Cache.GetType() == typeof(GameCacheGen3) && UseXSDCommand.XSDFileInfo == null)
                return new TagToolError(CommandError.CustomError, "You must use the \"UseXSD\" command first!");

            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            OutputPath = args[0];

            if (args.Count > 1)
            {
                DirectoryInfo cacheDirectory = new DirectoryInfo(args[1]);
                if (!cacheDirectory.Exists)
                    return new TagToolError(CommandError.ArgInvalid, "Invalid cache directory.");

                foreach (var cacheFile in cacheDirectory.GetFiles("*.map"))
                {
                    if (cacheFile.Name == "shared.map" || cacheFile.Name == "campaign.map")
                        continue;

                    Console.WriteLine($"Disassembling shaders in \"{cacheFile.Name}\"");
                    DisassembleCacheShaders(GameCache.Open(cacheFile));
                }
            }
            else
            {
                DisassembleCacheShaders(Cache);
            }

            return true;
        }

        private void DisassembleCacheShaders(GameCache cache)
        {
            IsXbox = CacheVersionDetection.GetGeneration(cache.Version) != CacheGeneration.Eldorado && cache.Platform != CachePlatform.MCC;

            Type entryPointEnum = typeof(EntryPoint);
            if (cache.Version >= CacheVersion.HaloReach)
                entryPointEnum = typeof(EntryPointReach);
            else if (cache.Version >= CacheVersion.Eldorado301003 && cache.Version <= CacheVersion.Eldorado700123)
                entryPointEnum = typeof(EntryPointMs30);

            using (var stream = cache.OpenCacheRead())
            {
                GlobalCacheFilePixelShaders gpix = null;
                if (cache.Version >= CacheVersion.HaloReach)
                    gpix = cache.Deserialize<GlobalCacheFilePixelShaders>(stream, cache.TagCache.FindFirstInGroup("gpix"));

                Dictionary<string, CachedTag> shaderTypes = new Dictionary<string, CachedTag>();

                foreach (var tag in cache.TagCache.NonNull())
                {
                    if (tag.Name == null || tag.Name == "" || tag.Group.Tag != "rmdf")
                        continue;
                    if (cache.Version == CacheVersion.EldoradoED && tag.Name.StartsWith("ms30\\"))
                        continue; // ignore ms30 in ms23, disassemble from ms30 directly instead
                    var pieces = tag.Name.Split('\\');

                    shaderTypes[pieces[pieces.Length - 1]] = tag;
                }

                foreach (var shaderType in shaderTypes.Keys)
                {
                    CurrentRmdf = cache.Deserialize<RenderMethodDefinition>(stream, shaderTypes[shaderType]);

                    CachedTag glvsTag = CurrentRmdf.GlobalVertexShader;
                    CachedTag glpsTag = CurrentRmdf.GlobalPixelShader;

                    if (glvsTag == null || glpsTag == null)
                    {
                        Log.Warning($"Cache \"{cache.DisplayName}\" has invalid shader type \"{shaderType}\"");
                        continue;
                    }

                    var glvsTagName = glvsTag.Name;
                    var glpsTagName = glpsTag.Name;

                    var glvs = cache.Deserialize<GlobalVertexShader>(stream, glvsTag);
                    var glps = cache.Deserialize<GlobalPixelShader>(stream, glpsTag);

                    foreach (var tag in cache.TagCache.NonNull())
                    {
                        if (tag.IsInGroup("rmt2") && tag.Name.StartsWith($"shaders\\{shaderType}_templates"))
                        {
                            // disassemble specified shaders related to rmt2
                            var tagName = tag.Name;
                            var rmt2Tag = cache.TagCache.GetTag(tagName, "rmt2");

                            CurrentRmt2 = cache.Deserialize<RenderMethodTemplate>(stream, rmt2Tag);

                            if (CurrentRmt2.PixelShader == null)
                            {
                                Log.Error("Template pixel shader was null");
                                CurrentRmt2 = null;
                                continue;
                            }

                            foreach (var index in rmt2Tag.Name.Split('\\')[2].Remove(0, 1).Split('_'))
                                CurrentOptionIndices.Add(Convert.ToByte(index));

                            var pixl = cache.Deserialize<PixelShader>(stream, CurrentRmt2.PixelShader);

                            var tagOutputPath = Path.Combine(OutputPath, cache.Version.ToString(), tagName);
                            Directory.CreateDirectory(tagOutputPath);

                            foreach (var entry in Enum.GetValues(entryPointEnum))
                            {
                                CurrentEntryPointIndex = GetEntryPointIndex(entry, cache.Version);

                                if (CurrentEntryPointIndex < pixl.EntryPoints.Count)
                                {
                                    var entryShader = pixl.EntryPoints[CurrentEntryPointIndex].StartIndex;

                                    if (pixl.EntryPoints[CurrentEntryPointIndex].Count != 0)
                                    {
                                        string entryName = entry.ToString().ToLower() + ".pixel_shader";
                                        string pixelShaderFilename = Path.Combine(tagName, entryName);

                                        DisassembleShader(pixl, entryShader, pixelShaderFilename, cache, stream, pixl.CompiledShaders[entryShader].CompiledShaderSplut.GlobalCachePixelShaderIndex != -1 ? gpix : null);
                                    }
                                }
                            }

                            CurrentEntryPointIndex = -1;
                            CurrentOptionIndices.Clear();
                            CurrentRmt2 = null;
                        }
                    }

                    // glps
                    var glpsOutputPath = Path.Combine(OutputPath, cache.Version.ToString(), glpsTagName);
                    Directory.CreateDirectory(glpsOutputPath);

                    foreach (var entry in Enum.GetValues(entryPointEnum))
                    {
                        CurrentEntryPointIndex = GetEntryPointIndex(entry, cache.Version);

                        if (CurrentEntryPointIndex < glps.EntryPoints.Count)
                        {
                            var entryShader = glps.EntryPoints[CurrentEntryPointIndex].DefaultCompiledShaderIndex;
                            if (entryShader != -1)
                            {
                                string entryName = entry.ToString().ToLower() + ".shared_pixel_shader";
                                string pixelShaderFilename = Path.Combine(glpsTagName, entryName);

                                DisassembleShader(glps, entryShader, pixelShaderFilename, cache, stream, glps.CompiledShaders[entryShader].CompiledShaderSplut.GlobalCachePixelShaderIndex != -1 ? gpix : null);
                            }
                            else if (glps.EntryPoints[CurrentEntryPointIndex].CategoryDependency.Count > 0)
                            {
                                foreach (var option in glps.EntryPoints[CurrentEntryPointIndex].CategoryDependency)
                                {
                                    var methodIndex = option.DefinitionCategoryIndex;
                                    for (int i = 0; i < option.OptionDependency.Count; i++)
                                    {
                                        var optionIndex = i;
                                        string glpsFilename = entry.ToString().ToLower() + $"_{methodIndex}_{optionIndex}" + ".shared_pixel_shader";
                                        glpsFilename = Path.Combine(glpsTagName, glpsFilename);
                                        DisassembleShader(glps, option.OptionDependency[i].CompiledShaderIndex, glpsFilename, cache, stream, glps.CompiledShaders[option.OptionDependency[i].CompiledShaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex != -1 ? gpix : null);
                                    }
                                }
                            }
                        }
                    }

                    CurrentEntryPointIndex = -1;

                    // glvs
                    foreach (VertexType vert in Enum.GetValues(typeof(VertexType)))
                    {
                        if ((int)vert < glvs.VertexTypes.Count)
                        {
                            var vertexFormat = glvs.VertexTypes[(int)vert];
                            var dirName = Path.Combine(glvsTagName, vert.ToString().ToLower());
                            var outputPath = Path.Combine(OutputPath, cache.Version.ToString(), dirName);

                            foreach (var entry in Enum.GetValues(entryPointEnum))
                            {
                                CurrentEntryPointIndex = GetEntryPointIndex(entry, cache.Version);

                                if (CurrentEntryPointIndex < vertexFormat.EntryPoints.Count)
                                {
                                    var entryShader = vertexFormat.EntryPoints[CurrentEntryPointIndex].ShaderIndex;
                                    if (entryShader != -1)
                                    {

                                        Directory.CreateDirectory(outputPath);
                                        string entryName = entry.ToString().ToLower() + ".shared_vertex_shader";
                                        string vertexShaderFileName = Path.Combine(dirName, entryName);

                                        DisassembleShader(glvs, entryShader, vertexShaderFileName, cache, stream, null);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < vertexFormat.EntryPoints[CurrentEntryPointIndex].CategoryDependency.Count; i++)
                                        {
                                            var catDep = vertexFormat.EntryPoints[CurrentEntryPointIndex].CategoryDependency[i];
                                            for (int j = 0; j < catDep.OptionDependency.Count; j++)
                                            {
                                                var opDep = catDep.OptionDependency[j];
                                                entryShader = opDep.CompiledShaderIndex;

                                                if (entryShader != -1)
                                                {
                                                    Directory.CreateDirectory(outputPath);
                                                    string entryName = entry.ToString().ToLower() + $"_catg{i}_i{j}.shared_vertex_shader";
                                                    string vertexShaderFileName = Path.Combine(dirName, entryName);

                                                    DisassembleShader(glvs, entryShader, vertexShaderFileName, cache, stream, null);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    CurrentEntryPointIndex = -1;
                    CurrentRmdf = null;
                }

                CachedTag rasgTag = cache.TagCache.FindFirstInGroup("rasg");
                if (rasgTag != null)
                {
                    var rasg = cache.Deserialize<RasterizerGlobals>(stream, rasgTag);

                    for (int i = 0; i < rasg.DefaultShaders.Count; i++)
                    {
                        var explicitShader = rasg.DefaultShaders[i];

                        if (explicitShader.PixelShader == null)
                        {
                            Console.WriteLine($"Invalid explicit pixel shader {i}");
                        }
                        else
                        {
                            string shaderName = explicitShader.PixelShader.Name.Split('\\')[2];

                            var outputPath = Path.Combine(OutputPath, cache.Version.ToString(), "explicit", shaderName);
                            Directory.CreateDirectory(outputPath);

                            var pixl = cache.Deserialize<PixelShader>(stream, explicitShader.PixelShader);
                            foreach (var entry in Enum.GetValues(entryPointEnum))
                            {
                                CurrentEntryPointIndex = GetEntryPointIndex(entry, cache.Version);

                                if (pixl.EntryPoints.Count <= CurrentEntryPointIndex)
                                    break;

                                for (int j = 0; j < pixl.EntryPoints[CurrentEntryPointIndex].Count; j++)
                                {
                                    int shaderIndex = pixl.EntryPoints[CurrentEntryPointIndex].StartIndex + j;
                                    string entryName = shaderIndex + "_" + entry.ToString().ToLower() + ".pixel_shader";
                                    string pixelShaderFilename = Path.Combine("explicit\\" + shaderName, entryName);

                                    DisassembleShader(pixl, shaderIndex, pixelShaderFilename, cache, stream, pixl.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex != -1 ? gpix : null);
                                }
                            }

                            CurrentEntryPointIndex = -1;
                        }

                        if (explicitShader.VertexShader == null)
                        {
                            Console.WriteLine($"Invalid explicit vertex shader {i}");
                        }
                        else
                        {
                            string shaderName = explicitShader.VertexShader.Name.Split('\\')[2];

                            var vtsh = cache.Deserialize<VertexShader>(stream, explicitShader.VertexShader);
                            foreach (var entry in Enum.GetValues(entryPointEnum))
                            {
                                CurrentEntryPointIndex = GetEntryPointIndex(entry, cache.Version);

                                if (vtsh.EntryPoints.Count <= CurrentEntryPointIndex)
                                    break;

                                for (int j = 0; j < vtsh.EntryPoints[CurrentEntryPointIndex].VertexTypes.Count; j++)
                                {
                                    for (int k = 0; k < vtsh.EntryPoints[CurrentEntryPointIndex].VertexTypes[j].Count; k++)
                                    {
                                        int shaderIndex = vtsh.EntryPoints[CurrentEntryPointIndex].VertexTypes[j].StartIndex + k;

                                        var dirName = Path.Combine("explicit\\" + shaderName + "\\", ((VertexType)k).ToString().ToLower() + "\\");

                                        var outputPath = Path.Combine(OutputPath, cache.Version.ToString(), dirName);
                                        Directory.CreateDirectory(outputPath);

                                        string entryName = shaderIndex + "_" + entry.ToString().ToLower() + ".vertex_shader";
                                        string vertexShaderFilename = Path.Combine(dirName, entryName);

                                        DisassembleShader(vtsh, shaderIndex, vertexShaderFilename, cache, stream, null);
                                    }
                                }
                            }

                            CurrentEntryPointIndex = -1;
                        }
                    }
                }

                if (cache.Version < CacheVersion.HaloReach)
                {
                    CachedTag chgdTag = cache.TagCache.FindFirstInGroup("chgd");
                    if (chgdTag != null)
                    {
                        var chgd = cache.Deserialize<ChudGlobalsDefinition>(stream, chgdTag);

                        for (int i = 0; i < chgd.HudShaders.Count; i++)
                        {
                            var hudShader = chgd.HudShaders[i];

                            if (hudShader.PixelShader == null)
                            {
                                Console.WriteLine($"Invalid chud pixel shader {i}");
                            }
                            else
                            {
                                string shaderName = hudShader.PixelShader.Name.Split('\\')[2];

                                var outputPath = Path.Combine(OutputPath, cache.Version.ToString(), "chud", shaderName);
                                Directory.CreateDirectory(outputPath);

                                var pixl = cache.Deserialize<PixelShader>(stream, hudShader.PixelShader);
                                foreach (var entry in Enum.GetValues(entryPointEnum))
                                {
                                    CurrentEntryPointIndex = GetEntryPointIndex(entry, cache.Version);

                                    if (pixl.EntryPoints.Count <= CurrentEntryPointIndex)
                                        break;

                                    for (int j = 0; j < pixl.EntryPoints[CurrentEntryPointIndex].Count; j++)
                                    {
                                        int shaderIndex = pixl.EntryPoints[CurrentEntryPointIndex].StartIndex + j;
                                        string entryName = shaderIndex + "_" + entry.ToString().ToLower() + ".pixel_shader";
                                        string pixelShaderFilename = Path.Combine("chud\\" + shaderName, entryName);

                                        DisassembleShader(pixl, shaderIndex, pixelShaderFilename, cache, stream, pixl.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex != -1 ? gpix : null);
                                    }
                                }

                                CurrentEntryPointIndex = -1;
                            }

                            if (hudShader.VertexShader == null)
                            {
                                Console.WriteLine($"Invalid chud vertex shader {i}");
                            }
                            else
                            {
                                string shaderName = hudShader.VertexShader.Name.Split('\\')[2];

                                var vtsh = cache.Deserialize<VertexShader>(stream, hudShader.VertexShader);
                                foreach (var entry in Enum.GetValues(entryPointEnum))
                                {
                                    CurrentEntryPointIndex = GetEntryPointIndex(entry, cache.Version);

                                    if (vtsh.EntryPoints.Count <= CurrentEntryPointIndex)
                                        break;

                                    for (int j = 0; j < vtsh.EntryPoints[CurrentEntryPointIndex].VertexTypes.Count; j++)
                                    {
                                        for (int k = 0; k < vtsh.EntryPoints[CurrentEntryPointIndex].VertexTypes[j].Count; k++)
                                        {
                                            int shaderIndex = vtsh.EntryPoints[CurrentEntryPointIndex].VertexTypes[j].StartIndex + k;

                                            var dirName = Path.Combine("chud\\" + shaderName + "\\", ((VertexType)k).ToString().ToLower() + "\\");

                                            var outputPath = Path.Combine(OutputPath, cache.Version.ToString(), dirName);
                                            Directory.CreateDirectory(outputPath);

                                            string entryName = shaderIndex + "_" + entry.ToString().ToLower() + ".vertex_shader";
                                            string vertexShaderFilename = Path.Combine(dirName, entryName);

                                            DisassembleShader(vtsh, shaderIndex, vertexShaderFilename, cache, stream, null);
                                        }
                                    }
                                }

                                CurrentEntryPointIndex = -1;
                            }
                        }
                    }
                }
            }
        }

        private string DisassembleShader(object definition, int shaderIndex, string filename, GameCache cache, Stream stream, GlobalCacheFilePixelShaders gpix)
        {
            string path = $"{OutputPath}\\{cache.Version}\\{filename}";

            if (IsXbox)
            {
                switch (definition)
                {
                    case PixelShader pixl:
                        if (pixl.CompiledShaders[shaderIndex].RuntimeShader != null ||
                            (cache.Version >= CacheVersion.HaloReach && pixl.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex != -1))
                            break;
                        return "NO DATA";
                    case VertexShader vtsh:
                        if (vtsh.CompiledShaders[shaderIndex].RuntimeShader != null)
                            break;
                        return "NO DATA";
                    case GlobalPixelShader glps:
                        if (glps.CompiledShaders[shaderIndex].RuntimeShader != null ||
                            (cache.Version >= CacheVersion.HaloReach && glps.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex != -1))
                            break;
                        return "NO DATA";
                    case GlobalVertexShader glvs:
                        if (glvs.CompiledShaders[shaderIndex].RuntimeShader != null)
                            break;
                        return "NO DATA";
                }

                return DisassembleGen3Shader(definition, shaderIndex, cache, stream, path, gpix);
            }
            else
            {
                return DisassemblePCShader(definition, shaderIndex, path);
            }
        }

        private string DisassembleGen3Shader(object definition, int shaderIndex, GameCache cache, Stream stream, string filename, GlobalCacheFilePixelShaders gpix)
        {
            var file = UseXSDCommand.XSDFileInfo;
            if (file == null)
            {
                Console.WriteLine("xsd.exe not found! use command usexsd <directory> to load xsd.exe");
                return null;
            }

            var tempFile = Path.GetTempFileName();
            string disassembly = "";
            string xsdArguments = " \"" + tempFile + "\"";
            List<int> disassemblyConstants = new List<int>();

            //
            // Set the arguments for xsd.exe according to the XDK documentation
            //
            try
            {
                CompiledShaderInfo shaderInfo = GetCompiledShaderInfo(definition, shaderIndex, gpix, IsXbox);

                File.WriteAllBytes(tempFile, shaderInfo.DebugData);
                File.WriteAllBytes(tempFile, shaderInfo.ConstantData);
                File.WriteAllBytes(tempFile, shaderInfo.ShaderData);

                xsdArguments = (shaderInfo.PixelShader ? "/rawps" : "/rawvs") + xsdArguments;

                ProcessStartInfo info = new ProcessStartInfo(UseXSDCommand.XSDFileInfo.FullName)
                {
                    Arguments = xsdArguments,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardError = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = false
                };
                Process xsd = Process.Start(info);

                // read disassembly + get all constants used in the shader
                // this is a bit hacky, however is the only way it can be done atm

                while (!xsd.StandardOutput.EndOfStream)
                {
                    string line = xsd.StandardOutput.ReadLine();
                    disassembly += line + "\n";

                    if (line.Length <= 4 || !line.Contains(" "))
                        continue;

                    var lineParts = line.Replace(",", "").Remove(0, 4).Split(' ');

                    // [0] is the instruction, skip it
                    for (int i = 1; i < lineParts.Length; i++)
                    {
                        if (lineParts[i].StartsWith("c") && char.IsDigit(lineParts[i][1]))
                        {
                            string registerString = lineParts[i];
                            registerString = registerString.Remove(0, 1);
                            registerString = registerString.Split('.')[0];
                            registerString = registerString.Replace("_abs", "");

                            int register = int.Parse(registerString);
                            if (!disassemblyConstants.Contains(register))
                                disassemblyConstants.Add(register);
                        }
                    }
                }

                xsd.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to disassemble shader: {e.ToString()}");
            }
            finally
            {
                File.Delete(tempFile);
            }

            using (var writer = File.CreateText(filename))
            {
                GenerateGen3ShaderHeader(definition, shaderIndex, cache, stream, writer, gpix, disassemblyConstants);
                writer.WriteLine(disassembly);
            }

            return disassembly;
        }

        private CompiledShaderInfo GetCompiledShaderInfo(object definition, int shaderIndex, GlobalCacheFilePixelShaders gpix, bool isXbox)
        {
            switch (definition)
            {
                case PixelShader pixl:
                    if (gpix == null && shaderIndex < pixl.CompiledShaders.Count)
                    {
                        CompiledPixelShaderBlock shaderBlock = pixl.CompiledShaders[shaderIndex];
                        bool containsConstants = shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants.Count > 0 || shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants.Count > 0;
                        return new CompiledShaderInfo(true, containsConstants, shaderBlock.RuntimeShader, isXbox ? shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants : shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants);
                    }
                    else if (gpix != null)
                    {
                        CompiledPixelShaderBlock shaderBlock = gpix.CompiledShaders[pixl.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex];
                        bool containsConstants = shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants.Count > 0 || shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants.Count > 0;
                        return new CompiledShaderInfo(true, containsConstants, shaderBlock.RuntimeShader, isXbox ? shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants : shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants);
                    }
                    break;
                case GlobalPixelShader glps:
                    if (gpix == null && shaderIndex < glps.CompiledShaders.Count)
                    {
                        CompiledPixelShaderBlock shaderBlock = glps.CompiledShaders[shaderIndex];
                        bool containsConstants = shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants.Count > 0 || shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants.Count > 0;
                        return new CompiledShaderInfo(true, containsConstants, shaderBlock.RuntimeShader, isXbox ? shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants : shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants);
                    }
                    else if (gpix != null)
                    {
                        CompiledPixelShaderBlock shaderBlock = gpix.CompiledShaders[glps.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex];
                        bool containsConstants = shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants.Count > 0 || shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants.Count > 0;
                        return new CompiledShaderInfo(true, containsConstants, shaderBlock.RuntimeShader, isXbox ? shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants : shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants);
                    }
                    break;
                case VertexShader vtsh:
                    if (shaderIndex < vtsh.CompiledShaders.Count)
                    {
                        CompiledVertexShaderBlock shaderBlock = vtsh.CompiledShaders[shaderIndex];
                        bool containsConstants = shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants.Count > 0 || shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants.Count > 0;
                        return new CompiledShaderInfo(false, containsConstants, shaderBlock.RuntimeShader, isXbox ? shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants : shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants);
                    }
                    break;
                case GlobalVertexShader glvs:
                    if (shaderIndex < glvs.CompiledShaders.Count)
                    {
                        CompiledVertexShaderBlock shaderBlock = glvs.CompiledShaders[shaderIndex];
                        bool containsConstants = shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants.Count > 0 || shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants.Count > 0;
                        return new CompiledShaderInfo(false, containsConstants, shaderBlock.RuntimeShader, isXbox ? shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants : shaderBlock.CompiledShaderSplut.DX9ConstantTable.Constants);
                    }
                    break;
            }

            return null;
        }

        private void GenerateGen3ShaderHeader(object definition, int shaderIndex, GameCache cache, Stream stream, StreamWriter writer, GlobalCacheFilePixelShaders gpix, List<int> disassemblyConstants = null)
        {
            CompiledShaderInfo shaderInfo = GetCompiledShaderInfo(definition, shaderIndex, gpix, IsXbox);

            if (!shaderInfo.ValidConstantTable && CurrentRmt2 != null)
                shaderInfo.GenerateParametersFromTemplate(cache, stream, CurrentEntryPointIndex, CurrentRmt2, CurrentRmdf, CurrentOptionIndices);

            List<RasterizerConstantBlock> parameters = shaderInfo.Parameters;
            List<RasterizerConstantBlock> orderedParameters = shaderInfo.ReorderParameters();
            List<RealQuaternion> constants = shaderInfo.GetXboxShaderConstants();

            List<int> usedConstants = new List<int>();

            WriteHeaderLine(writer);
            WriteHeaderLine(writer, "Generated by TagTool and Xbox Shader Disassembler");
            WriteHeaderLine(writer);

            if (parameters.Count > 0)
            {
                WriteHeaderLine(writer, "Parameters:");
                WriteHeaderLine(writer);

                uint regNameLength = 1;

                for (int i = 0; i < parameters.Count; i++)
                {
                    var param = parameters[i];
                    string paramName = cache.StringTable.GetString(parameters[i].ConstantName);
                    WriteHeaderLine(writer, $"\t{GetTypeString(param.RegisterSet, param.RegisterCount)} {paramName};");

                    if (paramName.Length > regNameLength)
                        regNameLength = (uint)paramName.Length;
                }

                WriteHeaderLine(writer);
                WriteHeaderLine(writer);
                WriteHeaderLine(writer, "Registers:");
                WriteHeaderLine(writer);
                WriteHeaderLine(writer, $"\t\t{"Name".ToLength(regNameLength)} {"Reg".ToLength(6)}{"Size".ToLength(4)}");
                WriteHeaderLine(writer, $"\t\t{"-".Repeat(regNameLength - 1)} ----- ----");

                for (int i = 0; i < orderedParameters.Count; i++)
                {
                    var param = orderedParameters[i];

                    if (param.RegisterSet == RasterizerConstantBlock.RegisterSetValue.Float)
                    {
                        // store used registers to sort literal constants
                        for (int j = 0; j < param.RegisterCount; j++)
                            usedConstants.Add(j + param.RegisterStart);
                    }

                    string name = cache.StringTable.GetString(orderedParameters[i].ConstantName).ToLength(regNameLength);
                    string reg = GetRegisterString(param.RegisterSet, param.RegisterStart).ToLength(6);
                    string size = param.RegisterCount.ToString().ToLength(4);

                    WriteHeaderLine(writer, $"\t\t{name} {reg}{size}");
                }

                WriteHeaderLine(writer);
            }

            WriteHeaderLine(writer);
            WriteHeaderLine(writer, "Constants:");
            WriteHeaderLine(writer);

            int constantRegister = 255;
            List<int> validConstants = new List<int>();
            for (int i = 0; i < constants.Count; i++)
            {
                while (true)
                {
                    if (!usedConstants.Contains(constantRegister))
                    {
                        if (disassemblyConstants.Contains(constantRegister))
                            break;
                        validConstants.Add(constantRegister);
                    }

                    constantRegister--;
                    if (constantRegister < 0)
                    {
                        //Console.WriteLine("Constant register could not be matched, using highest available.");
                        constantRegister = validConstants[0];
                        validConstants.RemoveAt(0);
                        break;
                    }
                }

                WriteHeaderLine(writer, $"\t\tc{constantRegister} {constants[i]} ");
                constantRegister--;
            }

            WriteHeaderLine(writer);
        }

        private void WriteHeaderLine(StreamWriter writer, string entry = null)
        {
            string result = "// ";
            if (entry != null)
                result += entry;
            writer.WriteLine(result);
        }

        private string GetRegisterString(RasterizerConstantBlock.RegisterSetValue type, int registerIndex)
        {
            string result = "";
            switch (type)
            {
                case RasterizerConstantBlock.RegisterSetValue.Bool:
                    result = "b";
                    break;
                case RasterizerConstantBlock.RegisterSetValue.Int:
                    result = "i";
                    break;
                case RasterizerConstantBlock.RegisterSetValue.Float:
                    result = "c";
                    break;
                case RasterizerConstantBlock.RegisterSetValue.Sampler:
                    result = "s";
                    break;
            }
            result += registerIndex.ToString();
            return result;
        }

        private string GetTypeString(RasterizerConstantBlock.RegisterSetValue type, int size)
        {
            string result = "";
            switch (type)
            {
                case RasterizerConstantBlock.RegisterSetValue.Bool:
                    result = "bool";
                    break;
                case RasterizerConstantBlock.RegisterSetValue.Int:
                    result = "integer";
                    break;
                case RasterizerConstantBlock.RegisterSetValue.Float:
                    result = "float4";
                    if (size > 1)
                        result += $"x{size}";
                    break;
                case RasterizerConstantBlock.RegisterSetValue.Sampler:
                    result = "sampler2D";
                    break;
            }
            return result;
        }

        private string DisassemblePCShader(object definition, int shaderIndex, string filename)
        {
            string disassembly = null;

            if (definition.GetType() == typeof(PixelShader) || definition.GetType() == typeof(GlobalPixelShader))
            {
                CompiledPixelShaderBlock shader_block = null;
                if (definition.GetType() == typeof(PixelShader))
                {
                    var _definition = definition as PixelShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return null;
                }

                if (definition.GetType() == typeof(GlobalPixelShader))
                {
                    var _definition = definition as GlobalPixelShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return null;
                }

                var pc_shader = shader_block.CompiledShaderSplut.DX9CompiledShader;
                disassembly = D3DCompiler.Disassemble(pc_shader);
                if (pc_shader == null)
                    disassembly = null;
            }

            if (definition.GetType() == typeof(VertexShader) || definition.GetType() == typeof(GlobalVertexShader))
            {
                CompiledVertexShaderBlock shader_block = null;
                if (definition.GetType() == typeof(VertexShader))
                {
                    var _definition = definition as VertexShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return null;
                }

                if (definition.GetType() == typeof(GlobalVertexShader))
                {
                    var _definition = definition as GlobalVertexShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return null;
                }

                var pc_shader = shader_block.CompiledShaderSplut.DX9CompiledShader;
                disassembly = D3DCompiler.Disassemble(pc_shader);
                if (pc_shader == null)
                    disassembly = null;
            }

            using (var writer = File.CreateText(filename))
            {
                writer.WriteLine(disassembly);
            }

            return disassembly;
        }

        private int GetEntryPointIndex(object input, CacheVersion version)
        {
            if (version >= CacheVersion.HaloReach)
                return (int)((EntryPointReach)input);
            else if (version >= CacheVersion.Eldorado301003 && version <= CacheVersion.Eldorado700123)
                return (int)((EntryPointMs30)input);
            else
                return (int)((EntryPoint)input);
        }
    }
}

