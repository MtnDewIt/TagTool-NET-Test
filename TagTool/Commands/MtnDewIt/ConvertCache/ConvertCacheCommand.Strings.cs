using System.Text.RegularExpressions;
using System;
using TagTool.Tags.Definitions;
using System.Linq;
using System.Globalization;
using TagTool.Common;

namespace TagTool.Commands.MtnDewIt
{
    partial class ConvertCacheCommand : Command
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
                        AddString(unic, "assault_rifle_v2", "Assault Rifle (Damage)");
                        AddString(unic, "assault_rifle_v3", "Assault Rifle (Accuracy)");
                        AddString(unic, "assault_rifle_v4", "Assault Rifle (Rate of Fire)");
                        AddString(unic, "assault_rifle_v5", "Assault Rifle (Accuracy)");
                        AddString(unic, "assault_rifle_v6", "Assault Rifle (Power)");
                        AddString(unic, "balanced", "Balancing Only");
                        AddString(unic, "base", "No Upgrades");
                        AddString(unic, "battle_rifle_v1", "Battle Rifle (Ammo)");
                        AddString(unic, "battle_rifle_v2", "Battle Rifle (Damage)");
                        AddString(unic, "battle_rifle_v3", "Battle Rifle (Accuracy)");
                        AddString(unic, "battle_rifle_v4", "Battle Rifle (Rate of Fire)");
                        AddString(unic, "battle_rifle_v5", "Battle Rifle (Range)");
                        AddString(unic, "battle_rifle_v6", "Battle Rifle (Power)");
                        AddString(unic, "bottomless_clip", "bottomless clip");
                        AddString(unic, "carbine", "Covenant Carbine");
                        AddString(unic, "covenant_carbine_v1", "Covenant Carbine (Ammo)");
                        AddString(unic, "covenant_carbine_v2", "Covenant Carbine (Damage)");
                        AddString(unic, "covenant_carbine_v3", "Covenant Carbine (Accuracy)");
                        AddString(unic, "covenant_carbine_v4", "Covenant Carbine (Rate of Fire)");
                        AddString(unic, "covenant_carbine_v5", "Covenant Carbine (Range)");
                        AddString(unic, "covenant_carbine_v6", "Covenant Carbine (Power)");
                        AddString(unic, "dmr", "DMR");
                        AddString(unic, "dmr_v1", "DMR (Ammo)");
                        AddString(unic, "dmr_v2", "DMR (Damage)");
                        AddString(unic, "dmr_v3", "DMR (Accuracy)");
                        AddString(unic, "dmr_v4", "DMR (Rate of Fire)");
                        AddString(unic, "dmr_v5", "DMR (Range)");
                        AddString(unic, "dmr_v6", "DMR (Power)");
                        AddString(unic, "excavator", "Mauler");
                        AddString(unic, "excavator_v3", "Mauler (Power)");
                        AddString(unic, "flamethrower", "Flamethrower");
                        AddString(unic, "fuel_rod_gun", "Fuel Rod Gun");
                        AddString(unic, "info", "All weapons are their base versions.");
                        AddString(unic, "machinegun_turret", "Machine Gun Turret");
                        AddString(unic, "magnum_v2", "Magnum (Damage)");
                        AddString(unic, "magnum_v3", "Magnum (Power)");
                        AddString(unic, "missile_pod", "Missile Pod");
                        AddString(unic, "percent_15", "15%");
                        AddString(unic, "percent_1500", "1500%");
                        AddString(unic, "percent_3000", "3000%");
                        AddString(unic, "percent_35", "35%");
                        AddString(unic, "percent_750", "750%");
                        AddString(unic, "plasma_cannon", "Plasma Cannon");
                        AddString(unic, "plasma_pistol_v3", "Plasma Pistol (Power)");
                        AddString(unic, "plasma_rifle_v6", "Plasma Rifle (Power)");
                        AddString(unic, "respawn_spectating", "Spectating");
                        AddString(unic, "respawn_spectating_desc", "This determines whether a player can spectate other players upon death.");
                        AddString(unic, "sentinel_beam", "Sentinel Beam");
                        AddString(unic, "smg_v1", "SMG (Ammo)");
                        AddString(unic, "smg_v2", "SMG (Damage)");
                        AddString(unic, "smg_v3", "SMG (Accuracy)");
                        AddString(unic, "smg_v4", "SMG (Rate of Fire)");
                        AddString(unic, "smg_v6", "SMG (Power)");
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
                }
            }
        }
    }
}