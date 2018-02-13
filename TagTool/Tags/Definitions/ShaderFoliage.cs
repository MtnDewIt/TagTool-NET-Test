using TagTool.Common;
using TagTool.Serialization;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "shader_foliage", Tag = "rmfl", Size = 0x4)]
    public class ShaderFoliage : RenderMethod
    {
        public StringId Material;
    }
}