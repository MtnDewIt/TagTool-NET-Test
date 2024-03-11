using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @chillout : MapVariantFile
    {
        public @chillout(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\chillout\chillout");
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
                    MapId = 600,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Cold Storage",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cold Storage",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Kaltes Lager",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Chambre froide",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Almacenamiento frío",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Almacenamiento frío",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cella frigorifera",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cold Storage",
                        },
                        new NameUnicode32
                        {
                            Name = $@"冷藏室",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cold Storage",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Deep in the bowels of Installation 05 things have gotten a little out of hand. I hope you packed extra underwear. 2-6 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"制御不能となったデルタ Halo の中心部|n(2-6 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Tief im Inneren von Installation 05 sind die Dinge etwas aus dem Ruder gelaufen. Ich hoffe, Sie haben lange Unterhosen dabei.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Dans les tréfonds de l'installation 05, les choses ont un poil dégénéré. J'espère que vous avez prévu des caleçons de rechange.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"En las profundidades de la Instalación 05 las cosas se han ido un poco de las manos. Espero que lleves mudas extra.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"En las profundidades de la Instalación 05 las cosas se han ido un poco de las manos. Espero que lleves mudas extra.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Nelle profondità dell'Installazione 05 la situazione è fuori controllo. Spero che tu ti sia portato dei vestiti extra.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"05 시설의 내부는 사람의 손길이 미치지 않은지 오래 되었습니다. 2-6인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"在 05 特區深處，狀況一發不可收拾，希望你有多準備一套內衣褲。2-6 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Nas entranhas da Instalação 05, as  coisas  meio que saíram do controle. Tomara que você tenha trazido roupa de baixo extra.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_chillout",
                    MapName = $@"chillout",
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
                            Name = $@"Cold Storage",
                            Description = $@"Deep in the bowels of Installation 05 things have gotten a little out of hand. I hope you packed extra underwear. 2-6 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 600,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 600,
                        WorldBounds = new RealRectangle3d(-16.79799f, 25.6f, -12.60001f, 12.8f, -3.764646f, 14.09f),
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