using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x4)]
    public class BlfScreenshotData : BlfChunkHeader
    {
        public int BufferSize;

        public static BlfScreenshotData Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext, out byte[] buffer)
        {
            var screenshot = deserializer.Deserialize<BlfScreenshotData>(dataContext);
            buffer = reader.ReadBytes(screenshot.BufferSize);
            return screenshot;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfScreenshotData screenshotData, byte[] buffer)
        {
            serializer.Serialize(dataContext, screenshotData);

            if (screenshotData != null && screenshotData.Length > 0)
            {
                screenshotData.BufferSize = screenshotData.Length;
                serializer.Serialize(dataContext, screenshotData);

                // image is always little endian
                writer.Format = EndianFormat.LittleEndian;
                writer.WriteBlock(buffer);
                writer.Format = serializer.Format;
            }
            else
            {
                new TagToolError(CommandError.CustomError, "No data, screenshot will not be written to BLF");
            }
        }
    }
}
