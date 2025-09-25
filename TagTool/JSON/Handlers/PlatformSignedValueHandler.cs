using Newtonsoft.Json;
using System;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class PlatformSignedValueHandler : JsonConverter<PlatformSignedValue>
    {
        private CachePlatform Platform { get; set; }

        public PlatformSignedValueHandler(CachePlatform platform) 
        {
            Platform = platform;
        }

        public override void WriteJson(JsonWriter writer, PlatformSignedValue value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override PlatformSignedValue ReadJson(JsonReader reader, Type objectType, PlatformSignedValue existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var signedValue = reader.Value.ToString();
            var platformType = CacheVersionDetection.GetPlatformType(Platform);

            return platformType switch
            {
                PlatformType._32Bit => new PlatformSignedValue(int.Parse(signedValue)),
                PlatformType._64Bit => new PlatformSignedValue(long.Parse(signedValue)),
                _ => new PlatformSignedValue(),
            };
        }
    }
}
