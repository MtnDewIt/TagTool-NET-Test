using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON
{
    public class StringIdHandler : JsonConverter<StringId>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public StringIdHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, StringId value, JsonSerializer serializer)
        {
            writer.WriteValue(Cache.StringTable.GetString(value));
        }

        public override StringId ReadJson(JsonReader reader, Type objectType, StringId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // TODO: Add a proper reader
            return StringId.Invalid;
        }
    }
}