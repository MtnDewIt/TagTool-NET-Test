using System.Collections.Generic;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.Audio.FMOD.Bank
{
    public class FSBSubSound
    {
        public int Channels;
        public int Frequency;
        public long DataOffset;
        public long DataSize;
        public int SampleCount;
        public string Name;
        public List<FSBChunk> Chunks = [];

        static readonly int[] ChannelsTable =
         [
             1,2,6,8
         ];

        static readonly int[] FrequencyTable =
        [
                4000,
                8000,
                11000,
                12000,
                16000,
                22050,
                24000,
                32000,
                44100,
                48000,
                96000
        ];

        public void Read(EndianReader reader)
        {
            ulong data = reader.ReadUInt64();

            bool moreChunks = (data & 1) == 1;
            int freqIndex = (int)data.Bits(1, 4);
            int channelsIndex = (int)data.Bits(5, 2);
            Channels = ChannelsTable[channelsIndex];
            Frequency = FrequencyTable[freqIndex];
            DataOffset = (long)data.Bits(7, 27) * 32;
            SampleCount = (int)data.Bits(34, 30);

            while (moreChunks)
            {
                var chunk = new FSBChunk();
                chunk.Read(reader);
                Chunks.Add(chunk);

                switch (chunk.ChunkData)
                {
                    case VorbisIntraLayersChunkData intraLayer:
                        Channels = intraLayer.Channels;
                        break;
                    case FrequencyChunkData freqChunk:
                        Frequency = FrequencyTable[freqChunk.FrequencyIndex];
                        break;
                }

                moreChunks = chunk.MoreChunks;
            }
        }
    }
}
