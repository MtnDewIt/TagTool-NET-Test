using System;
using TagTool.BlamFile.Chunks.Metadata;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;
using static TagTool.BlamFile.Chunks.MapVariants.VariantObjectDatum.VariantMultiplayerProperties;

namespace TagTool.BlamFile.Chunks.MapVariants
{
    [TagStructure(Size = 0xE090)]
    public class MapVariant : TagStructure
    {
        public ContentItemMetadata Metadata;
        public short VariantVersion;
        public short ScenarioObjectCount;
        public short VariantObjectCount;
        public short PlaceableQuotaCount;
        public int MapId = -1;
        public RealRectangle3d WorldBounds;
        public GameEngineSubType RuntimeEngineSubType = GameEngineSubType.All;
        public float MaximumBudget;
        public float SpentBudget;
        public bool HelpersEnabled;
        public bool BuiltIn;
        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding1;
        public uint OriginalMapRSASignatureHash;

        [TagField(Length = 640)]
        public VariantObjectDatum[] Objects;

        [TagField(Length = 14, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        [TagField(Length = 15, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline449175)]
        [TagField(Length = 16, MinVersion = CacheVersion.HaloOnline498295, MaxVersion = CacheVersion.HaloOnline700123)]
        public short[] ObjectTypeStartIndex;

        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline449175)]
        public byte[] Padding2;

        [TagField(Length = 256)]
        public VariantObjectQuota[] Quotas;

        [TagField(Length = 80)]
        public int[] SimulationEntities;

        [TagField(Length = 0x4, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.Halo3Retail)]
        public byte[] Padding3;

        public static MapVariant Decode(BitStream stream) 
        {
            var mapVariant = new MapVariant();

            mapVariant.Metadata = ContentItemMetadata.Decode(stream);
            mapVariant.VariantVersion = (short)stream.ReadUnsigned(8);
            mapVariant.OriginalMapRSASignatureHash = stream.ReadUnsigned(32);
            mapVariant.ScenarioObjectCount = (short)stream.ReadUnsigned(10);
            mapVariant.VariantObjectCount = (short)stream.ReadUnsigned(10);
            mapVariant.PlaceableQuotaCount = (short)stream.ReadUnsigned(9);
            mapVariant.MapId = (int)stream.ReadUnsigned(32);
            mapVariant.BuiltIn = stream.ReadBool();
            mapVariant.WorldBounds = stream.ReadRealRectangle3d(32);
            mapVariant.RuntimeEngineSubType = (GameEngineSubType)stream.ReadUnsigned(4);
            mapVariant.MaximumBudget = stream.ReadFloat(32);
            mapVariant.SpentBudget = stream.ReadFloat(32);

            mapVariant.Objects = new VariantObjectDatum[mapVariant.VariantObjectCount];
            for (int i = 0; i < mapVariant.VariantObjectCount; i++)
            {
                mapVariant.Objects[i] = VariantObjectDatum.Decode(stream, mapVariant.WorldBounds);
            }

            mapVariant.ObjectTypeStartIndex = new short[14];
            for (int i = 0; i < mapVariant.ObjectTypeStartIndex.Length; i++)
            {
                mapVariant.ObjectTypeStartIndex[i] = (short)stream.ReadUnsigned(9);
            }

            mapVariant.Quotas = new VariantObjectQuota[mapVariant.PlaceableQuotaCount];
            for (int i = 0; i < mapVariant.PlaceableQuotaCount; i++)
            {
                mapVariant.Quotas[i] = VariantObjectQuota.Decode(stream);
            }

            return mapVariant;
        }

        public static void Encode(BitStream stream, MapVariant mapVariant) 
        {
            // TODO: Implement
        }
    }

    [TagStructure(Size = 0x54)]
    public class VariantObjectDatum : TagStructure
    {
        public VariantObjectPlacementFlags Flags;
        public short ReuseTimeout;
        public int ObjectIndex = -1;
        public int HelperObjectIndex = -1;
        public int QuotaIndex = -1;
        public RealPoint3d Position;
        public RealVector3d Forward;
        public RealVector3d Up;
        public ObjectIdentifier ParentObject;
        public VariantMultiplayerProperties Properties;

        [Flags]
        public enum VariantObjectPlacementFlags : ushort
        {
            None = 0,
            OccupiedSlot = 1 << 0,            // not an empty slot
            Edited = 1 << 1,                  // set whenever the object has been edited in any way
            RuntimeIgnored = 1 << 2,          // hack for globally placed scenario objects
            ScenarioObject = 1 << 3,          // set for all scenario placements
            Unused4 = 1 << 4,                 // unused
            ScenarioObjectRemoved = 1 << 5,   // scenario object has been deleted
            RuntimeSandboxSuspended = 1 << 6, // object has been suspended by the sandbox engine
            RuntimeCandyMonitored = 1 << 7,   // object is being candy monitored
            SpawnsRelative = 1 << 8,          // position and axes are relative to the parent
            SpawnsAttached = 1 << 9           // object will be attached to the parent (node 0)
        }

