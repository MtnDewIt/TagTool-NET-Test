using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class RealQuaternionHandler : JsonConverter<RealQuaternion>
    {
        public override void WriteJson(JsonWriter writer, RealQuaternion value, JsonSerializer serializer)
        {
            writer.WriteValue($@"I: {value.I}, J: {value.J}, K: {value.K}, W: {value.W}");
        }

        public override RealQuaternion ReadJson(JsonReader reader, Type objectType, RealQuaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
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

            return new RealQuaternion(i, j, k, w);
        }
    }
}
