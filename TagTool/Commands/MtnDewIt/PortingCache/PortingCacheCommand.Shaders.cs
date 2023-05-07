using System;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        public void GenerateRenderMethods()
        {
            CommandRunner.Current.RunCommand($@"generatermdf shader");
            CommandRunner.Current.RunCommand($@"generatermdf beam");
            CommandRunner.Current.RunCommand($@"generatermdf contrail");
            CommandRunner.Current.RunCommand($@"generatermdf decal");
            CommandRunner.Current.RunCommand($@"generatermdf halogram");
            CommandRunner.Current.RunCommand($@"generatermdf light_volume");
            CommandRunner.Current.RunCommand($@"generatermdf particle");
            CommandRunner.Current.RunCommand($@"generatermdf terrain");
            CommandRunner.Current.RunCommand($@"generatermdf cortana");
            CommandRunner.Current.RunCommand($@"generatermdf water");
            CommandRunner.Current.RunCommand($@"generatermdf black");
            CommandRunner.Current.RunCommand($@"generatermdf screen");
            CommandRunner.Current.RunCommand($@"generatermdf custom");
            CommandRunner.Current.RunCommand($@"generatermdf foliage");
            CommandRunner.Current.RunCommand($@"generatermdf zonly");
        }

        //TODO: Generate these in real time (either by a C# tag structure, or the shader generator, assuming support is eventually added for generating these shader types) rather than overiting using exported tag files
        public void OverwriteGlobalVertexShaders() 
        {
            string tagDirectory = Program.TagToolDirectory + @"\Tools\PortingCache\Tags\glvs\";

            CommandRunner.Current.RunCommand($"importtag shaders\\halogram_shared_vertex_shaders.global_vertex_shader \"{tagDirectory}halogram.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\beam_shared_vertex_shaders.global_vertex_shader \"{tagDirectory}beam.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\contrail_shared_vertex_shaders.global_vertex_shader \"{tagDirectory}contrail.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\light_volume_shared_vertex_shaders.global_vertex_shader \"{tagDirectory}light_volume.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\particle_shared_vertex_shaders.global_vertex_shader \"{tagDirectory}particle.glvs\"");
            CommandRunner.Current.RunCommand($"importtag shaders\\screen_shared_vertex_shaders.global_vertex_shader \"{tagDirectory}screen.glvs\"");
        }
    }
}