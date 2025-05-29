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
    public class BlfPackedMapVariant
    {
        public static BlfMapVariant Read(EndianReader reader)
        {
            var blfChunk = new BlfMapVariant();

            blfChunk.Signature = reader.ReadTag();
            blfChunk.Length = reader.ReadInt32();
            blfChunk.MajorVersion = reader.ReadInt16();
            blfChunk.MinorVersion = reader.ReadInt16();

            var variantSize = blfChunk.Length - 0xC;

            var buffer = new byte[variantSize];

            for (int i = 0; i < variantSize; i++)
            {
                buffer[i] = reader.ReadByte();
            }

            var stream = new MemoryStream(buffer);
            var bitStream = new BitStream(stream);

            var mapVariant = new MapVariant();

            mapVariant.Metadata = ReadMetadata(bitStream);
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

            mapVariant.Objects = new VariantObjectDatum[mapVariant.VariantObjectCount];
            for (int i = 0; i < mapVariant.VariantObjectCount; i++)
            {
                mapVariant.Objects[i] = ReadObjectDatum(bitStream, mapVariant.WorldBounds);
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

            blfChunk.MapVariant = mapVariant;

            return blfChunk;
        }

        public static void Write()
        {
            // TODO: Implement
        }

        public static ContentItemMetadata ReadMetadata(BitStream stream)
        {
            var metadata = new ContentItemMetadata();

            metadata.UniqueId = stream.ReadUnsigned64(64);
            metadata.Name = stream.ReadUnicodeString(16);
            metadata.Description = stream.ReadString(128);
            metadata.Author = stream.ReadString(16);
            metadata.ContentType = (ContentItemType)(stream.ReadUnsigned(5) - 1);
            metadata.AuthorIsOnline = stream.ReadBool();
            metadata.AuthorId = stream.ReadUnsigned64(64);
            metadata.ContentSize = stream.ReadUnsigned64(64);
            metadata.Timestamp = stream.ReadUnsigned64(64);
            metadata.FilmDuration = (int)stream.ReadUnsigned(32);
            metadata.CampaignId = (int)stream.ReadUnsigned(32);
            metadata.MapId = (int)stream.ReadUnsigned(32);
            metadata.GameEngineType = (GameEngineType)stream.ReadUnsigned(4);
            metadata.CampaignDifficulty = (int)(stream.ReadUnsigned(3) - 1);
            metadata.HopperId = (short)stream.ReadUnsigned(16);
            metadata.GameId = stream.ReadUnsigned64(64);

            return metadata;
        }

        public static void WriteMetadata()
        {
            // TODO: Implement
        }

        static float ReinterpretCastFloat(uint value)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
        }

        public static VariantObjectDatum ReadObjectDatum(BitStream stream, RealRectangle3d worldBounds)
        {
            var objectDatum = new VariantObjectDatum();

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

                ReadAxis(stream, out objectDatum.Forward, out objectDatum.Up);

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

        public static void WriteObjectDatum()
        {
            // TODO: Implement
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

        public unsafe static RealPoint3d ReadQuantizedPosition(BitStream stream, int axisEncodingSizeInBits, RealRectangle3d worldBounds)
        {
            var point = stackalloc int[3];

            point[0] = (int)stream.ReadUnsigned(axisEncodingSizeInBits);
            point[1] = (int)stream.ReadUnsigned(axisEncodingSizeInBits);
            point[2] = (int)stream.ReadUnsigned(axisEncodingSizeInBits);

            var dequantizedPoint = new RealPoint3d(0.0f, 0.0f, 0.0f)
            {
                X = DequantizeReal(point[0], worldBounds.X0, worldBounds.X1, axisEncodingSizeInBits, false),
                Y = DequantizeReal(point[1], worldBounds.Y0, worldBounds.Y1, axisEncodingSizeInBits, false),
                Z = DequantizeReal(point[2], worldBounds.Z0, worldBounds.Z1, axisEncodingSizeInBits, false),
            };

            return dequantizedPoint;
        }

        public static void ReadAxis(BitStream stream, out RealVector3d forward, out RealVector3d up)
        {
            var isUp = stream.ReadBool();

            if (isUp)
            {
                // TODO: Find home for global unit vectors
                // GlobalUp
                up = new RealVector3d(0.0f, 0.0f, 1.0f);
            }
            else
            {
                int quantizedUp = (int)stream.ReadUnsigned(19);
                DequantizeUnitVector3d(quantizedUp, out up);
            }

            int quantizedForward = (int)stream.ReadUnsigned(8);
            float forwardAngle = DequantizeReal(quantizedForward, -(float)Math.PI, (float)Math.PI, 8, true);

            AngleToAxes(up, forwardAngle, out forward);
        }

        public static void AngleToAxes(RealVector3d up, float angle, out RealVector3d forward)
        {
            var forwardReference = new RealVector3d(0.0f, 0.0f, 0.0f);
            var leftReference = new RealVector3d(0.0f, 0.0f, 0.0f);

            AxesComputeReference(up, out forwardReference, out leftReference);

            forward = new RealVector3d 
            {
                I = forwardReference.I,
                J = forwardReference.J,
                K = forwardReference.K,
            };

            float u;
            float v;

            if (angle == (float)Math.PI || angle == -(float)Math.PI)
            {
                u = 0.0f;
                v = -1.0f;
            }
            else
            {
                u = (float)Math.Sin(angle);
                v = (float)Math.Cos(angle);
            }

            forward = RotateVectorAboutAxis(forward, up, u, v);
            Normalize3d(forward, out forward);

            if (!ValidReadlVector3dAxes2(forward, up)) 
            {
                throw new InvalidOperationException("Invalid forward and up vectors");
            }
        }

        public static void AxesComputeReference(RealVector3d up, out RealVector3d forwardReference, out RealVector3d leftReference)
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

            //float forwardMagnitude = RealVector3d.Magnitude(forwardReference);
            float forwardMagnitude = Normalize3d(forwardReference, out forwardReference);

            if (forwardMagnitude < 0.0001f)
            {
                throw new InvalidOperationException("Forward Magnitude was less than epsilon");
            }

            leftReference = RealVector3d.CrossProductNoNorm(up, forwardReference);

            float leftMagnitude = Normalize3d(leftReference, out leftReference);

            if (leftMagnitude < 0.0001f)
            {
                throw new InvalidOperationException("Left Magnitude was less than epsilon");
            }

            if (!ValidReadlVector3dAxes3(forwardReference, leftReference, up))
            {
                throw new InvalidOperationException("Invalid vector axes");
            }
        }

        public static float Magnitude3d(RealVector3d vector) 
        {
            return (float)Math.Sqrt(RealVector3d.Magnitude(vector));
        }

        public static RealVector3d ScaleVector3d(RealVector3d vector, float scale) 
        {
            vector.I *= scale;
            vector.J *= scale;
            vector.K *= scale;

            return vector;
        }

        public static float Normalize3d(RealVector3d vector, out RealVector3d output) 
        {
            float result = Magnitude3d(vector);

            if (Math.Abs(result) >= 0.0001f)
            {
                float scale = 1.0f / result;
                output = ScaleVector3d(vector, scale);
            }
            else 
            {
                output = vector;
                result = 0.0f;
            }

            return result;
        }

        public static bool ValidReadlVector3dAxes2(RealVector3d forward, RealVector3d up)
        {
            bool v1 = ValidRealVector(forward);
            bool v2 = ValidRealVector(up);
            bool v3 = ValidRealComparison(RealVector3d.DotProduct(forward, up), 0.0f);

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
            return ValidReal(a1 - a2) && Math.Abs(a1 - a2) < 0.001f;
        }

        public static bool ValidRealVector(RealVector3d vector) 
        {
            var squaredLength = RealVector3d.Magnitude(vector) - 1.0f;

            if (float.IsNaN(squaredLength) || float.IsInfinity(squaredLength)) 
            {
                return false;
            }

            return Math.Abs(squaredLength) < 0.001f;
        }

        public static RealVector3d RotateVectorAboutAxis(RealVector3d forward, RealVector3d up, float u, float v) 
        {
            float v1 = (1.0f - v) * (((forward.I * up.I) + (forward.J * up.J)) + (forward.K * up.K));
            float v2 = (forward.K * up.I) - (forward.I * up.K);
            float v3 = (forward.I * up.J) - (forward.J * up.I);
            forward.I = ((v * forward.I) + (v1 * up.I)) - (u * ((forward.J * up.K) - (forward.K * up.J)));
            forward.J = ((v * forward.J) + (v1 * up.J)) - (u * v2);
            forward.K = ((v * forward.K) + (v1 * up.K)) - (u * v3);

            return forward;
        }

        public static void DequantizeUnitVector3d(int value, out RealVector3d vector) 
        {
            int face = value & 7;
            float x = DequantizeReal((value >> 3) & 0xFF, -1.0f, 1.0f, 8, true);
            float y = DequantizeReal((value >> 11) & 0xFF, -1.0f, 1.0f, 8, true);

            switch (face)
            {
                case 0:
                    vector = new RealVector3d(1.0f, x, y);
                    break;
                case 1:
                    vector = new RealVector3d(x, 1.0f, y);
                    break;
                case 2:
                    vector = new RealVector3d(x, y, 1.0f);
                    break;
                case 3:
                    vector = new RealVector3d(-1.0f, x, y);
                    break;
                case 4:
                    vector = new RealVector3d(x, -1.0f, y);
                    break;
                case 5:
                    vector = new RealVector3d(x, y, -1.0f);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid face value {face} when reading unit vector");
            }

            Normalize3d(vector, out vector);
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
    }
}
