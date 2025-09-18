using System;
using TagTool.Cache;
using TagTool.Tags.Definitions;

namespace TagTool.Audio.Utils
{
    public static class SoundExtractorEldorado
    {
        /// <summary>
        /// Extracts raw sound data for a given permutation
        /// </summary>
        public static BlamSound ExtractSound(GameCacheEldoradoBase cache, Sound sound, int pitchRangeIndex, int permutationIndex)
        {
            PitchRange pitchRange = sound.PitchRanges[pitchRangeIndex];
            Permutation permutation = pitchRange.Permutations[permutationIndex];

            var resourceDefinition = cache.ResourceCache.GetSoundResourceDefinition(sound.Resource);
            int permutationDataSize = permutation.PermutationChunks[0].EncodedSize & 0x3FFFFFF;

            // TODO: we should probably add a flag somewhere in the sound definition to indicate that it has been padded for fmod
            int padding = sound.PlatformCodec.Compression == Compression.PCM ? 16 : 0;

            byte[] permutationData = new byte[permutationDataSize - (padding * 2)];
            Array.Copy(resourceDefinition.Data.Data, permutation.PermutationChunks[0].Offset + padding, permutationData, 0, permutationData.Length);

            int channelCount = Encoding.GetChannelCount(sound.PlatformCodec.Encoding);
            int sampleRate = sound.SampleRate.GetSampleRateHz();

            return new BlamSound(sampleRate, channelCount, permutation.SampleCount, sound.PlatformCodec.Compression, permutationData);
        }
    }
}
