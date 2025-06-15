using TagTool.Cache;
using System.Collections.Generic;
using System;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "style", Tag = "styl", Size = 0x5C, MinVersion = CacheVersion.Halo3Retail)]
    public class Style : TagStructure
	{
        [TagField(Length = 32)]
        public string Name;

        public CombatStatusDecayOptionsValue CombatStatusDecayOptions;
        public StyleAttitudeEnum Attitude;
        public StyleControlFlags StyleControl;

        public StyleBehaviors1 Behaviors1;
        public StyleBehaviors2 Behaviors2;
        public StyleBehaviors3 Behaviors3;
        public StyleBehaviors4 Behaviors4;
        public StyleBehaviors5 Behaviors5;
        public StyleBehaviors6 Behaviors6;
        public StyleBehaviors7 Behaviors7;

        public List<SpecialMovementBlock> SpecialMovement;
        public List<BehaviorListBlock> BehaviorList;

        [Flags]
        public enum StyleBehaviors1 : int
        {
            None = 0,
            ______GENERAL______ = 1 << 0,
            Root = 1 << 1,
	        Null = 1 << 2,
            NullDiscrete = 1 << 3,
            Obey = 1 << 4,
            Guard = 1 << 5,
            FollowBehavior = 1 << 6,
            Ready = 1 << 7,
            SmashObstacle = 1 << 8,
            DestroyObstacle = 1 << 9,
            Perch = 1 << 10,
            CoverFriend = 1 << 11,
            blindPanic = 1 << 12,
            Combat = 1 << 13,
            SquadPatrolBehavior = 1 << 14,
            ______BROKEN______ = 1 << 15,
            BrokenBehavior = 1 << 16,
            HuddleImpulse = 1 << 17,
            HuddleBehavior = 1 << 18,
            KamikazeBehavior = 1 << 19,
            BrokenKamikazeImpulse = 1 << 20,
            BrokenBerserkImpulse = 1 << 21,
            BrokenFleeImpulse = 1 << 22,
            BrokenScatterImpulse = 1 << 23,
            ______ENGAGE______ = 1 << 24,
            Equipment = 1 << 25,
            Engage = 1 << 26,
            Fight = 1 << 27,
            FightPositioning = 1 << 28,
            MeleeCharge = 1 << 29,
            MeleeLeapingCharge = 1 << 30,
            Surprise = 1 << 31,
        }

        [Flags]
        public enum StyleBehaviors2 : int
        {
            None = 0,
            GrenadeImpulse = 1 << 0,
            AntiVehicleGrenade = 1 << 1,
            Stalk = 1 << 2,
            Flank = 1 << 3,
            BerserkWanderImpulse = 1 << 4,
            StalkerCamoControl = 1 << 5,
            LeaderAbandonedBerserk = 1 << 6,
            UnassailableGrenadeImpulse = 1 << 7,
            Perimeter = 1 << 8,
            PerimeterAtTimeoutMorph = 1 << 9,
            PerimeterAtInfectionSpew = 1 << 10,
            ______BERSERK______ = 1 << 11,
            ShieldDepletedBerserk = 1 << 12,
            LastManBerserk = 1 << 13,
            StuckWithGrenadeBerserk = 1 << 14,
            ______PRESEARCH______ = 1 << 15,
            Presearch = 1 << 16,
            PresearchUncover = 1 << 17,
            DestroyCover = 1 << 18,
            SuppressingFire = 1 << 19,
            GrenadeUncover = 1 << 20,
            LeapOnCover = 1 << 21,
            ______LEADER______ = 1 << 22,
            SearchSync = 1 << 23,
            EngageSync = 1 << 24,
            ______SEARCH______ = 1 << 25,
            Search = 1 << 26,
            Uncover = 1 << 27,
            Investigate = 1 << 28,
            Pursuit_sync = 1 << 29,
            Pursuit = 1 << 30,
            RefreshTarget = 1 << 31,
        }

        [Flags]
        public enum StyleBehaviors3 : int
        {
            None = 0,
            SenseTarget = 1 << 0,
            postsearch = 1 << 1,
            CovermeInvestigate = 1 << 2,
            ______SELF_DEFENSE______ = 1 << 3,
            SelfPreservation = 1 << 4,
            Cover = 1 << 5,
            CoverPeek = 1 << 6,
            Avoid = 1 << 7,
            EvasionImpulse = 1 << 8,
            DiveImpulse = 1 << 9,
            DangerCoverImpulse = 1 << 10,
            DangerCrouchImpulse = 1 << 11,
            ProximityMelee = 1 << 12,
            ProximitySelfPreservation = 1 << 13,
            UnreachableEnemyCover = 1 << 14,
            UnassailableEnemyCover = 1 << 15,
            ScaryTargetCover = 1 << 16,
            GroupEmerge = 1 << 17,
            ShieldDepletedCover = 1 << 18,
            KungfuCover = 1 << 19,
            ______RETREAT______ = 1 << 20,
            Retreat = 1 << 21,
            RetreatGrenade = 1 << 22,
            Flee = 1 << 23,
            Cower = 1 << 24,
            LowShieldRetreat = 1 << 25,
            ScaryTargetRetreat = 1 << 26,
            LeaderDeadRetreat = 1 << 27,
            PeerDeadRetreat = 1 << 28,
            DangerRetreat = 1 << 29,
            ProximityRetreat = 1 << 30,
            ChargeWhenCornered = 1 << 31,
        }

        [Flags]
        public enum StyleBehaviors4 : int
        {
            None = 0,
            SurpriseRetreat = 1 << 0,
            OverheatedWeaponRetreat = 1 << 1,
            ______AMBUSH______ = 1 << 2,
            Ambush = 1 << 3,
            CoordinatedAmbush = 1 << 4,
            ProximityAmbush = 1 << 5,
            VulnerableEnemyAmbush = 1 << 6,
            NowhereToRunAmbush = 1 << 7,
            ______VEHICLE______ = 1 << 8,
            EnterVehicle = 1 << 9,
            EnterFriendlyVehicle = 1 << 10,
            VehicleEnterImpulse = 1 << 11,
            VehicleEntryEngageImpulse = 1 << 12,
            VehicleBoard = 1 << 13,
            VehicleFight = 1 << 14,
            VehicleFightAtBoost = 1 << 15,
            VehicleCharge = 1 << 16,
            VehicleRamBehavior = 1 << 17,
            VehicleCover = 1 << 18,
            DamageVehicleCover = 1 << 19,
            ExposedRearCoverImpulse = 1 << 20,
            PlayerEndageredCoverImpulse = 1 << 21,
            VehicleAvoid = 1 << 22,
            VehiclePickup = 1 << 23,
            VehiclePlayerPickup = 1 << 24,
            VehicleExitImpulse = 1 << 25,
            DangerVehicleExitImpulse = 1 << 26,
            VehicleFlipImpulse = 1 << 27,
            VehicleFlip = 1 << 28,
            VehicleTurtle = 1 << 29,
            VehicleEngagePatrolImpulse = 1 << 30,
            VehicleEngageWanderImpulse = 1 << 31,
        }

        [Flags]
        public enum StyleBehaviors5 : int
        {
            None = 0,
            ______POSTCOMBAT______ = 1 << 0,
            Postcombat = 1 << 1,
            PostPostcombat = 1 << 2,
            CheckFriend = 1 << 3,
            ShootCorpse = 1 << 4,
            PostcombatApproach = 1 << 5,
            ______ALERT______ = 1 << 6,
            Alert = 1 << 7,
            ______IDLE______ = 1 << 8,
            Idle = 1 << 9,
            Inspect = 1 << 10,
            WanderBehavior = 1 << 11,
            FlightWander = 1 << 12,
            Patrol = 1 << 13,
            FallSleep = 1 << 14,
            ______BUGGERS______ = 1 << 15,
            BuggerGroundUncover = 1 << 16,
            ______SWARMS______ = 1 << 17,
            SwarmRoot = 1 << 18,
            SwarmAttack = 1 << 19,
            SupportAttack = 1 << 20,
            Infect = 1 << 21,
            Scatter = 1 << 22,
            ______COMBATFORMS______ = 1 << 23,
            CombatFormBerserkControl = 1 << 24,
            EjectParasite = 1 << 25,
            ______SENTINELS______ = 1 << 26,
            EnforcerWeaponControl = 1 << 27,
            Grapple = 1 << 28,
            ______ENGINEER______ = 1 << 29,
            EngineerControl = 1 << 30,
            EngineerControlAtSlave = 1 << 31,
        }

        [Flags]
        public enum StyleBehaviors6 : int
        {
            None = 0,
            EngineerControlAtFree = 1 << 0,
            EngineerControlAtEquipment = 1 << 1,
            EngineerExplode = 1 << 2,
            EngineerBrokenDetonation = 1 << 3,
            BoostAllies = 1 << 4,
            ______GUARDIANS______ = 1 << 5,
            GuardianSurge = 1 << 6,
            GuardianProximitySurge = 1 << 7,
            GuardianDangerSurge = 1 << 8,
            GuardianIsolationSurge = 1 << 9,
            ______PUREFORMS______ = 1 << 10,
            GroupMorphImpulse = 1 << 11,
            ArrivalMorphImpulse = 1 << 12,
            PureformDefaultImpulse = 1 << 13,
            SearchMorph = 1 << 14,
            StealthActive_camo_control = 1 << 15,
            StealthDamage_morph = 1 << 16,
            StealthStalk = 1 << 17,
            StealthStalkAtThwarted = 1 << 18,
            StealthStalkGroup = 1 << 19,
            StealthChargeRecover = 1 << 20,
            RangedProximityMorph = 1 << 21,
            TankDistanceDamageMorph = 1 << 22,
            TankThrottleControl = 1 << 23,
            StealthMorph = 1 << 24,
            TankMorph = 1 << 25,
            RangedMorph = 1 << 26,
            RangedTurtle = 1 << 27,
            RangedUncover = 1 << 28,
            ______SCARAB______ = 1 << 29,
            ScarabRoot = 1 << 30,
            ScarabCureIsolation = 1 << 31,
        }

        [Flags]
        public enum StyleBehaviors7 : int
        {
            None = 0,
            ScarabCombat = 1 << 0,
            ScarabFight = 1 << 1,
            ScarabTargetLock = 1 << 2,
            ScarabSearch = 1 << 3,
            ScarabSearchPause = 1 << 4,
            ______ATOMS______ = 1 << 5,
            GoTo = 1 << 6,
            ______ACTIVITIES______ = 1 << 7,
            Activity = 1 << 8,
            Posture = 1 << 9,
            Activity_default = 1 << 10,
            ______SPECIAL______ = 1 << 11,
            Formation = 1 << 12,
            GruntScaredByElite = 1 << 13,
            Stunned = 1 << 14,
            CureIsolation = 1 << 15,
            DeployTurret = 1 << 16,
        }

        public enum CombatStatusDecayOptionsValue : short
        {
            LatchAtIdle,
            LatchAtAlert,
            LatchAtCombat
        }

        public enum StyleAttitudeEnum : short
        {
            Normal,
            Timid,
            Aggressive
        }

        [Flags]
        public enum StyleControlFlags : int
        {
            None = 0,
            NewBehaviorsDefaultToOn = 1 << 0,
            DoNotForceOnDefaultBehaviors = 1 << 1
        }

        [TagStructure(Size = 0x4)]
        public class SpecialMovementBlock : TagStructure
		{
            public SpecialMovementFlags SpecialMovement1;

            [Flags]
            public enum SpecialMovementFlags : uint
            {
                None,
                Jump = 1 << 0,
                Climb = 1 << 1,
                Vault = 1 << 2,
                Mount = 1 << 3,
                Hoist = 1 << 4,
                WallJump = 1 << 5,
                Na = 1 << 6,
                Rail = 1 << 7,
                Seam = 1 << 8,
                Door = 1 << 9
            }
        }

        [TagStructure(Size = 0x20)]
        public class BehaviorListBlock : TagStructure
		{
            [TagField(Length = 32)]
            public string BehaviorName;
        }
    }
}