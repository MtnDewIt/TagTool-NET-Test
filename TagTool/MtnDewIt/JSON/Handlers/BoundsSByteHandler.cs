using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsSByteHandler : JsonConverter<Bounds<sbyte>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<sbyte> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<sbyte> ReadJson(JsonReader reader, Type objectType, Bounds<sbyte> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = sbyte.Parse(valueArray[0]);
            var upper = sbyte.Parse(valueArray[1]);

            return new Bounds<sbyte>(lower, upper);
        }
    }
}