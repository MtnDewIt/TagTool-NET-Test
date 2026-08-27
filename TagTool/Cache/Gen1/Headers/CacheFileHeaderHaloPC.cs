using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Gen1.Headers
{
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.HaloPC, MaxVersion = CacheVersion.HaloPC)]
    public class CacheFileHeaderHaloPC : CacheFileHeader
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

        public ScenarioType ScenarioType;
        public short SharedCacheFileType;

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
        public override uint GetSize() => Size;
        public override string GetName() => Name;
        public override string GetBuildNumber() => BuildNumber;
        public override ScenarioType GetScenarioType() => ScenarioType;
        public override CacheFileSharedType GetSharedCacheFileType() => CacheFileSharedType.None;
    }
}
