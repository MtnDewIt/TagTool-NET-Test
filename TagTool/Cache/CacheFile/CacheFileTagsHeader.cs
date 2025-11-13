using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.CacheFile
{
    [TagStructure(Size = 0x28, MinVersion = CacheVersion.Halo3PreAlpha, MaxVersion = CacheVersion.Halo4, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x48, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.H2AMP, Platform = CachePlatform.MCC)]
    public class CacheFileTagsHeader : TagStructure
    {
        public CacheFileSection TagGroups;
        public CacheFileSection TagInstances;
        public CacheFileSection GlobalTagIndices;
        public CacheFileSection TagInteropFixups;
        public int TagsChecksum;
        public Tag Signature = new Tag("tags");
    }
}
