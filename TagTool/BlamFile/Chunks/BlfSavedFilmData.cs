using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x0, MinVersion = CacheVersion.Halo3Retail)]
    public class BlfSavedFilmData : BlfChunkHeader
    {
        // TODO: Fully map saved film data structure
        public static BlfSavedFilmData Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext, out byte[] buffer)
        {
            var savedFilmData = (BlfSavedFilmData)deserializer.Deserialize(dataContext, typeof(BlfSavedFilmData));
            buffer = reader.ReadBytes(savedFilmData.Length - 0xC);
            return savedFilmData;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfSavedFilmData savedFilmData, byte[] buffer)
        {
            if (buffer != null && buffer.Length > 0)
            {
                serializer.Serialize(dataContext, savedFilmData);
                writer.WriteBlock(buffer);
            }
            else
            {
                new TagToolError(CommandError.CustomError, "No data, saved film will not be written to BLF");
            }
        }
    }
}
