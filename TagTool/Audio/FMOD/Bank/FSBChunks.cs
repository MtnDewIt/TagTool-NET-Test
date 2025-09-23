using TagTool.Common;
using TagTool.IO;

namespace TagTool.Audio.FMOD.Bank
{
    public enum ChunkType
    {
        CHANNELS = 1,
        FREQUENCY = 2,
        LOOP = 3,
        COMMENT = 4,
        XMASEEK = 6,
        DSPCOEFF = 7,
        ATRAC9CFG = 9,
        XWMADATA = 10,
        VORBISDATA = 11,
        PEAKVOLUME = 13,
        VORBISINTRALAYERS = 14,
        OPUSDATALEN = 15,
    }

    public interface IChunkData
    {
        void Read(EndianReader reader, uint expectedSize);
    }

    public class FSBChunk
    {
        public bool MoreChunks;
        public ChunkType ChunkType;
        public uint ChunkSize;
        public IChunkData ChunkData;

        public void Read(EndianReader reader)
        {
            var packedHeader = reader.ReadUInt32();
            MoreChunks = packedHeader.Bits(0, 1) == 1;
            ChunkSize = packedHeader.Bits(1, 24);
            ChunkType = (ChunkType)packedHeader.Bits(25, 7);
            ChunkData = ChunkType switch
            {
                ChunkType.VORBISDATA => new VorbisChunkData(),
                ChunkType.VORBISINTRALAYERS => new VorbisIntraLayersChunkData(),
                ChunkType.FREQUENCY => new FrequencyChunkData(),
                ChunkType.CHANNELS => new ChannelChunkData(),
                _ => new UnknownChunkData()
            };

            ChunkData.Read(reader, ChunkSize);
        }
    }

    public class VorbisChunkData : IChunkData
    {
        public uint SetupHash;

        public void Read(EndianReader reader, uint expectedSize)
        {
            SetupHash = reader.ReadUInt32();
            reader.Skip((int)(expectedSize - 4));
        }
    }

    public class VorbisIntraLayersChunkData : IChunkData
    {
        public int Channels;

        public void Read(EndianReader reader, uint expectedSize)
        {
            Channels = reader.ReadInt32();
        }
    }

    public class FrequencyChunkData : IChunkData
    {
        public uint FrequencyIndex;

        public void Read(EndianReader reader, uint expectedSize)
        {
            FrequencyIndex = reader.ReadUInt32();
        }
    }

    public class ChannelChunkData : IChunkData
    {
        public byte Channels;

        public void Read(EndianReader reader, uint expectedSize)
        {
            Channels = reader.ReadByte();
        }
    }

    public class UnknownChunkData : IChunkData
    {
        public byte[] Data = null;

        public void Read(EndianReader reader, uint expectedSize)
        {
            Data = reader.ReadBytes((int)expectedSize);
        }
    }
}
