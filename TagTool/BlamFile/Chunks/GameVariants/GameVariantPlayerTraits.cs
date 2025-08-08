using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.BlamFile.Chunks.GameVariants
{
    [TagStructure(Size = 0x1C)]
    public class GameVariantPlayerTraits : TagStructure 
    {
        public PlayerShieldVitalityTraits ShieldVitalityTraits;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        public PlayerExtendedTraits ExtendedTraits;

        public PlayerWeaponTraits WeaponTraits;
        public PlayerMovementTraits MovementTraits;
        public PlayerAppearanceTraits AppearanceTraits;
        public PlayerSensorTraits SensorTraits;

        [TagStructure(Size = 0x8, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x5, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
        [TagStructure(Size = 0x8, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
        public class PlayerShieldVitalityTraits : TagStructure
        {
            public DamageResistancePercentage DamageResistance;
            public ShieldRechargeRatePercentage ShieldRechargeRate;
            public ShieldVampirismPercentage ShieldVampirism;
            public HeadshotImmunitySettings HeadshotImmunity;
            public ShieldMultiplierSettings ShieldMultiplier;

            [TagField(Flags = TagFieldFlags.Padding, Length = 0x3, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(Flags = TagFieldFlags.Padding, Length = 0x3, MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
            public byte[] Padding;

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

            public static PlayerShieldVitalityTraits Decode(BitStream stream)
            {
                var shieldVitalityTraits = new PlayerShieldVitalityTraits();

                shieldVitalityTraits.DamageResistance = (DamageResistancePercentage)stream.ReadUnsigned(4);
                shieldVitalityTraits.ShieldRechargeRate = (ShieldRechargeRatePercentage)stream.ReadUnsigned(4);
                shieldVitalityTraits.ShieldVampirism = (ShieldVampirismPercentage)stream.ReadUnsigned(3);
                shieldVitalityTraits.HeadshotImmunity = (HeadshotImmunitySettings)stream.ReadUnsigned(2);
                shieldVitalityTraits.ShieldMultiplier = (ShieldMultiplierSettings)stream.ReadUnsigned(3);

                return shieldVitalityTraits;
            }

            public static void Encode(BitStream stream, PlayerShieldVitalityTraits shieldVitalityTraits)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [TagStructure(Size = 0x3)]
        public class PlayerExtendedTraits : TagStructure
        {
            public byte PlayerCharacterValue;
            public ExtendedTraitSettings ExtendedTraits;

            [TagField(Flags = TagFieldFlags.Padding, Length = 1)]
            public byte[] Padding;

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

        [TagStructure(Size = 0x8)]
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

            public static PlayerWeaponTraits Decode(BitStream stream)
            {
                var weaponTraits = new PlayerWeaponTraits();

                weaponTraits.DamageModifier = (DamageModifierPercentage)stream.ReadUnsigned(4);
                weaponTraits.PrimaryWeaponIndex = (byte)stream.ReadUnsigned(8);
                weaponTraits.SecondaryWeaponIndex = (byte)stream.ReadUnsigned(8);
                weaponTraits.InitialGrenadeCount = (WeaponGrenadeCount)stream.ReadUnsigned(2);
                weaponTraits.InfiniteAmmo = (InfiniteAmmoSettings)stream.ReadUnsigned(2);
                weaponTraits.RechargingGrenades = (RechargingGrenadesSettings)stream.ReadUnsigned(2);
                weaponTraits.WeaponPickup = (WeaponPickupSettings)stream.ReadUnsigned(2);

                return weaponTraits;
            }

            public static void Encode(BitStream stream, PlayerWeaponTraits weaponTraits)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [TagStructure(Size = 0x4)]
        public class PlayerMovementTraits : TagStructure
        {
            public PlayerSpeedSettings PlayerSpeed;
            public PlayerGravitySettings PlayerGravity;
            public PlayerVehicleUsage VehicleUsage;

            [TagField(Flags = TagFieldFlags.Padding, Length = 1)]
            public byte[] Padding;

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

            public static PlayerMovementTraits Decode(BitStream stream)
            {
                var movementTraits = new PlayerMovementTraits();

                movementTraits.PlayerSpeed = (PlayerSpeedSettings)stream.ReadUnsigned(4);
                movementTraits.PlayerGravity = (PlayerGravitySettings)stream.ReadUnsigned(3);
                movementTraits.VehicleUsage = (PlayerVehicleUsage)stream.ReadUnsigned(2);

                return movementTraits;
            }

            public static void Encode(BitStream stream, PlayerMovementTraits movementTraits)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [TagStructure(Size = 0x4)]
        public class PlayerAppearanceTraits : TagStructure
        {
            public ActiveCamoSettings ActiveCamo;
            public WaypointSettings Waypoint;

            [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnlineED)]
            public PlayerSizeSettings PlayerSize;

            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
            [TagField(MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708)]
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

            public static PlayerAppearanceTraits Decode(BitStream stream)
            {
                var appearanceTraits = new PlayerAppearanceTraits();

                appearanceTraits.ActiveCamo = (ActiveCamoSettings)stream.ReadUnsigned(3);
                appearanceTraits.Waypoint = (WaypointSettings)stream.ReadUnsigned(2);
                appearanceTraits.Aura = (AuraSettings)stream.ReadUnsigned(3);
                appearanceTraits.ForcedColorChange = (ForcedColorChangeSettings)stream.ReadUnsigned(4);

                return appearanceTraits;
            }

            public static void Encode(BitStream stream, PlayerAppearanceTraits appearanceTraits)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        [TagStructure(Size = 0x4)]
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

            public static PlayerSensorTraits Decode(BitStream stream)
            {
                var sensorTraits = new PlayerSensorTraits();

                sensorTraits.MotionTracker = (MotionTrackerSettings)stream.ReadUnsigned(3);
                sensorTraits.MotionTrackerRange = (MotionTrackerRangeSettings)stream.ReadUnsigned(3);

                return sensorTraits;
            }

            public static void Encode(BitStream stream, PlayerSensorTraits sensorTraits)
            {
                // TODO: Implement
                throw new NotImplementedException();
            }
        }

        public static GameVariantPlayerTraits Decode(BitStream stream)
        {
            var playerTraits = new GameVariantPlayerTraits();

            playerTraits.ShieldVitalityTraits = PlayerShieldVitalityTraits.Decode(stream);
            playerTraits.WeaponTraits = PlayerWeaponTraits.Decode(stream);
            playerTraits.MovementTraits = PlayerMovementTraits.Decode(stream);
            playerTraits.AppearanceTraits = PlayerAppearanceTraits.Decode(stream);
            playerTraits.SensorTraits = PlayerSensorTraits.Decode(stream);

            return playerTraits;
        }

        public static void Encode(BitStream stream, GameVariantPlayerTraits playerTraits)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
