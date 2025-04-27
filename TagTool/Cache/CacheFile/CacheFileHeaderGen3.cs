using TagTool.Common;
using TagTool.Tags;
using static TagTool.Cache.SharedResourceUsage;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x3000, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0xA000, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x4000, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0xA000, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.MCC)]
    public class CacheFileHeaderGen3 : CacheFileHeader
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
        public string SourceFile;

        [TagField(Length = 32)]
        public string Build;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        [TagField(MaxVersion = CacheVersion.Halo3Beta)]
        public uint CacheResourceCRC;

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

        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 0x20)]
        public string Name;

        public GameLanguage Language;

        [TagField(Length = 256)]
        public string ScenarioPath;

        public int MinorVersion;

        public TagNameHeader TagNamesHeader;

        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        public PlatformUnsignedValue VirtualBaseAddress;

        public int XDKVersion;

        [TagField(Length = (int)CacheFilePartitionTypeBeta.Count, MaxVersion = CacheVersion.Halo3Beta)]
        [TagField(Length = (int)CacheFilePartitionType.Count, MinVersion = CacheVersion.Halo3Retail)]
        public CacheFilePartition[] Partitions;

        [TagField(Length = 0x4EC, MaxVersion = CacheVersion.Halo3Beta)]
        public byte[] UnknownH3Beta;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int ContentHashMask;

        [TagField(Length = 0x4, MinVersion = CacheVersion.Halo3Retail, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public ulong SignatureMarker;

        [TagField(Length = 0x3, MinVersion = CacheVersion.Halo3Retail)]
        public SharedNetworkRequestHash[] Hash;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public RSASignature RSASignature;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CacheFileSectionTable SectionTable;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public SharedResourceUsage SharedResourceUsage;

        [TagField(Length = 0x584, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x1E0, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x6FC4, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
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
        public override string GetScenarioPath() => null;
        public override CacheFileType GetCacheType() => CacheType;
        public override CacheFileSharedType GetSharedCacheType() => SharedCacheType;
        public override StringIDHeader GetStringIDHeader() => StringIdsHeader;
        public override TagNameHeader GetTagNameHeader() => TagNamesHeader;
        public override TagMemoryHeader GetTagMemoryHeader() => TagMemoryHeader;
        public override int GetScenarioTagIndex() => -1;
    }
}
