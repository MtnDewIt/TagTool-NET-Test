using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "swear_filter", Tag = "sweg", Size = 0xC)]
    public class SwearFilter : TagStructure
    {
        public List<Filter> FilterLists;

        [TagStructure(Size = 0x10)]
        public class Filter : TagStructure 
        {
            [TagField(ValidTags = new[] { "swel" })]
            public CachedTag List;
        }
    }
}
