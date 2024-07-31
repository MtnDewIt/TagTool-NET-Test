using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON
{
    public class CachedTagHandler : JsonConverter<CachedTag>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public CachedTagHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, CachedTag value, JsonSerializer serializer)
        {
            var cachedTag = new InlineCachedTag(Cache.TagCache.TagDefinitions.GetTagDefinitionType(value.Group).Name, value.Name);

            serializer.Serialize(writer, cachedTag);
        }

        public override CachedTag ReadJson(JsonReader reader, Type objectType, CachedTag existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // TODO: Add a proper reader

            // var inlineTag = /* some function which retrieves the inline tag object from the json */

            // return GetCachedTag<ConvertToType(inlineTag.Type)>(inlineTag.Name);

            return null;
        }
    }

    public class InlineCachedTag
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public InlineCachedTag(string type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}