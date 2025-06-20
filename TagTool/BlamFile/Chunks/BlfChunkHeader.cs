using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0xC, Align = 0x1)]
    public class BlfChunkHeader : TagStructure
    {
        public Tag Signature;
        public int Length;
        public short MajorVersion;
        public short MinorVersion;
    }
}
