using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x8)]
    public class BlfMapImage : BlfChunkHeader
    {
        public BlfImageType Type;
        public int BufferSize;

        public enum BlfImageType : uint
        {
            JPG,
            PNG,
        }

        public static BlfMapImage Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext, out byte[] buffer) 
        {
            var image = (BlfMapImage)deserializer.Deserialize(dataContext, typeof(BlfMapImage));
            buffer = reader.ReadBytes(image.BufferSize);
            return image;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfMapImage image, byte[] buffer) 
        {
            if (buffer != null && buffer.Length > 0)
            {
                image.BufferSize = buffer.Length;
                serializer.Serialize(dataContext, image);

                // image is always little endian
                writer.Format = EndianFormat.LittleEndian;
                writer.WriteBlock(buffer);
                writer.Format = serializer.Format;
            }
            else
            {
                new TagToolError(CommandError.CustomError, "No data, image will not be written to BLF");
            }
        }
    }
}
