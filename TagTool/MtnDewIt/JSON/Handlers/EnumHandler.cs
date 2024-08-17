using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class EnumHandler : JsonConverter<Enum>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public EnumHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, Enum value, JsonSerializer serializer)
        {
            string enumValue = value.ToString();

            writer.WriteValue(enumValue);
        }

        public override Enum ReadJson(JsonReader reader, Type objectType, Enum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string enumValue = reader.Value.ToString();

            return (Enum)Enum.Parse(objectType, enumValue, true);
        }
    }
}