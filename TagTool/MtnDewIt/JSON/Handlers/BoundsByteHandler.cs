using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsByteHandler : JsonConverter<Bounds<byte>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<byte> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<byte> ReadJson(JsonReader reader, Type objectType, Bounds<byte> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = byte.Parse(valueArray[0]);
            var upper = byte.Parse(valueArray[1]);

            return new Bounds<byte>(lower, upper);
        }
    }
}