using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class Rectangle2dHandler : JsonConverter<Rectangle2d>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public Rectangle2dHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, Rectangle2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Top: {value.Top}, Left: {value.Left}, Bottom: {value.Bottom}, Right: {value.Right}");
        }

        public override Rectangle2d ReadJson(JsonReader reader, Type objectType, Rectangle2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new Rectangle2d();
        }
    }
}
