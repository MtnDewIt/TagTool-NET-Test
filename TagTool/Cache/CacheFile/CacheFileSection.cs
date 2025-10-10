using TagTool.Tags;

namespace TagTool.Cache.CacheFile
{
    [TagStructure(Size = 0x8, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x10, Platform = CachePlatform.MCC)]
    public class CacheFileSection : TagStructure
    {
        public int Count;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding, Platform  = CachePlatform.MCC)]
        public byte[] Alignment;

        public PlatformUnsignedValue Address;
    }
}
