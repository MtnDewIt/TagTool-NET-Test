using System;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        public void GenerateRenderMethods()
        {
            CommandRunner.Current.RunCommand($@"generatermdf shader");
            CommandRunner.Current.RunCommand($@"generatermdf halogram");
        }
    }
}