using System;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        public void GenerateRenderMethods()
        {
            // TODO: Investigate the rest of the MS23 and MS30 render_method_defintions for issues or edge cases

            CommandRunner.Current.RunCommand($@"generatermdf shader");
            //CommandRunner.Current.RunCommand($@"generatermdf beam");
            //CommandRunner.Current.RunCommand($@"generatermdf contrail");
            //CommandRunner.Current.RunCommand($@"generatermdf decal");
            CommandRunner.Current.RunCommand($@"generatermdf halogram");
            CommandRunner.Current.RunCommand($@"generatermdf light_volume");
            CommandRunner.Current.RunCommand($@"generatermdf particle");
            //CommandRunner.Current.RunCommand($@"generatermdf terrain");
            //CommandRunner.Current.RunCommand($@"generatermdf cortana");
            //CommandRunner.Current.RunCommand($@"generatermdf water");
            //CommandRunner.Current.RunCommand($@"generatermdf black");
            CommandRunner.Current.RunCommand($@"generatermdf screen");
            //CommandRunner.Current.RunCommand($@"generatermdf custom");
            //CommandRunner.Current.RunCommand($@"generatermdf foliage");
            //CommandRunner.Current.RunCommand($@"generatermdf zonly");
        }

        public void OverwriteGlobalVertexShaders()
        {
            CommandRunner.Current.RunCommand($"importtag shaders\\halogram_shared_vertex_shaders.global_vertex_shader \"{Program.TagToolDirectory}\\Tools\\PortingCache\\Tags\\glvs\\halogram.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\light_volume_shared_vertex_shaders.global_vertex_shader \"{Program.TagToolDirectory}\\Tools\\PortingCache\\Tags\\glvs\\light_volume.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\particle_shared_vertex_shaders.global_vertex_shader \"{Program.TagToolDirectory}\\Tools\\PortingCache\\Tags\\glvs\\particle.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\screen_shared_vertex_shaders.global_vertex_shader \"{Program.TagToolDirectory}\\Tools\\PortingCache\\Tags\\glvs\\screen.glvs\"");
        }
    }
}