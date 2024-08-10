using Newtonsoft.Json;
using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
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
            var stringIdHandler = new StringIdHandler(Cache, CacheContext);
            var cachedTagHandler = new CachedTagHandler(Cache, CacheContext);
            var tagHandler = new TagHandler(Cache, CacheContext);
            var tagStructureHandler = new TagStructureHandler(Cache, CacheContext);
            var enumHandler  = new EnumHandler(Cache, CacheContext);
            var unicodeStringHandler = new UnicodeStringHandler(Cache, CacheContext);
            var animationResourceHandler = new AnimationResourceHandler(Cache, CacheContext);
            var bitmapResourceHandler = new BitmapResourceHandler(Cache, CacheContext);
            var blamScriptResourceHandler = new BlamScriptResourceHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    stringIdHandler,
                    cachedTagHandler,
                    tagHandler,
                    tagStructureHandler,
                    enumHandler,
                    unicodeStringHandler,
                    animationResourceHandler,
                    bitmapResourceHandler,
                    blamScriptResourceHandler,
                },
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public TagObject Deserialize(string input)
        {
            var stringIdHandler = new StringIdHandler(Cache, CacheContext);
            var cachedTagHandler = new CachedTagHandler(Cache, CacheContext);
            var tagHandler = new TagHandler(Cache, CacheContext);
            var enumHandler  = new EnumHandler(Cache, CacheContext);
            var unicodeStringHandler = new UnicodeStringHandler(Cache, CacheContext);
            var animationResourceHandler = new AnimationResourceHandler(Cache, CacheContext);
            var bitmapResourceHandler = new BitmapResourceHandler(Cache, CacheContext);
            var blamScriptResourceHandler = new BlamScriptResourceHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    stringIdHandler,
                    cachedTagHandler,
                    tagHandler,
                    enumHandler,
                    unicodeStringHandler,
                    animationResourceHandler,
                    bitmapResourceHandler,
                    blamScriptResourceHandler,
                },
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<TagObject>(input, settings);
        }
    }
}