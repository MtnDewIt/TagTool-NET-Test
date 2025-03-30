using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "shader_mux", Tag = "rmmx", Size = 0x4)]
    public class ShaderMux : RenderMethod
    {
        [TagField(Flags = TagFieldFlags.GlobalMaterial)]
        public StringId Material;
    }
}