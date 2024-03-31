using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class s3d_reactor : MapVariantFile
    {
        public s3d_reactor(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\s3d_reactor\s3d_reactor");
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
                    MapId = 700,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer | BlfDataScenarioFlags.IsDlc,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Reactor",
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
                            Name = $@"Being constructed just prior to the Invasion, its builders had to evacuate before it was completed. 6-16 players.",
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
                    ImageName = $@"m_s3d_reactor",
                    MapName = $@"s3d_reactor",
                    MapIndex = 14,
                    MinimumDesiredPlayers = 2,
                    MaximumDesiredPlayers = 8,
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
                            Name = $@"Reactor",
                            Description = $@"Being constructed just prior to the Invasion, its builders had to evacuate before it was completed. 6-16 players.",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1510964582,
                            CampaignId = -1,
                            MapId = 700,
                            CampaignDifficulty = -1,
                            CampaignInsertionPoint = 0,
                        },
                        VariantVersion = 12,
                        ScenarioObjectCount = 22,
                        VariantObjectCount = 225,
                        PlaceableQuotaCount = 67,
                        MapId = 700,
                        WorldBounds = new RealRectangle3d(-754.2204f, 749.6592f, -476.3346f, 752.8756f, -271.7563f, 340.2927f),
                        RuntimeEngineSubType = VariantDataGameEngineSubType.All,
                        MaximumBudget = 13f,
                        SpentBudget = -2f,
                        RuntimeShowHelpers = true,
                        MapVariantChecksum = 3809790297,
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
                                Position = new RealPoint3d(20.4977f, -2.825736f, 0.5744153f),
                                Forward = new RealVector3d(0.4000058f, -0.9036511f, -0.1530029f),
                                Up = new RealVector3d(0.09761562f, -0.1239849f, 0.9874709f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                Flags = 0,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 0,
                                Position = new RealPoint3d(6.227197f, -24.23106f, -0.1407727f),
                                Forward = new RealVector3d(0.3830944f, -0.9160872f, 0.1184177f),
                                Up = new RealVector3d(0.1151849f, 0.1745744f, 0.9778835f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(-20.18267f, -17.67652f, 0.175494f),
                                Forward = new RealVector3d(0.6487108f, -0.7603339f, 0.03265862f),
                                Up = new RealVector3d(-0.1185712f, -0.05858831f, 0.9912155f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 100,
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
                                QuotaIndex = 35,
                                Position = new RealPoint3d(-21.75099f, -14.90635f, 1.728423f),
                                Forward = new RealVector3d(0.7194385f, -0.6945562f, 0f),
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
                                    SpawnTime = 120,
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
                                QuotaIndex = 35,
                                Position = new RealPoint3d(15.70555f, 22.75234f, 1.744111f),
                                Forward = new RealVector3d(0.7957992f, -0.6055606f, 0f),
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
                                    SpawnTime = 120,
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
                                QuotaIndex = 34,
                                Position = new RealPoint3d(18.83375f, 21.05518f, 0.2696005f),
                                Forward = new RealVector3d(0.7064298f, -0.7068686f, -0.03596766f),
                                Up = new RealVector3d(0.1748828f, 0.1250812f, 0.9766119f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 100,
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
                                QuotaIndex = 36,
                                Position = new RealPoint3d(24.1215f, -22.37496f, -0.6860366f),
                                Forward = new RealVector3d(-0.6035464f, 0.791073f, -0.09967628f),
                                Up = new RealVector3d(-0.05264838f, 0.08519994f, 0.9949719f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 180,
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
                                QuotaIndex = 37,
                                Position = new RealPoint3d(-25.35402f, -0.5842586f, 0.06954513f),
                                Forward = new RealVector3d(0.580219f, -0.8072364f, -0.1082373f),
                                Up = new RealVector3d(-0.02663294f, -0.1516283f, 0.9880787f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 37,
                                Position = new RealPoint3d(1.347548f, 25.88392f, 0.1148143f),
                                Forward = new RealVector3d(0.7053002f, -0.7060786f, -0.06328127f),
                                Up = new RealVector3d(0.05521336f, -0.03428159f, 0.9978859f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
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
                                QuotaIndex = 38,
                                Position = new RealPoint3d(9.905678f, 9.998495f, 2.524776f),
                                Forward = new RealVector3d(-0.2207773f, 0.9753242f, -0.0004208082f),
                                Up = new RealVector3d(-0.9753237f, -0.2207776f, -0.000926961f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 39,
                                Position = new RealPoint3d(-11.43957f, 1.759063f, 0.02305352f),
                                Forward = new RealVector3d(0.3918147f, -0.9200324f, -0.004655895f),
                                Up = new RealVector3d(0.889181f, 0.3773666f, 0.2587501f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SharedStorage = 2,
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
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(-0.7893411f, 12.47258f, -0.003091391f),
                                Forward = new RealVector3d(0.9134918f, -0.4066072f, -0.01425675f),
                                Up = new RealVector3d(-0.4065579f, -0.9136031f, 0.006332959f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SharedStorage = 2,
                                    SpawnTime = 60,
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
                                QuotaIndex = 38,
                                Position = new RealPoint3d(-8.564981f, -9.036895f, 2.524765f),
                                Forward = new RealVector3d(0.867148f, -0.4980505f, -6.63465E-05f),
                                Up = new RealVector3d(0.4980505f, 0.867148f, -2.15393E-05f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
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
                                QuotaIndex = 40,
                                Position = new RealPoint3d(15.92107f, -14.19686f, -0.09156395f),
                                Forward = new RealVector3d(-0.4354037f, 0.5615951f, 0.7035869f),
                                Up = new RealVector3d(-0.659835f, -0.7307588f, 0.1749549f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SharedStorage = 1,
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
                                QuotaIndex = 41,
                                Position = new RealPoint3d(6.783807f, -5.787449f, 2.638159f),
                                Forward = new RealVector3d(0.5078049f, -0.5925918f, 0.6252753f),
                                Up = new RealVector3d(0.7362034f, 0.6754407f, 0.04224202f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SharedStorage = 2,
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
                                QuotaIndex = 42,
                                Position = new RealPoint3d(2.163655f, -1.157214f, 1.880365f),
                                Forward = new RealVector3d(0.2375375f, -0.971324f, -0.01027835f),
                                Up = new RealVector3d(-0.9711771f, -0.2376904f, 0.0178415f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(3.161657f, -1.967029f, -0.07691192f),
                                Forward = new RealVector3d(0.7874011f, 0.2236132f, -0.5744534f),
                                Up = new RealVector3d(0.5853239f, -0.5635462f, 0.5829337f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(3.012162f, -2.153052f, -0.07676696f),
                                Forward = new RealVector3d(0.7255745f, 0.3750497f, -0.576957f),
                                Up = new RealVector3d(0.6871495f, -0.4399309f, 0.5781751f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-28.7029f, -12.41784f, 0.37438f),
                                Forward = new RealVector3d(-0.0005619355f, -0.001015848f, -0.9999993f),
                                Up = new RealVector3d(-0.5011747f, -0.8653453f, 0.001160688f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 44,
                                Position = new RealPoint3d(-28.29738f, -12.61652f, 0.3753868f),
                                Forward = new RealVector3d(0.1709968f, -0.7343366f, -0.6568941f),
                                Up = new RealVector3d(0.9818878f, 0.0718004f, 0.1753312f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(15.5557f, -14.70846f, -0.292597f),
                                Forward = new RealVector3d(0.1628305f, 0.7721342f, -0.6142434f),
                                Up = new RealVector3d(0.1140583f, 0.6036474f, 0.7890504f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 44,
                                Position = new RealPoint3d(16.24862f, -13.97571f, -0.2872954f),
                                Forward = new RealVector3d(0.876378f, -0.4405633f, -0.1945909f),
                                Up = new RealVector3d(-0.4390747f, -0.8968789f, 0.05311926f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 44,
                                Position = new RealPoint3d(1.69628f, 10.6845f, 2.266578f),
                                Forward = new RealVector3d(0.06077424f, -0.6222158f, 0.7804831f),
                                Up = new RealVector3d(0.9674377f, 0.2291981f, 0.1073891f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(15.44717f, 27.27371f, 0.3766959f),
                                Forward = new RealVector3d(-0.002348338f, 0.0002126814f, -0.9999972f),
                                Up = new RealVector3d(-0.5667116f, -0.8239154f, 0.001155602f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(15.28242f, 27.49771f, 0.3839354f),
                                Forward = new RealVector3d(0.02091503f, -0.0183667f, -0.9996125f),
                                Up = new RealVector3d(-0.5702598f, -0.8214583f, 0.003161699f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 44,
                                Position = new RealPoint3d(1.201722f, 11.1894f, 2.269702f),
                                Forward = new RealVector3d(-0.6800746f, -0.2433938f, 0.6915621f),
                                Up = new RealVector3d(0.4973063f, -0.8462411f, 0.1912128f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 44,
                                Position = new RealPoint3d(-9.532763f, -0.8086588f, 2.275873f),
                                Forward = new RealVector3d(0.2867643f, -0.6661408f, 0.6884931f),
                                Up = new RealVector3d(-0.9576781f, -0.2179939f, 0.187966f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 44,
                                Position = new RealPoint3d(-10.04164f, -0.2851061f, 2.27876f),
                                Forward = new RealVector3d(-0.02002295f, -0.2247698f, 0.9742061f),
                                Up = new RealVector3d(0.988673f, 0.1405143f, 0.05273989f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(13.01223f, 29.64043f, 0.3698246f),
                                Forward = new RealVector3d(0.807665f, 0.07753594f, 0.5845216f),
                                Up = new RealVector3d(-0.3445194f, -0.7424466f, 0.5745255f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 44,
                                Position = new RealPoint3d(13.26114f, 29.41043f, 0.3767408f),
                                Forward = new RealVector3d(0.3221797f, -0.4827248f, -0.8143567f),
                                Up = new RealVector3d(-0.7072206f, -0.6945747f, 0.1319278f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-4.30884f, 5.24828f, 2.01689f),
                                Forward = new RealVector3d(0.4201992f, -0.1117995f, 0.9005185f),
                                Up = new RealVector3d(0.8957971f, 0.2095116f, -0.3919852f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-23.78771f, -12.06098f, 1.771076f),
                                Forward = new RealVector3d(0.7159945f, 0.6981058f, 0.000422036f),
                                Up = new RealVector3d(-0.01818805f, 0.01804977f, 0.9996716f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(-26.43977f, -8.303192f, 1.768288f),
                                Forward = new RealVector3d(0.7025612f, 0.711623f, 0.000763745f),
                                Up = new RealVector3d(-0.00382567f, 0.002703723f, 0.999989f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(13.03633f, 25.08142f, 1.765655f),
                                Forward = new RealVector3d(0.7266998f, 0.686946f, -0.003542749f),
                                Up = new RealVector3d(0.002030854f, 0.00300883f, 0.9999934f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(8.999587f, 27.44857f, 1.771518f),
                                Forward = new RealVector3d(0.7367549f, 0.6761128f, -0.007977481f),
                                Up = new RealVector3d(0.004041425f, 0.007394709f, 0.9999645f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(17.54313f, 4.56418f, 2.516104f),
                                Forward = new RealVector3d(0.9999877f, 0.004679539f, 0.001633466f),
                                Up = new RealVector3d(-0.001741616f, 0.02320118f, 0.9997293f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 10,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(-3.583899f, -15.83754f, 2.518265f),
                                Forward = new RealVector3d(0.0002181078f, 0.9999997f, -0.0007543793f),
                                Up = new RealVector3d(0.00366171f, 0.0007535756f, 0.999993f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 10,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(22.43552f, 6.989552f, 0.1895377f),
                                Forward = new RealVector3d(0.04681892f, 0.9933758f, -0.1049406f),
                                Up = new RealVector3d(0.001465514f, 0.1049874f, 0.9944724f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(-6.42867f, -21.47132f, 0.2489633f),
                                Forward = new RealVector3d(0.9988155f, 8.559749E-05f, 0.04865778f),
                                Up = new RealVector3d(-0.0482663f, 0.1283506f, 0.9905536f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(1.478464f, 11.00358f, 2.240461f),
                                Forward = new RealVector3d(0.6709411f, -0.7415081f, 0.001962715f),
                                Up = new RealVector3d(0.0006895271f, 0.003270816f, 0.9999944f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(-9.822216f, -0.5624428f, 2.246305f),
                                Forward = new RealVector3d(0.7004532f, -0.7136909f, -0.003252527f),
                                Up = new RealVector3d(-0.003780713f, -0.008267731f, 0.9999587f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(-31.67269f, -0.8479142f, 0.05396838f),
                                Forward = new RealVector3d(-0.03264659f, -0.9994669f, 0.0003174921f),
                                Up = new RealVector3d(0.001480338f, 0.0002693073f, 0.9999989f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(0.5066887f, 30.22454f, 0.05290274f),
                                Forward = new RealVector3d(0.0001377622f, 0.9999999f, -0.0003092249f),
                                Up = new RealVector3d(0.0009360014f, 0.0003090958f, 0.9999995f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                    SpawnTime = 5,
                                    Type = VariantDataMultiplayerObjectType.Equipment,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
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
                                Position = new RealPoint3d(-26.22347f, -14.78751f, 0.3722644f),
                                Forward = new RealVector3d(0.1767828f, -0.6926709f, -0.6992531f),
                                Up = new RealVector3d(0.9810546f, 0.06680826f, 0.1818476f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 43,
                                Position = new RealPoint3d(-26.55341f, -14.41241f, 0.3693722f),
                                Forward = new RealVector3d(0.4175907f, -0.7021334f, -0.5767381f),
                                Up = new RealVector3d(0.8183785f, 0.01483787f, 0.574488f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(14.1808f, 25.0064f, 1.8f),
                                Forward = new RealVector3d(-0.6775337f, -0.7349716f, -0.02765648f),
                                Up = new RealVector3d(-0.03243248f, -0.007710517f, 0.9994442f),
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
                                QuotaIndex = 48,
                                Position = new RealPoint3d(-23.52909f, -13.31973f, 1.74716f),
                                Forward = new RealVector3d(0.5948911f, 0.8038062f, 1.069161E-09f),
                                Up = new RealVector3d(-1.503607E-09f, -2.173144E-10f, 1f),
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
                                QuotaIndex = 49,
                                Position = new RealPoint3d(14.88772f, 34.16068f, 0.4106543f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 18f,
                                        BoxLength = 0f,
                                        PositiveHeight = -1f,
                                        NegativeHeight = -1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-32.43422f, -15.26157f, 0.3325922f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 18f,
                                        BoxLength = 0f,
                                        PositiveHeight = -1f,
                                        NegativeHeight = -1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(-23.48832f, -13.59245f, 1.8f),
                                Forward = new RealVector3d(0.6981996f, 0.7159032f, 2.138556E-06f),
                                Up = new RealVector3d(3.335838E-07f, -3.312549E-06f, 1f),
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
                                QuotaIndex = 50,
                                Position = new RealPoint3d(14.2578f, 24.90845f, 1.8f),
                                Forward = new RealVector3d(-0.4974806f, -0.8674751f, 0f),
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
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-23.3927f, -13.51778f, 1.761369f),
                                Forward = new RealVector3d(0.6148992f, 0.7867418f, -0.05418798f),
                                Up = new RealVector3d(0.08778476f, 0f, 0.9961395f),
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
                                QuotaIndex = 51,
                                Position = new RealPoint3d(14.30929f, 25.02424f, 1.753329f),
                                Forward = new RealVector3d(-0.8028349f, -0.5962014f, 0f),
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
                                QuotaIndex = 52,
                                Position = new RealPoint3d(14.24165f, 25.11112f, 1.753437f),
                                Forward = new RealVector3d(-0.5609555f, -0.827846f, 0f),
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
                                QuotaIndex = 52,
                                Position = new RealPoint3d(-23.40058f, -13.51334f, 1.753417f),
                                Forward = new RealVector3d(0.691089f, 0.7227697f, 2.456817E-09f),
                                Up = new RealVector3d(4.610995E-10f, -3.840058E-09f, 1f),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-27.5903f, -12.96021f, 0.3281032f),
                                Forward = new RealVector3d(-0.7779251f, 0.6283571f, 3.390914E-09f),
                                Up = new RealVector3d(6.561645E-09f, 2.727039E-09f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-28.57491f, -11.98959f, 0.3281032f),
                                Forward = new RealVector3d(-0.6475958f, 0.7619841f, 2.476242E-06f),
                                Up = new RealVector3d(-8.859119E-06f, -1.077893E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-26.55763f, -11.80448f, 0.341242f),
                                Forward = new RealVector3d(0.7113823f, 0.7028052f, 2.476244E-06f),
                                Up = new RealVector3d(-1.141169E-05f, 8.027589E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-22.45801f, -8.222339f, 0.05284126f),
                                Forward = new RealVector3d(0.4120049f, 0.9111816f, 2.476236E-06f),
                                Up = new RealVector3d(-1.353157E-05f, 3.400897E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-30.34538f, -10.62698f, 0.1013003f),
                                Forward = new RealVector3d(-0.704003f, 0.7101969f, 2.476227E-06f),
                                Up = new RealVector3d(-8.008362E-06f, -1.142519E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-24.84733f, -11.69333f, 0.3281032f),
                                Forward = new RealVector3d(0.4035596f, -0.9149534f, 9.200489E-06f),
                                Up = new RealVector3d(-1.330993E-05f, 4.185064E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-28.15622f, -15.93498f, -0.05821738f),
                                Forward = new RealVector3d(0.7487571f, -0.6628445f, 9.200467E-06f),
                                Up = new RealVector3d(-1.384152E-05f, -1.755267E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-25.87167f, -12.5827f, 1.75341f),
                                Forward = new RealVector3d(0.7653234f, -0.6436459f, 9.200481E-06f),
                                Up = new RealVector3d(-1.379258E-05f, -2.105661E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-27.79541f, -12.62469f, 1.753405f),
                                Forward = new RealVector3d(0.6883055f, -0.725421f, 9.200477E-06f),
                                Up = new RealVector3d(-1.394172E-05f, -5.454537E-07f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-26.91668f, -13.82729f, 0.3281042f),
                                Forward = new RealVector3d(0.897457f, -0.4411019f, 1.240457E-05f),
                                Up = new RealVector3d(-1.394995E-05f, -2.605048E-07f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-19.91461f, -14.1861f, 0.07380077f),
                                Forward = new RealVector3d(0.7609732f, -0.6487833f, 9.200482E-06f),
                                Up = new RealVector3d(-1.380642E-05f, -2.012746E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-18.5906f, -13.59311f, 0.1619692f),
                                Forward = new RealVector3d(-0.6643391f, -0.7464041f, -0.03917225f),
                                Up = new RealVector3d(0.0004415891f, -0.05280112f, 0.998605f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(13.88798f, 28.34921f, 1.753426f),
                                Forward = new RealVector3d(0.5645666f, -0.8253875f, 9.200474E-06f),
                                Up = new RealVector3d(-1.38518E-05f, 1.6722E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(16.448f, 25.14032f, 1.753448f),
                                Forward = new RealVector3d(-0.7435817f, -0.6686447f, -0.0006802854f),
                                Up = new RealVector3d(0.0002942008f, -0.001344581f, 0.999999f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(15.06042f, 24.46056f, 1.753444f),
                                Forward = new RealVector3d(-0.6066203f, -0.7949917f, 9.200461E-06f),
                                Up = new RealVector3d(-2.757515E-06f, 1.367716E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(13.79993f, 26.63409f, 1.763557f),
                                Forward = new RealVector3d(0.7383662f, -0.6743999f, 9.200469E-06f),
                                Up = new RealVector3d(-1.386713E-05f, -1.53996E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(13.53836f, 29.09704f, 0.3281031f),
                                Forward = new RealVector3d(-0.7444756f, 0.6676497f, 9.200469E-06f),
                                Up = new RealVector3d(1.385252E-05f, 1.666135E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(14.43952f, 20.39959f, 0.1596353f),
                                Forward = new RealVector3d(0.5580119f, -0.8298329f, -8.999723E-06f),
                                Up = new RealVector3d(1.386949E-05f, -1.518838E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(11.7332f, 26.96405f, 0.3281032f),
                                Forward = new RealVector3d(-0.8104111f, -0.5858616f, 1.6433E-07f),
                                Up = new RealVector3d(1.291353E-07f, 1.018624E-07f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(12.56639f, 29.98323f, 0.3281031f),
                                Forward = new RealVector3d(-0.7450643f, 0.6669926f, -0.0003652933f),
                                Up = new RealVector3d(-0.0006051754f, -0.0001283394f, 0.9999998f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(14.4716f, 27.80449f, 0.3281032f),
                                Forward = new RealVector3d(0.7019523f, -0.712224f, -8.999719E-06f),
                                Up = new RealVector3d(1.391097E-05f, 1.074266E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(13.0361f, 26.62166f, 0.3281032f),
                                Forward = new RealVector3d(0.9684116f, -0.2493572f, -8.999714E-06f),
                                Up = new RealVector3d(1.137403E-05f, 8.080898E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(22.33204f, 6.305311f, 0.239663f),
                                Forward = new RealVector3d(-0.1990453f, 0.9798952f, 0.01364972f),
                                Up = new RealVector3d(0.08013558f, 0.00239294f, 0.9967811f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(15.74577f, 26.86428f, 0.3281032f),
                                Forward = new RealVector3d(0.4327734f, -0.9015027f, -8.999722E-06f),
                                Up = new RealVector3d(1.350651E-05f, -3.499118E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(11.5382f, 28.69873f, 0.09921016f),
                                Forward = new RealVector3d(-0.2431601f, 0.9699861f, -8.365531E-06f),
                                Up = new RealVector3d(-0.0001849777f, -3.774658E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-25.91321f, -14.84351f, 0.3281032f),
                                Forward = new RealVector3d(0.7326051f, -0.6806539f, 9.200484E-06f),
                                Up = new RealVector3d(-1.387973E-05f, -1.421977E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(15.23571f, 21.17483f, 0.1237609f),
                                Forward = new RealVector3d(0.5476285f, -0.8367216f, -8.999715E-06f),
                                Up = new RealVector3d(1.384948E-05f, -1.691533E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(10.61788f, 23.82105f, 0.09921016f),
                                Forward = new RealVector3d(0.9820923f, -0.1884003f, -8.999709E-06f),
                                Up = new RealVector3d(1.084724E-05f, 8.775348E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-2.492001f, 23.03785f, 0.09249116f),
                                Forward = new RealVector3d(0.9386793f, 0.3447914f, 0.0001282306f),
                                Up = new RealVector3d(-2.721809E-05f, -0.0002978079f, 0.9999999f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-1.598059f, 22.50187f, 0.08015285f),
                                Forward = new RealVector3d(0.9267415f, 0.3756997f, 1.942048E-08f),
                                Up = new RealVector3d(-5.28366E-09f, -3.865825E-08f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-8.548446f, -6.286323f, 2.350725f),
                                Forward = new RealVector3d(-0.6923963f, 0.7215174f, 4.288777E-05f),
                                Up = new RealVector3d(3.049069E-05f, -3.018101E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-7.64261f, -6.587693f, 2.361918f),
                                Forward = new RealVector3d(0.6341221f, 0.7732329f, -4.142761E-06f),
                                Up = new RealVector3d(3.564517E-05f, -2.387461E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-12.78004f, -1.216902f, 2.347599f),
                                Forward = new RealVector3d(-0.6783054f, -0.7346643f, 0.01304624f),
                                Up = new RealVector3d(0.01042668f, 0.008129734f, 0.9999126f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(1.066418f, -7.230356f, -0.1183099f),
                                Forward = new RealVector3d(-0.2842221f, 0.9587584f, 0.0004942818f),
                                Up = new RealVector3d(-0.0001021392f, -0.0005458225f, 0.9999999f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(8.37557f, -0.3864866f, -0.1182343f),
                                Forward = new RealVector3d(-0.9761489f, 0.2171022f, 1.879619E-05f),
                                Up = new RealVector3d(-0.0001021392f, -0.0005458225f, 0.9999999f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-2.573268f, 14.00107f, -0.04406779f),
                                Forward = new RealVector3d(-0.05996364f, -0.9982005f, 0.000387274f),
                                Up = new RealVector3d(-8.504964E-05f, 0.0003930812f, 0.9999999f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(7.922794f, 8.158498f, 2.353647f),
                                Forward = new RealVector3d(-0.8008977f, -0.5988012f, 8.851142E-06f),
                                Up = new RealVector3d(2.520372E-05f, -1.892859E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(7.597046f, 9.406869f, 2.357925f),
                                Forward = new RealVector3d(-0.9828101f, 0.1846194f, 3.553856E-05f),
                                Up = new RealVector3d(3.049069E-05f, -3.018101E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(19.775f, -18.0957f, -0.3374424f),
                                Forward = new RealVector3d(-0.7934126f, 0.6086842f, 0f),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(18.11603f, -19.56939f, -0.3374333f),
                                Forward = new RealVector3d(-0.2973325f, 0.954774f, -2.017662E-05f),
                                Up = new RealVector3d(-6.133202E-05f, 2.032536E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(21.29332f, -16.56921f, -0.337429f),
                                Forward = new RealVector3d(-0.9212f, 0.3890894f, -6.125237E-05f),
                                Up = new RealVector3d(-5.497543E-05f, 2.726623E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-5.857122f, -20.90788f, 0.1742107f),
                                Forward = new RealVector3d(-0.7588191f, 0.6512354f, -0.009276389f),
                                Up = new RealVector3d(-0.121368f, -0.1273959f, 0.9843984f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-5.778999f, -19.74094f, 0.1545499f),
                                Forward = new RealVector3d(-0.9959148f, -0.01629941f, -0.08881466f),
                                Up = new RealVector3d(-0.09026165f, 0.1518224f, 0.9842778f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(21.78522f, 18.83258f, 0.231122f),
                                Forward = new RealVector3d(-0.8453583f, 0.5341998f, -6.788857E-12f),
                                Up = new RealVector3d(-2.56239E-11f, -2.784074E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(21.41018f, 6.259371f, 0.1809946f),
                                Forward = new RealVector3d(0.1720573f, 0.9803302f, -0.09669033f),
                                Up = new RealVector3d(-0.1213777f, 0.1185039f, 0.9855071f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-24.22576f, -13.92519f, 1.753415f),
                                Forward = new RealVector3d(0.635439f, 0.7721511f, 3.328663E-06f),
                                Up = new RealVector3d(-2.064776E-06f, -2.611696E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-25.37714f, -14.90814f, 1.753413f),
                                Forward = new RealVector3d(0.7165196f, -0.6975669f, 3.328663E-06f),
                                Up = new RealVector3d(-2.43057E-06f, 2.275211E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(14.73859f, 23.57292f, 1.753446f),
                                Forward = new RealVector3d(-0.6791741f, -0.7339772f, 9.200477E-06f),
                                Up = new RealVector3d(-1.450003E-06f, 1.387684E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(15.2684f, 18.81452f, 0.4470229f),
                                Forward = new RealVector3d(0.9809486f, 0.1455024f, 0.1287197f),
                                Up = new RealVector3d(-0.126476f, -0.02460635f, 0.9916644f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 54,
                                Position = new RealPoint3d(-32f, 0.9f, 0.2f),
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
                                        WidthRadius = 9f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(-19.07539f, -14.72566f, 0.9762855f),
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
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(0f, 32.88f, 0.2f),
                                Forward = new RealVector3d(0.999027f, 0f, 0.044102f),
                                Up = new RealVector3d(-0.044102f, 0f, 0.999027f),
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
                                        WidthRadius = 9f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(15.41589f, 20.3315f, 0.2f),
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
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-22.14644f, 3.282517f, 0.1582762f),
                                Forward = new RealVector3d(0.04144586f, -0.9991407f, 0f),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(11.4798f, 28.62202f, 1.753411f),
                                Forward = new RealVector3d(0.6883962f, -0.7253349f, 9.200475E-06f),
                                Up = new RealVector3d(-1.394164E-05f, -5.471943E-07f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(13.90996f, 22.30923f, 0.09121044f),
                                Forward = new RealVector3d(-0.9458103f, 0.3247197f, -8.999711E-06f),
                                Up = new RealVector3d(-1.197413E-05f, -7.161691E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(9.345848f, 21.83586f, 0.09479445f),
                                Forward = new RealVector3d(-0.9865043f, -0.1629133f, -0.01638385f),
                                Up = new RealVector3d(0.00178063f, -0.1107318f, 0.9938487f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(7.440469f, 27.58852f, 0.09921017f),
                                Forward = new RealVector3d(0.06180608f, -0.9980882f, -8.99972E-06f),
                                Up = new RealVector3d(1.119766E-05f, -8.32355E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-18.98368f, -11.59364f, 0.09744635f),
                                Forward = new RealVector3d(0.9654163f, -0.2480469f, -0.08027502f),
                                Up = new RealVector3d(0.1162779f, 0.1340708f, 0.9841263f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-25.74225f, -11.00484f, 0.3281032f),
                                Forward = new RealVector3d(0.5696285f, 0.8219023f, -8.999727E-06f),
                                Up = new RealVector3d(-3.636467E-06f, 1.347017E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(10.02602f, 25.01202f, 1.753417f),
                                Forward = new RealVector3d(0.7921723f, 0.610114f, 0.01496003f),
                                Up = new RealVector3d(-0.0119299f, -0.009027528f, 0.9998881f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(8.561759f, 26.5512f, 1.74413f),
                                Forward = new RealVector3d(0.7459855f, -0.6657941f, 0.01496004f),
                                Up = new RealVector3d(-0.01107648f, 0.01005637f, 0.9998881f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(9.453097f, 27.32923f, 1.737722f),
                                Forward = new RealVector3d(0.9928454f, -0.1194066f, 0f),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-27.38576f, -9.872975f, 1.753402f),
                                Forward = new RealVector3d(0.968978f, -0.2466936f, 0.01496005f),
                                Up = new RealVector3d(-0.01446618f, 0.00381429f, 0.9998881f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-26.21413f, -9.769569f, 1.753405f),
                                Forward = new RealVector3d(0.9117448f, -0.4104848f, 0.01496003f),
                                Up = new RealVector3d(-0.01358901f, 0.006257602f, 0.9998881f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-25.84686f, -8.324621f, 1.753404f),
                                Forward = new RealVector3d(0.6673476f, -0.7445961f, 0.01496002f),
                                Up = new RealVector3d(-0.009889871f, 0.01122537f, 0.9998881f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-22.85512f, 3.006397f, 0.134437f),
                                Forward = new RealVector3d(0.02950238f, -0.9911229f, -0.129634f),
                                Up = new RealVector3d(-0.04416888f, -0.1308565f, 0.9904169f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-3.372671f, -2.871264f, 2.247339f),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-3.312613f, -3.931616f, 2.244969f),
                                Forward = new RealVector3d(-0.9742907f, -0.2252944f, 0f),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(4.881548f, 4.544273f, 2.3f),
                                Forward = new RealVector3d(-0.5276117f, 0.8494853f, -0.000798038f),
                                Up = new RealVector3d(-0.002355479f, -0.0005235436f, 0.9999971f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-31.23337f, 1.711124f, 0.03611378f),
                                Forward = new RealVector3d(0.06058981f, -0.9981627f, -1.639709E-10f),
                                Up = new RealVector3d(2.456408E-10f, -1.49362E-10f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-32.69029f, 1.302462f, 0.03584924f),
                                Forward = new RealVector3d(0.2921781f, -0.9563639f, -2.861857E-10f),
                                Up = new RealVector3d(1.097415E-10f, -2.657165E-10f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-30.17955f, 0.8891062f, 0.03607876f),
                                Forward = new RealVector3d(0.9980997f, 0.06162044f, -9.315937E-11f),
                                Up = new RealVector3d(1.097415E-10f, -2.657165E-10f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-0.2322242f, 33.43631f, 0.03588678f),
                                Forward = new RealVector3d(0.8966058f, -0.4428295f, 1.996984E-09f),
                                Up = new RealVector3d(-2.111139E-09f, 2.35136E-10f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-0.2071758f, 32.81176f, 0.04689221f),
                                Forward = new RealVector3d(0.9825304f, -0.1726349f, 0.06950835f),
                                Up = new RealVector3d(-0.06565887f, 0.02791663f, 0.9974515f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(0.2913615f, 31.36172f, 0.02567255f),
                                Forward = new RealVector3d(-0.03041987f, -0.9995312f, -0.003454393f),
                                Up = new RealVector3d(-0.01416168f, -0.003024652f, 0.9998952f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(-13.1315f, 3.381965f, -0.03666295f),
                                Forward = new RealVector3d(0.9741479f, 0.225911f, -5.950446E-06f),
                                Up = new RealVector3d(-8.504964E-05f, 0.0003930812f, 0.9999999f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                QuotaIndex = 53,
                                Position = new RealPoint3d(3.611505f, 4.430729f, 2.3f),
                                Forward = new RealVector3d(-0.1382027f, 0.9904036f, -0.0007980377f),
                                Up = new RealVector3d(-0.002365611f, 0.0004756661f, 0.9999971f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
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
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(-23.66022f, -13.80485f, 1.753416f),
                                Forward = new RealVector3d(0.717071f, 0.6970001f, 0f),
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
                                QuotaIndex = 56,
                                Position = new RealPoint3d(-32.43422f, -15.26157f, 0.3325922f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 18f,
                                        BoxLength = 0f,
                                        PositiveHeight = -1f,
                                        NegativeHeight = -1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 56,
                                Position = new RealPoint3d(14.88772f, 34.16068f, 0.4106543f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 18f,
                                        BoxLength = 0f,
                                        PositiveHeight = -1f,
                                        NegativeHeight = -1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(14.31228f, 24.9635f, 1.753438f),
                                Forward = new RealVector3d(-0.688054f, -0.7256594f, 0f),
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
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
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
                                Position = new RealPoint3d(-25.1609f, -10.2964f, 1.80063f),
                                Forward = new RealVector3d(1f, 5.72926E-19f, 1.008402E-09f),
                                Up = new RealVector3d(-1.008402E-09f, 1.136305E-09f, 1f),
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
                                QuotaIndex = 58,
                                Position = new RealPoint3d(-25.17988f, -10.29528f, 1.753408f),
                                Forward = new RealVector3d(1f, 5.729269E-19f, 1.008403E-09f),
                                Up = new RealVector3d(-1.008403E-09f, 1.136305E-09f, 1f),
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
                                QuotaIndex = 58,
                                Position = new RealPoint3d(10.90339f, 26.25626f, 1.754793f),
                                Forward = new RealVector3d(0.9997142f, -0.02390757f, 0f),
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
                                QuotaIndex = 57,
                                Position = new RealPoint3d(10.89928f, 26.26439f, 1.765349f),
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
                                QuotaIndex = 59,
                                Position = new RealPoint3d(4.025333f, -2.949467f, -0.07818932f),
                                Forward = new RealVector3d(0.9518908f, -0.3064374f, 0f),
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
                                QuotaIndex = 59,
                                Position = new RealPoint3d(17.16435f, -15.53155f, -0.3003666f),
                                Forward = new RealVector3d(0.9518908f, -0.3064374f, 0f),
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
                                QuotaIndex = 59,
                                Position = new RealPoint3d(-11.8553f, 12.82762f, -0.2608258f),
                                Forward = new RealVector3d(0.9396089f, -0.3422502f, -2.590133E-08f),
                                Up = new RealVector3d(9.371722E-09f, -4.995053E-08f, 1f),
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
                                QuotaIndex = 60,
                                Position = new RealPoint3d(17.05336f, -15.58102f, -0.3375612f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 3.5f,
                                        BoxLength = 5f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = -0.5f,
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
                                Position = new RealPoint3d(3.968401f, -2.967834f, -0.08742633f),
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
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 8f,
                                        BoxLength = 4f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = -0.5f,
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
                                Position = new RealPoint3d(-30.21644f, -16.8558f, -0.05575202f),
                                Forward = new RealVector3d(-0.7052142f, -0.7089943f, 0f),
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
                                    SharedStorage = 5,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 7f,
                                        BoxLength = 10f,
                                        PositiveHeight = 3f,
                                        NegativeHeight = -0.5f,
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
                                Position = new RealPoint3d(16.63461f, 31.29874f, 0.066531f),
                                Forward = new RealVector3d(0.7171811f, 0.6968868f, 0f),
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
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 7f,
                                        BoxLength = 10f,
                                        PositiveHeight = 3f,
                                        NegativeHeight = -0.5f,
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
                                Position = new RealPoint3d(-9.69433f, 10.98871f, -0.04343865f),
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
                                        WidthRadius = 5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 4f,
                                        NegativeHeight = 3f,
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
                                Position = new RealPoint3d(-28.44802f, -6.926905f, 0.0952406f),
                                Forward = new RealVector3d(0.6956367f, 0.7183847f, -0.003600721f),
                                Up = new RealVector3d(-9.29102E-05f, 0.00510215f, 0.999987f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-29.22266f, -7.624763f, 0.04219607f),
                                Forward = new RealVector3d(0.6956367f, 0.7183847f, -0.003600721f),
                                Up = new RealVector3d(-9.29102E-05f, 0.00510215f, 0.999987f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(7.773797f, 29.86653f, 0.0975284f),
                                Forward = new RealVector3d(0.6996518f, 0.714484f, 0f),
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(8.471554f, 30.44723f, 0.04280655f),
                                Forward = new RealVector3d(0.6996518f, 0.714484f, 0f),
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(9.645315f, 22.596f, 0.1787596f),
                                Forward = new RealVector3d(0.6996518f, 0.714484f, 0f),
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(8.966896f, 23.43822f, 0.09949727f),
                                Forward = new RealVector3d(0.5926834f, -0.8054243f, -0.004250535f),
                                Up = new RealVector3d(0.005871695f, -0.0009565199f, 0.9999823f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-21.44007f, -8.881435f, 0.143663f),
                                Forward = new RealVector3d(0.5926834f, -0.8054243f, -0.004250535f),
                                Up = new RealVector3d(0.005871695f, -0.0009565199f, 0.9999823f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 61,
                                Position = new RealPoint3d(-23.24922f, -7.198484f, -0.01394068f),
                                Forward = new RealVector3d(0.5926834f, -0.8054243f, -0.004250535f),
                                Up = new RealVector3d(0.005871695f, -0.0009565199f, 0.9999823f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 62,
                                Position = new RealPoint3d(13.46123f, 23.06783f, 1.753442f),
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
                                QuotaIndex = 63,
                                Position = new RealPoint3d(9.532043f, 26.93f, 0.09921016f),
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
                                QuotaIndex = 63,
                                Position = new RealPoint3d(-26.22813f, -9.058912f, 0.09921015f),
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
                                QuotaIndex = 62,
                                Position = new RealPoint3d(-22.19563f, -12.5689f, 1.753419f),
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
                                QuotaIndex = 62,
                                Position = new RealPoint3d(17.79326f, -16.29693f, -0.3375127f),
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
                                QuotaIndex = 64,
                                Position = new RealPoint3d(22.46208f, -11.72325f, -0.6404302f),
                                Forward = new RealVector3d(-0.6745207f, -0.7185881f, 0.1692717f),
                                Up = new RealVector3d(0.1254245f, 0.1144094f, 0.9854842f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 64,
                                Position = new RealPoint3d(12.74444f, -20.67616f, -0.595434f),
                                Forward = new RealVector3d(0.8141369f, 0.5782388f, 0.05311339f),
                                Up = new RealVector3d(-0.02894692f, -0.05093984f, 0.9982821f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 65,
                                Position = new RealPoint3d(5.923132f, -23.32163f, -0.1382572f),
                                Forward = new RealVector3d(-0.9205927f, -0.3513116f, 0.1705556f),
                                Up = new RealVector3d(0.1406252f, 0.1092238f, 0.9840197f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 66,
                                Position = new RealPoint3d(21.89421f, -10.99917f, -0.7365921f),
                                Forward = new RealVector3d(0.0005262626f, 0.9945177f, -0.1045667f),
                                Up = new RealVector3d(0.003191743f, 0.1045645f, 0.994513f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                                QuotaIndex = 66,
                                Position = new RealPoint3d(13.62825f, -21.17792f, -0.6523708f),
                                Forward = new RealVector3d(0.02352338f, 0.9995955f, 0.01598431f),
                                Up = new RealVector3d(-0.0306816f, -0.01525936f, 0.9994127f),
                                ParentObject = new ObjectDataIdentifier
                                {
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
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
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
                            -1, 22, -1, -1, -1, 0,
                        },
                        Quotas = new VariantDataObjectQuota[256]
                        {
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = -1,
                                MinimumCount = 255,
                                MaximumCount = 255,
                                PlacedOnMap = 0,
                                MaxAllowed = 0,
                                Cost = -1f,
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
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\weapons\turret\machinegun_turret\machinegun_turret").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\ghost\ghost").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\vehicles\mongoose\mongoose").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_red\powerup_red").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\powerups\ammo_packs\ammo_small\ammo_small").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 10,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\powerups\ammo_packs\ammo_large\ammo_large").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 74,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_flag_away_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 4,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_return_area").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\oddball\oddball_ball_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\koth\koth_hill_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 5,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\multi\s3d_turf\turf_crate_large\turf_crate_large").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 8,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 3,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_goal_area").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\barricade_large\barricade_large").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\barricade_small\barricade_small").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\human\military\case\case").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
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