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
        public int FileCompressedLength;

        public PlatformUnsignedValue TagTableHeaderOffset;

        public TagMemoryHeader TagMemoryHeader;

        [TagField(Length = 256)]
        public string SourceFile;

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

        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 0x20)]
        public string Name;

        public GameLanguage Language;

        [TagField(Length = 256)]
        public string ScenarioPath;

        public int MinorVersion;

        public TagNameHeader TagNamesHeader;

        public int TagRemapCount;
        public int TagRemapAddress;
        public int DlcTagRemapCount;
        public int DlcTagRemapAddress;

        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        public PlatformUnsignedValue VirtualBaseAddress;

        public int XDKVersion;

        [TagField(Length = (int)CacheFilePartitionType.Count)]
        public CacheFilePartition[] Partitions;

        public int ContentHashMask;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public ulong SignatureMarker;

        [TagField(Length = 0x3)]
        public SharedNetworkRequestHash[] Hash;

        public RSASignature RSASignature;

        public CacheFileSectionTable SectionTable;

        public SharedResourceUsage SharedResourceUsage;

        [TagField(Length = 0x10)]
        public byte[] Data1D728;

        public int TagReferenceFixupCount;
        public int TagReferenceFixupAddress;
        public int FixupCount;
        public int FixupAddress;

        [TagField(Length = 0x8B4, Flags = TagFieldFlags.Padding)]
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
