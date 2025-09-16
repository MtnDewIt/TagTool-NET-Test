using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Gen1.Headers
{
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.HaloXbox, MaxVersion = CacheVersion.HaloXbox)]
    public class CacheFileHeaderHaloXbox : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion Version;
        public uint Size;
        public int CompressedFilePadding;

        public uint TagsOffset;
        public int TagsSize;

        public int IndexBufferCount;
        public int IndexBufferOffset;

        [TagField(Length = 32)]
        public string Name;

        [TagField(Length = 32)]
        public string BuildNumber;

        public CacheFileType ScenarioType;

        [TagField(Length = 0x2)]
        public byte[] Pad;

        public uint Checksum;

        [TagField(Length = 0x794)]
        public byte[] Unused2;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetHeaderSignature() => HeaderSignature;
        public override Tag GetFooterSignature() => FooterSignature;
        public override ulong GetTagsHeaderWhenLoaded() => TagsOffset;
        public override ulong GetExpectedBaseAddress() => 0;
        public override string GetName() => Name;
        public override string GetBuildNumber() => BuildNumber;
        public override string GetTagPath() => null;
        public override int GetMapId() => -1;
        public override int GetScenarioIndex() => -1;
        public override CacheFileType GetScenarioType() => ScenarioType;
        public override CacheFileSharedType GetSharedCacheFileType() => CacheFileSharedType.None;
        public override int GetStringIdCount() => -1;
        public override int GetStringIdDataCount() => -1;
        public override uint GetStringIdIndexOffset() => 0;
        public override uint GetStringIdDataOffset() => 0;
        public override int GetStringIdNamespaceCount() => -1;
        public override uint GetStringIdNamespaceOffset() => 0;
        public override int GetDebugTagNameCount() => -1;
        public override uint GetDebugTagNameDataOffset() => 0;
        public override int GetDebugTagNameDataSize() => -1;
        public override uint GetDebugTagNameIndexOffset() => 0;
        public override uint GetTagsOffset() => 0;
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
