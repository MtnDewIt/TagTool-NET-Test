using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealPlane3dHandler : JsonConverter<RealPlane3d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealPlane3dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealPlane3d value, JsonSerializer serializer)
        {
            writer.WriteValue($@" Normal: {value.Normal} , Distance:  {value.Distance}");
        }

        public override RealPlane3d ReadJson(JsonReader reader, Type objectType, RealPlane3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealPlane3d();
        }
    }
}
