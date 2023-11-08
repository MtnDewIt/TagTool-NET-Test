using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_ctf_ctf_respawn_on_capture_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_ctf_ctf_respawn_on_capture_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\ctf\ctf_respawn_on_capture");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntCtfRespawnDelay;
            sily.Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture");
            sily.Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    Name = CacheContext.StringTable.GetStringId($@"disabled"),
                    Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_disabled_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_ally"),
                    Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_ally_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_enemy"),
                    Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_enemy_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 3,
                    Name = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_all"),
                    Description = CacheContext.StringTable.GetStringId($@"territories_respawn_on_capture_all_desc"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
