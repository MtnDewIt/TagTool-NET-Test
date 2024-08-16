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

        private static List<JsonConverter> Converters;

        public MapObjectHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;

            Converters = new List<JsonConverter>
            {
                new StringIdHandler(Cache, CacheContext),
                new TagHandler(Cache, CacheContext),
                new TagStructureHandler(Cache, CacheContext),
                new FileAuthorHandler(Cache, CacheContext),
                new EnumHandler(Cache, CacheContext),
            };
        }

        public string Serialize(MapObject input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public MapObject Deserialize(string input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<MapObject>(input, settings);
        }
    }
}
