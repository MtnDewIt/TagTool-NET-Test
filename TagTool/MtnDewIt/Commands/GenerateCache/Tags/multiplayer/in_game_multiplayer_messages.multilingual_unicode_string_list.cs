using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class multiplayer_in_game_multiplayer_messages_multilingual_unicode_string_list : TagFile
    {
        public multiplayer_in_game_multiplayer_messages_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"multiplayer\in_game_multiplayer_messages");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
