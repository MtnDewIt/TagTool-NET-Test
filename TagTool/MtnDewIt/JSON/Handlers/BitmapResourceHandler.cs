using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BitmapResourceHandler : JsonConverter<BitmapResource>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public BitmapResourceHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, BitmapResource value, JsonSerializer serializer)
        {
            // Maybe if I ever add support for editing these JSON files in epsilon?
        }

        public override BitmapResource ReadJson(JsonReader reader, Type objectType, BitmapResource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //return serializer.Deserialize<BitmapResource>(reader);

            return null;
        }
    }
}