using Newtonsoft.Json;
using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class MapObjectHandler
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public MapObjectHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public string Serialize(object input)
        {
            var stringIdHandler = new StringIdHandler(Cache, CacheContext);
            var cachedTagHandler = new CachedTagHandler(Cache, CacheContext);
            var tagHandler = new  TagHandler(Cache, CacheContext);
            var fileAuthorHandler = new FileAuthorHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    stringIdHandler,
                    cachedTagHandler,
                    tagHandler,
                    fileAuthorHandler,
                },
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public MapObject Deserialize(string input)
        {
            var stringIdHandler = new StringIdHandler(Cache, CacheContext);
            var cachedTagHandler = new CachedTagHandler(Cache, CacheContext);
            var tagHandler = new TagHandler(Cache, CacheContext);
            var fileAuthorHandler = new FileAuthorHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    stringIdHandler,
                    cachedTagHandler,
                    tagHandler,
                    fileAuthorHandler,
                },
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<MapObject>(input, settings);
        }
    }
}
