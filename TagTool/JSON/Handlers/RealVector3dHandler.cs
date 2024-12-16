using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class RealVector3dHandler : JsonConverter<RealVector3d>
    {
        public override void WriteJson(JsonWriter writer, RealVector3d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"I: {value.I}, J: {value.J}, K: {value.K}");
        }

        public override RealVector3d ReadJson(JsonReader reader, Type objectType, RealVector3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("I: ", "")
            .Replace("J: ", "")
            .Replace("K: ", "")
            .Split(',');

            var i = float.Parse(valueArray[0]);
            var j = float.Parse(valueArray[1]);
            var k = float.Parse(valueArray[2]);

            return new RealVector3d(i, j, k);
        }
    }
}
