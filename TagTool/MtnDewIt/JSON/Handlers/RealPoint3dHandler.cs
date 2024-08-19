using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealPoint3dHandler : JsonConverter<RealPoint3d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealPoint3dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealPoint3d value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override RealPoint3d ReadJson(JsonReader reader, Type objectType, RealPoint3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealPoint3d();
        }
    }
}
