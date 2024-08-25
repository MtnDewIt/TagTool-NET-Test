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
            writer.WriteValue($@"Red: {value.Red}, Green: {value.Green}, Blue: {value.Blue}");
        }

        public override RealRgbColor ReadJson(JsonReader reader, Type objectType, RealRgbColor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Red: ", "")
            .Replace("Green: ", "")
            .Replace("Blue: ", "")
            .Split(',');

            var r = float.Parse(valueArray[0]);
            var g = float.Parse(valueArray[1]);
            var b = float.Parse(valueArray[2]);

            return new RealRgbColor(r, g, b);
        }
    }
}
