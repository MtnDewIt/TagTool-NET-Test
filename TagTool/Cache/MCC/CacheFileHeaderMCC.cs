using System;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.MCC
{
    [TagStructure(Size = 0x380, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC)]
    [TagStructure(Size = 0x4000, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0xA000, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x1E000, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
    public class CacheFileHeaderMCC : CacheFileHeader
    {
        //
        // Header definition
        //

        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public uint FileLength;

        public CacheFileEngineVersion EngineVersion;
        public CacheFilePlatformType PlatformType;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public TagMemoryHeader TagMemoryHeader;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        public ushort CacheFlags;
        public bool ValidSharedResourceUsage;
        public bool Unused1;

        public TagNameHeader TagNamesHeader;

        public StringIDHeaderMCC StringIdsHeader;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public GameLanguage Language;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach)]
        public int MinorVersion;

        [TagField(Length = (int)CacheFileSharedFileType.Count)]
        public SharedModificationDate[] SharedCreationDate;

        [TagField(Length = 0x10, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC)]
        [TagField(Length = 0x18, MinVersion = CacheVersion.Halo3Retail)]
        public byte[] Unknown1;

        public FileCreator CreatorName;

        [TagField(Length = 32)]
        public string Build;

        [TagField(Length = 32)]
        public string Name;

        [TagField(Length = 256)]
        public string ScenarioPath;

        [TagField(Length = 256)]
        public string SourceFile;

        public PlatformUnsignedValue VirtualBaseAddress;

        public PlatformUnsignedValue TagTableHeaderOffset;

        [TagField(Length = 0x10)]
        public byte[] Unknown2;

        [TagField(Length = (int)CacheFilePartitionType.Count, MinVersion = CacheVersion.Halo3Retail)]
        public CacheFilePartition[] Partitions = new CacheFilePartition[(int)CacheFilePartitionType.Count];

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public uint RealtimeChecksum;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public uint ContentHashMask;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public ulong SignatureMarker;

        [TagField(Length = 0x3, MinVersion = CacheVersion.Halo3Retail)]
        public SharedNetworkRequestHash[] Hash;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public SHA256Hash RSAKeyBlobHash;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public RSASignature RSASignature;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CacheFileSectionTable SectionTable;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public SharedResourceUsage SharedResourceUsage;

        [TagField(Length = 0x8C, MinVersion = CacheVersion.Halo2PC, MaxVersion = CacheVersion.Halo2PC)]
        [TagField(Length = 0x1524, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x1180, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Length = 0x6F64, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach)]
        [TagField(Length = 0x88C, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
        public byte[] Unknown3;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override string GetBuild() => Build;

        public override CacheFileType GetCacheType() => CacheType;

        public override Tag GetFootTag() => FooterSignature;

        public override Tag GetHeadTag() => HeaderSignature;

        public override string GetName() => Name;

        public override string GetScenarioPath() => ScenarioPath;

        public override int GetScenarioTagIndex() => -1;

        public override CacheFileSharedType GetSharedCacheType() => SharedCacheType;

        // TODO: clean up
        public override StringIDHeader GetStringIDHeader() => new StringIDHeader()
        {
            Count = StringIdsHeader.Count,
            IndicesOffset = StringIdsHeader.IndicesOffset,
            BufferOffset = StringIdsHeader.BufferOffset,
            BufferSize = StringIdsHeader.BufferSize
        };

        public override TagMemoryHeader GetTagMemoryHeader() => TagMemoryHeader;

        public override TagNameHeader GetTagNameHeader() => TagNamesHeader;

        public override ulong GetTagTableHeaderOffset() => throw new NotImplementedException();
    }
}
