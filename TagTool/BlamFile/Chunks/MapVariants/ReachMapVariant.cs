using System;
using System.Diagnostics;
using TagTool.Common;
using TagTool.Cache;
using TagTool.Tags;
using TagTool.Tags.Definitions.Common;
using TagTool.BlamFile.Chunks.Megalo;
using TagTool.BlamFile.Chunks.Metadata;

namespace TagTool.BlamFile.Chunks.MapVariants
{
    [TagStructure(Size = 0x30A, MinVersion = CacheVersion.HaloReach)]
    public class ReachMapVariant : TagStructure
    {
        public ReachContentItemMetadata Metadata;
        public int Version;
        public uint CacheCRC;
        public uint ScenarioPaletteCRC;
        public int PlaceableObjectQuota;
        public int MapId;
        public bool BuiltIn;
        public bool BuiltFromXml;
        public RealRectangle3d WorldBounds;
        public int MaxBudget;
        public int SpentBudget;
        public MegaloStringTable StringTable;

        [TagField(Length = 651)]
        public ReachVariantObjectDatum[] Objects;

        [TagField(Length = 256)]
        public ReachVariantQuota[] Quotas;

        public static ReachMapVariant Decode(BitStream stream)
        {
            var mapVariant = new ReachMapVariant();

            mapVariant.Metadata = ReachContentItemMetadata.Decode(stream, true);
            mapVariant.Version = (int)stream.ReadUnsigned(8);
            mapVariant.CacheCRC = stream.ReadUnsigned(32);
            mapVariant.ScenarioPaletteCRC = stream.ReadUnsigned(32);
            mapVariant.PlaceableObjectQuota = (int)stream.ReadUnsigned(9);
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
            mapVariant.MaxBudget = (int)stream.ReadUnsigned(32);
            mapVariant.SpentBudget = (int)stream.ReadUnsigned(32);
            mapVariant.StringTable = MegaloStringTable.Decode(stream);

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

    [TagStructure(Size = 0xC, MinVersion = CacheVersion.HaloReach)]
    public class ReachVariantQuota : TagStructure
    {
        public int MinimumCount;
        public int MaximumCount;
        public int PlacedOnMap;

        public static ReachVariantQuota Decode(BitStream stream)
        {
            var quotaDatum = new ReachVariantQuota();

            quotaDatum.MinimumCount = (int)stream.ReadUnsigned(8);
            quotaDatum.MaximumCount = (int)stream.ReadUnsigned(8);
            quotaDatum.PlacedOnMap = (int)stream.ReadUnsigned(8);

            return quotaDatum;
        }
    }

    [TagStructure(Size = 0x62, MinVersion = CacheVersion.HaloReach)]
    public class ReachVariantObjectDatum : TagStructure
    {
        public ObjectPlacementFlags Flags;
        public int QuotaIndex = -1;
        public int VariantIndex = -1;
        public RealPoint3d Position;
        public RealVector3d Forward;
        public RealVector3d Up;
        public int SpawnRelativeToIndex = -1;
        public ReachVarintMultiplayerObjectProperties Properties;

        public static ReachVariantObjectDatum Decode(BitStream stream, RealRectangle3d worldBounds)
        {
            var objectDatum = new ReachVariantObjectDatum();

            if (!stream.ReadBool())
                return objectDatum;

            objectDatum.Flags = (ObjectPlacementFlags)stream.ReadUnsigned(2);

            if (!stream.ReadBool())
                objectDatum.QuotaIndex = (int)stream.ReadUnsigned(8);

            if (!stream.ReadBool())
                objectDatum.VariantIndex = (int)stream.ReadUnsigned(5);

            var hasPosition = stream.ReadUnsigned(1) > 0;

            if (hasPosition) 
            {
                objectDatum.Position = RealMath.ReadQuantizedPositionPerAxis(stream, 21, worldBounds);

                BitStream.ReadAxis(stream, 14, 20, true, out objectDatum.Forward, out objectDatum.Up);

                objectDatum.SpawnRelativeToIndex = (int)stream.ReadUnsigned(10) - 1;

                objectDatum.Properties = ReachVarintMultiplayerObjectProperties.Decode(stream);
            }

            return objectDatum;
        }

        [Flags]
        public enum ObjectPlacementFlags : byte
        {
            None = 0,
            OccupiedSlot = 1 << 0
        }
    }

    [TagStructure(Size = 0x31, MinVersion = CacheVersion.HaloReach)]
    public class ReachVarintMultiplayerObjectProperties : TagStructure
    {
        public ReachMultiplayerObjectBoundary Boundary;
        public int SpawnOrder;
        public int SpawnTime;
        public MultiplayerObjectTypeReach Type;
        public int MegaloLabelIndex;
        public VariantPlacementFlags PlacementFlags;
        public MultiplayerTeamDesignator Team = MultiplayerTeamDesignator.Neutral;
        public int PrimaryChangeColorIndex = -1;
        public int SpareClips;
        public int TeleporterChannel;
        public TeleporterPassabilityFlags TeleporterPassability;
        public int LocationNameIndex = -1;

        public static ReachVarintMultiplayerObjectProperties Decode(BitStream stream)
        {
            var objectProperties = new ReachVarintMultiplayerObjectProperties();

            objectProperties.Boundary = ReachMultiplayerObjectBoundary.Decode(stream);

            objectProperties.SpawnOrder = (int)stream.ReadUnsigned(8);
            objectProperties.SpawnTime = (int)stream.ReadUnsigned(8);
            objectProperties.Type = (MultiplayerObjectTypeReach)(int)stream.ReadUnsigned(5);

            if (stream.ReadBool())
                objectProperties.MegaloLabelIndex = -1;
            else
                objectProperties.MegaloLabelIndex = (int)stream.ReadUnsigned(8);

            objectProperties.PlacementFlags = (VariantPlacementFlags)stream.ReadUnsigned(8);
            objectProperties.Team = (MultiplayerTeamDesignator)((int)stream.ReadUnsigned(4) - 1);

            if (stream.ReadBool())
                objectProperties.PrimaryChangeColorIndex = -1;
            else
                objectProperties.PrimaryChangeColorIndex = (int)stream.ReadUnsigned(3);

            if (objectProperties.Type == MultiplayerObjectTypeReach.Weapon)
            {
                objectProperties.SpareClips = (int)stream.ReadUnsigned(8);
            }
            else
            {
                if (objectProperties.Type <= MultiplayerObjectTypeReach.Device)
                    return objectProperties;
                if (objectProperties.Type <= MultiplayerObjectTypeReach.TeleporterReceiver)
                {
                    objectProperties.TeleporterChannel = (int)stream.ReadUnsigned(5);
                    objectProperties.TeleporterPassability = (TeleporterPassabilityFlags)stream.ReadUnsigned(5);
                }
                if (objectProperties.Type != MultiplayerObjectTypeReach.NamedLocationArea)
                    return objectProperties;

                objectProperties.LocationNameIndex = (int)stream.ReadUnsigned(8) - 1;
            }

            return objectProperties;
        }

        [Flags]
        public enum VariantPlacementFlags : byte
        {
            None = 0,
            UniqueSpawn  = 1 << 0,
            NotInitiallyPlaced  = 1 << 1,
            SymmetricPlacement = 1 << 2,
            AsymmetricPlacement = 1 << 3,
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

            if (boundary.Shape == MultiplayerObjectBoundaryShape.Sphere)
            {
                boundary.WidthRadius = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
            }
            else
            {
                if (boundary.Shape == MultiplayerObjectBoundaryShape.Cylinder)
                {
                    boundary.WidthRadius = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                }
                else
                {
                    if (boundary.Shape != MultiplayerObjectBoundaryShape.Box)
                    {
                        Debug.Assert(boundary.Shape == 0);
                        return boundary;
                    }


                    boundary.WidthRadius = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                    boundary.BoxLength = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                }

                boundary.PositiveHeight = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
                boundary.NegativeHeight = BitStream.ReadQuantizedRealWithEndPoints(stream, 0.0f, 200.0f, 11, false, true);
            }

            return boundary;
        }
    }
}
