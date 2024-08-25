using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealQuaternionHandler : JsonConverter<RealQuaternion>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealQuaternionHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealQuaternion value, JsonSerializer serializer)
        {
            writer.WriteValue($@"I: {value.I}, J: {value.J}, K: {value.K}, W: {value.W}");
        }

        public override RealQuaternion ReadJson(JsonReader reader, Type objectType, RealQuaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealQuaternion();
        }
    }
}
