using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    [Flags]
    public enum MiscellaneousOptionsFlags : byte
    {
        None = 0,
        TeamsEnabled = 1 << 0,
        RoundResetPlayers = 1 << 1,
        RoundResetMap = 1 << 2,
        SpectatingEnabled = 1 << 3,
    }

    [TagStructure(Size = 0x4)]
    public class MiscellaneousOptions
    {
        public MiscellaneousOptionsFlags Flags;
        public byte TimeLimit;
        public byte NumberOfRounds;
        public byte EarlyVictoryWinCount;
    }

    [Flags]
    public enum RespawnOptionsFlags : byte
    {
        InheritRespawnTime = 0,
        RespawnWithTeammate,
        RespawnAtLocation,
        RespawnOnKills,
        AutoRespawnDisabled,
    }

    public enum DamageResistancePercentage : byte
    {
        Unchanged = 0,
        Percent_10,
        Percent_50,
        Percent_90,
        Percent_100,
        Percent_110,
        Percent_150,
        Percent_200,
        Percent_300,
        Percent_500,
        Percent_1000,
        Percent_2000,
        Invulnerable,
        Percent_1500,
        Percent_3000,
        Invincible,
    }

    public enum ShieldRechargeRatePercentage : byte
    {
        Unchanged = 0,
        Percent_Minus_25,
        Percent_Minus_10,
        Percent_Minus_5,
        Percent_0,
        Percent_50,
        Percent_90,
        Percent_100,
        Percent_110,
        Percent_200,
    }

    public enum ShieldVampirismPercentage : byte
    {
        Unchanged = 0,
        Percent_0,
        Percent_10,
        Percent_25,
        Percent_50,
        Percent_100,
    }

    public enum HeadshotImmunity : byte
    {
        Unchanged = 0,
        Immune,
        NotImmune,
    }

    public enum ShieldMultiplier : byte
    {
        Unchanged = 0,
        Shield_0X,
        Shield_1X,
        Shield_2X,
        Shield_3X,
        Shield_4X,
    }

    [TagStructure(Size = 0x5, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
    [TagStructure(Size = 0x8, MinVersion = CacheVersion.HaloOnlineEDLegacy)]
    public class PlayerShieldVitalityTraits
    {
        public DamageResistancePercentage DamageResistance;
        public ShieldRechargeRatePercentage ShieldRechargeRate;
        public ShieldVampirismPercentage ShieldVampirism;
        public HeadshotImmunity HeadshotImmunity;
        public ShieldMultiplier ShieldMultiplier;

        [TagField(Flags = TagFieldFlags.Padding, Length = 3, MinVersion = CacheVersion.HaloOnlineEDLegacy, MaxVersion = CacheVersion.HaloOnlineEDLegacy)]
        public byte[] Padding1 = new byte[3];
    }

    [Flags]
    public enum ExtendedTraits : byte
    {
        None = 0,
        SprintEnabled = 1 << 0,
        SprintDisabled  = 1 << 1,
        ThirdPersonEnabled = 1 << 2,
        ThirdPersonDisabled = 1 << 3,
    }

    [TagStructure(Size = 0x3)]
    public class PlayerExtendedTraits
    {
        public byte PlayerCharacterValue;
        public ExtendedTraits ExtendedTraits;
        public byte Gap2;
    }

    public enum WeaponGrenadeCount : short
    {
        Unchanged,
        MapDefault,
        None,
    }

    public enum DamageModifierPercentage : byte
    {
        Unchanged = 0,
        Percent_0,
        Percent_25,
        Percent_50,
        Percent_75,
        Percent_90,
        Percent_100,
        Percent_110,
        Percent_125,
        Percent_150,
        Percent_200,
        Percent_300,
        Fatal,
    }

    public enum RechargingGrenadesSetting : byte
    {
        Unchanged = 0,
        Enabled,
        Disabled,
    }

    public enum InfiniteAmmoSetting : byte
    {
        Unchanged = 0,
        Disabled,
        Enabled,
        BottomlessClip,
    }

    public enum WeaponPickupSetting : byte
    {
        Unchanged = 0,
        Allowed,
        Disallowed,
    }

    [TagStructure(Size = 0x8)]
    public class PlayerWeaponTraits
    {
        public WeaponGrenadeCount InitialGrenadeCount;
        public byte PrimaryWeaponIndex;
        public byte SecondaryWeaponIndex;
        public DamageModifierPercentage DamageModifier;
        public RechargingGrenadesSetting RechargingGrenades;
        public InfiniteAmmoSetting InfiniteAmmo;
        public WeaponPickupSetting WeaponPickup;
    }

    public enum PlayerSpeedSetting : byte
    {
        Unchanged = 0,
        Percent_25,
        Percent_50,
        Percent_75,
        Percent_90,
        Percent_100,
        Percent_110,
        Percent_125,
        Percent_150,
        Percent_200,
        Percent_300,
    }

    public enum PlayerGravitySetting : byte
    {
        Unchanged = 0,
        Percent_50,
        Percent_75,
        Percent_100,
        Percent_150,
        Percent_200,
        Percent_0,
        Percent_15,
        Percent_25,
        Percent_35,
        Percent_125,
    }

    public enum PlayerVehicleUsage : byte
    {
        Unchanged = 0,
        None,
        PassengerOnly,
        Full,
    }

    [TagStructure(Size = 0x4)]
    public class PlayerMovementTraits
    {
        public PlayerSpeedSetting PlayerSpeed;
        public PlayerGravitySetting PlayerGravity;
        public PlayerVehicleUsage VehicleUsage;

        [TagField(Flags = TagFieldFlags.Padding, Length = 1)]
        public byte[] Padding1 = new byte[1];
    }

    public enum ActiveCamoSetting : byte
    {
        Unchanged = 0,
        Off,
        Poor,
        Good,
        Invisible,
    }

    public enum WaypointSetting : byte
    {
        Unchanged = 0,
        Off,
        Allies,
        All,
        None,
        NoneTeamOnly,
    }

    public enum PlayerSizeSetting : byte 
    {
        Unchanged = 0,
        Default,
        Percent_10,
        Percent_15,
        Percent_25,
        Percent_35,
        Percent_50,
        Percent_75,
        Percent_100,
        Percent_125,
        Percent_150,
        Percent_200,
        Percent_350,
        Percent_500,
        Percent_750,
        Percent_1000,
        Percent_1500,
        Percent_2000,
        Percent_3000,
    }

    public enum AuraSetting : byte
    {
        Unchanged = 0,
        Disabled,
        Team,
        Black,
        White,
    }

    public enum ForcedColorChangeSetting : byte
    {
        Unchanged = 0,
        Off,
        Red,
        Blue,
        Green,
        Orange,
        Purple,
        Gold,
        Brown,
        Pink,
        White,
        Black,
        Zombie,
    }

    [TagStructure(Size = 0x4)]
    public class PlayerAppearanceTraits
    {
        public ActiveCamoSetting ActiveCamo;
        public WaypointSetting Waypoint;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineEDLegacy)]
        public PlayerSizeSetting PlayerSize;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
        public AuraSetting Aura;

        public ForcedColorChangeSetting ForcedColorChange;
    }

    public enum MotionTrackerSetting : short
    {
        Unchanged = 0,
        Off,
        FriendlyOnly,
        Normal,
        Always,
    }

    public enum MotionTrackerRangeSetting : short
    {
        Unchanged = 0,
        Meters_10,
        Meters_15,
        Meters_25,
        Meters_50,
        Meters_75,
        Meters_100,
        Meters_150,
    }

    [TagStructure(Size = 0x4)]
    public class PlayerSensorTraits
    {
        public MotionTrackerSetting MotionTracker;
        public MotionTrackerRangeSetting MotionTrackerRange;
    }

    [TagStructure(Size = 0x1C)]
    public class PlayerTraits
    {
        public PlayerShieldVitalityTraits ShieldVitalityTraits;

        [TagField(Version = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        public PlayerExtendedTraits ExtendedTraits;

        public PlayerWeaponTraits WeaponTraits;
        public PlayerMovementTraits MovementTraits;
        public PlayerAppearanceTraits AppearanceTraits;
        public PlayerSensorTraits SensorTraits;
    }

    [TagStructure(Size = 0x28)]
    public class RespawnOptions
    {
        public RespawnOptionsFlags Flags;
        public byte LivesPerRound;
        public byte TeamLivesPerRound;
        public byte RespawnTime;
        public byte SuicidePenalty;
        public byte BetrayalPenalty;
        public byte UnknownPenalty;
        public byte RespawnGrowth;
        public byte RespawnPlayerTraitsDuration;

        [TagField(Flags = TagFieldFlags.Padding, Length = 3)]
        public byte[] Padding1 = new byte[3];

        public PlayerTraits RespawnPlayerTraits;
    }

    [Flags]
    public enum SocialOptionsFlags : short
    {
        None = 0,
        FriendlyFireEnabled  = 1 << 0,
        BetrayalBootingEnabled = 1 << 1,
        SpartansVsElitesEnabled = 1 << 2,
        EnemyVoiceEnabled = 1 << 3,
        OpenChannelVoiceEnabled = 1 << 4,
        DeadPlayerVoiceEnabled = 1 << 5,
    }

    public enum TeamChangingFlags : short 
    {
        None = 0,
        TeamChangingEnabled,
        TeamChangingBalancingOnlyEnabled,
    }

    [TagStructure(Size = 0x4)]
    public class SocialOptions
    {
        public SocialOptionsFlags Flags;
        public TeamChangingFlags TeamChanging;
    }

    [Flags]
    public enum MapOverrideOptionsFlags : int
    {
        None = 0,
        GrenadesOnMap = 1 << 0,
        IndestructibleVehicles = 1 << 1,
    }

    [TagStructure(Size = 0x7C)]
    public class MapOverrideOptions
    {
        public MapOverrideOptionsFlags Flags;
        public PlayerTraits BasePlayerTraits;
        public short WeaponSetIndex;
        public short VehicleSetIndex;
        public PlayerTraits RedPowerupTraits;
        public PlayerTraits BluePowerupTraits;
        public PlayerTraits YellowPowerupTraits;
        public byte RedPowerupDuration;
        public byte BluePowerupDuration;
        public byte YellowPowerupDuration;

        [TagField(Flags = TagFieldFlags.Padding, Length = 1)]
        public byte[] Padding1 = new byte[1];
    }

    [Flags]
    public enum BaseVariantFlags : short
    {
        BuiltIn = 0,
    }

    public enum TeamScoringMethodFlag : short 
    {
        SumOfTeam = 0,
        MinimumScore,
        MaximumScore,
        TeamControl,
    }

    [TagStructure(Size = 0x1D0)]
    public class GameVariantBase : TagStructure
    {
        public long VariantChecksum;

        [TagField(Length = 32)]
        public string VariantName;

        public BlfContentItemMetadata Metadata;
        public MiscellaneousOptions MiscellaneousOptions;
        public RespawnOptions RespawnOptions;
        public SocialOptions SocialOptions;
        public MapOverrideOptions MapOverrideOptions;
        public BaseVariantFlags BaseFlags;
        public TeamScoringMethodFlag TeamScoringMethod;
    }
}