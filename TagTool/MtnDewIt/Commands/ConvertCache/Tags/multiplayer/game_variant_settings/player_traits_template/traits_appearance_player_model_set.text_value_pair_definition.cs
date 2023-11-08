using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_model_set_text_value_pair_definition : TagFile
    {
        public multiplayer_game_variant_settings_player_traits_template_traits_appearance_player_model_set_text_value_pair_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<TextValuePairDefinition>($@"multiplayer\game_variant_settings\player_traits_template\traits_appearance_player_model_set");
            var sily = CacheContext.Deserialize<TextValuePairDefinition>(Stream, tag);
            sily.Parameter = (TextValuePairDefinition.GameVariantParameters)648;
            sily.Name = CacheContext.StringTable.GetStringId($@"traits_appearance_player_model_set");
            sily.Description = CacheContext.StringTable.GetStringId($@"traits_appearance_player_model_set_desc");
            CacheContext.Serialize(Stream, tag, sily);
        }
    }
}
