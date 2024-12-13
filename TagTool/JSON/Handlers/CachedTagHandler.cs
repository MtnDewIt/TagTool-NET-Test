using Newtonsoft.Json;
using System;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;
using TagTool.JSON.Parsers;
using System.Collections.Generic;

namespace TagTool.JSON.Handlers
{
    public class CachedTagHandler : JsonConverter<CachedTag>
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;
        private Stream CacheStream;
        private TagObjectParser TagParser;
        private List<string> ParsedTags;

        public CachedTagHandler(GameCache cache, GameCacheHaloOnlineBase cacheContext, Stream cacheStream, TagObjectParser tagParser, List<string> parsedTags)
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

                    // TODO: Maybe create an empty instance of the tag, then serialize the data
                    // This fixes an issue where if a tag contains a cyclic reference, it will fail to find said reference, as the tag doesn't exist until the tag object is finished being read

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