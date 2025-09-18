using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Shaders;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "vertex_shader", Tag = "vtsh", Size = 0x20, MinVersion = CacheVersion.Halo3Retail)]
    public class VertexShader : TagStructure
	{
        public EntryPointFlags EntryPointsMask;
        public List<VertexEntryPointBlock> EntryPoints;
        public int Version;
        public List<CompiledVertexShaderBlock> CompiledShaders;

        [TagStructure(Size = 0xC)]
        public class VertexEntryPointBlock : TagStructure
		{
            public List<VertexTypesBlock> VertexTypes;

            [TagStructure(Size = 0x2)]
            public class VertexTypesBlock : TagStructure 
            {
                public byte StartIndex;
                public byte Count;
            }
        }
    }
}