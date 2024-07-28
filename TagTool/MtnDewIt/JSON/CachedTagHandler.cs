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
            writer.WriteValue($"GetCachedTag<{Cache.TagCache.TagDefinitions.GetTagDefinitionType(value.Group).Name}>(\"{value.Name}\")");
        }

        public override CachedTag ReadJson(JsonReader reader, Type objectType, CachedTag existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // TODO: Add a proper reader
            return null;
        }
    }
}