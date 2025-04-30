using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x25DC, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x2980, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x2B9C, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
    [TagStructure(Size = 0x1D27C, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
    public class SharedResourceUsage : TagStructure
    {
        public TagPersistentIdentifier SharedLayoutIdentifier;
        public ushort SharedLocationCount;
        public ushort LocalLocationCount;
        public uint FirstFileOffset;
        public TagPersistentIdentifier CodecIdentifier;

        [TagField(Length = 320, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach11883)]
        [TagField(Length = 3600, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
        public LocalResourceLocation[] LocalLocations;

        public byte InsertionPointUsageCount;

        [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;

        [TagField(Length = 0x4, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 0x9, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Length = 0xC, MinVersion = CacheVersion.HaloReach)]
        public InsertionPointResourceUsage[] InsertionPointUsages;

        [TagStructure(Size = 0x10)]
        public class TagPersistentIdentifier : TagStructure
        {
            [TagField(Length = 0x4)]
            public uint[] Data;
        }

        [TagStructure(Size = 0x1C)]
        public class LocalResourceLocation : TagStructure
        {
            public uint FlagsAndFileSize;
            public uint MemorySize;
            public NetworkRequestHash EntireChecksum;
        }

        [TagStructure(Size = 0xAC, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xB4, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloReach11883)]
        [TagStructure(Size = 0x60C, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)] 
        public class InsertionPointResourceUsage : TagStructure
        {
            public byte InitialZoneSetIndex;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            // idk what this is, its from Halo 4 - MtnDewIt
            [TagField(Length = 0x8, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
            public byte[] Data04;

            [TagField(Length = 32, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach11883)]
            [TagField(Length = 256, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
            public uint[] SharedRequiredLocations;

            [TagField(Length = 10, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloReach11883)]
            [TagField(Length = 128, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
            public uint[] LocalRequiredLocations;

            // You are correct. - MtnDewIt
            // idk what this could be, something from ODST? - Twister
            [TagField(Length = 0x8, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloReach11883)]
            public byte[] DataAC;
        }
    }
}
