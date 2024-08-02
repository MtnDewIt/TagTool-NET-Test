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
            var stringId = new InlineStringId(Cache.StringTable.GetString(value));

            serializer.Serialize(writer, stringId);
        }

        public override StringId ReadJson(JsonReader reader, Type objectType, StringId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var inlineStringId = serializer.Deserialize<InlineStringId>(reader);

            return CacheContext.StringTable.GetOrAddString(inlineStringId.StringId);
        }
    }

    public class InlineStringId
    {
        public string StringId { get; set; }

        public InlineStringId(string stringId)
        {
            StringId = stringId;
        }
    }
}