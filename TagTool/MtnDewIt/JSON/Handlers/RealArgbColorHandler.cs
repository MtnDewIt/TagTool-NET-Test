using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealArgbColorHandler : JsonConverter<RealArgbColor>
    {
        public override void WriteJson(JsonWriter writer, RealArgbColor value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Alpha: {value.Alpha}, Red: {value.Red}, Green: {value.Green}, Blue: {value.Blue}");
        }

        public override RealArgbColor ReadJson(JsonReader reader, Type objectType, RealArgbColor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Alpha: ", "")
            .Replace("Red: ", "")
            .Replace("Green: ", "")
            .Replace("Blue: ", "")
            .Split(',');

            var a = float.Parse(valueArray[0]);
            var r = float.Parse(valueArray[1]);
            var g = float.Parse(valueArray[2]);
            var b = float.Parse(valueArray[3]);

            return new RealArgbColor(a, r, g, b);
        }
    }
}
