using TagTool.Serialization;

namespace TagTool.BlamFile.Chunks
{
    public class BlfScreenshotData : BlfChunkHeader
    {
        public int BufferSize;

        public static BlfScreenshotData Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfScreenshotData>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfScreenshotData scenario)
        {
            serializer.Serialize(dataContext, scenario);
        }
    }
}
