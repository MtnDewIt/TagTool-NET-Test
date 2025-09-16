using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.MCC.Headers
{
    [TagStructure(Size = 0x380, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
    public class CacheFileHeaderHalo2MCC : CacheFileHeader
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
        public byte[] Pad0;

        public PlatformUnsignedValue TagsHeaderWhenLoaded;

        public CacheFileType ScenarioType;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Pad;

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

        [TagField(Length = 0x10)]
        public byte[] Unknown60;

        public FileCreator CreatorName;

        [TagField(Length = 32)]
        public string BuildNumber;

        [TagField(Length = 32)]
        public string Name;

        [TagField(Length = 256)]
        public string TagPath;

        [TagField(Length = 256)]
        public string Path;

        public uint ExpectedBaseAddress; // TODO: Confirm if pointer

        // TODO: Update if above true
        public uint TagsInstancesSize;
        public int TagDataSize;

        [TagField(Length = 0x14)]
        public byte[] Unknown2DC;

        public int RawTableOffset;
        public int RawTableSize;

        [TagField(Length = 0x10)]
        public byte[] Unknown2F8;

        public int CompressedDataChunkSize;
        public int CompressedDataOffset;
        public int CompressedChunkTableOffset;
        public int CompressedChunkCount;

        [TagField(Length = 0x64, Flags = TagFieldFlags.Padding)]
        public byte[] Unused2;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetHeaderSignature() => HeaderSignature;
        public override Tag GetFooterSignature() => FooterSignature;
        public override ulong GetTagsHeaderWhenLoaded() => TagsHeaderWhenLoaded.Value;
        public override ulong GetExpectedBaseAddress() => ExpectedBaseAddress;
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
        public override uint GetTagsOffset() => TagsInstancesSize;
        public override uint GetTagsVirtualBase() => 0;
        public override CacheFileFlags GetFlags() => Flags;
        public override int GetCompressedDataChunkSize() => CompressedDataChunkSize;
        public override int GetCompressedDataOffset() => CompressedDataOffset;
        public override int GetCompressedChunkTableOffset() => CompressedChunkTableOffset;
        public override int GetCompressedChunkCount() => CompressedChunkCount;
        public override CacheFileSectionTable GetSectionTable() => null;
        public override CacheFileSectionFileBounds GetReports() => null;
    }
}
