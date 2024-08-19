using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class DatumHandleHandler : JsonConverter<DatumHandle>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public DatumHandleHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, DatumHandle value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override DatumHandle ReadJson(JsonReader reader, Type objectType, DatumHandle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new DatumHandle();
        }
    }
}
