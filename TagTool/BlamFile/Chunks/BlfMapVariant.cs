using System;
using System.IO;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0xE094, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0xD9C8, MinVersion = CacheVersion.HaloReach)]
    public class BlfMapVariant : BlfChunkHeader
    {
        [TagField(Length = 0x4, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Padding;

        [TagField(Length = 0x14, MinVersion = CacheVersion.HaloReach)]
        public byte[] Hash;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int Size;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public MapVariant MapVariant;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachMapVariant MapVariantReach;

        public static BlfMapVariant Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext, bool packed) 
        {
            if (!packed)
                return (BlfMapVariant)deserializer.Deserialize(dataContext, typeof(BlfMapVariant));

            var blfChunk = new BlfMapVariant();

            blfChunk.Signature = reader.ReadTag();
            blfChunk.Length = reader.ReadInt32();
            blfChunk.MajorVersion = reader.ReadInt16();
            blfChunk.MinorVersion = reader.ReadInt16();

            if (deserializer.Version == CacheVersion.HaloReach)
            {
                blfChunk.Hash = reader.ReadBytes(0x14);
                blfChunk.Size = reader.ReadInt32();

                var variantSize = blfChunk.Length - 0x24;

                var buffer = new byte[variantSize];

                for (int i = 0; i < variantSize; i++)
                {
                    buffer[i] = reader.ReadByte();
                }

                var stream = new MemoryStream(buffer);
                var bitStream = new BitStream(stream);

                blfChunk.MapVariantReach = ReachMapVariant.Decode(bitStream);
            }
            else if (deserializer.Version == CacheVersion.Halo4 || deserializer.Version == CacheVersion.Halo2AMP)
            {
                blfChunk.Hash = reader.ReadBytes(0x14);
                blfChunk.Size = reader.ReadInt32();

                var variantSize = blfChunk.Length - 0x24;

                var buffer = new byte[variantSize];

                for (int i = 0; i < variantSize; i++)
                {
                    buffer[i] = reader.ReadByte();
                }

                new TagToolWarning("Gen 4 Map Variants Not Supported. Skipping...");
            }
            else
            {
                var variantSize = blfChunk.Length - 0xC;

                var buffer = new byte[variantSize];

                for (int i = 0; i < variantSize; i++)
                {
                    buffer[i] = reader.ReadByte();
                }

                var stream = new MemoryStream(buffer);
                var bitStream = new BitStream(stream);

                blfChunk.MapVariant = MapVariant.Decode(bitStream);
            }

            return blfChunk;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfMapVariant mapVariant, bool packed) 
        {
            if (!packed) 
            {
                serializer.Serialize(dataContext, mapVariant);
                return;
            }

            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
