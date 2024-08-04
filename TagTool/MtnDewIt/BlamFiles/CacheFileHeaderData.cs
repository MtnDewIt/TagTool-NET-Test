using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    public abstract class CacheFileHeaderData : TagStructure
    {
        public virtual bool IsValid()
        {
            if (GetHeadTag() == "head" && GetFootTag() == "foot")
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static CacheFileHeaderData ReadData(CacheVersion version, CachePlatform cachePlatform, EndianReader reader)
        {
            var deserializer = new TagDeserializer(version, cachePlatform);
            reader.SeekTo(0);
            var dataContext = new DataSerializationContext(reader);

            switch (version)
            {
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
                    return deserializer.Deserialize<CacheFileHeaderDataHaloOnline>(dataContext);
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

    [TagStructure(Size = 0x10)]
    public class StringIDHeader
    {
        public int IndexBufferLength;
        public int StringStorageLength;
        public uint IndexBuffer;
        public uint StringStorage;
    }

    [TagStructure(Size = 0x10)]
    public class TagNameHeader 
    {
        public int TagNameCount;
        public uint TagNameBuffer;
        public int TagNameBufferLength;
        public uint TagNameOffsets;
    }

    [TagStructure(Size = 0x8)]
    public class TagMemoryHeader
    {
        public uint MemoryBufferOffset;
        public int MemoryBufferSize;
    }
}
