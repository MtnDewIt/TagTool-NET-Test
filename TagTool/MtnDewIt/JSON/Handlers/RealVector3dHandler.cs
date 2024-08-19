using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealVector3dHandler : JsonConverter<RealVector3d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealVector3dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealVector3d value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override RealVector3d ReadJson(JsonReader reader, Type objectType, RealVector3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealVector3d();
        }
    }
}
