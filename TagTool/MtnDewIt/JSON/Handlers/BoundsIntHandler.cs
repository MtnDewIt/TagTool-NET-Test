using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsIntHandler : JsonConverter<Bounds<int>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<int> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<int> ReadJson(JsonReader reader, Type objectType, Bounds<int> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = int.Parse(valueArray[0]);
            var upper = int.Parse(valueArray[1]);

            return new Bounds<int>(lower, upper);
        }
    }
}