using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_main_menu_user_interface_globals_definition : TagFile
    {
        public ui_main_menu_user_interface_globals_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<UserInterfaceGlobalsDefinition>($@"ui\main_menu");
            var wgtz = CacheContext.Deserialize<UserInterfaceGlobalsDefinition>(Stream, tag);
            wgtz.SharedGlobals = GetCachedTag<UserInterfaceSharedGlobalsDefinition>($@"ui\ui_shared_globals");
            wgtz.MpVariantSettingsUi = GetCachedTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\multiplayer_editable_settings");
            wgtz.GameHopperDescriptions = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\matchmaking_hopper_descriptions");
            wgtz.ScreenWidgets = new List<UserInterfaceGlobalsDefinition.ScreenWidget>
            {
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\game_browser\game_browser_search_criteria"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\main_menu\main_menu"),
                },
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
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_multiplayer\start_menu_game_multiplayer"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings\start_menu_settings"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots\start_menu_hq_screenshots"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots_viewer\start_menu_hq_screenshots_viewer"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots\start_menu_hq_screenshots_option"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq\start_menu_headquarters"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_transfers\start_menu_hq_transfers"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_transfers\start_menu_hq_transfers_item_selected"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record\start_menu_hq_service_record"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls\start_menu_settings_controls"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_thumbstick\start_menu_settings_controls_thumbstick"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_button\start_menu_settings_controls_button"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance\start_menu_settings_appearance"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance_colors\start_menu_settings_appearance_colors"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance_emblem\start_menu_settings_appearance_emblem"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance_model\start_menu_settings_appearance_model"),
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
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_film_autosave\start_menu_settings_film_autosave"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\e3\e3_demo"),
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
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog_four"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\spartan_program\spartan_milestone"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\spartan_program\spartan_rank"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_difficulty"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_level"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_loading"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_campaign"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_matchmaking"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_multiplayer"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_mapeditor"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_theater"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\pregame_selection"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\maximum_party_size\maximum_party_size"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\switch_lobby\pregame_switch_lobby"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    //Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\player_select"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\game_browser\game_browser"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\postgame_lobby\postgame_lobby"),
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
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\game_details\game_details"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\alpha_legal\alpha_legal"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\alpha_locked_down\alpha_locked_down"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\alpha_motd\alpha_motd"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\matchmaking\matchmaking_match_found"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\matchmaking\matchmaking_searching"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\game_options\game_options_screen"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    //Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\carnage_report\carnage_report"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    //Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\carnage_report_player_details"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\advanced_screen\advanced_matchmaking_options"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {

                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_screen"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_settings"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots_viewer\screenshots_file_share_previewer"),
                },



                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_survival"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\pregame_survival_level_selection"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\survival_select_difficulty"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\survival_select_skulls"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_scoring"),
                },
                new UserInterfaceGlobalsDefinition.ScreenWidget
                {
                    Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_skulls"),
                },
            };
            CacheContext.Serialize(Stream, tag, wgtz);
        }
    }
}
