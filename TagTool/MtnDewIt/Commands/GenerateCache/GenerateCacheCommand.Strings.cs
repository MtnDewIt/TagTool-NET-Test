using System.Text.RegularExpressions;
using System;
using TagTool.Tags.Definitions;
using System.Linq;
using System.Globalization;
using TagTool.Common;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        // Adds the input stringId to the specified string list tag. If the string id does not exist in the string table, it will be added to the end of the table.
        public void AddString(MultilingualUnicodeStringList unic, string stringIdName, string stringIdContent)
        {
            var stringIdIndex = Cache.StringTable.IndexOf(stringIdName);

            if (stringIdIndex < 0)
            {
                Cache.StringTable.AddString(stringIdName);
                Cache.SaveStrings();

                stringIdIndex = Cache.StringTable.IndexOf(stringIdName);
            }
            var stringId = Cache.StringTable.GetStringId(stringIdIndex);

            var parsedContent = new Regex(@"\\[uU]([0-9A-F]{4})").Replace(stringIdContent, match => ((char)Int32.Parse(match.Value.Substring(2), NumberStyles.HexNumber)).ToString());

            var localizedStr = unic.Strings.FirstOrDefault(s => s.StringID == stringId);

            if (localizedStr == null)
            {
                localizedStr = new LocalizedString
                {
                    StringID = stringId,
                    StringIDStr = stringIdName
                };

                unic.Strings.Add(localizedStr);
            }

            unic.SetString(localizedStr, GameLanguage.English, parsedContent);
        }

        // Replaces the specified strings with the specified input values
        public void modifyStrings()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                // Commented out strings are either halo online or eldewrito specific, or are unnused in the cache (functionality and use cases unknown)
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\global_strings\damage_strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        //AddString(unic, "armor_lock_crush", "Armor Lock");
                        AddString(unic, "shade_turret", "Shade Turret");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\game_browser\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "browser_title", "AVAILABLE GAMES");
                        AddString(unic, "system_link_games", "Local Games");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\dialog\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "confirm_boot_betrayer", "This will remove the player from the game. Are you sure you wish to do this?");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\main_menu\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "customization", "CUSTOMIZATION");
                        AddString(unic, "eldewrito_settings", "SETTINGS");
                        AddString(unic, "eldewrito_version", "<eldewrito-version/>");
                        AddString(unic, "exit", "EXIT");
                        AddString(unic, "game_browser", "LOCAL GAMES");
                        AddString(unic, "server_browser", "SERVER BROWSER");
                        AddString(unic, "survival", "FIREFIGHT");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\start_menu\panes\settings\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "controls_description", "Customize your settings to your personal preferences.");
                        AddString(unic, "controls_settings", "ED SETTINGS");
                        AddString(unic, "display_description", "Customize your screen settings to decide how you want subtitles to be displayed.");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\start_menu\panes\settings_appearance_colors\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "cef_color_detail", "Detail Color");
                        AddString(unic, "cef_color_detail_desc", "The armor detail color preserves your individual identity in all multiplayer scenarios.");
                        AddString(unic, "cef_color_light", "Light Color");
                        AddString(unic, "cef_color_light_desc", "Like Christmas, but more subtle.");
                        AddString(unic, "cef_color_primary", "Primary Color");
                        AddString(unic, "cef_color_primary_desc", "The primary armor color will serve you in individual combat but will be overwritten in team scenarios.");
                        AddString(unic, "cef_color_secondary", "Secondary Color");
                        AddString(unic, "cef_color_secondary_desc", "The secondary armor color accents your primary color and will be overwritten in team scenarios.");
                        AddString(unic, "cef_color_visor", "Visor Color");
                        AddString(unic, "cef_color_visor_desc", "Adjust the tint of your Spartan's visor.");
                        AddString(unic, "cef_elite_color_flair", "Flair Color");
                        AddString(unic, "cef_elite_color_flair_desc", "The secondary armor color accents your primary color and will always represent you in any scenario.");
                        AddString(unic, "cef_elite_color_light", "Light Color");
                        AddString(unic, "cef_elite_color_light_desc", "Like Christmas, but more subtle.");
                        AddString(unic, "cef_elite_color_primary", "Primary Color");
                        AddString(unic, "cef_elite_color_primary_desc", "The primary armor color will serve you in individual combat but will be overwritten in team scenarios.");
                        AddString(unic, "cef_elite_color_primary_sheen", "Primary Color Sheen");
                        AddString(unic, "cef_elite_color_primary_sheen_desc", "The primary armor color sheen will always represent you in any scenario.");
                        AddString(unic, "cef_elite_color_secondary", "Secondary Color");
                        AddString(unic, "cef_elite_color_secondary_desc", "The secondary armor color accents your primary color and will always represent you in any scenario.");
                        AddString(unic, "cef_spartan_color_detail", "Detail Color");
                        AddString(unic, "cef_spartan_color_detail_desc", "The armor detail color preserves your individual identity in all multiplayer scenarios.");
                        AddString(unic, "cef_spartan_color_light", "Light Color");
                        AddString(unic, "cef_spartan_color_light_desc", "Like Christmas, but more subtle.");
                        AddString(unic, "cef_spartan_color_primary", "Primary Color");
                        AddString(unic, "cef_spartan_color_primary_desc", "The primary armor color will serve you in individual combat but will be overwritten in team scenarios.");
                        AddString(unic, "cef_spartan_color_secondary", "Secondary Color");
                        AddString(unic, "cef_spartan_color_secondary_desc", "The secondary armor color accents your primary color and will be overwritten in team scenarios.");
                        AddString(unic, "cef_spartan_color_visor", "Visor Color");
                        AddString(unic, "cef_spartan_color_visor_desc", "Adjust the tint of your Spartan's visor.");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\pregame_lobby\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "advanced_options", @"\UE102 Edit Game Options");
                        AddString(unic, "campaign_difficulty", "<lobby-campaign-level/> on <lobby-campaign-difficulty/>");
                        AddString(unic, "game_setup", "GAME SETUP");
                        AddString(unic, "header_survival", "FIREFIGHT LOBBY");
                        AddString(unic, "mapeditor_map_name", "Edit Objects on <lobby-mapeditor-map/>");
                        AddString(unic, "metagame_off_description", "Scoring Off");
                        AddString(unic, "metagame_on_description", "Free for All Scoring");
                        AddString(unic, "metagame_on_group_description", "Team Scoring");
                        AddString(unic, "metagame_scoring", "SCORING: <metagame-scoring/>");
                        AddString(unic, "multiplayer_game_name", "<lobby-multiplayer-game/> on <lobby-multiplayer-map/>");
                        AddString(unic, "privacy_offline", "\r\nThis party is local to your PC. To play with others, select HOST SETTINGS and then choose Online.");
                        AddString(unic, "privacy_system_link", "\r\nThis party is open for others to join.");
                        AddString(unic, "scoring_title", "SCORING:");
                        AddString(unic, "select_network_mode", "HOST SETTINGS: <lobby-network/>");
                        AddString(unic, "select_scoring", "Scoring: <metagame-scoring/>");
                        AddString(unic, "select_skulls", "Skulls: <primary-skull-count/> Primary, <secondary-skull-count/> Secondary");
                        AddString(unic, "select_skulls_survival", "Skulls: <secondary-skull-count/> Secondary");
                        AddString(unic, "start_campaign_resume", "RESUME GAME");
                        AddString(unic, "start_survival_coop", "START FIREFIGHT");
                        AddString(unic, "start_survival_solo", "START FIREFIGHT");
                        AddString(unic, "status_ready_leader", "Ready |n<lobby-privacy/>");
                        AddString(unic, "survival_difficulty", "<lobby-campaign-level/> on <lobby-campaign-difficulty/>");
                        AddString(unic, "switch_selected_mod", "MOD: <eldewrito-mod/>");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\pregame_lobby\switch_lobby\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "survival", "FIREFIGHT");
                        AddString(unic, "survival_help", "Take your party to Firefight missions that gradually increase in difficulty as you rack up the points.");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\pregame_lobby\selection\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "network_mode_offline", "Offline");
                        AddString(unic, "network_mode_offline_description", "Play only on this PC.");
                        AddString(unic, "network_mode_system_link", "Online");
                        AddString(unic, "network_mode_system_link_advertise_description", "Host a INTERNET/LAN game. This can be joined from the Server Browser or the Local Games menu.");
                        AddString(unic, "network_mode_system_link_browse_description", "Find games that are being hosted on your local area network or VPN.");
                        AddString(unic, "network_mode_system_link_description", "Play with others over your local area network or VPN.");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\in_progress\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "game_variant_save_progress_message", "Saving content. Please don't turn off your PC.");
                        AddString(unic, "map_variant_save_progress_message", "Saving content. Please don't turn off your PC.");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\campaign\campaign_settings\strings_campaign_settings") 
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "skulls_help", "This setting allows you to turn skulls on or off.");
                        //AddString(unic, "skull_15_title", "Third Person");
                        //AddString(unic, "skull_15_hint", "Interred somewhere, anywhere, nowhere?);
                        //AddString(unic, "skull_15", "Got a good view of my ass from here");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\game_options\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        //AddString(unic, "assault_rifle_v2", "Assault Rifle (Damage)");
                        //AddString(unic, "assault_rifle_v3", "Assault Rifle (Accuracy)");
                        //AddString(unic, "assault_rifle_v4", "Assault Rifle (Rate of Fire)");
                        //AddString(unic, "assault_rifle_v5", "Assault Rifle (Accuracy)");
                        //AddString(unic, "assault_rifle_v6", "Assault Rifle (Power)");
                        AddString(unic, "balanced", "Balancing Only");
                        AddString(unic, "base", "No Upgrades");
                        //AddString(unic, "battle_rifle_v1", "Battle Rifle (Ammo)");
                        //AddString(unic, "battle_rifle_v2", "Battle Rifle (Damage)");
                        //AddString(unic, "battle_rifle_v3", "Battle Rifle (Accuracy)");
                        //AddString(unic, "battle_rifle_v4", "Battle Rifle (Rate of Fire)");
                        //AddString(unic, "battle_rifle_v5", "Battle Rifle (Range)");
                        //AddString(unic, "battle_rifle_v6", "Battle Rifle (Power)");
                        AddString(unic, "bottomless_clip", "bottomless clip");
                        AddString(unic, "carbine", "Covenant Carbine");
                        //AddString(unic, "covenant_carbine_v1", "Covenant Carbine (Ammo)");
                        //AddString(unic, "covenant_carbine_v2", "Covenant Carbine (Damage)");
                        //AddString(unic, "covenant_carbine_v3", "Covenant Carbine (Accuracy)");
                        //AddString(unic, "covenant_carbine_v4", "Covenant Carbine (Rate of Fire)");
                        //AddString(unic, "covenant_carbine_v5", "Covenant Carbine (Range)");
                        //AddString(unic, "covenant_carbine_v6", "Covenant Carbine (Power)");
                        //AddString(unic, "dmr", "DMR");
                        //AddString(unic, "dmr_v1", "DMR (Ammo)");
                        //AddString(unic, "dmr_v2", "DMR (Damage)");
                        //AddString(unic, "dmr_v3", "DMR (Accuracy)");
                        //AddString(unic, "dmr_v4", "DMR (Rate of Fire)");
                        //AddString(unic, "dmr_v5", "DMR (Range)");
                        //AddString(unic, "dmr_v6", "DMR (Power)");
                        AddString(unic, "excavator", "Mauler");
                        //AddString(unic, "excavator_v3", "Mauler (Power)");
                        AddString(unic, "flamethrower", "Flamethrower");
                        AddString(unic, "fuel_rod_gun", "Fuel Rod Gun");
                        AddString(unic, "info", "All weapons are their base versions.");
                        AddString(unic, "machinegun_turret", "Machine Gun Turret");
                        //AddString(unic, "magnum_v2", "Magnum (Damage)");
                        //AddString(unic, "magnum_v3", "Magnum (Power)");
                        AddString(unic, "missile_pod", "Missile Pod");
                        AddString(unic, "percent_15", "15%");
                        AddString(unic, "percent_1500", "1500%");
                        AddString(unic, "percent_3000", "3000%");
                        AddString(unic, "percent_35", "35%");
                        AddString(unic, "percent_750", "750%");
                        AddString(unic, "plasma_cannon", "Plasma Cannon");
                        //AddString(unic, "plasma_pistol_v3", "Plasma Pistol (Power)");
                        //AddString(unic, "plasma_rifle_v6", "Plasma Rifle (Power)");
                        AddString(unic, "respawn_spectating", "Spectating");
                        AddString(unic, "respawn_spectating_desc", "This determines whether a player can spectate other players upon death.");
                        AddString(unic, "sentinel_beam", "Sentinel Beam");
                        //AddString(unic, "smg_v1", "SMG (Ammo)");
                        //AddString(unic, "smg_v2", "SMG (Damage)");
                        //AddString(unic, "smg_v3", "SMG (Accuracy)");
                        //AddString(unic, "smg_v4", "SMG (Rate of Fire)");
                        //AddString(unic, "smg_v6", "SMG (Power)");
                        AddString(unic, "social_team_changing_balanced_desc", "Players may only change teams if doing so will not unbalance the teams.");
                        AddString(unic, "support_weapon_desc", "Support weapon, primary only.");
                        AddString(unic, "time_seconds_11", "11 Seconds");
                        AddString(unic, "time_seconds_12", "12 Seconds");
                        AddString(unic, "time_seconds_13", "13 Seconds");
                        AddString(unic, "time_seconds_14", "14 Seconds");
                        AddString(unic, "time_seconds_16", "16 Seconds");
                        AddString(unic, "time_seconds_17", "17 Seconds");
                        AddString(unic, "time_seconds_18", "18 Seconds");
                        AddString(unic, "time_seconds_19", "19 Seconds");
                        AddString(unic, "time_seconds_21", "21 Seconds");
                        AddString(unic, "time_seconds_22", "22 Seconds");
                        AddString(unic, "time_seconds_23", "23 Seconds");
                        AddString(unic, "time_seconds_24", "24 Seconds");
                        AddString(unic, "time_seconds_6", "6 Seconds");
                        AddString(unic, "time_seconds_7", "7 Seconds");
                        AddString(unic, "time_seconds_8", "8 Seconds");
                        AddString(unic, "time_seconds_9", "9 Seconds");
                        AddString(unic, "traits_appearance_active_camo_bad", "Bad Camo");
                        AddString(unic, "traits_appearance_active_camo_bad_desc", "I can still see you");
                        AddString(unic, "traits_appearance_player_model", "Player Character");
                        AddString(unic, "traits_appearance_player_model_desc", "This determines the current player character model");
                        AddString(unic, "traits_appearance_player_model_set", "Player Character Set");
                        AddString(unic, "traits_appearance_player_model_set_desc", "This determines the current player character set");
                        AddString(unic, "traits_appearance_player_size", "player size");
                        AddString(unic, "traits_appearance_player_size_desc", "This determines the size of the player");
                        AddString(unic, "traits_appearance_waypoints_nametag_allies", "No Nametag (team only)");
                        AddString(unic, "traits_appearance_waypoints_nametag_allies_desc", "Nametag and wapoint visible for teammates only");
                        AddString(unic, "traits_appearance_waypoints_nametag_none", "No Nametag");
                        AddString(unic, "traits_appearance_waypoints_nametag_none_desc", "Nametag and wapoint not visible to anyone");
                        AddString(unic, "traits_appearance_waypoints_none_nametag", "No Nametag");
                        AddString(unic, "traits_health_damage_resistance_invincible", "Invincible");
                        AddString(unic, "traits_health_damage_resistance_invincible_desc", "The player is invulnerable to most forms of damage including assassinations");
                        AddString(unic, "traits_movement_sprint", "Sprint");
                        AddString(unic, "traits_movement_sprint_desc", "This determines the current sprint state");
                        AddString(unic, "traits_weapons_carbine", "Covenant Carbine");
                        AddString(unic, "traits_weapons_excavator", "Mauler");
                        AddString(unic, "traits_weapons_third_person_camera", "Third Person");
                        AddString(unic, "traits_weapons_third_person_camera_desc", "This determines the current camera mode");
                        AddString(unic, "unarmed", "None (Melee)");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\global_strings\global_strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "network_mode_offline", "Offline");
                        AddString(unic, "network_mode_system_link_advertise", "Online");
                        AddString(unic, "metagame_off", "Off");
                        AddString(unic, "metagame_on", "Free for All");
                        AddString(unic, "metagame_on_group", "Team");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\halox\boot_betrayer\strings")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "help", @"You were betrayed again by <betrayer-name/>. Press \UE102 if you want to boot this player from the game.");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"ui\hud\hud_messages")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        //AddString(unic, "ar_acc_picked_up", "Picked up an Assault Rifle with Accuracy mods");
                        //AddString(unic, "ar_acc_pickup", @"Hold \UE445 to pickup \r\UE139");
                        //AddString(unic, "ar_acc_swap", @"Hold \UE445 to swap for \r\UE139");
                        //AddString(unic, "ar_acc_swap_ai", @"Hold \UE445 to take ally's \r\UE139");
                        //AddString(unic, "ar_acc_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE139");
                        //AddString(unic, "ar_dmg_picked_up", "Picked up an Assault Rifle with Damage mods");
                        //AddString(unic, "ar_dmg_pickup", @"Hold \UE445 to pickup \r\UE13a");
                        //AddString(unic, "ar_dmg_swap", @"Hold \UE445 to swap for \r\UE13a");
                        //AddString(unic, "ar_dmg_swap_ai", @"Hold \UE445 to take ally's \r\UE13a");
                        //AddString(unic, "ar_dmg_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE13a");
                        //AddString(unic, "ar_pwr_picked_up", "Picked up an Assault Rifle with Power mods");
                        //AddString(unic, "ar_pwr_pickup", @"Hold \UE445 to pickup \r\UE13b");
                        //AddString(unic, "ar_pwr_swap", @"Hold \UE445 to swap for \r\UE13b");
                        //AddString(unic, "ar_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE13b");
                        //AddString(unic, "ar_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE13b");
                        //AddString(unic, "ar_rof_picked_up", "Picked up an Assault Rifle with Rate of Fire mods");
                        //AddString(unic, "ar_rof_pickup", @"Hold \UE445 to pickup \r\UE13c");
                        //AddString(unic, "ar_rof_swap", @"Hold \UE445 to swap for \r\UE13c");
                        //AddString(unic, "ar_rof_swap_ai", @"Hold \UE445 to take ally's \r\UE13c");
                        //AddString(unic, "ar_rof_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE13c");
                        AddString(unic, "black_eye", "BLACK EYE");
                        //AddString(unic, "bombrun_picked_up", "Picked up Bomb Run");
                        //AddString(unic, "bombrun_swap", @"\UE461 \UE445 to swap for Bomb Run");
                        AddString(unic, "bonus_text", "Bonus Round: Lives awarded at 10,000");
                        //AddString(unic, "br_acc_picked_up", "Picked up a Battle Rifle with Accuracy mods");
                        //AddString(unic, "br_acc_pickup", @"Hold \UE445 to pickup \r\UE13d");
                        //AddString(unic, "br_acc_swap", @"Hold \UE445 to swap for \r\UE13d");
                        //AddString(unic, "br_acc_swap_ai", @"Hold \UE445 to take ally's \r\UE13d");
                        //AddString(unic, "br_acc_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE13d");
                        //AddString(unic, "br_dmg_picked_up", "Picked up a Battle Rifle with Damage mods");
                        //AddString(unic, "br_dmg_pickup", @"Hold \UE445 to pickup \r\UE13e");
                        //AddString(unic, "br_dmg_swap", @"Hold \UE445 to swap for \r\UE13e");
                        //AddString(unic, "br_dmg_swap_ai", @"Hold \UE445 to take ally's \r\UE13e");
                        //AddString(unic, "br_dmg_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE13e");
                        //AddString(unic, "br_mag_picked_up", "Picked up a Battle Rifle with Ammo mods");
                        //AddString(unic, "br_mag_pickup", @"Hold \UE445 to pickup \r\UE13f");
                        //AddString(unic, "br_mag_swap", @"Hold \UE445 to swap for \r\UE13f");
                        //AddString(unic, "br_mag_swap_ai", @"Hold \UE445 to take ally's \r\UE13f");
                        //AddString(unic, "br_mag_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE13f");
                        //AddString(unic, "br_pwr_picked_up", "Picked up a Battle Rifle with Power mods");
                        //AddString(unic, "br_pwr_pickup", @"Hold \UE445 to pickup \r\UE140");
                        //AddString(unic, "br_pwr_swap", @"Hold \UE445 to swap for \r\UE140");
                        //AddString(unic, "br_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE140");
                        //AddString(unic, "br_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE140");
                        //AddString(unic, "br_rng_picked_up", "Picked up a Battle Rifle with Range mods");
                        //AddString(unic, "br_rng_pickup", @"Hold \UE445 to pickup \r\UE141");
                        //AddString(unic, "br_rng_swap", @"Hold \UE445 to swap for \r\UE141");
                        //AddString(unic, "br_rng_swap_ai", @"Hold \UE445 to take ally's \r\UE141");
                        //AddString(unic, "br_rng_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE141");
                        //AddString(unic, "br_rof_picked_up", "Picked up a Battle Rifle with Rate of Fire mods");
                        //AddString(unic, "br_rof_pickup", @"Hold \UE445 to pickup \r\UE142");
                        //AddString(unic, "br_rof_swap", @"Hold \UE445 to swap for \r\UE142");
                        //AddString(unic, "br_rof_swap_ai", @"Hold \UE445 to take ally's \r\UE142");
                        //AddString(unic, "br_rof_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE142");
                        AddString(unic, "buck", "BUCK");
                        AddString(unic, "catch", "CATCH");
                        //AddString(unic, "cc_acc_picked_up", "Picked up a Carbine with Accuracy mods");
                        //AddString(unic, "cc_acc_pickup", @"Hold \UE445 to pickup \r\UE143");
                        //AddString(unic, "cc_acc_swap", @"Hold \UE445 to swap for \r\UE143");
                        //AddString(unic, "cc_acc_swap_ai", @"Hold \UE445 to take ally's \r\UE143");
                        //AddString(unic, "cc_acc_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE143");
                        //AddString(unic, "cc_dmg_picked_up", "Picked up a Carbine with Damage mods");
                        //AddString(unic, "cc_dmg_pickup", @"Hold \UE445 to pickup \r\UE144");
                        //AddString(unic, "cc_dmg_swap", @"Hold \UE445 to swap for \r\UE144");
                        //AddString(unic, "cc_dmg_swap_ai", @"Hold \UE445 to take ally's \r\UE144");
                        //AddString(unic, "cc_dmg_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE144");
                        //AddString(unic, "cc_mag_picked_up", "Picked up a Carbine with Ammo mods");
                        //AddString(unic, "cc_mag_pickup", @"Hold \UE445 to pickup \r\UE145");
                        //AddString(unic, "cc_mag_swap", @"Hold \UE445 to swap for \r\UE145");
                        //AddString(unic, "cc_mag_swap_ai", @"Hold \UE445 to take ally's \r\UE145");
                        //AddString(unic, "cc_mag_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE145");
                        //AddString(unic, "cc_pwr_picked_up", "Picked up a Carbine with Power mods");
                        //AddString(unic, "cc_pwr_pickup", @"Hold \UE445 to pickup \r\UE146");
                        //AddString(unic, "cc_pwr_swap", @"Hold \UE445 to swap for \r\UE146");
                        //AddString(unic, "cc_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE146");
                        //AddString(unic, "cc_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE146");
                        //AddString(unic, "cc_rng_picked_up", "Picked up a Carbine with Range mods");
                        //AddString(unic, "cc_rng_pickup", @"Hold \UE445 to pickup \r\UE147");
                        //AddString(unic, "cc_rng_swap", @"Hold \UE445 to swap for \r\UE147");
                        //AddString(unic, "cc_rng_swap_ai", @"Hold \UE445 to take ally's \r\UE147");
                        //AddString(unic, "cc_rng_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE147");
                        //AddString(unic, "cc_rof_picked_up", "Picked up a Carbine with Rate of Fire mods");
                        //AddString(unic, "cc_rof_pickup", @"Hold \UE445 to pickup \r\UE148");
                        //AddString(unic, "cc_rof_swap", @"Hold \UE445 to swap for \r\UE148");
                        //AddString(unic, "cc_rof_swap_ai", @"Hold \UE445 to take ally's \r\UE148");
                        //AddString(unic, "cc_rof_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE148");
                        //AddString(unic, "concussiveblast_picked_up", "Picked up Concussive Blast");
                        //AddString(unic, "concussiveblast_swap", @"\UE461 \UE445 to swap for Concussive Blast");
                        //AddString(unic, "consumable_1", "consumable 1");
                        //AddString(unic, "consumable_2", "consumable 2");
                        //AddString(unic, "consumable_3", "consumable 3");
                        //AddString(unic, "consumable_4", "consumable 4");
                        AddString(unic, "dare", "DARE");
                        AddString(unic, "device_arg", @"Tap \UE445 to download COMM data to VISR|nHold \UE445 to download and play immediately");
                        AddString(unic, "dutch", "DUCH");
                        AddString(unic, "engineer", "VRGL");
                        //AddString(unic, "ex_pwr_dual", @"Hold \UE45e to dual-wield \r\UE159");
                        //AddString(unic, "ex_pwr_dual_swap", @"Hold \UE45e to swap for \r\UE159");
                        //AddString(unic, "ex_pwr_picked_up", "Picked up a Mauler with Power mods");
                        //AddString(unic, "ex_pwr_pickup", @"Hold \UE445 to pickup \r\UE160");
                        //AddString(unic, "ex_pwr_swap", @"Hold \UE445 to swap for \r\UE160");
                        //AddString(unic, "ex_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE160");
                        //AddString(unic, "ex_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE160");
                        AddString(unic, "famine", "FAMINE");
                        AddString(unic, "gm_assault_bomb_defused", "BOMB HAS BEEN DEFUSED");
                        AddString(unic, "gm_assault_bomb_dropped", "BOMB DROPPED");
                        AddString(unic, "gm_assault_bomb_dropped_message", "BOMB IS DROPPED");
                        AddString(unic, "gm_assault_bomb_exploded", "BOMB HAS EXPLODED");
                        AddString(unic, "gm_assault_bomb_planted", "BOMB HAS BEEN PLANTED");
                        AddString(unic, "gm_assault_overrun", "YOUR TEAM HAVE BEEN OVERRUN");
                        AddString(unic, "gm_assault_overrun_enemy", "YOU HAVE OVERRUN THE ENEMY TEAM");
                        AddString(unic, "gm_assault_player_defender_aim", "PROTECT THE ARMING POINTS");
                        AddString(unic, "gm_assault_player_whithout_bomb", "PROTECT THE BOMB CARRIER");
                        AddString(unic, "gm_assault_player_with_bomb", "PLANT THE BOMB AT ARMING POINT");
                        AddString(unic, "gm_bomb_controlled", "BOMB");
                        AddString(unic, "gm_bomb_planted", "BOMB PLANTED");
                        AddString(unic, "gm_flag_dropped", "FLAG DROPPED");
                        AddString(unic, "gm_flag_stolen", "FLAG STOLEN");
                        AddString(unic, "gm_hill_controlled", "KING");
                        AddString(unic, "gm_oddball_controlled", "ODDBALL");
                        //AddString(unic, "hologram_picked_up", "Picked up Hologram");
                        //AddString(unic, "hologram_swap", @"\UE461 \UE445 to swap for Hologram");
                        //AddString(unic, "idx_1", "1");
                        //AddString(unic, "idx_2", "2");
                        //AddString(unic, "idx_3", "3");
                        //AddString(unic, "idx_4", "4");
                        //AddString(unic, "invisibility_vehicle_picked_up", "Picked up Vehicle Cloaking");
                        //AddString(unic, "invisibility_vehicle_swap", @"\UE461 \UE445 to swap for Vehicle Cloaking");
                        AddString(unic, "iron", "IRON");
                        //AddString(unic, "lightningstrike_picked_up", "Picked up Lightning Strike");
                        //AddString(unic, "lightningstrike_swap", @"\UE461 \UE445 to swap for Lightning Strike");
                        AddString(unic, "message_downloaded", "Message downloaded to VISR");
                        AddString(unic, "mickey", "MCKY");
                        //AddString(unic, "mp_dmg_dual", @"Hold \UE45e to dual-wield \r\UE155");
                        //AddString(unic, "mp_dmg_dual_swap", @"Hold \UE45e to swap for \r\UE155");
                        //AddString(unic, "mp_dmg_picked_up", "Picked up a Magnum with Damage mods");
                        //AddString(unic, "mp_dmg_pickup", @"Hold \UE445 to pickup \r\UE156");
                        //AddString(unic, "mp_dmg_swap", @"Hold \UE445 to swap for \r\UE156");
                        //AddString(unic, "mp_dmg_swap_ai", @"Hold \UE445 to take ally's \r\UE156");
                        //AddString(unic, "mp_dmg_switch_to", "Out of ammo \rPress \UE446 to switch to \UE156");
                        //AddString(unic, "mp_pwr_dual", @"Hold \UE45e to dual-wield \r\UE157");
                        //AddString(unic, "mp_pwr_dual_swap", @"Hold \UE45e to swap for \r\UE157");
                        //AddString(unic, "mp_pwr_picked_up", "Picked up a Magnum with Power mods");
                        //AddString(unic, "mp_pwr_pickup", @"Hold \UE445 to pickup \r\UE158");
                        //AddString(unic, "mp_pwr_swap", @"Hold \UE445 to swap for \r\UE158");
                        //AddString(unic, "mp_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE158");
                        //AddString(unic, "mp_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE158");
                        //AddString(unic, "mr_acc_picked_up", "Picked up a DMR with Accuracy mods");
                        //AddString(unic, "mr_acc_pickup", @"Hold \UE445 to pickup \r\UE149");
                        //AddString(unic, "mr_acc_swap", @"Hold \UE445 to swap for \r\UE149");
                        //AddString(unic, "mr_acc_swap_ai", @"Hold \UE445 to take ally's \r\UE149");
                        //AddString(unic, "mr_acc_switch_to", "Out of ammo \rPress \UE446 to switch to \UE149");
                        //AddString(unic, "mr_ammo_plural", @"Picked up \UE425 rounds for DMR");
                        //AddString(unic, "mr_ammo_singular", @"Picked up \UE425 round for DMR");
                        //AddString(unic, "mr_dmg_picked_up", "Picked up a DMR with Damage mods");
                        //AddString(unic, "mr_dmg_pickup", @"Hold \UE445 to pickup \r\UE150");
                        //AddString(unic, "mr_dmg_swap", @"Hold \UE445 to swap for \r\UE150");
                        //AddString(unic, "mr_dmg_swap_ai", @"Hold \UE445 to take ally's \r\UE150");
                        //AddString(unic, "mr_dmg_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE150");
                        //AddString(unic, "mr_mag_picked_up", "Picked up a DMR with Ammo mods");
                        //AddString(unic, "mr_mag_pickup", @"Hold \UE445 to pickup \r\UE151");
                        //AddString(unic, "mr_mag_swap", @"Hold \UE445 to swap for \r\UE151");
                        //AddString(unic, "mr_mag_swap_ai", @"Hold \UE445 to take ally's \r\UE151");
                        //AddString(unic, "mr_mag_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE151");
                        //AddString(unic, "mr_picked_up", "Picked up a DMR");
                        //AddString(unic, "mr_pickup", @"Hold \UE445 to pickup \r\UE170");
                        //AddString(unic, "mr_pwr_picked_up", "Picked up a DMR with Power mods");
                        //AddString(unic, "mr_pwr_pickup", @"Hold \UE445 to pickup \r\UE152");
                        //AddString(unic, "mr_pwr_swap", @"Hold \UE445 to swap for \r\UE152");
                        //AddString(unic, "mr_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE152");
                        //AddString(unic, "mr_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE152");
                        //AddString(unic, "mr_rng_picked_up", "Picked up a RNG DMR");
                        //AddString(unic, "mr_rng_pickup", @"Hold \UE445 to pickup \r\UE153");
                        //AddString(unic, "mr_rng_swap", @"Hold \UE445 to swap for \r\UE153");
                        //AddString(unic, "mr_rng_swap_ai", @"Hold \UE445 to take ally's \r\UE153");
                        //AddString(unic, "mr_rng_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE153");
                        //AddString(unic, "mr_rof_picked_up", "Picked up a DMR with Rate of Fire mods");
                        //AddString(unic, "mr_rof_pickup", @"Hold \UE445 to pickup \r\UE154");
                        //AddString(unic, "mr_rof_swap", @"Hold \UE445 to swap for \r\UE154");
                        //AddString(unic, "mr_rof_swap_ai", @"Hold \UE445 to take ally's \r\UE154");
                        //AddString(unic, "mr_rof_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE154");
                        //AddString(unic, "mr_swap", @"Hold \UE445 to swap for \r\UE170");
                        //AddString(unic, "mr_swap_ai", @"Hold \UE445 to take ally's \r\UE170");
                        //AddString(unic, "mr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE170");
                        AddString(unic, "mythic", "MYTHIC");
                        AddString(unic, "pda_activate_all", @"Press \UE44c to open VISR database");
                        AddString(unic, "pda_activate_comm", @"Press \UE44c to open VISR COMM data");
                        AddString(unic, "pda_activate_intel", @"Press \UE44c to open VISR INTEL data");
                        AddString(unic, "pda_activate_nav", @"Press \UE44c to open VISR NAV data");
                        //AddString(unic, "pp_pwr_dual", @"Hold \UE45e to dual-wield \r\UE161");
                        //AddString(unic, "pp_pwr_dual_swap", @"Hold \UE45e to swap for \r\UE161");
                        //AddString(unic, "pp_pwr_picked_up", "Picked up a Plasma Pistol with Power mods");
                        //AddString(unic, "pp_pwr_pickup", @"Hold \UE445 to pickup \r\UE162");
                        //AddString(unic, "pp_pwr_swap", @"Hold \UE445 to swap for \r\UE162");
                        //AddString(unic, "pp_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE162");
                        //AddString(unic, "pp_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE162");
                        //AddString(unic, "pr_pwr_dual", @"Hold \UE45e to dual-wield \r\UE163");
                        //AddString(unic, "pr_pwr_dual_swap", @"Hold \UE45e to swap for \r\UE163");
                        //AddString(unic, "pr_pwr_picked_up", "Picked up a Plasma Rifle with Power mods");
                        //AddString(unic, "pr_pwr_pickup", @"Hold \UE445 to pickup \r\UE164");
                        //AddString(unic, "pr_pwr_swap", @"Hold \UE445 to swap for \r\UE164");
                        //AddString(unic, "pr_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE164");
                        //AddString(unic, "pr_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE164");
                        //AddString(unic, "prim_attr_accuracy", "ACCURACY");
                        //AddString(unic, "prim_attr_ammo", "AMMO");
                        //AddString(unic, "prim_attr_damage", "DAMAGE");
                        //AddString(unic, "prim_attr_none", " ");
                        //AddString(unic, "prim_attr_power", "POWER");
                        //AddString(unic, "prim_attr_range", "RANGE");
                        //AddString(unic, "prim_attr_rof", "RATE OF FIRE");
                        //AddString(unic, "reactive_armor_picked_up", "Picked up Reflective Shield");
                        //AddString(unic, "reactive_armor_swap", @"\UE461 \UE445 to swap for Reflective Shield");
                        AddString(unic, "romeo", "ROME");
                        AddString(unic, "skull_black_eye", "Melee to recharge your Stamina");
                        AddString(unic, "skull_catch", "Enemies love to throw grenades");
                        AddString(unic, "skull_famine", "Enemies drop low-ammo weapons");
                        AddString(unic, "skull_iron", "Respawning is disabled. Be Careful!");
                        AddString(unic, "skull_mythic", "Enemies have 2x health");
                        AddString(unic, "skull_thunderstorm", "Enemies are upgraded");
                        AddString(unic, "skull_tilt", "Enemy shields deflect bullets");
                        AddString(unic, "skull_tough_luck", "Enemies always evade danger");
                        AddString(unic, "slash", "/");
                        //AddString(unic, "smg_acc_dual", @"Hold \UE45e to dual-wield \r\UE165");
                        //AddString(unic, "smg_acc_dual_swap", @"Hold \UE45e to swap for \r\UE165");
                        //AddString(unic, "smg_acc_picked_up", "Picked up an SMG with Accuracy mods");
                        //AddString(unic, "smg_acc_pickup", @"Hold \UE445 to pickup \r\UE166");
                        //AddString(unic, "smg_acc_swap", @"Hold \UE445 to swap for \r\UE166");
                        //AddString(unic, "smg_acc_swap_ai", @"Hold \UE445 to take ally's \r\UE166");
                        //AddString(unic, "smg_acc_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE166");
                        //AddString(unic, "smg_dmg_dual", @"Hold \UE45e to dual-wield \r\UE168");
                        //AddString(unic, "smg_dmg_dual_swap", @"Hold \UE45e to swap for \r\UE168");
                        //AddString(unic, "smg_dmg_picked_up", "Picked up an SMG with Damage mods");
                        //AddString(unic, "smg_dmg_pickup", @"Hold \UE445 to pickup \r\UE169");
                        //AddString(unic, "smg_dmg_swap", @"Hold \UE445 to swap for \r\UE169");
                        //AddString(unic, "smg_dmg_swap_ai", @"Hold \UE445 to take ally's \r\UE169");
                        //AddString(unic, "smg_dmg_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE169");
                        //AddString(unic, "smg_pwr_dual", @"Hold \UE45e to dual-wield \r\UE15a");
                        //AddString(unic, "smg_pwr_dual_swap", @"Hold \UE45e to swap for \r\UE15a");
                        //AddString(unic, "smg_pwr_picked_up", "Picked up an SMG with Power mods");
                        //AddString(unic, "smg_pwr_pickup", @"Hold \UE445 to pickup \r\UE15b");
                        //AddString(unic, "smg_pwr_swap", @"Hold \UE445 to swap for \r\UE15b");
                        //AddString(unic, "smg_pwr_swap_ai", @"Hold \UE445 to take ally's \r\UE15b");
                        //AddString(unic, "smg_pwr_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE15b");
                        //AddString(unic, "smg_rof_dual", @"Hold \UE45e to dual-wield \r\UE15c");
                        //AddString(unic, "smg_rof_dual_swap", @"Hold \UE45e to swap for \r\UE15c");
                        //AddString(unic, "smg_rof_picked_up", "Picked up an SMG with Rate of Fire mods");
                        //AddString(unic, "smg_rof_pickup", @"Hold \UE445 to pickup \r\UE15d");
                        //AddString(unic, "smg_rof_swap", @"Hold \UE445 to swap for \r\UE15d");
                        //AddString(unic, "smg_rof_swap_ai", @"Hold \UE445 to take ally's \r\UE15d");
                        //AddString(unic, "smg_rof_switch_to", @"Out of ammo \rPress \UE446 to switch to \UE15d");
                        AddString(unic, "survival_bits", ">>>WAVE:\r\n>>ROUND:\r\n>SET:\r\nLIVES:");
                        AddString(unic, "thunderstorm", "THUNDERSTORM");
                        AddString(unic, "tilt", "TILT");
                        AddString(unic, "tough_luck", "TOUGH LUCK");
                        AddString(unic, "vision_picked_up", "Picked up V.I.S.R.");
                        AddString(unic, "vision_swap", @"\UE461 \UE445 to swap for V.I.S.R.");
                        AddString(unic, "visr_warning", "V.I.S.R. DETECTED");
                        //AddString(unic, "wp_pickup", @"\UE461 \UE45f to pick up\r\n");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"multiplayer\global_multiplayer_messages")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "variant_name_elimination", "Elimination");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"multiplayer\in_game_multiplayer_messages")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "assault_kill_carrier_all", "#cause_player stopped #effect_player");
                        AddString(unic, "assault_last_player_on_team", "You are the last player on the team");
                        AddString(unic, "ctf_kill_carrier_all", "#cause_player stopped #effect_player");
                        AddString(unic, "flavor_nemesis", "Nemesis");
                        AddString(unic, "flavor_revenge", "Revenge");
                        AddString(unic, "gen_kill_all", "#cause_player killed #effect_player");
                        AddString(unic, "gen_kill_col_all", "#cause_player splattered #effect_player");
                        AddString(unic, "gen_kill_deadplayer_all", "#cause_player killed #effect_player from the grave");
                        AddString(unic, "gen_kill_flame_all", "#cause_player incinerated #effect_player");
                        AddString(unic, "gen_kill_melee_all", "#cause_player beat down #effect_player");
                        AddString(unic, "gen_kill_sneak_all", "#cause_player assassinated #effect_player");
                        AddString(unic, "gen_kill_sniper_all", "#cause_player sniped #effect_player");
                        AddString(unic, "gen_kill_spartanlaser_all", "#cause_player lasered #effect_player");
                        AddString(unic, "gen_kill_sticky_all", "#cause_player stuck #effect_player");
                        AddString(unic, "gen_kill_teammate_all", "#cause_player betrayed #effect_player");
                        AddString(unic, "wp_10_in_a_row", "KILLING FRENZY");
                        AddString(unic, "wp_15_in_a_row", "RUNNING RIOT");
                        AddString(unic, "wp_20_in_a_row", "RAMPAGE");
                        AddString(unic, "wp_25_in_a_row", "UNTOUCHABLE");
                        AddString(unic, "wp_30_in_a_row", "INVINCIBLE");
                        AddString(unic, "wp_5_in_a_row", "KILLING SPREE");
                        AddString(unic, "wp_assist", "ASSIST");
                        AddString(unic, "wp_assist_to_driver", "WHEELMAN");
                        AddString(unic, "wp_broke_killing_spree", "KILLJOY");
                        AddString(unic, "wp_bulltrue", "BULLTRUE");
                        AddString(unic, "wp_extermination", "EXTERMINATION");
                        AddString(unic, "wp_flag_capture", "FLAG SCORE");
                        AddString(unic, "wp_flag_grabbed_from_stand", "FLAG RUNNER");
                        AddString(unic, "wp_flag_returned_by_player", "FLAG RETURN");
                        AddString(unic, "wp_from_the_grave", "DEATH FROM THE GRAVE");
                        AddString(unic, "wp_headshot", "HEADSHOT");
                        AddString(unic, "wp_hijack", "HIJACKER");
                        AddString(unic, "wp_hill_kill_5x", "HAIL TO THE KING");
                        AddString(unic, "wp_kill", "KILL");
                        AddString(unic, "wp_kill_bash", "BEAT DOWN");
                        AddString(unic, "wp_kill_bash_behind", "ASSASSIN");
                        AddString(unic, "wp_kill_flag", "FLAG KILL");
                        AddString(unic, "wp_kill_flag_carrier", "KILLED FLAG CARRIER");
                        AddString(unic, "wp_kill_flame", "INCINERATION");
                        AddString(unic, "wp_kill_laser", "LASER KILL");
                        AddString(unic, "wp_kill_oddball", "ODDBALL KILL");
                        AddString(unic, "wp_kill_sniper", "SNIPER KILL");
                        AddString(unic, "wp_kill_sticky_grenade", "GRENADE STICK");
                        AddString(unic, "wp_multikill_x10", "KILLIONAIRE");
                        AddString(unic, "wp_multikill_x2", "DOUBLE KILL");
                        AddString(unic, "wp_multikill_x3", "TRIPLE KILL");
                        AddString(unic, "wp_multikill_x4", "OVERKILL");
                        AddString(unic, "wp_multikill_x5", "KILLTACULAR");
                        AddString(unic, "wp_multikill_x6", "KILLTROCITY");
                        AddString(unic, "wp_multikill_x7", "KILLIMANJARO");
                        AddString(unic, "wp_multikill_x8", "KILLTASTROPHE");
                        AddString(unic, "wp_multikill_x9", "KILLAPOCALYPSE");
                        AddString(unic, "wp_perfection", "PERFECTION");
                        AddString(unic, "wp_revenge", "REVENGE");
                        AddString(unic, "wp_skyjack", "SKYJACKER");
                        AddString(unic, "wp_splatter", "SPLATTER");
                        AddString(unic, "wp_splatter_5x", "SPLATTER SPREE");
                        CacheContext.Serialize(stream, tag, unic);
                    }

                    if (tag.IsInGroup("unic") && tag.Name == $@"multiplayer\in_game_survival_messages")
                    {
                        var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(stream, tag);
                        AddString(unic, "gen_kill_cause_player", "You killed #effect_player");
                        AddString(unic, "gen_kill_effect_player", "#cause_player killed you");
                        CacheContext.Serialize(stream, tag, unic);
                    }
                }
            }
        }
    }
}