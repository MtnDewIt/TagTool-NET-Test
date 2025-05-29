using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile
{
    [TagStructure(Align = 0x1)]
    public class BlfPackedMapVariant : BlfChunkHeader
    {
        public PackedContentItemMetadata Metadata;
        public short VariantVersion;
        public uint MapVariantChecksum;
        public short ScenarioObjectCount;
        public short VariantObjectCount;
        public short PlaceableQuotaCount;
        public int MapId = -1;
        public bool BuiltIn;
        public RealRectangle3d WorldBounds;
        public GameEngineSubType RuntimeEngineSubType = GameEngineSubType.All;
        public float MaximumBudget;
        public float SpentBudget;

        [TagField(Length = 640)]
        public PackedObjectDatum[] Objects;

        [TagField(Length = 14)]
        public short[] ObjectTypeStartIndex;

        [TagField(Length = 256)]
        public VariantObjectQuota[] Quotas;

        public static BlfPackedMapVariant Read(EndianReader reader)
        {
            var mapVariant = new BlfPackedMapVariant();

            mapVariant.Signature = reader.ReadTag();
            mapVariant.Length = reader.ReadInt32();
            mapVariant.MajorVersion = reader.ReadInt16();
            mapVariant.MinorVersion = reader.ReadInt16();

            var variantSize = mapVariant.Length - 0xC;

            var buffer = new byte[variantSize];

            for (int i = 0; i < variantSize; i++)
            {
                buffer[i] = reader.ReadByte();
            }

            var stream = new MemoryStream(buffer);
            var bitStream = new BitStream(stream);

            mapVariant.Metadata = PackedContentItemMetadata.Read(bitStream);
            mapVariant.VariantVersion = (short)bitStream.ReadUnsigned(8);
            mapVariant.MapVariantChecksum = bitStream.ReadUnsigned(32);
            mapVariant.ScenarioObjectCount = (short)bitStream.ReadUnsigned(10);
            mapVariant.VariantObjectCount = (short)bitStream.ReadUnsigned(10);
            mapVariant.PlaceableQuotaCount = (short)bitStream.ReadUnsigned(9);
            mapVariant.MapId = (int)bitStream.ReadUnsigned(32);
            mapVariant.BuiltIn = bitStream.ReadBool();
            mapVariant.WorldBounds = new RealRectangle3d
            {
                X0 = ReinterpretCastFloat(bitStream.ReadUnsigned(32)),
                X1 = ReinterpretCastFloat(bitStream.ReadUnsigned(32)),
                Y0 = ReinterpretCastFloat(bitStream.ReadUnsigned(32)),
                Y1 = ReinterpretCastFloat(bitStream.ReadUnsigned(32)),
                Z0 = ReinterpretCastFloat(bitStream.ReadUnsigned(32)),
                Z1 = ReinterpretCastFloat(bitStream.ReadUnsigned(32)),
            };
            mapVariant.RuntimeEngineSubType = (GameEngineSubType)bitStream.ReadUnsigned(4);
            mapVariant.MaximumBudget = ReinterpretCastFloat(bitStream.ReadUnsigned(32));
            mapVariant.SpentBudget = ReinterpretCastFloat(bitStream.ReadUnsigned(32));

            mapVariant.Objects = new PackedObjectDatum[mapVariant.VariantObjectCount];
            for (int i = 0; i < mapVariant.VariantObjectCount; i++) 
            {
                mapVariant.Objects[i] = PackedObjectDatum.Read(bitStream);
            }

            mapVariant.ObjectTypeStartIndex = new short[14];
            for (int i = 0; i < mapVariant.ObjectTypeStartIndex.Length; i++) 
            {
                mapVariant.ObjectTypeStartIndex[i] = (short)bitStream.ReadUnsigned(9);
            }

            mapVariant.Quotas = new VariantObjectQuota[mapVariant.PlaceableQuotaCount];
            for (int i = 0; i < mapVariant.PlaceableQuotaCount; i++)
            {
                mapVariant.Quotas[i] = ReadObjectQuota(bitStream);
            }

            return mapVariant;
        }

        public static void Write()
        {
            // TODO: Implement
        }

        static float ReinterpretCastFloat(uint value)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
        }

        [TagStructure(Size = 0x54)]
        public class PackedObjectDatum : TagStructure
        {
            public VariantObjectPlacementFlags Flags;
            public short RuntimeRemovalTimer;
            public int RuntimeObjectIndex = -1;
            public int RuntimeEditorObjectIndex = -1;
            public int QuotaIndex = -1;
            public PackedPosition Position;
            public PackedAxis Axis;
            // TODO: Infer unpacked data from packed data
            //public RealPoint3d Position;
            //public RealVector3d Forward;
            //public RealVector3d Up;
            public ObjectIdentifier ParentObject;
            public VariantMultiplayerProperties Properties;

            public static PackedObjectDatum Read(BitStream stream)
            {
                var objectDatum = new PackedObjectDatum();

                if (stream.ReadUnsigned(1) == 0)
                {
                    return objectDatum;
                }

                objectDatum.Flags = (VariantObjectPlacementFlags)stream.ReadUnsigned(16);
                objectDatum.QuotaIndex = (int)stream.ReadUnsigned(32);

                var hasParentObject = stream.ReadUnsigned(1) > 0;

                // TODO: Set default values for ObjectIdentifier
                objectDatum.ParentObject = new ObjectIdentifier();

                if (hasParentObject)
                {
                    objectDatum.ParentObject.UniqueId = new DatumHandle(stream.ReadUnsigned(32));
                    objectDatum.ParentObject.OriginBspIndex = (short)stream.ReadUnsigned(16);
                    objectDatum.ParentObject.Type = new GameObjectType8() { Halo3Retail = (GameObjectTypeHalo3Retail)stream.ReadUnsigned(8) };
                    objectDatum.ParentObject.Source = (ObjectIdentifier.SourceValue)stream.ReadUnsigned(8);
                }

                var hasPosition = stream.ReadUnsigned(1) > 0;

                if (hasPosition)
                {
                    objectDatum.Position = PackedPosition.Read(stream);
                    objectDatum.Axis = PackedAxis.Read(stream);

                    objectDatum.Properties = new VariantMultiplayerProperties
                    {
                        Type = (MultiplayerObjectType)stream.ReadUnsigned(8),
                        Flags = (VariantPlacementFlags)stream.ReadUnsigned(8),
                        EngineFlags = (GameEngineSubTypeFlags)stream.ReadUnsigned(16),
                        SharedStorage = (byte)stream.ReadUnsigned(8),
                        SpawnTime = (byte)stream.ReadUnsigned(8),
                        Team = (MultiplayerTeamDesignator)stream.ReadUnsigned(8),
                        Boundary = new MultiplayerObjectBoundary 
                        {
                            Type = (MultiplayerObjectBoundaryShape)stream.ReadUnsigned(8),
                        },
                    };

                    if (objectDatum.Properties.Boundary.Type != MultiplayerObjectBoundaryShape.None)
                    {
                        switch (objectDatum.Properties.Boundary.Type)
                        {
                            case MultiplayerObjectBoundaryShape.Sphere:
                                objectDatum.Properties.Boundary.WidthRadius = (short)stream.ReadUnsigned(16);
                                break;
                            case MultiplayerObjectBoundaryShape.Cylinder:
                                objectDatum.Properties.Boundary.WidthRadius = (short)stream.ReadUnsigned(16);
                                objectDatum.Properties.Boundary.BoxLength = (short)stream.ReadUnsigned(16);
                                objectDatum.Properties.Boundary.PositiveHeight = (short)stream.ReadUnsigned(16);
                                break;
                            case MultiplayerObjectBoundaryShape.Box:
                                objectDatum.Properties.Boundary.WidthRadius = (short)stream.ReadUnsigned(16);
                                objectDatum.Properties.Boundary.BoxLength = (short)stream.ReadUnsigned(16);
                                objectDatum.Properties.Boundary.PositiveHeight = (short)stream.ReadUnsigned(16);
                                objectDatum.Properties.Boundary.NegativeHeight = (short)stream.ReadUnsigned(16);
                                break;
                        }
                    }
                }

                return objectDatum;
            }

            public static void Write()
            {
                // TODO: Implement
            }
        }

        public static VariantObjectQuota ReadObjectQuota(BitStream stream)
        {
            var quotaDatum = new VariantObjectQuota();

            quotaDatum.ObjectDefinitionIndex = (int)stream.ReadUnsigned(32);
            quotaDatum.MinimumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.MaximumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.PlacedOnMap = (byte)stream.ReadUnsigned(8);
            quotaDatum.MaxAllowed = (byte)stream.ReadUnsigned(8);
            quotaDatum.Cost = ReinterpretCastFloat(stream.ReadUnsigned(32));

            return quotaDatum;
        }

        public static void WriteObjectQuota()
        {
            // TODO: Implement
        }

        [TagStructure(Size = 0x6)]
        public class PackedPosition : TagStructure
        {
            public short X;
            public short Y;
            public short Z;

            public static PackedPosition Read(BitStream stream)
            {
                var position = new PackedPosition();

                position.X = (short)stream.ReadUnsigned(16);
                position.Y = (short)stream.ReadUnsigned(16);
                position.Z = (short)stream.ReadUnsigned(16);

                return position;
            }

            public static void Write()
            {
                // TODO: Implement
            }
        }

        [TagStructure(Size = 0x5)]
        public class PackedAxis : TagStructure
        {
            public int Up;
            public byte Forward;

            public static PackedAxis Read(BitStream stream)
            {
                var axis = new PackedAxis();

                var isUp = stream.ReadBool();

                if (!isUp)
                {
                    axis.Up = (int)stream.ReadUnsigned(19);
                }

                axis.Forward = (byte)stream.ReadUnsigned(8);

                return axis;
            }

            public static void Write()
            {
                // TODO: Implement
            }
        }
    }
}
