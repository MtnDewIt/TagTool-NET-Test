using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class RealPoint2dHandler : JsonConverter<RealPoint2d>
    {
        public override void WriteJson(JsonWriter writer, RealPoint2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"X: {value.X}, Y: {value.Y}");
        }

        public override RealPoint2d ReadJson(JsonReader reader, Type objectType, RealPoint2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("X: ", "")
            .Replace("Y: ", "")
            .Split(',');

            var x = float.Parse(valueArray[0]);
            var y = float.Parse(valueArray[1]);

            return new RealPoint2d(x, y);
        }
    }
}
