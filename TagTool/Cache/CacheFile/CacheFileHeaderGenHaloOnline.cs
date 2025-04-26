using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x3390, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    public class CacheFileHeaderGenHaloOnline : CacheFileHeader
    {
        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public int FileLength;
        public int FileCompressedLength;

        public uint TagTableHeaderOffset;

        public TagMemoryHeader TagMemoryHeader;

        [TagField(Length = 256)]
        public string Path;

        [TagField(Length = 32)]
        public string Build;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        public bool Uncompressed;
        public bool TrackedBuild;
        public bool ValidSharedResourceUsage;
        public byte HeaderFlags;

        public LastModificationDate SlotModificationDate;

        public int LowDetailTextureCount;
        public int LowDetailTextureOffset;
        public int LowDetailTextureByteCount;

        public StringIDHeader StringIdsHeader;

        public uint SharedFileFlags;

        public LastModificationDate CreationDate;

        [TagField(Length = 6, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline106708)]
        [TagField(Length = 8, MinVersion = CacheVersion.HaloOnline235640)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 32)]
        public string Name;

        public GameLanguage Language;

        [TagField(Length = 256)]
        public string ScenarioPath;

        public int MinorVersion;

        public TagNameHeader TagNamesHeader;

        public SectionFileBounds Reports;

        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        public int ExpectedBaseAddress;
        public int XdkVersion;
        public int ContentHashMask;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public ulong SignatureMarker;

        public NetworkRequestHash Hash;

        public RSASignature RSASignature;

        [TagField(Length = 4)]
        public int[] SectionOffsets;

        [TagField(Length = 4)]
        public SectionFileBounds[] OriginalSectionBounds;

        public SharedResourceUsage SharedResourceUsage;

        public int TagCacheOffsets;

        public int TagCount;

        public int MapId;

        public int ScenarioTagIndex;

        public int CacheFileResourceGestaltIndex;

        [TagField(Length = 0x594, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline106708, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x584, MinVersion = CacheVersion.HaloOnline235640, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetFootTag() => FooterSignature;
        public override Tag GetHeadTag() => HeaderSignature;
        public override ulong GetTagTableHeaderOffset() => TagTableHeaderOffset;
        public override string GetName() => Name;
        public override string GetBuild() => Build;
        public override string GetScenarioPath() => ScenarioPath;
        public override CacheFileType GetCacheType() => CacheType;
        public override CacheFileSharedType GetSharedCacheType() => SharedCacheType;
        public override StringIDHeader GetStringIDHeader() => StringIdsHeader;
        public override TagNameHeader GetTagNameHeader() => TagNamesHeader;
        public override TagMemoryHeader GetTagMemoryHeader() => TagMemoryHeader;
        public override int GetScenarioTagIndex() => ScenarioTagIndex;
    }

    [TagStructure(Size = 0x8)]
    public class LastModificationDate
    {
        public uint Low;
        public uint High;

        public LastModificationDate()
        {
            Low = 0;
            High = 0;
        }

        public LastModificationDate(long timeStamp)
        {
            var dateTime = DateTime.FromFileTimeUtc(timeStamp);

            SetModificationDate(dateTime);
        }

        public DateTime GetModificationDate()
        {
            var high = (long)High << 32;
            var ldap = high + Low;

            return DateTime.FromFileTimeUtc(ldap);
        }

        public void SetModificationDate(DateTime date)
        {
            var ldap = date.ToFileTimeUtc();

            Low = (uint)(ldap & uint.MaxValue);
            High = (uint)(ldap >> 32);
        }
    }

    [TagStructure(Size = 0x8)]
    public class SharedModificationDate : TagStructure
    {
        public LastModificationDate LastModificationDate;
    }

    [TagStructure(Size = 0x8)]
    public class SectionFileBounds : TagStructure
    {
        public int Offset;
        public int Size;
    }

    [TagStructure(Size = 0x14)]
    public class NetworkRequestHash
    {
        [TagField(Length = 20)]
        public byte[] Data;

        public string GetHash() 
        {
            return BitConverter.ToString(Data).Replace("-", "");
        }

        public void SetHash(string hashString) 
        {
            Data = new byte[20];

            var chunkSize = 2;

            var parsedString = hashString.PadLeft(40, '0');

            for (int i = 0; i < 20; i++)
            {
                int start = i * chunkSize;
                int length = Math.Min(chunkSize, parsedString.Length - start);
                Data[i] = byte.Parse(parsedString.Substring(start, length), NumberStyles.HexNumber);
            }
        }
    }

    [TagStructure(Size = 0x100)]
    public class RSASignature
    {
        [TagField(Length = 256)]
        public byte[] Data;

        public string GetSignature()
        {
            return BitConverter.ToString(Data).Replace("-", "");
        }

        public void SetSignature(string signatureString) 
        {
            Data = new byte[256];

            var chunkSize = 2;

            var parsedString = signatureString.PadLeft(512, '0');

            for (int i = 0; i < 256; i++)
            {
                int start = i * chunkSize;
                int length = Math.Min(chunkSize, parsedString.Length - start);
                Data[i] = byte.Parse(parsedString.Substring(start, length), NumberStyles.HexNumber);
            }
        }
    }

    [TagStructure(Size = 0x2980)]
    public class SharedResourceUsage : TagStructure
    {
        public TagPersistentIdentifier SharedLayoutIdentifier;
        public ushort SharedLocationCount;
        public ushort LocalLocationCount;
        public uint FirstFileOffset;
        public TagPersistentIdentifier CodecIdentifier;

        [TagField(Length = 320)]
        public LocalResourceLocation[] LocalLocations;

        public byte InsertionPointUsageCount;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;

        [TagField(Length = 9)]
        public InsertionPointResourceUsage[] InsertionPointUsages;

        [TagStructure(Size = 0x10)]
        public class TagPersistentIdentifier : TagStructure 
        {
            [TagField(Length = 0x4)]
            public uint[] Data;
        }

        [TagStructure(Size = 0x1C)]
        public class LocalResourceLocation : TagStructure 
        {
            // TODO: Add some kind of function to handle this
            // Flags is 2 bits
            // FileSize is 30 bits
            public uint FlagsAndFileSize;
            public uint MemorySize;
            public NetworkRequestHash EntireChecksum;
        }

        [TagStructure(Size = 0xB4)]
        public class InsertionPointResourceUsage : TagStructure
        {
            public byte InitialZoneSetIndex;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            // TODO: Add some kind of dynamic bit vector class

            // 1024 bits
            [TagField(Length = 0x80)]
            public byte[] SharedRequiredLocations;

            // 320 bits
            [TagField(Length = 0x28)]
            public byte[] LocalRequiredLocations;

            // idk what this could be, something from ODST? - Twister
            [TagField(Length = 0x8)]
            public byte[] DataAC;
        }
    }

    [TagStructure(Size = 0x20)]
    public class FileCreator
    {
        [TagField(Length = 0x20)]
        public byte[] Data;

        private static readonly byte[] FileCreatorKey = new byte[64]
        {
            0x05, 0x11, 0x6A, 0xA3, 0xCA, 0xB5, 0x07, 0xDF, 0x50, 0xE7,
            0x5B, 0x75, 0x6B, 0x4A, 0xBB, 0xF4, 0xE8, 0x54, 0x8F, 0xC6,
            0xD6, 0xCC, 0x92, 0x15, 0x97, 0xDC, 0xF5, 0xEE, 0xB9, 0x3C,
            0x01, 0x3C, 0x95, 0xCF, 0xB8, 0x58, 0x5A, 0x6F, 0x2E, 0xB9,
            0x30, 0x6D, 0x89, 0x31, 0x2F, 0x83, 0x6F, 0xF0, 0x9F, 0xE8,
            0x37, 0x78, 0xE4, 0xC7, 0xE2, 0x2B, 0x19, 0x66, 0x11, 0x06,
            0x77, 0x24, 0x74, 0x66
        };

        public static string GetCreator(byte[] author)
        {
            char[] creatorString = new char[32];

            author.CopyTo(creatorString, 0);

            for (int i = 0; i < 32; i++)
            {
                creatorString[i] ^= (char)FileCreatorKey[i];
            }

            return new string(creatorString.Where(c => c != 0).ToArray());
        }

        public static byte[] SetCreator(string author)
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
    }
}
