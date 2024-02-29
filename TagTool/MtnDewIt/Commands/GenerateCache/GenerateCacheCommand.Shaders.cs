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
            using (var stream = Cache.OpenCacheReadWrite())
            {
                //GenerateRenderMethod(stream, $@"beam", false);
                GenerateRenderMethod(stream, $@"black", false);
                //GenerateRenderMethod(stream, $@"contrail", false);
                //GenerateRenderMethod(stream, $@"cortana", false);
                //GenerateRenderMethod(stream, $@"custom", false);
                //GenerateRenderMethod(stream, $@"decal", false);
                //GenerateRenderMethod(stream, $@"foliage", false);
                GenerateRenderMethod(stream, $@"halogram", false);
                //GenerateRenderMethod(stream, $@"light_volume", false);
                //GenerateRenderMethod(stream, $@"particle", false);
                //GenerateRenderMethod(stream, $@"screen", false);
                GenerateRenderMethod(stream, $@"shader", false);
                GenerateRenderMethod(stream, $@"terrain", false);
                //GenerateRenderMethod(stream, $@"water", false);
                GenerateRenderMethod(stream, $@"zonly", false);
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