using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealArgbColorHandler : JsonConverter<RealArgbColor>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealArgbColorHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealArgbColor value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override RealArgbColor ReadJson(JsonReader reader, Type objectType, RealArgbColor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealArgbColor();
        }
    }
}
