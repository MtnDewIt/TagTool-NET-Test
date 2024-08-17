using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagObjectHandler 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private Stream CacheStream;

        private static List<JsonConverter> Converters;

        public TagObjectHandler(GameCache cache, GameCacheHaloOnline cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;

            Converters = new List<JsonConverter>
            {
                new StringIdHandler(Cache, CacheContext),
                new CachedTagHandler(Cache, CacheContext, CacheStream),
                new TagHandler(Cache, CacheContext),
                new TagStructureHandler(Cache, CacheContext),
                new EnumHandler(Cache, CacheContext),
            };
        }

        public string Serialize(TagObject input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public TagObject Deserialize(string input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<TagObject>(input, settings);
        }
    }
}