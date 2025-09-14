using TagTool.Cache;
using TagTool.Common;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "bink", Tag = "bink", Size = 0xC, MaxVersion = CacheVersion.Eldorado700123)]
    public class Bink : TagStructure
	{
        public int FrameCount;
        public TagResourceReference ResourceReference;
    }
}