using TagTool.Cache;
using TagTool.Tags.Definitions;
using System;
using System.Collections.Generic;
using TagTool.Shaders;
using TagTool.Common;
using TagTool.Commands.Common;
using System.IO;
using TagTool.IO;
using System.Linq;
using System.Diagnostics;
using TagTool.Cache.HaloOnline;

namespace TagTool.Commands.Shaders
{
    public class DisassembleCommand<T> : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private T Definition { get; }

        public DisassembleCommand(GameCache cache, CachedTag tag, T definition) :
            base(true,

                "Disassemble",
                "Disassembles the shader at the specified index.",

                "Disassemble <index> [file]",

                "<index> - index into the Shaders tagblock.")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            var disassemblies = new List<string> { };
            var indices = new List<int>();

            GlobalCacheFilePixelShaders gpix = null;

            if (args[0] == "*")
            {
                for (var i = 0; ; i++)
                {
                    string disassembly = null;
                    if (Cache.GetType() == typeof(GameCacheGen3))
                    {
                        if (Cache.Version >= CacheVersion.HaloReach)
                        {
                            using (var stream = Cache.OpenCacheRead())
                                gpix = Cache.Deserialize<GlobalCacheFilePixelShaders>(stream, Cache.TagCache.FindFirstInGroup("gpix"));
                        }

                        disassembly = DisassembleGen3Shader(i, gpix, $" \"{i}\"");
                    }
                    else if (Cache.GetType() == typeof(GameCacheHaloOnline))
                    {
                        disassembly = DisassembleHaloOnlineShader(i);
                    }
                    
                    if (disassembly == null)
                        break;
                    else
                    {
                        disassemblies.Add(disassembly);
                        indices.Add(i);
                    }
                }
            }
            else
            {
                if (int.TryParse(args[0], out int shaderIndex))
                {
                    if (Cache.GetType() == typeof(GameCacheGen3))
                    {
                        if (Cache.Version >= CacheVersion.HaloReach)
                        {
                            using (var stream = Cache.OpenCacheRead())
                                gpix = Cache.Deserialize<GlobalCacheFilePixelShaders>(stream, Cache.TagCache.FindFirstInGroup("gpix"));
                        }

                        disassemblies.Add(DisassembleGen3Shader(shaderIndex, gpix, $" \"{shaderIndex}\""));
                    }
                    else if (Cache.GetType() == typeof(GameCacheHaloOnline))
                    {
                        disassemblies.Add(DisassembleHaloOnlineShader(shaderIndex));
                    }
                    indices.Add(shaderIndex);
                }
                    
            }

            string filename = args.Count == 2 ? args[1] : "Shaders";

            for (var i = 0; i < disassemblies.Count; i++)
                using (var writer = File.CreateText(Path.Combine(filename, $"{Tag.Name.Split('\\').Last()}_{indices[i]}.{Tag.Group}.txt")))
                {
                    if (Cache.GetType() == typeof(GameCacheGen3))
                        GenerateGen3ShaderHeader(indices[i], writer, gpix);
                    writer.WriteLine(disassemblies[i]);
                }
                    

