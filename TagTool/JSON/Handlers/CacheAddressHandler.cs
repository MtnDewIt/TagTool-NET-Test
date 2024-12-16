using Newtonsoft.Json;
using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Layouts;

namespace TagTool.JSON.Handlers
{
    public class CacheAddressHandler : JsonConverter<CacheAddress>
    {
        public override void WriteJson(JsonWriter writer, CacheAddress value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Type: {value.Type}, Offset: {value.Offset}");
        }

        public override CacheAddress ReadJson(JsonReader reader, Type objectType, CacheAddress existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Type: ", "")
            .Replace("Offset: ", "")
            .Split(',');

            var type = (CacheAddressType)Enum.Parse(typeof(CacheAddressType), valueArray[0], true);
            var offset = int.Parse(valueArray[1]);

            return new CacheAddress(type, offset);
        }
    }
}
