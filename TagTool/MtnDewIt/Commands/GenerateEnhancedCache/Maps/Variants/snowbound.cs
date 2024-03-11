using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @snowbound : MapVariantFile
    {
        public @snowbound(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\snowbound\snowbound");
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
                    MapId = 360,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Snowbound",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Snowbound",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Schneeschlacht",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Blizzard",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Snowbound",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Snowbound",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Nella neve",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Snowbound",
                        },
                        new NameUnicode32
                        {
                            Name = $@"大雪",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Snowbound",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Hostile conditions did not prevent the Covenant from seeking salvage on this buried Forerunner construct. 2-8 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"フォアランナーの遺跡が静かに眠る過酷な環境|n(2-8 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Die Allianz wurde nicht davon abgehalten, in diesem verschütteten Blutsväter-Konstrukt nach Bergungsgut zu suchen. 2-8 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Les conditions hostiles n'ont pas empêché les Covenants de mettre à sac cette construction forerunner enfouie. 2-8 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Las condiciones no han impedido al Covenant rescatar lo que pueda de este lugar. 2-8 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Las condiciones no han impedido al Covenant rescatar lo que pueda de este lugar. 2-8 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Le condizioni ostili non hanno impedito ai Covenant di cercare rifugio in queste rovine dei Precursori. 2-8 giocatori.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"선조들의 건축물이 파묻혀 있는 환경이 열악한 지역입니다. 2-8인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"即使情勢相當險惡，星盟仍舊義無反顧地從先行者遺跡搜尋受難人員。2-8 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Condições adversas não impediram que o Covenant procurasse salvamento nesta construção Forerunner enterrada.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_snowbound",
                    MapName = $@"snowbound",
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
                            Name = $@"Snowbound",
                            Description = $@"Hostile conditions did not prevent the Covenant from seeking salvage on this buried Forerunner construct. 2-8 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 360,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 360,
                        WorldBounds = new RealRectangle3d(-256.2146f, 395.0836f, -251.1736f, 378.4259f, -53.24137f, 442.8734f),
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