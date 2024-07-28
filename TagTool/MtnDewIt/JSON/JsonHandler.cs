using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using Newtonsoft.Json;
using System.IO;
using System;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.JSON
{
    public class JsonHandler 
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public JsonHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public void TestNew(object input) 
        {
            var json = SerializeToJson(input);
            File.WriteAllText("json_test.json", json);
        }

        public string SerializeToJson(object input)
        {
            var stringIdHandler = new StringIdHandler(Cache, CacheContext);
            var cachedTagHandler = new CachedTagHandler(Cache, CacheContext);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> 
                { 
                    stringIdHandler,
                    cachedTagHandler,
                },
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(input, settings);
        }
    }
}
