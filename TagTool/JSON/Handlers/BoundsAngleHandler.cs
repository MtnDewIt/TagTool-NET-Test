using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class BoundsAngleHandler : JsonConverter<Bounds<Angle>>
    {
        public override void WriteJson(JsonWriter writer, Bounds<Angle> value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Lower: Degrees: {value.Lower.Degrees}, Upper: Degrees: {value.Upper.Degrees}");
        }

        public override Bounds<Angle> ReadJson(JsonReader reader, Type objectType, Bounds<Angle> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Degrees: ", "")
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var lower = float.Parse(valueArray[0]);
            var upper = float.Parse(valueArray[1]);

            return new Bounds<Angle>(Angle.FromDegrees(lower), Angle.FromDegrees(upper));
        }
    }
}
