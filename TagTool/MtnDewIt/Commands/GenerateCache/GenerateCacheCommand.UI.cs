using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
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
                        CacheContext.Serialize(stream, tag, wgtz);
                    }

                    if (tag.IsInGroup("wgtz") && tag.Name == $@"ui\multiplayer")
                    {
                        var wgtz = CacheContext.Deserialize<UserInterfaceGlobalsDefinition>(stream, tag);
                        wgtz.SharedGlobals = GetCachedTag<UserInterfaceSharedGlobalsDefinition>($@"ui\ui_shared_globals");
                        wgtz.ScreenWidgets = new List<UserInterfaceGlobalsDefinition.ScreenWidget>
                        {
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\start_menu"),
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
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\boot_betrayer\boot_betrayer"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_budget_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_editor\start_menu_game_editor"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\observer_camera_list_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_creation_menu"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_properties_menu"),
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
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\popup"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\game_details\game_details"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_saved_film\start_menu_game_saved_films"),
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
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\director\saved_film_snippet_screen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\in_progress\in_progress_mini_me"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_editor\change_gametype"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\start_menu\panes\game_multiplayer\change_team"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_budget_screen_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_creation_menu_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\sandbox_object_properties_menu_splitscreen"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\sandbox_ui\forge_legal"),
                            },
                            new UserInterfaceGlobalsDefinition.ScreenWidget
                            {
                                Widget = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\boot_betrayer\boot_betrayer_splitscreen"),
                            },
                        };
                        CacheContext.Serialize(stream, tag, wgtz);
                    }

                    if (tag.IsInGroup("wgtz") && tag.Name == $@"ui\single_player")
                    {
                        var wgtz = CacheContext.Deserialize<UserInterfaceGlobalsDefinition>(stream, tag);
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
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"main_menu");
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

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\main_menu\main_menu")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling | GuiScreenWidgetDefinition.GuiScreenWidgetFlags.BBackShouldntDisposeScreen;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"main_menu"),
                            Bounds720p = new Rectangle2d(-420, -756, 420, 756),
                            Bounds480i = new Rectangle2d(-315, -420, 315, 420)
                        };
                        scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\main_menu\strings");
                        scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"main_menu_offline");
                        scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
                        {
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\main_menu\main_menu_list"),
                            },
                        };
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            TemplateReference = GetCachedTag<GuiListWidgetDefinition>($@"ui\halox\main_menu\mainmenu_list"),
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.ListWraps,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"main_menu"),
                                                    ScaledPositioning = GuiDefinition.WidgetPositioning.BottomReftCorner,
                                                    Bounds720p = new Rectangle2d(525, 111, 0, 0),
                                                    Bounds480i = new Rectangle2d(409, 63, 0, 0),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"main_menu"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(-42, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(32, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(65, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(98, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(131, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify |GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"start_new_campaign"),
                                                    Bounds720p = new Rectangle2d(595, 761, 682, 1359),
                                                    Bounds480i = new Rectangle2d(467, 320, 538, 774),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\500_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"sidebar_items"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"dim"),
                                                CustomFont = WidgetFontValue.SuperLargeFont,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.RightJustify,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"version_number"),
                                                    RenderDepthBias = -11,
                                                    Bounds720p = new Rectangle2d(699, 102, 738, 489),
                                                    Bounds480i = new Rectangle2d(534, 52, 573, 270),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"eldewrito_version"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"dim"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"channel"),
                                                    RenderDepthBias = -10,
                                                    Bounds720p = new Rectangle2d(477, 102, 780, 505),
                                                    Bounds480i = new Rectangle2d(374, 52, 590, 283),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\mainmenu_bkd"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"channel"),
                                                    RenderDepthBias = -10,
                                                    Bounds720p = new Rectangle2d(780, 102, 840, 505),
                                                    Bounds480i = new Rectangle2d(590, 52, 630, 283),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\bottom_gradient_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.RenderAsScreenBlur,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"channel_blur"),
                                                    RenderDepthBias = -12,
                                                    Bounds720p = new Rectangle2d(477, 102, 840, 505),
                                                    Bounds480i = new Rectangle2d(374, 52, 630, 283),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_slide_up"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"full_black_fade_in"),
                                                    RenderDepthBias = 150,
                                                    Bounds720p = new Rectangle2d(-26, -1, 893, 1526),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\black_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_fade_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        ScaledPositioning = GuiDefinition.WidgetPositioning.RightEdge,
                                        Bounds720p = new Rectangle2d(0, -26, 0, 0),
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"title"),
                                                    Bounds720p = new Rectangle2d(518, 780, 0, 0),
                                                    Bounds480i = new Rectangle2d(408, 337, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\500_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\halo3_logo_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = -1,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"bungie"),
                                                    Bounds720p = new Rectangle2d(721, 1269, 0, 0),
                                                    Bounds480i = new Rectangle2d(551, 669, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\500_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\main_menu\bungielogo"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                    },
                                },
                            },
                        };
                        scn3.ButtonKeys = new List<GuiScreenWidgetDefinition.ButtonKeyLegend>
                        {
                            new GuiScreenWidgetDefinition.ButtonKeyLegend
                            {
                                Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\main_menu\main_menu_offline"),
                            },
                            new GuiScreenWidgetDefinition.ButtonKeyLegend
                            {
                                Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\main_menu\main_menu_online"),
                            },
                        };
                        scn3.OnLoadScriptName = "mainmenu_cam";
                        scn3.ScriptIndex = 47;
                        CacheContext.Serialize(stream, tag, scn3);
                    }



                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\pregame_lobby\switch_lobby\lobbies")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"switch_lobby");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>()
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"campaign"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Value = CacheContext.StringTable.GetStringId($@"campaign_help"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"survival"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Value = CacheContext.StringTable.GetStringId($@"survival_help"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"multiplayer"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Value = CacheContext.StringTable.GetStringId($@"custom_games_help"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"mapeditor"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Value = CacheContext.StringTable.GetStringId($@"editor_help"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\start_menu\panes\settings\sidebar_items") 
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"sidebar_items");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"controls_settings"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"display_group"),
                                        Value = CacheContext.StringTable.GetStringId($@"controls_settings"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"start_menu_settings_controls"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_settings"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"display_group"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_settings"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"start_menu_settings_display"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\start_menu\panes\settings_display\sidebar_items")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"sidebar_items");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_subtitles"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"display_group"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_subtitles"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"spinner"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_subtitles"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_setting_description"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\start_menu\panes\settings_display\spinner_display_subtitles") 
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"display_subtitles");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                IntegerValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"value"),
                                        Value = 0,
                                    },
                                },
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_subtitles_on"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_subtitles_on_help"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                IntegerValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.IntegerValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"value"),
                                        Value = 1,
                                    },
                                },
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_subtitles_off"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"description"),
                                        Value = CacheContext.StringTable.GetStringId($@"display_subtitles_off_help"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\start_menu\panes\settings_display\start_menu_settings_display") 
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.GroupWidgets[1].Definition.TextWidgets[0].Definition.GuiRenderBlock.Bounds720p = new Rectangle2d(147, 65, 422, 603);
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\pregame_lobby\lobby_list_campaign")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"lobby_list");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_lobby"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"select_network_mode"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"network_mode"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"select_skulls"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"select_scoring"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_campaign_level"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"level"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_campaign_difficulty"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"difficulty"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_selected_mod"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"start_game"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("skn3") && tag.Name == $@"ui\halox\campaign\campaign_scoring") 
                    {
                        var skn3 = CacheContext.Deserialize<GuiSkinDefinition>(stream, tag);
                        skn3.TextWidgets = new List<TextWidget>
                        {
                            new TextWidget
                            {
                                Definition = new GuiTextWidgetDefinition
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow | GuiTextWidgetDefinition.GuiTextFlags.AllowListItemToOverrideAnimationSkin,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        RenderDepthBias = 1,
                                        Bounds720p = new Rectangle2d(2, 5, 45, 599),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetStringId($@"name"),
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                        };
                        skn3.BitmapWidgets = new List<BitmapWidget> 
                        {
                            new BitmapWidget
                            {
                                Definition = new GuiBitmapWidgetDefinition
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Bounds720p = new Rectangle2d(0, -9, 32, 598),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\pregame_lobby\switch_lobby\immediate_dismiss_list_bitmaps"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\standard_list\black_bar"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, skn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_campaign")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"pregame_lobby_campaign"),
                        };
                        scn3.ScreenTemplate = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template");
                        scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
                        {
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\lobby_list_campaign"),
                            },
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_constants"),
                            },
                        };
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"template"),
                                    },
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            TemplateReference = GetCachedTag<GuiListWidgetDefinition>($@"ui\halox\pregame_lobby\lobby_ui_list"),
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.ListWraps,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                    Bounds720p = new Rectangle2d(111, 112, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(102, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(144, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(186, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\common\roster\roster"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"roster"),
                                        ScaledPositioning = GuiDefinition.WidgetPositioning.RightEdge,
                                        Bounds720p = new Rectangle2d(84, 1106, 0, 0),
                                        Bounds480i = new Rectangle2d(59, 580, 0, 0),
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"images"),
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                               Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                               GuiRenderBlock = new GuiDefinition
                                               {
                                                   Name = CacheContext.StringTable.GetStringId($@"difficulty"),
                                                   Bounds720p = new Rectangle2d(656, 116, 695, 704),
                                                   AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                               },
                                               ValueIdentifier = CacheContext.StringTable.GetStringId($@"campaign_difficulty"),
                                               TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                               CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                               {
                                                   Name = CacheContext.StringTable.GetStringId($@"campaign_insertion_point"),
                                                   Bounds720p = new Rectangle2d(686, 116, 725, 704),
                                                   AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                               },
                                               ValueIdentifier = CacheContext.StringTable.GetStringId($@"campaign_insertion_point"),
                                               TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                               CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_status"),
                                                    Bounds720p = new Rectangle2d(334, 116, 494, 704),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\lobby_slide_with_alt_flash"),
                                                },
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"map_image"),
                                                    RenderDepthBias = -30,
                                                    Bounds720p = new Rectangle2d(454, 103, 653, 711),
                                                    Bounds480i = new Rectangle2d(333, 72, 531, 679),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"difficulty_image"),
                                                    Bounds720p = new Rectangle2d(467, 118, 637, 288),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\difficulty_large_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = 2,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\map_load"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"precaching"),
                                    },
                                },
                            },
                        };
                        scn3.OnLoadScriptName = "campaign_cam";
                        scn3.ScriptIndex = 48;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\campaign\campaign_select_scoring") 
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"campaign_select_scoring"),
                            Bounds720p = new Rectangle2d(-307, -756, 307, 756),
                        };
                        scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\campaign_settings\strings_campaign_settings");
                        scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"a_select_b_back");
                        scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
                        {
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\campaign\campaign_settings_spinner"),
                            },
                        };
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"scoring_option"),
                                                    Bounds720p = new Rectangle2d(128, 252, 196, 656),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"spinner"),
                                                Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_scoring"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"title"),
                                                    Bounds720p = new Rectangle2d(1, 242, 53, 1275),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"title"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"hilite"),
                                                CustomFont = WidgetFontValue.Title,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Bounds720p = new Rectangle2d(72, 245, 111, 1417),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"metagame_scoring_help"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background"),
                                                    RenderDepthBias = -10,
                                                    Bounds720p = new Rectangle2d(0, 0, 614, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\selection_bkd"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.RenderAsScreenBlur,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background_blur"),
                                                    RenderDepthBias = -21,
                                                    Bounds720p = new Rectangle2d(-118, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"dark_background"),
                                                    RenderDepthBias = -20,
                                                    Bounds720p = new Rectangle2d(-131, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"skull_overline"),
                                                    RenderDepthBias = 5,
                                                    Bounds720p = new Rectangle2d(118, 242, 120, 1261),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\line_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"column_gradient"),
                                                    RenderDepthBias = -9,
                                                    Bounds720p = new Rectangle2d(120, 242, 603, 918),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\third_column"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"player_black"),
                                                    RenderDepthBias = -8,
                                                    Bounds720p = new Rectangle2d(120, 918, 563, 1261),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_75"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"no_skull"),
                                                    RenderDepthBias = 1,
                                                    Bounds720p = new Rectangle2d(131, 997, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\skulls_lg_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = 10,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"selected_otem"),
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"scoring_description"),
                                                    Bounds720p = new Rectangle2d(426, 929, 577, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"scoring_option"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"description"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.Uppercase,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"scoring_name"),
                                                    Bounds720p = new Rectangle2d(393, 929, 433, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"option_display_campaign_scoring"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                },
                            },
                        };
                        scn3.ButtonKeys = new List<GuiScreenWidgetDefinition.ButtonKeyLegend>
                        {
                            new GuiScreenWidgetDefinition.ButtonKeyLegend
                            {
                                Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\campaign\button_key_a_select_b_back"),
                            },
                        };
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\campaign\campaign_select_skulls")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"campaign_select_skulls"),
                            Bounds720p = new Rectangle2d(-307, -756, 307, 756),
                        };
                        scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\campaign_settings\strings_campaign_settings");
                        scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"a_select_b_back");
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"primary_skulls"),
                                                    RenderDepthBias = 50,
                                                    Bounds720p = new Rectangle2d(136, 262, 399, 1181),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"primary_skulls"),
                                                Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_settings_skulls"),
                                                Rows = 2,
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 131, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 262, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 393, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 525, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(131, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(131, 131, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(131, 262, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(131, 393, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(131, 525, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                        new ListWidget
                                        {
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.HorizontalList,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(399, 262, 530, 1181),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_settings_skulls_secondary"),
                                                //Rows = 2, // Add when I get assassin and third person skulls working
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 131, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 262, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 393, 0, 0),
                                                        },
                                                    },

                                                    // Extras in the event I get the assassin and third person skulls working
                                                    // Third Person and Directors Cut Skulls appear irregardless if these items are added
                                                    //new GuiListWidgetDefinition.ListWidgetItem
                                                    //{
                                                    //    Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                    //    GuiRenderBlock = new GuiDefinition
                                                    //    {
                                                    //        Bounds720p = new Rectangle2d(0, 525, 0, 0),
                                                    //    },
                                                    //},
                                                    //new GuiListWidgetDefinition.ListWidgetItem
                                                    //{
                                                    //    Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                    //    GuiRenderBlock = new GuiDefinition
                                                    //    {
                                                    //        Bounds720p = new Rectangle2d(131, 0, 0, 0),
                                                    //    },
                                                    //},
                                                },
                                            },
                                        },
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"title"),
                                                    Bounds720p = new Rectangle2d(1, 242, 53, 1275),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"title"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"hilite"),
                                                CustomFont = WidgetFontValue.Title,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Bounds720p = new Rectangle2d(72, 245, 111, 1417),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skulls_help"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background"),
                                                    RenderDepthBias = -10,
                                                    Bounds720p = new Rectangle2d(0, 0, 614, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\selection_bkd"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.RenderAsScreenBlur,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background_blur"),
                                                    RenderDepthBias = -21,
                                                    Bounds720p = new Rectangle2d(-118, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"dark_background"),
                                                    RenderDepthBias = -20,
                                                    Bounds720p = new Rectangle2d(-131, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"skull_overline"),
                                                    RenderDepthBias = 5,
                                                    Bounds720p = new Rectangle2d(118, 242, 120, 1261),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\line_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"column_gradient"),
                                                    RenderDepthBias = -9,
                                                    Bounds720p = new Rectangle2d(120, 242, 603, 918),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\third_column"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"player_black"),
                                                    RenderDepthBias = -8,
                                                    Bounds720p = new Rectangle2d(120, 918, 563, 1261),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_75"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"no_skull"),
                                                    RenderDepthBias = 1,
                                                    Bounds720p = new Rectangle2d(131, 997, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\skulls_lg_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = 10,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"selected_otem"),
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"primary_status"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(525, 929, 564, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"primary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_status"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"primary_skull_description"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(426, 929, 525, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"primary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_description"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"primary_skull_name"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(393, 929, 433, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"primary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_name"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify |  GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_status"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(525, 929, 564, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_status"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skull_description"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(426, 929, 525, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_description"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skull_name"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(393, 929, 433, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_name"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.SpriteFromExportedInteger,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"primary_skulls"),
                                                    RenderDepthBias = 3,
                                                    Bounds720p = new Rectangle2d(131, 997, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\skulls_lg_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"primary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"primary_skull_image"),
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.SpriteFromExportedInteger,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                    RenderDepthBias = 3,
                                                    Bounds720p = new Rectangle2d(131, 997, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\secondary_skulls_lg_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"secondary_skull_image"),
                                            },
                                        },
                                    },
                                },
                            },
                        };
                        scn3.ButtonKeys = new List<GuiScreenWidgetDefinition.ButtonKeyLegend>
                        {
                            new GuiScreenWidgetDefinition.ButtonKeyLegend
                            {
                                Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\campaign\button_key_a_select_b_back"),
                            },
                        };
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    }



                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\pregame_lobby\lobby_list_survival")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"lobby_list");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_lobby"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"select_network_mode"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"network_mode"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"select_skulls_survival"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_campaign_level"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"level"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_campaign_difficulty"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"difficulty"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_selected_mod"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"start_game"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_survival")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"pregame_lobby_survival"),
                        };
                        scn3.ScreenTemplate = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template");
                        scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
                        {
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\lobby_list_survival"),
                            },
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_constants"),
                            },
                        };
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"template"),
                                    },
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            TemplateReference = GetCachedTag<GuiListWidgetDefinition>($@"ui\halox\pregame_lobby\lobby_ui_list"),
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.ListWraps,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                    Bounds720p = new Rectangle2d(111, 112, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(102, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(144, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(186, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\common\roster\roster"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"roster"),
                                        ScaledPositioning = GuiDefinition.WidgetPositioning.RightEdge,
                                        Bounds720p = new Rectangle2d(84, 1106, 0, 0),
                                        Bounds480i = new Rectangle2d(59, 580, 0, 0),
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"images"),
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"difficulty"),
                                                    Bounds720p = new Rectangle2d(656, 116, 695, 704),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"survival_difficulty"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_status"),
                                                    Bounds720p = new Rectangle2d(334, 116, 494, 704),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\lobby_slide_with_alt_flash"),
                                                },
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"map_image"),
                                                    RenderDepthBias = -30,
                                                    Bounds720p = new Rectangle2d(454, 103, 653, 711),
                                                    Bounds480i = new Rectangle2d(333, 72, 531, 679),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"difficulty_image"),
                                                    Bounds720p = new Rectangle2d(467, 118, 637, 288),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\difficulty_large_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = 2,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\map_load"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"precaching"),
                                    },
                                },
                            },
                        };
                        scn3.OnLoadScriptName = "campaign_cam";
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\selection\pregame_survival_level_selection")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"survival_select_level"),
                            Bounds720p = new Rectangle2d(-307, -756, 307, 756),
                        };
                        scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\strings_level");
                        scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"a_select_b_back");
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"level"),
                                                    RenderDepthBias = 10,
                                                    Bounds720p = new Rectangle2d(70, 245, 0, 0),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"level"),
                                                Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_select_level"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(102, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(136, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(170, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(204, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(238, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(273, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(307, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(341, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(375, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(409, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(443, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(477, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"title"),
                                                    RenderDepthBias = 15,
                                                    Bounds720p = new Rectangle2d(1, 242, 53, 1417),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"title"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"hilite"),
                                                CustomFont = WidgetFontValue.Title,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"description"),
                                                    RenderDepthBias = 15,
                                                    Bounds720p = new Rectangle2d(225, 883, 525, 1266),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"description"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background"),
                                                    RenderDepthBias = -19,
                                                    Bounds720p = new Rectangle2d(0, 0, 614, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\selection_bkd"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"level_image"),
                                                    RenderDepthBias = 5,
                                                    Bounds720p = new Rectangle2d(86, 883, 225, 1256),
                                                    Bounds480i = new Rectangle2d(57, 620, 175, 988),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"level_locked"),
                                                    RenderDepthBias = 5,
                                                    Bounds720p = new Rectangle2d(86, 883, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\locked_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.RenderAsScreenBlur,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background_blur"),
                                                    RenderDepthBias = -21,
                                                    Bounds720p = new Rectangle2d(-157, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_50"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background_darkening"),
                                                    RenderDepthBias = -20,
                                                    Bounds720p = new Rectangle2d(-157, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"level_image_background"),
                                                    RenderDepthBias = -15,
                                                    Bounds720p = new Rectangle2d(70, 872, 603, 1266),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\third_column"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                    },
                                },
                            },
                        };
                        scn3.ButtonKeys = new List<GuiScreenWidgetDefinition.ButtonKeyLegend>
                        {
                            new GuiScreenWidgetDefinition.ButtonKeyLegend
                            {
                                Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\campaign\button_key_a_select_b_back"),
                            },
                        };
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\selection\survival_select_difficulty")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"survival_select_difficulty"),
                            Bounds720p = new Rectangle2d(-307, -756, 307, 756),
                        };
                        scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\strings_difficulty");
                        scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"a_select_b_back");
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"difficulty"),
                                                    Bounds720p = new Rectangle2d(70, 245, 0, 0),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"difficulty"),
                                                Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_select_difficulty"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(102, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"title"),
                                                    Bounds720p = new Rectangle2d(1, 242, 53, 1275),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"title"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"hilite"),
                                                CustomFont = WidgetFontValue.Title,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"description"),
                                                    Bounds720p = new Rectangle2d(343, 652, 561, 1266),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"description"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background"),
                                                    RenderDepthBias = -9,
                                                    Bounds720p = new Rectangle2d(0, 0, 614, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\selection_bkd"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"difficulty_image"),
                                                    RenderDepthBias = 5,
                                                    Bounds720p = new Rectangle2d(70, 652, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\difficulty_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.RenderAsScreenBlur,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background_blur"),
                                                    RenderDepthBias = -11,
                                                    Bounds720p = new Rectangle2d(-157, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background_darkening"),
                                                    RenderDepthBias = -10,
                                                    Bounds720p = new Rectangle2d(-157, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                    },
                                },
                            },
                        };
                        scn3.ButtonKeys = new List<GuiScreenWidgetDefinition.ButtonKeyLegend>
                        {
                            new GuiScreenWidgetDefinition.ButtonKeyLegend
                            {
                                Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\campaign\button_key_a_select_b_back"),
                            },
                        };
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\selection\survival_select_skulls")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"survival_select_skulls"),
                            Bounds720p = new Rectangle2d(-307, -756, 307, 756),
                        };
                        scn3.StringList = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\campaign\campaign_settings\strings_campaign_settings");
                        scn3.InitialButtonKeyName = CacheContext.StringTable.GetStringId($@"a_select_b_back");
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.HorizontalList,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                    Bounds720p = new Rectangle2d(136, 262, 399, 1181),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                Skin = GetCachedTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_settings_skulls_secondary"),
                                                //Rows = 2, // Add when I get assassin and third person skulls working
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 131, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 262, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 393, 0, 0),
                                                        },
                                                    },

                                                    // Extras in the event I get the assassin and third person skulls working
                                                    // Third Person and Directors Cut Skulls appear irregardless if these items are added
                                                    //new GuiListWidgetDefinition.ListWidgetItem
                                                    //{
                                                    //    Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                    //    GuiRenderBlock = new GuiDefinition
                                                    //    {
                                                    //        Bounds720p = new Rectangle2d(0, 525, 0, 0),
                                                    //    },
                                                    //},
                                                    //new GuiListWidgetDefinition.ListWidgetItem
                                                    //{
                                                    //    Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                    //    GuiRenderBlock = new GuiDefinition
                                                    //    {
                                                    //        Bounds720p = new Rectangle2d(131, 0, 0, 0),
                                                    //    },
                                                    //},
                                                },
                                            },
                                        },
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"title"),
                                                    Bounds720p = new Rectangle2d(1, 242, 53, 1275),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"title"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"hilite"),
                                                CustomFont = WidgetFontValue.Title,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Bounds720p = new Rectangle2d(72, 245, 111, 1417),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skulls_help"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background"),
                                                    RenderDepthBias = -10,
                                                    Bounds720p = new Rectangle2d(0, 0, 614, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\selection_bkd"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.RenderAsScreenBlur,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"background_blur"),
                                                    RenderDepthBias = -21,
                                                    Bounds720p = new Rectangle2d(-118, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"dark_background"),
                                                    RenderDepthBias = -20,
                                                    Bounds720p = new Rectangle2d(-131, 0, 840, 1512),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_25"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"skull_overline"),
                                                    RenderDepthBias = 5,
                                                    Bounds720p = new Rectangle2d(118, 242, 120, 1261),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\line_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"column_gradient"),
                                                    RenderDepthBias = -9,
                                                    Bounds720p = new Rectangle2d(120, 242, 603, 918),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\third_column"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"player_black"),
                                                    RenderDepthBias = -8,
                                                    Bounds720p = new Rectangle2d(120, 918, 563, 1261),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\black_75"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"no_skull"),
                                                    RenderDepthBias = 1,
                                                    Bounds720p = new Rectangle2d(131, 997, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\skulls_lg_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = 10,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"selected_item"),
                                    },
                                    TextWidgets = new List<TextWidget>
                                    {                                        
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify |  GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_status"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(525, 929, 564, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_status"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skull_description"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(426, 929, 525, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_description"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedStringId,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skull_name"),
                                                    RenderDepthBias = 30,
                                                    Bounds720p = new Rectangle2d(393, 929, 433, 1250),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\basic_fade"),
                                                },
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"skull_name"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.SpriteFromExportedInteger,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                    RenderDepthBias = 3,
                                                    Bounds720p = new Rectangle2d(131, 997, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\campaign\secondary_skulls_lg_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                ValueOverrideList = CacheContext.StringTable.GetStringId($@"secondary_skulls"),
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"secondary_skull_image"),
                                            },
                                        },
                                    },
                                },
                            },
                        };
                        scn3.ButtonKeys = new List<GuiScreenWidgetDefinition.ButtonKeyLegend>
                        {
                            new GuiScreenWidgetDefinition.ButtonKeyLegend
                            {
                                Definition = GetCachedTag<GuiButtonKeyDefinition>($@"ui\halox\campaign\button_key_a_select_b_back"),
                            },
                        };
                        scn3.ScriptIndex = -1;
                        CacheContext.Serialize(stream, tag, scn3);
                    } 



                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\pregame_lobby\lobby_list_multiplayer")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"lobby_list");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_lobby"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"select_network_mode"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"network_mode"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_multiplayer_game"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"variant"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_multiplayer_map"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"map"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_selected_mod"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"start_game"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"advanced_options"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_multiplayer")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"pregame_lobby_multiplayer"),
                        };
                        scn3.ScreenTemplate = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template");
                        scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
                        {
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\lobby_list_multiplayer"),
                            },
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_constants"),
                            },
                        };
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"template"),
                                    },
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            TemplateReference = GetCachedTag<GuiListWidgetDefinition>($@"ui\halox\pregame_lobby\lobby_ui_list"),
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.ListWraps,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                    Bounds720p = new Rectangle2d(111, 112, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(102, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(144, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(186, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\common\roster\roster"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"roster"),
                                        ScaledPositioning = GuiDefinition.WidgetPositioning.RightEdge,
                                        Bounds720p = new Rectangle2d(84, 1106, 0, 0),
                                        Bounds480i = new Rectangle2d(59, 580, 0, 0),
                                    },

                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"multiplayer_game_name"),
                                                    Bounds720p = new Rectangle2d(656, 116, 715, 704),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"multiplayer_game_name"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_status"),
                                                    Bounds720p = new Rectangle2d(334, 116, 494, 704),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\lobby_slide_with_alt_flash"),
                                                },
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"map_image"),
                                                    RenderDepthBias = -30,
                                                    Bounds720p = new Rectangle2d(454, 103, 653, 711),
                                                    Bounds480i = new Rectangle2d(333, 72, 531, 679),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"gametype_image"),
                                                    Bounds720p = new Rectangle2d(467, 118, 637, 288),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\gametypes_large_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = 1,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\map_load"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"precaching"),
                                    },
                                },
                            },
                        };
                        scn3.OnLoadScriptName = "custom_cam";
                        scn3.ScriptIndex = 50;
                        CacheContext.Serialize(stream, tag, scn3);
                    }



                    if (tag.IsInGroup("dsrc") && tag.Name == $@"ui\halox\pregame_lobby\lobby_list_mapeditor")
                    {
                        var dsrc = CacheContext.Deserialize<GuiDatasourceDefinition>(stream, tag);
                        dsrc.Name = CacheContext.StringTable.GetStringId($@"lobby_list");
                        dsrc.Elements = new List<GuiDatasourceDefinition.DatasourceElementBlock>
                        {
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_lobby"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"select_network_mode"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"network_mode"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_mapeditor_map"),
                                    },
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"target"),
                                        Value = CacheContext.StringTable.GetStringId($@"map"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"switch_selected_mod"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"start_game"),
                                    },
                                },
                            },
                            new GuiDatasourceDefinition.DatasourceElementBlock
                            {
                                StringidValues = new List<GuiDatasourceDefinition.DatasourceElementBlock.StringidValue>
                                {
                                    new GuiDatasourceDefinition.DatasourceElementBlock.StringidValue
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"name"),
                                        Value = CacheContext.StringTable.GetStringId($@"advanced_options"),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, dsrc);
                    }

                    if (tag.IsInGroup("scn3") && tag.Name == $@"ui\halox\pregame_lobby\pregame_lobby_mapeditor")
                    {
                        var scn3 = CacheContext.Deserialize<GuiScreenWidgetDefinition>(stream, tag);
                        scn3.Flags = GuiScreenWidgetDefinition.GuiScreenWidgetFlags.DoNotApplyOldContentUpscaling;
                        scn3.GuiRenderBlock = new GuiDefinition
                        {
                            Name = CacheContext.StringTable.GetStringId($@"pregame_lobby_mapeditor"),
                        };
                        scn3.ScreenTemplate = GetCachedTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template");
                        scn3.DebugDatasources = new List<GuiScreenWidgetDefinition.DataSource>
                        {
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\lobby_list_mapeditor"),
                            },
                            new GuiScreenWidgetDefinition.DataSource
                            {
                                DataSourceTag = GetCachedTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_constants"),
                            },
                        };
                        scn3.GroupWidgets = new List<GuiScreenWidgetDefinition.GroupWidget>
                        {
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_template"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"template"),
                                    },
                                    ListWidgets = new List<ListWidget>
                                    {
                                        new ListWidget
                                        {
                                            TemplateReference = GetCachedTag<GuiListWidgetDefinition>($@"ui\halox\pregame_lobby\lobby_ui_list"),
                                            Definition = new GuiListWidgetDefinition
                                            {
                                                Flags = GuiListWidgetDefinition.GuiListWidgetFlags.DoNotApplyOldContentUpscaling | GuiListWidgetDefinition.GuiListWidgetFlags.ListWraps,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                    Bounds720p = new Rectangle2d(111, 112, 0, 0),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\mainmenu_fade"),
                                                },
                                                DataSourceName = CacheContext.StringTable.GetStringId($@"lobby_list"),
                                                Items = new List<GuiListWidgetDefinition.ListWidgetItem>
                                                {
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(0, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(34, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(68, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(102, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(144, 0, 0, 0),
                                                        },
                                                    },
                                                    new GuiListWidgetDefinition.ListWidgetItem
                                                    {
                                                        Flags = GuiListWidgetDefinition.ListWidgetItem.ListItemWidgetFlags.DoNotApplyOldContentUpscaling,
                                                        GuiRenderBlock = new GuiDefinition
                                                        {
                                                            Bounds720p = new Rectangle2d(186, 0, 0, 0),
                                                        },
                                                    },
                                                },
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\common\roster\roster"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"roster"),
                                        ScaledPositioning = GuiDefinition.WidgetPositioning.RightEdge,
                                        Bounds720p = new Rectangle2d(84, 1106, 0, 0),
                                        Bounds480i = new Rectangle2d(59, 580, 0, 0),
                                    },

                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    TextWidgets = new List<TextWidget>
                                    {
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"mapeditor_map_name"),
                                                    Bounds720p = new Rectangle2d(656, 116, 715, 704),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                ValueIdentifier = CacheContext.StringTable.GetStringId($@"mapeditor_map_name"),
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                        new TextWidget
                                        {
                                            Definition = new GuiTextWidgetDefinition
                                            {
                                                Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.LargeTextBuffer255Chars | GuiTextWidgetDefinition.GuiTextFlags.NoDropShadow,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"lobby_status"),
                                                    Bounds720p = new Rectangle2d(334, 116, 494, 704),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\global_animations\animation_collections\lobby_slide_with_alt_flash"),
                                                },
                                                TextColorPreset = CacheContext.StringTable.GetStringId($@"ice"),
                                                CustomFont = WidgetFontValue.BodyText,
                                            },
                                        },
                                    },
                                    BitmapWidgets = new List<BitmapWidget>
                                    {
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"map_image"),
                                                    RenderDepthBias = -30,
                                                    Bounds720p = new Rectangle2d(454, 103, 653, 711),
                                                    Bounds480i = new Rectangle2d(333, 72, 531, 679),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                            },
                                        },
                                        new BitmapWidget
                                        {
                                            Definition = new GuiBitmapWidgetDefinition
                                            {
                                                Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                                GuiRenderBlock = new GuiDefinition
                                                {
                                                    Name = CacheContext.StringTable.GetStringId($@"gametype_image"),
                                                    Bounds720p = new Rectangle2d(467, 118, 637, 288),
                                                    AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\main_menu\animations\lobby_slide"),
                                                },
                                                Bitmap = GetCachedTag<Bitmap>($@"ui\halox\pregame_lobby\gametypes_large_ui"),
                                                BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                                InitialSpriteFrame = 5,
                                            },
                                        },
                                    },
                                },
                            },
                            new GuiScreenWidgetDefinition.GroupWidget
                            {
                                TemplateReference = GetCachedTag<GuiGroupWidgetDefinition>($@"ui\halox\pregame_lobby\map_load"),
                                Definition = new GuiGroupWidgetDefinition
                                {
                                    Flags = GuiGroupWidgetDefinition.GuiGroupWidgetFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"precaching"),
                                    },
                                },
                            },
                        };
                        scn3.OnLoadScriptName = "editor_cam";
                        scn3.ScriptIndex = 52;
                        CacheContext.Serialize(stream, tag, scn3);
                    }



                    if (tag.IsInGroup("skn3") && tag.Name == $@"ui\halox\common\roster\roster")
                    {
                        var skn3 = CacheContext.Deserialize<GuiSkinDefinition>(stream, tag);
                        skn3.TextWidgets = new List<TextWidget>()
                        {
                            new TextWidget()
                            {
                                Definition = new GuiTextWidgetDefinition()
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name"),
                                        RenderDepthBias = 89,
                                        Bounds720p = new Rectangle2d(5, 0, 43, 265),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_name"),
                                    },
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                            new TextWidget()
                            {
                                Definition = new GuiTextWidgetDefinition()
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedText,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("name_hilite"),
                                        RenderDepthBias = 100,
                                        Bounds720p = new Rectangle2d(-9, 9, 32, 274),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_name_hilite"),
                                    },
                                    ValueOverrideList = CacheContext.StringTable.GetStringId("player_name"),
                                    ValueIdentifier = CacheContext.StringTable.GetStringId("player_name"),
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                            new TextWidget()
                            {
                                Definition = new GuiTextWidgetDefinition()
                                {
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("player_found"),
                                    },
                                },
                            },
                            new TextWidget()
                            {
                                Definition = new GuiTextWidgetDefinition()
                                {
                                    Flags = GuiTextWidgetDefinition.GuiTextFlags.DoNotApplyOldContentUpscaling | GuiTextWidgetDefinition.GuiTextFlags.LeftJustify | GuiTextWidgetDefinition.GuiTextFlags.Uppercase | GuiTextWidgetDefinition.GuiTextFlags.StringFromExportedText,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("service_tag"),
                                        RenderDepthBias = 100,
                                        Bounds720p = new Rectangle2d(19, 9, 60, 274),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\rank_hilite"),
                                    },
                                    ValueIdentifier = CacheContext.StringTable.GetStringId("service_tag"),
                                    CustomFont = WidgetFontValue.BodyText,
                                },
                            },
                        };
                        skn3.BitmapWidgets = new List<BitmapWidget>()
                        {
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("base_color"),
                                        RenderDepthBias = 83,
                                        Bounds720p = new Rectangle2d(0, -47, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_bitmap"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\roster_unfocused_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("base_color_hilite"),
                                        RenderDepthBias = 93,
                                        Bounds720p = new Rectangle2d(-15, -47, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_hilite"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\roster_focused_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("player_emblem"),
                                        RenderDepthBias = 87,
                                        Bounds720p = new Rectangle2d(2, -42, 36, -7),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_emblem"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\emblems"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("player_emblem_hilite"),
                                        RenderDepthBias = 97,
                                        Bounds720p = new Rectangle2d(-5, -43, 43, 5),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\emblem_hilite"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\common_bitmaps\emblems"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("skill_level"),
                                    },
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("skill_level_hilite"),
                                    },
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("experience"),
                                        RenderDepthBias = 88,
                                        Bounds720p = new Rectangle2d(3, 296, 35, 318),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\rating_list_bitmap"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\exp_med_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling | GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.ScaleToFitBounds,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("experience_hilite"),
                                        RenderDepthBias = 98,
                                        Bounds720p = new Rectangle2d(0, 295, 39, 322),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\rating_hilite"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\exp_med_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("ring_of_light"),
                                        RenderDepthBias = 85,
                                        Bounds720p = new Rectangle2d(3, -82, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\roster_fade"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\ringspeak_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("player_found"),
                                    },
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    Flags = GuiBitmapWidgetDefinition.BitmapWidgetDefinitionFlags.DoNotApplyOldContentUpscaling,
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("rank_tray"),
                                        RenderDepthBias = 85,
                                        Bounds720p = new Rectangle2d(0, 253, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_list_bitmap"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\rank_tray_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                },
                            },
                            new BitmapWidget()
                            {
                                Definition = new GuiBitmapWidgetDefinition()
                                {
                                    GuiRenderBlock = new GuiDefinition()
                                    {
                                        Name = CacheContext.StringTable.GetStringId("rank_tray_hilite"),
                                        RenderDepthBias = 95,
                                        Bounds720p = new Rectangle2d(-10, 253, 0, 0),
                                        AnimationCollection = GetCachedTag<GuiWidgetAnimationCollectionDefinition>($@"ui\halox\common\roster\animations\mp_hilite"),
                                    },
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\halox\common\roster\rank_tray_ui"),
                                    BlendMethod = GuiBitmapWidgetDefinition.BlendMethodValue.AlphaBlend,
                                    InitialSpriteFrame = 1,
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, skn3);
                    }
                }
            }
        }
    }
} 