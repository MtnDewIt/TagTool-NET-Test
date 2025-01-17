using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.Shaders
{
    [TagStructure(Size = 0x90, Align = 0x8, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x98, Align = 0x8, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)] // might not be correct
    public class ComputeShaderBlock : TagStructure
    {
        [TagField(MinVersion = Cache.CacheVersion.HaloReach)]
        public CompiledShaderFlags Flags;

        // bytecode and constant tables are two separate arrays indexed by platform
        public byte[] XboxShaderBytecode;
        public byte[] PCShaderBytecode;
        [TagField(Platform = CachePlatform.MCC)]
        public byte[] DurangoShaderBytecode;

        public ShaderConstantTable XBoxConstantTable;
        public ShaderConstantTable PCConstantTable;
        [TagField(Platform = CachePlatform.MCC)]
        public ShaderConstantTable DurangoConstantTable;

        public uint Gprs;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int GlobalCachePixelShaderIndex;

        public ComputeShaderReference XboxShaderReference;

        [Flags]
        public enum CompiledShaderFlags : uint
        {
            None = 0,
            RequiresConstantTable = 1 << 0,
        }
    }
}
