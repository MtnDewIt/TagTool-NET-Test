using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealPoint2dHandler : JsonConverter<RealPoint2d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealPoint2dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealPoint2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"X: {value.X}, Y: {value.Y}");
        }

        public override RealPoint2d ReadJson(JsonReader reader, Type objectType, RealPoint2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("X: ", "")
            .Replace("Y: ", "")
            .Split(',');

            var x = float.Parse(valueArray[0]);
            var y = float.Parse(valueArray[1]);

            return new RealPoint2d(x, y);
        }
    }
}
