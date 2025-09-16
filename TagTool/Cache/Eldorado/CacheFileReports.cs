using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache.Eldorado
{
    public class CacheFileReports 
    {
        public CacheVersion Version;

        public int Count;
        public CacheFileReport[] Reports;

        public CacheFileReports(CacheVersion version)
        {
            Version = version;
        }

        public void Read(EndianReader reader, CacheFileSectionFileBounds reports)
        {
            var deserializer = new TagDeserializer(Version, CachePlatform.Original);
            var dataContext = new DataSerializationContext(reader);

            var reportSize = (int)TagStructure.GetTagStructureInfo(typeof(CacheFileReport), Version, CachePlatform.Original).TotalSize;

            Count = reports.Size / reportSize;

            Reports = new CacheFileReport[Count];

            for (int i = 0; i < Count; i++)
            {
                Reports[i] = deserializer.Deserialize<CacheFileReport>(dataContext);
            }
        }

        public void Write(EndianWriter writer, EndianFormat format) 
        {
            var dataContext = new DataSerializationContext(writer);
            var serializer = new TagSerializer(Version, CachePlatform.Original, format);

            for (int i = 0; i < Count; i++)
                serializer.Serialize(dataContext, Reports[i]);
        }

        [TagStructure(Size = 0x114, MinVersion = CacheVersion.Eldorado106708, MaxVersion = CacheVersion.Eldorado700123)]
        public class CacheFileReport : TagStructure
        {
            [TagField(Length = 0x20)]
            public byte[] Unknown0;

            [TagField(Length = 0x5)]
            public uint[] Hash;

            public FileReferencePersist FileReference;

            [TagField(Length = 0x14)]
            public uint[] UnknownB0;

            public uint Unknown100;
            public uint Unknown104;
            public uint Unknown108;
            public uint Unknown10C;
            public uint Unknown110;

            [TagStructure(Size = 0x7C, MinVersion = CacheVersion.Eldorado106708, MaxVersion = CacheVersion.Eldorado700123)]
            public class FileReferencePersist : TagStructure
            {
                public Tag Signature;
                public ushort Flags;
                public short Location;

                [TagField(Length = 0x6C)]
                public string Path;

                public uint Handle;
                public int Position;
            }
        }
    }
}
