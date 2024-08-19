using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealRgbColorHandler : JsonConverter<RealRgbColor>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealRgbColorHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealRgbColor value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override RealRgbColor ReadJson(JsonReader reader, Type objectType, RealRgbColor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealRgbColor();
        }
    }
}
