using System;
using TagTool.BlamFile.Chunks.Megalo;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;

namespace TagTool.BlamFile.Chunks.MapVariants
{
    [TagStructure(Size = 0xD9B0, MinVersion = CacheVersion.HaloReach)]
    public class ReachMapVariant : TagStructure
    {
        public ReachContentItemMetadata Metadata;
        public short VariantVersion;
        public short ScenarioObjectCount;
        public short VariantObjectCount;
        public short PlaceableQuotaCount;
        public int MapId = -1;
        public RealRectangle3d WorldBounds;
        public int MaximumBudget;
        public int SpentBudget;
        public bool HelpersEnabled;
        public bool BuiltIn;
        public bool BuiltFromXml;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public uint OriginalMapRSASignatureHash;
        public uint ScenarioPaletteCRC;

        public SingleLanguageStringTable StringTable;

        [TagField(Length = 651)]
        public ReachVariantObjectDatum[] Objects;

        [TagField(Length = 256)]
        public ReachVariantQuota[] Quotas;

        [TagField(Length = 32)]
        public int[] SimulationEntities;

        public static ReachMapVariant Decode(BitStream stream)
        {
            var mapVariant = new ReachMapVariant();

            mapVariant.Metadata = ReachContentItemMetadata.Decode(stream, true);
            mapVariant.VariantVersion = (short)stream.ReadUnsigned(8);
            mapVariant.OriginalMapRSASignatureHash = stream.ReadUnsigned(32);
            mapVariant.ScenarioPaletteCRC = stream.ReadUnsigned(32);
            mapVariant.PlaceableQuotaCount = (short)stream.ReadUnsigned(9);
            mapVariant.MapId = (int)stream.ReadUnsigned(32);
            mapVariant.BuiltIn = stream.ReadBool();
            mapVariant.BuiltFromXml = stream.ReadBool();
            mapVariant.WorldBounds = new RealRectangle3d
            {
                X0 = stream.ReadFloat(32),
                X1 = stream.ReadFloat(32),
                Y0 = stream.ReadFloat(32),
                Y1 = stream.ReadFloat(32),
                Z0 = stream.ReadFloat(32),
                Z1 = stream.ReadFloat(32)
            };
            mapVariant.MaximumBudget = (int)stream.ReadUnsigned(32);
            mapVariant.SpentBudget = (int)stream.ReadUnsigned(32);
            mapVariant.StringTable = SingleLanguageStringTable.Decode(stream);

            mapVariant.Objects = new ReachVariantObjectDatum[651];
            for (int i = 0; i < 651; i++)
            {
                mapVariant.Objects[i] = ReachVariantObjectDatum.Decode(stream, mapVariant.WorldBounds);
            }

            mapVariant.Quotas = new ReachVariantQuota[256];
            for (int i = 0; i < 256; i++)
            {
                mapVariant.Quotas[i] = ReachVariantQuota.Decode(stream);
            }

            return mapVariant;
        }
    }

    [TagStructure(Size = 0x3, MinVersion = CacheVersion.HaloReach)]
    public class ReachVariantQuota : TagStructure
    {
        public byte MinimumCount;
        public byte MaximumCount;
        public byte PlacedOnMap;

        public static ReachVariantQuota Decode(BitStream stream)
        {
            var quotaDatum = new ReachVariantQuota();

            quotaDatum.MinimumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.MaximumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.PlacedOnMap = (byte)stream.ReadUnsigned(8);

            return quotaDatum;
        }
    }

    [TagStructure(Size = 0x4C, MinVersion = CacheVersion.HaloReach)]
    public class ReachVariantObjectDatum : TagStructure
    {
        public ObjectPlacementFlags Flags;
        public ushort ReuseTimeout;
        public int ObjectIndex = -1;
        public int HelperObjectIndex = -1;
        public int QuotaIndex = -1;
        public int VariantIndex = -1;
        public RealPoint3d Position;
        public RealVector3d Forward;
        public RealVector3d Up;
        public int SpawnRelativeToIndex = -1;
        public ReachVariantMultiplayerObjectProperties Properties;

        [Flags]
        public enum ObjectPlacementFlags : ushort
        {
            None = 0,
            OccupiedSlot = 1 << 0,
            Bit1 = 1 << 1,
            Bit2 = 1 << 2,
            Bit3 = 1 << 3,
            Bit4 = 1 << 4,
            Bit5 = 1 << 5,
            Bit6 = 1 << 6,
            Bit7 = 1 << 7,
        }

        public static ReachVariantObjectDatum Decode(BitStream stream, RealRectangle3d worldBounds)
        {
            var objectDatum = new ReachVariantObjectDatum();

            if (!stream.ReadBool())
                return objectDatum;

            objectDatum.Flags = (ObjectPlacementFlags)stream.ReadUnsigned(2);

            if (!stream.ReadBool())
                objectDatum.QuotaIndex = (short)stream.ReadUnsigned(8);

            if (!stream.ReadBool())
                objectDatum.VariantIndex = (sbyte)stream.ReadUnsigned(5);

            var hasPosition = stream.ReadUnsigned(1) > 0;

            if (hasPosition) 
            {
                objectDatum.Position = RealMath.ReadQuantizedPositionPerAxis(stream, 21, worldBounds);

                BitStream.ReadAxis(stream, 14, 20, true, out objectDatum.Forward, out objectDatum.Up);

                objectDatum.SpawnRelativeToIndex = (short)((int)stream.ReadUnsigned(10) - 1);

                objectDatum.Properties = ReachVariantMultiplayerObjectProperties.Decode(stream);
            }

            return objectDatum;
        }
    }

