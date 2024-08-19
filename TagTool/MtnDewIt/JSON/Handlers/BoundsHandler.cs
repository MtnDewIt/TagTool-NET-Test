using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsHandler : JsonConverter<IBounds>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public BoundsHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, IBounds value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override IBounds ReadJson(JsonReader reader, Type objectType, IBounds existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new Bounds<byte>();
        }
    }
}
