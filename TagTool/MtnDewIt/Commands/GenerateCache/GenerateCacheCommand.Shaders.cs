using TagTool.Commands.Common;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void GenerateRenderMethods()
        {
            CommandRunner.Current.RunCommand($@"generatermdf shader");
            CommandRunner.Current.RunCommand($@"generatermdf halogram");
        }
    }
}