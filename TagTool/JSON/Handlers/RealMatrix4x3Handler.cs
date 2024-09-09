using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class RealMatrix4x3Handler : JsonConverter<RealMatrix4x3>
    {
        public override void WriteJson(JsonWriter writer, RealMatrix4x3 value, JsonSerializer serializer)
        {
            writer.WriteValue($@"M11: {value.m11}, M12: {value.m12}, M13: {value.m13}, M21: {value.m21}, M22: {value.m22}, M23: {value.m23}, M31: {value.m31}, M32: {value.m32}, M33: {value.m33}, M41: {value.m41}, M42: {value.m42}, M43: {value.m43}");
        }

        public override RealMatrix4x3 ReadJson(JsonReader reader, Type objectType, RealMatrix4x3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("M11: ", "")
            .Replace("M12: ", "")
            .Replace("M13: ", "")
            .Replace("M21: ", "")
            .Replace("M22: ", "")
            .Replace("M23: ", "")
            .Replace("M31: ", "")
            .Replace("M32: ", "")
            .Replace("M33: ", "")
            .Replace("M41: ", "")
            .Replace("M42: ", "")
            .Replace("M43: ", "")
            .Split(',');

            var m11 = float.Parse(valueArray[0]);
            var m12 = float.Parse(valueArray[1]);
            var m13 = float.Parse(valueArray[2]);
            var m21 = float.Parse(valueArray[3]);
            var m22 = float.Parse(valueArray[4]);
            var m23 = float.Parse(valueArray[5]);
            var m31 = float.Parse(valueArray[6]);
            var m32 = float.Parse(valueArray[7]);
            var m33 = float.Parse(valueArray[8]);
            var m41 = float.Parse(valueArray[9]);
            var m42 = float.Parse(valueArray[10]);
            var m43 = float.Parse(valueArray[11]);

            return new RealMatrix4x3(m11, m12, m13, m21, m22, m23, m31, m32, m33, m41, m42, m43);
        }
    }
}
