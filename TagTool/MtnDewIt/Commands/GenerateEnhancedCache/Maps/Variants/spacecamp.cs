using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @spacecamp : MapVariantFile
    {
        public @spacecamp(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\spacecamp\spacecamp");
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
                    MapId = 500,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Orbital",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Orbital",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Im Orbit",
                        },
                        new NameUnicode32
                        {
                            Name = $@"En orbite",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Orbital",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Orbital",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Stazione orbitale",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Orbital",
                        },
                        new NameUnicode32
                        {
                            Name = $@"軌道",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Orbital",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"With a lot of situational awareness, and a little luck, hopefully the only thing you will lose is your luggage. 4-12 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"人類の科学技術の粋をこらした宇宙ステーション|n(4-12 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Wenn Sie den Überblick behalten und etwas Glück haben, verlieren Sie hier hoffentlich nichts weiter als Ihr Gepäck.4-12 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Avec beaucoup de concentration et une pincée de chance, vous ne perdrez peut-être que vos bagages. 4-12 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Con bastante capacidad de percepción y un poco de suerte, lo único que perderás será el equipaje. Jugadores: 4-12.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Con bastante capacidad de percepción y un poco de suerte, lo único que perderás será el equipaje. Jugadores: 4-12.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Con molta consapevolezza e un po' di fortuna, forse l'unica cosa che perderai sarà il bagaglio. 4-12 giocatori",
                        },
                        new NameUnicode128
                        {
                            Name = $@"아무것도 잃을 것이 없는 당신에게 이곳은 기회의 장소입니다. 4-12인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"敏捷的環境察覺能力和危機意識，加上一點運氣，你也許可以損失少一點。4-12 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Com uma boa percepção da situação e um pouco de sorte, talvez você só perca sua bagagem. 4-12 jogadores",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_spacecamp",
                    MapName = $@"spacecamp",
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
                            Name = $@"Orbital",
                            Description = $@"With a lot of situational awareness, and a little luck, hopefully the only thing you will lose is your luggage. 4-12 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 500,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 500,
                        WorldBounds = new RealRectangle3d(-14.58579f, 14.65313f, -22.71089f, 27f, -29.36559f, 16f),
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