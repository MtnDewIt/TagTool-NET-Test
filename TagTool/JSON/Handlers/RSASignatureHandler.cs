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
                signatureString = value.GetSignature();
            }

            writer.WriteValue(signatureString);
        }

        public override RSASignature ReadJson(JsonReader reader, Type objectType, RSASignature existingValue, bool hasExistingValue, JsonSerializer serializer) 
        {
            var signatureString = reader.Value.ToString();

            var signature = new RSASignature();

            if (signatureString != "") 
            {
                signature.SetSignature(signatureString);
            }

            return signature;
        }
    }
}
