using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Size = 0x1C)]
    public class ResourceDefinition : TagStructure
    {
        [TagField(Length = 16)]
        public byte[] GUID;

        public int DefinitionFlags;
        public short PageableAlignmentBits;
        public short OptionalAlignmentBits;

        [TagField(Flags = TagFieldFlags.Label)]
        public StringId Name;
    }
}