using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BlfObjectHandler 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        
        private static List<JsonConverter> Converters;

        public BlfObjectHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;

            Converters = new List<JsonConverter>
            {
                new TagHandler(Cache, CacheContext),
                new TagStructureHandler(Cache, CacheContext),
                new EnumHandler(Cache, CacheContext),
            };
        }

        public string Serialize(BlfObject input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public BlfObject Deserialize(string input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<BlfObject>(input, settings);
        }
    }
}
