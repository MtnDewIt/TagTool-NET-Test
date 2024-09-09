using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class RealPlane3dHandler : JsonConverter<RealPlane3d>
    {
        public override void WriteJson(JsonWriter writer, RealPlane3d value, JsonSerializer serializer)
        {
            writer.WriteValue($@" Normal: I: {value.Normal.I}, J: {value.Normal.J}, K: {value.Normal.K}, Distance:  {value.Distance}");
        }

        public override RealPlane3d ReadJson(JsonReader reader, Type objectType, RealPlane3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Normal: ", "")
            .Replace("I: ", "")
            .Replace("J: ", "")
            .Replace("K: ", "")
            .Replace("Distance: ", "")
            .Split(",");

            var i = float.Parse(valueArray[0]);
            var j = float.Parse(valueArray[1]);
            var k = float.Parse(valueArray[2]);
            var distance = float.Parse(valueArray[3]);

            return new RealPlane3d(new RealVector3d(i, j, k), distance);
        }
    }
}
