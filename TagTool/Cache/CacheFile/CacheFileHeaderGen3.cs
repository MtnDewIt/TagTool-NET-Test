﻿using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x800, MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.Halo3Beta, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x3000, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0xA000, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x4000, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0xA000, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.MCC)]
    public class CacheFileHeaderGen3 : CacheFileHeader
    {
        public Tag HeaderSignature;

        public CacheFileVersion FileVersion;
        public int FileLength;
        public int FileCompressedLength;

        public PlatformUnsignedValue TagTableHeaderOffset;

        public TagMemoryHeader TagMemoryHeader;

        [TagField(Length = 256)]
        public string SourceFile;

        [TagField(Length = 32)]
        public string Build;

        public CacheFileType CacheType;
        public CacheFileSharedType SharedCacheType;

        [TagField(MaxVersion = CacheVersion.Halo3Beta)]
        public uint CacheResourceCRC;

        public bool Unknown2;     
        public bool TrackedBuild;       
        public bool Unknown3;
        public byte Unknown4;
        public int Unknown5;
        public int Unknown6;
        public int Unknown7;       
        public int Unknown8;
        public int Unknown9;
        public StringIDHeader StringIdsHeader;
        public int ExternalDependencies;
        public ulong Timestamp;
        public ulong MainMenuTimestamp;
        public ulong SharedTimestamp;
        public ulong CampaignTimestamp;

        [TagField(Platform = CachePlatform.MCC)]
        public ulong MultiplayerTimestamp;

        [TagField(Length = 0x20)]
        public string Name;
     
        public int Unknown13;

        [TagField(Length = 256)]
        public string ScenarioPath;

        public int MinorVersion;
        public TagNameHeader TagNamesHeader;
        public uint Checksum;
        
        public int Unknown14;
        public int Unknown15;
        public int Unknown16;
        public int Unknown17;
        public int Unknown18;
        public int Unknown19;
        public int Unknown20;
        public int Unknown21_1;

        [TagField(Length = 0x10, MinVersion = CacheVersion.Halo4)]
        public byte[] UnknownH4;
        [TagField(Platform = CachePlatform.MCC)]
        public int Unknown21_2;

        public PlatformUnsignedValue VirtualBaseAddress;

        public int XDKVersion;

        [TagField(Platform = CachePlatform.MCC)]
        public int Unknown21_3;

        [TagField(Length = (int)CacheFilePartitionTypeBeta.Count, MaxVersion = CacheVersion.Halo3Beta)]
        public CacheFilePartition[] PartitionsBeta = new CacheFilePartition[(int)CacheFilePartitionTypeBeta.Count];

        [TagField(Length = (int)CacheFilePartitionType.Count, MinVersion = CacheVersion.Halo3Retail)]
        public CacheFilePartition[] Partitions = new CacheFilePartition[(int)CacheFilePartitionType.Count];

        [TagField(Length = 0x4EC, MaxVersion = CacheVersion.Halo3Beta)]
        public byte[] UnknownH3Beta;

        // everything after that is min h3 retail

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int CountUnknown1;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int Unknown22;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int Unknown23;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int Unknown24;

        [TagField(Length = 5, MinVersion = CacheVersion.Halo3Retail)]
        public int[] SHA1_A;
        [TagField(Length = 5, MinVersion = CacheVersion.Halo3Retail)]
        public int[] SHA1_B;
        [TagField(Length = 5, MinVersion = CacheVersion.Halo3Retail)]
        public int[] SHA1_C;
        [TagField(Length = 64, MinVersion = CacheVersion.Halo3Retail)]
        public int[] RSA;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public CacheFileSectionTable SectionTable;

        [TagField(Length = 4, MinVersion = CacheVersion.Halo3Retail)]
        public int[] GUID;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public short Unknown108;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public short CountUnknown2;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public int Unknown109;

        [TagField(Length = 4, MinVersion = CacheVersion.Halo3Retail)]
        public int[] CompressionGUID;

        [TagField(Length = 0x2B38, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
        public byte[] UnknownFileData;

        [TagField(Length = 0x2AF0, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public byte[] UnknownFileDataMCC;

        [TagField(Length = 0x7000, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public byte[] UnknownReach;

        [TagField(Length = 0x13FF0, MinVersion = CacheVersion.Halo4)]
        public byte[] UnknownH4FileData;

        public Tag FooterSignature;

        //
        // overrides
        //

        public override Tag GetFootTag() => FooterSignature;
        public override Tag GetHeadTag() => HeaderSignature;
        public override ulong GetTagTableHeaderOffset() => TagTableHeaderOffset.Value;
        public override string GetName() => Name;
        public override string GetBuild() => Build;
        public override string GetScenarioPath() => null;
        public override CacheFileType GetCacheType() => CacheType;
        public override CacheFileSharedType GetSharedCacheType() => SharedCacheType;
        public override StringIDHeader GetStringIDHeader() => StringIdsHeader;
        public override TagNameHeader GetTagNameHeader() => TagNamesHeader;
        public override TagMemoryHeader GetTagMemoryHeader() => TagMemoryHeader;
        public override int GetScenarioTagIndex() => -1;
    }
}
