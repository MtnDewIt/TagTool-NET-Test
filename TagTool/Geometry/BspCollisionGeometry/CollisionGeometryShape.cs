using TagTool.Cache;
using TagTool.Common;
using TagTool.Havok;
using TagTool.Tags;

namespace TagTool.Geometry.BspCollisionGeometry
{
    [TagStructure(Size = 0x38, Align = 0x10, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x48, Align = 0x10, MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x40, Align = 0x10, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x50, Align = 0x10, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class CollisionGeometryShape : HkpShapeCollection
    {
        [TagField(Align = 16)]
        public RealQuaternion AABB_Center;
        public RealQuaternion AABB_Half_Extents;
        [TagField(Flags = TagFieldFlags.Short)] 
        public CachedTag Model;
        public PlatformUnsignedValue CollisionBspAddress; // runtime
        [TagField(MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        public PlatformUnsignedValue LargeCollisionBspAddress; // runtime
        public sbyte BspIndex;
        public byte CollisionGeometryShapeType;
        public ushort CollisionGeometryShapeKey; // runtime
        public float Scale; // runtime

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x10, Platform = CachePlatform.MCC, MinVersion = CacheVersion.HaloReach)]
        public byte[] ReachMCCPad;
    }

    [TagStructure(Size = 0x28, MaxVersion = CacheVersion.Halo2Vista)]
    public class CollisionGeometryShapeGen2 : HkpShape
    {
        public uint CollisionBspAddress; // runtime
        public RealQuaternion AABB_Center;
        public RealQuaternion AABB_Half_Extents;
        [TagField(Flags = TagFieldFlags.Short)]
        public CachedTag Model;
    }
}
