using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x44, Align = 0x1)]
    public class BlfAuthor : BlfChunkHeader
    {
        [TagField(Length = 16)]
        public string BuildName;

        public ulong BuildIdentifier;

        [TagField(Length = 28)]
        public string BuildString;

        [TagField(Length = 16)]
        public string AuthorName;

        public static BlfAuthor Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return (BlfAuthor)deserializer.Deserialize(dataContext, typeof(BlfAuthor));
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfAuthor author)
        {
            serializer.Serialize(dataContext, author);
        }
    }
}
