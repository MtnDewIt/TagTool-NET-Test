using System;
using TagTool.Tags;

namespace TagTool.Cache.Resources
{
    [TagStructure(Size = 0x24, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline498295)]
    [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnline530605, MaxVersion = CacheVersion.HaloOnline700123)]
    public class ResourceFileLocation : TagStructure
    {
        public short ResourceHandleSalt;
        public ResourceLocationFlags Flags;
        public CompressionCodec CodecIndex;

        [TagField(Length = 0x4, MinVersion = CacheVersion.HaloOnline530605, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Padding;

        public int Offset;
        public int CompressedSize;
        public int UncompressedSize;
        public int Checksum;

        public ResourceSubpageTable StreamingSublocationTable;

        [Flags]
        public enum ResourceLocationFlags : byte
        {
            None = 0,
            ValidChecksum = 1 << 0,
            Resources = 1 << 1,
            Textures = 1 << 2,
            TexturesB = 1 << 3,
            Audio = 1 << 4,
            Video = 1 << 5,
            Unused = 1 << 6,
            OnlyFullValidChecksum = 1 << 7,
        }

        public enum CompressionCodec : sbyte 
        {
            None = -1,
            LZ,
            RuntimeResource,
            RuntimeTagResource,
        }
    }
}
