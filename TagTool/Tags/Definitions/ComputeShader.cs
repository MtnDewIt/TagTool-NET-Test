using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Shaders;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "compute_shader", Tag = "cmpu", Size = 0x20, MinVersion = CacheVersion.Halo3Retail)]
    public class ComputeShader : TagStructure
    {
        public EntryPointFlags EntryPointsMask;
        public List<ComputeEntryPointBlock> EntryPoints;
        public int Version;
        public List<CompiledComputeShaderBlock> CompiledShaders;

        [TagStructure(Size = 0x2)]
        public class ComputeEntryPointBlock : TagStructure
        {
            public byte StartIndex;
            public byte Count;
        }
    }
}
