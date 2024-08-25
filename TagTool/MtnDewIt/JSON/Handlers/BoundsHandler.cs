using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class BoundsHandler : JsonConverter<IBounds>
    {
        public override void WriteJson(JsonWriter writer, IBounds value, JsonSerializer serializer)
        {
            var lower = value.GetType().GetProperty("Lower").GetValue(value);
            var upper = value.GetType().GetProperty("Upper").GetValue(value);

            if (lower.GetType() == typeof(Angle) && upper.GetType() == typeof(Angle))
            {
                var lowerValue = (Angle)lower;
                var upperValue = (Angle)upper;

                writer.WriteValue($@"Lower: Degrees: {lowerValue.Degrees}, Upper: Degrees: {upperValue.Degrees}");
            }
            else 
            {
                writer.WriteValue($@"Lower: {lower}, Upper: {upper}");
            }
        }

        public override IBounds ReadJson(JsonReader reader, Type objectType, IBounds existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // TODO: Update to support generic types
            // Currently only works with byte bounds
            // No clue how its gonna pull the type from just string data
            // Attempting to parse each potential type would be pretty inefficient
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
