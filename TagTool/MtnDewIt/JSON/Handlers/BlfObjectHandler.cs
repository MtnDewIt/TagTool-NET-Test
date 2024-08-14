using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BlfObjectHandler 
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public BlfObjectHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public string Serialize(BlfObject input)
        {
            var tagHandler = new TagHandler(Cache, CacheContext);
            var tagStructureHandler = new TagStructureHandler(Cache, CacheContext);
            var enumHandler  = new EnumHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    tagHandler,
                    tagStructureHandler,
                    enumHandler,
                },
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public BlfObject Deserialize(string input)
        {
            var tagHandler = new TagHandler(Cache, CacheContext);
            var tagStructureHandler = new TagStructureHandler(Cache, CacheContext);
            var enumHandler  = new EnumHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    tagHandler,
                    tagStructureHandler,
                    enumHandler,
                },
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<BlfObject>(input, settings);
        }
    }
}
