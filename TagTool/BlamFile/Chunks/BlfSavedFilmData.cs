using TagTool.Serialization;

namespace TagTool.BlamFile.Chunks
{
    public class BlfSavedFilmData : BlfChunkHeader
    {
        public static BlfSavedFilmData Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfSavedFilmData>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfSavedFilmData scenario)
        {
            serializer.Serialize(dataContext, scenario);
        }
    }
}
