using HaloShaderGenerator.Globals;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using TagTool.Cache;
using TagTool.Commands.Shaders;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON.Parsers;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public static HashSet<ShaderType> noFixesShaders = new HashSet<ShaderType> 
        {
            ShaderType.Water,
            ShaderType.Foliage,
        };

        public void UpdateShaderData()
        {
            // This will eventually get defined at runtime, along with all the other JSON related objects
            // Right now, we just need to replace the existing system with JSON, ensuring 1:1 functionality, or as close as we can get
            var tagParser = new TagObjectParser(Cache, CacheContext, CacheStream);

            var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\updateshaderdata\tags.json");
            var tagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);

            foreach (var file in tagObjectList)
                tagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

            foreach (ShaderType shaderType in Enum.GetValues(typeof(ShaderType)))
            {
                if (shaderType == ShaderType.Glass)
                    continue;
                    
                bool applyFixes = !noFixesShaders.Contains(shaderType);
                GenerateGlobalShader(CacheStream, shaderType, applyFixes);
            }
        }

        public void GenerateGlobalShader(Stream stream, ShaderType shader, bool applyFixes = true)
        {
            string shaderName = shader.ToString().ToLowerInvariant();
            string rmdfName = shaderName == "lightvolume" ? "shaders\\light_volume" : $"shaders\\{shaderName}";

            CachedTag rmdfTag = Cache.TagCache.GetTag<RenderMethodDefinition>(rmdfName);
            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            GlobalPixelShader glps = ShaderGeneratorNew.GenerateSharedPixelShaders(Cache, rmdf, shader, applyFixes);
            GlobalVertexShader glvs = ShaderGeneratorNew.GenerateSharedVertexShaders(Cache, rmdf, shader, applyFixes);

            Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
        }

        public void GenerateRenderMethodTemplate(string shaderType, string shaderOptions)
        {
            List<byte> rawShaderOptions = new List<byte>();

            string[] optionsList = shaderOptions.Split(new char[] { ' ' });

            for (int i = 0; i < optionsList.Length; i++)
            {
                var parsedShaderOption = byte.Parse(optionsList[i]);

                rawShaderOptions.Add(parsedShaderOption);
            }

            var rmdfTag = CacheContext.TagCache.GetTag<RenderMethodDefinition>($@"shaders\{shaderType}");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(CacheStream, rmdfTag);

            GenerateShaderCommand.GenerateRenderMethodTemplate(Cache, CacheStream, shaderType, rawShaderOptions.ToArray(), rmdf, true);
        }
    }
}