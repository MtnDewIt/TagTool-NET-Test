using System;
using System.Collections.Generic;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "sound_cache_file_gestalt", Tag = "ugh!", Size = 0xC8, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "sound_cache_file_gestalt", Tag = "ugh!", Size = 0xB8, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Name = "sound_cache_file_gestalt", Tag = "ugh!", Size = 0xD4, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "sound_cache_file_gestalt", Tag = "ugh!", Size = 0xC4, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Name = "sound_cache_file_gestalt", Tag = "ugh!", Size = 0xDC, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Name = "sound_cache_file_gestalt", Tag = "ugh!", Size = 0xE0, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class SoundCacheFileGestalt : TagStructure
	{
        [TagField(Platform = CachePlatform.MCC)]
        public uint ContentType;

        public List<PlatformCodec> PlatformCodecs;

        public List<PlaybackParameter> PlaybackParameters;
        public List<Scale> Scales;
        public List<ImportName> ImportNames;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public List<PitchRangeDistance> PitchRangeDistances;

        public List<PitchRangeParameter> PitchRangeParameters;
        public List<PitchRange> PitchRanges;
        public List<Permutation> Permutations;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public List<LanguagePermutation> PermutationLanguages;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<CustomPlaybackReach> CustomPlaybacksReach;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public List<CustomPlayback> CustomPlaybacks;

        public List<LanguageBlock> LanguageDurations;

        /// <summary>
        /// Bit vector
        /// </summary>
        public List<byte> RuntimePermutationFlags;

        public TagFunction NativeSampleData = new TagFunction { Data = new byte[0] };
        public uint Unknown4;
        public uint Unknown5;

        public List<PermutationChunk> PermutationChunks;
        public List<Promotion> Promotions;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public List<ExtraInfo> ExtraInfo;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<TagResourceReference> FacialAnimations;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<LayerMarker> LayerMarkers;

        [TagStructure(Size = 0x4)]
        public class LayerMarker : TagStructure
        {
            public int SampleOffset;
        }

        //
        // Functions for sound conversion 
        //

        /// <summary>
        /// Get the chunk size from a chunk in Gen3 Blam engine
        /// </summary>
        /// <param name="chunkIndex"></param>
        /// <returns></returns>
        public int GetChunkSize(int chunkIndex)
        {
            return PermutationChunks[chunkIndex].EncodedSize & 0xFFFFFF;
        }

        /// <summary>
        /// Get the chunk offset.
        /// </summary>
        /// <param name="chunkIndex"></param>
        /// <returns></returns>
        public int GetChunkOffset(int chunkIndex)
        {
            return PermutationChunks[chunkIndex].Offset;
        }

        /// <summary>
        /// Get the size of the data for a permutation
        /// </summary>
        /// <param name="permutationIndex"></param>
        /// <returns></returns>
        public int GetPermutationSize(int permutationIndex)
        {
            var permutation = Permutations[permutationIndex];
            var lastChunk = PermutationChunks[permutation.PermutationChunkCount + permutation.FirstPermutationChunkIndex - 1];
            var firstChunk = PermutationChunks[permutation.FirstPermutationChunkIndex];

            return lastChunk.Offset + (lastChunk.EncodedSize & 0xFFFFFF) - firstChunk.Offset;
        }

        /// <summary>
        /// Get the offset of the permutation in the resource.
        /// </summary>
        /// <param name="permutationIndex"></param>
        /// <returns></returns>
        public int GetPermutationOffset(int permutationIndex)
        {
            int offset = int.MaxValue;
            var permutation = Permutations[permutationIndex];

            // Get the minimal offset value for all the chunks in the permutation
            for (int i = 0; i < permutation.PermutationChunkCount; i++)
            {
                var tempOffset = GetChunkOffset(permutation.FirstPermutationChunkIndex + i);
                if (tempOffset < offset)
                    offset = tempOffset;
            }

            return offset;
        }

        /// <summary>
        /// Get the index of the first permutation in a pitch range block.
        /// </summary>
        /// <param name="pitchRangeIndex"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public int GetFirstPermutationIndex(int pitchRangeIndex, CachePlatform platform)
        {
            var pitchRange = PitchRanges[pitchRangeIndex];
            return GetFirstPermutationIndex(pitchRange, platform);
        }

        /// <summary>
        /// Get the index of the first permutation in a pitch range block.
        /// </summary>
        /// <param name="pitchRange"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public int GetFirstPermutationIndex(PitchRange pitchRange, CachePlatform platform)
        {
            if (platform == CachePlatform.MCC)
            {
                return (int)(pitchRange.EncodedPermutationInfoMCC << 12 >> 12);
            }
            else
            {
                return pitchRange.FirstPermutationIndex;
            }
        }

        /// <summary>
        /// Get the number of permutation in the pitch range block.
        /// </summary>
        /// <param name="pitchRangeIndex"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public int GetPermutationCount(int pitchRangeIndex, CachePlatform platform)
        {
            return GetPermutationCount(PitchRanges[pitchRangeIndex], platform);
        }

        /// <summary>
        /// Get the number of permutation in the pitch range block.
        /// </summary>
        public int GetPermutationCount(PitchRange pitchRange, CachePlatform platform)
        {
            if (platform == CachePlatform.MCC)
            {
                return (int)((pitchRange.EncodedPermutationInfoMCC >> 20) & 63);
            }
            else
            {
                return (pitchRange.EncodedPermutationCount >> 4) & 63;
            }
        }

        /// <summary>
        /// Get permutation block.
        /// </summary>
        /// <param name="permutationIndex"></param>
        /// <returns></returns>
        public Permutation GetPermutation(int permutationIndex)
        {
            return Permutations[permutationIndex];
        }

        /// <summary>
        /// Get permutation block.
        /// </summary>
        public Permutation GetPermutation(PitchRange pitchRange, int permutationIndex, CachePlatform platform)
        {
            int firstIndex = GetFirstPermutationIndex(pitchRange, platform);
            return Permutations[firstIndex + permutationIndex];
        }

        /// <summary>
        /// Get the number of samples in a permutation
        /// </summary>
        /// <param name="permutationIndex"></param>
        /// <returns></returns>
        public uint GetPermutationSamples(int permutationIndex)
        {
            return Permutations[permutationIndex].SampleCount;
        }

        /// <summary>
        /// Get the total number of audio samples in a pitch range block.
        /// </summary>
        public uint GetSamplesPerPitchRange(PitchRange pitchRange, CachePlatform platform)
        {
            uint samples = 0;

            var firstPermutationIndex = GetFirstPermutationIndex(pitchRange, platform);

            for(int i = 0; i < GetPermutationCount(pitchRange, platform); i++)
            {
                samples += GetPermutationSamples(firstPermutationIndex + i);
            }

            return samples;
        }

        /// <summary>
        /// Get the order of the permutations.
        /// </summary>
        /// <param name="pitchRangeIndex"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public int[] GetPermutationOrder(int pitchRangeIndex, CachePlatform platform)
        {
            var pitchRange = PitchRanges[pitchRangeIndex];
            var permutationCount = GetPermutationCount(pitchRangeIndex, platform);
            int[] permutationOrder = new int[permutationCount];

            for(int i = 0; i < permutationCount; i++)
            {
                permutationOrder[i] = Permutations[pitchRange.FirstPermutationIndex + i].PermutationInfoIndex;
            }
            return permutationOrder;
        }

        /// <summary>
        /// Get the file size given the pitch range blocks
        /// </summary>
        /// <param name="basePitchRangeIndex"></param>
        /// <param name="pitchRangeCount"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public int GetFileSize(int basePitchRangeIndex, int pitchRangeCount, CachePlatform platform)
        {
            int fileSize = 0;

            // largest offset among all permutations
            var maxOffset = -1;
            // permutation index where the largest offset resides.
            var maxIndex = -1;

            //Loop through all the permutation in all pitch ranges to get the largest offset, then use the maxIndex to get totalSize
            for(int i = basePitchRangeIndex; i < basePitchRangeIndex + pitchRangeCount; i++)
            {
                for( int j = GetFirstPermutationIndex(i, platform); j < GetFirstPermutationIndex(i, platform)+GetPermutationCount(i, platform); j++)
                {
                    if (GetPermutationOffset(j) >= maxOffset)
                    {
                        maxOffset = GetPermutationOffset(j);
                        maxIndex = j;
                    }
                }
            }
            if (maxOffset < 0 || maxIndex < 0)
                return -1;

            fileSize = maxOffset + GetPermutationSize(maxIndex);

            return fileSize;
        }

        public PermutationChunk GetPermutationChunk(int permutationChunkIndex)
        {
            return PermutationChunks[permutationChunkIndex];
        }

        public PermutationChunk GetPermutationChunk(Permutation permutation, int chunkIndex)
        {
            return PermutationChunks[permutation.FirstPermutationChunkIndex + chunkIndex];
        }
    }
}