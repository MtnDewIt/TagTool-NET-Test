using TagTool.Cache;
using TagTool.Common;
using TagTool.Serialization;
using System;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "object", Tag = "obje", Size = 0xF8, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Name = "object", Tag = "obje", Size = 0x104, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "object", Tag = "obje", Size = 0x120, MinVersion = CacheVersion.HaloOnline106708)]
    public abstract class GameObject
    {
        public GameObjectType ObjectType;
        public GameObjectFlags ObjectFlags;
        public float BoundingRadius;
        public RealPoint3d BoundingOffset;
        public float AccelerationScale;
        public LightmapShadowModeValue LightmapShadowMode;
        public SweetenerSizeValue SweetenerSize;
        public WaterDensityValue WaterDensity;
        public int RuntimeFlags;
        public float DynamicLightSphereRadius;
        public RealPoint3d DynamicLightSphereOffset;
        public StringId DefaultModelVariant;
        public CachedTagInstance Model;

        [TagField(MaxVersion = CacheVersion.HaloOnline449175)]
        public CachedTagInstance CrateObject;

        public CachedTagInstance CollisionDamage;
        public List<EarlyMoverProperty> EarlyMoverProperties;
        public CachedTagInstance CreationEffect;
        public CachedTagInstance MaterialEffects;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public CachedTagInstance ArmorSounds;

        public CachedTagInstance MeleeImpact;
        public List<AiProperty> AiProperties;
        public List<Function> Functions;
        public short HudTextMessageIndex;

        [TagField(Padding = true, Length = 2)]
        public byte[] Unused1;

        public List<Attachment> Attachments;
        public List<TagReferenceBlock> Widgets;
        public List<ChangeColor> ChangeColors;

        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public List<PredictedResource> PredictedResources;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public List<NodeMap> NodeMaps;

        public List<MultiplayerObjectProperty> MultiplayerObjectProperties;

        [TagField(MinVersion = CacheVersion.HaloOnline498295)]
        public CachedTagInstance SimulationInterpolation;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public List<TagReferenceBlock> RevivingEquipment;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public List<ModelObjectDatum> ModelObjectData;
        
        public enum LightmapShadowModeValue : short
        {
            Default,
            Never,
            Always,
            Blur
        }

        public enum MultipleAirprobeModeValue : sbyte
        {
            Default,
            Always
        }

        public enum SweetenerSizeValue : sbyte
        {
            Small,
            Medium,
            Large
        }

        public enum WaterDensityValue : sbyte
        {
            Default,
            Least,
            Some,
            Equal,
            More,
            MoreStill,
            LotsMore
        }

        [TagStructure(Size = 0x28)]
        public class EarlyMoverProperty
        {
            [TagField(Label = true)]
            public StringId Name;
            public Bounds<float> XBounds;
            public Bounds<float> YBounds;
            public Bounds<float> ZBounds;
            public RealEulerAngles3d Angles;
        }

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xC, MinVersion = CacheVersion.Halo3ODST)]
        public class AiProperty
        {
            public FlagsValue Flags;
            public StringId AiTypeName;
            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public uint Unknown;
            public ObjectSizeValue Size;
            public AiDistanceValue LeapJumpSpeed;

            [Flags]
            public enum FlagsValue : int
            {
                None = 0,
                DestroyableCover = 1 << 0,
                PathfindingIgnoreWhenDead = 1 << 1,
                DynamicCover = 1 << 2
            }
        }

        public enum ObjectSizeValue : short
        {
            Default,
            Tiny,
            Small,
            Medium,
            Large,
            Huge,
            Immobile
        }

        public enum AiDistanceValue : short
        {
            None,
            Down,
            Step,
            Crouch,
            Stand,
            Storey,
            Tower,
            Infinite
        }

        [TagStructure(Size = 0x2C)]
        public class Function
        {
            public FlagsValue Flags;
            public StringId ImportName;
            public StringId ExportName;
            public StringId TurnOffWith;
            public float MinimumValue;
            public TagFunction DefaultFunction = new TagFunction { Data = new byte[0] };
            public StringId ScaleBy;

            [Flags]
            public enum FlagsValue : int
            {
                None = 0,
                Invert = 1 << 0,
                MappingDoesNotControlsActive = 1 << 1,
                AlwaysActive = 1 << 2,
                RandomTimeOffset = 1 << 3
            }
        }

        [TagStructure(Size = 0x20, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x24, MinVersion = CacheVersion.Halo3ODST)]
        public class Attachment
        {
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public AtlasFlagsValue AtlasFlags;
            [TagField(Label = true)]
            public CachedTagInstance Attachment2;
            public StringId Marker;
            public ChangeColorValue ChangeColor;
            public short Unknown;
            public StringId PrimaryScale;
            public StringId SecondaryScale;

            [Flags]
            public enum AtlasFlagsValue : int
            {
                None = 0,
                GameplayVisionMode = 1 << 0,
                TheaterVisionMode = 1 << 1
            }

            public enum ChangeColorValue : short
            {
                None,
                Primary,
                Secondary,
                Tertiary,
                Quaternary
            }
        }
        
        [TagStructure(Size = 0x18)]
        public class ChangeColor
        {
            public List<InitialPermutation> InitialPermutations;
            public List<Function> Functions;

            [TagStructure(Size = 0x20)]
            public class InitialPermutation
            {
                public float Weight;
                public RealRgbColor ColorLowerBound;
                public RealRgbColor ColorUpperBound;
                [TagField(Label = true)]
                public StringId VariantName;
            }

            [TagStructure(Size = 0x20)]
            public class Function
            {
                public ScaleFlagsValue ScaleFlags;
                public RealRgbColor ColorLowerBound;
                public RealRgbColor ColorUpperBound;
                public StringId DarkenBy;
                public StringId ScaleBy;

                [Flags]
                public enum ScaleFlagsValue : int
                {
                    None = 0,
                    BlendInHsv = 1 << 0,
                    MoreColors = 1 << 1
                }
            }
        }

        [TagStructure(Size = 0x8)]
        public class PredictedResource
        {
            public short Type;
            public short ResourceIndex;
            [TagField(Short = true)]
            public CachedTagInstance TagIndex;
        }

        [TagStructure(Size = 0x1)]
        public class NodeMap
        {
            public sbyte TargetNode;
        }

        [TagStructure(Size = 0xC4)]
        public class MultiplayerObjectProperty
        {
            public EngineFlagsValue EngineFlags;
            public ObjectTypeValue ObjectType;
            public byte TeleporterFlags;
            public sbyte Unknown;
            public byte Flags;
            public ObjectShapeValue Shape;
            public SpawnTimerModeValue SpawnTimerMode;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public float RadiusWidth;
            public float Length;
            public float Top;
            public float Bottom;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public int Unknown5;
            public int Unknown6;
            public CachedTagInstance ChildObject;
            public int Unknown7;
            public CachedTagInstance ShapeShader;
            public CachedTagInstance UnknownShader;
            public CachedTagInstance Unknown8;
            public CachedTagInstance Unknown9;
            public CachedTagInstance Unknown10;
            public CachedTagInstance Unknown11;
            public CachedTagInstance Unknown12;
            public CachedTagInstance Unknown13;
            public enum EngineFlagsValue : ushort
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
                Bit9 = 1 << 9
            }
        }

        public enum ObjectTypeValue : sbyte
        {
            Ordinary,
            Weapon,
            Grenade,
            Projectile,
            Powerup,
            Equipment,
            LightLandVehicle,
            HeavyLandVehicle,
            FlyingVehicle,
            Teleporter2way,
            TeleporterSender,
            TeleporterReceiver,
            PlayerSpawnLocation,
            PlayerRespawnZone,
            HoldSpawnObjective,
            CaptureSpawnObjective,
            HoldDestinationObjective,
            CaptureDestinationObjective,
            HillObjective,
            InfectionHavenObjective,
            TerritoryObjective,
            VipBoundaryObjective,
            VipDestinationObjective,
            JuggernautDestinationObjective
        }

        public enum SpawnTimerModeValue : sbyte
        {
            DefaultOne,
            Multiple
        }

        public enum ObjectShapeValue : sbyte
        {
            None,
            Sphere,
            Cylinder,
            Box
        }

        [TagStructure(Size = 0x14)]
        public class ModelObjectDatum
        {
            public TypeValue Type;
            public short Unknown;
            public RealPoint3d Offset;
            public float Radius;
            public enum TypeValue : short
            {
                NotSet,
                UserDefined,
                AutoGenerated,
            }
        }
    }
    
    public enum GameObjectTypeHalo3Beta : sbyte
    {
        None = -1,
        Biped,
        Vehicle,
        Weapon,
        Equipment,
        Terminal,
        Projectile,
        Scenery,
        Machine,
        Control,
        LightFixture,
        SoundScenery,
        Crate,
        Creature,
        Giant,
        EffectScenery
    }

    public enum GameObjectTypeHalo3Retail : sbyte
    {
        None = -1,
        Biped,
        Vehicle,
        Weapon,
        Equipment,
        Terminal,
        Projectile,
        Scenery,
        Machine,
        Control,
        SoundScenery,
        Crate,
        Creature,
        Giant,
        EffectScenery
    }

    public enum GameObjectTypeHalo3ODST : sbyte
    {
        None = -1,
        Biped,
        Vehicle,
        Weapon,
        Equipment,
        AlternateRealityDevice,
        Terminal,
        Projectile,
        Scenery,
        Machine,
        Control,
        SoundScenery,
        Crate,
        Creature,
        Giant,
        EffectScenery
    }

    public enum GameObjectTypeHaloOnline : sbyte
    {
        None = -1,
        Biped,
        Vehicle,
        Weapon,
        Armor,
        Equipment,
        AlternateRealityDevice,
        Terminal,
        Projectile,
        Scenery,
        Machine,
        Control,
        SoundScenery,
        Crate,
        Creature,
        Giant,
        EffectScenery
    }

    [TagStructure(Size = 0x2)]
    public class GameObjectType
    {
        [TagField(Padding = true, Length = 1, MaxVersion = CacheVersion.Halo3ODST)]
        public byte[] Unused1;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        public GameObjectTypeHalo3Retail Halo3Retail;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline449175)]
        public GameObjectTypeHalo3ODST Halo3ODST;

        [TagField(MinVersion = CacheVersion.HaloOnline498295)]
        public GameObjectTypeHaloOnline HaloOnline;

        [TagField(Padding = true, Length = 1, MinVersion = CacheVersion.HaloOnline106708)]
        public byte[] Unused2;
    }

    [TagStructure(Size = 0x1)]
    public class ScenarioObjectType
    {
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        public GameObjectTypeHalo3Retail Halo3Retail;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline449175)]
        public GameObjectTypeHalo3ODST Halo3ODST;

        [TagField(MinVersion = CacheVersion.HaloOnline498295)]
        public GameObjectTypeHaloOnline HaloOnline;
    }

    [Flags]
    public enum GameObjectFlags : ushort
    {
        None = 0,
        DoesNotCastShadow = 1 << 0,
        SearchCardinalDirectionMaps = 1 << 1,
        Bit2 = 1 << 2,
        NotAPathfindingObstacle = 1 << 3,
        ExtensionOfParent = 1 << 4,
        DoesNotCauseCollisionDamage = 1 << 5,
        EarlyMover = 1 << 6,
        EarlyMoverLocalizedPhysics = 1 << 7,
        UseStaticMassiveLightmapSample = 1 << 8,
        ObjectScalesAttachments = 1 << 9,
        InheritsPlayersAppearance = 1 << 10,
        DeadBipedsCantLocalize = 1 << 11,
        AttachToClustersByDynamicSphere = 1 << 12,
        EffectsDoNotSpawnObjectsInMultiplayer = 1 << 13,
        Bit14 = 1 << 14,
        Bit15 = 1 << 15
    }
}
