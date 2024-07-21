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
        public static byte[] FileCreatorKey = new byte[64]
        {
            0x05, 0x11, 0x6A, 0xA3, 0xCA, 0xB5, 0x07, 0xDF, 0x50, 0xE7,
            0x5B, 0x75, 0x6B, 0x4A, 0xBB, 0xF4, 0xE8, 0x54, 0x8F, 0xC6,
            0xD6, 0xCC, 0x92, 0x15, 0x97, 0xDC, 0xF5, 0xEE, 0xB9, 0x3C,
            0x01, 0x3C, 0x95, 0xCF, 0xB8, 0x58, 0x5A, 0x6F, 0x2E, 0xB9,
            0x30, 0x6D, 0x89, 0x31, 0x2F, 0x83, 0x6F, 0xF0, 0x9F, 0xE8,
            0x37, 0x78, 0xE4, 0xC7, 0xE2, 0x2B, 0x19, 0x66, 0x11, 0x06,
            0x77, 0x24, 0x74, 0x66
        };

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

        public static string GetAuthor(byte[] author)
        {
            char[] creatorString = new char[32];

            author.CopyTo(creatorString, 0);

            for (int i = 0; i < 32; i++) 
            {
                creatorString[i] ^= (char)FileCreatorKey[i];
            }

            return new string(creatorString.Where(c => c != 0).ToArray());
        }

        public static byte[] SetAuthor(string author)
        {
            char[] creatorArray = new char[32];
            
            author.ToCharArray().CopyTo(creatorArray, 0);
            
            for (int i = 0; i < 32; i++)
                creatorArray[i] ^= (char)FileCreatorKey[i];
            
            byte[] authorBytes = new byte[32];
            
            for (int i = 0; i < 32; i++)
                authorBytes[i] = (byte)creatorArray[i];
            
            return authorBytes;
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
