using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using TagTool.BlamFile;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class BlfRSASignatureHandler : JsonConverter<BlfRSASignature>
    {
        public override void WriteJson(JsonWriter writer, BlfRSASignature value, JsonSerializer serializer)
        {
            var signatureString = "";

            if (!Array.TrueForAll(value.Data, b => b == 0)) 
            {
                signatureString = BitConverter.ToString(value.Data).Replace("-", "");
            }

            writer.WriteValue(signatureString);
        }

        public override BlfRSASignature ReadJson(JsonReader reader, Type objectType, BlfRSASignature existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var signatureString = reader.Value.ToString();

            byte[] result = new byte[256];

            if (signatureString != "")
            {
                var chunkSize = 2;

                for (int i = 0; i < 256; i++)
                {
                    int start = i * chunkSize;
                    int length = Math.Min(chunkSize, signatureString.Length - start);
                    result[i] = byte.Parse(signatureString.Substring(start, length), NumberStyles.HexNumber);
                }
            }

            return new BlfRSASignature
            {
                Data = result,
            };
        }
    }
}
