using System.Collections.Generic;
using TagTool.Cache.Codecs;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Name = "cache_file_resource_layout_table", Tag = "play", Size = 0x3C, MaxVersion = CacheVersion.HaloReach11883, Platform = CachePlatform.Original)]
    [TagStructure(Name = "cache_file_resource_layout_table", Tag = "play", Size = 0x48, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    public class ResourceLayoutTable : TagStructure
    {
        public List<CodecDefinition> CodecDefinitions;
        public List<ResourceSharedFile> SharedFiles;
        public List<ResourcePage> Pages;
        public List<ResourceSubpageTable> SubpageTables;
        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public List<ResourcePageLookup> PagesPatchLookup;
        public List<ResourceSection> Sections;

        [TagStructure(Size=  0xC)]
        public class ResourcePageLookup : TagStructure
        {
            public int PatchIndex;
            public int PageableFileLocationIndex;
            public int ResourceIndex;
        }
    }
}