            return true;
        }

        private string DisassembleGen3Shader(int shaderIndex, GlobalCacheFilePixelShaders gpix, string shaderInfo = "")
        {
            var file = UseXSDCommand.XSDFileInfo;
            if(file == null)
            {
                Console.WriteLine("xsd.exe not found! use command usexsd <directory> to load xsd.exe");
                return null;
            }
            var tempFile = Path.GetTempFileName();
            string disassembly = null;
            string xsdArguments = " \"" + tempFile +"\"";
            byte[] microcode = new byte[0];
            byte[] debugData = new byte[0];
            byte[] constantData = new byte[0];

            //
            // Set the arguments for xsd.exe according to the XDK documentation
            //
            try
            {
                if (typeof(T) == typeof(PixelShader) || typeof(T) == typeof(GlobalPixelShader))
                {
                    xsdArguments = "/rawps" + xsdArguments;
                    CompiledPixelShaderBlock shaderBlock = null;
                    if (typeof(T) == typeof(PixelShader))
                    {
                        var _definition = Definition as PixelShader;
                        if (gpix == null && shaderIndex < _definition.CompiledShaders.Count)
                            shaderBlock = _definition.CompiledShaders[shaderIndex];
                        else if (gpix != null)
                            shaderBlock = gpix.CompiledShaders[_definition.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex];
                        else
                            return null;
                    }

                    if (typeof(T) == typeof(GlobalPixelShader))
                    {
                        var _definition = Definition as GlobalPixelShader;
                        if (shaderIndex < _definition.CompiledShaders.Count)
                            shaderBlock = _definition.CompiledShaders[shaderIndex];
                        else
                            return null;
                    }

                    microcode = shaderBlock.RuntimeShader.ShaderData;
                    debugData = shaderBlock.RuntimeShader.DebugData;
                    constantData = shaderBlock.RuntimeShader.ConstantData;
                }

                if (typeof(T) == typeof(VertexShader) || typeof(T) == typeof(GlobalVertexShader))
                {
                    xsdArguments = "/rawvs" + xsdArguments;
                    CompiledVertexShaderBlock shaderBlock = null;
                    if (typeof(T) == typeof(VertexShader))
                    {
                        var _definition = Definition as VertexShader;
                        if (shaderIndex < _definition.CompiledShaders.Count)
                            shaderBlock = _definition.CompiledShaders[shaderIndex];
                        else
                            return null;
                    }

                    if (typeof(T) == typeof(GlobalVertexShader))
                    {
                        var _definition = Definition as GlobalVertexShader;
                        if (shaderIndex < _definition.CompiledShaders.Count)
                            shaderBlock = _definition.CompiledShaders[shaderIndex];
                        else
                            return null;
                    }

                    microcode = shaderBlock.RuntimeShader.ShaderData;
                    debugData = shaderBlock.RuntimeShader.DebugData;
                    constantData = shaderBlock.RuntimeShader.ConstantData;
                }

                File.WriteAllBytes(tempFile, debugData);
                File.WriteAllBytes(tempFile, constantData);
                File.WriteAllBytes(tempFile, microcode);

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
                disassembly = xsd.StandardOutput.ReadToEnd();
                xsd.WaitForExit();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Failed to disassemble shader{shaderInfo}: {e.ToString()}");
            }
            finally
            {
                File.Delete(tempFile);
            }

            return disassembly;
        }

        private string DisassembleHaloOnlineShader(int shaderIndex)
        {
            string disassembly = null;

            if (typeof(T) == typeof(PixelShader) || typeof(T) == typeof(GlobalPixelShader))
            {
                CompiledPixelShaderBlock shader_block = null;
                if (typeof(T) == typeof(PixelShader))
                {
                    var _definition = Definition as PixelShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return null;
                }

                if (typeof(T) == typeof(GlobalPixelShader))
                {
                    var _definition = Definition as GlobalPixelShader;
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

            if (typeof(T) == typeof(VertexShader) || typeof(T) == typeof(GlobalVertexShader))
            {
                CompiledVertexShaderBlock shader_block = null;
                if (typeof(T) == typeof(VertexShader))
                {
                    var _definition = Definition as VertexShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return null;
                }

                if (typeof(T) == typeof(GlobalVertexShader))
                {
                    var _definition = Definition as GlobalVertexShader;
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

            return disassembly;
        }

        private void GenerateGen3ShaderHeader(int shaderIndex, StreamWriter writer, GlobalCacheFilePixelShaders gpix)
        {
            List<RasterizerConstantBlock> parameters = null;
            List<RealQuaternion> constants = new List<RealQuaternion>();

            if (typeof(T) == typeof(PixelShader) || typeof(T) == typeof(GlobalPixelShader))
            {
                CompiledPixelShaderBlock shader_block = null;
                if (typeof(T) == typeof(PixelShader))
                {
                    var _definition = Definition as PixelShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return;

                    if (shader_block.RuntimeShader == null && gpix != null)
                        shader_block = gpix.CompiledShaders[_definition.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex];
                }

                if (typeof(T) == typeof(GlobalPixelShader))
                {
                    var _definition = Definition as GlobalPixelShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shader_block = _definition.CompiledShaders[shaderIndex];
                    else
                        return;

                    if (shader_block.RuntimeShader == null && gpix != null)
                        shader_block = gpix.CompiledShaders[_definition.CompiledShaders[shaderIndex].CompiledShaderSplut.GlobalCachePixelShaderIndex];
                }

                if (shader_block.RuntimeShader != null)
                    constants = GetShaderConstants(shader_block.RuntimeShader.ConstantData);
                parameters = shader_block.CompiledShaderSplut.XenonConstantTable.Constants;
            }

            if (typeof(T) == typeof(VertexShader) || typeof(T) == typeof(GlobalVertexShader))
            {
                CompiledVertexShaderBlock shaderBlock = null;
                if (typeof(T) == typeof(VertexShader))
                {
                    var _definition = Definition as VertexShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shaderBlock = _definition.CompiledShaders[shaderIndex];
                    else
                        return;
                }

                if (typeof(T) == typeof(GlobalVertexShader))
                {
                    var _definition = Definition as GlobalVertexShader;
                    if (shaderIndex < _definition.CompiledShaders.Count)
                        shaderBlock = _definition.CompiledShaders[shaderIndex];
                    else
                        return;
                }

                if (shaderBlock.RuntimeShader != null)
                    constants = GetShaderConstants(shaderBlock.RuntimeShader.ConstantData);
                parameters = shaderBlock.CompiledShaderSplut.XenonConstantTable.Constants;
            }

            List<string> parameterNames = new List<string>();

            for (int i = 0; i < parameters.Count; i++)
                parameterNames.Add(Cache.StringTable.GetString(parameters[i].ConstantName));

            WriteHeaderLine(writer);
            WriteHeaderLine(writer, "Generated by TagTool and Xbox Shader Disassembler");
            WriteHeaderLine(writer);
            WriteHeaderLine(writer, "Parameters");
            WriteHeaderLine(writer);
            for(int i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                WriteHeaderLine(writer, $"    {GetTypeString(param.RegisterSet, param.RegisterCount)} {parameterNames[i]};");
            }
            WriteHeaderLine(writer);
            WriteHeaderLine(writer);
            WriteHeaderLine(writer, "Registers");
            WriteHeaderLine(writer);
            // sort later
            for (int i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                WriteHeaderLine(writer, $"    {parameterNames[i]} {GetRegisterString(param.RegisterSet, param.RegisterStart)} {param.RegisterCount}");
            }
            WriteHeaderLine(writer);
            WriteHeaderLine(writer);
            WriteHeaderLine(writer, "Constants");
            WriteHeaderLine(writer);
            int constantregister = 255;
            for (int i = 0; i < constants.Count; i++)
            {
                WriteHeaderLine(writer, $"    c{constantregister} {constants[i]} ");
                constantregister--;
            }
        }

        private void WriteHeaderLine(StreamWriter writer, string entry = null)
        {
            string result = "// ";
            if(entry != null)
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

        private List<RealQuaternion> GetShaderConstants(byte[] constantData)
        {
            var constants = new List<RealQuaternion>();
            using (var stream = new MemoryStream(constantData))
            using (var reader = new EndianReader(stream, EndianFormat.BigEndian))
            {
                for (var i = 0; i < constantData.Length / 16; i++)
                {
                    constants.Add(new RealQuaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
                }
                constants.Reverse(); //they are stored in reverse order
            }

            return constants;
        }
    }
}
