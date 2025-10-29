namespace TagTool.Geometry
{
    public interface IVertexStream
    {
        int GetVertexSize(VertexBufferFormat type);

        WorldVertex ReadWorldVertex();
        void WriteWorldVertex(in WorldVertex v);
        RigidVertex ReadRigidVertex();
        void WriteRigidVertex(in RigidVertex v);
        SkinnedVertex ReadSkinnedVertex();
        void WriteSkinnedVertex(in SkinnedVertex v);
        ParticleModelVertex ReadParticleModelVertex();
        void WriteParticleModelVertex(in ParticleModelVertex v);
        FlatWorldVertex ReadFlatWorldVertex();
        void WriteFlatWorldVertex(in FlatWorldVertex v);
        FlatRigidVertex ReadFlatRigidVertex();
        void WriteFlatRigidVertex(in FlatRigidVertex v);
        FlatSkinnedVertex ReadFlatSkinnedVertex();
        void WriteFlatSkinnedVertex(in FlatSkinnedVertex v);
        ScreenVertex ReadScreenVertex();
        void WriteScreenVertex(in ScreenVertex v);
        DebugVertex ReadDebugVertex();
        void WriteDebugVertex(in DebugVertex v);
        TransparentVertex ReadTransparentVertex();
        void WriteTransparentVertex(in TransparentVertex v);
        ParticleVertex ReadParticleVertex();
        void WriteParticleVertex(in ParticleVertex v);
        ContrailVertex ReadContrailVertex();
        void WriteContrailVertex(in ContrailVertex v);
        LightVolumeVertex ReadLightVolumeVertex();
        void WriteLightVolumeVertex(in LightVolumeVertex v);
        ChudVertexSimple ReadChudVertexSimple();
        void WriteChudVertexSimple(in ChudVertexSimple v);
        ChudVertexFancy ReadChudVertexFancy();
        void WriteChudVertexFancy(in ChudVertexFancy v);
        DecoratorVertex ReadDecoratorVertex();
        void WriteDecoratorVertex(in DecoratorVertex v);
        TinyPositionVertex ReadTinyPositionVertex();
        void WriteTinyPositionVertex(in TinyPositionVertex v);
        PatchyFogVertex ReadPatchyFogVertex();
        void WritePatchyFogVertex(in PatchyFogVertex v);
        WaterVertex ReadWaterVertex();
        void WriteWaterVertex(in WaterVertex v);
        RippleVertex ReadRippleVertex();
        void WriteRippleVertex(in RippleVertex v);
        ImplicitVertex ReadImplicitVertex();
        void WriteImplicitVertex(in ImplicitVertex v);
        BeamVertex ReadBeamVertex();
        void WriteBeamVertex(in BeamVertex v);
        DualQuatVertex ReadDualQuatVertex();
        void WriteDualQuatVertex(in DualQuatVertex v);
        StaticPerVertexColorData ReadStaticPerVertexColorData();
        void WriteStaticPerVertexColorData(in StaticPerVertexColorData v);
        StaticPerPixelData ReadStaticPerPixelData();
        void WriteStaticPerPixelData(in StaticPerPixelData v);
        StaticPerVertexData ReadStaticPerVertexData();
        void WriteStaticPerVertexData(in StaticPerVertexData v);
        AmbientPrtData ReadAmbientPrtData();
        void WriteAmbientPrtData(in AmbientPrtData v);
        LinearPrtData ReadLinearPrtData();
        void WriteLinearPrtData(in LinearPrtData v);
        QuadraticPrtData ReadQuadraticPrtData();
        void WriteQuadraticPrtData(in QuadraticPrtData v);
        WaterTriangleIndices ReadWaterTriangleIndices();
        void WriteWaterTriangleIndices(in WaterTriangleIndices v);
        WaterTesselatedParameters ReadWaterTesselatedParameters();
        void WriteWaterTesselatedParameters(in WaterTesselatedParameters v);
        WorldWaterVertex ReadWorldWaterVertex();
        void WriteWorldWaterVertex(in WorldWaterVertex v);
    }
}
