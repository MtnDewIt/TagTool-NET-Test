using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BlamScriptResourceHandler : JsonConverter<BlamScriptResource>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public BlamScriptResourceHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, BlamScriptResource value, JsonSerializer serializer)
        {
            // Maybe if I ever add support for editing these JSON files in epsilon?
        }

        public override BlamScriptResource ReadJson(JsonReader reader, Type objectType, BlamScriptResource existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //return serializer.Deserialize<BlamScriptResource>(reader);

            return null;
        }
    }
}