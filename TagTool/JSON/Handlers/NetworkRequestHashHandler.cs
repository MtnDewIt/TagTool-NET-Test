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
                hashString = value.GetHash();
            }

            writer.WriteValue(hashString);
        }

        public override NetworkRequestHash ReadJson(JsonReader reader, Type objectType, NetworkRequestHash existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var hashString = reader.Value.ToString();

            var networkRequestHash = new NetworkRequestHash();

            if (hashString != "") 
            {
                networkRequestHash.SetHash(hashString);
            }

            return networkRequestHash;
        }
    }
}
