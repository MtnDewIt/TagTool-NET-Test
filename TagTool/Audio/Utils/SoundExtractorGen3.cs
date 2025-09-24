using System;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Tags.Resources;

namespace TagTool.Audio.Utils
{
    public static class SoundExtractorGen3
    {
        /// <summary>
        /// Extracts raw sound data for a given permutation
        /// </summary>
        public static BlamSound ExtractSound(GameCacheGen3 cache, SoundCacheFileGestalt soundGestalt, Sound sound, int pitchRangeIndex, int permutationIndex)
        {
            if (CacheVersionDetection.GetCacheBuildType(cache.Version) == CacheBuildType.TagsBuild)
            {
                SoundResourceDefinition resourceDefinition = cache.ResourceCache.GetSoundResourceDefinition(sound.GetResource(cache.Version, cache.Platform));

                var permutation = sound.PitchRanges[pitchRangeIndex].Permutations[permutationIndex];
                var rawInfo = sound.ExtraInfo[0].LanguagePermutations[permutation.RawInfoIndex].RawInfo[0];

                Compression format = sound.PlatformCodec.Compression;
                int sampleRate = sound.PlatformCodec.SampleRate.GetSampleRateHz();
                int channelCount = Encoding.GetChannelCount(sound.PlatformCodec.Encoding);
                uint sampleCount = permutation.SampleCount;

                var permutationData = new byte[rawInfo.ResourceSampleSize];
                Array.Copy(resourceDefinition.Data.Data, (int)rawInfo.ResourceSampleOffset, permutationData, 0, (int)rawInfo.ResourceSampleSize);

                var blamSound = new BlamSound(sampleRate, channelCount, sampleCount, format, permutationData);
   
                return blamSound;
            }
            else
            {
                int pitchRangeGestaltIndex = sound.SoundReference.PitchRangeIndex + pitchRangeIndex;
                int permutationGestaltIndex = soundGestalt.GetFirstPermutationIndex(pitchRangeGestaltIndex, cache.Platform) + permutationIndex;
                var permutation = soundGestalt.GetPermutation(permutationGestaltIndex);
                int permutationSize = soundGestalt.GetPermutationSize(permutationGestaltIndex);
                int permutationOffset = soundGestalt.GetPermutationOffset(permutationGestaltIndex);

                PlatformCodec codec = soundGestalt.PlatformCodecs[sound.SoundReference.PlatformCodecIndex];
                Compression format = codec.Compression;
                int sampleRate = codec.SampleRate.GetSampleRateHz();
                int channelCount = Encoding.GetChannelCount(codec.Encoding);
                uint sampleCount = permutation.SampleCount;

                if (cache.Platform == CachePlatform.MCC)
                {
                    cache.LoadSoundBanks();
                    var info = cache.SoundBanks.GetSoundInfo(permutation.FsbSoundHash);
                    BlamSound blamSound = cache.SoundBanks.ExtractSound(permutation.FsbSoundHash);
                    if (blamSound == null)
                        return null;

                    return blamSound;
                }
                else
                {
                    SoundResourceDefinition resourceDefinition = cache.ResourceCache.GetSoundResourceDefinition(sound.GetResource(cache.Version, cache.Platform));
                    if (resourceDefinition == null)
                        return null;

                    byte[] permutationData = new byte[permutationSize];
                    Array.Copy(resourceDefinition.Data.Data, permutationOffset, permutationData, 0, permutationSize);

                    return new BlamSound(sampleRate, channelCount, sampleCount, format, permutationData);
                }
            }
        }
    }
}
