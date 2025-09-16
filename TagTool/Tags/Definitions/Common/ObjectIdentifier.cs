using TagTool.Common;

namespace TagTool.Tags.Definitions.Common
{
    [TagStructure(Size = 0x8)]
    public class ObjectIdentifier : TagStructure
    {
        public DatumHandle UniqueId = DatumHandle.None;
        public short OriginBspIndex = -1;
        public GameObjectType8 Type;
        public SourceValue Source = SourceValue.None;

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
