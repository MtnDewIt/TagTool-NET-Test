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

        public static CacheFileHeader Read(CacheVersion version, CachePlatform cachePlatform, EndianReader reader)
        {
            var deserializer = new TagDeserializer(version, cachePlatform);
            reader.SeekTo(0);
            var dataContext = new DataSerializationContext(reader);

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
                case CacheVersion.Halo2Retail:
                    return deserializer.Deserialize<CacheFileHeaderGen2>(dataContext);
                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReach:
                case CacheVersion.HaloReach11883:
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
                case CacheVersion.Halo2AMP:
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

    [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x18, MinVersion = CacheVersion.Halo2Retail, Platform = CachePlatform.MCC)]
    public class StringIDHeader : TagStructure
    {
        [TagField(MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
        public uint BufferAlignedOffset;

        public int Count;

        [TagField(MinVersion = CacheVersion.Halo2Retail, Platform = CachePlatform.MCC)]
        public uint BufferOffsetMCC;

        public int BufferSize;
        public uint IndicesOffset;

        [TagField(MinVersion = CacheVersion.Halo2Alpha, Platform = CachePlatform.Original)]
        public uint BufferOffset;

        [TagField(MinVersion = CacheVersion.Halo2Retail, Platform = CachePlatform.MCC)]
        public int NamespacesCount;

        [TagField(MinVersion = CacheVersion.Halo2Retail, Platform = CachePlatform.MCC)]
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
    [TagStructure(Size = 0x8, MinVersion = CacheVersion.Halo2Retail)]
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
