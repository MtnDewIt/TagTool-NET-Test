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

        public static ReachMapVariant Decode(BitStreamReader stream)
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
            mapVariant.WorldBounds = stream.ReadRealRectangle3d(32);
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

        public static void Encode(BitStreamWriter stream, ReachMapVariant mapVariant) 
        {
            // TODO: Implement
        }
    }

    [TagStructure(Size = 0x3, MinVersion = CacheVersion.HaloReach)]
    public class ReachVariantQuota : TagStructure
    {
        public byte MinimumCount;
        public byte MaximumCount;
        public byte PlacedOnMap;

        public static ReachVariantQuota Decode(BitStreamReader stream)
        {
            var quotaDatum = new ReachVariantQuota();

            quotaDatum.MinimumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.MaximumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.PlacedOnMap = (byte)stream.ReadUnsigned(8);

            return quotaDatum;
        }

        public static void Encode(BitStreamWriter stream, ReachVariantQuota quota) 
        {
            // TODO: Implement
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

        public static ReachVariantObjectDatum Decode(BitStreamReader stream, RealRectangle3d worldBounds)
        {
            var objectDatum = new ReachVariantObjectDatum();

            if (stream.ReadBool()) 
            {
                objectDatum.Flags = (ObjectPlacementFlags)stream.ReadUnsigned(2);
                objectDatum.QuotaIndex = stream.ReadIndex(8, 256);
                objectDatum.VariantIndex = stream.ReadIndex(5, 32);
                SimulationEncoding.SimulationReadPosition(stream, out objectDatum.Position, 21, false, true, worldBounds);
                stream.ReadAxis(14, 20, out objectDatum.Forward, out objectDatum.Up);
                objectDatum.SpawnRelativeToIndex = (int)stream.ReadUnsigned(10) - 1;
                objectDatum.Properties = ReachVariantMultiplayerObjectProperties.Decode(stream);
            }

            return objectDatum;
        }

        public static void Encode(BitStreamWriter stream, ReachVariantObjectDatum variantObject, RealRectangle3d worldBounds)
        {
            // TODO: Implement
        }
    }

    [TagStructure(Size = 0x1C, MinVersion = CacheVersion.HaloReach)]
    public class ReachVariantMultiplayerObjectProperties : TagStructure
    {
        public ReachMultiplayerObjectBoundary Boundary;
        public byte UserData;
        public byte SpawnTime;
        public MultiplayerObjectTypeReach CachedType;
        public sbyte LabelIndex = -1;
        public VariantPlacementFlags Flags;
        public MultiplayerTeamDesignator Team = MultiplayerTeamDesignator.Neutral;

        [TagField(Length = 0x2)]
        public byte[] SharedStorage = new byte[2];

        public sbyte PrimaryChangeColorIndex = -1;

        [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
        public byte[] Padding;

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
            PhysicsFixed = 1 << 6,
            PhysicsPhased = 1 << 7
        }

        public static ReachVariantMultiplayerObjectProperties Decode(BitStreamReader stream)
        {
            var objectProperties = new ReachVariantMultiplayerObjectProperties();

            objectProperties.Boundary = ReachMultiplayerObjectBoundary.Decode(stream);

            objectProperties.UserData = (byte)stream.ReadUnsigned(8);
            objectProperties.SpawnTime = (byte)stream.ReadUnsigned(8);
            objectProperties.CachedType = (MultiplayerObjectTypeReach)(int)stream.ReadUnsigned(5);
            objectProperties.LabelIndex = (sbyte)stream.ReadIndex(8, 256);
            objectProperties.Flags = (VariantPlacementFlags)stream.ReadUnsigned(8);
            objectProperties.Team = (MultiplayerTeamDesignator)((int)stream.ReadUnsigned(4) - 1);
            objectProperties.PrimaryChangeColorIndex = (sbyte)stream.ReadIndex(3, 8);

            switch (objectProperties.CachedType)
            {
                case MultiplayerObjectTypeReach.Weapon:
                    objectProperties.SharedStorage[0] = (byte)stream.ReadUnsigned(8); // spare_clips
                    break;
                case MultiplayerObjectTypeReach.TeleporterTwoWay:
                case MultiplayerObjectTypeReach.TeleporterSender:
                case MultiplayerObjectTypeReach.TeleporterReceiver:
                    objectProperties.SharedStorage[0] = (byte)stream.ReadUnsigned(5); // channel
                    objectProperties.SharedStorage[1] = (byte)stream.ReadUnsigned(5); // passability
                    break;
                case MultiplayerObjectTypeReach.NamedLocationArea:
                    objectProperties.SharedStorage[0] = (byte)stream.ReadIndex(8, 255); // location_name_index
                    break;
            }

            return objectProperties;
        }

        public static void Encode(BitStreamWriter stream, ReachVariantMultiplayerObjectProperties properties)
        {
            // TODO: Implement
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

        public static ReachMultiplayerObjectBoundary Decode(BitStreamReader stream)
        {
            var boundary = new ReachMultiplayerObjectBoundary();

            boundary.Shape = (MultiplayerObjectBoundaryShape)(int)stream.ReadUnsigned(2);

            switch (boundary.Shape)
            {
                case MultiplayerObjectBoundaryShape.Sphere:
                    boundary.WidthRadius = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    break;
                case MultiplayerObjectBoundaryShape.Cylinder:
                    boundary.WidthRadius = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    boundary.PositiveHeight = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    boundary.NegativeHeight = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    break;
                case MultiplayerObjectBoundaryShape.Box:
                    boundary.WidthRadius = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    boundary.BoxLength = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    boundary.PositiveHeight = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    boundary.NegativeHeight = stream.ReadQuantizedReal(0.0f, 200.0f, 11, false, true);
                    break;
            }

            return boundary;
        }

        public static void Encode(BitStreamWriter stream, ReachMultiplayerObjectBoundary boundary) 
        {
            // TODO: Implement
        }
    }
}
