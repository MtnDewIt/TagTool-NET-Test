using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class ghosttown : MapVariantFile
    {
        public ghosttown(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\ghosttown\ghosttown");
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
                    MapId = 590,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Ghost Town",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Ghost Town",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Geisterstadt",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Ville fantôme",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Pueblo fantasma",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Pueblo fantasma",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Città fantasma",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Ghost Town",
                        },
                        new NameUnicode32
                        {
                            Name = $@"鬼城",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cidade fantasma",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"These fractured remains near Voi remind us that brave souls died here to buy our salvation. 4-12 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"多くの犠牲者が眠るヴォイ近郊の廃墟の街|n(4-12 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Diese zerstörten Überbleibsel in der Nähe von Voi erinnern an die tapferen Seelen, die hier für unsere Rettung starben.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Les restes calcinés près de Voi sont là pour nous rappeler que des braves ont donné leur vie pour nous. 4-12 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Los restos cerca de Voi nos recuerdan a quienes murieron por nuestra salvación.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Los restos cerca de Voi nos recuerdan a quienes murieron por nuestra salvación.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Queste rovine nei pressi di Voi ci ricordano quei coraggiosi caduti qui per la nostra salvezza. 4-12 giocatori",
                        },
                        new NameUnicode128
                        {
                            Name = $@"많은 희생자가 발생했던 보이(VOI) 마을 근처의 폐허입니다. 4-12인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"這些沃城附近的遺跡提醒我們，沒有當年英勇的戰士就沒有今日的我們，4-12 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Esses destroços perto de Voi nos fazem lembrar que almas corajosas pereceram aqui comprando nossa salvação. 4-12 jogadores",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_ghosttown",
                    MapName = $@"ghosttown",
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
                            Name = $@"Ghost Town",
                            Description = $@"These fractured remains near Voi remind us that brave souls died here to buy our salvation. 4-12 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 590,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 590,
                        WorldBounds = new RealRectangle3d(-23.10219f, 26.45811f, -23.8373f, 34.61412f, -1.467384f, 42.30659f),
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