using System;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    public enum VariantDataGameEngineSubType : int
    {
        CaptureTheFlag,
        Slayer,
        Oddball,
        KingOfTheHill,
        Juggernaut,
        Territories,
        Assault,
        Vip,
        Infection,
        TargetTraining,
        All,
    }

    [Flags]
    public enum VariantDataObjectPlacementFlags : ushort
    {
        OccupiedSlot = 1 << 0,
        Edited = 1 << 1,
        RuntimeIgnored = 1 << 2,
        ScenarioObject = 1 << 3,
        Unused4 = 1 << 4,
        ScenarioObjectRemoved = 1 << 5,
        RuntimeSandboxSuspended = 1 << 6,
        RuntimeCandyMonitored = 1 << 7,
        SpawnsRelative = 1 << 8,
        SpawnsAttached = 1 << 9,
    }

    [Flags]
    public enum VariantDataGameEngineSubTypeFlags : ushort
    {
        None = 0,
        CaptureTheFlag = 1 << 0,
        Slayer = 1 << 1,
        Oddball = 1 << 2,
        KingOfTheHill = 1 << 3,
        Juggernaut = 1 << 4,
        Territories = 1 << 5,
        Assault = 1 << 6,
        Vip = 1 << 7,
        Infection = 1 << 8,
        TargetTraining = 1 << 9,
        All = 0x3FF,
    }

    [Flags]
    public enum VariantDataPlacementFlags : byte
    {
        None = 0,
        UniqueSpawn = 1 << 0,
        NotInitiallyPlaced = 1 << 1,
        Symmetric = 1 << 2,
        Asymmetric = 1 << 3,
    }

    public enum VariantDataMultiplayerTeamDesignator : sbyte
    {
        None = -1,
        Red,
        Blue,
        Green,
        Orange,
        Purple,
        Yellow,
        Brown,
        Pink,
        Neutral,
    }

    public enum VariantDataMultiplayerTeleporterChannel : byte 
    {
        Alpha,
        Bravo,
        Charlie,
        Delta,
        Echo,
        Foxtrot,
        Golf,
        Hotel,
        India,
        Juliet,
        Kilo,
        Lima,
        Mike,
        November,
        Oscar,
        Papa,
        Quebec,
        Romeo,
        Sierra,
        Tango,
        Uniform,
        Victor,
        Whiskey,
        Xray,
        Yankee,
        Zulu,
    }

    public enum VariantDataMultiplayerObjectType : sbyte
    {
        None = -1,
        Ordinary,
        Weapon,
        Grenade,
        Projectile,
        Powerup,
        Equipment,
        LightLandVehicle,
        HeavyLandVehicle,
        FlyingVehicle,
        TeleporterTwoWay,
        TeleporterSender,
        TeleporterReceiver,
        PlayerSpawnLocation,
        PlayerRespawnZone,
        OddballSpawnLocation,
        CtfFlagSpawnLocation,
        TargetSpawnLocation,
        CtfFlagReturnArea,
        KothHillArea,
        InfectionSafeArea,
        TerritoryArea,
        VipInfluenceArea,
        VipDestinationZone,
        JuggernautDestinationZone,
    };

    public enum VariantDataMultiplayerObjectBoundaryShape : sbyte
    {
        None,
        Sphere,
        Cylinder,
        Box,
    }

    [TagStructure(Size = 0x11)]
    public class MultiplayerObjectBoundary : TagStructure
    {
        [TagField(EnumType = typeof(sbyte))]
        public VariantDataMultiplayerObjectBoundaryShape Type;

        public float WidthRadius;
        public float BoxLength;
        public float PositiveHeight;
        public float NegativeHeight;
    }

    [TagStructure(Size = 0x18)]
    public class VariantMultiplayerProperties : TagStructure
    {
        public VariantDataGameEngineSubTypeFlags EngineFlags = VariantDataGameEngineSubTypeFlags.All;
        public VariantDataPlacementFlags Flags;
        public VariantDataMultiplayerTeamDesignator Team = VariantDataMultiplayerTeamDesignator.Neutral;

        // SharedStorage takes the union of the following values:
        // public byte SpareClips;
        // public VariantDataMultiplayerTeleporterChannel TeleporterChannel;
        // public byte SpawnOrder;
        // public byte ReforgeMaterial;

        public byte SharedStorage;

        public byte SpawnTime;
        public VariantDataMultiplayerObjectType Type;
        public MultiplayerObjectBoundary Boundary = new MultiplayerObjectBoundary();
    }

    [TagStructure(Size = 0x8)]
    public class ObjectDataIdentifier : TagStructure
    {
        public DatumHandle UniqueID = DatumHandle.None;
        public short BspIndex = -1;
        public sbyte Type = -1;
        public sbyte Source = -1;
    }

    [TagStructure(Size = 0x54)]
    public class VariantDataObjectDatum : TagStructure
    {
        public VariantDataObjectPlacementFlags Flags;
        public short RuntimeRemovalTimer;
        public int RuntimeObjectIndex = -1;
        public int RuntimeEditorObjectIndex = -1;
        public int QuotaIndex = -1;
        public RealPoint3d Position;
        public RealVector3d Forward;
        public RealVector3d Up;
        public ObjectDataIdentifier ParentObject;
        public VariantMultiplayerProperties Properties;
    }

    [TagStructure(Size = 0xC)]
    public class VariantDataObjectQuota : TagStructure
    {
        [TagField(Platform = CachePlatform.Original)]
        public int ObjectDefinitionIndex = -1;

        public byte MinimumCount;
        public byte MaximumCount;
        public byte PlacedOnMap;
        public byte MaxAllowed = 255;
        public float Cost = -1.0f;
    }

    [TagStructure(Size = 0xE090)]
    public class MapVariantData : TagStructure
    {
        public ContentItemMetadata Metadata;
        public short VariantVersion;
        public short ScenarioObjectCount;
        public short VariantObjectCount;
        public short PlaceableQuotaCount;
        public int MapId = -1;
        public RealRectangle3d WorldBounds;
        public VariantDataGameEngineSubType RuntimeEngineSubType = VariantDataGameEngineSubType.All;
        public float MaximumBudget;
        public float SpentBudget;
        public bool RuntimeShowHelpers;
        public bool BuiltIn;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;

        public uint MapVariantChecksum;

        [TagField(Length = 640)]
        public VariantDataObjectDatum[] Objects;

        [TagField(Length = 14, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 16, MinVersion = CacheVersion.Halo3ODST)]
        public short[] ObjectTypeStartIndex;

        [TagField(Length = 0x100)]
        public VariantDataObjectQuota[] Quotas;

        [TagField(Length = 31)]
        public int[] SimulationEntities;

        [TagField(Length = 0xC4, Flags = TagFieldFlags.Padding)]
        public byte[] Padding2;
    }
}