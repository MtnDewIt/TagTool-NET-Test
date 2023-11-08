using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Commands.Shaders;
using TagTool.Tags.Definitions;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command
    {
        public void GenerateRenderMethods()
        {
            CommandRunner.Current.RunCommand($@"generatermdf shader");
            CommandRunner.Current.RunCommand($@"generatermdf halogram");
        }

        public void RecompileShaders() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
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

        public void RecompileShaderType(Stream stream, string shaderType) 
        {
            var rmdfTag = CacheContext.TagCache.GetTag<RenderMethodDefinition>($@"shaders\{shaderType}");

            var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            if (rmdf.GlobalVertexShader == null || rmdf.GlobalPixelShader == null)
                new TagToolError(CommandError.TagInvalid, "A global shader was missing from rmdf");

            List<CachedTag> regenTags = new List<CachedTag>();

            foreach (var tag in Cache.TagCache.NonNull())
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

                GenerateShaderCommand.GenerateRenderMethodTemplate(Cache, stream, shaderType, options.ToArray(), rmdf);
            }
        }

        public void GenerateShaderTemplate(string shaderType, byte[] options) 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                var renderMethodTag = GetCachedTag<RenderMethodDefinition>($@"shaders\{shaderType}");

                var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, renderMethodTag);

                GenerateShaderCommand.GenerateRenderMethodTemplate(Cache, stream, shaderType, options, rmdf);
            }
        }

        public byte[] GenerateShaderOptions(string options) 
        {
            List<byte> optionsData = new List<byte>();

            List<string> optionsList = options.Split(new char[] {' '}).ToList();

            for (int i = 0; i < optionsList.Count; i++) 
            {
                var option = byte.Parse(optionsList[i]);

                optionsData.Add(option);
            }

            return optionsData.ToArray();
        }
    }
}