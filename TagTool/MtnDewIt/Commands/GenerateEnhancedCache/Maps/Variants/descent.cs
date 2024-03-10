using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps
{
    public class descent : MapVariantFile
    {
        public descent(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenario>($@"levels\dlc\descent\descent");
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
                    MapId = 490,
                    MapFlags = BlfDataScenarioFlags.Visible | BlfDataScenarioFlags.GeneratesFilm | BlfDataScenarioFlags.IsMultiplayer,
                    Names = new NameUnicode32[12]
                    {
                        new NameUnicode32
                        {
                            Name = $@"Assembly",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Assembly",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Versammlung",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Assemblée",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Reunión",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Reunión",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Adunanza",
                        },
                        new NameUnicode32
                        {
                            Name = $@"Assembly",
                        },
                        new NameUnicode32
                        {
                            Name = $@"組裝工廠",
                        },
                        new NameUnicode32
                        {
                        },
                        new NameUnicode32
                        {
                            Name = $@"Assembly",
                        },
                        new NameUnicode32
                        {
                        },
                    },
                    Descriptions = new NameUnicode128[12]
                    {
                        new NameUnicode128
                        {
                            Name = $@"The Covenant war machine continues its march to conquest; even with its head severed it is still dangerous. 2-8 players",
                        },
                        new NameUnicode128
                        {
                            Name = $@"あのスカラベが製造されていたコヴナントの兵器工場|n(2-8 プレイヤー向け)",
                        },
                        new NameUnicode128
                        {
                            Name = $@"Die Kriegsmaschinerie der Allianz setzt ihren Eroberungsfeldzug fort und ist auch kopflos noch eine Bedrohung. 2-8 Spieler",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La machine de guerre covenante poursuit son avancée inexorable. Même décapitée, elle reste dangereuse. 2-8 joueurs",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La maquinaria de guerra del Covenant sigue su marcha hacia la conquista; incluso sin cabeza sigue siendo peligrosa.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La maquinaria de guerra del Covenant sigue su marcha hacia la conquista; incluso sin cabeza sigue siendo peligrosa.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"La macchina da guerra Covenant prosegue la sua marcia di conquista; anche se privata della propria testa è ancora pericolosa.",
                        },
                        new NameUnicode128
                        {
                            Name = $@"여전히 위험한 코버넌트의 전쟁 무기를 생산하던 곳입니다. 2-8인용",
                        },
                        new NameUnicode128
                        {
                            Name = $@"星盟的戰爭機器攻無不克，即使受重傷仍然相當危險。2-8 位玩家。",
                        },
                        new NameUnicode128
                        {
                        },
                        new NameUnicode128
                        {
                            Name = $@"A máquina de guerra Covenant continua sua marcha rumo à conquista; mesmo com a cabeça decepada, ainda é perigosa. 2-8 jog.",
                        },
                        new NameUnicode128
                        {
                        },
                    },
                    ImageName = $@"dlc_descent",
                    MapName = $@"descent",
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
                            Name = $@"Assembly",
                            Description = $@"The Covenant war machine continues its march to conquest; even with its head severed it is still dangerous. 2-8 players",
                            Author = $@"Bungie",
                            ContentType = BlfContentItemType.SandboxMap,
                            ContentSize = 57840,
                            Timestamp = 1132661994,
                            CampaignId = -1,
                            MapId = 490,
                            CampaignDifficulty = -1,
                        },
                        VariantVersion = 12,
                        MapId = 490,
                        WorldBounds = new RealRectangle3d(-293.1657f, 293.1989f, -187.2087f, 187.2218f, -36.73389f, 182.2966f),
                        RuntimeEngineSubType = VariantDataGameEngineSubType.All,
                        MaximumBudget = 13f,
                        SpentBudget = 0f,
                        MapVariantChecksum = 1329238095,
                        Objects = new VariantDataObjectDatum[640]
                        {
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(4.21358f, 5.09328f, -19.1385f),
                                Forward = new RealVector3d(0.134556f, -0.2519877f, 0.9583302f),
                                Up = new RealVector3d(-0.4779378f, -0.8636988f, -0.1599992f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 2,
                                Position = new RealPoint3d(-4.439008f, 5.308543f, -19.08019f),
                                Forward = new RealVector3d(-0.171005f, -0.4382037f, 0.8824595f),
                                Up = new RealVector3d(-0.8951191f, 0.4433736f, 0.04670827f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(4.384014f, -5.133564f, -19.10566f),
                                Forward = new RealVector3d(0.03635604f, 0.299111f, 0.9535255f),
                                Up = new RealVector3d(-0.8229015f, 0.5503438f, -0.1412615f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 5,
                                Position = new RealPoint3d(4.91498f, 8.116071f, -20.8779f),
                                Forward = new RealVector3d(0.9903955f, -0.1381872f, -0.004572923f),
                                Up = new RealVector3d(0.1382501f, 0.9902114f, 0.01919204f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 5,
                                Position = new RealPoint3d(-4.840192f, -7.936411f, -20.88095f),
                                Forward = new RealVector3d(0.9883836f, -0.1519729f, -0.001439714f),
                                Up = new RealVector3d(0.1519445f, 0.9883143f, -0.01215352f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 2,
                                Position = new RealPoint3d(-4.407013f, -5.246848f, -19.08407f),
                                Forward = new RealVector3d(-0.03216309f, 0.3856499f, 0.9220845f),
                                Up = new RealVector3d(0.478342f, 0.8159843f, -0.3245899f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 3,
                                Position = new RealPoint3d(-9.576681f, -11.0246f, -18.7387f),
                                Forward = new RealVector3d(-0.9485396f, -0.316289f, -0.01529907f),
                                Up = new RealVector3d(-0.3165285f, 0.9484279f, 0.0171563f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 3,
                                Position = new RealPoint3d(-9.485228f, 10.81059f, -18.70336f),
                                Forward = new RealVector3d(-0.9903203f, 0.1385221f, -0.00878404f),
                                Up = new RealVector3d(-0.1386985f, -0.9900335f, 0.02441936f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(10.4506f, 11.9432f, -18.70934f),
                                Forward = new RealVector3d(0.9988248f, -0.04842829f, -0.001902327f),
                                Up = new RealVector3d(0.04842262f, 0.9988226f, -0.002922956f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 5,
                                Position = new RealPoint3d(9.5958f, -11.99587f, -18.70962f),
                                Forward = new RealVector3d(0.9977456f, -0.06710208f, -0.0009831605f),
                                Up = new RealVector3d(0.06708694f, 0.9976844f, -0.01118726f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(4.661386f, -8.078002f, -20.8605f),
                                Forward = new RealVector3d(0.999534f, -0.03052193f, 0.0002722815f),
                                Up = new RealVector3d(0.02967511f, 0.9696369f, -0.242742f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(-2.663734f, 10.98538f, -19.02115f),
                                Forward = new RealVector3d(-0.5258973f, 0.8505261f, -0.006117319f),
                                Up = new RealVector3d(-0.8505439f, -0.5259038f, 0.0006240822f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(2.656931f, -10.95721f, -19.02254f),
                                Forward = new RealVector3d(0.8241096f, -0.5664219f, 0.003124658f),
                                Up = new RealVector3d(0.5664172f, 0.8241155f, 0.002311413f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 18,
                                Position = new RealPoint3d(2.492665f, -0.07510094f, -18.86079f),
                                Forward = new RealVector3d(-0.9998582f, 0.01628246f, -0.004298634f),
                                Up = new RealVector3d(0.01627352f, 0.9998654f, 0.002105866f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 9,
                                Position = new RealPoint3d(-2.303811f, -0.06294482f, -18.86601f),
                                Forward = new RealVector3d(0.06395848f, -0.9979524f, 0.000485003f),
                                Up = new RealVector3d(-0.9979058f, -0.06396018f, -0.009650314f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(0.03945166f, -3.754167f, -21.53988f),
                                Forward = new RealVector3d(0.9990386f, 0.04328624f, -0.00694475f),
                                Up = new RealVector3d(-0.04383111f, 0.9893824f, -0.138569f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 6,
                                Position = new RealPoint3d(0.05936906f, 3.677788f, -21.55068f),
                                Forward = new RealVector3d(0.9975126f, 0.06856252f, 0.01636367f),
                                Up = new RealVector3d(-0.07023834f, 0.9863515f, 0.14892f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 12,
                                Position = new RealPoint3d(7.911226f, -0.008722127f, -17.40884f),
                                Forward = new RealVector3d(0.06159275f, -0.9981011f, 0.0007002354f),
                                Up = new RealVector3d(-0.9867533f, -0.06099795f, -0.1503232f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 10,
                                Position = new RealPoint3d(-0.003419351f, -0.004276737f, -21.48742f),
                                Forward = new RealVector3d(0.9998206f, 0.001151799f, -0.01890535f),
                                Up = new RealVector3d(0.01891542f, -0.009470958f, 0.9997762f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 180,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(-4.875789f, 8.202827f, -20.86374f),
                                Forward = new RealVector3d(0.1162249f, -0.9932228f, -0.0004003644f),
                                Up = new RealVector3d(-0.9485111f, -0.1108733f, -0.2967048f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(2.68495f, 10.95759f, -19.01034f),
                                Forward = new RealVector3d(-0.08648351f, -0.9962509f, 0.002173305f),
                                Up = new RealVector3d(-0.008570646f, 0.002925403f, 0.999959f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 1,
                                Position = new RealPoint3d(-2.659454f, -10.7839f, -18.99074f),
                                Forward = new RealVector3d(0.1085737f, -0.994083f, 0.003274649f),
                                Up = new RealVector3d(-0.9458678f, -0.10432f, -0.3073297f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 18,
                                Position = new RealPoint3d(7.93854f, -0.07479321f, -20.86558f),
                                Forward = new RealVector3d(0.9493902f, -0.3140973f, 0.001044712f),
                                Up = new RealVector3d(0.3140953f, 0.9493574f, -0.008043157f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 90,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(10.8699f, -4.047346f, -18.94078f),
                                Forward = new RealVector3d(0.6750613f, -0.02629423f, 0.7372929f),
                                Up = new RealVector3d(-0.5891414f, -0.6207556f, 0.5172764f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 14,
                                Position = new RealPoint3d(10.89669f, 4.063461f, -18.93065f),
                                Forward = new RealVector3d(0.4327196f, 0.1948819f, 0.8802129f),
                                Up = new RealVector3d(-0.4791014f, 0.8767822f, 0.04140769f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 5,
                                Position = new RealPoint3d(9.510729f, 11.85415f, -18.6288f),
                                Forward = new RealVector3d(0.9988248f, -0.04842829f, -0.001902327f),
                                Up = new RealVector3d(0.04842262f, 0.9988226f, -0.002922956f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 13,
                                Position = new RealPoint3d(10.55856f, -11.60838f, -18.68928f),
                                Forward = new RealVector3d(0.9977456f, -0.06710208f, -0.0009831605f),
                                Up = new RealVector3d(0.06708694f, 0.9976844f, -0.01118726f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Weapon,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 54,
                                Position = new RealPoint3d(0.02969985f, 3.58462f, -16.51761f),
                                Forward = new RealVector3d(0.9718445f, 0.1510934f, 0.180801f),
                                Up = new RealVector3d(-0.1706834f, -0.07755122f, 0.9822693f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 20,
                                Position = new RealPoint3d(0.0131268f, -8.76706f, -20.9495f),
                                Forward = new RealVector3d(1f, 1.192095E-07f, 0.0001228153f),
                                Up = new RealVector3d(-0.0001228153f, -1.311303E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 23,
                                Position = new RealPoint3d(-13.04263f, 0.03584324f, -19.41911f),
                                Forward = new RealVector3d(0.9999998f, 1.897222E-07f, -0.0006697205f),
                                Up = new RealVector3d(0.0006697205f, -0.0008174471f, 0.9999994f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 20,
                                Position = new RealPoint3d(0.01409744f, 8.731469f, -20.94705f),
                                Forward = new RealVector3d(1f, 5.960509E-08f, -3.039837E-06f),
                                Up = new RealVector3d(3.039837E-06f, -3.904104E-06f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.3852279f, 6.417243f, -20.40916f),
                                Forward = new RealVector3d(0.01892402f, 0.001258105f, -0.9998202f),
                                Up = new RealVector3d(0.9995843f, 0.02173304f, 0.01894691f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-0.3955491f, 6.384241f, -20.41025f),
                                Forward = new RealVector3d(0.00564698f, 0.001068786f, -0.9999835f),
                                Up = new RealVector3d(0.9997116f, 0.02333447f, 0.005670385f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(0.3229873f, -6.37482f, -20.40909f),
                                Forward = new RealVector3d(0.003703727f, -0.001127914f, -0.9999925f),
                                Up = new RealVector3d(0.9997198f, 0.02338393f, 0.003676341f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(-0.2849866f, -6.364556f, -20.40906f),
                                Forward = new RealVector3d(0.003071285f, -0.001191348f, -0.9999946f),
                                Up = new RealVector3d(0.9997219f, 0.02338323f, 0.00304259f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(7.790357f, -1.387036f, -20.90857f),
                                Forward = new RealVector3d(-0.01990748f, 0.004065156f, -0.9997936f),
                                Up = new RealVector3d(0.9995297f, 0.02340984f, -0.01980705f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(7.627935f, 1.430339f, -20.90373f),
                                Forward = new RealVector3d(-0.04996037f, -0.01021835f, -0.9986989f),
                                Up = new RealVector3d(0.9984725f, 0.02311219f, -0.05018551f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-1.123633f, 3.332241f, -21.61959f),
                                Forward = new RealVector3d(0.9865069f, -0.1363278f, 0.09065758f),
                                Up = new RealVector3d(0.1584247f, 0.934575f, -0.3185456f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(-1.325092f, 3.241823f, -21.62086f),
                                Forward = new RealVector3d(-0.4049315f, 0.1917874f, -0.8940068f),
                                Up = new RealVector3d(0.9143369f, 0.08952957f, -0.3949335f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(1.087588f, -3.436536f, -21.60914f),
                                Forward = new RealVector3d(0.199775f, -0.1940992f, 0.9604246f),
                                Up = new RealVector3d(0.3979416f, -0.8796352f, -0.2605464f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 26,
                                Position = new RealPoint3d(1.260774f, -3.282308f, -21.61974f),
                                Forward = new RealVector3d(-0.5239653f, -0.7474984f, 0.4082971f),
                                Up = new RealVector3d(0.6802772f, -0.6557251f, -0.3274866f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(10.95075f, 10.15459f, -18.77273f),
                                Forward = new RealVector3d(-0.3756092f, -0.01503187f, -0.9266562f),
                                Up = new RealVector3d(0.9265539f, 0.01590409f, -0.3758257f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(10.9525f, 9.935792f, -18.77308f),
                                Forward = new RealVector3d(-0.3794656f, -0.009597041f, -0.9251561f),
                                Up = new RealVector3d(0.9249038f, 0.02161234f, -0.3795864f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(10.99617f, -10.2079f, -18.77378f),
                                Forward = new RealVector3d(-0.3708047f, -0.009572912f, -0.9286616f),
                                Up = new RealVector3d(0.9284086f, 0.02169216f, -0.3709272f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 21,
                                Position = new RealPoint3d(10.97278f, -9.954491f, -18.77593f),
                                Forward = new RealVector3d(-0.3313443f, 0.09807464f, -0.9383988f),
                                Up = new RealVector3d(0.9433929f, 0.05009739f, -0.3278719f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 30,
                                    SpawnTime = 15,
                                    Type = VariantDataMultiplayerObjectType.Grenade,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 24,
                                Position = new RealPoint3d(8.328954f, 0.007720884f, -19.45387f),
                                Forward = new RealVector3d(1f, -1.635134E-09f, -8.407581E-06f),
                                Up = new RealVector3d(8.407581E-06f, 2.003378E-05f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 60,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 27,
                                Position = new RealPoint3d(0.001797f, 0.000643f, -18.76812f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.Powerup,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(8.95401f, 3.198158f, -20.9559f),
                                Forward = new RealVector3d(-0.9046479f, -0.4261597f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(5.550482f, 7.693493f, -20.95588f),
                                Forward = new RealVector3d(-0.7848182f, -0.619726f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(9.028963f, -3.245719f, -20.95592f),
                                Forward = new RealVector3d(-0.9412171f, 0.3378024f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(5.399998f, -7.938587f, -20.95592f),
                                Forward = new RealVector3d(-0.6271842f, 0.778871f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-1.946537f, -9.253504f, -20.95589f),
                                Forward = new RealVector3d(-0.9699382f, 0.2433513f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-8.224411f, -4.822827f, -20.95588f),
                                Forward = new RealVector3d(0.8404036f, 0.5419611f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-8.575126f, 4.168663f, -20.95585f),
                                Forward = new RealVector3d(0.7973905f, -0.6034636f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-5.467975f, 7.828923f, -20.95585f),
                                Forward = new RealVector3d(0.6347677f, -0.772703f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(9.107242f, 7.55448f, -19.11308f),
                                Forward = new RealVector3d(-0.6540576f, -0.7564448f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-9.080892f, 7.613526f, -19.11306f),
                                Forward = new RealVector3d(0.8778229f, -0.4789854f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-8.555948f, -10.21875f, -18.81679f),
                                Forward = new RealVector3d(0.4379585f, 0.8989952f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(8.632794f, -9.989993f, -18.81678f),
                                Forward = new RealVector3d(-0.4649069f, 0.8853595f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(3.632805f, -9.844871f, -19.11306f),
                                Forward = new RealVector3d(0.4236434f, 0.9058291f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-3.626382f, -9.683695f, -19.11305f),
                                Forward = new RealVector3d(-0.3089376f, 0.9510823f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-3.693984f, 9.67524f, -19.11307f),
                                Forward = new RealVector3d(-0.3432413f, -0.9392473f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(3.907245f, 9.608904f, -19.11307f),
                                Forward = new RealVector3d(0.3082581f, -0.9513028f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(0.03002974f, 12.24267f, -19.08155f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 8f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 31,
                                Position = new RealPoint3d(0.009782395f, -12.3209f, -19.07503f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 10f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-8.411855f, 9.980876f, -18.8168f),
                                Forward = new RealVector3d(0.5138347f, -0.8578892f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(0.02550143f, 14.92044f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(0.01105198f, -15.0783f, -19.71935f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-9.123973f, -7.705155f, -19.11305f),
                                Forward = new RealVector3d(0.7800843f, 0.6256745f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(9.030231f, -7.635566f, -19.11307f),
                                Forward = new RealVector3d(-0.7386872f, 0.6740484f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(8.943614f, 10.42597f, -18.81679f),
                                Forward = new RealVector3d(-0.3747373f, -0.9271311f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 30,
                                Position = new RealPoint3d(0.02550143f, 14.92044f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 30,
                                Position = new RealPoint3d(0.01105198f, -15.0783f, -19.71935f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(2.114955f, -9.257295f, -20.95589f),
                                Forward = new RealVector3d(0.6852331f, 0.7283239f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(4.921501f, -11.38137f, -20.79773f),
                                Forward = new RealVector3d(-0.2729395f, 0.9620312f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-4.910448f, 11.25442f, -20.79775f),
                                Forward = new RealVector3d(0.4643707f, -0.8856409f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(4.894973f, 11.31367f, -20.79774f),
                                Forward = new RealVector3d(-0.5500119f, -0.8351568f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(0.9677076f, -15.18727f, -19.71935f),
                                Forward = new RealVector3d(0.009598303f, 0.9999539f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-0.9471267f, -15.2222f, -19.71935f),
                                Forward = new RealVector3d(0.03908743f, 0.9992358f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(0.5273334f, -14.58881f, -19.71935f),
                                Forward = new RealVector3d(0.009113261f, 0.9999585f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-0.5096545f, -14.56747f, -19.71935f),
                                Forward = new RealVector3d(0.06655284f, 0.9977829f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-11.43774f, -2.140892f, -20.95587f),
                                Forward = new RealVector3d(0.9458417f, 0.3246284f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-11.39055f, 2.235656f, -20.95585f),
                                Forward = new RealVector3d(0.9978618f, -0.06535874f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-9.059628f, -2.657161f, -20.95588f),
                                Forward = new RealVector3d(0.9679797f, 0.2510283f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-9.059794f, 2.652311f, -20.95586f),
                                Forward = new RealVector3d(0.9797195f, -0.2003737f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(8.003393f, 5.073195f, -20.95589f),
                                Forward = new RealVector3d(-0.7525624f, -0.6585209f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(8.036815f, -5.179663f, -20.95592f),
                                Forward = new RealVector3d(-0.8061797f, 0.5916708f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(0.03002974f, 12.24267f, -19.08155f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 8f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(0.009782395f, -12.3209f, -19.07503f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 8f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(0.02638118f, 14.91635f, -19.71874f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(0.01105198f, -15.0783f, -19.71935f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(0.01105198f, -15.0783f, -19.71935f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(0.02550143f, 14.92044f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-2.450825f, -12.10401f, -20.79758f),
                                Forward = new RealVector3d(-0.4975765f, 0.8674201f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-0.946493f, -12.45131f, -20.79758f),
                                Forward = new RealVector3d(-0.6529277f, 0.7574202f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(1.021618f, -12.38916f, -20.79758f),
                                Forward = new RealVector3d(0.6757721f, 0.7371106f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(2.604298f, -12.01593f, -20.79758f),
                                Forward = new RealVector3d(0.5442106f, 0.8389487f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-2.533185f, 12.14921f, -20.79758f),
                                Forward = new RealVector3d(-0.614836f, -0.788655f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-0.9087166f, 12.45105f, -20.79758f),
                                Forward = new RealVector3d(-0.6883218f, -0.7254055f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(1.094463f, 12.41393f, -20.79758f),
                                Forward = new RealVector3d(0.5346391f, -0.8450805f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(2.712026f, 12.05496f, -20.79757f),
                                Forward = new RealVector3d(0.5330233f, -0.8461006f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(0.02550143f, 14.92044f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(0.01105198f, -15.0783f, -19.71935f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 37,
                                Position = new RealPoint3d(0.02550143f, 14.92044f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 37,
                                Position = new RealPoint3d(0.01105198f, -15.0783f, -19.71935f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(0.009782395f, -12.3209f, -19.07503f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 10f,
                                        BoxLength = 3f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 39,
                                Position = new RealPoint3d(0.03002974f, 12.24267f, -19.08155f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 12f,
                                        BoxLength = 3f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = 1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(-7.659331f, 0.06388324f, -20.95588f),
                                Forward = new RealVector3d(0.9979537f, -0.06394004f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Infection,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 38,
                                Position = new RealPoint3d(8.404361f, 0.08412858f, -20.9559f),
                                Forward = new RealVector3d(-0.3212263f, -0.9470025f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Infection,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(0.02550143f, 14.92044f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(0.01105198f, -15.0783f, -19.71935f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(10.62537f, 3.358614f, -19.11308f),
                                Forward = new RealVector3d(-0.999994f, -0.003463889f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(10.69064f, -3.410615f, -19.11307f),
                                Forward = new RealVector3d(-0.9987877f, 0.04922489f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(1.943155f, 9.250612f, -20.9559f),
                                Forward = new RealVector3d(0.9407734f, -0.3390359f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-4.908083f, -11.41143f, -20.79773f),
                                Forward = new RealVector3d(0.2603703f, 0.9655088f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-1.93705f, 9.223246f, -20.9559f),
                                Forward = new RealVector3d(-0.7018068f, -0.7123674f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-1.102253f, 15.15244f, -19.7187f),
                                Forward = new RealVector3d(0.2300311f, -0.9731833f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(1.11184f, 15.14023f, -19.7187f),
                                Forward = new RealVector3d(-0.1118593f, -0.993724f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(9.404348f, -1.166886f, -20.68476f),
                                Forward = new RealVector3d(-0.9947005f, 0.102815f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(0.6583011f, 14.66667f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-0.6289912f, 14.67052f, -19.7187f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(-0.009877805f, 14.53622f, -19.6963f),
                                Forward = new RealVector3d(-0.08724899f, -0.9961866f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-6.512876f, -12.61847f, -19.11305f),
                                Forward = new RealVector3d(0.03916747f, 0.9992326f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(6.542106f, -12.55012f, -19.11306f),
                                Forward = new RealVector3d(0.03358693f, 0.9994358f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(6.661782f, 12.60782f, -19.11308f),
                                Forward = new RealVector3d(0.09849463f, -0.9951376f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-6.602729f, 12.64775f, -19.11307f),
                                Forward = new RealVector3d(0.2649932f, -0.9642503f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(9.42399f, 1.167921f, -20.68476f),
                                Forward = new RealVector3d(-0.9947005f, 0.102815f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(8.132728f, 4.115893f, -20.95591f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(-8.903343f, 2.849796f, -20.95591f),
                                Forward = new RealVector3d(-4.371139E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(-8.904078f, -3.022794f, -20.95589f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -0.02325184f, 0.9997296f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 33,
                                Position = new RealPoint3d(8.008976f, -4.018777f, -20.95589f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -0.02325184f, 0.9997296f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerRespawnZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 5f,
                                        NegativeHeight = -5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(7.205851f, 1.63827f, -20.95589f),
                                Forward = new RealVector3d(-0.8079582f, 0.5892398f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(7.276198f, -1.613627f, -20.95589f),
                                Forward = new RealVector3d(-0.7051309f, -0.7090772f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(9.117165f, -2.338558f, -20.95589f),
                                Forward = new RealVector3d(-0.9936861f, 0.1121964f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 29,
                                Position = new RealPoint3d(-7.659331f, 0.06388324f, -20.95588f),
                                Forward = new RealVector3d(0.9979537f, -0.06394005f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Slayer,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-9.28895f, -1.242475f, -20.95589f),
                                Forward = new RealVector3d(0.8267699f, -0.5625401f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-9.334709f, 1.160477f, -20.95589f),
                                Forward = new RealVector3d(0.804839f, 0.5934932f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-12.69827f, 1.511675f, -21.11643f),
                                Forward = new RealVector3d(0.9538023f, 0.3004351f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-12.77324f, -1.438464f, -21.11235f),
                                Forward = new RealVector3d(0.9285896f, -0.3711083f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(8.613578f, -4.00667f, -20.92539f),
                                Forward = new RealVector3d(-0.8992767f, 0.4373802f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(8.55352f, 4.04205f, -20.93947f),
                                Forward = new RealVector3d(-0.8349581f, -0.5503136f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(9.110374f, -2.323218f, -20.95594f),
                                Forward = new RealVector3d(-0.9990752f, 0.04299665f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 34,
                                Position = new RealPoint3d(-7.658844f, 0.0633664f, -20.97141f),
                                Forward = new RealVector3d(0.9979537f, -0.06394004f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(9.109912f, -2.340602f, -20.9559f),
                                Forward = new RealVector3d(-0.9989588f, 0.04562049f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 35,
                                Position = new RealPoint3d(-7.658844f, 0.0633664f, -20.97141f),
                                Forward = new RealVector3d(0.9979537f, -0.06394004f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(9.106061f, -2.335325f, -20.9559f),
                                Forward = new RealVector3d(-0.9982851f, 0.05853872f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 32,
                                Position = new RealPoint3d(-7.659331f, 0.06388324f, -20.95588f),
                                Forward = new RealVector3d(0.9979537f, -0.06394005f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(9.129114f, -2.319308f, -20.9559f),
                                Forward = new RealVector3d(-0.9999836f, 0.005725742f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Green,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 36,
                                Position = new RealPoint3d(-7.658844f, 0.0633664f, -20.97141f),
                                Forward = new RealVector3d(0.9979537f, -0.06394004f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Orange,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(4.504487f, 13.53503f, -19.11294f),
                                Forward = new RealVector3d(0.8155026f, -0.5787534f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-4.499731f, 13.57746f, -19.11291f),
                                Forward = new RealVector3d(-0.7615168f, -0.6481452f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-4.583534f, -13.46714f, -19.11264f),
                                Forward = new RealVector3d(-0.8349847f, 0.5502732f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(4.551362f, -13.5358f, -19.11281f),
                                Forward = new RealVector3d(0.8299899f, 0.5577785f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(0.02219117f, -14.68793f, -19.75112f),
                                Forward = new RealVector3d(0.9999993f, 0.001213144f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(9.831141f, 5.554221f, -19.11329f),
                                Forward = new RealVector3d(-0.8279332f, -0.5608268f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(9.668753f, -5.966091f, -19.11323f),
                                Forward = new RealVector3d(-0.8381252f, 0.545478f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(-13.46417f, -0.02230926f, -19.61584f),
                                Forward = new RealVector3d(0.9983161f, -0.05800767f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 55,
                                Position = new RealPoint3d(8.060997f, 0.01935976f, -19.69747f),
                                Forward = new RealVector3d(-0.9998321f, 0.01832565f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-8.226894f, 1.103679f, -20.95587f),
                                Forward = new RealVector3d(0.9743105f, -0.2252088f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 28,
                                Position = new RealPoint3d(-8.237045f, -1.046585f, -20.95588f),
                                Forward = new RealVector3d(0.9081809f, 0.418578f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.PlayerSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 41,
                                Position = new RealPoint3d(0.02275199f, 11.4962f, -19.11201f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(0.03002974f, 12.24267f, -19.08155f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 41,
                                Position = new RealPoint3d(0.001403324f, -11.64884f, -19.11299f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 40,
                                Position = new RealPoint3d(0.009782395f, -12.3209f, -19.07503f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-0.0408034f, -11.51656f, -20.79773f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 4f,
                                        BoxLength = 3f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-0.05795163f, 11.37809f, -20.798f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 5f,
                                        BoxLength = 3f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(0.001797f, 0.000643f, -21.98315f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.75f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(8.203335f, -0.01500605f, -17.53821f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 3f,
                                        BoxLength = 4.5f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(-12.10576f, -0.01250601f, -19.6823f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 2f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 45,
                                Position = new RealPoint3d(0.009791288f, -11.65406f, -19.11152f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Territories,
                                    Flags = VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.TerritoryArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 2.5f,
                                        BoxLength = 3f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-1.217505f, -0.05908378f, -19.73018f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(8.67877f, 0.02346538f, -20.95591f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 3f,
                                        BoxLength = 5f,
                                        PositiveHeight = 2f,
                                        NegativeHeight = -0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(0.04900253f, 10.55345f, -20.79774f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Box,
                                        WidthRadius = 5f,
                                        BoxLength = 4.5f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = -0.5f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(0.009782395f, -12.3209f, -19.07503f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 2f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(-11.84925f, 0.003141331f, -21.00431f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 2.5f,
                                        BoxLength = 0f,
                                        PositiveHeight = 3f,
                                        NegativeHeight = 2f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(9.052458f, -0.04228696f, -17.56306f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-12.10576f, -0.01250601f, -19.67087f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(-0.125273f, -11.51989f, -20.776f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 46,
                                Position = new RealPoint3d(0.03002974f, 12.24267f, -19.10358f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Oddball,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.OddballSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-0.05795163f, 11.37809f, -20.74026f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = -0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 49,
                                Position = new RealPoint3d(-0.1434986f, -11.52698f, -20.79773f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagReturnArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 1f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = -0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(0.009791229f, -11.65406f, -19.11127f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Blue,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(0.02275199f, 11.4962f, -19.11781f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(1.273027f, -0.01218808f, -21.5069f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(-1.243509f, -0.003291304f, -21.50129f),
                                Forward = new RealVector3d(1.192488E-08f, -1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(9.041156f, -0.02508489f, -17.53821f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(0.03002974f, 12.24267f, -19.08155f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(0.001797f, 0.000643f, -21.98315f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-12.09954f, -0.04081363f, -19.6251f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 51,
                                Position = new RealPoint3d(-0.1345942f, -11.52139f, -20.76713f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Juggernaut,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.JuggernautDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0.5f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(-0.1408938f, -11.52935f, -20.79774f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(-12.81666f, 0.07058223f, -21.16713f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 1,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(9.036042f, -0.03127459f, -17.53821f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 2,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(0.009782395f, -12.3209f, -19.07503f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 3.880191E-12f),
                                Up = new RealVector3d(-0.0002441406f, -1.455192E-11f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 3,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 50,
                                Position = new RealPoint3d(10.06336f, 11.28641f, -18.81679f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Vip,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 4,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.VipDestinationZone,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 0.75f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(9.87678f, 1.52122f, -16.93574f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 52,
                                Position = new RealPoint3d(9.87678f, -1.508723f, -16.9357f),
                                Forward = new RealVector3d(-4.371139E-08f, 1f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 120,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 48,
                                Position = new RealPoint3d(1.248539f, 0.002306678f, -19.75355f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.Assault,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.CtfFlagSpawnLocation,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 47,
                                Position = new RealPoint3d(0.001797f, 0.000643f, -19.67772f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.KingOfTheHill,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.KothHillArea,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 53,
                                Position = new RealPoint3d(0f, 0f, -17.68107f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, -0.01405029f, 0.9999013f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Neutral,
                                    SharedStorage = 0,
                                    SpawnTime = 30,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.Cylinder,
                                        WidthRadius = 3f,
                                        BoxLength = 0f,
                                        PositiveHeight = 1.5f,
                                        NegativeHeight = 0.1f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 56,
                                Position = new RealPoint3d(-0.6611401f, -38.7729f, -25.7527f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 56,
                                Position = new RealPoint3d(0.1944241f, -37.05298f, -25.99486f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 57,
                                Position = new RealPoint3d(1.281325f, -38.79419f, -25.79922f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 57,
                                Position = new RealPoint3d(1.874989f, -37.03986f, -26.05635f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 58,
                                Position = new RealPoint3d(3.305664f, -38.68697f, -25.8191f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 58,
                                Position = new RealPoint3d(3.729397f, -36.93089f, -26.06432f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 59,
                                Position = new RealPoint3d(5.549813f, -38.58159f, -25.89749f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 59,
                                Position = new RealPoint3d(6.233391f, -36.69049f, -26.12998f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 60,
                                Position = new RealPoint3d(7.602859f, -38.44342f, -26.10487f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 60,
                                Position = new RealPoint3d(8.462263f, -36.51089f, -26.29428f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(15.88095f, -34.11137f, -25.57323f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 61,
                                Position = new RealPoint3d(16.39382f, -31.09118f, -24.73011f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(19.15762f, -32.03904f, -25.35915f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 62,
                                Position = new RealPoint3d(18.77463f, -29.80185f, -24.77575f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(21.75448f, -30.27365f, -25.34318f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 63,
                                Position = new RealPoint3d(21.11473f, -28.07743f, -24.69083f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(23.97014f, -28.35942f, -25.25822f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 64,
                                Position = new RealPoint3d(23.04389f, -26.36005f, -24.64879f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(25.91057f, -26.29527f, -25.08516f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                                Flags = VariantDataObjectPlacementFlags.OccupiedSlot | VariantDataObjectPlacementFlags.Edited | VariantDataObjectPlacementFlags.RuntimeCandyMonitored,
                                RuntimeRemovalTimer = 0,
                                RuntimeObjectIndex = -1,
                                RuntimeEditorObjectIndex = -1,
                                QuotaIndex = 65,
                                Position = new RealPoint3d(25.03458f, -24.43456f, -24.59679f),
                                Forward = new RealVector3d(1f, 0f, 0f),
                                Up = new RealVector3d(0f, 0f, 1f),
                                ParentObject = new ObjectDataIdentifier
                                {
                                    UniqueID = new DatumHandle(65535, 65535),
                                    BspIndex = -1,
                                    Type = -1,
                                    Source = -1,
                                },
                                Properties = new VariantMultiplayerProperties
                                {
                                    EngineFlags = VariantDataGameEngineSubTypeFlags.CaptureTheFlag | VariantDataGameEngineSubTypeFlags.Slayer | VariantDataGameEngineSubTypeFlags.Oddball | VariantDataGameEngineSubTypeFlags.KingOfTheHill | VariantDataGameEngineSubTypeFlags.Juggernaut | VariantDataGameEngineSubTypeFlags.Territories | VariantDataGameEngineSubTypeFlags.Assault | VariantDataGameEngineSubTypeFlags.Vip | VariantDataGameEngineSubTypeFlags.Infection | VariantDataGameEngineSubTypeFlags.TargetTraining | VariantDataGameEngineSubTypeFlags.All,
                                    Flags = VariantDataPlacementFlags.Symmetric | VariantDataPlacementFlags.Asymmetric,
                                    Team = VariantDataMultiplayerTeamDesignator.Red,
                                    SharedStorage = 0,
                                    SpawnTime = 0,
                                    Type = VariantDataMultiplayerObjectType.Ordinary,
                                    Boundary = new MultiplayerObjectBoundary
                                    {
                                        Type = VariantDataMultiplayerObjectBoundaryShape.None,
                                        WidthRadius = 0f,
                                        BoxLength = 0f,
                                        PositiveHeight = 0f,
                                        NegativeHeight = 0f,
                                    },
                                },
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                            new VariantDataObjectDatum
                            {
                            },
                        },
                        ObjectTypeStartIndex = new short[16]
                        {
                            -1, 0, 0, 28, -1, -1, -1, 47, -1, -1, 
                            -1, 166, -1, -1, -1, 0, 
                        },
                        Quotas = new VariantDataObjectQuota[256]
                        {
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Vehicle>($@"objects\weapons\turret\plasma_cannon\plasma_cannon").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 6f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\spike_rifle\spike_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 8,
                                PlacedOnMap = 4,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\covenant_carbine\covenant_carbine").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 2,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_low\brute_shot\brute_shot").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 2,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_high\flak_cannon\flak_cannon").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 6f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\plasma_pistol\plasma_pistol").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 4,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\plasma_rifle\plasma_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 4,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\beam_rifle\beam_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\melee\energy_blade\energy_blade").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\excavator\excavator").Index,
                                MinimumCount = 0,
                                MaximumCount = 3,
                                PlacedOnMap = 1,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\melee\gravity_hammer\gravity_hammer").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\shotgun\shotgun").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\magnum\magnum").Index,
                                MinimumCount = 0,
                                MaximumCount = 6,
                                PlacedOnMap = 2,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\battle_rifle\battle_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 16,
                                PlacedOnMap = 4,
                                MaxAllowed = 16,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\rifle\sniper_rifle\sniper_rifle").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_high\rocket_launcher\rocket_launcher").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\support_high\spartan_laser\spartan_laser").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\weapons\pistol\needler\needler").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 8,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\instantcover_equipment\instantcover_equipment_mp").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\powerdrain_equipment\powerdrain_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 2,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\plasma_grenade\plasma_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 10,
                                MaxAllowed = 32,
                                Cost = 1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\claymore_grenade\claymore_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 32,
                                Cost = 1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\regenerator_equipment\regenerator_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\bubbleshield_equipment\bubbleshield_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 2,
                                PlacedOnMap = 1,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\equipment\jammer_equipment\jammer_equipment").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\weapons\grenade\frag_grenade\frag_grenade").Index,
                                MinimumCount = 0,
                                MaximumCount = 32,
                                PlacedOnMap = 4,
                                MaxAllowed = 32,
                                Cost = 1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Equipment>($@"objects\multi\powerups\powerup_blue\powerup_blue").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 1,
                                MaxAllowed = 4,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 100,
                                PlacedOnMap = 71,
                                MaxAllowed = 100,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\slayer\slayer_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\ctf\ctf_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\territories\territories_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\territories\territories_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\oddball\oddball_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\koth\koth_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\vip\vip_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\infection\infection_initial_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\assault\assault_respawn_zone").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_return_area").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\ctf\ctf_flag_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\covenant\military\cov_sword_holder\cov_sword_holder").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 3f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\covenant\military\battery\battery").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 20,
                                Cost = 4f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\covenant\military\crate_space_a\crate_space_a").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 12,
                                Cost = 2f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\territories\territory_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 12,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\oddball\oddball_ball_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\koth\koth_hill_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_spawn_point").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\assault\assault_bomb_goal_area").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 16,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\vip\vip_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 12,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\juggernaut\juggernaut_destination_static").Index,
                                MinimumCount = 0,
                                MaximumCount = 0,
                                PlacedOnMap = 0,
                                MaxAllowed = 8,
                                Cost = 0f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\gear\forerunner\power_core_for_stable\power_core_for_stable").Index,
                                MinimumCount = 0,
                                MaximumCount = 20,
                                PlacedOnMap = 4,
                                MaxAllowed = 20,
                                Cost = 4f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\levels\dlc\descent\egg_shield\egg_shield").Index,
                                MinimumCount = 0,
                                MaximumCount = 4,
                                PlacedOnMap = 1,
                                MaxAllowed = 4,
                                Cost = 4f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Weapon>($@"objects\levels\dlc\shared\forge_ball\forge_ball").Index,
                                MinimumCount = 0,
                                MaximumCount = 1,
                                PlacedOnMap = 1,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 6,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_l\box_l").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_m\box_m").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xl\box_xl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xxl\box_xxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\box_xxxl\box_xxxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_l\wall_l").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_m\wall_m").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xl\wall_xl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xxl\wall_xxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                                ObjectDefinitionIndex = GetCachedTag<Crate>($@"objects\multi\wall_xxxl\wall_xxxl").Index,
                                MinimumCount = 0,
                                MaximumCount = 255,
                                PlacedOnMap = 2,
                                MaxAllowed = 255,
                                Cost = -1f,
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                            new VariantDataObjectQuota
                            {
                            },
                        },
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