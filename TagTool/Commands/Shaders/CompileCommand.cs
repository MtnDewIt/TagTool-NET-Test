﻿using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;
using System;
using System.Collections.Generic;
using System.IO;

namespace TagTool.Commands.Shaders
{
    public class CompileCommand<T> : Command
	{
		private GameCache Cache { get; }
		private CachedTag Tag { get; }
		private T Definition { get; }
        public static bool IsVertexShader => typeof(T) == typeof(GlobalVertexShader) || typeof(T) == typeof(VertexShader);
        public static bool IsPixelShader => typeof(T) == typeof(GlobalPixelShader) || typeof(T) == typeof(PixelShader);

        public CompileCommand(GameCache cache, CachedTag tag, T definition) :
			base(true,

				"Compile",
				"Compiles HLSL source file against shader profile vs_3_0",

				"Compile <index> <file.hlsl>",

				"Compiles <file.hlsl> against shader profile vs_3_0" +
				"into shader bytecode, generates a VertexShaderBlock element\n" +
				"and writes it over <index>")
		{
			Cache = cache;
			Tag = tag;
			Definition = definition;
		}

		public override object Execute(List<string> args)
		{
			if (args.Count < 2)
                return new TagToolError(CommandError.ArgCount);

            bool use_assembly_compiler = args.Count >= 2 && args[0].ToLower() == "asm";
            string file = args[args.Count - 1];
            string shader_code = File.ReadAllText(file);

            if (use_assembly_compiler && args.Count < 3)
                return false;

            int index = use_assembly_compiler ? int.Parse(args[1]) : int.Parse(args[0]);

            if (!use_assembly_compiler)
            {
                using (var reader = new StringReader(shader_code))
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        var str = line.Trim();
                        if (str == "ps_3_0" || str == "vs_3_0")
                        {
                            use_assembly_compiler = true;
                            break;
                        }
                    }
                }
            }

            byte[] bytecode = null;
            if (use_assembly_compiler)
            {
                bytecode = D3DCompiler.Assemble(shader_code);
            }
            else
            {
                var profile = IsVertexShader ? "vs_3_0" : "ps_3_0";

                try
                {
                    bytecode = D3DCompiler.CompileFromFile(shader_code, "main", profile);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return true;
                }
            }

            var disassembly = D3DCompiler.Disassemble(bytecode);
            Console.WriteLine(disassembly);

            if (typeof(T) == typeof(PixelShader) || typeof(T) == typeof(GlobalPixelShader))
            {
                var shader_data_block = new CompiledPixelShaderBlock
                {
                    CompiledShaderSplut = new RasterizerCompiledShader 
                    {
                        DX9CompiledShader = bytecode
                    },
                };

                if (typeof(T) == typeof(PixelShader))
                {
                    var _definition = Definition as PixelShader;
                    var existing_block = _definition.CompiledShaders[index];
                    shader_data_block.CompiledShaderSplut.DX9ConstantTable.Constants = existing_block.CompiledShaderSplut.DX9ConstantTable.Constants;

                    _definition.CompiledShaders[index] = shader_data_block;
                }

                if (typeof(T) == typeof(GlobalPixelShader))
                {
                    var _definition = Definition as GlobalPixelShader;
                    var existing_block = _definition.CompiledShaders[index];
                    shader_data_block.CompiledShaderSplut.DX9ConstantTable.Constants = existing_block.CompiledShaderSplut.DX9ConstantTable.Constants;

                    _definition.CompiledShaders[index] = shader_data_block;
                }
            }

            if (typeof(T) == typeof(VertexShader) || typeof(T) == typeof(GlobalVertexShader))
            {
                
                var shader_data_block = new CompiledVertexShaderBlock
                {
                    CompiledShaderSplut = new RasterizerCompiledShader
                    {
                        DX9CompiledShader = bytecode
                    },
                };

                if (typeof(T) == typeof(VertexShader))
                {
                    var _definition = Definition as VertexShader;
                    var existing_block = _definition.CompiledShaders[index];
                    shader_data_block.CompiledShaderSplut.DX9ConstantTable.Constants = existing_block.CompiledShaderSplut.DX9ConstantTable.Constants;

                    _definition.CompiledShaders[index] = shader_data_block;
                }

                if (typeof(T) == typeof(GlobalVertexShader))
                {
                    var _definition = Definition as GlobalVertexShader;
                    var existing_block = _definition.CompiledShaders[index];
                    shader_data_block.CompiledShaderSplut.DX9ConstantTable = existing_block.CompiledShaderSplut.DX9ConstantTable;


                    _definition.CompiledShaders[index] = shader_data_block;
                }
            }

            return true;
		}

		public List<RasterizerConstantBlock> GetParamInfo(string assembly)
		{
			var parameters = new List<RasterizerConstantBlock> { };

			using (StringReader reader = new StringReader(assembly))
			{
				if (string.IsNullOrEmpty(assembly))
					return null;

				string line;

				while (!(line = reader.ReadLine()).Contains("//   -"))
					continue;

				while (!string.IsNullOrEmpty((line = reader.ReadLine())))
				{
					line = (line.Replace("//   ", "").Replace("//", "").Replace(";", ""));

					while (line.Contains("  "))
						line = line.Replace("  ", " ");

					if (!string.IsNullOrEmpty(line))
					{
						var split = line.Split(' ');
                        parameters.Add(new RasterizerConstantBlock
                        {
                            ConstantName = Cache.StringTable.GetStringId(split[0]),
                            RegisterSet = (RasterizerConstantBlock.RegisterSetValue)Enum.Parse(typeof(RasterizerConstantBlock.RegisterSetValue), split[1][0].ToString()),
                            RegisterStart = byte.Parse(split[1].Substring(1)),
                            RegisterCount = byte.Parse(split[2])
                        });
					}
				}
			}

			return parameters;
		}
	}
}