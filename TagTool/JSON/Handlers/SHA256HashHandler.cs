using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class SHA256HashHandler : JsonConverter<SHA256Hash>
    {
        public override void WriteJson(JsonWriter writer, SHA256Hash value, JsonSerializer serializer)
        {
            var signatureString = "";

            if (!Array.TrueForAll(value.Data, b => b == 0))
            {
                signatureString = value.GetHash();
            }

            writer.WriteValue(signatureString);
        }

        public override SHA256Hash ReadJson(JsonReader reader, Type objectType, SHA256Hash existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var signatureString = reader.Value.ToString();

            var signature = new SHA256Hash();

            if (signatureString != "")
            {
                signature.SetHash(signatureString);
            }

            return signature;
        }
    }
}
