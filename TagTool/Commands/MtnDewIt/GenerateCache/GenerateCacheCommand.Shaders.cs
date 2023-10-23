using System;
using TagTool.Commands.Common;

namespace TagTool.Commands.MtnDewIt
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