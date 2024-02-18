using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class armory : MapVariantFile
    {
        public armory(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\armory\armory");
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
                    MapId = 580,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Rat's Nest",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Rat's Nest",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Rattennest",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Cour des miracles",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Rat's Nest",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Rat's Nest",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Rat's Nest",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Rat's Nest",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Rat's Nest",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Ninho de ratos",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Snowmelt from Kilimanjaro feeds reservoirs every bit as vital as the fuel and ammunition stores. 6-16 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"燃料や弾薬を潤沢に備蓄した地下軍事施設 (6-16 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Schmelzwasser des Kilimandscharo speist Speicherbecken, die ebenso wichtig wie die Treibstoff- und Munitionslager sind.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Les lacs formés par la fonte du Kilimandjaro sont tout aussi cruciaux que les réserves de combustible et de munitions.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La nieve derretida del Kilimanjaro es tan vital para las reservas como los almacenes de combustible y de munición.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La nieve derretida del Kilimanjaro es tan vital para las reservas como los almacenes de combustible y de munición.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"L'acqua proveniente dai ghiacci del Kilimanjaro alimenta i serbatoi ed è preziosa quanto le riserve di carburante e munizioni.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"연료와 무기 저장소가 있는 지하 비밀 기지입니다. 6-16인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"吉力馬札羅山的融雪好像軍火補給一樣，一點一滴的流進水庫中。6-16 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"A neve derretida do Kilimanjaro abastece os reservatórios de água, tão vitais quanto os depósitos de combustível e de munição.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_armory",
                    MapName = $@"armory",
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
                            Name = $@"Rat's Nest",
                            Description = $@"Snowmelt from Kilimanjaro feeds reservoirs every bit as vital as the fuel and ammunition stores. 6-16 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 580,
                            CampaignDifficulty = -1,
                            CampaignInsertionPoint = 0,
                        },
                        VariantVersion = 12,
                        MapId = 580,
                        WorldBounds = new RealRectangle3d(-99.97967f, 22.75111f, -81.84559f, 66.11623f, -57.7369f, 40.02354f),
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