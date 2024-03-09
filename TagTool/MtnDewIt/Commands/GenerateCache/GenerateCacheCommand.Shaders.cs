using TagTool.Commands.Common;
using TagTool.Commands;
using System.IO;
using TagTool.Cache;
using TagTool.MtnDewIt.Shaders.LegacyShaderGenerator;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void UpdateShaderData()
        {
            //GenerateRenderMethod(CacheStream, $@"beam", false);
            GenerateRenderMethod(CacheStream, $@"black", false);
            //GenerateRenderMethod(CacheStream, $@"contrail", false);
            //GenerateRenderMethod(CacheStream, $@"cortana", false);
            //GenerateRenderMethod(CacheStream, $@"custom", false);
            //GenerateRenderMethod(CacheStream, $@"decal", false);
            //GenerateRenderMethod(CacheStream, $@"foliage", false);
            GenerateRenderMethod(CacheStream, $@"halogram", false);
            //GenerateRenderMethod(CacheStream, $@"light_volume", false);
            //GenerateRenderMethod(CacheStream, $@"particle", false);
            //GenerateRenderMethod(CacheStream, $@"screen", false);
            GenerateRenderMethod(CacheStream, $@"shader", false);
            GenerateRenderMethod(CacheStream, $@"terrain", false);
            //GenerateRenderMethod(CacheStream, $@"water", false);
            GenerateRenderMethod(CacheStream, $@"zonly", false);
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
    }
}