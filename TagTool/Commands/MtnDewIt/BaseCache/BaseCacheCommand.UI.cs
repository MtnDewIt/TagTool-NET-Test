using System.Collections.Generic;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheCommand : Command
    {
        public void UserInterfaceGlobalsSetup() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("wgtz") && tag.Name == $@"ui\main_menu") 
                    {
                        var wgtz = CacheContext.Deserialize<UserInterfaceGlobalsDefinition>(stream, tag);
                        wgtz.SharedGlobals = CacheContext.TagCache.GetTag<UserInterfaceSharedGlobalsDefinition>($@"ui\ui_shared_globals");
                        wgtz.MpVariantSettingsUi = CacheContext.TagCache.GetTag<MultiplayerVariantSettingsInterfaceDefinition>($@"multiplayer\game_variant_settings\multiplayer_editable_settings");
                        wgtz.GameHopperDescriptions = CacheContext.TagCache.GetTag<MultilingualUnicodeStringList>($@"multiplayer\matchmaking_hopper_descriptions");
                        wgtz.ScreenWidgets = new List<UserInterfaceGlobalsDefinition.ScreenWidget>
                        {
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\game_browser\game_browser_search_criteria"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\main_menu\main_menu"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\start_menu"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_campaign\start_menu_game_campaign"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_multiplayer\start_menu_game_multiplayer"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings\start_menu_settings"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots\start_menu_hq_screenshots"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots_viewer\start_menu_hq_screenshots_viewer"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots\start_menu_hq_screenshots_option"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq\start_menu_headquarters"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_transfers\start_menu_hq_transfers"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_transfers\start_menu_hq_transfers_item_selected"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record\start_menu_hq_service_record"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls\start_menu_settings_controls"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_thumbstick\start_menu_settings_controls_thumbstick"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_button\start_menu_settings_controls_button"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance\start_menu_settings_appearance"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance_colors\start_menu_settings_appearance_colors"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance_emblem\start_menu_settings_appearance_emblem"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_appearance_model\start_menu_settings_appearance_model"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_voice\start_menu_settings_voice"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_camera\start_menu_settings_camera"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_display\start_menu_settings_display"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_film_autosave\start_menu_settings_film_autosave"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\e3\e3_demo"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_nonblocking"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_toast"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog_four"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\spartan_program\spartan_milestone"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\spartan_program\spartan_rank"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_difficulty"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_level"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_loading"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_campaign"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_matchmaking"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_multiplayer"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_mapeditor"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_theater"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\pregame_selection"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\maximum_party_size\maximum_party_size"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\switch_lobby\pregame_switch_lobby"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\player_select"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\game_browser\game_browser"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\postgame_lobby\postgame_lobby"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\game_details\game_details"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alpha_legal\alpha_legal"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alpha_locked_down\alpha_locked_down"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alpha_motd\alpha_motd"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\matchmaking\matchmaking_match_found"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\matchmaking\matchmaking_searching"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\game_options\game_options_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\carnage_report\carnage_report"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\carnage_report_player_details"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\advanced_screen\advanced_matchmaking_options"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {

                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_settings"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\hq_screenshots_viewer\screenshots_file_share_previewer"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, wgtz);
                    }

                    if (tag.IsInGroup("wgtz") && tag.Name == $@"ui\multiplayer") 
                    {
                        var wgtz = CacheContext.Deserialize<UserInterfaceGlobalsDefinition>(stream, tag);
                        wgtz.SharedGlobals = CacheContext.TagCache.GetTag<UserInterfaceSharedGlobalsDefinition>($@"ui\ui_shared_globals");
                        wgtz.ScreenWidgets = new List<UserInterfaceGlobalsDefinition.ScreenWidget>
                        {
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\start_menu"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_multiplayer\start_menu_game_multiplayer"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings\start_menu_settings"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls\start_menu_settings_controls"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_button\start_menu_settings_controls_button"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_thumbstick\start_menu_settings_controls_thumbstick"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_voice\start_menu_settings_voice"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_camera\start_menu_settings_camera"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_display\start_menu_settings_display"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_nonblocking"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_toast"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_ingame_full"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_ingame_split"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog_four"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\boot_betrayer\boot_betrayer"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_budget_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_editor\start_menu_game_editor"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_creation_menu"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_properties_menu"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\scoreboard\scoreboard"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\scoreboard\scoreboard_half"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\scoreboard_player_select"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_control_pad"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_take_screenshot"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\popup"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\game_details\game_details"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_saved_film\start_menu_game_saved_films"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\splitscreen_player_select"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_snippet_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini_me"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_editor\change_gametype"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_multiplayer\change_team"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_budget_screen_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_creation_menu_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_properties_menu_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\forge_legal"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\boot_betrayer\boot_betrayer_splitscreen"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, wgtz);
                    }

                    if (tag.IsInGroup("wgtz") && tag.Name == $@"ui\single_player") 
                    {
                        var wgtz = CacheContext.Deserialize<UserInterfaceGlobalsDefinition>(stream, tag);
                        wgtz.SharedGlobals = CacheContext.TagCache.GetTag<UserInterfaceSharedGlobalsDefinition>($@"ui\ui_shared_globals");
                        wgtz.ScreenWidgets = new List<UserInterfaceGlobalsDefinition.ScreenWidget>
                        {
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\start_menu"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_campaign\start_menu_game_campaign"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_saved_film\start_menu_game_saved_films"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings\start_menu_settings"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls\start_menu_settings_controls"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_button\start_menu_settings_controls_button"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_controls_thumbstick\start_menu_settings_controls_thumbstick"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_voice\start_menu_settings_voice"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_camera\start_menu_settings_camera"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\settings_display\start_menu_settings_display"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_nonblocking"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_toast"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_ingame_full"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\alert\alert_ingame_split"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\dialog\dialog_four"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\terminals\terminal_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\scoreboard\scoreboard"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\scoreboard\scoreboard_half"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\scoreboard_player_select"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_control_pad"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_take_screenshot"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\game_details\game_details"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\common\player_select\splitscreen_player_select"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\carnage_report\campaign_carnage_report"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini_me"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = CacheContext.TagCache.GetTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_screen"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, wgtz);
                    }
                }
            }
        }

        public void applyUIPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\main_menu\main_menu_list")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>()
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("server_browser"),
                                    },
                                }
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("campaign"),
                                    },
                                }
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("multiplayer"),
                                    },
                                }
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("mapeditor"),
                                    },
                                }
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("survival"),
                                    },
                                }
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("customization"),
                                    },
                                }
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("eldewrito_settings"),
                                    },
                                }
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock()
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>()
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        Value = CacheContext.StringTable.GetStringId("exit"),
                                    },
                                }
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }
                }
            }
        }
    }
}