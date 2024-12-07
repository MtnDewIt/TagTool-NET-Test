using Newtonsoft.Json;
using System;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.JSON.Handlers
{
    public class CachedTagHandler : JsonConverter<CachedTag>
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;
        private Stream CacheStream;

        public CachedTagHandler(GameCache cache, GameCacheHaloOnlineBase cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
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
                return GenerateCachedTag(inlineTag.Name, inlineTag.Type);
            }

            return null;
        }

        public CachedTag GenerateCachedTag(string tagName, string tagType)
        {
            if (!Cache.TagCache.TryGetTag($@"{tagName}.{tagType}", out var result))
            {
                Cache.TagCache.TryParseGroupTag(tagType, out var tagGroup);
                var type = Cache.TagCache.TagDefinitions.GetTagDefinitionType(tagGroup);
                result = Cache.TagCache.AllocateTag(type, tagName);
                var definition = (TagStructure)Activator.CreateInstance(type);
                CacheContext.Serialize(CacheStream, result, definition);
                CacheContext.SaveTagNames();
            }

            return result;
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