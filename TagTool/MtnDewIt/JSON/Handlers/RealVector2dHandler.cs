using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealVector2dHandler : JsonConverter<RealVector2d>
    {
        public override void WriteJson(JsonWriter writer, RealVector2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"I: {value.I}, J: {value.J}");
        }

        public override RealVector2d ReadJson(JsonReader reader, Type objectType, RealVector2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("I: ", "")
            .Replace("J: ", "")
            .Split(',');

            var i = float.Parse(valueArray[0]);
            var j = float.Parse(valueArray[1]);

            return new RealVector2d(i, j);
        }
    }
}
