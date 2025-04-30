using System;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.MCC
{
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

        [TagField(MaxVersion = CacheVersion.HaloReach)]
        public GameLanguage Language;

        [TagField(MaxVersion = CacheVersion.HaloReach)]
        public int MinorVersion;

        [TagField(Length = 6)]
        public SharedModificationDate[] SharedCreationDate;

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

        [TagField(Length = 0x10, Flags = TagFieldFlags.Padding)]
        public byte[] Unused3;

        [TagField(Length = (int)CacheFilePartitionType.Count)]
        public CacheFilePartition[] Partitions = new CacheFilePartition[(int)CacheFilePartitionType.Count];

        public uint RealtimeChecksum;
        public uint ContentHashMask;
        public ulong SignatureMarker;

        [TagField(Length = 0x3)]
        public SharedNetworkRequestHash[] Hash;

        [TagField(Length = 0x20)]
        public byte[] RSAKeyBlobHash;

        public RSASignature RSASignature;

        public CacheFileSectionTable SectionTable;

        public SharedResourceUsage SharedResourceUsage;

        [TagField(Length = 0x1524, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x1180, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Length = 0x6F64, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach)]
        [TagField(Length = 0x88C, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
        public byte[] Unknown1;

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
