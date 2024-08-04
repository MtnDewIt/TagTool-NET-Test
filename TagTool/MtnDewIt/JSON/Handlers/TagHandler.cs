using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagHandler : JsonConverter<Tag> 
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public TagHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, Tag value, JsonSerializer serializer)
        {
            var tag = new InlineTag(value.ToString());

            serializer.Serialize(writer, tag);
        }

        public override Tag ReadJson(JsonReader reader, Type objectType, Tag existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var inlineTag = serializer.Deserialize<InlineTag>(reader);

            return new Tag(inlineTag.Tag);
        }
    }

    public class InlineTag 
    {
        public string Tag { get; set; }

        public InlineTag(string tag)
        {
            Tag = tag;
        }
    }
}
