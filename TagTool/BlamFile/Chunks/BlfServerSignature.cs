using TagTool.Cache;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x2C, MinVersion = CacheVersion.HaloReach)]
    public class BlfServerSignature : BlfChunkHeader
    {
        public FileServerSignature ServerSignature;
        public int Unknown34;

        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloReach)]
        public class FileServerSignature : TagStructure 
        {
            [TagField(Length = 0x28, MinVersion = CacheVersion.HaloReach)]
            public byte[] Data;
        }

        public static BlfServerSignature Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfServerSignature>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfServerSignature serverSignature)
        {
            serializer.Serialize(dataContext, serverSignature);
        }
    }
}
