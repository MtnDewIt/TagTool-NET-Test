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
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("I: ", "")
            .Replace("J: ", "")
            .Replace("K: ", "")
            .Replace("W: ", "")
            .Split(',');

            var i = float.Parse(valueArray[0]);
            var j = float.Parse(valueArray[1]);
            var k = float.Parse(valueArray[2]);
            var w = float.Parse(valueArray[3]);

            return new RealQuaternion(i, j, k, w);
        }
    }
}
