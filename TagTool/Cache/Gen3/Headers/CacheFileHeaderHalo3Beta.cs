using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Gen3.Headers
{
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.Halo3Beta)]
    public class CacheFileHeaderHalo3Beta : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion Version;
        public uint Size;
        public int CompressedFilePadding;

        public PlatformUnsignedValue TagsHeaderWhenLoaded;

        public uint TagsOffset;
        public uint TotalTagsSize;

        [TagField(Length = 256)]
        public string Path;

        [TagField(Length = 32)]
        public string BuildNumber;

        public CacheFileType ScenarioType;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Pad0;

        public uint Checksum;

        public bool Uncompressed;
        public bool Tracked;
        public bool ValidSharedResourceUsage;
        public byte HeaderFlags;

        public LastModificationDate SlotModificationDate;

        public int LowDetailTextureNumber;
        public uint LowDetailTextureOffset;
        public uint LowDetailTextureByteCount;

        public uint StringIdOffset;
        public int StringIdCount;

        public int StringIdDataCount;
        public uint StringIdIndexOffset;
        public uint StringIdDataOffset;

        public uint SharedMapUsage; // c_flags_no_init<e_cache_file_shared_file_type,unsigned char,k_number_of_shared_file_types> (with 3 byte Pad1 after it)

        public LastModificationDate CreationDate;

        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 32)]
        public string Name;

        public GameLanguage Language;

        [TagField(Length = 256)]
        public string TagPath;

        public int MinorVersion;

        public int DebugTagNameCount;
        public uint DebugTagNameDataOffset;
        public int DebugTagNameDataSize;
        public uint DebugTagNameIndexOffset;

        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        public PlatformUnsignedValue ExpectedBaseAddress;

        public uint XDKVersion;

        [TagField(Length = (int)CacheFilePartitionTypeBeta.Count)]
        public CacheFilePartition[] Partitions;

        [TagField(Length = 0x4EC)]
        public byte[] UnknownH3Beta;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetHeaderSignature() => HeaderSignature;
        public override Tag GetFooterSignature() => FooterSignature;
        public override ulong GetTagsHeaderWhenLoaded() => TagsHeaderWhenLoaded.Value;
        public override ulong GetExpectedBaseAddress() => ExpectedBaseAddress.Value;
        public override string GetName() => Name;
        public override string GetBuildNumber() => BuildNumber;
        public override string GetTagPath() => TagPath;
        public override int GetMapId() => -1;
        public override int GetScenarioIndex() => -1;
        public override CacheFileType GetScenarioType() => ScenarioType;
        public override CacheFileSharedType GetSharedCacheFileType() => CacheFileSharedType.None;
        public override int GetStringIdCount() => StringIdCount;
        public override int GetStringIdDataCount() => StringIdDataCount;
        public override uint GetStringIdIndexOffset() => StringIdIndexOffset;
        public override uint GetStringIdDataOffset() => StringIdDataOffset;
        public override int GetStringIdNamespaceCount() => -1;
        public override uint GetStringIdNamespaceOffset() => 0;
        public override int GetDebugTagNameCount() => DebugTagNameCount;
        public override uint GetDebugTagNameDataOffset() => DebugTagNameDataOffset;
        public override int GetDebugTagNameDataSize() => DebugTagNameDataSize;
        public override uint GetDebugTagNameIndexOffset() => DebugTagNameIndexOffset;
        public override uint GetTagsOffset() => TagsOffset;
        public override uint GetTagsVirtualBase() => 0;
        public override CacheFileFlags GetFlags() => CacheFileFlags.None;
        public override int GetCompressedDataChunkSize() => -1;
        public override int GetCompressedDataOffset() => -1;
        public override int GetCompressedChunkTableOffset() => -1;
        public override int GetCompressedChunkCount() => -1;
        public override CacheFileSectionTable GetSectionTable() => null;
        public override CacheFileSectionFileBounds GetReports() => null;
    }
}
