using TagTool.Serialization;

namespace TagTool.BlamFile.Chunks
{
    public class BlfSavedFilmHeader : BlfChunkHeader
    {
        public static BlfSavedFilmHeader Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfSavedFilmHeader>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfSavedFilmHeader scenario)
        {
            serializer.Serialize(dataContext, scenario);
        }
    }
}
