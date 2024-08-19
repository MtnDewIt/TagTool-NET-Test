using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealMatrix4x3Handler : JsonConverter<RealMatrix4x3>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealMatrix4x3Handler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealMatrix4x3 value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override RealMatrix4x3 ReadJson(JsonReader reader, Type objectType, RealMatrix4x3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealMatrix4x3();
        }
    }
}
