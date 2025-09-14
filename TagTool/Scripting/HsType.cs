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
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        AiLine,
        StartingProfile,
        Conversation,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        Player,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        ZoneSet,
        [TagEnumMember(MaxVersion = CacheVersion.Halo2PC)]
        StructureBsp,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        DesignerZone,
        [TagEnumMember(MaxVersion = CacheVersion.Halo2PC)]
        Navpoint,
        PointReference,
        Style,
        [TagEnumMember(MaxVersion = CacheVersion.Halo2PC)]
        HudMessage,
        ObjectList,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Retail)]
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
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        CinematicDefinition,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        CinematicSceneDefinition,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        CinematicTransitionDefinition,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Retail)]
        BinkDefinition,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        CuiScreenDefinition,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        AnyTag,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        AnyTagNotResolving,
        GameDifficulty,
        Team,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        MpTeam,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        Controller,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        ButtonPreset,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        JoystickPreset,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.Halo3ODST)]
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        PlayerColor,
        [TagEnumMember(MinVersion = CacheVersion.HaloReach)]
        PlayerModelChoice,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.Eldorado700123)]
        PlayerCharacterType,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        VoiceOutputSetting,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        VoiceMask,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        SubtitleSetting,
        ActorType,
        [TagEnumMember(MaxVersion = CacheVersion.Halo2PC)]
        HudCorner,
        ModelState,
        [TagEnumMember(MaxVersion = CacheVersion.Halo2PC)]
        NetworkEvent,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        Event,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        CharacterPhysics,
        [TagEnumMember(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        PrimarySkull,
        [TagEnumMember(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
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
        [TagEnumMember(MinVersion = CacheVersion.Halo3Retail)]
        EffectScenery,
        ObjectName,
        UnitName,
        VehicleName,
        WeaponName,
        DeviceName,
        SceneryName,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Retail)]
        EffectSceneryName,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Beta)]
        CinematicLightprobe,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Retail)]
        AnimationBudgetReference,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Retail)]
        LoopingSoundBudgetReference,
        [TagEnumMember(MinVersion = CacheVersion.Halo3Retail)]
        SoundBudgetReference,
    }
}
