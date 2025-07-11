using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x24)]
    public class BlfChunkStartOfFile : BlfChunkHeader
    {
        // when -2, order is little endian, else order is big endian. Check byteswapped BOM to be -2 otherwise invalid.
        public short ByteOrderMark;

        [TagField(Length = 0x20)]
        public string FileType;

        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Alignment;

        public static BlfChunkStartOfFile Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return (BlfChunkStartOfFile)deserializer.Deserialize(dataContext, typeof(BlfChunkStartOfFile));
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfChunkStartOfFile startOfFile)
        {
            serializer.Serialize(dataContext, startOfFile);
        }
    }
}
