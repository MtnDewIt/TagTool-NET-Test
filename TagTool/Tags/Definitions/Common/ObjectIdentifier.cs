using TagTool.Common;

namespace TagTool.Tags.Definitions.Common
{
    [TagStructure(Size = 0x8)]
    public class ObjectIdentifier : TagStructure
    {
        public DatumHandle UniqueId;
        public short OriginBspIndex;
        public GameObjectType8 Type;
        public SourceValue Source;

        public enum SourceValue : sbyte
        {
            None = -1,
            Structure,
            Editor,
            Dynamic,
            Legacy,
            Sky,
            Parent
        }
    }
}
