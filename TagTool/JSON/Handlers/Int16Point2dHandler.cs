using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class Int16Point2dHandler : JsonConverter<Int16Point2d>
    {
        public override void WriteJson(JsonWriter writer, Int16Point2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"X: {value.X}, Y: {value.Y}");
        }

        public override Int16Point2d ReadJson(JsonReader reader, Type objectType, Int16Point2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("X: ", "")
            .Replace("Y: ", "")
            .Split(',');

            var x = short.Parse(valueArray[0]);
            var y = short.Parse(valueArray[1]);

            return new Int16Point2d(x, y);
        }
    }
}
