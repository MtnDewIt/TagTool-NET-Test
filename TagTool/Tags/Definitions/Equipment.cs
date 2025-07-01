using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "equipment", Tag = "eqip", Size = 0xD4, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Name = "equipment", Tag = "eqip", Size = 0xE0, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "equipment", Tag = "eqip", Size = 0x1B0, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "equipment", Tag = "eqip", Size = 0x220, MinVersion = CacheVersion.HaloReach)]
    public class Equipment : Item
    {
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float WarmupTime;

        public float Duration;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float CooldownTime;

        public float PhantomVolumeActivationTime;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float EnergyRecoveryTime;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float MinimumActivationEnergy;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float LowEnergyWarningThreshold;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float ActivationEnergyCost;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float DeactivationEnergyCost;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float ActiveEnergyRate; // energy/second
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public TagFunction MovementSpeedToEnergyRate; // 1/s
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float MovementSpeedDomain; // wu/s

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public short Charges;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public EquipmentFlagBits EquipmentFlags;

        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
        public EquipmentFlagBitsH3 EquipmentFlagsH3;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public EquipmentFlagBitsReach EquipmentFlagsReach;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public short NumberOfUsesReach;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public sbyte ActivationType;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public sbyte ObjectNoiseAdjustment;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId UnitStowMarker;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public RealArgbColor ForcedPrimaryChangeColor;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public RealArgbColor ForcedSecondaryChangeColor;

        public float AiDangerRadius;
        public float AiMinDeployDistance;
        public float AiAwarenessDelay;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId AiDialogueEquipmentType;

        [TagField(MinVersion = CacheVersion.HaloOnlineED)]
        public List<Unit.UnitCameraBlock> OverrideCamera;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public List<SuperShieldBlock> SuperShield;

        public List<MultiplayerPowerupBlock> MultiplayerPowerup;
        public List<SpawnerBlock> Spawner;
        public List<ProximityMineBlock> ProximityMine;
        public List<MotionTrackerNoiseBlock> MotionTrackerNoise;
        public List<ShowmeBlock> Showme;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public List<InvisibilityBlock> Invisibility;

        public List<InvincibilityBlock> Invincibility;
        public List<RegeneratorBlock> Regenerator;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> Shapeshifter;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> PlayerTraitField;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> AiTraitField;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> RepulsorField;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> IWHBYDaddy;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> LaserDesignation;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> SuperJump;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> AmmoPackReach;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> PowerFist;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public List<HealthPackBlock> HealthPack;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> Jetpack;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<ForcedReloadBlock> ForcedReload;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<ConcussiveBlastBlock> ConcussiveBlast;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<TankModeBlock> TankMode;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<MagPulseBlock> MagPulse;
        [TagField(MinVersion = CacheVersion.HaloOnlineED)]
        public List<HologramBlock> Hologram;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<ReactiveArmorBlock> ReactiveArmor;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<BombRunBlock> BombRun;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<ArmorLockBlock> ArmorLock;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<AdrenalineBlock> Adrenaline;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<LightningStrikeBlock> LightningStrike;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<ScramblerBlock> Scrambler;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<WeaponJammerBlock> WeaponJammer;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<AmmoPackBlock> AmmoPack;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<VisionBlock> Vision;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> SpecialWeapon;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> SpecialMove;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> EngineerShields;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<NullBlock> Sprint;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public sbyte DamageReportingType;
        [TagField(Length = 0x3, Flags = Padding, MinVersion = CacheVersion.HaloReach)]
        public byte[] Padding1;

        [TagField(ValidTags = new[] { "chdt" })]
        public CachedTag ChudInterface;

        [TagField(ValidTags = new[] { "scmb", "snd!" })]
        public CachedTag PickupSound;
        [TagField(ValidTags = new[] { "scmb", "snd!" }, MinVersion = CacheVersion.HaloOnlineED)]
        public CachedTag ActivateSound;

        [TagField(ValidTags = new[] { "effe", "snd!" })]
        public CachedTag ActivateEffect;
        [TagField(ValidTags = new[] { "effe", "snd!" })]
        public CachedTag RunningEffect;
        [TagField(ValidTags = new[] { "snd!" })]
        public CachedTag DeactivateSound;
        [TagField(ValidTags = new[] { "effe" }, MinVersion = CacheVersion.HaloReach)]
        public CachedTag EnergyChargedEffect;

        [TagField(MinVersion = CacheVersion.HaloOnlineED)]
        public StringId ActivationAnimation;
        [TagField(MinVersion = CacheVersion.HaloOnlineED)]
        public StringId ActiveAnimation;
        [TagField(MinVersion = CacheVersion.HaloOnlineED)]
        public StringId DeactivateAnimation;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId ActiveAnimationStance;

        [Flags]
        public enum EquipmentFlagBits : ushort
        {
            None,
            PathfindingObstacle = 1 << 0,
            GravityLiftCollisionGroup = 1 << 1,
            EquipmentIsDangerousToAi = 1 << 2,
            ProtectsParentFromAoe = 1 << 3,
            ThirdPersonCameraAlways = 1 << 4,
            HidesWeaponOnActivation = 1 << 5,
            CannotActivateWhileAirborne = 1 << 6,
            UsableInVehicle = 1 << 7,
            AppliesOnVehicleInsteadOfUser = 1 << 8,
            NotDroppedByPlayer = 1 << 9,
            IsDroppedByAi = 1 << 10,
            Bit11 = 1 << 11,
            Bit12 = 1 << 12,
            Bit13 = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15
        }

        [Flags]
        public enum EquipmentFlagBitsH3 : ushort
        {
            None,
            PathfindingObstacle = 1 << 0,
            GravityLiftCollisionGroup = 1 << 1,
            EquipmentIsDangerousToAi = 1 << 2,
            ProtectsParentFromAoe = 1 << 3,
            ThirdPersonCameraAlways = 1 << 4,
            UseForcedPrimaryChangeColor = 1 << 5,
            UseForcedSecondaryChangeColor = 1 << 6,
            CanNotBePickedUpByPlayer = 1 << 7,
            IsRemovedFromWorldOnDeactivation = 1 << 8,
            NotDroppedByPlayer = 1 << 9,
            IsDroppedByAi = 1 << 10
        }

        [Flags]
        public enum EquipmentFlagBitsReach : uint
        {
            PathfindingObstacle = 1 << 0,
            EquipmentIsDangerousToAi = 1 << 1,
            // if an actor dies while carrying this, it gets deleted immediately
            // does not affect dropping by players
            NeverDroppedByAi = 1 << 2,
            ProtectsParentFromAoe = 1 << 3,
            ThirdPersonCameraWhileActive = 1 << 4,
            ThirdPersonCameraAlways = 1 << 5,
            HideReticuleWhileActive = 1 << 6,
            CannotBeActiveWhileAirborne = 1 << 7, // if checked, this equipment cannot be activated if the user is airborne, and deactivates itself if the user becomes airborne
            CannotActivateWhileAirborne = 1 << 8, // can't activate in midair, but doesn't turn off if you later become airborne
            CannotActivateWhileStandingOnBiped = 1 << 9, // if you are standing on another biped you can not use this equipment
            CannotBeActiveInVehicle = 1 << 10, // can't be activated in a seat, and deactivates if a vehicle is entered
            SuppressesWeaponsWhileActive = 1 << 11, // firing your weapon turns off equipment
            SuppressesMeleeWhileActive = 1 << 12, // meleeing turns off equipment
            SuppressesGrenadesWhileActive = 1 << 13, // throwing a grenade turns off equipment
            SuppressesDeviceInteractionWhileActive = 1 << 14,
            UseForcedPrimaryChangeColor = 1 << 15,
            UseForcedSecondaryChangeColor = 1 << 16,
            DuckSoundWhileActive = 1 << 17,
            BlocksTrackingWhileActive = 1 << 18,
            ReadiesWeaponOnDeactivation = 1 << 19, // note - if this equipment has an animation cycle, the weapon is readied after the exit animation finishes.  Otherwise the weapon-ready happens immediately on deactivation
            DropsSupportMustBeReadiedWeaponsOnActivation = 1 << 20,
            HidesWeaponOnActivation = 1 << 21, // checking this flag will automatically cause the weapon to ready on deactivation
            CanNotBePickedUpByPlayer = 1 << 22,
            DoesNotActivateFromPrediction = 1 << 23 // used for evade to ensure that the equipment always activates from an event (more reliable).
        }

        [TagStructure(Size = 0x3C)]
        public class SuperShieldBlock : TagStructure
        {
            public float ShieldRechargeDelayScale;
            public float ShieldRechargeRateScale;
            public float ShieldCeilingScale;
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag ShieldEffect;
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag OverchargeEffect;
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag OverchargeDamageEffect;
        }

        [TagStructure(Size = 0x4)]
        public class MultiplayerPowerupBlock : TagStructure
		{
            public FlavorValue Flavor;

            public enum FlavorValue : int
            {
                RedPowerup,
                BluePowerup,
                YellowPowerup,
                CustomPowerup
            }
        }

        [TagStructure(Size = 0x34)]
        public class SpawnerBlock : TagStructure
		{
            [TagField(ValidTags = new[] { "obje" })]
            public CachedTag SpawnedObject;
            [TagField(ValidTags = new[] { "effe" })]
            public CachedTag SpawnedEffect;
            public float SpawnRadius;
            public float SpawnZOffset;
            public float SpawnAreaRadius;
            public float SpawnVelocity;
            public TypeValue Type;

            [TagField(Flags = Padding, Length = 2)]
            public byte[] Padding2 = new byte[2];

            public enum TypeValue : short
            {
                AlongAimingVector,
                CameraPosZPlane,
                FootPosZPlane
            }
        }

        [TagStructure(Size = 0x30)]
        public class ProximityMineBlock : TagStructure
		{
            public CachedTag ExplosionEffect;
            public CachedTag ExplosionDamageEffect;
            public float ArmTime;
            public float SelfDestructTime;
            public float TriggerTime;
            public float TriggerVelocity;
        }

        [TagStructure(Size = 0x10)]
        public class MotionTrackerNoiseBlock : TagStructure
		{
            public float ArmTime;
            public float NoiseRadius;
            public int NoiseCount;
            public float FlashRadius;
        }

        [TagStructure(Size = 0x4)]
        public class ShowmeBlock : TagStructure
        {
            public float ShowmeRadius;
        }

        [TagStructure(Size = 0x8)]
        public class InvisibilityBlock : TagStructure
		{
            public float InvisibilityDuration;
            public float InvisibilityFadeTime;
        }

        [TagStructure(Size = 0x2C, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x3C, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x2C, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x80, MinVersion = CacheVersion.HaloReach)]
        public class InvincibilityBlock : TagStructure
		{
            [TagField(Flags = GlobalMaterial)]
            public StringId InvincibilityMaterial;
            public short InvincibilityMaterialType;

            [TagField(Length = 0x2, Flags = Padding)]
            public byte[] Padding0;

            public float ShieldRechargeRate;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ShieldMaxRechargeLevel;
            [TagField(ValidTags = new[] { "cddf" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag OverrideCollisionDamage;
            [TagField(ValidTags = new[] { "jpt!" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag AiMeleeReflectDamage;
            [TagField(ValidTags = new[] { "jpt!" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag PlayerMeleeReflectDamage;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public StringId LoopInvincibilityShieldName;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public StringId PostInvincibilityShieldName;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public TagFunction PostInvincibilityTimeToShieldLevelFunction;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MaximumVerticalVelocity; // WU/SEC
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public TagFunction ActiveVerticalVelocityDamping;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ThresholdEffect> ThresholdEffects;

            [TagField(ValidTags = new[] { "effe" }, MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag ActivationEffect;
            [TagField(ValidTags = new[] { "effe" }, MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag AttachedEffect;

            [TagField(ValidTags = new[] { "effe" }, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
            public CachedTag ShutdownEffect;
        }

        [TagStructure(Size = 0x18)]
        public class ThresholdEffect : TagStructure
        {
            public float ThresholdEnergyBurned; // how much energy you have to burn to play this effect (0-1)
            public float EnergyAdjustment; // how much energy to add when playing this effect (-1 to 1)
            [TagField(ValidTags = new[] { "effe" })]
            public CachedTag Effect;
        }

        [TagStructure(Size = 0x4, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x10, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0xC, MinVersion = CacheVersion.HaloReach)]
        public class RegeneratorBlock : TagStructure
		{
            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            public float PhantomVolumesMakeMyLifeEasy;

            [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag RegeneratingEffect;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public FlagsValue Flags;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public StringId OriginMarker;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float Radius;

            [Flags]
            public enum FlagsValue : uint
            {
                UnStunsShileds = 1 << 0,
                UnStunsBody = 1 << 1
            }
        }

        [TagStructure(Size = 0x8, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x14, MinVersion = CacheVersion.HaloReach)]
        public class HealthPackBlock : TagStructure
		{
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float HeathAmount;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float ShieldAmount;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public TagFunction Function;
        }

        [TagStructure(Size = 0x14)]
        public class ForcedReloadBlock : TagStructure
		{
            public CachedTag WeaponEffect;
            public float AmmoAmountTaken;
        }

        [TagStructure(Size = 0x20)]
        public class ConcussiveBlastBlock : TagStructure
		{
            public CachedTag ExplosionEffect;
            public CachedTag ExplosionDamageEffect;
        }

        [TagStructure(Size = 0x28)]
        public class TankModeBlock : TagStructure
		{
            [TagField(Flags = GlobalMaterial)]
            public StringId TankModeMaterial;
            public uint TankModeMaterialType;
            public float TimeTankModeIsGrantedFor;
            public float OverallDamageReduction;
            public float MeleeDamageBoost;
            public uint HeadshotDamageReduction;
            public CachedTag ChudEffect;
        }

        [TagStructure(Size = 0x34)]
        public class MagPulseBlock : TagStructure
		{
            [TagField(ValidTags = new[] { "effe" })]
            public CachedTag ExplosionEffect;

            public CachedTag ProjectileEffect;
            public CachedTag EquipmentEffect;
            public uint Radius;
        }

        [TagStructure(Size = 0x6C, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x60, MinVersion = CacheVersion.HaloReach)]
        public class HologramBlock : TagStructure
		{
            public float HologramDuration;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int HavokFilterGroup;
            [TagField(ValidTags = new[] { "effe" })]
            public CachedTag CreationEffect;
            [TagField(ValidTags = new[] { "effe" })]
            public CachedTag AttachedEffect;
            public StringId AttachedEffectMarker;
            public StringId AttachedEffectPrimaryScale;
            public StringId AttachedEffectSecondaryScale;
            [TagField(ValidTags = new[] { "effe" })]
            public CachedTag DestructionEffect;
            public float ShimmerDecreaseRate;
            public float ShimmerBulletPing;
            public TagFunction ShimmerToCamoFunction;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag ChudHologramTarget;
        }

        [TagStructure(Size = 0x4C)]
        public class ReactiveArmorBlock : TagStructure
		{
            public float EffectDuration;
            public float MeleeDamageReflected;
            public uint OtherDamageReflected;
            public CachedTag ActivationEffect;
            public CachedTag EndingEffect;
            public CachedTag ReflectEffect;
            public CachedTag InducedDamageEffect;
        }

        [TagStructure(Size = 0x34)]
        public class BombRunBlock : TagStructure
		{
            public int MaxGrenades;
            public float MaxPowerModifier;
            public float MinPowerModifier;
            public float MaxAngleHorizontal;
            public float MaxAngleVertical;
            public CachedTag GrenadeToThrow;
            public CachedTag ActivationSound;
        }

        [TagStructure(Size = 0x20)]
        public class ArmorLockBlock : TagStructure
		{
            [TagField(ValidTags = new[] { "cddf" })]
            public CachedTag OverrideCollisionDamage;
            [TagField(ValidTags = new[] { "cddf" })]
            public CachedTag VehicleOverrideCollisionDamage;
        }

        [TagStructure(Size = 0x24)]
        public class AdrenalineBlock : TagStructure
		{
            public float StaminaAmount;
            public CachedTag ActivationEffect;
            public CachedTag StepsEffect;
        }

        [TagStructure(Size = 0x14)]
        public class LightningStrikeBlock : TagStructure
		{
            public float StrikeAcceleration;
            public CachedTag MeleeAttackSound;
        }

        [TagStructure(Size = 0x24)]
        public class ScramblerBlock : TagStructure
		{
            public uint ActionRadius;
            public CachedTag AttachedEffect;
            public int ActivationDelay;
            public int DisableDelay;
            public int EnableDelay;
            public int TimeToLive;
        }

        [TagStructure(Size = 0x24)]
        public class WeaponJammerBlock : TagStructure
		{
            public uint ActionRadius;
            public CachedTag AttachedEffect;
            public int ActivationDelay;
            public int DisableDelay;
            public int EnableDelay;
            public int TimeToLive;
        }

        [TagStructure(Size = 0x34)]
        public class AmmoPackBlock : TagStructure
		{
            public float PickupRadius;
            public int NumberOfActivations;
            public int TimeToLive;
            public int NextUseDelay;
            public int FirstUseDelay;
            public int DisappearDelay;
            public List<AmmoPackWeapon> AdditionalAmmo;
            public CachedTag ResupplySound;

            [TagStructure(Size = 0x18)]
            public class AmmoPackWeapon : TagStructure
			{
                public StringId Name;
                public CachedTag Weapon;
                public int AmmoCount;
            }
        }

        [TagStructure(Size = 0x20)]
        public class VisionBlock : TagStructure
		{
            public CachedTag GlobalScreenEffect;
            public CachedTag SelfDamageEffect;
        }
    }
}