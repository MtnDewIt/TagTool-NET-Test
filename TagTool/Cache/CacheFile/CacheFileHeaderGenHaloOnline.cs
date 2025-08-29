using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x3390, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    public class CacheFileHeaderGenHaloOnline : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public int FileLength;
        public int FileCompressedLength;

        public PlatformUnsignedValue TagTableHeaderOffset;

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

        [TagField(Length = (int)CacheFileSharedFileTypeMS23.Count, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline155080)]
        [TagField(Length = (int)CacheFileSharedFileTypeHO.Count, MinVersion = CacheVersion.HaloOnline235640)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 32)]
        public string Name;

        public GameLanguage Language;

        [TagField(Length = 256)]
        public string ScenarioPath;

        public int MinorVersion;

        public TagNameHeader TagNamesHeader;

        public CacheFileSection Reports;

        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        public PlatformUnsignedValue VirtualBaseAddress;

        public int XDKVersion;

        public int ContentHashMask;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public ulong SignatureMarker;

        public NetworkRequestHash Hash;

        public RSASignature RSASignature;

        public CacheFileSectionTable SectionTable;

        public SharedResourceUsage SharedResourceUsage;

        public int TagCacheOffsets;

        public int TagCount;

        public int MapId;

        public int ScenarioTagIndex;

        public int CacheFileResourceGestaltIndex;

        [TagField(Length = 0x594, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline155080, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x584, MinVersion = CacheVersion.HaloOnline235640, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetFootTag() => FooterSignature;
        public override Tag GetHeadTag() => HeaderSignature;
        public override ulong GetTagTableHeaderOffset() => TagTableHeaderOffset.Value;
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
}
