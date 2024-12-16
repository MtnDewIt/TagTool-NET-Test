using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class StringIdHandler : JsonConverter<StringId>
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;

        public StringIdHandler(GameCache cache, GameCacheHaloOnlineBase cacheContext)
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
            string stringId = reader.Value.ToString();

            return stringId == $@"invalid" ? StringId.Invalid : CacheContext.StringTable.GetOrAddString(stringId);
        }
    }
}