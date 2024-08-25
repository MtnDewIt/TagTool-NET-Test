using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class AngleHandler : JsonConverter<Angle>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public AngleHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, Angle value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Degrees: {value.Degrees}");
        }

        public override Angle ReadJson(JsonReader reader, Type objectType, Angle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new Angle();
        }
    }
}
