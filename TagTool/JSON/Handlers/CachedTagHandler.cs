using Newtonsoft.Json;
using System;
using System.IO;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;
using TagTool.JSON.Parsers;
using System.Collections.Generic;
using TagTool.Common.Logging;

namespace TagTool.JSON.Handlers
{
    public class CachedTagHandler : JsonConverter<CachedTag>
    {
        private GameCache Cache;
        private GameCacheEldoradoBase CacheContext;
        private Stream CacheStream;
        private TagObjectParser TagParser;
        private List<string> ParsedTags;

        public CachedTagHandler(GameCache cache, GameCacheEldoradoBase cacheContext, Stream cacheStream, TagObjectParser tagParser, List<string> parsedTags)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            TagParser = tagParser;
            ParsedTags = parsedTags;
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
                if (!ParsedTags.Contains($@"{inlineTag.Name}.{inlineTag.Type}")) 
                {
                    ParsedTags.Add($@"{inlineTag.Name}.{inlineTag.Type}");

                    Cache.TagCache.TryGetTag($@"{inlineTag.Name}.{inlineTag.Type}", out var result);

                    if (result == null) 
                    {
                        Cache.TagCache.TryParseGroupTag(inlineTag.Type, out var tagGroup);
                        var type = Cache.TagCache.TagDefinitions.GetTagDefinitionType(tagGroup);
                        result = Cache.TagCache.AllocateTag(type, inlineTag.Name);
                        var definition = (TagStructure)Activator.CreateInstance(type);
                        Cache.Serialize(CacheStream, result, definition);
                        CacheContext.SaveTagNames();
                    }

                    TagParser.ParseFile($@"{inlineTag.Name}.{inlineTag.Type}");
                }

                return GetCachedTag(inlineTag.Name, inlineTag.Type);
            }

            return null;
        }

        public CachedTag GetCachedTag(string tagName, string tagType)
        {
            if (Cache.TagCache.TryGetTag($@"{tagName}.{tagType}", out var result))
            {
                return result;
            }
            else
            {
                Log.Warning($@"Could not find tag: '{tagName}.{tagType}'. Assigning null tag instead");
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