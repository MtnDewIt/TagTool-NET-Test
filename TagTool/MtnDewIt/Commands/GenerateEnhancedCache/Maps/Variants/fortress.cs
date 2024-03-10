using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class fortress : MapVariantFile
    {
        public fortress(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\fortress\fortress");
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
                    MapId = 740,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Citadel",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Citadel",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Zitadelle",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Citadelle",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Ciudadela",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Ciudadela",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cittadella",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Citadel",
                        },
                        new NameUnicode32
                        {
                            Name = $@"要塞",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cidadela",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"In the heart of this Forerunner structure, far above the troubled surface of the Ark, another battle rages. 2-6 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"アークから遠く離れたフォアランナーの要塞内部|n(2-6 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Im Herzen dieser Blutsväter-Struktur weit über der umkämpften Oberfläche der Arche tobt ein weiterer Kampf. 2-6 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Au cœur du repaire des Forerunners, bien au-dessus de la surface houleuse de l'Arche, une autre bataille fait rage. 2-6 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"En el corazón de esta estructura de los Forerunner, muy por debajo de la atribulada superficie del Arca, se libra otra batalla.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"En el corazón de esta estructura de los Forerunner, muy por debajo de la atribulada superficie del Arca, se libra otra batalla.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Nel cuore di questa struttura dei Precursori, molto al di sopra dell'inquieta superficie dell'Arca, infuria un'altra battaglia.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"이곳 선조의 구조물 중심부에서 또다른 전쟁이 벌어집니다. 2-6인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"遠離紛亂的方舟上，在這先行者建築的中心，另外一場戰鬥正展開。 2-6 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"No coração desta estrutura Forerunner, bem  acima da superfície atormentada da Ark, uma outra batalha é travada. 2-6 jogadores",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_fortress",
                    MapName = $@"fortress",
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
                            Name = $@"Citadel",
                            Description = $@"In the heart of this Forerunner structure, far above the troubled surface of the Ark, another battle rages. 2-6 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 740,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 740,
                        WorldBounds = new RealRectangle3d(-39.56091f, -3.463892f, -13.78029f, 20.6454f, -49.76229f, -14.05086f),
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