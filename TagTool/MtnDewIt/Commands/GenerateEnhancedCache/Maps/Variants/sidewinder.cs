using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class sidewinder : MapVariantFile
    {
        public sidewinder(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\sidewinder\sidewinder");
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
                    MapId = 470,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Avalanche",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Avalanche",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Lawine",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Avalanche",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Avalancha",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Avalancha",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Valanga",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Avalanche",
                        },
                        new NameUnicode32
                        {
                            Name = $@"雪崩",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Avalanche",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Freezing winds scour blasted terrain, and ancient battle scars are a grim reminder that this is a precious prize. 6-16 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"雪に埋もれた寒風吹きすさぶ古戦場跡|n(6-16 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Eiskalte Winde wehen über zerstörtes Terrain, und uralte Kampfspuren erinnern daran, dass hier ein wertvoller Preis wartet.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Un vent glacial balaie une plaine désolée portant encore les stigmates sinistres de quelque bataille passée. 6-16 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"El viento azota el terreno y las antiguas cicatrices son un recordatorio de que se trata de un codiciado premio.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"El viento azota el terreno y las antiguas cicatrices son un recordatorio de que se trata de un codiciado premio.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Venti gelidi imperversano sul terreno e i segni di antiche battaglie ci ricordano l'importanza di questo luogo. 6-16 gioc.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"전쟁의 상처를 안고 있는 매서운 혹한 지역입니다. 6-16인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"冷冽寒風吹噬著荒蕪地表，古代戰爭的傷痕無言的訴說著輝煌的過去，6-16 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Ventos gelados varrem as ruínas, e velhas cicatrizes de guerra são uma lembrança de que este prêmio é valioso. 6-16 jogadores",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_sidewinder",
                    MapName = $@"sidewinder",
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
                            Name = $@"Avalanche",
                            Description = $@"Freezing winds scour blasted terrain, and ancient battle scars are a grim reminder that this is a precious prize. 6-16 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 470,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 470,
                        WorldBounds = new RealRectangle3d(-209.9415f, 213.4076f, -243.7742f, 117.37f, -65.855f, 135.4793f),
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