using System;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Commands;
using TagTool.MtnDewIt.Porting;

namespace TagTool.MtnDewIt.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command
    {
        public void PortTagData()
        {
            InitializePortingContext();

            sandbox.SetPortingProperties(audioCodec: Compression.OGG);
            GenerateTag<Bitmap>($@"ui\chud\bitmaps\stamina_icon_elite");
            sandbox.PortTag($@"", $@"ui\chud\elite.chud_definition");
            DuplicateTag(GetCachedTag<ChudDefinition>($@"ui\chud\scoreboard"), $@"ui\chud\scoreboard_elite");
            sandbox.PortTag($@"", $@"sound\dialog\multiplayer_en\juggernaut\juggernaut.sound");

            h3MainMenu.SetPortingProperties(audioCodec: Compression.MP3);
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\ui_shared_globals.user_interface_shared_globals_definition");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_weapons_third_person_camera");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_movement_sprint");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_size");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_model_set");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_model");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\global_options\rounds_reset");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\respawn_options\respawn_spectating");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\ctf\ctf_respawn_on_capture");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_haven_movement");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_haven_movement_time");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_respawn_on_haven_move");
            GenerateTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_scoring_haven_arrival");
            h3MainMenu.PortTag($@"autorescalegui", $@"multiplayer\game_variant_settings\multiplayer_editable_settings.multiplayer_variant_settings_interface_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"multiplayer\matchmaking_hopper_descriptions.multilingual_unicode_string_list");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\alert\alert_nonblocking.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\alert\alert_toast.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\alpha_legal\alpha_legal.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\alpha_locked_down\alpha_locked_down.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\alpha_motd\alpha_motd.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\campaign\campaign_loading.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\campaign\campaign_select_difficulty.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\campaign\campaign_select_level.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\campaign\campaign_settings.gui_screen_widget_definition");
            //h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\carnage_report\carnage_report.gui_screen_widget_definition");
            //h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\common\player_select\carnage_report_player_details.gui_screen_widget_definition");
            //h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\common\player_select\player_select.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\dialog\dialog.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\dialog\dialog_four.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\director\observer_camera_list_screen.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\e3\e3_demo.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\game_browser\game_browser.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\game_browser\game_browser_search_criteria.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\game_details\game_details.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\game_options\game_options_screen.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\in_progress\in_progress.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\in_progress\in_progress_mini.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\main_menu\main_menu.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\matchmaking\matchmaking_match_found.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\matchmaking\matchmaking_searching.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\postgame_lobby\postgame_lobby.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\advanced_screen\advanced_matchmaking_options.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\maximum_party_size\maximum_party_size.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\pregame_lobby_campaign.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\pregame_lobby_mapeditor.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\pregame_lobby_matchmaking.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\pregame_lobby_multiplayer.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\pregame_lobby_theater.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\selection\pregame_selection.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\pregame_lobby\switch_lobby\pregame_switch_lobby.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\spartan_program\spartan_milestone.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\spartan_program\spartan_rank.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\game_campaign\start_menu_game_campaign.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\game_multiplayer\start_menu_game_multiplayer.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq\start_menu_headquarters.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_screenshots\start_menu_hq_screenshots.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_screenshots\start_menu_hq_screenshots_option.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_screenshots_viewer\screenshots_file_share_previewer.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_screenshots_viewer\start_menu_hq_screenshots_viewer.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_service_record\start_menu_hq_service_record.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share_bungie.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share_choose_category.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share_choose_item.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_service_record_file_share\start_menu_hq_service_record_file_share_item_selected.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_transfers\start_menu_hq_transfers.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\hq_transfers\start_menu_hq_transfers_item_selected.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings\start_menu_settings.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_appearance\start_menu_settings_appearance.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_appearance_colors\start_menu_settings_appearance_colors.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_appearance_emblem\start_menu_settings_appearance_emblem.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_appearance_model\start_menu_settings_appearance_model.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_camera\start_menu_settings_camera.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_controls\start_menu_settings_controls.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_controls_button\start_menu_settings_controls_button.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_controls_thumbstick\start_menu_settings_controls_thumbstick.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_display\start_menu_settings_display.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_film_autosave\start_menu_settings_film_autosave.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\settings_voice\start_menu_settings_voice.gui_screen_widget_definition");
            h3MainMenu.PortTag($@"autorescalegui", $@"ui\halox\start_menu\start_menu.gui_screen_widget_definition");

            sandbox.SetPortingProperties(audioCodec: Compression.MP3);
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\alert\alert_ingame_full.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\alert\alert_ingame_split.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\boot_betrayer\boot_betrayer.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\boot_betrayer\boot_betrayer_splitscreen.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\common\player_select\scoreboard_player_select.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\common\player_select\splitscreen_player_select.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\director\observer_camera_list_splitscreen.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\director\popup.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\director\saved_film_control_pad.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\director\saved_film_snippet_screen.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\director\saved_film_take_screenshot.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\in_progress\in_progress_mini_me.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\sandbox_ui\forge_legal.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\sandbox_ui\sandbox_budget_screen.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\sandbox_ui\sandbox_budget_screen_splitscreen.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\sandbox_ui\sandbox_object_creation_menu.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\sandbox_ui\sandbox_object_creation_menu_splitscreen.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\sandbox_ui\sandbox_object_properties_menu.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\sandbox_ui\sandbox_object_properties_menu_splitscreen.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\scoreboard\scoreboard.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\scoreboard\scoreboard_half.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\game_editor\change_gametype.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\game_editor\start_menu_game_editor.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\game_multiplayer\change_team.gui_screen_widget_definition");
            sandbox.PortTag($@"autorescalegui", $@"ui\halox\start_menu\panes\game_saved_film\start_menu_game_saved_films.gui_screen_widget_definition");

            citadel.SetPortingProperties(audioCodec: Compression.MP3);
            //citadel.PortTag($@"autorescalegui", $@"ui\halox\carnage_report\campaign_carnage_report.gui_screen_widget_definition");
            citadel.PortTag($@"autorescalegui", $@"ui\halox\terminals\terminal_screen.gui_screen_widget_definition");

            GenerateTag<GuiDatasourceDefinition>($@"ui\halox\pregame_lobby\lobby_list_survival");
            GenerateTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\pregame_lobby_survival");
            GenerateTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\pregame_survival_level_selection");
            GenerateTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\survival_select_difficulty");
            GenerateTag<GuiScreenWidgetDefinition>($@"ui\halox\pregame_lobby\selection\survival_select_skulls");

            GenerateTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_skulls");
            GenerateTag<GuiSkinDefinition>($@"ui\halox\campaign\campaign_scoring");
            GenerateTag<GuiScreenWidgetDefinition>($@"ui\halox\campaign\campaign_select_scoring");

            GenerateTag<UserInterfaceGlobalsDefinition>($@"ui\main_menu");
            GenerateTag<UserInterfaceGlobalsDefinition>($@"ui\multiplayer");
            GenerateTag<UserInterfaceGlobalsDefinition>($@"ui\single_player");

            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\placeholder");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\armory");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\bunkerworld");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\chillout");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\descent");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\docks");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\fortress");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\ghosttown");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\lockout");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\midship");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sandbox");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sidewinder");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\spacecamp");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\warehouse");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\chill");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\construct");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\cyberdyne");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\deadlock");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\guardian");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\isolation");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\riverworld");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_avalanche");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_edge");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_reactor");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_turf");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\s3d_waterfall");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\salvation");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\shrine");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\snowbound");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\zanzibar");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\005_intro");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\010_jungle");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\020_base");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\030_outskirts");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\040_voi");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\050_floodvoi");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\070_waste");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\100_citadel");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\110_hc");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\120_halo");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\130_epilogue");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\c100");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\c200");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\h100");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\l200");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\l300");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc100");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc110");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc120");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc130");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc140");
            GenerateTag<Bitmap>($@"ui\eldewrito\common\map_bitmaps\sc150");

            sandbox.SetPortingProperties(audioCodec: Compression.OGG);
            sandbox.PortTag($@"", $@"sound\game_sfx\ui\shield_charge_dervish\shield_charge_dervish.sound_looping");
            sandbox.PortTag($@"", $@"sound\game_sfx\ui\shield_low_dervish\shield_low_dervish.sound_looping");
            sandbox.PortTag($@"", $@"sound\game_sfx\ui\shield_depleted_dervish\shield_depleted_dervish.sound_looping");

            GenerateTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
            GenerateTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
            GenerateTag<ShieldImpact>($@"globals\masterchief_3p_shield_impact");
            GenerateTag<ShieldImpact>($@"globals\masterchief_fp_shield_impact");
            GenerateTag<ShieldImpact>($@"globals\elite_3p_shield_impact");
            GenerateTag<ShieldImpact>($@"globals\elite_fp_shield_impact");

            sandbox.SetPortingProperties(audioCodec: Compression.OGG);
            sandbox.PortTag($@"", $@"objects\characters\masterchief\mp_masterchief\fp\fp.mode");
            sandbox.PortTag($@"", $@"objects\characters\masterchief\mp_masterchief\fp_body\fp_body.mode");
            GenerateTag<Light>($@"objects\characters\masterchief\fx\shield\shield_down");
            GenerateRenderMethodTemplate($@"shader", $@"4 1 0 1 1 2 0 0 0 1 0 0");
            sandbox.PortTag($@"", $@"objects\characters\masterchief\shaders\visor.rmsh");
            RenameTag(GetCachedTag<Shader>($@"objects\characters\masterchief\shaders\visor"), $@"objects\characters\masterchief\shaders\mp_visor");
            GenerateTag<Bitmap>($@"objects\characters\masterchief\bitmaps\mp_visor_cc");
            sandbox.PortTag($@"", $@"objects\characters\masterchief\mp_masterchief\mp_masterchief.bipd");
            GenerateTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera");
            GenerateTag<PlayerActionSet>($@"objects\characters\masterchief\mp_masterchief\actions");
            sandbox.PortTag($@"", $@"objects\characters\elite\mp_elite\fp\fp.mode");
            sandbox.PortTag($@"", $@"objects\characters\elite\mp_elite\fp_body\fp_body.mode");
            GenerateTag<Light>($@"objects\characters\dervish\fx\shield\shield_down");
            sandbox.PortTag($@"", $@"objects\characters\elite\mp_elite\mp_elite.bipd");
            GenerateTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera");
            GenerateTag<PlayerActionSet>($@"objects\characters\elite\mp_elite\actions");
            sandbox.PortTag($@"", $@"objects\characters\monitor\monitor_editor.bipd");

            citadel.SetPortingProperties(audioCodec: Compression.OGG);
            citadel.PortTag($@"", $@"objects\characters\dervish\fp\fp.mode");
            citadel.PortTag($@"", $@"objects\characters\dervish\fp_body\fp_body.mode");
            citadel.PortTag($@"", $@"objects\characters\dervish\dervish.bipd");
            citadel.PortTag($@"", $@"objects\characters\elite\fp_arms\fp_arms.mode");
            citadel.PortTag($@"", $@"objects\characters\elite\fp_body\fp_body.mode");
            citadel.PortTag($@"", $@"objects\characters\elite\elite_sp.bipd");
            citadel.PortTag($@"", $@"objects\characters\masterchief\fp\fp.mode");
            citadel.PortTag($@"", $@"objects\characters\masterchief\fp_body\fp_body.mode");
            citadel.PortTag($@"", $@"objects\characters\masterchief\masterchief.bipd");

            haloOnline.SetPortingProperties(audioCodec: Compression.OGG);
            haloOnline.PortTag($@"", $@"camera\biped_assassination_camera.camera_track");
            haloOnline.PortTag($@"", $@"globals\damage_responses\player_assassination.damage_response_definition");
            haloOnline.PortTag($@"", $@"objects\props\human\unsc\spartan_knife\spartan_knife.scenery");
            haloOnline.PortTag($@"", $@"globals\damage_effects\shield_pop_melee.damage_effect");
            haloOnline.PortTag($@"", $@"globals\damage_effects\assassination.damage_effect");
            haloOnline.PortTag($@"", $@"objects\equipment\hologram_equipment\fx\hologram_pop.effect");
            haloOnline.PortTag($@"", $@"fx\shield_impacts\hologram_damage.shield_impact");
            DuplicateTag(GetCachedTag<Biped>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief"), $@"objects\equipment\hologram\bipeds\masterchief_hologram");
            DuplicateTag(GetCachedTag<Model>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief"), $@"objects\equipment\hologram\bipeds\masterchief_hologram");
            DuplicateTag(GetCachedTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite"), $@"objects\equipment\hologram\bipeds\elite_hologram");
            DuplicateTag(GetCachedTag<Model>($@"objects\characters\elite\mp_elite\mp_elite"), $@"objects\equipment\hologram\bipeds\elite_hologram");

            haloOnline.SetPortingProperties(audioCodec: Compression.OGG);
            haloOnline.PortTag($@"replace single", $@"objects\characters\masterchief\masterchief.model_animation_graph");
            haloOnline.PortTag($@"replace single", $@"objects\characters\elite\lipsync\lipsync.model_animation_graph");
            haloOnline.PortTag($@"replace single", $@"objects\characters\elite\elite.model_animation_graph");
            haloOnline.PortTag($@"replace single", $@"objects\characters\dervish\dervish.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\marine\marine.model_animation_graph");

            haloOnline.SetPortingProperties(audioCodec: Compression.OGG);
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\melee\fp_energy_blade\fp_energy_blade.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\melee\fp_gravity_hammer\fp_gravity_hammer.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\multiplayer\fp_assault_bomb\fp_assault_bomb.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\multiplayer\fp_ball\fp_ball.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\multiplayer\fp_flag\fp_flag.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\pistol\fp_excavator\fp_excavator.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\pistol\fp_needler\fp_needler.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\pistol\fp_plasma_pistol\fp_plasma_pistol.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\pistol\fp_magnum\fp_magnum.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_assault_rifle\fp_assault_rifle.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_battle_rifle\fp_battle_rifle.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_beam_rifle\fp_beam_rifle.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_covenant_carbine\fp_covenant_carbine.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_dmr\fp_dmr.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_plasma_rifle\fp_plasma_rifle.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_shotgun\fp_shotgun.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_smg\fp_smg.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\rifle\fp_spike_rifle\fp_spike_rifle.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\support_high\fp_flak_cannon\fp_flak_cannon.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\support_high\fp_rocket_launcher\fp_rocket_launcher.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\support_high\fp_spartan_laser\fp_spartan_laser.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\support_low\fp_brute_shot\fp_brute_shot.model_animation_graph");
            haloOnline.PortTag($@"", $@"objects\characters\dervish\fp\weapons\support_low\fp_sentinel_beam\fp_sentinel_beam.model_animation_graph");

            sandbox.SetPortingProperties(audioCodec: Compression.OGG);
            sandbox.PortTag($@"", $@"objects\equipment\instantcover_equipment\instantcover_equipment_mp.eqip");
            sandbox.PortTag($@"", $@"objects\levels\dlc\shared\damage_sphere\damage_sphere.crate");

            citadel.SetPortingProperties(audioCodec: Compression.OGG);
            citadel.PortTag($@"", $@"objects\equipment\invisibility_equipment\invisibility_equipment.eqip");

            DuplicateTag(GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_initial_spawn_point"), $@"objects\multi\spawning\initial_spawn_point");
            DuplicateTag(GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_respawn_zone"), $@"objects\multi\spawning\respawn_zone");

            halo.SetPortingProperties(audioCodec: Compression.OGG);
            halo.PortTag($@"", $@"objects\equipment\autoturret_equipment\autoturret_equipment.eqip");

            halo.SetPortingProperties(audioCodec: Compression.OGG);
            halo.PortTag($@"", $@"fx\scenery_fx\weather\snow\snow_heavy\snow_heavy.effect");

            voi.SetPortingProperties(audioCodec: Compression.OGG);
            voi.PortTag($@"", $@"fx\scenery_fx\weather\rain\rain_angle\rain_angle.effect");

            highCharity.SetPortingProperties(audioCodec: Compression.OGG);
            highCharity.PortTag($@"", $@"fx\scenery_fx\weather\flood_pollen\flood_pollen_light\flood_pollen_light.effect");
            highCharity.PortTag($@"", $@"fx\scenery_fx\weather\flood_pollen\flood_pollen_heavy\flood_pollen_heavy.effect");

            floodvoi.SetPortingProperties(audioCodec: Compression.OGG);
            floodvoi.PortTag($@"", $@"fx\scenery_fx\weather\falling_ash\falling_ash.effect");

            sc100.SetPortingProperties(audioCodec: Compression.OGG);
            sc100.PortTag($@"", $@"fx\scenery_fx\weather\slipspace_fallout\slipspace_fallout.effect");
            sc100.PortTag($@"", $@"fx\scenery_fx\weather\slipspace_fallout\slipspace_fallout_strong.effect");

            h3MainMenu.SetPortingProperties(audioCodec: Compression.OGG);
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\monitor_cheap\monitor_cheap.scenery");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\warthog_cheap\warthog_cheap.scenery");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\matchmaking_earth\matchmaking_earth.scenery");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\lights\campaign.light");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\lights\custom_games.light");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\lights\editor.light");
            h3MainMenu.PortTag($@"", $@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap.biped");
            h3MainMenu.PortTag($@"", $@"sound\levels\main_menu\the_world\the_world.sound_looping");

            h100.SetPortingProperties(audioCodec: Compression.OGG);
            h100.PortTag($@"", $@"objects\vehicles\phantom\hirez_cinematic_phantom\phantom_cinematic\phantom_cinematic.scenery");
            RenameTag(GetCachedTag<ModelAnimationGraph>($@"objects\vehicles\phantom\hirez_cinematic_phantom\phantom_cinematic\cinematics\c200\c200"), $@"objects\vehicles\phantom\phantom");
            h100.PortTag($@"replace", $@"objects\vehicles\phantom\phantom.model_animation_graph");
            h100.PortTag($@"", $@"objects\vehicles\phantom\fx\running\cinematic_gravlift.light");
            h100.PortTag($@"", $@"sound\vehicles\phantom\phantom_engine_right\phantom_engine_right.sound_looping");
            h100.PortTag($@"", $@"sound\vehicles\phantom\phantom_hover_right\phantom_hover_right.sound_looping");
            h100.PortTag($@"", $@"sound\vehicles\phantom\phantom_engine_lod\phantom_engine_lod.sound_looping");
            h100.PortTag($@"", $@"objects\characters\odst\odst.render_model");
            h100.PortTag($@"", $@"objects\characters\odst\odst.collision_model");
            h100.PortTag($@"", $@"objects\characters\marine\marine.physics_model");
            h100.PortTag($@"single", $@"objects\characters\odst_recon\odst_recon.model");
            DuplicateTag(GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap"), $@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
            RenameTag(GetCachedTag<Scenery>($@"objects\vehicles\phantom\hirez_cinematic_phantom\phantom_cinematic\phantom_cinematic"), $@"levels\ui\mainmenu\objects\vehicles\phantom\hirez_cinematic_phantom");
            RenameTag(GetCachedTag<Model>($@"objects\vehicles\phantom\hirez_cinematic_phantom\phantom_cinematic\phantom_cinematic"), $@"levels\ui\mainmenu\objects\vehicles\phantom\hirez_cinematic_phantom");
            RenameTag(GetCachedTag<Model>($@"objects\characters\odst_recon\odst_recon"), $@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
            RenameTag(GetCachedTag<RenderModel>($@"objects\characters\odst\odst"), $@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");

            odstMainMenu.SetPortingProperties(audioCodec: Compression.OGG);
            odstMainMenu.PortTag($@"", $@"objects\weapons\pistol\automag\automag.scenery");
            odstMainMenu.PortTag($@"", $@"objects\weapons\rifle\smg_silenced\smg_silenced.scenery");

            citadel.SetPortingProperties(audioCodec: Compression.OGG);
            citadel.PortTag($@"", $@"levels\shared\shaders\simple\black.shader");

            DuplicateTag(GetCachedTag<Crate>($@"objects\eldewrito\reforge\block_01x20x20"), $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
            DuplicateTag(GetCachedTag<Model>($@"objects\eldewrito\reforge\block_01x20x20"), $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
            DuplicateTag(GetCachedTag<RenderModel>($@"objects\eldewrito\reforge\block_01x20x20"), $@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");

            riverworld.SetPortingProperties(audioCodec: Compression.OGG);
            riverworld.PortTag($@"", $@"levels\multi\riverworld\riverworld.performance_throttles");
        }

        public void InitializePortingContext() 
        {
            // These need to be defined after the new cache has been generated, otherwise it gets given the wrong cache context

            haloOnline = new PortingContext(CacheContext, haloOnlineCache);

            h3MainMenu = new PortingContext(CacheContext, h3MainMenuCache);
            intro = new PortingContext(CacheContext, introCache);
            jungle = new PortingContext(CacheContext, jungleCache);
            crows = new PortingContext(CacheContext, crowsCache);
            outskirts = new PortingContext(CacheContext, outskirtsCache);
            voi = new PortingContext(CacheContext, voiCache);
            floodvoi = new PortingContext(CacheContext, floodvoiCache);
            waste = new PortingContext(CacheContext, wasteCache);
            citadel = new PortingContext(CacheContext, citadelCache);
            highCharity = new PortingContext(CacheContext, highCharityCache);
            halo = new PortingContext(CacheContext, haloCache);
            epilogue = new PortingContext(CacheContext, epilogueCache);

            mythicMainMenu = new PortingContext(CacheContext, mythicMainMenuCache);
            armory = new PortingContext(CacheContext, armoryCache);
            bunkerworld = new PortingContext(CacheContext, bunkerworldCache);
            chill = new PortingContext(CacheContext, chillCache);
            chillout = new PortingContext(CacheContext, chilloutCache);
            construct = new PortingContext(CacheContext, constructCache);
            cyberdyne = new PortingContext(CacheContext, cyberdyneCache);
            deadlock = new PortingContext(CacheContext, deadlockCache);
            descent = new PortingContext(CacheContext, descentCache);
            docks = new PortingContext(CacheContext, docksCache);
            fortress = new PortingContext(CacheContext, fortressCache);
            ghosttown = new PortingContext(CacheContext, ghosttownCache);
            guardian = new PortingContext(CacheContext, guardianCache);
            isolation = new PortingContext(CacheContext, isolationCache);
            lockout = new PortingContext(CacheContext, lockoutCache);
            midship = new PortingContext(CacheContext, midshipCache);
            riverworld = new PortingContext(CacheContext, riverworldCache);
            salvation = new PortingContext(CacheContext, salvationCache);
            sandbox = new PortingContext(CacheContext, sandboxCache);
            shrine = new PortingContext(CacheContext, shrineCache);
            sidewinder = new PortingContext(CacheContext, sidewinderCache);
            snowbound = new PortingContext(CacheContext, snowboundCache);
            spacecamp = new PortingContext(CacheContext, spacecampCache);
            warehouse = new PortingContext(CacheContext, warehouseCache);
            zanzibar = new PortingContext(CacheContext, zanzibarCache);

            odstMainMenu = new PortingContext(CacheContext, odstMainMenuCache);
            h100 = new PortingContext(CacheContext, h100Cache);
            c100 = new PortingContext(CacheContext, c100Cache);
            c200 = new PortingContext(CacheContext, c200Cache);
            l200 = new PortingContext(CacheContext, l200Cache);
            l300 = new PortingContext(CacheContext, l300Cache);
            sc100 = new PortingContext(CacheContext, sc100Cache);
            sc110 = new PortingContext(CacheContext, sc110Cache);
            sc120 = new PortingContext(CacheContext, sc120Cache);
            sc130 = new PortingContext(CacheContext, sc130Cache);
            sc140 = new PortingContext(CacheContext, sc140Cache);
            sc150 = new PortingContext(CacheContext, sc150Cache);
        }

        //TODO: Figure out how to make all these functions use the same stream, and have it play nicely with the porting context

        public void GenerateTag<T>(string tagName) where T : TagStructure
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var tag = Cache.TagCache.AllocateTag<T>(tagName);
                var definition = Activator.CreateInstance<T>();
                Cache.Serialize(stream, tag, definition);
            }
        }

        public void DuplicateTag(CachedTag tag, string newName)
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var newTag = Cache.TagCache.AllocateTag(tag.Group, newName);
                var definition = Cache.Deserialize(stream, tag);
                Cache.Serialize(stream, newTag, definition);
                CacheContext.SaveTagNames();
            }
        }

        public void RenameTag(CachedTag currentTag, string newName)
        {
            currentTag.Name = newName;
            CacheContext.SaveTagNames();
        }
    }
}