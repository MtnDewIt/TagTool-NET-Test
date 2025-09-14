using System.IO;
using Sytem.IO;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0xFC, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Size = 0x2B4, MinVersion = CacheVersion.HaloReach)]
    public class BlfContentHeader : BlfChunkHeader
    {
        public short BuildVersion;
        public short MapMinorVersion;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Eldorado700123)]
        public ContentItemMetadata Metadata;

        [TagField(MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.Halo2AMP)]
        public ReachContentItemMetadata MetadataReach;

        public static BlfContentHeader Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            var contentHeader = new BlfContentHeader();

            contentHeader.Signature = reader.ReadTag();
            contentHeader.Length = reader.ReadInt32();
            contentHeader.MajorVersion = reader.ReadInt16();
            contentHeader.MinorVersion = reader.ReadInt16();
            contentHeader.BuildVersion = reader.ReadInt16();
            contentHeader.MapMinorVersion = reader.ReadInt16();

            if (deserializer.Version == CacheVersion.HaloReach || deserializer.Version == CacheVersion.Halo4 || deserializer.Version == CacheVersion.Halo2AMP)
            {
                var bitStream = new BitStreamReader(reader.BaseStream);

                if (deserializer.CachePlatform == CachePlatform.MCC)
                {
                    // TODO: Figure out how to account for 343's bullshit :/
                    // chunk header = big endian
                    // chunk data = little endian 
                    contentHeader.MetadataReach = ReachContentItemMetadata.Decode(bitStream, false);
                }
                else 
                {
                    contentHeader.MetadataReach = ReachContentItemMetadata.Decode(bitStream, false);
                }
            }
            else
            {
                contentHeader.Metadata = (ContentItemMetadata)deserializer.Deserialize(dataContext, typeof(ContentItemMetadata));
            }

            return contentHeader;
        }

        public static void Encode(EndianWriter writer, TagSerializer serializer, DataSerializationContext dataContext, BlfContentHeader contentHeader) 
        {
            writer.Write(contentHeader.Signature);
            writer.Write(contentHeader.Length);
            writer.Write(contentHeader.MajorVersion);
            writer.Write(contentHeader.MinorVersion);
            writer.Write(contentHeader.BuildVersion);
            writer.Write(contentHeader.MapMinorVersion);

            if (CacheVersionDetection.IsBetween(serializer.Version, CacheVersion.HaloReach, CacheVersion.Halo2AMP))
            {
                ReachContentItemMetadata.Encode(new BitStreamWriter(writer.BaseStream), contentHeader.MetadataReach, false);
            }
            else 
            {
                serializer.Serialize(dataContext, contentHeader.Metadata);
            }
        }
    }
}
