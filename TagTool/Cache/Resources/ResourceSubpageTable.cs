using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Size = 0x10, Align = 0x8)]
    public class ResourceSubpageTable : TagStructure
    {
        public int TotalSize;
        public List<ResourceSubpage> Subpages;

        [TagStructure(Size = 0x8)]
        public class ResourceSubpage : TagStructure
        {
            public int Offset;
            public int Size;
        }
    }
}