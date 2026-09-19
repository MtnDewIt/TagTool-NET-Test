using System.Buffers.Binary;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0xC)]
    public class BlfChunkHeader : TagStructure
    {
        public Tag Signature;
        public int Length;
        public short MajorVersion;
        public short MinorVersion;

        public void ByteSwap()
        {
            Signature = new Tag(BinaryPrimitives.ReverseEndianness(Signature.Value));
            Length = BinaryPrimitives.ReverseEndianness(Length);
            MajorVersion = BinaryPrimitives.ReverseEndianness(MajorVersion);
            MinorVersion = BinaryPrimitives.ReverseEndianness(MinorVersion);
        }
    }
}
