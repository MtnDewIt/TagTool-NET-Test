using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_respawn_options_respawn_time_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_respawn_options_respawn_time_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\respawn_options\respawn_time");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalRespawnTime;
            sily.Name = CacheContext.StringTable.GetStringId($@"respawn_time");
            sily.Description = CacheContext.StringTable.GetStringId($@"respawn_time_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Name = CacheContext.StringTable.GetStringId($@"time_instant"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_1"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 3,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_3"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 4,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_4"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    EnumeratedValue = 5,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_5"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 6,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_6"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 7,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_7"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 8,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_8"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 9,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_9"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 10,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_10"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 11,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_11"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 12,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_12"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 13,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_13"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 14,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_14"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 15,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_15"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 16,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_16"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 17,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_17"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 18,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_18"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 19,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_19"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 20,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_20"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 21,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_21"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 22,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_22"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 23,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_23"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 24,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_24"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 25,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_25"),
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
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_60"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 90,
                    Name = CacheContext.StringTable.GetStringId($@"time_seconds_90"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 120,
                    Name = CacheContext.StringTable.GetStringId($@"time_minutes_2"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 180,
                    Name = CacheContext.StringTable.GetStringId($@"time_minutes_3"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
