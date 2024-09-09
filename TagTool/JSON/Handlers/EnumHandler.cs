using Newtonsoft.Json;
using System;

namespace TagTool.JSON.Handlers
{
    public class EnumHandler : JsonConverter<Enum>
    {
        public override void WriteJson(JsonWriter writer, Enum value, JsonSerializer serializer)
        {
            string enumValue = value.ToString();

            writer.WriteValue(enumValue);
        }

        public override Enum ReadJson(JsonReader reader, Type objectType, Enum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string enumValue = reader.Value.ToString();

            return (Enum)Enum.Parse(objectType, enumValue, true);
        }
    }
}