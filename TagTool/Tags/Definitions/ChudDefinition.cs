using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "chud_definition", Tag = "chdt", Size = 0x18, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "chud_definition", Tag = "chdt", Size = 0x28, MinVersion = CacheVersion.HaloReach)]
    public class ChudDefinition : TagStructure
    {
        public List<HudWidget> HudWidgets;
        public ChudAmmunitionInfo HudAmmunitionInfo;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<ReachUpdateCacheBlock> WidgetUpdateCache;

        [TagStructure(Size = 0x38, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x7C, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x7C, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public class HudWidgetBase : TagStructure
        {
            [TagField(Flags = TagFieldFlags.Label)]
            public StringId Name;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ChudScriptingClass ScriptingClass;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public WidgetFlags BaseFlags;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public WidgetLayerEnum SortLayer;

            [TagField(MinVersion = CacheVersion.HaloReach)] public ChudScriptingClassReach ScriptingClassReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public sbyte PostprocessedIntermediateListIndex;
            [TagField(MinVersion = CacheVersion.HaloReach)] public WidgetFlagsReach BaseFlagsReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public WidgetLayerEnum SortLayerReach;

            [TagField(MinVersion = CacheVersion.HaloReach)] public ChudExternalInputReach ExternalInputA;
            [TagField(MinVersion = CacheVersion.HaloReach)] public ChudExternalInputReach ExternalInputB;

            [TagField(ValidTags = new[] { "wsdt" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag StateDataTemplate;

            public List<StateDatum> StateData;
          
            [TagField(ValidTags = new[] { "wpdt" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag PlacementDataTemplate;

            public List<PlacementDatum> PlacementData;
          
            [TagField(ValidTags = new[] { "wadt" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag AnimationDataTemplate;

            public List<AnimationDatum> AnimationData;

            [TagField(ValidTags = new[] { "wrdt" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag RenderDataTemplate;

            public List<RenderDatum> RenderData;


            [TagStructure(Size = 0x28, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
            [TagStructure(Size = 0x2C, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
            [TagStructure(Size = 0x38, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
            [TagStructure(Size = 0x3C, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
            [TagStructure(Size = 0x44, MaxVersion = CacheVersion.HaloOnline604673)]
            [TagStructure(Size = 0x48, Version = CacheVersion.HaloOnline700123)]
            [TagStructure(Size = 0x38, MinVersion = CacheVersion.HaloReach)]
            public class StateDatum : TagStructure
            {
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public GameStateFlags GameState;
                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
                public GameStateFlagsH3 GameStateH3;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
                public GameStateFlagsODST GameStateODST;
                [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public GameStateFlagsMCC GameStateMCC;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public SkinStateFlags SkinState;

                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
                public PDAStateFlags PDAState;

                [TagField(MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public SandboxStateFlags SandboxStateMCC;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public GameTeamFlags GameTeam;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public WindowStateFlags WindowState;

                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                public GameEngineStateFlags GameEngineState;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public GameEngineStateFlagsHO GameEngineStateHO;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public MiscStateFlagsH3 MiscStateH3;
                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public MiscStateFlagsODST MiscStateODST;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public MiscStateFlags MiscState;

                [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public SandboxStateFlags SandboxState;

                [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public HindsightStateFlags HindsightState;
                [TagField(MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public HindsightStateFlagsMCC HindsightStateMCC;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public SkullStateFlags SkullState;
                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public SkullStateFlagsMCC SkullStateMCC;

                [TagField(Flags = TagFieldFlags.Padding, Length = 0x4, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public byte[] Padding1;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public SurvivalRoundStateFlags SurvivalRoundState;
                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public SurvivalRoundStateFlagsMCC SurvivalRoundStateMCC;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public SurvivalWaveStateFlags SurvivalWaveState;
                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public SurvivalWaveStateFlagsMCC SurvivalWaveStateMCC;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public SurvivalLivesStateFlags SurvivalLivesState;
                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public SurvivalLivesStateFlagsMCC SurvivalLivesStateMCC;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public DifficultyStateFlags DifficultyState;
                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public DifficultyStateFlagsMCC DifficultyStateMCC;

                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public PDAStateFlags PDAStateMCC;

                [TagField(Flags = TagFieldFlags.Padding, Length = 0x2, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public byte[] Padding2;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public UnitImpulseStateFlagsH3 UnitImpulseStateH3;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                public UnitImpulseStateFlagsODST UnitImpulseStateODST;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public UnitImpulseStateFlagsHO UnitImpulseStateHO;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public UnitZoomStateFlags UnitZoomState;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public UnitArmedStateFlags UnitArmedState;

                [TagField(Flags = TagFieldFlags.Padding, Length = 0x2, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline604673)]
                public byte[] Unknown3;

                [TagField(Version = CacheVersion.HaloOnline700123)]
                public UnknownStateFlagsMS30 UnknownStateMS30; // This might be in all HO builds, but only MS30 has non zero values

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public UnitMiscStateFlags UnitMiscState;

                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public UnknownStateFlags UnknownState;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public WeaponImpulseStateFlags WeaponImpulseState;

                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                public WeaponArmedStateFlags WeaponArmedState;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public WeaponArmedStateFlagsHO WeaponArmedStateHO;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public WeaponCrosshairStateFlagsH3 WeaponCrosshairStateH3;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public WeaponCrosshairStateFlags WeaponCrosshairState;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public WeaponMiscStateFlags WeaponMiscState;

                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                public NonWeaponFlashFlags NonWeaponFlash;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public NonWeaponFlashFlagsHO NonWeaponFlashHO;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public WeaponFlashFlags WeaponFlash;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public HiddenStateFlags HiddenState;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public NotHiddenStateFlags NotHiddenState;

                [TagField(Flags = TagFieldFlags.Padding, Length = 0x2, MaxVersion = CacheVersion.Halo3Retail)]
                public byte[] Padding4;

                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ConsumableStateFlags ConsumableState;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public EnergyMeterStateFlags EnergyMeterState;

                [TagField(Flags = TagFieldFlags.Padding, Length = 0x4, MinVersion = CacheVersion.HaloOnline700123, MaxVersion = CacheVersion.HaloOnline700123)]
                public byte[] Padding5;

                // Reach
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public List<ChudWidgetStateAndBlock> ActiveStateReach;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public List<ChudWidgetStateAndBlock> FlashStateReach;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public List<ChudWidgetStateAndBlock> HiddenStateReach;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public short ActiveStateEditorRoot;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public short FlashStateEditorRoot;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public short HiddenStateEditorRoot;
                [TagField(MinVersion = CacheVersion.HaloReach, Length = 2, Flags = TagFieldFlags.Padding)]
                public byte[] PaddingReach;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public List<ChudWidgetStateEditorBlock> StateEditorData;

                [Flags]
                public enum GameStateFlags : ushort
                {
                    None = 0,
                    CampaignSolo = 1 << 0,
                    CampaignCoop = 1 << 1,
                    MultiFFA = 1 << 2,
                    MultiTeam = 1 << 3,
                    MPCTF = 1 << 4,
                    MPSlayer = 1 << 5,
                    MPOddball = 1 << 6,
                    MPKing = 1 << 7,
                    MPJuggernaut = 1 << 8,
                    MPTerritories = 1 << 9,
                    MPAssault = 1 << 10,
                    MPVIP = 1 << 11,
                    MPInfection = 1 << 12,
                    MPSandbox = 1 << 13,
                    FilmPlayback = 1 << 14,
                    CampaignSurvival = 1 << 15,
                }

                [Flags]
                public enum GameStateFlagsH3 : ushort
                {
                    None = 0,
                    CampaignSolo = 1 << 0,
                    CampaignCoop = 1 << 1,
                    MultiFFA = 1 << 2,
                    MultiTeam = 1 << 3,
                    MPCTF = 1 << 4,
                    MPSlayer = 1 << 5,
                    MPOddball = 1 << 6,
                    MPKing = 1 << 7,
                    MPJuggernaut = 1 << 8,
                    MPTerritories = 1 << 9,
                    MPAssault = 1 << 10,
                    MPVIP = 1 << 11,
                    MPInfection = 1 << 12,
                    Unused = 1 << 13,
                    MPSandbox = 1 << 14,
                    FilmPlayback = 1 << 15,
                }

                [Flags]
                public enum GameStateFlagsODST : ushort 
                {
                    None = 0,
                    CampaignSolo = 1 << 0,
                    CampaignCoop = 1 << 1,
                    CampaignSurvival = 1 << 2,
                    MPSandbox = 1 << 3,
                    FilmPlayback = 1 << 4,
                }

                [Flags]
                public enum GameStateFlagsMCC : uint
                {
                    None = 0,
                    CampaignSolo = 1 << 0,
                    CampaignCoop = 1 << 1,
                    MultiFFA = 1 << 2,
                    MultiTeam = 1 << 3,
                    MPCTF = 1 << 4,
                    MPSlayer = 1 << 5,
                    MPOddball = 1 << 6,
                    MPKing = 1 << 7,
                    MPJuggernaut = 1 << 8,
                    MPTerritories = 1 << 9,
                    MPAssault = 1 << 10,
                    MPVIP = 1 << 11,
                    MPInfection = 1 << 12,
                    MPSandbox = 1 << 13,
                    FilmPlayback = 1 << 14,
                    CampaignSurvival = 1 << 15,
                    MPGunGame = 1 << 16,
                }

                [Flags]
                public enum SkinStateFlags : ushort
                {
                    None = 0,
                    Spartan = 1 << 0,
                    Elite = 1 << 1,
                    Monitor = 1 << 2,
                }

                [Flags]
                public enum PDAStateFlags : ushort
                {
                    None = 0,
                    PDAActive = 1 << 0,
                    PDAInactive = 1 << 1,
                    FirstPerson = 1 << 2,
                }

                [Flags]
                public enum SandboxStateFlags : ushort
                {
                    None = 0,
                    DefaultCrosshair = 1 << 0,
                    ActiveCrosshair = 1 << 1,
                    ManipulationCrosshair = 1 << 2,
                    NotAllowedCrosshair = 1 << 3,
                    BudgetAvailable = 1 << 4,
                }

                [Flags]
                public enum GameTeamFlags : ushort
                {
                    None = 0,
                    Offense = 1 << 0,
                    Defense = 1 << 1,
                    DoesntApply = 1 << 2,
                    PlayerIsSpecial = 1 << 3,
                    PlayerSpecialDefense = 1 << 4,
                    VoiceNo = 1 << 5,
                    VoiceBanned = 1 << 6,
                    VoiceRadio = 1 << 7,
                    VoiceRadioBroadcast = 1 << 8,
                    VoiceOpen = 1 << 9,
                    VoiceOpenBroadcast = 1 << 10,
                }

                [Flags]
                public enum WindowStateFlags : ushort
                {
                    None = 0,
                    _720pFullscreen = 1 << 0,
                    _720pHalfscreen = 1 << 1,
                    _480pFullscreen = 1 << 2,
                    _480iFullscreen = 1 << 3,
                    _720pQuarterscreen = 1 << 4,
                    _480Halfscreen = 1 << 5,
                    _480pQuarterscreen = 1 << 6,
                    _480iQuarterscreen = 1 << 7,
                }

                [Flags]
                public enum GameEngineStateFlags : ushort
                {
                    None = 0,
                    FriendlyScoreAvailable = 1 << 0,
                    EnemyScoreAvailable = 1 << 1,
                    VariantNameAvailable = 1 << 2,
                    TalkingPlayerAvailable = 1 << 3,
                    ArmingMeterAvailable = 1 << 4,
                    TimeLeftAvailable = 1 << 5,
                    FriendlyPosession = 1 << 6,
                    EnemyPosession = 1 << 7,
                    VariantCustomA = 1 << 8,
                    VariantCustomB = 1 << 9,
                    VariantCustomC = 1 << 10,
                    RoundStartPeriod = 1 << 11,
                    TestEnabled = 1 << 12,
                }

                [Flags]
                public enum GameEngineStateFlagsHO : uint
                {
                    None = 0,
                    FriendlyScoreAvailable = 1 << 0,
                    EnemyScoreAvailable = 1 << 1,
                    VariantNameAvailable = 1 << 2,
                    TalkingPlayerAvailable = 1 << 3,
                    ArmingMeterAvailable = 1 << 4,
                    TimeLeftAvailable = 1 << 5,
                    FriendlyPosession = 1 << 6,
                    EnemyPosession = 1 << 7,
                    VariantCustomA = 1 << 8,
                    VariantCustomB = 1 << 9,
                    VariantCustomC = 1 << 10,
                    VariantCustomD = 1 << 11,
                    VariantCustomE = 1 << 12,
                    VariantCustomF = 1 << 13,
                    VariantCustomG = 1 << 14,
                    RoundStartPeriod = 1 << 15,
                    Bit16 = 1 << 16,
                    TestEnabled = 1 << 17,
                }

                [Flags]
                public enum MiscStateFlagsH3 : ushort
                {
                    None = 0,
                    TextureCamAvailable = 1 << 0,
                    SniperFlavaAvailable = 1 << 1,
                    SavedFilmRecordingMode = 1 << 2,
                    SavedFilmNormalMode = 1 << 3,
                    PlayerTrainingAvailable = 1 << 4,
                    CampaignObjectiveAvailable = 1 << 5,
                }

                [Flags]
                public enum MiscStateFlagsODST : ushort
                {
                    None = 0,
                    TextureCamAvailable = 1 << 0,
                    SniperFlavaAvailable = 1 << 1,
                    SavedFilmRecordingMode = 1 << 2,
                    SavedFilmNormalMode = 1 << 3,
                    PlayerTrainingAvailable = 1 << 4,
                    CampaignObjectiveAvailable = 1 << 5,
                    SurvivalObjectiveAvailable = 1 << 6,
                    UserPlacedWaypointBeacon = 1 << 7,
                    UserPlacedWaypointUserPlaced = 1 << 8,
                    SavedFilmControlsActive = 1 << 9,
                    AchievementToast1Active = 1 << 10,
                    AchievementToast2Active = 1 << 11,
                    AchievementToast3Active = 1 << 12,
                    AchievementToast4Active = 1 << 13,
                    AchievementToast5Active = 1 << 14,
                    ArgPlaying = 1 << 15,
                }

                [Flags]
                public enum MiscStateFlags : uint
                {
                    None = 0,
                    TextureCamAvailable = 1 << 0,
                    SniperFlavaAvailable = 1 << 1,
                    SavedFilmRecordingMode = 1 << 2,
                    SavedFilmNormalMode = 1 << 3,
                    PlayerTrainingAvailable = 1 << 4,
                    CampaignObjectiveAvailable = 1 << 5,
                    SurvivalObjectiveAvailable = 1 << 6,
                    UserPlacedWaypointBeacon = 1 << 7,
                    UserPlacedWaypointUserPlaced = 1 << 8,
                    SavedFilmControlsActive= 1 << 9,
                    AchievementToast1Active= 1 << 10,
                    AchievementToast2Active= 1 << 11,
                    AchievementToast3Active= 1 << 12,
                    AchievementToast4Active= 1 << 13,
                    AchievementToast5Active = 1 << 14,
                    ArgPlaying = 1 << 15, 
                }

                [Flags]
                public enum HindsightStateFlags : ushort
                {
                    None = 0,
                    SensorRange10m = 1 << 0,
                    SensorRange25m = 1 << 1,
                    SensorRange75m = 1 << 2,
                    SensorRange150m = 1 << 3,
                    MetagameP1Talking = 1 << 4,
                    MetagameP2Enabled = 1 << 5,
                    MetagameP2Talking = 1 << 6,
                    MetagameP3Enabled = 1 << 7,
                    MetagameP3Talking = 1 << 8,
                    MetagameP4Enabled = 1 << 9,
                    MetagameP4Talking = 1 << 10,
                    TransientScoreAvailable = 1 << 11,
                    MetagameMultikillAvailable = 1 << 12,
                    MetagameNegativeScoreAvailable = 1 << 13,
                    MetagameTeamScoring = 1 << 14,
                    MetagameFFAScoring = 1 << 15,
                }

                [Flags]
                public enum HindsightStateFlagsMCC : uint
                {
                    None = 0,
                    SensorRange10m = 1 << 0,
                    SensorRange25m = 1 << 1,
                    SensorRange75m = 1 << 2,
                    SensorRange150m = 1 << 3,
                    MetagameP1Talking = 1 << 4,
                    MetagameP2Enabled = 1 << 5,
                    MetagameP2Talking = 1 << 6,
                    MetagameP3Enabled = 1 << 7,
                    MetagameP3Talking = 1 << 8,
                    MetagameP4Enabled = 1 << 9,
                    MetagameP4Talking = 1 << 10,
                    TransientScoreAvailable = 1 << 11,
                    MetagameMultikillAvailable = 1 << 12,
                    MetagameNegativeScoreAvailable = 1 << 13,
                    MetagameTeamScoring = 1 << 14,
                    MetagameFFAScoring = 1 << 15,
                }

                [Flags]
                public enum SkullStateFlags : ushort 
                {
                    None = 0,
                    PrimaryIron = 1 << 0,
                    PrimaryBlackEye = 1 << 1,
                    PrimaryToughLuck = 1 << 2,
                    PrimaryCatch = 1 << 3,
                    PrimaryFog = 1 << 4,
                    PrimaryFamine = 1 << 5,
                    PrimaryThunderstorm = 1 << 6,
                    PrimaryTilt = 1 << 7,
                    PrimaryMythic = 1 << 8,
                    SecondaryAssassin = 1 << 9,
                    SecondaryBlind = 1 << 10,
                    SecondarySuperman = 1 << 11,
                    SecondaryGruntBirthdayParty = 1 << 12,
                    SecondaryIWHBYD = 1 << 13,
                    SecondaryThirdPerson = 1 << 14,
                    SecondaryDirectorsCut = 1 << 15,
                }

                [Flags]
                public enum SkullStateFlagsMCC : uint
                {
                    None = 0,
                    PrimaryIron = 1 << 0,
                    PrimaryBlackEye = 1 << 1,
                    PrimaryToughLuck = 1 << 2,
                    PrimaryCatch = 1 << 3,
                    PrimaryFog = 1 << 4,
                    PrimaryFamine = 1 << 5,
                    PrimaryThunderstorm = 1 << 6,
                    PrimaryTilt = 1 << 7,
                    PrimaryMythic = 1 << 8,
                    SecondaryAssassin = 1 << 9,
                    SecondaryBlind = 1 << 10,
                    SecondarySuperman = 1 << 11,
                    SecondaryGruntBirthdayParty = 1 << 12,
                    SecondaryIWHBYD = 1 << 13,
                    SecondaryThirdPerson = 1 << 14,
                    SecondaryDirectorsCut = 1 << 15,
                }

                [Flags]
                public enum SurvivalRoundStateFlags : ushort
                {
                    None = 0,
                    Round0 = 1 << 0,
                    Round1 = 1 << 1,
                    Round2 = 1 << 2,
                    Round3 = 1 << 3,
                    Round4 = 1 << 4,
                    Round5 = 1 << 5,
                    BonusRound = 1 << 6,
                }

                [Flags]
                public enum SurvivalRoundStateFlagsMCC : byte
                {
                    None = 0,
                    Round0 = 1 << 0,
                    Round1 = 1 << 1,
                    Round2 = 1 << 2,
                    Round3 = 1 << 3,
                    Round4 = 1 << 4,
                    Round5 = 1 << 5,
                    BonusRound = 1 << 6,
                }

                [Flags]
                public enum SurvivalWaveStateFlags : ushort
                {
                    None = 0,
                    Wave0 = 1 << 0,
                    Wave1 = 1 << 1,
                    Wave2 = 1 << 2,
                    Wave3 = 1 << 3,
                    Wave4 = 1 << 4,
                    Wave5 = 1 << 5,
                    Wave6 = 1 << 6,
                    Wave7 = 1 << 7,
                    Wave8 = 1 << 8,
                    Wave9 = 1 << 9,
                    Wave10 = 1 << 10,
                    Wave11 = 1 << 11,
                    Wave12 = 1 << 12,
                    Wave13 = 1 << 13,
                    Wave14 = 1 << 14,
                    Wave15 = 1 << 15,
                }

                [Flags]
                public enum SurvivalWaveStateFlagsMCC : byte
                {
                    None = 0,
                    Wave0 = 1 << 0,
                    Wave1 = 1 << 1,
                    Wave2 = 1 << 2,
                    Wave3 = 1 << 3,
                    Wave4 = 1 << 4,
                    Wave5 = 1 << 5,
                    Wave6 = 1 << 6,
                    Wave7 = 1 << 7,
                }

                [Flags]
                public enum SurvivalLivesStateFlags : ushort
                {
                    None = 0,
                    _0Lives = 1 << 0,
                    _1Life = 1 << 1,
                    _2Lives = 1 << 2,
                    _3Lives = 1 << 3,
                    _4Lives = 1 << 4,
                    _5Lives = 1 << 5,
                    _6Lives = 1 << 6,
                    _7Lives = 1 << 7,
                    _8Lives = 1 << 8,
                    _9Lives = 1 << 9,
                    _10Lives = 1 << 10,
                    _11Lives = 1 << 11,
                    _12Lives = 1 << 12,
                    _13Lives = 1 << 13,
                    _14Lives = 1 << 14,
                    _15Lives = 1 << 15,
                }

                [Flags]
                public enum SurvivalLivesStateFlagsMCC : byte
                {
                    None = 0,
                    _0Lives = 1 << 0,
                    _1Life = 1 << 1,
                    _2Lives = 1 << 2,
                    _3Lives = 1 << 3,
                    _4Lives = 1 << 4,
                    _5Lives = 1 << 5,
                }

                [Flags]
                public enum DifficultyStateFlags : ushort
                {
                    None = 0,
                    Easy = 1 << 0,
                    Normal = 1 << 1,
                    Heroic = 1 << 2,
                    Legendary = 1 << 3,
                }

                [Flags]
                public enum DifficultyStateFlagsMCC : byte
                {
                    None = 0,
                    Easy = 1 << 0,
                    Normal = 1 << 1,
                    Heroic = 1 << 2,
                    Legendary = 1 << 3,
                }

                [Flags]
                public enum UnitImpulseStateFlagsH3 : ushort
                {
                    None = 0,
                    GrenadeHumanPickup = 1 << 0,
                    GrenadePlasmaPickup = 1 << 1,
                    GrenadeBrutePickup = 1 << 2,
                    GrenadeFirePickup = 1 << 3,
                    GrenadeEmpty = 1 << 4,
                    Zoom0To1 = 1 << 5,
                    Zoom1To2 = 1 << 6,
                    Zoom1To0 = 1 << 7,
                    Zoom2To0 = 1 << 8,
                }

                [Flags]
                public enum UnitImpulseStateFlagsODST : ushort
                {
                    None = 0,
                    GrenadeHumanPickup = 1 << 0,
                    GrenadePlasmaPickup = 1 << 1,
                    GrenadeBrutePickup = 1 << 2,
                    GrenadeFirePickup = 1 << 3,
                    GrenadeEmpty = 1 << 4,
                    Zoom0To1 = 1 << 5,
                    Zoom1To2 = 1 << 6,
                    Zoom1To0 = 1 << 7,
                    Zoom2To0 = 1 << 8,
                    SurvivalLivesAdded = 1 << 9
                }

                [Flags]
                public enum UnitImpulseStateFlagsHO : ushort
                {
                    None = 0,
                    GrenadeHumanPickup = 1 << 0,
                    GrenadePlasmaPickup = 1 << 1,
                    GrenadeBrutePickup = 1 << 2,
                    GrenadeFirePickup = 1 << 3,
                    GrenadeEmpty = 1 << 4,
                    SurvivalLivesAdded = 1 << 5,
                    Consumable1Unknown = 1 << 6,
                    Consumable2Unknown = 1 << 7,
                    Consumable3Unknown = 1 << 8,
                    Consumable4Unknown = 1 << 9,
                    EnemyVisionActive = 1 << 10,
                    Bit11 = 1 << 11,
                    HitMarkerLow = 1 << 12,
                    HitMarkerMedium = 1 << 13,
                    HitMarkerHigh = 1 << 14,
                    Bit15 = 1 << 15,
                }

                [Flags]
                public enum UnitZoomStateFlags : ushort
                {
                    None = 0,
                    Unzoomed = 1 << 0,
                    ZoomLvl1 = 1 << 1,
                    ZoomLvl2 = 1 << 2,
                }

                [Flags]
                public enum UnitArmedStateFlags : ushort
                {
                    None = 0,
                    Unarmed = 1 << 0,
                    SingleWielding = 1 << 1,
                    DualWielding = 1 << 2,
                    SupportWeapon = 1 << 3,
                }

                [Flags]
                public enum UnknownStateFlagsMS30 : ushort 
                {
                    None = 0,
                    Bit0 = 1 << 0,
                    Bit1 = 1 << 1,
                    Bit2 = 1 << 2,
                }

                [Flags]
                public enum UnitMiscStateFlags : ushort
                {
                    None = 0,
                    MotionSensorEnabled = 1 << 0,
                    MotionSensorDisabled = 1 << 1,
                    HumanGrenadeSelected = 1 << 2,
                    PlasmaGrenadeSelected = 1 << 3,
                    ClaymoreGrenadeSelected = 1 << 4,
                    FireGrenadeSelected = 1 << 5,
                    BinocularsEnabled = 1 << 6,
                    BinocularsDisabled = 1 << 7,
                    FirstPerson = 1 << 8,
                    ThirdPerson = 1 << 9,
                    PlayerIsTalking = 1 << 10,
                    PlayerIsBroadcasting = 1 << 11,
                    Overshield2 = 1 << 12,
                    Overshield3 = 1 << 13,
                    Overshield4 = 1 << 14,
                    ShieldAvailable = 1 << 15,
                }

                [Flags]
                public enum UnknownStateFlags : ushort
                {
                    None = 0,
                    Bit0 = 1 << 0,
                    Bit1 = 1 << 1,
                    Bit2 = 1 << 2,
                }

                [Flags]
                public enum WeaponImpulseStateFlags : ushort 
                {
                    None = 0,
                    AmmoUsed = 1 << 0,
                    AmmoPickup = 1 << 1,
                    AmmoThreshold = 1 << 2,
                }

                [Flags]
                public enum WeaponArmedStateFlags : ushort
                {
                    None = 0,
                    RightHand = 1 << 0,
                    LeftHand = 1 << 1,
                    Backpack = 1 << 2,
                    Hidden = 1 << 3,
                }

                [Flags]
                public enum WeaponArmedStateFlagsHO : ushort
                {
                    None = 0,
                    RightHand = 1 << 0,
                    LeftHand = 1 << 1,
                    Backpack = 1 << 2,
                    Hidden = 1 << 3,
                    PickupMessage = 1 << 4,
                    Bit5 = 1 << 5,
                    Bit6 = 1 << 6,
                    Bit7 = 1 << 7,
                }

                [Flags]
                public enum WeaponCrosshairStateFlags : ushort
                {
                    None = 0,
                    Normal = 1 << 0,
                    Friendly = 1 << 1,
                    Enemy = 1 << 2,
                    EnemyHeadshot = 1 << 3,
                    EnemyWeakpoint = 1 << 4,
                    Invincible = 1 << 5,
                    LockAvailable = 1 << 6,
                    PlasmaTrack = 1 << 7,
                    LockUnavailable = 1 << 8,
                    TargetUnobstructed = 1 << 9,
                    TargetObstructed = 1 << 10,
                }

                [Flags]
                public enum WeaponCrosshairStateFlagsH3 : ushort
                {
                    None = 0,
                    Normal = 1 << 0,
                    Friendly = 1 << 1,
                    Enemy = 1 << 2,
                    EnemyHeadshot = 1 << 3,
                    EnemyWeakpoint = 1 << 4,
                    Invincible = 1 << 5,
                    LockAvailable = 1 << 6,
                    PlasmaTrack = 1 << 7,
                    LockUnavailable = 1 << 8,
                }

                [Flags]
                public enum WeaponMiscStateFlags : ushort
                {
                    None = 0,
                    LockingOnAvailable = 1 << 0,
		            LockedOnAvailable = 1 << 1,
		            LockedOnUnavailable = 1 << 2,
                }

                [Flags]
                public enum NonWeaponFlashFlags : ushort
                {
                    None = 0,
                    ShieldLow = 1 << 0,
                    ShieldEmpty = 1 << 1,
                    HealthMinor = 1 << 2,
                    HealthMajor = 1 << 3,
                    HealthCritical = 1 << 4,
                    ShieldMinor = 1 << 5,
                    ShieldMajor = 1 << 6,
                    ShieldCritical = 1 << 7,
                    FragEmpty = 1 << 8,
                    PlasmaEmpty = 1 << 9,
                    ClaymoreEmpty = 1 << 10,
                    FirebombEmpty = 1 << 11,
                }

                [Flags]
                public enum NonWeaponFlashFlagsHO : ushort
                {
                    None = 0,
                    HealthMinor = 1 << 0,
                    HealthMajor = 1 << 1,
                    HealthCritical = 1 << 2,
                    ShieldMinor = 1 << 3,
                    ShieldMajor = 1 << 4,
                    ShieldCritical = 1 << 5,
                    FragEmpty = 1 << 6,
                    PlasmaEmpty = 1 << 7,
                    ClaymoreEmpty = 1 << 8,
                    FirebombEmpty = 1 << 9,
                    Bit10 = 1 << 10,
                    Bit11 = 1 << 11,
                }

                [Flags]
                public enum WeaponFlashFlags : ushort
                {
                    None = 0,
                    AmmoLoadedLow = 1 << 0,
                    AmmoLoadedEmpty = 1 << 1,
                    AmmoReserveLow = 1 << 2,
                    AmmoReserveEmpty = 1 << 3,
                    BatteryLow = 1 << 4,
                    BatteryEmpty = 1 << 5,
                    Overheating = 1 << 6,
                }

                [Flags]
                public enum HiddenStateFlags : ushort
                {
                    None = 0,
                    Zoomed = 1 << 0,
                    GrenadesUnusable = 1 << 1,
                    BackpackWeaponUnavailable = 1 << 2,
                }

                [Flags]
                public enum NotHiddenStateFlags : ushort
                {
                    None = 0,
                    PDAActive = 1 << 0,
                }

                [Flags]
                public enum ConsumableStateFlags : uint
                {
                    None = 0,
                    Consumable1Low = 1 << 0,
                    Consumable2Low = 1 << 1,
                    Consumable3Low = 1 << 2,
                    Consumable4Low = 1 << 3,
                    Consumable1Empty = 1 << 4,
                    Consumable2Empty = 1 << 5,
                    Consumable3Empty = 1 << 6,
                    Consumable4Empty = 1 << 7,
                    Consumable1Available = 1 << 8,
                    Consumable2Available = 1 << 9,
                    Consumable3Available = 1 << 10,
                    Consumable4Available = 1 << 11,
                    Consumable1DisabledA = 1 << 12,
                    Consumable2DisabledA = 1 << 13,
                    Consumable3DisabledA = 1 << 14,
                    Consumable4DisabledA = 1 << 15,
                    Consumable1DisabledB = 1 << 16,
                    Consumable2DisabledB = 1 << 17,
                    Consumable3DisabledB = 1 << 18,
                    Consumable4DisabledB = 1 << 19,
                    Consumable1Active = 1 << 20,
                    Consumable2Active = 1 << 21,
                    Consumable3Active = 1 << 22,
                    Consumable4Active = 1 << 23,
                }

                [Flags]
                public enum EnergyMeterStateFlags : uint 
                {
                    None = 0,
                    EnergyMeter1Full = 1 << 0,
                    EnergyMeter2Full = 1 << 1,
                    EnergyMeter3Full = 1 << 2,
                    EnergyMeter4Full = 1 << 3,
                    EnergyMeter5Full = 1 << 4,
                    Bit5 = 1 << 5,
                    Bit6 = 1 << 6,
                    Bit7 = 1 << 7,
                    Bit8 = 1 << 8,
                    Bit9 = 1 << 9,
                    Bit10 = 1 << 10,
                    Bit11 = 1 << 11,
                    Bit12 = 1 << 12,
                }
            }

            [TagStructure(Size = 0x1C)]
            public class PlacementDatum : TagStructure
            {
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public ChudCurvatureResFlags WindowState;

                [TagField(Flags = TagFieldFlags.Label, MaxVersion = CacheVersion.HaloOnline700123)]
                public ChudAnchorType Anchor;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public ChudWidgetPlacementFlags AnchorFlags;

                [TagField(Flags = TagFieldFlags.Label, MinVersion = CacheVersion.HaloReach)]
                public ChudAnchorTypeReach AnchorReach;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public ChudWidgetPlacementFlagsReach AnchorFlagsReach;
                [TagField(MinVersion = CacheVersion.HaloReach, Length = 0x1, Flags = TagFieldFlags.Padding)]
                public byte[] DSFKSLVJ;

                public RealPoint2d Origin;
                public RealPoint2d Offset;
                public RealPoint2d Scale;

                public enum ChudAnchorType : short
                {
                    TopLeft,
                    TopRight,
                    BottomRight,
                    BottomLeft,
                    Crosshair,
                    TopCenter,
                    GrenadeHuman,
                    GrenadePlasma,
                    GrenadeBrute,
                    GrenadeFire,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    Parent,
                    Center, //same as crosshair
                    BackpackWeapon, //uses both x and y offsets
                    Equipment, //x offset always 0
                    Ddamge, //same as center
                    Territory1,
                    Territory2,
                    Territory3,
                    Territory4,
                    Territory5,
                    Messaging, //uses notification offset in chgd
                    BottomCenter, //bottom center
                    WeaponTarget,
                    StateMessageRight,
                    StateMessageLeft,
                    MessageBottomState,
                    MessageBottomPrimary, //separate float for this in chgd
                    ScoreboardFriendlyScoreOffset,
                    ScoreboardEnemyScoreOffset,
                    MetagameBar,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    TopCenterSavedfilm,
                    Prompt, //ODST, corresponds to prompt offset in chgd
                    HologramTarget,
                    Medals, //uses medal offset in chgd
                    SurvivalMedals, //has values in chgd
                    UnknownHO_Offset3, //has values in chgd
                    MotionSensor
                }

                public enum ChudAnchorTypeReach : byte
                {
                    Parent,
                    TopLeft,
                    TopCenter,
                    TopRight,
                    Center,
                    BottomLeft,
                    BottomCenter,
                    BottomRight,
                    MotionSensor,
                    Ddamge, //same as center
                    Messaging, //uses notification offset in chgd
                    StateMessageRight,
                    StateMessageLeft,
                    MessageBottomState,
                    MessageBottomPrimary, //separate float for this in chgd
                    TrackedTarget,
                    TrackingObject,
                    Crosshair,
                    BackpackWeapon, //uses both x and y offsets
                    Grenade,
                    Equipment, //x offset always 0
                    WeaponTarget,
                    GhostReticule,
                    HologramTarget,
                    AirstrikeTarget,
                    Player,
                    ScriptedObject,
                    MetagameBar,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    Territory1,
                    Territory2,
                    Territory3,
                    Territory4,
                    Territory5,
                    StateMsgFireteam,
                    FireteamPossibleActionObject,
                    FireteamPendingTargetObject,
                    FireteamCurrentTargetObject,
                    FireteamPendingDirectiveUnit,
                    FireteamCurrentDirectiveUnit,
                    EnemyObjectiveObject,
                    FriendlyObjectiveObject,
                    NeutralObjectiveObject,
                    LasingTargetObject,
                    CampaignFireteamMember,
                    TopCenterSavedfilm
                }

                [Flags]
                public enum ChudWidgetPlacementFlags : ushort
                {
                    MoreSoon = 1 << 0
                }

                [Flags]
                public enum ChudWidgetPlacementFlagsReach : byte
                {
                    ClampPlacementToScreenCircle = 1 << 0,
                    ClampPlacementUnlessSplitscreen = 1 << 1,
                    DoNotRotate = 1 << 2
                }

                [Flags]
                public enum ChudCurvatureResFlags : byte
                {
                    FullscreenWide = 1 << 0,
                    FullscreenStandard = 1 << 1,
                    Halfscreen = 1 << 2,
                    QuarterscreenWide = 1 << 3,
                    QuarterscreenStandard = 1 << 4
                }
            }

            [TagStructure(Size = 0x78, MaxVersion = CacheVersion.Halo3ODST)]
            [TagStructure(Size = 0x90, MinVersion = CacheVersion.HaloOnlineED,  MaxVersion = CacheVersion.HaloOnline700123)]
            [TagStructure(Size = 0x64, MinVersion = CacheVersion.HaloReach)]
            public class AnimationDatum : TagStructure
            {
                public ChudWidgetAnimationStruct Initializing;
                public ChudWidgetAnimationStruct Active;
                public ChudWidgetAnimationStruct Flashing;
                public ChudWidgetAnimationStruct Readying;
                public ChudWidgetAnimationStruct Unreadying;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public ChudWidgetAnimationStruct Impulse;

                [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo3ODST)]
                [TagStructure(Size = 0x18, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                [TagStructure(Size = 0x14, MinVersion = CacheVersion.HaloReach)]
                public class ChudWidgetAnimationStruct : TagStructure
                {
                    [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                    [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                    public ChudWidgetAnimationFlags Flags;
                    [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                    [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                    public ChudWidgetAnimationInputTypeEnum InputType;

                    [TagField(MinVersion = CacheVersion.HaloReach)]
                    public ChudWidgetAnimationFlagsReach FlagsReach;
                    [TagField(MinVersion = CacheVersion.HaloReach)]
                    public ChudWidgetAnimationInputTypeReach InputTypeReach;

                    [TagField(MinVersion = CacheVersion.HaloReach, Length = 0x2, Flags = TagFieldFlags.Padding)]
                    public byte[] ReachAnimationPadding;

                    [TagField(ValidTags = new[] { "chad" })]
                    public CachedTag Animation;

                    [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                    public float StateUnknown;

                    [Flags]
                    public enum ChudWidgetAnimationFlags : ushort
                    {
                        PlayReverse = 1 << 0
                    }

                    [Flags]
                    public enum ChudWidgetAnimationFlagsReach : sbyte
                    {
                        PlayReverse = 1 << 0
                    }

                    public enum ChudWidgetAnimationInputTypeEnum : short
                    {
                        Time,
                        Extern1,
                        Extern2,
                        UseCompassTarget, //? HO or invalid
                        UseUserTarget //? HO or invalid
                    }

                    public enum ChudWidgetAnimationInputTypeReach : sbyte
                    {
                        Time,
                        Extern1,
                        Extern2,
                        Zero
                    }
                }
            }

            [TagStructure(Size = 0x40, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0x48, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
            [TagStructure(Size = 0x78, MinVersion = CacheVersion.HaloReach)]
            public class RenderDatum : TagStructure
            {
                [TagField(MaxVersion = CacheVersion.HaloOnline700123, Flags = TagFieldFlags.Label)]
                public ChudShaderType ShaderType;
                [TagField(MinVersion = CacheVersion.HaloReach, Flags = TagFieldFlags.Label)]
                public ChudShaderTypeReach ShaderTypeReach;

                [TagField(Flags = TagFieldFlags.Padding, Length = 0x2, MinVersion = CacheVersion.Halo3Beta, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(Flags = TagFieldFlags.Padding, Length = 0x3, MinVersion = CacheVersion.HaloReach)]
                public byte[] Padding;

                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ChudBlendMode BlendModeHO;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ChudRenderExternalInputHO ExternalInput;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ChudRenderExternalInputHO RangeInput;

                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
                public ChudRenderExternalInput_H3 ExternalInput_H3;
                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
                public ChudRenderExternalInput_H3 RangeInput_H3;

                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
                public ChudRenderExternalInput_H3MCC ExternalInput_H3MCC;
                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
                public ChudRenderExternalInput_H3MCC RangeInput_H3MCC;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                public ChudRenderExternalInput_ODST ExternalInput_ODST;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                public ChudRenderExternalInput_ODST RangeInput_ODST;

                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ArgbColor LocalColorA;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ArgbColor LocalColorB;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ArgbColor LocalColorC;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public ArgbColor LocalColorD;

                [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor LocalColorA_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor LocalColorB_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor LocalColorC_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor LocalColorD_Reach;

                public float LocalScalarA;
                public float LocalScalarB;
                public float LocalScalarC;
                public float LocalScalarD;

                [TagField(MaxVersion = CacheVersion.Halo3ODST)] public OutputColorValue OutputColorA_Retail;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)] public OutputColorValue OutputColorB_Retail;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)] public OutputColorValue OutputColorC_Retail;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)] public OutputColorValue OutputColorD_Retail;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)] public OutputColorValue OutputColorE_Retail;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)] public OutputColorValue OutputColorF_Retail;

                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputColorValueReach OutputColorA_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputColorValueReach OutputColorB_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputColorValueReach OutputColorC_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputColorValueReach OutputColorD_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputColorValueReach OutputColorE_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputColorValueReach OutputColorF_Reach;

                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public OutputColorValue_HO OutputColorA;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public OutputColorValue_HO OutputColorB;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public OutputColorValue_HO OutputColorC;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public OutputColorValue_HO OutputColorD;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public OutputColorValue_HO OutputColorE;
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public OutputColorValue_HO OutputColorF;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public OutputScalarValue OutputScalarA;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public OutputScalarValue OutputScalarB;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public OutputScalarValue OutputScalarC;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public OutputScalarValue OutputScalarD;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public OutputScalarValue OutputScalarE;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public OutputScalarValue OutputScalarF;

                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputScalarValueReach OutputScalarA_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputScalarValueReach OutputScalarB_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputScalarValueReach OutputScalarC_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputScalarValueReach OutputScalarD_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputScalarValueReach OutputScalarE_Reach;
                [TagField(MinVersion = CacheVersion.HaloReach)] public OutputScalarValueReach OutputScalarF_Reach;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public Rectangle2d ScissorRect;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public ChudBlendModeReach BlendModeReach;
                [TagField(MinVersion = CacheVersion.HaloReach, Length = 0x2, Flags = TagFieldFlags.Padding)]
                public byte[] ReachPadding;

                public enum ChudShaderType : short
                {
                    Simple,
                    Meter,
                    TextSimple,
                    MeterShield,
                    MeterGradient,
                    Crosshair,
                    DirectionalDamage, // dontUse
                    Solid, // dontUse
                    Sensor, // dontUse
                    MeterSingleColor,
                    Navpoints,
                    Medal,
                    TextureCam,
                    CortanaScreen,
                    CortanaCamera,
                    CortanaOffscreen,
                    CortanaScreenFinal,
                    MeterChapter,
                    MeterDoubleGradient,
                    MeterRadialGradient,
                    DistortionAndBlur,
                    Emblem,
                    CortanaComposite,
                    DirectionalDamageApply,
                    ReallySimple,
                    Unknown // ?? not in H3 (DamageTrackerDontUse?)
                }

                public enum ChudShaderTypeReach : sbyte
                {
                    ReallySimple,
                    AntiAlias,
                    Meter,
                    TextSimple,
                    MeterShield,
                    MeterGradient,
                    Crosshair,
                    DirectionalDamage,
                    Solid,
                    Sensor,
                    MeterSingleColor,
                    Navpoints,
                    Medal,
                    TextureCam,
                    MeterChapter,
                    MeterDoubleGradient,
                    MeterRadialGradient,
                    DistortionAndBlur,
                    Emblem,
                    DirectionalDamageApply,
                    DamageTrackerDontUse
                }

                public enum ChudBlendMode : short
                {
                    AlphaBlend,
                    Additive,
                    Multiply,
                    Opaque,
                    DoubleMultiply,
                    PreMultipliedAlpha,
                    Maximum,
                    MultiplyAdd,
                    AddSrcTimesDstAlpha,
                    AddSrcTimesSrcAlpha,
                    InvAlphaBlend,
                    SeparateAlphaBlend,
                    SeparateAlphaBlendAdditive
                }

                public enum ChudBlendModeReach : short
                {
                    Opaque,
                    Additive,
                    Multiply,
                    AlphaBlend,
                    DoubleMultiply,
                    PreMultipliedAlpha,
                    Maximum,
                    MultiplyAdd,
                    AddSrcTimesDstAlpha,
                    AddSrcTimesSrcAlpha,
                    InvAlphaBlend,
                    MotionBlurStatic,
                    MotionBlurInhibit,
                    ApplyShadowToShadowMask,
                    AlphaBlendConstant,
                    OverdrawApply,
                    WetEffect,
                    Minimum
                }

                public enum ChudRenderExternalInputHO : short
                {
                    Zero,
                    One,
                    DebugSlide1,    // ? Time
                    DebugSlide100,  // ? Fade
                    BodyVitality,
                    HealthRecentDamage,
                    ShieldAmount,
                    ShieldRecentDamage,
                    WeaponAmmoLoaded,
                    WeaponAmmoReserve,
                    WeaponVersionNumber,
                    WeaponHeatFraction,
                    WeaponBatteryFraction,
                    WeaponErrorCurrent1,
                    WeaponErrorCurrent2,
                    ImpulseValue,
                    Autoaim,
                    GrenadeSelected,
                    GrenadeCount,
                    WeaponChargeFraction,
                    FriendlyScore,
                    EnemyScore,
                    ScoreToWin,
                    ArmingFraction,
                    LockingAmount,
                    Unit1xOvershieldCurrent,
                    Unit1xOvershieldRecentDmg,
                    Unit2xOvershieldCurrent,
                    Unit2xOvershieldRecentDmg,
                    Unit3xOvershieldCurrent,
                    Unit3xOvershieldRecentDmg,
                    CameraYaw,
                    CameraPitch,
                    TargetDistance,
                    TargetElevation,
                    EditorBudgetFraction,
                    EditorBudgetLeft,
                    SavedFilmTotalTime,
                    SavedFilmMarkerTime,
                    SavedFilmChapterWidth,
                    SavedFilmBufferedTheta,
                    SavedFilmCurrentPositionTheta,
                    SavedFilmRecordStartTheta,
                    SavedFilmPieFraction,
                    MetagameTime,
                    MetagameTransientScore,
                    MetagameP1Score,
                    MetagameP2Score,
                    MetagameP3Score,
                    MetagameP4Score,
                    MetagameTimeMultiplier,
                    MetagameSkullDifficultyModifier,
                    MotionSensorRange,
                    NetworkLatency,
                    NetworkLatencyQuality,
                    NetworkHostQuality,
                    NetworkLocalQuality,
                    MetagameScoreNegative,
                    SurvivalCurrentSet,
                    SurvivalCurrentRound,
                    SurvivalCurrentWave,
                    SurvivalCurrentLives,
                    SurvivalBonusTime,
                    SurvivalBonusScore,
                    SurvivalMultiplier,
                    MetagameTotalModifier,
                    Achievement1Current,
                    Achievement2Current,
                    Achievement3Current,
                    Achievement4Current,
                    Achievement5Current,
                    Achievement1Goal,
                    Achievement2Goal,
                    Achievement3Goal,
                    Achievement4Goal,
                    Achievement5Goal,
                    Achievement1Icon,
                    Achievement2Icon,
                    Achievement3Icon,
                    Achievement4Icon,
                    Achievement5Icon,
                    UnknownX51,
                    UnknownX52,
                    Consumable3Icon,
                    Consumable4Icon,
                    ConsumableName,
                    UnknownX56,
                    UnknownX57,
                    UnknownX58,
                    ConsumableCooldownText,
                    ConsumableCooldownMeter,
                    UnknownX5b,
                    UnknownX5c,
                    UnknownX5d,
                    UnknownX5e,
                    Consumable1Charge,
                    Consumable2Charge,
                    Consumable3Charge,
                    Consumable4Charge,
                    UnknownX63,
                    UnknownX64,
                    EnergyMeter1,
                    EnergyMeter2,
                    EnergyMeter3,
                    EnergyMeter4,
                    EnergyMeter5,
                    Consumable1Cost,
                    Consumable2Cost,
                    Consumable3Cost,
                    Consumable4Cost,
                    UnitStaminaCurrent
                }

                public enum ChudRenderExternalInput_H3 : short
                {
                    Zero,
                    One,
                    DebugSlide1,    // ? Time
                    DebugSlide100,  // ? Fade
                    ShieldAmount,
                    ShieldRecentDamage,
                    WeaponAmmoLoaded,
                    WeaponAmmoReserve,
                    WeaponHeatFraction,
                    WeaponBatteryFraction,
                    ImpulseValue,
                    Autoaim,
                    GrenadeSelected,
                    GrenadeCount,
                    WeaponChargeFraction,
                    FriendlyScore,
                    EnemyScore,
                    ScoreToWin,
                    ArmingFraction,
                    LockingAmount,
                    Unit1xOvershieldCurrent,
                    Unit1xOvershieldRecentDmg,
                    Unit2xOvershieldCurrent,
                    Unit2xOvershieldRecentDmg,
                    Unit3xOvershieldCurrent,
                    Unit3xOvershieldRecentDmg,
                    CameraYaw,
                    CameraPitch,
                    TargetDistance,
                    TargetElevation,
                    EditorBudgetFraction,
                    EditorBudgetLeft,
                    SavedFilmTotalTime,
                    SavedFilmMarkerTime,
                    SavedFilmChapterWidth,
                    SavedFilmBufferedTheta,
                    SavedFilmCurrentPositionTheta,
                    SavedFilmRecordStartTheta,
                    SavedFilmPieFraction,
                    MetagameTime,
                    MetagameTransientScore,
                    MetagameP1Score,
                    MetagameP2Score,
                    MetagameP3Score,
                    MetagameP4Score,
                    MetagameTimeMultiplier,
                    MetagameSkullDifficultyModifier,
                    MotionSensorRange,
                    NetworkLatency,
                    NetworkLatencyQuality,
                    NetworkHostQuality,
                    NetworkLocalQuality,
                    MetagameScoreNegative,
                }

                public enum ChudRenderExternalInput_ODST : short
                {
                    Zero,
                    One,
                    DebugSlide1,        // ? Time
                    DebugSlide100,      // ? Fade
                    BodyVitality,
                    HealthRecentDamage,
                    ShieldAmount,
                    ShieldRecentDamage,
                    WeaponAmmoLoaded,
                    WeaponAmmoReserve,
                    WeaponHeatFraction,
                    WeaponBatteryFraction,
                    ImpulseValue,
                    Autoaim,
                    GrenadeSelected,
                    GrenadeCount,
                    WeaponChargeFraction,
                    FriendlyScore,
                    EnemyScore,
                    ScoreToWin,
                    ArmingFraction,
                    LockingAmount,
                    Unit1xOvershieldCurrent,
                    Unit1xOvershieldRecentDmg,
                    Unit2xOvershieldCurrent,
                    Unit2xOvershieldRecentDmg,
                    Unit3xOvershieldCurrent,
                    Unit3xOvershieldRecentDmg,
                    CameraYaw,
                    CameraPitch,
                    TargetDistance,
                    TargetElevation,
                    EditorBudgetFraction,
                    EditorBudgetLeft,
                    SavedFilmTotalTime,
                    SavedFilmMarkerTime,
                    SavedFilmChapterWidth,
                    SavedFilmBufferedTheta,
                    SavedFilmCurrentPositionTheta,
                    SavedFilmRecordStartTheta,
                    SavedFilmPieFraction,
                    MetagameTime,
                    MetagameTransientScore,
                    MetagameP1Score,
                    MetagameP2Score,
                    MetagameP3Score,
                    MetagameP4Score,
                    MetagameTimeMultiplier,
                    MetagameSkullDifficultyModifier,
                    MotionSensorRange,
                    NetworkLatency,
                    NetworkLatencyQuality,
                    NetworkHostQuality,
                    NetworkLocalQuality,
                    MetagameScoreNegative,
                    CompassUserTargetUnknown, // Unknown1
                    CompassUserTargetYaw, // CompassDistanceToUserTarget
                    CompassUserTargetDistance, // CompassDistanceToUserTarget2
                    CompassTargetUnknown, // Unknown2
                    CompassTargetYaw, // CompassDistanceToTarget
                    CompassTargetDistance, // CompassDistanceToTarget2
                    SurvivalCurrentSet,
                    SurvivalCurrentRound,
                    SurvivalCurrentWave,
                    SurvivalCurrentLives,
                    SurvivalBonusTime,
                    SurvivalBonusScore,
                    SurvivalMultiplier,
                    Achievement1Current,
                    Achievement2Current,
                    Achievement3Current,
                    Achievement4Current,
                    Achievement5Current,
                    Achievement1Goal,
                    Achievement2Goal,
                    Achievement3Goal,
                    Achievement4Goal,
                    Achievement5Goal,
                    Achievement1Icon,
                    Achievement2Icon,
                    Achievement3Icon,
                    Achievement4Icon,
                    Achievement5Icon,
                }

                public enum ChudRenderExternalInput_H3MCC : short
                {
                    Zero,
                    One,
                    DebugSlide1,    // ? Time
                    DebugSlide100,  // ? Fade
                    BodyVitality,       // MCC only
                    HealthRecentDamage, // MCC only
                    ShieldAmount,
                    ShieldRecentDamage,
                    WeaponAmmoLoaded,
                    WeaponAmmoReserve,
                    WeaponHeatFraction,
                    WeaponBatteryFraction,
                    ImpulseValue,
                    Autoaim,
                    GrenadeSelected,
                    GrenadeCount,
                    WeaponChargeFraction,
                    FriendlyScore,
                    EnemyScore,
                    ScoreToWin,
                    ArmingFraction,
                    LockingAmount,
                    Unit1xOvershieldCurrent,
                    Unit1xOvershieldRecentDmg,
                    Unit2xOvershieldCurrent,
                    Unit2xOvershieldRecentDmg,
                    Unit3xOvershieldCurrent,
                    Unit3xOvershieldRecentDmg,
                    CameraYaw,
                    CameraPitch,
                    TargetDistance,
                    TargetElevation,
                    EditorBudgetFraction,
                    EditorBudgetLeft,
                    SavedFilmTotalTime,
                    SavedFilmMarkerTime,
                    SavedFilmChapterWidth,
                    SavedFilmBufferedTheta,
                    SavedFilmCurrentPositionTheta,
                    SavedFilmRecordStartTheta,
                    SavedFilmPieFraction,
                    MetagameTime,
                    MetagameTransientScore,
                    MetagameP1Score,
                    MetagameP2Score,
                    MetagameP3Score,
                    MetagameP4Score,
                    MetagameTimeMultiplier,
                    MetagameSkullDifficultyModifier,
                    MotionSensorRange,
                    NetworkLatency,
                    NetworkLatencyQuality,
                    NetworkHostQuality,
                    NetworkLocalQuality,
                    MetagameScoreNegative,
                }

                public enum OutputColorValue : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    ColorAnimationA, //just returns 0 for the color
                    ColorAnimationB, //just returns 0 for the color
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingMeter,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    GameTimeRemaining, //returns LocalA if there is more than 60 seconds left, or LocalB if there is less
                    PrimaryBackground,      // global 0
                    SecondaryBackground,
                    HighlightForeground,
                    WarningFlash,
                    CrosshairNormal,
                    CrosshairEnemy,         // global 5
                    CrosshairFriendly,
                    BlipBase,
                    SelfBlip,
                    EnemyBlip,
                    NeutralBlip,            // global 10
                    FriendlyBlip,
                    BlipPing,
                    ObjectiveBlipOnRadar,
                    ObjectiveBlipOffRadar,
                    NavpointFriendly,       // global 15
                    NavpointNeutral,
                    NavpointEnemy,
                    NavpointAllyDead,
                    MessageFlashSelf,
                    MessageFlashFriendly,   // global 20
                    MessageFlashEnemy,
                    MessageFlashNeutral,
                    InvincibleShield,
                    NavpointAllyStandingBy,
                    NavpointAllyFiring,   // global 25
                    NavpointAllyTakingDamage,
                    NavpointAllySpeaking,
                }

                public enum OutputColorValue_HO : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    ColorAnimationA,
                    ColorAnimationB,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingMeter,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    WeaponVersion,
                    GameTimeRemaining,      // Unknown14
                    PrimaryBackground,      // global 0
                    SecondaryBackground,
                    HighlightForeground,
                    WarningFlash,
                    CrosshairNormal,        // global 4
                    CrosshairEnemy,
                    CrosshairFriendly,
                    BlipBase,
                    SelfBlip,
                    EnemyBlip,
                    NeutralBlip,            // global 10
                    FriendlyBlip,
                    BlipPing,
                    ObjectiveBlipOnRadar,
                    ObjectiveBlipOffRadar,
                    NavpointFriendly,       // global 15
                    NavpointNeutral,
                    NavpointEnemy,
                    NavpointAllyDead,
                    NavpointAllyBlue,
                    MessageFlashSelf,        // global 20
                    MessageFlashFriendly,
                    MessageFlashEnemy,
                    MessageFlashNeutral,
                    InvincibleShield,
                    NavpointAllyStandingBy,
                    NavpointAllyFiring,
                    NavpointAllyTakingDamage,
                    NavpointAllySpeaking,
                    GlobalDynamic29_HO,     // White
                    WeaponOutlineDefault,
                    WeaponOutlineAmmo,
                    WeaponOutlineDamage,
                    WeaponOutlineAccuracy,
                    WeaponOutlineRateOfFire,
                    WeaponOutlineRange,
                    WeaponOutlinePower
                }

                public enum OutputColorValueReach : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    ColorAnimationA,
                    ColorAnimationB,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingMeter,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    MetagamePlayerColor,
                    CommendationGameTypeColor,
                    CommendationCalloutLevelColor,
                    ScriptedObjectPrimaryColor,
                    ScriptedObjectSecondaryColor,
                    PrimaryBackground,
                    SecondaryBackground,
                    HighlightForeground,
                    WarningFlash,
                    CrosshairNormal,
                    CrosshairEnemy,
                    CrosshairFriendly,
                    NavpointNormal,
                    NavpointFriendly,
                    NavpointNeutral,
                    NavpointEnemy,
                    NavpointAllyDead,
                    NavptLaserPointOpen,
                    NavptLaserPointLocked,
                    NavptText,
                    MessageFlashSelf,
                    MessageFlashFriendly,
                    MessageFlashEnemy,
                    MessageFlashNeutral,
                    InvincibleShield,
                    NavpointAllyFiring,
                    NavpointAllyTakingDamage,
                    NavpointAllySpeaking,
                    NavpointAllyCoopSpawning,
                    Custom0,
                    Custom1,
                    Custom2,
                    NeutralTerritory,
                    FireTeamTriangleClose,
                    FireTeamTriangleFar,
                    FireTeamTriangleBorderClose,
                    FireTeamTriangleBorderFar
                }

                public enum OutputScalarValue : short
                {
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    FlashAnimation,
                    ScalarAnimationB
                }

                public enum OutputScalarValueReach : short
                {
                    Zero,
                    One,
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    FlashAnimation,
                    ScalarAnimationB
                }
            }
        }

        [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x60, MinVersion = CacheVersion.HaloReach)]
        public class HudWidget : HudWidgetBase
        {
            [TagField(ValidTags = new[] { "cprl" }, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag ParallaxData;

            [TagField(ValidTags = new[] { "wdst" }, MinVersion = CacheVersion.HaloReach)]
            public CachedTag DatasourceTemplate;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ChudWidgetDatasourceBaseBlock> Datasource;

            public List<BitmapWidget> BitmapWidgets;
            public List<TextWidget> TextWidgets;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ChudWidgetObjectHighlightBlock> ObjectHighlightWidgets;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ReachHudWidgetStruct ReachValues;


            [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.HaloOnline700123)]
            [TagStructure(Size = 0x20, MinVersion = CacheVersion.HaloReach)]
            public class BitmapWidget : HudWidgetBase
            {
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public int RuntimeWidgetIndex;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public WidgetBitmapFlagsH3 FlagsH3;

                [TagField(Version = CacheVersion.Halo3ODST)]
                public WidgetBitmapFlagsODST FlagsODST;

                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public WidgetBitmapFlagsHO Flags;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public WidgetBitmapFlagsReach FlagsReach;

                [TagField(Length = 2, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.Halo3ODST)]
                public byte[] Padding0;

                [TagField(ValidTags = new[] { "bitm" })]
                public CachedTag Bitmap;

                public byte BitmapSequenceIndex;

                [TagField(Length = 3, Flags = TagFieldFlags.Padding)]
                public byte[] Padding2;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public Rectangle2d ClipBounds;

                [Flags]
                public enum WidgetBitmapFlagsH3 : ushort
                {
                    None,
                    MirrorHorizontally = 1 << 0,
                    MirrorVertically = 1 << 1,
                    ExtendBorder = 1 << 2, // stretch edges
                    UseTextureCam = 1 << 3,
                    UseWrapSampling = 1 << 4, // looping
                    SpriteFromPlayerCharacterType = 1 << 5,
                    Player1Emblem = 1 << 6,
                    Player2Emblem = 1 << 7,
                    Player3Emblem = 1 << 8,
                    Player4Emblem = 1 << 9,
                    ScaleAlphaByColOutA = 1 << 10,
                    Stretch = 1 << 11, // NCC
                }

                [Flags]
                public enum WidgetBitmapFlagsODST : ushort
                {
                    None,
                    MirrorHorizontally = 1 << 0,
                    MirrorVertically = 1 << 1,
                    ExtendBorder = 1 << 2, // stretch edges
                    UseTextureCam = 1 << 3,
                    UseWrapSampling = 1 << 4, // looping
                    SpriteFromPlayerCharacterType = 1 << 5,
                    SpriteFromSurvivalRounds = 1 << 6,
                    AutoPermuteExternalInput0 = 1 << 7,
                    AutoPermuteExternalInput1 = 1 << 8,
                    Player1Emblem = 1 << 9,
                    Player2Emblem = 1 << 10,
                    Player3Emblem = 1 << 11,
                    Player4Emblem = 1 << 12,
                    ScaleAlphaByColOutA = 1 << 13,
                    Stretch = 1 << 14, // MCC
                }

                [Flags]
                public enum WidgetBitmapFlagsHO : uint
                {
                    None,
                    MirrorHorizontally = 1 << 0,
                    MirrorVertically = 1 << 1,
                    ExtendBorder = 1 << 2, // stretch edges
                    UseTextureCam = 1 << 3,
                    UseWrapSampling = 1 << 4, // looping
                    SpriteFromPlayerCharacterType = 1 << 5,
                    SpriteFromSurvivalRounds = 1 << 6,
                    AutoPermuteExternalInput0 = 1 << 7,
                    AutoPermuteExternalInput1 = 1 << 8,
                    Player1Emblem = 1 << 9,
                    Player2Emblem = 1 << 10,
                    Player3Emblem = 1 << 11,
                    Player4Emblem = 1 << 12,
                    ScaleAlphaByColOutA = 1 << 13,
                    SpriteFromConsumable = 1 << 14,
                    SpriteFromWeapon = 1 << 15,
                    Stretch = 1 << 16, // ED
                }

                [Flags]
                public enum WidgetBitmapFlagsReach : uint
                {
                    None,
                    MirrorHorizontally = 1 << 0,
                    MirrorVertically = 1 << 1,
                    RemoveTwoPixelPadding = 1 << 2, // stretch edges
                    ExtendBorder = 1 << 3,
                    UseTextureCam = 1 << 4, // looping
                    UseWrapSampling = 1 << 5,
                    AutoPermute = 1 << 6,
                    AutoPermuteExternalInput0 = 1 << 7,
                    AutoPermuteExternalInput1 = 1 << 8,
                    Player1Emblem = 1 << 9,
                    Player2Emblem = 1 << 10,
                    Player3Emblem = 1 << 11,
                    Player4Emblem = 1 << 12,
                    EmblemMetagamePlayer = 1 << 13,
                    ScaleAlphaByColOutA = 1 << 14,
                    MpObjFt1Emblem = 1 << 15,
                    MpObjFt2Emblem = 1 << 16,
                    MpObjFt3Emblem = 1 << 17,
                    FtMemberEmblem = 1 << 18,
                    MpObjFt1Weapon = 1 << 19,
                    MpObjFt2Weapon = 1 << 20,
                    MpObjFt3Weapon = 1 << 21,
                    FtMemberWeapon = 1 << 22,
                    UsesManualBitmapTextureCoordinates = 1 << 23
                }
            }

            [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
            [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
            [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original, MaxVersion = CacheVersion.HaloOnline700123)]
            [TagStructure(Size = 0x8, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
            public class TextWidget : HudWidgetBase
            {
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public int WidgetIndex;

                // flags

                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
                public WidgetTextFlags_H3Original TextFlags_H3Original; // ushort
                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
                public WidgetTextFlags_H3MCC TextFlags_H3MCC; // uint
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public WidgetTextFlags TextFlags; // uint
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public WidgetTextFlags_Reach FlagsReach; // ushort

                // fonts
                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
                public WidgetFontValue_H3Original Font_H3; // short
                [TagField(EnumType = typeof(int), MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
                public WidgetFontValue_H3MCC Font_H3MCC; // int
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
                public WidgetFontValue_ODST Font_ODST; // short
                [TagField(Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
                public WidgetFontValue_ODST Font_ODSTMCC; // short
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public WidgetFontValue Font; // short
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public WidgetFontValue_Reach FontReach; // short

                [TagField(Length = 2, Flags = TagFieldFlags.Padding, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public byte[] FontPadding;

                public StringId InputString;

                [Flags]
                public enum WidgetTextFlags_H3Original : ushort
                {
                    None = 0,
                    StringIsANumber = 1 << 0,
                    Force2DigitNumber = 1 << 1,
                    Force3DigitNumber = 1 << 2,
                    Kudos = 1 << 3,
                    PostfixMForMeters = 1 << 4,
                    Decimal2Digits = 1 << 5,
                    Decimal3Digits = 1 << 6,
                    Decimal5Digits = 1 << 7,
                    SuperHugeNumber = 1 << 8,
                    PostfixX = 1 << 9,
                    WrapWithBrackets = 1 << 10,
                    FormatAsTime = 1 << 11,
                    FormatAsHhmmssTime = 1 << 12,
                    FormatAsBudgetNumber = 1 << 13,
                    KudosNegative = 1 << 14,
                    OnlyAxesGlobal = 1 << 15
                }

                [Flags]
                public enum WidgetTextFlags_H3MCC : uint
                {
                    None = 0,
                    StringIsANumber = 1 << 0,
                    Force2DigitNumber = 1 << 1,
                    Force3DigitNumber = 1 << 2,
                    Kudos = 1 << 3,
                    PostfixMForMeters = 1 << 4,
                    Decimal1Digit = 1 << 5,
                    Decimal2Digits = 1 << 6,
                    Decimal3Digits = 1 << 7,
                    Decimal5Digits = 1 << 8,
                    SuperHugeNumber = 1 << 9,
                    PostfixX = 1 << 10,
                    WrapWithBrackets = 1 << 11,
                    FormatAsTime = 1 << 12,
                    FormatAsHhmmssTime = 1 << 13,
                    FormatAsBudgetNumber = 1 << 14,
                    KudosNegative = 1 << 15,
                    CurveHorizontally = 1 << 16,
                    OnlyAxesGlobal = 1 << 17,
                    OnlyAxesLocal = 1 << 18
                }

                [Flags]
                public enum WidgetTextFlags : uint
                {
                    None,
                    StringIsANumber = 1 << 0,
                    Force2DigitNumber = 1 << 1,
                    Force3DigitNumber = 1 << 2,
                    Kudos = 1 << 3,
                    PostfixMForMeters = 1 << 4,
                    Decimal1Digit = 1 << 5,
                    Decimal2Digits = 1 << 6,
                    Decimal3Digits = 1 << 7,
                    Decimal5Digits = 1 << 8,
                    SuperHugeNumber = 1 << 9,
                    PostfixX = 1 << 10,
                    WrapWithBrackets = 1 << 11,
                    FormatAsTime = 1 << 12,
                    FormatAsHhmmssTime = 1 << 13,
                    FormatAsBudgetNumber = 1 << 14,
                    KudosNegative = 1 << 15,
                    CurveHorizontally = 1 << 16,
                    OnlyAxesGlobal = 1 << 17,
                    OnlyAxesLocal = 1 << 18,
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
                }

                [Flags]
                public enum WidgetTextFlags_Reach : ushort
                {
                    None,
                    StringIsANumber = 1 << 0,
                    Force2DigitNumber = 1 << 1,
                    Force3DigitNumber = 1 << 2,
                    Kudos = 1 << 3,
                    PostfixMForMeters = 1 << 4,
                    Decimal1Digit = 1 << 5,
                    Decimal2Digits = 1 << 6,
                    Decimal3Digits = 1 << 7,
                    Decimal5Digits = 1 << 8,
                    SuperHugeNumber = 1 << 9,
                    PostfixX = 1 << 10,
                    WrapWithBrackets = 1 << 11,
                    FormatAsTime = 1 << 12,
                    FormatAsHhmmssTime = 1 << 13,
                    FormatAsBudgetNumber = 1 << 14,
                    KudosNegative = 1 << 15
                }
            }

            [TagStructure(Size = 0x4, MinVersion = CacheVersion.HaloReach)]
            public class ChudWidgetObjectHighlightBlock : HudWidgetBase
            {
                public float IntensityMultiplier;
            }

            [TagStructure(Size = 0x20, MinVersion = CacheVersion.HaloReach)]
            public class ReachHudWidgetStruct : TagStructure
            {
                public sbyte HiddenStateCacheStartIndex;
                [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
                public byte[] SFLKJER;
                public short StateInvertCache;
                public short StateCache0;
                public short StateCache1;
                public short StateCache2;
                public short StateCache3;
                public short StateCache4;
                public short StateCache5;
                public short StateCache6;
                public short StateCache7;
                public short StateCache8;
                public short StateCache9;
                public short StateCache10;
                public short StateCache11;
                public short StateCache12;
            }
        }

        [TagStructure(Size = 0xC, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x10, MinVersion = CacheVersion.HaloReach)]
        public class ChudAmmunitionInfo : TagStructure
        {
            public int LowAmmoLoadedThreshold;
            public int LowAmmoReserveThreshold;
            public int LowBatteryThreshold;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public int FtMemberWeaponSequence;
        }

        [TagStructure(Size = 0x5C)]
        public class ReachUpdateCacheBlock : TagStructure
        {
            public ChudScriptingClassEnum ScriptingClass;
            public sbyte IntermediateListIndex;
            public ChudWidgetBaseFlags BaseFlags;
            public sbyte AnimationExistsFlags;
            public float InitializingAnimationStateDuration;
            public float ActiveAnimationStateDuration;
            public float FlashingAnimationStateDuration;
            public float ReadyingAnimationStateDuration;
            public float UnreadyingAnimationStateDuration;
            public ChudRenderExternalInputEnum ExternalInputA;
            public ChudRenderExternalInputEnum ExternalInputB;
            public int StateCacheInvertFlags;
            public sbyte FlashingStateCacheStartIndex;
            public sbyte HiddenStateCacheStartIndex;
            public short StateCache0;
            public short StateCache1;
            public short StateCache2;
            public short StateCache3;
            public short StateCache4;
            public short StateCache5;
            public short StateCache6;
            public short StateCache7;
            public short StateCache8;
            public short StateCache9;
            public short StateCache10;
            public short StateCache11;
            public short StateCache12;
            public short StateCache13;
            public short StateCache14;
            public short StateCache15;
            public short StateCache16;
            public short StateCache17;
            public short StateCache18;
            public short StateCache19;
            public short StateCache20;
            public short StateCache21;
            public short StateCache22;
            public short StateCache23;
            public short StateCache24;
            public short StateCache25;
            public short StateCache26;
            public short StateCache27;
            public short StateCache28;

            public enum ChudScriptingClassEnum : sbyte
            {
                UndefinedUseParent,
                WeaponStats,
                Crosshair,
                Shield,
                Grenades,
                Messages,
                MotionSensor,
                ChapterTitle,
                Cinematics
            }

            [Flags]
            public enum ChudWidgetBaseFlags : byte
            {
                DieOnActive = 1 << 0,
                SkipInputUpdateWhenUnreadying = 1 << 1,
                ResetTimerOnInputChange = 1 << 2,
                InheritSortLayer = 1 << 3,
                SpecialSavedFilmLayer = 1 << 4,
                NoCurvatureAndOnTop = 1 << 5
            }

            public enum ChudRenderExternalInputEnum : short
            {
                Zero,
                One,
                DatasourceDataIndex,
                DatasourceRenderSlot,
                ImpulseValue,
                DebugSlide1,
                DebugSlide100,
                HsObjectFunction1,
                HsObjectFunction2,
                HsObjectFunction3,
                HsObjectFunction4,
                ScriptedHsVariable1,
                ScriptedHsVariable2,
                ScriptedHsVariable3,
                ScriptedHsVariable4,
                ScriptedHsVariable5,
                ScriptedHsVariable6,
                ScriptedHsVariable7,
                ScriptedHsVariable8,
                ScriptedHsVariable9,
                ScriptedHsVariable10,
                VehicleHealth,
                VehicleHealthPercentage,
                UnshieldedVitality,
                UnshieldedRecentDamage,
                ShieldAmount,
                ShieldAmount2,
                ShieldAmount3,
                ShieldAmount4,
                ShieldRecentDamage,
                ShieldRecentDamage2,
                ShieldRecentDamage3,
                ShieldRecentDamage4,
                ShieldPercentage,
                VehicleShieldPercentage,
                VehicleBoostMeter,
                VehicleBoostRecharge,
                CameraYaw,
                CameraPitch,
                CameraRoll,
                MotionSensorRange,
                AltitudeF,
                AltitudeFraction,
                GameHeat,
                OutOfBoundsTimer,
                TransientCookies,
                TotalCookies,
                WeaponAmmoLoaded,
                WeaponAmmoReserve,
                WeaponAmmoPickup,
                WeaponHeat,
                WeaponHeatPercentage,
                WeaponBattery,
                WeaponPickup,
                WeaponAutoaimScale,
                WeaponBarrelErrorScale,
                WeaponBarrelPinnedErrorScale,
                WeaponAutoaimTarget,
                WeaponAutoaimTargetDistance,
                AirstrikeDistanceToTarget,
                AirstrikeWarmupTime,
                AirstrikeLaunchesLeft,
                AirstrikeLaunchState,
                GrenadeSelected,
                GrenadeCount,
                GrenadePickup,
                WeaponCharge,
                WeaponReloadPercentage,
                BarrelRecoveryPercentage,
                WeaponTetherPercentage,
                LockingAmount,
                FlavaTgtDistance,
                FlavaTgtElevation,
                EquipmentEnergy,
                EquipmentEnergyMinimumActivationEnergy,
                PlayerDistance,
                MedalSequenceIndex,
                ProgressionToastCurrentProgress,
                ProgressionToastGoal,
                ProgressionToastSequenceIndex,
                CommendationCalloutSequenceIndex,
                ScriptedObjectHealth,
                ScriptedObjectRecentBodyDamage,
                ScriptedObjectRecentShieldDamage,
                ScriptedObjectDistance, // meters
                ScriptedObjectElevation, // meters
                ScriptedObjectCombatStatus,
                ScriptedObjectPriorityOnscreenSequenceIndex,
                ScriptedObjectPriorityOffscreenSequenceIndex,
                LicensePlateIconIndex,
                LicensePlateDesignatorIconIndex,
                MetagameTime,
                MetagameTransientScore,
                MetagameP1Score,
                MetagameP2Score,
                MetagameP3Score,
                MetagameP4Score,
                MetagamePlayerScore,
                MetagameTimeMultiplier,
                MetagameSkullDiffMult,
                MetagameTotalMultiplier,
                MetagameNegTransScore,
                SurvivalModeSet,
                SurvivalModeRound,
                SurvivalModeWave,
                SurvivalModeLives,
                SurvivalModeEnemyLives,
                SurvivalModeBonusRoundTimer,
                SurvivalModeBonusRoundPoints,
                EnemyPlayerKills,
                SBFriendlyScore,
                SBEnemyScore,
                SBMaxScore,
                ArmingMeterFrac,
                MegaloEngineIconIndex,
                MegaloOmniWidgetMeterValue,
                MegaloOmniWidgetAugmentationIconSequenceIndex,
                MegaloProgressBarMeterValue,
                CampaignFtShield,
                CampaignFtPossibleActionObjDist, // meters
                CampaignFtPendingTargetObjDist, // meters
                CampaignFtCurrentTargetObjDist, // meters
                MpObjFt1Shield,
                MpObjFt2Shield,
                MpObjFt3Shield,
                MpObjFt1Meter,
                MpObjFt2Meter,
                MpObjFt3Meter,
                MpObjFt1Yaw,
                MpObjFt2Yaw,
                MpObjFt3Yaw,
                MpObjFt1DamageYaw,
                MpObjFt2DamageYaw,
                MpObjFt3DamageYaw,
                FtMemberShield,
                FtMemberMeter,
                FtMemberYaw,
                FtMemberDamageYaw,
                BudgetFraction,
                BudgetLeft,
                SFTotalTime,
                SFMarkerTime,
                SFChapWidth,
                SFBufferedTheta,
                SFCurrPosTheta,
                SFRecordStartTheta,
                SFPieFraction,
                NetworkLatency,
                NetworkLatencyQuality,
                NetworkHostQuality,
                NetworkLocalQuality
            }
        }

        public enum ChudScriptingClass : short
        {
            UseParent,
            WeaponStats,
            Crosshair,
            Shield,
            Grenades,
            Messages, //gametype related
            MotionSensor,
            SpikeGrenade,
            FireGrenade,
            Compass,
            Stamina,
            EnergyMeter,
            Consumable
        }

        public enum ChudScriptingClassReach : byte
        {
            UndefinedUseParent,
            WeaponStats,
            Crosshair,
            Shield,
            Grenades,
            Messages,
            MotionSensor,
            ChapterTitle,
            Cinematics
        }

        [Flags]
        public enum WidgetFlags : byte
        {
            None,
            DieOnActive = 1 << 0,
            SkipInputUpdateWhenUnreadying = 1 << 1,
            ResetTimerOnInputChange = 1 << 2,
            WeaponSwapHack = 1 << 3,
            EquipmentHack = 1 << 4
        }

        [Flags]
        public enum WidgetFlagsReach : byte
        {
            DieOnActive = 1 << 0,
            SkipInputUpdateWhenUnreadying = 1 << 1,
            ResetTimerOnInputChange = 1 << 2,
            InheritSortLayer = 1 << 3,
            SpecialSavedFilmLayer = 1 << 4,
            NoCurvatureAndOnTop = 1 << 5
        }

        public enum WidgetLayerEnum : byte
        {
            Background,
            Flashes,
            Parent,
            Middle,
            Child,
            Foreground,
            Inherited,
            SavedFilm
        }

        public enum ChudExternalInputReach : short
        {
            Zero,
            One,
            DatasourceDataIndex,
            DatasourceRenderSlot,
            ImpulseValue,
            DebugSlide1,
            DebugSlide100,
            HsObjectFunction1,
            HsObjectFunction2,
            HsObjectFunction3,
            HsObjectFunction4,
            ScriptedHsVariable1,
            ScriptedHsVariable2,
            ScriptedHsVariable3,
            ScriptedHsVariable4,
            ScriptedHsVariable5,
            ScriptedHsVariable6,
            ScriptedHsVariable7,
            ScriptedHsVariable8,
            ScriptedHsVariable9,
            ScriptedHsVariable10,
            VehicleHealth,
            VehicleHealthPercentage,
            UnshieldedVitality,
            UnshieldedRecentDamage,
            ShieldAmount,
            ShieldAmount2,
            ShieldAmount3,
            ShieldAmount4,
            ShieldRecentDamage,
            ShieldRecentDamage2,
            ShieldRecentDamage3,
            ShieldRecentDamage4,
            ShieldPercentage,
            VehicleShieldPercentage,
            VehicleBoostMeter,
            VehicleBoostRecharge,
            CameraYaw,
            CameraPitch,
            CameraRoll,
            MotionSensorRange,
            AltitudeF,
            AltitudeFraction,
            GameHeat,
            OutOfBoundsTimer,
            TransientCookies,
            TotalCookies,
            WeaponAmmoLoaded,
            WeaponAmmoReserve,
            WeaponAmmoPickup,
            WeaponHeat,
            WeaponHeatPercentage,
            WeaponBattery,
            WeaponPickup,
            WeaponAutoaimScale,
            WeaponBarrelErrorScale,
            WeaponBarrelPinnedErrorScale,
            WeaponAutoaimTarget,
            WeaponAutoaimTargetDistance,
            AirstrikeDistanceToTarget,
            AirstrikeWarmupTime,
            AirstrikeLaunchesLeft,
            AirstrikeLaunchState,
            GrenadeSelected,
            GrenadeCount,
            GrenadePickup,
            WeaponCharge,
            WeaponReloadPercentage,
            BarrelRecoveryPercentage,
            WeaponTetherPercentage,
            LockingAmount,
            FlavaTgtDistance,
            FlavaTgtElevation,
            EquipmentEnergy,
            EquipmentEnergyMinimumActivationEnergy,
            PlayerDistance,
            MedalSequenceIndex,
            ProgressionToastCurrentProgress,
            ProgressionToastGoal,
            ProgressionToastSequenceIndex,
            CommendationCalloutSequenceIndex,
            ScriptedObjectHealth,
            ScriptedObjectRecentBodyDamage,
            ScriptedObjectRecentShieldDamage,
            ScriptedObjectDistance, // meters
            ScriptedObjectElevation, // meters
            ScriptedObjectCombatStatus,
            ScriptedObjectPriorityOnscreenSequenceIndex,
            ScriptedObjectPriorityOffscreenSequenceIndex,
            LicensePlateIconIndex,
            LicensePlateDesignatorIconIndex,
            MetagameTime,
            MetagameTransientScore,
            MetagameP1Score,
            MetagameP2Score,
            MetagameP3Score,
            MetagameP4Score,
            MetagamePlayerScore,
            MetagameTimeMultiplier,
            MetagameSkullDiffMult,
            MetagameTotalMultiplier,
            MetagameNegTransScore,
            SurvivalModeSet,
            SurvivalModeRound,
            SurvivalModeWave,
            SurvivalModeLives,
            SurvivalModeEnemyLives,
            SurvivalModeBonusRoundTimer,
            SurvivalModeBonusRoundPoints,
            EnemyPlayerKills,
            SBFriendlyScore,
            SBEnemyScore,
            SBMaxScore,
            ArmingMeterFrac,
            MegaloEngineIconIndex,
            MegaloOmniWidgetMeterValue,
            MegaloOmniWidgetAugmentationIconSequenceIndex,
            MegaloProgressBarMeterValue,
            CampaignFtShield,
            CampaignFtPossibleActionObjDist, // meters
            CampaignFtPendingTargetObjDist, // meters
            CampaignFtCurrentTargetObjDist, // meters
            MpObjFt1Shield,
            MpObjFt2Shield,
            MpObjFt3Shield,
            MpObjFt1Meter,
            MpObjFt2Meter,
            MpObjFt3Meter,
            MpObjFt1Yaw,
            MpObjFt2Yaw,
            MpObjFt3Yaw,
            MpObjFt1DamageYaw,
            MpObjFt2DamageYaw,
            MpObjFt3DamageYaw,
            FtMemberShield,
            FtMemberMeter,
            FtMemberYaw,
            FtMemberDamageYaw,
            BudgetFraction,
            BudgetLeft,
            SFTotalTime,
            SFMarkerTime,
            SFChapWidth,
            SFBufferedTheta,
            SFCurrPosTheta,
            SFRecordStartTheta,
            SFPieFraction,
            NetworkLatency,
            NetworkLatencyQuality,
            NetworkHostQuality,
            NetworkLocalQuality
        }

        [TagStructure(Size = 0x20)]
        public class ChudWidgetDatasourceBaseBlock : TagStructure
        {
            public ChudDatasourceFlags Flags;
            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
            public byte[] SVHELRNN;
            public ChudDatasourceTypeEnum Type;
            public short RenderMaximum;
            public List<ChudDatasourceResolutionBlock> Resolutions;
            public List<ChudDatasourcePositionBlock> Positions; // As offsets from the previous one

            [Flags]
            public enum ChudDatasourceFlags : byte
            {
                Extend = 1 << 0, // Use the final datasource position offset over and over
                Center = 1 << 1, // Center the elements around the first position using the second position as the offset between them
                EvenlySpace = 1 << 2, // Evenly space elements between the first two positions
                Reverse = 1 << 3 // Iterate over the datasource in reverse order
            }

            public enum ChudDatasourceTypeEnum : short
            {
                Grenades,
                Players,
                MetagamePlayers,
                FireteamMembers,
                CampaignFireteamMembers,
                Medals,
                ProgressionToasts,
                ScriptedObjects,
                Skulls,
                TrackingObjects, // projectiles tracking the current player
                OmniWidgetsTopLeft,
                OmniWidgetsTopCenter,
                OmniWidgetsTopRight,
                OmniWidgetsHighLeft,
                OmniWidgetsHighCenter,
                OmniWidgetsHighRight,
                OmniWidgetsLowLeft,
                OmniWidgetsLowCenter,
                OmniWidgetsLowRight,
                OmniWidgetsBottomLeft,
                OmniWidgetsBottomCenter,
                OmniWidgetsBottomRight
            }

            [TagStructure(Size = 0x4)]
            public class ChudDatasourceResolutionBlock : TagStructure
            {
                public ChudCurvatureResFlags ResFlags;
                [TagField(Length = 0x1, Flags = TagFieldFlags.Padding)]
                public byte[] ASFYUIHHIER;
                public short RenderMaximum;

                [Flags]
                public enum ChudCurvatureResFlags : byte
                {
                    FullscreenWide = 1 << 0,
                    FullscreenStandard = 1 << 1,
                    Halfscreen = 1 << 2,
                    QuarterscreenWide = 1 << 3,
                    QuarterscreenStandard = 1 << 4
                }
            }

            [TagStructure(Size = 0x10)]
            public class ChudDatasourcePositionBlock : TagStructure
            {
                public RealPoint2d OriginOffset;
                public RealPoint2d WidgetScale;
            }
        }

        [TagStructure(Size = 0xC)]
        public class ChudWidgetStateAndBlock : TagStructure
        {
            public List<ChudWidgetStateOrBlock> Or;

            [TagStructure(Size = 0x8)]
            public class ChudWidgetStateOrBlock : TagStructure
            {
                public ChudWidgetStateFlags Flags;
                [TagField(Length = 0x3, Flags = TagFieldFlags.Padding)]
                public byte[] ReachPadding;
                public ChudStateEnumReach Condition;

                [Flags]
                public enum ChudWidgetStateFlags : byte
                {
                    InvertCondition = 1 << 0 // Check if the condition is false
                }

                
            }
        }

        [TagStructure(Size = 0x14)]
        public class ChudWidgetStateEditorBlock : TagStructure
        {
            public ChudWidgetStateFlags Flags;
            public ChudWidgetStateEditorDataTypeEnum Type;
            public ChudStateEnumReach Condition;
            public short Parent;
            public short FirstChild;
            public short NextSibling;
            [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
            public byte[] XJZPOOP;

            [Flags]
            public enum ChudWidgetStateFlags : uint
            {
                InvertCondition = 1 << 0 // Check if the condition is false
            }

            public enum ChudWidgetStateEditorDataTypeEnum : int
            {
                State,
                And,
                Or
            }
        }

        public enum ChudStateEnumReach : int
        {
            FlagDeletedFromCode,
            WideFull,
            StandardFull,
            WideHalf,
            WideQuarter,
            StandardQuarter,
            TextureCamAvailable,
            ChudStateDebugFlag,
            HsVariable1Active,
            HsVariable2Active,
            HsVariable3Active,
            HsVariable4Active,
            HsVariable5Active,
            HsVariable6Active,
            HsVariable7Active,
            HsVariable8Active,
            HsVariable9Active,
            HsVariable10Active,
            HsScreenTrainingActive,
            HsScreenObjectiveActive,
            HsScreenChapterTitleActive,
            Spartan,
            Elite,
            Monitor,
            FirstPersonCamera,
            ThirdPersonCamera,
            HealthMinorDamage,
            HealthMediumDamage,
            HealthHeavyDamage,
            ShieldsMinorDamage,
            ShieldsMediumDamage,
            ShieldsHeavyDamage,
            HasShields,
            HasOvershieldLevel1,
            HasOvershieldLevel2,
            HasOvershieldLevel3,
            PlayerTrainingAvailable,
            HasMinimap,
            SensorRange10m,
            SensorRange25m,
            SensorRange75m,
            SensorRange150m,
            Unarmed,
            IsSingleWielding,
            IsDualWielding,
            HasSupportWeapon,
            InSabre,
            MotionTrackerEnabled,
            MotionTrackerDisabled,
            BinocularsActive,
            BinocularsNotActive,
            EquipmentActive,
            EquipmentInactive,
            EquipmentDisabledByPlayerTraits,
            EquipmentReachedMinimumActivationEnergy,
            LasingEnabled,
            LasingDisabled,
            PlayerIsFiring,
            PlayerIsTalking,
            PlayerIsBroadcasting,
            VoiceNo,
            VoiceBanned,
            VoiceRadio,
            VoiceRadioBrdcst,
            VoiceOpen,
            VoiceOpenBrdcst,
            InSpace,
            AirstrikeEnabled,
            AirstrikeIsOffscreen,
            GhostTargetAvailable,
            HologramTargetAvailable,
            AirstrikeTargetAvailable,
            TargetTrackingAvailable,
            TrackedTargetIsOffscreen,
            HeatIsOnFire,
            HeatIsOnBetrayalPenalty,
            _3dMotionSensorEnabled,
            OutOfBounds,
            VtolAltitudeLocked,
            MissileLocked,
            MissileTracking,
            MissileLockedReallyClose,
            BackpackWeaponUnavailable,
            Zoomed,
            Unzoomed,
            ZoomLvl1,
            ZoomLvl2,
            ZoomChanging0To1,
            ZoomChanging1To2,
            ZoomChanging1To0,
            ZoomChanging2To0,
            SniperFlavaAvailable,
            GrenadesUnusable,
            GrenadeSelected,
            GrenadeUnselected,
            GrenadePickup,
            GrenadeEmpty,
            WeaponIsRightHand,
            WeaponIsLeftHand,
            WeaponIsBackpacked,
            CrosshairNormal,
            CrosshairFriendly,
            CrosshairEnemy,
            CrosshairEnemyHeadshot,
            CrosshairEnemyWeakpoint,
            CrosshairInvincible,
            PlasmaTrack,
            AmmoLoadedLow,
            AmmoLoadedEmpty,
            AmmoReserveLow,
            AmmoReserveEmpty,
            BatteryLow,
            BatteryEmpty,
            Overheating,
            LockingOnAvailable,
            LockAvailable,
            LockUnavailable,
            LockedOnAvailable,
            LockedOnUnavailable,
            AmmoPickup,
            SkullActive,
            SkullIsPrimary,
            SkullIsSecondary,
            SkullIsCustom,
            FireteamCommandModeAvailable,
            FireteamPossibleActionObjectValid,
            FireteamPendingActionObjectValid,
            FireteamCurrentTargetObjectValid,
            FireteamPossibleActionObjectOffscreen,
            FireteamPendingActionObjectOffscreen,
            FireteamCurrentTargetObjectOffscreen,
            FireteamPendingDirectiveUnitValid,
            FireteamCurrentDirectiveUnitValid,
            FireteamPendingDirectiveUnitOffscreen,
            FireteamCurrentDirectiveUnitOffscreen,
            CampaignFireteamRegroupEnabled,
            CampaignFireteamSlot1Open,
            CampaignFireteamSlot2Open,
            CampaignFireteamSlot3Open,
            CampaignFireteamSlot4Open,
            CampaignFireteamSlot5Open,
            CampaignFtMemberActive,
            CampaignFtMemberSlotOpen,
            CampaignFtMemberDirectiveGiven,
            CampaignFtMemberDirectiveComplete,
            CampaignFtMemberHealthCritical,
            CampaignFtMemberDead,
            CampaignFtMemberSpeaking,
            MedalValid,
            ProgressionToastActive,
            ProgressionToastLevelClear,
            ProgressionToastLevelSteel,
            ProgressionToastLevelBronze,
            ProgressionToastLevelSilver,
            ProgressionToastLevelGold,
            ProgressionToastLevelOnyx,
            ProgressionToastLevelMax,
            PlayerActive,
            PlayerAlive,
            PlayerIsMe,
            PlayerOnSameTeamFireteam,
            PlayerIsEnemy,
            PlayerSpeaking,
            PlayerInLineOfSight,
            PlayerTakingDamage,
            PlayerIsShooting,
            PlayerHasBeenSpotted,
            PlayerIsBeingSpawnedOn,
            PlayerOffscreen,
            WatermarkCompassOn,
            CommendationCalloutActive,
            CommendationCalloutLevelSteel,
            CommendationCalloutLevelBronze,
            CommendationCalloutLevelSilver,
            CommendationCalloutLevelGold,
            CommendationCalloutLevelOnyx,
            CommendationCalloutLevelMax,
            TransientCookiesAvailable,
            CampaignSolo,
            CampaignCoop,
            CampaignSurvival,
            DifficultyEasy,
            DifficultyNormal,
            DifficultyHeroic,
            DifficultyLegendary,
            CampaignObjectiveAvailable,
            MetagamePlayerActive,
            MetagamePlayerTalking,
            MetagameP1Talking,
            MetagameP2Enabled,
            MetagameP2Talking,
            MetagameP3Enabled,
            MetagameP3Talking,
            MetagameP4Enabled,
            MetagameP4Talking,
            TransientScoreAvail,
            MetagameMultikillAvail,
            MetagameNegScoreAvail,
            MetagameFfaScoring,
            MetagameTeamScoring,
            ScriptedObjectValid,
            ScriptedObjectAlive,
            ScriptedObjectOffscreen,
            ScriptedObjectTakenRecentBodyDamage,
            ScriptedObjectTakenRecentShieldDamage,
            ScriptedObjectPriority0,
            ScriptedObjectPriority1,
            ScriptedObjectPriority2,
            ScriptedObjectPriority3,
            ScriptedObjectPriority4,
            ScriptedObjectPriority5,
            ScriptedObjectPriority6,
            ScriptedObjectPriority7,
            ScriptedObjectPriority8,
            ScriptedObjectPriority9,
            ScriptedObjectPriority10,
            ScriptedObjectPriority11,
            ScriptedObjectPriority12,
            ScriptedObjectPriority13,
            ScriptedObjectPriority14,
            ScriptedObjectPriority15,
            ScriptedObjectPriority16,
            ScriptedObjectPriority17,
            ScriptedObjectPriority18,
            ScriptedObjectPriority19,
            ScriptedObjectPriority20,
            ScriptedObjectPriority21,
            ScriptedObjectPriority22,
            ScriptedObjectPriority23,
            ScriptedObjectPriority24,
            ScriptedObjectPriority25,
            ScriptedObjectPriority26,
            ScriptedObjectPriority27,
            ScriptedObjectPriority28,
            ScriptedObjectPriority29,
            SurvivalWave0,
            SurvivalWave1,
            SurvivalWave2,
            SurvivalWave3,
            SurvivalWave4,
            SurvivalWave5,
            SurvivalWave6,
            SurvivalWave7,
            SurvivalWave8,
            SurvivalWave9,
            SurvivalRound0,
            SurvivalRound1,
            SurvivalRound2,
            SurvivalRound3,
            SurvivalRound4,
            SurvivalRound5,
            SurvivalRound6,
            SurvivalRound7,
            SurvivalRound8,
            SurvivalRound9,
            SurvivalLivesInfinite,
            SurvivalLives0,
            SurvivalLives1,
            SurvivalLives2,
            SurvivalLives3,
            SurvivalLives4,
            SurvivalLives5,
            SurvivalBonusRound,
            MultiFfa,
            MultiTeam,
            MpSandbox,
            MpMegalo,
            Offense,
            Defense,
            GameHasNoTeams,
            PlayerIsSpecial,
            PlayerSpecialAndDefense,
            FriendlyScoreAvailable,
            EnemyScoreAvailable,
            VariantNameAvailable,
            VariantObjectiveAvailable,
            VariantObjectiveDesignatorAvailable,
            TalkingPlayerAvailable,
            ArmingMeterAvailable,
            TimeLeftAvailable,
            FriendlyPosession,
            EnemyPosession,
            VariantCustomA,
            VariantCustomB,
            VariantCustomC,
            VariantCustomD,
            VariantCustomE,
            VariantCustomF,
            RoundStartPeriod,
            TestEnabled,
            MegaloOmniWidgetAvailable,
            MegaloOmniWidgetLabelStringAvailable,
            MegaloOmniWidgetValueStringAvailable,
            MegaloOmniWidgetMeterAvailable,
            MegaloOmniWidgetIconAvailable,
            MegaloProgressBarAvailable,
            LastManStanding,
            TeammateAttemptingToSpawn,
            StatusReadyToSpawn,
            StatusWaitingToSpawn,
            StatusEnemyTerritory,
            StatusTeammateDamage,
            StatusEnemyNearby,
            StatusProjectiles,
            FtMember1,
            FtMember2,
            FtMember3,
            FtMemberIsMember1,
            FtMemberIsMember2,
            FtMemberIsMember3,
            FtMemberExists,
            FtMemberAlive,
            FtMemberIdle,
            FtMemberArming,
            FtMemberDisarming,
            FtMemberDead,
            FtMemberBuying,
            FtMemberTakingDamage,
            FtMemberShieldEmpty,
            BudgetAvailable,
            DefaultCrosshair,
            ActiveCrosshair,
            ManipulationCrosshair,
            NotAllowedCrosshair,
            ForgeScreenOpen,
            FilmPlayback,
            SavedFilmRecordingMode,
            SavedFilmNormalMode
        }
    }
}
