using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @guardian : MapVariantFile
    {
        public @guardian(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\guardian\guardian");
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
                    MapId = 320,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Guardian",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Guardian",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Wächter",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Gardien",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Guardian",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Guardian",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Il guardiano",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Guardian",
                        },
                        new NameUnicode32
                        {
                            Name = $@"守護者",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Guardião",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Millennia of tending has produced trees as ancient as the Forerunner structures they have grown around. 2-6 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"数千年の時を経た古代の木々が静かに見守る地|n(2-6 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Jahrtausende der Pflege brachten bei den Bauwerken der Blutsväter Bäume hervor, die fast so alt sind wie diese. 2-6 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Ces arbres ont traversé autant de millénaires que les structures forerunners autour desquelles ils poussent. 2-6 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Milenios de cuidados han creado árboles tan antiguos como las estructuras circundantes de los Forerunner. 2-6 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Milenios de cuidados han creado árboles tan antiguos como las estructuras circundantes de los Forerunner. 2-6 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Il trascorrere dei millenni ha prodotto alberi antichi quanto le strutture dei Precursori che circondano. 2-6 giocatori.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"수천 년 된 고대 시설물입니다. 2-6인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"經過數百萬年的時間，這些樹木已經跟先行者的建築一樣古老。2-6 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Milênios de cuidado produziram árvores tão antigas quanto as estruturas Forerunner em volta das quais elas cresceram.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_guardian",
                    MapName = $@"guardian",
                    MapIndex = 4,
                    MinimumDesiredPlayers = 2,
                    MaximumDesiredPlayers = 6,
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
                            Name = $@"Guardian",
                            Description = $@"Millennia of tending has produced trees as ancient as the Forerunner structures they have grown around. 2-6 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 320,
                            CampaignDifficulty = -1,
                            CampaignInsertionPoint = 0,
                        },
                        VariantVersion = 12,
                        ScenarioObjectCount = 26,
                        VariantObjectCount = 217,
                        PlaceableQuotaCount = 54,
                        MapId = 320,
                        WorldBounds = new RealRectangle3d(-43.86917f, 43.70989f, -59.25331f, 35.75649f, -53.08789f, 94.53089f),
                        RuntimeEngineSubType = VariantDataGameEngineSubType.All,
                        MaximumBudget = 13f,
                        MapVariantChecksum = 1329238095,
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
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(11.99273f, -14.73658f, 18.40429f),
                                Forward = new RealVector3d(-0.9998213f, 0.01890276f, 0f),
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
                                Position = new RealPoint3d(10.4971f, -1.709673f, 16.54753f),
                                Forward = new RealVector3d(-0.01825402f, -0.9998334f, 0f),
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
                                Position = new RealPoint3d(3.201403f, 2.969404f, 16.79392f),
                                Forward = new RealVector3d(-0.4591783f, -0.8883441f, 0f),
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
                                Position = new RealPoint3d(-6.754405f, -5.683809f, 18.67026f),
                                Forward = new RealVector3d(0.8330967f, -0.5531275f, 0f),
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
                                Position = new RealPoint3d(-8.150805f, -19.4649f, 19.00025f),
                                Forward = new RealVector3d(0.9998941f, -0.01455037f, 0f),
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
                                Position = new RealPoint3d(2.405918f, -21.503f, 16.66001f),
                                Forward = new RealVector3d(0.5657105f, 0.8246039f, 0f),
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
                                QuotaIndex = 1,
                                Position = new RealPoint3d(13.28656f, -11.90617f, 17.48428f),
                                Forward = new RealVector3d(0.03116773f, -0.8794448f, 0.4749794f),
                                Up = new RealVector3d(-0.9995142f, -0.02747206f, 0.01472154f),
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
                                    SharedStorage = 1,
                                    SpawnTime = 45,
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
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(-3.739174f, -18.44569f, 19.0386f),
                                Forward = new RealVector3d(0.9998526f, -0.01671436f, 0.003938396f),
                                Up = new RealVector3d(-0.01670634f, -0.9998583f, -0.002062552f),
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
                                    SharedStorage = 1,
                                    SpawnTime = 45,
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
                                QuotaIndex = 2,
                                Position = new RealPoint3d(1.620076f, -15.49775f, 18.57783f),
                                Forward = new RealVector3d(0.003723991f, -0.964154f, 0.265317f),
                                Up = new RealVector3d(-0.9999681f, -0.001716079f, 0.007799379f),
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
                                QuotaIndex = 3,
                                Position = new RealPoint3d(9.76653f, -14.83506f, 18.74482f),
                                Forward = new RealVector3d(0.05001986f, -0.9979224f, -0.04060622f),
                                Up = new RealVector3d(-0.9529864f, -0.05985438f, 0.2970426f),
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
                                    SharedStorage = 3,
                                    SpawnTime = 120,
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
                                QuotaIndex = 4,
                                Position = new RealPoint3d(-11.3167f, -19.52023f, 16.78646f),
                                Forward = new RealVector3d(-0.4233537f, 0.0006895125f, 0.9059643f),
                                Up = new RealVector3d(-0.0002468847f, -0.9999998f, 0.0006457129f),
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
                                    SharedStorage = 1,
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
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(-5.998668f, -6.639749f, 18.70826f),
                                Forward = new RealVector3d(0.9964736f, 0.08367316f, 0.006259763f),
                                Up = new RealVector3d(0.08372136f, -0.9964581f, -0.007881491f),
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
                                    SharedStorage = 1,
                                    SpawnTime = 45,
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
                                QuotaIndex = 5,
                                Position = new RealPoint3d(-9.679959f, -16.63537f, 18.59374f),
                                Forward = new RealVector3d(-0.05118864f, -0.968853f, 0.2422881f),
                                Up = new RealVector3d(-0.006162591f, 0.242908f, 0.9700298f),
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
                                QuotaIndex = 5,
                                Position = new RealPoint3d(6.969269f, -0.5420336f, 16.10516f),
                                Forward = new RealVector3d(0.9579221f, 0.06008006f, 0.2806699f),
                                Up = new RealVector3d(0.02856526f, 0.9530383f, -0.3014997f),
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
                                QuotaIndex = 6,
                                Position = new RealPoint3d(1.801847f, -4.371575f, 15.98308f),
                                Forward = new RealVector3d(0.9890306f, 0.1476269f, 0.004971501f),
                                Up = new RealVector3d(0.1476511f, -0.9890273f, -0.004914797f),
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
                                Position = new RealPoint3d(-7.186679f, -12.00238f, 18.2524f),
                                Forward = new RealVector3d(0.2961802f, -0.04075627f, 0.9542621f),
                                Up = new RealVector3d(0.01151248f, 0.9991689f, 0.03910103f),
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
                                QuotaIndex = 8,
                                Position = new RealPoint3d(9.386451f, -8.968952f, 18.23455f),
                                Forward = new RealVector3d(-0.3909815f, 0.4183814f, 0.8198112f),
                                Up = new RealVector3d(0.5609167f, 0.814506f, -0.1481635f),
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
                                QuotaIndex = 5,
                                Position = new RealPoint3d(6.966865f, -1.02445f, 16.10465f),
                                Forward = new RealVector3d(0.9571009f, -0.05886401f, 0.2837125f),
                                Up = new RealVector3d(0.04854964f, -0.9327264f, -0.3573015f),
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
                                QuotaIndex = 9,
                                Position = new RealPoint3d(-3.72991f, -9.970077f, 15.85518f),
                                Forward = new RealVector3d(0.9999557f, 0.009412999f, -0.0001003379f),
                                Up = new RealVector3d(-0.00941301f, 0.9999557f, -0.0001051817f),
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
                                Position = new RealPoint3d(-0.9866516f, -23.08481f, 16.7054f),
                                Forward = new RealVector3d(0.999956f, 0.007904503f, -0.005059456f),
                                Up = new RealVector3d(-0.007735473f, 0.9994385f, 0.03259921f),
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
                                    SharedStorage = 3,
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
                                Position = new RealPoint3d(2.001983f, -21.86676f, 18.92427f),
                                Forward = new RealVector3d(0.24157f, -0.1771922f, 0.9540685f),
                                Up = new RealVector3d(-0.6061597f, -0.7953219f, 0.005770189f),
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
                                QuotaIndex = 12,
                                Position = new RealPoint3d(1.975782f, 2.647555f, 16.80569f),
                                Forward = new RealVector3d(0.491267f, -0.8707461f, -0.02140265f),
                                Up = new RealVector3d(0.8496891f, 0.473694f, 0.2316084f),
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
                                    SpawnTime = 120,
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
                                Position = new RealPoint3d(-5.03926f, -14.9933f, 16.05131f),
                                Forward = new RealVector3d(0.6641662f, 0.7475848f, -0.0005595694f),
                                Up = new RealVector3d(0.7475848f, -0.6641653f, 0.001233039f),
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
                                Position = new RealPoint3d(-0.9680221f, -23.49153f, 16.70521f),
                                Forward = new RealVector3d(0.9984577f, 0.05534082f, 0.004427761f),
                                Up = new RealVector3d(0.05511008f, -0.9976167f, 0.04151832f),
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
                                    SharedStorage = 3,
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
                                QuotaIndex = 13,
                                Position = new RealPoint3d(10.56073f, -8.986858f, 16.69335f),
                                Forward = new RealVector3d(0.007717798f, 0.4218193f, 0.9066471f),
                                Up = new RealVector3d(0.9995846f, -0.02843315f, 0.004719652f),
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
                                QuotaIndex = 14,
                                Position = new RealPoint3d(1.639878f, -9.110637f, 16.83638f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
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
                                QuotaIndex = 15,
                                Position = new RealPoint3d(7.203566f, -11.74737f, 19.95238f),
                                Forward = new RealVector3d(-0.0009134569f, 4.386913E-05f, -0.9999996f),
                                Up = new RealVector3d(0.9999996f, -2.157452E-07f, -0.000913457f),
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
                                QuotaIndex = 15,
                                Position = new RealPoint3d(7.206257f, -12.09119f, 19.95238f),
                                Forward = new RealVector3d(-0.0008457461f, 3.916422E-05f, -0.9999996f),
                                Up = new RealVector3d(0.9999996f, 1.135912E-09f, -0.0008457461f),
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
                                QuotaIndex = 15,
                                Position = new RealPoint3d(-4.682471f, -7.412293f, 18.71823f),
                                Forward = new RealVector3d(0.0006904608f, -0.0003796025f, -0.9999997f),
                                Up = new RealVector3d(0.9999998f, -9.902973E-06f, 0.0006904646f),
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
                                QuotaIndex = 15,
                                Position = new RealPoint3d(-4.68807f, -7.804191f, 18.71825f),
                                Forward = new RealVector3d(0.0006904167f, -0.0003376619f, -0.9999997f),
                                Up = new RealVector3d(0.9999998f, -1.258561E-05f, 0.0006904209f),
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
                                Position = new RealPoint3d(-4.57935f, -16.22932f, 19.04461f),
                                Forward = new RealVector3d(0.5782081f, 0.6627356f, -0.4758749f),
                                Up = new RealVector3d(0.5367485f, -0.7482529f, -0.3898955f),
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
                                Position = new RealPoint3d(-4.971952f, -16.5069f, 19.04457f),
                                Forward = new RealVector3d(-0.7913908f, 0.2045838f, 0.5760608f),
                                Up = new RealVector3d(-0.4857608f, -0.7825531f, -0.3894188f),
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
                                Position = new RealPoint3d(9.348161f, -1.485899f, 16.59187f),
                                Forward = new RealVector3d(0.9127238f, 0.3943229f, 0.1069804f),
                                Up = new RealVector3d(-0.3264488f, 0.8612685f, -0.38942f),
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
                                Position = new RealPoint3d(9.673666f, -1.786859f, 16.59186f),
                                Forward = new RealVector3d(-0.3463077f, -0.9319929f, 0.1070518f),
                                Up = new RealVector3d(0.8478799f, -0.3597843f, -0.3894291f),
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
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 17,
                                Position = new RealPoint3d(-2.56376f, -16.66806f, 19.09645f),
                                Forward = new RealVector3d(0.9999162f, 0.01117599f, 0.006539793f),
                                Up = new RealVector3d(-0.006506868f, -0.002979883f, 0.9999744f),
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
                                Position = new RealPoint3d(1.253953f, -2.720607f, 18.47307f),
                                Forward = new RealVector3d(0.05799435f, -0.7090685f, -0.7027507f),
                                Up = new RealVector3d(0.9977418f, 0.06505901f, 0.01669454f),
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
                                QuotaIndex = 19,
                                Position = new RealPoint3d(-9.669745f, -4.342382f, 19.00475f),
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
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(10.2254f, -11.60365f, 18.49386f),
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
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(-0.613242f, -12.3025f, 18.10428f),
                                Forward = new RealVector3d(0.7098216f, 0.7043815f, -3.13135E-07f),
                                Up = new RealVector3d(2.015143E-07f, 2.414826E-07f, 1f),
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
                                Position = new RealPoint3d(-0.7110112f, -7.671627f, 18.10428f),
                                Forward = new RealVector3d(0.6902231f, -0.7235966f, 3.564618E-08f),
                                Up = new RealVector3d(2.015143E-07f, 2.414826E-07f, 1f),
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
                                Position = new RealPoint3d(3.937483f, -7.715191f, 18.10428f),
                                Forward = new RealVector3d(-0.7241479f, -0.6896448f, 3.124633E-07f),
                                Up = new RealVector3d(2.015143E-07f, 2.414826E-07f, 1f),
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
                                Position = new RealPoint3d(3.98954f, -12.33022f, 18.10428f),
                                Forward = new RealVector3d(-0.7017263f, 0.7124466f, -3.06356E-08f),
                                Up = new RealVector3d(2.015143E-07f, 2.414826E-07f, 1f),
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
                                Position = new RealPoint3d(-0.6285483f, 2.519371f, 16.24144f),
                                Forward = new RealVector3d(0.5970597f, -0.8021969f, 0f),
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
                                Position = new RealPoint3d(9.954692f, 0.1805066f, 16.54754f),
                                Forward = new RealVector3d(0.1827198f, -0.983165f, 0f),
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
                                Position = new RealPoint3d(11.51887f, -0.9874878f, 16.54753f),
                                Forward = new RealVector3d(-0.3772835f, -0.9260978f, 0f),
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
                                Position = new RealPoint3d(13.81819f, -15.28685f, 18.40428f),
                                Forward = new RealVector3d(-0.983236f, 0.1823373f, 1.134977E-06f),
                                Up = new RealVector3d(1.327378E-06f, 9.331578E-07f, 1f),
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
                                Position = new RealPoint3d(13.74081f, -9.094133f, 16.80426f),
                                Forward = new RealVector3d(-0.9850035f, -0.1725341f, 2.938539E-05f),
                                Up = new RealVector3d(2.622156E-05f, 2.061653E-05f, 1f),
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
                                Position = new RealPoint3d(1.008006f, -23.80081f, 16.66001f),
                                Forward = new RealVector3d(0.4873237f, 0.8732214f, 0f),
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
                                Position = new RealPoint3d(-3.848425f, -15.94003f, 16.00709f),
                                Forward = new RealVector3d(-0.8728619f, 0.4879674f, 0f),
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
                                Position = new RealPoint3d(-10.30623f, -14.4304f, 15.93222f),
                                Forward = new RealVector3d(0.221981f, 0.975051f, -3.702405E-06f),
                                Up = new RealVector3d(2.620127E-05f, -2.167864E-06f, 1f),
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
                                Position = new RealPoint3d(-7.364263f, -7.948954f, 15.93216f),
                                Forward = new RealVector3d(-0.7018129f, -0.7123613f, 1.684409E-05f),
                                Up = new RealVector3d(2.620127E-05f, -2.167864E-06f, 1f),
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
                                Position = new RealPoint3d(-10.25257f, -7.786483f, 15.93224f),
                                Forward = new RealVector3d(0.8448734f, -0.5349663f, -2.329649E-05f),
                                Up = new RealVector3d(2.620127E-05f, -2.167864E-06f, 1f),
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
                                Position = new RealPoint3d(-7.759306f, -11.75381f, 15.93216f),
                                Forward = new RealVector3d(-0.7610071f, 0.6487436f, 2.134574E-05f),
                                Up = new RealVector3d(2.620127E-05f, -2.167864E-06f, 1f),
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
                                Position = new RealPoint3d(2.21856f, -21.45601f, 18.80025f),
                                Forward = new RealVector3d(-0.1755059f, 0.9844784f, -5.846567E-07f),
                                Up = new RealVector3d(1.409524E-07f, 6.190026E-07f, 1f),
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
                                Position = new RealPoint3d(-4.672737f, -20.14856f, 19.00025f),
                                Forward = new RealVector3d(0.9810965f, 0.1935192f, 3.199752E-07f),
                                Up = new RealVector3d(-1.006405E-06f, 3.448781E-06f, 1f),
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
                                Position = new RealPoint3d(-7.641891f, -7.446349f, 18.1108f),
                                Forward = new RealVector3d(-0.3083216f, -0.9512821f, -2.693126E-07f),
                                Up = new RealVector3d(-4.02688E-07f, -1.525889E-07f, 1f),
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
                                Position = new RealPoint3d(-6.753843f, -8.265674f, 18.1108f),
                                Forward = new RealVector3d(-0.4307739f, -0.9024599f, -3.111729E-07f),
                                Up = new RealVector3d(-4.02688E-07f, -1.525889E-07f, 1f),
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
                                Position = new RealPoint3d(-10.40006f, -13.6879f, 18.1108f),
                                Forward = new RealVector3d(0.691884f, 0.7220087f, 3.887839E-07f),
                                Up = new RealVector3d(-4.02688E-07f, -1.525889E-07f, 1f),
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
                                Position = new RealPoint3d(-4.605424f, -23.76985f, 16.80025f),
                                Forward = new RealVector3d(0.04270085f, 0.9990879f, 7.577719E-06f),
                                Up = new RealVector3d(-5.995001E-06f, -7.328412E-06f, 1f),
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
                                Position = new RealPoint3d(3.317754f, -3.272605f, 15.92558f),
                                Forward = new RealVector3d(-0.571091f, -0.8208868f, 0f),
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
                                Position = new RealPoint3d(11.83504f, -11.12745f, 18.10428f),
                                Forward = new RealVector3d(-0.9597885f, 0.2807241f, 1.256211E-07f),
                                Up = new RealVector3d(2.015143E-07f, 2.414826E-07f, 1f),
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
                                Position = new RealPoint3d(11.85754f, -10.92518f, 16.52504f),
                                Forward = new RealVector3d(-0.9801245f, 0.1983835f, 0f),
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
                                Position = new RealPoint3d(13.79725f, -10.11589f, 16.80428f),
                                Forward = new RealVector3d(-0.996787f, 0.08009753f, 2.448598E-05f),
                                Up = new RealVector3d(2.622156E-05f, 2.061653E-05f, 1f),
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
                                Position = new RealPoint3d(-10.62648f, -5.318099f, 18.30025f),
                                Forward = new RealVector3d(0.9999871f, -0.005080798f, 0f),
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
                                QuotaIndex = 22,
                                Position = new RealPoint3d(10.70053f, 0.1127809f, 16.54753f),
                                Forward = new RealVector3d(-0.03116441f, -0.9995143f, 0f),
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
                                Position = new RealPoint3d(-3.947396f, -23.70753f, 16.80025f),
                                Forward = new RealVector3d(-0.05554372f, 0.9984562f, 4.858571E-06f),
                                Up = new RealVector3d(-1.00241E-05f, -5.423719E-06f, 1f),
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
                                Position = new RealPoint3d(-3.94772f, -23.69525f, 16.80025f),
                                Forward = new RealVector3d(-0.09585842f, 0.995395f, 4.437849E-06f),
                                Up = new RealVector3d(-1.00241E-05f, -5.423719E-06f, 1f),
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
                                QuotaIndex = 24,
                                Position = new RealPoint3d(10.16493f, -1.054858f, 16.54753f),
                                Forward = new RealVector3d(-0.9345162f, -0.3557981f, -0.009335619f),
                                Up = new RealVector3d(-0.007196154f, -0.007336193f, 0.9999472f),
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
                                        WidthRadius = 12f,
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
                                QuotaIndex = 24,
                                Position = new RealPoint3d(-4.353228f, -21.93724f, 16.80025f),
                                Forward = new RealVector3d(-0.9345162f, -0.3557981f, -0.009335619f),
                                Up = new RealVector3d(-0.007196154f, -0.007336193f, 0.9999472f),
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
                                        WidthRadius = 12f,
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
                                QuotaIndex = 23,
                                Position = new RealPoint3d(10.71312f, 0.1093724f, 16.54753f),
                                Forward = new RealVector3d(-0.09463046f, -0.9955125f, 0f),
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
                                QuotaIndex = 25,
                                Position = new RealPoint3d(-4.350411f, -21.94402f, 16.80025f),
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
                                        WidthRadius = 12f,
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
                                Position = new RealPoint3d(10.16992f, -1.054099f, 16.54753f),
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
                                        WidthRadius = 12f,
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
                                Position = new RealPoint3d(-3.92268f, -23.67347f, 16.80025f),
                                Forward = new RealVector3d(-0.221328f, 0.9751994f, 3.070594E-06f),
                                Up = new RealVector3d(-1.00241E-05f, -5.423719E-06f, 1f),
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
                                QuotaIndex = 26,
                                Position = new RealPoint3d(10.71103f, 0.1195607f, 16.54753f),
                                Forward = new RealVector3d(-0.08335756f, -0.9964883f, -0.007910939f),
                                Up = new RealVector3d(-0.007196078f, -0.007336437f, 0.9999472f),
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
                                QuotaIndex = 27,
                                Position = new RealPoint3d(-4.351987f, -21.93976f, 16.80025f),
                                Forward = new RealVector3d(-0.9758134f, 0.2185376f, -0.005419134f),
                                Up = new RealVector3d(-0.00719614f, -0.007336227f, 0.9999472f),
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
                                        WidthRadius = 12f,
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
                                QuotaIndex = 27,
                                Position = new RealPoint3d(10.17143f, -1.056896f, 16.54753f),
                                Forward = new RealVector3d(-0.9758134f, 0.2185376f, -0.005419134f),
                                Up = new RealVector3d(-0.00719614f, -0.007336227f, 0.9999472f),
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
                                        WidthRadius = 12f,
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
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-3.931377f, -23.66823f, 16.80025f),
                                Forward = new RealVector3d(-0.1673647f, 0.985895f, 3.669537E-06f),
                                Up = new RealVector3d(-1.00241E-05f, -5.423719E-06f, 1f),
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
                                QuotaIndex = 28,
                                Position = new RealPoint3d(10.69859f, 0.1165268f, 16.54753f),
                                Forward = new RealVector3d(-0.02527217f, -0.9996523f, -0.007516097f),
                                Up = new RealVector3d(-0.007196093f, -0.00733639f, 0.9999472f),
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
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-10.41732f, -7.412194f, 18.1108f),
                                Forward = new RealVector3d(0.8937971f, -0.4484716f, 2.914896E-07f),
                                Up = new RealVector3d(-4.02688E-07f, -1.525889E-07f, 1f),
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
                                Position = new RealPoint3d(-11.14143f, -11.808f, 16.02315f),
                                Forward = new RealVector3d(0.9113896f, 0.4115446f, 3.192043E-06f),
                                Up = new RealVector3d(-1.605537E-06f, -4.200694E-06f, 1f),
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
                                Position = new RealPoint3d(-11.20661f, -8.361166f, 16.02316f),
                                Forward = new RealVector3d(0.9673561f, -0.2534211f, 4.885821E-07f),
                                Up = new RealVector3d(-1.605537E-06f, -4.200694E-06f, 1f),
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
                                QuotaIndex = 29,
                                Position = new RealPoint3d(-3.936089f, -23.63441f, 16.80025f),
                                Forward = new RealVector3d(-0.1225245f, 0.9924655f, 4.154656E-06f),
                                Up = new RealVector3d(-1.00241E-05f, -5.423719E-06f, 1f),
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
                                QuotaIndex = 29,
                                Position = new RealPoint3d(10.71512f, 0.125462f, 16.54753f),
                                Forward = new RealVector3d(-0.04866124f, -0.9988154f, 0f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 30,
                                Position = new RealPoint3d(10.70752f, 0.1264707f, 16.54753f),
                                Forward = new RealVector3d(-0.083036f, -0.9965466f, 0f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
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
                                QuotaIndex = 30,
                                Position = new RealPoint3d(-3.948496f, -23.67892f, 16.80025f),
                                Forward = new RealVector3d(-0.128627f, 0.991693f, 4.089295E-06f),
                                Up = new RealVector3d(-1.00241E-05f, -5.423719E-06f, 1f),
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
                                QuotaIndex = 31,
                                Position = new RealPoint3d(-3.928091f, -23.68731f, 16.80025f),
                                Forward = new RealVector3d(-0.2219158f, 0.9750658f, 3.063978E-06f),
                                Up = new RealVector3d(-1.00241E-05f, -5.423719E-06f, 1f),
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
                                QuotaIndex = 31,
                                Position = new RealPoint3d(10.7166f, 0.1110185f, 16.54753f),
                                Forward = new RealVector3d(-0.1271386f, -0.9918849f, 0f),
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
                                QuotaIndex = 21,
                                Position = new RealPoint3d(9.185017f, -0.2195063f, 16.54754f),
                                Forward = new RealVector3d(0.3834299f, -0.92357f, 0f),
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
                                Position = new RealPoint3d(11.47466f, 0.1603647f, 16.54753f),
                                Forward = new RealVector3d(-0.2790262f, -0.9602835f, 0f),
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
                                Position = new RealPoint3d(-10.2729f, -18.31437f, 18.95161f),
                                Forward = new RealVector3d(0.1445585f, 0.9604833f, -0.2378544f),
                                Up = new RealVector3d(0.001592033f, 0.2401532f, 0.9707338f),
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
                                Position = new RealPoint3d(-0.5950106f, -20.10383f, 19.00026f),
                                Forward = new RealVector3d(-0.7265019f, 0.6871644f, -3.101035E-06f),
                                Up = new RealVector3d(-1.006405E-06f, 3.448781E-06f, 1f),
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
                                Position = new RealPoint3d(0.8379064f, 3.427712f, 16.62997f),
                                Forward = new RealVector3d(0.1459479f, -0.9829931f, -0.1114625f),
                                Up = new RealVector3d(-0.1669392f, -0.1355245f, 0.9766086f),
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
                                Position = new RealPoint3d(0.8265193f, -0.7494384f, 15.96136f),
                                Forward = new RealVector3d(0.999599f, 0.02831566f, 0f),
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
                                Position = new RealPoint3d(1.629835f, -8.415235f, 16.31508f),
                                Forward = new RealVector3d(0.01606296f, 0.999871f, 4.53997E-06f),
                                Up = new RealVector3d(-4.950313E-09f, -4.540477E-06f, 1f),
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
                                Position = new RealPoint3d(2.37944f, 0.09927399f, 15.92548f),
                                Forward = new RealVector3d(-0.01111513f, -0.9999382f, 0f),
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
                                Position = new RealPoint3d(3.985392f, 2.010696f, 16.64725f),
                                Forward = new RealVector3d(-0.3050825f, -0.9104874f, -0.2791726f),
                                Up = new RealVector3d(0.1546457f, -0.3366223f, 0.9288542f),
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
                                Position = new RealPoint3d(-5.26485f, -23.7645f, 16.80024f),
                                Forward = new RealVector3d(0.2103947f, 0.9776165f, 8.425693E-06f),
                                Up = new RealVector3d(-5.995001E-06f, -7.328412E-06f, 1f),
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
                                Position = new RealPoint3d(3.021817f, -22.53799f, 16.66001f),
                                Forward = new RealVector3d(0.2830942f, 0.9590921f, 0f),
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
                                Position = new RealPoint3d(7.705989f, -9.328078f, 16.32545f),
                                Forward = new RealVector3d(-0.9844743f, -0.1755287f, 1.282296E-05f),
                                Up = new RealVector3d(1.257121E-05f, 2.546141E-06f, 1f),
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
                                Position = new RealPoint3d(-5.919967f, -10.7394f, 15.80024f),
                                Forward = new RealVector3d(0.9885452f, 0.1509251f, 0f),
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
                                Position = new RealPoint3d(-2.731197f, -23.74444f, 16.66002f),
                                Forward = new RealVector3d(-0.6676596f, 0.7444667f, 0f),
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
                                Position = new RealPoint3d(-5.181137f, -22.38466f, 16.80025f),
                                Forward = new RealVector3d(0.2370531f, 0.9714967f, 8.540661E-06f),
                                Up = new RealVector3d(-5.995001E-06f, -7.328412E-06f, 1f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-4.64398f, -17.72292f, 19.00025f),
                                Forward = new RealVector3d(0.9402601f, -0.340457f, 2.120444E-06f),
                                Up = new RealVector3d(-1.006405E-06f, 3.448781E-06f, 1f),
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
                                Position = new RealPoint3d(-0.2322063f, -10.75383f, 16.31507f),
                                Forward = new RealVector3d(0.2852957f, 0.9584395f, 4.353185E-06f),
                                Up = new RealVector3d(-4.950313E-09f, -4.540477E-06f, 1f),
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
                                Position = new RealPoint3d(3.541716f, -10.7769f, 16.31507f),
                                Forward = new RealVector3d(-0.3343445f, 0.9424509f, 4.277521E-06f),
                                Up = new RealVector3d(-4.950313E-09f, -4.540477E-06f, 1f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(10.70618f, 0.08719756f, 16.54753f),
                                Forward = new RealVector3d(-0.03116441f, -0.9995143f, 0f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Infection,
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
                                QuotaIndex = 32,
                                Position = new RealPoint3d(-3.938014f, -23.67041f, 16.80025f),
                                Forward = new RealVector3d(-0.1153342f, 0.9933267f, 0f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Infection,
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
                                QuotaIndex = 33,
                                Position = new RealPoint3d(1.638155f, -9.99947f, 18.25595f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
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
                                QuotaIndex = 33,
                                Position = new RealPoint3d(-2.277207f, -18.59051f, 18.98879f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
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
                                QuotaIndex = 33,
                                Position = new RealPoint3d(2.676738f, -0.8378533f, 15.92551f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
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
                                QuotaIndex = 33,
                                Position = new RealPoint3d(10.94789f, -10.01315f, 18.10428f),
                                Forward = new RealVector3d(-0.007036075f, 0.9999753f, 0f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
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
                                QuotaIndex = 33,
                                Position = new RealPoint3d(-8.23176f, -10.04379f, 15.80023f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
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
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(1.644876f, -10.00361f, 18.20035f),
                                Forward = new RealVector3d(0.3280418f, -0.9446632f, 0f),
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
                                        WidthRadius = 3.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.3f,
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
                                QuotaIndex = 34,
                                Position = new RealPoint3d(-2.697071f, -18.21298f, 19.00025f),
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
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 4.5f,
                                        BoxLength = 4.3f,
                                        PositiveHeight = 1.6f,
                                        NegativeHeight = 0.3f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(10.43644f, -0.8618492f, 16.54753f),
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
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 3.5f,
                                        BoxLength = 3.5f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(-8.265256f, -9.996586f, 18.10429f),
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
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 2.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 0.6f,
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
                                Position = new RealPoint3d(-4.400573f, -19.39963f, 16.66001f),
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
                                        PositiveHeight = 1.7f,
                                        NegativeHeight = 0.7f,
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
                                Position = new RealPoint3d(10.4397f, -4.607819f, 17.32392f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0.3389128f, 0.9408178f),
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
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0.2f,
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
                                Position = new RealPoint3d(-8.307938f, -10.01167f, 18.0608f),
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
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0.2f,
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
                                Position = new RealPoint3d(-4.499673f, -21.58215f, 16.80025f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
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
                                QuotaIndex = 37,
                                Position = new RealPoint3d(-4.492015f, -22.331f, 16.80025f),
                                Forward = new RealVector3d(0.9997276f, 0.02333899f, 0f),
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
                                    Flags = VariantDataPlacementFlags.Symmetric,
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
                                QuotaIndex = 36,
                                Position = new RealPoint3d(9.85139f, -1.310586f, 16.54753f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
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
                                    Flags = VariantDataPlacementFlags.Symmetric,
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
                                QuotaIndex = 37,
                                Position = new RealPoint3d(10.40253f, -0.847494f, 16.54753f),
                                Forward = new RealVector3d(-0.6983151f, 0.7157905f, 0f),
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
                                QuotaIndex = 38,
                                Position = new RealPoint3d(-0.7246749f, -17.34432f, 19.01504f),
                                Forward = new RealVector3d(0.4671829f, -0.8841603f, -0.0008473686f),
                                Up = new RealVector3d(-0.001553571f, -0.001779279f, 0.9999972f),
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
                                Position = new RealPoint3d(-1.298322f, -16.74444f, 19.01614f),
                                Forward = new RealVector3d(-0.2449943f, -0.96952f, 0.002990103f),
                                Up = new RealVector3d(0.001756629f, 0.002640197f, 0.999995f),
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
                                Position = new RealPoint3d(8.487699f, -12.36946f, 19.91982f),
                                Forward = new RealVector3d(-0.9454949f, 0.3256366f, 0.0003015545f),
                                Up = new RealVector3d(0.0003048674f, -4.085516E-05f, 0.9999999f),
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
                                Position = new RealPoint3d(-4.508456f, -21.59392f, 16.80025f),
                                Forward = new RealVector3d(-0.02254681f, 0.9997458f, 0f),
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
                                QuotaIndex = 40,
                                Position = new RealPoint3d(1.988286f, -22.17147f, 16.65903f),
                                Forward = new RealVector3d(0.7310817f, 0.6822899f, 0f),
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
                                QuotaIndex = 39,
                                Position = new RealPoint3d(9.849417f, -1.31374f, 16.54753f),
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
                                QuotaIndex = 40,
                                Position = new RealPoint3d(2.682783f, -0.8410508f, 15.92551f),
                                Forward = new RealVector3d(-0.9998851f, -0.01516085f, 0f),
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
                                QuotaIndex = 39,
                                Position = new RealPoint3d(1.636794f, -9.996097f, 18.25595f),
                                Forward = new RealVector3d(0.3953617f, -0.9185255f, 0f),
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
                                    Flags = VariantDataPlacementFlags.Symmetric,
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
                                QuotaIndex = 35,
                                Position = new RealPoint3d(13.21611f, -14.75602f, 18.40428f),
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
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 1.2f,
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
                                Position = new RealPoint3d(1.636065f, -10.02761f, 16.44798f),
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
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.3f,
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(1.63797f, -9.998966f, 18.25595f),
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(1.997579f, -22.16476f, 16.65903f),
                                Forward = new RealVector3d(0.7734061f, 0.6339109f, 0f),
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(11.10833f, -9.897659f, 16.52504f),
                                Forward = new RealVector3d(-0.03138854f, 0.9995072f, 0f),
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(2.674724f, -0.8376058f, 15.92551f),
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(-8.229012f, -10.04194f, 15.80023f),
                                Forward = new RealVector3d(-0.004404813f, -0.9999903f, 0f),
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
                                QuotaIndex = 42,
                                Position = new RealPoint3d(-8.234791f, -10.04177f, 15.80023f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
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
                                QuotaIndex = 42,
                                Position = new RealPoint3d(2.677573f, -0.8405412f, 15.92551f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
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
                                QuotaIndex = 42,
                                Position = new RealPoint3d(10.93772f, -10.00733f, 18.10428f),
                                Forward = new RealVector3d(0.008541079f, 0.9999635f, 0f),
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
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
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
                                QuotaIndex = 42,
                                Position = new RealPoint3d(1.9956f, -22.16566f, 16.65913f),
                                Forward = new RealVector3d(0.7766746f, 0.629902f, 0f),
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
                                QuotaIndex = 42,
                                Position = new RealPoint3d(1.637981f, -10.00112f, 18.25595f),
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
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
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
                                QuotaIndex = 35,
                                Position = new RealPoint3d(10.93462f, -10.00604f, 18.10428f),
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
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.2f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 0.1f,
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
                                Position = new RealPoint3d(2.276795f, -0.7224303f, 15.92549f),
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
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
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
                                QuotaIndex = 35,
                                Position = new RealPoint3d(-9.353544f, -5.743694f, 18.30025f),
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
                                        PositiveHeight = 1.7f,
                                        NegativeHeight = 0.4f,
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
                                Position = new RealPoint3d(-5.828386f, -9.995379f, 15.81068f),
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
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3.2f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.8f,
                                        NegativeHeight = 0.2f,
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
                                Position = new RealPoint3d(-2.283033f, -17.81218f, 18.98879f),
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
                                        PositiveHeight = 1.7f,
                                        NegativeHeight = 0.2f,
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-9.392118f, -20.75286f, 19.98137f),
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
                                    SpawnTime = 180,
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
                                Position = new RealPoint3d(-10.1566f, -20.75286f, 19.98137f),
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
                                    SpawnTime = 180,
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
                                Position = new RealPoint3d(1.932927f, 3.786075f, 16.79799f),
                                Forward = new RealVector3d(-0.9331791f, 0.3594091f, 0.0013984f),
                                Up = new RealVector3d(0.001701474f, 0.000526925f, 0.9999985f),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 44,
                                Position = new RealPoint3d(9.49746f, -13.41926f, 24.26809f),
                                Forward = new RealVector3d(-0.8268212f, -0.4473831f, 0.3409033f),
                                Up = new RealVector3d(0.3034873f, 0.1554447f, 0.9400704f),
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
                                Position = new RealPoint3d(-9.142056f, -4.887459f, 55.68275f),
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
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-6.845149f, -6.04046f, 55.71556f),
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
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-8.723669f, -8.279024f, 54.97181f),
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
                                QuotaIndex = 48,
                                Position = new RealPoint3d(-8.699773f, -10.111f, 55.15501f),
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
                                QuotaIndex = 49,
                                Position = new RealPoint3d(0.7161674f, -21.51035f, 21.25197f),
                                Forward = new RealVector3d(0.2002487f, -0.1083633f, -0.9737341f),
                                Up = new RealVector3d(0.4212781f, 0.9068191f, -0.01428062f),
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
                                Position = new RealPoint3d(-8.46939f, -8.952744f, 53.43159f),
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
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-2.401586f, -15.68233f, 17.27177f),
                                Forward = new RealVector3d(0.9864181f, 0.1449683f, 0.07722411f),
                                Up = new RealVector3d(-0.09350775f, 0.1090924f, 0.9896237f),
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
                                QuotaIndex = 52,
                                Position = new RealPoint3d(-0.4010385f, -23.78646f, 20.99068f),
                                Forward = new RealVector3d(0.8356363f, -0.5488656f, -0.02141458f),
                                Up = new RealVector3d(-0.01571494f, -0.06285976f, 0.9978987f),
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
                                Position = new RealPoint3d(12.67134f, -11.41424f, 24.33341f),
                                Forward = new RealVector3d(0.9981897f, 0.02473366f, 0.05482357f),
                                Up = new RealVector3d(-0.05503288f, 0.00786184f, 0.9984536f),
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
                                Position = new RealPoint3d(0.34332f, -17.78012f, 22.40526f),
                                Forward = new RealVector3d(0.7234899f, 0.6748416f, 0.1454346f),
                                Up = new RealVector3d(-0.1477403f, -0.05443064f, 0.9875273f),
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
                                Position = new RealPoint3d(-9.111269f, -11.39252f, 51.95753f),
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
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-8.310587f, -9.380576f, 52.40536f),
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
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-8.510853f, -6.871422f, 52.7969f),
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
                                QuotaIndex = 48,
                                Position = new RealPoint3d(-8.393456f, -7.080241f, 51.96556f),
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
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-0.9983963f, -11.79408f, 16.88208f),
                                Forward = new RealVector3d(0.8402183f, 0.4717183f, 0.2674233f),
                                Up = new RealVector3d(-0.2427449f, -0.1137867f, 0.9633938f),
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
                                Position = new RealPoint3d(-1.892428f, -14.6559f, 21.42541f),
                                Forward = new RealVector3d(0.613067f, 0.6864861f, -0.3910062f),
                                Up = new RealVector3d(-0.7554039f, 0.6542869f, -0.03568837f),
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
                                Position = new RealPoint3d(11.56483f, -13.20179f, 21.49749f),
                                Forward = new RealVector3d(7.66258E-11f, -0.9984845f, -0.05503457f),
                                Up = new RealVector3d(0.02357969f, -0.05501927f, 0.9982069f),
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
                                QuotaIndex = 52,
                                Position = new RealPoint3d(12.54305f, -11.34175f, 21.48173f),
                                Forward = new RealVector3d(0.9724839f, 0.007657354f, -0.2328441f),
                                Up = new RealVector3d(0.007873772f, -0.999969f, 0f),
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
                                Position = new RealPoint3d(10.98618f, -13.93682f, 23.14859f),
                                Forward = new RealVector3d(0.09856776f, -0.8384827f, -0.5359394f),
                                Up = new RealVector3d(0.06647637f, -0.5318109f, 0.8442499f),
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
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
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
                            -1, 7, -1, -1, -1, 0,
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
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 0,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\smg\smg").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol").Index,
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
                                MaximumCount = 4,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\assault_rifle\assault_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 15,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\superflare_equipment\superflare_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 0,
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
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_blue\powerup_blue").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_red\powerup_red").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 47,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_initial_spawn_point").Index,
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
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\infection\infection_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\oddball\oddball_ball_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\koth\koth_hill_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 4,
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
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\covenant\military\battery\battery").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
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
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\juggernaut\juggernaut_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\vip\vip_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\forerunner\power_core_for\power_core_for").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
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