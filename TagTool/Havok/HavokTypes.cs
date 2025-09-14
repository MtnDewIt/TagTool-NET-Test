﻿using TagTool.Common;
using TagTool.Tags;
using TagTool.Cache;

/*
 * Havok Structures required to deserialize tags and resources. Most havok structs are aligned at 0x10 which is why there is a lot of padding. 
 * Either the values in padding are 0 or 0xCD depending if they are in a tag or resource. The tag version of HkpMoppData has the flag DONT_DEALLOCATE_FLAG.
 */

namespace TagTool.Havok
{
    public static class HkArrayFlags
    {
        public static readonly uint CAPACITY_MASK = 0x3FFFFFFF;
        public static readonly uint FLAG_MASK = 0xC0000000;
        public static readonly uint DONT_DEALLOCATE_FLAG = 0x80000000; // Indicates that the storage is not the array's to delete
        public static readonly uint LOCKED_FLAG = 0x40000000;  // Indicates that the array will never have its dtor called (read in from packfile for instance)
    };

    public enum BlamShapeType : short
    {
        Sphere,
        Pill,
        Box,
        Triangle,
        Polyhedron,
        MultiSphere,
        TriangleMesh,
        CompoundShape,
        Unused0,
        Unused1,
        Unused2,
        Unused3,
        Unused4,
        Unused5,
        List,
        Mopp
    }

    [TagStructure(Size = 0x4, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x8, Platform = CachePlatform.MCC)]
    public class HavokShapeReference : TagStructure
    {
        // TOOD: consider endianess
        public BlamShapeType Type;
        public short Index;
        [TagField(Platform = CachePlatform.MCC)]
        public int RuntimeShapePointerPad;

        public HavokShapeReference() { }

        public HavokShapeReference(BlamShapeType type, short index)
        {
            Type = type;
            Index = index; 
        }
    }

    /// <summary>
    /// Tag variant of HkpMoppCode with the actual codes in a tag block
    /// </summary>
    [TagStructure(Size = 0x10, Align = 16, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x10, Align = 16, Platform = CachePlatform.MCC)]
    public class TagHkpMoppCode : HkpMoppCode
    {
        public TagBlock<byte> Data;
        public MoppBuildType BuildType;
        [TagField(Flags = TagFieldFlags.Padding, Length = 3)]
        public byte[] Padding2;

        public enum MoppBuildType : sbyte
        {
            BuiltWithChunkSubdivision,
            BuiltWithoutChunkSubdivision
        }
    }

    /// <summary>
    /// Mopp code structure used in byte[]'s
    /// </summary>
    [TagStructure(Size = 0x30, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x30, Platform = CachePlatform.MCC, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x50, Platform = CachePlatform.MCC, MaxVersion = CacheVersion.HaloReach)]
    public class HkpMoppCode : TagStructure
    {
        public PlatformUnsignedValue VfTableAddress;
        public HkpReferencedObject ReferencedObject;

        [TagField(Platform = CachePlatform.Original)]
        [TagField(Platform = CachePlatform.MCC, MinVersion = CacheVersion.HaloReach)]
        public PlatformUnsignedValue UserData;

        [TagField(Align = 16)]
        public CodeInfo Info;
        public HkArrayBase ArrayBase;

        [TagField(Length = 4, Platform = CachePlatform.Original)]
        [TagField(Length = 16, Platform = CachePlatform.MCC, MinVersion = CacheVersion.HaloReach)]
        public byte[] Padding1;
    }

    public enum BvTreeTypeValue : uint
    {
        Mopp,
        TrisampledHeightfield,
        User,
    };

    [TagStructure(Size = 0xC, Platform = CachePlatform.Original, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Size = 0x30, Platform = CachePlatform.Original, MinVersion = CacheVersion.HaloReach)]
    [TagStructure(Size = 0x18, Platform = CachePlatform.MCC, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x50, Platform = CachePlatform.MCC, MinVersion = CacheVersion.HaloReach)]
    public class HkpMoppBvTreeShape : HkpShape
    {
        [TagField(MaxVersion = CacheVersion.Eldorado700123)]
        public HkpSingleShapeContainer Child;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public BvTreeTypeValue TreeType;

        public PlatformUnsignedValue MoppCodeAddress;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public PlatformUnsignedValue MoppDataAddress;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int MoppDataSize;
        [TagField(Align = 16, MinVersion = CacheVersion.HaloReach)]
        public RealVector4d CodeInfoCopy;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public HkpSingleShapeContainer ChildReach;
        [TagField(Platform = CachePlatform.MCC, MinVersion = CacheVersion.HaloReach, Flags = TagFieldFlags.Padding, Length = 0x8)]
        public byte[] HkpMoppReachPadMCC;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int ChildSize;
        [TagField(MinVersion = CacheVersion.HaloReach, Flags = TagFieldFlags.Padding, Length = 0x4)]
        public byte[] HkpMoppReachPad;
    }

    [TagStructure(Size = 0x4, Platform = CachePlatform.Original, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Size = 0x8, Platform = CachePlatform.MCC, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x10, MinVersion = CacheVersion.HaloReach)]
    public class CMoppBvTreeShape : HkpMoppBvTreeShape
    {
        public float Scale;

