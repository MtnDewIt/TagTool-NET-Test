using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @riverworld : MapVariantFile
    {
        public @riverworld(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\riverworld\riverworld");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            BlfData blfData = new BlfData(Cache.Version, CachePlatform.Original)
            {
                Version = CacheVersion.HaloOnlineEDLegacy,
                CachePlatform = CachePlatform.Original,
                Format = EndianFormat.LittleEndian,
                ContentFlags = BlfDataFileContentFlags.StartOfFile | BlfDataFileContentFlags.EndOfFile | BlfDataFileContentFlags.MapVariant | BlfDataFileContentFlags.Scenario,
                AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeNone,
                StartOfFile = new BlfDataChunkStartOfFile
                {
                    ByteOrderMarker = -2,
                    InternalName = $@"",
                    Signature = new Tag("_blf"),
                    Length = 48,
                    MajorVersion = 1,
                    MinorVersion = 2,
                },
                EndOfFile = new BlfDataChunkEndOfFile
                {
                    AuthenticationDataSize = 0,
                    AuthenticationType = BlfDataAuthenticationType.AuthenticationTypeNone,
                    Signature = new Tag("_eof"),
                    Length = 0,
                    MajorVersion = 0,
                    MinorVersion = 0,
                },
                Scenario = new BlfDataScenario
                {
                    MapId = 340,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Walhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                            Name = $@"英靈殿",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valhalla",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"The crew of V-398 barely survived their unplanned landing in this gorge... this curious gorge. 6-16 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"V-398 のクルーが辛うじて不時着に成功した奇妙な渓谷 (6-16 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Die Crew der V-398 hat die nicht geplante Landung in dieser ... merkwürdigen .. Schlucht gerade eben überlebt. 6-16 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"L'équipage du V-398 a failli ne pas survivre à son atterrissage impromptu dans cette gorge... profonde. 6-16 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La tripulación de V-398 apenas sobrevivió al aterrizaje forzoso en este cañón... este curioso cañón. 6-16 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La tripulación de V-398 apenas sobrevivió al aterrizaje forzoso en este cañón... este curioso cañón. 6-16 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"L'equipaggio del V-398 è sopravvissuto a stento all'atterraggio in questa strana gola. 6-16 giocatori.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"V-398의 승무원들이 불시착한 골짜기입니다. 6-16인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"突然迫降在這座古怪的峽谷，使得 V-398 隊員幾近全滅。6-16 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"A tripulação do V-398 mal sobreviveu ao pouso não planejado neste desfiladeiro... estranho.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_riverworld",
                    MapName = $@"riverworld",
                    MapIndex = 6,
                    MinimumDesiredPlayers = 4,
                    MaximumDesiredPlayers = 12,
                    GameEngineTeamCounts = new BlfDataGameEngineTeams
                    {
                        NoGametypeTeamCount = 0,
                        OddballTeamCount = 2,
                        VipTeamCount = 8,
                        AssaultTeamCount = 8,
                        CtfTeamCount = 8,
                        KothTeamCount = 8,
                        JuggernautTeamCount = 8,
                        InfectionTeamCount = 8,
                        SlayerTeamCount = 4,
                        ForgeTeamCount = 2,
                        TerritoriesTeamCount = 8,
                    },
                    Insertions = new BlfDataScenarioInsertion[8],
                    Signature = new Tag("levl"),
                    Length = 19792,
                    MajorVersion = 0,
                    MinorVersion = 0,
                },
                MapVariant = new BlfDataMapVariant
                {
                    MapVariant = new MapVariantData
                    {
                        Metadata = new BlfContentItemMetadata
                        {
                            Name = $@"Valhalla",
                            Description = $@"The crew of V-398 barely survived their unplanned landing in this gorge... this curious gorge. 6-16 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 340,
                            CampaignDifficulty = -1,
                            CampaignInsertionPoint = 0,
                        },
                        VariantVersion = 12,
                        ScenarioObjectCount = 21,
                        VariantObjectCount = 351,
                        PlaceableQuotaCount = 67,
                        MapId = 340,
                        WorldBounds = new RealRectangle3d(-40.85219f, 206.5339f, -285.4266f, 92.48665f, -15.51741f, 1892.309f),
                        RuntimeEngineSubType = VariantDataGameEngineSubType.All,
                        MaximumBudget = 13f,
                        MapVariantChecksum = 270491700,
                        Objects = new VariantDataObjectDatum[640]
                        {
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(61.0884f, -147.1492f, 3.450236f),
                                Forward = new RealVector3d(0.9554094f, 0.2952843f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(51.50547f, -96.94978f, 3.309289f),
                                Forward = new RealVector3d(0.9980093f, -0.06306609f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(58.63309f, -61.25359f, 3.38649f),
                                Forward = new RealVector3d(0.9980093f, -0.06306609f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(81.60983f, -57.40851f, 1.597463f),
                                Forward = new RealVector3d(-0.005743993f, -0.9999835f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(97.75635f, -75.76194f, 2.779872f),
                                Forward = new RealVector3d(-0.9965725f, -0.08272426f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(97.84599f, -104.3127f, 3.514497f),
                                Forward = new RealVector3d(-0.948155f, 0.3178084f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(94.51018f, -125.545f, 3.794847f),
                                Forward = new RealVector3d(-0.8335577f, -0.5524325f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(81.56037f, -147.2863f, 2.38413f),
                                Forward = new RealVector3d(0.04157258f, 0.9991355f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.None,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = (VariantDataMultiplayerTeamDesignator)9,
                                }
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 2,
                                Position = new RealPoint3d(81.6848f, -50.6895f, 1.1912f),
                                Forward = new RealVector3d(0.05345866f, 0.8700052f, 0.4901357f),
                                Up = new RealVector3d(-0.03006016f, -0.489213f, 0.8716461f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.FlyingVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 2,
                                Position = new RealPoint3d(81.50983f, -153.4135f, 2.082689f),
                                Forward = new RealVector3d(-0.0270684f, -0.873751f, 0.4856196f),
                                Up = new RealVector3d(0.01526867f, 0.4853796f, 0.8741702f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.FlyingVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 3,
                                Position = new RealPoint3d(77.50133f, -51.54965f, 0.5986246f),
                                Forward = new RealVector3d(-0.7239112f, -0.6898868f, -0.002955172f),
                                Up = new RealVector3d(-0.08152723f, 0.08129298f, 0.9933503f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 3,
                                Position = new RealPoint3d(85.70427f, -153.858f, 1.553612f),
                                Forward = new RealVector3d(0.7282334f, 0.6852754f, -0.008595976f),
                                Up = new RealVector3d(0.02328101f, -0.01220094f, 0.9996545f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(85.80526f, -55.88096f, 1.51706f),
                                Forward = new RealVector3d(-0.0001862486f, 0.9996513f, -0.02640561f),
                                Up = new RealVector3d(5.114276E-05f, 0.02640562f, 0.9996513f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(77.42783f, -147.2014f, 2.394937f),
                                Forward = new RealVector3d(0.008929892f, -0.9977634f, -0.06624567f),
                                Up = new RealVector3d(0.01394151f, -0.06611764f, 0.9977145f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(77.43101f, -148.318f, 2.391372f),
                                Forward = new RealVector3d(-0.004448165f, -0.9993455f, -0.03590127f),
                                Up = new RealVector3d(0.0277079f, -0.03601101f, 0.9989672f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(85.79529f, -57.20814f, 1.51698f),
                                Forward = new RealVector3d(0.01065468f, 0.9995934f, -0.02644647f),
                                Up = new RealVector3d(0.0001971013f, 0.02644588f, 0.9996502f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 4,
                                Position = new RealPoint3d(54.42943f, -94.90951f, 3.331948f),
                                Forward = new RealVector3d(0.7845548f, -0.6198247f, -0.01706185f),
                                Up = new RealVector3d(-0.0364837f, -0.07361376f, 0.9966193f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 5,
                                Position = new RealPoint3d(64.76712f, -100.7698f, 3.034201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = VariantDataMultiplayerObjectType.LightLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(89.57039f, -51.41422f, 0.3157009f),
                                Forward = new RealVector3d(0.4371904f, -0.8982232f, 0.0453827f),
                                Up = new RealVector3d(0.02955018f, 0.06477964f, 0.9974619f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.HeavyLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(73.95355f, -154.051f, 1.471367f),
                                Forward = new RealVector3d(-0.6380649f, 0.769743f, 0.01920369f),
                                Up = new RealVector3d(0.04645332f, 0.01358771f, 0.9988281f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.HeavyLandVehicle,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 7,
                                Position = new RealPoint3d(83.4311f, -60.7878f, 2.14364f),
                                Forward = new RealVector3d(-0.4659058f, -0.4252663f, -0.7759383f),
                                Up = new RealVector3d(-0.5915827f, -0.5024108f, 0.6305659f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 150,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 7,
                                Position = new RealPoint3d(83.17274f, -143.3953f, 3.0399f),
                                Forward = new RealVector3d(0.4271629f, -0.4649302f, -0.7754817f),
                                Up = new RealVector3d(0.501565f, -0.5917668f, 0.6310661f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 150,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 8,
                                Position = new RealPoint3d(82.32272f, -56.59195f, 0.1195271f),
                                Forward = new RealVector3d(0.0009550659f, 0.1365447f, 0.9906334f),
                                Up = new RealVector3d(0.9997957f, -0.02013279f, 0.00181112f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 8,
                                Position = new RealPoint3d(80.84422f, -147.7845f, 1.012185f),
                                Forward = new RealVector3d(0.01598869f, -0.182915f, 0.9829987f),
                                Up = new RealVector3d(-0.9970401f, -0.07685953f, 0.001915163f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 9,
                                Position = new RealPoint3d(82.80323f, -102.4698f, 5.00219f),
                                Forward = new RealVector3d(-0.995856f, 0.08735621f, 0.02529367f),
                                Up = new RealVector3d(0.08659837f, 0.9958019f, -0.02965123f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(78.82657f, -61.17258f, 2.153918f),
                                Forward = new RealVector3d(-0.1920428f, -0.09085701f, 0.9771717f),
                                Up = new RealVector3d(0.80401f, -0.5855264f, 0.1035695f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(77.54913f, -144.5007f, 3.048866f),
                                Forward = new RealVector3d(-0.06059491f, 0.1857795f, 0.9807213f),
                                Up = new RealVector3d(-0.6427709f, -0.7589584f, 0.1040563f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(77.56383f, -59.88577f, 2.154192f),
                                Forward = new RealVector3d(-0.1304457f, -0.2034422f, 0.9703583f),
                                Up = new RealVector3d(-0.6230477f, 0.7781448f, 0.07938676f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(78.75886f, -143.2841f, 3.050181f),
                                Forward = new RealVector3d(-0.1454506f, 0.08432597f, 0.9857653f),
                                Up = new RealVector3d(0.8531895f, 0.5151435f, 0.08182164f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(91.85574f, -101.2902f, 4.666959f),
                                Forward = new RealVector3d(0.4416129f, -0.884287f, 0.1517053f),
                                Up = new RealVector3d(-0.8971263f, -0.4329662f, 0.08777659f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(65.10189f, -150.7998f, 2.340422f),
                                Forward = new RealVector3d(-0.9971991f, 0.029346f, -0.0687955f),
                                Up = new RealVector3d(-0.03884397f, -0.9892372f, 0.1410704f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(65.29489f, -68.93537f, 2.712502f),
                                Forward = new RealVector3d(0.3765486f, 0.3239783f, 0.8678993f),
                                Up = new RealVector3d(-0.2817972f, 0.9325168f, -0.2258382f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(67.40894f, -124.6945f, 2.275635f),
                                Forward = new RealVector3d(0.04731285f, 0.2960289f, 0.9540065f),
                                Up = new RealVector3d(0.9899239f, -0.1415055f, -0.005184867f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(66.32994f, -80.11156f, 3.260791f),
                                Forward = new RealVector3d(-0.5089735f, 0.3248358f, 0.7971371f),
                                Up = new RealVector3d(-0.6350188f, -0.7668839f, -0.09295318f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(94.93472f, -83.98286f, 3.277368f),
                                Forward = new RealVector3d(-0.0852103f, 0.04100501f, 0.9955189f),
                                Up = new RealVector3d(-0.4977559f, 0.8637861f, -0.07818384f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(92.10064f, -118.8016f, 3.513989f),
                                Forward = new RealVector3d(-0.1828003f, -0.1135638f, 0.9765691f),
                                Up = new RealVector3d(-0.3087082f, 0.9496983f, 0.05265307f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(72.89619f, -103.4436f, 3.958736f),
                                Forward = new RealVector3d(0.1700291f, 0.07418789f, 0.9826425f),
                                Up = new RealVector3d(-0.08891697f, -0.9919396f, 0.09027533f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(80.14943f, -112.5195f, 2.991087f),
                                Forward = new RealVector3d(-0.1920916f, 0.3108326f, 0.9308511f),
                                Up = new RealVector3d(-0.9183792f, -0.3913003f, -0.05885374f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(80.59883f, -89.98479f, 2.022018f),
                                Forward = new RealVector3d(-0.2356029f, -0.7421716f, 0.6274333f),
                                Up = new RealVector3d(0.9364676f, -0.3459897f, -0.05761459f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(51.05527f, -106.8089f, 3.372083f),
                                Forward = new RealVector3d(0.6548898f, 0.7292783f, -0.1981729f),
                                Up = new RealVector3d(-0.7464799f, 0.6651323f, -0.01915242f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(78.70432f, -146.1644f, 0.9987723f),
                                Forward = new RealVector3d(0.06170069f, 0.2025288f, 0.9773306f),
                                Up = new RealVector3d(-0.9802512f, -0.1720309f, 0.09753444f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(84.50449f, -146.1918f, 0.9978734f),
                                Forward = new RealVector3d(-0.02719051f, 0.2837901f, 0.9585009f),
                                Up = new RealVector3d(0.9853632f, -0.1538119f, 0.0734927f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(78.77736f, -58.22898f, 0.1051387f),
                                Forward = new RealVector3d(0.07650031f, -0.1786692f, 0.9809307f),
                                Up = new RealVector3d(-0.9965172f, 0.01904241f, 0.0811843f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(84.38165f, -58.22921f, 0.1038364f),
                                Forward = new RealVector3d(-0.1054459f, -0.1771437f, 0.9785199f),
                                Up = new RealVector3d(0.9944192f, -0.01541621f, 0.1043684f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(76.76931f, -58.7369f, 2.515486f),
                                Forward = new RealVector3d(-0.9996924f, -0.02475351f, 0.001542645f),
                                Up = new RealVector3d(0.0247707f, -0.9996168f, 0.01235559f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(76.75746f, -145.6131f, 3.411176f),
                                Forward = new RealVector3d(-0.9999832f, -0.005782136f, -0.0004961976f),
                                Up = new RealVector3d(-0.005780819f, 0.9999799f, -0.002615687f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(76.23447f, -81.51543f, 2.250817f),
                                Forward = new RealVector3d(0.9464602f, 0.2047041f, -0.2496186f),
                                Up = new RealVector3d(0.1961715f, -0.9788006f, -0.05887366f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(67.92491f, -115.4384f, 2.06542f),
                                Forward = new RealVector3d(0.09273639f, 0.7146732f, 0.6932836f),
                                Up = new RealVector3d(-0.9649351f, 0.2362273f, -0.114442f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(76.77465f, -58.93481f, 2.516095f),
                                Forward = new RealVector3d(-0.9996542f, -0.02629451f, 0.0001495965f),
                                Up = new RealVector3d(0.02629456f, -0.9996542f, 0.0003428028f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 11,
                                Position = new RealPoint3d(76.75577f, -145.4231f, 3.411161f),
                                Forward = new RealVector3d(-0.9995478f, -0.03006585f, 0.000397483f),
                                Up = new RealVector3d(-0.0300663f, 0.9995472f, -0.001193146f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 12,
                                Position = new RealPoint3d(95.67578f, -86.62949f, 3.353327f),
                                Forward = new RealVector3d(-0.3657511f, -0.06921965f, 0.9281351f),
                                Up = new RealVector3d(0.1397087f, 0.9818481f, 0.1282807f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 12,
                                Position = new RealPoint3d(92.40108f, -114.4375f, 3.254746f),
                                Forward = new RealVector3d(0.187951f, -0.03645976f, 0.9815015f),
                                Up = new RealVector3d(0.3732618f, 0.9269862f, -0.03704246f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(85.95922f, -59.23291f, 2.056797f),
                                Forward = new RealVector3d(0.2236625f, 0.9746621f, 0.00299665f),
                                Up = new RealVector3d(0.01343572f, -0.006157406f, 0.9998908f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(65.60833f, -73.30695f, 3.658701f),
                                Forward = new RealVector3d(0.2428879f, -0.9657571f, 0.09120668f),
                                Up = new RealVector3d(-0.001307846f, 0.09369614f, 0.9956f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(86.10802f, -145.1981f, 2.951772f),
                                Forward = new RealVector3d(-0.08378103f, 0.9964838f, -0.0008505363f),
                                Up = new RealVector3d(0.01508907f, 0.002122077f, 0.9998839f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(69.71804f, -124.4562f, 2.311278f),
                                Forward = new RealVector3d(0.9838801f, -0.1472057f, 0.1015406f),
                                Up = new RealVector3d(-0.1045777f, -0.01302089f, 0.9944315f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(50.32767f, -88.05386f, 2.755475f),
                                Forward = new RealVector3d(0.3426126f, -0.9389749f, 0.03070621f),
                                Up = new RealVector3d(-0.9394501f, -0.3421737f, 0.01872274f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(51.6981f, -108.632f, 3.338328f),
                                Forward = new RealVector3d(0.9490327f, 0.1246895f, -0.2894641f),
                                Up = new RealVector3d(0.1448259f, -0.9882365f, 0.04913149f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 15,
                                Position = new RealPoint3d(77.50742f, -57.34293f, -0.02728073f),
                                Forward = new RealVector3d(0.9921364f, -0.125162f, -3.324077E-05f),
                                Up = new RealVector3d(0.1251619f, 0.9921346f, 0.001847717f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 15,
                                Position = new RealPoint3d(85.69122f, -57.2715f, -0.02731596f),
                                Forward = new RealVector3d(0.9921049f, -0.1254083f, 0.0007728557f),
                                Up = new RealVector3d(0.1254106f, 0.9920811f, -0.006877043f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 15,
                                Position = new RealPoint3d(85.75088f, -147.1326f, 0.867176f),
                                Forward = new RealVector3d(0.9922342f, -0.1242569f, 0.005612441f),
                                Up = new RealVector3d(0.1242746f, 0.9922436f, -0.002918607f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 15,
                                Position = new RealPoint3d(77.40753f, -147.1962f, 0.8673752f),
                                Forward = new RealVector3d(0.9922627f, -0.1241552f, -0.0002595917f),
                                Up = new RealVector3d(0.124151f, 0.9922423f, -0.006454801f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(76.8821f, -59.157f, 2.5339f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.0002187369f, -1f),
                                Up = new RealVector3d(1f, 0f, -4.371139E-08f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(76.88277f, -59.2247f, 2.533897f),
                                Forward = new RealVector3d(-4.371139E-08f, 0.0001138927f, -1f),
                                Up = new RealVector3d(1f, 0f, -4.371139E-08f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(91.81651f, -118.3285f, 3.369005f),
                                Forward = new RealVector3d(0.1727707f, -0.06011795f, -0.9831256f),
                                Up = new RealVector3d(0.9847201f, -0.01157984f, 0.173759f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(91.65143f, -118.0934f, 3.356949f),
                                Forward = new RealVector3d(0.1683027f, -0.05752186f, -0.9840556f),
                                Up = new RealVector3d(0.9854574f, -0.0138861f, 0.1693542f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(94.82095f, -83.6283f, 3.143173f),
                                Forward = new RealVector3d(0.1914995f, -0.2568425f, -0.9472908f),
                                Up = new RealVector3d(0.9796891f, -0.008464196f, 0.2003439f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(94.87074f, -83.74072f, 3.155112f),
                                Forward = new RealVector3d(0.1894844f, -0.2539642f, -0.9484713f),
                                Up = new RealVector3d(0.9800138f, -0.01066997f, 0.1986429f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(76.76379f, -145.0395f, 3.428577f),
                                Forward = new RealVector3d(0.000375352f, -0.0006620021f, -0.9999997f),
                                Up = new RealVector3d(0.9996564f, -0.02620778f, 0.0003925728f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(76.77479f, -145.1222f, 3.428586f),
                                Forward = new RealVector3d(-4.371138E-08f, -0.0004494936f, -0.9999999f),
                                Up = new RealVector3d(1f, 0f, -4.371139E-08f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(92.11146f, -101.7406f, 4.708247f),
                                Forward = new RealVector3d(0.8143254f, 0.3471069f, -0.4651784f),
                                Up = new RealVector3d(-0.5201802f, 0.791984f, -0.3196467f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(92.14716f, -101.6056f, 4.713047f),
                                Forward = new RealVector3d(-0.3135711f, 0.005436028f, 0.9495492f),
                                Up = new RealVector3d(-0.9280747f, 0.209786f, -0.3076805f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(64.75939f, -98.74521f, 3.664135f),
                                Forward = new RealVector3d(0.2999474f, -0.01285015f, -0.9538692f),
                                Up = new RealVector3d(0.9534117f, -0.02972708f, 0.300204f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(64.86368f, -98.7366f, 3.67544f),
                                Forward = new RealVector3d(0.3092165f, -0.0138463f, -0.9508908f),
                                Up = new RealVector3d(0.9506357f, -0.02285316f, 0.3094664f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(59.68972f, -63.33956f, 3.283082f),
                                Forward = new RealVector3d(0.0620592f, 0.007374323f, -0.9980452f),
                                Up = new RealVector3d(0.9691463f, -0.2394454f, 0.05849303f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(59.6129f, -63.18109f, 3.282067f),
                                Forward = new RealVector3d(0.0736692f, 0.007276143f, -0.9972562f),
                                Up = new RealVector3d(0.9537156f, -0.2928471f, 0.06831611f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(62.34912f, -149.1299f, 3.403245f),
                                Forward = new RealVector3d(0.04916865f, 0.5667498f, -0.8224215f),
                                Up = new RealVector3d(0.9954209f, -0.09538641f, -0.006221537f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 16,
                                Position = new RealPoint3d(62.18746f, -149.1891f, 3.390444f),
                                Forward = new RealVector3d(0.03373542f, 0.5948489f, -0.8031294f),
                                Up = new RealVector3d(0.9878191f, 0.1022935f, 0.1172584f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(82.33434f, -59.56861f, -0.01994987f),
                                Forward = new RealVector3d(-0.3095487f, 0.2094379f, -0.9275318f),
                                Up = new RealVector3d(0.9508817f, 0.06621978f, -0.3023888f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(82.45545f, -59.57644f, -0.01998607f),
                                Forward = new RealVector3d(-0.274409f, -0.1869529f, -0.9432647f),
                                Up = new RealVector3d(0.946142f, 0.1227574f, -0.2995763f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(80.70463f, -144.8579f, 0.8742518f),
                                Forward = new RealVector3d(-0.3024527f, -0.2883543f, -0.908501f),
                                Up = new RealVector3d(-0.01840589f, 0.9547312f, -0.2969f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(80.87302f, -144.8607f, 0.8731695f),
                                Forward = new RealVector3d(-0.3481824f, -0.2725347f, -0.8969358f),
                                Up = new RealVector3d(0.007124064f, 0.9560093f, -0.2932497f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(72.88462f, -103.2306f, 3.837636f),
                                Forward = new RealVector3d(0.2386794f, -0.1422507f, 0.9606231f),
                                Up = new RealVector3d(0.7585307f, -0.5903535f, -0.2758874f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(72.87506f, -103.3966f, 3.841825f),
                                Forward = new RealVector3d(0.2366338f, -0.1449413f, 0.960727f),
                                Up = new RealVector3d(0.7582513f, -0.5907151f, -0.2758816f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(67.76013f, -124.9192f, 2.116003f),
                                Forward = new RealVector3d(0.8186637f, -0.2161823f, -0.532029f),
                                Up = new RealVector3d(0.2439199f, 0.9696159f, -0.01865581f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(67.86735f, -124.9484f, 2.113851f),
                                Forward = new RealVector3d(0.9498062f, -0.04745892f, -0.309218f),
                                Up = new RealVector3d(0.04098415f, 0.9987839f, -0.02740528f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(76.45873f, -81.0118f, 2.210271f),
                                Forward = new RealVector3d(-0.2175189f, 0.8463568f, -0.4861746f),
                                Up = new RealVector3d(-0.9335572f, -0.3257822f, -0.1494559f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(76.40505f, -81.10883f, 2.222639f),
                                Forward = new RealVector3d(-0.4422575f, 0.7138239f, -0.5430136f),
                                Up = new RealVector3d(0.8738461f, 0.2065901f, -0.440129f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(51.27781f, -106.8342f, 3.327497f),
                                Forward = new RealVector3d(-0.1305493f, 0.2978834f, 0.9456334f),
                                Up = new RealVector3d(-0.9239646f, -0.3824121f, -0.007094453f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(51.19525f, -106.8744f, 3.351347f),
                                Forward = new RealVector3d(-0.2309735f, 0.8221363f, -0.5203297f),
                                Up = new RealVector3d(-0.9542556f, -0.2957752f, -0.04374114f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 18,
                                Position = new RealPoint3d(84.57459f, -144.3482f, 2.905664f),
                                Forward = new RealVector3d(0.9983571f, -0.05487613f, -0.01648107f),
                                Up = new RealVector3d(0.01654146f, 0.000646349f, 0.999863f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 18,
                                Position = new RealPoint3d(84.5401f, -60.10139f, 2.011124f),
                                Forward = new RealVector3d(-0.4803825f, 0.8770525f, 0.003387822f),
                                Up = new RealVector3d(0.01337436f, 0.003463085f, 0.9999045f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 19,
                                Position = new RealPoint3d(100.1776f, -102.6572f, 3.857206f),
                                Forward = new RealVector3d(0.1667822f, -0.03137882f, -0.9854944f),
                                Up = new RealVector3d(0.9676409f, 0.1971553f, 0.1574832f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 20,
                                Position = new RealPoint3d(55.78154f, -93.0443f, 3.412376f),
                                Forward = new RealVector3d(0.6214489f, 0.3345425f, -0.7084366f),
                                Up = new RealVector3d(-0.5179415f, 0.8538874f, -0.05111613f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(79.7632f, -56.72962f, 1.500243f),
                                Forward = new RealVector3d(0.04309971f, -0.9990708f, -2.979135E-06f),
                                Up = new RealVector3d(-8.517545E-10f, -2.981942E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(80.34682f, -56.73528f, 1.500243f),
                                Forward = new RealVector3d(0.04309971f, -0.9990708f, -2.979135E-06f),
                                Up = new RealVector3d(-8.517545E-10f, -2.981942E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(82.80276f, -56.72621f, 1.500243f),
                                Forward = new RealVector3d(-0.05511153f, -0.9984802f, -2.977457E-06f),
                                Up = new RealVector3d(-8.517545E-10f, -2.981942E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(83.37491f, -56.73626f, 1.500243f),
                                Forward = new RealVector3d(-0.05266189f, -0.9986124f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(82.97963f, -59.05672f, -0.04975589f),
                                Forward = new RealVector3d(-0.4061323f, 0.9138143f, 1.295461E-06f),
                                Up = new RealVector3d(1.869164E-07f, -1.334569E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(80.26289f, -59.04519f, -0.04975532f),
                                Forward = new RealVector3d(0.3876879f, 0.9217907f, 1.157728E-06f),
                                Up = new RealVector3d(1.869164E-07f, -1.334569E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(84.50264f, -59.99831f, -0.04975748f),
                                Forward = new RealVector3d(0.719073f, -0.6949345f, -1.061845E-06f),
                                Up = new RealVector3d(1.869164E-07f, -1.334569E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(78.67572f, -60.14661f, -0.04975659f),
                                Forward = new RealVector3d(-0.7122209f, -0.7019554f, -8.03682E-07f),
                                Up = new RealVector3d(1.869164E-07f, -1.334569E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(58.01224f, -59.46835f, 3.801682f),
                                Forward = new RealVector3d(0.9672195f, -0.2017137f, -0.1542663f),
                                Up = new RealVector3d(0.09014073f, -0.2952093f, 0.9511709f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(58.13252f, -60.59021f, 3.610252f),
                                Forward = new RealVector3d(0.9661587f, -0.1013261f, -0.2372136f),
                                Up = new RealVector3d(0.2315607f, -0.0644882f, 0.9706807f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(58.12624f, -61.69997f, 3.527107f),
                                Forward = new RealVector3d(0.9264652f, 0.1680994f, -0.3367564f),
                                Up = new RealVector3d(0.3490737f, -0.04917715f, 0.935804f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(66.69948f, -75.28759f, 3.756757f),
                                Forward = new RealVector3d(0.6436079f, 0.7588051f, -0.09991823f),
                                Up = new RealVector3d(0.09653085f, 0.04902822f, 0.9941217f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(67.00403f, -76.00961f, 3.681018f),
                                Forward = new RealVector3d(0.573258f, 0.8193361f, -0.007978376f),
                                Up = new RealVector3d(0.1451463f, -0.09196047f, 0.9851273f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(88.80809f, -47.30428f, 0.1173137f),
                                Forward = new RealVector3d(-0.5235555f, -0.8502538f, 0.05438857f),
                                Up = new RealVector3d(0.05725602f, 0.02858016f, 0.9979503f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(87.34026f, -46.61111f, 0.1201784f),
                                Forward = new RealVector3d(-0.4420363f, -0.8927224f, 0.08746684f),
                                Up = new RealVector3d(0.02634813f, 0.08454628f, 0.9960711f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(85.69344f, -46.23811f, 0.1344591f),
                                Forward = new RealVector3d(-0.1482733f, -0.9850718f, 0.08745618f),
                                Up = new RealVector3d(0.02796759f, 0.08422154f, 0.9960545f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(97.14079f, -79.47021f, 3.112629f),
                                Forward = new RealVector3d(-0.9358743f, 0.2535748f, -0.2446202f),
                                Up = new RealVector3d(-0.2188588f, 0.1257077f, 0.9676251f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(96.635f, -79.69662f, 3.027644f),
                                Forward = new RealVector3d(-0.9042608f, 0.3464722f, -0.2495384f),
                                Up = new RealVector3d(-0.2188588f, 0.1257077f, 0.9676251f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(98.2819f, -78.45995f, 3.260232f),
                                Forward = new RealVector3d(-0.9161655f, -0.2981821f, -0.2678213f),
                                Up = new RealVector3d(-0.3162139f, 0.1271652f, 0.9401265f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(96.16666f, -85.19863f, 3.288167f),
                                Forward = new RealVector3d(-0.05007607f, -0.998684f, 0.01106822f),
                                Up = new RealVector3d(-0.09725007f, 0.01590518f, 0.9951329f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(96.87423f, -85.71086f, 3.306363f),
                                Forward = new RealVector3d(-0.2646379f, -0.9639764f, 0.02676349f),
                                Up = new RealVector3d(0.01255713f, 0.02430597f, 0.9996257f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(102.8375f, -96.4915f, 4.296371f),
                                Forward = new RealVector3d(-0.9937387f, -0.1117296f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(102.7874f, -97.20412f, 4.334664f),
                                Forward = new RealVector3d(-0.9986256f, 0.0523753f, 0.001890461f),
                                Up = new RealVector3d(0.002798147f, 0.01726253f, 0.9998471f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(94.23493f, -112.918f, 3.270405f),
                                Forward = new RealVector3d(-0.4788094f, 0.8636846f, -0.1574504f),
                                Up = new RealVector3d(-0.189075f, 0.07368843f, 0.9791939f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(94.96284f, -113.0302f, 3.403049f),
                                Forward = new RealVector3d(-0.4883735f, 0.8695891f, -0.07284267f),
                                Up = new RealVector3d(-0.1495454f, -0.001162033f, 0.9887542f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(96.19885f, -111.8974f, 3.643138f),
                                Forward = new RealVector3d(-0.7037048f, 0.7104924f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(91.05715f, -116.963f, 3.230128f),
                                Forward = new RealVector3d(-0.8823194f, 0.4640702f, -0.07843049f),
                                Up = new RealVector3d(-0.06506617f, 0.04476981f, 0.9968761f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(91.51419f, -116.5342f, 3.240703f),
                                Forward = new RealVector3d(-0.54014f, 0.838411f, -0.0729081f),
                                Up = new RealVector3d(-0.06506617f, 0.04476981f, 0.9968761f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(94.30795f, -125.0668f, 3.784161f),
                                Forward = new RealVector3d(-0.8800235f, -0.459f, -0.121974f),
                                Up = new RealVector3d(-0.1268394f, -0.02035244f, 0.9917145f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(94.93169f, -125.6772f, 3.827814f),
                                Forward = new RealVector3d(-0.7703757f, -0.6222615f, -0.1389677f),
                                Up = new RealVector3d(-0.09488994f, -0.103635f, 0.9900786f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(83.33277f, -147.5039f, 2.383492f),
                                Forward = new RealVector3d(-0.03473982f, 0.9993964f, -2.514218E-06f),
                                Up = new RealVector3d(-7.008345E-08f, 2.5133E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(82.72997f, -147.5128f, 2.383294f),
                                Forward = new RealVector3d(-0.03473982f, 0.9993964f, -2.514218E-06f),
                                Up = new RealVector3d(-7.008345E-08f, 2.5133E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(80.40401f, -147.5261f, 2.382528f),
                                Forward = new RealVector3d(0.125055f, 0.9921498f, -2.484806E-06f),
                                Up = new RealVector3d(-7.008345E-08f, 2.5133E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(79.8671f, -147.5231f, 2.38235f),
                                Forward = new RealVector3d(0.125055f, 0.9921498f, -2.484806E-06f),
                                Up = new RealVector3d(-7.008345E-08f, 2.5133E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(80.24113f, -145.3222f, 0.8449438f),
                                Forward = new RealVector3d(0.6269943f, -0.7790238f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(82.95617f, -145.4301f, 0.8449439f),
                                Forward = new RealVector3d(-0.6919667f, -0.7219295f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(78.60976f, -144.2771f, 0.8449438f),
                                Forward = new RealVector3d(-0.7264223f, 0.6872486f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(84.58615f, -144.2806f, 0.8449466f),
                                Forward = new RealVector3d(0.7011267f, 0.7130367f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(85.74992f, -159.503f, 1.84499f),
                                Forward = new RealVector3d(-0.2144527f, 0.9584966f, -0.1878674f),
                                Up = new RealVector3d(-0.01783854f, 0.1884668f, 0.9819175f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(82.38127f, -159.7111f, 1.697444f),
                                Forward = new RealVector3d(0.1844873f, 0.9750022f, -0.1238353f),
                                Up = new RealVector3d(-0.2042406f, 0.1612798f, 0.9655437f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(82.2662f, -93.95769f, 0.8771772f),
                                Forward = new RealVector3d(-0.8203818f, -0.5036073f, -0.2708383f),
                                Up = new RealVector3d(-0.3986686f, 0.1641941f, 0.9022769f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(82.26389f, -93.08814f, 0.7250267f),
                                Forward = new RealVector3d(-0.8864107f, -0.3833655f, -0.2594357f),
                                Up = new RealVector3d(-0.3323574f, 0.1369755f, 0.9331539f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(78.92097f, -112.8085f, 2.676047f),
                                Forward = new RealVector3d(-0.3127909f, -0.9374584f, -0.1527533f),
                                Up = new RealVector3d(-0.09952445f, -0.1275894f, 0.9868211f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(79.62831f, -113.0618f, 2.714629f),
                                Forward = new RealVector3d(-0.01798538f, -0.9913523f, -0.1299892f),
                                Up = new RealVector3d(-0.09952445f, -0.1275894f, 0.9868211f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(69.03508f, -112.0664f, 1.607677f),
                                Forward = new RealVector3d(0.3027275f, 0.937385f, -0.1722362f),
                                Up = new RealVector3d(-0.2085415f, 0.2414856f, 0.9477316f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(68.43758f, -111.646f, 1.345868f),
                                Forward = new RealVector3d(0.3197834f, 0.9009969f, -0.2931608f),
                                Up = new RealVector3d(-0.2298793f, 0.3739414f, 0.8985118f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(52.28382f, -110.0035f, 3.398235f),
                                Forward = new RealVector3d(0.7291762f, 0.44117f, -0.5231359f),
                                Up = new RealVector3d(0.4253795f, 0.3066157f, 0.8514923f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(51.85575f, -109.3067f, 3.372964f),
                                Forward = new RealVector3d(0.7599037f, 0.4747411f, -0.4440351f),
                                Up = new RealVector3d(0.3819917f, 0.2265696f, 0.8959624f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(48.75128f, -101.4164f, 3.245216f),
                                Forward = new RealVector3d(0.9971037f, 0.00544932f, 0.07585829f),
                                Up = new RealVector3d(-0.07605374f, 0.07062215f, 0.9945996f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(48.78298f, -100.1723f, 3.284994f),
                                Forward = new RealVector3d(0.9732434f, 0.0004062427f, 0.2297763f),
                                Up = new RealVector3d(-0.2297213f, -0.02024072f, 0.9730459f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(48.69542f, -93.55517f, 2.949995f),
                                Forward = new RealVector3d(0.9951314f, -0.002656907f, -0.09852141f),
                                Up = new RealVector3d(0.09821936f, 0.1094356f, 0.9891294f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(48.67536f, -92.22669f, 2.863209f),
                                Forward = new RealVector3d(0.985684f, -0.0008542009f, -0.1686009f),
                                Up = new RealVector3d(0.1684838f, 0.04258707f, 0.984784f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(62.62331f, -96.77617f, 2.098686f),
                                Forward = new RealVector3d(0.8574957f, 0.4191442f, -0.2983611f),
                                Up = new RealVector3d(0.2170762f, 0.2310203f, 0.9484237f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(61.9319f, -96.54397f, 2.14215f),
                                Forward = new RealVector3d(0.6338956f, 0.741233f, -0.2207941f),
                                Up = new RealVector3d(0.08792254f, 0.2145648f, 0.9727443f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(58.44067f, -105.1486f, 2.101994f),
                                Forward = new RealVector3d(0.5041576f, -0.85539f, -0.1188828f),
                                Up = new RealVector3d(-0.0466971f, -0.1644575f, 0.9852782f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(58.12333f, -106.08f, 1.950984f),
                                Forward = new RealVector3d(0.6516376f, -0.7541545f, -0.08135998f),
                                Up = new RealVector3d(-0.04058725f, -0.1417729f, 0.9890668f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(62.50598f, -107.8797f, 0.51419f),
                                Forward = new RealVector3d(-0.4938864f, -0.8667313f, -0.06966347f),
                                Up = new RealVector3d(0.1401288f, -0.1584059f, 0.9773799f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(63.21923f, -107.0071f, 0.5214416f),
                                Forward = new RealVector3d(-0.2948045f, -0.9505365f, -0.09782971f),
                                Up = new RealVector3d(0.1931389f, -0.1595399f, 0.9681138f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(67.09237f, -100.2196f, 0.9250109f),
                                Forward = new RealVector3d(0.8673401f, 0.4965507f, -0.0340363f),
                                Up = new RealVector3d(0.08370445f, -0.07811438f, 0.9934242f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(66.98615f, -101.1855f, 0.8293498f),
                                Forward = new RealVector3d(0.8665526f, 0.497724f, -0.03684331f),
                                Up = new RealVector3d(0.1193484f, -0.1349771f, 0.9836347f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(62.51757f, -87.56075f, 2.033107f),
                                Forward = new RealVector3d(0.9520592f, -0.2899512f, -0.09752728f),
                                Up = new RealVector3d(0.09263483f, -0.03058534f, 0.9952303f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(63.52832f, -87.05206f, 1.95466f),
                                Forward = new RealVector3d(0.9243034f, -0.3690277f, -0.09737398f),
                                Up = new RealVector3d(0.09263483f, -0.03058534f, 0.9952303f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(84.4456f, -149.4243f, 2.241512f),
                                Forward = new RealVector3d(-0.05594768f, 0.9028642f, 0.4262699f),
                                Up = new RealVector3d(-1.039397E-07f, -0.4269386f, 0.9042806f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(78.82306f, -149.4504f, 2.229192f),
                                Forward = new RealVector3d(0.03608f, 0.9036918f, 0.4266606f),
                                Up = new RealVector3d(-1.039397E-07f, -0.4269386f, 0.9042806f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(92.53546f, -146.7442f, 1.114592f),
                                Forward = new RealVector3d(-0.6652234f, 0.7465655f, -0.01085367f),
                                Up = new RealVector3d(0.04225372f, 0.0521553f, 0.9977446f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(93.5143f, -145.819f, 1.051891f),
                                Forward = new RealVector3d(-0.7045813f, 0.709381f, 0.0185446f),
                                Up = new RealVector3d(0.06414121f, 0.03763767f, 0.9972308f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(72.96294f, -120.5278f, 2.264601f),
                                Forward = new RealVector3d(0.7750179f, 0.6305634f, 0.04167655f),
                                Up = new RealVector3d(0.01220475f, -0.08087341f, 0.9966496f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(73.33073f, -121.0725f, 2.222821f),
                                Forward = new RealVector3d(0.7741257f, 0.630077f, 0.06109347f),
                                Up = new RealVector3d(-0.02084178f, -0.07108884f, 0.9972522f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(78.61101f, -73.23933f, 1.815918f),
                                Forward = new RealVector3d(0.1252856f, -0.8505409f, 0.5107678f),
                                Up = new RealVector3d(-0.1749426f, 0.487818f, 0.855236f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(77.75003f, -73.26996f, 1.691846f),
                                Forward = new RealVector3d(0.1670604f, -0.9492589f, 0.2664551f),
                                Up = new RealVector3d(-0.04708813f, 0.2622629f, 0.9638469f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(73.41684f, -82.51425f, 2.48957f),
                                Forward = new RealVector3d(-0.3579634f, -0.9324811f, -0.04838641f),
                                Up = new RealVector3d(0.02017105f, -0.05953068f, 0.9980227f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(74.00404f, -82.93182f, 2.493297f),
                                Forward = new RealVector3d(-0.3843843f, -0.9223626f, 0.03867816f),
                                Up = new RealVector3d(0.02430346f, 0.03177203f, 0.9991996f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(97.86333f, -103.5513f, 3.468875f),
                                Forward = new RealVector3d(-0.9393181f, 0.3024641f, -0.1618546f),
                                Up = new RealVector3d(-0.149398f, 0.06404012f, 0.9867011f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(97.2646f, -104.9123f, 3.465823f),
                                Forward = new RealVector3d(-0.8849808f, 0.4382047f, -0.1574351f),
                                Up = new RealVector3d(-0.1457815f, 0.06035803f, 0.9874739f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(81.82724f, -107.2312f, 4.567258f),
                                Forward = new RealVector3d(-0.0004153657f, 0.9993849f, -0.03506514f),
                                Up = new RealVector3d(0.1574799f, 0.03469298f, 0.9869125f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(80.97697f, -107.0179f, 4.608719f),
                                Forward = new RealVector3d(0.002957555f, 0.9993634f, -0.03555303f),
                                Up = new RealVector3d(-0.03337533f, 0.03563202f, 0.9988075f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(80.29578f, -102.203f, 5.093095f),
                                Forward = new RealVector3d(-0.001156138f, -0.996667f, -0.08156911f),
                                Up = new RealVector3d(0.08348329f, -0.08138061f, 0.9931806f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(81.11102f, -102.289f, 5.014985f),
                                Forward = new RealVector3d(-0.02733373f, -0.9974089f, 0.06654529f),
                                Up = new RealVector3d(0.03778276f, 0.06549175f, 0.9971376f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(88.34157f, -102.4355f, 4.876535f),
                                Forward = new RealVector3d(-0.9305267f, 0.3637429f, -0.04255812f),
                                Up = new RealVector3d(-0.05602755f, -0.02655414f, 0.998076f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(88.15182f, -103.1551f, 4.833398f),
                                Forward = new RealVector3d(-0.9788417f, -0.1270239f, -0.160418f),
                                Up = new RealVector3d(-0.1202542f, -0.2771928f, 0.9532592f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(65.01999f, -56.6873f, 0.4895388f),
                                Forward = new RealVector3d(0.5022094f, -0.86068f, -0.08375944f),
                                Up = new RealVector3d(0.3918453f, 0.1401525f, 0.9092934f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(65.76755f, -55.84562f, 0.02648334f),
                                Forward = new RealVector3d(0.5100941f, -0.8589054f, -0.04566685f),
                                Up = new RealVector3d(0.3878666f, 0.1823114f, 0.9035054f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(56.47486f, -130.02f, 0.4948694f),
                                Forward = new RealVector3d(0.8901048f, 0.4557028f, -0.006969612f),
                                Up = new RealVector3d(-0.003090753f, 0.02132769f, 0.9997678f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(56.95805f, -130.8486f, 0.5140407f),
                                Forward = new RealVector3d(0.8047787f, 0.5934879f, -0.01017272f),
                                Up = new RealVector3d(-0.003090753f, 0.02132769f, 0.9997678f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(94.33566f, -71.4748f, 2.147184f),
                                Forward = new RealVector3d(-0.5145102f, -0.8573605f, 0.01456813f),
                                Up = new RealVector3d(-0.03363417f, 0.03715467f, 0.9987434f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(93.86933f, -70.89087f, 2.109226f),
                                Forward = new RealVector3d(-0.5145342f, -0.857319f, 0.01608278f),
                                Up = new RealVector3d(-0.03347863f, 0.03882748f, 0.9986849f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(93.4992f, -136.4976f, 0.4974691f),
                                Forward = new RealVector3d(-0.8885989f, 0.4586849f, -0.0003661997f),
                                Up = new RealVector3d(-0.0005627561f, -0.0002918449f, 0.9999998f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(94.10806f, -137.5704f, 0.4974986f),
                                Forward = new RealVector3d(-0.9705111f, 0.2410558f, -0.0004758103f),
                                Up = new RealVector3d(-0.0005627561f, -0.0002918449f, 0.9999998f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(68.30009f, -126.4772f, 1.930884f),
                                Forward = new RealVector3d(-0.8532507f, 0.2427097f, -0.4615792f),
                                Up = new RealVector3d(-0.4471568f, 0.1149571f, 0.8870375f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(68.41401f, -128.3225f, 2.075382f),
                                Forward = new RealVector3d(-0.5775819f, 0.7428963f, -0.3383847f),
                                Up = new RealVector3d(-0.632409f, -0.1450836f, 0.7609268f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(68.06395f, -127.3483f, 1.852478f),
                                Forward = new RealVector3d(-0.7024855f, 0.609466f, -0.3675124f),
                                Up = new RealVector3d(-0.4336891f, 0.04285182f, 0.9000431f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(83.30482f, -159.5088f, 1.739053f),
                                Forward = new RealVector3d(-0.08465496f, 0.9766808f, -0.1973021f),
                                Up = new RealVector3d(-0.05564867f, 0.1930695f, 0.9796057f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(61.64521f, -148.0146f, 3.411423f),
                                Forward = new RealVector3d(0.9661419f, 0.2541479f, 0.04448133f),
                                Up = new RealVector3d(-0.03434439f, -0.0441871f, 0.9984328f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(60.89853f, -147.2773f, 3.46318f),
                                Forward = new RealVector3d(0.9801246f, 0.1874078f, -0.06507014f),
                                Up = new RealVector3d(0.07191679f, -0.02996171f, 0.9969606f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(60.5673f, -146.3939f, 3.49458f),
                                Forward = new RealVector3d(0.978766f, 0.03508571f, -0.2019557f),
                                Up = new RealVector3d(0.2015498f, 0.01478009f, 0.9793667f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 22,
                                Position = new RealPoint3d(81.59283f, -147.4012f, 2.394943f),
                                Forward = new RealVector3d(-0.003474988f, 0.999994f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 22,
                                Position = new RealPoint3d(81.5928f, -57.0154f, 1.500243f),
                                Forward = new RealVector3d(0.006033221f, -0.9999818f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 23,
                                Position = new RealPoint3d(81.5928f, -57.01574f, 1.494216f),
                                Forward = new RealVector3d(0.006033221f, -0.9999818f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 23,
                                Position = new RealPoint3d(81.59283f, -147.4008f, 2.387751f),
                                Forward = new RealVector3d(-0.003474988f, 0.999994f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(81.5928f, -57.01574f, 1.494216f),
                                Forward = new RealVector3d(0.006033221f, -0.9999818f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(81.59283f, -147.4008f, 2.387751f),
                                Forward = new RealVector3d(-0.003474988f, 0.999994f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 25,
                                Position = new RealPoint3d(79.39494f, -48.64377f, 0.3809218f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 25,
                                Position = new RealPoint3d(79.55737f, -155.793f, 1.381261f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(76.76402f, -81.30865f, 2.032371f),
                                Forward = new RealVector3d(-0.4598522f, 0.8872471f, 0.03644621f),
                                Up = new RealVector3d(0.1670031f, 0.04609954f, 0.9848781f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(50.37737f, -106.9428f, 3.358002f),
                                Forward = new RealVector3d(0.9975006f, -0.02483022f, -0.06615181f),
                                Up = new RealVector3d(0.06919135f, 0.1534728f, 0.9857275f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 27,
                                Position = new RealPoint3d(81.5928f, -57.01574f, 1.494216f),
                                Forward = new RealVector3d(0.006033221f, -0.9999818f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 27,
                                Position = new RealPoint3d(81.59283f, -147.4008f, 2.387751f),
                                Forward = new RealVector3d(-0.003474988f, 0.999994f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(81.5928f, -57.01574f, 1.494216f),
                                Forward = new RealVector3d(0.006033221f, -0.9999818f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(81.59283f, -147.4008f, 2.387751f),
                                Forward = new RealVector3d(-0.003474988f, 0.999994f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(81.5928f, -57.01574f, 1.494216f),
                                Forward = new RealVector3d(0.006033221f, -0.9999818f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(81.59283f, -147.4008f, 2.387751f),
                                Forward = new RealVector3d(-0.003474988f, 0.999994f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 30,
                                Position = new RealPoint3d(77.51289f, -51.56215f, 0.5141572f),
                                Forward = new RealVector3d(-0.724124f, -0.6896698f, -0.000121957f),
                                Up = new RealVector3d(-0.07953395f, 0.08333162f, 0.9933429f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 30,
                                Position = new RealPoint3d(85.70383f, -153.8578f, 1.467234f),
                                Forward = new RealVector3d(0.7282335f, 0.6852753f, -0.008595974f),
                                Up = new RealVector3d(0.023281f, -0.01220094f, 0.9996545f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(79.39494f, -48.64377f, 0.3809218f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(79.55737f, -155.793f, 1.381261f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(79.39494f, -48.64377f, 0.3809218f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(79.55737f, -155.793f, 1.381261f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(79.39494f, -48.64377f, 0.3809218f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(79.55737f, -155.793f, 1.381261f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(79.39494f, -48.64377f, 0.3809218f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(79.55737f, -155.793f, 1.381261f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 45f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(61.50272f, -83.24931f, 2.571517f),
                                Forward = new RealVector3d(0.9639665f, 0.2632777f, -0.03812225f),
                                Up = new RealVector3d(0.121033f, -0.3064371f, 0.9441649f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(61.55299f, -84.02574f, 2.381555f),
                                Forward = new RealVector3d(0.9167891f, 0.3990204f, -0.01674606f),
                                Up = new RealVector3d(0.09809057f, -0.18433f, 0.9779574f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(78.51447f, -54.82155f, 1.274362f),
                                Forward = new RealVector3d(0.04086139f, -0.9035296f, 0.4265731f),
                                Up = new RealVector3d(7.568417E-07f, 0.4269297f, 0.9042848f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(84.57967f, -54.84544f, 1.285638f),
                                Forward = new RealVector3d(-0.06694877f, -0.902256f, 0.4259718f),
                                Up = new RealVector3d(7.568417E-07f, 0.4269297f, 0.9042848f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(81.9019f, -104.075f, 4.83276f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(83.6514f, -102.729f, 4.92305f),
                                Forward = new RealVector3d(0.6340694f, 0.7721432f, 0.04184251f),
                                Up = new RealVector3d(-4.279896E-10f, -0.0541107f, 0.9985349f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 37,
                                Position = new RealPoint3d(55.2181f, -93.367f, 3.39098f),
                                Forward = new RealVector3d(0.9999965f, 6.172137E-05f, 0.002655509f),
                                Up = new RealVector3d(-0.002655655f, 0.002498148f, 0.9999934f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(55.2781f, -94.43f, 3.37838f),
                                Forward = new RealVector3d(0.9996718f, -0.004577027f, 0.02520671f),
                                Up = new RealVector3d(-0.025463f, -0.06913423f, 0.9972823f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(54.8503f, -93.4026f, 3.39398f),
                                Forward = new RealVector3d(-0.482797f, 0.8756568f, 0.01149141f),
                                Up = new RealVector3d(0.02484762f, 0.0005806994f, 0.9996911f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(55.1228f, -94.1875f, 3.68882f),
                                Forward = new RealVector3d(0.999684f, -0.005435639f, 0.02454042f),
                                Up = new RealVector3d(0.00541388f, 0.9999849f, 0.0009530205f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(58.495f, -99.4875f, 2.28512f),
                                Forward = new RealVector3d(0.9998787f, 0f, 0.0155734f),
                                Up = new RealVector3d(-0.0155734f, 0f, 0.9998787f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(97.3108f, -104.583f, 3.4546f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(62.3146f, -104.132f, 4.03979f),
                                Forward = new RealVector3d(-0.879949f, -0.4747425f, -0.01759087f),
                                Up = new RealVector3d(-0.0318153f, 0.02194476f, 0.9992529f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(97.58749f, -102.2085f, 3.353781f),
                                Forward = new RealVector3d(-0.1091469f, -0.9933366f, 0.03700506f),
                                Up = new RealVector3d(-0.1203893f, 0.05016336f, 0.9914585f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 41,
                                Position = new RealPoint3d(80.7472f, -142.03f, 4.2433f),
                                Forward = new RealVector3d(-0.0001414258f, 1.284554E-07f, 1f),
                                Up = new RealVector3d(-0.001217363f, -0.9999993f, -4.371136E-08f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(80.8345f, -142.667f, 4.10471f),
                                Forward = new RealVector3d(-0.9989055f, 0.04662782f, 0.003698501f),
                                Up = new RealVector3d(0.004026621f, 0.006945041f, 0.9999678f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 41,
                                Position = new RealPoint3d(82.3423f, -61.9768f, 3.3484f),
                                Forward = new RealVector3d(0.0007155695f, 0.000773351f, 0.9999995f),
                                Up = new RealVector3d(0.0002843735f, -0.9999996f, 0.0007731476f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(83.2876f, -62.0242f, 2.45998f),
                                Forward = new RealVector3d(0.9999999f, -1.734097E-05f, -0.0004344792f),
                                Up = new RealVector3d(0.0004344788f, -2.284548E-05f, 0.9999999f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(83.287f, -62.1586f, 2.46016f),
                                Forward = new RealVector3d(0.9999822f, -0.0003252411f, 0.005957896f),
                                Up = new RealVector3d(-0.005957157f, 0.002228395f, 0.9999797f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(95.3214f, -93.6129f, 2.54849f),
                                Forward = new RealVector3d(0.7854447f, 0.6189109f, 0.005092656f),
                                Up = new RealVector3d(0.6179186f, -0.7846029f, 0.05074353f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(96.7029f, -98.2882f, 2.90641f),
                                Forward = new RealVector3d(0.4267907f, 0.5568371f, -0.7125883f),
                                Up = new RealVector3d(0.8218558f, -0.5676114f, 0.04868637f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(97.415f, -104.005f, 3.43122f),
                                Forward = new RealVector3d(0.9960595f, 0f, 0.08868725f),
                                Up = new RealVector3d(-0.08868725f, 0f, 0.9960595f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(66.8165f, -127.02f, 1.49332f),
                                Forward = new RealVector3d(0.1741475f, -0.9761992f, -0.1292583f),
                                Up = new RealVector3d(-0.2122054f, -0.1653837f, 0.9631288f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(95.9943f, -83.4863f, 3.22161f),
                                Forward = new RealVector3d(0.9815558f, 0.1884744f, 0.03202426f),
                                Up = new RealVector3d(-0.03650871f, 0.02036922f, 0.9991257f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.8f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(63.515f, -83.6171f, 2.2964f),
                                Forward = new RealVector3d(-0.730702f, 0.6666459f, 0.1471661f),
                                Up = new RealVector3d(0.03214726f, -0.181728f, 0.9828233f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(51.18001f, -107.3762f, 3.464443f),
                                Forward = new RealVector3d(0.2679151f, 0.06563265f, 0.9612044f),
                                Up = new RealVector3d(-0.9630778f, -0.00920348f, 0.2690657f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(95.0155f, -97.5372f, 2.92663f),
                                Forward = new RealVector3d(-0.01841307f, 0.02306217f, 0.9995644f),
                                Up = new RealVector3d(-0.9842506f, -0.1762185f, -0.01406522f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(100.013f, -101.708f, 3.83229f),
                                Forward = new RealVector3d(0.3823594f, -0.1177119f, -0.9164852f),
                                Up = new RealVector3d(-0.6082171f, -0.7787421f, -0.153729f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 42,
                                Position = new RealPoint3d(102.312f, -104.858f, 3.82136f),
                                Forward = new RealVector3d(-0.4007893f, -0.8287854f, 0.3904903f),
                                Up = new RealVector3d(0.9094242f, -0.4115201f, 0.05999026f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(81.6071f, -57.9788f, 1.52532f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(81.63f, -146.506f, 2.43179f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(81.6093f, -61.0276f, 2.10034f),
                                Forward = new RealVector3d(0.7071068f, -0.7071068f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(81.5551f, -58.3443f, -0.0497548f),
                                Forward = new RealVector3d(-1f, -8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = -0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(81.6111f, -143.387f, 2.99493f),
                                Forward = new RealVector3d(0.7071068f, 0.7071068f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(81.5931f, -146.064f, 0.844945f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = -0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(92.2137f, -91.8829f, 2.57696f),
                                Forward = new RealVector3d(0.9995843f, 0.0008735384f, 0.02881874f),
                                Up = new RealVector3d(-0.0283564f, 0.2105815f, 0.9771649f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(95.9026f, -100.872f, 3.21009f),
                                Forward = new RealVector3d(-0.1054709f, -0.9942403f, -0.01902663f),
                                Up = new RealVector3d(-0.1775313f, 3.561935E-09f, 0.9841151f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                                Forward = new RealVector3d(0.5793563f, 0.8150744f, -1.681204E-07f),
                                Up = new RealVector3d(0.1824415f, -0.1296795f, 0.9746273f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(84.4004f, -153.901f, 1.54089f),
                                Forward = new RealVector3d(0.3050785f, 0.9518341f, 0.0306418f),
                                Up = new RealVector3d(0.9514312f, -0.3032383f, -0.05315264f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(84.4789f, -154.151f, 1.48953f),
                                Forward = new RealVector3d(0.9675596f, 0.2498592f, -0.03740066f),
                                Up = new RealVector3d(0.04235066f, -0.01446251f, 0.9989982f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(76.6112f, -51.3018f, 0.525322f),
                                Forward = new RealVector3d(-0.1151215f, 0.1288103f, 0.9849644f),
                                Up = new RealVector3d(-0.7129445f, -0.7011705f, 0.008368583f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(76.293f, -51.6978f, 0.397189f),
                                Forward = new RealVector3d(-0.6570975f, 0.7337344f, -0.1727912f),
                                Up = new RealVector3d(-0.1264052f, 0.1187249f, 0.9848483f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(83.6342f, -102.709f, 4.92467f),
                                Forward = new RealVector3d(0.7071068f, 0.7071068f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(77.6742f, -101.999f, 5.3752f),
                                Forward = new RealVector3d(0.7462921f, 0.6640841f, -0.04517155f),
                                Up = new RealVector3d(0.1287812f, -0.077475f, 0.988642f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                                Forward = new RealVector3d(0.5793563f, 0.8150744f, -1.681204E-07f),
                                Up = new RealVector3d(0.1824415f, -0.1296795f, 0.9746273f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(97.58749f, -102.2085f, 3.353781f),
                                Forward = new RealVector3d(-0.1091469f, -0.9933366f, 0.03700506f),
                                Up = new RealVector3d(-0.1203893f, 0.05016336f, 0.9914585f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(57.0105f, -98.4585f, 2.43212f),
                                Forward = new RealVector3d(0.5793563f, 0.8150744f, -1.681204E-07f),
                                Up = new RealVector3d(0.1824415f, -0.1296795f, 0.9746273f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(95.9026f, -100.872f, 3.21009f),
                                Forward = new RealVector3d(-0.1054709f, -0.9942403f, -0.01902663f),
                                Up = new RealVector3d(-0.1775313f, 3.561935E-09f, 0.9841151f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(81.63f, -146.506f, 2.38217f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(81.6071f, -57.9788f, 1.47689f),
                                Forward = new RealVector3d(-1f, 8.742278E-08f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(70.7251f, -127.831f, 2.87516f),
                                Forward = new RealVector3d(0.99699f, 0f, 0.07753076f),
                                Up = new RealVector3d(-0.07753076f, 0f, 0.99699f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(93.3272f, -118.508f, 3.44034f),
                                Forward = new RealVector3d(0.9960595f, 0f, 0.08868725f),
                                Up = new RealVector3d(-0.08868725f, 0f, 0.9960595f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(83.61036f, -102.9507f, 4.906605f),
                                Forward = new RealVector3d(0.9952901f, 0.09694123f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 4f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(95.9943f, -83.4863f, 3.22161f),
                                Forward = new RealVector3d(0.9815558f, 0.1884744f, 0.03202426f),
                                Up = new RealVector3d(-0.03650871f, 0.02036922f, 0.9991257f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.8f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(75.20548f, -80.30006f, 2.33234f),
                                Forward = new RealVector3d(0.9914536f, 0f, -0.1304595f),
                                Up = new RealVector3d(0.1304595f, 0f, 0.9914536f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(85.6133f, -121.082f, 2.98847f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -0.0523004f, 0.9986314f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(72.4726f, -77.9601f, 3.01574f),
                                Forward = new RealVector3d(-0.9614201f, 0.2647149f, 0.07481653f),
                                Up = new RealVector3d(0.07758421f, 0f, 0.9969858f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(71.2153f, -74.4041f, 3.21789f),
                                Forward = new RealVector3d(0.05656752f, -0.9965307f, 0.06104705f),
                                Up = new RealVector3d(0.007246701f, 0.06155316f, 0.9980775f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(71.6165f, -78.0496f, 3.24951f),
                                Forward = new RealVector3d(0.8279634f, -0.5607802f, -0.001456673f),
                                Up = new RealVector3d(0.09221678f, 0.1335902f, 0.9867369f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(74.6567f, -83.129f, 2.49623f),
                                Forward = new RealVector3d(0.9931204f, 0.1170978f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(87.0449f, -106.241f, 4.01366f),
                                Forward = new RealVector3d(-0.9640778f, 0.2647149f, -0.02191182f),
                                Up = new RealVector3d(-0.02272241f, 0f, 0.9997418f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(88.5995f, -114.545f, 2.69899f),
                                Forward = new RealVector3d(-0.9876316f, -0.1552536f, -0.02191189f),
                                Up = new RealVector3d(-0.02071139f, -0.009346069f, 0.9997418f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(93.7792f, -128.393f, 3.48919f),
                                Forward = new RealVector3d(0.1981362f, 0.9799296f, -0.02191178f),
                                Up = new RealVector3d(-0.001554763f, 0.02266916f, 0.9997419f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(90.2448f, -128.221f, 2.67069f),
                                Forward = new RealVector3d(-0.9636815f, 0.2647149f, 0.03527327f),
                                Up = new RealVector3d(0.03657813f, 0f, 0.9993308f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(74.4966f, -86.7925f, 2.12612f),
                                Forward = new RealVector3d(-0.9636815f, 0.2669835f, 0.006163669f),
                                Up = new RealVector3d(0.03657813f, 0.1090964f, 0.993358f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(88.3602f, -99.9714f, 3.63971f),
                                Forward = new RealVector3d(-0.9902062f, 0.08704966f, 0.1091518f),
                                Up = new RealVector3d(0.1290031f, 0.2715319f, 0.9537445f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(55.473f, -93.9713f, 3.97739f),
                                Forward = new RealVector3d(-0.2780505f, 0.9605457f, -0.006310193f),
                                Up = new RealVector3d(-0.02482354f, -0.000618347f, 0.9996917f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 56,
                                Position = new RealPoint3d(55.7763f, -93.7475f, 3.51947f),
                                Forward = new RealVector3d(0.9768997f, 0.2131743f, 0.014961f),
                                Up = new RealVector3d(-0.02369743f, 0.03848635f, 0.9989781f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(91.5979f, -130.075f, 2.4999f),
                                Forward = new RealVector3d(0.5445396f, -0.8333302f, -0.09506528f),
                                Up = new RealVector3d(-0.1105217f, -0.1836479f, 0.9767591f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 57,
                                Position = new RealPoint3d(72.13075f, -7.151678f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 57,
                                Position = new RealPoint3d(72.10191f, -7.930175f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 58,
                                Position = new RealPoint3d(71.47431f, -7.118358f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 58,
                                Position = new RealPoint3d(71.48746f, -7.902164f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 59,
                                Position = new RealPoint3d(70.91357f, -7.03483f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 59,
                                Position = new RealPoint3d(70.92479f, -7.886478f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 60,
                                Position = new RealPoint3d(70.36563f, -7.144942f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 60,
                                Position = new RealPoint3d(70.35686f, -7.839686f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(69.77449f, -7.128363f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(69.80562f, -7.815611f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(69.17648f, -7.101247f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(69.17175f, -7.832245f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(68.54926f, -7.124963f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(68.55874f, -7.756835f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(67.96917f, -7.030532f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(68.01935f, -7.707038f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(67.41357f, -7.055074f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(67.37775f, -7.718326f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 66,
                                Position = new RealPoint3d(66.82541f, -7.047056f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 66,
                                Position = new RealPoint3d(66.88258f, -7.681393f, -6.549201f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                        },
                        ObjectTypeStartIndex = new short[16]
                        {
                            -1, 0, 0, 0, -1, -1, -1, 0, -1, -1,
                            -1, 17, -1, -1, -1, 0,
                        },
                        Quotas = new VariantDataObjectQuota[256]
                        {
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\physics\nutblocker_1x1x2\nutblocker_1x1x2").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\banshee\banshee").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose").Index,
                                MinimumCount = 0,
                                MaximumCount = 7,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\weapons\turret\machinegun_turret\machinegun_turret").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\turret\missile_pod\missile_pod").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_high\spartan_laser\spartan_laser").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 24,
                                PlacedOnMap = 19,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg").Index,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 24,
                                PlacedOnMap = 14,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 24,
                                PlacedOnMap = 14,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\powerdrain_equipment\powerdrain_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\regenerator_equipment\regenerator_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 99,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\gear\human\military\resupply_capsule_fired\resupply_capsule_fired").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\territories\territories_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\vip\vip_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\scenery\human\military\warthog_drop_palette\warthog_drop_palette").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\vip\vip_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\territories\territories_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\koth\koth_hill_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\oddball\oddball_ball_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\antennae_mast\antennae_mast").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\crate_packing\crate_packing").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\generator\generator").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\case_ap_turret\case_ap_turret").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\fusion_coil\fusion_coil").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\drum_12gal\drum_12gal").Index,
                                MinimumCount = 0,
                                MaximumCount = 5,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\territories\territory_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 10,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\resupply_capsule_panel\resupply_capsule_panel").Index,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_return_area").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_goal_area").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\vip\vip_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\blitzcan\blitzcan").Index,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"ms30\objects\levels\dlc\bunkerworld\drum_55gal_bunker\drum_55gal_bunker").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\juggernaut\juggernaut_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_tree_pine\plant_tree_pine").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 10,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\solo\100_citadel\foliage\plant_pine_tree_large\plant_pine_tree_large").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\hu_mil_radio_small\hu_mil_radio_small").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\camping_stool_mp\camping_stool_mp").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_l\box_l").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_m\box_m").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xl\box_xl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xxl\box_xxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xxxl\box_xxxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_l\wall_l").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_m\wall_m").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xl\wall_xl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xxl\wall_xxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xxxl\wall_xxxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
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

            GenerateMapFile(tag, blfData);
        }
    }
}