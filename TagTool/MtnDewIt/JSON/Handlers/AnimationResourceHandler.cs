using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class AnimationResourceHandler : JsonConverter<AnimationResource>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public AnimationResourceHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, AnimationResource value, JsonSerializer serializer)
        {
            // Maybe if I ever add support for editing these JSON files in epsilon?
        }

        public override AnimationResource ReadJson(JsonReader reader, Type objectType, AnimationResource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //return serializer.Deserialize<AnimationResource>(reader);

            return null;
        }
    }
}