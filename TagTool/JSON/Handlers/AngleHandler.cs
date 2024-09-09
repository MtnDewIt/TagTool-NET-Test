using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class AngleHandler : JsonConverter<Angle>
    {
        public override void WriteJson(JsonWriter writer, Angle value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Degrees: {value.Degrees}");
        }

        public override Angle ReadJson(JsonReader reader, Type objectType, Angle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueString = value.Replace("Degrees: ", "");
            var degrees = float.Parse(valueString);

            return Angle.FromDegrees(degrees);
        }
    }
}
