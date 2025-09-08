using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "new_cinematic_lighting", Tag = "nclt", Size = 0x1C, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "new_cinematic_lighting", Tag = "nclt", Size = 0x60, MinVersion = CacheVersion.HaloReach)]
    public class NewCinematicLighting : TagStructure
    {
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public List<CinematicShLightBlock> ShLights;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public RealRgbColor DirectionalColor;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float DirectionalScale; // [0,4]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float Direction;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float FrontBack;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float Bandwidth; // [0,1]
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public RealRgbColor AnalyticalColor;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float AnalyticalScale;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float DirectionA;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float FrontBackA;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public RealRgbColor AmbientColor;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float AmbientScale;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float SampledVmfLightWeight;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float SampledAnalyticalLightWeight;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float VmfLightScale;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float AnalyticalLightScale;

        public List<CinematicDynamicLightBlock> DynamicLights;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public float EnvironmentalLightingScale;

        [TagStructure(Size = 0x20)]
        public class CinematicShLightBlock : TagStructure
        {
            public CinematicShLightFlags Flags;
            public float Direction; // degrees
            public float FrontBack; // degrees
            public float Intensity;
            public RealRgbColor Color;
            public float Diffusion;

            [Flags]
            public enum CinematicShLightFlags : uint
            {
                None,
                DebugThisLight = 1 << 0
            }
        }

        [TagStructure(Size = 0x20)]
        public class CinematicDynamicLightBlock : TagStructure
        {
            public CinematicDynamicLightFlags Flags;
            public float Direction;
            public float FrontBack;
            public float Distance; // world units
            public CachedTag Light;

            [Flags]
            public enum CinematicDynamicLightFlags : uint
            {
                None,
                DebugThisLight = 1 << 0,
                FollowObject = 1 << 1,
                PositionAtMarker = 1 << 2
            }
        }
    }
}