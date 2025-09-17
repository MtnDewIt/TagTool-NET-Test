namespace TagTool.Audio
{
    public class BlamSound
    {
        public int SampleRate;
        public int ChannelCount;
        public Compression Compression;
        public uint SampleCount;
        public byte[] Data;

        public BlamSound(int sampleRate, int channelCount, uint sampleCount, Compression compression, byte[] data)
        {
            SampleRate = sampleRate;
            ChannelCount = channelCount;
            Compression = compression;
            SampleCount = sampleCount;

            Data = data;
        }

        public void UpdateFormat(Compression compression, byte[] data)
        {
            Compression = compression;
            Data = data;

            if (compression == Compression.PCM)
            {
                var dataLength = data.Length;
                uint newSampleCount = (uint)(((dataLength * 8) / 16) / ChannelCount);
                SampleCount = newSampleCount;
            }
        }
    }
}
