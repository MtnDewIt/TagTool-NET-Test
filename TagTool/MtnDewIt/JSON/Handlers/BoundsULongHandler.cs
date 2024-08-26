using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsULongHandler : JsonConverter<Bounds<ulong>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<ulong> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<ulong> ReadJson(JsonReader reader, Type objectType, Bounds<ulong> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = ulong.Parse(valueArray[0]);
            var upper = ulong.Parse(valueArray[1]);

            return new Bounds<ulong>(lower, upper);
        }
    }
}