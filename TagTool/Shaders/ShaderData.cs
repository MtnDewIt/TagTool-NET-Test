using TagTool.Common;
using TagTool.Tags;
using System.Collections.Generic;

namespace TagTool.Shaders
{
    [TagStructure(Size = 0x50)]
    public class ShaderData : TagStructure
	{
        public byte[] Unknown1;
        public byte[] PcCompiledShader;
        public List<RasterizerConstantBlock> XboxParameters;
        public uint Unknown2;
        public List<RasterizerConstantBlock> PcParameters;
        public StringId Unknown3;
        public uint Unknown4;
        public uint XboxShaderAddress;
    }
}