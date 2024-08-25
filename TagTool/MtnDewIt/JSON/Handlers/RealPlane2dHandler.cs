using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealPlane2dHandler : JsonConverter<RealPlane2d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealPlane2dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealPlane2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Normal: {value.Normal}, Distance: {value.Distance}");
        }

        public override RealPlane2d ReadJson(JsonReader reader, Type objectType, RealPlane2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealPlane2d();
        }
    }
}
