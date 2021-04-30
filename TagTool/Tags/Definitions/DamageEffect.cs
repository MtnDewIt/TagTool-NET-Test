using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "damage_effect", Tag = "jpt!", Size = 0xF0, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "damage_effect", Tag = "jpt!", Size = 0xF4, MinVersion = CacheVersion.HaloOnline106708)]
    public class DamageEffect : TagStructure
	{
        public Bounds<float> Radius; // world units
        public float CutoffScale;
        public FlagsValue Flags;
        public SideEffectValue SideEffect;
        public CategoryValue Category;
        public FlagsValue1 Flags2;
        public float AreaOfEffectCoreRadius;
        public float DamageLowerBound;
        public Bounds<float> DamageUpperBound;
        public Angle DamageInnerConeAngle;
        public Angle DamageOuterConeAngle;
        public float ActiveCamoflageDamage;
        public float Stun;
        public float MaxStun;
        public float StunTime;
        public float InstantaneousAcceleration;
        public float RiderDirectDamageScale;
        public float RiderMaxTransferDamageScale;
        public float RiderMinTransferDamageScale;
        public StringId GeneralDamage;
        public StringId SpecificDamage;
        public StringId SpecialDamage;
        public float AiStunRadius;
        public Bounds<float> AiStunBounds;
        public float ShakeRadius;
        public float EmpRadius;
        public float AOESpikeRadius;
        public float AOESpikeDamageBump;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public float Unknown_HO = 1.0f;

        public List<PlayerResponseBlock> PlayerResponses;
        public CachedTag DamageResponse;
        public float CameraImpulseDuration;
        public FunctionType CameraImpulseFadeFunction;
        public short Unknown;
        public Angle CameraImpulseRotation;
        public float CameraImpulsePushback;
        public Bounds<float> CameraImpulseJitter;
        public float CameraShakeDuration;
        public FunctionType CameraShakeFalloffFunction;
        public short Unknown2;
        public float CameraShakeRandomTranslation;
        public Angle CameraShakeRandomRotation;
        public WobbleFunctionValue CameraShakeWobbleFunction;
        public short Unknown3;
        public float CameraShakeWobbleFunctionPeriod;
        public float CameraShakeWobbleWeight;
        public CachedTag Sound;
        public float BreakingEffectForwardVelocity;
        public float BreakingEffectForwardRadius;
        public float BreakingEffectForwardExponent;
        public float BreakingEffectOutwardVelocity;
        public float BreakingEffectOutwardRadius;
        public float BreakingEffectOutwardExponent;

        [Flags]
        public enum FlagsValue : uint
        {
            DonTScaleDamageByDistance = 1 << 0,
            /// <summary>
            /// area of effect damage only affects players
            /// </summary>
            AreaDamagePlayersOnly = 1 << 1,
            AffectsModelTargets = 1 << 2
        }

        [Flags]
        public enum FlagsValue1 : uint
        {
            DoesNotHurtOwner = 1 << 0,
            CanCauseHeadshots = 1 << 1,
            PingsResistantUnits = 1 << 2,
            DoesNotHurtFriends = 1 << 3,
            DoesNotPingUnits = 1 << 4,
            DetonatesExplosives = 1 << 5,
            OnlyHurtsShields = 1 << 6,
            CausesFlamingDeath = 1 << 7,
            DamageIndicatorsAlwaysPointDown = 1 << 8,
            SkipsShields = 1 << 9,
            OnlyHurtsOneInfectionForm = 1 << 10,
            TransferDamageAlwaysUsesMinimum = 1 << 11,
            InfectionFormPop = 1 << 12,
            IgnoreSeatScaleForDirDmg = 1 << 13,
            ForcesHardPing = 1 << 14,
            DoesNotHurtPlayers = 1 << 15
        }

        public enum SideEffectValue : short
        {
            None,
            Harmless,
            LethalToTheUnsuspecting,
            Emp
        }

        public enum CategoryValue : short
        {
            None,
            Falling,
            Bullet,
            Grenade,
            HighExplosive,
            Sniper,
            Melee,
            Flame,
            MountedWeapon,
            Vehicle,
            Plasma,
            Needle,
            Shotgun
        }

        [TagStructure(Size = 0x70)]
        public class PlayerResponseBlock : TagStructure
		{
            public ResponseTypeValue ResponseType;
            public short Unknown;
            public TypeValue Type;
            public PriorityValue Priority;
            public float Duration;
            public FunctionType FadeFunction;
            public short Unknown2;
            public float MaximumIntensity;
            public RealArgbColor Color;
            public float LowFrequencyVibrationDuration;
            public TagFunction LowFrequencyVibrationFunction = new TagFunction { Data = new byte[0] };
            public float HighFrequencyVibrationDuration;
            public TagFunction HighFrequencyVibrationFunction = new TagFunction { Data = new byte[0] };
            public StringId EffectName;
            public float Duration2;
            public TagFunction EffectScaleFunction = new TagFunction { Data = new byte[0] };

            public enum ResponseTypeValue : short
            {
                Shielded,
                Unshielded,
                All
            }

            public enum TypeValue : short
            {
                None,
                Lighten,
                Darken,
                Max,
                Min,
                Invert,
                Tint
            }

            public enum PriorityValue : short
            {
                Low,
                Medium,
                High
            }
        }

        public enum WobbleFunctionValue : short
        {
            One,
            Zero,
            Cosine,
            CosineVariablePeriod,
            DiagonalWave,
            DiagonalWaveVariablePeriod,
            Slide,
            SlideVariablePeriod,
            Noise,
            Jitter,
            Wander,
            Spark
        }
    }
}