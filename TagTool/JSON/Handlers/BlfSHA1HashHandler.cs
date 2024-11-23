using Newtonsoft.Json;
using System;
using System.Globalization;
using TagTool.BlamFile;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class BlfSHA1HashHandler : JsonConverter<BlfSHA1Hash>
    {
        public override void WriteJson(JsonWriter writer, BlfSHA1Hash value, JsonSerializer serializer)
        {
            var hashString = "";

            if (!Array.TrueForAll(value.Hash, b => b == 0))
            {
                hashString = BitConverter.ToString(value.Hash).Replace("-", "");
            }

            writer.WriteValue(hashString);
        }

        public override BlfSHA1Hash ReadJson(JsonReader reader, Type objectType, BlfSHA1Hash existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var hashString = reader.Value.ToString();

            byte[] result = new byte[256];

            if (hashString != "")
            {
                var chunkSize = 2;

                for (int i = 0; i < 256; i++)
                {
                    int start = i * chunkSize;
                    int length = Math.Min(chunkSize, hashString.Length - start);
                    result[i] = byte.Parse(hashString.Substring(start, length), NumberStyles.HexNumber);
                }
            }

            return new BlfSHA1Hash
            {
                Hash = result,
            };
        }
    }
}
