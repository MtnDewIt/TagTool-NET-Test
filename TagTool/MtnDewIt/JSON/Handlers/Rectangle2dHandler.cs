using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class Rectangle2dHandler : JsonConverter<Rectangle2d>
    {
        public override void WriteJson(JsonWriter writer, Rectangle2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Top: {value.Top}, Left: {value.Left}, Bottom: {value.Bottom}, Right: {value.Right}");
        }

        public override Rectangle2d ReadJson(JsonReader reader, Type objectType, Rectangle2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Top: ", "")
            .Replace("Left: ", "")
            .Replace("Bottom: ", "")
            .Replace("Right: ", "")
            .Split(',');
            
            var top = short.Parse(valueArray[0]);
            var left = short.Parse(valueArray[1]);
            var bottom = short.Parse(valueArray[2]);
            var right = short.Parse(valueArray[3]);

            return new Rectangle2d(top, left, bottom, right);
        }
    }
}
