using System.IO;
using TagTool.Audio.FMOD.Bank;

namespace TagTool.Audio.Bank
{
    public class SoundBank
    {
        public readonly FSB Bank;
        public readonly SoundBankIndex Index;

        public SoundBank(string filePath)
        {
            Index = new SoundBankIndex($"{filePath}.info");
            Bank = new FSB(filePath, withFilenames: false);
        }

        public BlamSound ExtractSound(int index)
        {
            FSBSubSound subsound = Bank.SubSounds[index];

            using Stream stream = Bank.OpenRead();
            byte[] data = Bank.Extract(stream, subsound);

            return new BlamSound(subsound.Frequency, subsound.Channels, (uint)subsound.SampleCount, Compression.OGG, data);
        }

        public int FindSound(uint hash)
        {
            return Index.FindSoundByHash(hash);
        }
    }
}
