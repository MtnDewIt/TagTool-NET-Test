using TagTool.Common;

namespace TagTool.Geometry
{
    public struct WorldVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public struct RigidVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public struct SkinnedVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public struct ParticleModelVertex
    {
        public RealVector3d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
    }

    public struct FlatWorldVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public struct FlatRigidVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public struct FlatSkinnedVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public struct ScreenVertex
    {
        public RealVector2d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public uint Color { get; set; }
    }

    public struct DebugVertex
    {
        public RealVector3d Position { get; set; }
        public uint Color { get; set; }
    }

    public struct TransparentVertex
    {
        public RealVector3d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public uint Color { get; set; }
    }

    public struct ParticleVertex
    {
        public RealVector2d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public struct ContrailVertex
    {
        public RealQuaternion Position { get; set; }
        public RealQuaternion Position2 { get; set; }
        public RealQuaternion Position3 { get; set; }
        public RealQuaternion Texcoord { get; set; }
        public RealQuaternion Texcoord2 { get; set; }
        public RealVector2d Texcoord3 { get; set; }
        public uint Color { get; set; }
        public uint Color2 { get; set; }
        public RealQuaternion Position4 { get; set; }
    }

    public struct LightVolumeVertex
    {
        public short[] Texcoord { get; set; }
    }

    public struct ChudVertexSimple
    {
        public RealVector2d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public struct ChudVertexFancy
    {
        public RealVector3d Position { get; set; }
        public uint Color { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public struct DecoratorVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealQuaternion Normal { get; set; }
    }

    public struct TinyPositionVertex
    {
        public RealVector3d Position { get; set; }
        public ushort Variant { get; set; } // type index (high 8 bits), motion scale (low 8 bits)
        public RealQuaternion Normal { get; set; }
        public uint Color { get; set; }
    }

    public struct PatchyFogVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public struct WaterVertex
    {
        public RealQuaternion Position { get; set; }
        public RealQuaternion Position2 { get; set; }
        public RealQuaternion Position3 { get; set; }
        public RealQuaternion Position4 { get; set; }
        public RealQuaternion Position5 { get; set; }
        public RealQuaternion Position6 { get; set; }
        public RealQuaternion Position7 { get; set; }
        public RealQuaternion Position8 { get; set; }
        public RealQuaternion Texcoord { get; set; }
        public RealVector3d Texcoord2 { get; set; }
        public RealQuaternion Normal { get; set; }
        public RealQuaternion Normal2 { get; set; }
        public RealQuaternion Normal3 { get; set; }
        public RealQuaternion Normal4 { get; set; }
        public RealVector2d Normal5 { get; set; }
        public RealVector3d Texcoord3 { get; set; }
    }

    public struct RippleVertex
    {
        public RealQuaternion Position { get; set; }
        public RealQuaternion Texcoord { get; set; }
        public RealQuaternion Texcoord2 { get; set; }
        public RealQuaternion Texcoord3 { get; set; }
        public RealQuaternion Texcoord4 { get; set; }
        public RealQuaternion Texcoord5 { get; set; }
        public RealQuaternion Color { get; set; }
        public RealQuaternion Color2 { get; set; }
        public short[] Texcoord6 { get; set; }
    }

    public struct ImplicitVertex
    {
        public RealVector3d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public struct BeamVertex
    {
        public RealQuaternion Position { get; set; }
        public RealQuaternion Texcoord { get; set; }
        public RealQuaternion Texcoord2 { get; set; }
        public uint Color { get; set; }
        public RealVector3d Position2 { get; set; }
        public short[] Texcoord3 { get; set; }
    }

    public struct DualQuatVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public struct StaticPerVertexColorData
    {
        public RealVector3d Color { get; set; }
    }

    public struct StaticPerPixelData
    {
        public RealVector2d Texcoord { get; set; }
    }

    /// <summary>
    /// Each color is some form of RGBE, engine converts it to rgb. Color 4,5 seem unused
    /// </summary>
    public struct StaticPerVertexData
    {
        public uint Color1 { get; set; }
        public uint Color2 { get; set; }
        public uint Color3 { get; set; }
        public uint Color4 { get; set; }
        public uint Color5 { get; set; }
    }

    public struct AmbientPrtData
    {
        public float SHCoefficient { get; set; }
    }

    public struct LinearPrtData
    {
        public RealQuaternion SHCoefficients { get; set; }
    }

    public struct QuadraticPrtData
    {
        public RealVector3d SHCoefficients1 { get; set; }
        public RealVector3d SHCoefficients2 { get; set; }
        public RealVector3d SHCoefficients3 { get; set; }
    }

    public struct WaterTriangleIndices
    {
        public ushort[] MeshIndices { get; set; }
        public ushort[] WaterIndices { get; set; }
    }

    public struct WaterTesselatedParameters
    {
        public RealVector2d LocalInfo { get; set; }
        public float LocalInfoPadd;
        public RealVector2d BaseTex { get; set; }
        public float BaseTexPadd;
    }

    public struct WorldWaterVertex
    {
        public RealQuaternion Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealQuaternion Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
        public RealVector2d StaticPerPixel;
    }
}
