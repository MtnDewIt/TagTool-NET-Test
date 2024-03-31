using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class s3d_waterfall : MapVariantFile
    {
        public s3d_waterfall(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\multi\s3d_waterfall\s3d_waterfall");
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
                    MapId = 706,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer | BlfDataScenarioFlags.IsDlc,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Waterfall",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"The UNSC constructed many secret holdfasts during the final years of the Covenant War. 4-12 players.",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"m_s3d_waterfall",
                    MapName = $@"s3d_waterfall",
                    MapIndex = 14,
                    MinimumDesiredPlayers = 2,
                    MaximumDesiredPlayers = 8,
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
                            Name = $@"Waterfall",
                            Description = $@"The UNSC constructed many secret holdfasts during the final years of the Covenant War. 4-12 players",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 706,
                            CampaignDifficulty = -1,
                            CampaignInsertionPoint = 0,
                        },
                        VariantVersion = 12,
                        MapId = 706,
                        WorldBounds = new RealRectangle3d(-192.7094f, 234.4026f, -252.2577f, 198.472f, -56.69442f, 79.16683f),
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