using Newtonsoft.Json;
using System;
using TagTool.BlamFile;
using System.Globalization;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class BlfCRCChecksumHandler : JsonConverter<BlfEndOfFileCRC.BlfCRCChecksum>
    {
        public override void WriteJson(JsonWriter writer, BlfEndOfFileCRC.BlfCRCChecksum value, JsonSerializer serializer) 
        {
            var checksumString = "";

            if (value.Checksum != 0) 
            {
                checksumString = value.Checksum.ToString("X");
            }

            writer.WriteValue(checksumString);
        }

        public override BlfEndOfFileCRC.BlfCRCChecksum ReadJson(JsonReader reader, Type objectType, BlfEndOfFileCRC.BlfCRCChecksum existingValue, bool hasExistingValue, JsonSerializer serializer) 
        {
            var checksumString = reader.Value.ToString();

            uint result = 0;

            if (checksumString != "") 
            {
                result = uint.Parse(checksumString, NumberStyles.HexNumber);
            }

            return new BlfEndOfFileCRC.BlfCRCChecksum 
            {
                Checksum = result,
            };
        }
    }
}
