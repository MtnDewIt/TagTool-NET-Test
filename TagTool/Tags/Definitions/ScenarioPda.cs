using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "scenario_pda", Tag = "spda", Size = 0xC, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
    public class ScenarioPDA
    {
        public List<PDADefinition> PDADefinitions;
    }

    [TagStructure(Size = 0xC0)]
    public class PDADefinition
    {
        public StringId Name;
        public List<PDARenderModel> RenderModels;
        public List<PDARenderModelColor> PDARenderModelColors;
        public CachedTag PDAValidMovementMap;
        public CachedTag PDAHeightMap;
        public Bounds<float> PDAHeight;
        public float FalloffRadius;
        public RealPoint2d InitialPosition;
        public RealPoint3d MinimumWorldPosition;
        public RealPoint3d MaximumWorldPosition;
        public RealPoint3d MinimumCameraOffset;
        public RealPoint3d MinimumCameraFocalOffset;
        public RealPoint3d MaximumCameraOffset;
        public RealPoint3d MaximumCameraFocalOffset;
        public float InitialZoom;
        public float ZoomSpeed;

        public float MovementSpeed;
        public RealEulerAngles2d InitialRotation;
        public RealEulerAngles2d MinimumRotation;
        public RealEulerAngles2d MaximumRotation;
        public Angle RotationSpeed;
    }

    [TagStructure(Size = 0x1C)]
    public class PDARenderModel
    {
        public CachedTag RenderModel;
        public short ModelColorIndex;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x2)]
        public byte[] Padding0;

        public RealPoint2d Scale;
    }

    [TagStructure(Size = 0x10)]
    public class PDARenderModelColor
    {
        public RealRgbColor Color;
        public float Intensity;
    }
}