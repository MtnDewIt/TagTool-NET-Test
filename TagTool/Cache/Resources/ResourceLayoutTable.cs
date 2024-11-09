using System;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Name = "cache_file_resource_layout_table", Tag = "play", Size = 0x3C, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
    [TagStructure(Name = "cache_file_resource_layout_table", Tag = "play", Size = 0x48, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    public class ResourceLayoutTable : TagStructure
    {
        public List<ResourceCodec> CodecDefinitions;
        public List<ResourceSharedFile> SharedFiles;
        public List<ResourcePage> Pages;
        public List<ResourceSubpageTable> SubpageTables;
        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public List<ResourcePageLookup> PagesPatchLookup;
        public List<ResourceSection> Sections;

        [TagStructure(Size = 0x10)]
        public class ResourceCodec : TagStructure
        {
            [TagField(Length = 0x10)]
            public byte[] GUID;
        }

        [TagStructure(Size = 0x108)]
        public class ResourceSharedFile : TagStructure
        {
            [TagField(Length = 256)]
            public string MapPath;

            // We'll switch to using the enum once the page read 
            // and write functions have been updated accordingly
            public ushort Flags;
            public short GlobalSharedSegmentOffset;

            public uint BlockOffset;

            [Flags]
            public enum SharedFileFlags : ushort 
            {
                None = 0,
                UseHeaderBlockOffset = 1 << 0,
                NotRequired = 1 << 1,
                UseHeaderLocations = 1 << 2,
                NoResources = 1 << 3,
            }
        }

        [TagStructure(Size=  0xC)]
        public class ResourcePageLookup : TagStructure
        {
            public int PatchIndex;
            public int PageableFileLocationIndex;
            public int ResourceIndex;
        }

        [TagStructure(Size = 0x10, Align = 0x8)]
        public class ResourceSection : TagStructure
        {
            public short RequiredPageIndex;
            public short OptionalPageIndex;
            public int RequiredSegmentOffset;
            public int OptionalSegmentOffset;
            public short RequiredSizeIndex;
            public short OptionalSizeIndex;
        }
    }
}