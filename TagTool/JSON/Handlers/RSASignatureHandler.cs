using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class RSASignatureHandler : JsonConverter<RSASignature>
    {
        public override void WriteJson(JsonWriter writer, RSASignature value, JsonSerializer serializer) 
        {
            var signatureString = "";

            if (!Array.TrueForAll(value.Data, b => b == 0)) 
            {
                List<string> signatureList = new List<string>();

                foreach (var dataPoint in value.Data)
                {
                    var hex = ulong.Parse(dataPoint.ToString().PadLeft(20, '0')).ToString("X").PadLeft(16, '0');

                    signatureList.Add(hex);
                }

                signatureString = string.Join("", signatureList.ToArray());
            }

            writer.WriteValue(signatureString);
        }

        public override RSASignature ReadJson(JsonReader reader, Type objectType, RSASignature existingValue, bool hasExistingValue, JsonSerializer serializer) 
        {
            var signatureString = reader.Value.ToString();

            ulong[] result = new ulong[32];

            if (signatureString != "") 
            {
                var chunkSize = 16;

                for (int i = 0; i < 32; i++)
                {
                    int start = i * chunkSize;
                    int length = Math.Min(chunkSize, signatureString.Length - start);
                    result[i] = ulong.Parse(signatureString.Substring(start, length), NumberStyles.HexNumber);
                }
            }

            return new RSASignature 
            {
                Data = result,
            };
        }
    }
}
