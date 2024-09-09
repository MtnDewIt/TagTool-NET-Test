using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class RealRectangle3dHandler : JsonConverter<RealRectangle3d>
    {
        public override void WriteJson(JsonWriter writer, RealRectangle3d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"X0: {value.X0}, X1: {value.X1}, Y0: {value.Y0}, Y1: {value.Y1}, Z0: {value.Z0}, Z1: {value.Z1}");
        }

        public override RealRectangle3d ReadJson(JsonReader reader, Type objectType, RealRectangle3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("X0: ", "")
            .Replace("X1: ", "")
            .Replace("Y0: ", "")
            .Replace("Y1: ", "")
            .Replace("Z0: ", "")
            .Replace("Z1: ", "")
            .Split(",");

            var x0 = float.Parse(valueArray[0]);
            var x1 = float.Parse(valueArray[1]);
            var y0 = float.Parse(valueArray[2]);
            var y1 = float.Parse(valueArray[3]);
            var z0 = float.Parse(valueArray[4]);
            var z1 = float.Parse(valueArray[5]);

            return new RealRectangle3d(x0, x1, y0, y1, z0, z1);
        }
    }
}
