using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @isolation : MapVariantFile
    {
        public @isolation(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\isolation\isolation");
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
                    MapId = 330,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Isolation",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolation",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolation",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolement",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolation",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolation",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolamento",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolation",
                        },
                        new NameUnicode32
                        {
                            Name = $@"隔離",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Isolamento",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Containment protocols are almost impervious to pre-Gravemind infestations. What could possibly go wrong? 2-10 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"グレイヴマインドの出現まで磐石だった隔離施設|n(2-10 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Eindämmungsprotokolle für die Vor-Gravemind-Verseuchungen weisen keine Lücken auf. Was sollte da schief gehen? 2-10 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Le confinement endigue de façon quasi certaine les infestations pré-Fossoyeur. AUCUN risque, vraiment. 2-10 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Los protocolos son casi insensibles a las infestaciones anteriores a la Gravemind. ¿Qué pudo ir mal? 2-10 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Los protocolos son casi insensibles a las infestaciones anteriores a la Gravemind. ¿Qué pudo ir mal? 2-10 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"I sistemi di contenimento sono impenetrabili alle infestazioni pre-Mente Suprema. Cosa potrebbe andare storto? 2-10 giocatori",
                        },
                        new NameUnicode128
                        {
                            Name = $@"플러드의 침입을 모두 막았던 봉쇄 시설입니다. 2-10인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"汙染防制措施對於屍腦獸的寄生感染絲毫無效，到底是哪裡出差錯了？2-10 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Protocolos de contenção são quase impenetráveis às infestações pré-Gravemind. O que pode ter dado errado?",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_isolation",
                    MapName = $@"isolation",
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
                            Name = $@"Isolation",
                            Description = $@"Containment protocols are almost impervious to pre-Gravemind infestations. What could possibly go wrong? 2-10 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 330,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 330,
                        WorldBounds = new RealRectangle3d(-112.7445f, 112.7445f, -39.31153f, 43.63758f, -14.82482f, 47.82688f),
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