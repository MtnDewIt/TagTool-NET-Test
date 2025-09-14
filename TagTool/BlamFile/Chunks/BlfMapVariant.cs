using System.IO;
using TagTool.BlamFile.Chunks.MapVariants;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0xE094, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Size = 0xD9C8, MinVersion = CacheVersion.HaloReach)]
    public class BlfMapVariant : BlfChunkHeader
    {
        [TagField(Length = 0x4, MaxVersion = CacheVersion.Eldorado700123)]
        public byte[] Padding;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public NetworkRequestHash Hash;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int Size;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public MapVariant MapVariant;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachMapVariant ReachMapVariant;

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
                blfChunk.Hash = deserializer.Deserialize<NetworkRequestHash>(dataContext);
                blfChunk.Size = reader.ReadInt32();

                var buffer = reader.ReadBytes(blfChunk.Length - 0x24);

                var stream = new MemoryStream(buffer);
                var bitStream = new BitStreamReader(stream);

                blfChunk.ReachMapVariant = ReachMapVariant.Decode(bitStream);
            }
            else if (deserializer.Version == CacheVersion.Halo4 || deserializer.Version == CacheVersion.Halo2AMP)
            {
                blfChunk.Hash = deserializer.Deserialize<NetworkRequestHash>(dataContext);
                blfChunk.Size = reader.ReadInt32();

                var buffer = reader.ReadBytes(blfChunk.Length - 0x24);

                Log.Warning("Gen 4 Map Variants Not Supported. Skipping...");
            }
            else
            {
                var buffer = reader.ReadBytes(blfChunk.Length - 0xC);

                var stream = new MemoryStream(buffer);
                var bitStream = new BitStreamReader(stream);

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

            writer.Write(mapVariant.Signature.Value);
            writer.Write(mapVariant.Length);
            writer.Write(mapVariant.MajorVersion);
            writer.Write(mapVariant.MinorVersion);

            if (serializer.Version == CacheVersion.HaloReach)
            {
                serializer.Serialize(dataContext, mapVariant.Hash);
                writer.Write(mapVariant.Size);

                var buffer = new byte[mapVariant.Length - 0x24];

                var bitStream = new MemoryStream(buffer);
                var bitWriter = new BitStreamWriter(bitStream);

                ReachMapVariant.Encode(bitWriter, mapVariant.ReachMapVariant);

                writer.Write(buffer);
            }
            else if (serializer.Version == CacheVersion.Halo4 || serializer.Version == CacheVersion.Halo2AMP)
            {
                serializer.Serialize(dataContext, mapVariant.Hash);
                writer.Write(mapVariant.Size);

                var buffer = new byte[mapVariant.Length - 0x24];

                var bitStream = new MemoryStream(buffer);
                var bitWriter = new BitStreamWriter(bitStream);

                Log.Warning("Gen 4 Map Variants Not Supported. Skipping...");

                writer.Write(buffer);
            }
            else 
            {
                var buffer = new byte[mapVariant.Length - 0xC];

                var bitStream = new MemoryStream(buffer);
                var bitWriter = new BitStreamWriter(bitStream);

                MapVariant.Encode(bitWriter, mapVariant.MapVariant);

                writer.Write(buffer);
            }
        }
    }
}
