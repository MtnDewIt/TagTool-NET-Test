using System.Collections.Generic;
using System.Linq;
using TagTool.Commands.Common;
using TagTool.Commands.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags 
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
            CommandRunner.Current.RunCommand($@"recompileshaders shader");
            CommandRunner.Current.RunCommand($@"recompileshaders beam");
            CommandRunner.Current.RunCommand($@"recompileshaders contrail");
            CommandRunner.Current.RunCommand($@"recompileshaders decal");
            //CommandRunner.Current.RunCommand($@"recompileshaders halogram"); // Crashes :/
            CommandRunner.Current.RunCommand($@"recompileshaders light_volume");
            CommandRunner.Current.RunCommand($@"recompileshaders particle");
            CommandRunner.Current.RunCommand($@"recompileshaders terrain");
            CommandRunner.Current.RunCommand($@"recompileshaders custom");
            //CommandRunner.Current.RunCommand($@"recompileshaders water "); // Crashes :/
            CommandRunner.Current.RunCommand($@"recompileshaders foliage");
            CommandRunner.Current.RunCommand($@"recompileshaders screen");
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