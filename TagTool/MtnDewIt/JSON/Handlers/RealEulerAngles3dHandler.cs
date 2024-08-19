using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealEulerAngles3dHandler : JsonConverter<RealEulerAngles3d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealEulerAngles3dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealEulerAngles3d value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override RealEulerAngles3d ReadJson(JsonReader reader, Type objectType, RealEulerAngles3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealEulerAngles3d();
        }
    }
}
