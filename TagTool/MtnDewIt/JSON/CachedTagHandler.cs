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
            var cachedTag = new InlineCachedTag(Cache.TagCache.TagDefinitions.GetTagDefinitionType(value.Group).Name, value.Name);

            serializer.Serialize(writer, cachedTag);
        }

        public override CachedTag ReadJson(JsonReader reader, Type objectType, CachedTag existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var inlineTag = serializer.Deserialize<InlineCachedTag>(reader);

            if (inlineTag != null) 
            {
                // TODO: REDO ALL THIS, BECAUSE THIS SUCKS

                // This needs a complete rework. General idea would be to keep the current system where the tag type and name are separate,
                // but use one of the other tag retrieval functions, which uses the full name, so all that needs to be done is that the inline tag type 
                // justs needs to be appended to the end of the inline tag name.

                Type tagType = Type.GetType($@"TagTool.Tags.Definitions.{inlineTag.Type}");

                if (tagType == null) 
                {
                    // This is only here because apparently keeping all the definitions in the same namespace is rocket science
                    tagType = Type.GetType($@"TagTool.Tags.{inlineTag.Type}");
                }

                // I hate reflection, but I'm forced to use it since all the tag retrieval functions use template functions :/
                // Another option is I use one of the other functions which uses the full tag name, including the tag type.
                var method = GetType().GetMethod(nameof(GetCachedTag));
                var genericMethod = method.MakeGenericMethod(tagType);
                var cachedTag = genericMethod.Invoke(this, [inlineTag.Name]);

                return (CachedTag)cachedTag;
            }

            return null;
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
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