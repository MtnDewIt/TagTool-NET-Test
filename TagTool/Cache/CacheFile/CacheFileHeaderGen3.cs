using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x3000, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0xA000, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x4000, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0xA000, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class CacheFileHeaderGen3 : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public int FileLength;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public int FileCompressedLength;

        [TagField(MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public CacheFileEngineVersion EngineVersion;
        [TagField(MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public CacheFilePlatformType PlatformType;

        [TagField(Length = 0x2, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public PlatformUnsignedValue TagTableHeaderOffset;

        public TagMemoryHeader TagMemoryHeader;

        [TagField(Length = 256, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public string SourceFile;

        [TagField(Length = 32, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public string Build;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        [TagField(MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
        public ResourceCRC CacheResourceCRC;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public bool Uncompressed;
        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public bool TrackedBuild;

        [TagField(MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public CacheFileFlags Flags;

        public bool ValidSharedResourceUsage;
        public byte HeaderFlags;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public LastModificationDate SlotModificationDate;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public int LowDetailTextureCount;
        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public int LowDetailTextureOffset;
        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public int LowDetailTextureByteCount;

        [TagField(MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public TagNameHeader TagNamesHeaderMCC;

        public StringIDHeader StringIdsHeader;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public GameLanguage LanguageMCC;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public int MinorVersionMCC;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public uint SharedFileFlags;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public LastModificationDate CreationDate;

        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 0x18, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public byte[] Unknown1;

        [TagField(Length = 0x20, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public string Name;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public GameLanguage Language;

        [TagField(Length = 256, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public string ScenarioPath;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public int MinorVersion;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public TagNameHeader TagNamesHeader;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        [TagField(Length = 32, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public string BuildMCC;

        [TagField(Length = 32, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public string NameMCC;

        [TagField(Length = 256, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public string ScenarioPathMCC;

        [TagField(Length = 256, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public string SourceFileMCC;

        public PlatformUnsignedValue VirtualBaseAddress;

        [TagField(MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public PlatformUnsignedValue TagTableHeaderOffsetMCC;

        [TagField(MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        public int XDKVersion;

        [TagField(Length = 0x10, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public byte[] Unknown2;

        [TagField(Length = (int)CacheFilePartitionTypeBeta.Count, MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
        [TagField(Length = (int)CacheFilePartitionType.Count, MinVersion = CacheVersion.Halo3Retail)]
        public CacheFilePartition[] Partitions;

        [TagField(Length = 0x4EC, MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
        public byte[] UnknownH3Beta;

        [TagField(MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public uint RealtimeChecksumMCC;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int ContentHashMask;

        [TagField(Length = 0x4, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public ulong SignatureMarker;

        [TagField(Length = 0x3, MinVersion = CacheVersion.Halo3Retail)]
        public SharedNetworkRequestHash[] Hash;

        [TagField(MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public SHA256Hash RSAKeyBlobHash;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public RSASignature RSASignature;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CacheFileSectionTable SectionTable;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public SharedResourceUsage SharedResourceUsage;

        [TagField(Length = 0x584, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x1E0, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x18A4, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
        [TagField(Length = 0x1524, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        [TagField(Length = 0x1180, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        [TagField(Length = 0x1844, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public byte[] Padding3;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetFootTag() => FooterSignature;
        public override Tag GetHeadTag() => HeaderSignature;
        public override ulong GetTagTableHeaderOffset() => (TagTableHeaderOffset ?? TagTableHeaderOffsetMCC).Value;
        public override string GetName() => Name ?? NameMCC;
        public override string GetBuild() => Build ?? BuildMCC;
        public override string GetScenarioPath() => ScenarioPath ?? ScenarioPathMCC;
        public override CacheFileType GetCacheType() => CacheType;
        public override CacheFileSharedType GetSharedCacheType() => SharedCacheType;
        public override StringIDHeader GetStringIDHeader() => StringIdsHeader;
        public override TagNameHeader GetTagNameHeader() => TagNamesHeader ?? TagNamesHeaderMCC;
        public override TagMemoryHeader GetTagMemoryHeader() => TagMemoryHeader;
        public override int GetScenarioTagIndex() => -1;
    }
}
