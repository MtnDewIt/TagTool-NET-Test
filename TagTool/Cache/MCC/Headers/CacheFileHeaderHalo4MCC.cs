using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.MCC.Headers
{
    [TagStructure(Size = 0x1E000, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.MCC)]
    public class CacheFileHeaderHalo4MCC : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion Version;
        public uint Size;

        public CacheFileEngineType Engine;
        public CacheFilePlatformType Platform;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Pad;

        public uint TagsOffset;
        public uint TotalTagsSize;

        public CacheFileType ScenarioType;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Pad0;

        public CacheFileFlags Flags;

        public bool ValidSharedResourceUsage;
        public byte HeaderFlags;

        public int DebugTagNameCount;
        public uint DebugTagNameDataOffset;
        public int DebugTagNameDataSize;
        public uint DebugTagNameIndexOffset;

        public int StringIdCount;
        public uint StringIdDataOffset;
        public int StringIdDataCount;
        public uint StringIdIndexOffset;
        public int StringIdNamespaceCount;
        public uint StringIdNamespaceOffset;

        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 0x18)]
        public byte[] Unknown1;

        public FileCreator CreatorName;

        [TagField(Length = 32)]
        public string BuildNumber;

        [TagField(Length = 32)]
        public string Name;

        [TagField(Length = 256)]
        public string TagPath;

        [TagField(Length = 256)]
        public string Path;

        public PlatformUnsignedValue ExpectedBaseAddress;
        public PlatformUnsignedValue TagsHeaderWhenLoaded;

        [TagField(Length = 0x10)]
        public byte[] Unknown2;

        [TagField(Length = (int)CacheFilePartitionType.Count)]
        public CacheFilePartition[] Partitions;

        public uint RealtimeChecksum;
        public uint ContentHashMask;
        public ulong SignatureMarker;

        [TagField(Length = 0x3)]
        public SharedNetworkRequestHash[] ContentHashes;

        public SHA256Hash RSAKeyBlobHash;

        public RSASignature RSASignature;

        public CacheFileSectionTable SectionTable;

        public SharedResourceUsage SharedResourceUsage;

        // Everything past here is a bit of a mess

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

        [TagField(Length = 0x828, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;

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
        public override int GetStringIdNamespaceCount() => StringIdNamespaceCount;
        public override uint GetStringIdNamespaceOffset() => StringIdNamespaceOffset;
        public override int GetDebugTagNameCount() => DebugTagNameCount;
        public override uint GetDebugTagNameDataOffset() => DebugTagNameDataOffset;
        public override int GetDebugTagNameDataSize() => DebugTagNameDataSize;
        public override uint GetDebugTagNameIndexOffset() => DebugTagNameIndexOffset;
        public override uint GetTagsOffset() => TagsOffset;
        public override uint GetTagsVirtualBase() => 0;
        public override CacheFileFlags GetFlags() => Flags;
        public override int GetCompressedDataChunkSize() => -1;
        public override int GetCompressedDataOffset() => -1;
        public override int GetCompressedChunkTableOffset() => -1;
        public override int GetCompressedChunkCount() => -1;
        public override CacheFileSectionTable GetSectionTable() => SectionTable;
        public override CacheFileSectionFileBounds GetReports() => null;
    }
}
