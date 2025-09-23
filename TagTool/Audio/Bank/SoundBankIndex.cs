using System.Collections;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Audio.Bank
{
    public class SoundBankIndex : IReadOnlyList<SoundInfo>
    {
        private readonly Dictionary<uint, int> HashLookup = new Dictionary<uint, int>();
        private List<SoundInfo> Sounds = new List<SoundInfo>();

        public int Count => Sounds.Count;

        public SoundInfo this[int index] => Sounds[index];

        public SoundBankIndex(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
                Load(stream);
        }

        public SoundBankIndex(Stream stream)
        {
            Load(stream);
        }

        public int FindSoundByHash(uint hash)
        {
            if (HashLookup.TryGetValue(hash, out int index))
                return index;
            else
                return -1;
        }

        private void Load(Stream stream)
        {
            var reader = new EndianReader(stream);
            var dataContext = new DataSerializationContext(reader);
            var deserializer = new TagDeserializer(CacheVersion.Unknown, CachePlatform.MCC);

            int index = 0;
            while (!reader.EOF)
            {
                var info = deserializer.Deserialize<SoundInfo>(dataContext);
                if (HashLookup.ContainsKey(info.Hash))
                {
                    index++;
                    continue;
                }
                HashLookup.Add(info.Hash, index);
                Sounds.Add(info);
                index++;
            }
        }

        public IEnumerator<SoundInfo> GetEnumerator() => Sounds.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [TagStructure(Size = 0x118)]
    public class SoundInfo : TagStructure
    {
        public uint Hash;
        public uint PcmDataSize;
        public int ChannelCount;
        public int SampleSize;
        public uint LoopStart;
        public uint LoopEnd;
        [TagField(Length = 256)]
        public string Filename;

        public uint SampleCount => (uint)(PcmDataSize / (SampleSize * ChannelCount));

        public override string ToString() => Filename;
    }
}
