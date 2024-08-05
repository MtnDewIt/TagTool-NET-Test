using Newtonsoft.Json;
using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Resolvers;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagObjectHandler 
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public TagObjectHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public string Serialize(TagObject input)
        {
            var tagStructureInfo = TagStructure.GetTagStructureInfo(input.TagData.GetType(), Cache.Version, Cache.Platform);

            var stringIdHandler = new StringIdHandler(Cache, CacheContext);
            var cachedTagHandler = new CachedTagHandler(Cache, CacheContext);
            var tagHandler = new TagHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    stringIdHandler,
                    cachedTagHandler,
                    tagHandler,
                },
                Formatting = Formatting.Indented,
                ContractResolver = new TagStructureResolver(tagStructureInfo, Cache, CacheContext),
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public TagObject Deserialize(string input)
        {
            var stringIdHandler = new StringIdHandler(Cache, CacheContext);
            var cachedTagHandler = new CachedTagHandler(Cache, CacheContext);
            var tagHandler = new TagHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    stringIdHandler,
                    cachedTagHandler,
                    tagHandler,
                },
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<TagObject>(input, settings);
        }
    }
}
