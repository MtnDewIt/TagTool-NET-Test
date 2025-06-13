using System.IO;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Serialization;

namespace TagTool.BlamFile.Chunks
{
    public class BlfChunkCompressedData : BlfChunkHeader
    {
        public byte[] Data;

        public static BlfMapVariant Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            var chunk = new BlfChunkCompressedData();

            chunk.Signature = reader.ReadTag();
            chunk.Length = reader.ReadInt32();
            chunk.MajorVersion = reader.ReadInt16();
            chunk.MinorVersion = reader.ReadInt16();

            var variantSize = chunk.Length - 0xC;

            var buffer = new byte[variantSize];

            for (int i = 0; i < variantSize; i++)
            {
                buffer[i] = reader.ReadByte();
            }

            if (deserializer.Version == CacheVersion.HaloReach)
            {
                // TODO: Implement
            }
            else 
            {
                // TODO: Implement
            }

            // TODO: Implement

            return null;
        }

        public static void Encode()
        {
            // TODO: Implement
        }
    }
}
