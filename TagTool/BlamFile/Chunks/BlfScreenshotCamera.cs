using TagTool.Common;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks
{
    [TagStructure(Size = 0x164)]
    public class BlfScreenshotCamera : BlfChunkHeader
    {
        public uint BufferSize;
        public ScreenshotCamera Camera;
        public uint GameTick;
        public uint FilmTick;

        [TagStructure(Size = 0x158)]
        public class ScreenshotCamera : TagStructure 
        {
            public RenderCamera Camera;
            public Rectangle2d FrustumBounds;
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
                public RealMatrix4x3 WorldToView;
                public RealMatrix4x3 ViewToWorld;
                public Rectangle2d ProjectionBounds;
                public float[][] ProjectionMatrix; // RealMatrix4x4???
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
