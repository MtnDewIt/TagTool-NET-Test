using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsLongHandler : JsonConverter<Bounds<long>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<long> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<long> ReadJson(JsonReader reader, Type objectType, Bounds<long> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = long.Parse(valueArray[0]);
            var upper = long.Parse(valueArray[1]);

            return new Bounds<long>(lower, upper);
        }
    }
}