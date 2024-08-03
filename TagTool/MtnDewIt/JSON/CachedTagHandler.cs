using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Tags;
using Assimp;

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
            var cachedTag = new InlineCachedTag(TagStructure.GetTagStructureInfo(Cache.TagCache.TagDefinitions.GetTagDefinitionType(value.Group), Cache.Version, Cache.Platform).Structure.Name, value.Name);

            serializer.Serialize(writer, cachedTag);
        }

        public override CachedTag ReadJson(JsonReader reader, Type objectType, CachedTag existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var inlineTag = serializer.Deserialize<InlineCachedTag>(reader);

            if (inlineTag != null) 
            {
                return GetCachedTag(inlineTag.Name, inlineTag.Type);
            }

            return null;
        }

        public CachedTag GetCachedTag(string tagName, string tagType)
        {
            if (CacheContext.TagCache.TryGetTag($@"{tagName}.{tagType}", out var result)) 
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{tagType}'. Assigning null tag instead");
                return null;
            }
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