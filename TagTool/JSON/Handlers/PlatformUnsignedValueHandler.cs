using Newtonsoft.Json;
using System;
using TagTool.Cache;

namespace TagTool.JSON.Handlers
{
    public class PlatformUnsignedValueHandler : JsonConverter<PlatformUnsignedValue>
    {
        private CachePlatform Platform { get; set; }

        public PlatformUnsignedValueHandler(CachePlatform platform) 
        {
            Platform = platform;
        }

        public override void WriteJson(JsonWriter writer, PlatformUnsignedValue value, JsonSerializer serializer) 
        {
            writer.WriteValue(value.ToString());
        }

        public override PlatformUnsignedValue ReadJson(JsonReader reader, Type objectType, PlatformUnsignedValue existingValue, bool hasExistingValue, JsonSerializer serializer) 
        {
            var unsignedValue = reader.Value.ToString();
            var platformType = CacheVersionDetection.GetPlatformType(Platform);

            return platformType switch
            {
                PlatformType._32Bit => new PlatformUnsignedValue(uint.Parse(unsignedValue)),
                PlatformType._64Bit => new PlatformUnsignedValue(ulong.Parse(unsignedValue)),
                _ => new PlatformUnsignedValue(),
            };
        }
    }
}
