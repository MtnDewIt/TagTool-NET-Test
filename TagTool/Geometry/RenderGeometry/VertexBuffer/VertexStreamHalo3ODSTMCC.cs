﻿using System;
using System.IO;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.Geometry
{
    public class VertexStreamHalo3ODSTMCC : IVertexStream
    {
        private VertexElementStream Stream { get; }

        public VertexStreamHalo3ODSTMCC(Stream stream)
        {
            Stream = new VertexElementStream(stream, EndianFormat.LittleEndian);
        }

        public AmbientPrtData ReadAmbientPrtData()
        {
            return new AmbientPrtData
            {
                SHCoefficient = Stream.ReadFloat1()
            };
        }

        public BeamVertex ReadBeamVertex()
        {
            throw new NotImplementedException();
        }

        public ChudVertexFancy ReadChudVertexFancy()
        {
            return new ChudVertexFancy
            {
                Position = Stream.ReadFloat3(),
                Color = Stream.ReadColor(),
                Texcoord = Stream.ReadFloat2()
            };
        }

        public ChudVertexSimple ReadChudVertexSimple()
        {
            return new ChudVertexSimple
            {
                Position = Stream.ReadFloat2(),
                Texcoord = Stream.ReadFloat2()
            };
        }

        public ContrailVertex ReadContrailVertex()
        {
            throw new NotImplementedException();
        }

        public DebugVertex ReadDebugVertex()
        {
            return new DebugVertex
            {
                Position = Stream.ReadFloat3(),
                Color = Stream.ReadColor()
            };
        }

        public DecoratorVertex ReadDecoratorVertex()
        {
            var vertex = new DecoratorVertex
            {
                Position = Stream.ReadUShort4N(),
                Texcoord = Stream.ReadUShort2N(),
                Normal = Stream.ReadUShort4N()
            };
            return vertex;
        }

        public DualQuatVertex ReadDualQuatVertex()
        {
            throw new NotImplementedException();
        }

        public FlatRigidVertex ReadFlatRigidVertex()
        {
            return new FlatRigidVertex
            {
                Position = Stream.ReadUShort4N(),
                Texcoord = Stream.ReadUShort2N(),
                Normal = Stream.ReadShort4N().IJK,
                Tangent = new RealQuaternion(Stream.ReadShort4N().IJK, 1.0f),
                Binormal = Stream.ReadShort4N().IJK
            };
        }

        public FlatSkinnedVertex ReadFlatSkinnedVertex()
        {
            return new FlatSkinnedVertex
            {
                Position = Stream.ReadUShort4N(),
                Texcoord = Stream.ReadUShort2N(),
                Normal = Stream.ReadShort4N().IJK,
                Tangent = new RealQuaternion(Stream.ReadShort4N().IJK, 1.0f),
                Binormal = Stream.ReadShort4N().IJK,
                BlendIndices = Stream.ReadUByte4(),
                BlendWeights = Stream.ReadUByte4N().ToArray()
            };
        }

        public FlatWorldVertex ReadFlatWorldVertex()
        {
            return new FlatWorldVertex
            {
                Position = new RealQuaternion(Stream.ReadFloat3(), 0.0f),
                Texcoord = Stream.ReadFloat2(),
                Normal = Stream.ReadUShort4N().IJK,
                Tangent = new RealQuaternion(Stream.ReadUShort4N().IJK, 1.0f),
                Binormal = Stream.ReadUShort4N().IJK
            };
        }

        public ImplicitVertex ReadImplicitVertex()
        {
            return new ImplicitVertex
            {
                Position = Stream.ReadFloat3(),
                Texcoord = Stream.ReadFloat2()
            };
        }

        public LightVolumeVertex ReadLightVolumeVertex()
        {
            throw new NotImplementedException();
        }

        public LinearPrtData ReadLinearPrtData()
        {
            return new LinearPrtData
            {
                SHCoefficients = ReadTinyNormal()
            };
        }

        public ParticleModelVertex ReadParticleModelVertex()
        {
            return new ParticleModelVertex
            {
                Position = Stream.ReadFloat3(),
                Texcoord = Stream.ReadFloat2(),
                Normal = Stream.ReadFloat3(),
            };
        }

        public ParticleVertex ReadParticleVertex()
        {
            throw new NotImplementedException();
        }

        public PatchyFogVertex ReadPatchyFogVertex()
        {
            return new PatchyFogVertex
            {
                Position = Stream.ReadFloat4(),
                Texcoord = Stream.ReadFloat2()
            };
        }

        public QuadraticPrtData ReadQuadraticPrtData()
        {
            return new QuadraticPrtData
            {
                SHCoefficients1 = Stream.ReadShort4N().IJK,
                SHCoefficients2 = Stream.ReadShort4N().IJK,
                SHCoefficients3 = Stream.ReadShort4N().IJK
            };
        }
  
        public RigidVertex ReadRigidVertex()
        {
            var vertex = new RigidVertex
            {
                Position = Stream.ReadUShort4N(),
                Texcoord = Stream.ReadUShort2N(),
                Normal = Stream.ReadUShort4N().IJK,
                Tangent = new RealQuaternion(Stream.ReadUShort4N().IJK, 0.0f),
                Binormal = Stream.ReadUShort4N().IJK
            };
            return vertex;
        }

        public RippleVertex ReadRippleVertex()
        {
            return new RippleVertex
            {
                Position = Stream.ReadFloat4(),
                Texcoord = Stream.ReadFloat4(),
                Texcoord2 = Stream.ReadFloat4(),
                Texcoord3 = Stream.ReadFloat4(),
                Texcoord4 = Stream.ReadFloat4(),
                Texcoord5 = Stream.ReadFloat4(),
                Color = Stream.ReadFloat4(),
                Color2 = Stream.ReadFloat4(),
                Texcoord6 = new short[] { 0, 0 }
            };
        }

        public ScreenVertex ReadScreenVertex()
        {
            return new ScreenVertex
            {
                Position = Stream.ReadFloat2(),
                Texcoord = Stream.ReadFloat2(),
                Color = Stream.ReadColor()
            };
        }

        public SkinnedVertex ReadSkinnedVertex()
        {
            return new SkinnedVertex
            {
                Position = Stream.ReadUShort4N(),
                Texcoord = Stream.ReadUShort2N(),
                Normal = Stream.ReadUShort4N().IJK,
                Tangent = Stream.ReadUShort4N(),
                Binormal = Stream.ReadUShort4N().IJK,
                BlendIndices = Stream.ReadUByte4(),
                BlendWeights = Stream.ReadUByte4N().ToArray()
            };
        }

        public StaticPerPixelData ReadStaticPerPixelData()
        {
            return new StaticPerPixelData
            {
                Texcoord = Stream.ReadUShort2N()
            };
        }

        public StaticPerVertexColorData ReadStaticPerVertexColorData()
        {
            return new StaticPerVertexColorData
            {
                Color = Stream.ReadFloat3(),
            };
        }

        public StaticPerVertexData ReadStaticPerVertexData()
        {
            return new StaticPerVertexData
            {
                Color1 = Stream.ReadColor(),
                Color2 = Stream.ReadColor(),
                Color3 = Stream.ReadColor(),
                Color4 = Stream.ReadColor(),
                Color5 = Stream.ReadColor()
            };
        }

        private RealQuaternion ReadTinyNormal()
        {
            var normal = Stream.ReadSByte4N();

            return new RealQuaternion(normal.W, normal.K, normal.J, normal.I);
        }

        public TinyPositionVertex ReadTinyPositionVertex()
        {
            return new TinyPositionVertex
            {
                Position = Stream.ReadUShort3N(),
                // most likely wrong given what the converter is doing
                Variant = Stream.ReadUShort(), 
                Normal = ReadTinyNormal(),
                Color = Stream.ReadColor()
            };
        }

        public TransparentVertex ReadTransparentVertex()
        {
            return new TransparentVertex
            {
                Position = Stream.ReadFloat3(),
                Texcoord = Stream.ReadFloat2(),
                Color = Stream.ReadColor()
            };
        }

        public WaterVertex ReadWaterVertex()
        {
            return new WaterVertex()
            {
                Position = Stream.ReadFloat4(),
                Position2 = Stream.ReadFloat4(),
                Position3 = Stream.ReadFloat4(),
                Position4 = Stream.ReadFloat4(),
                Position5 = Stream.ReadFloat4(),
                Position6 = Stream.ReadFloat4(),
                Position7 = Stream.ReadFloat4(),
                Position8 = Stream.ReadFloat4(),
                Texcoord = new RealQuaternion(Stream.ReadFloat3(), 0),
                Texcoord2 = Stream.ReadFloat3(),
                Normal = Stream.ReadFloat4(),
                Normal2 = Stream.ReadFloat4(),
                Normal3 = Stream.ReadFloat4(),
                Normal4 = Stream.ReadFloat4(),
                Normal5 = Stream.ReadFloat2(),
                Texcoord3 = Stream.ReadFloat3()
            };
        }

        public WorldVertex ReadWorldVertex()
        {
            return new WorldVertex
            {
                Position = new RealQuaternion(Stream.ReadFloat3(), 0.0f),
                Texcoord = Stream.ReadFloat2(),
                Normal = Stream.ReadUShort4N().IJK,
                Tangent = Stream.ReadUShort4N(),
                Binormal = Stream.ReadUShort4N().IJK
            };
        }

        public void WriteAmbientPrtData(in AmbientPrtData v)
        {
            throw new NotImplementedException();
        }

        public void WriteBeamVertex(in BeamVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteChudVertexFancy(in ChudVertexFancy v)
        {
            throw new NotImplementedException();
        }

        public void WriteChudVertexSimple(in ChudVertexSimple v)
        {
            throw new NotImplementedException();
        }

        public void WriteContrailVertex(in ContrailVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteDebugVertex(in DebugVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteDecoratorVertex(in DecoratorVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteDualQuatVertex(in DualQuatVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteFlatRigidVertex(in FlatRigidVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteFlatSkinnedVertex(in FlatSkinnedVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteFlatWorldVertex(in FlatWorldVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteImplicitVertex(in ImplicitVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteLightVolumeVertex(in LightVolumeVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteLinearPrtData(in LinearPrtData v)
        {
            throw new NotImplementedException();
        }

        public void WriteParticleModelVertex(in ParticleModelVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteParticleVertex(in ParticleVertex v)
        {
            throw new NotImplementedException();
        }

        public void WritePatchyFogVertex(in PatchyFogVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteQuadraticPrtData(in QuadraticPrtData v)
        {
            throw new NotImplementedException();
        }

        public void WriteRigidVertex(in RigidVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteRippleVertex(in RippleVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteScreenVertex(in ScreenVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteSkinnedVertex(in SkinnedVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteStaticPerPixelData(in StaticPerPixelData v)
        {
            throw new NotImplementedException();
        }

        public void WriteStaticPerVertexColorData(in StaticPerVertexColorData v)
        {
            throw new NotImplementedException();
        }

        public void WriteStaticPerVertexData(in StaticPerVertexData v)
        {
            throw new NotImplementedException();
        }

        public void WriteTinyPositionVertex(in TinyPositionVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteTransparentVertex(in TransparentVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteWaterVertex(in WaterVertex v)
        {
            throw new NotImplementedException();
        }

        public void WriteWorldVertex(in WorldVertex v)
        {
            throw new NotImplementedException();
        }

        public WaterTriangleIndices ReadWaterTriangleIndices()
        {
            var buffer = Stream.ReadUShort6();
            ushort[] vertices = new ushort[3];
            ushort[] indices = new ushort[3];

            for(int i = 0; i<3; i++)
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

        public void WriteWaterTriangleIndices(in WaterTriangleIndices v)
        {
            throw new NotImplementedException();
        }

        public WaterTesselatedParameters ReadWaterTesselatedParameters()
        {
            return new WaterTesselatedParameters
            {
                LocalInfo = Stream.ReadFloat2(),
                LocalInfoPadd = Stream.ReadFloat4().I,
                BaseTex = Stream.ReadFloat2(),
                BaseTexPadd = Stream.ReadFloat1(),
            };
        }

        public void WriteWaterTesselatedParameters(in WaterTesselatedParameters v)
        {
            throw new NotImplementedException();
        }

        public void WriteWorldWaterVertex(in WorldWaterVertex v)
        {
            throw new NotImplementedException();
        }

        public WorldWaterVertex ReadWorldWaterVertex()
        {
            throw new NotImplementedException();
        }

        public int GetVertexSize(VertexBufferFormat type)
        {
            switch (type)
            {
                case VertexBufferFormat.AmbientPrt:
                    return 0x4;
                case VertexBufferFormat.LinearPrt:
                    return 0x4;
                case VertexBufferFormat.QuadraticPrt:
                    return 0xC;
                case VertexBufferFormat.Decorator:
                    return 0x14;
                case VertexBufferFormat.ParticleModel:
                    return 0x20;
                case VertexBufferFormat.Rigid:
                    return 0x24;
                case VertexBufferFormat.Skinned:
                    return 0x2C;
                case VertexBufferFormat.StaticPerPixel:
                    return 0x4;
                case VertexBufferFormat.StaticPerVertex:
                    return 0x14;
                case VertexBufferFormat.StaticPerVertexColor:
                    return 0xC;
                case VertexBufferFormat.TinyPosition:
                    return 0x8;
                case VertexBufferFormat.World:
                case VertexBufferFormat.World2:
                    return 0x2c;
                case VertexBufferFormat.WaterTriangleIndices:
                    return 0xC;
                case VertexBufferFormat.TesselatedWaterParameters:
                    return 0x24;
                default:
                    return -1;
            }
        }
    }
}
