using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Gen4.Headers
{
    [TagStructure(Size = 0x1E000, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
    public class CacheFileHeaderHalo4 : CacheFileHeader
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

        public ScenarioType ScenarioType;
        public short SharedCacheFileType;

        public bool Uncompressed;
        public bool Tracked;
        public bool ValidSharedResourceUsage;
        public byte HeaderFlags;

        public LastModificationDate SlotModificationDate;

        public int LowDetailTextureNumber;
        public uint LowDetailTextureOffset;
        public uint LowDetailTextureByteCount;

        public int StringIdCount;
        public int StringIdDataCount;
        public uint StringIdIndexOffset;
        public uint StringIdDataOffset;

        public CacheFileSharedFileType SharedMapUsage;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] Pad1;

        public LastModificationDate CreationDate;

        [TagField(Length = (int)SharedResourceDatabaseType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 32)]
        public string Name;

        public GameLanguage Language;

        [TagField(Length = 256)]
        public string TagPath;

        public int MinorVersionNumber;

        public int DebugTagNameCount;
        public uint DebugTagNameDataOffset;
        public int DebugTagNameDataSize;
        public uint DebugTagNameIndexOffset;

        public int TagRemapCount; // c_wrapped_array tag_remap_info
        public uint TagRemapAddress;
        public int DlcTagRemapCount; // c_wrapped_array dlc_tag_remap_info
        public uint DlcTagRemapAddress;

        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        public PlatformUnsignedValue ExpectedBaseAddress;

        public uint XDKVersion;

        [TagField(Length = (int)CacheFilePartitionType.Count)]
        public CacheFilePartition[] Partitions;

        public uint ContentHashMask;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Pad2;

        public ulong SignatureMarker;

        [TagField(Length = 0x3)]
        public SharedNetworkRequestHash[] ContentHashes;

        public RSASignature RSASignature;

        public CacheFileSectionTable SectionTable;

        public SharedResourceUsage SharedResourceUsage;

        // Everything past here is a bit of a mess

        [TagField(Length = 0x10)]
        public byte[] Data1D728;

        public uint LateBindingTagReferenceFixupInfoCount;
        public uint LateBindingTagReferenceFixupInfoAddress;
        public uint CacheFileFixupsCount;
        public uint CacheFileFixupsAddress;

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

        [TagField(Length = 0x870, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetHeaderSignature() => HeaderSignature;
        public override Tag GetFooterSignature() => FooterSignature;
        public override ulong GetTagsHeaderWhenLoaded() => TagsHeaderWhenLoaded.Value;
        public override ulong GetExpectedBaseAddress() => ExpectedBaseAddress.Value;
        public override uint GetSize() => Size;
        public override string GetName() => Name;
        public override string GetBuildNumber() => BuildNumber;
        public override string GetTagPath() => TagPath;
        public override int GetMapId() => -1;
        public override int GetScenarioIndex() => -1;
        public override ScenarioType GetScenarioType() => ScenarioType;
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
        public override bool GetCompression() => Uncompressed;
        public override int GetCompressedDataChunkSize() => -1;
        public override int GetCompressedDataOffset() => -1;
        public override int GetCompressedChunkTableOffset() => -1;
        public override int GetCompressedChunkCount() => -1;
        public override CacheFileSectionTable GetSectionTable() => SectionTable;
        public override CacheFileSectionFileBounds GetReports() => null;
    }
}
