using System;
using TagTool.Cache;
using TagTool.Tags.Definitions.Gen2;
using Gen2Sound = TagTool.Tags.Definitions.Gen2.Sound;

namespace TagTool.Audio.Utils
{
    public static class SoundExtractorGen2
    {
        /// <summary>
        /// Extracts raw sound data for a given permutation
        /// </summary>
        public static BlamSound ExtractSound(GameCacheGen2 cache, SoundCacheFileGestalt soundGestalt, Gen2Sound sound, int pitchRangeIndex, int permutationIndex)
        {
            var pitchRange = soundGestalt.PitchRanges[sound.PitchRangeIndex + pitchRangeIndex];
            var permutation = soundGestalt.GetPermutation(pitchRange.FirstPermutation + permutationIndex);

            // build sound data[]
            var permutationSize = 0;

            // compute total size
            for (int k = 0; k < permutation.ChunkCount; k++)
            {
                var permutationChunkIndex = permutation.FirstChunk + k;
                var chunk = soundGestalt.Chunks[permutationChunkIndex];
                permutationSize += chunk.GetSize();
            }

            byte[] permutationData = new byte[permutationSize];
            var currentOffset = 0;

            // move Data
            for (int k = 0; k < permutation.ChunkCount; k++)
            {
                var permutationChunkIndex = permutation.FirstChunk + k;
                var chunk = soundGestalt.Chunks[permutationChunkIndex];
                var chunkSize = chunk.GetSize();

                byte[] chunkData = cache.GetCacheRawData(chunk.ResourceReference.Gen2ResourceAddress, chunkSize);
                Array.Copy(chunkData, 0, permutationData, currentOffset, chunkSize);
                currentOffset += chunkSize;
            }

            int sampleRate = sound.SampleRate.GetSampleRateHz();
            int channelCount = Encoding.GetChannelCount(sound.Encoding);

            return new BlamSound(sampleRate, channelCount, permutation.SampleSize, sound.Compression, permutationData);
        }
    }
}
