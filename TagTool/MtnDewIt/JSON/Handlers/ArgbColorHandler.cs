using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class ArgbColorHandler : JsonConverter<ArgbColor>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public ArgbColorHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, ArgbColor value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override ArgbColor ReadJson(JsonReader reader, Type objectType, ArgbColor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new ArgbColor();
        }
    }
}
