using TagTool.Commands.Common;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheHaloOnlineCommand : Command
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
            CommandRunner.Current.RunCommand($@"recompileshaders particle ");
            CommandRunner.Current.RunCommand($@"recompileshaders terrain ");
            CommandRunner.Current.RunCommand($@"recompileshaders custom ");
            //CommandRunner.Current.RunCommand($@"recompileshaders water "); // Crashes :/
            CommandRunner.Current.RunCommand($@"recompileshaders foliage ");
            CommandRunner.Current.RunCommand($@"recompileshaders screen ");
        }
    }
}