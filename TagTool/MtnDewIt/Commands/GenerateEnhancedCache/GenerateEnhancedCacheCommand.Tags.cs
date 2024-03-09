using System.IO;
using TagTool.Commands;
using TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Tags;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache
{
    partial class GenerateEnhancedCacheCommand : Command
    {
        public void UpdateTagData()
        {
            Cache.StringTable.Add($@"menu_spartan1");
            Cache.StringTable.Add($@"menu_spartan2");
            Cache.SaveStrings();

            new ui_eldewrito_common_map_bitmaps_placeholder_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_armory_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_bunkerworld_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_chillout_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_descent_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_docks_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_fortress_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_ghosttown_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_lockout_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_midship_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sandbox_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_sidewinder_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_spacecamp_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_warehouse_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_chill_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_construct_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_cyberdyne_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_deadlock_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_guardian_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_isolation_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_riverworld_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_avalanche_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_edge_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_lockout_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_powerhouse_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_reactor_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_sky_bridgenew_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_turf_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_s3d_waterfall_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_salvation_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_shrine_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_snowbound_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_common_map_bitmaps_zanzibar_bitmap(Cache, CacheContext, CacheStream);

            new ui_eldewrito_maps_map_list(Cache, CacheContext, CacheStream);

            new multiplayer_forge_globals_forge_globals_definition(Cache, CacheContext, CacheStream);

            new ui_halox_common_roster_roster_gui_skin_definition(Cache, CacheContext, CacheStream);

            new ui_halox_common_roster_animations_player_scale_up_gui_widget_scale_animation_definition(Cache, CacheContext, CacheStream);

            new ui_halox_main_menu_main_menu_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_pregame_lobby_multiplayer_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new ui_halox_pregame_lobby_pregame_lobby_mapeditor_gui_screen_widget_definition(Cache, CacheContext, CacheStream);

            new levels_ui_mainmenu_objects_spartan_cheap_spartan_cheap_model(Cache, CacheContext, CacheStream);

            new objects_eldewrito_reforge_block_01x20x20_black_mainmenu_crate(Cache, CacheContext, CacheStream);

            new objects_eldewrito_reforge_block_01x20x20_black_mainmenu_model(Cache, CacheContext, CacheStream);

            new objects_eldewrito_reforge_block_01x20x20_black_mainmenu_render_model(Cache, CacheContext, CacheStream);

            new levels_ui_mainmenu_mainmenu_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_armory_armory_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_bunkerworld_bunkerworld_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_chillout_chillout_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_descent_descent_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_docks_docks_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_fortress_fortress_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_ghosttown_ghosttown_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_lockout_lockout_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_midship_midship_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_sandbox_sandbox_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_sidewinder_sidewinder_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_spacecamp_spacecamp_scenario(Cache, CacheContext, CacheStream);

            new levels_dlc_warehouse_warehouse_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_chill_chill_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_construct_construct_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_cyberdyne_cyberdyne_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_deadlock_deadlock_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_guardian_guardian_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_isolation_isolation_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_riverworld_riverworld_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_avalanche_s3d_avalanche_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_edge_s3d_edge_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_lockout_s3d_lockout_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_powerhouse_s3d_powerhouse_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_reactor_s3d_reactor_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_sky_bridgenew_s3d_sky_bridgenew_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_turf_s3d_turf_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_s3d_waterfall_s3d_waterfall_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_salvation_salvation_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_shrine_shrine_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_snowbound_snowbound_scenario(Cache, CacheContext, CacheStream);

            new levels_multi_zanzibar_zanzibar_scenario(Cache, CacheContext, CacheStream);
        }
    }
}