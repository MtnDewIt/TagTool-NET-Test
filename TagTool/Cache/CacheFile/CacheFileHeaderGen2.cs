using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x380, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
    public class CacheFileHeaderGen2 : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public int FileLength;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int FileCompressedLength;

        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public CacheFileEngineVersion EngineVersion;
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public CacheFilePlatformType PlatformType;

        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC, Length = 0x2, Flags = TagFieldFlags.Padding)] 
        public byte[] Padding1;

        public PlatformUnsignedValue TagTableHeaderOffset;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public TagMemoryHeader TagMemoryHeader;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int SharedTagDependencyOffset;
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public uint SharedTagDependencyCount;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2Alpha, Platform = CachePlatform.Original)]
        public string NameAlpha;

        [TagField(Length = 256, MinVersion = CacheVersion.Halo2Beta, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public string SourceFile;
        
        [TagField(Length = 32, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public string Build;

        [TagField(Length = 256, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2Alpha, Platform = CachePlatform.Original)]
        public string SourceFileAlpha;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public ResourceCRC CacheResourceCRC;

        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public CacheFileFlags Flags;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public bool Uncompressed;
        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public bool TrackedBuild;

        public bool ValidSharedResourceUsage;
        public byte HeaderFlags;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public LastModificationDate SlotModificationDate;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int LowDetailTextureCount;
        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int LowDetailTextureOffset;
        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int LowDetailTextureByteCount;

        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public TagNameHeader TagNamesHeaderMCC;

        public StringIDHeader StringIdsHeader;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public uint SharedFileFlags;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public LastModificationDate CreationDate;
        
        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 0x10, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public byte[] Unknown60;
        
        [TagField(Length = 0x10, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public FileCreator CreatorName;

        [TagField(Length = 32, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public string BuildMCC;

        [TagField(Length = 0x20, MinVersion = CacheVersion.Halo2Beta)]
        public string Name;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public GameLanguage Language;
        
        [TagField(Length = 256)]
        public string ScenarioPath;

        [TagField(Length = 256, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public string SourceFileMCC;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int MinorVersion;

        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public uint VirtualBaseAddress;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public TagNameHeader TagNamesHeader;

        [TagField(Length = 0x10, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public TagMemoryHeader TagMemoryHeaderMCC;

        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int LanguagePacksOffset = -1;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public uint LanguagePacksSize = 0;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int SecondarySoundGestaltDatumIndex = -1;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public int GeometryDataOffset = -1;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public uint GeometryDataSize = 0;

        [TagField(MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public uint Checksum;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
        public uint MoppChecksum;

        [TagField(Length = 0x14, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public byte[] Unknown2DC;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public int RawTableOffset;
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public int RawTableSize;
        
        [TagField(Length = 0x10, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public byte[] Unknown2F8;
        
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public int CompressedDataChunkSize;
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public int CompressedDataOffset;
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public int CompressedChunkTableOffset;
        [TagField(MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
        public int CompressedChunkCount;

        [TagField(Length = 0x504, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x528, MinVersion = CacheVersion.Halo2Alpha, MaxVersion = CacheVersion.Halo2Xbox, Platform = CachePlatform.Original, Flags = TagFieldFlags.Padding)]
        [TagField(Length = 0x64, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetFootTag() => FooterSignature;
        public override Tag GetHeadTag() => HeaderSignature;
        public override ulong GetTagTableHeaderOffset() => TagTableHeaderOffset.Value;
        public override string GetName() => Name ?? NameAlpha;
        public override string GetBuild() => Build ?? BuildMCC;
        public override string GetScenarioPath() => ScenarioPath;
        public override CacheFileType GetCacheType() => CacheType;
        public override CacheFileSharedType GetSharedCacheType() => SharedCacheType;
        public override StringIDHeader GetStringIDHeader() => StringIdsHeader;
        public override TagNameHeader GetTagNameHeader() => TagNamesHeader ?? TagNamesHeaderMCC;
        public override TagMemoryHeader GetTagMemoryHeader() => TagMemoryHeader ?? TagMemoryHeaderMCC;
        public override int GetScenarioTagIndex() => -1;
    }
}
