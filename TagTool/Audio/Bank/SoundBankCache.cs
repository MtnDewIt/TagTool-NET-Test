using System.Collections.Generic;
using System.IO;

namespace TagTool.Audio.Bank
{
    public class SoundBankCache
    {
        public List<DirectoryInfo> Directories;
        public List<SoundBank> LoadedBanks;

        public SoundBankCache(List<DirectoryInfo> directories)
        {
            Directories = directories;
            LoadedBanks = new List<SoundBank>();

            LoadBanks();
        }

        private void LoadBanks()
        {
            foreach (var directory in Directories)
            {
                foreach (var file in directory.EnumerateFiles())
                {
                    if (file.Extension == ".fsb")
                        LoadBank(file.FullName);
                }
            }
        }

        private void LoadBank(string filePath)
        {
            LoadedBanks.Add(new SoundBank(filePath));
        }

        public int FindSound(uint hash, out SoundBank outBank)
        {
            outBank = null;
            foreach (var bank in LoadedBanks)
            {
                int soundIndex = bank.FindSound(hash);
                if (soundIndex != -1)
                {
                    outBank = bank;
                    return soundIndex;
                }
            }
            return -1;
        }

        public SoundInfo GetSoundInfo(uint hash)
        {
            int soundIndex = FindSound(hash, out SoundBank bank);
            if (soundIndex == -1)
                return null;

            return bank.Index[soundIndex];
        }

        public BlamSound ExtractSound(uint hash)
        {
            int soundIndex = FindSound(hash, out SoundBank bank);
            if (soundIndex == -1)
                return null;

            return bank.ExtractSound(soundIndex);
        }
    }
}
