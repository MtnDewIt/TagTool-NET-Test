using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "scenario_structure_lighting_info", Tag = "stli", Size = 0x34, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "scenario_structure_lighting_info", Tag = "stli", Size = 0x4C, MinVersion = CacheVersion.HaloReach)]
    public class ScenarioStructureLightingInfo : TagStructure
    {
        public int ImportInfoChecksum;
        public List<GenericLightDefinition> GenericLightDefinitions;
        public List<GenericLightInstance> GenericLightInstances;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<ScreenSpaceLightShader> ScreenSpaceLightShaders;

        public List<LightingRegion> Regions;
        public List<LightingMaterialInfo> MaterialInfo;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<InstanceImposterInfo> InstanceImposterInfos;

        [TagStructure(Size = 0x34, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x50, MinVersion = CacheVersion.HaloReach)]
        public class GenericLightDefinition : TagStructure
        {
            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
            public GenericLightInstanceType Type;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public GenericLightInstanceTypeReach TypeReach;

            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
            public GenericLightInstanceFlags Flags;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public GenericLightInstanceFlagsReach FlagsReach;

            public GenericLightInstanceShape Shape;

            [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
            public byte[] Padding;

            public RealRgbColor Color;
            public float Intensity;
            public float HotspotSize;
            public float HotspotCutoffSize;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HotspotFalloffSpeed;

            public Bounds<float> NearAttenuationBounds;
            public Bounds<float> FarAttenuationBounds;
            public float Aspect;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ClippingPlanesXPos;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ClippingPlanesXNeg;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ClippingPlanesYPos;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ClippingPlanesYNeg;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ClippingPlanesZPos;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ClippingPlanesZNeg;

            public enum GenericLightInstanceType : short
            {
                Omni = 0,
                Spot,
                Directional,
                Ambient,
            }

            public enum GenericLightInstanceTypeReach : short
            {
                Omni = 0,
                Spot,
                Directional,
            }

            [Flags]
            public enum GenericLightInstanceFlags : short
            {
                None = 0,
                UseNearAttenuation = 1 << 0,
                UseFarAttenuation = 1 << 1,
            }

            [Flags]
            public enum GenericLightInstanceFlagsReach : short
            {
                None = 0,
                UseNearAttenuation = 1 << 0,
                UseFarAttenuation = 1 << 1,
                InverseSquaredFalloff = 1 << 2,
                LightVersion1 = 1 << 3,
                HasClippingPlanes = 1 << 4,
            }

            public enum GenericLightInstanceShape : short
            {
                Rectangle = 0,
                Circle,
            }
        }

        [TagStructure(Size = 0x28, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x84, MinVersion = CacheVersion.HaloReach)]
        public class GenericLightInstance : TagStructure
        {
            public int DefinitionIndex;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int ShaderReferenceIndex;

            public RealPoint3d Origin;
            public RealVector3d Forward;
            public RealVector3d Up;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public GenericLightDefinitionType BungieLightType;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public GenericLightDefinitionFlags ScreenSpaceSpecular;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float BounceLightControl;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float LightVolumeDistance;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float LightVolumeIntensityScalar;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float FadeOutDistance;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float FadeStartDistance;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CachedTag UserControl;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CachedTag ShaderReference;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CachedTag GelReference;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CachedTag LensFlareReference;

            public enum GenericLightDefinitionType : short
            {
                DefaultLightmapLight = 0,
                UberLight,
                InlinedLight,
                ScreenSpaceLight,
                RerenderLights,
            }

            [Flags]
            public enum GenericLightDefinitionFlags : short
            {
                None = 0,
                ScreenSpaceLightHasSpecular = 1 << 0,
                Version1Instances = 1 << 1,
                RainVolume = 1 << 2,
                HasLensFlare = 1 << 3,
            }
        }

        [TagStructure(Size = 0x2C)]
        public class ScreenSpaceLightShader : TagStructure
        {
            public RealRgbColor SpecularColorNormal;
            public float SpecularSteepness;
            public RealRgbColor SpecularColorGazing;
            public float SpecularCoeff;
            public float DiffuseCoeff;
            public float RoughnessOffset;
            public float AlbedoBlend;
        }

        [TagStructure(Size = 0x10)]
        public class LightingRegion : TagStructure
        {
            public StringId Name;
            public List<Triangle> Triangles;

            [TagStructure(Size = 0x24)]
            public class Triangle : TagStructure
            {
                public RealPoint3d V0;
                public RealPoint3d V1;
                public RealPoint3d V2;
            }
        }

        [TagStructure(Size = 0x30, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloReach)]
        public class LightingMaterialInfo : TagStructure
        {
            public float EmissivePower;
            public RealRgbColor EmissiveColor;
            public float EmissiveQuality;
            public float EmissiveFocus;

            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
            public LightingMaterialFlags Flags;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public LightingMaterialFlagsReach FlagsReach;

            public float AttenuationFalloff;
            public float AttenuationCutoff;

            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
            public float FrustumBlend;
            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
            public Angle FrustumFalloffAngle;
            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
            public Angle FrustumCutoffAngle;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float BounceRatio;

            [Flags]
            public enum LightingMaterialFlags : int
            {
                None = 0,
                UseAttenuation = 1 << 0,
                PowerPerUnitArea = 1 << 1,
                UseShaderGel = 1 << 2,
            }

            [Flags]
            public enum LightingMaterialFlagsReach : int
            {
                None = 0,
                Reserved = 1 << 0,
                PowerPerUnitArea = 1 << 1,
                UseShaderGel = 1 << 2,
            }
        }

        [TagStructure(Size = 0xC)]
        public class InstanceImposterInfo : TagStructure
        {
            public StringId Name;
            public byte ImposterPolicy;

            [TagField(Flags = TagFieldFlags.Padding, Length = 0x3)]
            public byte[] Padding;

            public float TransitionDistance;
        }
    }
}