using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Eldorado.Headers
{
    [TagStructure(Size = 0x3390, MinVersion = CacheVersion.Eldorado155080, MaxVersion = CacheVersion.Eldorado155080)]
    public class CacheFileHeaderEldorado155080 : CacheFileHeader
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
        public CacheFileSharedType SharedCacheFileType;

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

        public uint SharedMapUsage;

        public LastModificationDate CreationDate;

        [TagField(Length = (int)CacheFileSharedFileTypeMS23.Count)]
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

        public CacheFileSectionFileBounds Reports;

        public uint RealtimeChecksum;

        public FileCreator CreatorName;

        public PlatformUnsignedValue ExpectedBaseAddress;

        public int XDKVersion;
        public int ContentHashMask;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding)]
        public byte[] Pad2;

        public ulong SignatureMarker;

        public NetworkRequestHash Hash;

        public RSASignature RSASignature;

        public CacheFileSectionTable SectionTable;

        public SharedResourceUsage SharedResourceUsage;

        public int TagCacheOffsets;
        public int TagCount;
        public int MapId;
        public int ScenarioIndex;
        public int CacheFileResourceGestaltIndex;

        [TagField(Length = 0x594, Flags = TagFieldFlags.Padding)]
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
        public override int GetMapId() => MapId;
        public override int GetScenarioIndex() => ScenarioIndex;
        public override CacheFileType GetScenarioType() => ScenarioType;
        public override CacheFileSharedType GetSharedCacheFileType() => SharedCacheFileType;
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
        public override CacheFileSectionTable GetSectionTable() => SectionTable;
        public override CacheFileSectionFileBounds GetReports() => Reports;

        public override void SetScenarioIndex(int index) => ScenarioIndex = index;
        public override void SetScenarioType(CacheFileType scenarioType) => ScenarioType = scenarioType;
    }
}
