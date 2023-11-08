using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_infection_infection_haven_movement_time_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_infection_infection_haven_movement_time_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\infection\infection_haven_movement_time");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntInfectionHavenMovementTime;
            sily.Name = CacheContext.StringTable.GetStringId($@"infection_haven_movement_time");
            sily.Description = CacheContext.StringTable.GetStringId($@"infection_haven_movement_time_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair> 
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    Name = CacheContext.StringTable.GetStringId($@"disabled"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 5,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_5"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 10,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_10"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 15,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_15"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 20,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_20"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 30,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_30"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 45,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_45"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 60,
                    Name = CacheContext.StringTable.GetStringId($@"time_minutes_1"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 120,
                    Name = CacheContext.StringTable.GetStringId($@"time_minutes_2"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
