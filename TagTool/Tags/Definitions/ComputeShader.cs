using System.Collections.Generic;
using TagTool.Shaders;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "compute_shader", Tag = "cmpu", Size = 0x20)]
    public class ComputeShader : TagStructure
    {
        public EntryPointBitMask EntryPointsMask;
        public List<ShortOffsetCountBlock> EntryPoints;
        public int Version;
        public List<ComputeShaderBlock> Shaders;
    }
}
