using HaloShaderGenerator.Globals;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using TagTool.Cache;
using TagTool.Commands.Shaders;
using TagTool.JSON.Parsers;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;
using TagTool.JSON;

namespace TagTool.Commands.GenerateDonkeyCache
{
    partial class GenerateDonkeyCacheCommand : Command
    {
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

        public void GenerateExplicitShader(Stream stream, ExplicitShader shader, bool applyFixes = true)
        {
            CachedTag pixlTag = Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");
            CachedTag vtshTag = Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            ShaderGeneratorNew.GenerateExplicitShader(Cache, stream, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }

        public void GenerateChudShader(Stream stream, ChudShader shader, bool applyFixes = true)
        {
            CachedTag pixlTag = Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");
            CachedTag vtshTag = Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            ShaderGeneratorNew.GenerateChudShader(Cache, stream, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }
    }
}
