using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Shaders;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "pixel_shader", Tag = "pixl", Size = 0x20, MinVersion = CacheVersion.Halo3Retail)]
    public class PixelShader : TagStructure
	{
        public EntryPointFlags EntryPointsMask;
        public List<PixelEntryPointBlock> EntryPoints;
        public int Version;
        public List<CompiledPixelShaderBlock> CompiledShaders;

        [TagStructure(Size = 0x2)]
        public class PixelEntryPointBlock : TagStructure 
        {
            public byte StartIndex;
            public byte Count;
        }
    }
}