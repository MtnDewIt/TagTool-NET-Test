using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache.HaloOnline
{
    [TagStructure(Size = 0x20)]
    public class CacheFileSectionHeader : TagStructure
    {
        public uint Unknown0;
        public uint FileOffsets;
        public int FileCount;
        public uint UnknownC;
        public LastModificationDate CreationDate;
        public uint Unknown18;
        public uint Unknown1C;

        public static CacheFileSectionHeader CreateHeader(CacheVersion version, CachePlatform platform) 
        {
            return new CacheFileSectionHeader
            {
                FileOffsets = GetStructureSize(typeof(CacheFileSectionHeader), version, platform),
                CreationDate = LastModificationDate.CreateFromVersion(version)
            };
        }

        public static CacheFileSectionHeader ReadHeader(EndianReader reader, CacheVersion version, CachePlatform platform) 
        {
            var dataContext = new DataSerializationContext(reader);
            var deserializer = new TagDeserializer(version, platform);

            return deserializer.Deserialize<CacheFileSectionHeader>(dataContext);
        }

        public static void WriteHeader(EndianWriter writer, CacheVersion version, CachePlatform platform, CacheFileSectionHeader header) 
        {
            var dataContext = new DataSerializationContext(writer);
            var serializer = new TagSerializer(version, platform);

            serializer.Serialize(dataContext, header);
        }
    }
}
