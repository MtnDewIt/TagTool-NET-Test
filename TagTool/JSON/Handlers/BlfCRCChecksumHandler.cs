using Newtonsoft.Json;
using System;
using TagTool.BlamFile;
using System.Globalization;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class BlfCRCChecksumHandler : JsonConverter<BlfCRCChecksum>
    {
        public override void WriteJson(JsonWriter writer, BlfCRCChecksum value, JsonSerializer serializer) 
        {
            var checksumString = "";

            if (value.Checksum != 0) 
            {
                checksumString = value.Checksum.ToString("X");
            }

            writer.WriteValue(checksumString);
        }

        public override BlfCRCChecksum ReadJson(JsonReader reader, Type objectType, BlfCRCChecksum existingValue, bool hasExistingValue, JsonSerializer serializer) 
        {
            var checksumString = reader.Value.ToString();

            uint result = 0;

            if (checksumString != "") 
            {
                result = uint.Parse(checksumString, NumberStyles.HexNumber);
            }

            return new BlfCRCChecksum 
            {
                Checksum = result,
            };
        }
    }
}
