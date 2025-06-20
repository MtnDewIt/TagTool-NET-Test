using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x10000, Align = 0x1)]
    public class BlfMapVariantTagNames : BlfChunkHeader
    {
        [TagField(Length = 0x100)]
        public TagName[] Names;

        [TagStructure(Size = 0x100, Align = 0x1)]
        public class TagName : TagStructure
        {
            [TagField(Length = 0x100)]
            public string Name;
        }

        public static BlfMapVariantTagNames Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return (BlfMapVariantTagNames)deserializer.Deserialize(dataContext, typeof(BlfMapVariantTagNames));
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfMapVariantTagNames mapVariantTagNames)
        {
            serializer.Serialize(dataContext, mapVariantTagNames);
        }
    }
}
