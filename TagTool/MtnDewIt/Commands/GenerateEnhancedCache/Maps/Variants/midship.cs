using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @midship : MapVariantFile
    {
        public @midship(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\midship\midship");
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
                    MapId = 720,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Heretic",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Heretic",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Ketzer",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Hérétique",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Hereje",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Hereje",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Heretic",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Heretic",
                        },
                        new NameUnicode32
                        {
                            Name = $@"異教徒",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Herege",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Because of its speed and luxury the Pious Inquisitor has become an irresistible prize during these dark times. 2-8 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"コヴナント軍が誇る最新鋭のフラッグシップ|n(2-8 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Aufgrund seiner Schnelligkeit und luxuriösen Ausstattung ist die Pious Inquisitor in diesen finsteren Zeiten heiß begehrt.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Rapide et luxueux, le Pious Inquisitor est devenu une proie de choix en ces temps hostiles. 2-8 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Dada su velocidad y prestigio, la Pious Inquisitor se ha convertido en un premio irresistible en estos tiempos oscuros.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Dada su velocidad y prestigio, la Pious Inquisitor se ha convertido en un premio irresistible en estos tiempos oscuros.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"A causa del lusso e della propria velocità il Pious Inquisitor è divenuto una preda irresistibile durante questi tempi bui.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"코버넌트가 자랑하는 빠르고 화려한 전함입니다. 2-8인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"因為豪華及速度上的優勢，使它成為人人無可抗拒的誘惑。2-8 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Por causa de sua velocidade e luxo, o Pious Inquisitor tornou-se um troféu irresistível durante os tempos sombrios. 2-8 jog.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_midship",
                    MapName = $@"midship",
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
                            Name = $@"Heretic",
                            Description = $@"Because of its speed and luxury the Pious Inquisitor has become an irresistible prize during these dark times. 2-8 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 720,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 720,
                        WorldBounds = new RealRectangle3d(-14.62926f, 14.62924f, -9.996522f, 18.07923f, -3.411678f, 9.46344f),
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