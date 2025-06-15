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
    [TagStructure(Size = 0xFC, Align = 0x1, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x2B4, Align = 0x1, MinVersion = CacheVersion.HaloReach)]
    public class BlfContentHeader : BlfChunkHeader
    {
        public ushort BuildVersion;
        public ushort MapMinorVersion;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public ContentItemMetadata Metadata;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachContentItemMetadata MetadataReach;

        public static BlfContentHeader Decode(EndianReader reader, TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            var contentHeader = new BlfContentHeader();

            contentHeader.Signature = reader.ReadTag();
            contentHeader.Length = reader.ReadInt32();
            contentHeader.MajorVersion = reader.ReadInt16();
            contentHeader.MinorVersion = reader.ReadInt16();
            contentHeader.BuildVersion = reader.ReadUInt16();
            contentHeader.MapMinorVersion = reader.ReadUInt16();

            if (deserializer.Version == CacheVersion.HaloReach)
            {
                if (deserializer.CachePlatform == CachePlatform.MCC)
                {
                    // TODO: Figure out how to account for 343's bullshit :/
                }
                else 
                {
                    contentHeader.MetadataReach = ReachContentItemMetadata.Decode(new BitStream(reader.BaseStream), false);
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

            if (serializer.Version == CacheVersion.HaloReach)
            {
                ReachContentItemMetadata.Encode(new BitStream(writer.BaseStream), contentHeader.MetadataReach, false);
            }
            else 
            {
                serializer.Serialize(dataContext, contentHeader.Metadata);
            }
        }
    }
}
