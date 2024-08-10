using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class UnicodeStringHandler : JsonConverter<UnicodeStringData>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public UnicodeStringHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, UnicodeStringData value, JsonSerializer serializer)
        {
            // Maybe if I ever add support for editing these JSON files in epsilon?
        }

        public override UnicodeStringData ReadJson(JsonReader reader, Type objectType, UnicodeStringData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //return serializer.Deserialize<UnicodeStringData>(reader);

            return null;
        }
    }
}