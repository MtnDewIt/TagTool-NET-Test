using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.Shaders
{
    [TagStructure(Size = 0x90, Align = 0x8, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x98, Align = 0x8, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)] // might not be correct
    public class CompiledComputeShaderBlock : TagStructure
    {
        public RasterizerCompiledShader CompiledShaderSplut;

        public ComputeShaderReference RuntimeShader;
    }
}
