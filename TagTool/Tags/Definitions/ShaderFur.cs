using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "shader_fur", Tag = "rmfu", Size = 0x4)]
    public class ShaderFur : RenderMethod
    {
        [TagField(Flags = TagFieldFlags.GlobalMaterial)]
        public StringId Material;
    }
}