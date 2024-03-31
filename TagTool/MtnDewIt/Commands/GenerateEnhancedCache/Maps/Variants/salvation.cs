using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @salvation : MapVariantFile
    {
        public @salvation(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\salvation\salvation");
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
                    MapId = 350,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Epitaph",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Epitaph",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Grabinschrift",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Épitaphe",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Epitaph",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Epitaph",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Epitaffio",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Epitaph",
                        },
                        new NameUnicode32
                        {
                            Name = $@"墓園",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Epitáfio",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Some believe the Forerunners preferred desolate places. Others suggest that few other sites survived the Flood. 2-6 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"フラッドの脅威を逃れた、ひと気のないさびれた地域|n(2-6 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Die Blutsväter sollen trostlose Orte bevorzugen. Andere meinen, dass nur wenige Plätze die Flood überlebt haben. 2-6 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Soit les Forerunners préféraient les endroits désolés, soit ce sont les seuls sites à avoir échappé au Parasite. 2-6 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Se piensa que los Forerunners preferían lugares aislados. Pocos lugares sobrevivieron a los Flood. 2-6 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Se piensa que los Forerunners preferían lugares aislados. Pocos lugares sobrevivieron a los Flood. 2-6 jugadores.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Si dice che i Precursori preferissero zone desolate. Per altri pochi luoghi sono sopravvissuti ai Flood. 2-6 giocatori.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"선조들이 좋아했던 황량한 지역입니다. 2-6인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"有人相信先行者喜歡渺無人煙的地方，有人覺得應該有少數據點躲過了蟲族的破壞。2-6 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Alguns acreditam que os Forerunners preferiam lugares desolados. Outros afirmam que poucos locais sobreviveram ao Flood.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_salvation",
                    MapName = $@"salvation",
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
                            Name = $@"Epitaph",
                            Description = $@"Some believe the Forerunners preferred desolate places. Others suggest that few other sites survived the Flood. 2-6 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 350,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 350,
                        WorldBounds = new RealRectangle3d(-146.9224f, 191.9066f, -132.5474f, 240.5062f, -291.2364f, 311.8749f),
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