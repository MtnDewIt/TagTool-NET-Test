using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealEulerAngles3dHandler : JsonConverter<RealEulerAngles3d>
    {
        public override void WriteJson(JsonWriter writer, RealEulerAngles3d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Yaw: {value.Yaw.Degrees}, Pitch: {value.Pitch.Degrees}, Roll: {value.Roll.Degrees}");
        }

        public override RealEulerAngles3d ReadJson(JsonReader reader, Type objectType, RealEulerAngles3d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Yaw: ", "")
            .Replace("Pitch: ", "")
            .Replace("Roll: ", "")
            .Split(',');

            var yaw = float.Parse(valueArray[0]);
            var pitch = float.Parse(valueArray[1]);
            var roll = float.Parse(valueArray[2]);

            return new RealEulerAngles3d(Angle.FromDegrees(yaw), Angle.FromDegrees(pitch), Angle.FromDegrees(roll));
        }
    }
}
