using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "scenario_lightmap", Tag = "sLdT", Size = 0x4C, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "scenario_lightmap", Tag = "sLdT", Size = 0x58, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Name = "scenario_lightmap", Tag = "sLdT", Size = 0x4C, MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Name = "scenario_lightmap", Tag = "sLdT", Size = 0x40, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class ScenarioLightmap : TagStructure
	{
        public uint JobGuid;

        [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
        public List<ScenarioLightmapBspData> Lightmaps;

        public List<DataReferenceBlock> PerPixelLightmapDataReferences;

        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public List<CachedTag> PerVertexLightmapDataReferences;

        public List<Airprobe> Airprobes;
        public List<SceneryLightProbe> SceneryLightProbes;
        public List<MachineLightProbes> MachineLightProbes;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0xC, MaxVersion = CacheVersion.Eldorado700123)]
        public byte[] DeprecatedLightmapBspDataBlock = new byte[0xC];

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> LightmapBspS;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public List<NullBlock> UberLightBspIndexRemapping;

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0x20, MinVersion = CacheVersion.HaloReach)]
        public class DataReferenceBlock : TagStructure
        {
            [TagField(ValidTags = new[] { "Lbsp" })]
            public CachedTag LightmapBspData;
            [TagField(ValidTags = new[] { "wetn" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag WetnessBspData;
        }
    }
}
