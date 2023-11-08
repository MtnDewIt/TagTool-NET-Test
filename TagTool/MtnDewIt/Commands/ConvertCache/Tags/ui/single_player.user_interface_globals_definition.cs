using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_single_player_user_interface_globals_definition : TagFile
    {
        public ui_single_player_user_interface_globals_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<UserInterfaceGlobalsDefinition>($@"ui\single_player");
            var wgtz = CacheContext.Deserialize<UserInterfaceGlobalsDefinition>(Stream, tag);
            wgtz.SharedGlobals = GetCachedTag<UserInterfaceSharedGlobalsDefinition>($@"ui\ui_shared_globals");
            wgtz.ScreenWidgets = new List<UserInterfaceGlobalsDefinition.ScreenWidget>
            {
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\start_menu"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_campaign\start_menu_game_campaign"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_saved_film\start_menu_game_saved_films"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings\start_menu_settings"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls\start_menu_settings_controls"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_button\start_menu_settings_controls_button"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_thumbstick\start_menu_settings_controls_thumbstick"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_voice\start_menu_settings_voice"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_camera\start_menu_settings_camera"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_display\start_menu_settings_display"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_nonblocking"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_toast"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_ingame_full"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_ingame_split"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog_four"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\terminals\terminal_screen"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\scoreboard\scoreboard"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\scoreboard\scoreboard_half"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\scoreboard_player_select"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_control_pad"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_take_screenshot"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\game_details\game_details"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_splitscreen"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\splitscreen_player_select"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    //Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\carnage_report\campaign_carnage_report"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini_me"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_screen"),
                },
            };
            CacheContext.Serialize(Stream, tag, wgtz);
        }
    }
}
