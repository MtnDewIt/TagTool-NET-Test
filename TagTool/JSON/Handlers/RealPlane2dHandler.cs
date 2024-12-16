﻿using Newtonsoft.Json;
using System;
using TagTool.Common;

namespace TagTool.JSON.Handlers
{
    public class RealPlane2dHandler : JsonConverter<RealPlane2d>
    {
        public override void WriteJson(JsonWriter writer, RealPlane2d value, JsonSerializer serializer)
        {
            writer.WriteValue($@"Normal: I: {value.Normal.I}, J: {value.Normal.J}, Distance: {value.Distance}");
        }

        public override RealPlane2d ReadJson(JsonReader reader, Type objectType, RealPlane2d existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            var valueArray = value
            .Replace("Normal: ", "")
            .Replace("I: ", "")
            .Replace("J: ", "")
            .Replace("Distance: ", "")
            .Split(",");

            var i = float.Parse(valueArray[0]);
            var j = float.Parse(valueArray[1]);
            var distance = float.Parse(valueArray[2]);

            return new RealPlane2d(new RealVector2d(i, j), distance);
        }
    }
}
