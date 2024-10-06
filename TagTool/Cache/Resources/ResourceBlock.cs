using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Size = 0xC)]
    public class ResourceBlock : TagStructure 
    {
        public int BlockIndex1;
        public int BlockIndex2;
        public int BlockIndex3;
    }
}
