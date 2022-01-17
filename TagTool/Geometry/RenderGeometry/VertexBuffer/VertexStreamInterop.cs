using TagTool.Common;
using System.IO;

namespace TagTool.Geometry
{
    /// <summary>
    /// Vertex stream for using in and out of tagtool, uncompressed
    /// </summary>
    public class VertexStreamInterop : IVertexStream
    {
        private readonly VertexElementStream _stream;

        public VertexStreamInterop(Stream stream)
        {
            _stream = new VertexElementStream(stream);
        }

        public WorldVertex ReadWorldVertex()
        {
            return new WorldVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
            };
        }

        public void WriteWorldVertex(WorldVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
        }

        public RigidVertex ReadRigidVertex()
        {
            return new RigidVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
            };
        }

        public void WriteRigidVertex(RigidVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
        }

        public SkinnedVertex ReadSkinnedVertex()
        {
            return new SkinnedVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
                BlendIndices = _stream.ReadUByte4(),
                BlendWeights = _stream.ReadFloat4().ToArray(),
            };
        }

        public void WriteSkinnedVertex(SkinnedVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
            _stream.WriteUByte4(v.BlendIndices);
            _stream.WriteFloat4(new RealQuaternion(v.BlendWeights));
        }

        public ParticleModelVertex ReadParticleModelVertex()
        {
            return new ParticleModelVertex
            {
                Position = _stream.ReadFloat3(),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
            };
        }

        public void WriteParticleModelVertex(ParticleModelVertex v)
        {
            _stream.WriteFloat3(v.Position);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
        }

        public FlatWorldVertex ReadFlatWorldVertex()
        {
            return new FlatWorldVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
            };
        }

        public void WriteFlatWorldVertex(FlatWorldVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
        }

        public FlatRigidVertex ReadFlatRigidVertex()
        {
            return new FlatRigidVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
            };
        }

        public void WriteFlatRigidVertex(FlatRigidVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
        }

        public FlatSkinnedVertex ReadFlatSkinnedVertex()
        {
            return new FlatSkinnedVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
                BlendIndices = _stream.ReadUByte4(),
                BlendWeights = _stream.ReadFloat4().ToArray(),
            };
        }

        public void WriteFlatSkinnedVertex(FlatSkinnedVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
            _stream.WriteUByte4(v.BlendIndices);
            _stream.WriteFloat4(new RealQuaternion(v.BlendWeights));
        }

        public ScreenVertex ReadScreenVertex()
        {
            return new ScreenVertex
            {
                Position = _stream.ReadFloat2(),
                Texcoord = _stream.ReadFloat2(),
                Color = _stream.ReadColor(),
            };
        }

        public void WriteScreenVertex(ScreenVertex v)
        {
            _stream.WriteFloat2(v.Position);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteColor(v.Color);
        }

        public DebugVertex ReadDebugVertex()
        {
            return new DebugVertex
            {
                Position = _stream.ReadFloat3(),
                Color = _stream.ReadColor(),
            };
        }

        public void WriteDebugVertex(DebugVertex v)
        {
            _stream.WriteFloat3(v.Position);
            _stream.WriteColor(v.Color);
        }

        public TransparentVertex ReadTransparentVertex()
        {
            return new TransparentVertex
            {
                Position = _stream.ReadFloat3(),
                Texcoord = _stream.ReadFloat2(),
                Color = _stream.ReadColor(),
            };
        }

        public void WriteTransparentVertex(TransparentVertex v)
        {
            _stream.WriteFloat3(v.Position);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteColor(v.Color);
        }

        public ParticleVertex ReadParticleVertex()
        {
            return new ParticleVertex
            {
            };
        }

        public void WriteParticleVertex(ParticleVertex v)
        {
        }

        public ContrailVertex ReadContrailVertex()
        {
            return new ContrailVertex
            {
                Position = _stream.ReadFloat4(),
                Position2 = _stream.ReadFloat16_4(),
                Position3 = _stream.ReadShort4N(),
                Texcoord = _stream.ReadFloat16_4(),
                Texcoord2 = _stream.ReadShort4N(),
                Texcoord3 = _stream.ReadFloat16_2(),
                Color = _stream.ReadColor(),
                Color2 = _stream.ReadColor(),
                Position4 = _stream.ReadFloat4(),
            };
        }

        public void WriteContrailVertex(ContrailVertex v)
        {
            _stream.WriteFloat4(v.Position);
            _stream.WriteFloat16_4(v.Position2);
            _stream.WriteShort4N(v.Position3);
            _stream.WriteFloat16_4(v.Texcoord);
            _stream.WriteShort4N(v.Texcoord2);
            _stream.WriteFloat16_2(v.Texcoord3);
            _stream.WriteColor(v.Color);
            _stream.WriteColor(v.Color2);
            _stream.WriteFloat4(v.Position4);
        }

        public LightVolumeVertex ReadLightVolumeVertex()
        {
            return new LightVolumeVertex
            {
                Texcoord = _stream.ReadShort2(),
            };
        }

        public void WriteLightVolumeVertex(LightVolumeVertex v)
        {
            _stream.WriteShort2(v.Texcoord);
        }

        public ChudVertexSimple ReadChudVertexSimple()
        {
            return new ChudVertexSimple
            {
                Position = _stream.ReadFloat2(),
                Texcoord = _stream.ReadFloat2(),
            };
        }

        public void WriteChudVertexSimple(ChudVertexSimple v)
        {
            _stream.WriteFloat2(v.Position);
            _stream.WriteFloat2(v.Texcoord);
        }

        public ChudVertexFancy ReadChudVertexFancy()
        {
            return new ChudVertexFancy
            {
                Position = _stream.ReadFloat3(),
                Color = _stream.ReadColor(),
                Texcoord = _stream.ReadFloat2(),
            };
        }

        public void WriteChudVertexFancy(ChudVertexFancy v)
        {
            _stream.WriteFloat3(v.Position);
            _stream.WriteColor(v.Color);
            _stream.WriteFloat2(v.Texcoord);
        }

        public DecoratorVertex ReadDecoratorVertex()
        {
            return new DecoratorVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = new RealQuaternion(_stream.ReadFloat3(), 0),
                /*Texcoord2 = _stream.ReadShort4(),
                Texcoord3 = _stream.ReadUByte4N(),
                Texcoord4 = _stream.ReadUByte4N(),*/
            };
        }

        public void WriteDecoratorVertex(DecoratorVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal.IJK);
            /*_stream.WriteShort4(v.Texcoord2);
            _stream.WriteUByte4N(v.Texcoord3);
            _stream.WriteUByte4N(v.Texcoord4);*/
        }

        public TinyPositionVertex ReadTinyPositionVertex()
        {
            return new TinyPositionVertex
            {
                Position = _stream.ReadFloat3(),
                Variant = _stream.ReadUShort(),
                Normal = _stream.ReadFloat4(),
                Color = _stream.ReadColor()
            };
        }

        public void WriteTinyPositionVertex(TinyPositionVertex v)
        {
            _stream.WriteFloat3(v.Position);
            _stream.WriteUShort(v.Variant);
            _stream.WriteFloat4(v.Normal);
            _stream.WriteColor(v.Color);
        }

        public PatchyFogVertex ReadPatchyFogVertex()
        {
            return new PatchyFogVertex
            {
                Position = _stream.ReadFloat4(),
                Texcoord = _stream.ReadFloat2(),
            };
        }

        public void WritePatchyFogVertex(PatchyFogVertex v)
        {
            _stream.WriteFloat4(v.Position);
            _stream.WriteFloat2(v.Texcoord);
        }

        public WaterVertex ReadWaterVertex()
        {
            return new WaterVertex
            {
                Position = _stream.ReadFloat4(),
                Position2 = _stream.ReadFloat4(),
                Position3 = _stream.ReadFloat4(),
                Position4 = _stream.ReadFloat4(),
                Position5 = _stream.ReadFloat4(),
                Position6 = _stream.ReadFloat4(),
                Position7 = _stream.ReadFloat4(),
                Position8 = _stream.ReadFloat4(),
                Texcoord = _stream.ReadFloat4(),
                Texcoord2 = _stream.ReadFloat3(),
                Normal = _stream.ReadFloat4(),
                Normal2 = _stream.ReadFloat4(),
                Normal3 = _stream.ReadFloat4(),
                Normal4 = _stream.ReadFloat4(),
                Normal5 = _stream.ReadFloat2(),
                Texcoord3 = _stream.ReadFloat3(),
            };
        }

        public void WriteWaterVertex(WaterVertex v)
        {
            _stream.WriteFloat4(v.Position);
            _stream.WriteFloat4(v.Position2);
            _stream.WriteFloat4(v.Position3);
            _stream.WriteFloat4(v.Position4);
            _stream.WriteFloat4(v.Position5);
            _stream.WriteFloat4(v.Position6);
            _stream.WriteFloat4(v.Position7);
            _stream.WriteFloat4(v.Position8);
            _stream.WriteFloat4(v.Texcoord);
            _stream.WriteFloat3(v.Texcoord2);
            _stream.WriteFloat4(v.Normal);
            _stream.WriteFloat4(v.Normal2);
            _stream.WriteFloat4(v.Normal3);
            _stream.WriteFloat4(v.Normal4);
            _stream.WriteFloat2(v.Normal5);
            _stream.WriteFloat3(v.Texcoord3);
        }

        public RippleVertex ReadRippleVertex()
        {
            return new RippleVertex
            {
                Position = _stream.ReadFloat4(),
                Texcoord = _stream.ReadFloat4(),
                Texcoord2 = _stream.ReadFloat4(),
                Texcoord3 = _stream.ReadFloat4(),
                Texcoord4 = _stream.ReadFloat4(),
                Texcoord5 = _stream.ReadFloat4(),
                Color = _stream.ReadFloat4(),
                Color2 = _stream.ReadFloat4(),
                Texcoord6 = _stream.ReadShort2(),
            };
        }

        public void WriteRippleVertex(RippleVertex v)
        {
            _stream.WriteFloat4(v.Position);
            _stream.WriteFloat4(v.Texcoord);
            _stream.WriteFloat4(v.Texcoord2);
            _stream.WriteFloat4(v.Texcoord3);
            _stream.WriteFloat4(v.Texcoord4);
            _stream.WriteFloat4(v.Texcoord5);
            _stream.WriteFloat4(v.Color);
            _stream.WriteFloat4(v.Color2);
            _stream.WriteShort2(v.Texcoord6);
        }

        public ImplicitVertex ReadImplicitVertex()
        {
            return new ImplicitVertex
            {
                Position = _stream.ReadFloat3(),
                Texcoord = _stream.ReadFloat2(),
            };
        }

        public void WriteImplicitVertex(ImplicitVertex v)
        {
            _stream.WriteFloat3(v.Position);
            _stream.WriteFloat2(v.Texcoord);
        }

        public BeamVertex ReadBeamVertex()
        {
            return new BeamVertex
            {
                Position = _stream.ReadFloat4(),
                Texcoord = _stream.ReadShort4N(),
                Texcoord2 = _stream.ReadFloat16_4(),
                Color = _stream.ReadColor(),
                Position2 = _stream.ReadFloat3(),
                Texcoord3 = _stream.ReadShort2(),
            };
        }

        public void WriteBeamVertex(BeamVertex v)
        {
            _stream.WriteFloat4(v.Position);
            _stream.WriteShort4N(v.Texcoord);
            _stream.WriteFloat16_4(v.Texcoord2);
            _stream.WriteColor(v.Color);
            _stream.WriteFloat3(v.Position2);
            _stream.WriteShort2(v.Texcoord3);
        }

        public DualQuatVertex ReadDualQuatVertex()
        {
            return new DualQuatVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Normal = _stream.ReadFloat3(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
                BlendIndices = _stream.ReadUByte4(),
                BlendWeights = _stream.ReadUByte4N().ToArray(),
            };
        }

        public void WriteDualQuatVertex(DualQuatVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Normal);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
            _stream.WriteUByte4(v.BlendIndices);
            _stream.WriteUByte4N(new RealQuaternion(v.BlendWeights));
        }

        public StaticPerVertexColorData ReadStaticPerVertexColorData()
        {
            return new StaticPerVertexColorData
            {
                Color = _stream.ReadFloat3(),
            };
        }

        public void WriteStaticPerVertexColorData(StaticPerVertexColorData v)
        {
            _stream.WriteFloat3(v.Color);
        }

        public StaticPerPixelData ReadStaticPerPixelData()
        {
            return new StaticPerPixelData
            {
                // Texcoord = _stream.ReadFloat1(),
                Texcoord = _stream.ReadFloat2()
            };
        }

        public void WriteStaticPerPixelData(StaticPerPixelData v)
        {
            // _stream.WriteFloat1(v.Texcoord);
            _stream.WriteFloat2(v.Texcoord);
        }

        public StaticPerVertexData ReadStaticPerVertexData()
        {
            return new StaticPerVertexData
            {
                Color1 = _stream.ReadColor(),
                Color2 = _stream.ReadColor(),
                Color3 = _stream.ReadColor(),
                Color4 = _stream.ReadColor(),
                Color5 = _stream.ReadColor()
            };
        }

        public void WriteStaticPerVertexData(StaticPerVertexData v)
        {
            _stream.WriteColor(v.Color1);
            _stream.WriteColor(v.Color2);
            _stream.WriteColor(v.Color3);
            _stream.WriteColor(v.Color4);
            _stream.WriteColor(v.Color5);
        }

        public AmbientPrtData ReadAmbientPrtData()
        {
            return new AmbientPrtData
            {
                SHCoefficient = _stream.ReadFloat1()
            };
        }

        public void WriteAmbientPrtData(AmbientPrtData v)
        {
            _stream.WriteFloat1(v.SHCoefficient);
        }

        public LinearPrtData ReadLinearPrtData()
        {
            return new LinearPrtData
            {
                SHCoefficients = _stream.ReadFloat4(),
            };
        }

        public void WriteLinearPrtData(LinearPrtData v)
        {
            _stream.WriteFloat4(v.SHCoefficients);
        }

        public QuadraticPrtData ReadQuadraticPrtData()
        {
            return new QuadraticPrtData
            {
                SHCoefficients1 = _stream.ReadFloat3(),
                SHCoefficients2 = _stream.ReadFloat3(),
                SHCoefficients3 = _stream.ReadFloat3(),
            };
        }

        public void WriteQuadraticPrtData(QuadraticPrtData v)
        {
            _stream.WriteFloat3(v.SHCoefficients1);
            _stream.WriteFloat3(v.SHCoefficients2);
            _stream.WriteFloat3(v.SHCoefficients3);
        }

        public WaterTriangleIndices ReadWaterTriangleIndices()
        {
            var buffer = _stream.ReadUShort6();
            ushort[] vertices = new ushort[3];
            ushort[] indices = new ushort[3];

            for (int i = 0; i < 3; i++)
            {
                vertices[i] = buffer[2 * i];
                indices[i] = buffer[2 * i + 1];
            }
            return new WaterTriangleIndices
            {
                MeshIndices = vertices,
                WaterIndices = indices
            };
        }

        public void WriteWaterTriangleIndices(WaterTriangleIndices v)
        {
            for (int i = 0; i < 3; i += 2)
            {
                _stream.WriteUShort(v.MeshIndices[i]);
                _stream.WriteUShort(v.WaterIndices[i]);
            }
        }

        public WaterTesselatedParameters ReadWaterTesselatedParameters()
        {
            return new WaterTesselatedParameters
            {
                LocalInfo = _stream.ReadFloat2(),
                LocalInfoPadd = _stream.ReadFloat1(),
                BaseTex = _stream.ReadFloat2(),
                BaseTexPadd = _stream.ReadFloat1(),
            };
        }

        public void WriteWaterTesselatedParameters(WaterTesselatedParameters v)
        {
            _stream.WriteFloat2(v.LocalInfo);
            _stream.WriteFloat1(v.LocalInfoPadd);
            _stream.WriteFloat2(v.BaseTex);
            _stream.WriteFloat1(v.BaseTexPadd);
        }

        //TODO The last 2 float in WorldWaterVertex are unknown

        public WorldWaterVertex ReadWorldWaterVertex()
        {
            return new WorldWaterVertex
            {
                Position = new RealQuaternion(_stream.ReadFloat3(), 0),
                Texcoord = _stream.ReadFloat2(),
                Tangent = new RealQuaternion(_stream.ReadFloat3(), 0),
                Binormal = _stream.ReadFloat3(),
                Normal = new RealVector3d(0, 0, 1)
            };
        }

        public void WriteWorldWaterVertex(WorldWaterVertex v)
        {
            _stream.WriteFloat3(v.Position.IJK);
            _stream.WriteFloat2(v.Texcoord);
            _stream.WriteFloat3(v.Tangent.IJK);
            _stream.WriteFloat3(v.Binormal);
            //Temporary hack to have the right size I have no idea what these 2 values are
            _stream.WriteFloat2(new RealVector2d(1, 1));
        }

        public int GetVertexSize(VertexBufferFormat type)
        {
            switch (type)
            {
                case VertexBufferFormat.AmbientPrt:
                    return 0x4;
                case VertexBufferFormat.LinearPrt:
                    return 0x10;
                case VertexBufferFormat.QuadraticPrt:
                    return 0x24;
                case VertexBufferFormat.Decorator:
                    return 0x20;
                case VertexBufferFormat.ParticleModel:
                    return 0x20;
                case VertexBufferFormat.Rigid:
                    return 0x38;
                case VertexBufferFormat.Skinned:
                    return 0x4C;
                case VertexBufferFormat.StaticPerPixel:
                    return 0x8;
                case VertexBufferFormat.StaticPerVertex:
                    return 0x14;
                case VertexBufferFormat.StaticPerVertexColor:
                    return 0xC;
                case VertexBufferFormat.TinyPosition:
                    return 0x10;
                case VertexBufferFormat.World:
                case VertexBufferFormat.World2:
                    return 0x38;
                case VertexBufferFormat.WaterTriangleIndices:
                    return 0xC;
                case VertexBufferFormat.TesselatedWaterParameters:
                    return 0x18;
                default:
                    return -1;
            }
        }

    }
}
