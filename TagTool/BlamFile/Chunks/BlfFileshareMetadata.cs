using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x1C4)]
    public class BlfFileshareMetadata : BlfChunkHeader
    {
        // TODO: Map this out at some point;

        [TagField(Length = 0x1C4)]
        public byte[] Data;

        public static BlfFileshareMetadata Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfFileshareMetadata>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfFileshareMetadata metadata)
        {
            serializer.Serialize(dataContext, metadata);
        }
    }
}
