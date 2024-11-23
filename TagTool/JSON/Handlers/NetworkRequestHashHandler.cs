using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class NetworkRequestHashHandler : JsonConverter<NetworkRequestHash>
    {
        public override void WriteJson(JsonWriter writer, NetworkRequestHash value, JsonSerializer serializer)
        {
            var hashString = "";

            if (!Array.TrueForAll(value.Data, b => b == 0)) 
            {
                List<string> hashList = new List<string>();

                foreach (var dataPoint in value.Data)
                {
                    var hex = ulong.Parse(dataPoint.ToString().PadLeft(10, '0')).ToString("X").PadLeft(8, '0');

                    hashList.Add(hex);
                }

                hashString = string.Join("", hashList.ToArray());
            }

            writer.WriteValue(hashString);
        }

        public override NetworkRequestHash ReadJson(JsonReader reader, Type objectType, NetworkRequestHash existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var hashString = reader.Value.ToString();

            uint[] result = new uint[5];

            if (hashString != "") 
            {
                var chunkSize = 8;

                for (int i = 0; i < 5; i++)
                {
                    int start = i * chunkSize;
                    int length = Math.Min(chunkSize, hashString.Length - start);
                    result[i] = uint.Parse(hashString.Substring(start, length), NumberStyles.HexNumber);
                }
            }

            return new NetworkRequestHash
            {
                Data = result,
            };
        }
    }
}
