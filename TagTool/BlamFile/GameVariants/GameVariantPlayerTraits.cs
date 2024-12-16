using System;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.BlamFile.GameVariants
{
    [TagStructure(Size = 0x1C, Align = 0x1)]
    public class GameVariantPlayerTraits : TagStructure 
    {
        public PlayerShieldVitalityTraits ShieldVitalityTraits;

        //[TagField(Version = CacheVersion.HaloOnlineED)]
        //public PlayerExtendedTraits ExtendedTraits;

        public PlayerWeaponTraits WeaponTraits;
        public PlayerMovementTraits MovementTraits;
        public PlayerAppearanceTraits AppearanceTraits;
        public PlayerSensorTraits SensorTraits;

        [TagStructure(Size = 0x8, Align = 0x1, MinVersion = CacheVersion.Halo3Retail)]
        //[TagStructure(Size = 0x5, Align = 0x1, Version = CacheVersion.HaloOnlineED)]
        public class PlayerShieldVitalityTraits : TagStructure
        {
            public DamageResistancePercentage DamageResistance;
            public ShieldRechargeRatePercentage ShieldRechargeRate;
            public ShieldVampirismPercentage ShieldVampirism;
            public HeadshotImmunitySettings HeadshotImmunity;
            public ShieldMultiplierSettings ShieldMultiplier;

            [TagField(Flags = TagFieldFlags.Padding, Length = 3)]
            public byte[] Padding1 = new byte[3];

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

            public enum HeadshotImmunitySettings : byte
            {
                Unchanged = 0,
                Immune,
                NotImmune,
            }

            public enum ShieldMultiplierSettings : byte
            {
                Unchanged = 0,
                Shield_0X,
                Shield_1X,
                Shield_2X,
                Shield_3X,
                Shield_4X,
            }
        }

        [TagStructure(Size = 0x3, Align = 0x1)]
        public class PlayerExtendedTraits : TagStructure
        {
            public byte PlayerCharacterValue;
            public ExtendedTraitSettings ExtendedTraits;
            public byte Unknown; // Might be padding?

            [Flags]
            public enum ExtendedTraitSettings : byte
            {
                None = 0,
                SprintEnabled = 1 << 0,
                SprintDisabled = 1 << 1,
                ThirdPersonEnabled = 1 << 2,
                ThirdPersonDisabled = 1 << 3,
            }
        }

        [TagStructure(Size = 0x8, Align = 0x1)]
        public class PlayerWeaponTraits : TagStructure
        {
            public WeaponGrenadeCount InitialGrenadeCount;
            public byte PrimaryWeaponIndex;
            public byte SecondaryWeaponIndex;
            public DamageModifierPercentage DamageModifier;
            public RechargingGrenadesSettings RechargingGrenades;
            public InfiniteAmmoSettings InfiniteAmmo;
            public WeaponPickupSettings WeaponPickup;

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

            public enum RechargingGrenadesSettings : byte
            {
                Unchanged = 0,
                Enabled,
                Disabled,
            }

            public enum InfiniteAmmoSettings : byte
            {
                Unchanged = 0,
                Disabled,
                Enabled,
                BottomlessClip,
            }

            public enum WeaponPickupSettings : byte
            {
                Unchanged = 0,
                Allowed,
                Disallowed,
            }
        }

        [TagStructure(Size = 0x4, Align = 0x1)]
        public class PlayerMovementTraits : TagStructure
        {
            public PlayerSpeedSettings PlayerSpeed;
            public PlayerGravitySettings PlayerGravity;
            public PlayerVehicleUsage VehicleUsage;

            [TagField(Flags = TagFieldFlags.Padding, Length = 1)]
            public byte[] Padding1 = new byte[1];

            public enum PlayerSpeedSettings : byte
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

            public enum PlayerGravitySettings : byte
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
        }

        [TagStructure(Size = 0x4, Align = 0x1)]
        public class PlayerAppearanceTraits : TagStructure
        {
            public ActiveCamoSettings ActiveCamo;
            public WaypointSettings Waypoint;

            [TagField(Version = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
            public PlayerSizeSettings PlayerSize;

            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
            public AuraSettings Aura;

            public ForcedColorChangeSettings ForcedColorChange;

            public enum ActiveCamoSettings : byte
            {
                Unchanged = 0,
                Off,
                Poor,
                Good,
                Invisible,
            }

            public enum WaypointSettings : byte
            {
                Unchanged = 0,
                Off,
                Allies,
                All,
                None,
                NoneTeamOnly,
            }

            public enum PlayerSizeSettings : byte
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

            public enum AuraSettings : byte
            {
                Unchanged = 0,
                Disabled,
                Team,
                Black,
                White,
            }

            public enum ForcedColorChangeSettings : byte
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
        }

        [TagStructure(Size = 0x4, Align = 0x1)]
        public class PlayerSensorTraits : TagStructure
        {
            public MotionTrackerSettings MotionTracker;
            public MotionTrackerRangeSettings MotionTrackerRange;

            public enum MotionTrackerSettings : short
            {
                Unchanged = 0,
                Off,
                FriendlyOnly,
                Normal,
                Always,
            }

            public enum MotionTrackerRangeSettings : short
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
        }
    }
}
