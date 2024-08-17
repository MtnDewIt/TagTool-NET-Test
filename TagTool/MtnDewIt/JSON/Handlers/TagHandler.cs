using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagHandler : JsonConverter<Tag> 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public TagHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, Tag value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override Tag ReadJson(JsonReader reader, Type objectType, Tag existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var tag = reader.Value.ToString();

            return new Tag(tag);
        }
    }
}
