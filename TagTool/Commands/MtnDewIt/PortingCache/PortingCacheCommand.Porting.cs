using TagTool.Commands.Common;
using TagTool.Commands.Porting;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        // Ports all the required taga data for the porting cache, after rebuilding
        public void portTagData() 
        {
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, sandbox));
            GenerateDialogueGlobals();
            CommandRunner.Current.RunCommand($@"porttag ai\assaulting.style");
            CommandRunner.Current.RunCommand($@"porttag ai\bunkering.style");
            CommandRunner.Current.RunCommand($@"porttag ai\normal.style");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\brittle\glass.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\energy\energy.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\hard_metal_thick_cov_chopper_wheel.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\hard_metal_thick_hum_scorpion_tread.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_solid.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thick.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thick_cov.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thick_for_sentinel.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thick_hum_hollow_huge.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thick_hum_hollow_med.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thin.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thin_cov_elite.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\metal_thin_hum_obj_rattly.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\terrain_concrete.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\hard\terrain_stone.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\liquid\liquid.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\soft\soft_inorganic_cardboard.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\soft\soft_organic_cloth.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\soft\soft_organic_plant.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\soft\soft_organic_plant_bushy_dynamic.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\soft\soft_organic_plant_leafy_dynamic.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\soft\terrain_snow.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\inorganic_plastic.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\inorganic_rubber.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\inorganic_rubber_hum_tire.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\inorganic_rubber_hum_tire_mongoose.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\organic_wood.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\terrain_dirt.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\tough_floodflesh.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\tough_organic_wood_sapling_dynamic.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\materials\tough\tough_organic_wood_tree_dynamic.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\objects\havok\blitzcan.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\objects\havok\hubcap.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\objects\havok\soccer_ball.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\material_effects\objects\weapons\flag.material_effects");
            CommandRunner.Current.RunCommand($@"porttag fx\scenery_fx\explosions\human_explosion_huge\human_explosion_huge.effect");
            CommandRunner.Current.RunCommand($@"porttag fx\scenery_fx\havok\havok_collection.effect");
            CommandRunner.Current.RunCommand($@"porttag fx\water\default_large.render_water_ripple");
            CommandRunner.Current.RunCommand($@"porttag fx\water\default_medium.render_water_ripple");
            CommandRunner.Current.RunCommand($@"porttag fx\water\default_small.render_water_ripple");
            GenerateShieldImpactTags();
            CommandRunner.Current.RunCommand($@"porttag globals\collision_damage\collision.damage_effect");
            CommandRunner.Current.RunCommand($@"porttag globals\collision_damage\default.collision_damage");
            CommandRunner.Current.RunCommand($@"porttag globals\collision_damage\landing_hard.damage_effect");
            CommandRunner.Current.RunCommand($@"porttag globals\collision_damage\landing_soft.damage_effect");
            CommandRunner.Current.RunCommand($@"porttag globals\damage_responses\default.damage_response_definition");
            CommandRunner.Current.RunCommand($@"porttag globals\default.camera_fx_settings");
            CommandRunner.Current.RunCommand($@"porttag globals\default.performance_throttles");
            CommandRunner.Current.RunCommand($@"porttag globals\default_unit_camera_track.camera_track");
            CommandRunner.Current.RunCommand($@"porttag globals\default_wind.wind");
            CommandRunner.Current.RunCommand($@"porttag globals\distance.damage_effect");
            CommandRunner.Current.RunCommand($@"porttag globals\effect_globals.effect_globals");
            CommandRunner.Current.RunCommand($@"porttag globals\falling.damage_effect");
            CommandRunner.Current.RunCommand($@"porttag globals\glass.breakable_surface");
            CommandRunner.Current.RunCommand($@"porttag globals\glass_thick.breakable_surface");
            CommandRunner.Current.RunCommand($@"porttag globals\hs_damage.damage_effect");
            GenerateInputGlobals();
            GenerateRasterizerGlobalsTag();
            CommandRunner.Current.RunCommand($@"porttag levels\shared\bitmaps\test_maps\cloud_1.bitmap");
            CommandRunner.Current.RunCommand($@"porttag levels\shared\bitmaps\test_maps\cloud_2.bitmap");
            CommandRunner.Current.RunCommand($@"porttag multiplayer\game_engine_settings.game_engine_settings_definition");
            CommandRunner.Current.RunCommand($@"porttag multiplayer\global_multiplayer_messages.multilingual_unicode_string_list");
            CommandRunner.Current.RunCommand($@"porttag multiplayer\hill\hill.bitmap");
            CommandRunner.Current.RunCommand($@"porttag multiplayer\in_game_multiplayer_messages.multilingual_unicode_string_list");
            GenerateMultiplayerGlobals();
            CommandRunner.Current.RunCommand($@"porttag multiplayer\random_player_names.multilingual_unicode_string_list");
            CommandRunner.Current.RunCommand($@"porttag multiplayer\sandbox\cursor_impact.effect");
            GenerateSurvivalGlobalsTag();
            CommandRunner.Current.RunCommand($@"porttag multiplayer\team_names.multilingual_unicode_string_list");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\masterchief\fx\coop_teleport.effect");
            //CommandRunner.Current.RunCommand($@"porttag multiplayer\vehicle_autoflip.effect"); // Halo Online Specific
            //CommandRunner.Current.RunCommand($@"porttag multiplayer\safety_booster.effect"); // Halo Online Specific
            CommandRunner.Current.RunCommand($@"porttag objects\multi\shaders\koth_shield.shader_halogram");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\multiplayer\assault_bomb\damage_effects\bomb_explosion.damage_effect");
            CommandRunner.Current.RunCommand($@"porttag rasterizer\active_camouflage_distortion.bitmap");
            CommandRunner.Current.RunCommand($@"porttag rasterizer\cc0236.bitmap");
            CommandRunner.Current.RunCommand($@"porttag rasterizer\c78d78.bitmap");
            CommandRunner.Current.RunCommand($@"porttag rasterizer\dd0236.bitmap");
            CommandRunner.Current.RunCommand($@"porttag rasterizer\shaders\simple.vertex_shader");
            CommandRunner.Current.RunCommand($@"porttag rasterizer\shaders\simple.pixel_shader");
            CommandRunner.Current.RunCommand($@"porttag rasterizer\plasma_noise.bitmap");
            CommandRunner.Current.RunCommand($@"porttag sound\combat_dialogue_constants.sound_dialogue_constants");
            CommandRunner.Current.RunCommand($@"porttag sound\default.sound_global_propagation");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\assault.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\bomb_armed.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\bomb_detonated.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\bomb_disarmed.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\bomb_dropped.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\bomb_reset.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\bomb_returned.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\assault\bomb_taken.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\capture_the_flag.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\defense.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\flag_captured.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\flag_dropped.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\flag_recovered.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\flag_reset.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\flag_stolen.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\flag_taken.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\capture_the_flag\offense.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\double_kill.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\extermination.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\hail_to_the_king.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\hells_janitor.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\infection_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\invincible.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\juggernaut_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killimanjaro.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killing_frenzy.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killing_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killionaire.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killjoy.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killpocalypse.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killtacular.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killtastrophe.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\killtrocity.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\mmm_brains.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\open_season.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\overkill.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\rampage.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\running_riot.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\sharpshooter.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\shotgun_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\slice_n_dice.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\sniper_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\splatter_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\sword_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\triple_kill.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\unstoppable.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\untouchable.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\vehicular_manslaughter.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\flavor\zombie_killing_spree.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\betrayal.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\betrayed.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\fifteen_mins_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\five_mins_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\gained_the_lead.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\game_over.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\one_min_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\round_over.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\sudden_death.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\suicide.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\teamate_gained.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\ten_points_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\ten_points_to_win.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\ten_secs_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\thirty_mins_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\thirty_secs_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\twenty_five_points_remaining.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\general\twenty_five_points_to_win.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\infection\infected.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\infection\last_man_standing.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\infection\new_zombie.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\juggernaut\destination_moved.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\juggernaut\new_juggernaut.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\king_of_the_hill\hill_contested.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\king_of_the_hill\hill_controlled.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\king_of_the_hill\hill_moved.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\king_of_the_hill\king_of_the_hill.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\misc\perfection.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\oddball\ball_dropped.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\oddball\ball_reset.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\oddball\ball_taken.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\oddball\oddball.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\oddball\play_ball.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\slayer\slayer.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\slayer\target_changed.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\territories\territories.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\territories\territory_captured.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\territories\territory_lost.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\vip\new_vip.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\dialog\multiplayer_en\vip\vip_killed.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\multiplayer\comm_fail.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\multiplayer\comm_loop_mp\comm_loop_mp.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\multiplayer\countdown_for_respawn.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\multiplayer\player_respawn.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\multiplayer\teleporter_activate.sound");
            //CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\multiplayer\transport.sound"); // Halo Online Specific
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\ui\binoculars\binocs_in_click.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\ui\binoculars\binocs_out_click.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\ui\death_gurgle.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\game_sfx\ui\flag_fail.sound");
            GenerateSoundEffectTemplates();
            CommandRunner.Current.RunCommand($@"porttag sound\global_fx.sound_effect_collection");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\energy\blue_plasma_looping\blue_plasma_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\energy\cortana_melee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_solid\metal_solid_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_solid\metal_solid_med_h3_actee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_solid\metal_solid_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_solid\metal_solid_small_h3_actee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thick\hard_metal_thick_cov_hunter.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thick\hit_ghost.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thick\hit_ghost_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thick\vehicle_hit_human.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\cov_weap_melee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\human_weap_melee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\metal_thin_cov_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\metal_thin_fence.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\metal_thin_gas_can.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\metal_thin_hum_grating_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\metal_thin_hum_grating_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\metal_thin\metal_thin_hum_railing.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\terrain_concrete\concrete_looping\concrete_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\terrain_concrete\concrete_melee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\terrain_ice\ice_large.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\terrain_ice\ice_looping\ice_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\hard\terrain_ice\ice_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\havok\tire\tire_hits.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\soft\cardboard\cardboard_hits_med_actee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\soft\cardboard\cardboard_hits_small_actee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\soft\organic_flesh\melee_impact.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\soft\soft_organic_plant\soft_organic_plant_hits_actor.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\soft\soft_organic_plant_bushy_dynamic\soft_organic_plant_bushy_dyn_hits\plant_bushy_dyn_melee.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\soft\terrain_snow\snow_looping\snow_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\submerged_default_material\submerged_thud_large.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\submerged_default_material\submerged_thud_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\squish_hits.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_carpet\carpet_hit_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_dirt\dirt_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_dry_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_hit_dry_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_hit_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_hit_small_wet.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_hits_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_hits_wet_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_looping\floodflesh_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_floodflesh\floodflesh_wet_looping\floodflesh_wet_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_grass\grass_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_grass\grass_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_gravel\gravel_looping\gravel_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_gravel\gravel_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_gravel\gravel_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_mud\mud_looping\mud_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_mud\mud_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_mud\mud_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_sand\sand_looping\sand_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_sand\sand_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_sand\sand_small.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_underbrush\underbrush_looping\underbrush_looping.sound_looping");
            CommandRunner.Current.RunCommand($@"porttag sound\materials\tough\terrain_underbrush\underbrush_med.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\sound_classes.sound_classes");
            CommandRunner.Current.RunCommand($@"porttag sound\sound_mix.sound_mix");
            CommandRunner.Current.RunCommand($@"porttag sound\weapons\battle_rifle\flashlight.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\weapons\claymore_grenade\claymore_throw.effect");
            CommandRunner.Current.RunCommand($@"porttag sound\weapons\firebomb\firebomb_throw.effect");
            CommandRunner.Current.RunCommand($@"porttag sound\weapons\flag\melee_flag.sound");
            CommandRunner.Current.RunCommand($@"porttag sound\weapons\frag_grenade\frag_throw.effect");
            CommandRunner.Current.RunCommand($@"porttag sound\weapons\plasma_grenade\throwgren.effect");
            CommandRunner.Current.RunCommand($@"porttag ui\dialog.color_table");
            CommandRunner.Current.RunCommand($@"porttag ui\editor.color_table");
            CommandRunner.Current.RunCommand($@"porttag ui\halox\common\common_bitmaps\emblems.bitmap");
            CommandRunner.Current.RunCommand($@"porttag ui\halox\sandbox_ui\object_properties_menu_values.sandbox_text_value_pair_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\halox\sandbox_ui\strings.multilingual_unicode_string_list");
            CommandRunner.Current.RunCommand($@"porttag ui\halox\scoreboard\dead_player_ui.bitmap");
            CommandRunner.Current.RunCommand($@"porttag ui\hud.color_table");
            ContextStack.Pop();

            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, h100));
            GenerateSquadTemplates();
            CommandRunner.Current.RunCommand($@"porttag globals\ai_globals.ai_globals");
            CommandRunner.Current.RunCommand($@"porttag globals\default_vision_mode.vision_mode");
            CommandRunner.Current.RunCommand($@"porttag globals\game_progression.game_progression");
            CommandRunner.Current.RunCommand($@"porttag globals\global_achievements.achievements");
            CommandRunner.Current.RunCommand($@"porttag multiplayer\in_game_survival_messages.multilingual_unicode_string_list");
            ContextStack.Pop();

            // Uses the Halo 3 UI, as that is the most complete feature wise
            switch (cacheType)
            {
                case "Halo 3":
                case "Halo 3 Mythic":
                    ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, h3_mainmenu));
                    break;
            }

            // Mainmenu UI tags
            CommandRunner.Current.RunCommand($@"porttag autorescalegui ui\main_menu.wgtz");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, sandbox));

            // Multiplayer UI tags
            CommandRunner.Current.RunCommand($@"porttag autorescalegui ui\multiplayer.wgtz");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, citadel));

            // Singleplayer UI tags
            CommandRunner.Current.RunCommand($@"porttag autorescalegui ui\single_player.wgtz");

            // Fixes crashing issue with certain weapons
            CommandRunner.Current.RunCommand($@"porttag shaders\invalid.shader");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, sandbox));
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\backpack_test.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\backpack_unready.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\backpack_warning_flash.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\beam_rifle_meter_left.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\beam_rifle_meter_right.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\carbine_crosshair.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\carbine_crosshair2.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\center_dimming.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\center_hack.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\clockwise.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\counterclockwise.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\ctf_scoreboard.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\dimming.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\equipment_kablam.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\fade_in.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\fade_in_slow.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\flash_test.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\help_text_hack.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\init_wipe_horizontal.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\init_wipe_vertical.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\laser_charge.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\laser_unzoom_level.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\laser_zoom_fade_level.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\laser_zoom_level.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\lock_flash.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\motion_tracker_ping.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\pitch_slide.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\shield_dimming.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\shields_out.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\sniper_slide.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\vip_aura_center.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\vip_aura_pulsate.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\vip_notify.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\vip_notify_text.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\vox1.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\vox2.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\yaw_slide.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\animations\zoom_scope.chud_animation_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_ctf.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_slayer.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_oddball.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_king.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_editor.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_vip.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_juggernaut.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_territories.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_assault.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\multiplayer_intro\summary_infection.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\assault_rifle.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\battle_rifle.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\beam_rifle.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\brute_shot.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\carbine.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_bubbleshield.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_flare.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_gravlift.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_instacover.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_jammer.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_powerdrain.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_regen.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_tripmine.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\elite.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\excavator.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\flamethrower.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\fuel_rod_cannon.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\golf_club.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\hammer.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\machinegun_turret.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\magnum.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\missile.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\monitor.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\needler.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\plasma_pistol.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\plasma_rifle.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\plasma_turret.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\rocket.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\scoreboard.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\sentinel_beam.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\shotgun.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\smg.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\sniper_rifle.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\spartan.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\spartan_laser.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\spike_rifle.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\sword.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\t_machinegun.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\t_plasmaturret.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\unarmed.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_banshee.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_chaingun.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_chopper.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_driver.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_gaussturret.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_ghost.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_grinderdriver.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_grinderturret.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_hornet.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_mongoose.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_scorpion.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_scorpionturret.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_wraith.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_wraith_anti_air.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\v_wraithturret.chud_definition");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, citadel));
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_autoturret.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_invincibility.chud_definition");
            CommandRunner.Current.RunCommand($@"porttag ui\chud\e_invisibility.chud_definition");
            ContextStack.Pop();

            // Chud Globals Definition
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, sandbox));
            CommandRunner.Current.RunCommand($@"porttag ui\chud\globals.chud_globals_definition");
            ContextStack.Pop();

            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, sandbox));
            CommandRunner.Current.RunCommand($@"porttag objects\characters\masterchief\mp_masterchief\fp\fp.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\masterchief\mp_masterchief\fp_body\fp_body.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\masterchief\mp_masterchief\mp_masterchief.bipd");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\elite\mp_elite\fp\fp.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\elite\mp_elite\fp_body\fp_body.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\elite\mp_elite\mp_elite.bipd");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\monitor\monitor_editor.bipd");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, citadel));
            CommandRunner.Current.RunCommand($@"porttag objects\characters\dervish\fp\fp.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\dervish\fp_body\fp_body.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\dervish\dervish.bipd");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\elite\fp_arms\fp_arms.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\elite\fp_body\fp_body.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\elite\elite_sp.bipd");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\masterchief\fp\fp.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\masterchief\fp_body\fp_body.mode");
            CommandRunner.Current.RunCommand($@"porttag objects\characters\masterchief\masterchief.bipd");
            ContextStack.Pop();

            switch (cacheType)
            {
                case "Halo 3":
                    ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, h3_mainmenu));
                    break;
                case "Halo 3 Mythic":
                    ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, h3_mythic_mainmenu));
                    break;
            }

            CommandRunner.Current.RunCommand($@"mergeanimationgraphs");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, sandbox));
            CommandRunner.Current.RunCommand($@"porttag objects\ui\editor_gizmo\editor_gizmo.scen");
            CommandRunner.Current.RunCommand($@"porttag objects\multi\vip\vip_boundary.bloc");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\claymore_grenade\claymore_grenade.proj");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\claymore_grenade\claymore_grenade.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\firebomb_grenade\projectiles\firebomb_grenade.proj");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\firebomb_grenade\firebomb_grenade.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\frag_grenade\frag_grenade.proj");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\frag_grenade\frag_grenade.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\plasma_grenade\plasma_grenade.proj");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\grenade\plasma_grenade\plasma_grenade.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\melee\energy_blade\energy_blade.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\melee\energy_blade\energy_blade_useless.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\melee\gravity_hammer\gravity_hammer.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\multiplayer\assault_bomb\assault_bomb.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\multiplayer\ball\ball.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\multiplayer\flag\flag.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\pistol\excavator\excavator.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\pistol\magnum\magnum.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\pistol\needler\needler.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\pistol\plasma_pistol\plasma_pistol.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\assault_rifle\assault_rifle.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\battle_rifle\battle_rifle.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\beam_rifle\beam_rifle.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\covenant_carbine\covenant_carbine.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\plasma_rifle\plasma_rifle.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\shotgun\shotgun.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\smg\smg.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\sniper_rifle\sniper_rifle.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\rifle\spike_rifle\spike_rifle.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\support_high\rocket_launcher\rocket_launcher.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\support_high\spartan_laser\spartan_laser.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\support_low\brute_shot\brute_shot.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\turret\flamethrower\flamethrower.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\weapons\turret\missile_pod\missile_pod.weap");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\bubbleshield_equipment\bubbleshield_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\gravlift_equipment\gravlift_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\instantcover_equipment\instantcover_equipment_mp.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\jammer_equipment\jammer_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\powerdrain_equipment\powerdrain_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\regenerator_equipment\regenerator_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\superflare_equipment\superflare_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\tripmine_equipment\tripmine_equipment.eqip");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, citadel));
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\instantcover_equipment\instantcover_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\invincibility_equipment\invincibility_equipment.eqip");
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\invisibility_equipment\invisibility_equipment.eqip");
            ContextStack.Pop();
            ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, halo));
            CommandRunner.Current.RunCommand($@"porttag objects\equipment\autoturret_equipment\autoturret_equipment.eqip");
            ContextStack.Pop();

            switch (cacheType)
            {
                case "Halo 3":
                    ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, h3_mainmenu));
                    break;
                case "Halo 3 Mythic":
                    ContextStack.Push(PortingContextFactory.Create(ContextStack, Cache, h3_mythic_mainmenu));
                    break;
            }
            
            CommandRunner.Current.RunCommand($@"porttag *.scnr");
            ContextStack.Pop();
            
            switch (cacheType)
            {
                case "Halo 3":
                    CommandRunner.Current.RunCommand($@"updatemapfiles {halo3DirectoryInfo}\info");
                    break;
                case "Halo 3 Mythic":
                    CommandRunner.Current.RunCommand($@"updatemapfiles {halo3MythicDirectoryInfo}\info");
                    break;
            }
        }
    }
}