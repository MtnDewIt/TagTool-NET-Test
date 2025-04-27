using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x25DC, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x2980, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x2B9C, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach)]
    //[TagStructure(Size = 0x0, MinVersion = CacheVersion.Halo4, MaxVersion = CacheVersion.Halo2AMP)]
    public class SharedResourceUsage : TagStructure
    {
        public TagPersistentIdentifier SharedLayoutIdentifier;
        public ushort SharedLocationCount;
        public ushort LocalLocationCount;
        public uint FirstFileOffset;
        public TagPersistentIdentifier CodecIdentifier;

        // This maybe have been increased in halo reach and halo 4
        [TagField(Length = 320)]
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
            // TODO: Add some kind of function to handle this
            // Flags is 2 bits
            // FileSize is 30 bits
            public uint FlagsAndFileSize;
            public uint MemorySize;
            public NetworkRequestHash EntireChecksum;
        }

        [TagStructure(Size = 0xAC, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xB4, MinVersion = CacheVersion.Halo3ODST)]
        public class InsertionPointResourceUsage : TagStructure
        {
            public byte InitialZoneSetIndex;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            // TODO: Add some kind of dynamic bit vector class

            // This maybe have been increased in halo reach and halo 4
            // Values greater than 1024 have been observed
            // 1024 bits
            [TagField(Length = 0x80)]
            public byte[] SharedRequiredLocations;

            // This maybe have been increased in halo reach and halo 4
            // Values greater than 320 have been observed
            // 320 bits
            [TagField(Length = 0x28)]
            public byte[] LocalRequiredLocations;

            // You are correct. - MtnDewIt
            // idk what this could be, something from ODST? - Twister
            [TagField(Length = 0x8, MinVersion = CacheVersion.Halo3ODST)]
            public byte[] DataAC;
        }
    }
}
