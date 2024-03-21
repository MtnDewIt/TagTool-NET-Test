using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    [TagStructure(Size = 0x3390, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    public class CacheFileHeaderDataHaloOnline : CacheFileHeaderData
    {
        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public int FileLength;
        public int FileCompressedLength;

        public uint TagTableHeaderOffset;

        public TagMemoryHeader TagMemoryHeader;

        [TagField(Length = 256)]
        public string SourceFile;

        [TagField(Length = 32)]
        public string Build;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        public bool Unknown1;
        public bool TrackedBuild;
        public bool HasInsertionPoints;
        public byte HeaderFlags;

        public LastModificationDate ModificationDate;

        [TagField(Length = 12)]
        public byte[] Unknown2;

        public StringIDHeader StringIdsHeader;

        public uint SharedFileFlags;

        public LastModificationDate CreationTime;

        [TagField(Length = 6, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline106708)]
        [TagField(Length = 8, MinVersion = CacheVersion.HaloOnline235640)]
        public LastModificationDate[] SharedFileTimes;

        [TagField(Length = 0x20)]
        public string Name;

        public GameLanguage GameLanguage;

        [TagField(Length = 256)]
        public string ScenarioPath;

        public int MinorVersion;

        public TagNameHeader TagNamesHeader;

        public SectionFileBounds Reports;

        [TagField(Length = 4)]
        public byte[] Unknown3;

        public FileAuthor Author;

        [TagField(Length = 0x10)]
        public byte[] Unknown4;

        public ulong Unknown5;

        public NetworkRequestHash Hash;

        public RSASignature RSASignature;

        [TagField(Length = 4)]
        public int[] SectionOffsets;

        [TagField(Length = 4)]
        public SectionFileBounds[] OriginalSectionBounds;

        public SharedResourceUsage SharedResourceUsage;

        public int InsertionPointResourceUsageCount;

        [TagField(Length = 9)]
        public InsertionPointResourceUsage[] InsertionPointResourceUsage;

        public int TagCacheOffsets;

        public int TagCount;

        public int MapId;

        public int ScenarioTagIndex;

        public int CacheFileResourceGestaltIndex;

        [TagField(Length = 0x594, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline106708)]
        [TagField(Length = 0x584, MinVersion = CacheVersion.HaloOnline235640)]
        public byte[] Unknown6;

        public Tag FooterSignature;

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
    }

    [TagStructure(Size = 0x8)]
    public class SectionFileBounds
    {
        public int Offset;
        public int Size;
    }

    [TagStructure(Size = 0x14)]
    public class NetworkRequestHash
    {
        [TagField(Length = 5)]
        public uint[] Data;
    }

    [TagStructure(Size = 0x100)]
    public class RSASignature
    {
        [TagField(Length = 32)]
        public ulong[] Data;
    }

    [TagStructure(Size = 0x2328)]
    public class SharedResourceUsage
    {
        [TagField(Length = 0x2328)]
        public byte[] Data;
    }

    [TagStructure(Size = 0xB4)]
    public class InsertionPointResourceUsage
    {
        [TagField(Length = 0xB4)]
        public byte[] Data;
    }

    [TagStructure(Size = 0x20)]
    public class FileAuthor
    {
        [TagField(Length = 0x20)]
        public byte[] Data;
    }
}