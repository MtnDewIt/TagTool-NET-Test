using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Gen2.Headers
{
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.Halo2Xbox, MaxVersion = CacheVersion.Halo2Xbox)]
    public class CacheFileHeaderHalo2Xbox : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion Version;
        public uint Size;
        public int CompressedFilePadding;

        public uint TagsOffset;
        public uint TagsInstancesSize;
        public int TagDataSize;
        public int TotalTagsSize;

        [TagField(Length = 256)]
        public string Path;

        [TagField(Length = 32)]
        public string BuildNumber;

        public CacheFileType ScenarioType;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Pad;

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

        public uint UsesSharedMap; // Technially an array of 3 bools (with 1 byte Pad3 after it)

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

        public uint CustomLanguagePacksOffset;
        public int CustomLanguagePacksSize;
        public int CustomRuntimeGesaltSoundDefinitionIndex;

        public uint GeometryDataOffset;
        public int GeometryDataSize;

        public uint RealtimeChecksum;
        public uint MoppChecksum;

        [TagField(Length = 0x510, Flags = TagFieldFlags.Padding)]
        public byte[] Unused2;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetHeaderSignature() => HeaderSignature;
        public override Tag GetFooterSignature() => FooterSignature;
        public override ulong GetTagsHeaderWhenLoaded() => TagsOffset;
        public override ulong GetExpectedBaseAddress() => 0;
        public override uint GetSize() => Size;
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
        public override uint GetTagsOffset() => TagsInstancesSize;
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
