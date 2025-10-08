using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    internal class RealVector4dHandler : JsonConverter<RealVector4d>
    {
        public override void WriteJson(JsonWriter writer, RealVector4d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"I: {value.I}, J: {value.J}, K: {value.K}, W: {value.W}");
        }

        public override RealVector4d ReadJson(JsonReader reader, Type objectType, RealVector4d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("I: ", "")
            .Replace("J: ", "")
            .Replace("K: ", "")
            .Replace("W: ", "")
            .Split(',');

            var i = float.Parse(valueArray[0]);
            var j = float.Parse(valueArray[1]);
            var k = float.Parse(valueArray[2]);
            var w = float.Parse(valueArray[3]);

            return new RealVector4d(i, j, k, w);
        }
    }
}
