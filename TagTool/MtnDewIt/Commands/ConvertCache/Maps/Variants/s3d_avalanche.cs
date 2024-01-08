using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.BlamFile;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Maps
{
    public class s3d_avalanche  : MapVariantFile
    {
        public s3d_avalanche(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            MapVariantData();
        }

        public override void MapVariantData()
        {
            var tag = GetCachedTag<Scenario>($@"levels\multi\s3d_avalanche\s3d_avalanche");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            Blf blf = new Blf(Cache.Version, CachePlatform.Original)
            {
                Version = CacheVersion.HaloOnlineED,
                CachePlatform = CachePlatform.Original,
                Format = EndianFormat.LittleEndian,
                ContentFlags = BlfFileContentFlags.StartOfFile | BlfFileContentFlags.EndOfFile | BlfFileContentFlags.MapVariant | BlfFileContentFlags.Scenario | BlfFileContentFlags.MapVariantTagNames,
                AuthenticationType = BlfAuthenticationType.None,
                StartOfFile = new BlfChunkStartOfFile
                {
                    ByteOrderMarker = -2,
                    Unknown = 0,
                    InternalName = $@"",
                    Signature = new Tag("_blf"),
                    Length = 48,
                    MajorVersion = 1,
                    MinorVersion = 2,
                },
                EndOfFile = new BlfChunkEndOfFile
                {
                    AuthenticationDataSize = 0,
                    AuthenticationType = BlfAuthenticationType.None,
                    Signature = new Tag("_eof"),
                    Length = 17,
                    MajorVersion = 1,
                    MinorVersion = 2,
                },
                Scenario = new BlfScenario
                {
                    MapId = 705,
                    MapFlags = BlfScenarioFlags.Unknown0 | BlfScenarioFlags.Visible | BlfScenarioFlags.GeneratesFilm | BlfScenarioFlags.IsMultiplayer | BlfScenarioFlags.IsDlc,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Diamondback",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Hot winds blow over what should be a dead moon. A reminder of the power Forerunners once wielded. 6-16 players.",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_s3d_avalanche",
                    MapName = $@"s3d_avalanche",
                    MapIndex = 14,
                    Unknown1 = 2,
                    Unknown2 = 8,
                    GameEngineTeamCounts = new byte[11]
                    {
                        0x00, 0x02, 0x08, 0x08, 0x08, 0x08, 0x08, 0x08, 0x04, 0x02, 
                        0x08, 
                    },
                    Insertions = new BlfScenarioInsertion[9],
                    Signature = new Tag("levl"),
                    Length = 39104,
                    MajorVersion = 3,
                    MinorVersion = 1,
                },
                MapVariantTagNames = new BlfMapVariantTagNames
                {
                    Names = new TagName[256]
                    {
                        new TagName
                        {
                            Name = $@"objects\multi\spawning\respawn_point_invisible.scen",
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\wraith\wraith.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\warthog\warthog.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\levels\dlc\sidewinder\hornet_lite\hornet_lite.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\ghost\ghost.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\mongoose\mongoose.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\brute_chopper\brute_chopper.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\scorpion\scorpion.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\vehicles\banshee\banshee.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\turret\machinegun_turret\machinegun_turret.vehi",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\battle_rifle\battle_rifle.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\sniper_rifle\sniper_rifle.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\shotgun\shotgun.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\pistol\needler\needler.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\pistol\plasma_pistol\plasma_pistol.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\support_high\spartan_laser\spartan_laser.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\support_high\rocket_launcher\rocket_launcher.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\support_low\brute_shot\brute_shot.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\rifle\spike_rifle\spike_rifle.weap",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\grenade\plasma_grenade\plasma_grenade.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\equipment\powerdrain_equipment\powerdrain_equipment.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\equipment\regenerator_equipment\regenerator_equipment.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\weapons\grenade\frag_grenade\frag_grenade.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\equipment\tripmine_equipment\tripmine_equipment.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\powerups\powerup_red\powerup_red.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\powerups\powerup_blue\powerup_blue.eqip",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\slayer\slayer_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\spawning\respawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\koth\koth_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\territories\territories_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\infection\infection_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\oddball\oddball_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\vip\vip_initial_spawn_point.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\territories\territories_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\slayer\slayer_respawn_zone.scen",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_flag_spawn_point.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\ctf\ctf_flag_return_area.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\teleporter_2way\teleporter_2way.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\territories\territory_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\koth\koth_hill_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_bomb_goal_area.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\assault\assault_bomb_spawn_point.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\oddball\oddball_ball_spawn_point.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\vip\vip_destination_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\juggernaut\juggernaut_destination_static.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_l\box_l.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_m\box_m.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_xl\box_xl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_xxl\box_xxl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\box_xxxl\box_xxxl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_l\wall_l.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_m\wall_m.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_xl\wall_xl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_xxl\wall_xxl.bloc",
                        },
                        new TagName
                        {
                            Name = $@"objects\multi\wall_xxxl\wall_xxxl.bloc",
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                        new TagName
                        {
                        },
                    },
                    Signature = new Tag("tagn"),
                    Length = 65548,
                    MajorVersion = 1,
                    MinorVersion = 0,
                },
                MapVariant = new BlfMapVariant
                {
                    MapVariant = new MapVariant
                    {
                        Metadata = new ContentItemMetadata
                        {
                            Name = $@"Diamondback",
                            Description = $@"Hot winds blow over what should be a dead moon. A reminder of the power Forerunners once wielded. 6-16 players.",
                            ContentType = ContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1510964025,
                            CampaignId = -1,
                            MapId = 705,
                            CampaignDifficulty = -1,
                        },
                        Version = 12,
                        ScenarioObjectCount = 34,
                        VariantObjectCount = 358,
                        PlaceableQuotaCount = 119,
                        MapId = 705,
                        WorldBounds = new RealRectangle3d(-209.9415f, 215.6458f, -243.7742f, 327.7593f, -88.48547f, 135.9741f),
                        RuntimeEngineSubType = GameEngineSubType.All,
                        MaximumBudget = 13f,
                        SpentBudget = -5f,
                        RuntimeShowHelpers = true,
                        MapChecksum = 2204829881,
                        Objects = new VariantObjectDatum[640]
                        {
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(27.01724f, -30.90468f, -0.4390086f),
                                Forward = new RealVector3d(0.0487302f, 0.9988118f, 0.0005554095f),
                                Up = new RealVector3d(0.003943104f, -0.0007484425f, 0.999992f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(-27.02451f, -30.91261f, -0.7997601f),
                                Forward = new RealVector3d(0.0487302f, 0.9988118f, 0.0005554095f),
                                Up = new RealVector3d(0.003943104f, -0.0007484425f, 0.999992f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(-0.07900129f, 51.70804f, -3.505613f),
                                Forward = new RealVector3d(0.05792722f, -0.9983203f, -0.0009756074f),
                                Up = new RealVector3d(0.003943101f, -0.0007484438f, 0.999992f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(40.25458f, 31.921f, -0.1505716f),
                                Forward = new RealVector3d(-0.9952875f, 0.09688632f, 0.003997067f),
                                Up = new RealVector3d(0.003943103f, -0.0007484445f, 0.999992f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(-37.98057f, 35.4383f, 0.01823027f),
                                Forward = new RealVector3d(0.9887834f, 0.1493084f, -0.003787158f),
                                Up = new RealVector3d(0.003943105f, -0.0007484455f, 0.999992f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 60,
                                Position = new RealPoint3d(-38.47941f, -25.195f, -4.650977f),
                                Forward = new RealVector3d(0.733869f, 0.6785434f, -0.03185971f),
                                Up = new RealVector3d(0.03181414f, 0.01251752f, 0.9994154f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.HeavyLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 60,
                                Position = new RealPoint3d(37.72873f, -25.4412f, -4.607501f),
                                Forward = new RealVector3d(-0.459982f, 0.8870994f, -0.03835542f),
                                Up = new RealVector3d(0.1177288f, 0.1037464f, 0.9876116f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.HeavyLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-19.56114f, -29.95322f, -4.397287f),
                                Forward = new RealVector3d(0.008146355f, 0.9999006f, -0.01150863f),
                                Up = new RealVector3d(-0.002936381f, 0.01153288f, 0.9999292f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(19.45554f, -30.1929f, -4.414864f),
                                Forward = new RealVector3d(0.03341321f, 0.9992458f, -0.01978278f),
                                Up = new RealVector3d(-0.0009273441f, 0.01982482f, 0.9998031f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(25.1796f, -20.67526f, -3.969796f),
                                Forward = new RealVector3d(-0.03837794f, 0.9950697f, 0.09145124f),
                                Up = new RealVector3d(0.02715148f, -0.09044646f, 0.9955311f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.FlyingVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(34.58663f, -30.02337f, -4.37758f),
                                Forward = new RealVector3d(-0.02792347f, 0.9995611f, -0.009889293f),
                                Up = new RealVector3d(0.0040109f, 0.01000511f, 0.9999419f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(-27.13201f, -25.40025f, -4.584851f),
                                Forward = new RealVector3d(-0.02766822f, 0.9986397f, -0.04419526f),
                                Up = new RealVector3d(-0.01169284f, 0.04388583f, 0.9989681f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.FlyingVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-34.54545f, -29.71296f, -4.429476f),
                                Forward = new RealVector3d(-0.01383808f, 0.9996982f, -0.02030036f),
                                Up = new RealVector3d(-0.00650348f, 0.02021188f, 0.9997746f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(2.009876f, 34.51999f, -2.795942f),
                                Forward = new RealVector3d(-0.00972025f, 0.9964498f, 0.0836255f),
                                Up = new RealVector3d(0.01184026f, -0.08350889f, 0.9964367f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(-23.9817f, -27.35096f, -4.485111f),
                                Forward = new RealVector3d(-0.05990714f, 0.9925662f, -0.1059405f),
                                Up = new RealVector3d(0.05591143f, 0.109301f, 0.992435f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(23.07937f, -27.65673f, -4.443757f),
                                Forward = new RealVector3d(0.02909899f, 0.9851692f, -0.1690999f),
                                Up = new RealVector3d(-0.0944746f, 0.1711249f, 0.9807094f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(30.66748f, -26.95044f, -4.357893f),
                                Forward = new RealVector3d(0.008700009f, 0.9990345f, 0.04306391f),
                                Up = new RealVector3d(-0.05792355f, -0.04248974f, 0.9974164f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(19.4874f, -28.4366f, -4.455484f),
                                Forward = new RealVector3d(-0.01171696f, 0.9897047f, 0.142644f),
                                Up = new RealVector3d(0.001588717f, -0.1426352f, 0.989774f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 66,
                                Position = new RealPoint3d(-31.52499f, -25.8553f, -4.641537f),
                                Forward = new RealVector3d(0.70968f, 0.7036305f, -0.03547217f),
                                Up = new RealVector3d(-0.02166266f, 0.07211883f, 0.9971607f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 90,
                                    Type = MultiplayerObjectType.HeavyLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 67,
                                Position = new RealPoint3d(27.16354f, -24.01723f, -4.315884f),
                                Forward = new RealVector3d(-0.002265384f, 0.863579f, 0.5042085f),
                                Up = new RealVector3d(-0.08308186f, -0.5026292f, 0.8605007f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 80,
                                    Type = MultiplayerObjectType.FlyingVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(34.69494f, -28.11301f, -4.469924f),
                                Forward = new RealVector3d(0.03295473f, 0.9871297f, 0.1564896f),
                                Up = new RealVector3d(0.04284913f, -0.1578261f, 0.9865367f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 68,
                                Position = new RealPoint3d(40.10308f, 29.29163f, -0.3517018f),
                                Forward = new RealVector3d(-0.9958054f, -0.05134479f, -0.07573236f),
                                Up = new RealVector3d(-0.07563189f, -0.003899667f, 0.9971282f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 200,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 68,
                                Position = new RealPoint3d(-36.7005f, 33.40078f, 0.001284396f),
                                Forward = new RealVector3d(0.9947829f, -0.09601366f, -0.0344726f),
                                Up = new RealVector3d(0.03431315f, -0.003311808f, 0.9994056f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 200,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(-22.91996f, -27.38673f, -4.50994f),
                                Forward = new RealVector3d(-0.05663962f, 0.9936102f, -0.09762578f),
                                Up = new RealVector3d(0.005179045f, 0.09807383f, 0.9951656f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 20,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(-28.31117f, 16.70894f, -3.946797f),
                                Forward = new RealVector3d(0.07905439f, 0.9451777f, 0.3168432f),
                                Up = new RealVector3d(-0.03667049f, -0.3148655f, 0.9484277f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(38.37484f, 22.30213f, -4.44312f),
                                Forward = new RealVector3d(-0.7988425f, 0.5774866f, 0.1684043f),
                                Up = new RealVector3d(0.08953587f, -0.162688f, 0.9826067f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-22.4429f, -38.6849f, -2.06647f),
                                Forward = new RealVector3d(0.3970844f, 0.1313958f, 0.9083276f),
                                Up = new RealVector3d(0.2329498f, -0.9717172f, 0.03872924f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 70,
                                Position = new RealPoint3d(8.276392f, 0.8543354f, 0.4221151f),
                                Forward = new RealVector3d(-0.2781305f, 0.5535138f, 0.785026f),
                                Up = new RealVector3d(-0.9392605f, -0.3278096f, -0.1016397f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 120,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 71,
                                Position = new RealPoint3d(0.004037878f, -4.418032f, 0.12696f),
                                Forward = new RealVector3d(-0.0411979f, -0.5528199f, 0.8322817f),
                                Up = new RealVector3d(-0.9977589f, 0.06671875f, -0.00507294f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 80,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(25.06536f, -37.6708f, -2.263445f),
                                Forward = new RealVector3d(-0.2689126f, 0.3746648f, 0.8873062f),
                                Up = new RealVector3d(0.6446834f, 0.7544587f, -0.1231882f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 72,
                                Position = new RealPoint3d(26.17134f, -29.5739f, -4.270855f),
                                Forward = new RealVector3d(0.999943f, -0.01021144f, -0.003125341f),
                                Up = new RealVector3d(0.01012959f, 0.9996319f, -0.02516833f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 72,
                                Position = new RealPoint3d(-26.14854f, -29.50937f, -4.355709f),
                                Forward = new RealVector3d(-0.9989175f, -0.02278409f, -0.04055745f),
                                Up = new RealVector3d(0.01816536f, -0.9936753f, 0.1108129f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-23.01893f, -30.66724f, -4.403284f),
                                Forward = new RealVector3d(0.09748982f, -0.9745126f, 0.2020418f),
                                Up = new RealVector3d(0.9952289f, 0.09466384f, -0.02362671f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 73,
                                Position = new RealPoint3d(-5.076882f, -4.902681f, 0.007984653f),
                                Forward = new RealVector3d(0.9675516f, -0.2438809f, 0.06607502f),
                                Up = new RealVector3d(0.2400534f, 0.9688511f, 0.06084361f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 74,
                                Position = new RealPoint3d(5.977881f, 24.12798f, -2.19718f),
                                Forward = new RealVector3d(0.7666322f, -0.2910591f, 0.5723283f),
                                Up = new RealVector3d(0.1196016f, 0.9404889f, 0.3180821f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 200,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 70,
                                Position = new RealPoint3d(-6.920904f, 0.8646735f, 0.5190104f),
                                Forward = new RealVector3d(0.491146f, 0.5364611f, 0.6862836f),
                                Up = new RealVector3d(-0.8379887f, 0.5060714f, 0.2041243f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 120,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(22.98083f, -31.27487f, -4.354418f),
                                Forward = new RealVector3d(0.008202509f, -0.6152913f, 0.7882571f),
                                Up = new RealVector3d(0.999828f, 0.01815724f, 0.003768942f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-25.25584f, -37.40952f, -2.553552f),
                                Forward = new RealVector3d(0.5604194f, 0.3573417f, 0.7471526f),
                                Up = new RealVector3d(-0.4306912f, 0.8962972f, -0.1056232f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-28.79776f, -37.40658f, -2.55599f),
                                Forward = new RealVector3d(-0.4740915f, 0.150333f, 0.8675467f),
                                Up = new RealVector3d(-0.4749685f, -0.8733227f, -0.1082239f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(31.55062f, -38.63727f, -3.068026f),
                                Forward = new RealVector3d(0.3086157f, 0.002202879f, 0.9511843f),
                                Up = new RealVector3d(-0.06141538f, -0.9978646f, 0.02223746f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-30.96223f, 28.43565f, -0.01403957f),
                                Forward = new RealVector3d(0.5314433f, -0.7169082f, 0.4512324f),
                                Up = new RealVector3d(-0.8311558f, -0.5441509f, 0.1143667f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-29.9454f, 34.30077f, -4.158601f),
                                Forward = new RealVector3d(0.3804739f, -0.09157229f, 0.9202468f),
                                Up = new RealVector3d(-0.2825837f, -0.9590038f, 0.02140462f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(1.119858f, 25.11111f, -2.294688f),
                                Forward = new RealVector3d(0.1647332f, -0.755801f, 0.6337411f),
                                Up = new RealVector3d(-0.9803079f, -0.05451852f, 0.1898001f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(37.28707f, 38.9034f, -2.175779f),
                                Forward = new RealVector3d(0.2619698f, 0.8459471f, 0.4644839f),
                                Up = new RealVector3d(-0.7989187f, -0.07989882f, 0.5961083f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 73,
                                Position = new RealPoint3d(4.880101f, -4.820794f, 0.111356f),
                                Forward = new RealVector3d(0.9369358f, -0.2510912f, -0.2431143f),
                                Up = new RealVector3d(0.2394779f, 0.9678673f, -0.07670263f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 75,
                                Position = new RealPoint3d(-39.10277f, 34.53436f, 0.1262163f),
                                Forward = new RealVector3d(-0.3355929f, 0.9418943f, 0.01457764f),
                                Up = new RealVector3d(0.9363828f, 0.3352378f, -0.103937f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 75,
                                Position = new RealPoint3d(41.63112f, 32.16238f, 0.1196577f),
                                Forward = new RealVector3d(-0.3579627f, 0.9335824f, 0.01693446f),
                                Up = new RealVector3d(-0.9329676f, -0.3568737f, -0.04703846f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 60,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(28.85254f, -37.48748f, -2.571515f),
                                Forward = new RealVector3d(0.5286542f, 0.285737f, 0.7992991f),
                                Up = new RealVector3d(-0.7553187f, 0.5880182f, 0.2893583f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 76,
                                Position = new RealPoint3d(21.29645f, 24.49136f, -3.247449f),
                                Forward = new RealVector3d(-0.552079f, -0.7867087f, 0.2762212f),
                                Up = new RealVector3d(-0.8284444f, 0.5550224f, -0.07503351f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 2,
                                    SpawnTime = 50,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 76,
                                Position = new RealPoint3d(-19.50322f, 24.7441f, -3.405551f),
                                Forward = new RealVector3d(0.3196604f, -0.8710037f, 0.3730546f),
                                Up = new RealVector3d(0.9242325f, 0.3733901f, 0.07983729f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 2,
                                    SpawnTime = 50,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(41.17431f, 27.26849f, -0.3046173f),
                                Forward = new RealVector3d(-0.5927546f, 0.3384823f, 0.7308021f),
                                Up = new RealVector3d(-0.5093004f, -0.8604658f, -0.01455617f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-36.88774f, 36.08512f, -0.01425871f),
                                Forward = new RealVector3d(0.6765507f, -0.7362618f, 0.01405809f),
                                Up = new RealVector3d(0.7347242f, 0.673606f, -0.08022007f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 77,
                                Position = new RealPoint3d(5.004705f, -6.277762f, 0.1558854f),
                                Forward = new RealVector3d(-0.9822305f, -0.1111516f, 0.1512237f),
                                Up = new RealVector3d(0.1600604f, -0.07537454f, 0.9842253f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 77,
                                Position = new RealPoint3d(5.000931f, -6.78814f, 0.1102201f),
                                Forward = new RealVector3d(-0.9849081f, -0.06345814f, 0.161025f),
                                Up = new RealVector3d(0.1660094f, -0.08319539f, 0.9826084f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 77,
                                Position = new RealPoint3d(-5.026361f, -6.27852f, 0.04515287f),
                                Forward = new RealVector3d(0.981254f, 0.08310398f, 0.1738798f),
                                Up = new RealVector3d(-0.1743685f, -0.001397484f, 0.9846795f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 77,
                                Position = new RealPoint3d(-5.054312f, -6.722208f, 0.0109408f),
                                Forward = new RealVector3d(0.9949099f, 0.01216414f, 0.1000317f),
                                Up = new RealVector3d(-0.0994627f, -0.04075094f, 0.9942065f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(37.59101f, 25.64864f, -4.047725f),
                                Forward = new RealVector3d(0.7185943f, 0.3650033f, 0.5919415f),
                                Up = new RealVector3d(-0.6578963f, 0.6326612f, 0.4085489f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-8.183714f, -8.42774f, -0.02274342f),
                                Forward = new RealVector3d(0.6996709f, 0.3022731f, -0.6473728f),
                                Up = new RealVector3d(0.7095986f, -0.3995754f, 0.5803528f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(9.522241f, -7.596602f, 0.1398782f),
                                Forward = new RealVector3d(0.6876675f, -0.2900113f, 0.6655875f),
                                Up = new RealVector3d(0.1773179f, 0.9560804f, 0.2333853f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(-48.0043f, 2.808988f, -2.175543f),
                                Forward = new RealVector3d(0.6708958f, -0.3859993f, 0.6331694f),
                                Up = new RealVector3d(-0.5765505f, -0.8084927f, 0.1180216f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 69,
                                Position = new RealPoint3d(47.39957f, 0.2053559f, -3.287444f),
                                Forward = new RealVector3d(-0.8114751f, 0.1746728f, 0.5576715f),
                                Up = new RealVector3d(-0.1710692f, -0.9834837f, 0.05911984f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(9.561458f, -7.898171f, 0.06673319f),
                                Forward = new RealVector3d(0.2007298f, 0.1792046f, -0.9631164f),
                                Up = new RealVector3d(0.8393154f, 0.4755652f, 0.2634147f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 79,
                                Position = new RealPoint3d(25.698f, -5.20814f, -3.25659f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 80,
                                Position = new RealPoint3d(27.8719f, -29.5055f, -4.34646f),
                                Forward = new RealVector3d(0.01631144f, 0.7271346f, -0.6863012f),
                                Up = new RealVector3d(0.9997479f, -0.02245351f, -2.825321E-05f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(-31.16774f, 28.36906f, -0.03201491f),
                                Forward = new RealVector3d(-0.8671895f, -0.08949548f, -0.4898703f),
                                Up = new RealVector3d(0.246892f, -0.9315717f, -0.2668679f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(-31.46682f, 27.80741f, -0.01490515f),
                                Forward = new RealVector3d(0.615806f, -0.7213992f, 0.3168062f),
                                Up = new RealVector3d(-0.6856889f, -0.6887448f, -0.2355024f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(-26.69176f, -29.49754f, -4.360413f),
                                Forward = new RealVector3d(1f, 5.199376E-06f, 1.433903E-05f),
                                Up = new RealVector3d(1.035401E-05f, -0.9217144f, -0.3878693f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(-27.14063f, -29.50204f, -4.359284f),
                                Forward = new RealVector3d(0.9999992f, 0.0008833265f, -0.0008635375f),
                                Up = new RealVector3d(0.0004811905f, -0.9223793f, -0.3862852f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(5.877472f, 24.47393f, -2.336276f),
                                Forward = new RealVector3d(-0.0004199094f, 8.967718E-05f, -0.9999999f),
                                Up = new RealVector3d(0.9948329f, -0.1015246f, -0.0004268442f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(5.903487f, 24.04795f, -2.337499f),
                                Forward = new RealVector3d(-0.0002796951f, -9.059807E-05f, -1f),
                                Up = new RealVector3d(0.9948674f, -0.1011864f, -0.0002690923f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 82,
                                Position = new RealPoint3d(1.94688f, 30.4704f, -2.35202f),
                                Forward = new RealVector3d(-0.1094034f, 0.9912521f, 0.07382512f),
                                Up = new RealVector3d(-0.07880168f, -0.08268646f, 0.9934552f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 80,
                                Position = new RealPoint3d(-27.7008f, -29.49f, -4.344f),
                                Forward = new RealVector3d(0.007384174f, 0.7037572f, -0.7104022f),
                                Up = new RealVector3d(0.9999352f, -0.01135091f, -0.0008510493f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 79,
                                Position = new RealPoint3d(-25.9436f, -5.90503f, -2.92302f),
                                Forward = new RealVector3d(-0.252717f, 0.7512173f, -0.6097595f),
                                Up = new RealVector3d(0.5530092f, 0.6292782f, 0.5460675f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(-29.51133f, 18.5613f, -2.865666f),
                                Forward = new RealVector3d(0.3088496f, 0.5103896f, -0.8025674f),
                                Up = new RealVector3d(0.9497855f, -0.1209743f, 0.28857f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(-29.84211f, 17.90141f, -2.948008f),
                                Forward = new RealVector3d(0.2770042f, 0.4466473f, -0.8507496f),
                                Up = new RealVector3d(0.9588593f, -0.07126282f, 0.2747915f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 83,
                                Position = new RealPoint3d(47.3147f, 28.6852f, 0.121396f),
                                Forward = new RealVector3d(0.09930249f, 0.7645304f, -0.6368927f),
                                Up = new RealVector3d(0.9912621f, -0.1318545f, -0.003724247f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 83,
                                Position = new RealPoint3d(-45.5941f, 28.7365f, 0.196559f),
                                Forward = new RealVector3d(-0.2062273f, 0.491781f, 0.8459442f),
                                Up = new RealVector3d(0.9087414f, 0.4168414f, -0.02079026f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(36.77213f, 39.19352f, -2.329753f),
                                Forward = new RealVector3d(-0.710198f, 0.6559504f, -0.2556321f),
                                Up = new RealVector3d(0.2419201f, 0.5683921f, 0.7863873f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(37.04861f, 39.24334f, -2.314851f),
                                Forward = new RealVector3d(-0.3354953f, -0.4138263f, -0.8462805f),
                                Up = new RealVector3d(0.7462938f, -0.664971f, 0.02930994f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(26.93426f, -29.56079f, -4.35154f),
                                Forward = new RealVector3d(0.01584483f, -0.0001199878f, -0.9998745f),
                                Up = new RealVector3d(-0.3843253f, -0.9231784f, -0.005979549f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 81,
                                Position = new RealPoint3d(27.3502f, -29.54019f, -4.351545f),
                                Forward = new RealVector3d(0.01580465f, -0.0001395357f, -0.9998751f),
                                Up = new RealVector3d(-0.38267f, -0.9238662f, -0.005919793f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(9.516903f, -7.208733f, 0.07903853f),
                                Forward = new RealVector3d(0.09377655f, 0.09818143f, -0.9907403f),
                                Up = new RealVector3d(0.04415349f, -0.9945565f, -0.09438036f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(1.440393f, 25.77362f, -2.389241f),
                                Forward = new RealVector3d(0.06541502f, -0.001716808f, -0.9978566f),
                                Up = new RealVector3d(0.3272889f, -0.9446424f, 0.02308085f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(0.6996431f, 25.82395f, -2.403143f),
                                Forward = new RealVector3d(0.03561526f, -0.1295767f, -0.9909296f),
                                Up = new RealVector3d(0.3257722f, -0.9358914f, 0.1340885f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(41.27456f, 27.51596f, -0.3601411f),
                                Forward = new RealVector3d(0.08292356f, 0.1221051f, -0.9890471f),
                                Up = new RealVector3d(0.3284849f, -0.940349f, -0.0885522f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(41.05552f, 26.81586f, -0.4127287f),
                                Forward = new RealVector3d(0.3694916f, 0.2437f, -0.8967086f),
                                Up = new RealVector3d(0.3591997f, -0.927443f, -0.1040434f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(-36.94875f, 35.20066f, 0.03522134f),
                                Forward = new RealVector3d(-0.04930053f, -0.002838296f, -0.99878f),
                                Up = new RealVector3d(0.9292147f, 0.366551f, -0.04690839f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(-36.81838f, 34.47395f, 0.04074109f),
                                Forward = new RealVector3d(-0.03550585f, 0.009864139f, -0.9993207f),
                                Up = new RealVector3d(0.9294916f, 0.3676701f, -0.02939561f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 83,
                                Position = new RealPoint3d(22.4952f, 23.4578f, -3.02947f),
                                Forward = new RealVector3d(0.7076926f, 0.5005686f, 0.4986004f),
                                Up = new RealVector3d(0.4697551f, -0.8605016f, 0.1971475f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 83,
                                Position = new RealPoint3d(-19.7649f, 24.0526f, -3.30289f),
                                Forward = new RealVector3d(-0.7121157f, 0.578353f, 0.3979939f),
                                Up = new RealVector3d(0.6282523f, 0.777983f, -0.006433564f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 45,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 84,
                                Position = new RealPoint3d(-8.366668f, -12.63723f, 0.4855444f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 84,
                                Position = new RealPoint3d(8.557924f, -12.5568f, 0.2997453f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 85,
                                Position = new RealPoint3d(20.38978f, 24.00144f, -2.743842f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 85,
                                Position = new RealPoint3d(-18.46563f, 24.49717f, -2.727619f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = MultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(-48.48128f, 2.099025f, -2.211444f),
                                Forward = new RealVector3d(-0.1321414f, 0.1187844f, -0.9840879f),
                                Up = new RealVector3d(0.9244345f, 0.3730465f, -0.07910267f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(-48.42231f, 2.624261f, -2.209201f),
                                Forward = new RealVector3d(-0.1398052f, -0.3867067f, -0.911544f),
                                Up = new RealVector3d(0.9132118f, 0.3054945f, -0.2696617f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(47.75744f, -0.304684f, -3.320866f),
                                Forward = new RealVector3d(0.04815243f, 0.04559056f, -0.997799f),
                                Up = new RealVector3d(0.7039422f, 0.7071578f, 0.06628214f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(47.94043f, 0.4032126f, -3.323478f),
                                Forward = new RealVector3d(0.07109065f, -0.05467942f, -0.99597f),
                                Up = new RealVector3d(0.757188f, 0.6529434f, 0.01819976f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 78,
                                Position = new RealPoint3d(47.94043f, 0.4032126f, -3.323478f),
                                Forward = new RealVector3d(0.07109065f, -0.05467942f, -0.99597f),
                                Up = new RealVector3d(0.757188f, 0.6529434f, 0.01819976f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = MultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 86,
                                Position = new RealPoint3d(-26.9661f, -40.4861f, -2.65547f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 86,
                                Position = new RealPoint3d(26.96206f, -40.47952f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-24.97474f, -39.98934f, -2.601237f),
                                Forward = new RealVector3d(-0.2706118f, 0.9592219f, -0.08162516f),
                                Up = new RealVector3d(-0.2889963f, -6.627317E-05f, 0.9573302f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-25.81376f, -40.64666f, -2.655469f),
                                Forward = new RealVector3d(-0.101662f, 0.994819f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-28.31933f, -40.63731f, -2.65547f),
                                Forward = new RealVector3d(0.05343081f, 0.9985716f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-28.06549f, -34.97546f, -3.764671f),
                                Forward = new RealVector3d(0.2221626f, 0.8568311f, -0.4652786f),
                                Up = new RealVector3d(0.001665733f, 0.4768698f, 0.8789724f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-25.82944f, -34.86954f, -3.824961f),
                                Forward = new RealVector3d(-0.2777754f, 0.8444661f, -0.4579494f),
                                Up = new RealVector3d(-2.937566E-06f, 0.4767091f, 0.8790611f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(28.16014f, -38.59515f, -2.6599f),
                                Forward = new RealVector3d(0.02102061f, 0.999779f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(25.86808f, -40.70298f, -2.655475f),
                                Forward = new RealVector3d(0.1260163f, 0.9920282f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 88,
                                Position = new RealPoint3d(26.96362f, -40.47754f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 89,
                                Position = new RealPoint3d(27.03031f, -33.43999f, -4.399975f),
                                Forward = new RealVector3d(0.05988846f, 0.9982051f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 30f,
                                        BoxLength = 0f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 89,
                                Position = new RealPoint3d(-27.03195f, -33.24467f, -4.399754f),
                                Forward = new RealVector3d(0.05988846f, 0.9982051f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 30f,
                                        BoxLength = 0f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 88,
                                Position = new RealPoint3d(-26.97003f, -40.48484f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(33.30695f, -30.67205f, -4.435648f),
                                Forward = new RealVector3d(0.05573137f, 0.9984163f, 0.007671603f),
                                Up = new RealVector3d(-0.02362382f, -0.006362795f, 0.9997007f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(18.26797f, -30.98457f, -4.448089f),
                                Forward = new RealVector3d(0.2037517f, 0.9767507f, -0.06665865f),
                                Up = new RealVector3d(0.005699595f, 0.06690235f, 0.9977432f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(25.89465f, -34.98f, -3.764743f),
                                Forward = new RealVector3d(0.2809232f, 0.843662f, -0.4575114f),
                                Up = new RealVector3d(-2.937566E-06f, 0.4767091f, 0.8790611f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(28.06247f, -35.02072f, -3.740497f),
                                Forward = new RealVector3d(-0.134535f, 0.8715256f, -0.4715331f),
                                Up = new RealVector3d(0.00247071f, 0.4761528f, 0.8793591f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(27.78711f, -31.00308f, -4.399765f),
                                Forward = new RealVector3d(0.5527292f, 0.8333609f, -1.404825E-07f),
                                Up = new RealVector3d(6.597941E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(20.66339f, -30.77537f, -4.429799f),
                                Forward = new RealVector3d(-4.370565E-08f, 1f, 7.08482E-10f),
                                Up = new RealVector3d(0.01620818f, 0f, 0.9998686f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(28.21625f, -40.65887f, -2.655463f),
                                Forward = new RealVector3d(-0.1533432f, 0.988173f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(11.52802f, -13.40272f, -0.1681718f),
                                Forward = new RealVector3d(-0.462709f, 0.8864986f, -0.004546698f),
                                Up = new RealVector3d(0.2077256f, 0.1134057f, 0.9715911f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(12.07469f, -7.479638f, 0.1915232f),
                                Forward = new RealVector3d(-0.853157f, 0.5167325f, -0.07148756f),
                                Up = new RealVector3d(-0.09342672f, -0.01653195f, 0.9954889f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(5.274154f, -10.89383f, 0.2340198f),
                                Forward = new RealVector3d(0.424816f, 0.7374554f, -0.5250627f),
                                Up = new RealVector3d(0.1890669f, 0.4949356f, 0.8481112f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(10.81131f, -12.20136f, -0.1351226f),
                                Forward = new RealVector3d(0.6100425f, 0.7845632f, -0.1109446f),
                                Up = new RealVector3d(0.0794498f, 0.07874511f, 0.9937238f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(16.40018f, -17.28045f, -4.330933f),
                                Forward = new RealVector3d(0.5784087f, 0.8051453f, -0.1310899f),
                                Up = new RealVector3d(0.1367797f, 0.06270037f, 0.9886152f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(16.61239f, -8.729441f, -3.868198f),
                                Forward = new RealVector3d(0.9436837f, -0.08358964f, -0.3201153f),
                                Up = new RealVector3d(0.304169f, -0.161459f, 0.9388356f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(12.45224f, -18.96175f, -0.9058257f),
                                Forward = new RealVector3d(0.1506812f, 0.9843409f, -0.09147795f),
                                Up = new RealVector3d(0.4552311f, 0.01305037f, 0.8902777f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-26.27397f, -30.83647f, -4.367512f),
                                Forward = new RealVector3d(0.8315607f, 0.5554339f, -1.241909E-07f),
                                Up = new RealVector3d(6.597943E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-20.70015f, -30.72818f, -4.4344f),
                                Forward = new RealVector3d(-0.1043448f, 0.9942988f, -0.02195899f),
                                Up = new RealVector3d(-0.002506883f, 0.02181649f, 0.9997588f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-33.22037f, -30.73665f, -4.436229f),
                                Forward = new RealVector3d(0.216781f, 0.9762203f, -1.361474E-07f),
                                Up = new RealVector3d(6.597951E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-35.67432f, -31.01824f, -4.4269f),
                                Forward = new RealVector3d(0.1607481f, 0.98582f, -0.04815497f),
                                Up = new RealVector3d(0.0272294f, 0.04434142f, 0.9986452f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-6.928801f, -11.66227f, 0.2668663f),
                                Forward = new RealVector3d(-0.01202528f, 0.9704676f, -0.2409316f),
                                Up = new RealVector3d(-0.1824177f, 0.2347764f, 0.9547794f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-5.309232f, -0.644662f, 0.0653199f),
                                Forward = new RealVector3d(-0.7177495f, -0.6961818f, -0.01290609f),
                                Up = new RealVector3d(0.02723103f, -0.04658603f, 0.998543f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-33.61085f, 26.22252f, -0.6072766f),
                                Forward = new RealVector3d(0.8212221f, -0.5292327f, -0.2133237f),
                                Up = new RealVector3d(-0.09958868f, -0.5010502f, 0.859669f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-46.10205f, 28.05142f, 0.1020169f),
                                Forward = new RealVector3d(0.8886939f, 0.4584838f, -0.003975841f),
                                Up = new RealVector3d(0.005801969f, -0.002574602f, 0.9999799f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-42.82497f, 25.45984f, -0.3356278f),
                                Forward = new RealVector3d(0.5243986f, 0.8434753f, -0.116428f),
                                Up = new RealVector3d(0.2773841f, -0.03995061f, 0.9599281f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-42.28947f, 31.15409f, -0.09264547f),
                                Forward = new RealVector3d(0.9955108f, 0.04923918f, -0.08083294f),
                                Up = new RealVector3d(0.07866155f, 0.0445489f, 0.9959055f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-43.26335f, 40.1657f, 0.2554539f),
                                Forward = new RealVector3d(0.7590095f, -0.6333872f, -0.1507492f),
                                Up = new RealVector3d(-0.04135125f, -0.277966f, 0.9597005f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-41.5602f, 31.82607f, 0.0226642f),
                                Forward = new RealVector3d(0.9891857f, 0.1456915f, 0.01690092f),
                                Up = new RealVector3d(0.01567858f, -0.2196094f, 0.9754618f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-2.338035f, 36.16995f, -2.889239f),
                                Forward = new RealVector3d(0.3640847f, 0.9283695f, 0.0746493f),
                                Up = new RealVector3d(-0.04531847f, -0.06239675f, 0.997022f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 90,
                                Position = new RealPoint3d(26.96313f, -40.48671f, -2.655466f),
                                Forward = new RealVector3d(-0.05515212f, 0.9984779f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-26.97003f, -40.48484f, -2.655466f),
                                Forward = new RealVector3d(0.02443304f, 0.9997014f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 91,
                                Position = new RealPoint3d(-26.96761f, -40.49206f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 91,
                                Position = new RealPoint3d(26.96392f, -40.47388f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 92,
                                Position = new RealPoint3d(-26.96247f, -40.48119f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 92,
                                Position = new RealPoint3d(26.96139f, -40.47649f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 93,
                                Position = new RealPoint3d(-26.96405f, -40.4847f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Infection,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 93,
                                Position = new RealPoint3d(26.95908f, -40.48435f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Infection,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 94,
                                Position = new RealPoint3d(26.95718f, -40.47844f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 94,
                                Position = new RealPoint3d(-26.96823f, -40.48762f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 95,
                                Position = new RealPoint3d(-26.96823f, -40.48761f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 95,
                                Position = new RealPoint3d(26.96243f, -40.48661f, -2.655466f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-28.53553f, -39.00899f, -2.683706f),
                                Forward = new RealVector3d(0.1371238f, 0.9905539f, 6.616581E-07f),
                                Up = new RealVector3d(-6.412029E-08f, -6.590915E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 96,
                                Position = new RealPoint3d(-27.16193f, -33.07557f, -4.399753f),
                                Forward = new RealVector3d(0.02443304f, 0.9997014f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 30f,
                                        BoxLength = 0f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 96,
                                Position = new RealPoint3d(27.05268f, -33.50306f, -4.399806f),
                                Forward = new RealVector3d(0.008193954f, 0.9999664f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 30f,
                                        BoxLength = 0f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 97,
                                Position = new RealPoint3d(-27.16791f, -33.23074f, -4.399753f),
                                Forward = new RealVector3d(0.02443304f, 0.9997014f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 30f,
                                        BoxLength = 0f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 97,
                                Position = new RealPoint3d(26.96823f, -33.49089f, -4.39981f),
                                Forward = new RealVector3d(0.008193954f, 0.9999664f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 30f,
                                        BoxLength = 0f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-27.61324f, -15.16446f, -3.786956f),
                                Forward = new RealVector3d(0.02443304f, 0.9997014f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 45f,
                                        BoxLength = 50f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 98,
                                Position = new RealPoint3d(28.08756f, -18.39169f, -4.581054f),
                                Forward = new RealVector3d(0.02443304f, 0.9997014f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 45f,
                                        BoxLength = 50f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(43.83926f, 32.00377f, 0.07142241f),
                                Forward = new RealVector3d(-0.9593506f, 0.2811986f, -0.02395251f),
                                Up = new RealVector3d(0.004496158f, 0.1000907f, 0.9949681f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(45.58746f, 37.61145f, 0.5678014f),
                                Forward = new RealVector3d(-0.9237112f, -0.3579093f, -0.1365963f),
                                Up = new RealVector3d(-0.09434766f, -0.1330428f, 0.9866094f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(45.91534f, 25.27036f, -0.01213469f),
                                Forward = new RealVector3d(-0.811538f, 0.5842996f, 3.330713E-07f),
                                Up = new RealVector3d(-6.412019E-08f, -6.590921E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(44.65678f, 31.04004f, 0.1143302f),
                                Forward = new RealVector3d(-0.9821762f, -0.1871203f, -0.01777318f),
                                Up = new RealVector3d(-0.00522093f, -0.06736143f, 0.997715f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(37.56905f, -30.74403f, -4.438288f),
                                Forward = new RealVector3d(-0.1447523f, 0.9894679f, -1.13947E-07f),
                                Up = new RealVector3d(6.597952E-08f, 1.248122E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-6.203956f, -11.60429f, 0.5248827f),
                                Forward = new RealVector3d(-0.1670275f, 0.9559255f, -0.2414712f),
                                Up = new RealVector3d(-0.4021183f, 0.1575694f, 0.9019273f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(5.340364f, -1.196209f, -0.03563831f),
                                Forward = new RealVector3d(0.7797928f, -0.60912f, -0.1445544f),
                                Up = new RealVector3d(0.04980488f, -0.1698113f, 0.9842172f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-18.20745f, -31.08277f, -4.473247f),
                                Forward = new RealVector3d(-0.09522133f, 0.9941398f, 0.05117479f),
                                Up = new RealVector3d(0.002195187f, -0.05119855f, 0.9986861f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-27.77868f, -30.85545f, -4.394816f),
                                Forward = new RealVector3d(-0.7899954f, 0.6131127f, -2.44006E-08f),
                                Up = new RealVector3d(6.59794E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-25.60124f, -32.64244f, -4.399759f),
                                Forward = new RealVector3d(-0.725687f, 0.688025f, -3.799352E-08f),
                                Up = new RealVector3d(6.59795E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(35.65926f, -31.05765f, -4.40416f),
                                Forward = new RealVector3d(0.05573137f, 0.9984163f, 0.007671603f),
                                Up = new RealVector3d(-0.02362382f, -0.006362795f, 0.9997007f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(26.19294f, -30.84875f, -4.381657f),
                                Forward = new RealVector3d(-0.4343031f, 0.9007668f, -8.377182E-08f),
                                Up = new RealVector3d(6.597936E-08f, 1.248124E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(25.90701f, -32.3238f, -4.399766f),
                                Forward = new RealVector3d(0.7170079f, 0.6970651f, -1.343101E-07f),
                                Up = new RealVector3d(6.597934E-08f, 1.248124E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-5.925531f, -0.1416955f, 0.1057558f),
                                Forward = new RealVector3d(-0.7209666f, -0.6913735f, -0.04700818f),
                                Up = new RealVector3d(0.05282091f, -0.1224668f, 0.991066f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(6.142136f, -0.7785446f, -0.009503867f),
                                Forward = new RealVector3d(0.6376848f, -0.7530283f, -0.1621924f),
                                Up = new RealVector3d(0.04980488f, -0.1698113f, 0.9842172f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-11.17635f, -5.652108f, 0.4405937f),
                                Forward = new RealVector3d(0.9030039f, 0.4225269f, 0.07781339f),
                                Up = new RealVector3d(-0.0616613f, -0.05178445f, 0.9967529f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(11.51489f, -17.78197f, -0.4831515f),
                                Forward = new RealVector3d(0.1691229f, 0.9849728f, -0.03501359f),
                                Up = new RealVector3d(0.4055215f, -0.03716248f, 0.9133298f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(11.91138f, -18.3542f, -0.6472705f),
                                Forward = new RealVector3d(0.1512809f, 0.9781441f, -0.142647f),
                                Up = new RealVector3d(0.4328421f, 0.06418773f, 0.8991816f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-13.7787f, -23.9217f, -3.877554f),
                                Forward = new RealVector3d(-0.2344915f, 0.9578514f, 0.1659356f),
                                Up = new RealVector3d(-0.1770145f, -0.2099134f, 0.9615624f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-13.78779f, -22.7171f, -3.624061f),
                                Forward = new RealVector3d(0.1113012f, 0.9723494f, 0.2053015f),
                                Up = new RealVector3d(-0.2220205f, -0.1770343f, 0.9588356f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(6.326512f, -11.46571f, 0.1196991f),
                                Forward = new RealVector3d(0.5688108f, 0.7978351f, -0.1997835f),
                                Up = new RealVector3d(-0.01205041f, 0.2509655f, 0.967921f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-5.39911f, -11.41605f, 0.733539f),
                                Forward = new RealVector3d(-0.1042809f, 0.9710134f, -0.2150778f),
                                Up = new RealVector3d(-0.05483435f, 0.2103144f, 0.9760948f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-29.47934f, -40.37911f, -2.935552f),
                                Forward = new RealVector3d(0.3096029f, 0.9461995f, 0.0940874f),
                                Up = new RealVector3d(-0.2898645f, -0.0003224518f, 0.9570676f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-25.72659f, -38.93696f, -2.655469f),
                                Forward = new RealVector3d(0.05343081f, 0.9985716f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(29.19387f, -40.46419f, -2.834067f),
                                Forward = new RealVector3d(-0.2839129f, 0.9549559f, 0.08632927f),
                                Up = new RealVector3d(0.289902f, -0.0003299281f, 0.9570563f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(24.84384f, -40.08994f, -2.562431f),
                                Forward = new RealVector3d(0.2561735f, 0.9635679f, -0.07688931f),
                                Up = new RealVector3d(0.2875815f, -3.066468E-05f, 0.9577562f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(25.91419f, -38.57518f, -2.655465f),
                                Forward = new RealVector3d(-0.03546035f, 0.9993711f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-11.99384f, -17.54832f, -1.751275f),
                                Forward = new RealVector3d(-0.07759992f, 0.968529f, 0.2364949f),
                                Up = new RealVector3d(-0.2562755f, -0.2486172f, 0.9340836f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 86,
                                Position = new RealPoint3d(-41.34671f, 37.12999f, 0.05763151f),
                                Forward = new RealVector3d(0.6990286f, -0.7114942f, 0.07165926f),
                                Up = new RealVector3d(-0.03369874f, 0.06732241f, 0.997162f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 86,
                                Position = new RealPoint3d(41.85168f, 35.85109f, 0.0963755f),
                                Forward = new RealVector3d(-0.7422064f, -0.6672242f, -0.06278171f),
                                Up = new RealVector3d(-0.1006218f, 0.01832923f, 0.9947559f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(43.31488f, 36.31316f, 0.1549208f),
                                Forward = new RealVector3d(-0.7671578f, -0.6393512f, -0.05195132f),
                                Up = new RealVector3d(0.08179245f, -0.1778273f, 0.9806566f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(41.75444f, 37.84073f, 0.1289437f),
                                Forward = new RealVector3d(-0.5286534f, -0.8392313f, -0.1273438f),
                                Up = new RealVector3d(-0.2406296f, 0.004300146f, 0.9706075f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(41.76671f, 34.53878f, 0.1034321f),
                                Forward = new RealVector3d(-0.8303753f, -0.5522933f, -0.07381789f),
                                Up = new RealVector3d(-0.1006218f, 0.01832923f, 0.9947559f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(40.77186f, 35.67784f, -0.1609085f),
                                Forward = new RealVector3d(-0.6525316f, -0.7455136f, -0.1356915f),
                                Up = new RealVector3d(-0.2902456f, 0.08048715f, 0.9535614f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-43.19098f, 37.76243f, -0.04437353f),
                                Forward = new RealVector3d(0.773223f, -0.6322726f, -0.04855441f),
                                Up = new RealVector3d(0.03900765f, -0.02899921f, 0.998818f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-41.47578f, 39.86075f, 0.09543484f),
                                Forward = new RealVector3d(0.5204228f, -0.8455628f, -0.1190958f),
                                Up = new RealVector3d(-0.00914774f, -0.144984f, 0.9893917f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-40.49825f, 36.77082f, 0.09580906f),
                                Forward = new RealVector3d(0.6954692f, -0.7183311f, -0.01797425f),
                                Up = new RealVector3d(0.1105085f, 0.08220766f, 0.9904695f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-41.4142f, 36.2727f, 0.02672998f),
                                Forward = new RealVector3d(0.6919954f, -0.7209346f, 0.03735916f),
                                Up = new RealVector3d(-0.241302f, -0.1822212f, 0.9531887f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 94,
                                Position = new RealPoint3d(-41.34244f, 37.12423f, 0.05439253f),
                                Forward = new RealVector3d(0.695574f, -0.7148607f, 0.0717698f),
                                Up = new RealVector3d(-0.03369874f, 0.06732241f, 0.997162f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 94,
                                Position = new RealPoint3d(41.85448f, 35.85286f, 0.08892979f),
                                Forward = new RealVector3d(-0.7098811f, -0.7018566f, -0.05887379f),
                                Up = new RealVector3d(-0.1006218f, 0.01832923f, 0.9947559f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 91,
                                Position = new RealPoint3d(41.85421f, 35.85574f, 0.08884995f),
                                Forward = new RealVector3d(-0.6541535f, -0.7545539f, -0.05226582f),
                                Up = new RealVector3d(-0.1006218f, 0.01832923f, 0.9947559f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 91,
                                Position = new RealPoint3d(-41.34637f, 37.13301f, 0.05332419f),
                                Forward = new RealVector3d(0.6309956f, -0.7723001f, 0.07346535f),
                                Up = new RealVector3d(-0.03369874f, 0.06732241f, 0.997162f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 90,
                                Position = new RealPoint3d(-41.34906f, 37.12443f, 0.05381209f),
                                Forward = new RealVector3d(0.758355f, -0.641047f, 0.1181378f),
                                Up = new RealVector3d(-0.08454691f, 0.08297268f, 0.9929589f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 90,
                                Position = new RealPoint3d(41.85441f, 35.86916f, 0.08862288f),
                                Forward = new RealVector3d(-0.7208636f, -0.6904581f, -0.06019459f),
                                Up = new RealVector3d(-0.100622f, 0.0183296f, 0.9947559f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 95,
                                Position = new RealPoint3d(41.87428f, 35.88733f, 0.0902976f),
                                Forward = new RealVector3d(-0.6216575f, -0.7817876f, -0.04847679f),
                                Up = new RealVector3d(-0.100622f, 0.0183296f, 0.9947559f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 95,
                                Position = new RealPoint3d(-41.37144f, 37.12218f, 0.05209451f),
                                Forward = new RealVector3d(0.6909662f, -0.7131212f, 0.1184225f),
                                Up = new RealVector3d(-0.08454691f, 0.08297268f, 0.9929589f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-1.179782f, -4.398078f, -0.0002131401f),
                                Forward = new RealVector3d(0.02787153f, 0.9996115f, -1.266028E-07f),
                                Up = new RealVector3d(6.597947E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-2.122198f, -4.289264f, -0.0002135107f),
                                Forward = new RealVector3d(0.05950553f, 0.998228f, -1.285173E-07f),
                                Up = new RealVector3d(6.597944E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(2.165284f, -4.473619f, -0.0002136847f),
                                Forward = new RealVector3d(-0.06609736f, 0.9978132f, -1.201783E-07f),
                                Up = new RealVector3d(6.597946E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(1.248483f, -4.412127f, -0.0002137784f),
                                Forward = new RealVector3d(-0.06609736f, 0.9978132f, -1.201783E-07f),
                                Up = new RealVector3d(6.597946E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-1.363751f, 0.6509109f, -0.000179337f),
                                Forward = new RealVector3d(0.3718967f, -0.9282741f, 9.132256E-08f),
                                Up = new RealVector3d(6.597938E-08f, 1.248124E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(1.451922f, 0.6688423f, -0.0001822117f),
                                Forward = new RealVector3d(-0.3644487f, -0.9312235f, 1.402743E-07f),
                                Up = new RealVector3d(6.597936E-08f, 1.248123E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-2.192846f, -1.428153f, -0.0002007486f),
                                Forward = new RealVector3d(0.6231616f, -0.7820931f, 5.649912E-08f),
                                Up = new RealVector3d(6.597934E-08f, 1.248124E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(2.211601f, -1.408734f, -0.0002053344f),
                                Forward = new RealVector3d(-0.6485139f, -0.7612028f, 1.377961E-07f),
                                Up = new RealVector3d(6.597934E-08f, 1.248124E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-40.96517f, 37.94258f, 0.05120213f),
                                Forward = new RealVector3d(0.6643509f, -0.7166183f, 0.2123584f),
                                Up = new RealVector3d(-0.1942237f, 0.1088385f, 0.9749007f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-42.726f, 36.60513f, -0.105757f),
                                Forward = new RealVector3d(0.8644397f, -0.4991377f, 0.06004681f),
                                Up = new RealVector3d(-0.1239817f, -0.09590566f, 0.9876389f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(42.72985f, 35.2158f, 0.07581914f),
                                Forward = new RealVector3d(-0.8725933f, -0.4813858f, 0.08275571f),
                                Up = new RealVector3d(0.1059032f, -0.02106119f, 0.9941533f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(41.02974f, 36.91692f, -0.09850697f),
                                Forward = new RealVector3d(-0.5074262f, -0.8304526f, -0.2299288f),
                                Up = new RealVector3d(-0.3176748f, -0.06775182f, 0.9457761f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-9.193415f, 55.81253f, -4.559876f),
                                Forward = new RealVector3d(0.1596139f, -0.9568207f, 0.2429352f),
                                Up = new RealVector3d(-0.217528f, 0.2059516f, 0.9540783f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(10.00967f, 55.0876f, -3.916624f),
                                Forward = new RealVector3d(0.05069904f, -0.9936674f, -0.1002731f),
                                Up = new RealVector3d(-0.08108331f, -0.1041661f, 0.9912492f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(37.21196f, 44.95923f, -3.912725f),
                                Forward = new RealVector3d(-0.802744f, -0.5955293f, -0.03077365f),
                                Up = new RealVector3d(-0.1889102f, 0.2050158f, 0.9603549f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-33.41228f, 42.90308f, -4.01961f),
                                Forward = new RealVector3d(0.9521953f, -0.2448607f, -0.1826673f),
                                Up = new RealVector3d(0.2070104f, 0.0774511f, 0.9752682f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-44.52882f, -27.58417f, -4.44634f),
                                Forward = new RealVector3d(0.3405843f, 0.940172f, -0.0088924f),
                                Up = new RealVector3d(-0.009632692f, 0.01294655f, 0.9998698f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(43.80649f, -25.28357f, -4.436679f),
                                Forward = new RealVector3d(-0.8763843f, 0.448543f, -0.1753847f),
                                Up = new RealVector3d(-0.1880686f, 0.01652092f, 0.9820169f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-24.01403f, -2.249176f, -3.783814f),
                                Forward = new RealVector3d(-0.1636771f, -0.9848364f, 0.05750759f),
                                Up = new RealVector3d(-0.02941954f, 0.06314064f, 0.9975709f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-16.63395f, 22.29176f, -2.754697f),
                                Forward = new RealVector3d(-0.4540244f, -0.8741539f, 0.1723857f),
                                Up = new RealVector3d(-0.0119269f, 0.1994222f, 0.9798411f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(-46.92974f, 10.2449f, -4.238082f),
                                Forward = new RealVector3d(0.8716472f, -0.4020025f, -0.2804016f),
                                Up = new RealVector3d(0.2962686f, -0.02360536f, 0.9548129f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(19.71234f, 22.11567f, -2.525373f),
                                Forward = new RealVector3d(0.6721432f, -0.7247262f, 0.1516425f),
                                Up = new RealVector3d(0.09008078f, 0.283325f, 0.954784f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(23.34547f, -2.922467f, -4.097869f),
                                Forward = new RealVector3d(0.250719f, -0.9128446f, 0.3222651f),
                                Up = new RealVector3d(-0.0657554f, 0.3160703f, 0.9464543f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(47.93632f, 10.10154f, -3.589007f),
                                Forward = new RealVector3d(-0.5613844f, -0.789376f, -0.2484614f),
                                Up = new RealVector3d(-0.2764871f, -0.1040769f, 0.9553653f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 87,
                                Position = new RealPoint3d(5.447065f, 22.57638f, -2.385698f),
                                Forward = new RealVector3d(-0.2942893f, 0.9557164f, 1.390675E-06f),
                                Up = new RealVector3d(3.411138E-06f, -4.047368E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 98,
                                Position = new RealPoint3d(-27.42162f, 35.0127f, -2.720344f),
                                Forward = new RealVector3d(0.02443304f, 0.9997014f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 45f,
                                        BoxLength = 50f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 98,
                                Position = new RealPoint3d(28.69021f, 31.49343f, -4.807404f),
                                Forward = new RealVector3d(0.02443304f, 0.9997014f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Slayer,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 45f,
                                        BoxLength = 50f,
                                        PositiveHeight = 8f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 99,
                                Position = new RealPoint3d(-26.999f, -31.6507f, -0.8289047f),
                                Forward = new RealVector3d(0.9999964f, -0.002696635f, -3.486499E-09f),
                                Up = new RealVector3d(2.786226E-09f, -2.596875E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 100,
                                Position = new RealPoint3d(-26.97441f, -39.50143f, -2.660436f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 100,
                                Position = new RealPoint3d(27.00456f, -39.49583f, -2.668312f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 99,
                                Position = new RealPoint3d(26.9986f, -31.6507f, -0.8293847f),
                                Forward = new RealVector3d(1f, -8.398628E-09f, -2.786228E-09f),
                                Up = new RealVector3d(2.786226E-09f, -2.596875E-07f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 101,
                                Position = new RealPoint3d(-22.9659f, -36.5353f, -2.212121f),
                                Forward = new RealVector3d(-0.01061829f, -0.9999436f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Teleporter2way,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0.25f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 101,
                                Position = new RealPoint3d(-51.13515f, 21.19733f, 0.07154457f),
                                Forward = new RealVector3d(0.7153147f, 0.6988024f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Teleporter2way,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0.25f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 101,
                                Position = new RealPoint3d(53.0553f, 21.21764f, 0.06895176f),
                                Forward = new RealVector3d(-0.7208658f, 0.6930746f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Teleporter2way,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0.25f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 101,
                                Position = new RealPoint3d(23.10906f, -36.4513f, -2.20816f),
                                Forward = new RealVector3d(0.003267358f, -0.9999946f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 30,
                                    Type = MultiplayerObjectType.Teleporter2way,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0.25f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(1.13168f, 41.1736f, -3.19863f),
                                Forward = new RealVector3d(0.9999173f, 0.01286455f, 0.0001058991f),
                                Up = new RealVector3d(-1.19157E-05f, -0.00730547f, 0.9999733f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(35.0474f, -11.2346f, -2.700046f),
                                Forward = new RealVector3d(0.9987996f, 0.01310349f, -0.04720003f),
                                Up = new RealVector3d(0.04804203f, -0.07386706f, 0.9961103f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 3f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(-0.0305791f, -3.021f, -0.02845945f),
                                Forward = new RealVector3d(0.9999173f, 0.01286494f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(-32.3306f, 28.878f, -0.06387408f),
                                Forward = new RealVector3d(0.9924406f, 0.01057511f, -0.1222699f),
                                Up = new RealVector3d(0.1219039f, 0.03020095f, 0.9920824f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(41.8261f, 30.5319f, -0.06155178f),
                                Forward = new RealVector3d(0.9950346f, 0.006150274f, 0.09933951f),
                                Up = new RealVector3d(-0.09757821f, -0.1363963f, 0.985837f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 103,
                                Position = new RealPoint3d(-0.0388613f, -1.67948f, 0.009879f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 8f,
                                        BoxLength = 6f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = -0.5f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 103,
                                Position = new RealPoint3d(1.14029f, 43.7067f, -3.28056f),
                                Forward = new RealVector3d(0.9991786f, -0.001588773f, -0.04049313f),
                                Up = new RealVector3d(0.04049313f, 0.0783186f, 0.9961057f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 103,
                                Position = new RealPoint3d(-22.8163f, 20.4292f, -3.29383f),
                                Forward = new RealVector3d(0.9906927f, 0.007903142f, 0.1358876f),
                                Up = new RealVector3d(-0.1358876f, 0.1153874f, 0.9839818f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 3f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 103,
                                Position = new RealPoint3d(31.24072f, 11.40687f, -4.817535f),
                                Forward = new RealVector3d(0.9974083f, -0.006780457f, -0.07162903f),
                                Up = new RealVector3d(0.07162903f, 0.187397f, 0.9796692f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 3f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 104,
                                Position = new RealPoint3d(27.00314f, -32.29267f, -0.7997519f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 105,
                                Position = new RealPoint3d(-26.99771f, -38.32284f, -2.655467f),
                                Forward = new RealVector3d(0.7114559f, 0.7027308f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 104,
                                Position = new RealPoint3d(-27.0113f, -32.28013f, -0.7997525f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 105,
                                Position = new RealPoint3d(26.98776f, -38.32007f, -2.655468f),
                                Forward = new RealVector3d(0.693032f, 0.7209069f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 105,
                                Position = new RealPoint3d(1.124849f, 41.17582f, -3.198645f),
                                Forward = new RealVector3d(0.9999998f, -0.0007044864f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Assault,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 106,
                                Position = new RealPoint3d(-0.04773085f, -2.403038f, 0.009269205f),
                                Forward = new RealVector3d(0.999984f, 0.005667544f, -1.382084E-05f),
                                Up = new RealVector3d(1.374658E-05f, 1.314187E-05f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 107,
                                Position = new RealPoint3d(27.68468f, -23.61028f, -4.393579f),
                                Forward = new RealVector3d(0.9991681f, -0.0153013f, 0.03780232f),
                                Up = new RealVector3d(-0.03962671f, -0.1452304f, 0.9886039f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 107,
                                Position = new RealPoint3d(-26.58341f, -24.17621f, -4.666903f),
                                Forward = new RealVector3d(0.9994698f, -0.01540638f, 0.02868654f),
                                Up = new RealVector3d(-0.0290363f, -0.02298038f, 0.9993142f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 107,
                                Position = new RealPoint3d(1.117794f, 41.16398f, -3.198741f),
                                Forward = new RealVector3d(0.999881f, -0.01542721f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 107,
                                Position = new RealPoint3d(40.71272f, 31.13239f, -0.1289683f),
                                Forward = new RealVector3d(0.9931189f, -0.01533371f, 0.1161025f),
                                Up = new RealVector3d(-0.1170721f, -0.1045266f, 0.9876074f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 107,
                                Position = new RealPoint3d(-38.59758f, 32.4273f, -0.04462295f),
                                Forward = new RealVector3d(0.9998444f, -0.0154705f, 0.008483186f),
                                Up = new RealVector3d(-0.008641673f, -0.01020655f, 0.9999106f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Vip,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 108,
                                Position = new RealPoint3d(-0.04050164f, -2.408152f, 0.009264873f),
                                Forward = new RealVector3d(0.9999074f, -0.01361104f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 108,
                                Position = new RealPoint3d(40.65335f, 30.28063f, -0.2193722f),
                                Forward = new RealVector3d(0.997646f, -0.01614352f, 0.06664583f),
                                Up = new RealVector3d(-0.06772034f, -0.07914092f, 0.9945605f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 108,
                                Position = new RealPoint3d(-38.58427f, 31.7239f, -0.04969341f),
                                Forward = new RealVector3d(0.9999074f, -0.01361104f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 108,
                                Position = new RealPoint3d(-27.30211f, -24.15744f, -4.688493f),
                                Forward = new RealVector3d(0.9994094f, -0.01397818f, 0.03139254f),
                                Up = new RealVector3d(-0.03171373f, -0.02338131f, 0.9992235f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 108,
                                Position = new RealPoint3d(28.42987f, -23.61938f, -4.338537f),
                                Forward = new RealVector3d(0.9901748f, -0.01420021f, 0.1391121f),
                                Up = new RealVector3d(-0.1393512f, -0.01752624f, 0.9900879f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(-38.45055f, -6.287983f, -4.010915f),
                                Forward = new RealVector3d(1f, -5.775609E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.3f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(35.25998f, -10.92344f, -2.690597f),
                                Forward = new RealVector3d(1f, -5.775609E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.3f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(-8.01389f, 38.55357f, -4.50008f),
                                Forward = new RealVector3d(0.987439f, 0.002886567f, 0.1579744f),
                                Up = new RealVector3d(-0.1579744f, 0.03630382f, 0.9867756f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.3f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(11.67695f, 38.0363f, -4.480881f),
                                Forward = new RealVector3d(0.9946371f, -0.0053112f, -0.1032898f),
                                Up = new RealVector3d(0.1032898f, 0.1022934f, 0.9893773f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.3f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 102,
                                Position = new RealPoint3d(-0.02981906f, -2.411809f, 0.009261759f),
                                Forward = new RealVector3d(1f, -5.775609E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Territories,
                                    Flags = VariantPlacementFlags.Symmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2.3f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 106,
                                Position = new RealPoint3d(1.131665f, 40.44944f, -3.202571f),
                                Forward = new RealVector3d(0.999984f, 0.005667544f, -1.382084E-05f),
                                Up = new RealVector3d(1.374658E-05f, 1.314187E-05f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 106,
                                Position = new RealPoint3d(40.04039f, 30.73081f, -0.2269255f),
                                Forward = new RealVector3d(0.9963832f, 0.002244063f, 0.08494361f),
                                Up = new RealVector3d(-0.08456784f, -0.07134488f, 0.9938602f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 106,
                                Position = new RealPoint3d(-39.23549f, 31.99108f, -0.03136889f),
                                Forward = new RealVector3d(0.9956096f, 0.005934663f, -0.09341484f),
                                Up = new RealVector3d(0.09360304f, -0.06154517f, 0.9937055f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 5,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 106,
                                Position = new RealPoint3d(34.8667f, -10.38561f, -2.686553f),
                                Forward = new RealVector3d(0.9991478f, 0.006687543f, -0.04072864f),
                                Up = new RealVector3d(0.04043412f, 0.03946311f, 0.9984027f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 106,
                                Position = new RealPoint3d(-34.08335f, -17.0653f, -2.521078f),
                                Forward = new RealVector3d(0.9977275f, 0.005490822f, 0.06715381f),
                                Up = new RealVector3d(-0.06644872f, -0.08476687f, 0.9941826f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.Oddball,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.HoldSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 109,
                                Position = new RealPoint3d(0.03524584f, -33.04482f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 109,
                                Position = new RealPoint3d(-0.3980845f, -33.27321f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 110,
                                Position = new RealPoint3d(0.3409766f, -32.21721f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 110,
                                Position = new RealPoint3d(-0.1501986f, -32.34266f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 111,
                                Position = new RealPoint3d(0.2854908f, -31.2258f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 111,
                                Position = new RealPoint3d(-0.1224979f, -31.27435f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 112,
                                Position = new RealPoint3d(0.3011741f, -30.58607f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 112,
                                Position = new RealPoint3d(-0.1452421f, -30.54926f, 28.73521f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 113,
                                Position = new RealPoint3d(0.3302135f, -30.00074f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 113,
                                Position = new RealPoint3d(-0.1360432f, -29.99482f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 114,
                                Position = new RealPoint3d(0.3476015f, -29.6142f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 114,
                                Position = new RealPoint3d(-0.1446688f, -29.53535f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 115,
                                Position = new RealPoint3d(0.3519284f, -28.94254f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 115,
                                Position = new RealPoint3d(-0.1127202f, -28.95207f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 116,
                                Position = new RealPoint3d(0.3582833f, -28.45925f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 116,
                                Position = new RealPoint3d(-0.1429941f, -28.3778f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 117,
                                Position = new RealPoint3d(0.3218046f, -27.75893f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 117,
                                Position = new RealPoint3d(-0.168669f, -27.71283f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 118,
                                Position = new RealPoint3d(0.359273f, -27.21827f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                                Flags = VariantObjectPlacementFlags.OccupiedSlot | VariantObjectPlacementFlags.Edited | VariantObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 118,
                                Position = new RealPoint3d(-0.1778327f, -27.12345f, 28.7352f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = GameEngineSubTypeFlags.CaptureTheFlag | GameEngineSubTypeFlags.Slayer | GameEngineSubTypeFlags.Oddball | GameEngineSubTypeFlags.KingOfTheHill | GameEngineSubTypeFlags.Juggernaut | GameEngineSubTypeFlags.Territories | GameEngineSubTypeFlags.Assault | GameEngineSubTypeFlags.Vip | GameEngineSubTypeFlags.Infection | GameEngineSubTypeFlags.TargetTraining | GameEngineSubTypeFlags.All,
                                    Flags = VariantPlacementFlags.Symmetric | VariantPlacementFlags.Asymmetric,
                                    Team = MultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = MultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = MultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                            new VariantObjectDatum
                            {
                            },
                        },
                        ObjectTypeStartIndex = new short[16]
                        {
                            -1, 0, 0, 0, -1, -1, -1, 0, -1, -1, 
                            -1, 26, -1, -1, -1, 0, 
                        },
                        Quotas = new VariantObjectQuota[256]
                        {
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11942,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5401,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5407,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5531,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5399,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5526,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5400,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5408,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5402,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 10316,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5500,
                                MinimumCount = 0,
                                MaximumCount = 24,
                                PlacedOnMap = 19,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5553,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 6725,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5368,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5367,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5554,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5555,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5375,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5376,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 431,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 17,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5473,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5478,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 428,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5479,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 5476,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11947,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11946,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11922,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11920,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 96,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11921,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11923,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11930,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11932,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11928,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11943,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11933,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11934,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11927,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11929,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11924,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11971,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11972,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11970,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11978,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 10,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11976,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11974,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11973,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11977,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11979,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 11975,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12009,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12010,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12011,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12012,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12013,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12014,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12015,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12016,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12017,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                                ObjectDefinitionIndex = 12018,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                            new VariantObjectQuota
                            {
                            },
                        },
                        SimulationEntities = new int[80]
                        {
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                        },
                    },
                    Signature = new Tag("mapv"),
                    Length = 57504,
                    MajorVersion = 12,
                    MinorVersion = 1,
                },
            };

            UpdateQuotaIndexes(blf.MapVariantTagNames.Names, blf.MapVariant.MapVariant.Quotas);

            GenerateMapFile(tag, scnr, blf);
        }
    }
}