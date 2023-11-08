using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_halox_pregame_lobby_strings_multilingual_unicode_string_list : TagFile
    {
        public ui_halox_pregame_lobby_strings_multilingual_unicode_string_list(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<MultilingualUnicodeStringList>($@"ui\halox\pregame_lobby\strings");
            var unic = CacheContext.Deserialize<MultilingualUnicodeStringList>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, unic);
        }
    }
}
