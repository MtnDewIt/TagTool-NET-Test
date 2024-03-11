using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @warehouse : MapVariantFile
    {
        public @warehouse(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\warehouse\warehouse");
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
                    MapId = 480,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Foundry",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Foundry",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Gießerei",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Fonderie",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Foundry",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Foundry",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Foundry",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Foundry",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Foundry",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Fornalha",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"After the orbital elevator fell, supply warehouses sending munitions to space were soon abandoned. 4-12 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"テザー崩壊後に廃墟と化した広大な補給倉庫 (4-12 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Nach dem Fall des Orbitalaufzugs wurden auch die Munitionslager zur Versorgung des Weltraums bald verlassen.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Après la chute de l'ascenseur orbital, les envois de munitions vers l'espace ont rapidement cessé.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Tras la caída del ascensor orbital, los almacenes de suministros para enviar municiones al espacio fueron pronto abandonados.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Tras la caída del ascensor orbital, los almacenes de suministros para enviar municiones al espacio fueron pronto abandonados.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Dopo la caduta dell'ascensore orbitale, i magazzini di rifornimento che inviavano munizioni nello spazio furono abbandonati.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"궤도 엘리베이터의 추락으로 버려진 보급 창고입니다. 4-12인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"自從太空纜索毀損後，運送軍火的倉儲很快就被遺棄了。4-12 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Depois que o elevador orbital caiu, os armazéns de abastecimento que mandavam munição para o espaço foram logo abandonados.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_warehouse",
                    MapName = $@"warehouse",
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
                            Name = $@"Foundry",
                            Description = $@"After the orbital elevator fell, supply warehouses sending munitions to space were soon abandoned. 4-12 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 480,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 480,
                        WorldBounds = new RealRectangle3d(-42.67284f, 52.53315f, -38.64833f, 31.63995f, -0.7491053f, 19.8558f),
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