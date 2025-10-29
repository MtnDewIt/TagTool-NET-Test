﻿using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Audio
{
    [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x38, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Size = 0xC, MinVersion = CacheVersion.HaloReach, BuildType = CacheBuildType.ReleaseBuild)]
    [TagStructure(Size = 0x48, MinVersion = CacheVersion.HaloReach, BuildType = CacheBuildType.TagsBuild)]
    public class PitchRange : TagStructure
	{
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild)]
        public short ImportNameIndex;

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public StringId ImportName;

        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild)]
        public short PitchRangeParametersIndex;

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public PitchRangeParameter PitchRangeParameters;

        //
        // Attenuation override
        //

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public SoundDistanceParameters DistanceParameters;

        /// <summary>
        /// keeps track of played permutations
        /// </summary>
        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public int XsyncFlags;

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public sbyte RuntimeUsablePermutationCount;

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public byte Unknown1; // unused

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public sbyte RuntimeLastPermutationIndex; 

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public sbyte RuntimeDiscardedPermutationIndex;

        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild)]
        public short EncodedPermutationDataIndex;

        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild)]
        public short EncodedRuntimePermutationFlagIndex;

        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild, Platform = CachePlatform.Original)]
        public short EncodedPermutationCount;

        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.ReleaseBuild, Platform = CachePlatform.Original)]
        public ushort FirstPermutationIndex;

        [TagField(MaxVersion = CacheVersion.Halo2PC)]
        public short PermutationCountH2;

        [TagField(Platform = CachePlatform.MCC, BuildType = CacheBuildType.ReleaseBuild)]
        public uint EncodedPermutationInfoMCC;

        [TagField(Gen = CacheGeneration.Eldorado)]
        [TagField(Gen = CacheGeneration.Third, BuildType = CacheBuildType.TagsBuild)]
        public List<Permutation> Permutations;
    }

    [TagStructure(Size = 0xC)]
    public class Gen2PitchRange : TagStructure
    {
        public short Name;
        public short Parameters;
        public short EncodedPermutationData;
        public short FirstRuntimePermutationFlagIndex;
        public short FirstPermutation;
        public short PermutationCount;
    }
}