using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x1E000, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
    public class CacheFileHeaderGen4 : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public int FileLength;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int FileCompressedLength;

        [TagField(MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public CacheFileEngineVersion EngineVersion;
        [TagField(MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public CacheFilePlatformType PlatformType;

        [TagField(Length = 0x2, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public PlatformUnsignedValue TagTableHeaderOffset;

        public TagMemoryHeader TagMemoryHeader;

        [TagField(Length = 256, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public string SourceFile;

        [TagField(Length = 32, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public string Build;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public bool Uncompressed;
        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public bool TrackedBuild;

        [TagField(MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public CacheFileFlags Flags;

        public bool ValidSharedResourceUsage;
        public byte HeaderFlags;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public LastModificationDate SlotModificationDate;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int LowDetailTextureCount;
        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int LowDetailTextureOffset;
        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int LowDetailTextureByteCount;

        [TagField(MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public TagNameHeader TagNamesHeaderMCC;

        public StringIDHeader StringIdsHeader;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public uint SharedFileFlags;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public LastModificationDate CreationDate;

        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 0x18, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public byte[] Unknown1;

        [TagField(Length = 0x20, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public string Name;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public GameLanguage Language;

        [TagField(Length = 256, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public string ScenarioPath;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int MinorVersion;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public TagNameHeader TagNamesHeader;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int TagRemapCount;
        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int TagRemapAddress;
        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int DlcTagRemapCount;
        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int DlcTagRemapAddress;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        [TagField(Length = 32, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public string BuildMCC;

        [TagField(Length = 32, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public string NameMCC;

        [TagField(Length = 256, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public string ScenarioPathMCC;

        [TagField(Length = 256, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public string SourceFileMCC;

        public PlatformUnsignedValue VirtualBaseAddress;

        [TagField(MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public PlatformUnsignedValue TagTableHeaderOffsetMCC;

        [TagField(MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
        public int XDKVersion;

        [TagField(Length = 0x10, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public byte[] Unknown2;

        [TagField(Length = (int)CacheFilePartitionType.Count)]
        public CacheFilePartition[] Partitions;

        [TagField(MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public uint RealtimeChecksumMCC;

        public int ContentHashMask;

        [TagField(Length = 0x4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public ulong SignatureMarker;

        [TagField(Length = 0x3)]
        public SharedNetworkRequestHash[] Hash;

        [TagField(MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC)]
        public SHA256Hash RSAKeyBlobHash;

        public RSASignature RSASignature;

        public CacheFileSectionTable SectionTable;

        public SharedResourceUsage SharedResourceUsage;

        [TagField(Length = 0x10)]
        public byte[] Data1D728;

        public uint TagReferenceFixupCount;
        public uint TagReferenceFixupAddress;
        public uint FixupCount;
        public uint FixupAddress;

        [TagField(Length = 0x10)]
        public byte[] Data1D738;

        public uint Unknown1D73C;
        public uint Unknown1D740;
        public uint Unknown1D744;
        public uint Unknown1D748;

        [TagField(Length = 0x1C)]
        public byte[] Data1D74C;

        public uint Unknown1D768;
        public uint Unknown1D76C;

        [TagField(Length = 0x870, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x828, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP, Platform = CachePlatform.MCC, Flags = TagFieldFlags.Padding)]
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
