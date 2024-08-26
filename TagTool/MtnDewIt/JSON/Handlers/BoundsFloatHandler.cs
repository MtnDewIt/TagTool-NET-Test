using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsFloatHandler : JsonConverter<Bounds<float>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<float> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<float> ReadJson(JsonReader reader, Type objectType, Bounds<float> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = float.Parse(valueArray[0]);
            var upper = float.Parse(valueArray[1]);

            return new Bounds<float>(lower, upper);
        }
    }
}