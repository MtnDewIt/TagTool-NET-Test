using TagTool.Tags;

namespace TagTool.Cache
{
    [TagStructure(Size = 0x14)]
    public class SharedNetworkRequestHash : TagStructure
    {
        public NetworkRequestHash Hash;
    }
}