        [TagField(Flags = TagFieldFlags.Padding, Length = 0x4, Platform = CachePlatform.MCC, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
        [TagField(Flags = TagFieldFlags.Padding, Length = 0xC, MinVersion = CacheVersion.HaloReach)]
        public byte[] CMoppPad;
    }

    [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.Halo2PC, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x20, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
    public class HkpShape : TagStructure
    {
        public PlatformUnsignedValue VfTableAddress;
        public HkpReferencedObject ReferencedObject;
        public PlatformUnsignedValue UserDataAddress;
        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public uint Type;
        [TagField(Length = 4, Platform = CachePlatform.MCC, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;
    }

    /// <summary>
    /// At runtime this is a pointer
    /// </summary>
    [TagStructure(Size = 0x8, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x10, Platform = CachePlatform.MCC)]
    public class HkpSingleShapeContainer : TagStructure
    {
        public PlatformUnsignedValue VTableAddress;
        public HavokShapeReference Shape;
    }

    [TagStructure(Size = 0x8, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x10, Platform = CachePlatform.MCC)]
    public class HkpShapeCollection : HkpShape
    {
        public PlatformUnsignedValue VTableAddress;
        public bool DisableWelding;
        public sbyte CollectionType;
        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding3;
        [TagField(Length = 4, Flags = TagFieldFlags.Padding, Platform = CachePlatform.MCC)]
        public byte[] Padding4;
    }

    [TagStructure(Size = 0xC, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x10, Platform = CachePlatform.MCC)]
    public class HkArrayBase : TagStructure
    {
        public PlatformUnsignedValue DataAddress;
        public uint Size;
        public uint CapacityAndFlags;

        public uint GetCapacity()
        {
            return CapacityAndFlags & HkArrayFlags.CAPACITY_MASK;
        }
    }

    [TagStructure(Size = 0x4)]
    public class HkpReferencedObject : TagStructure
    {
        public ushort SizeAndFlags;
        public ushort ReferenceCount = 128;
    }

    [TagStructure(Size = 0x10)]
    public class CodeInfo : TagStructure
    {
        [TagField(Align = 16)]
        public RealVector4d Offset; // actually vector4
    }   

    [TagStructure(Size = 0x90, Align = 0x10)]
    public class HkMultiSphereShape : HkpShape
    {
        public int NumSpheres;
        [TagField(Length = 8, Align = 0x10)]
        public RealVector4d[] Spheres;
    }

    [TagStructure(Size = 0x38, Align = 0x10, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x30, Align = 0x10, Platform = CachePlatform.MCC)]
    public class HkListShape : HkpShapeCollection
    {
        [TagField(Align = 0x4, Platform = CachePlatform.Original)]
        [TagField(Align = 0x8, Platform = CachePlatform.MCC)]
        public HkArrayBase ChildInfo;

        public RealVector4d AabbHalfExtents;
        public RealVector4d AabbCenter;
    }

    [TagStructure(Size = 0x14, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x28, Platform = CachePlatform.MCC)]
    public class HkConvexShape : TagStructure
    {
        public HkpShape Base;
        public float Radius;
    }

    [TagStructure(Size = 0x60, Align = 16, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x80, Align = 16, MaxVersion = CacheVersion.Eldorado700123, Platform = CachePlatform.MCC)]
    [TagStructure(Size = 0x70, Align = 16, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Size = 0x90, Align = 16, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class HkConvexVerticesShape : TagStructure
    {
        public HkConvexShape Base;
        [TagField(Align = 16)]
        public RealVector4d AabbHalfExtents;
        public RealVector4d AabbCenter;
        public HkArrayBase FourVectors;
        public int NumVertices;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public PlatformUnsignedValue ConvexPiecePtr;
        public HkArrayBase PlaneEquations;
        public PlatformUnsignedValue Connectivity;
    }
}

namespace TagTool.Havok.Gen2
{
    [TagStructure(Size = 0x4)]
    public class HkConvexWelderShape : HkpShape
    {
        public uint ShapeAddress;
    }

    [TagStructure(Size = 0x4)]
    public class HkSingleShapeContainer : TagStructure
    {
        public uint ShapeAddress;
    }

    [TagStructure(Size = 0x8)]
    public class HkMoppBvTreeShape : HkpShape
    {
        public HkSingleShapeContainer Child;
        public uint MoppCodeAddress;
    }

    [TagStructure]
    public class CMoppBvTreeShape : HkMoppBvTreeShape
    {
        
    }

    [TagStructure(Size = 0x30)]
    public class HkMoppCode
    {
        public RealVector4d Offset;
        public int ByteOrdering;
        [TagField(Length = 0xC, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;
        public HkpReferencedObject ReferencedObject;
        [TagField(Length = 0xC, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;
    }

    [TagStructure(Size = 4)]
    public class CConvexWelderShape : HkpShape
    {
        public uint ShapeAddress;
    }

    [TagStructure(Size = 0x30)]
    public class MoppCodeHeader : TagStructure
    {
        public RealVector4d Offset;
        public int Unknown1;
        public int Unknown2;
        public int Unknown3;
        public int Unknown4;
        public uint Size;
        public int Unknown6;
        public int Unknown7;
        public int Unknown8;
    }
}