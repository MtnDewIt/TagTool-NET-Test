using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Ai
{
    [TagStructure(Size = 0x34, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Size = 0x38, MinVersion = CacheVersion.HaloReach)]
    public class VocalizationPattern : TagStructure
    {
        public DialogueTypeEnum DialogueType;
        public short VocalizationIndex;

        [TagField(Flags = Label)]
        public StringId VocalizationName;

        public SpeakerTypeEnum SpeakerType;  // who/what am I speaking to/of?
        public SpeakerTypeEnum ListenerTarget; // The relationship between the subject and the cause
        public HostilityEnum Hostility;
        public PatternFlags Flags;
        public ActorTypeEnum CauseActorType;
        public DialogueObjectTypesEnum CauseType;
        public StringId CauseAiTypeName;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId CauseEquipmentTypeName;

        public DialogueObjectTypesEnum SpeakerObjectType;

        [TagField(Length = 2, Flags = Padding, MaxVersion = CacheVersion.HaloOnline700123)]
        public byte[] Unused;

        public SpeakerBehaviorEnum SpeakerBehavior;

        [TagField(Platform = CachePlatform.Original)]
        [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public DangerEnum DangerLevel;

        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public DangerEnumMCC DangerLevelMCC;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public StyleAttitudeEnum Attitude;

        public SpatialRelationEnum SpeakerSubjectPosition;
        public SpatialRelationEnum SpeakerCausePosition;

        [TagField(Platform = CachePlatform.Original)]
        [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        public DialogueConditionFlags Conditions;

        [TagField(MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        public DialogueConditionFlagsMCC ConditionsMCC;

        [TagField(EnumType = typeof(short))]
        public SpatialRelationEnum SpacialRelation;
        public DamageEnum DamageType;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public GameTypeEnum GameType;

        public ActorTypeEnum SubjectActorType;
        public DialogueObjectTypesEnum SubjectType;

        [TagField(MinVersion = CacheVersion.HaloReach, Length = 0x2, Flags = Padding)]
        public byte[] PaddingReach;

        public StringId SubjectAiTypeName;

        public enum DialogueObjectTypesEnum : short
        {
            NONE,
            Player,
            Actor,
            Biped,
            Body,
            Vehicle,
            Projectile,
            ActorOrPlayer,
            Turret,
            UnitInVehicle,
            UnitInTurret,
            UnitCarryingTurret,
            Driver,
            Gunner,
            Passenger,
            Postcombat,
            PostcombatWon,
            PostcombatLost,
            PlayerMasterchief,
            PlayerDervish,
            PlayerRookie,
            PlayerBuck,
            PlayerDutch,
            PlayerMickey,
            PlayerRomeo,
            Heretic,
            MajorlyScary,
            LastManInVehicle,
            Male,
            Female,
            Grenade,
            Stealth,
            Flood,
            Pureform,
            PlayerEmptyVehicle
        }

        public enum DamageEnum : short
        {
            NONE,
            Falling,
            Bullet,
            Grenade,
            Explosive,
            Sniper,
            Melee,
            Flame,
            MountedWeapon,
            Vehicle,
            Plasma,
            Needle,
            Shotgun
        }

        public enum SpatialRelationEnum : sbyte
        {
            None,
            VeryNear,
            Near,
            MediumRange,
            Far,
            VeryFar,
            InFrontOf,
            Behind,
            Above,
            Below,
            Few,
            InRange
        }

        [Flags]
        public enum DialogueConditionFlags : uint
        {
            None = 0,
            Asleep = 1 << 0,
            Idle = 1 << 1,
            Alert = 1 << 2,
            Active = 1 << 3,
            UninspectedOrphan = 1 << 4,
            DefiniteOrphan = 1 << 5,
            CertainOrphan = 1 << 6,
            VisibleEnemy = 1 << 7,
            ClearLosEnemy = 1 << 8,
            DangerousEnemy = 1 << 9,
            NoVehicle = 1 << 10,
            VehicleDriver = 1 << 11,
            VehiclePassenger = 1 << 12,
        }

        [Flags]
        public enum DialogueConditionFlagsMCC : int
        {
            None = 0,
            Asleep = 1 << 0,
            Idle = 1 << 1,
            Alert = 1 << 2,
            Active = 1 << 3,
            UninspectedOrphan = 1 << 4,
            DefiniteOrphan = 1 << 5,
            CertainOrphan = 1 << 6,
            VisibleEnemy = 1 << 7,
            ClearLosEnemy = 1 << 8,
            DangerousEnemy = 1 << 9,
            NoVehicle = 1 << 10,
            VehicleDriver = 1 << 11,
            VehiclePassenger = 1 << 12,
            Bit13 = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15,
            Bit16 = 1 << 16,
            Bit17 = 1 << 17,
            Bit18 = 1 << 18,
            Bit19 = 1 << 19,
            Bit20 = 1 << 20,
            Bit21 = 1 << 21,
            Bit22 = 1 << 22,
            Bit23 = 1 << 23,
            Bit24 = 1 << 24,
            Bit25 = 1 << 25,
            Bit26 = 1 << 26,
            Bit27 = 1 << 27,
            Bit28 = 1 << 28,
            Bit29 = 1 << 29,
            Bit30 = 1 << 30,
            Bit31 = 1 << 31,
        }

        public enum SpeakerBehaviorEnum : short
        {
            Any,
            Combat,
            Engage,
            Search,
            Cover,
            Retreat,
            Follow,
            Shoot,
            ClumpIdle,
            ClumpCombat,
            FoughtBrutes,
            FoughtFlood
        }

        public enum DangerEnum : short
        {
            NONE,
            BroadlyFacing,
            ShootingNear,
            ShootingAt,
            ExtremelyClose,
            ShieldDamage,
            ShieldExtendedDamage,
            BodyDamage,
            BodyExtendedDamage
        }

        public enum DangerEnumMCC : short
        {
            NONE = -1,
            BroadlyFacing = 1,
            ShootingNear,
            ShootingAt,
            ExtremelyClose,
            ShieldDamage,
            ShieldExtendedDamage,
            BodyDamage,
            BodyExtendedDamage,
        }

        public enum StyleAttitudeEnum : short
        {
            Normal,
            Timid,
            Aggressive
        }

        public enum GameTypeEnum : short
        {
            None,
            Sandbox,
            Megalo,
            Campaign,
            Survival
        }
    }
}
