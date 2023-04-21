using System.Collections.Generic;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        // Modifies the global tags, with valid data (This is required as all these values are null after the cache is rebuilt)
        public void modifyGlobals() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("matg") && tag.Name == $@"globals\globals")
                    {
                        var matg = CacheContext.Deserialize<Globals>(stream, tag);
                        matg.Grenades[0].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade");
                        matg.Grenades[0].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\frag_grenade\frag_grenade");
                        matg.Grenades[1].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        matg.Grenades[1].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        matg.Grenades[2].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade");
                        matg.Grenades[2].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade");
                        matg.Grenades[3].Equipment = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\firebomb_grenade\firebomb_grenade");
                        matg.Grenades[3].Projectile = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\firebomb_grenade\projectiles\firebomb_grenade");
                        //matg.InterfaceTags[0].MainMenuUiGlobals = CacheContext.TagCache.GetTag<UserInterfaceGlobalsDefinition>($@"ui\main_menu"); // Need to figure out why the main menu UI is causing the game to crash
                        matg.InterfaceTags[0].SinglePlayerUiGlobals = CacheContext.TagCache.GetTag<UserInterfaceGlobalsDefinition>($@"ui\single_player");
                        matg.InterfaceTags[0].MultiplayerUiGlobals = CacheContext.TagCache.GetTag<UserInterfaceGlobalsDefinition>($@"ui\multiplayer");
                        matg.InterfaceTags[0].HudGlobals = CacheContext.TagCache.GetTag<ChudGlobalsDefinition>($@"ui\chud\globals");

                        // Assigns Halo 3 player bipeds
                        matg.PlayerRepresentation[0].Name = CacheContext.StringTable.GetStringId($@"masterchief"); // 0.7 specifc (used in the PlayerCharacterType blocks)
                        matg.PlayerRepresentation[0].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\fp\fp");
                        matg.PlayerRepresentation[0].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\fp_body\fp_body");
                        matg.PlayerRepresentation[0].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\masterchief\masterchief");
                        matg.PlayerRepresentation[0].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[0].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[1].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\dervish\fp\fp");
                        matg.PlayerRepresentation[1].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\dervish\fp_body\fp_body");
                        matg.PlayerRepresentation[1].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\dervish\dervish");
                        matg.PlayerRepresentation[1].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[1].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[2].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\mp_masterchief\fp\fp");
                        matg.PlayerRepresentation[2].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\masterchief\mp_masterchief\fp_body\fp_body");
                        matg.PlayerRepresentation[2].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief");
                        matg.PlayerRepresentation[2].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[2].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[3].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\mp_elite\fp\fp");
                        matg.PlayerRepresentation[3].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\mp_elite\fp_body\fp_body");
                        matg.PlayerRepresentation[3].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite");
                        matg.PlayerRepresentation[3].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[3].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[4].FirstPersonHands = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\fp_arms\fp_arms");
                        matg.PlayerRepresentation[4].FirstPersonBody = CacheContext.TagCache.GetTag<RenderModel>($@"objects\characters\elite\fp_body\fp_body");
                        matg.PlayerRepresentation[4].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\elite\elite_sp");
                        matg.PlayerRepresentation[4].BinocularsZoomInSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_in_click");
                        matg.PlayerRepresentation[4].BinocularsZoomOutSound = CacheContext.TagCache.GetTag<Sound>($@"sound\game_sfx\ui\binoculars\binocs_out_click");
                        matg.PlayerRepresentation[5].ThirdPersonUnit = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\monitor\monitor_editor");

                        // Used to assign player character types (string ids and sbyte values reference data from player representation blocks)
                        matg.PlayerCharacterTypes = new List<Globals.PlayerCharacterType>()
                        {
                            new Globals.PlayerCharacterType()
                            {
                                Name = CacheContext.StringTable.GetStringId($@"masterchief"),
                                CampaignRepresentation = 0,
                                MultiplayerRepresentation = 2,
                                MultiplayerArmorCustomization = 0,
                            },
                            new Globals.PlayerCharacterType()
                            {
                                Name = CacheContext.StringTable.GetStringId($@"dervish"),
                                CampaignRepresentation = 1,
                                MultiplayerRepresentation = 3,
                                MultiplayerArmorCustomization = 1,
                            },
                        };

                        matg.CinematicGlobals[0].CinematicAnchor = CacheContext.TagCache.GetTag<Scenery>($@"objects\cinematics\cinematic_anchor\cinematic_anchor"); // Required in order for cutscenes to function correctly
                        CacheContext.Serialize(stream, tag, matg);
                    }

                    // Modifies the multiplayer globals data (this tag is completely reformated with Halo 3 weapon values during the rebuilding process)
                    if (tag.IsInGroup("mulg") && tag.Name == $@"multiplayer\multiplayer_globals")
                    {
                        var mulg = CacheContext.Deserialize<MultiplayerGlobals>(stream, tag);
                        mulg.Universal[0].Equipment[0].Object = null;
                        mulg.Universal[0].Equipment[1].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\jammer_equipment\jammer_equipment");
                        mulg.Universal[0].Equipment[2].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\powerdrain_equipment\powerdrain_equipment");
                        mulg.Universal[0].Equipment[3].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment");
                        mulg.Universal[0].Equipment[4].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\superflare_equipment\superflare_equipment");
                        mulg.Universal[0].Equipment[5].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\regenerator_equipment\regenerator_equipment");
                        mulg.Universal[0].Equipment[6].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\tripmine_equipment\tripmine_equipment");
                        mulg.Universal[0].Equipment[7].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment_mp");
                        mulg.Universal[0].Equipment[8].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\invincibility_equipment\invincibility_equipment");
                        mulg.Universal[0].Equipment[9].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\gravlift_equipment\gravlift_equipment");
                        mulg.Universal[0].Equipment[10].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\autoturret_equipment\autoturret_equipment");
                        mulg.Universal[0].Equipment[11].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\invisibility_equipment\invisibility_equipment");
                        mulg.Universal[0].Equipment[12].Object = CacheContext.TagCache.GetTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment");
                        mulg.Universal[0].GameVariantWeapons[0].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle");
                        mulg.Universal[0].GameVariantWeapons[1].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle");
                        mulg.Universal[0].GameVariantWeapons[2].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol");
                        mulg.Universal[0].GameVariantWeapons[3].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle");
                        mulg.Universal[0].GameVariantWeapons[4].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\smg\smg");
                        mulg.Universal[0].GameVariantWeapons[5].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine");
                        mulg.Universal[0].GameVariantWeapons[6].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade");
                        mulg.Universal[0].GameVariantWeapons[7].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\magnum\magnum");
                        mulg.Universal[0].GameVariantWeapons[8].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\needler\needler");
                        mulg.Universal[0].GameVariantWeapons[9].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle");
                        mulg.Universal[0].GameVariantWeapons[10].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher");
                        mulg.Universal[0].GameVariantWeapons[11].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun");
                        mulg.Universal[0].GameVariantWeapons[12].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle");
                        mulg.Universal[0].GameVariantWeapons[13].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot");
                        mulg.Universal[0].GameVariantWeapons[14].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade_useless");
                        mulg.Universal[0].GameVariantWeapons[15].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle");
                        mulg.Universal[0].GameVariantWeapons[16].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\support_high\spartan_laser\spartan_laser");
                        mulg.Universal[0].GameVariantWeapons[17].Weapon = null;
                        mulg.Universal[0].GameVariantWeapons[18].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer");
                        mulg.Universal[0].GameVariantWeapons[19].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\pistol\excavator\excavator");
                        mulg.Universal[0].GameVariantWeapons[20].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\turret\flamethrower\flamethrower");
                        mulg.Universal[0].GameVariantWeapons[21].Weapon = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\turret\missile_pod\missile_pod");
                        mulg.Universal[0].GameVariantGrenades[0].Grenade = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade");
                        mulg.Universal[0].GameVariantGrenades[1].Grenade = CacheContext.TagCache.GetTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        mulg.Runtime[0].EditorBiped = CacheContext.TagCache.GetTag<Biped>($@"objects\characters\monitor\monitor_editor");
                        mulg.Runtime[0].EditorHelperObject = CacheContext.TagCache.GetTag<Scenery>($@"objects\ui\editor_gizmo\editor_gizmo");
                        mulg.Runtime[0].Flag = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\multiplayer\flag\flag");
                        mulg.Runtime[0].Ball = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\multiplayer\ball\ball");
                        mulg.Runtime[0].Bomb = CacheContext.TagCache.GetTag<Weapon>($@"objects\weapons\multiplayer\assault_bomb\assault_bomb");
                        mulg.Runtime[0].VipInfluenceArea = CacheContext.TagCache.GetTag<Crate>($@"objects\multi\vip\vip_boundary");
                        mulg.Runtime[0].HaloOnlineRuntimeEffects.ThusIRefuteTheeEffect = CacheContext.TagCache.GetTag<Projectile>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade");
                        CacheContext.Serialize(stream, tag, mulg);
                    }
                }
            }
        }
    }
}