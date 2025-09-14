using TagTool.Geometry;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "particle_model", Tag = "pmdf", Size = 0x90, MaxVersion = Cache.CacheVersion.Eldorado700123)]
    [TagStructure(Name = "particle_model", Tag = "pmdf", Size = 0xA8, MinVersion = Cache.CacheVersion.HaloReach, Platform = Cache.CachePlatform.Original)]
    [TagStructure(Name = "particle_model", Tag = "pmdf", Size = 0xB4, MinVersion = Cache.CacheVersion.HaloReach, Platform = Cache.CachePlatform.MCC)]
    public class ParticleModel : TagStructure
	{
        public RenderGeometry Geometry;
        public List<MVariant> MVariants;

        [TagStructure(Size = 0x10)]
        public class MVariant : TagStructure
		{
            [TagField(Length = 4)]
            public float[] RuntimeMCount = new float[4];
        }
    }
}