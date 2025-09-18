using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Shaders
{
    [TagStructure(Size = 0x8)]
    public class RasterizerConstantBlock : TagStructure
	{
        public StringId ConstantName;
        public ushort RegisterStart;
        public byte RegisterCount;
        public RegisterSetValue RegisterSet;

        public enum RegisterSetValue : byte
        {
            Bool = 0,
            Int = 1,
            Float = 2,
            Sampler = 3
        }
    }
}
