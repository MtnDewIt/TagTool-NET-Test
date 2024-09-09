using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class BoundsShortHandler : JsonConverter<Bounds<short>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<short> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<short> ReadJson(JsonReader reader, Type objectType, Bounds<short> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = short.Parse(valueArray[0]);
            var upper = short.Parse(valueArray[1]);

            return new Bounds<short>(lower, upper);
        }
    }
}