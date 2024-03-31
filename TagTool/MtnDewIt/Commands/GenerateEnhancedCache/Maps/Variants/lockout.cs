using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @lockout : MapVariantFile
    {
        public @lockout(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\lockout\lockout");
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
                    MapId = 520,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Blackout",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Blackout",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Blackout",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Black-out",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Apagón",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Apagón",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Blackout",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Blackout",
                        },
                        new NameUnicode32
                        {
                            Name = $@"斷電",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Blackout",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Bathed in frozen moonlight, this abandoned drilling platform is now a monument to human frailty. 4-12 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"冷たい月光と静寂に包まれたかつての掘削基地|n(4-12 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Diese in eiskaltes Mondlicht gebadet Bohrplattform ist jetzt ein Monument der menschlichen Zerbrechlichkeit. 4-12 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Dans un clair de lune glacé, cette plateforme désaffectée n'est plus qu'un symbole de la fragilité des Hommes. 4-12 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Esta plataforma abandonada, bajo la luz de la Luna, es ahora un monumento a la debilidad humana.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Esta plataforma abandonada, bajo la luz de la Luna, es ahora un monumento a la debilidad humana.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Avvolta nel gelo del chiarore lunare, questa piattaforma di perforazione abbandonata è un monumento alla fragilità umana.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"차가운 달빛 아래 놓여있는 버려진 굴착 지역입니다. 4-12인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"浸漬在冰封的月光中，這座荒廢的鑽油平台現在是人類脆弱的象徵，4-12 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Banhada pelo luar gelado, esta plataforma de perfuração abandonada é um novo monumento à fragilidade humana. 4-12 jogadores",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_lockout",
                    MapName = $@"lockout",
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
                            Name = $@"Blackout",
                            Description = $@"Bathed in frozen moonlight, this abandoned drilling platform is now a monument to human frailty. 4-12 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 520,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 520,
                        WorldBounds = new RealRectangle3d(-30f, 30f, -40f, 40f, -37.41294f, 20f),
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