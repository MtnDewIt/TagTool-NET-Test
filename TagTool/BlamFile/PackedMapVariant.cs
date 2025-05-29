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
                mapVariant.Objects[i] = PackedObjectDatum.Read(bitStream, mapVariant.WorldBounds);
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
            public RealPoint3d Position;
            public RealVector3d Forward;
            public RealVector3d Up;
            public ObjectIdentifier ParentObject;
            public VariantMultiplayerProperties Properties;

            public static PackedObjectDatum Read(BitStream stream, RealRectangle3d worldBounds)
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
                    objectDatum.Position = ReadQuantizedPosition(stream, 16, worldBounds);

                    // TODO: Inline some functions, as it never properly returns the values for forward and up
                    ReadAxis(stream, objectDatum.Forward, objectDatum.Up);

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

        public unsafe static RealPoint3d ReadQuantizedPosition(BitStream stream, int axisEncodingSizeInBits, RealRectangle3d worldBounds)
        {
            var point = stackalloc int[3];

            point[0] = (int)stream.ReadUnsigned(axisEncodingSizeInBits);
            point[1] = (int)stream.ReadUnsigned(axisEncodingSizeInBits);
            point[2] = (int)stream.ReadUnsigned(axisEncodingSizeInBits);

            var dequantizedPoint = new RealPoint3d(0.0f, 0.0f, 0.0f)
            {
                X = DequantizeReal(point[0], worldBounds.X0, worldBounds.X1, axisEncodingSizeInBits, false),
                Y = DequantizeReal(point[1], worldBounds.X0, worldBounds.X1, axisEncodingSizeInBits, false),
                Z = DequantizeReal(point[3], worldBounds.X0, worldBounds.X1, axisEncodingSizeInBits, false),
            };

            return dequantizedPoint;
        }

        public static void ReadAxis(BitStream stream, RealVector3d forward, RealVector3d up)
        {
            var isUp = stream.ReadBool();

            if (isUp)
            {
                // TODO: Find home for global unit vectors
                // GlobalUp
                up.I = 0.0f;
                up.J = 0.0f;
                up.K = 1.0f;
            }
            else
            {
                int quantizedUp = (int)stream.ReadUnsigned(19);
                DequantizeUnitVector3d(quantizedUp, up);
            }

            int quantizedForward = (int)stream.ReadUnsigned(8);
            float forwardAngle = DequantizeReal(quantizedForward, -(int)Math.PI, (int)Math.PI, 8, true);

            AngleToAxes(up, forwardAngle, forward);
        }

        public static void AngleToAxes(RealVector3d up, float angle, RealVector3d forward)
        {
            var forwardReference = new RealVector3d(0.0f, 0.0f, 0.0f);
            var leftReference = new RealVector3d(0.0f, 0.0f, 0.0f);

            AxesComputeReference(up, forwardReference, leftReference);

            forward.I = forwardReference.I;
            forward.J = forwardReference.J;
            forward.K = forwardReference.K;

            float u;
            float v;

            if (angle == Math.PI || angle == -Math.PI)
            {
                u = 0.0f;
                v = -1.0f;
            }
            else
            {
                u = (float)Math.Sin(angle);
                v = (float)Math.Cos(angle);
            }

            RotateVectorAboutAxis(forward, up, u, v);
            RealVector3d.Normalize(forward);

            if (!ValidReadlVector3dAxes2(forward, up)) 
            {
                throw new InvalidOperationException("Invalid forward and up vectors");
            }
        }

        public static void AxesComputeReference(RealVector3d up, RealVector3d forwardReference, RealVector3d leftReference)
        {
            if (!ValidRealVector(up)) 
            {
                throw new ArgumentException("Up vector is not a valid vector");
            }

            // TODO: Find home for global unit vectors

            // GlobalForward
            float forwardAmount = Math.Abs(RealVector3d.DotProduct(up, new RealVector3d(1.0f, 0.0f, 0.0f)));
            // GlobalLeft
            float leftAmount = Math.Abs(RealVector3d.DotProduct(up, new RealVector3d(0.0f, 1.0f, 0.0f)));

            if (forwardAmount >= leftAmount)
            {
                // GlobalLeft
                forwardReference = RealVector3d.CrossProductNoNorm(new RealVector3d(0.0f, 1.0f, 0.0f), up);
            }
            else
            {
                // GlobalForward
                forwardReference = RealVector3d.CrossProductNoNorm(up, new RealVector3d(1.0f, 0.0f, 0.0f));
            }

            float forwardMagnitude = RealVector3d.Magnitude(forwardReference);

            if (forwardMagnitude < float.Epsilon)
            {
                throw new InvalidOperationException("Forward Magnitude was less than epsilon");
            }

            leftReference = RealVector3d.CrossProductNoNorm(up, forwardReference);

            float leftMagnitude = RealVector3d.Magnitude(leftReference);

            if (leftMagnitude < float.Epsilon)
            {
                throw new InvalidOperationException("Left Magnitude was less than epsilon");
            }

            if (!ValidReadlVector3dAxes3(forwardReference, leftReference, up))
            {
                throw new InvalidOperationException("Invalid vector axes");
            }
        }

        public static bool ValidReadlVector3dAxes2(RealVector3d forward, RealVector3d up)
        {
            return ValidRealVector(forward)
                && ValidRealVector(up)
                && ValidRealComparison(RealVector3d.DotProduct(forward, up), 0.0f);
        }

        public static bool ValidReadlVector3dAxes3(RealVector3d forward, RealVector3d left, RealVector3d up)
        {
            return ValidRealVector(forward)
                && ValidRealVector(left)
                && ValidRealVector(up)
                && ValidRealComparison(RealVector3d.DotProduct(forward, left), 0.0f)
                && ValidRealComparison(RealVector3d.DotProduct(left, up), 0.0f)
                && ValidRealComparison(RealVector3d.DotProduct(forward, up), 0.0f);
        }

        public static bool ValidReal(float value)
        {
            return !float.IsInfinity(value) && !float.IsNaN(value);
        }

        public static bool ValidRealComparison(float a1, float a2)
        {
            return ValidReal(a1 - a2) && Math.Abs(a1 - a2) < float.Epsilon;
        }

        public static bool ValidRealVector(RealVector3d vector) 
        {
            var squaredLength = vector.I * vector.I + vector.J * vector.J + vector.K * vector.K - 1.0f;

            if (float.IsNaN(squaredLength) || float.IsInfinity(squaredLength)) 
            {
                return false;
            }

            return Math.Abs(squaredLength) < 0.001f;
        }

        public static void RotateVectorAboutAxis(RealVector3d forward, RealVector3d up, float u, float v) 
        {
            float v1 = (1.0f - v) * (((forward.I * up.I) + (forward.J * up.J)) + (forward.K * up.K));
            float v2 = (forward.K * up.I) - (forward.I * up.K);
            float v3 = (forward.I * up.J) - (forward.J * up.I);
            forward.I = ((v * forward.I) + (v1 * up.I)) - (u * ((forward.J * up.K) - (forward.K * up.J)));
            forward.J = ((v * forward.J) + (v1 * up.J)) - (u * v2);
            forward.K = ((v * forward.K) + (v1 * up.K)) - (u * v3);
        }

        public static void DequantizeUnitVector3d(int value, RealVector3d vector) 
        {
            int face = value & 7;
            float x = DequantizeReal((value >> 3) & 0xFF, -1.0f, 1.0f, 8, true);
            float y = DequantizeReal((value >> 11) & 0xFF, -1.0f, 1.0f, 8, true);

            switch (face)
            {
                case 0:
                    vector.I = 1.0f;
                    vector.J = x;
                    vector.K = y;
                    break;
                case 1:
                    vector.I = x;
                    vector.J = 1.0f;
                    vector.K = y;
                    break;
                case 2:
                    vector.I = x;
                    vector.J = y;
                    vector.K = 1.0f;
                    break;
                case 3:
                    vector.I = -1.0f;
                    vector.J = x;
                    vector.K = y;
                    break;
                case 4:
                    vector.I = x;
                    vector.J = -1.0f;
                    vector.K = y;
                    break;
                case 5:
                    vector.I = x;
                    vector.J = y;
                    vector.K = -1.0f;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid face value {face} when reading unit vector");
            }

            RealVector3d.Normalize(vector);
        }

        public static float DequantizeReal(int quantized, float minValue, float maxValue, int sizeInBits, bool exactMidPoint)
        {
            if (sizeInBits <= 0) 
            {
                throw new ArgumentException("Number of bits must be greater than zero");
            }

            if (maxValue <= minValue)
            {
                throw new ArgumentException("Maximum Value must be greater than Minimum Value");
            }

            if (exactMidPoint && sizeInBits <= 1)
            {
                throw new ArgumentException("Number of bits must be greater than 1 when exact mid point is enabled");
            }

            int stepCount = (1 << sizeInBits) - 1;

            if (exactMidPoint)
            {
                stepCount -= stepCount % 2;
            }

            if (stepCount <= 0)
            {
                throw new InvalidOperationException("Number of steps was less than or equal to zero");
            }

            float dequantized;

            if (quantized != 0)
            {
                if (quantized < stepCount)
                {
                    dequantized = (((stepCount - quantized) * minValue) + (quantized * maxValue)) / stepCount;
                }
                else
                {
                    dequantized = maxValue;
                }
            }
            else
            {
                dequantized = minValue;
            }

            if (exactMidPoint && 2 * quantized == stepCount)
            {
                if (dequantized != (minValue + maxValue) / 2.0f) 
                {
                    throw new InvalidOperationException("Dequantized value must be equal to the exact mid point of Minimum Value and Maximum Value");
                }
            }

            return dequantized;
        }

        public static void WriteObjectQuota()
        {
            // TODO: Implement
        }
    }
}
