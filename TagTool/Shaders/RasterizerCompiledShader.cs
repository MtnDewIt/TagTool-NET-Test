using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.Shaders
{
    [TagStructure(Size = 0x90, Align = 0x8, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x98, Align = 0x8, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)] // might not be correct
    [TagStructure(Size = 0x50, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x58, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    public class RasterizerCompiledShader : TagStructure
    {
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CompiledShaderFlags Flags;

        public byte[] XenonCompiledShader;
        public byte[] DX9CompiledShader;
        [TagField(Platform = CachePlatform.MCC)]
        public byte[] DurangoCompiledShader;

        public GlobalRasterizerConstantTable XenonConstantTable;
        public GlobalRasterizerConstantTable DX9ConstantTable;
        [TagField(Platform = CachePlatform.MCC)]
        public GlobalRasterizerConstantTable DurangoConstantTable;

        public uint Gprs;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int GlobalCachePixelShaderIndex;

        [Flags]
        public enum CompiledShaderFlags : uint
        {
            None = 0,
            RequiresConstantTable = 1 << 0,
        }
    }
}
