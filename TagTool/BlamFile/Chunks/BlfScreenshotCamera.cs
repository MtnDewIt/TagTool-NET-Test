using TagTool.Serialization;

namespace TagTool.BlamFile.Chunks
{
    public class BlfScreenshotCamera : BlfChunkHeader
    {
        public static BlfScreenshotCamera Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfScreenshotCamera>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfScreenshotCamera scenario)
        {
            serializer.Serialize(dataContext, scenario);
        }
    }
}
