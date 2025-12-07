using System;
using System.Collections.Generic;
using System.Text;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions.Gen2
{
    [TagStructure(Name = "unit", Tag = "unit", Size = 0x1EC)]
    public class Unit : GameObject
    {
        public UnitFlagBits UnitFlags;
        public DefaultTeamValue DefaultTeam;
        public ConstantSoundVolumeValue ConstantSoundVolume;
        [TagField(ValidTags = new[] { "effe" })]
        public CachedTag IntegratedLightToggle;
        public Angle CameraFieldOfView; // degrees
        public float CameraStiffness;
        public UnitCameraStructBlock UnitCamera;
        public UnitSeatAccelerationStructBlock Acceleration;
        public float SoftPingThreshold; // [0,1]
        public float SoftPingInterruptTime; // seconds
        public float HardPingThreshold; // [0,1]
        public float HardPingInterruptTime; // seconds
        public float HardDeathThreshold; // [0,1]
        public float FeignDeathThreshold; // [0,1]
        public float FeignDeathTime; // seconds
        /// <summary>
        /// this must be set to tell the AI how far it should expect our evade animation to move us
        /// </summary>
        public float DistanceOfEvadeAnim; // world units
        /// <summary>
        /// this must be set to tell the AI how far it should expect our dive animation to move us
        /// </summary>
        public float DistanceOfDiveAnim; // world units
        /// <summary>
        /// if we take this much damage in a short space of time we will play our 'stunned movement' animations
        /// </summary>
        public float StunnedMovementThreshold; // [0,1]
        public float FeignDeathChance; // [0,1]
        public float FeignRepeatChance; // [0,1]
        /// <summary>
        /// automatically created character when this unit is driven
        /// </summary>
        [TagField(ValidTags = new[] { "char" })]
        public CachedTag SpawnedTurretCharacter;
        /// <summary>
        /// number of actors which we spawn
        /// </summary>
        public Bounds<short> SpawnedActorCount;
        /// <summary>
        /// velocity at which we throw spawned actors
        /// </summary>
        public float SpawnedVelocity;
        public Angle AimingVelocityMaximum; // degrees per second
        public Angle AimingAccelerationMaximum; // degrees per second squared
        public float CasualAimingModifier; // [0,1]
        public Angle LookingVelocityMaximum; // degrees per second
        public Angle LookingAccelerationMaximum; // degrees per second squared
        /// <summary>
        /// where the primary weapon is attached
        /// </summary>
        public StringId RightHandNode;
        /// <summary>
        /// where the seconday weapon is attached (for dual-pistol modes)
        /// </summary>
        public StringId LeftHandNode;
        public UnitAdditionalNodeNamesStructBlock MoreDamnNodes;
        [TagField(ValidTags = new[] { "jpt!" })]
        public CachedTag MeleeDamage;
        public UnitBoardingMeleeStructBlock YourMomma;
        public MotionSensorBlipSizeValue MotionSensorBlipSize;
        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding, Platform = CachePlatform.Original)]
        public byte[] Padding4;

        [TagField(Platform = CachePlatform.MCC)]
        public MetagameBucket.CampaignMetagameBucketType MetagameType;
        [TagField(Platform = CachePlatform.MCC)]
        public MetagameBucket.CampaignMetagameBucketClass MetagameClassification;

        public List<UnitPosturesBlock> Postures;
        public List<UnitHudReferenceBlock> NewHudInterfaces;
        public List<DialogueVariantBlock> DialogueVariants;
        public float GrenadeVelocity; // world units per second
        public GrenadeTypeValue GrenadeType;
        public short GrenadeCount;
        public List<PoweredSeatBlock> PoweredSeats;
        public List<UnitWeaponBlock> Weapons;
        public List<UnitSeatBlock> Seats;
        public UnitBoostStructBlock Boost;
        public UnitLipsyncScalesStructBlock Lipsync;

        [Flags]
        public enum UnitFlagBits : uint
        {
            CircularAiming = 1 << 0,
            DestroyedAfterDying = 1 << 1,
            HalfSpeedInterpolation = 1 << 2,
            FiresFromCamera = 1 << 3,
            EntranceInsideBoundingSphere = 1 << 4,
            DoesnTShowReadiedWeapon = 1 << 5,
            CausesPassengerDialogue = 1 << 6,
            ResistsPings = 1 << 7,
            MeleeAttackIsFatal = 1 << 8,
            DonTRefaceDuringPings = 1 << 9,
            HasNoAiming = 1 << 10,
            SimpleCreature = 1 << 11,
            ImpactMeleeAttachesToUnit = 1 << 12,
            ImpactMeleeDiesOnShields = 1 << 13,
            CannotOpenDoorsAutomatically = 1 << 14,
            MeleeAttackersCannotAttach = 1 << 15,
            NotInstantlyKilledByMelee = 1 << 16,
            ShieldSapping = 1 << 17,
            RunsAroundFlaming = 1 << 18,
            Inconsequential = 1 << 19,
            SpecialCinematicUnit = 1 << 20,
            IgnoredByAutoaiming = 1 << 21,
            ShieldsFryInfectionForms = 1 << 22,
            Unused = 1 << 23,
            Unused1 = 1 << 24,
            ActsAsGunnerForParent = 1 << 25,
            ControlledByParentGunner = 1 << 26,
            ParentSPrimaryWeapon = 1 << 27,
            UnitHasBoost = 1 << 28
        }

        public enum DefaultTeamValue : short
        {
            Default,
            Player,
            Human,
            Covenant,
            Flood,
            Sentinel,
            Heretic,
            Prophet,
            Unused8,
            Unused9,
            Unused10,
            Unused11,
            Unused12,
            Unused13,
            Unused14,
            Unused15
        }

        public enum ConstantSoundVolumeValue : short
        {
            Silent,
            Medium,
            Loud,
            Shout,
            Quiet
        }

        [TagStructure(Size = 0x1C)]
        public class UnitCameraStructBlock : TagStructure
        {
            public StringId CameraMarkerName;
            public StringId CameraSubmergedMarkerName;
            public Angle PitchAutoLevel;
            public Bounds<Angle> PitchRange;
            public List<UnitCameraTrackBlock> CameraTracks;

            [TagStructure(Size = 0x8)]
            public class UnitCameraTrackBlock : TagStructure
            {
                [TagField(ValidTags = new[] { "trak" })]
                public CachedTag Track;
            }
        }

        [TagStructure(Size = 0x14)]
        public class UnitSeatAccelerationStructBlock : TagStructure
        {
            public RealVector3d AccelerationRange; // world units per second squared
            public float AccelActionScale; // actions fail [0,1+]
            public float AccelAttachScale; // detach unit [0,1+]
        }

        [TagStructure(Size = 0x4)]
        public class UnitAdditionalNodeNamesStructBlock : TagStructure
        {
            /// <summary>
            /// if found, use this gun marker
            /// </summary>
            public StringId PreferredGunNode;
        }

        [TagStructure(Size = 0x28)]
        public class UnitBoardingMeleeStructBlock : TagStructure
        {
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag BoardingMeleeDamage;
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag BoardingMeleeResponse;
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag LandingMeleeDamage;
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag FlurryMeleeDamage;
            [TagField(ValidTags = new[] { "jpt!" })]
            public CachedTag ObstacleSmashDamage;
        }

        public enum MotionSensorBlipSizeValue : short
        {
            Medium,
            Small,
            Large
        }

        [TagStructure(Size = 0x10)]
        public class UnitPosturesBlock : TagStructure
        {
            public StringId Name;
            public RealVector3d PillOffset;
        }

        [TagStructure(Size = 0x8)]
        public class UnitHudReferenceBlock : TagStructure
        {
            [TagField(ValidTags = new[] { "nhdt" })]
            public CachedTag NewUnitHudInterface;
        }

        [TagStructure(Size = 0xC)]
        public class DialogueVariantBlock : TagStructure
        {
            /// <summary>
            /// variant number to use this dialogue with (must match the suffix in the permutations on the unit's model)
            /// </summary>
            public short VariantNumber;
            [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;
            [TagField(ValidTags = new[] { "udlg" })]
            public CachedTag Dialogue;
        }

        public enum GrenadeTypeValue : short
        {
            HumanFragmentation,
            CovenantPlasma
        }

        [TagStructure(Size = 0x8)]
        public class PoweredSeatBlock : TagStructure
        {
            public float DriverPowerupTime; // seconds
            public float DriverPowerdownTime; // seconds
        }

        [TagStructure(Size = 0x8)]
        public class UnitWeaponBlock : TagStructure
        {
            [TagField(ValidTags = new[] { "weap" })]
            public CachedTag Weapon;
        }

        [TagStructure(Size = 0xB0)]
        public class UnitSeatBlock : TagStructure
        {
            public FlagsValue Flags;
            public StringId Label;
            public StringId MarkerName;
            public StringId EntryMarkerName;
            public StringId BoardingGrenadeMarker;
            public StringId BoardingGrenadeString;
            public StringId BoardingMeleeString;
            /// <summary>
            /// nathan is too lazy to make pings for each seat.
            /// </summary>
            public float PingScale;
            /// <summary>
            /// how much time it takes to evict a rider from a flipped vehicle
            /// </summary>
            public float TurnoverTime; // seconds
            public UnitSeatAccelerationStructBlock Acceleration;
            public float AiScariness;
            public AiSeatTypeValue AiSeatType;
            public short BoardingSeat;
            /// <summary>
            /// how far to interpolate listener position from camera to occupant's head
            /// </summary>
            public float ListenerInterpolationFactor;
            /// <summary>
            /// when the unit velocity is 0, the yaw/pitch rates are the left values
            /// at [max speed reference], the yaw/pitch rates are
            /// the right values.
            /// the max speed reference is what the code uses to generate a clamped speed from 0..1
            /// the exponent
            /// controls how midrange speeds are interpreted.
            /// </summary>
            public Bounds<float> YawRateBounds; // degrees per second
            public Bounds<float> PitchRateBounds; // degrees per second
            public float MinSpeedReference;
            public float MaxSpeedReference;
            public float SpeedExponent;
            public UnitCameraStructBlock UnitCamera;
            public List<UnitHudReferenceBlock> UnitHudInterface;
            public StringId EnterSeatString;
            public Angle YawMinimum;
            public Angle YawMaximum;
            [TagField(ValidTags = new[] { "char" })]
            public CachedTag BuiltInGunner;
            /// <summary>
            /// note: the entry radius shouldn't exceed 3 world units, 
            /// as that is as far as the player will search for a vehicle
            /// to
            /// enter.
            /// </summary>
            /// <summary>
            /// how close to the entry marker a unit must be
            /// </summary>
            public float EntryRadius;
            /// <summary>
            /// angle from marker forward the unit must be
            /// </summary>
            public Angle EntryMarkerConeAngle;
            /// <summary>
            /// angle from unit facing the marker must be
            /// </summary>
            public Angle EntryMarkerFacingAngle;
            public float MaximumRelativeVelocity;
            public StringId InvisibleSeatRegion;
            public int RuntimeInvisibleSeatRegionIndex;

            [Flags]
            public enum FlagsValue : uint
            {
                Invisible = 1 << 0,
                Locked = 1 << 1,
                Driver = 1 << 2,
                Gunner = 1 << 3,
                ThirdPersonCamera = 1 << 4,
                AllowsWeapons = 1 << 5,
                ThirdPersonOnEnter = 1 << 6,
                FirstPersonCameraSlavedToGun = 1 << 7,
                AllowVehicleCommunicationAnimations = 1 << 8,
                NotValidWithoutDriver = 1 << 9,
                AllowAiNoncombatants = 1 << 10,
                BoardingSeat = 1 << 11,
                AiFiringDisabledByMaxAcceleration = 1 << 12,
                BoardingEntersSeat = 1 << 13,
                BoardingNeedAnyPassenger = 1 << 14,
                ControlsOpenAndClose = 1 << 15,
                InvalidForPlayer = 1 << 16,
                InvalidForNonPlayer = 1 << 17,
                GunnerPlayerOnly = 1 << 18,
                InvisibleUnderMajorDamage = 1 << 19
            }

            [TagStructure(Size = 0x14)]
            public class UnitSeatAccelerationStructBlock : TagStructure
            {
                public RealVector3d AccelerationRange; // world units per second squared
                public float AccelActionScale; // actions fail [0,1+]
                public float AccelAttachScale; // detach unit [0,1+]
            }

            public enum AiSeatTypeValue : short
            {
                None,
                Passenger,
                Gunner,
                SmallCargo,
                LargeCargo,
                Driver
            }

            [TagStructure(Size = 0x1C)]
            public class UnitCameraStructBlock : TagStructure
            {
                public StringId CameraMarkerName;
                public StringId CameraSubmergedMarkerName;
                public Angle PitchAutoLevel;
                public Bounds<Angle> PitchRange;
                public List<UnitCameraTrackBlock> CameraTracks;

                [TagStructure(Size = 0x8)]
                public class UnitCameraTrackBlock : TagStructure
                {
                    [TagField(ValidTags = new[] { "trak" })]
                    public CachedTag Track;
                }
            }

            [TagStructure(Size = 0x8)]
            public class UnitHudReferenceBlock : TagStructure
            {
                [TagField(ValidTags = new[] { "nhdt" })]
                public CachedTag NewUnitHudInterface;
            }
        }

        [TagStructure(Size = 0x14)]
        public class UnitBoostStructBlock : TagStructure
        {
            public float BoostPeakPower;
            public float BoostRisePower;
            public float BoostPeakTime;
            public float BoostFallPower;
            public float DeadTime;
        }

        [TagStructure(Size = 0x8)]
        public class UnitLipsyncScalesStructBlock : TagStructure
        {
            public float AttackWeight;
            public float DecayWeight;
        }
    }
}
