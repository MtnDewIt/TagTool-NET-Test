using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_social_options_team_changing_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_social_options_team_changing_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\social_options\team_changing");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTeamChanging;
            sily.Name = CacheContext.StringTable.GetStringId($@"social_team_changing");
            sily.Description = CacheContext.StringTable.GetStringId($@"social_team_changing_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Name = CacheContext.StringTable.GetStringId($@"not_allowed"),
                    Description = CacheContext.StringTable.GetStringId($@"social_team_changing_disabled_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"allowed"),
                    Description = CacheContext.StringTable.GetStringId($@"social_team_changing_enabled_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"balanced"),
                    Description = CacheContext.StringTable.GetStringId($@"social_team_changing_balanced_desc"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
