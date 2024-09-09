using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class BoundsUIntHandler : JsonConverter<Bounds<uint>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<uint> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: {value.Lower}, Upper: {value.Upper}");
        }

        public override Bounds<uint> ReadJson(JsonReader reader, Type objectType, Bounds<uint> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = uint.Parse(valueArray[0]);
            var upper = uint.Parse(valueArray[1]);

            return new Bounds<uint>(lower, upper);
        }
    }
}