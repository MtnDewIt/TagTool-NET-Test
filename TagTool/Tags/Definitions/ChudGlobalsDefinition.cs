using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;
using static TagTool.Tags.TagFieldFlags;
using System.Drawing;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "chud_globals_definition", Tag = "chgd", Size = 0xF0, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Name = "chud_globals_definition", Tag = "chgd", Size = 0x208, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
    [TagStructure(Name = "chud_globals_definition", Tag = "chgd", Size = 0x198, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
    [TagStructure(Name = "chud_globals_definition", Tag = "chgd", Size = 0x2C0, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
    [TagStructure(Name = "chud_globals_definition", Tag = "chgd", Size = 0x46C, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
    [TagStructure(Name = "chud_globals_definition", Tag = "chgd", Size = 0x210, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
    public class ChudGlobalsDefinition : TagStructure
    {
        public List<HudGlobal> HudGlobals;
        public List<HudShader> HudShaders;

        [TagField(Platform = CachePlatform.Original)]
        public List<ChudSuckProfile> SuckProfiles;

        [TagField(Platform = CachePlatform.Original, MaxVersion = CacheVersion.HaloOnline700123)]
        public List<CortanaEffectConfig> CortanaConfigs;

        public List<PlayerTrainingDatum> PlayerTrainingData;
        public CampaignMetagameStruct CampaignMetagame;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public CachedTag DirectDamageMicrotexture;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public float MicrotextureScale;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CachedTag SurvivalModeMultiplayerIntroReach;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float ProgressionToastTime;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public MotionSensorFlagsValue MotionSensorFlags;
        [TagField(Flags = Padding, Length = 3, MinVersion = CacheVersion.HaloReach)]
        public byte[] SensorFlagsPadReach;

        public float MediumSensorBlipScale;
        public float SmallSensorBlipScale;
        public float LargeSensorBlipScale;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float Vehicle3dMotionTrackerRange;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float MotionTracker3dTilt;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float UpMovementRegistrationPercentage;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float DownMovementRegistrationPercentage;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float DefaultMaxDistance;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float GutterRange;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float VehicleGutterRange;

        public float MaxAgeSize; // SensorBlipGlowAmount ??

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public float SizePower; // SensorBlipGlowRadius ??
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public float AlphaPower; // SensorBlipGlowOpacity ??

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public TagFunction SizeReach;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public TagFunction AlphaReach;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float MotionSensorVelocityThresholdNonplayers;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float FtTriangleCloseColorDistThreshold;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float FtTriangleFarColorDistThreshold;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float FireteamTriangleTexelsPixel;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CachedTag FireteamTriangleTextureReference;

        public CachedTag MotionSensorBlip;

        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public CachedTag GruntBirthdayEffect;
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public CachedTag CampaignFloodMask; // TentaclePorn
        [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
        public CachedTag CampaignFloodMaskTile; // FloodGoo

        // Minimap

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public MinimapFlagsValue MinimapFlags;
        [TagField(Length = 3, Flags = Padding, MinVersion = CacheVersion.HaloReach)]
        public byte[] MinimapFlagsPad;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float ActiveTime;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public CachedTag PingTexture;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public sbyte PingSequence;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public sbyte PingFrame;
        [TagField(Length = 2, Flags = Padding, MinVersion = CacheVersion.HaloReach)]
        public byte[] PingPadReach;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float PingInitialSize;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float PingFinalSize;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float PingInitialAlpha;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float PingFinalAlpha;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public float PingExpansionTime;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public int MaximumSimultaneousPings;

        // Group Pings

        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachPingProperties FriendObjectArmingPing;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachPingProperties FriendObjectArmedPing;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachPingProperties CallForHelpPing;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachPingProperties NewCameraPerspectivePing;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachPingProperties EnemySpottedPing;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachPingProperties RadioMessageSentPing;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachPingProperties LocationMentionedPing;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachWaypointProperties ViewingPlayerWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachWaypointProperties FireteamMatePlayerWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachWaypointProperties FireteamLeaderPlayerWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachWaypointProperties AlliedPlayerWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachWaypointProperties AlliedFireteamLeaderWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public ReachWaypointProperties KnownEnemyPlayerWaypoint;

        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties HumanPrimaryObjectiveWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties HumanSecondaryObjectiveWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties MoneyTreeWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties CovyPrimaryObjectiveWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties CovySecondaryObjectiveWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties HumanFireteamLabel1Waypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties CovyFireteamLabel1Waypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties CovyFireteamLabel2Waypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties HumanFireteamLabel2Waypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties CovyFireteamLabel3Waypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties HumanFireteamLabel3Waypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties TargetWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties DestinationWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties BombWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties FlagWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties SkullWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties HillWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties VipWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties PadlockWaypoint;
        [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        public ReachWaypointProperties TerritoryWaypoint;

        [TagField(Gen = CacheGeneration.HaloOnline)]
        public float MotionSensorLevelHeightRange = float.MaxValue; // if object outside this height range of player, up/down indicator is used respectively
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.HaloOnline700123)]
        public float ShieldMinorThreshold;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.HaloOnline700123)]
        public float ShieldMajorThreshold;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.HaloOnline700123)]
        public float ShieldCriticalThreshold;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.HaloOnline700123)]
        public float HealthMinorThreshold;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.HaloOnline700123)]
        public float HealthMajorThreshold;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.HaloOnline700123)]
        public float HealthCriticalThreshold;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public RealRgbColor HealthMultiplyColor0 = new RealRgbColor(1.0f, 1.0f, 1.0f);
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public float HealthMultiplyColor0Alpha;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public RealRgbColor HealthMultiplyColor1 = new RealRgbColor(1.0f, 1.0f, 1.0f);
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public float HealthMultiplyColor1Alpha;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public RealRgbColor HealthAdditiveColor0;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public float HealthAdditiveColor0Alpha;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public RealRgbColor HealthAdditiveColor1;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public float HealthAdditiveColor1Alpha;

        //DAMAGE MASK FUNCTIONS AND VARIABLES
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public TagFunction HealthEffectDamageMaskIntensity = new TagFunction
        {
            Data = new byte[]
            {
                0x08, 0x3C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6F, 0x12, 0x83, 0x3A,
                0x6F, 0x12, 0x03, 0x3B, 0x28, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
                0x0A, 0x00, 0x00, 0xCD, 0xFF, 0xFF, 0x7F, 0x7F, 0x77, 0xBE, 0xFF, 0xBF,
                0xD9, 0xCE, 0x3F, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x4B, 0xDD, 0x97, 0x40
            }
        };

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public RealRgbColor ShieldMultiplyColor0;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public float ShieldMultiplyColor0Alpha;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public RealRgbColor ShieldMultiplyColor1;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public float ShieldMultiplyColor1Alpha;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public RealRgbColor ShieldAdditiveColor0;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public float ShieldAdditiveColor0Alpha;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public RealRgbColor ShieldAdditiveColor1;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public float ShieldAdditiveColor1Alpha;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public TagFunction ShieldEffectDamageMaskIntensity = new TagFunction
        {
            Data = new byte[]
            {
                0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
                0x0A, 0x00, 0x00, 0xCD, 0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x00, 0xC0,
                0x00, 0x00, 0x40, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x4B, 0xDD, 0x97, 0x40
            }
        };

        //ODST VALUES FOR PDA/BEACON
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public float PDABeaconTextOuterFadeAngle;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public float PDABeaconTextInnerFadeAngle;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public float PDABeaconRadiusmin;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public float PDABeaconRadiusmax;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public float PDAUserBeaconRadius;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public float WaypointDistanceMax;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public TagFunction WaypointDistanceModifier;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public TagFunction WaypointAngleModifier;

        //HO VALUES
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public float SprintFovMultiplier = 1.0f;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public float SprintFovTransitionInTime = 0.5f;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public float SprintFovTransitionOutTime = 1.0f;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public CachedTag ParallaxData = null;

        [TagField(Gen = CacheGeneration.HaloOnline)]
        public CameraShakeFunctions CameraShakeRunning;
        [TagField(Gen = CacheGeneration.HaloOnline)]
        public CameraShakeFunctions CameraShakeSprinting;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        public CachedTag SurvivalModeMultiplayerIntro = null;  //chdt tagreference which activates in firefight

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
        public float AchievementDisplayTime = 3.0f;

        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public float Unknown73;
        [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        public float Unknown74;

        [TagField(MinVersion = CacheVersion.HaloReach)]
        public List<ChudStateCategoryBlock> StateCategories;

        [TagStructure(Size = 0x208, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x1C8, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
        [TagStructure(Size = 0x23C, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x1FC, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
        [TagStructure(Size = 0x2B0, MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x584, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
        [TagStructure(Size = 0x534, MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.MCC)]
        public class HudGlobal : TagStructure
        {
            [TagField(Flags = Label)]
            public ChudSkinType Type;
            // possible mismatches below
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor PrimaryBackground;         // global 0
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor SecondaryBackground;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor HighlightForeground;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor WarningFlash;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor CrosshairNormal;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor CrosshairEnemy;            // global 5
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor CrosshairFriendly;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor BaseBlip;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor SelfBlip;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor EnemyBlip;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NeutralBlip;               // global 10
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor FriendlyBlip;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor BlipPing;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor ObjectiveBlipOnRadar;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor ObjectiveBlipOffRadar;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointFriendly;          // global 15
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointNeutral;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointEnemy;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointAllyDead;

            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor NavpointAllyBlue;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor MessageFlashSelf;          // global 20
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor MessageFlashFriendly;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor MessageFlashEnemy;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor MessageFlashNeutral;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor InvincibleShield;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointAllyStandingBy;    // global 25
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointAllyFiring;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointAllyTakingDamage;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)] public ArgbColor NavpointAllySpeaking;

            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor GlobalDynamic29_HO;        // White
            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor DefaultItemOutline;        // global 30
            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor MAGItemOutline;
            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor DMGItemOutline;
            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor ACCItemOutline;
            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor ROFItemOutline;
            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor RNGItemOutline;
            [TagField(Gen = CacheGeneration.HaloOnline)] public ArgbColor PWRItemOutline;

            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor PrimaryBackgroundReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor SecondaryBackgroundReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor HighlightBackground;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor FlashBackground;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor CrosshairNormalReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor CrosshairEnemyReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor CrosshairFriendlyReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptNormal;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptAlly;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptNeutral;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptEnemy;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptDead;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptLaserPointUnlocked;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptLaserPointLocked;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NavptText;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor MsgFlashSelf;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor MsgFlashFriend;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor MsgFlashEnemy;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor MsgFlashNeutral;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor InvincibleShieldReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor PlayerNavpointFiring;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor PlayerNavpointTakingDamage;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor PlayerNavpointSpeaking;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor PlayerNavpointCoopSpawning;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor Custom0;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor Custom1;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor Custom2;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor NeutralTerritory;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor FireTeamTriangleClose;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor FireTeamTriangleFar;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor FireTeamTriangleBorderClose;
            [TagField(MinVersion = CacheVersion.HaloReach)] public RealArgbColor FireTeamTriangleBorderFar;

            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipBase;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipSelf;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipEnemy;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipNeutral;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipFriend;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipFireteam;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipPingReach;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipCustomOnscreen;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction BlipCustomOffscreen;
            [TagField(MinVersion = CacheVersion.HaloReach)] public TagFunction MotionSensorHeight;

            [TagField(MinVersion = CacheVersion.HaloReach)] public float MotionSensorHeightMax;
            [TagField(MinVersion = CacheVersion.HaloReach)] public float MotionSensorHeightAboveThreshold;
            [TagField(MinVersion = CacheVersion.HaloReach)] public float MotionSensorHeightBelowThreshold;
            [TagField(MinVersion = CacheVersion.HaloReach)] public float MotionSensorHeightMin;

            public List<HudAttribute> HudAttributes;
            public List<HudSound> HudSounds;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float CloseProjectileWarningDistance;

            public CachedTag BannedVehicleEntranceSound;
            public CachedTag FragGrenadeSwapSound;
            public CachedTag PlasmaGrenadeSwapSound;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag SpikeGrenadeSwapSound;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag FirebombGrenadeSwapSound;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public DirectionalDamageFlagsValue DirectionalDamageFlags;
            [TagField(Flags = Padding, Length = 3, MinVersion = CacheVersion.HaloReach)]
            public byte[] PadReach;

            public CachedTag DamageMicrotexture;

            [TagField(MinVersion = CacheVersion.HaloReach)] public float MicrotextureScale;
            [TagField(MinVersion = CacheVersion.HaloReach)] public float MicrotextureCenterFadeScale;
            [TagField(MinVersion = CacheVersion.HaloReach)] public float MicrotextureCenterFadeFalloff;
            [TagField(MinVersion = CacheVersion.HaloReach)] public float MicrotextureCenterFadeInnerAlpha;
            [TagField(MinVersion = CacheVersion.HaloReach)] public float MicrotextureCenterFadeOuterAlpha;

            [TagField(Platform = CachePlatform.Original)]
            public CachedTag DamageNoise;

            public CachedTag DamageDirectionalArrow;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CachedTag DamageDirectionalArrowFastForward;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CachedTag MotionSensorDirectionalArrow;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public CachedTag MotionSensorDirectionalArrowFastForward;

            [TagField(Gen = CacheGeneration.HaloOnline)]
            public CachedTag GrenadeWaypoint = null;
            [TagField(Gen = CacheGeneration.HaloOnline)]
            public CachedTag PinkGradient = null;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public float DirectionalArrowDisplayTime;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public float DirectionalCutoffAngle;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public float DirectionalArrowScale;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float DirectionalDamageDistanceFromCrosshair;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float DirectionalDamageDurationModifier;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float DirectionalDamageMin;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public float DirectionalDamageMax;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public TagFunction DirectionalDamagePitch;

            [TagField(Gen = CacheGeneration.HaloOnline)]
            public float Unknown10;
            [TagField(Gen = CacheGeneration.HaloOnline)]
            public float Unknown11;
            [TagField(Gen = CacheGeneration.HaloOnline)]
            public float Unknown12;

            public CachedTag Waypoints;

            [TagField(Gen = CacheGeneration.HaloOnline)]
            public CachedTag PlayerWaypoints = null;

            public CachedTag ScoreboardHud;

            [TagField(MinVersion = CacheVersion.HaloReach, Platform = CachePlatform.Original)]
            public CachedTag UberScoreboardHud;

            public CachedTag MetagameScoreboardHud;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public CachedTag SurvivalHud = null;
            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag MetagameScoreboardHud2 = null;

            public CachedTag TheaterHud;
            public CachedTag ForgeHud;
            public CachedTag HudStrings;
            public CachedTag Medals;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public List<MultiplayerMedal> MultiplayerMedals;

            [TagField(Gen = CacheGeneration.HaloOnline)]
            public CachedTag MedalHudAnimation2 = null;

            public CachedTag MedalAnimation;

            [TagField(Platform = CachePlatform.Original)]
            public CachedTag CortanaChannel; // TestBitmap0
            [TagField(Platform = CachePlatform.Original)]
            public CachedTag TestBitmap1;
            [TagField(Platform = CachePlatform.Original)]
            public CachedTag TestBitmap2;

            public CachedTag JammerDamage;
            public CachedTag JammerDamageSound;

            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
            public RealPoint2d GrenadeSchematicsOffset;

            public float GrenadeAnchorOffset; // GrenadeScematicsSpacing
            public float EquipmentVerticalOffset;
            public float EquipmentVerticalOffsetDual;
            public float EquipmentVerticalOffsetNone;
            public float EquipmentHorizontalSize;
            public float ScoreboardSpacingSize;

            public float WaypointMinDistanceScale;
            public float WaypointMaxDistanceScale;

            [TagField(Gen = CacheGeneration.HaloOnline)]
            public float WaypointScale;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ChudDamageTrackerStruct Shielded;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public ChudDamageTrackerStruct Unshielded;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ChudScriptedObjectPriorityDefinition> ScriptedObjectPriorityPriorities;

            public enum ChudSkinType : int
            {
                Default,
                Dervish,
                Monitor,
                MpFfa,
                MpRedTeam,
                MpBlueTeam
            }

            [Flags]
            public enum DirectionalDamageFlagsValue : sbyte
            {
                ScreenSpace = 1 << 0,
                TopDown = 1 << 1,
                Halo3StyleClampedAngles = 1 << 2,
                FastForward = 1 << 3,
            }

            [TagStructure(Size = 0x4C)]
            public class ChudDamageTrackerStruct : TagStructure
            {
                public float RecentDamageFalloffTime;
                public float FadeStart;
                public float FadeStop;
                public RealRgbColor FadeColor;
                public float MinorThreshold;
                public float MajorThreshold;
                public float CriticalThreshold;
                public TagFunction Health;
                public TagFunction RecentDamage;
            }

            [TagStructure(Size = 0x2C)]
            public class ChudScriptedObjectPriorityDefinition : TagStructure
            {
                public StringId Text;
                public StringId DescriptionText;
                public sbyte OnscreenSequenceIndex;
                public sbyte OffscreenSequenceIndex;
                [TagField(Length = 2, Flags = TagTool.Tags.TagFieldFlags.Padding)]
                public byte[] Kjceasf;
                public RealArgbColor PrimaryColor;
                public RealArgbColor SecondaryColor;
            }

            [TagStructure(Size = 0x60, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
            [TagStructure(Size = 0x130, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
            [TagStructure(Size = 0xE8, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
            [TagStructure(Size = 0x60, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
            [TagStructure(Size = 0x110, Version = CacheVersion.Halo3ODST, Platform = CachePlatform.MCC)]
            [TagStructure(Size = 0x10C, MinVersion = CacheVersion.HaloReach)]
            public class HudAttribute : TagStructure
            {
                public ResolutionFlagValue ResolutionFlags;

                //Not present in ODST, ugly version hacks
                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                [TagField(MinVersion = CacheVersion.HaloOnlineED)]
                public Angle WarpSourceFovY; // WarpAngle
                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public float WarpAmount; // WarpAmount
                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                [TagField(MinVersion = CacheVersion.HaloOnlineED, MaxVersion = CacheVersion.HaloOnline700123)]
                public float WarpDestinationZOffset; // the Z-axis is along the camera line of sight.

                //ODST only warp fields
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointTopLeft;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointCenterLeft;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointBottomLeft;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointTopMiddle;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointCenterMiddle;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointBottomMiddle;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointTopRight;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointCenterRight;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d CurvePointBottomRight;

                //undocumented fields
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float HorizontalRoll;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VeticalBow;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float InverseHorizontalRoll;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float InverseVerticalBow;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float HorizontalRoll2;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VericalBow2;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float HorizontalTwist;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VerticalTwist;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float HorizontalTwist2;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VerticalTwist2;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VerticalScale2;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VerticalTwist3;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float HorizontalSkew;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VerticalFlip;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float InverseHorizontalSkew;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float VerticalFlip2;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public RealPoint2d HUDOffset;

                public uint VirtualWidth; // resolution
                public uint VirtualHeight; // resolution
                public RealPoint2d MotionSensorOrigin;
                public float MotionSensorRadius;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float Vehicle3dSensorRadius;

                public float BlipRadius; // MotionSensorScale ?

                [TagField(MinVersion = CacheVersion.HaloReach)] public RealPoint2d MinimapWorldUl;
                [TagField(MinVersion = CacheVersion.HaloReach)] public RealPoint2d MinimapWorldLr;
                [TagField(MinVersion = CacheVersion.HaloReach)] public RealPoint2d MinimapHudUl;
                [TagField(MinVersion = CacheVersion.HaloReach)] public RealPoint2d MinimapHudLr;

                public float GlobalSafeFrameHorizontal; // HorizontalScale
                public float GlobalSafeFrameVertical; // VerticalScale
                public float SafeFrameHorizontalDing; // HorizontalStretch
                public float SafeFrameVerticalDing; // VerticalStretch

                //these four tagrefs have no function in HO
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public CachedTag DamageBorderHealthEffect = null;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123, Platform = CachePlatform.Original)]
                public CachedTag ThirdPersonDamageBorderHealthEffect = null;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public CachedTag DamageBorderShieldEffect = null;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public CachedTag ThirdPersonDamageBorderShieldEffect = null;

                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float StateMessageScale;

                [TagField(Gen = CacheGeneration.HaloOnline)]
                public RealPoint2d StateLeftRightOffset_HO;

                //these only exist in HO
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float ScaleUnknown1; //related to state scale (alternate version?)
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float SpacingUnknown1;
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float ScaleUnknown2;
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float SpacingUnknown2;

                //From here, fields have been moved around a bit.
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
                public float NotificationOffsetX_H3;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                public float NotificationOffsetY_H3;
                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                public float StateLeftRightOffsetY_H3;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float MessageAnchorHorizontalOffset;

                public float MessageAnchorVerticalOffset;
                public float StateMessageVerticalOffset;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float BottomStateVerticalOffset;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float BottomPrimaryVerticalOffset;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float FireteamStateVerticalOffset;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public float FireteamStateHorizontalOffset;

                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public float MedalScale;
                [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
                public float MedalWidth; // medal spacing

                [TagField(MaxVersion = CacheVersion.Halo3ODST)]
                public float StateMessageScaleH3;

                [TagField(Gen = CacheGeneration.HaloOnline)]
                public RealPoint2d SurvivalMedalsOffset; //referenced by chud anchors -- must be neither campaign nor multiplayer
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float Unknown32;
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public RealPoint2d MultiplayerMedalsOffset; //referenced by chud anchors

                public float MessageScale;
                public float MessageHeight; // line spacing
                public int MessageCountDelta; //controls max number of notification lines onscreen

                [TagField(Gen = CacheGeneration.HaloOnline)]
                public RealPoint2d MessageOffset;

                //This group of 5 floats is all part of the same system
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float ScaleUnknown;
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float SpacingUnknown;
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public float NullUnknown;
                [TagField(Gen = CacheGeneration.HaloOnline)]
                public RealPoint2d UnknownOffset3; //referenced by chud anchors

                //this is present in HO, it is still used in chud anchors
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public float PromptOffsetY;
                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                public float PromptOffsetX;

                [Flags]
                public enum ResolutionFlagValue : int
                {
                    None,
                    WideFull = 1 << 0,
                    WideHalf = 1 << 1,
                    NativeFull = 1 << 2,
                    StandardFull = 1 << 3,
                    WideQuarter = 1 << 4,
                    StandardHalf = 1 << 5,
                    NativeQuarter = 1 << 6,
                    StandardQuarter = 1 << 7
                }
            }

            [TagStructure(Size = 0x28, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
            [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.MCC)]
            [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline449175)]
            [TagStructure(Size = 0x18, MinVersion = CacheVersion.HaloOnline498295)]
            public class HudSound : TagStructure
            {
                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public CachedTag SpartanSound;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public ChudSoundCueFlags_H3 LatchedTo_H3;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public ChudSoundCueFlags LatchedTo;

                [TagField(MinVersion = CacheVersion.HaloOnline498295, MaxVersion = CacheVersion.HaloOnline700123)]
                public uint LatchedTo2;

                public float Scale;

                [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
                [TagField(Platform = CachePlatform.MCC, MaxVersion = CacheVersion.Halo3ODST)]
                public List<BipedData> Bipeds;

                [TagField(MaxVersion = CacheVersion.Halo3Retail, Platform = CachePlatform.Original)]
                public CachedTag EliteSound;

                [Flags]
                public enum ChudSoundCueFlags : int
                {
                    None,
                    HealthRecharging = 1 << 0,
                    HealthMinorDamage = 1 << 1,
                    HealthMajorDamage = 1 << 2,
                    HealthCriticalDamage = 1 << 3,
                    HealthMinorState = 1 << 4,
                    HealthLow = 1 << 5,
                    HealthEmpty = 1 << 6,
                    ShieldRecharging = 1 << 7,
                    ShieldMinorDamage = 1 << 8,
                    ShieldMajorDamage = 1 << 9,
                    ShieldCriticalDamage = 1 << 10,
                    ShieldMinorState = 1 << 11,
                    ShieldLow = 1 << 12,
                    ShieldEmpty = 1 << 13,
                    RocketLocking = 1 << 14,
                    RocketLocked = 1 << 15,
                    TrackedTarget = 1 << 16,
                    LockedTarget = 1 << 17,
                    Vip = 1 << 18,
                    Juggernaut = 1 << 19,
                    Zombie = 1 << 20,
                    LastManStanding = 1 << 21,
                    StaminaFull = 1 << 22,
                    StaminaWarning = 1 << 23,
                    StaminaRecharge = 1 << 24,
                    Bit25 = 1 << 25,
                    Bit26 = 1 << 26,
                    Bit27 = 1 << 27,
                    TacticalPackageError = 1 << 28,
                    TacticalPackageUsed = 1 << 29,
                    GainMedal = 1 << 30,
                    WinningPoints = 1 << 31
                }

                [Flags]
                public enum ChudSoundCueFlags_H3 : int
                {
                    None,
                    ShieldRecharging = 1 << 0,
                    ShieldMinorDamage = 1 << 1,
                    ShieldLow = 1 << 2,
                    ShieldEmpty = 1 << 3,
                    HealthLow = 1 << 4,
                    HealthEmpty = 1 << 5,
                    HealthMinorDamage = 1 << 6,
                    HealthMajorDamage = 1 << 7,
                    RocketLocking = 1 << 8,
                    RocketLocked = 1 << 9,
                    TrackedTarget = 1 << 10,
                    LockedTarget = 1 << 11,
                    Vip = 1 << 12,
                    Juggernaut = 1 << 13,
                    Zombie = 1 << 14,
                    LastManStanding = 1 << 15
                }

                [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo3ODST)]
                [TagStructure(Size = 0x14, Platform = CachePlatform.MCC)]
                public class BipedData : TagStructure
                {
                    [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
                    public BipedTypeValue_ODST BipedType_ODST;

                    [TagField(MinVersion = CacheVersion.HaloOnlineED)]
                    public BipedTypeValue_HO BipedType_HO;

                    [TagField(Flags = Padding, Length = 3, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = CachePlatform.Original)]
                    public byte[] Unused = new byte[3];

                    [TagField(Platform = CachePlatform.MCC)]
                    public StringId CharacterVariantName;

                    public CachedTag Sound;

                    public enum BipedTypeValue_ODST : sbyte
                    {
                        Any = 0,
                        Rookie = 1,
                        Buck = 2,
                        Dare = 3,
                        Dutch = 4,
                        Johnson = 5,
                        Mickey = 6,
                        Romeo = 7
                    }

                    public enum BipedTypeValue_HO : int
                    {
                        Spartan = 0,
                        Elite = 1,
                        Monitor = 2
                    }
                }
            }

            [TagStructure(Size = 0x4)]
            public class MultiplayerMedal : TagStructure
            {
                [TagField(Flags = Label)]
                public StringId MedalName;
            }
        }

        [TagStructure(Size = 0x20)]
        public class HudShader : TagStructure
        {
            public CachedTag VertexShader;
            public CachedTag PixelShader;
        }

        [TagStructure(Size = 0x40)]
        public class ChudSuckProfile : TagStructure
        {
            public float EffectRadius;
            public Bounds<float> VertexNoiseBounds;
            public float VertexNoisePower;
            public Bounds<float> PixelNoiseBounds;
            public float PixelNoisePower;
            public Bounds<float> WarpRadiusBounds;
            public float WarpRadiusPower;
            public Bounds<float> WarpIntensityBounds;
            public float WarpIntensityPower;
            public Bounds<float> NoiseSharpnessBounds;
            public float NoiseSharpnessPower;
        }

        [TagStructure(Size = 0x10)]
        public class CortanaEffectConfig : TagStructure
        {
            public StringId Name;
            public List<CortanaEffectDistanceConfig> DistanceConfigs;

            [TagStructure(Size = 0xE4)]
            public class CortanaEffectDistanceConfig : TagStructure
            {
                public float Distance;
                public CortanaEffectHeadingConfigStruct Facing;
                public CortanaEffectHeadingConfigStruct Oblique;

                [TagStructure(Size = 0x70)]
                public class CortanaEffectHeadingConfigStruct : TagStructure
                {
                    public Bounds<float> NoiseAVelocity;
                    public Bounds<float> NoiseAScaleX;
                    public Bounds<float> NoiseAScaleY;
                    public Bounds<float> NoiseBVelocity;
                    public Bounds<float> NoiseBScaleX;
                    public Bounds<float> NoiseBScaleY;
                    public Bounds<float> PixelationThreshold;
                    public Bounds<float> PixelationPersistence;
                    public Bounds<float> PixelationVelocity;
                    public Bounds<float> PixelationTurbulence;
                    public Bounds<float> TranslationScaleX;
                    public Bounds<float> TranslationScaleY;
                    public CachedTag SoundReference;
                }
            }
        }

        [TagStructure(Size = 0x14)]
        public class PlayerTrainingDatum : TagStructure
        {
            [TagField(Flags = Label)]
            public StringId DisplayString; // comes out of the HUD text globals
            public short MaxDisplayTime; // how long the message can be on screen before being hidden
            public short DisplayCount; // how many times a training message will get displayed (0-3 only!)
            public short DisappearDelay; // how long a displayed but untriggered message stays up
            public short RedisplayDelay; // how long after display this message will stay hidden
            public float DisplayDelay; // how long the event can be triggered before it's displayed
            public PlayerTrainingFlags Flags;

            [TagField(Length = 2, Flags = Padding)]
            public byte[] Padding0;

            [Flags]
            public enum PlayerTrainingFlags : ushort
            {
                NotInMultiplayer = 1 << 0
            }
        }

        [TagStructure(Size = 0x48, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x4C, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.HaloOnline700123)]
        [TagStructure(Size = 0x2C, MinVersion = CacheVersion.HaloReach)]
        public class CampaignMetagameStruct : TagStructure
        {
            public CachedTag Emblems;

            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag Medals;
            [TagField(MaxVersion = CacheVersion.HaloOnline700123)]
            public CachedTag MedalAnimation;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ChudDefinition.HudWidget.PlacementDatum.ChudAnchorType MedalChudAnchor;

            [TagField(MinVersion = CacheVersion.Halo3ODST, Length = 2, Flags = Padding)]
            public byte[] PostAnchorPadding;

            public float MedalScale;
            public float MedalSpacing;
            public RealPoint2d MedalOffset;
            public float ScoreboardTopY;
            public float ScoreboardSpacing;
        }

        [TagStructure(Size = 0x68,  Gen = CacheGeneration.HaloOnline)]
        public class CameraShakeFunctions : TagStructure
        {
            public float Period; // seconds
            public TagFunction Horizontal;
            public TagFunction Vertical;
            public TagFunction Yaw;
            public TagFunction Pitch;
            public TagFunction Roll;
        }

        [Flags]
        public enum MotionSensorFlagsValue : sbyte
        {
            MotionSensorDrawFtTriangle = 1 << 0,
            PingsAppearBeyondGutter = 1 << 1,
            DoNotOrientEnemyWaypoints = 1 << 2,
            Use3dMotionSensor = 1 << 3,
        }

        [Flags]
        public enum MinimapFlagsValue : sbyte
        {
            MinimapDrawFtTriangleForMyFireteam = 1 << 0,
            MinimapDrawAlliedFtLeaders = 1 << 1,
            MinimapDrawAlliedNonLeaderPlayers = 1 << 2,
            MinimapDrawKnownEnemyPlayers = 1 << 3,
            MinimapActiveWhileDead = 1 << 4,
        }

        [TagStructure(Size = 0x1C)]
        public class ReachPingProperties : TagStructure
        {
            public float Duration;
            public RealArgbColor Color;
            public float Scale;
            public float Priority;
        }

        [TagStructure(Size = 0x18)]
        public class ReachWaypointProperties : TagStructure
        {
            public CachedTag Texture;
            public sbyte Sequence;
            public sbyte Frame;

            [TagField(Flags = Padding, Length = 2)]
            public byte[] Pad;

            public sbyte ShouldOrient;

            [TagField(Flags = Padding, Length = 3)]
            public byte[] Pad1;
        }

        [TagStructure(Size = 0x104)]
        public class ChudStateCategoryBlock : TagStructure
        {
            public int Condition;
            [TagField(Length = 256)]
            public string CategoryName;
        }
    }
}
