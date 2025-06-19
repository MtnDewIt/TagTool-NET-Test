using TagTool.Cache;
using TagTool.Common;
using TagTool.Geometry;
using System.Collections.Generic;
using static TagTool.Tags.TagFieldFlags;
using TagTool.Tags.Resources;
using System;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "scenario_lightmap_bsp_data", Tag = "Lbsp", Size = 0x1B4, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Name = "scenario_lightmap_bsp_data", Tag = "Lbsp", Size = 0x1E4, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "scenario_lightmap_bsp_data", Tag = "Lbsp", Size = 0x1E4, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "scenario_lightmap_bsp_data", Tag = "Lbsp", Size = 0x15C, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Name = "scenario_lightmap_bsp_data", Tag = "Lbsp", Size = 0x168, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class ScenarioLightmapBspData : TagStructure
    {
        public ScenarioLightmapBspFlags Flags;
        public short BspIndex;
        public int StructureChecksum;

        /// <summary>
        /// When sampling from the lightmap coefficient map, the resuling rgb SH coefficients are multiplied by this luminance scale.
        /// </summary>
        [TagField(Length = 9, MaxVersion = CacheVersion.HaloOnline700123)]
        public LuminanceScale[] CoefficientsMapScale;

        [TagField(ValidTags = new[] { "bitm" }, MinVersion = CacheVersion.HaloReach)]
        public CachedTag Unknown1;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float Brightness;

        [TagField(ValidTags = new[] { "bitm" })]
        public CachedTag LightmapSHCoefficientsBitmap;
        [TagField(ValidTags = new[] { "bitm" })]
        public CachedTag LightmapDominantLightDirectionBitmap;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> Unknown3;

        public List<StaticPerVertexLighting> StaticPerVertexLightingBuffers;
        public List<ClusterStaticPerVertexLighting> ClusterStaticPerVertexLightingBuffers;
        public List<InstancedGeometryLighting> InstancedGeometry;

        public List<InstancedGeometryLightProbe> InstancedGeometryLightProbes;

        public RenderGeometry Geometry;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<TriangleMappingPerMeshBlock> PerMeshTriangleMapping;

        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public List<Airprobe> Airprobes;
        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public List<SceneryLightProbe> SceneryLightProbes;
        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public List<MachineLightProbes> MachineLightProbes;
        /// <summary>
        /// Actually unused in all games. Probably intended for another object type.
        /// </summary>
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public List<int> Unused;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<GlobalSelfTrackBlock> SelfTrack;

        [Flags]
        public enum ScenarioLightmapBspFlags : ushort
        {
            // Halo 3 / ODST
            Compressed = 1 << 0,
            XsyncedGeometry = 1 << 1,
            Relightmapped = 1 << 2,
            GenerateFakeSmallLightmaps = 1 << 3,
            GeneratedFromMatchData = 1 << 4,
            // Reach
            OnlyACheckerBoard = 1 << 5,
            SurfaceToTriangleMappingPruned = 1 << 6,
            FakedLightmapTagForCacheBuild = 1 << 7,
            OptimizedForLessDpAll = 1 << 8,
            // Halo 4
            FloatingShadowsEnabled = 1 << 9,
            AtlasUnrefinedPacking = 1 << 10,
            AtlasRepacked = 1 << 11,
            UsingSimplifiedIrradianceLighting = 1 << 12,
            DisableShadowGeometry = 1 << 13,
            DisableHybridRefinement = 1 << 14
        }

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x4, MinVersion = CacheVersion.HaloReach)]
        public class StaticPerVertexLighting : TagStructure
        {
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public List<int> UnusedVertexBuffer;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public int VertexBufferIndex;

            [TagField(MinVersion = CacheVersion.HaloReach, Downgrade = nameof(VertexBufferIndex))]
            public short VertexBufferIndexReach;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ushort HDRScalar;

            [TagField(Flags = Runtime)]
            public VertexBufferDefinition VertexBuffer;
        }

        [TagStructure(Size = 0x4, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x8, MinVersion = CacheVersion.HaloReach)]
        public class ClusterStaticPerVertexLighting : TagStructure
        {
            public short LightmapBitmapsImageIndex;
            public short StaticPerVertexLightingIndex;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int PerVertexOffset;
        }

        [TagStructure(Size = 0x8, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0xC, MinVersion = CacheVersion.HaloReach)]
        public class InstancedGeometryLighting : TagStructure
        {
            public short LightmapBitmapsImageIndex;
            public short StaticPerVertexLightingIndex;
            public short InstancedGeometryLightProbesIndex;
            [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint AnalyticalLightIndex;
        }

        [TagStructure(Size = 0xC)]
        public class TriangleMappingPerMeshBlock : TagStructure
        {
            public List<TriangleMappingBlock> Mesh;

            [TagStructure(Size = 0x4)]
            public class TriangleMappingBlock : TagStructure
            {
                public int Word;
            }
        }

        [TagStructure(Size = 0x0)]
        public class NullBlock : TagStructure
        {
        }

        [TagStructure(Size = 0x240)]
        public class GlobalSelfTrackBlock : TagStructure
        {
            [TagField(Length = 32)]
            public string Time;
            [TagField(Length = 32)]
            public string Machine;
            [TagField(Length = 256)]
            public string Version;
            [TagField(Length = 256)]
            public string Command;
        }
    }

    [TagStructure(Size = 0x48, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x24, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
    public class InstancedGeometryLightProbe : TagStructure
    {
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public HalfRGBLightProbe LightProbe;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public DualVmfLightProbe VmfLightProbe;
    }

    [TagStructure(Size = 0x5C, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x38, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
    public class Airprobe : TagStructure
    {
        public RealPoint3d Position;
        public StringId Name;
        public uint Flags;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public HalfRGBLightProbe LightProbe;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public DualVmfLightProbe VmfLightProbe;
    }

    [TagStructure(Size = 0x50, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x2C, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
    public class SceneryLightProbe : TagStructure
    {
        public ObjectIdentifier ObjectId;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public HalfRGBLightProbe LightProbe;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public DualVmfLightProbe VmfLightProbe;
    }

    [TagStructure(Size = 0x2C)]
    public class MachineLightProbes : TagStructure
    {
        public ObjectIdentifier ObjectId;
        public RealRectangle3d Bounds;
        public List<MachineLightProbe> LightProbes;

        [TagStructure(Size = 0x54, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x30, MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
        public class MachineLightProbe : TagStructure
        {
            public RealPoint3d Position;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public HalfRGBLightProbe LightProbe;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public DualVmfLightProbe VmfLightProbe;
        }
    }

    [TagStructure(Size = 0x24)]
    public class DualVmfLightProbe : TagStructure
    {
        [TagField(Length = 16)]
        public ushort[] VmfTerms;
        public uint AnalyticalLightIndex;
    }

}
