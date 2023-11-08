using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_game_options_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_game_options_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\game_options\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
