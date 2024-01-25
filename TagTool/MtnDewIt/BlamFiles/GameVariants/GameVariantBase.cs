using System;
using TagTool.Tags;

namespace TagTool.MtnDewIt.BlamFiles
{
    [Flags]
    public enum MiscellaneousOptionsFlags : byte
    {
        TeamsEnabled = 0,
        RoundResetPlayers,
        RoundResetMap,
    }

    [TagStructure(Size = 0x4)]
    public class MiscellaneousOptions
    {
        public MiscellaneousOptionsFlags Flags;
        public byte RoundTimeLimitMinutes;
        public byte RoundLimit;
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

    [TagStructure(Size = 0x5)]
    public class PlayerShieldVitalityTraits
    {
        public DamageResistancePercentage DamageResistance;
        public ShieldRechargeRatePercentage ShieldRechargeRate;
        public ShieldVampirismPercentage ShieldVampirism;
        public HeadshotImmunity HeadshotImmunity;
        public ShieldMultiplier ShieldMultiplier;
    }

    public enum SharedTraits : byte
    {
        // Might not be entirely correct
        SprintUnchangedThirdPersonUnchanged = 0,
        SprintEnabledThirdPersonUnchanged,
        SprintDisabledThirdPersonUnchanged,
        SprintUnknownThirdPersonUnchanged,
        SprintUnchangedThirdPersonEnabled,
        SprintEnabledThirdPersonEnabled,
        SprintDisabledThirdPersonEnabled,
        SprintUnknownThirdPersonEnabled,
        SprintUnchangedThirdPersonDisabled,
        SprintEnabledThirdPersonDisabled,
        SprintDisabledThirdPersonDisabled,
        SprintUnknownThirdPersonDisabled,   
    }

    [TagStructure(Size = 0x3)]
    public class PlayerExtendedTraits
    {
        public byte PlayerCharacterValue;
        public SharedTraits SharedTraitsValue;

        // Might not be padding
        [TagField(Flags = TagFieldFlags.Padding, Length = 1)]
        public byte[] Padding1 = new byte[1];
    }

    public enum WeaponGrenadeCount : short
    {
        Unchanged,
        MapDefault,
        None,
        One,
        Two,
        //Three,
        //Four,
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
        //EnabledIncludingFirebombs,
    }

    public enum InfiniteAmmoSetting : byte
    {
        Unchanged = 0,
        Disabled,
        Enabled,
        //BottomlessClip,
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
    }

    public enum PlayerVehicleUsage : byte
    {
        Unchanged = 0,
        None,
        PassengerOnly,
        Full,
    }

    public enum PlayerSprintState : byte
    {
        Unchanged = 0,
        Enabled,
        Disabled,
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
    }

    public enum AuraSetting : byte
    {
        Unchanged = 0,
        Off,
        TeamColor,
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
        Yellow,
        Purple,
        Orange,
        Brown,
        Grey,
        Primary,
        Secondary,
        Tertiary,
        Quaternary,
    }

    [TagStructure(Size = 0x4)]
    public class PlayerAppearanceTraits
    {
        public ActiveCamoSetting ActiveCamo;
        public WaypointSetting Waypoint;
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

    public enum SocialOptionsFlags : short
    {
        Observers = 0,
        TeamChanging,
        TeamChangingBalancingOnly,
        FriendlyFire,
        BetrayalBooting,
        SpartansVsElites, // Halo Online Specific
        EnemyVoice,       // Unused in Halo Online
        OpenChannelVoice, // Unused in Halo Online
        DeadPlayerVoice,  // Unused in Halo Online
    }

    [TagStructure(Size = 0x4)]
    public class SocialOptions
    {
        public SocialOptionsFlags Flags;
        public short TeamChanging;
    }

    public enum MapOverrideOptionsFlags : int
    {
        GrenadesOnMap = 0,
        IndestructibleVehicles,
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
        public short TeamScoringMethod;
    }
}