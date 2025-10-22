using System;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Size = 0x40, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x40, MinVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x48, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
    public class ResourceData : TagStructure
	{
        public CachedTag ParentTag;
        public ushort ResourceSalt;

        [TagField(Gen = CacheGeneration.Third)]
        public sbyte ResourceTypeIndex;
        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public TagResourceTypeGen3 ResourceType;

        public sbyte DefinitionDataAlignmentBits;

        [TagField(Gen = CacheGeneration.Third)]
        public int DefinitionDataOffset;

        [TagField(Gen = CacheGeneration.Third)]
        public int DefinitionDataLength;

        [TagField(Gen = CacheGeneration.Third)]
        public int SecondaryFixupInformationOffset;

        [TagField(Gen = CacheGeneration.Third)]
        public ResourceDataFlags Flags;

        [TagField(Gen = CacheGeneration.Third)]
        public short SegmentIndex;

        [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public byte[] DefinitionData;

        public CacheAddress DefinitionAddress;

        public List<ResourceFixupLocation> FixupLocations = new List<ResourceFixupLocation>();
        public List<ResourceInteropLocation> InteropLocations = new List<ResourceInteropLocation>();

        [TagField(EnumType = typeof(int), MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
        public ResourceDataFlags FlagsHO = ResourceDataFlags.HasPageableData;

        [Flags]
        public enum ResourceDataFlags : short
        {
            Invalid = 0,
            HasPageableData = 1 << 0,
            HasOptionalData = 1 << 1
        }
    }
}
