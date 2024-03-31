using System;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    public class TagCacheHeaderData
    {
        public static TagCacheHeader ReadData(EndianReader reader, CacheVersion version)
        {
            var deserializer = new TagDeserializer(version, CachePlatform.Original);
            reader.SeekTo(0);
            var dataContext = new DataSerializationContext(reader);

            switch (version)
            {
                case CacheVersion.HaloOnlineED:
                case CacheVersion.HaloOnlineEDLegacy:
                case CacheVersion.HaloOnline106708:
                case CacheVersion.HaloOnline235640:
                case CacheVersion.HaloOnline301003:
                case CacheVersion.HaloOnline327043:
                case CacheVersion.HaloOnline372731:
                case CacheVersion.HaloOnline416097:
                case CacheVersion.HaloOnline430475:
                case CacheVersion.HaloOnline454665:
                case CacheVersion.HaloOnline449175:
                case CacheVersion.HaloOnline498295:
                case CacheVersion.HaloOnline530605:
                case CacheVersion.HaloOnline532911:
                case CacheVersion.HaloOnline554482:
                case CacheVersion.HaloOnline571627:
                case CacheVersion.HaloOnline604673:
                case CacheVersion.HaloOnline700123:
                    return deserializer.Deserialize<TagCacheHeader>(dataContext);
            }
            return null;
        }

        public static void WriteData(EndianWriter writer, object tagCache, CacheVersion version) 
        {
            var dataContext = new DataSerializationContext(writer);
            var serializer = new TagSerializer(version, CachePlatform.Original);
            serializer.Serialize(dataContext, tagCache);
        }
    }

    [TagStructure(Size = 0x20)]
    public class TagCacheHeader : TagStructure
    {
        public uint Unknown1;
        public int TagCacheOffsets;
        public int TagCount;
        public uint Unknown2;
        public LastModificationDate CreationDate;
        public uint Unknown3;
        public uint Unknown4;
    }
}