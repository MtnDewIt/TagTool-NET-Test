using System;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        public void GenerateRenderMethods()
        {
            // TODO: Investigate the rest of the MS23 render_method_defintions for issues or edge cases

            CommandRunner.Current.RunCommand($@"generatermdf shader"); // This the only render_method_definition that needs to be regenerated, as it has visible graphical issues
            //CommandRunner.Current.RunCommand($@"generatermdf beam");
            //CommandRunner.Current.RunCommand($@"generatermdf contrail");
            //CommandRunner.Current.RunCommand($@"generatermdf decal");
            //CommandRunner.Current.RunCommand($@"generatermdf halogram");
            //CommandRunner.Current.RunCommand($@"generatermdf light_volume");
            //CommandRunner.Current.RunCommand($@"generatermdf particle");
            //CommandRunner.Current.RunCommand($@"generatermdf terrain");
            //CommandRunner.Current.RunCommand($@"generatermdf cortana");
            //CommandRunner.Current.RunCommand($@"generatermdf water");
            //CommandRunner.Current.RunCommand($@"generatermdf black");
            //CommandRunner.Current.RunCommand($@"generatermdf screen");
            //CommandRunner.Current.RunCommand($@"generatermdf custom");
            //CommandRunner.Current.RunCommand($@"generatermdf foliage");
            //CommandRunner.Current.RunCommand($@"generatermdf zonly");
        }
    }
}