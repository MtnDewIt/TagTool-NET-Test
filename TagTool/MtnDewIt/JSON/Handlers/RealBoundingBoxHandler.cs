using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealBoundingBoxHandler : JsonConverter<RealBoundingBox>
    {
        public override void WriteJson(JsonWriter writer, RealBoundingBox value, JsonSerializer serializer)
        {
            writer.WriteValue($@"X: Lower: {value.XBounds.Lower}, Upper: {value.XBounds.Upper}, Y: Lower: {value.YBounds.Lower}, Upper: {value.YBounds.Upper}, Z: Lower: {value.ZBounds.Lower}, Upper: {value.ZBounds.Upper}");
        }                         
                                  
        public override RealBoundingBox ReadJson(JsonReader reader, Type objectType, RealBoundingBox existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("X: ", "")
            .Replace("Y: ", "")
            .Replace("Z: ", "")
            .Replace("Lower: ", "")
            .Replace("Upper: ", "")
            .Split(',');

            var xLower = float.Parse(valueArray[0]);
            var xUpper = float.Parse(valueArray[1]);
            var yLower = float.Parse(valueArray[2]);
            var yUpper = float.Parse(valueArray[3]);
            var zLower = float.Parse(valueArray[4]);
            var zUpper = float.Parse(valueArray[5]);

            return new RealBoundingBox(new Bounds<float>(xLower, xUpper), new Bounds<float>(yLower, yUpper), new Bounds<float>(zLower, zUpper));
        }
    }
}
