using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsUShortHandler : JsonConverter<Bounds<ushort>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<ushort> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<ushort> ReadJson(JsonReader reader, Type objectType, Bounds<ushort> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = ushort.Parse(valueArray[0]);
            var upper = ushort.Parse(valueArray[1]);

            return new Bounds<ushort>(lower, upper);
        }
    }
}