    [TagStructure(Size = 0x1C, MinVersion = CacheVersion.HaloReach)]
    public class ReachVariantMultiplayerObjectProperties : TagStructure
    {
        public ReachMultiplayerObjectBoundary Boundary;
        public byte UserData;
        public byte SpawnTime;
        public MultiplayerObjectTypeReach Type;
        public short MegaloLabelIndex = -1;
        public VariantPlacementFlags Flags;
        public MultiplayerTeamDesignator Team = MultiplayerTeamDesignator.Neutral;

        [TagField(Length = 0x2)]
        public byte[] SharedStorage = new byte[2];

        public sbyte PrimaryChangeColorIndex = -1;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;

        public static ReachVariantMultiplayerObjectProperties Decode(BitStream stream)
        {
            var objectProperties = new ReachVariantMultiplayerObjectProperties();

            objectProperties.Boundary = ReachMultiplayerObjectBoundary.Decode(stream);

            objectProperties.UserData = (byte)stream.ReadUnsigned(8);
            objectProperties.SpawnTime = (byte)stream.ReadUnsigned(8);
            objectProperties.Type = (MultiplayerObjectTypeReach)(int)stream.ReadUnsigned(5);

            if (!stream.ReadBool())
                objectProperties.MegaloLabelIndex = (short)stream.ReadUnsigned(8);

            objectProperties.Flags = (VariantPlacementFlags)stream.ReadUnsigned(8);
            objectProperties.Team = (MultiplayerTeamDesignator)((int)stream.ReadUnsigned(4) - 1);

            if (!stream.ReadBool())
                objectProperties.PrimaryChangeColorIndex = (sbyte)stream.ReadUnsigned(3);

            if (objectProperties.Type != MultiplayerObjectTypeReach.Ordinary) 
            {
                switch (objectProperties.Type)
                {
                    case MultiplayerObjectTypeReach.Weapon:
                        objectProperties.SharedStorage[0] = (byte)stream.ReadUnsigned(8);
                        break;
                    case MultiplayerObjectTypeReach.Grenade:
                    case MultiplayerObjectTypeReach.Projectile:
                    case MultiplayerObjectTypeReach.Powerup:
                    case MultiplayerObjectTypeReach.Equipment:
                    case MultiplayerObjectTypeReach.AmmoPack:
                    case MultiplayerObjectTypeReach.LightLandVehicle:
                    case MultiplayerObjectTypeReach.HeavyLandVehicle:
                    case MultiplayerObjectTypeReach.FlyingVehicle:
                    case MultiplayerObjectTypeReach.Turret:
                    case MultiplayerObjectTypeReach.Device:
                        return objectProperties;
                    case MultiplayerObjectTypeReach.TeleporterTwoWay:
                    case MultiplayerObjectTypeReach.TeleporterSender:
                    case MultiplayerObjectTypeReach.TeleporterReceiver:
                        objectProperties.SharedStorage[0] = (byte)stream.ReadUnsigned(5);
                        objectProperties.SharedStorage[1] = (byte)stream.ReadUnsigned(5);
                        break;
                    case MultiplayerObjectTypeReach.NamedLocationArea:
                        objectProperties.SharedStorage[0] = (byte)((int)stream.ReadUnsigned(8) - 1);
                        break;
                }
            }

            return objectProperties;
        }

        [Flags]
        public enum VariantPlacementFlags : byte
        {
            None = 0,
            UniqueSpawn  = 1 << 0,
            NotInitiallyPlaced  = 1 << 1,
            Symmetric = 1 << 2,
            Asymmetric = 1 << 3,
            IsShortcut = 1 << 4,
            HideUnlessRequired = 1 << 5,
            PhysicsFixed = 1 << 6, // create at rest
            PhysicsPhased = 1 << 7
        }
    }

    [TagStructure(Size = 0x11, MinVersion = CacheVersion.HaloReach)]
    public class ReachMultiplayerObjectBoundary : TagStructure
    {
        public MultiplayerObjectBoundaryShape Shape;
        public float WidthRadius;
        public float BoxLength;
        public float PositiveHeight;
        public float NegativeHeight;

        public static ReachMultiplayerObjectBoundary Decode(BitStream stream)
        {
            var boundary = new ReachMultiplayerObjectBoundary();

            boundary.Shape = (MultiplayerObjectBoundaryShape)stream.ReadUnsigned(2);

            if (boundary.Shape != MultiplayerObjectBoundaryShape.None) 
            {
                switch (boundary.Shape)
                {
                    case MultiplayerObjectBoundaryShape.Sphere:
                        boundary.WidthRadius = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        break;
                    case MultiplayerObjectBoundaryShape.Cylinder:
                        boundary.WidthRadius = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        boundary.PositiveHeight = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        boundary.NegativeHeight = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        break;
                    case MultiplayerObjectBoundaryShape.Box:
                        boundary.WidthRadius = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        boundary.BoxLength = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        boundary.PositiveHeight = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        boundary.NegativeHeight = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                        break;
                }
            }

            return boundary;
        }
    }
}
