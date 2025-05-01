using System;
using System.Globalization;
using System.Linq;
using TagTool.Cache.MCC;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache
{
    public abstract class CacheFileHeader : TagStructure
    {
        public virtual bool IsValid()
        {
            if (GetHeadTag() == "head" && GetFootTag() == "foot")
                return true;
            else
                return false;
        }

        public static CacheFileHeader Read(CacheFileVersion fileVersion, CacheVersion version, CachePlatform cachePlatform, EndianReader reader)
        {
            var deserializer = new TagDeserializer(version, cachePlatform);
            reader.SeekTo(0);
            var dataContext = new DataSerializationContext(reader);

            if (fileVersion == CacheFileVersion.HaloMCCUniversal)
            {
                switch (version)
                {
                    case CacheVersion.HaloCustomEdition:
                        return deserializer.Deserialize<CacheFileHeaderGen1>(dataContext);
                    case CacheVersion.Halo2PC:
                        // TODO: cleanup
                        // adapt the header for gen2 for now
                        var gen2Header = deserializer.Deserialize<CacheFileHeaderMCC>(dataContext);
                        var gen2Adapter = new CacheFileHeaderGen2()
                        {
                            HeaderSignature = gen2Header.HeaderSignature,
                            FileVersion = gen2Header.FileVersion,
                            TagTableHeaderOffset = gen2Header.TagTableHeaderOffset,
                            TagMemoryHeader = gen2Header.TagMemoryHeader,
                            SourceFile = gen2Header.SourceFile,
                            Build = gen2Header.Build,
                            CacheType = gen2Header.CacheType,
                            SharedCacheType = gen2Header.SharedCacheType,
                            StringIdsHeader = gen2Header.GetStringIDHeader(),
                            TagNamesHeader = gen2Header.TagNamesHeader,
                            Name = gen2Header.Name,
                            FooterSignature = gen2Header.FooterSignature
                        };
                        return gen2Adapter;
                    case CacheVersion.Halo3Retail:
                    case CacheVersion.Halo3ODST:
                    case CacheVersion.HaloReach:
                        // TODO: cleanup
                        // adapt the header for gen3 for now
                        var gen3Header = deserializer.Deserialize<CacheFileHeaderMCC>(dataContext);
                        var gen3Adapter = new CacheFileHeaderGen3()
                        {
                            HeaderSignature = gen3Header.HeaderSignature,
                            FileVersion = gen3Header.FileVersion,
                            TagTableHeaderOffset = gen3Header.TagTableHeaderOffset,
                            TagMemoryHeader = gen3Header.TagMemoryHeader,
                            SourceFile = gen3Header.SourceFile,
                            Build = gen3Header.Build,
                            CacheType = gen3Header.CacheType,
                            SharedCacheType = gen3Header.SharedCacheType,
                            StringIdsHeader = gen3Header.GetStringIDHeader(),
                            TagNamesHeader = gen3Header.TagNamesHeader,
                            Name = gen3Header.Name,
                            VirtualBaseAddress = gen3Header.VirtualBaseAddress,
                            Partitions = gen3Header.Partitions,
                            SectionTable = gen3Header.SectionTable,
                            FooterSignature = gen3Header.FooterSignature
                        };
                        return gen3Adapter;
                    case CacheVersion.Halo4:
                    case CacheVersion.Halo2AMP:
                        // TODO: cleanup
                        // adapt the header for gen4 for now
                        var gen4Header = deserializer.Deserialize<CacheFileHeaderMCC>(dataContext);
                        var gen4Adapter = new CacheFileHeaderGen4()
                        {
                            HeaderSignature = gen4Header.HeaderSignature,
                            FileVersion = gen4Header.FileVersion,
                            TagTableHeaderOffset = gen4Header.TagTableHeaderOffset,
                            TagMemoryHeader = gen4Header.TagMemoryHeader,
                            SourceFile = gen4Header.SourceFile,
                            Build = gen4Header.Build,
                            CacheType = gen4Header.CacheType,
                            SharedCacheType = gen4Header.SharedCacheType,
                            StringIdsHeader = gen4Header.GetStringIDHeader(),
                            TagNamesHeader = gen4Header.TagNamesHeader,
                            Name = gen4Header.Name,
                            VirtualBaseAddress = gen4Header.VirtualBaseAddress,
                            Partitions = gen4Header.Partitions,
                            SectionTable = gen4Header.SectionTable,
                            FooterSignature = gen4Header.FooterSignature
                        };
                        return gen4Adapter;
                }
            }

            switch (version)
            {
                case CacheVersion.HaloPC:
                case CacheVersion.HaloXbox:
                case CacheVersion.HaloCustomEdition:
                    return deserializer.Deserialize<CacheFileHeaderGen1>(dataContext);
                case CacheVersion.Halo2Alpha:
                case CacheVersion.Halo2Beta:
                case CacheVersion.Halo2Xbox:
                case CacheVersion.Halo2Vista:
                    return deserializer.Deserialize<CacheFileHeaderGen2>(dataContext);
                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReach:
                    return deserializer.Deserialize<CacheFileHeaderGen3>(dataContext);
                case CacheVersion.HaloOnlineED:
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
                    return deserializer.Deserialize<CacheFileHeaderGenHaloOnline>(dataContext);
                case CacheVersion.Halo4:
                    return deserializer.Deserialize<CacheFileHeaderGen4>(dataContext);
            }
            return null;
        }

        public abstract Tag GetHeadTag();
        public abstract Tag GetFootTag();
        public abstract ulong GetTagTableHeaderOffset();
        public abstract string GetName();
        public abstract string GetBuild();
        public abstract string GetScenarioPath();
        public abstract int GetScenarioTagIndex();
        public abstract CacheFileType GetCacheType();
        public abstract CacheFileSharedType GetSharedCacheType();
        public abstract StringIDHeader GetStringIDHeader();
        public abstract TagNameHeader GetTagNameHeader();
        public abstract TagMemoryHeader GetTagMemoryHeader();
    }

    [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo3Beta)]
    [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3Retail)]
    public class StringIDHeader : TagStructure
    {
        [TagField(MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo3Beta)]
        public uint BufferAlignedOffset;

        public int Count;
        public int BufferSize;
        public uint IndicesOffset;
        public uint BufferOffset;
    }

    [TagStructure(Size = 0x18, MinVersion = CacheVersion.Halo2PC)]
    public class StringIDHeaderMCC : TagStructure
    {
        public int Count;
        public uint BufferOffset;
        public int BufferSize;
        public uint IndicesOffset;
        public int NamespacesCount;
        public uint NamespacesOffset;
    }

    [TagStructure(Size = 0x10)]
    public class TagNameHeader : TagStructure
    {
        public int TagNamesCount;
        public uint TagNamesBufferOffset;
        public int TagNamesBufferSize;
        public uint TagNameIndicesOffset;
    }

    [TagStructure(Size = 0xC, MaxVersion = CacheVersion.HaloCustomEdition)]
    [TagStructure(Size = 0xC, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2Xbox)]
    [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo2Vista, MaxVersion = CacheVersion.Halo2Vista)]
    [TagStructure(Size = 0x8, MinVersion = CacheVersion.Halo2PC)]
    public class TagMemoryHeader : TagStructure
    {
        [TagField(MaxVersion = CacheVersion.HaloCustomEdition)]
        public int TagDataSize;

        public uint MemoryBufferOffset;
        public int MemoryBufferSize;

        [TagField(MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2Vista)]
        public int MemoryBufferCapacity;

        [TagField(MinVersion = CacheVersion.Halo2Vista, MaxVersion = CacheVersion.Halo2Vista)]
        public uint VirtualAddress;
    }
}
