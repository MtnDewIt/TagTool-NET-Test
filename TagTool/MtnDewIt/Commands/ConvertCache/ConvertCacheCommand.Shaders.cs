using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using TagTool.Commands;
using TagTool.MtnDewIt.Shaders.LegacyShaderGenerator;
using TagTool.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command
    {
        public void UpdateShaderData()
        {
            GenerateRenderMethod(CacheStream, $@"halogram", false);
            GenerateRenderMethod(CacheStream, $@"shader", false);
            GenerateRenderMethod(CacheStream, $@"terrain", false);
            GenerateRenderMethod(CacheStream, $@"custom", false);
            GenerateRenderMethod(CacheStream, $@"zonly", false);
            GenerateRenderMethod(CacheStream, $@"cortana", false);
            GenerateRenderMethod(CacheStream, $@"black", false);

            RecompileShaderType(CacheStream, $@"beam");
            RecompileShaderType(CacheStream, $@"contrail");
            RecompileShaderType(CacheStream, $@"decal");
            RecompileShaderType(CacheStream, $@"foliage");
            RecompileShaderType(CacheStream, $@"halogram");
            RecompileShaderType(CacheStream, $@"light_volume");
            RecompileShaderType(CacheStream, $@"particle");
            RecompileShaderType(CacheStream, $@"screen");
            RecompileShaderType(CacheStream, $@"shader");
            RecompileShaderType(CacheStream, $@"terrain");
            RecompileShaderType(CacheStream, $@"water");
        }

        public void GenerateRenderMethod(Stream stream, string shaderType, bool updateRenderMethod) 
        {
            if (updateRenderMethod)
            {
                LegacyRenderMethodDefinitionGenerator.UpdateRenderMethodDefinition(Cache, stream, shaderType);
            }

            else 
            {
                var generator = LegacyShaderGenerator.GetLegacyGlobalShaderGenerator(shaderType, true);

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

            foreach (var tag in regenTags)
            {
                List<byte> options = new List<byte>();

                foreach (var option in tag.Name.Split('\\')[2].Remove(0, 1).Split('_'))
                    options.Add(byte.Parse(option));

                while (options.Count != rmdf.Categories.Count)
                    options.Add(0);

                LegacyShaderGenerator.GenerateShaderTemplate(Cache, stream, shaderType, options.ToArray(), rmdf);
            }

            CustomThreadPool.FreeAllThreads();
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

            LegacyShaderGenerator.GenerateShaderTemplate(Cache, CacheStream, shaderType, rawShaderOptions.ToArray(), rmdf);

            CustomThreadPool.FreeAllThreads();
        }
    }
}