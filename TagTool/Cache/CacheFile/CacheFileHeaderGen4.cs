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

        [TagField(Platform = CachePlatform.Original)]
        public uint TagTableHeaderOffset32;
        [TagField(Platform = CachePlatform.MCC)]
        public ulong TagTableHeaderOffset64;

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

        [TagField(Platform = CachePlatform.Original)]
        public uint VirtualBaseAddress32;
         [TagField(Platform = CachePlatform.MCC)]
        public ulong VirtualBaseAddress64;

        public int XDKVersion;

        [TagField(Length = (int)CacheFilePartitionType.Count)]
        public CacheFilePartition[] Partitions;

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

        [TagField(Length = 4, MinVersion = CacheVersion.Halo3Retail)]
        public int[] GUID;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public short Unknown108;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public short CountUnknown2;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int Unknown109;

        [TagField(Length = 4, MinVersion = CacheVersion.Halo3Retail)]
        public int[] CompressionGUID;

        [TagField(Length = 0x1DB28, MinVersion = CacheVersion.Halo4)]
        public byte[] UnknownH4FileData;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetFootTag() => FooterSignature;
        public override Tag GetHeadTag() => HeaderSignature;
        public override ulong GetTagTableHeaderOffset() => TagTableHeaderOffset32;
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
