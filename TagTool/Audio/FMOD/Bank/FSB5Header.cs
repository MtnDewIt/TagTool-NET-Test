using System;
using System.Diagnostics;
using TagTool.IO;

namespace TagTool.Audio.FMOD.Bank
{
    class FSBHeader
    {
        public uint HeaderSize;

        public uint SubVersion;
        public int NumSoundSounds;
        public uint HeaderChunkSizeBytes;
        public uint NamesChunkSizeBytes;
        public uint DataChunkSizeBytes;
        public CompressionFormat CompressionType;
        public uint DataVersion;

        public void Read(EndianReader reader)
        {
            string magic = reader.ReadString(4);
            if (magic != "FSB5")
                throw new FormatException("Header check failed. Not an FSB5");

            SubVersion = reader.ReadUInt32();
            if (SubVersion != 1)
                throw new FormatException($"Header check failed. FSB5 sub-version {SubVersion} is unknown");

            NumSoundSounds = reader.ReadInt32();
            Debug.Assert(NumSoundSounds > 0);

            HeaderChunkSizeBytes = reader.ReadUInt32();
            Debug.Assert(HeaderChunkSizeBytes > 0);

            NamesChunkSizeBytes = reader.ReadUInt32();

            DataChunkSizeBytes = reader.ReadUInt32();
            Debug.Assert(DataChunkSizeBytes > 0);

            CompressionType = (CompressionFormat)reader.ReadInt32();

            DataVersion = reader.ReadUInt32();
            if (DataVersion != 1)
                throw new FormatException($"Header check failed. FSB5 data version {DataVersion} is unsupported");

            HeaderSize = 0x3C;

            reader.SeekTo(HeaderSize);
        }
    }
}