        [TagStructure(Size = 0x18)]
        public class VariantMultiplayerProperties : TagStructure
        {
            public GameEngineSubTypeFlags EngineFlags = GameEngineSubTypeFlags.All;
            public VariantPlacementFlags Flags;
            public MultiplayerTeamDesignator Team = MultiplayerTeamDesignator.Neutral;
            public byte SharedStorage; // spare clips, teleporter channel, spawn order, reforge material
            public byte SpawnTime;
            public MultiplayerObjectType Type;
            public MultiplayerObjectBoundary Boundary = new MultiplayerObjectBoundary();

            [Flags]
            public enum VariantPlacementFlags : byte
            {
                None = 0,
                UniqueSpawn = 1 << 0,
                NotInitiallyPlaced = 1 << 1,
                Symmetric = 1 << 2,
                Asymmetric = 1 << 3
            }

            [TagStructure(Size = 0x11)]
            public class MultiplayerObjectBoundary : TagStructure
            {
                public MultiplayerObjectBoundaryShape Type;
                public float WidthRadius;
                public float BoxLength;
                public float PositiveHeight;
                public float NegativeHeight;
            }
        }

        public static VariantObjectDatum Decode(BitStream stream, RealRectangle3d worldBounds)
        {
            var objectDatum = new VariantObjectDatum();

            if (!stream.ReadBool())
            {
                return objectDatum;
            }

            objectDatum.Flags = (VariantObjectPlacementFlags)stream.ReadUnsigned(16);
            objectDatum.QuotaIndex = stream.ReadSignedInteger(32);

            // TODO: Set default values for ObjectIdentifier
            objectDatum.ParentObject = new ObjectIdentifier();

            if (stream.ReadBool())
            {
                objectDatum.ParentObject.UniqueId = new DatumHandle(stream.ReadUnsigned(32));
                objectDatum.ParentObject.OriginBspIndex = (short)stream.ReadUnsigned(16);
                objectDatum.ParentObject.Type = new GameObjectType8() { Halo3Retail = (GameObjectTypeHalo3Retail)stream.ReadUnsigned(8) };
                objectDatum.ParentObject.Source = (ObjectIdentifier.SourceValue)stream.ReadUnsigned(8);
            }

            if (stream.ReadBool())
            {
                SimulationEncoding.SimulationReadQuantizedPosition(stream, out objectDatum.Position, 16, worldBounds);
                stream.ReadAxis(out objectDatum.Forward, out objectDatum.Up);

                objectDatum.Properties = new VariantMultiplayerProperties
                {
                    Type = (MultiplayerObjectType)stream.ReadSignedInteger(8),
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

                switch (objectDatum.Properties.Boundary.Type)
                {
                    case MultiplayerObjectBoundaryShape.Sphere:
                        objectDatum.Properties.Boundary.WidthRadius = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        break;
                    case MultiplayerObjectBoundaryShape.Cylinder:
                        objectDatum.Properties.Boundary.WidthRadius = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        objectDatum.Properties.Boundary.BoxLength = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        objectDatum.Properties.Boundary.PositiveHeight = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        break;
                    case MultiplayerObjectBoundaryShape.Box:
                        objectDatum.Properties.Boundary.WidthRadius = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        objectDatum.Properties.Boundary.BoxLength = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        objectDatum.Properties.Boundary.PositiveHeight = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        objectDatum.Properties.Boundary.NegativeHeight = stream.ReadQuantizedReal(0.0f, 60.0f, 16, false, true);
                        break;
                }
            }

            return objectDatum;
        }

        public static void Encode(BitStream stream, VariantObjectDatum objectDatum)
        {
            // TODO: Implement
        }
    }

    [TagStructure(Size = 0xC)]
    public class VariantObjectQuota : TagStructure
    {
        public int ObjectDefinitionIndex = -1;
        public byte MinimumCount;
        public byte MaximumCount;
        public byte PlacedOnMap;
        public sbyte MaxAllowed = -1;
        public float Cost = -1.0f;

        public static VariantObjectQuota Decode(BitStream stream)
        {
            var quotaDatum = new VariantObjectQuota();

            quotaDatum.ObjectDefinitionIndex = (int)stream.ReadUnsigned(32);
            quotaDatum.MinimumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.MaximumCount = (byte)stream.ReadUnsigned(8);
            quotaDatum.PlacedOnMap = (byte)stream.ReadUnsigned(8);
            quotaDatum.MaxAllowed = (sbyte)stream.ReadSignedInteger(8);
            quotaDatum.Cost = stream.ReadFloat(32);

            return quotaDatum;
        }

        public static void Encode(BitStream stream, VariantObjectQuota objectQuota)
        {
            // TODO: Implement
        }
    }
}
