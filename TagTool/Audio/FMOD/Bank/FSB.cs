using System.Collections.Generic;
using System.IO;
using TagTool.IO;

namespace TagTool.Audio.FMOD.Bank
{
    public class FSB
    {
        private readonly string FilePath;
        private FSBHeader Header;
        public List<FSBSubSound> SubSounds;

        public FSB(string filePath)
        {
            FilePath = filePath;

            using var reader = new EndianReader(OpenRead());
            Load(reader);
        }

        public Stream OpenRead()
        {
            return File.OpenRead(FilePath);
        }

        public byte[] ExtractRaw(Stream stream, FSBSubSound sound)
        {
            long baseOffset = Header.HeaderSize + Header.HeaderChunkSizeBytes + Header.NamesChunkSizeBytes;
            var reader = new EndianReader(stream);
            reader.SeekTo(sound.DataOffset + baseOffset);
            return reader.ReadBytes((int)sound.DataSize);
        }

        public byte[] Extract(Stream stream, FSBSubSound sound)
        {
            byte[] raw = ExtractRaw(stream, sound);
            switch (Header.CompressionType)
            {
                case CompressionFormat.VORBIS:
                    return OggVorbisRebuilder.Rebuild(sound, raw);
                case CompressionFormat.PCM32:
                case CompressionFormat.PCM24:
                case CompressionFormat.PCM16:
                    return raw;

                default:
                    throw new System.Exception($"Compression type '{Header.CompressionType}' not supported");
            }
        }

        private void Load(EndianReader reader)
        {
            Header = new FSBHeader();
            Header.Read(reader);

            SubSounds = new List<FSBSubSound>(Header.NumSoundSounds);
            for (int i = 0; i < Header.NumSoundSounds; i++)
            {
                var subsound = new FSBSubSound();
                subsound.Read(reader);
                SubSounds.Add(subsound);
            }

            for (int i = 0; i < SubSounds.Count; i++)
            {
                long end = i >= SubSounds.Count - 1 ? Header.DataChunkSizeBytes : SubSounds[i + 1].DataOffset;
                SubSounds[i].DataSize = end - SubSounds[i].DataOffset;
            }

            if (Header.NamesChunkSizeBytes > 0)
            {
                reader.SeekTo(Header.HeaderChunkSizeBytes + Header.HeaderSize);
                uint[] nameOffsets = new uint[Header.NumSoundSounds];
                for (int i = 0; i < Header.NumSoundSounds; i++)
                    nameOffsets[i] = reader.ReadUInt32();

                for (int i = 0; i < Header.NumSoundSounds; i++)
                {
                    reader.SeekTo(Header.HeaderChunkSizeBytes + Header.HeaderSize + nameOffsets[i]);
                    SubSounds[i].Name = reader.ReadNullTerminatedString();
                }
            }
        }
    }
}
