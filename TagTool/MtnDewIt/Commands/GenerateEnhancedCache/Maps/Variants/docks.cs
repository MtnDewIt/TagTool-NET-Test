using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class @docks : MapVariantFile
    {
        public @docks(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\docks\docks");
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
                    MapId = 440,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Longshore",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Longshore",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Küste",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Littoral",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Costa",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Costa",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Porto industriale",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Longshore",
                        },
                        new NameUnicode32
                        {
                            Name = $@"沿岸",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Longshore",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"Abandoned during the invasion of Earth, the Mombasa Quays are now bereft of commerce, but rife with danger. 4-12 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"今や人影も途絶えたモンバサ埠頭の産業エリア|n(4-12 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Mombasa-Kais, verlassen während der Allianzinvasion auf der Erde, dafür aber viele Gefahren. 4-12 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Sur les quais de Mombasa désertés lors de l'invasion des Covenants, tout commerce a disparu mais le danger guette.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Los muelles de Mombasa, abandonados en la invasión de la Tierra, no tienen actividad, pero aún son peligrosos.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Los muelles de Mombasa, abandonados en la invasión de la Tierra, no tienen actividad, pero aún son peligrosos.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Abbandonate con l'invasione Covenant, le banchine di Mombasa non sono più un porto, ma traboccano di pericoli. 4-12 gioc.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"버려진 몸바사 항구에는 이제 교역이 없고 위험만이 남아 있습니다. 4-12인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"在入侵地球時遭到遺棄，蒙巴薩島碼頭已無商業活動，只充滿著危險。4-12 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"Abandonados na invasão da Terra pelos Covenant, os Cais de Mombasa não têm comércio, mas estão cheios de perigos. 4-12 jog.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_docks",
                    MapName = $@"docks",
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
                            Name = $@"Longshore",
                            Description = $@"Abandoned during the invasion of Earth, the Mombasa Quays are now bereft of commerce, but rife with danger. 4-12 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 440,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 440,
                        WorldBounds = new RealRectangle3d(-210.4125f, 174.1172f, -152.6497f, 207.2426f, -12.00001f, 99.99999f),
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