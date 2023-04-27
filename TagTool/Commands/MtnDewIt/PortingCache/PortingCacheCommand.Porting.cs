using TagTool.Commands.Common;
using TagTool.Commands.Porting;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        // Ports all the required taga data for the porting cache, after rebuilding
        public void portTagData() 
        {
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