using TagTool.Cache;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.Havok;

namespace TagTool.Tags.Resources
{
    [TagStructure(Name = "structure_bsp_tag_resources", Size = 0x18, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Name = "structure_bsp_tag_resources", Size = 0x30, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
    [TagStructure(Name = "structure_bsp_tag_resources", Size = 0x24, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Name = "structure_bsp_tag_resources", Size = 0x24, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "structure_bsp_tag_resources", Size = 0x30, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    public class StructureBspTagResources : TagStructure
    {
        public TagBlock<CollisionGeometry> CollisionBsps;

        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public TagBlock<LargeCollisionBspBlock> LargeCollisionBsps;

        public TagBlock<InstancedGeometryBlock> InstancedGeometry;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        public TagBlock<HavokDatum> HavokData;
    }
}