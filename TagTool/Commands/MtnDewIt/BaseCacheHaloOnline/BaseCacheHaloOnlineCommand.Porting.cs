using TagTool.Commands.Common;
using TagTool.Commands.Porting;

namespace TagTool.Commands.Tags 
{
    partial class BaseCacheHaloOnlineCommand : Command
    {
        public void portTagData() 
        {
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, h3_mainmenu));
            CommandRunner.Current.RunCommand($@"porttag autorescalegui ui\main_menu.wgtz"); // Mainmenu UI tags
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, sandbox));
            CommandRunner.Current.RunCommand($@"porttag autorescalegui ui\multiplayer.wgtz"); // Multiplayer UI tags
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, citadel));
            CommandRunner.Current.RunCommand($@"porttag autorescalegui ui\single_player.wgtz"); // Singleplayer UI tags
            ContextStack.Pop();
        }
    }
}