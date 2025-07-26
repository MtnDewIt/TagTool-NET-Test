using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.Scripting
{
    [TagEnum(IsVersioned = true)]
    public enum HsType
    {
        [TagEnumMember(Flags = TagEnumMemberFlags.Constant)]
        Invalid = 0xBABA,

        Unparsed = 0,
        SpecialForm,
        FunctionName,
        Passthrough,
        Void,
        Boolean,
        Real,
        Short,
        Long,
        String,
        Script,
        StringId,
        UnitSeatMapping,
        TriggerVolume,
        CutsceneFlag,
        CutsceneCameraPoint,
        CutsceneTitle,
        CutsceneRecording,
        DeviceGroup,
        Ai,
        AiCommandList,
        AiCommandScript,
        AiBehavior,
        AiOrders,
        AiLine,
        StartingProfile,
        Conversation,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        Player,
        ZoneSet,
        DesignerZone,
        PointReference,
        Style,
        ObjectList,
        Folder,
        Sound,
        Effect,
        Damage,
        LoopingSound,
        AnimationGraph,
        DamageEffect,
        ObjectDefinition,
        Bitmap,
        Shader,
        RenderModel,
        StructureDefinition,
        LightmapDefinition,
        CinematicDefinition,
        CinematicSceneDefinition,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        CinematicTransitionDefinition,
        BinkDefinition,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        CuiScreenDefinition,
        AnyTag,
        AnyTagNotResolving,
        GameDifficulty,
        Team,
        MpTeam,
        Controller,
        ButtonPreset,
        JoystickPreset,
        [TagEnumMember(MaxVersion = CacheVersion.Halo3ODST)]
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        PlayerColor,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        PlayerModelChoice,
        PlayerCharacterType,
        VoiceOutputSetting,
        VoiceMask,
        SubtitleSetting,
        ActorType,
        ModelState,
        Event,
        CharacterPhysics,
        [TagEnumMember(MinVersion = CacheVersion.Halo3ODST)]
        PrimarySkull,
        [TagEnumMember(MinVersion = CacheVersion.Halo3ODST)]
        SecondarySkull,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        Skull,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        FiringPointEvaluator,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        DamageRegion,
        Object,
        Unit,
        Vehicle,
        Weapon,
        Device,
        Scenery,
        EffectScenery,
        ObjectName,
        UnitName,
        VehicleName,
        WeaponName,
        DeviceName,
        SceneryName,
        EffectSceneryName,
        CinematicLightprobe,
        AnimationBudgetReference,
        LoopingSoundBudgetReference,
        SoundBudgetReference,
    }
}
