using System;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags
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