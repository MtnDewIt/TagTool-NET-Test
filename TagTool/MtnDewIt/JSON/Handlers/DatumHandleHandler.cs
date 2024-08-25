using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class DatumHandleHandler : JsonConverter<DatumHandle>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public DatumHandleHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, DatumHandle value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Salt: 0x{value.Salt:X4}, Index: {value.Index}");
        }

        public override DatumHandle ReadJson(JsonReader reader, Type objectType, DatumHandle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Salt: ", "")
            .Replace("Index: ", "")
            .Split(',');

            var salt = ushort.Parse(valueArray[0]);
            var index = ushort.Parse(valueArray[1]);

            return new DatumHandle(salt, index);
        }
    }
}
