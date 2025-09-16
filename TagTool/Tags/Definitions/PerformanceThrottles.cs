using System;
using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Tags.Definitions
{
	[TagStructure(Name = "performance_throttles", Tag = "perf", Size = 0xC, MaxVersion = CacheVersion.Eldorado700123)]
	[TagStructure(Name = "performance_throttles", Tag = "perf", Size = 0x10, MinVersion = CacheVersion.HaloReach)]
	public class PerformanceThrottles : TagStructure
	{
        // block 0: default non-splitscreen
        // block 1: two-way splitscreen
        // block 2: three-way splitscreen
        // block 3: four-way splitscreen

		[TagField(MinVersion = CacheVersion.HaloReach)]
		public int VersionReach;

		public List<PerformanceThrottleBlock> PerformanceThrottle;
		
		[TagStructure(Size = 0x38, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
		[TagStructure(Size = 0x4C, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
		[TagStructure(Size = 0x3C, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.MCC)]
		[TagStructure(Size = 0x50, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
		public class PerformanceThrottleBlock : TagStructure
		{
			[TagField(MaxVersion = CacheVersion.Eldorado700123)]
			public PerformanceThrottleFlags Flags;
			[TagField(MinVersion = CacheVersion.HaloReach)]
			public PerformanceThrottleFlagsReach FlagsReach;

			public float WaterLod;
			public float DecoratorFadeDistanceScale; // 0 = off
			public float EffectLodDistanceScale;
			public float InstancedGeometryFadeModifier;
			public float ObjectFadeModifier;
			public float ObjectLodThresholdModifier;

			[TagField(MinVersion = CacheVersion.HaloReach)]
			public float ObjectImposterCutoffOffset; // pushes out the distance in world units the imposter stops rendering

			public float DecalFadeDistanceScale;

			[TagField(MinVersion = CacheVersion.HaloReach)]
			public float StructureInstanceLodModifier; // modifies the distance at which structure instances will lod
			
			public int MaxCpuDynamicLights; // will quickly fade cpu lights when we try to render more than this many
			public float CpuLightFadeDistanceScale; // scales the size used for distance-fade (set smaller to make it fade earlier)
			public int MaxGpuDynamicLights; // will quickly fade gpu lights when we try to render more than this many
			public float GpuLightFadeDistanceScale; // scales the size used for distance-fade (set smaller to make it fade earlier)
			
			[TagField(MinVersion = CacheVersion.HaloReach)]
			public int MaxScreenspaceDynamicLights; // will quickly fade screenspace lights when we try to render more than this many
			[TagField(MinVersion = CacheVersion.HaloReach)]
			public float ScreenspaceLightFadeDistanceScale; // scales the size used for distance-fade (set smaller to make it fade earlier)

			public int MaxShadowCastingObjects; // 0 = off
			public float ShadowQualityLod;

			[TagField(MinVersion = CacheVersion.HaloReach)]
			public float Coop34WayCampaignObjectAndInstanceMultiplier; // also affects firefight
			
			[TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
			public float AnisotropyLevel;
			
			[Flags]
			public enum PerformanceThrottleFlags : uint
			{
			    BloomIgnoreLDR = 1 << 0,
			    DisableObjectPRT = 1 << 1,
			    DisableFirstPersonShadow = 1 << 2,
			    HighQualityShadows = 1 << 3,
			    DisableFxaa = 1 << 4,
			    DisableMotionBlur = 1 << 5,
			    DisableHeavyPerfEffectsxbox = 1 << 6,
			    MultithreadedVisibility = 1 << 7
			}

			[Flags]
			public enum PerformanceThrottleFlagsReach : uint
			{
			    DisableObjectPrt = 1 << 0,
			    DisableFirstPersonShadow = 1 << 1,
			    DisableDynamicLightsShadow = 1 << 2,
			    DisablePatchyFog = 1 << 3,
			    DisableCheapParticles = 1 << 4,
			    DisableSsao = 1 << 5,
			    DisableChudTurbulence = 1 << 6,
			    DisableDecoratorTypeInstances = 1 << 7,
			    DisableRain = 1 << 8,
			    EnableCoop3 = 1 << 9
			}
		}
	}
}
