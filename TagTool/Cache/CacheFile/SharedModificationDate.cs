using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x8)]
    public class SharedModificationDate : TagStructure
    {
        public LastModificationDate LastModificationDate;
    }
}
