using System;
using TagTool.Ai;
using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;
using static TagTool.Tags.TagFieldFlags;
using System.Threading.Channels;
using System.ComponentModel.DataAnnotations;
using static TagTool.Tags.Definitions.Gen4.Character.CharacterBoardingBlock;
using static TagTool.Tags.Definitions.Character.CharacterWeaponsProperties;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "character", Tag = "char", Size = 0x1D4, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Name = "character", Tag = "char", Size = 0x1F8, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "character", Tag = "char", Size = 0x270, MinVersion = CacheVersion.HaloReach)]
    public class Character : TagStructure
    {
        public CharacterFlags Flags;
        public CachedTag ParentCharacter;
        public CachedTag Unit;
        public CachedTag Creature; // Creature reference for swarm characters ONLY
        public CachedTag Style;
        public CachedTag MajorCharacter;

        public List<CharacterVariant> Variants;
        public List<CharacterVoiceProperties> Voice;
        public List<CharacterGeneralProperties> GeneralProperties;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterInteractBlock> InteractProperties;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterEmotionsBlock> EmotionProperties;

        public List<CharacterVitalityProperties> VitalityProperties;
        public List<CharacterPlacementProperties> PlacementProperties;
        public List<CharacterPerceptionProperties> PerceptionProperties;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterTargetBlockStruct> TargetProperties;

        public List<CharacterLookProperties> LookProperties;
        public List<CharacterMovementProperties> MovementProperties;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterThrottleStyleBlock> ThrottleStyles;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterMovementSetBlock> MovementSets;

        public List<CharacterFlockingProperties> FlockingProperties;
        public List<CharacterSwarmProperties> SwarmProperties;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterFiringPointEvaluator> FiringPointEvaluatorProperties;

        public List<CharacterReadyProperties> ReadyProperties;
        public List<CharacterEngageProperties> EngageProperties;
        public List<CharacterChargeProperties> ChargeProperties;
        public List<CharacterEvasionProperties> EvasionProperties;
        public List<CharacterCoverProperties> CoverProperties;
        public List<CharacterRetreatProperties> RetreatProperties;
        public List<CharacterSearchProperties> SearchProperties;
        public List<CharacterPreSearchProperties> PreSearchProperties;
        public List<CharacterIdleProperties> IdleProperties;
        public List<CharacterVocalizationProperties> VocalizationProperties;
        public List<CharacterBoardingProperties> BoardingProperties;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public List<CharacterKungfuProperties> KungfuProperties;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterBunkerBlock> BunkerProperties;

        public List<CharacterGuardianProperties> GuardianProperties;       
        public List<CharacterCombatformProperties> CombatformProperties;
       
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public List<CharacterEngineerProperties> EngineerProperties;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public List<CharacterInspectProperties> InspectProperties;

        public List<CharacterScarabProperties> ScarabProperties;
        public List<CharacterWeaponsProperties> WeaponsProperties;
        public List<CharacterFiringPatternProperties> FiringPatternProperties;
        public List<CharacterGrenadesProperties> GrenadesProperties;
        public List<CharacterVehicleProperties> VehicleProperties;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterFlyingMovementBlock> FlyingMovementProperties;

        public List<CharacterMorphProperties> MorphProperties;
        public List<CharacterEquipmentProperties> EquipmentProperties;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterStimuliResponseBlock> StimuliResponses;

        public List<MetagameBucket> CampaignMetagameBucket;
        public List<CharacterActAttachment> ActivityObjects;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<Gen4.Character.CharacterPainScreenBlock> PainScreenProperties;

        [Flags]
        public enum CharacterFlags : uint
        {
            None,
            Bit0 = 1 << 0,
            Bit1 = 1 << 1,
            Bit2 = 1 << 2,
            Bit3 = 1 << 3,
            Bit4 = 1 << 4,
            Bit5 = 1 << 5,
            Bit6 = 1 << 6
        }

        [TagStructure(Size = 0x14, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x18, MinVersion = CacheVersion.HaloReach)]
        public class CharacterVariant : TagStructure
        {
            [TagField(Flags = Label)]
            public StringId VariantName;
            public short VariantIndex;

            [TagField(Flags = Padding, Length = 2)]
            public byte[] Unused;

            public List<CharacterVoice> Voices;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public StringId DefaultDialogueEffectID;
        }

        [TagStructure(Size = 0xC)]
        public class CharacterVoiceProperties : TagStructure
        {
            public List<CharacterVoice> DialogueVariations;
        }

        [TagStructure(Size = 0x18, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x24, MinVersion = CacheVersion.HaloReach)]
        public class CharacterVoice : TagStructure
        {
            public CachedTag Dialogue;
            [TagField(Flags = Label)]
            public StringId Designator;
            public float Weight;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<RegionFilter> RegionFilters;

            [TagStructure(Size = 0x10)]
            public class RegionFilter : TagStructure
            {
                public StringId RegionName;
                public List<PermutationFilter> PermutationFilters;

                [TagStructure(Size = 0x4)]
                public class PermutationFilter : TagStructure
                {
                    public StringId PermutationName;
                }
            }
        }

        [Flags]
        public enum CharacterGeneralFlags : uint
        {
            None = 0,
            Swarm = 1 << 0,
            Flying = 1 << 1,
            DualWields = 1 << 2,
            UsesGravemind = 1 << 3,
            GravemindChorus = 1 << 4,
            DoNotTradeWeapon = 1 << 5,
            DoNotStowWeapon = 1 << 6,
            HeroCharacter = 1 << 7,
            LeaderIndependentPositioning = 1 << 8,
            HasActiveCamo = 1 << 9,
            UseHeadMarkerForLooking = 1 << 10,
            SpaceCharacter = 1 << 11,
            DoNotDropEquipment = 1 << 12,
            DoNotAllowCrouch = 1 << 13,
            DoNotAllowMovingCrouch = 1 << 14,
            CriticalBetrayal = 1 << 15,
            DeathlessCriticalBetrayal = 1 << 16,
            ArmorPreventsAssassination = 1 << 17, // Non-depleted ai-tracked damage sections prevent instant melee kills.
            DropAllWeaponsOnDeath = 1 << 18, // The default is to drop only the currently equipped weapon.
            DropNoWeaponsOnDeath = 1 << 19, // This will override 'drop all weapons'.
            ShieldPreventsAssassination = 1 << 20, // Cannot be assassinated unless its shield has been depleted.
            CannotBeAssassinated = 1 << 21 // This overrides all other character assassination modifications.
        }

        [TagStructure(Size = 0x1C, MaxVersion = Cache.CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x2C, MinVersion = Cache.CacheVersion.HaloReach)]
        public class CharacterGeneralProperties : TagStructure
        {
            public CharacterGeneralFlags Flags;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public ActorTypeEnum ActorType;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ActorTypeEnumReach ActorTypeReach;

            public short Rank; // The rank of this character, helps determine who should be a squad leader. (0 is lowly, 32767 is highest)
            public CombatPositioning FollowerPositioning; // Where should my followers try and position themselves when I am their leader?

            [TagField(Flags = Padding, Length = 2)]
            public byte[] Unused;

            public float MaximumLeaderDistance; // Don't let my combat range get outside this distance from my leader when in combat. (if 0 then defaults to 4wu)
            public float AbsoluteMaximumLeaderDistance;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MaximumPlayerDialogueDistance; // Never play dialogue if all players are outside of this range. (if 0 then defaults to 20wu)s

            public float Scariness; // The inherent scariness of the character.

            public CharacterGrenadeType DefaultGrenadeType;
            public CharacterBehaviorTreeRoot BehaviorTreeRoot; // Postgrenadepadding in h3mcc?

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<DisallowedWeapon> DisallowedWeaponsFromTrading;

            [TagStructure(Size = 0x10)]
            public class DisallowedWeapon : TagStructure
            {
                public CachedTag Weapon;
            }

            public enum CombatPositioning : short
            {
                InFrontOfMe,
                BehindMe,
                Tight
            }

            public enum CharacterBehaviorTreeRoot : short
            {
                Default,
                Flying
            }
        }

        [TagStructure(Size = 0x80, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x64, MinVersion = CacheVersion.HaloReach)]
        public class CharacterVitalityProperties : TagStructure
        {
            public CharacterVitalityFlags Flags;
            public float NormalBodyVitality; // maximum body vitality of our unit
            public float NormalShieldVitality; // maximum shield vitality of our unit
            public float LegendaryBodyVitality; // maximum body vitality of our unit (on legendary)
            public float LegendaryShieldVitality; // maximum shield vitality of our unit (on legendary)
            public float BodyRechargeFraction; // fraction of body health that can be regained after damage
            public float SoftPingShieldedThreshold; // damage necessary to trigger a soft ping when shields are up
            public float SoftPingUnshieldedThreshold; // damage necessary to trigger a soft ping when shields are down

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float SoftPingMinInterruptTime; // minimum time before a soft ping can be interrupted
            
            public float HardPingShieldedThreshold; // damage necessary to trigger a hard ping when shields are up
            public float HardPingUnshieldedThreshold; // damage necessary to trigger a hard ping when shields are down

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float HardPingMinInterruptTime; // minimum time before a hard ping can be interrupted
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HardPingCooldownTime;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float CurrentDamageDecayDelay; // current damage begins to fall after a time delay has passed since last the damage (MAX 4.1, because timer is stored in a char so 127 ticks maximum)
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float CurrentDamageDecayTime; // amount of time it would take for 100% current damage to decay to 0
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float RecentDamageDecayDelay; // recent damage begins to fall after a time delay has passed since last the damage (MAX 4.1, because timer is stored in a char so 127 ticks maximum)
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float RecentDamageDecayTime; // amount of time it would take for 100% recent damage to decay to 0
            
            public float BodyRechargeDelayTime; // amount of time delay before a shield begins to recharge
            public float BodyRechargeTime; // amount of time for shields to recharge completely
            public float ShieldRechargeDelayTime; // amount of time delay before a shield begins to recharge
            public float ShieldRechargeTime; // amount of time for shields to recharge completely

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float StunThreshold; // stun level that triggers the stunned state (currently, the 'stunned' behavior)
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Bounds<float> StunTimeBounds; // seconds
            
            public float ExtendedShieldDamageThreshold; // Amount of shield damage sustained before it is considered 'extended' (percent)
            public float ExtendedBodyDamageThreshold; // Amount of body damage sustained before it is considered 'extended' (percent)
            public float SuicideRadius; // when I die and explode, I damage stuff within this distance of me.
            public float RuntimeBodyRechargeVelocity;
            public float RuntimeShieldRechargeVelocity;
            public CachedTag ResurrectWeapon; // If I'm being automatically resurrected then I pull out a ...

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float PlayerDamageScale;

            [Flags]
            public enum CharacterVitalityFlags : int
            {
                None = 0,
                AutoResurrect = 1 << 0
            }
        }

        [TagStructure(Size = 0x34)]
        public class CharacterPlacementProperties : TagStructure
        {
            [TagField(Flags = Padding, Length = 4)]
            public byte[] Unused;

            public float FewUpgradeChanceEasy;
            public float FewUpgradeChanceNormal;
            public float FewUpgradeChanceHeroic;
            public float FewUpgradeChanceLegendary;
            public float NormalUpgradeChanceEasy;
            public float NormalUpgradeChanceNormal;
            public float NormalUpgradeChanceHeroic;
            public float NormalUpgradeChanceLegendary;
            public float ManyUpgradeChanceEasy;
            public float ManyUpgradeChanceNormal;
            public float ManyUpgradeChanceHeroic;
            public float ManyUpgradeChanceLegendary;
        }

        [TagStructure(Size = 0x2C, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0xA0, MinVersion = CacheVersion.HaloReach)]
        public class CharacterPerceptionProperties : TagStructure
        {
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CharacterPerceptionMode PerceptionMode;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123, EnumType = typeof(uint))]
            [TagField(MinVersion = CacheVersion.HaloReach, EnumType = typeof(ushort))]
            public CharacterPerceptionFlags Flags;

            public float MaxVisionDistance; // maximum range of sight (world units)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ReliableVisionDistance; // reliable range of sight
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MaximumPeripheralVisionDistance; // maximum range of peripheral vision
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ReliablePeripheralVisionDistance; // reliable range of peripheral vision
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinimumPeripheralVisionDistance; // (at peripheral vision angle)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinimumReliablePeripheralVisionDistance; // (at peripheral vision angle)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float SurpriseDistance; // if a new prop is acknowledged within the given distance, surprise is registered
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Angle FocusInteriorAngle; // horizontal angle within which we see targets out to our max range
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Angle FocusExteriorAngle; // horizontal angle within which we can see targets between max and min range

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Angle CentralVisionAngle; // horizontal angle within which we see targets out to our maximum range
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Angle MaxVisionAngle; // maximum horizontal angle within which we see targets at range
            
            public Angle PeripheralVisionAngle; // maximum horizontal angle within which we can see targets out of the corner of our eye

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float PeripheralDistance; // maximum range at which we can see targets our of the corner of our eye (world units)
            
            public float HearingDistance; // maximum range at which sounds can be heard (world units)
            public float NoticeProjectileChance; // random chance of noticing a dangerous enemy projectile, e.g. grenade (0-1)
            public float NoticeVehicleChance; // random chance of noticing a dangerous vehicle (0-1)
            public float PerceptionTime; // time required to acknowledge a visible enemy (seconds)

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float FirstAcknowledgeSurpriseDistance; // If a new prop is acknowledged within the given distance, surprise is registered

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AwarenessGlanceLevel; // While acknowledging, the awareness delta at which an AI will glance at you
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AwarenessGlanceDelta; // The chance that an AI identifies a unit is actually a hologram
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float IdentifyHologramChance; // [0, 1] The time after which we will ignore the hologram once seen
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> HologramIgnoreTimer; // (seconds) The number of seconds taken off of the ignore timer each time the hologram is shot
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HologramIgnoreTimerShotPenalty; // (seconds) Distance below which the AI becomes aware of you even if you are camouflaged, normal difficulty
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float CamoEnemyVisibleDistanceNormal; // (wu) Distance below which the AI becomes aware of you even if you are camouflaged, lengendary difficulty
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float CamoEnemyVisibleDistanceLegendary; // (wu)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public TagFunction Function;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ActiveCamoPerceptionProperties NormalActiveCamoPerception;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ActiveCamoPerceptionProperties LegendaryActiveCamoPerception;

            [Flags]
            public enum CharacterPerceptionFlags : ushort
            {
                None = 0,
                CharacterCanSeeInDarkness = 1 << 0,
                IgnoreTrackingProjectiles = 1 << 1,
                IgnoreMinorTrackingProjectiles = 1 << 2
            }

            public enum CharacterPerceptionMode : short
            {
                Idle,
                Alert,
                Combat,
                Search,
                Patrol,
                VehicleIdle,
                VehicleAlert,
                VehicleCombat
            }

            [TagStructure(Size = 0x18)]
            public class ActiveCamoPerceptionProperties : TagStructure
            {
                // this amount of active camouflage makes a target 'partially invisible'
                public float PartialInvisAmount; // [0,1]
                // maximum vision distance for partially invisible targets. 0= unlimited
                public float PartialInvisVisionDistance; // world units
                // multiplier on our awareness speed for partially invisible targets. 0= no change. Should be in (0, 1].
                public float PartialInvisAwarenessMultiplier; // [0,1]
                // this amount of active camouflage makes a target 'fully invisible'
                public float FullInvisAmount; // [0,1]
                // maximum vision distance for fully invisible targets. 0= unlimited
                public float FullInvisVisionDistance; // world units
                // multiplier on our awareness speed for fully invisible targets. 0= no change. Should be in (0, 1].
                public float FullInvisAwarenessMultiplier; // [0,1]
            }
        }

        [TagStructure(Size = 0x50)]
        public class CharacterLookProperties : TagStructure
        {
            public RealEulerAngles2d MaximumAimingDeviation; // how far we can turn our weapon (degrees)
            public RealEulerAngles2d MaximumLookingDeviation; // how far we can turn our head (degrees)
            public RealEulerAngles2d RuntimeAimingDeviationCosines;
            public RealEulerAngles2d RuntimeLookingDeviationCosines;
            public Angle NoncombatLookDeltaL; // how far we can turn our head left away from our aiming vector when not in combat (degrees)
            public Angle NoncombatLookDeltaR; // how far we can turn our head right away from our aiming vector when not in combat (degrees)
            public Angle CombatLookDeltaL; // how far we can turn our head left away from our aiming vector when in combat (degrees)
            public Angle CombatLookDeltaR; // how far we can turn our head right away from our aiming vector when in combat (degrees)
            public Bounds<float> NoncombatIdleLooking; // rate at which we change look around randomly when not in combat (seconds)
            public Bounds<float> NoncombatIdleAiming; // rate at which we change aiming directions when looking around randomly when not in combat (seconds)
            public Bounds<float> CombatIdleLooking; // rate at which we change look around randomly when searching or in combat (seconds)
            public Bounds<float> CombatIdleAiming; // rate at which we change aiming directions when looking around randomly when searching or in combat (seconds)
        }

        [TagStructure(Size = 0x2C, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0xA4, MinVersion = CacheVersion.HaloReach)]
        public class CharacterMovementProperties : TagStructure
        {
            [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123)]
            public CharacterMovementFlagsH3 FlagsH3;
            [TagField(MinVersion = CacheVersion.HaloReach, MaxVersion = CacheVersion.HaloReach11883)]
            public CharacterMovementFlagsReach FlagsReach;
            [TagField(Version = CacheVersion.Halo4)]
            public CharacterMovementFlagsH4 FlagsH4;
            public float PathfindingRadius;
            public float DestinationRadius;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ArmorLockChance; // chance AI will use armor lock, if they have it
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ArmorLockChanceWhenStuck; // chance AI will use armor lock when stuck with a grenade
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ArmorLockSafetyDuration; // seconds we will stay in armor lock after danger has passed
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ArmorLockMaximumDuration; // the longest we will stay in armor lock regardless of danger
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ArmorLockCooldown; // won't go into armor lock again for this many seconds

            public float DiveGrenadeChance;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float BraceGrenadeChance;

            public AiSize ObstacleLeapMinSize;
            public AiSize ObstacleLeapMaxSize;
            public AiSize ObstacleIgnoreSize;
            public AiSize ObstaceSmashableSize;

            [TagField(Flags = Padding, Length = 2)]
            public byte[] Unused = new byte[2];

            public CharacterJumpHeight JumpHeight;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MaximumLeapHeight; // how high can a crate be for this unit to leap it
            // how close to the obstacle should the actor be before leaping
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float LeapProximityFraction; // 1- too close, 0- as soon as he becomes aware of it
            // max distance penalty applied to an avoidance volume search path if we're facing away from the path
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AvoidanceVolumeTurnPenaltyDistance; // 1000 wu good for space, 5 wu good for ground

            public CharacterMovementHintFlags MovementHints;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float ThrottleScale;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float ThrottleDampening; // 0 = slow change in throttle, 1 = fast change in throttle
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float WalkDistance; // Under this distance, actors will walk instead of run (world units)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int MinimumMovementTicks; // ticks
            // If the character changes movement direction by more than this angle, he will have to move for at least minimum
            // movement ticks until he can change his mind.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinimumMovementTicksResetAngle; // degrees
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<MovementStationaryPauseBlock> ChangeDirectionPause;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MaximumThrottle; // [0-1]  the character will never throttle beyond this value
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinimumThrottle; // [0-1] the character will not throttle below this value
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<MovementThrottleControlBlock> MovementThrottleControl;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinimumJukeThrottle; // [0-1] The character will consider juking at this throttle and above
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Angle MinimumDirectionChangeJukeAngle; // If we change movement direction by more this angle, we will attempt a juke
            // Probability to do a juke for a given tick, even if you are not planning to change direction (and provided you have
            // not already performed a juke within the timeout time
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float NonDirectionChangeJukeProbability;
            // After you do a change or no change of direction juke, you cannot perform a NON directional change juke for at least
            // this many seconds. Direction change jukes will still happen
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float NonDirectionChangeJukeTimeout; // seconds
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int MinimumPostJukeMovementTicks; // ticks the actor keep moving after a juke. This may lower juke frequency.
            // If this actor translates during turn animations, enter a radius that encloses the translation.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float StationaryTurnRadius; // [wu]
            // Distance to move as per the move_localized firing position evaluator (0 value resolves to 5wu)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float LocalizedMoveDistance; // [wu]
            // Distance to move as per the move_distance firing position evaluator (0 value resolves to 5wu for min, 10wu for max)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> MoveDistance; // [wu]
            // Distance to move as per the vehicle_move_distance firing position evaluator (0 value resolves to 5wu for min, 10wu
            // for max)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> VehicleMoveDistance; // [wu]
            // Actor will face away from his target and run to his destination if his target at a larger distance than this
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float TurnAndRunDistanceFromTarget; // wus
            // Firing point must be at least this distance away from the actor for him to consider turning and running to it
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float TurnAndRunDistanceToDestination; // wus
            // When following a unit, such as the player, this is the additional buffer outside of the task follow radius that we
            // are allowed to position ourselves before full firing position avoidance kicks in
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float FollowUnitBufferDistance; // wus

            [TagStructure(Size = 0x8)]
            public class MovementStationaryPauseBlock : TagStructure
            {
                public Angle DirectionChangeAngle; // degrees
                public int StationaryChange; // ticks
            }

            [TagStructure(Size = 0x10)]
            public class MovementThrottleControlBlock : TagStructure
            {
                // When combat status is bigger or equal to this combat status, use the throttle settings below.
                public CombatStatusEnum CombatStatus;
                public MovementThrottleControlFlags Flags;
                public List<MovementThrottleBlock> ThrottleSettings;

                public enum CombatStatusEnum : short
                {
                    Asleep,
                    Idle,
                    Alert,
                    Active,
                    UninspectedOrphan,
                    DefiniteOrphan,
                    CertainOrphan,
                    VisibleEnemy,
                    ClearEnemyLos,
                    DangerousEnemy
                }

                [Flags]
                public enum MovementThrottleControlFlags : ushort
                {
                    ResampleDistanceEveryTick = 1 << 0
                }

                [TagStructure(Size = 0x8)]
                public class MovementThrottleBlock : TagStructure
                {
                    // If AI needs to move at greater or equal to this distance, they will move at the given throttle
                    public float Distance; // wus
                    // Throttle scale between minimum and maximum throttle
                    public float ThrottleScale; // [0-1]
                }
            }
        }

        [TagStructure(Size = 0x18)]
        public class CharacterFlockingProperties : TagStructure
        {
            public float DecelerationDistance;
            public float NormalizedSpeed;
            public float BufferDistance;
            public Bounds<float> ThrottleThresholdBounds;
            public float DecelerationStopTime;
        }

        [TagStructure(Size = 0x38)]
        public class CharacterSwarmProperties : TagStructure
        {
            [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.Halo3ODST)]
            public CharacterSwarmFlags Flags;

            public short ScatterKilledCount;

            [TagField(Flags = Padding, Length = 2, Platform = CachePlatform.Original)]
            [TagField(Flags = Padding, Length = 2, Platform = CachePlatform.MCC, MinVersion = CacheVersion.HaloReach)]
            public byte[] Unused;

            public float ScatterRadius; // the distance from the target that the swarm scatters
            public float ScatterTime; // amount of time to remain scattered
            public Bounds<float> HoundDistance;
            public Bounds<float> InfectionTime; // how long the infection form and its victim will wrestle before the point of no return
            public float PerlinOffsetScale; // amount of randomness added to creature's throttle [0-1]
            public Bounds<float> OffsetPeriod; // how fast the creature changes random offset to throttle (seconds)
            public float PerlinIdleMovementThreshold; // a random offset lower then given threshold is made 0. (threshold of 1 = no movement)
            public float PerlinCombatMovementThreshold; // a random offset lower then given threshold is made 0. (threshold of 1 = no movement)
            public float StuckTime; // how long we have to move (stuck distance) before we get deleted
            public float StuckDistance; // how far we have to move in (stuck time) to not get deleted

            [Flags]
            public enum CharacterSwarmFlags : short
            {
                None = 0,
                IgnoreAttachmentVitalityThreshold = 1 << 0
            }
        }

        [TagStructure(Size = 0x8)]
        public class CharacterReadyProperties : TagStructure
        {
            public Bounds<float> ReadyTimeBounds;
        }

        [TagStructure(Size = 0x28, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x38, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x60, MinVersion = CacheVersion.HaloReach)]
        public class CharacterEngageProperties : TagStructure
        {
            public CharacterEngageFlags Flags;
            public Bounds<float> RepositionBounds; // How long should I remain at a firing position before moving? (0 values will use the default values of 6 and 7 seconds)
            public float CrouchDangerThreshold; // When danger rises above the threshold, the actor crouches
            public float StandDangerThreshold; // When danger drops below this threshold, the actor can stand again.
            public float FightDangerMoveThreshold; // When danger goes above given level, this actor switches firing positions

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<short> FightDangerMoveThresholdCooldown; // (ticks) Wait at least this many ticks before relocating due to danger
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float FightFlankChance; // [0-1] Chance of flanking when fighting someone who isn't paying attention to me

            public CachedTag OverrideGrenadeProjectile; // when I throw a grenade, forget what type I officially have

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> ThrowDistance; // (wu) Targets outside this range will not be attacked with a throw
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ThrowSearchRadius; // How far does actor search for throwable items
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Angle ThrowSearchAngle; // Angle (degrees) that the actor searches for throwable items (from his facing direction)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MaximumThrowForce; // Maximum throw force - it will not be used all the time
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ThrowTargetPointOffset; // Vertical offset from target position on ground where throw is aimed
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> ThrowDelay; // Delay until another throw is attempted

            //If we are not holding a weapon, or we don't know how to use our weapon, use these bounds on my combat range
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public Bounds<float> DefaultCombatRange; // wu
            //If we don't know how to use our weapon, use these bounds on my firing range
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public Bounds<float> DefaultFiringRange;

            [Flags]
            public enum CharacterEngageFlags : uint
            {
                None = 0,
                EngagePerch = 1 << 0,
                FightConstantMovement = 1 << 1,
                FlightFightConstantMovement = 1 << 2,
                DisallowCombatCrouching = 1 << 3,
                DisallowCrouchShooting = 1 << 4,
                FightStable = 1 << 5,
                ThrowShouldLob = 1 << 6,
                AllowPositioningBeyondIdealRange = 1 << 7,
                CanSuppress = 1 << 8,
                PrefersBunker = 1 << 9,
                BurstInhibitsEvasion = 1 << 10
            }
        }

        [TagStructure(Size = 0x7C, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x9C, MinVersion = CacheVersion.HaloReach)]
        public class CharacterChargeProperties : TagStructure
        {
            public CharacterChargeFlags Flags;
            public float MeleeConsiderRange;
            public float MeleeChance; // chance of initiating a melee within a 1 second period
            public float MeleeAttackRange;
            public float MeleeAbortRange;
            public float MeleeAttackTimeout; // Give up after given amount of time spent charging (seconds)
            public float MeleeAttackDelayTimer; // don't attempt again before given time since last melee (seconds)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MeleeArmorLockDelay; // don't attempt a melee on a recently armor locked target for this many seconds

            public Bounds<float> MeleeLeapRange;
            public float MeleeLeapChance;
            public float IdealLeapVelocity;
            public float MaxLeapVelocity;
            public float MeleeLeapBallistic;
            public float MeleeDelayTimer; // time between melee leaps (seconds)
            public float LeaderAbandonedBerserkChance; // chance for a leader to berserk when all his followers die (actually charge, NOT berserk, but I'm not changing the name of the variable)
            public Bounds<float> ShieldDownBerserkChance; // lower bound is chance to berserk at max range, upper bound is chance to berserk at min range, requires shield depleted berserk impulse
            public Bounds<float> ShielddownBerserkRanges;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float FriendlyKilledMaxBerserkDistance; // max range at which we will go berserk if we see a friendly AI of the same type (brute, etc) get killed
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float PeerKilledBerserkChance; // Chance that we will go berserk if we see a friendly AI of the same type(brute, etc) with the same or lower standing get killed
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float LeaderKilledBerserkChance; // Chance that we will go berserk if we see a friendly AI of the same type (brute, etc) with higher standing get killed
            
            [TagField(Flags = Label)]
            public CachedTag BerserkWeapon; // when I berserk, I pull out a ...

            public float BeserkCooldown; // Time that I will stay in beserk after losing my target, and then revert back to normal (seconds)

            //If our target is closer than this distance, and not (in a vehicle/larger size than us/using a melee weapon), we will berserk.
            //If our target is further than this distance, we will stop berserking. Set to 0 to disable proximity berserking.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ProximityBerserkRange;
            //We will never go more than this far outside our firing point areas when proximity-berserking. 0= no limit.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ProximityBerserkOutsideFpRange;
            //If we have a target close enough to berserk, this is the chance that we will do so. If chance fails, we will try again after timeout.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ProximityBerserkChance;
            //We will not proximity-berserk unless it has been at least this long since we last stopped berserking. 0= no timeout.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ProximityBerserkTimeout;

            public float BrokenKamikazeChance; // Probability that I will run the kamikaze behaviour when my leader dies.
            public float PerimeterRange; // How far we will melee charge outside our firing points before starting perimeter (defaults to 5wu)
            public float PerimeterRangeClose; // How far we will melee charge outside our firing points before starting perimeter when the target is close to me (within 3wu) (defaults to 9wu)
            public float PerimeterDamageTimeout; // How long will we take damage from our target before either seeking cover or berserking (defaults to 3secs)
            public List<CharacterChargeDifficultyLimit> DifficultyLimits;

            [Flags]
            public enum CharacterChargeFlags : int
            {
                None = 0,
                OffhandMeleeAllowed = 1 << 0,
                BerserkWheneverCharge = 1 << 1,
                DoNotUseBerserkMode = 1 << 2,
                DoNotStowWeaponDuringBerserk = 1 << 3,
                AllowDialogueWhileBerserking = 1 << 4,
                DoNotPlayBerserkAnimation = 1 << 5,
                DoNotShootDuringCharge = 1 << 6,
                AllowLeapWithRangedWeapons = 1 << 7,
                PermanentBerserkOnceInitiated = 1 << 8
            }

            [TagStructure(Size = 0x6)]
            public class CharacterChargeDifficultyLimit : TagStructure
            {
                public short MaximumKamikazeCount; // How many guys in a single clump can be kamikazing at one time
                public short MaximumBerserkCount; // How many guys in a single clump can be berserking at one time
                public short MinimumBerserkCount; // We'd like at least this number of guys in a single clump can be berserking at one time (primarily combat forms)
            }
        }

        [TagStructure(Size = 0x14)]
        public class CharacterEvasionProperties : TagStructure
        {
            public float EvasionDangerThreshold; // Consider evading when immediate danger surpasses threshold
            public float EvasionDelayTimer; // Wait at least this delay between evasions
            public float EvasionChance; // If danger is above threshold, the chance that we will evade. Expressed as chance of evading within a 1 second time period
            public float EvasionProximityThreshold; // If target is within given proximity, possibly evade
            public float DiveRetreatChance; // Chance of retreating (fleeing) after danger avoidance dive
        }

        [TagStructure(Size = 0x54, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x58, MinVersion = CacheVersion.HaloReach)]
        public class CharacterCoverProperties : TagStructure
        {
            public CharacterCoverFlags Flags;
            public Bounds<float> HideBehindCoverTime; // how long we stay behind cover after seeking cover (seconds)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> HologramCoverWaitTime; //how long we wait in cover before using the hologram
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HologramCooldownDelay; //Amount of time I will wait before trying to use hologram equipment again (0 value defaults to 5 seconds)

            public float CoverShieldFraction; // Only cover when shield falls below this level
            public float CoverVitalityThreshold; // Only cover when vitality falls below this level

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float DisallowCoverDistance; // Disallow covering from visible target closer than this distance (world units)
            
            public float CoverDangerThreshold; // Danger must be this high to cover. At a danger level of 'danger threshold', the chance of seeking cover is the cover chance lower bound (below)

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float DangerUpperThreshold; // At or above danger level of upper threshold, the chance of seeking cover is the cover chance upper bound (below)

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Bounds<float> CoverChanceBounds; // Bounds on the chances of seeking cover, given the above conditions are valid.
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Bounds<float> ShieldedCoverChance; // Bounds on the chances of seeking cover when shielded, given the above conditions are valid.

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinDefensiveDistanceFromTarget; //How far from the target should we switch from aggresive to defensive covering (0 always defensive, big number always offensive)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinDefensiveDistanceFromCover; //If our cover point is less than this distance, we will never consider defensive covering
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AlwaysDefensiveScaryThreshold; //If the target has scarines bigger or equal to this, we will always cover defensively

            public float CoverCheckDelay; // Amount of time I will wait before trying again after covering (0 value defaults to 2 seconds)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float CoverPinnedDownCheckDelay;//Amount of time I will wait before issuing a pinned down message (0 value defaults to 2 seconds)

            public float EmergeShieldThreshold; // Emerge from cover when shield fraction reaches threshold
            public float ProximitySelfPreserve; // Triggers self-preservation when target within this distance (assuming proximity_self_preserve_impulse is enabled)
            public float ProximityMeleeDistance; // When self preserving from a target less than given distance, causes melee attack (assuming proximity_melee_impulse is enabled)
            public float UnreachableEnemyDangerThreshold; // When danger from an unreachable enemy surpasses threshold, actor cover (assuming unreachable_enemy_cover impulse is enabled)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float UnassailableEnemyDangerThreshold;

            public float ScaryTargetThreshold; // When target is aware of me and surpasses the given scariness, self-preserve (assuming scary_target_cover_impulse is enabled)

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float ShieldDepletedCoverChance; // Probability of going straight into cover when shield is depleted (assuming shield_depleted_cover_impulse is enabled)
            
            public float VitalityFractionShieldEquipment; // Fraction of vitality below which an equipped shield equipment (instant cover/bubbleshield) will be activated (once damage has died down, and assuming shield_equipment_impulse is enabled)
            public float RecentDamageShieldEquipment; // Must have less than this amount of recent body damage before we can deploy our equipped shield equipment.

            [Flags]
            public enum CharacterCoverFlags : int
            {
                UnassailableCoverEndsOnlyWhenTargetAssailable = 0,
                UsePhasing = 1 << 1
            }

        }

        [TagStructure(Size = 0x58)]
        public class CharacterRetreatProperties : TagStructure
        {
            public CharacterRetreatFlags Flags;
            public float ShieldThreshold; // When shield vitality drops below given amount, retreat is triggered by low_shield_retreat_impulse
            public float ScaryTargetThreshold; // When confronting an enemy of over the given scariness, retreat is triggered by scary_target_retreat_impulse
            public float DangerThreshold; // When perceived danger rises above the given threshold, retreat is triggered by danger_retreat_impulse
            public float ProximityThreshold; // When enemy closer than given threshold, retreat is triggered by proximity_retreat_impulse
            public Bounds<float> ForcedCowerTimeBounds; // actor cowers for at least the given amount of time
            public Bounds<float> CowerTimeBounds; // actor times out of cower after the given amount of time
            public float ProximityAmbushThreshold; // If target reaches is within the given proximity, an ambush is triggered by the proximity ambush impulse
            public float AwarenessAmbushThreshold; // If target is less than threshold (0-1) aware of me, an ambush is triggered by the vulnerable enemy ambush impulse
            public float LeaderDeadRetreatChance; // If leader-dead-retreat-impulse is active, gives the chance that we will flee when our leader dies within 4 world units of us
            public float PeerDeadRetreatChance; // If peer-dead-retreat-impulse is active, gives the chance that we will flee when one of our peers (friend of the same race) dies within 4 world units of us
            public float SecondPeerDeadRetreatChance; // If peer-dead-retreat-impulse is active, gives the chance that we will flee when a second peer (friend of the same race) dies within 4 world units of us
            public float FleeTimeout; // Flee for no longer than this time (if there is no cover, then we will keep fleeing indefinitely). Value of 0 means 'no timeout' (seconds)
            public Angle ZigZagAngle; // The angle from the intended destination direction that a zig-zag will cause
            public float ZigZagPeriod; // How long it takes to zig left and then zag right.
            public float RetreatGrenadeChance; // The likelihood of throwing down a grenade to cover our retreat
            public CachedTag BackupWeapon; // If I want to flee and I don't have flee animations with my current weapon, throw it away and try a ...

            [Flags]
            public enum CharacterRetreatFlags : int
            {
                None = 0,
                ZigZagWhenFleeing = 1 << 0
            }
        }

        [TagStructure(Size = 0x20, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x2C, MinVersion = CacheVersion.HaloReach)]
        public class CharacterSearchProperties : TagStructure
        {
            public CharacterSearchFlags Flags;
            public Bounds<float> SearchTime;
            public float SearchDistance; // Max distance from our firing positions that we can search (0 value will default to 3wu). Does not affect vehicle search distance (see maxd if you want that value too).
            public Bounds<float> UncoverDistanceBounds; // Distance of uncover point from target. Hard lower limit, soft upper limit.
            public float OrphanOffset; // (0 value will default to 1.8wu)
            public float MinimumOffset; // Minimum offset from the target point to investigate, otherwise we just use the target point itself. Not entirely sure about the justification for this one...

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> VocalizationTime;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float PerformanceCooldownTime; //The number of seconds that must elapse before an actor will consider a search-performance again

            [Flags]
            public enum CharacterSearchFlags : int
            {
                None = 0,
                CrouchOnInvestigate = 1 << 0,
                WalkOnPursuit = 1 << 1,
                SearchForever = 1 << 2,
                SearchExclusively = 1 << 3,
                SearchPointsOnlyWhileWalking = 1 << 4
            }
        }

        [TagStructure(Size = 0x28, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x24, Platform = CachePlatform.MCC, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x28, Platform = CachePlatform.MCC, MinVersion = CacheVersion.HaloReach)]
        public class CharacterPreSearchProperties : TagStructure
        {
            public CharacterPreSearchFlags Flags;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Bounds<float> MinimumPreSearchTime; // If the min presearch time expires and the target is (actually) outside the min-certainty radius, presearch turns off (seconds)
            
            public Bounds<float> MaximumPreSearchTime; // Presearch turns off after the given time (seconds)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MaximumSuppressTime;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float MinimumCertaintyRadius;
            [TagField(Platform = CachePlatform.Original, MaxVersion = CacheVersion.HaloOnline700123)]
            public float DEPRECATED;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Bounds<float> MinimumSuppressingTime; // if the min suppressing time expires and the target is outside the min-certainty radius, suppressing fire turns off
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public short MaxSuppressCount; // the maximum number of guys allowed to be suppressing at one time
            [TagField(Length = 2, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.HaloOnline700123)]
            public byte[] Padding;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float SuppressingFireWeight;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float UncoverWeight;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float LeapOnCoverWeight;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float DestroyCoverWeight;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float GuardWeight;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float InvestigateWeight;

            [Flags]
            public enum CharacterPreSearchFlags : int
            {
                None = 0,
                Flag1 = 1 << 0
            }
        }

        [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo3ODST)]
        public class CharacterIdleProperties : TagStructure
        {
            [TagField(Flags = Padding, Length = 4)]
            public byte[] Unused;

            public Bounds<float> IdlePoseDelayTime; // time range for delays between idle poses (seconds)

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public Bounds<float> WanderDelayTime;
        }

        [TagStructure(Size = 0xC)]
        public class CharacterVocalizationProperties : TagStructure
        {
            public float CharacterSkipFraction; // [0,1]
            public float LookCommentTime; // How long does the player look at an AI before the AI responds? (seconds)
            public float LookLongCommentTime; // How long does the player look at the AI before he responds with his 'long look' comment? (seconds)
        }

        [TagStructure(Size = 0x14, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloReach)]
        public class CharacterBoardingProperties : TagStructure
        {
            public CharacterBoardingFlags Flags;
            public float MaximumDistance; // maximum distance from entry point that we will consider boarding (world units)
            public float AbortDistance; // give up trying to get in boarding seat if entry point is further away than this (world units)
            public float MaximumSpeed; // maximum speed at which we will consider boarding (world units)
            public float BoardTime; // maximum time we will melee board for (seconds)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> BoardingTimeout; // seconds
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<CharacterVehicleBoardingBlock> VehicleSpecificProperties;

            [Flags]
            public enum CharacterBoardingFlags : int
            {
                None = 0,
                AirborneBoarding = 1 << 0
            }

            [TagStructure(Size = 0x14)]
            public class CharacterVehicleBoardingBlock : TagStructure
            {
                [TagField(ValidTags = new[] { "unit" })]
                public CachedTag Vehicle;
                public VehicleBoardingFlags Flags;

                [Flags]
                public enum VehicleBoardingFlags : uint
                {
                    BoardingDoesNotEnterSeat = 1 << 0
                }
            }
        }

        [TagStructure(Size = 0x8)]
        public class CharacterKungfuProperties : TagStructure
        {
            public float KungfuOverrideDistance; // If the player is within this distance, open fire, even if your task is kungfu-fight disallowed (wus)
            public float KungfuCoverDangerThreshold; // If you are kungfu disallowed and your danger is above this level, take cover (wus)
        }

        [TagStructure(Size = 0x18)]
        public class CharacterGuardianProperties : TagStructure
        {
            public float SurgeTime; //length of time for which the guardian surges (seconds)
            public float SurgeDelay; //minimum enforced delay between surges (seconds)
            public float ProximitySurgeDistance; //surge when our target gets closer than this to me (0 value defaults to 2wu)
            public float PhaseTime; //length of time it takes the guardian to get to its phase destination (seconds)
            public float MinPhaseDistance; //Minimum distance that I will consider phasing (world units)
            public float TargetPhaseDistance; //Minimum distance from my target that I will phase to (world units)
        }

        [TagStructure(Size = 0x8)]
        public class CharacterCombatformProperties : TagStructure
        {
            public float BerserkDistance; // Distance at which the combatform will be forced into berserking. (world units)
            public float BerserkChance; // Chance of which the combatform will be forced into berserking this second.
        }

        [TagStructure(Size = 0x38)]
        public class CharacterEngineerProperties : TagStructure
        {
            public float DeathHeight; // try and rise this amount before dying (wu)
            public float DeathRiseTime; // spend this time rising (seconds)
            public float DeathDetonationTime; // spend this time detonating (seconds)
            public float ShieldBoostRadiusMax; // Boost the shields of allies within this radius during combat

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float ShieldBoostRadiusMin; // Allies within this radius get maximum shield boost

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ShieldBoostPeriod;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public float ShieldBoostVitality; // Boost allies' shields by this amount during combat

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public StringId ShieldBoostDamageSectionName;

            /* Detonation Thresholds */
            public float DetonationShieldThreshold;
            public float DetonationBodyVitality;
            public float ProximityRadius; // if target enters within this radius, either detonate or deploy equipment (wus)
            public float ProximityDetonationChance; // chance of detonating if target enters the drain radius radius

            [TagField(ValidTags = new[] { "eqip" })]
            public CachedTag ProximityEquipment; // if target enters radius and detonation is not chosen, deploy this equipment.
        }

        [TagStructure(Size = 0x8, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo3ODST)]
        public class CharacterInspectProperties : TagStructure
        {
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public float StopDistance; // distance from object at which to stop and turn on the inspection light (wu)

            public Bounds<float> InspectTime; // time which we should inspect each object for (seconds)

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public Bounds<float> SearchRange; // range in which we should search for objects to inspect (wu)
        }

        [TagStructure(Size = 0x18)]
        public class CharacterScarabProperties : TagStructure
        {
            public float FightingMinDistance; // When target within this distance, the scarab will back up (world units)
            public float FightingMaxDistance; // When target outside this distance, the scarab will chase (world units)
            public Bounds<float> AnticipatedAimRadius; // When within these bounds distance from the target, we blend in our anticipated facing vector (world units)
            public float SnapForwardAngle; // When moving forward within this dot of our desired facing, just move forward [0-1]
            public float SnapForwardAngleMax; // When moving forward within this dot of our desired facing, just move forward [0-1]
        }

        [TagStructure(Size = 0xE0, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0xC4, MinVersion = CacheVersion.HaloReach)]
        public class CharacterWeaponsProperties : TagStructure
        {
            public CharacterWeaponFlags Flags;

            [TagField(Flags = Label)]
            public CachedTag Weapon;

            public float MaximumFiringRange; // we can only fire our weapon at targets within this distance (world units)
            public float MinimumFiringRange; // weapon will not be fired at target closer than given distance (world units)
            public Bounds<float> NormalCombatRange; // (world units)
            public float BombardmentRange; // we offset our burst targets randomly by this range when firing at non-visible enemies (zero = never)
            public float MaxSpecialTargetDistance; // Specific target regions on a vehicle or unit will be fired upon only under the given distance

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Bounds<float> TimidCombatRange; // (world units)
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public Bounds<float> AggressiveCombatRange; // (world units)
            
            public float SuperBallisticRange; // we try to aim our shots super-ballistically if target is outside this range (zero = never)
            public Bounds<float> BallisticFiringBounds; // At the min range, the min ballistic fraction is used, at the max, the max ballistic fraction is used (world units)
            public Bounds<float> BallisticFractionBounds; // Controls speed and degree of arc. 0 = high, slow, 1 = low, fast [0-1]
            public Bounds<float> FirstBurstDelayTimeBounds; // (seconds)
            public float SurpriseDelayTime; // (seconds)
            public float SurpriseFireWildlyTime; // (seconds)
            public float DeathFireWildlyChance; // [0-1]
            public float DeathFireWildlyTime; // (seconds)
            public RealVector3d CustomStandGunOffset; // custom standing gun offset for overriding the default in the base actor
            public RealVector3d CustomCrouchGunOffset; // custom crouching gun offset for overriding the default in the base actor
            public CharacterWeaponSpecialFireMode SpecialFireMode; // the type of special weapon fire that we can use
            public CharacterWeaponSpecialFireSituation SpecialFireSituation; // when we will decide to use our special weapon fire mode
            public float SpecialFireChance; // how likely we are to use our special weapon fire mode [0,1]
            public float SpecialFireDelay; // how long we must wait between uses of our special weapon fire mode (seconds)
            public float SpecialDamageModifier; // damage modifier for special weapon fire (applied in addition to the normal damage modifier. zero = no change) [0,1]
            public Angle SpecialProjectileError; // projectile error angle for special weapon fire (applied in addition to the normal error)
            public Bounds<float> DropWeaponLoadedBounds; // amount of ammo loaded into the weapon that we drop (in fractions of a clip, e.g. 0.3 to 0.5)
            public Bounds<short> DropWeaponAmmoBounds; // total number of rounds in the weapon that we drop (ignored for energy weapons)
            public Bounds<float> NormalAccuracyBounds; // indicates starting and ending accuracies at normal difficulty
            public float NormalAccuracyTime; // the amount of time it takes the accuracy to go from starting to ending
            public Bounds<float> HeroicAccuracyBounds; // indicates starting and ending accuracies at heroic difficulty
            public float HeroicAccuracyTime; // the amount of time it takes the accuracy to go from starting to ending
            public Bounds<float> LegendaryAccuracyBounds; // indicates starting and ending accuracies at legendary difficulty
            public float LegendaryAccuracyTime; // the amount of time it takes the accuracy to go from starting to ending

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public List<CharacterFiringPattern> FiringPatterns;

            public CachedTag WeaponMeleeDamage;

            [Flags]
            public enum CharacterWeaponFlags : int
            {
                None = 0,
                BurstingInhibitsMovement = 1 << 0,
                MustCrouchToShoot = 1 << 1,
                UseExtendedSafeToSaveRange = 1 << 2,
                FixedAimingVector = 1 << 3,
                AimAtFeet = 1 << 4,
                ForceAimFromBarrelPosition = 1 << 5, // Use only for weapons with really, really long barrels (bfg), do NOT use for rotating turret weapons (warthog, falcon, etc)
                FavorForLongRange = 1 << 6,
                FavorForCloseRange = 1 << 7,
                FavorAgainstVehicles = 1 << 8,
                FavoredSpecialWeapon = 1 << 9,
                BurstingInhibitsEvasion = 1 << 10
            }

            public enum CharacterWeaponSpecialFireMode : short
            {
                None,
                Overcharge,
                SecondaryTrigger
            }

            public enum CharacterWeaponSpecialFireSituation : short
            {
                Never,
                EnemyVisible,
                EnemyOutOfSight,
                Strafing
            }
        }

        [TagStructure(Size = 0x40)]
        public class CharacterFiringPattern : TagStructure
        {
            public float RateOfFire; // how many times per second we pull the trigger (zero = continuously held down)
            public float TargetTracking; // how well our bursts track moving targets. 0.0= fire at the position they were standing when we started the burst. 1.0= fire at current position [0-1]
            public float TargetLeading; // how much we lead moving targets. 0.0= no prediction. 1.0= predict completely [0-1]
            public float BurstOriginRadius; // how far away from the target the starting point is (world units)
            public Angle BurstOriginAngle; // the range from the horizontal that our starting error can be
            public Bounds<float> BurstReturnLengthBounds; // how far the burst point moves back towards the target (could be negative) (world units)
            public Angle BurstReturnAngle; // the range from the horizontal that the return direction can be
            public Bounds<float> BurstDurationBounds; // how long each burst we fire is
            public Bounds<float> BurstSeparationBounds; // how long we wait between bursts
            public float WeaponDamageModifier; // what fraction of its normal damage our weapon inflicts (zero = no modifier)
            public Angle ProjectileError; // error added to every projectile we fire
            public Angle BurstAngularVelocity; // the maximum rate at which we can sweep our fire (zero = unlimited) (degrees per second)
            public Angle MaximumErrorAngle; // cap on the maximum angle by which we will miss target (restriction on burst origin radius
        }

        [TagStructure(Size = 0x1C)]
        public class CharacterFiringPatternProperties : TagStructure
        {
            [TagField(Flags = Label)]
            public CachedTag Weapon;

            public List<CharacterFiringPattern> FiringPatterns;
        }

        [TagStructure(Size = 0x3C)]
        public class CharacterGrenadesProperties : TagStructure
        {
            public GrenadeFlags GrenadesFlags;
            [TagField(Flags = Label)]
            public CharacterGrenadeType GrenadeType; // type of grenades that we throw^
            public CharacterGrenadeTrajectoryType TrajectoryType; // how we throw our grenades

            [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public short MinimumEnemyCount; // how many enemies must be within the radius of the grenade before we will consider throwing there
            public float EnemyRadius; // we consider enemies within this radius when determining where to throw (world units)
            public float GrenadeIdealVelocity; // how fast we LIKE to throw our grenades (world units per second)
            public float GrenadeVelocity; // the fastest we can possibly throw our grenades (world units per second)
            public Bounds<float> GrenadeRange; // ranges within which we will consider throwing a grenade (world units)
            public float CollateralDamageRadius; // we won't throw if there are friendlies around our target within this range (world units)
            public float GrenadeChance; // how likely we are to throw a grenade in one second [0,1]
            public float GrenadeThrowCooldown; // How long we have to wait after throwing a grenade before we can throw another one (seconds)
            public float GrenadeUncoverChance; // how likely we are to throw a grenade to flush out a target in one second [0,1]
            public float AntiVehicleGrenadeChance; // how likely we are to throw a grenade against a vehicle [0,1]
            public Bounds<short> GrenadeCount; // number of grenades that we start with
            public float NoGrenadesDroppedChance; // how likely we are not to drop any grenades when we die, even if we still have some [0,1]

            [Flags]
            public enum GrenadeFlags : uint
            {
                DoNotThrowWhileBunkering = 1 << 0,
                AllowWhileBerserking = 1 << 1
            }

            public enum CharacterGrenadeTrajectoryType : short
            {
                Toss,
                Lob,
                Bounce
            }
        }

        [TagStructure(Size = 0xD0, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x138, MinVersion = CacheVersion.HaloReach)]
        public class CharacterVehicleProperties : TagStructure
        {
            public CachedTag Unit;
            public CachedTag Style;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float LookaheadTime; //How much in the future should we estimate a collision (affects collision ray length)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float RollChangeMagnitude; //How fast to control the roll avoidance
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float RollDecayMultiplier; //How fast roll goes back to 0- 1 means never, 0 means instantaneously
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float ThrottleGracePeriod; //How long after a collision should the vehicle keep moving at max throttle
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float MinimumThrottle; //Minimum throttle that the avoidance can slow down to
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AvoidanceVolumeTurnPenaltyDistance;

            public VehicleFlags Flags;

            // Distance defines a box outside of which we clamp perturbation. Value of zero causes fallback to run.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverDecelerationDistance; // wus
            // The max radius of the XZ anchor perturbation. Value of zero causes fallback to run.
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverOffsetDistance; // wus
            // The speed the vehicle must be below for it to start running hover perturbation (default=0.4).
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverAllowPerturbationSpeed; // wu/s
            // The number of seconds for the x component of the anchor perturbation to repeat itself (default=10).
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverRandomXAxisPeriod; // sec
            // The number of seconds for the y component of the anchor perturbation to repeat itself (default=7).
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverRandomYAxisPeriod; // sec
            // The number of seconds for the z component of the anchor perturbation to repeat itself (default=5).
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverRandomZAxisPeriod; // sec
            // The radius of the anchor perturbation. (default=0)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverRandomRadius; // wu
            // If we're traveling faster than this amount toward the anchor inside the max throttle distance, we drop throttle to
            // the min. (default=0.2)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverAnchorApproachSpeedLimit; // wu/s
            // The distance from the anchor at which the min and max throttle scale occur. (default=[0.25, 2.0])
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> HoverAnchorThrottleScaleDistance; // wu
            // The xy-throttle scale at the min and max throttle scale distances. (default=[0.0, 0.2])
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> HoverAnchorXyThrottleScale; // [0,1]
            // The z-throttle scale at the min and max throttle scale distances. (default=[1.0, 1.0])
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Bounds<float> HoverAnchorZThrottleScale; // [0,1]
            // The minimum the z component of throttle is allowed to be (default=0.2)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float HoverThrottleMinZ; // [-1, 1]

            public float AiPathfindingRadius; // Ground vehicles (world units)
            public float AiDestinationRadius; // Distance within which goal is considered reached (world units)
            public float AiDecelerationDistance; // Distance from goal at which AI starts to decelerate (world units)
            public float AiTurningRadius; // Idealized average turning radius (should reflect actual vehicle physics) (world units)
            public float AiInnerTurningRadius; // Idealized minimum turning radius (should reflect actual vehicle physics) (Warthogs)
            public float AiIdealTurningRadius; // Ideal turning radius for rounding turns (barring obstacles, etc.) (Warthogs, ghosts)
            public Angle AiBansheeSteeringMaxAngle; // (banshees)
            public float AiMaxSteeringAngle; // Maximum steering angle from forward (ultimately controls turning speed) degrees (warthogs, ghosts, wraiths)
            public float AiMaxSteeringDelta; // Maximum delta in steering angle from one tick to the next (ultimately controls turn acceleration) degrees (warthogs, dropships, ghosts, wraiths)
            public float AiOversteeringScale; // (warthogs, ghosts, wraiths)
            public Bounds<Angle> AiOversteeringBounds; // Angle to goal at which AI will oversteer (banshees)
            public float AiSideSlipDistance; // Distance within which Ai will strafe to target, rather than turning (ghosts, dropships)
            public float AiAvoidanceDistance; // Look-ahead distance for obstacle avoidance (banshees)
            public float AiMinimumUrgency; // The minimum urgency with which a turn can be made (urgency = percent of maximum steering delta) [0-1]
            public Angle DestinationBehindAngle; // The angle from facing that is considered to be behind us (we do the ugly floaty slidey turn to things behind us) (dropships)
            public float SkidScale; // When approaching a corner at speed, we may want to skid around that corner, by turning slightly too early. This is (roughly) how many seconds ahead we should start turning. (warthog)
            public float AiThrottleMaximum; // (0 - 1) (all vehicles)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AiReverseThrottleMaximum; // If zero, default to ai throttle maximum

            public float AiGoalMinThrottleScale; // scale on throttle when within 'ai deceleration distance' of goal (0...1) (warthogs, dropships, ghosts)
            public float AiTurnMinThrottleScale; // Scale on throttle due to nearness to a turn (0...1) (warthogs, dropships, ghosts)
            public float AiDirectionMinimumThrottleScale; // Scale on throttle due to facing away from intended direction (0...1) (warthogs, dropships, ghosts)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AiSkidMinimumThrottleScale; // Scale on throttle due to skidding (0...1)
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public Angle SkidAttenutationMaximumAngle; // Maximise min throttle at this deviation of angles from current movement

            public float AiAccelerationScale; // The maximum allowable change in throttle between ticks (0-1): (warthogs, ghosts)
            public float AiThrottleBlend; // The degree of throttle blending between one tick and the next (0 = no blending) (0-1): (dropships, sentinels)
            public float TheoreticalMaxSpeed; // About how fast I can go. wu/s (warthogs, dropships, ghosts)
            public float ErrorScale; // scale on the difference between desired and actual speed, applied to throttle (warthogs, dropships)
            public Angle AiAllowableAimDeviationAngle;
            public float AiChargeTightAngleDistance; // The distance at which the tight angle criterion is used for deciding to vehicle charge (world units)
            public float AiChargeTightAngle; // Angle cosine within which the target must be when target is closer than tight angle distance in order to charge [0-1] (all vehicles)
            public float AiChargeRepeatTimeout; // Time delay between vehicle charges (all vehicles)
            public float AiChargeLookAheadTime; // In deciding when to abort vehicle charge, look ahead these many seconds to predict time of contact (all vehicles)
            public float AiConsiderDistance; // Consider charging the target when it is within this range (0 = infinite distance) (all vehicles)
            public float AiChargeAbortDistance; // Abort the charge when the target get more than this far away (0 = never abort) (all vehicles)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AiChargeArmorLockedTargetChance; // Probability that we decide to charge a target even if they are armor locked

            public float VehicleRamTimeout; // The ram behavior stops after a maximum of the given number of seconds
            public float RamParalysisTime; // The ram behavior freezes the vehicle for a given number of seconds after performing the ram
            public float AiCoverDamageThreshold; // Trigger a cover when recent damage is above given threshold (damage_vehicle_cover impulse) (all vehicles)

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float AiCoverShieldDamageThreshold; // Trigger a cover when recent shied damage is above given threshold (flying_cover behavior)

            public float AiCoverMinimumDistance; // When executing vehicle-cover, minimum distance from the target to flee to (all vehicles)
            public float AiCoverTime; // How long to stay away from the target/ (all vehicles)
            public float AiCoverMinimumBoostDistance; // Boosting allowed when distance to cover destination is greater then this. (all vehicles)
            public float TurtlingRecentDamageThreshold; // If vehicle turtling behavior is enabled, turtling is initiated if 'recent damage' surpasses the given threshold (percent)
            public float TurtlingMinimumTime; // If the vehicle turtling behavior is enabled, turtling occurs for at least the given time (seconds)
            public float TurtlingTimeout; // The turtled state times out after the given number of seconds (seconds)
            public AiSize ObstacleIgnoreSize;

            [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
            public byte[] Padding;

            public short MaxVehicleCharge; // max number of this type of vehicle in a task who can vehicle charge at once
            public short MinVehicleCharge; // min number of this type of vehicle in a task who can vehicle charge at once (soft limit, just a desired number)

            [Flags]
            public enum VehicleFlags : uint
            {
                PassengersAdoptOriginalSquad = 1 << 0,
                SnapFacingToForward = 1 << 1,   // Ghosts
                ThrottleToTarget = 1 << 2,      // Hornets
                StationaryFight = 1 << 3,       // Tanks
                KeepMoving = 1 << 4,
                CanPathfindWithAvoidanceOnly = 1 << 5,
                UseVolumeAvoidance = 1 << 6,
                TargetEquality = 1 << 7,
                DontFaceTarget = 1 << 8,
                OverrideAimingLabels = 1 << 9
            }
        }

        [TagStructure(Size = 0xE4)]
        public class CharacterMorphProperties : TagStructure
        {
            public CachedTag RangedCharacter;
            public CachedTag TankCharacter;
            public CachedTag StealthCharacter;
            public CachedTag MorphMuffins;
            public CachedTag RangedWeapon;
            public CachedTag TankWeapon;
            public CachedTag StealthWeapon;
            public float DistanceDamageOuterRadius; // Considered damaging-outside-range when you START firing from outside this distance
            public float DistanceDamageInnerRadius; // Considered damaging-outside-range when you CONTINUE firing from outside this distance
            public float DistanceDamageTime; // Damaging tank guy from outside-range for this long causes a morph
            public float DistanceDamageResetTime; // Damage timer is reset after this long of not damaging him from outside-range
            public Bounds<float> ThrottleDistance; // Throttle the tank from running (far) to walking (near) across this range of distances. (defaults to 5 and 3)
            public float ProtectDamageAmount; // Once current damage reaches this amount, protect your special parts until no recent damage
            public float ProtectTime; // How long should we protect our special parts for?

            [TagField(Flags = Label)]
            public CachedTag SpewInfectionCharacter; // What character should I throw up all over my target? Carrots?

            public float SpewChance; // Probability of throwing up a bunch of infection forms when perimeterising
            public StringId SpewMarker; // From whence should the infection forms cometh?
            public Bounds<float> SpewFrequency; // Min/max time between spawning each infection form during spew. (defaults to 0.1 and 0.3)
            public float StealthMorphDistanceThreshold; // Morphing inside this range causes a tank guy, outside this range causes a ranged fella
            public float StealthMorphDamageThreshold; // Percentage of body health he has to be taken down in order to cause a morph
            public float StalkRangeMin; // We want to stalk our target from outside this radius
            public float StalkRangeMax; // We want to stalk our target from inside this radius
            public float StalkRangeHardMax; // We will never be able to pick a firing position more than this far from our target
            public float StalkChargeChance; // While stalking, charge randomly with this probability per second (also will charge when on periphery, this is just some spice)
            public float RangedProximityDistance; // Morph to tank/stalker when someone gets this close to me as a ranged form
            public float TurtleDamageThreshold; // amount of damage necessary to trigger a turtle
            public Bounds<float> TurtleTime; // when turtling, turtle for a random time with these bounds
            public float TurtleDistance; // when I turtle I send out a stimulus to friends within this radius to also turtle
            public float TurtleAbortDistance; // when my target get within this range, abort turtling
            public float GroupMorphRange; // Follow the morph of any other form within this distance
        }

        [TagStructure(Size = 0x24)]
        public class CharacterEquipmentProperties : TagStructure
        {
            [TagField(Flags = Label)]
            public CachedTag Equipment;

            public CharacterEquipmentFlags Flags;
            public float RelativeDropChance; // The relative chance of this equipment being dropped with respect to the other pieces of equipment specified in this block
            public List<CharacterEquipmentUsageCondition> UseConditions;

            [Flags]
            public enum CharacterEquipmentFlags : uint
            {
                DefaultEquipment = 1 << 0
            }

            [TagStructure(Size = 0xC)]
            public class CharacterEquipmentUsageCondition : TagStructure
            {
                public CharacterEquipmentUsageWhenEnum UseWhen; // When should we use this equipment?
                public CharacterEquipmentUsageHowEnum UseHow; // How should we use this equipment?
                public float Easynormal; // 0-1
                public float Legendary; // 0-1

                public enum CharacterEquipmentUsageWhenEnum : short
                {
                    Combat,
                    Cover,
                    Shield,
                    Health,
                    Uncover,
                    Berserk,
                    Investigate,
                    AntiVehicle
                }

                public enum CharacterEquipmentUsageHowEnum : short
                {
                    AttachToSelf,
                    ThrowAtEnemy,
                    ThrowAtFeet,
                    UseOnSelf
                }
            }
        }

        [TagStructure(Size = 0x1C)]
        public class CharacterActAttachment : TagStructure
        {
            [TagField(Flags = Label)]
            public StringId ActivityName;
            public CachedTag Crate;
            public StringId CrateMarkerName;
            public StringId UnitMarkerName;
        }
    }
}