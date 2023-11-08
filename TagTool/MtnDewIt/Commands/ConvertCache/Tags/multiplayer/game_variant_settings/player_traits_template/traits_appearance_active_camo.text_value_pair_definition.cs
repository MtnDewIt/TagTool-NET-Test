using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_appearance_active_camo_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_appearance_active_camo_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_active_camo");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = TextValuePairDefinition.GameVariantParameters.IntGlobalTraitsTemplateActiveCamo;
            sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo");
            sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_desc");
            sily.TextValuePairs = new List<TextValuePairDefinition.TextValuePair>
            {
                new TextValuePairDefinition.TextValuePair
                {
                    Flags = TextValuePairDefinition.TextValuePair.TextValuePairFlags.DefaultSetting,
                    Name = CacheContext.StringTable.GetStringId($@"unchanged"),
                    Description = CacheContext.StringTable.GetStringId($@"unchanged_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 1,
                    Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_off"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_off_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 2,
                    Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_bad"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_bad_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 3,
                    Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_poor"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_poor_desc"),
                },
                new TextValuePairDefinition.TextValuePair
                {
                    EnumeratedValue = 4,
                    Name = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_good"),
                    Description = CacheContext.StringTable.GetStringId($@"traits_appearance_active_camo_good_desc"),
                },
            };
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
