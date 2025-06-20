using TagTool.Cache;
using TagTool.Common;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x164, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x1364, MinVersion = CacheVersion.HaloReach)]
    public class BlfScreenshotCamera : BlfChunkHeader
    {
        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public uint BufferSize;
        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public SavedCamera Camera;
        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public uint GameTick;
        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public uint FilmTick;

        // TODO: Figure out what this is :/
        [TagField(Length = 0x1364, MinVersion = CacheVersion.HaloReach)]
        public byte[] ReachData;

        [TagStructure(Size = 0x158)]
        public class SavedCamera : TagStructure 
        {
            public RenderCamera Camera;
            public RealRectangle2d FrustumBounds;
            public RenderProjection Projection;

            [TagStructure(Size = 0x88)]
            public class RenderCamera : TagStructure 
            {
                public RealPoint3d Position;
                public RealVector3d Forward;
                public RealVector3d Up;
                public bool Mirrored;

                [TagField(Length = 0x3)]
                public byte[] Padding1;

                public float VerticalFieldOfView;
                public float FieldOfViewScale;
                public Rectangle2d WindowPixelBounds;
                public Rectangle2d WindowTitleSafePixelBounds;
                public Point2d WindowFinalLocation;
                public Rectangle2d RenderPixelBounds;
                public Rectangle2d RenderTitleSafePixelBounds;
                public Rectangle2d DisplayPixelBounds;
                public float ZNear;
                public float ZFar;
                public RealPlane3d MirrorPlane;
                public bool EnlargedView;

                [TagField(Length = 0x3)]
                public byte[] Padding2;

                public RealPoint2d EnlargeCenter;
                public float EnlargeSizeX;
                public float EnlargeSizeY;
            }

            [TagStructure(Size = 0xC0)]
            public class RenderProjection : TagStructure 
            {
                public float WorldToViewScale;
                public RealMatrix4x3 WorldToView;
                public float ViewToWorldScale;
                public RealMatrix4x3 ViewToWorld;
                public RealRectangle2d ProjectionBounds;
                public RealMatrix4x4 ProjectionMatrix;
                public RealVector2d WorldToScreenSize;
            }
        }

        public static BlfScreenshotCamera Decode(TagDeserializer deserializer, DataSerializationContext dataContext)
        {
            return deserializer.Deserialize<BlfScreenshotCamera>(dataContext);
        }

        public static void Encode(TagSerializer serializer, DataSerializationContext dataContext, BlfScreenshotCamera scenario)
        {
            serializer.Serialize(dataContext, scenario);
        }
    }
}
