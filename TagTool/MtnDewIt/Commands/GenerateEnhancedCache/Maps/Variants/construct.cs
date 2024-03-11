using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @construct : MapVariantFile
    {
        public @construct(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\construct\construct");
            var scnr = CacheContext.Deserialize<Scenario>(Stream, tag);

            BlfData blfData = new BlfData(Cache.Version, CachePlatform.Original)
            {
                Version = CacheVersion.HaloOnline106708,
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
                    MapId = 300,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Construct",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Construct",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Konstrukt",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Construction",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Construct",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Construct",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Struttura",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Construct",
                        },
                        new NameUnicode32
                        {
                            Name = $@"建築物",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Construção",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Vast quantities of water and other raw materials are consumed in creating even the smallest orbital installations. 2-8 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"膨大な量の水や原料が消費される軌道施設|n(2-8 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Schon für den Bau der kleinsten Orbitaleinrichtungen werden riesige Mengen Wasser und andere Rohstoffe verbraucht. 2-8 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Même la plus petite installation orbitale nécessite d'énormes quantités d'eau et de matières premières. 2-8 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Se consumen agua y otras materias primas, incluso con las instalaciones orbitales más pequeñas. 2-8 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Se consumen agua y otras materias primas, incluso con las instalaciones orbitales más pequeñas. 2-8 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Enormi quantità d'acqua e materie prime sono impiegate per creare anche le più piccole installazioni orbitali. 2-8 giocatori.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"많은 양의 물과 원료가 소비된 작은 궤도 설비입니다. 2-8인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"即使是建造最小的軌道基地，都要消耗大量的水及原物料。2-8 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Vastas quantidades de água e de outras matérias-primas são consumidas para criar mesmo a menor das instalações orbitais.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_construct",
                    MapName = $@"construct",
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
                            Name = $@"Construct",
                            Description = $@"Vast quantities of water and other raw materials are consumed in creating even the smallest orbital installations. 2-8 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 300,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 300,
                        WorldBounds = new RealRectangle3d(-85.5014f, 85.49911f, -114.8048f, 20.85302f, -546.1587f, 63.27521f),
                        RuntimeEngineSubType = VariantDataGameEngineSubType.All,
                        MaximumBudget = 13f,
                        SpentBudget = 0f,
                        MapVariantChecksum = 1329238095,
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

            GenerateMapVariant(tag, blfData);

            GenerateMapFile(tag, blfData);
        }
    }
}