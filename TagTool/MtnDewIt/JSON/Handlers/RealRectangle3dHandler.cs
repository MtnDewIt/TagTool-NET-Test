using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealRectangle3dHandler : JsonConverter<RealRectangle3d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealRectangle3dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealRectangle3d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"X0: {value.X0}, X1: {value.X1}, Y0: {value.Y0}, Y1: {value.Y1}, Z0: {value.Z0}, Z1: {value.Z1}");
        }

        public override RealRectangle3d ReadJson(JsonReader reader, Type objectType, RealRectangle3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealRectangle3d();
        }
    }
}
