using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class Point2dHandler : JsonConverter<Point2d>
    {
        public override void WriteJson(JsonWriter writer, Point2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"X: {value.X}, Y: {value.Y}");
        }

        public override Point2d ReadJson(JsonReader reader, Type objectType, Point2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("X: ", "")
            .Replace("Y: ", "")
            .Split(',');

            var x = short.Parse(valueArray[0]);
            var y = short.Parse(valueArray[1]);

            return new Point2d(x, y);
        }
    }
}
