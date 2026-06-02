using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.Ai
{
    [TagEnum(IsVersioned = true)]
    public enum CharacterMovementFlags
    {
        DangerCrouchAllowMovement,
        NoSideStep,
        PreferToCombatNearFriends,
        [TagEnumMember(MaxVersion = CacheVersion.HaloReach11883)]
        HopToCoverPathSegements,
        [TagEnumMember(MaxVersion = CacheVersion.HaloReach11883)]
        HopToEndOfPath,
        AllowBoostedJump,
        Perch,
        Climb,
        PreferWallMovement,
        HasFlyingMode,
        DisallowCrouch,
        DisallowAllMovement,
        AlwaysUseSearchPoints,
        KeepMoving,
        CureIsolationJump,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        GainElevation,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        RepositionDistant,
        [TagEnumMember(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloReach11883)]
        OnlyUseAerialFiringPositions,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        UseHighPriorityPathFinding,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        LowerWeaponWhenNoAlertMovementOverride,
        [TagEnumMember(MinVersion = CacheVersion.Halo4)]
        Phase,
        [TagEnumMember(MinVersion = CacheVersion.Halo4)]
        NoOverrideWhenFiring,
        [TagEnumMember(MinVersion = CacheVersion.Halo4)]
        NoStowDuringIdleActivities,
        [TagEnumMember(MinVersion = CacheVersion.Halo4)]
        FlipAnyVehicle,
        // Not in H4 definition? Where's this from?
        [TagEnumMember(MinVersion = CacheVersion.Halo4)]
        BoundAlongPath,
    }
}
