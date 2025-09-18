using System.IO;
using TagTool.Cache;

namespace TagTool.Audio.Utils
{
    public class AudioCache
    {
        public static BlamSound Load(string soundCachePath, CacheVersion version, string tagName, int pitchRangeIndex, int permutationIndex, Compression format, int sampleRate, uint sampleCount, int channelCount)
        {
            string cachedFilePath = GetSoundCacheFileName(tagName, format, version, soundCachePath, pitchRangeIndex, permutationIndex);
            if (File.Exists(cachedFilePath))
            {
                var data = File.ReadAllBytes(cachedFilePath);
                return new BlamSound(sampleRate, channelCount, sampleCount, format, data);
            }

            return null;
        }

        public static void Store(string soundCachePath, CacheVersion version, string tagName, int pitchRangeIndex, int permutationIndex, BlamSound sound)
        {
            string cachedFilePath = GetSoundCacheFileName(tagName, sound.Compression, version, soundCachePath, pitchRangeIndex, permutationIndex);
            File.WriteAllBytes(cachedFilePath, sound.Data);
        }

        private static string GetSoundCacheFileName(string tagName, Compression targetFormat, CacheVersion version, string cacheFilePath, int pitchRangeIndex, int permutationIndex)
        {
            var split = tagName.Split('\\');
            var endName = split[split.Length - 1]; //get the last portion of the tag name
            var newPath = cacheFilePath;

            newPath = Path.Combine(newPath, version.ToString());

            for (int i = 0; i < split.Length - 1; i++)
            {

                var folder = split[i];

                var dir = Path.Combine(newPath, folder); //combine the new path with the current folder
                if (!Directory.Exists(dir))// check if that specific folder exists and if not create it
                    Directory.CreateDirectory(dir);

                newPath = Path.Combine(newPath, folder); // update the new path varible with the current folder
            }

            var basePermutationCacheName = Path.Combine(newPath, endName); //combine the last portion of the tag name with the new path

            var extension = AudioUtils.GetFormatFileExtension(targetFormat);
            return $"{basePermutationCacheName}_{pitchRangeIndex}_{permutationIndex}.{extension}";
        }
    }
}
